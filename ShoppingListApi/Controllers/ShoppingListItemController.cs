using Microsoft.AspNetCore.Mvc;
using ShoppingListApi.Models;
using ShoppingListApi.Services;
using ShoppingListApi.Dtos;

namespace ShoppingListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListItemController : ControllerBase
    {
        private readonly IShoppingListItemRepository _shoppingListItemRepository;

        public ShoppingListItemController(IShoppingListItemRepository itemRepository)
        {
            _shoppingListItemRepository= itemRepository;
        }

        [HttpGet]
        public async Task<List<ShoppingListItem>> GetAllShoppingListitems()
        {
            return await _shoppingListItemRepository.GetAllShoppingListItems();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewShoppingListItem(NewShoppingListItemDto itemDto)
        {
            bool isSuccessfull = await _shoppingListItemRepository.AddNewShoppingListItem(itemDto.ItemName);
            if (isSuccessfull)
            {
                return Created("ShoppingListItem", "New item added succeffully");
            }
            else
            {
                return BadRequest("Failed to add new item");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateIsPickedUp(ShopListItemIdDto idDto)
        {
            bool isSuccessfull = await _shoppingListItemRepository.UpdateIsPickedUp(idDto.Id);

            if (isSuccessfull)
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Failed to change picked up status");
            }
        }
    }
}
