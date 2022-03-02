using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Persistence;
using Services;
using Servicess.Interfaces.Department;

namespace EntityCache.Bussines
{
    public class CustomerBussines : ICustomers
    {
        public Guid Guid { get; set; }
        public bool Status { get; set; } = true;
        public DateTime Modified { get; set; } = DateTime.Now;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string ExpireDateSh => Calendar.MiladiToShamsi(ExpireDate);
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public string Name { get; set; }
        [Display(Name = "نام مجموعه")] public string CompanyName { get; set; }
        [Display(Name = "کد ملی")] public string NationalCode { get; set; }
        [Display(Name = "سریال نرم افزار")] public string AppSerial { get; set; }
        [Display(Name = "آدرس")] public string Address { get; set; }
        [Display(Name = "کدپستی")] public string PostalCode { get; set; }
        [Display(Name = "تلفن 1")] public string Tell1 { get; set; }
        [Display(Name = "تلفن 2")] public string Tell2 { get; set; }
        [Display(Name = "تلفن 3")] public string Tell3 { get; set; }
        [Display(Name = "تلفن 4")] public string Tell4 { get; set; }
        [Display(Name = "پست الکترونیک")] public string Email { get; set; }
        [Display(Name = "توضیحات")] public string Description { get; set; }
        public DateTime ExpireDate { get; set; } = DateTime.Now.AddYears(1);
        public Guid UserGuid { get; set; }
        public decimal Account { get; set; } = 0;
        public string UserName { get; set; }
        public string Password { get; set; }
        [Display(Name = "آدرس سایت")] public string SiteUrl { get; set; }
        [Display(Name = "مشخصه فنی")] public string HardSerial { get; set; }
        public string LkSerial { get; set; }
        public bool isBlock { get; set; } = false;
        public bool isWebServiceBlock { get; set; } = false;

        public async Task<ReturnedSaveFuncInfo> SaveAsync(SqlTransaction tr = null)
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = tr == null;
            SqlConnection cn = null;
            try
            {
                if (autoTran)
                {
                    cn = new SqlConnection(Cache.ConnectionString);
                    await cn.OpenAsync();
                    tr = cn.BeginTransaction();
                }
                var cmd = new SqlCommand("sp_Customer_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", Guid);
                cmd.Parameters.AddWithValue("@st", Status);
                cmd.Parameters.AddWithValue("@name", Name ?? "");
                cmd.Parameters.AddWithValue("@createDate", CreateDate);
                cmd.Parameters.AddWithValue("@companyName", CompanyName ?? "");
                cmd.Parameters.AddWithValue("@nationalCode", NationalCode ?? "");
                cmd.Parameters.AddWithValue("@appSerial", AppSerial ?? "");
                cmd.Parameters.AddWithValue("@address", Address ?? "");
                cmd.Parameters.AddWithValue("@postalCode", PostalCode ?? "");
                cmd.Parameters.AddWithValue("@tell1", Tell1 ?? "");
                cmd.Parameters.AddWithValue("@tell2", Tell2 ?? "");
                cmd.Parameters.AddWithValue("@tell3", Tell3 ?? "");
                cmd.Parameters.AddWithValue("@tell4", Tell4 ?? "");
                cmd.Parameters.AddWithValue("@email", Email ?? "");
                cmd.Parameters.AddWithValue("@desc", Description ?? "");
                cmd.Parameters.AddWithValue("@expireDate", ExpireDate);
                cmd.Parameters.AddWithValue("@userGuid", UserGuid);
                cmd.Parameters.AddWithValue("@account", Account);
                cmd.Parameters.AddWithValue("@userName", UserName ?? "");
                cmd.Parameters.AddWithValue("@pass", Password ?? "");
                cmd.Parameters.AddWithValue("@siteUrl", SiteUrl ?? "");
                cmd.Parameters.AddWithValue("@hardSerial", HardSerial ?? "");
                cmd.Parameters.AddWithValue("@isBlock", isBlock);
                cmd.Parameters.AddWithValue("@isWebServiceBlock", isWebServiceBlock);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (autoTran)
                {
                    res.AddReturnedValue(tr.TransactionDestiny(res.HasError));
                    res.AddReturnedValue(cn.CloseConnection());
                }
            }
            return res;
        }
        public static async Task<List<CustomerBussines>> GetAllAsync()
        {
            var list = new List<CustomerBussines>();
            try
            {
                using (var cn = new SqlConnection(Cache.ConnectionString))
                {
                    using (var cmd = new SqlCommand("sp_Customer_GetAll", cn))
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
        public static async Task<CustomerBussines> GetAsync(Guid guid)
        {
            CustomerBussines item = null;
            try
            {
                using (var cn = new SqlConnection(Cache.ConnectionString))
                {
                    using (var cmd = new SqlCommand("sp_Customer_Get", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue(@"Guid", guid);
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
        private static CustomerBussines LoadData(SqlDataReader dr)
        {
            var item = new CustomerBussines();
            try
            {
                if (dr["Guid"] != DBNull.Value) item.Guid = (Guid)dr["Guid"];
                if (dr["Name"] != DBNull.Value) item.Name = dr["Name"].ToString();
                if (dr["Modified"] != DBNull.Value) item.Modified = (DateTime)dr["Modified"];
                if (dr["Status"] != DBNull.Value) item.Status = (bool)dr["Status"];
                if (dr["CreateDate"] != DBNull.Value) item.CreateDate = (DateTime)dr["CreateDate"];
                if (dr["CompanyName"] != DBNull.Value) item.CompanyName = dr["CompanyName"].ToString();
                if (dr["NationalCode"] != DBNull.Value) item.NationalCode = dr["NationalCode"].ToString();
                if (dr["AppSerial"] != DBNull.Value) item.AppSerial = dr["AppSerial"].ToString();
                if (dr["Address"] != DBNull.Value) item.Address = dr["Address"].ToString();
                if (dr["PostalCode"] != DBNull.Value) item.PostalCode = dr["PostalCode"].ToString();
                if (dr["Tell1"] != DBNull.Value) item.Tell1 = dr["Tell1"].ToString();
                if (dr["Tell2"] != DBNull.Value) item.Tell2 = dr["Tell2"].ToString();
                if (dr["Tell3"] != DBNull.Value) item.Tell3 = dr["Tell3"].ToString();
                if (dr["Tell4"] != DBNull.Value) item.Tell4 = dr["Tell4"].ToString();
                if (dr["Email"] != DBNull.Value) item.Email = dr["Email"].ToString();
                if (dr["Description"] != DBNull.Value) item.Description = dr["Description"].ToString();
                if (dr["ExpireDate"] != DBNull.Value) item.ExpireDate = (DateTime)dr["ExpireDate"];
                if (dr["UserGuid"] != DBNull.Value) item.UserGuid = (Guid)dr["UserGuid"];
                if (dr["Account"] != DBNull.Value) item.Account = (decimal)dr["Account"];
                if (dr["UserName"] != DBNull.Value) item.UserName = dr["UserName"].ToString();
                if (dr["Password"] != DBNull.Value) item.Password = dr["Password"].ToString();
                if (dr["SiteUrl"] != DBNull.Value) item.SiteUrl = dr["SiteUrl"].ToString();
                if (dr["HardSerial"] != DBNull.Value) item.HardSerial = dr["HardSerial"].ToString();
                if (dr["isBlock"] != DBNull.Value) item.isBlock = (bool)dr["isBlock"];
                if (dr["isWebServiceBlock"] != DBNull.Value) item.isWebServiceBlock = (bool)dr["isWebServiceBlock"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return item;
        }
    }
}
