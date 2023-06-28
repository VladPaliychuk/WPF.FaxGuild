using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.FaxGuild.BLL.DTOs
{
    public class OrderDTO
    {
        [Key]
        public Guid Id { get; set; }
        public int Roomnumber { get; set; }
        public int Placenumber { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
