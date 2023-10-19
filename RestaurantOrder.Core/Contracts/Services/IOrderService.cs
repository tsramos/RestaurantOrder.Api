namespace RestaurantOrder.Core.Contracts.Services
{
    public interface IOrderService
    {
        string OrderMeal(string period, string order);
    }
}
