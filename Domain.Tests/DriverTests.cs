using Domain.Constants;
using FluentAssertions;
using Moq;
using Xunit;

namespace Domain.Tests
{
    public class DriverTests
    {
        [Fact]
        public void DriverNotDrunk_Should_ArriveAtHome()
        {
            // ARRANGE
            var carMock = new Mock<ICar>();

            // ACT
            var driver = new Driver(carMock.Object);
            var result = driver.GoHome(isDrunk: false);

            // ASSERT
            result.Should().BeTrue();
        }
        [Fact]
        public void DriverNotDrunk_Shouldnt_HaveBreakDown()
        {
            // ARRANGE
            var carMock = new Mock<ICar>();

            // ACT
            var driver = new Driver(carMock.Object);
            var result = driver.GoHome(isDrunk: false);

            // ASSERT
            carMock.Verify(c => c.BreakDown(), Times.Never);
        }
        [Fact]
        public void DriverNotDrunk_Should_Stop()
        {
            // ARRANGE
            var carMock = new Mock<ICar>();

            // ACT
            var driver = new Driver(carMock.Object);
            var result = driver.GoHome(isDrunk: false);

            // ASSERT
            carMock.Verify(c => c.Stop(), Times.Once);
        }
        [Fact]
        public void DriverNotDrunk_Should_MoveAtLegalSpeedLimit()
        {
            // ARRANGE
            var carMock = new Mock<ICar>();
            carMock.Setup(c => c.Move(Speed.LegalLimitation)).Verifiable();

            // ACT
            var driver = new Driver(carMock.Object);
            var result = driver.GoHome(isDrunk: false);

            // ASSERT
            carMock.Verify();
        }
        [Fact]
        public void DriverNotDrunk_ShouldNot_MoveTooFast()
        {
            // ARRANGE
            var carMock = new Mock<ICar>();

            // ACT
            var driver = new Driver(carMock.Object);
            var result = driver.GoHome(isDrunk: false);

            // ASSERT
            carMock.Verify(c => c.Move(It.IsInRange<int>(0, Speed.LegalLimitation, Range.Inclusive)));
            carMock.Verify(c => c.Move(200), Times.Never);
        }
        [Fact]
        public void DriverNotDrunk_Should_StartMoveAndStop()
        {
            // ARRANGE
            var carMock = new Mock<ICar>();
            carMock.Setup(c => c.Start());
            carMock.Setup(c => c.Move(It.IsAny<int>()));
            carMock.Setup(c => c.Stop());

            // ACT
            var driver = new Driver(carMock.Object);
            var result = driver.GoHome(isDrunk: false);

            // ASSERT
            carMock.VerifyAll();
        }

        [Fact]
        public void DriverNotDrunk_Should_StartMoveAndStopInSequence()
        {
            // ARRANGE
            // To assert sequence, moq behavior must be 'Strict'
            var carMock = new Mock<ICar>(MockBehavior.Strict);

            var sequence = new MockSequence();
            carMock.InSequence(sequence).Setup(c => c.Start()).Returns(true); // 'Strict' behavior require a return value, like in real life
            carMock.InSequence(sequence).Setup(c => c.Move(It.IsAny<int>()));
            carMock.InSequence(sequence).Setup(c => c.Stop()).Returns(true);

            // ACT
            var driver = new Driver(carMock.Object);
            var result = driver.GoHome(isDrunk: false);

            // ASSERT
            // auto assertion if it's a correct sequence
        }

        [Fact]
        public void DriverNotDrunk_Should_StartMoveAndStop_bis()
        {
            // ARRANGE
            var carMock = new Mock<ICar>();
            carMock.Setup(c => c.Start()).Verifiable();
            carMock.Setup(c => c.Move(It.IsAny<int>())).Verifiable();
            carMock.Setup(c => c.Stop()).Verifiable();

            // ACT
            var driver = new Driver(carMock.Object);
            var result = driver.GoHome(isDrunk: false);

            // ASSERT
            carMock.Verify();
            carMock.VerifyNoOtherCalls();
        }
        [Fact]
        public void DriverDrunk_Should_NotArriveAtHome()
        {
            // ARRANGE
            var carMock = new Mock<ICar>();

            // ACT
            var driver = new Driver(carMock.Object);
            var result = driver.GoHome(isDrunk: true);

            // ASSERT
            result.Should().BeFalse();
        }
        [Fact]
        public void DriverDrunk_Should_HaveBreakDown()
        {
            // ARRANGE
            var carMock = new Mock<ICar>();
            carMock.Setup(c => c.BreakDown()).Verifiable();

            // ACT
            var driver = new Driver(carMock.Object);
            var result = driver.GoHome(isDrunk: true);

            // ASSERT
            carMock.Verify();
        }
        [Fact]
        public void DriverDrunk_Should_HaveBreakDown_bis()
        {
            // ARRANGE
            var carMock = new Mock<ICar>();

            // ACT
            var driver = new Driver(carMock.Object);
            var result = driver.GoHome(isDrunk: true);

            // ASSERT
            carMock.Verify(c => c.BreakDown());
        }
        [Fact]
        public void DriverDrunk_Should_MoveTooFast()
        {
            // ARRANGE
            var carMock = new Mock<ICar>();

            // ACT
            var driver = new Driver(carMock.Object);
            var result = driver.GoHome(isDrunk: true);

            // ASSERT
            carMock.Verify(c => c.Move(It.IsAny<int>()));
            carMock.Verify(c => c.Move(Speed.LegalLimitation), Times.Never);
        }
    }
}
