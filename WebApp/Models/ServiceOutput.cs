using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Properties
    {
        public int HLTH_CHSA_SYSID { get; set; }
        public string CMNTY_HLTH_SERV_AREA_CODE { get; set; }
        public string CMNTY_HLTH_SERV_AREA_NAME { get; set; }
        public int OBJECTID { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public string id { get; set; }
        public object geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class ServiceOutput
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
        public int totalFeatures { get; set; }
        public int numberMatched { get; set; }
        public int numberReturned { get; set; }
        public DateTime timeStamp { get; set; }
        public object crs { get; set; }
    }
}