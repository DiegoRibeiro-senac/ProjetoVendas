﻿using MySql.Data.MySqlClient;
using SistemadeVendas.br.com.projeto.conexao;
using SistemadeVendas.br.com.projeto.model;
using System;
using System.Data;
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

        #region ListarClientes

        public DataTable listarClientes()
        {
            try
            {
                //1 passo - Criar o DataTable e o comando sql
                DataTable tabelacliente = new DataTable();
                string sql = "select * from tb_clientes";

                //2 passo - Organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                conexao.Open();

                //3 passo - Criar o MySQLDataApter para preencher os dados no DataTable;
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);

                //Fechar a conexao
                conexao.Close();

                return tabelacliente;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar o comando sql: " + erro);
                return null;
            }
        }

        #endregion ListarClientes

        #region AlterarCliente

        public void alterarCliente(Cliente obj)
        {
            try
            {
                //1 passo - definir o cmd sql -  insert into
                string sql = @"update tb_clientes set nome=@nome,rg=@rg,cpf=@cpf,email=@email,telefone=@telefone,celular=@celular,cep=@cep,
                              endereco=@endereco,numero=@numero,complemento=@complemento,bairro=@bairro,cidade=@cidade,estado=@estado
                              where id=@id";

                //2 passo - Organizar o cmd sql
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

                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                //3 passo - Abrir a conexao e executar o comando sql
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Cliente Alterado com sucesso!");

                //Fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }

        #endregion AlterarCliente

        #region ExcluirCliente

        public void excluirClientes(Cliente obj)
        {
            try
            {
                //1 passo - definir o cmd sql -  Delete
                string sql = @"Delete from tb_clientes where id=@id";

                //2 passo - Organizar o cmd sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                //3 passo - Abrir a conexao e executar o comando sql
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Cliente Excluido com sucesso!");

                //Fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o erro" + erro);
            }
        }

        #endregion ExcluirCliente

        #region PesquisaNome

        public DataTable BuscarClientePorNome(string nome)
        {
            try
            {
                //1 passo - definir o cmd sql -  Delete
                DataTable tabelacliente = new DataTable();
                string sql = "select * from tb_clientes where nome=@nome";

                //2 passo - Organizar o cmd sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);

                //3 passo - Abrir a conexao e executar o comando sql
                conexao.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);

                //Fechar a conexao
                conexao.Close();
                return tabelacliente;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar o comando Sql:" + erro);
                return null;
            }
        }

        #endregion PesquisaNome
    }
}