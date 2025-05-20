using Microsoft.EntityFrameworkCore;
using ScholarMVC.BL.Exceptions;
using ScholarMVC.BL.ViewModels;
using ScholarMVC.DAL.Contexts;
using ScholarMVC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScholarMVC.BL.Services;

public class ScholarService
{
    private readonly AppDbContext _context;
    
    
    public ScholarService(AppDbContext context)
    {
        _context = context;
    }
    #region Read
    public List<Scholar> GetAllScholar()
    {
        List<Scholar> scholars = _context.Scholar.ToList();
        return scholars;
    }

    public Scholar GetScholarById(int id)
    {
        Scholar? scholar = _context.Scholar.Find(id);
        if (scholar is null)
        {
            throw new ScholarException($"Databasada {id} idsi yoxdur");
        }
        return scholar;
    }
    #endregion

    #region Create
    public void CreateScholar(ScholarVM scholarVM) 
    {
        Scholar newScholar = new Scholar();

        newScholar.Price = scholarVM.Price;
        newScholar.Category = scholarVM.Category;
        newScholar.Name = scholarVM.Name;


        string filename = Path.GetFileNameWithoutExtension(scholarVM.ImgFile.FileName);
        string extension = Path.GetExtension(scholarVM.ImgFile.FileName);
        string resutname = filename + Guid.NewGuid() + extension;

        string uploadPath = "C:\\Users\\II Novbe\\source\\repos\\ScholarMVC\\ScholarMVC.MVC\\wwwroot\\assets\\uploadedImages";
        uploadPath = Path.Combine(uploadPath,resutname);
        using FileStream stream = new FileStream(uploadPath,FileMode.Create
            );
        scholarVM.ImgFile.CopyTo(stream);

        newScholar.ImgPath = resutname;


        _context.Scholar.Add(newScholar);
        _context.SaveChanges();
    }
    #endregion




    #region Update
    public void UpdateScholar(int id, ScholarVM scholarVM) 
    {
        string filename = Path.GetFileNameWithoutExtension(scholarVM.ImgFile.FileName);
        string extension = Path.GetExtension(scholarVM.ImgFile.FileName);
        string resutname = filename + Guid.NewGuid() + extension;

        string uploadPath = "C:\\Users\\II Novbe\\source\\repos\\ScholarMVC\\ScholarMVC.MVC\\wwwroot\\assets\\uploadedImages";
        uploadPath = Path.Combine(uploadPath, resutname);
        using FileStream stream = new FileStream(uploadPath, FileMode.Create
            );
        scholarVM.ImgFile.CopyTo(stream);

        Scholar? scholar1 = _context.Scholar.AsNoTracking().SingleOrDefault(sc =>sc.Id==id);

        scholar1.Price = scholarVM.Price;
        scholar1.Category = scholarVM.Category;
        scholar1.Name = scholarVM.Name;
        scholar1.ImgPath = resutname;
        if (scholar1 is not null)

        {
            _context.Scholar.Update(scholar1);
            _context.SaveChanges();
        }
        else
        {
            throw new ScholarException($"Databasada {id} idsine sahib bir data tapilmadi");
        }
    }
    #endregion

    #region Delete
    public void DeleteScholar(int id) 
    {
        Scholar? scholar = _context.Scholar.Find(id);
        if (scholar is null)
        {
            throw new ScholarException($"Databasada {id} idsine sahib bir data tapilmadi");

        }
        _context.Remove(scholar);
        _context.SaveChanges();
    }
    #endregion


}
