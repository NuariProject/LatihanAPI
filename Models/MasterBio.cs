using System;
using System.Collections.Generic;

namespace LatihanAPI.Models
{
    public partial class MasterBio
    {
        public int IdBio { get; set; }
        public int IdKota { get; set; }
        public string Nama { get; set; } = null!;
        public string? Deskrispsi { get; set; }
        public DateOnly? Tanggal { get; set; }
    }
}
