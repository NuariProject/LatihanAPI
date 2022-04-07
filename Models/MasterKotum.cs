using System;
using System.Collections.Generic;

namespace LatihanAPI.Models
{
    public partial class MasterKotum
    {
        public int IdKota { get; set; }
        public int IdProvinsi { get; set; }
        public string NamaKota { get; set; } = null!;
    }
}
