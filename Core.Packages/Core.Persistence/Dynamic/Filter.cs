namespace Core.Persistence.Dynamic
{
    public class Filter
    {
        public Filter()
        {
            Field = string.Empty;
            Operator = string.Empty;
        }

        public Filter(string field, string @operator)
        {
            Field = field;
            Operator = @operator;
        }

        public string Field { get; set; }
        public string? Value { get; set; }
        public string Operator { get; set; }
        public string? Logic { get; set; }

        public IEnumerable<Filter>? Filters { get; set; }
    }
}
