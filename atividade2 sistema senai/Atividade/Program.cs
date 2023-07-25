using System;


namespace ControleClientes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criação de uma pessoa física
            PessoaFisica pessoaFisica = new PessoaFisica("João da Silva", "123.456.789-00", new DateTime(1990, 5, 15));
            pessoaFisica.PagarImpostos();

            // Criação de uma pessoa jurídica
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Empresa XYZ", "12.345.678/0001-90");
            pessoaJuridica.PagarImpostos();
            
            // Exibir informações das pessoas
            Console.WriteLine("Pessoa Física:");
            Console.WriteLine($"Nome: {pessoaFisica.Nome}");
            Console.WriteLine($"CPF: {pessoaFisica.CPF}");
            Console.WriteLine($"Data de Nascimento: {pessoaFisica.DataNascimento.ToShortDateString()}");
            Console.WriteLine($"Impostos Pagos: {pessoaFisica.Impostos.Pagos}");

            Console.WriteLine("\n\nPessoa Jurídica:");
            Console.WriteLine($"Nome: {pessoaJuridica.Nome}");
            Console.WriteLine($"CNPJ: {pessoaJuridica.CNPJ}");
            Console.WriteLine($"Impostos Pagos: {pessoaJuridica.Impostos.Pagos}");

            // Salvar informações em arquivos
            SalvarPessoaEmArquivo("pessoa_fisica.txt", pessoaFisica);
            SalvarPessoaEmArquivo("pessoa_juridica.txt", pessoaJuridica);
        }

        static void SalvarPessoaEmArquivo(string nomeArquivo, object pessoa)
        {
            using (StreamWriter writer = new StreamWriter(nomeArquivo))
            {
                if (pessoa is PessoaFisica)
                {
                    PessoaFisica pessoaFisica = (PessoaFisica)pessoa;
                    writer.WriteLine($"Nome: {pessoaFisica.Nome}");
                    writer.WriteLine($"CPF: {pessoaFisica.CPF}");
                    writer.WriteLine($"Data de Nascimento: {pessoaFisica.DataNascimento.ToShortDateString()}");
                    writer.WriteLine($"Impostos Pagos: {pessoaFisica.Impostos.Pagos}");
                }
                else if (pessoa is PessoaJuridica)
                {
                    PessoaJuridica pessoaJuridica = (PessoaJuridica)pessoa;
                    writer.WriteLine($"Nome: {pessoaJuridica.Nome}");
                    writer.WriteLine($"CNPJ: {pessoaJuridica.CNPJ}");
                    writer.WriteLine($"Impostos Pagos: {pessoaJuridica.Impostos.Pagos}");
                }
            }
        }
    }

    class PessoaFisica
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public Impostos Impostos { get; set; }

        public PessoaFisica(string nome, string cpf, DateTime dataNascimento)
        {
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
            Impostos = new Impostos();
        }

        public void PagarImpostos()
        {
            Impostos.Pagos = true;
        }
    }

    class PessoaJuridica
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public Impostos Impostos { get; set; }

        public PessoaJuridica(string nome, string cnpj)
        {
            Nome = nome;
            CNPJ = cnpj;
            Impostos = new Impostos();
        }

        public void PagarImpostos()
        {
            Impostos.Pagos = true;
        }
    }

    class Impostos
    {
        public bool Pagos { get; set; }
    }
}
