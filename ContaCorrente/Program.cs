namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta1 = new();
            conta1.Saldo = 1000;
            conta1.Numero = 12;
            conta1.Limite = 0;
            conta1.EhEspecial = true;
            conta1.movimentacoes = new Movimentacao[10];

            conta1.Sacar(200);

            conta1.Depositar(300);

            conta1.Depositar(500);

            conta1.Sacar(200);

            ContaCorrente conta2 = new();
            conta2.Saldo = 300;
            conta2.Numero = 13;
            conta2.Limite = 0;
            conta2.EhEspecial = true;
            conta2.movimentacoes = new Movimentacao[10];

            conta1.TransferirPara(conta2, 400);

            conta1.ExibirExtrato();

            Console.ReadKey();
        }
    }
}