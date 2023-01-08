namespace PostManager.Common.DTO
{
    public sealed class PostDTO
    {
        public int Id { get;}
        public int UserId { get; }
        public string Title { get;}
        public string Body { get; }

        public PostDTO(int id, int userId, string title, string body)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Body = body;
        }
    }
}
