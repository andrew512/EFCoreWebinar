using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingEFCore.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public virtual IList<PostAuthorLink> AuthorLinks { get; set; }
        public virtual IList<PostMetaData> MetaData { get; set; }
    }
}
