using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BloggingEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new BlogContext())
            {
                var allPosts = ctx.Posts.Include(p => p.AuthorLinks).ThenInclude(l => l.Author).ToList();

                allPosts.ForEach(p => 
                {
                    var entry = $"({String.Join(", ", p.AuthorLinks.Select(l => l.Author.Surname))}) => {p.Content}";
                    Console.WriteLine(entry);
                });
            }

            Console.ReadKey();
        }
    }
}
