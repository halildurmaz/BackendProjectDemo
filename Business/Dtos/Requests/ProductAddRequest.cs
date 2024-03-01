namespace Business.Dtos.Requests;

public class ProductAddRequest
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public int StockAmount { get; set; }
}
