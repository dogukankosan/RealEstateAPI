﻿namespace RealEstate_API.Dtos.CategoryDtos
{
    public class ResultCategoryDto
    {
        public byte CategoryID { get; set; }
        public required string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
    }
}