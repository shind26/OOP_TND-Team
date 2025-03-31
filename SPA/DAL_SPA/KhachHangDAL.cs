using DTO_SPA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL_SPA
{
    public class KhachHangDAL
    {
        public static List<KhachHangDTO> ListKhachHang = new List<KhachHangDTO>();

        public KhachHangDAL()
        {
            KhachHangDAL.ListKhachHang = docFile(@"../../../DAL_SPA/Data/DSKhachHang.xml");
        }

        public List<KhachHangDTO> docFile(string path)
        {
            XmlDocument document = new XmlDocument();
            List<KhachHangDTO> listKhachHang = new List<KhachHangDTO>();
            document.Load(path);
            XmlNodeList nodeList = document.SelectNodes("DSKhachHang/KhachHang");
            foreach (XmlNode node in nodeList)
            {
                KhachHangDTO khachHang = new KhachHangDTO();
                khachHang.MaKhachHang = node["MaKhachHang"].InnerText;
                khachHang.TenKhachHang = node["TenKhachHang"].InnerText;
                khachHang.SoDienThoai = node["SoDienThoai"].InnerText;
                XmlNodeList listDV = node.SelectNodes("DSDichVuThucHien/DichVu");
                foreach(XmlNode nodedv in listDV)
                {
                    DichVuDTO dichVu = new DichVuDTO();
                    dichVu.MaDichVu = nodedv["MaDichVu"].InnerText;
                    dichVu.TenDichVu = nodedv["TenDichVu"].InnerText;
                    dichVu.LoaiDichVu = nodedv["LoaiDichVu"].InnerText;
                    dichVu.GiaThanh = double.Parse(nodedv["GiaThanh"].InnerText);
                    
                    XmlNodeList listDVDK = nodedv.SelectNodes("DSDichVuDiKem/DichVuDiKem");
                    foreach(XmlNode nodedvdk in listDVDK)
                    {
                        DichVuDiKemDTO dichVuDiKem = new DichVuDiKemDTO();
                        dichVuDiKem.MaDichVu = nodedvdk["MaDichVu"].InnerText;
                        dichVuDiKem.TenDichVu = nodedvdk["TenDichVu"].InnerText;
                        dichVu.DsDVDiKem.Add(dichVuDiKem);
                    }
                    khachHang.DanhSachDichVu.Add(dichVu);
                }
                listKhachHang.Add(khachHang);
            }
            return listKhachHang;
        }

        public void xuatDanhSachKhachHang()
        {
            foreach (KhachHangDTO khachHang in ListKhachHang) { 
                khachHang.xuatKhachHang();
            }
        }
    }
}
