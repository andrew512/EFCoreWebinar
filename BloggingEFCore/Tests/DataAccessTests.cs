using BloggingEFCore;
using BloggingEFCore.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace Tests
{
    public class DataAccessTests
    {
        [Fact]
        public void BlogRepository_Searches_Posts_By_Authors_Surname()
        {
            IBlogRepository repo = new BlogRepository(GetMockContext());

            var posts = repo.GetPostsByAuthor("Johnson");

            Assert.Equal(3, posts.Count);
        }


        private BlogContext GetMockContext()
        {
            var options = new DbContextOptionsBuilder<BlogContext>()
                              .UseInMemoryDatabase(Guid.NewGuid().ToString())
                              .Options;

            var context = new BlogContext(options);

            context.Authors.Add(new BloggingEFCore.Model.Author { Id = 1, Name = null, Surname = "Johnson", Bio = "Some info" });
            context.Authors.Add(new BloggingEFCore.Model.Author { Id = 2, Name = null, Surname = "Smith", Bio = null });
            context.Authors.Add(new BloggingEFCore.Model.Author { Id = 3, Name = "John", Surname = "Dow", Bio = null });
            context.Authors.Add(new BloggingEFCore.Model.Author { Id = 4, Name = null, Surname = "Pupkin", Bio = null });

            context.Posts.Add(new BloggingEFCore.Model.Post() { Id = 1, Content = "Post 1" });
            context.Posts.Add(new BloggingEFCore.Model.Post() { Id = 2, Content = "Post 2" });
            context.Posts.Add(new BloggingEFCore.Model.Post() { Id = 3, Content = "Post 3" });
            context.Posts.Add(new BloggingEFCore.Model.Post() { Id = 4, Content = "Post 4" });

            context.PostAuthorLinks.Add(new BloggingEFCore.Model.PostAuthorLink() { PostId = 1, AuthorId = 1});
            context.PostAuthorLinks.Add(new BloggingEFCore.Model.PostAuthorLink() { PostId = 1, AuthorId = 2 });
            context.PostAuthorLinks.Add(new BloggingEFCore.Model.PostAuthorLink() { PostId = 2, AuthorId = 1 });
            context.PostAuthorLinks.Add(new BloggingEFCore.Model.PostAuthorLink() { PostId = 3, AuthorId = 2 });
            context.PostAuthorLinks.Add(new BloggingEFCore.Model.PostAuthorLink() { PostId = 3, AuthorId = 3 });
            context.PostAuthorLinks.Add(new BloggingEFCore.Model.PostAuthorLink() { PostId = 3, AuthorId = 4 });
            context.PostAuthorLinks.Add(new BloggingEFCore.Model.PostAuthorLink() { PostId = 4, AuthorId = 1 });

            context.SaveChanges();

            return context;
        }
    }
}
