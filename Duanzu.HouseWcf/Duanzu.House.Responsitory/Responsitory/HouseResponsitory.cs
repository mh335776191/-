using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duanzu.House.DataContract.HouseModel;
using Duanzu.House.DataContract.HouseModel.BusinessModel;
using Duanzu.House.DataContract.HouseModel.DBModel;
using Duanzu.House.modelInterface.Interface;
using Duanzu.House.MyBatis;


namespace Duanzu.House.Responsitory.Responsitory
{
    public class HouseResponsitory : IResponsitory
    {
        #region IResponsitory 成员
        public int ResponsitoryAdd(IEntity entity)
        {
            var house = entity as HouseInfo;
            if (house != null)
            {
                var thouseinfo = new T_HouseInfo();
                #region T_HouseInfo 表
                thouseinfo.UserID = house.UserID;
                thouseinfo.ProvinceID = house.ProvinceID;
                thouseinfo.CityID = house.CityID;
                thouseinfo.Lat = house.Lat;
                thouseinfo.Lng = house.Lng;
                thouseinfo.AreaID = house.AreaID;
                thouseinfo.BusinessID = house.BusinessID;
                thouseinfo.Address = house.Address;
                thouseinfo.RentType = house.RentType;
                thouseinfo.HouseType = house.HouseType;
                thouseinfo.Room = house.Room;
                thouseinfo.Hall = house.Hall;
                thouseinfo.Toilet = house.Toilet;
                thouseinfo.Kitchen = house.Kitchen;
                thouseinfo.Balcony = house.Balcony;
                thouseinfo.Bed = house.Bed;
                thouseinfo.Square = house.Square;
                thouseinfo.PeopleNumber = house.PeopleNumber;
                thouseinfo.Title = house.Title;
                thouseinfo.HouseRemark = house.HouseRemark;
                thouseinfo.HousePhoto = house.HousePhoto;
                thouseinfo.RentPrice = house.RentPrice;
                thouseinfo.Contact = house.Contact;
                thouseinfo.Mobile = house.Mobile;
                thouseinfo.Status = house.Status;
                thouseinfo.PayStatus = house.PayStatus;
                thouseinfo.PayAmount = house.PayAmount;
                #endregion
                using (IBatisNet.Common.Transaction.TransactionScope scope = new IBatisNet.Common.Transaction.TransactionScope())
                {
                    var houseid = MyBatisHelper.Insert<T_HouseInfo>("AddHouse", thouseinfo);
                    if (houseid > 0)
                    {
                        #region T_HouseRentState
                        T_HouseRentState thouserentstate = new T_HouseRentState();
                        thouserentstate.HouseID = houseid;
                        thouserentstate.RentDate = house.RentDate;
                        thouserentstate.RentStatus = house.RentStatus;
                        #endregion
                        MyBatisHelper.Insert<T_HouseRentState>("AddHouseRent", thouserentstate);
                        #region T_HouseAudit
                        T_HouseAudit thouseaudit = new T_HouseAudit();
                        thouseaudit.HouseID = houseid;
                        thouseaudit.AuditState = house.AuditState;
                        thouseaudit.AuditorID = house.AuditorID;
                        thouseaudit.Auditor = house.Auditor;
                        #endregion
                        MyBatisHelper.Insert<T_HouseAudit>("AddHouseAudit", thouseaudit);
                        #region T_HouseBreach
                        T_HouseBreach thousebreach = new T_HouseBreach();
                        thousebreach.HouseID = houseid;
                        thousebreach.RentBeforeDays = house.RentBeforeDays;
                        thousebreach.DeductDays = house.DeductDays;
                        #endregion
                        MyBatisHelper.Insert<T_HouseBreach>("AddHouseBreach", thousebreach);
                        #region T_HouseAroundInfo
                        if (!string.IsNullOrWhiteSpace(house.TsString))//房源特色
                        {
                            string[] tsarr = house.TsString.Split(',');
                            foreach (string ts in tsarr)
                            {
                                T_HouseAroundInfo thousearound = new T_HouseAroundInfo();
                                thousearound.HouseID = houseid;
                                thousearound.DictID = house.DictID;
                                thousearound.Type = 1;//房源特色
                                MyBatisHelper.Insert<T_HouseAroundInfo>("AddHouseAroundInfo", thousearound);
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(house.FacilitieString))//房源配套
                        {
                            string[] facilarr = house.FacilitieString.Split(',');
                            foreach (string ts in facilarr)
                            {
                                T_HouseAroundInfo thousearound = new T_HouseAroundInfo();
                                thousearound.HouseID = houseid;
                                thousearound.DictID = house.DictID;
                                thousearound.Type = 2;//房源配套
                                MyBatisHelper.Insert<T_HouseAroundInfo>("AddHouseAroundInfo", thousearound);
                            }
                        }
                        #endregion
                        scope.Complete();
                    }
                    return houseid;
                }
            }
            ///添加到数据库
            return 0;
        }
        public int ResponsitoryEdit(IEntity entity)
        {
            var house = entity as HouseInfo;
            if (house != null)
            {
                var thouseinfo = new T_HouseInfo();
                #region T_HouseInfo 表
                thouseinfo.HouseID = house.HouseID;
                thouseinfo.UserID = house.UserID;
                thouseinfo.ProvinceID = house.ProvinceID;
                thouseinfo.CityID = house.CityID;
                thouseinfo.Lat = house.Lat;
                thouseinfo.Lng = house.Lng;
                thouseinfo.AreaID = house.AreaID;
                thouseinfo.BusinessID = house.BusinessID;
                thouseinfo.Address = house.Address;
                thouseinfo.RentType = house.RentType;
                thouseinfo.HouseType = house.HouseType;
                thouseinfo.Room = house.Room;
                thouseinfo.Hall = house.Hall;
                thouseinfo.Toilet = house.Toilet;
                thouseinfo.Kitchen = house.Kitchen;
                thouseinfo.Balcony = house.Balcony;
                thouseinfo.Bed = house.Bed;
                thouseinfo.Square = house.Square;
                thouseinfo.PeopleNumber = house.PeopleNumber;
                thouseinfo.Title = house.Title;
                thouseinfo.HouseRemark = house.HouseRemark;
                thouseinfo.HousePhoto = house.HousePhoto;
                thouseinfo.RentPrice = house.RentPrice;
                thouseinfo.Contact = house.Contact;
                thouseinfo.Mobile = house.Mobile;
                thouseinfo.Status = house.Status;
                thouseinfo.PayStatus = house.PayStatus;
                thouseinfo.PayAmount = house.PayAmount;
                #endregion
                using (IBatisNet.Common.Transaction.TransactionScope scope = new IBatisNet.Common.Transaction.TransactionScope())
                {
                    var result = MyBatisHelper.Update<T_HouseInfo>("UpdateHouseInfo", thouseinfo);
                    if (result > 0)
                    {
                        #region T_HouseRentState
                        T_HouseRentState thouserentstate = new T_HouseRentState();
                        thouserentstate.HouseID = thouseinfo.HouseID;
                        thouserentstate.RentDate = house.RentDate;
                        thouserentstate.RentStatus = house.RentStatus;
                        #endregion
                        MyBatisHelper.Update<T_HouseRentState>("UpdateHouseRent", thouserentstate);
                        #region T_HouseBreach
                        T_HouseBreach thousebreach = new T_HouseBreach();
                        thousebreach.HouseID = thouseinfo.HouseID;
                        thousebreach.RentBeforeDays = house.RentBeforeDays;
                        thousebreach.DeductDays = house.DeductDays;
                        #endregion
                        MyBatisHelper.Update<T_HouseBreach>("UpdateHouseBreach", thousebreach);
                        #region T_HouseAroundInfo 先删除，后插入
                        MyBatisHelper.Delete("DeleteHouseAroundInfo", thouseinfo.HouseID);
                        if (!string.IsNullOrWhiteSpace(house.TsString))//房源特色
                        {
                            string[] tsarr = house.TsString.Split(',');
                            foreach (string ts in tsarr)
                            {
                                T_HouseAroundInfo thousearound = new T_HouseAroundInfo();
                                thousearound.HouseID = thouseinfo.HouseID;
                                thousearound.DictID = house.DictID;
                                thousearound.Type = 1;//房源特色
                                MyBatisHelper.Insert<T_HouseAroundInfo>("AddHouseAroundInfo", thousearound);
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(house.FacilitieString))//房源配套
                        {
                            string[] facilarr = house.FacilitieString.Split(',');
                            foreach (string ts in facilarr)
                            {
                                T_HouseAroundInfo thousearound = new T_HouseAroundInfo();
                                thousearound.HouseID = thouseinfo.HouseID;
                                thousearound.DictID = house.DictID;
                                thousearound.Type = 2;//房源配套
                                MyBatisHelper.Insert<T_HouseAroundInfo>("AddHouseAroundInfo", thousearound);
                            }
                        }
                        #endregion
                        scope.Complete();
                    }
                    return result;
                }
            }
            return 0;
        }

        public int ResponsitoryDelete(int identify)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetList<T>(IEntity queryentity)
        {
            return MyBatisHelper.QueryForList<T>("SelectHouseByWhere", queryentity);
        }

        public T GetEntity<T>(IEntity queryentity)
        {
            return MyBatisHelper.Get<T>("SelectHouseByWhere", queryentity);
        }

        public T GetEntity<T>(int identify)
        {
            return MyBatisHelper.Get<T>("SelectHouseById", identify);
        }
        #endregion


    }
}
