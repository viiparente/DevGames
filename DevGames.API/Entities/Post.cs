namespace DevGames.API.Entities
{
    public class Post
    {
        public Post(int boardId, string description, string title)
        {
            Title = title;
            Description = description;
            BoardId = boardId;

            CreatedAt = DateTime.Now;
            Comments = new List<Comment>();
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int BoardId { get; private set; }

        public List<Comment> Comments { get; private set; }


        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }
    }
}
