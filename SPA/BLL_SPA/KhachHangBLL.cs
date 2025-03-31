using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_SPA;
using DTO_SPA;

namespace BLL_SPA
{
    public class KhachHangBLL
    {
        private KhachHangDAL khachHangDAL;
        public KhachHangDAL KhachHangDAL { get => khachHangDAL; set => khachHangDAL = value; }

        public KhachHangBLL()
        {
            KhachHangDAL = new KhachHangDAL();
        }
        public List<KhachHangDTO> getList()
        {
            return khachHangDAL.docFile(@"../../../DAL_SPA/Data/DSKhachHang.xml");
        }

        //Xuất danh sách dịch vụ khi biết tên khách hàng
        public void xuatDSDV_TenKhachHang(string tenKH)
        {
            var dsKhachHang = KhachHangDAL.ListKhachHang.Where(kh => kh.TenKhachHang.Equals(tenKH, StringComparison.OrdinalIgnoreCase)).ToList();
            if (dsKhachHang.Count == 0)
            {
                Console.WriteLine($"Không có khách hàng nào có tên: {tenKH}");
                return;
            }
            foreach (var khachHang in dsKhachHang)
                khachHang.xuatKhachHang();
        }

        //Danh sách khách hàng thực hiện nhiều hơn 3 dịch vụ
        public void xuatDSKH_NhieuDichVu()
        {
            var dsKhachHangNhieuDichVu = KhachHangDAL.ListKhachHang.Where(kh => kh.DanhSachDichVu.Count > 3).ToList();
            if (dsKhachHangNhieuDichVu.Count == 0)
            {
                Console.WriteLine("Không có khách hàng nào thực hiện nhiều hơn 3 dịch vụ");
                return;
            }
            foreach (var khachHang in dsKhachHangNhieuDichVu)
                khachHang.xuatKhachHang();
        }
    }
}
