namespace BloggingEFCore.Model
{
    public class PostAuthorLink
    {
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }

}
