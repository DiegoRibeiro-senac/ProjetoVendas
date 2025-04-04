using SistemadeVendas.br.com.projeto.dao;
using SistemadeVendas.br.com.projeto.model;
using System;
using System.Windows.Forms;

namespace SistemadeVendas.br.com.projeto.view
{
    public partial class Frmclientes : Form
    {
        public Frmclientes()
        {
            InitializeComponent();
        }

        private void btnsalvar_Click(object sender, EventArgs e)
        {
            // 1 passo - Receber os dados dentro do objeto modelo de cliente

            Cliente obj = new Cliente();

            obj.nome = txtnome.Text;
            obj.rg = txtrg.Text;
            obj.cpf = txtcpf.Text;
            obj.email = txtemail.Text;
            obj.telefone = txttelefone.Text;
            obj.celular = txtcelular.Text;
            obj.cep = txtcep.Text;
            obj.endereco = txtendereco.Text;
            obj.numero = int.Parse(txtnumero.Text);
            obj.complemento = txtcomplemento.Text;
            obj.bairro = txtbairro.Text;
            obj.cidade = txtcidade.Text;
            obj.estado = cbuf.Text;

            // passo - Criar um objeto da classeDAO  e chamar o metodo cadastrarCliente

            ClienteDAO dao = new ClienteDAO();
            dao.cadastrarCliente(obj);
        }
    }
}