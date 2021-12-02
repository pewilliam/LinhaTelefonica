using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using LinhaTelefonica.Entities;

namespace LinhaTelefonica
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ligacao> list = new List<Ligacao>();

            int escolha = 1;
            Phone Conta;

            Console.Write("Nome do titular da conta: ");
            string nome = Console.ReadLine();
            Console.Write("Número de telefone: ");
            double numeroTelefone = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Valor inicial da conta: R$");
            double valorInicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Conta = new Phone(nome, numeroTelefone, valorInicial);

            while (escolha != 0)
            {
                Console.Clear();
                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("1 - Verificar dados da conta");
                Console.WriteLine("2 - Depositar");
                Console.WriteLine("3 - Ligar");
                Console.WriteLine("4 - Consultar histórico de ligações");
                Console.WriteLine("0 - Sair");

                escolha = int.Parse(Console.ReadLine());

                if (escolha < 0 || escolha > 4)
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    Console.WriteLine("Por favor, digite uma opção válida...");
                    Thread.Sleep(3000);
                }

                else
                {
                    Console.Clear();

                    switch (escolha)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine(Conta);
                            Console.WriteLine("\nPressione enter para continuar...");
                            Console.ReadLine();
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("Digite o valor que deseja depositar: ");
                            double valorDeposito = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            Conta.Deposito(valorDeposito);
                            break;

                        case 3:
                            Console.Clear();
                            Console.Write("Digite o número que deseja telefonar: ");
                            double numero = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            Console.Write("Digite o tempo de ligação (em segundos): ");
                            int duracao = int.Parse(Console.ReadLine());

                            DateTime d1 = DateTime.Now;
                            DateTime d2 = d1.AddSeconds(duracao);

                            TimeSpan t = d2 - d1;

                            if ((duracao * 0.001) <= Conta.Saldo) // padrao determinado (1 segundo equivale a R$ 0.001
                            {
                                Console.Clear();
                                Conta.Ligacao(duracao);
                                list.Add(new Ligacao(numero, duracao, t.ToString()));

                                Console.WriteLine("Ligação efetuada com sucesso!");
                                Console.WriteLine("Saldo após chamada: R$" + Conta.Saldo.ToString("F2", CultureInfo.InvariantCulture));
                                Console.WriteLine("Custo da ligação: R$" + Conta.Ligacao(duracao).ToString("F2", CultureInfo.InvariantCulture));
                                Console.WriteLine("\nAperte enter para continuar...");
                                Console.ReadLine();
                            }

                            else
                            {
                                Console.Clear();
                                Console.WriteLine("O saldo atual de R$ " + Conta.Saldo.ToString("F2", CultureInfo.InvariantCulture) + " é insuficiente para realizar a ligação.");
                                Console.WriteLine("Considere pôr créditos para continuar efetuando ligações.");
                                Console.WriteLine("\nPressione enter para continuar...");
                                Console.ReadLine();
                            }

                            break;

                        case 4:
                            Console.Clear();
                            foreach (Ligacao obj in list)
                            {
                                Console.WriteLine("Ligação #" + (list.IndexOf(obj) + 1));
                                Console.WriteLine(obj);
                            }

                            Console.WriteLine("Pressione enter para continuar...");
                            Console.ReadLine();
                            break;

                        case 0:
                            break;
                    }
                }
            }
        }
    }
}
