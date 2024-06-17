using Dapper;
using MyF.Model;
using MyF.ViewModel;
using MyFs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace BaoCaoBenhVien.Viewmodel
{
    public class MainViewModel: BaseViewModel
    {
        private ObservableCollection<InfoAccount> _infoAccounts = new ObservableCollection<InfoAccount>();
        public ObservableCollection<InfoAccount> InfoAccounts
        {
            get { return _infoAccounts; }
            set
            {
                _infoAccounts = value;
                OnPropertyChanged();

            }
        }
        public ICommand Add_Command { get; set; }
        public static ICommand UpdateUI_Command { get; set; }
        public static ICommand Edit_Command { get; set; }
        public static ICommand Clear_Command { get; set; }
        public static ICommand Delete_Command { get; set; }
        public static ICommand DanhSachBenhNhan_Command { get; set; }
        public static ICommand QuaTrinhKham_Command { get; set; }
        public MainViewModel()
        {
            UpdateUI_Command = new RelayCommand<InfoAccount>(x => { return true; }, x => {
                var acc = InfoAccounts.Where(r => r.ID == x.ID).SingleOrDefault();
                try
                {
                    acc = x;
                    Application.Current.Dispatcher.Invoke((Action)delegate {

                        try
                        {
                            CollectionViewSource.GetDefaultView(InfoAccounts).Refresh();

                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show("UpdateUI: " + ee.Message);

                        }
                    });
                }
                catch (Exception e){
                }
            });
            QuaTrinhKham_Command = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
               
                QuaTrinhKham quaTrinhKham = new QuaTrinhKham();
                if(!QuaTrinhKham.isOpen)
                {
                    using (IDbConnection con = new SQLiteConnection(DataProvider.GetConnectionString()))
                    {

                        try
                        {
                            var output = con.Query<InfoAccount>("select * from InfoAccount Where FM = '" + MainWindow.W.TEXT_FM.Text + "' OR M = '" + MainWindow.W.TEXT_M.Text + "'", new DynamicParameters());

                            if (output.Count() == 0)
                            {
                                MessageBox.Show("Không có bệnh nhân này !!! Hãy ghi thông tin của bênh nhân và thêm vào rồi thử lại");
                                QuaTrinhKham.isOpen = false;
                                return;
                            }
                        }
                        catch (Exception e)
                        {
                            QuaTrinhKham.isOpen = false;
                            MessageBox.Show("Không có bệnh nhân này !!! Hãy ghi thông tin của bênh nhân và thêm vào rồi thử lại");
                            return;
                        }
                    }
                    quaTrinhKham.Show();
                }
                
            });
            DanhSachBenhNhan_Command = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                DanhSachBenhNhan danhSachBenhNhan = new DanhSachBenhNhan();
                if(!DanhSachBenhNhan.isOpen)
                    danhSachBenhNhan.Show();
            });
            Clear_Command = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {

                MainWindow.W.TEXT_Husband.Text = "";
                MainWindow.W.TEXT_Wife.Text = "";
                MainWindow.W.TEXT_PhoneHusband.Text = "";
                MainWindow.W.Text_PhoneWife.Text = "";
                MainWindow.W.Text_NSHusband.Text = "";
                MainWindow.W.Text_NSWife.Text = "";
                MainWindow.W.Text_Address.Text = "";
                MainWindow.W.TEXT_BacSiTheoDoi.Text = "";


            });
            Edit_Command = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                MessageBoxResult r = MessageBox.Show("Bạn có thật sự muốn cập nhật bệnh nhân này !", "Lưu ý !", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (r == MessageBoxResult.Yes)
                {
                    InfoAccount acc = new InfoAccount();
                    using (IDbConnection con = new SQLiteConnection(DataProvider.GetConnectionString()))
                    {

                        try
                        {
                            var output = con.Query<InfoAccount>($"select * from InfoAccount Where M = '{MainWindow.W.TEXT_M.Text}' OR FM = '{MainWindow.W.TEXT_FM.Text}'", new DynamicParameters());

                            acc = output.ToList().FirstOrDefault();
                            if (acc == null)
                            {
                                MessageBox.Show("Không có bệnh nhân này !!! Hãy ghi thông tin của bênh nhân và thêm vào rồi thử lại");
                                return;
                            }
                        }
                        catch (Exception e)
                        {

                            MessageBox.Show("Không có bệnh nhân này !!! Hãy ghi thông tin của bênh nhân và thêm vào rồi thử lại");
                            return;
                        }
                    }
                    acc.SoHoSo = MainWindow.W.TEXT_CODE.Text.Trim();
                    acc.FM = MainWindow.W.TEXT_FM.Text.Trim();
                    acc.M = MainWindow.W.TEXT_M.Text.Trim();
                    acc.Hotenchong = MainWindow.W.TEXT_Husband.Text.Trim();
                    acc.Hotenvo = MainWindow.W.TEXT_Wife.Text.Trim();
                    acc.SDTC = MainWindow.W.TEXT_PhoneHusband.Text.Trim();
                    acc.SDTV = MainWindow.W.Text_PhoneWife.Text.Trim();
                    acc.NSC = MainWindow.W.Text_NSHusband.Text.Trim();
                    acc.NSV = MainWindow.W.Text_NSWife.Text.Trim();
                    acc.Diachi = MainWindow.W.Text_Address.Text;
                    acc.BacSiTheoDoi = MainWindow.W.TEXT_BacSiTheoDoi.Text;



                    DataProvider.UpdateAccount(acc);
                    MessageBox.Show("Đã cập nhật !");


                }
                  
            });
            Delete_Command = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                MessageBoxResult r = MessageBox.Show("Bạn có thật sự muốn xoá bệnh nhân này !", "Lưu ý !", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if(r == MessageBoxResult.Yes)
                {
                    InfoAccount acc = new InfoAccount();
                    using (IDbConnection con = new SQLiteConnection(DataProvider.GetConnectionString()))
                    {

                        try
                        {
                            var output = con.Query<InfoAccount>($"select * from InfoAccount Where M = '{MainWindow.W.TEXT_M.Text}' OR FM = '{MainWindow.W.TEXT_FM.Text}'", new DynamicParameters());

                            acc = output.ToList().FirstOrDefault();
                            if (acc == null)
                            {
                                MessageBox.Show("Không có bệnh nhân này !!! Hãy ghi thông tin của bênh nhân và thêm vào rồi thử lại");
                                return;
                            }
                        }
                        catch (Exception e)
                        {

                            MessageBox.Show("Không có bệnh nhân này !!! Hãy ghi thông tin của bênh nhân và thêm vào rồi thử lại");
                            return;
                        }
                    }

                    DataProvider.DeleteAccount(acc);
                    MainWindow.W.TEXT_Husband.Text = "";
                    MainWindow.W.TEXT_Wife.Text = "";
                    MainWindow.W.TEXT_PhoneHusband.Text = "";
                    MainWindow.W.Text_PhoneWife.Text = "";
                    MainWindow.W.Text_NSHusband.Text = "";
                    MainWindow.W.Text_NSWife.Text = "";
                    MainWindow.W.Text_Address.Text = "";
                    MainWindow.W.TEXT_FM.Text = "";
                    MainWindow.W.TEXT_M.Text = "";
                    MainWindow.W.TEXT_CODE.Text = "";
                    MainWindow.W.TEXT_BacSiTheoDoi.Text = "";
                    MessageBox.Show("Đã xoá");
                }
                
            });
            Add_Command = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                InfoAccount acc = new InfoAccount();
                acc.ID = "BN" +  Global.RandomStringNumber(6);
                string husband = MainWindow.W.TEXT_Husband.Text.Trim();
                string wife = MainWindow.W.TEXT_Wife.Text.Trim();
                string phoneH = MainWindow.W.TEXT_PhoneHusband.Text.Trim();
                string phoneW = MainWindow.W.Text_PhoneWife.Text.Trim();
                string NSH = MainWindow.W.Text_NSHusband.Text.Trim();
                string NSW = MainWindow.W.Text_NSWife.Text.Trim();
                string diachi = MainWindow.W.Text_Address.Text.Trim();
                string FM = MainWindow.W.TEXT_FM.Text.Trim();
                string M = MainWindow.W.TEXT_M.Text.Trim();
                string SoHoSo = MainWindow.W.TEXT_CODE.Text.Trim();
                string BSTD = MainWindow.W.TEXT_BacSiTheoDoi.Text.Trim();
                if
                (
                MainWindow.W.TEXT_Husband.Text.Trim() == "" ||
                MainWindow.W.TEXT_Wife.Text.Trim() == ""
                )
                {
                    MessageBox.Show("Vui lòng nhập họ tên vợ và vợ tên chồng");
                    return;
                }
                if
              (
                MainWindow.W.TEXT_FM.Text == ""||
                MainWindow.W.TEXT_M.Text == "" 
              )
                {
                    MessageBox.Show("Vui lòng nhập đủ FM và M");
                    return;
                }

                acc.Hotenchong = husband;
                acc.Hotenvo = wife;
                acc.SDTC = phoneH;
                acc.SDTV = phoneW;
                acc.NSC = NSH;
                acc.NSV = NSW;
                acc.Diachi = diachi;
                acc.FM = FM;
                acc.M = M;
                acc.SoHoSo = SoHoSo;
                acc.BacSiTheoDoi = BSTD;


                if (DataProvider.AddAccount(acc)=="1")
                    MessageBox.Show("Thêm thành công !");
                MainWindow.W.TEXT_Husband.Text = "";
                MainWindow.W.TEXT_Wife.Text = "";
                MainWindow.W.TEXT_PhoneHusband.Text = "";
                MainWindow.W.Text_PhoneWife.Text = "";
                MainWindow.W.Text_NSHusband.Text = "";
                MainWindow.W.Text_NSWife.Text = "";
                MainWindow.W.Text_Address.Text = "";
            });

        }
       
    }
}
