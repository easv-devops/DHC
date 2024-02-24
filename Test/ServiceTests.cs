using app;
using Moq;

namespace Test;

[TestFixture]
public class ServiceTests
{
    private Mock<ICalculator> _mockCalculator;
    private CalculatorService _calculatorService;
    
    [SetUp]
    public void SetUp()
    {
        _mockCalculator = new Mock<ICalculator>();
        _calculatorService = new CalculatorService(_mockCalculator.Object);
    }

    [Test]
    public void PerformOperation_Add_ReturnsCorrectResult()
    {
        _mockCalculator.Setup(x => x.Add(It.IsAny<double>(), It.IsAny<double>())).Returns(5);

        double result = _calculatorService.PerformOperation(2, 3, "add");

        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void PerformOperation_Subtract_ReturnsCorrectResult()
    {
        _mockCalculator.Setup(x => x.Subtract(It.IsAny<double>(), It.IsAny<double>())).Returns(1);

        double result = _calculatorService.PerformOperation(3, 2, "subtract");

        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void PerformOperation_Multiply_ReturnsCorrectResult()
    {
        _mockCalculator.Setup(x => x.Multiply(It.IsAny<double>(), It.IsAny<double>())).Returns(6);

        double result = _calculatorService.PerformOperation(2, 3, "multiply");

        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void PerformOperation_Divide_ReturnsCorrectResult()
    {
        _mockCalculator.Setup(x => x.Divide(It.IsAny<double>(), It.IsAny<double>())).Returns(2);

        double result = _calculatorService.PerformOperation(4, 2, "divide");

        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void PerformOperation_InvalidOperation_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => _calculatorService.PerformOperation(2, 3, "invalid"));
    }
}