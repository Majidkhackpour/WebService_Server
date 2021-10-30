using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using EntityCache.ViewModels;
using Persistence;
using Services;

namespace EntityCache.Bussines
{
    public class ProductBussines
    {
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
                    while (dr.Read()) list.Add(LoadData(dr));
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
        private static ProductGardeshViewModel LoadData(SqlDataReader dr)
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
    }
}
