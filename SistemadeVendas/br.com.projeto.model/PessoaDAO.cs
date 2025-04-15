using MySql.Data.MySqlClient;
using SistemadeVendas.br.com.projeto.conexao;
using SistemadeVendas.br.com.projeto.model;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemadeVendas.br.com.projeto.dao
{
    public abstract class PessoaDAO
    {
        protected MySqlConnection conexao;
        protected string nomeTabela;

        public PessoaDAO(string nomeTabela)
        {
            this.conexao = new ConnectionFactory().getconnection();
            this.nomeTabela = nomeTabela;
        }

        protected void AdicionarParametrosPessoa(MySqlCommand cmd, Pessoa obj)
        {
            cmd.Parameters.AddWithValue("@nome", obj.nome);
            cmd.Parameters.AddWithValue("@email", obj.email);
            cmd.Parameters.AddWithValue("@telefone", obj.telefone);
            cmd.Parameters.AddWithValue("@celular", obj.celular);
            cmd.Parameters.AddWithValue("@cep", obj.cep);
            cmd.Parameters.AddWithValue("@endereco", obj.endereco);
            cmd.Parameters.AddWithValue("@numero", obj.numero);
            cmd.Parameters.AddWithValue("@complemento", obj.complemento);
            cmd.Parameters.AddWithValue("@bairro", obj.bairro);
            cmd.Parameters.AddWithValue("@cidade", obj.cidade);
            cmd.Parameters.AddWithValue("@estado", obj.estado);
            cmd.Parameters.AddWithValue("@codigo", obj.codigo); // Para updates e deletes
        }

        public virtual DataTable ListarTodos()
        {
            try
            {
                DataTable tabela = new DataTable();
                string sql = $"SELECT * FROM {nomeTabela}";
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabela);
                conexao.Close();
                return tabela;
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao listar na tabela {nomeTabela}: " + erro);
                return null;
            }
        }

        public virtual Pessoa BuscarPorCodigo(int codigo)
        {
            try
            {
                string sql = $"SELECT * FROM {nomeTabela} WHERE id = @codigo";
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@codigo", codigo);
                conexao.Open();
                MySqlDataReader dr = executacmd.ExecuteReader();
                Pessoa pessoa = null;

                if (dr.Read())
                {
                    pessoa = CriarObjetoPessoa(dr);
                }
                conexao.Close();
                return pessoa;
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao buscar por código na tabela {nomeTabela}: " + erro);
                return null;
            }
        }

        protected abstract Pessoa CriarObjetoPessoa(MySqlDataReader dr);

        public abstract void Cadastrar(Pessoa obj);

        public abstract void Alterar(Pessoa obj);

        public abstract void Excluir(Pessoa obj);

        public abstract DataTable BuscarPorNome(string nome);
    }
}