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
        private Button refreshButton;
        private Button sairButton;
        private DataGridView combustivelDataGridView;

        public ListCombustivelForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {


            //Configurações da janela do formulário
            this.ClientSize = new System.Drawing.Size(480, 400);
            this.Text = "Listar Combustiveis";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = ColorTranslator.FromHtml("#FFFDE8");

            //Configurações do botão de novo 
            novoButton = new Button();
            novoButton.Text = "Novo";
            novoButton.Location = new Point(20, 360);
            novoButton.Size = new Size(80, 30);
            novoButton.Click += new EventHandler(NovoButton_Click);
            novoButton.BackColor = ColorTranslator.FromHtml("#FFFDE8");
            this.Controls.Add(novoButton);
           
            //Configurações do botão de alterar 
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

            //Configurações do botão de refresh
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
            panel.BackColor = ColorTranslator.FromHtml("#F7E0A3");
            panel.Dock = DockStyle.Bottom;
            this.Controls.Add(panel);

            //Configurações do grid de combustivelss
            combustivelDataGridView = new DataGridView();
            combustivelDataGridView.Location = new Point(20, 40);
            combustivelDataGridView.Size = new Size(440, 280);
            combustivelDataGridView.Columns.Add("combustivelId", "Id");
            combustivelDataGridView.Columns.Add("Nome", "Nome");
            combustivelDataGridView.Columns.Add("Sigla", "Sigla");
            combustivelDataGridView.Columns.Add("Descricao", "Descrição");
            combustivelDataGridView.Columns.Add("PrecoCompra", "Val. de Compra");
            combustivelDataGridView.Columns.Add("PrecoVenda", "Val. de Venda");
            foreach (var combustivel in Controller.Combustivel.ListaCombustivel())
            {
                combustivelDataGridView.Rows.Add(combustivel.combustivelId, combustivel.nome, combustivel.sigla, combustivel.descricao, combustivel.precoCompra, combustivel.precoVenda);
            }
            combustivelDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            combustivelDataGridView.RowsDefaultCellStyle.BackColor = Color.White;
            combustivelDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Aquamarine;
            combustivelDataGridView.DefaultCellStyle.Font = new Font("TrebuchetMS", 10, FontStyle.Regular);
            combustivelDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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
            AbrirForm(new View.Formulario.CombustivelForm.FormEditaCombustivel());
            this.ListaCombustivel();
            //Adicionar Ação/código para alterar uma combustivel selecionada
        }

        private void ExcluirButton_Click(object sender, EventArgs e)
        {
            AbrirForm(new View.Formulario.CombustivelForm.FormExcluiCombustivel());
            this.ListaCombustivel();
            //Adicionar Ação/código para excluir uma combustivel selecionada
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.ListaCombustivel();
            //Adicionar Ação/código para refresh a operação atual
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