using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScholarMVC.DAL.Models
{
    public class Scholar
    {
        public int Id { get; set; }
        public string ImgPath { get; set; }
        
        public double Price { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }

    }
}
