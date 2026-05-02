using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLTToeic.Application.Models.ViewModels
{
    public class ExamViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string LType { get; set; }

        public string Type { get; set; }
    }
}
