using FluentAssertions;
using Xunit;

namespace BinaryCalculator.Core.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void SimpleAdd()
        {
            var calculator = new Calculator();
            
            calculator
                .EnterOne()
                .EnterOne()
                .EnterOne()
                .Add()
                .EnterOne()
                .EnterZero()
                .EnterZero()
                .PerformOperation();

            calculator.CurrentResult.Should().Be("1011");
            calculator.CurrentInput.Should().Be("100");
            calculator.CurrentOperation.Should().Be(Calculator.Operation.Add);

            calculator.ClearAll();
            calculator.CurrentResult.Should().Be("0");
            calculator.CurrentInput.Should().Be("");
            calculator.CurrentOperation.Should().Be(Calculator.Operation.None);
        }
        
        [Fact]
        public void AddWithDoublePerformOperation()
        {
            var calculator = new Calculator();

            calculator
                .EnterOne()
                .EnterOne()
                .EnterOne()
                .Add()
                .EnterOne()
                .EnterZero()
                .EnterZero()
                .PerformOperation()
                .PerformOperation();

            calculator.CurrentResult.Should().Be("1111");
            calculator.CurrentInput.Should().Be("100");
            calculator.CurrentOperation.Should().Be(Calculator.Operation.Add);
        }
    }
}
