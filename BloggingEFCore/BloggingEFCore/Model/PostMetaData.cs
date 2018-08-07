namespace BloggingEFCore.Model
{
    public class PostMetaData
    {
        public int Id { get; set; }
        public int PostId { get; set; }

        public string Key { get; set; }
        public string Value { get; set; }

        public Post Post { get; set; }
    }
}
