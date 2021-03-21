﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Net.Http;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private Models.AuditModel db = new Models.AuditModel();
        /*
        public ActionResult Index()
        {
            return View();
        }*/

        public enum ServiceResult : int
        {
            OK=1,
            NONE=0,
            ERR=-1
        }

        public ActionResult Index(Models.ServiceInput model)
        {
            var res = ServiceResult.NONE;
            string message = "";

            try
            {
                if (ModelState.IsValid)
                {
                    //model.latitude = "+48.4251378";
                    //model.longitude = "-123.3646335";

                    if (!string.IsNullOrEmpty(model.latitude) && !string.IsNullOrEmpty(model.longitude))
                    {
                        message = model.result = getServiceResponse(model);
                        res = ServiceResult.OK;

                        // Event Log:
                        db.EventLogs.Add(new Models.EventLog() { vAction = "GET", vInput = model.cql_filter, vOutput = message, iResult = (int)res, dProcessTimestamp = DateTime.UtcNow, vClientInfo = "" });
                        db.SaveChanges();
                    }
                    else
                    {
                        model.result = "";
                    }
                }
            }
            catch(Exception ex)
            {
                message = ex.Message;
                res = ServiceResult.ERR;

                // Event Log:
                db.EventLogs.Add(new Models.EventLog() { vAction = "GET", vInput = model.cql_filter, vOutput = message, iResult = (int)res, dProcessTimestamp = DateTime.UtcNow, vClientInfo = "" });
                db.SaveChanges();
            }

            return View("Index", model);
        }

        private string getServiceResponse(Models.ServiceInput model)
        {
            try
            {
                string uriApi = ConfigurationManager.AppSettings["ServiceEndpoint"] + ConfigurationManager.AppSettings["ServiceResource"];
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync(uriApi + string.Format("?service={0}&version={1}&request={2}&typeName={3}&srsname={4}&cql_filter={5}&propertyName={6}&outputFormat={7}", model.service, model.version, model.request, model.typeName, model.srsname, model.cql_filter, model.propertyName, model.outpuFormat)).Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = (response.Content.ReadAsStringAsync()).Result;
                    Models.ServiceOutput result = JsonConvert.DeserializeObject<Models.ServiceOutput>(jsonData);

                    foreach (var item in result.features)
                    {
                        if (item.properties != null)
                        {
                            return item.properties.CMNTY_HLTH_SERV_AREA_NAME;
                        }
                    }
                    throw new Exception("[!] Invalid data structure!");
                }
                else
                {
                    throw new Exception("[!] Wrong Response!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "[!] Error";
            }
           
        }

    }
}