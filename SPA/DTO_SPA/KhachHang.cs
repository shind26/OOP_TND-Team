using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SPA
{
    public class KhachHang
    {
        private string maKhachHang;
        private string tenKhachHang;
        private string soDienThoai;
        public List<DichVu> danhSachDichVu = new List<DichVu>();
        public string MaKhachHang 
        { 
            get => maKhachHang;
            set
            {
                if (!(string.IsNullOrEmpty(value)) && string.IsNullOrWhiteSpace(value))
                    maKhachHang = value;
                else maKhachHang = "KH000";
            } 
        }
        public string TenKhachHang 
        { 
            get => tenKhachHang;
            set
            {
                if (!(string.IsNullOrEmpty(value)) && string.IsNullOrWhiteSpace(value))
                    maKhachHang = value;
                else maKhachHang = "Anonymous";
            } 
        }
        public string SoDienThoai 
        { 
            get => soDienThoai;
            set
            {
                if (value.Length == 10 && value.StartsWith("0") && !(string.IsNullOrEmpty(value)) && string.IsNullOrWhiteSpace(value))
                    maKhachHang = value;
                else maKhachHang = "0000000000";
            } 
        }
        public List<DichVu> DanhSachDichVu 
        { 
            get => danhSachDichVu;
            set => danhSachDichVu = value;
        }

        public KhachHang()
        {

        }
    }
}
