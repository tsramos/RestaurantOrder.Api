using Microsoft.AspNetCore.Mvc;
using RestaurantOrder.Core.Contracts.Services;

namespace RestaurantOrder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Choose your meal
        /// </summary>
        /// <param name="order">Numbers </param>
        /// <param name="period">Period of the day</param>
        /// <returns></returns>
        [HttpGet(Name = "OrderMealtest")]
        public string OrderMeal(string period, string order)
        {
            return _orderService.OrderMeal(period, order);
        }
    }
}
