using BaoCaoBenhVien.Viewmodel;
using Dapper;
using MyF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BaoCaoBenhVien
{
    /// <summary>
    /// Interaction logic for DanhSachBenhNhan.xaml
    /// </summary>
    public partial class DanhSachBenhNhan : Window
    {
        public static bool isOpen;
        public static DanhSachBenhNhan W = new DanhSachBenhNhan();
        public DanhSachBenhNhan()
        {
            InitializeComponent();
            W = this;
        }
        private bool Fillter(object item)
        {
            string text = TB_thongtin.Text.Trim();
            if (string.IsNullOrEmpty(text))
            {
                return true;
            }
            else
            {
                try
                {
                    return ((item as Main_InfoAccount).MY_INFO_ACCOUNT.Hotenchong.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    ((item as Main_InfoAccount).MY_INFO_ACCOUNT.Hotenvo.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    ((item as Main_InfoAccount).MY_INFO_ACCOUNT.SoHoSo.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0);



                }
                catch { }



            }
            return false;
        }
        private void BTN_TIM_Click(object sender, RoutedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(DataGrid_Main.ItemsSource).Refresh();

            ObservableCollection<Main_InfoAccount> allAccount = new ObservableCollection<Main_InfoAccount>();
            int STT = 1;
            foreach (var item in DataProvider.GetAllAccount())
            {
                allAccount.Add(new Main_InfoAccount() { MY_INFO_ACCOUNT = item, STT = STT++ });
            }

            DanhSachBenhNhanViewmodel.W.InfoAccounts = allAccount;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(DataGrid_Main.ItemsSource);
            if (view != null)
            {

                view.Filter = Fillter;

            }
            
        }

        private void TB_thongtin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(TB_thongtin.Text=="")
            {
                BTN_TIM_Click(sender,e);
            }
        }

        private void TB_Tongso_TextChanged(object sender, TextChangedEventArgs e)
        {
            int length = TB_Tongso.Text.ToString().Length;
            if (length > 0)
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"[^\d]");
                System.Text.RegularExpressions.Match match = regex.Match(TB_Tongso.Text);
                if (match.ToString() != "")
                {
                    TB_Tongso.Text = TB_Tongso.Text.ToString().Remove(length - 1);
                    TB_Tongso.Select(TB_Tongso.Text.Length, 0);
                }
                try
                {
                    if (TB_Tongso.Text[0].ToString() == "0")
                    {
                        TB_Tongso.Text = TB_Tongso.Text.ToString().Remove(0);

                    }
                }
                catch { }

                

            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            isOpen = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            isOpen = true ;

        }
    }
}
