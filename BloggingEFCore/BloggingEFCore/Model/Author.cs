using System.Collections.Generic;

namespace BloggingEFCore.Model
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Bio { get; set; }

        public virtual IList<PostAuthorLink> PostLinks { get; set; }
    }
}
