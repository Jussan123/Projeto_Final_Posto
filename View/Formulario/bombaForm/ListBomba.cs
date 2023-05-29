/* Módulo View ListBomba
 * Descrição: Listar bomba de combustivel
 * Autor: Erich Wanderley 
 * Data: 22/05/2023
 * Versão: 1.0
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ViewListBomba
{
    public partial class ListBombaForm : Form
    {
        private Button novoButton;
        private Button alterarButton;
        private Button excluirButton;
        private Button cancelarButton;
        private Button sairButton;
        private DataGridView produtosDataGridView;

        public ListBombaForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Configurações da janela do formulário
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Text = "Listar Bombas";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Configurações do botão de novo 
            novoButton = new Button();
            novoButton.Text = "Novo";
            novoButton.Location = new Point(20, 340);
            novoButton.Size = new Size(80, 30);
            novoButton.Click += new EventHandler(NovoButton_Click);
            this.Controls.Add(novoButton);

            // Configurações do botão de alterar 
            alterarButton = new Button();
            alterarButton.Text = "Alterar";
            alterarButton.Location = new Point(110, 340);
            alterarButton.Size = new Size(80, 30);
            alterarButton.Click += new EventHandler(AlterarButton_Click);
            this.Controls.Add(alterarButton);

            //Configurações do botão de excluir
            excluirButton = new Button();
            excluirButton.Text = "Excluir";
            excluirButton.Location = new Point(200, 340);
            excluirButton.Size = new Size(80, 30);
            excluirButton.Click += new EventHandler(ExcluirButton_Click);
            this.Controls.Add(excluirButton);

            //Configurações do botão de cancelar
            cancelarButton = new Button();
            cancelarButton.Text = "Cancelar";
            cancelarButton.Location = new Point(290, 340);
            cancelarButton.Size = new Size(80, 30);
            cancelarButton.Click += new EventHandler(CancelarButton_Click);
            this.Controls.Add(cancelarButton);

            //Configurações do botão de sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(380, 340);
            sairButton.Size = new Size(80, 30);
            sairButton.Click += new EventHandler(SairButton_Click);
            this.Controls.Add(sairButton);

            //Configurações do grid de Bombas
            produtosDataGridView = new DataGridView();
            produtosDataGridView.Location = new Point(20, 40);
            produtosDataGridView.Size = new Size(440, 280);
            produtosDataGridView.AllowUserToAddRows = false;
            produtosDataGridView.AllowUserToDeleteRows = false;
            produtosDataGridView.ReadOnly = true;
            produtosDataGridView.MultiSelect = false;
            produtosDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            produtosDataGridView.AutoGenerateColumns = false;

            //Configuração das colunas do grid
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "Bomba";//Lembrar que a exibição é nome + 
            idColumn.HeaderText = "Bomba";
            idColumn.Width = 50;
            idColumn.ReadOnly = true;
            produtosDataGridView.Columns.Add(idColumn);


            DataGridViewTextBoxColumn precoColumn = new DataGridViewTextBoxColumn();
            precoColumn.DataPropertyName = "Nome Combustível"; //JUSSAN - Lembrar de preparar a controller para buscar o nome do combustível no tipo combustível
            precoColumn.HeaderText = "Nome Combustível";
            precoColumn.Width = 70;
            precoColumn.ReadOnly = true;
            produtosDataGridView.Columns.Add(precoColumn);

            DataGridViewTextBoxColumn quantidadeColumn = new DataGridViewTextBoxColumn();
            quantidadeColumn.DataPropertyName = "Quantidade";
            quantidadeColumn.HeaderText = "Quantidade";
            quantidadeColumn.Width = 80;
            quantidadeColumn.ReadOnly = true;
            produtosDataGridView.Columns.Add(quantidadeColumn);

            DataGridViewTextBoxColumn nomeColumn = new DataGridViewTextBoxColumn();
            nomeColumn.DataPropertyName = "Nome";
            nomeColumn.HeaderText = "Nome";
            nomeColumn.Width = 150;
            nomeColumn.ReadOnly = true;
            produtosDataGridView.Columns.Add(nomeColumn);
/*
         BOMBA ID
         TIPO_COMBUS_ID 
         TIPO_COMBUS_NOME 
         CAPACIDADE MAX 
         CAPACIDADE MIN
         MOV. ID
         Movimentacao Movimentacao 
*/



            this.Controls.Add(produtosDataGridView);
        }

        private void NovoButton_Click(object sender, EventArgs e)
        {
            FrmNovoAlx alx = new FrmNovoAlx();
            alx.Show();
            //throw new NotImplementedException();
        }

        private void AlterarButton_Click(object sender, EventArgs e)
        {
            //Adicionar Ação/código para alterar uma bomba selecionada
        }

        private void ExcluirButton_Click(object sender, EventArgs e)
        {
            //Adicionar Ação/código para excluir uma bomba selecionada
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            //Adicionar Ação/código para cancelar a operação atual
        }

        private void SairButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você realmente deseja sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                //Application.Exit();
            }
        }
    }
}