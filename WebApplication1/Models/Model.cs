using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vision.Data.EntityFramework;

namespace WebApplication1.Models
{
    public class SearchServiceDbContext : VisionDbContext
    {
        public SearchServiceDbContext(DbContextOptions<SearchServiceDbContext> options, IServiceProvider serviceProvider)
            : base(options, serviceProvider)
        { }

    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public bool Actived { get; set; }
        public string Content { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Actived { get; set; }
    }
}
