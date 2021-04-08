namespace Calculator.Src.UnitTests.Extensions
{
    using System;
    using Microsoft.Extensions.Logging;
    using Moq;

    public static class MockLoggerExtensions
    {
        // Adapted from: https://adamstorr.azurewebsites.net/blog/mocking-ilogger-with-moq
        public static Mock<ILogger<T>> VerifyInformationWasCalled<T>(this Mock<ILogger<T>> logger, string expectedMessage)
        {
            Func<object, Type, bool> state = (v, t) => v.ToString() == expectedMessage;

            logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Information),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => state(v, t)),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)));

            return logger;
        }
    }
}