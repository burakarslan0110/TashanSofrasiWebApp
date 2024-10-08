﻿namespace TashanSofrasiWebApp.DTOs.ProductDTOs
{
	public class CreateProductDTO
	{
		public string ProductName { get; set; }
		public string ProductDescription { get; set; }
		public decimal ProductPrice { get; set; }
		public string ProductImageURL { get; set; }
		public bool ProductStatus { get; set; }
		public string CategoryID { get; set; }	
	}
}
