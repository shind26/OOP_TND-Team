using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DTO_SPA.DichVu;

namespace DTO_SPA
{
    public abstract class DichVu
    {
        public enum LoaiDV { ChamSocSacDep, ChamSocBody, DuongSinh }

        protected string maDichVu;
        protected string tenDichVu;
        protected string loaiDichVu;
        protected double giaThanh;
        public string MaDichVu 
        {  
            get => maDichVu;
            set
            {
                if (!(string.IsNullOrEmpty(value)) && string.IsNullOrWhiteSpace(value))
                    maDichVu = value;
                else maDichVu = "DV000";
            }
        }
        public string TenDichVu 
        { 
            get => tenDichVu;
            set
            {
                if (!(string.IsNullOrEmpty(value)) && string.IsNullOrWhiteSpace(value))
                    tenDichVu = value;
                else tenDichVu = "Massage";
            } 
        }
        public string LoaiDichVu
        {
            get => loaiDichVu;
            set
            {
                if ((!(string.IsNullOrEmpty(value)) && string.IsNullOrWhiteSpace(value)) &&
                    (value == "ChamSocSacDep" || value == "ChamSocBody" || value == "DuongSinh"))
                    loaiDichVu = value;
                else loaiDichVu = "ChamSocSacDep";  //Mặc định là Chăm sóc sắc đẹp
            }
        }
        public double GiaThanh
        {
            get => giaThanh;
            set
            {
                if (value > 0)
                    giaThanh = value;
                else value = 20000;
            }
        }

        public DichVu()
        {

        }

        public DichVu(string madv, string tendv, string loaidv, double giathanh)
        {
            MaDichVu = madv;
            TenDichVu = tendv;
            LoaiDichVu = loaidv;
            GiaThanh = giathanh;
        }

        public DichVu(DichVu dv)
        {
            MaDichVu = dv.MaDichVu;
            TenDichVu = dv.TenDichVu;
            LoaiDichVu = dv.LoaiDichVu;
            GiaThanh = dv.GiaThanh;
        }

        // Phương thức trừu tượng - các lớp con phải override
        public abstract double TinhGiaSauGiamGia();
    }

    //Interface phương thức cập nhật giá
    public interface ICapNhatGia
    {
        void CapNhatGia();
    }

    // Lớp dịch vụ chăm sóc sắc đẹp (không giảm giá)
    public class DichVuChamSocSacDep : DichVu,ICapNhatGia
    {
        public override double TinhGiaSauGiamGia()
        {
            return GiaThanh; // Không giảm giá
        }

        public void CapNhatGia()
        {
            GiaThanh *= 1.03; // Tăng 3%
        }
    }

    // Lớp dịch vụ chăm sóc body (giảm 7%)
    public class DichVuChamSocBody : DichVu
    {
        public override double TinhGiaSauGiamGia()
        {
            return GiaThanh * 0.93; // Giảm 7%
        }
    }

    // Lớp dịch vụ dưỡng sinh (giảm 10%)
    public class DichVuDuongSinh : DichVu
    {
        public override double TinhGiaSauGiamGia()
        {
            return GiaThanh * 0.90; // Giảm 10%
        }
    }
}
