namespace Aminoko.Api.Models
{
    public class PagedResult<T> where T : class
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<T> Items { get; set; } = [];
    }
}
