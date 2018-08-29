namespace Project.Services
{
    using Project.Data;

    public abstract class Service
    {
        public Service(SportsSystemContext context)
        {
            this.Context = context;
        }

        protected SportsSystemContext Context { get; private set; }
    }
}