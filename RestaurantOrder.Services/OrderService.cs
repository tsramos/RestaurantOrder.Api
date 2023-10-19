using RestaurantOrder.Core.Contracts.Services;
using System.Text;

namespace RestaurantOrder.Services
{
    public class OrderService : IOrderService
    {
        private Dictionary<int, string> BreakFastMenu = new Dictionary<int, string>()
        {
            { 1,"Eggs" },
            { 2,"Toast" },
            { 3,"Coffee" }
        };

        private Dictionary<int, string> DinnerMenu = new Dictionary<int, string>()
        {
            { 1,"Steak" },
            { 2,"Potato" },
            { 3,"Wine" },
            { 4,"Cake" }
        };

        public string OrderMeal(string period, string order)
        {
            switch (period.ToLower())
            {
                case "morning":
                    return BuildMorningMeal(order);
                case "night":
                    return BuildNightMeal(order);
                default:
                    return "Select a valid period. Set morning or night";
            }
        }

        private string BuildMorningMeal(string orders)
        {
            StringBuilder meal = new StringBuilder();
            string[] orderList = orders.Split(',');
            List<int> orderNumbers = new List<int>();

            foreach (string order in orderList)
            {
                int.TryParse(order, out int orderNumber);
                if (orderNumber != default)
                {
                    orderNumbers.Add(orderNumber);
                }
            }

            orderNumbers.Sort();

            if (ValidateOrder(orderNumbers, 1))
                return "select only one dish";
            else if (orderNumbers.Count(x => x == 1) > 0)
                meal.Append(BreakFastMenu[1]);

            if (ValidateOrder(orderNumbers, 2))
                return "select only one dish";
            else if (orderNumbers.Count(x => x == 2) > 0)
                meal.Append(", " + BreakFastMenu[2]);

            if (orderNumbers.Any(x => x == 3))
            {
                int drinkCount = orderNumbers.Count(x => x == 3);
                if (drinkCount == 1)
                    meal.Append(", " + BreakFastMenu[3]);
                else
                    meal.Append(", " + BreakFastMenu[3] + $"(x{drinkCount})");
            }

            if (orderNumbers.Any(x => x != 1
                                   && x != 2
                                   && x != 3
                                ))
            {
                int errorCount = orderNumbers.Count(x => x != 1
                                                 && x != 2
                                                 && x != 3);

                for (int i = 0; i < errorCount; i++)
                {
                    meal.Append(", Error");
                }
            }

            return meal.ToString();
        }

        private string BuildNightMeal(string orders)
        {
            StringBuilder meal = new StringBuilder();
            string[] orderList = orders.Split(',');
            List<int> orderNumbers = new List<int>();

            foreach (string order in orderList)
            {
                int.TryParse(order, out int orderNumber);
                if (orderNumber != default)
                    orderNumbers.Add(orderNumber);
            }

            orderNumbers.Sort();

            if (ValidateOrder(orderNumbers, 1))
                return "select only one dish";
            else if (orderNumbers.Count(x => x == 1) > 0)
                meal.Append(DinnerMenu[1]);

            if (orderNumbers.Any(x => x == 2))
            {
                int drinkCount = orderNumbers.Count(x => x == 2);

                if (drinkCount == 1)
                    meal.Append(", " + DinnerMenu[2]);
                else
                    meal.Append(", " + DinnerMenu[2] + $"(x{drinkCount})");
            }

            if (ValidateOrder(orderNumbers, 3))
                return "select only one dish";
            else if (orderNumbers.Count(x => x == 3) > 0)
                meal.Append(", " + DinnerMenu[3]);

            if (ValidateOrder(orderNumbers, 4))
                return "select only one dish";
            else if (orderNumbers.Count(x => x == 4) > 0)
                meal.Append(", " + DinnerMenu[4]);

            if (orderNumbers.Any(x => x != 1
                                   && x != 2
                                   && x != 3
                                   && x != 4
                                ))
            {
                int errorCount = orderNumbers.Count(x => x != 1
                                                 && x != 2
                                                 && x != 3
                                                 && x != 4);

                for (int i = 0; i < errorCount; i++)
                {
                    meal.Append(", Error");
                }
            }

            return meal.ToString();
        }

        private bool ValidateOrder(List<int> order, int dishType)
        {
            return order.Count(x => x == dishType) > 1;
        }


    }
}
