namespace BA.Domains
{
    public class Like : TEntity
    {
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
