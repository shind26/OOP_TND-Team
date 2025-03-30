using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SPA
{
    public class DichVuDiKemDTO
    {

        #region Attributes
        private string maDichVu;
        private string tenDichVu;
        #endregion
        public string MaDichVu
        {
            get
            {
                return maDichVu;
            }
            set
            {
                if (!(string.IsNullOrEmpty(value)) && !(string.IsNullOrWhiteSpace(value)))
                    maDichVu = value;
                else maDichVu = "DVDK000";
            }
        }

        public string TenDichVu
        {
            get => tenDichVu;
            set
            {
                if (!(string.IsNullOrEmpty(value) && !(string.IsNullOrWhiteSpace(value))))
                    tenDichVu = value;
            }
        }

        public DichVuDiKemDTO()
        {
            
        }

        public DichVuDiKemDTO(string ma, string ten)
        {
            MaDichVu = ma;
            TenDichVu = ten;
        }
        public void nhapDichVuDiKem()
        {
            Console.Write("Nhập mã dịch vụ: ");
            MaDichVu = Console.ReadLine();
            Console.Write("Nhập tên dịch vụ: ");
            TenDichVu = Console.ReadLine();
        }
        public void xuatDichVuDiKem()
        {
            Console.WriteLine($"Mã dịch vụ: {MaDichVu}\nTên dịch vụ: {TenDichVu}");
        }
     }
}
