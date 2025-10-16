using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class NewsDtos
    {
        public int Id { get; set; } 
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int MenuId { get; set; }
    }
}
