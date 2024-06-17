using MyF.Model;
using MyF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BaoCaoBenhVien.Viewmodel
{
    public class DanhSachBenhNhanViewmodel:BaseViewModel
    {
        public static DanhSachBenhNhanViewmodel W = new DanhSachBenhNhanViewmodel();
        private ObservableCollection<Main_InfoAccount> _infoAccounts = new ObservableCollection<Main_InfoAccount>();
        public ObservableCollection<Main_InfoAccount> InfoAccounts
        {
            get { return _infoAccounts; }
            set
            {
                _infoAccounts = value;
                OnPropertyChanged();

            }
        }

        public ICommand LoadedWindow_Command { get; set; }
        public ICommand Lietke_Command { get; set; }
        public DanhSachBenhNhanViewmodel() {
            LoadedWindow_Command = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                LoadedListAccount();

            });
            Lietke_Command = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                var num = int.Parse(DanhSachBenhNhan.W.TB_Tongso.Text.Trim());
                LoadedListAccount(num);

            });
        }
        async public void LoadedListAccount(int num = 5000)
        {

            List<InfoAccount> listInfoAccount = new List<InfoAccount>();

            Application.Current.Dispatcher.Invoke((Action)delegate {

                listInfoAccount = DataProvider.GetAccounts(1, num);
            });


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
                ObservableCollection<Main_InfoAccount> listAccount = new ObservableCollection<Main_InfoAccount>();
                foreach (var accFB in listInfoAccount)
                {
                    listAccount.Add(new Main_InfoAccount() { MY_INFO_ACCOUNT = accFB, STT = STT++ });
                }
                InfoAccounts = listAccount;


            }


        }
    }
}
