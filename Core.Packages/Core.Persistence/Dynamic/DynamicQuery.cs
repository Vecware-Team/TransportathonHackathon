namespace Core.Persistence.Dynamic
{
    public class DynamicQuery
    {
        public DynamicQuery()
        {

        }

        public DynamicQuery(IEnumerable<Sort>? sort, Filter? filter)
        {
            Filter = filter;
            Sort = sort;
        }

        public IEnumerable<Sort>? Sort { get; set; }
        public Filter? Filter { get; set; }
    }
}
