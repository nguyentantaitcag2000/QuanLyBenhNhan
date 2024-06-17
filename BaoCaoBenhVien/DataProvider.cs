using Dapper;
using MyF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyF.Model
{
    public class DataProvider
    {
        public static string TextError_UNIQUE = "UNIQUE constraint failed";
        public static void Execute(string cmd)
        {
            using(IDbConnection con = new SQLiteConnection(GetConnectionString()))
            {
                try
                {
                    con.Query<InfoAccount>(cmd, new DynamicParameters());
                    
                }
                catch (Exception e)
                {
                    if (!e.Message.Contains("duplicate column name"))//Lỗi add column đã tồn tại => bỏ qua
                    MessageBox.Show("Không execute \nDataProvider/Execute: " + e.Message);
                    List<InfoAccount> a = new List<InfoAccount>();
                }
            }    
        }
        public static List<InfoAccount> ExecuteAndReturn(string cmd)
        {
            using (IDbConnection con = new SQLiteConnection(GetConnectionString()))
            {
                try
                {
                    var output = con.Query<InfoAccount>(cmd, new DynamicParameters());
                    return output.ToList();
                }
                catch (Exception e)
                {
                    if (!e.Message.Contains("duplicate column name"))//Lỗi add column đã tồn tại => bỏ qua
                        MessageBox.Show("Không execute \nDataProvider/Execute: " + e.Message);
                    List<InfoAccount> a = new List<InfoAccount>();
                    return a;
                }
            }
        }
        #region InfoAccount Table
        public static InfoAccount GetAccount(string UID)
        {
            using (IDbConnection con = new SQLiteConnection(GetConnectionString()))
            {
                
                try
                {
                    var output = con.Query<InfoAccount>("select * from InfoAccount Where ID = '" + UID + "'", new DynamicParameters());

                    return output.ToList().FirstOrDefault();
                }
                catch (Exception e)
                {

                    MessageBox.Show("Không get được \nDataProvider/GetAccount: " + e.Message);
                    return null;
                }
            }
        


        }
     
        public static InfoAccount GetAccountByPackageName(string packageName)
        {
            using (IDbConnection con = new SQLiteConnection(GetConnectionString()))
            {

                try
                {
                    var output = con.Query<InfoAccount>("select * from InfoAccount Where PackageName = '" + packageName + "'", new DynamicParameters());

                    return output.ToList().FirstOrDefault();
                }
                catch (Exception e)
                {

                    MessageBox.Show("Không get được \nDataProvider/GetAccount: " + e.Message);
                    List<InfoAccount> a = new List<InfoAccount>();
                    return a.FirstOrDefault();
                }
            }



        }
        public static InfoAccount GetAccountHaveEmail(string email)
        {
            using (IDbConnection con = new SQLiteConnection(GetConnectionString()))
            {
                try
                {
                    var output = con.Query<InfoAccount>("select * from InfoAccount Where Email = '" + email + "'", new DynamicParameters());

                    return output.ToList().FirstOrDefault();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Không get được \nDataProvider/GetAccountHaveEmail: " + e.Message);
                    List<InfoAccount> a = new List<InfoAccount>();
                    return a.FirstOrDefault();
                }
            }



        }
        public static List<InfoAccount> GetAllAccount()
        {
                using (IDbConnection con = new SQLiteConnection(GetConnectionString()))
                {
                    try
                    {
                        var output = con.Query<InfoAccount>("select * from InfoAccount", new DynamicParameters());

                        return output.ToList();
                    }
                    catch (Exception e)
                    {
                         MessageBox.Show(e.Message);
                        List<InfoAccount> a = new List<InfoAccount>();
                        return a;

                    }
                }

            
           
            
           
        }
        public static List<InfoAccount> GetAllCheckPointAccount(string category)
        {
            using (IDbConnection con = new SQLiteConnection(GetConnectionString()))
            {
                try
                {
                    var output = con.Query<InfoAccount>("SELECT * FROM InfoAccount WHERE Category = '" + category + "' AND Status LIKE '%CheckPoint%'", new DynamicParameters());

                    return output.ToList();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Không get được \nDataProvider/GetAllAccount: " + e.Message);
                    List<InfoAccount> a = new List<InfoAccount>();
                    return a;

                }
            }





        }

        public static List<InfoAccount> GetAccounts(int start = 1, int max = 500)
        {
            using (IDbConnection con = new SQLiteConnection(GetConnectionString()))
            {

                try
                {
                    var output = con.Query<InfoAccount>($"SELECT * FROM InfoAccount limit {--start}, {max}", new DynamicParameters()); //` -- get "max" records beginning with row "start"

                    return output.ToList();
                }
                catch (Exception e)
                {

                    MessageBox.Show("Không get được \nDataProvider/GetAccount: " + e.Message);
                    List<InfoAccount> a = new List<InfoAccount>();
                    return a;
                }
            }



        }
        public static string AddAccount(InfoAccount acc)
        {


            using (IDbConnection con = new SQLiteConnection(GetConnectionString()))
            {
                try
                {
                    con.Execute("insert into InfoAccount (ID,Hotenchong,Hotenvo,Ngayhen,Ngaykham,Huongdieutri,NSC,NSV,SDTC,SDTV,Noidunghen,Diachi,M,FM,SoHoSo,BacSiTheoDoi) values (@ID,@Hotenchong,@Hotenvo,@Ngayhen,@Ngaykham,@Huongdieutri,@NSC,@NSV,@SDTC,@SDTV,@Noidunghen,@Diachi,@M,@FM,@SoHoSo,@BacSiTheoDoi)", acc);
                    return "1";
                }
                catch (Exception e)
                {
                    if (e.Message.Contains(TextError_UNIQUE))
                    {
                        MessageBox.Show("Hồ sơ của bệnh nhân này có FM hoặc M đã tồn tại trong danh sách !");
                        return "0";
                    }
                    else
                    {
                        MessageBox.Show("DataProvider/AddAccount " + e.Message);
                        return "0";
                    }

                }
            }



        }
        public static void UpdateAccount(InfoAccount acc)
        {


            using (IDbConnection con = new SQLiteConnection(GetConnectionString()))
            {
                try
                {
                    con.Execute("UPDATE InfoAccount SET  BacSiTheoDoi = '" + acc.BacSiTheoDoi + "', SoHoSo = '" + acc.SoHoSo + "', FM = '" + acc.FM + "',  M = '" + acc.M + "', Diachi = '" + acc.Diachi + "', Noidunghen = '" + acc.Noidunghen + "', Huongdieutri = '" + acc.Huongdieutri + "', NSC = '" + acc.NSC + "', NSV = '" + acc.NSV + "',SDTC = '" + acc.SDTC + "', SDTV = '" + acc.SDTV + "', Hotenchong = '" + acc.Hotenchong + "', Hotenvo = '" + acc.Hotenvo + "', Ngayhen = '" + acc.Ngayhen + "',Ngaykham = '" + acc.Ngaykham + "' WHERE ID = '" + acc.ID + "'");

                }
                catch (Exception e)
                {

                    MessageBox.Show("DataProvider/UpdateAccount : " + e.Message);

                }
            }

        }
        public static void UpdateUID(string oldUID,string  newUID){
           using (IDbConnection con = new SQLiteConnection(GetConnectionString()))
                {
                    try
                    {
                        con.Execute("UPDATE InfoAccount SET UID = '" + newUID + "' WHERE UID = '" + oldUID + "'");

                    }
                    catch (Exception e)
                    {

                        MessageBox.Show("DataProvider/UpdateUID : "+e.Message);

                    }
                }
        
        }
        public static void DeleteAccount(InfoAccount acc)
        {

            using (IDbConnection con = new SQLiteConnection(GetConnectionString()))
            {
                try
                {
                    con.Execute("DELETE FROM InfoAccount WHERE ID = '" + acc.ID + "'");

                }
                catch (Exception e)
                {

                    MessageBox.Show("Không reset được \nDataProvider/Reset: " + e.Message);

                }
            }

        }

        public static string GetConnectionString(string id="Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        #endregion

   
        public static string GetUserData()
        {
            using (IDbConnection con = new SQLiteConnection(GetConnectionString()))
            {
                try
                {
                    var output = con.Query<string>("select * from User", new DynamicParameters());

                    return output.ToList().FirstOrDefault();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Không get được \nDataProvider/GetUserData: " + e.Message);
                    List<string> a = new List<string>();
                    return a.FirstOrDefault();
                }
            }


        }
        public static void Reset()
        {

            using (IDbConnection con = new SQLiteConnection(GetConnectionString()))
            {
                try
                {
                    con.Execute("DELETE FROM InfoAccount");
                    con.Execute("DELETE FROM Category");
                }
                catch (Exception e)
                {

                    MessageBox.Show("Không reset được \nDataProvider/Reset: " + e.Message);

                }
            }


        }
    }
}
