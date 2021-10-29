using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Persistence;
using Services;
using Services.AndroidViewModels;

namespace EntityCache.Bussines
{
    public class BuildingBussines
    {
        public static List<BuildingListViewModel> GetAllBuildingListViewModel(Guid customerGuid, EnRequestType type)
        {
            var list = new List<BuildingListViewModel>();
            try
            {
                using (var cn = new SqlConnection(Cache.ConnectionString))
                {
                    var cmd = new SqlCommand("sp_Buildings_GetBuildingListViewModel", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@cusGuid", customerGuid);
                    cmd.Parameters.AddWithValue("@buType", (short)type);

                    cn.Open();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read()) list.Add(LoadData(dr));
                    dr.Close();
                    cn.Close();
                }

                list = list?.OrderByDescending(q => q.CreateDate)?.Take(100).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return list;
        }
        private static BuildingListViewModel LoadData(SqlDataReader dr)
        {
            try
            {
                var parent = EnBuildingParent.None;
                string type = "", ownerTell = "", ownerTellTitle = "", relatedNumber = "";

                var item = new BuildingListViewModel();
                if (dr["Guid"] != DBNull.Value) item.Guid = (Guid)dr["Guid"];
                if (dr["ImageName"] != DBNull.Value) item.ImageName = dr["ImageName"].ToString();
                if (dr["Masahat"] != DBNull.Value) item.Metrazh = $"{dr["Masahat"]} متر";
                if (dr["ZirBana"] != DBNull.Value) item.ZirBana = $"{dr["ZirBana"]} متر";
                if (dr["Address"] != DBNull.Value) item.Address = dr["Address"].ToString();
                if (dr["SaleSakht"] != DBNull.Value) item.SaleSakht = dr["SaleSakht"].ToString();
                if (dr["SellPrice"] != DBNull.Value) item.SellPrice = $"{dr["SellPrice"]:N0} تومان";
                if (dr["RoomCount"] != DBNull.Value)
                {
                    var roomCount = (int)dr["RoomCount"];
                    item.RoomCount = roomCount > 0 ? $"{roomCount} خواب" : "بدون خواب";
                }
                if (dr["PishPrice"] != DBNull.Value) item.PishPrice = $"{dr["PishPrice"]:N0} تومان";
                if (dr["TabaqeNo"] != DBNull.Value && dr["TedadTabaqe"] != DBNull.Value)
                {
                    var tabaqeNo = (int)dr["TabaqeNo"];
                    var tabaqeCount = (int)dr["TedadTabaqe"];
                    if (tabaqeNo > 0 && tabaqeCount > 0) item.TabaqeCount = $"طبقه {tabaqeNo} از {tabaqeNo}";
                    else if (tabaqeNo > 0 && tabaqeCount > 0) item.TabaqeCount = $"طبقه {tabaqeNo}";
                    else item.TabaqeCount = "یک طبقه";
                }
                if (dr["PishTotalPrice"] != DBNull.Value) item.PishTotalPrice = $"{dr["PishTotalPrice"]:N0} تومان";
                if (dr["CreateDate"] != DBNull.Value)
                {
                    item.Date = ((DateTime)dr["CreateDate"]).GetTelegramDate();
                    item.CreateDate = (DateTime) dr["CreateDate"];
                }
                if (dr["EjarePrice"] != DBNull.Value) item.EjarePrice = $"{dr["EjarePrice"]:N0} تومان";
                if (dr["RahnPrice"] != DBNull.Value) item.EjarePrice = $"{dr["RahnPrice"]:N0} تومان";
                if (dr["Parent"] != DBNull.Value) parent = (EnBuildingParent)dr["Parent"];
                if (dr["Type"] != DBNull.Value) type = dr["Type"].ToString();
                if (dr["OwnerName"] != DBNull.Value) item.OwnerName = dr["OwnerName"].ToString();
                if (dr["OwnerAddress"] != DBNull.Value) item.OwnerAddress = dr["OwnerAddress"].ToString();
                if (dr["OwnerTellTitle"] != DBNull.Value) ownerTellTitle = dr["OwnerTellTitle"].ToString();
                if (dr["OwnerTell"] != DBNull.Value) ownerTell = dr["OwnerTell"].ToString();
                if (dr["RelatedNumber"] != DBNull.Value) relatedNumber = dr["RelatedNumber"].ToString();
                item.Type = parent == EnBuildingParent.None ? type : parent.GetDisplay();
                if (!string.IsNullOrEmpty(relatedNumber)) item.OwnerTell = $"دریافت شده: {relatedNumber}";
                else if (!string.IsNullOrEmpty(ownerTell))
                    item.OwnerTell = !string.IsNullOrEmpty(ownerTellTitle)
                        ? $"{ownerTellTitle}: {ownerTell}"
                        : ownerTell;
                else item.OwnerTell = "شماره مالک یافت نشد";
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
