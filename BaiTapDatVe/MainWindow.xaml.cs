using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BaiTapDatVe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        

        private String GioiTinh()
        {
            if (rdoNam.IsChecked == true)
                return "Nam";
            
            return "Nữ";
            
        }

        private String LoaiVe()
        {
            if (rdoGhe.IsChecked == true)
                return "Ghế";

            return "Giường";
        }

        private String QuocTich()
        {
            switch (lbQuocTich.SelectedIndex)
            {
                case 0 :
                    return "Việt Nam";
                case 1 :
                    return "Pháp";
                case 2 :
                    return "Anh";
                case 3 :
                    return "Canada";
                default :
                    return null;
            }

        }

        private String ThanhToan()
        {
            if (rdoVND.IsChecked == true)
                return "VND";

            return "USD";
        }

        private String TongTienPhaiTra()
        {
            float tienGhe = 200000;
            float tienGiuong = 500000;

            if (rdoGhe.IsChecked == true && rdoUSD.IsChecked == true && lbQuocTich.SelectedIndex == 0)
                return (((tienGhe / 20000) * 80) / 100).ToString() + " USD";
            else if (rdoGhe.IsChecked == true && rdoVND.IsChecked == true && lbQuocTich.SelectedIndex == 0)
                return ((tienGhe * 80) / 100).ToString() + " VND";
            else if (rdoGiuong.IsChecked == true && rdoUSD.IsChecked == true && lbQuocTich.SelectedIndex == 0)
                return (((tienGiuong / 20000) * 80) / 100).ToString() + "USD";
            else if (rdoGiuong.IsChecked == true && rdoVND.IsChecked == true && lbQuocTich.SelectedIndex == 0)
                return ((tienGiuong * 80) / 100).ToString()+ " VND";
            else if (rdoGhe.IsChecked == true && rdoUSD.IsChecked == true)
                return (tienGhe / 20000).ToString() + " USD";
            else if (rdoGiuong.IsChecked == true && rdoUSD.IsChecked == true)
                return (tienGiuong / 20000).ToString() + " USD";
            else if (rdoGiuong.IsChecked == true && rdoVND.IsChecked == true)
                return tienGiuong.ToString() + " VND";

            else if (rdoGhe.IsChecked == true && rdoVND.IsChecked == true)
                return tienGhe.ToString() + " VND";


             return null;
        }

        private bool FixError()
        {
            if (txbSDT.Text.Equals("") || txbTen.Text.Equals(""))
                return false;
            else if (rdoGhe.IsChecked == false && rdoGiuong.IsChecked == false)
                return false;
            else if (rdoUSD.IsChecked == false && rdoVND.IsChecked == false)
                return false;
            else if (rdoNam.IsChecked == false && rdoNu.IsChecked == false)
                return false;
            else if (lbQuocTich.SelectedIndex == -1)
                return false;

            return true;
        }


        private void Display()
        {
            String ten, sdt, gioiTinh, loaiVe, quocTich, thanhToan, tongTienPhaiTra;
            ten = txbTen.Text;
            sdt = txbSDT.Text;
            gioiTinh = GioiTinh();
            loaiVe = LoaiVe();
            quocTich = QuocTich();
            thanhToan = ThanhToan();
            tongTienPhaiTra = TongTienPhaiTra();
            txbHienThi.Text = "Tên : " + ten + "\n" + "SDT : " + sdt + "\n" + "Giới Tính : " + gioiTinh + "\n" + "Loại Vé : " + loaiVe + "\n"
                              + "Quốc Tịch : " + quocTich + "\n" + "Thanh Toán : " + thanhToan + "\n" + "Thành Tiền : " + tongTienPhaiTra;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (FixError())
                Display();
            else
                MessageBox.Show("Loi chua chon du chuc Nang");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();

           
        }

       
    }
}
