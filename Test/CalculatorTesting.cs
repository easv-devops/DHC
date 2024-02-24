using app;
using Moq;
using NUnit.Framework;

namespace Test;


public class CalculatorServiceTests
{
    
    // Represents a mock object of the ICalculator interface
    private Mock<ICalculator> _calculatorMock;

    
    // Represents our calculator service
    private CalculatorService _calculatorService;

    
    // Sets up the environment for running unit tests by initializing the necessary objects.
    [SetUp]
    public void Setup()
    {
        _calculatorMock = new Mock<ICalculator>();
        _calculatorService = new CalculatorService(_calculatorMock.Object);
    }
    
    // Test method for performing arithmetic operations using a calculator service.
    // This test method verifies that the PerformOperation method of the CalculatorService class
    // correctly performs the specified arithmetic operation on the given numbers and returns the
    // expected result.
    [TestCase("add", 1, 2, 3)]
    [TestCase("subtract", 5, 3, 2)]
    [TestCase("multiply", 4, 2, 8)]
    [TestCase("divide", 8, 2, 4)]
    public void TestPerformOperation(string operation, double n1, double n2, double expected)
    {
        _calculatorMock.Setup(c => c.Add(It.IsAny<double>(), It.IsAny<double>())).Returns((double a, double b) => a + b);
        _calculatorMock.Setup(c => c.Subtract(It.IsAny<double>(), It.IsAny<double>())).Returns((double a, double b) => a - b);
        _calculatorMock.Setup(c => c.Multiply(It.IsAny<double>(), It.IsAny<double>())).Returns((double a, double b) => a * b);
        _calculatorMock.Setup(c => c.Divide(It.IsAny<double>(), It.IsAny<double>())).Returns((double a, double b) => a / b);

        double result = _calculatorService.PerformOperation(n1, n2, operation);
            
        Assert.That(result, Is.EqualTo(expected));
    }

    // This method tests whether PerformOperation method throws an exception when an invalid operation is passed as a parameter.
    [Test]
    public void TestPerformOperation_ThrowsException_OnInvalidOperation()
    {
        Assert.Throws<InvalidOperationException>(() => _calculatorService.PerformOperation(1, 2, "invalid"));
    }
}