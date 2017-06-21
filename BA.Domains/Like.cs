namespace BA.Domains
{
    public class Like : TEntity
    {
        public int UserId { get; private set; }

        public Like()
        {
            
        }

        public Like(int userId)
        {
            UserId = userId;
        }
    }
}
