namespace HuzlabBlog.Service.Helpers.Pagination
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; }
        public int Page { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }
        public int PageSize { get; } // Add PageSize property

        public PaginatedList(List<T> items, int page, int totalPages, int totalCount, int pageSize)
        {
            Items = items;
            Page = page;
            TotalPages = totalPages;
            TotalCount = totalCount;
            PageSize = pageSize; // Set the PageSize property
        }
    }
}