namespace Validator.Application.Services.Interfaces
{
    public interface ICpfService
    {
        bool ValidateCpf(string cpf);
        string GetFirstVerifyingDigit(string nineDigits);
        string GetSecondVerifyingDigit(string nineDigits, string firstVerifyingDigit);
        bool VerifyEqualDigits(string cpf);
        string GenerateRandomCpf();
    }
}
