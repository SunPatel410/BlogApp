namespace BA.Domains
{
    public class Like
    {
        public int Id { get; private set; }
        public User User { get; private set; }

        public Like()
        {
            
        }

        public Like(User user)
        {
            User = user;
        }
    }
}
