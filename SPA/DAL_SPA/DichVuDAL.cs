using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using DTO_SPA;

namespace DAL_SPA
{
    public class DichVuDAL
    {
        public static List<DichVuDTO> ListDichVu = new List<DichVuDTO>();

        public DichVuDAL()
        {
            DichVuDAL.ListDichVu = docFile(@"../../../DAL_SPA/Data/DSDichVu.xml");
        }

        public List<DichVuDTO> docFile(string path)
        {
            XmlDocument document = new XmlDocument();
            List<DichVuDTO> listDichVu = new List<DichVuDTO>();
            document.Load(path);
            XmlNodeList nodeList = document.SelectNodes("DSDichVu/DichVu");
            foreach (XmlNode node in nodeList)
            {
                
                string maDichVu = node["MaDichVu"].InnerText;
                string tenDichVu = node["TenDichVu"].InnerText;
                string loaiDichVu = node["LoaiDichVu"].InnerText;
                double giaThanh = double.Parse(node["GiaThanh"].InnerText);
                DichVuDTO dv = new DichVuDTO();
                switch (loaiDichVu)
                {
                    case "Chăm sóc sắc đẹp":
                        dv = new ChamSocSacDepDTO(maDichVu, tenDichVu, giaThanh);
                        break;
                    case "Chăm sóc Body":
                        dv = new ChamSocBodyDTO(maDichVu, tenDichVu, giaThanh);
                        break;
                    case "Dưỡng sinh":
                        dv = new DuongSinhDTO(maDichVu, tenDichVu, giaThanh);
                        break;
                    default:
                        Console.WriteLine("Lỗi");
                        break;
                }
                XmlNodeList listDVDiKem = node.SelectNodes("DSDichVuDiKem/DichVuDiKem");
                foreach (XmlNode xmlNode in listDVDiKem)
                {
                    DichVuDiKemDTO dvdk = new DichVuDiKemDTO();
                    dvdk.MaDichVu = xmlNode["MaDichVu"].InnerText;
                    dvdk.TenDichVu = xmlNode["TenDichVu"].InnerText;
                    dv.DsDVDiKem.Add(dvdk);
                }
                    listDichVu.Add(dv);
            }
            return listDichVu;
        }

        public void xuatDanhSachDichVu()
        {
            foreach (DichVuDTO dichVu in ListDichVu)
                dichVu.xuatDichVu();
        }

        public void ghiFileDanhSachDichVu(string f)
        {
            XDocument xmlDoc;

            try
            {
                xmlDoc = XDocument.Load(f);
            }
            catch
            {
                xmlDoc = new XDocument(new XElement("DSDichVu"));
            }

            XElement root = xmlDoc.Element("DSDichVu");

            foreach (var dv in ListDichVu)
            {

                if (root.Elements("DichVu").Any(x => x.Element("MaDichVu")?.Value == dv.MaDichVu))
                {
                    continue;
                }


                XElement newDichVu = new XElement("DichVu",
                    new XElement("MaDichVu", dv.MaDichVu),
                    new XElement("TenDichVu", dv.TenDichVu),
                    new XElement("LoaiDichVu", dv.LoaiDichVu),
                    new XElement("GiaThanh", dv.GiaThanh),
                    new XElement("DSDichVuDiKem",
                        dv.DsDVDiKem.Select(dk =>
                            new XElement("DichVuDiKem",
                                new XElement("MaDichVu", dk.MaDichVu),
                                new XElement("TenDichVu", dk.TenDichVu)
                            )
                        )
                    )
                );

                root.Add(newDichVu);
            }


            xmlDoc.Save(f);
        }
        public void capNhatGia(string f, List<DichVuDTO> dvMoi)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(f);
            XmlNodeList nodeList = doc.SelectNodes("DSDichVu/DichVu");
            foreach (XmlNode node in nodeList)
            {
                foreach (DichVuDTO d in dvMoi) 
                {
                    string maDV = node["MaDichVu"].InnerText; //Lấy ra node mã dịch vụ trong file xml
                    if (d.MaDichVu == maDV)
                        node["GiaThanh"].InnerText = d.GiaThanh + "";
                }
            }
            doc.Save(f);
        }
    }
}

