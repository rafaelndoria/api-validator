﻿using Validator.Application.Services.Interfaces;

namespace Validator.Application.Services.Implementations
{
    public class CpfService : ICpfService
    {
        public bool ValidateCpf(string cpf)
        {
            try
            {
                ulong.TryParse(cpf, out ulong _);

                if (cpf.Length != 11)
                    return false;

                if (!VerifyEqualDigits(cpf))
                    return false;

                var nineDigitsCpf = cpf.Substring(0, 9);
                var verifyingDigit = cpf.Substring(9, 2);

                string resultVerifyingDigit = "";

                resultVerifyingDigit = GetFirstVerifyingDigit(nineDigitsCpf);
                resultVerifyingDigit += GetSecondVerifyingDigit(nineDigitsCpf, resultVerifyingDigit);

                if (resultVerifyingDigit != verifyingDigit)
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetFirstVerifyingDigit(string nineDigits)
        {
            var array = nineDigits.ToCharArray();
            int sum = 0;
            int a = 10;

            foreach (var digit in array)
            {
                int digitNumber = int.Parse(digit.ToString());
                sum += (digitNumber * a);
                a--;
            }

            var result = sum % 11;
            result = 11 - result;

            if (result >= 10)
                return "0";

            return result.ToString();
        }

        public string GetSecondVerifyingDigit(string nineDigits, string firstVerifyingDigit)
        {
            var cpf = nineDigits + firstVerifyingDigit;
            var array = cpf.ToCharArray();
            int sum = 0;
            int a = 11;

            foreach (var digit in array)
            {
                int digitNumber = int.Parse(digit.ToString());
                sum += (digitNumber * a);
                a--;
            }

            var result = sum % 11;
            result = 11 - result;

            if (result >= 10)
                return "0";

            return result.ToString();
        }

        public bool VerifyEqualDigits(string cpf)
        {
            var array = cpf.ToCharArray();
            int quantity = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (i != 10)
                {
                    if (array[i].ToString() == array[i+1].ToString())
                        quantity++;
                }
            }

            if (quantity == 10)
                return false;

            return true;
        }

        public string GenerateRandomCpf()
        {
            var random = new Random();
            var nineDigitsCpf = "";

            for (int i = 0; i < 9; i++)
            {
                nineDigitsCpf += random.Next(0, 10).ToString();
            }

            var firstVerifyingDigit = GetFirstVerifyingDigit(nineDigitsCpf);
            var secondVerifyingDigit = GetSecondVerifyingDigit(nineDigitsCpf, firstVerifyingDigit);

            return nineDigitsCpf + firstVerifyingDigit + secondVerifyingDigit;
        }
    }
}
