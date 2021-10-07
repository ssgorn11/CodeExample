using System;
using System.Collections.Generic;
using System.Text;

namespace DataLoader.PHDWin
{
    public class PHDData
    {
        public int IdTag { get; set; }
        public string Tag { get; set; }
        public DateTime DatePHD { get; set; }
        public decimal Value { get; set; }
        public int Confidence { get; set; }
        public DateTime ReadTime { get; set; }
        public string Unit { get; set; }
    }
}
