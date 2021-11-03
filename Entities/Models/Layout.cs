using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Layout
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LayoutID { get; set; }
        [Required]
        public int X { get; set; }
        [Required]
        public int Y { get; set; }
        public string Layout_Values { get; set; }
        

    }
}
