﻿namespace Microsoft.ILP.ProductService.DTOs
{
    public class UpdateProductDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public int Stock { get; set; }
    }
}
