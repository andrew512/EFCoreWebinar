using BloggingEFCore.Model;
using System.Collections.Generic;

namespace BloggingEFCore.DAL
{
    public interface IBlogRepository
    {
        IList<Post> GetPostsByAuthor(string authorSurname);
    }
}