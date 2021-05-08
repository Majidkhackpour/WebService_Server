using System;
using System.Collections.Generic;
using Persistence.Entities;
using Services;

namespace EntityCache.Assistence
{
    public static class DefaultProducts
    {
        private static List<Product> list = new List<Product>();
        private static Product SetDef(string name, string code, decimal backPrice, decimal price)
        {
            try
            {
                var reg = new Product()
                {
                    Guid = Guid.NewGuid(),
                    Name = name,
                    Modified = DateTime.Now,
                    Status = true,
                    Code = code,
                    BckUpPrice = backPrice,
                    Price = price
                };
                return reg;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public static List<Product> SetDef()
        {
            try
            {
                list.Add(SetDef("نرم افزار اتوماسیون املاک آراد", "36", 0, 0));
                list.Add(SetDef("زیربسته ارسال پیامک", "97", 0, 0));
                list.Add(SetDef("زیربسته ارسال آگهی تبلیغاتی", "72", 0, 0));
                list.Add(SetDef("زیربسته ربات تلگرام", "44", 0, 0));
                list.Add(SetDef("زیربسته ربات واتساپ", "32", 0, 0));
                list.Add(SetDef("زیربسته پشتیبان گیری خودکار", "87", 0, 0));
                list.Add(SetDef("زیربسته ارتباط با اکسل", "25", 0, 0));
                list.Add(SetDef("زیربسته سایت مرتبط با نرم افزار", "68", 0, 0));
                list.Add(SetDef("زیربسته اپلیکیشن اندروید", "53", 0, 0));
                list.Add(SetDef("زیربسته ارتباط با شبکه", "62", 0, 0));
                list.Add(SetDef("زیربسته حسابداری", "50", 0, 0));

                return list;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
    }
}
