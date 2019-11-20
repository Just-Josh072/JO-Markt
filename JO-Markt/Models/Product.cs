using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using JOMarkt.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JOMarkt.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string EAN { get; set; }

        public string Title { get; set; }
        public string Brand { get; set; }
        public string Shortdescription { get; set; }
        public string Fulldescription { get; set; }
        public string Image { get; set; }
        public string Weight { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        [NotMapped]
        public object SubsubCategory { get; private set; }
        public void EmptyTable(ApplicationDbContext _context, string Tablename)
        {
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE [" + Tablename + "]");
        }

        public void UpdateProducts(ApplicationDbContext _context)
        {
            bool ErrorOccured = false;
            List<Product> products = new List<Product>();
            try
            {
                string xmlurl = "https://supermaco.starwave.nl/api/products";
                var doc = XDocument.Load(xmlurl);
                Console.WriteLine(doc.Elements());
                List<Product> itemlist = doc.Root
                    .Descendants("Product")
                    .Select(node => new Product
                    {
                        Id = int.Parse(node.Attribute("Id").Value),
                        Title = node.Element("Title").Value,
                        EAN = node.Element("EAN").Value,
                        Brand = node.Element("Brand").Value,
                        Shortdescription = node.Element("Shortdescription").Value,
                        Fulldescription = node.Element("Fulldescription").Value,
                        Image = node.Element("Image").Value,
                        Weight = node.Element("Weight").Value,
                        Price = double.Parse(node.Element("Price").Value),
                        Category = node.Element("Category").Value,
                        Subcategory = node.Element("Subcategory").Value,
                        SubsubCategory = node.Element("Subsubcategory").Value
                    })
                    .ToList();
                foreach (var item in itemlist)
                {
                    Console.WriteLine("Id : " + item.EAN);
                }

                _context.Product.AddRange(itemlist);
                EmptyTable(_context, "Product");
                _context.SaveChanges();
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : " + error.Message);
                ErrorOccured = true;
            }
            if (ErrorOccured == true)
            {
                Product product1 = new Product();
                products.Add(product1);
            }
            else
            {
                return;
            }

        }
    }
}
