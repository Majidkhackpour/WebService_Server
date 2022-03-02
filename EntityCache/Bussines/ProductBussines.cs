using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.ViewModels;
using Persistence;
using Services;
using Servicess.Interfaces.Department;

namespace EntityCache.Bussines
{
    public class ProductBussines : IProduct
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public decimal BckUpPrice { get; set; }
        public string Unit { get; set; }


        public static async Task<List<ProductBussines>> GetAllAsync()
        {
            var list = new List<ProductBussines>();
            try
            {
                using (var cn = new SqlConnection(Cache.ConnectionString))
                {
                    using (var cmd = new SqlCommand("sp_Product_GetAll", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        await cn.OpenAsync();
                        using (var dr = await cmd.ExecuteReaderAsync())
                        {
                            while (dr.Read())
                                list.Add(LoadData(dr));

                            dr.Close();
                        }
                    }

                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return list;
        }
        public static async Task<ProductBussines> GetAsync(string code)
        {
            ProductBussines item = null;
            try
            {
                using (var cn = new SqlConnection(Cache.ConnectionString))
                {
                    using (var cmd = new SqlCommand("sp_Product_GetByCode", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue(@"Code", code);
                        await cn.OpenAsync();
                        using (var dr = await cmd.ExecuteReaderAsync())
                        {
                            if (dr.Read())
                                item = LoadData(dr);

                            dr.Close();
                        }
                    }

                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return item;
        }
        public static List<ProductGardeshViewModel> GetGardesh(Guid prdGuid)
        {
            var list = new List<ProductGardeshViewModel>();
            try
            {
                using (var cn = new SqlConnection(Cache.ConnectionString))
                {
                    var cmd = new SqlCommand("sp_Product_Gardesh", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@prdGuid", prdGuid);
                    cn.Open();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read()) list.Add(LoadDataGardesh(dr));
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list?.OrderByDescending(q => q.DateM)?.ToList();
        }
        private static ProductGardeshViewModel LoadDataGardesh(SqlDataReader dr)
        {
            try
            {
                var item = new ProductGardeshViewModel();
                if (dr["DateM"] != DBNull.Value) item.DateM = (DateTime)dr["DateM"];
                if (dr["OrderGuid"] != DBNull.Value) item.OrderGuid = (Guid)dr["OrderGuid"];
                if (dr["ContractCode"] != DBNull.Value) item.ContractCode = dr["ContractCode"].ToString();
                if (dr["CustomerName"] != DBNull.Value) item.CustomerName = dr["CustomerName"].ToString();
                if (dr["CompanyName"] != DBNull.Value) item.CompanyName = dr["CompanyName"].ToString();
                if (dr["Count"] != DBNull.Value) item.Count = (int)dr["Count"];
                if (dr["Price"] != DBNull.Value) item.Price = (decimal)dr["Price"];
                if (dr["Discount"] != DBNull.Value) item.Discount = (decimal)dr["Discount"];
                if (dr["TotalPrice"] != DBNull.Value) item.TotalPrice = (decimal)dr["TotalPrice"];
                return item;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        private static ProductBussines LoadData(SqlDataReader dr)
        {
            var item = new ProductBussines();
            try
            {
                if (dr["Guid"] != DBNull.Value) item.Guid = (Guid)dr["Guid"];
                if (dr["Name"] != DBNull.Value) item.Name = dr["Name"].ToString();
                if (dr["Modified"] != DBNull.Value) item.Modified = (DateTime)dr["Modified"];
                if (dr["Status"] != DBNull.Value) item.Status = (bool)dr["Status"];
                if (dr["Code"] != DBNull.Value) item.Code = dr["Code"].ToString();
                if (dr["Price"] != DBNull.Value) item.Price = (decimal)dr["Price"];
                if (dr["BckUpPrice"] != DBNull.Value) item.BckUpPrice = (decimal)dr["BckUpPrice"];
                if (dr["Unit"] != DBNull.Value) item.Unit = dr["Unit"].ToString();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return item;
        }
    }
}
