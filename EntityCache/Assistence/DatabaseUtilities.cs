using Services;
using System;
using System.Data;
using System.Data.SqlClient;

namespace EntityCache.Assistence
{
    public class DatabaseUtilities
    {
        public static ReturnedSaveFuncInfo Run(string script, SqlConnection cn)
        {
            var ret = new ReturnedSaveFuncInfo();
            try
            {
                if (string.IsNullOrEmpty(script)) return ret;

                string[] seperator = { "go\r", "go\r\n", "\ngo\n", "\ngo\r\n", "\tgo\t", " go ", "\rgo\r" };
                script = script.Replace("GO", "go").Replace("Go", "go").Replace("gO", "go");
                var scripts = script.Split(seperator, StringSplitOptions.RemoveEmptyEntries);

                var cmd = new SqlCommand("", cn)
                {
                    CommandTimeout = 60 * 1000 * 2,//2دقیقه
                    CommandType = CommandType.Text
                };
                if (cn.State != ConnectionState.Open) cn.Open();

                foreach (var item in scripts)
                    ret.AddReturnedValue(Execute(item, cmd));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                ret.AddReturnedValue(ex);
            }

            return ret;
        }
        private static ReturnedSaveFuncInfo Execute(string item, SqlCommand cmd)
        {
            var ret = new ReturnedSaveFuncInfo();
            try
            {
                cmd.CommandText = item;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex, "error in command " + item ?? "");
                ret.AddReturnedValue(ReturnedState.Error, $"{ex.Message}\r\nQuery:\r\n{item}");
            }

            return ret;
        }
    }
}
