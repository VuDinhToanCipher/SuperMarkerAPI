﻿namespace SuperMarket.Application.DTOs.ProductTypeDTO
{
    public class AddProductTypeDTO
    {
        public Guid IDType { get; set; }
        public string TypeName { get; set; } = string.Empty;
    }
}
