using Validator.Application.Services.Implementations;
using Validator.Application.Services.Interfaces;

namespace Validator.Tests.Services
{
    public class CpfServiceTests
    {
        [Fact]
        public void InputCpfEqualDigits_Executed_ReturnFalse()
        {
            // Arrange
            var cpf = "11111111111";
            var cpfService = new CpfService();

            // Act
            var result = cpfService.VerifyEqualDigits(cpf);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void InputCpfNotEqualDigits_Executed_ReturnTrue()
        {
            // Arrange
            var cpf = "11111111112";
            var cpfService = new CpfService();

            // Act
            var result = cpfService.VerifyEqualDigits(cpf);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void InputFormatInvalidCpf_Executed_ReturnFalse()
        {
            // Arrange
            var cpf = "11111a11111";
            var cpfService = new CpfService();

            // Act
            var result = cpfService.ValidateCpf(cpf);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void InputCpfLessThan11Digits_Executed_ReturnFalse()
        {
            // Arrange
            var cpf = "111";
            var cpfService = new CpfService();

            // Act
            var result = cpfService.ValidateCpf(cpf);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void InputCpfInvalid_Executed_ReturnFalse()
        {
            // Arrange
            var cpf = "12334556789";
            var cpfService = new CpfService();

            // Act
            var result = cpfService.ValidateCpf(cpf);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void InputCpfValid_Executed_ReturnTrue()
        {
            // Arrange
            var cpf = "";
            var cpfService = new CpfService();

            // Act
            var result = cpfService.ValidateCpf(cpf);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void VerifyGenerateCpfValid_Executed_ReturnTrue()
        {
            // Arrange
            var cpfService = new CpfService();
            var cpf = cpfService.GenerateRandomCpf();

            // Act
            var result = cpfService.ValidateCpf(cpf);

            // Assert
            Assert.True(result);
        }
    }
}
