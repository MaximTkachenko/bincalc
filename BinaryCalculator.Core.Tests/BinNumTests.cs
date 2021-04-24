using FluentAssertions;
using Xunit;

namespace BinaryCalculator.Core.Tests
{
    public class BinNumTests
    {
        [Fact]
        public void Add_Basic()
        {
            new BinNum("101").Add(new BinNum("11")).Value.Should().Be("1000");
            new BinNum("1111").Add(new BinNum("1111")).Value.Should().Be("11110");
            new BinNum("11111000111111100011").Add(new BinNum("111000001111110011")).Value.Should().Be("100110001001111010110");
        }
        
        [Fact]
        public void Add_EmptyNumbers_Ok()
        {
            new BinNum().Add(new BinNum()).Value.Should().Be("0");
            new BinNum("1111").Add(new BinNum()).Value.Should().Be("1111");
            new BinNum().Add(new BinNum("1111")).Value.Should().Be("1111");
        }

        [Fact]
        public void Subtract_Basic()
        {
            new BinNum("1111").Subtract(new BinNum("11")).Value.Should().Be("1100");
            new BinNum("1111").Subtract(new BinNum("1111")).Value.Should().Be("0");
            new BinNum("1111").Subtract(new BinNum("101")).Value.Should().Be("1010");
            new BinNum("1100").Subtract(new BinNum("11")).Value.Should().Be("1001");
            new BinNum("111100001110101010").Subtract(new BinNum("11000000111111")).Value.Should().Be("111001001101101011");
        }

        [Fact]
        public void Subtract_EmptyNumbers_Ok()
        {
            new BinNum("1111").Subtract(new BinNum()).Value.Should().Be("1111");
            new BinNum().Subtract(new BinNum()).Value.Should().Be("0");
        }

        [Fact]
        public void Append_Basic()
        {
            var bn = new BinNum();
            bn.Value.Should().Be("0");
            
            bn.AppendZero();
            bn.AppendZero();
            bn.AppendZero();
            bn.Value.Should().Be("0");

            bn.AppendOne();
            bn.Value.Should().Be("1");
            
            bn.AppendOne();
            bn.AppendZero();
            bn.AppendOne();
            bn.Value.Should().Be("1101");
        }
    }
}
