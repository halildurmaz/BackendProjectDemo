using Core.Entities;

namespace Entities.Concrete;

public class Category : BaseEntity<int>
{
    public string Name { get; set; }

    public virtual List<Product> Products { get; set; }
}
