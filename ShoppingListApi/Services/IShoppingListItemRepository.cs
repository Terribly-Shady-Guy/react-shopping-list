using ShoppingListApi.Models;

namespace ShoppingListApi.Services
{
    public interface IShoppingListItemRepository
    {
        Task<List<ShoppingListItem>> GetAllShoppingListItems();
        Task<bool> AddNewShoppingListItem(string itemName);
        Task<bool> UpdateIsPickedUp(int id);
    }
}
