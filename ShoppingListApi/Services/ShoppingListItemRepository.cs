using ShoppingListApi.Models;
using ShoppingListApi.Data;

using Microsoft.EntityFrameworkCore;

namespace ShoppingListApi.Services
{
    public class ShoppingListItemRepository : IShoppingListItemRepository
    {
        private readonly ShoppingListContext _context;

        public ShoppingListItemRepository(ShoppingListContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNewShoppingListItem(string itemName)
        {
            ShoppingListItem item = new ShoppingListItem()
            {
                ItemName = itemName,
                IsPickedUp = false,
            };

            _context.ShoppingListItems.Add(item);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ) 
            {
                return false;
            }
        }

        public async Task<List<ShoppingListItem>> GetAllShoppingListItems()
        {
            return await _context.ShoppingListItems.ToListAsync();
        }

        public async Task<bool> UpdateIsPickedUp(int id)
        {
            ShoppingListItem? item = await _context.ShoppingListItems.FindAsync(id);

            if (item is null)
            {
                return false;
            }

            item.IsPickedUp = !item.IsPickedUp;
            _context.ShoppingListItems.Update(item);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException )
            {
                return false;
            }
        }
    }
}
