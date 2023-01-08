namespace PostManager.DAL.Entities
{
    public sealed class PostEntity
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public string Title { get; }
        public string Body { get; }

        public PostEntity(int id, int userId, string title, string body)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Body = body;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public void SetUserId(int id)
        {
            UserId = id;
        }
    }
}
