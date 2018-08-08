using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BloggingEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //LoadConnectedData();
            LazyLoading();

            Console.ReadKey();
        }

        private static void LazyLoading()
        {
            using (var ctx = new BlogContext())
            {
                var firstPost = ctx.Posts.First(p => p.Id == 1);

                foreach (var entry in firstPost.MetaData)
                {
                    Console.WriteLine($"{entry.PostId}: {entry.Key} => {entry.Value}");
                }
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
