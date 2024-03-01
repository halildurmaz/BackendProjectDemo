﻿namespace Business.Dtos.Responses;

public class ProductDeleteResponse
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public int StockAmount { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
