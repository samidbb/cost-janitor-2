using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using CostJanitor.Application.Commands;
using CostJanitor.Domain.Aggregates;
using CostJanitor.Domain.Services;
using Xunit;

namespace CostJanitor.Application.UnitTest.Commands
{
    public class UpdateCostItemCommandHandlerTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange            
            var mockCostService = new Mock<ICostService>();
            var sut = new UpdateCostItemCommandHandler(mockCostService.Object);

            //Act
            var hashCode = sut.GetHashCode();

            //Assert
            Assert.Equal(hashCode, sut.GetHashCode());
            Assert.NotNull(sut);

            Mock.VerifyAll();
        }

        [Fact]
        public async Task CanHandleCommand()
        {
            //Arrange
            var mockCostService = new Mock<ICostService>();
            var costItem = new CostItem("b", "c", "a");

            throw new NotImplementedException();
            
            mockCostService.Setup(m => m.CreateOrAddCostItem(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), new CancellationToken())).Returns(Task.FromResult(costItem));

            var sut = new CreateCostItemCommandHandler(mockCostService.Object);

            //Act
            var result = await sut.Handle(new CreateCostItemCommand("a", "b", "c"));

            //Assert
            Assert.Equal(result, costItem);

            Mock.VerifyAll();
        }
    }
}