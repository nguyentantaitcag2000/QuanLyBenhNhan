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
    public class QuaTrinhKhanViewModel:BaseViewModel
    {
        private ObservableCollection<ModelQuaTrinhKham> _infoAccounts = new ObservableCollection<ModelQuaTrinhKham>();
        public ObservableCollection<ModelQuaTrinhKham> InfoAccounts
        {
            get { return _infoAccounts; }
            set
            {
                _infoAccounts = value;
                OnPropertyChanged();

            }
        }

        public ICommand LoadedWindow_Command { get; set; }
        public ICommand ClosedWindow_Command { get; set; }
        public ICommand Add_Command { get; set; }
        public static ICommand UpdateUI_Command { get; set; }
        public static ICommand Edit_Command { get; set; }
        public static ICommand Clear_Command { get; set; }
        public static ICommand Delete_Command { get; set; }
        public static ICommand DanhSachBenhNhan_Command { get; set; }
        public static ICommand QuaTrinhKham_Command { get; set; }
        public QuaTrinhKhanViewModel()
        {
            UpdateUI_Command = new RelayCommand<ModelQuaTrinhKham>(x => { return true; }, x => {
                var acc = InfoAccounts.Where(r => r.IDquatrinh == x.IDquatrinh).SingleOrDefault();
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
                catch (Exception e)
                {
                }
            });
            Clear_Command = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                QuaTrinhKham.W.Text_Ngayhen.Text = "";
                QuaTrinhKham.W.Text_Ngaykham.Text = "";
                QuaTrinhKham.W.Text_Noidunghen.Text = "";
                QuaTrinhKham.W.TEXT_Huongdieutri.Text = "";
                QuaTrinhKham.W.TEXT_BacSiKham.Text = "";


            });
            Edit_Command = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                if (InfoAccounts.Count == 0)
                {
                    MessageBox.Show("Bệnh nhân này chưa có quá trình để sửa");
                    return;
                }
                if (QuaTrinhKham.W.SelectedItems_MainDG().Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn 1 quá trình để sửa");
                    return;
                }
                MessageBoxResult r = MessageBox.Show("Bạn có thật sự muốn cập nhật quá trình này !", "Lưu ý !", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (r == MessageBoxResult.Yes)
                {
                    var info = QuaTrinhKham.W.SelectedItems_MainDG();
                    if (info.Count > 1)
                    {
                        MessageBox.Show("Chỉ chọn 1 quá trình khám !!");
                        return;
                    }
                    if (info.Count > 0)
                    {

                        string ngayhen = QuaTrinhKham.W.Text_Ngayhen.Text.Trim();
                        string ngaykham = QuaTrinhKham.W.Text_Ngaykham.Text.Trim();
                        string noidunghen = QuaTrinhKham.W.Text_Noidunghen.Text.Trim();
                        string dieutri = QuaTrinhKham.W.TEXT_Huongdieutri.Text;
                        string doctor = QuaTrinhKham.W.TEXT_BacSiKham.Text;

                        using (IDbConnection con = new SQLiteConnection(DataProvider.GetConnectionString()))
                        {
                            try
                            {
                                con.Execute("UPDATE QuaTrinhKham SET Doctor = '" + doctor + "', Ngaykham = '" + ngaykham + "', Ngayhen = '" + ngayhen + "',  Noidunghen = '" + noidunghen + "', Huongdieutri = '" + dieutri + "' WHERE IDquatrinh = '" + info[0].IDquatrinh + "'");

                            }
                            catch (Exception e)
                            {

                                MessageBox.Show("DataProvider/UpdateAccount : " + e.Message);

                            }
                        }
                        LoadedListAccount();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn 1 quá trình khám");
                    }

                }
                   
                
            });
            Delete_Command = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                if(InfoAccounts.Count == 0)
                {
                    MessageBox.Show("Bệnh nhân này chưa có quá trình để xoá");
                    return;
                }
                if (QuaTrinhKham.W.SelectedItems_MainDG().Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn 1 quá trình để xoá");
                    return;
                }
                MessageBoxResult r = MessageBox.Show("Bạn có thật sự muốn xoá quá trình này !", "Lưu ý !", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (r == MessageBoxResult.Yes)
                {
                    foreach (var item in QuaTrinhKham.W.SelectedItems_MainDG())
                    {
                        InfoAccounts.Remove(item);
                        using (IDbConnection con = new SQLiteConnection(DataProvider.GetConnectionString()))
                        {
                            try
                            {
                                con.Execute("DELETE FROM QuaTrinhKham WHERE IDquatrinh = '" + item.IDquatrinh + "' AND FM = '" + item.FM + "'");

                            }
                            catch (Exception e)
                            {

                                MessageBox.Show("Không delete được \nDataProvider/Reset: " + e.Message);

                            }
                        }
                        InfoAccounts.Remove(item);
                    }

                    CollectionViewSource.GetDefaultView(InfoAccounts).Refresh();
                }
                   
            });
            Add_Command = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                ModelQuaTrinhKham qt = new ModelQuaTrinhKham();
                InfoAccount acc = new InfoAccount();
                using (IDbConnection con = new SQLiteConnection(DataProvider.GetConnectionString()))
                {

                    try
                    {
                        var output = con.Query<InfoAccount>($"select * from InfoAccount Where M = '{MainWindow.W.TEXT_M.Text}' OR FM = '{MainWindow.W.TEXT_FM.Text}'", new DynamicParameters());

                        acc = output.ToList().FirstOrDefault();
                    }
                    catch (Exception e)
                    {

                        MessageBox.Show("Không get được \nDataProvider/GetAccount: " + e.Message);
                        acc = null;
                    }
                }
                string idQuaTrinh = Global.RandomStringNumber(6);
                string ngayhen = QuaTrinhKham.W.Text_Ngayhen.Text.Trim();
                string ngaykham = QuaTrinhKham.W.Text_Ngaykham.Text.Trim();
                string noidunghen = QuaTrinhKham.W.Text_Noidunghen.Text.Trim();
                string dieutri = QuaTrinhKham.W.TEXT_Huongdieutri.Text;
                string doctor = QuaTrinhKham.W.TEXT_BacSiKham.Text;

                if (ngayhen == "" || ngaykham == "")
                {
                    MessageBox.Show("Vui lòng nhập đủ Ngày hẹn và Ngày khám");
                    return;
                }
                acc.Ngayhen = ngayhen;
                acc.Ngaykham = ngaykham;
                acc.Noidunghen = noidunghen;
                acc.Huongdieutri = dieutri;

                qt.FM = acc.FM;
                qt.M = acc.M;
                qt.IDquatrinh = idQuaTrinh;
                qt.Ngayhen = acc.Ngayhen;
                qt.Ngaykham = acc.Ngaykham;
                qt.Noidunghen = acc.Noidunghen;
                qt.Huongdieutri = acc.Huongdieutri;
                qt.Doctor = doctor;
                using (IDbConnection con = new SQLiteConnection(DataProvider.GetConnectionString()))
                {
                    try
                    {
                        con.Execute("insert into QuaTrinhKham (Doctor,FM,M,IDquatrinh,Ngayhen,Ngaykham,Huongdieutri,Noidunghen) values (@Doctor,@FM,@M,@IDquatrinh,@Ngayhen,@Ngaykham,@Huongdieutri,@Noidunghen)", qt);
                    }
                    catch (Exception e)
                    {
                        if (e.Message.Contains(DataProvider.TextError_UNIQUE))
                        {
                            MessageBox.Show(acc.ID + " đã tồn tại");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("DataProvider/AddAccount " + e.Message);
                            return;
                        }

                    }
                }
                InfoAccounts.Add(new ModelQuaTrinhKham() {Doctor = doctor,IDquatrinh = idQuaTrinh, FM = acc.FM,M = acc.M,  Huongdieutri = acc.Huongdieutri,  Ngayhen = acc.Ngayhen, Ngaykham = acc.Ngaykham, Noidunghen = acc.Noidunghen});
                CollectionViewSource.GetDefaultView(InfoAccounts).Refresh();
                MessageBox.Show("Thêm thành công");
                Global.RandomStringNumber(6);
                QuaTrinhKham.W.Text_Ngayhen.Text = "";
                QuaTrinhKham.W.Text_Ngaykham.Text = "";
                QuaTrinhKham.W.Text_Noidunghen.Text = "";
                QuaTrinhKham.W.TEXT_Huongdieutri.Text = "";

            });
            LoadedWindow_Command = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                QuaTrinhKham.W.Text_Ngayhen.Text = "";
                QuaTrinhKham.W.Text_Ngaykham.Text = "";
                QuaTrinhKham.W.Text_Noidunghen.Text = "";
                QuaTrinhKham.W.TEXT_Huongdieutri.Text = "";
                LoadedListAccount();
            });
            ClosedWindow_Command = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                QuaTrinhKham.W.TEXT_Huongdieutri.Text = "";
                QuaTrinhKham.W.Text_Ngayhen.Text = "";
                QuaTrinhKham.W.Text_Ngaykham.Text = "";
                QuaTrinhKham.W.Text_Noidunghen.Text = "";
                InfoAccounts.Clear();
            });
        }
        async public void LoadedListAccount()
        {

            List<ModelQuaTrinhKham> listInfoAccount = new List<ModelQuaTrinhKham>();

            using (IDbConnection con = new SQLiteConnection(DataProvider.GetConnectionString()))
            {

                try
                {
                    var output = con.Query<ModelQuaTrinhKham>($"select * from QuaTrinhKham Where FM = '{MainWindow.W.TEXT_FM.Text}' OR M = '{MainWindow.W.TEXT_M.Text}'", new DynamicParameters());

                    listInfoAccount = output.ToList();
                }
                catch (Exception e)
                {
                }
            }
            if (listInfoAccount.Count > 0)
            {
                try
                {
                    InfoAccounts.Clear();

                }
                catch (Exception e)
                {
                    if (!e.Message.Contains("This type of CollectionView does not support changes to its SourceCollection from a thread different from the Dispatcher thread"))
                        MessageBox.Show("MVM/LoadedListAccount: " + e.Message);
                }
                int STT = 1;


                STT = 1;
                ObservableCollection<ModelQuaTrinhKham> listAccount = new ObservableCollection<ModelQuaTrinhKham>();
                foreach (var accFB in listInfoAccount)
                {
                    listAccount.Add(new ModelQuaTrinhKham() {Doctor = accFB.Doctor,IDquatrinh = accFB.IDquatrinh, FM = accFB.FM,M = accFB.M, Huongdieutri = accFB.Huongdieutri, Ngayhen =accFB.Ngayhen, Ngaykham = accFB.Ngaykham, Noidunghen = accFB.Noidunghen });
                }

                InfoAccounts = listAccount ;


            }


        }
    }
}
