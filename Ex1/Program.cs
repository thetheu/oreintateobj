using System;

namespace Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo - ThetheuBank");


            ContaCorrente conta1 = new ContaCorrente();
            conta1.titular = "Cesar";
            conta1.agencia = 132;
            conta1.numeroConta = 999;
            conta1.Despositar(10000);


            ContaCorrente conta2 = new ContaCorrente();
            conta2.titular = "Matheus";
            conta2.agencia = 132;
            conta2.numeroConta = 1;
            conta2.Despositar(15000);


            Console.WriteLine($"----Primeira conta----");
            Console.WriteLine($"titular: {conta1.titular}");
            Console.WriteLine($"Agencia: {conta1.agencia}");
            Console.WriteLine($"Numero da conta: {conta1.numeroConta}");
            Console.WriteLine($"saldo: {conta1.ExibirSaldo()}");
            Console.WriteLine("----------------------");


            Console.WriteLine($"----Segunda conta----");
            Console.WriteLine($"titular: {conta2.titular}");
            Console.WriteLine($"Agencia: {conta2.agencia}");
            Console.WriteLine($"Numero da conta: {conta2.numeroConta}");
            Console.WriteLine($"saldo: {conta2.ExibirSaldo()}");
            Console.WriteLine("----------------------");

            // bool valorRetorno = conta1.Sacar(4500);
            // if(valorRetorno){
            //     Console.WriteLine("Parabéns você conseguiu!");
            // }else{
            //     Console.WriteLine("Você não tem dinheiro na conta!");
            // }
            // Console.WriteLine($"Saldo depois do saque: {conta1.ExibirSaldo()}");


            conta2.Transferir(1000, conta1);

            Console.WriteLine($"Saldo conta 1: {conta1.ExibirSaldo()}");
            Console.WriteLine($"Saldo conta 2: {conta2.ExibirSaldo()}");
        }
    }
}