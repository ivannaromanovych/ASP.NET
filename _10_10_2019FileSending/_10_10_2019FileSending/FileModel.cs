using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_10_2019FileSending
{
    [Serializable]
    public class FileModel
    {
        public string Name { get; set; }
        public byte[] Body { get; set; } 
    }
}
