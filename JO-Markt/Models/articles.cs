using JOMarkt.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOMarkt.Models
{
    public class articles
    {
        public string image { get; set; }
        public int articlesId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublisherDate { get; set; }
        public string Publisher { get; set; }
        public bool IsVisible { get; set; }

        public void CreateArticle(ApplicationDbContext _context, string image, string Title, string Content, string Publisher, bool IsVisible)
        {
            List<articles> articles = new List<articles>();
            articles article = new articles()
            {
                Title = Title,
                Content = Content,
                PublisherDate = DateTime.Now,
                Publisher = Publisher,
                image = image,
                IsVisible = false
            };
            articles.Add(article);

            _context.AddRange(articles);
            _context.SaveChanges();
        }

    }
}
