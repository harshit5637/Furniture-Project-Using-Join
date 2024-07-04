using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureData.Furniture_Data
{
    public class FurnitureTableEntity
    {
       
        public int   Id { get; set; }
     
        public string FurName { get; set; }
        public string FurType { get; set; }
        public int ResId { get; set; }

    }
}
