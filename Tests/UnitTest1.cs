using Xunit;

namespace razorJqueryProject.Tests;

public class UnitTest1
{
    [Fact]
    public void PassingTest()
    {
    
        // Assert
        Assert.Equal(4, Add(2,2));

    }
    
    static int Add(int a, int b)
    {
        return a + b;
    }


}