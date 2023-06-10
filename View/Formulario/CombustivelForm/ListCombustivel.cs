/* Módulo View ListCombustivel
 * Descrição: listar combustivel
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


namespace View.Formulario.CombustivelForm
{
    public partial class ListCombustivelForm : Form
    {
        private Button novoButton;
        private Button alterarButton;
        private Button excluirButton;
        private Button cancelarButton;
        private Button sairButton;
        private DataGridView combustivelDataGridView;

        public ListCombustivelForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Configurações da janela do formulário
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Text = "Listar Combustiveis";
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

            //Configurações do grid de combustivels
            combustivelDataGridView = new DataGridView();
            combustivelDataGridView.Location = new Point(20, 40);
            combustivelDataGridView.Size = new Size(440, 280);
            combustivelDataGridView.AllowUserToAddRows = false;
            combustivelDataGridView.AllowUserToDeleteRows = false;
            combustivelDataGridView.ReadOnly = true;
            combustivelDataGridView.MultiSelect = false;
            combustivelDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            combustivelDataGridView.AutoGenerateColumns = false;

            //Configuração das colunas do grid
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "combustivel";//Lembrar que a exibição é nome + 
            idColumn.HeaderText = "combustivel";
            idColumn.Width = 50;
            idColumn.ReadOnly = true;
            combustivelDataGridView.Columns.Add(idColumn);

            DataGridViewTextBoxColumn nomeColumn = new DataGridViewTextBoxColumn();
            nomeColumn.DataPropertyName = "Nome Combustível"; //JUSSAN - Lembrar de preparar a controller para buscar o nome do combustível no tipo combustível
            nomeColumn.HeaderText = "Nome Combustível";
            nomeColumn.Width = 70;
            nomeColumn.ReadOnly = true;
            combustivelDataGridView.Columns.Add(nomeColumn);

            DataGridViewTextBoxColumn siglaColumn = new DataGridViewTextBoxColumn();
            siglaColumn.DataPropertyName = "Cap_Max";
            siglaColumn.HeaderText = "Capacidade Maxima";
            siglaColumn.Width = 80;
            siglaColumn.ReadOnly = true;
            combustivelDataGridView.Columns.Add(siglaColumn);

            DataGridViewTextBoxColumn descricaoColumn = new DataGridViewTextBoxColumn();
            descricaoColumn.DataPropertyName = "Cap_Min";
            descricaoColumn.HeaderText = "Capacidade Minima";
            descricaoColumn.Width = 90;
            descricaoColumn.ReadOnly = true;
            combustivelDataGridView.Columns.Add(descricaoColumn);

            DataGridViewTextBoxColumn precoCompraColumn = new DataGridViewTextBoxColumn();
            precoCompraColumn.DataPropertyName = "Preco_Compra";
            precoCompraColumn.HeaderText = "Preço de Compra";
            precoCompraColumn.Width = 90;
            precoCompraColumn.ReadOnly = true;
            combustivelDataGridView.Columns.Add(precoCompraColumn);

            DataGridViewTextBoxColumn precoVendaColumn = new DataGridViewTextBoxColumn();
            precoVendaColumn.DataPropertyName = "Preco_Venda";
            precoVendaColumn.HeaderText = "Preço de Venda";
            precoVendaColumn.Width = 90;
            precoVendaColumn.ReadOnly = true;
            combustivelDataGridView.Columns.Add(precoVendaColumn);

            this.Controls.Add(combustivelDataGridView);
        }

        private void NovoButton_Click(object sender, EventArgs e)
        {
            AbrirForm(new CadCombustivel());
            this.ListaCombustivel();
            //throw new NotImplementedException();
        }

        private void AlterarButton_Click(object sender, EventArgs e)
        {
            //Adicionar Ação/código para alterar uma combustivel selecionada
        }

        private void ExcluirButton_Click(object sender, EventArgs e)
        {
            //Adicionar Ação/código para excluir uma combustivel selecionada
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

        public void AbrirForm(Form form)
        {
            form.ShowDialog();
        }

        private void ListaCombustivel()
        {
            combustivelDataGridView.Rows.Clear();
            foreach (var combustivel in Controller.Combustivel.ListaCombustivel())
            {
                combustivelDataGridView.Rows.Add(combustivel.combustivelId, combustivel.nome, combustivel.sigla, combustivel.descricao, combustivel.precoCompra, combustivel.precoVenda);
            }
        }            
    }
}