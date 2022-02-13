using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Persistence;
using Services;
using Services.AndroidViewModels;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class BuildingBussines
    {
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(WebBuilding item, Guid customerGuid, SqlTransaction tr = null)
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
                res.AddReturnedValue(await SaveAsync_(item, customerGuid, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await BuildingRelatedOptionBussines.RemoveRangeAsync(item.Guid, customerGuid, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await BuildingGalleryBussines.RemoveRangeAsync(item.Guid, customerGuid, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await BuildingNoteBussines.RemoveRangeAsync(item.Guid, customerGuid, tr));
                if (res.HasError) return res;

                if (item.OptionList?.Count > 0)
                {
                    foreach (var op in item.OptionList)
                        op.BuildinGuid = item.Guid;
                    res.AddReturnedValue(await BuildingRelatedOptionBussines.SaveRangeAsync(item.OptionList, customerGuid, tr));
                    if (res.HasError) return res;
                }
                if (item.GalleryList?.Count > 0)
                {
                    foreach (var op in item.GalleryList)
                        op.BuildingGuid = item.Guid;

                    res.AddReturnedValue(await BuildingGalleryBussines.SaveRangeAsync(item.GalleryList, customerGuid, tr));
                    if (res.HasError) return res;
                }
                if (item.NoteList?.Count > 0)
                {
                    foreach (var op in item.NoteList)
                        op.BuildingGuid = item.Guid;

                    res.AddReturnedValue(await BuildingNoteBussines.SaveRangeAsync(item.NoteList, customerGuid, tr));
                    if (res.HasError) return res;
                }
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
        private static async Task<ReturnedSaveFuncInfo> SaveAsync_(WebBuilding item, Guid customerGuid, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Building_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@cusGuid", customerGuid);
                cmd.Parameters.AddWithValue("@st", item.Status);
                cmd.Parameters.AddWithValue("@ownerGuid", item.OwnerGuid);
                cmd.Parameters.AddWithValue("@modif", DateTime.Now);
                cmd.Parameters.AddWithValue("@sellPrice", item.SellPrice);
                cmd.Parameters.AddWithValue("@vamPrice", item.VamPrice);
                cmd.Parameters.AddWithValue("@qestPrice", item.QestPrice);
                cmd.Parameters.AddWithValue("@dong", item.Dang);
                cmd.Parameters.AddWithValue("@docTypeGuid", item.DocumentType);
                cmd.Parameters.AddWithValue("@tarakom", item.Tarakom);
                cmd.Parameters.AddWithValue("@rahnPrice1", item.RahnPrice1);
                cmd.Parameters.AddWithValue("@ejarePrice1", item.EjarePrice1);
                cmd.Parameters.AddWithValue("@rentalGuid", item.RentalAutorityGuid);
                cmd.Parameters.AddWithValue("@isShortTime", item.IsShortTime);
                cmd.Parameters.AddWithValue("@isOwnerHere", item.IsOwnerHere);
                cmd.Parameters.AddWithValue("@pishTotalPrice", item.PishTotalPrice);
                cmd.Parameters.AddWithValue("@pishPrice", item.PishPrice);
                cmd.Parameters.AddWithValue("@deliveryDate", item.DeliveryDate);
                cmd.Parameters.AddWithValue("@pishDesc", item.PishDesc ?? "");
                cmd.Parameters.AddWithValue("@moavezeDesc", item.MoavezeDesc ?? "");
                cmd.Parameters.AddWithValue("@mosharekatDesc", item.MosharekatDesc ?? "");
                cmd.Parameters.AddWithValue("@masahat", item.Masahat);
                cmd.Parameters.AddWithValue("@zirbana", item.ZirBana);
                cmd.Parameters.AddWithValue("@cityGuid", item.CityGuid);
                cmd.Parameters.AddWithValue("@regionGuid", item.RegionGuid);
                cmd.Parameters.AddWithValue("@address", item.Address ?? "");
                cmd.Parameters.AddWithValue("@conditionGuid", item.BuildingConditionGuid);
                if (item.Side != null)
                    cmd.Parameters.AddWithValue("@side", (int)item.Side);
                cmd.Parameters.AddWithValue("@typeGuid", item.BuildingTypeGuid);
                cmd.Parameters.AddWithValue("@shortDesc", item.ShortDesc ?? "");
                cmd.Parameters.AddWithValue("@accountTypeGuid", item.BuildingAccountTypeGuid);
                cmd.Parameters.AddWithValue("@metrazhTejari", item.MetrazhTejari);
                cmd.Parameters.AddWithValue("@viewGuid", item.BuildingViewGuid);
                cmd.Parameters.AddWithValue("@floorCoverGuid", item.FloorCoverGuid);
                cmd.Parameters.AddWithValue("@kitchenServiceGuid", item.KitchenServiceGuid);
                if (item.Water != null)
                    cmd.Parameters.AddWithValue("@water", (short)item.Water);
                if (item.Barq != null)
                    cmd.Parameters.AddWithValue("@barq", (short)item.Barq);
                if (item.Gas != null)
                    cmd.Parameters.AddWithValue("@gas", (short)item.Gas);
                if (item.Tell != null)
                    cmd.Parameters.AddWithValue("@tell", (short)item.Tell);
                cmd.Parameters.AddWithValue("@tedadTabaqe", item.TedadTabaqe);
                cmd.Parameters.AddWithValue("@tabaqeNo", item.TabaqeNo);
                cmd.Parameters.AddWithValue("@vahedPerTabaqe", item.VahedPerTabaqe);
                cmd.Parameters.AddWithValue("@metrazheKouche", item.MetrazhKouche);
                cmd.Parameters.AddWithValue("@ertefaSaqf", item.ErtefaSaqf);
                cmd.Parameters.AddWithValue("@hashie", item.Hashie);
                cmd.Parameters.AddWithValue("@saleSakht", item.SaleSakht ?? "");
                cmd.Parameters.AddWithValue("@dateParvane", item.DateParvane ?? "");
                cmd.Parameters.AddWithValue("@parvaneSerial", item.ParvaneSerial ?? "");
                cmd.Parameters.AddWithValue("@bonBast", item.BonBast);
                cmd.Parameters.AddWithValue("@mamarJoda", item.MamarJoda);
                cmd.Parameters.AddWithValue("@roomCount", item.RoomCount);
                cmd.Parameters.AddWithValue("@code", item.Code ?? "");
                cmd.Parameters.AddWithValue("@userGuid", item.UserGuid);
                cmd.Parameters.AddWithValue("@createDate", item.CreateDate);
                cmd.Parameters.AddWithValue("@image", item.Image ?? "");
                cmd.Parameters.AddWithValue("@priority", (short)item.Priority);
                cmd.Parameters.AddWithValue("@isArchive", item.IsArchive);
                cmd.Parameters.AddWithValue("@serverSt", (short)item.ServerStatus);
                cmd.Parameters.AddWithValue("@serverDate", item.ServerDeliveryDate);
                cmd.Parameters.AddWithValue("@lenght", item.Lenght);
                if (item.AdvertiseType != null)
                    cmd.Parameters.AddWithValue("@advType", (short)item.AdvertiseType);
                cmd.Parameters.AddWithValue("@divarTitle", item.DivarTitle ?? "");
                cmd.Parameters.AddWithValue("@hitting", item.Hiting ?? "");
                cmd.Parameters.AddWithValue("@colling", item.Colling ?? "");
                cmd.Parameters.AddWithValue("@tabdil", item.Tabdil);
                cmd.Parameters.AddWithValue("@reformArear", item.ReformArea);
                cmd.Parameters.AddWithValue("@buildingPermits", item.BuildingPermits);
                cmd.Parameters.AddWithValue("@widthOfPassage", item.WidthOfPassage);
                if (item.VillaType != null)
                    cmd.Parameters.AddWithValue("@villaType", (short)item.VillaType);
                if (item.CommericallLicense != null)
                    cmd.Parameters.AddWithValue("@commeriacallLicense", (short)item.CommericallLicense);
                cmd.Parameters.AddWithValue("@suitableFor", item.SuitableFor ?? "");
                cmd.Parameters.AddWithValue("@wallCovering", item.WallCovering ?? "");
                cmd.Parameters.AddWithValue("@treeCount", item.TreeCount);
                if (item.ConstructionStage != null)
                    cmd.Parameters.AddWithValue("@constructionStage", (short)item.ConstructionStage);
                if (item.Parent != null)
                    cmd.Parameters.AddWithValue("@parent", (short)item.Parent);
                cmd.Parameters.AddWithValue("@zoncanGuid", item.ZoncanGuid);
                cmd.Parameters.AddWithValue("@windowGuid", item.WindowGuid);
                cmd.Parameters.AddWithValue("@vahedNo", item.VahedNo);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
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
                    item.CreateDate = (DateTime)dr["CreateDate"];
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
