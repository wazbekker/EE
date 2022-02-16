using System;
using Shouldly;
using Xunit;

namespace EqualExperts.Tests;

public class UnitTest1 : IDisposable
{
    public UnitTest1()
    {
        
    }
    
    [Fact]
    public void Test1()
    {
        Assert.True(true);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    public void Test2(int input, int result)
    {
        input.ShouldBe(result);

        // Assert.Throws<Exception>(() => { });
    }

    public void Dispose()
    {
    }
}