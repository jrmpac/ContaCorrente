using ContaCorrente.ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente
{
    internal class ContaCorrente
    {
        public decimal Saldo { get; set; }
        public int Numero { get; set; }
        public decimal Limite { get; set; }
        public bool EhEspecial { get; set; }
        public Movimentacao[] movimentacoes;

        private int indice = 0;

        //extrato

        //    exibir saque e exibir saldo atual

        //    exibir deposito e exibir saldo atual

        //    calcular saldo e exibir saldo atual

        //    mostrar todas movimentações feitas na conta

        //    mostrar saldo
        public decimal Sacar(decimal valor)
        {
            if (valor >= Limite + Saldo)
            {
                Console.WriteLine("> Limite de saque excedido.");
            }

            else
            {
                Saldo -= valor;

                Console.WriteLine($">> Saque efetuado no valor de {valor}");

                ExibirSaldo();

                AdicionarMovimentacao("DEBITO", $">> Saque no valor de {valor}");

                Console.ReadKey();
            }

            return Saldo;
        }

        public decimal Depositar(decimal valor)
        {
            Saldo += valor;

            Console.WriteLine($"> Depósito no valor de {valor} efetuado com sucesso!");

            ExibirSaldo();

            AdicionarMovimentacao("CREDITO", $"> Depósito no valor de {valor}.");

            Console.ReadKey();
            return Saldo;

        }

        public void ExibirExtrato()
        {
            Console.WriteLine("-------------------------- Extrato --------------------------\n", ConsoleColor.Yellow);

            for (int i = 0; i < indice; i++)
            {
                if (movimentacoes[i].Tipo == "DEBITO")
                {
                    Console.WriteLine(movimentacoes[i].Mensagem, ConsoleColor.Red);
                }

                else if (movimentacoes[i].Tipo == "CREDITO")
                {
                    Console.WriteLine(movimentacoes[i].Mensagem, ConsoleColor.Green);
                }
            }

            Console.WriteLine("-------------------------- Extrato --------------------------\n", ConsoleColor.Yellow);

        }

        public void TransferirPara(ContaCorrente conta, decimal valor)
        {
            if (conta == this)
            {
                Console.WriteLine("Não é possível transferir para sua própria conta!", ConsoleColor.Red);
            }

            else if (Saldo < valor)
            {
                Console.WriteLine("Saldo insuficiente!", ConsoleColor.Red);
            }

            else
            {
                Saldo -= valor;
                conta.Saldo += valor;
                Console.WriteLine($"> Transferencia no valor de {valor} para a conta de número {conta.Numero} enviada com sucesso");

                ExibirSaldo();

                AdicionarMovimentacao("DEBITO", $"> Transferencia no valor de {valor} para a conta número {conta.Numero}");
            }
        }
        public void AdicionarMovimentacao(string tipoDeMovimentacao, string mensagem)
        {
            Movimentacao movimentacao = new Movimentacao();
            movimentacao.Tipo = tipoDeMovimentacao;
            movimentacao.Mensagem = mensagem;

            for (int i = 0; i < movimentacoes.Length; i++)
            {
                movimentacoes[indice] = movimentacao;
            }

            indice++;
        }

        public void ExibirSaldo()
        {
            Console.WriteLine($"> Seu saldo é de: {Saldo}");
        }
    }
}

