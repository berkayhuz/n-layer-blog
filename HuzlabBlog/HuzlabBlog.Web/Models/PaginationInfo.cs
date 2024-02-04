﻿namespace HuzlabBlog.Web.Models
{
    public class PaginationInfo
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / ItemsPerPage);
    }
}
