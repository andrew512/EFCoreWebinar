using BloggingEFCore.DAL;
using BloggingEFCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BloggingEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            FindPostsByAuthor();

            Console.ReadKey();
        }

        private static void FindPostsByAuthor()
        {
            IList<Post> posts = null;
            using (var ctx = new BlogContext())
            {
                IBlogRepository repo = new BlogRepository(ctx);

                posts = repo.GetPostsByAuthor("Johnson");
            }


            foreach (var p in posts)
            {
                var entry = $"({String.Join(", ", p.AuthorLinks.Select(l => l.Author.Surname))}) => {p.Content}";
                Console.WriteLine(entry);
            }
        }

        private static void LoadConnectedData()
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
        }
    }
}
