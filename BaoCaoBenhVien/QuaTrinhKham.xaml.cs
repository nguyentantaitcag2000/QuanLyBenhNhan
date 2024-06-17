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
using System.Windows.Shapes;

namespace BaoCaoBenhVien
{
    /// <summary>
    /// Interaction logic for QuaTrinhKham.xaml
    /// </summary>
    public partial class QuaTrinhKham : Window
    {
        public static QuaTrinhKham W = new QuaTrinhKham();
        public static bool isOpen;
        public QuaTrinhKham()
        {
            InitializeComponent();
            W = this;
        }
        public ObservableCollection<ModelQuaTrinhKham> SelectedItems_MainDG()
        {
            ObservableCollection<ModelQuaTrinhKham> l = new ObservableCollection<ModelQuaTrinhKham>();
            Application.Current.Dispatcher.Invoke((Action)delegate
            {

                if (DataGrid_Main.SelectedItems.Count != 0)
                {
                    Application.Current.Dispatcher.Invoke(async () =>
                    {

                        foreach (ModelQuaTrinhKham item in DataGrid_Main.SelectedItems)
                        {
                            l.Add(item);
                        }

                    });
                    while (l.Count == 0)
                    {
                        Thread.Sleep(100);
                    }
                }


            });

            return l;


        }

        private void DataGrid_Main_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var info = QuaTrinhKham.W.SelectedItems_MainDG();
            if (info.Count > 1)
            {
                MessageBox.Show("Chỉ chọn 1 bệnh nhân !!");
                return;
            }
            if(info.Count>0)
            {
                
                TEXT_Huongdieutri.Text = info[0].Huongdieutri;
                Text_Ngayhen.Text = info[0].Ngayhen;
                Text_Ngaykham.Text = info[0].Ngaykham;
                Text_Noidunghen.Text = info[0].Noidunghen;
                TEXT_BacSiKham.Text = info[0].Doctor;
            }
         



        }

        private void Window_Closed(object sender, EventArgs e)
        {
            isOpen = false;
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            
            isOpen = true;

        }
    }
}
