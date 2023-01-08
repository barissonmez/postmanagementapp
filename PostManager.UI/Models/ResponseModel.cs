namespace UI.Models
{
    internal class ResponseModel
    {
        public int Id { get; }
        public int UserId { get; }
        public string Title { get;}
        public string Body { get;}

        public ResponseModel(int id, int userId, string title, string body)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Body = body;
        }
    }
}