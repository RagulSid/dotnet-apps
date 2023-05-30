using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBackend.Models
{
    public class Hotel
    {
        public long id { get; set; }
        public string hotelName { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public string rating { get; set; }
        public string review { get; set; }
        public string hotel_image { get; set; }
        public string image { get; set; }
    }
}