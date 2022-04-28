using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCafe.DTO;

namespace QuanLyCafe.DAO
{
    public class FoodCategoryDAO
    {
        private static FoodCategoryDAO instance;
        public static FoodCategoryDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new FoodCategoryDAO();
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        private FoodCategoryDAO() { }
        public List<FoodCategory> GetList()
        {
            List<FoodCategory> list = new List<FoodCategory>();

            string query = "SELECT * FROM FoodCategory ORDER BY name ";

            DataTable result = DataProvider.Instance.FillData(query);
            foreach (DataRow item in result.Rows)
            {
                list.Add(new FoodCategory(item));
            }

            return list;
        }

        public DataTable GetTable()
        {           
            string query = "SELECT * FROM FoodCategory ORDER BY name ";
            return DataProvider.Instance.FillData(query);
        }
        public int InsertOrUpdate(int idCate, string nameCate)
        {
            string query = "EXEC USP_FoodCategory_InsertOrUpdate @id , @name ";
            return (int) DataProvider.Instance.ExecuteScalar(query, new object[] {idCate, nameCate});
        }
        public int Delete(int idCate)
        {
            string query = " EXEC USP_FoodCategory_Delete @id ";
            var result = DataProvider.Instance.ExecuteScalar(query, new object[] {idCate});
            return Convert.ToInt32(result);
        }
    }
}
