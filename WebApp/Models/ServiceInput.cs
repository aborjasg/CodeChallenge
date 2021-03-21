using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class ServiceInput
    {
        [Key]
        public int Id { get; set; }
        public string service { get; set; }
        public string version { get; set; }
        public string request { get; set; }
        public string typeName { get; set; }
        public string srsname { get; set; }
        public string cql_filter { 
            get { 
                return "INTERSECTS(SHAPE,SRID=4326;POINT(" + this.longitude.Trim() + this.latitude.Trim() + "))"; 
            }  
        }
        public string propertyName { get; set; }
        public string outpuFormat { get; set; }

        [Required]
        public string latitude { get; set; }

        [Required]
        public string longitude { get; set; }

        public string result { get; set; }


        public ServiceInput()
        {
            this.Id = 0;
            this.service = "WFS";
            this.version = "1.0.0";
            this.request = "GetFeature";
            this.typeName = "pub:WHSE_ADMIN_BOUNDARIES.BCHA_CMNTY_HEALTH_SERV_AREA_SP";
            this.srsname = "EPSG:4326";
            this.propertyName = "CMNTY_HLTH_SERV_AREA_CODE,CMNTY_HLTH_SERV_AREA_NAME";
            this.outpuFormat = "application/json";
            this.result = "";
        }

        public void setPoint (string latitude, string longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}