using DTO_SPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL_SPA
{
    public class DichVuDAL
    {
        List<DichVu> listDichVu;

        public List<DichVu> ListDichVu
        {
            get => listDichVu;
            set => listDichVu = value;
        }

        public DichVuDAL()
        {
            ListDichVu = new List<DichVu>();
        }

        // Đọc danh sách dịch vụ từ file xml
        public List<DichVu> docFile(string file)
        {
            XmlDocument read = new XmlDocument();
            read.Load(file);
            //....
            return ListDichVu;
        }

        // Xuất danh sách dịch vụ
        public void xuatDSDV()
        {
            foreach (DichVu dichVu in ListDichVu)
                dichVu.xuatThongTinDichVu();
        }
    }
}
