using System;
using System.Collections.Generic;
using Persistence.Entities;
using Services;

namespace EntityCache.Assistence
{
    public static class DefaultProducts
    {
        private static List<Product> list = new List<Product>();
        private static Product SetDef(string name, string code, decimal backPrice, decimal price, string unit)
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
                    Price = price,
                    Unit = unit
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
                list.Add(SetDef("نرم افزار اتوماسیون املاک آراد", "36", 12000000, 140000000,"نسخه"));
                list.Add(SetDef("زیربسته ارسال پیامک", "97", 3000000, 10000000, "نسخه"));
                list.Add(SetDef("زیربسته ارسال آگهی تبلیغاتی", "72", 12000000, 40000000, "نسخه"));
                list.Add(SetDef("زیربسته ربات تلگرام", "44", 3000000, 10000000, "نسخه"));
                list.Add(SetDef("زیربسته ربات واتساپ", "32", 3000000, 10000000, "نسخه"));
                list.Add(SetDef("زیربسته پشتیبان گیری خودکار", "87", 1500000, 5000000, "نسخه"));
                list.Add(SetDef("زیربسته ارتباط با اکسل", "25", 2400000, 8000000, "نسخه"));
                list.Add(SetDef("زیربسته سایت مرتبط با نرم افزار", "68", 12000000, 40000000, "نسخه"));
                list.Add(SetDef("زیربسته اپلیکیشن اندروید", "53", 3000000, 10000000, "نسخه"));
                list.Add(SetDef("زیربسته ارتباط با شبکه", "62", 4500000, 15000000, "نسخه"));
                list.Add(SetDef("زیربسته حسابداری", "50", 4500000, 15000000, "نسخه"));
                list.Add(SetDef("وب سرویس-هاست", "91", 1200000, 40000000, "نسخه"));

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
