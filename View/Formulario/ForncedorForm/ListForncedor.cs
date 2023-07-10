/* Módulo View ListFornecedor
 * Descrição: listar fornecedor
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
using View.Formulario.FornecedorForm;
//using CadFornecedorForm;


namespace View.Formulario.FornecedorForm
{
    public partial class ListFornecedorForm : Form
    {
        private Button novoButton;
        private Button alterarButton;
        private Button excluirButton;
        private Button refreshButton;
        private Button sairButton;
        private DataGridView fornecedorDataGridView;

        public ListFornecedorForm()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            // Configurações da janela do formulário
            this.ClientSize = new System.Drawing.Size(480, 400);
            this.Text = "Listar fornecedors";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = ColorTranslator.FromHtml("#CFCFCF");

            // Configurações do botão de novo 
            novoButton = new Button();
            novoButton.Text = "Novo";
            novoButton.Location = new Point(20, 360);
            novoButton.Size = new Size(80, 30);
            novoButton.Click += new EventHandler(NovoButton_Click);
            novoButton.BackColor = ColorTranslator.FromHtml("#FFFDE8");
            this.Controls.Add(novoButton);

            // Configurações do botão de alterar 
            alterarButton = new Button();
            alterarButton.Text = "Alterar";
            alterarButton.Location = new Point(110, 360);
            alterarButton.Size = new Size(80, 30);
            alterarButton.Click += new EventHandler(AlterarButton_Click);
            alterarButton.BackColor = ColorTranslator.FromHtml("#FFFDE8");
            this.Controls.Add(alterarButton);

            //Configurações do botão de excluir
            excluirButton = new Button();
            excluirButton.Text = "Excluir";
            excluirButton.Location = new Point(200, 360);
            excluirButton.Size = new Size(80, 30);
            excluirButton.Click += new EventHandler(ExcluirButton_Click);
            excluirButton.BackColor = ColorTranslator.FromHtml("#FFFDE8");
            this.Controls.Add(excluirButton);

            //Configurações do botão de cancelar
            refreshButton = new Button();
            refreshButton.Text = "Refresh";
            refreshButton.Location = new Point(290, 360);
            refreshButton.Size = new Size(80, 30);
            refreshButton.Click += new EventHandler(RefreshButton_Click);
            refreshButton.BackColor = ColorTranslator.FromHtml("#FFFDE8");
            this.Controls.Add(refreshButton);

            //Configurações do botão de sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(380, 360);
            sairButton.Size = new Size(80, 30);
            sairButton.Click += new EventHandler(SairButton_Click);
            sairButton.BackColor = ColorTranslator.FromHtml("#FFFDE8");
            this.Controls.Add(sairButton);

            //Painel para os botões
            Panel panel = new Panel();
            panel.Size = new Size(100, 50);
            panel.BackColor = ColorTranslator.FromHtml("#4056A1");
            panel.Dock = DockStyle.Bottom;
            this.Controls.Add(panel);
            
            //Configurações do grid de fornecedors
            //Data Grid View Jussan
            fornecedorDataGridView = new DataGridView();
            fornecedorDataGridView.Location = new Point(20, 40);
            fornecedorDataGridView.Size = new Size(440, 280);
            //Configura as colunas do grid
            fornecedorDataGridView.Columns.Add("fornecedorId", "fornecedor");
            fornecedorDataGridView.Columns.Add("nome", "Nome Fornecedor");
            fornecedorDataGridView.Columns.Add("contato", "Contato");
            fornecedorDataGridView.Columns.Add("endereco", "Endereço");
            foreach (var fornecedor in Controller.Fornecedor.BuscaFornecedores())
            {
                fornecedorDataGridView.Rows.Add(fornecedor.fornecedorId, fornecedor.nome, fornecedor.contato, fornecedor.endereco);
            }
            //configura o modo de redimensionamento das linhas e colunas
            fornecedorDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //configura a cor das linhas alternadas
            fornecedorDataGridView.RowsDefaultCellStyle.BackColor = Color.White;
            fornecedorDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Aquamarine;
            //configura a fonte e o tamanho do texto
            fornecedorDataGridView.DefaultCellStyle.Font = new Font("TrebuchetMS", 10, FontStyle.Regular);
            fornecedorDataGridView.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            //configura a altura das linhas do grid
            fornecedorDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.Controls.Add(fornecedorDataGridView);
        }

        private void NovoButton_Click(object sender, EventArgs e)
        {
            AbrirForm(new View.Formulario.FornecedorForm.CadFornecedor());
            this.ListaFornecedor();
            //throw new NotImplementedException();
        }

        private void AlterarButton_Click(object sender, EventArgs e)
        {
            AbrirForm(new View.Formulario.FornecedorForm.FormEditaFornecedor());
            this.ListaFornecedor();
            //Adicionar Ação/código para alterar uma fornecedor selecionada
        }

        private void ExcluirButton_Click(object sender, EventArgs e)
        {
            AbrirForm(new View.Formulario.FornecedorForm.FormExcluiFornecedor());
            this.ListaFornecedor();
            //Adicionar Ação/código para excluir uma fornecedor selecionada
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.ListaFornecedor();
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

        public void AbrirForm(Form form){
            form.ShowDialog();
        }

        public void ListaFornecedor()
        {
            fornecedorDataGridView.Rows.Clear();
            foreach (var fornecedor in Controller.Fornecedor.BuscaFornecedores())
            {
                fornecedorDataGridView.Rows.Add(fornecedor.fornecedorId, fornecedor.nome, fornecedor.contato, fornecedor.endereco);
            }
        }
    }
}