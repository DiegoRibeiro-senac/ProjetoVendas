namespace SistemadeVendas.br.com.projeto.model
{
    public class Funcionario : Pessoa
    {
        public string rg { get; set; }
        public string cpf { get; set; }
        public string senha { get; set; }
        public string cargo { get; set; }
        public string nivelAcesso { get; set; }

        public Funcionario()
        {
        }

        public Funcionario(string cargo, string rg, string cpf, string senha, string nivelAcesso, int codigo, string nome, string email, string telefone,
                           string celular, string cep, string endereco, int numero,
                           string complemento, string bairro, string cidade, string estado) : base(codigo, nome, email, telefone, celular, cep, endereco, numero, complemento, bairro, cidade, estado)
        {
            this.rg = rg;
            this.cpf = cpf;
            this.senha = senha;
            this.nivelAcesso = nivelAcesso;
            this.cargo = cargo;
        }
    }
}