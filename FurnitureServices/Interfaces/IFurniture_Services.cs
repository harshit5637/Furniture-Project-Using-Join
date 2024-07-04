using FurnitureData.Furniture_Data;
using FurnitureModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureServices.Interfaces
{
    public interface IFurniture_Services
    {
        public Furniture_Model AddFurniture(Furniture_Model fur);
        public string DeleteBy(int id);

        public Furniture_Model Updatejoin(Furniture_Model furniture_model);

        public string DeleteMultiple(List<int> ids);


       // public FurnitureTableEntity GetFurnitureById(int id);

        //public List<FurnitureTableEntity> GetFurniture();
        //public FurnitureTableEntity PutFurniture(int id, FurnitureTableEntity  tur);
        // public string DeleteEmployeeById(int id);
    }
}
