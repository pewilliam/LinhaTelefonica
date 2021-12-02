using System.Globalization;

namespace LinhaTelefonica.Entities
{
    class Phone
    {
        public string Nome { get; set; }
        public double Numero { get; private set; }
        public double Saldo { get; private set; }

        public Phone(string nome, double numero, double saldo)
        {
            Nome = nome;
            Numero = numero;
            Saldo = saldo;
        }

        public void Deposito(double valor)
        {
            Saldo += valor;
        }

        public double Ligacao(int tempo)
        {
            Saldo -= tempo * 0.001;
            return (tempo * 0.001);
        }

        public override string ToString()
        {
            return "Nome do titular: " + Nome + "\nNumero: " + Numero + "\nSaldo: R$" + Saldo.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
