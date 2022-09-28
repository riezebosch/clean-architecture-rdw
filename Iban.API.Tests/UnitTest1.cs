using Iban.API.Controllers;
using Iban.Tests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace Iban.API.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var validator = new IbanValidator(null!);
            var controller = new IbanController();
            
            // Act & Assert
            Assert.False(controller.Get("NLINGB...", validator));
        }
    }
}