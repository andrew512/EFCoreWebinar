using BloggingEFCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BloggingEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectedUpdate();
            Console.WriteLine("==================================================");
            DisconnectedUpdate();
            Console.WriteLine("==================================================");
            AsNoTracking();

            Console.ReadKey();
        }

        private static void ConnectedUpdate()
        {
            using (var ctx = new BlogContext())
            {
                var author = ctx.Authors.First();

                author.Name = "New Name";

                ctx.SaveChanges();
            }
        }

        private static void DisconnectedUpdate()
        {
            Author author = null;
            using (var ctx = new BlogContext())
            {
                author = ctx.Authors.First();
            }

            author.Name = "New Name Disconnected";

            using (var ctx = new BlogContext())
            {
                ctx.Entry(author).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        private static void AsNoTracking()
        {
            using (var ctx = new BlogContext())
            {
                var author = ctx.Authors.AsNoTracking().First();

                author.Name = "New Name No Tracking";
                ctx.Update(author);

                ctx.SaveChanges();
            }
        }
    }
}
