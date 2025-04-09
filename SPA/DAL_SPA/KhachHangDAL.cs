using DTO_SPA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

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

        public void ghiFileDanhSachKH(string f)
        {
            XDocument xmlDoc;

            try
            {
                xmlDoc = XDocument.Load(f);
            }
            catch
            {
                xmlDoc = new XDocument(new XElement("DSKhachHang"));
            }

            XElement root = xmlDoc.Element("DSKhachHang");

            foreach (var kh in ListKhachHang)
            {
                if (root.Elements("MaKhachHang").Any(x => x.Element("MaKhachHang")?.Value == kh.MaKhachHang))
                {
                    continue;
                }

                XElement newKhachHang = new XElement("KhachHang",
                    new XElement("MaKhachHang", kh.MaKhachHang),
                    new XElement("TenKhachHang", kh.TenKhachHang),
                    new XElement("SoDienThoai", kh.SoDienThoai),
                    new XElement("DSDichVuThucHien", kh.DanhSachDichVu.Select(dvth =>
                        new XElement("DichVu",
                            new XElement("MaDichVu", dvth.MaDichVu),
                            new XElement("TenDichVu", dvth.TenDichVu),
                            new XElement("LoaiDichVu", dvth.LoaiDichVu),
                            new XElement("GiaThanh", dvth.GiaThanh),
                                new XElement("DSDichVuDiKem", kh.DanhSachDichVu.Select(dvdk =>
                                    new XElement("DichVuDiKem",
                                        new XElement("MaDichVu", dvdk.MaDichVu),
                                        new XElement("TenDichVu", dvdk.TenDichVu)
                                        )
                                    )
                                )
                            )
                        )
                    )
                );

                root.Add(newKhachHang);
            }
            xmlDoc.Save(f);
        }
    }
}
