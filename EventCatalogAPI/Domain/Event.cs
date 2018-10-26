using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class Event
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public decimal Fee { get; set; }
        public string EventStartDate { get; set; }
        public string EventEndDate { get; set; }
        public string EventStartTime { get; set; }
        public string EventEndTime { get; set; }
        public string Location { get; set; }
        public string EventImageUrl { get; set; }  
        public string Created { get; set; }
        public string Address { get; set; }



        // Creating Foreign key
        public int EventCategoryId { get; set; }
        public int EventSubCatagoryId{ get; set; }
       

        public virtual Catagory Catagory { get; set; }  
        public virtual SubCatagory SubCatagory { get; set; }
       


    }
}
