using Dapper;
using MyF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BaoCaoBenhVien
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static MainWindow W = new MainWindow();

        public MainWindow()
        {
            InitializeComponent();
            W = this;
        }
       
        private void Window_Closed(object sender, EventArgs e)
        {
            App.Current.Shutdown();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void TEXT_CODE_LostFocus(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() => {
                InfoAccount acc = new InfoAccount();

                using (IDbConnection con = new SQLiteConnection(DataProvider.GetConnectionString()))
                {

                    try
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate {
                            var output = con.Query<InfoAccount>($"select * from InfoAccount Where SoHoSo = '{MainWindow.W.TEXT_CODE.Text}'", new DynamicParameters());
                            acc = output.ToList().FirstOrDefault();

                        });

                    }
                    catch (Exception eee)
                    {
                        return;
                    }
                }
                if (acc == null)
                {
                    return;
                }

                Application.Current.Dispatcher.Invoke((Action)delegate {
                    TEXT_FM.Text = acc.FM;
                    TEXT_M.Text = acc.M;
                    TEXT_Husband.Text = acc.Hotenchong;
                    TEXT_Wife.Text = acc.Hotenvo;
                    TEXT_PhoneHusband.Text = acc.SDTC;
                    Text_PhoneWife.Text = acc.SDTV;
                    Text_NSHusband.Text = acc.NSC;
                    Text_NSWife.Text = acc.NSV;
                    Text_Address.Text = acc.Diachi;
                    TEXT_BacSiTheoDoi.Text = acc.BacSiTheoDoi;
                });

            });
        }

        private void TEXT_M_LostFocus(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() => {
                InfoAccount acc = new InfoAccount();

                using (IDbConnection con = new SQLiteConnection(DataProvider.GetConnectionString()))
                {

                    try
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate {
                            var output = con.Query<InfoAccount>($"select * from InfoAccount Where M = '{MainWindow.W.TEXT_M.Text}'", new DynamicParameters());
                            acc = output.ToList().FirstOrDefault();

                        });

                    }
                    catch (Exception eee)
                    {
                        return;
                    }
                }
                if (acc == null)
                {
                    return;
                }
                Application.Current.Dispatcher.Invoke((Action)delegate {
                    TEXT_FM.Text = acc.FM;
                    TEXT_CODE.Text = acc.SoHoSo;
                    TEXT_Husband.Text = acc.Hotenchong;
                    TEXT_Wife.Text = acc.Hotenvo;
                    TEXT_PhoneHusband.Text = acc.SDTC;
                    Text_PhoneWife.Text = acc.SDTV;
                    Text_NSHusband.Text = acc.NSC;
                    Text_NSWife.Text = acc.NSV;
                    Text_Address.Text = acc.Diachi;
                    TEXT_BacSiTheoDoi.Text = acc.BacSiTheoDoi;

                });

            });
        }

        private void TEXT_FM_LostFocus(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() => {
                InfoAccount acc = new InfoAccount();

                using (IDbConnection con = new SQLiteConnection(DataProvider.GetConnectionString()))
                {

                    try
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate {
                            var output = con.Query<InfoAccount>($"select * from InfoAccount Where FM = '{MainWindow.W.TEXT_FM.Text}'", new DynamicParameters());
                            acc = output.ToList().FirstOrDefault();

                        });

                    }
                    catch (Exception eee)
                    {
                        return;
                    }
                }
                if(acc==null)
                {
                    return;
                }
                Application.Current.Dispatcher.Invoke((Action)delegate {
                    TEXT_M.Text = acc.M;
                    TEXT_CODE.Text = acc.SoHoSo;
                    TEXT_Husband.Text = acc.Hotenchong;
                    TEXT_Wife.Text = acc.Hotenvo;
                    TEXT_PhoneHusband.Text = acc.SDTC;
                    Text_PhoneWife.Text = acc.SDTV;
                    Text_NSHusband.Text = acc.NSC;
                    Text_NSWife.Text = acc.NSV;
                    Text_Address.Text = acc.Diachi;
                    TEXT_BacSiTheoDoi.Text = acc.BacSiTheoDoi;

                });

            });
        }
    }
}
