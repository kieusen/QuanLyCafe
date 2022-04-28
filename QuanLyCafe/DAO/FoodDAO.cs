using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCafe.DTO;

namespace QuanLyCafe.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;
        public static FoodDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new FoodDAO();
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        private FoodDAO() { }

        public List<Food> GetList()
        {
            List<Food> list = new List<Food>();

            string query = $@"SELECT f.id, f.name, f.price, 
                                    f.id_category, c.name as name_cate 
                             FROM Food f 
                               INNER JOIN FoodCategory c ON (c.id = f.id_category) 
                             ORDER BY c.name, f.name ";

            DataTable result = DataProvider.Instance.FillData(query);
            foreach (DataRow item in result.Rows)
            {
                list.Add(new Food(item));
            }

            return list;
        }

        public List<Food> GetByCate(int idCate)
        {
            List<Food> list = new List<Food>();

            string query = $@"SELECT f.id, f.name, f.price, 
                                    f.id_category, c.name as name_cate
                             FROM Food f 
                               INNER JOIN FoodCategory c ON (c.id = f.id_category) 
                             WHERE id_category = {idCate}
                             ORDER BY c.name, f.name "; 

            DataTable result = DataProvider.Instance.FillData(query);
            foreach (DataRow item in result.Rows)
            {
                list.Add(new Food(item));
            }

            return list;
        }

        public int Insert(string name, int idCate, decimal price)
        {
            string query = $@"INSERT INTO Food (name, id_category, price)
                              VALUES (N'{name}', {idCate}, {price})
                              SELECT SCOPE_IDENTITY() AS Id ";

            return Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query));
        }

        public bool Update(int id, string name, int idCate, decimal price)
        {
            string query = $@"UPDATE Food 
                              SET name = N'{name}', 
                                  id_category = {idCate}, 
                                  price = {price}
                              WHERE id = {id}";

            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public bool Delete(int id)
        {
            string query = $@"DELETE FROM Food WHERE id = {id}";

            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public bool Used(int id)
        {
            string query = $@"SELECT TOP 1 id_food FROM BillInfo WHERE id_food = {id}";

            return Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query)) > 0;
        }
    }
}
