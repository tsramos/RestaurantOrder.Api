using RestaurantOrder.Services;
using Moq;

namespace RestaurantOrder.Tests
{
    public class OrderServiceTest
    {

        private readonly Mock<OrderService> _serviceMock;

        public OrderServiceTest()
        {
            _serviceMock = new Mock<OrderService>();
        }

        [Theory]
        [InlineData("morning", "1,2,3", "Eggs, Toast, Coffee")]
        [InlineData("morning", "2,1,3", "Eggs, Toast, Coffee")]
        [InlineData("morning", "1,2,3,4", "Eggs, Toast, Coffee, Error")]
        [InlineData("morning", "1,2,3,3,3", "Eggs, Toast, Coffee(x3)")]
        [InlineData("night", "1,2,3,4", "Steak, Potato, Wine, Cake")]
        [InlineData("night", "1,2,2,4", "Steak, Potato(x2), Cake")]
        [InlineData("night", "1,2,3,5", "Steak, Potato, Wine, Error")]
        public void OrderMeal_ShouldBuildMeal_WhenOrderIsValid(string period, string order, string expectedResult)
        {
            //Arrange
            var sut = _serviceMock.Object;

            //Act
            string result = sut.OrderMeal(period,order);

            //Assert

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("Afternoon","1,2,3,4", "Select a valid period. Set morning or night")]
        public void OrderMeal_ShouldReturnErrorMessage_WhenPeriodIsInvalid(string period, string order, string expectedResult) 
        {
            //Arrange
            var sut = _serviceMock.Object;

            //Act
            string result = sut.OrderMeal(period, order);

            //Assert

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("morning", "1,1,2,3", "select only one dish")]
        [InlineData("morning", "1,2,2,3", "select only one dish")]
        [InlineData("Night", "1,1,2,3", "select only one dish")]
        [InlineData("night", "1,2,3,3", "select only one dish")]
        [InlineData("night", "1,2,4,4", "select only one dish")]

        public void OrderMeal_ShouldReturnErrorMessage_WhenOrderIsInvalid(string period, string order, string expectedResult)
        {
            //Arrange
            var sut = _serviceMock.Object;

            //Act
            string result = sut.OrderMeal(period, order);

            //Assert

            Assert.Equal(expectedResult, result);

        }
    }
}
