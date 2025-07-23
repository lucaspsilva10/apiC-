using System.Net.Mail;


namespace APIEstudo.Domain.Validation
{
    public static class UsuarioValidation
    {
        public static (bool valido, string mensagem) CpfValidation(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return (false, "CPF está vazio.");

            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
                return (false, "CPF deve conter 11 dígitos.");

            if (cpf.All(c => c == cpf[0]))
                return (false, "CPF não pode ter todos os dígitos iguais.");

            var numeros = cpf.Select(c => int.Parse(c.ToString())).ToArray();

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += numeros[i] * (10 - i);

            int digito1 = soma % 11 < 2 ? 0 : 11 - (soma % 11);
            if (numeros[9] != digito1)
                return (false, "Primeiro dígito verificador inválido.");

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += numeros[i] * (11 - i);

            int digito2 = soma % 11 < 2 ? 0 : 11 - (soma % 11);
            if (numeros[10] != digito2)
                return (false, "Segundo dígito verificador inválido.");

            return (true, "CPF válido.");
        }

        public static (bool valido, string mensagem) EmailValidation(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return (false, "E-mail está vazio.");

            try
            {
                var addr = new MailAddress(email);
                return (true, "E-mail válido.");
            }
            catch
            {
                return (false, "Formato de e-mail inválido.");
            }
        }
    }
}
