using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DTO_SPA
{
    public enum LoaiDichVu
    {
        [Description("Chăm sóc sức đẹp")]
        Cham_Soc_Suc_Dep,
        [Description("Chăm sóc body")]
        Cham_Soc_Body,
        [Description("Dưỡng sinh")]
        Duong_Sinh
    }
}
