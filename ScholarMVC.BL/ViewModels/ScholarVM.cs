using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScholarMVC.BL.ViewModels;

public class ScholarVM
{
    public IFormFile ImgFile { get; set; }

    public double Price { get; set; }
    public string Category { get; set; }
    public string Name { get; set; }
}
