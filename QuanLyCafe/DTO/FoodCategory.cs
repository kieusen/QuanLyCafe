using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DTO
{
    public class FoodCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public FoodCategory()
        {
        }

        public FoodCategory(DataRow data)
        {
            int.TryParse(data["id"].ToString(), out int id);
            Id = id;

            Name = data["name"].ToString();
        }
    }
}
