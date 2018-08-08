using BloggingEFCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloggingEFCore.DAL
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext _context;

        public BlogRepository(BlogContext context)
        {
            _context = context;
        }

        public IList<Post> GetPostsByAuthor(string authorSurname) =>       
            _context.Posts.Include(p => p.AuthorLinks).ThenInclude(l => l.Author).Where(p => p.AuthorLinks.Any(l => l.Author.Surname == authorSurname)).ToList();
        
    }
}
