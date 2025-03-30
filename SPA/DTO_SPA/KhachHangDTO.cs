using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SPA
{
    public class KhachHangDTO
    {
        private string maKhachHang;
        private string tenKhachHang;
        private string soDienThoai;
        public List<DichVuDTO> danhSachDichVu = new List<DichVuDTO>();
        public string MaKhachHang
        {
            get => maKhachHang;
            set
            {
                if (!(string.IsNullOrEmpty(value)) && !(string.IsNullOrWhiteSpace(value)))
                    maKhachHang = value;
                else maKhachHang = "KH000";
            }
        }
        public string TenKhachHang
        {
            get => tenKhachHang;
            set
            {
                if (!(string.IsNullOrEmpty(value)) && !(string.IsNullOrWhiteSpace(value)))
                    tenKhachHang = value;
                else tenKhachHang = "Anonymous";
            }
        }
        public string SoDienThoai
        {
            get => soDienThoai;
            set
            {
                if (value.Length == 10 && value.StartsWith("0") && !(string.IsNullOrEmpty(value)) && !(string.IsNullOrWhiteSpace(value)))
                    soDienThoai = value;
                else soDienThoai = "0000000000";
            }
        }
        public List<DichVuDTO> DanhSachDichVu
        {
            get => danhSachDichVu;
            set => danhSachDichVu = value;
        }

        public KhachHangDTO()
        {
            DanhSachDichVu = new List<DichVuDTO>();
        }

        public void xuatKhachHang()
        {
            Console.WriteLine($"Mã khách hàng: {MaKhachHang}");
            Console.WriteLine($"Tên khách hàng: {TenKhachHang}");
            Console.WriteLine($"Số điện thoại: {SoDienThoai}");
            Console.WriteLine("DANH SÁCH DỊCH VỤ SỬ DỤNG");
            foreach(DichVuDTO d in DanhSachDichVu)
            {
                d.xuatDichVu();
                Console.WriteLine("DANH SÁCH DỊCH VỤ ĐI KÈM");
                foreach(DichVuDiKemDTO dvdk in d.DsDVDiKem)
                {
                    dvdk.xuatDichVuDiKem();
                }
            }
        }
    }
}
