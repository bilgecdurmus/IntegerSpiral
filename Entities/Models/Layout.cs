using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Layout
    {
        [Key]
        public int LayoutID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

    }
}
