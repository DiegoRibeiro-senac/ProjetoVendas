using MySql.Data.MySqlClient;
using SistemadeVendas.br.com.projeto.conexao;
using SistemadeVendas.br.com.projeto.model;
using System;
using System.Windows.Forms;

namespace SistemadeVendas.br.com.projeto.dao
{
    public class ClienteDAO
    {
        private MySqlConnection conexao;

        public ClienteDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }

        #region CadastrarClientes

        public void cadastrarCliente(Cliente obj)
        {
            try
            {
                //passo 1 - Definir o comando sql para o insert

                string sql = @"insert into tb_clientes(nome,rg,cpf,email,telefone,celular,cep,endereco,numero,complemento,bairro,cidade, estado)
                             values(@nome, @rg, @cpf, @email, @telefone, @celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado) ";

                // 2 passo - organizar o comando sql

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);

                // 3 passo - Abrir a conexão e executar o comando sql

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Cleinte Cadastrado com sucesso");

                //Avaliar a situação com o fechamento do banco nesse momento
                // Fechando a conexão com o banco de Dados

                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro:" + erro);
            }
        }

        #endregion CadastrarClientes
    }
}