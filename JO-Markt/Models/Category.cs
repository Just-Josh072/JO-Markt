using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JOMarkt.Data;
using JOMarkt.Models;

namespace JOMarkt.Models
{
    public class Category
    {
       
        
            public int CategorieId { get; set; }
            public string Name { get; set; }
            public List<SubCategory> subcategories { get; set; }
            //public List<SubsubCategory> subsubcategories { get; set; }

            Product products = new Product();

            //public void UpdateCategory(ApplicationDbContext _context)
            //{
            //    string xmlurl = "https://supermaco.starwave.nl/api/categories";
            //    var doc = XDocument.Load(xmlurl);
            //    var root = doc.Root;
            //    //category to list
            //    var descendants = root.Descendants("Category");
            //    foreach (var item in descendants)
            //    {
            //        Console.WriteLine(item.Value + "   ");
            //        Console.WriteLine("    -   ");
            //    }
            //    List<Categorie> categories = doc.Root
            //        .Descendants("Category")
            //        .Select(node => new Categorie
            //        {
            //            Name = node.Element("Name").Value,
            //        }).ToList();

            //    //subcategory to list
            //    List<Subcategory> subcategories = doc.Root
            //        .Descendants("Subcategory")
            //        .Select(node => new Subcategory
            //        {
            //            Name = node.Element("Name").Value
            //        }).ToList();

            //    //subsubcategory to list
            //    List<Subsubcategory> subsubcategories = doc.Root
            //        .Descendants("Subsubcategory")
            //        .Select(node => new Subsubcategory
            //        {
            //            Name = node.Element("Name").Value
            //        }).ToList();
            //    //List<Subcategory> subcategories
            //    //products.EmptyTable(_context, "Categories");
            //    //products.EmptyTable(_context, "Subcategories");
            //    //products.EmptyTable(_context, "Subsubcategories");
            //    _context.Categories.AddRange(categories);
            //    _context.Subcategories.AddRange(subcategories);
            //    _context.Subsubcategories.AddRange(subsubcategories);

            //    //_context.Categories.AddRange(categories);
            //    _context.SaveChanges();
            //}
        }
        
    }
