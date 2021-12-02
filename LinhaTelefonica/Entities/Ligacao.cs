using System.Globalization;

namespace LinhaTelefonica.Entities
{
    class Ligacao
    {
        public double Numero { get; set; }
        public int Duracao { get; set; }
        public string Time { get; set; }
        public double Cost { get; private set; }

        public Ligacao(double numero, int duracao, string time)
        {
            Numero = numero;
            Duracao = duracao;
            Time = time;
            Cost = duracao * 0.001;
        }

        public override string ToString()
        {
            return "\nNúmero: " + Numero.ToString("F0", CultureInfo.InvariantCulture) + "\nDuração: " + Time + "\nCusto da ligação: R$" + Cost.ToString("F2", CultureInfo.InvariantCulture) + "\n";
        }
    }
}
