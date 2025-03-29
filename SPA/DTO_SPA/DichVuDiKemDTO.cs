using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SPA
{
    internal class DichVuDiKemDTO
    {
        #region Attributes
        private string maDichVu;
        private string tenDichVu;
        private double giaThanh;
        #endregion
        public string MaDichVu
        {
            get
            {
                return maDichVu;
            }
            set
            {
                if (!(string.IsNullOrEmpty(value)) && string.IsNullOrWhiteSpace(value))
                    maDichVu = value;
                else maDichVu = "DVDK000";
            }
        }

        public string TenDichVu
        {
            get => tenDichVu;
            set
            {
                if (!(string.IsNullOrEmpty(value)) && string.IsNullOrWhiteSpace(value))
                    tenDichVu = value;
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
        public DichVuDiKemDTO()
        {
            
        }

        public DichVuDiKemDTO(string ma, string ten, double gia)
        {
            MaDichVu = ma;
            TenDichVu = ten;
            GiaThanh = gia;
        }
        public void nhapDichVuDiKem()
        {
            Console.Write("Nhập mã dịch vụ: ");
            MaDichVu = Console.ReadLine();
            Console.Write("Nhập tên dịch vụ: ");
            TenDichVu = Console.ReadLine();
            Console.Write("Nhập giá thành: ");
            GiaThanh = double.Parse(Console.ReadLine());
        }
       }
}
