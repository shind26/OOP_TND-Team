using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SPA
{
    public abstract class DichVu
    {
        public enum LoaiDichVuEnum { ChamSocSacDep, ChamSocBody, DuongSinh }

        protected string maDichVu;
        protected string tenDichVu;
        protected LoaiDichVuEnum loaiDichVu;
        protected double giaThanh;

        DichVu dichVu;
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
        public LoaiDichVuEnum LoaiDichVu
        {
            get => loaiDichVu;
            set => loaiDichVu = value;
        }

        public static LoaiDichVuEnum NhapLoaiDichVu()
        {
            Console.WriteLine("Chọn loại dịch vụ:");
            Console.WriteLine("1. Chăm sóc sắc đẹp");
            Console.WriteLine("2. Chăm sóc body");
            Console.WriteLine("3. Dưỡng sinh");

            while (true)
            {
                Console.Write("Nhập lựa chọn (1-3): ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        return LoaiDichVuEnum.ChamSocSacDep;
                    case "2":
                        return LoaiDichVuEnum.ChamSocBody;
                    case "3":
                        return LoaiDichVuEnum.DuongSinh;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập lại.");
                        break;
                }
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

        public DichVu(string madv, string tendv, LoaiDichVuEnum loaidv, double giathanh)
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

        public void nhapThongTinDichVu()
        {
            Console.Write("Nhập mã dịch vụ: ");
            MaDichVu = Console.ReadLine();
            Console.Write("Nhập tên dịch vụ: ");
            TenDichVu = Console.ReadLine();
            Console.Write("Nhập giá thành: ");
            GiaThanh = double.Parse(Console.ReadLine());
            LoaiDichVuEnum loaiDV = NhapLoaiDichVu();
        }

        public void xuatThongTinDichVu()
        {
            Console.WriteLine($"Mã Dịch vụ: {MaDichVu}");
            Console.WriteLine($"Tên dịch vụ: {TenDichVu}");
            Console.WriteLine($"Loại dịch vụ: {LoaiDichVu}");
            Console.WriteLine($"Giá gốc: {GiaThanh:N0}");
            Console.WriteLine($"Giá sau giảm: {TinhGiaSauGiamGia():N0}");
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
        public DichVuChamSocSacDep() : base()
        {
            LoaiDichVu = LoaiDichVuEnum.ChamSocSacDep;
        }

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
        public DichVuChamSocBody() : base()
        {
            LoaiDichVu = LoaiDichVuEnum.ChamSocBody;
        }
        public override double TinhGiaSauGiamGia()
        {
            return GiaThanh * 0.93; // Giảm 7%
        }
    }

    // Lớp dịch vụ dưỡng sinh (giảm 10%)
    public class DichVuDuongSinh : DichVu
    {
        public DichVuDuongSinh() : base()
        {
            LoaiDichVu = LoaiDichVuEnum.DuongSinh;
        }
        public override double TinhGiaSauGiamGia()
        {
            return GiaThanh * 0.90; // Giảm 10%
        }
    }
}
