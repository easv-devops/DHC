using app;
using Moq;

namespace Test;

[TestFixture]
public class CalculatorClassTests
{
    private Mock<ICalculatorRepository> _mockRepository;
    private Calculator _calculator;

    [SetUp]
    public void Setup()
    {
        _mockRepository = new Mock<ICalculatorRepository>();
        _calculator = new Calculator(_mockRepository.Object);
    }

    [Test]
    public void Add_TwoNumbers_AddsCorrectly()
    {
        double result = _calculator.Add(2, 2);
        Assert.That(result, Is.EqualTo(4));
        _mockRepository.Verify(r => r.LogCalculation(2, 2, "+", 4));
    }

    [Test]
    public void Subtract_TwoNumbers_SubtractsCorrectly()
    {
        double result = _calculator.Subtract(5, 3);
        Assert.That(result, Is.EqualTo(2));
        _mockRepository.Verify(r => r.LogCalculation(5, 3, "-", 2));
    }

    [Test]
    public void Multiply_TwoNumbers_MultipliesCorrectly()
    {
        double result = _calculator.Multiply(2, 7);
        Assert.That(result, Is.EqualTo(14));
        _mockRepository.Verify(r => r.LogCalculation(2, 7, "*", 14));
    }

    [Test]
    public void Divide_TwoNumbers_DividesCorrectly()
    {
        double result = _calculator.Divide(20, 10);
        Assert.That(result, Is.EqualTo(2));
        _mockRepository.Verify(r => r.LogCalculation(20, 10, "/", 2));
    }

    [Test]
    public void Divide_DivideByZero_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
    }
}