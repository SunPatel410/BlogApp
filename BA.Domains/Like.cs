namespace BA.Domains
{
    public class Like : TEntity
    {
        public ApplicationUser User { get; private set; }

        public Like()
        {
            
        }

        public Like(ApplicationUser user)
        {
            User = user;
        }
    }
}
