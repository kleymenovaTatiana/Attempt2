﻿namespace WebApplication2.Contracts.Category
{
    public class GetCategoryResponse
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
