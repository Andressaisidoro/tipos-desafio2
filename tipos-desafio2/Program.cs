using System;

class ContaBancaria
{
    public string Titular { get; private set; }
    public double Saldo { get; private set; }

    public ContaBancaria(string titular, double saldoInicial)
    {
        Titular = titular;
        Saldo = saldoInicial;
    }

    public void Depositar(double valor)
    {
        Saldo += valor;
        Console.WriteLine($"Depósito de {valor} realizado com sucesso. Novo saldo: {Saldo}");
    }

    public bool Sacar(double valor)
    {
        if (valor > Saldo)
        {
            Console.WriteLine("Saldo insuficiente");
            return false;
        }
        else
        {
            Saldo -= valor;
            Console.WriteLine($"Saque de {valor} realizado com sucesso. Novo saldo: {Saldo}");
            return true;
        }
    }

    public void ExibirSaldo()
    {
        Console.WriteLine($"Saldo atual da conta de {Titular}: {Saldo}");
    }

    public bool Transferir(ContaBancaria destino, double valor)
    {
        if (Sacar(valor))
        {
            destino.Depositar(valor);
            Console.WriteLine($"Transferência de {valor} para a conta de {destino.Titular} realizada com sucesso.");
            return true;
        }
        else
        {
            Console.WriteLine($"Transferência de {valor} para a conta de {destino.Titular} falhou.");
            return false;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criando uma conta bancária para João com saldo inicial de 1000
        ContaBancaria contaJoao = new ContaBancaria("João", 1000);

        // Realizando operações na conta de João
        contaJoao.Depositar(500);
        contaJoao.Sacar(200);
        contaJoao.ExibirSaldo();

        // Criando uma nova conta bancária para Maria com saldo inicial de 2000
        ContaBancaria contaMaria = new ContaBancaria("Maria", 2000);

        // Transferindo 300 da conta de Maria para a conta de João
        contaMaria.Transferir(contaJoao, 300);

        // Exibindo os saldos atualizados das contas
        contaJoao.ExibirSaldo();
        contaMaria.ExibirSaldo();
    }
}
