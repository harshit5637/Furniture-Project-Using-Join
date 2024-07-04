using FurnitureModel;
using FurnitureData.Furniture_Data;
using FurnitureModel.Model;
using FurnitureServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FurnitureData;

namespace FurnitureServices.Implementation
{
    public class Furniture_Services:IFurniture_Services
    {
        private readonly ApplicationDbContext _context;
        public Furniture_Services(ApplicationDbContext context)
        {
            _context = context;
        }
        public Furniture_Model AddFurniture(Furniture_Model fur)
        {
            FurnitureTableEntity FT = new FurnitureTableEntity();
            RestaurantTableEntity RT= new RestaurantTableEntity();

            FT.Id = fur.Id;
            FT.FurName = fur.FurName;
            FT.FurType = fur.FurType;

         
            RT.ResName = fur.ResName;
            RT.ResType = fur.ResType;
            _context.RestrauntTable.Add(RT);
            _context.SaveChanges();
            
            FT.ResId=RT.Id;
            _context.Furniture.Add(FT);
            _context.SaveChanges();
            return fur;
        }


        // deleted by using joins 
        public string DeleteBy(int id)
        {
            // Attempt to find a Furniture record with the given id
            var delete = _context.Furniture.FirstOrDefault(d => d.Id == id);

            // Check if such a Furniture record exists
            if (delete != null)
            {
                // Attempt to find a RestrauntTable record with the same id
                 var never = _context.RestrauntTable.FirstOrDefault(d => d.Id == id);
                // If a RestrauntTable record with the given id is found, remove it from the context
                _context.RestrauntTable.Remove(never);
                _context.SaveChanges();
            }
            // Remove the Furniture record from the context
            _context.Furniture.Remove(delete);
            _context.SaveChanges();
            // Return a string message indicating the operation was performed
            return "DeleteIT";
        }
        // update by using join
        public Furniture_Model Updatejoin(Furniture_Model furniture_model)
        {
            
            var changeFurniture = _context.Furniture.FirstOrDefault(d => d.Id == furniture_model.Id);

            if (changeFurniture != null)
            {
                
                changeFurniture.FurName = furniture_model.FurName;
                changeFurniture.FurType = furniture_model.FurType;
                changeFurniture.ResId = furniture_model.Id; 
            }
            else
            {
                throw new InvalidOperationException($"Furniture with Id {furniture_model.Id} not found");
            }

            
            var changeRestrauntTable = _context.RestrauntTable.FirstOrDefault(d => d.Id == furniture_model.Id);

            if (changeRestrauntTable != null)
            {
                
                changeRestrauntTable.ResName = furniture_model.ResName;
                changeRestrauntTable.ResType = furniture_model.ResType;
            }
            else
            {
                throw new InvalidOperationException($"RestrauntTable with Id {furniture_model.Id} not found");
            }

            
            _context.SaveChanges();

            return furniture_model;
        }

        //MultipleDelete

       // This C# method is designed to delete multiple records from two different tables
       // (Furniture and RestrauntTable) in a database using Entity Framework (EF).
       // It takes a list of int IDs as input and iterates through each ID to attempt deletion from both tables
        public string DeleteMultiple(List<int> ids)
        {
            // Iterate through each ID in the provided list
            foreach (int id in ids)
            {
                // Attempt to find a Furniture record with the current id
                var furnitureToDelete = _context.Furniture.FirstOrDefault(f => f.Id == id);
                // If a Furniture record with the current id is found, remove it from the context
                if (furnitureToDelete != null)
                {
                    _context.Furniture.Remove(furnitureToDelete);
                    _context.SaveChanges();
                }

                // Attempt to find a RestrauntTable record with the current id
                var restaurantTableToDelete = _context.RestrauntTable.FirstOrDefault(rt => rt.Id == id);
                // If a RestrauntTable record with the current id is found, remove it from the context
                if (restaurantTableToDelete != null)
                {
                    _context.RestrauntTable.Remove(restaurantTableToDelete);
                    _context.SaveChanges();
                }
            }

            return $"Deleted {ids.Count} items.";
        }































        //    public FurnitureTableEntity GetFurnitureById(int id)
        //    {
        //        var har= _context.Furniture.FirstOrDefault(f => f.Id == id);

        //        _context.SaveChanges();
        //        return har;
        //    }

        //    public List<FurnitureTableEntity> GetFurniture()
        //    {
        //        var har=_context.Furniture.ToList();
        //        return har;
        //    }

        //    public FurnitureTableEntity PutFurniture(int id, FurnitureTableEntity tur)
        //    {
        //        var har = _context.Furniture.FirstOrDefault(i=>i.Id == id);
        //        har.FurName = tur.FurName;
        //        har.FurType = tur.FurType;
        //        har.ResId = tur.ResId;
        //        _context.SaveChanges();
        //        return har;
        //    }
    }
}
