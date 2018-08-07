namespace BloggingEFCore.Model
{
    public class PostAuthorLink
    {
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }

}
