using System.Collections.Generic;

namespace BethanyPieShop.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}