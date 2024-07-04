using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureData.Furniture_Data
{
    public  class RestaurantTableEntity
    {
        [Key]
        public int  Id  { get; set; }
        public string ResName { get; set; }
        public string ResType { get; set; }
    }
}
