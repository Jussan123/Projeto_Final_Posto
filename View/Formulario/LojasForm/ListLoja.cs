/* Módulo View ListLoja
 * Descrição: listar Loja
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
//using CadLojaForm;


namespace View.Formulario.LojasForm
{
    public partial class ListLojaForm : Form
    {
        private Button novoButton;
        private Button alterarButton;
        private Button excluirButton;
        private Button refreshButton;
        private Button sairButton;
        private DataGridView lojaDataGridView;

        public ListLojaForm()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            // Configurações da janela do formulário
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Text = "Listar lojas";
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
            refreshButton = new Button();
            refreshButton.Text = "Cancelar";
            refreshButton.Location = new Point(290, 340);
            refreshButton.Size = new Size(80, 30);
            refreshButton.Click += new EventHandler(RefreshButton_Click);
            this.Controls.Add(refreshButton);

            //Configurações do botão de sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(380, 340);
            sairButton.Size = new Size(80, 30);
            sairButton.Click += new EventHandler(SairButton_Click);
            this.Controls.Add(sairButton);

            //Configurações do grid de lojas
            //Data Grid View Jussan
            lojaDataGridView = new DataGridView();
            lojaDataGridView.Location = new Point(20, 40);
            lojaDataGridView.Size = new Size(440, 280);
            //Configura as colunas do grid
            lojaDataGridView.Columns.Add("lojaId", "loja");
            lojaDataGridView.Columns.Add("nome", "Nome Loja");
            lojaDataGridView.Columns.Add("endereco", "Endereço");
            lojaDataGridView.Columns.Add("telefone", "Telefone");
            lojaDataGridView.Columns.Add("email", "Email");
            foreach (var loja in Controller.Loja.ListaLojas())
            {
                lojaDataGridView.Rows.Add(loja.lojaId, loja.nome, loja.endereco, loja.telefone, loja.email);
            }
            //configura o modo de redimensionamento das linhas e colunas
            lojaDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //configura a cor das linhas alternadas
            lojaDataGridView.RowsDefaultCellStyle.BackColor = Color.White;
            lojaDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Aquamarine;
            //configura a fonte e o tamanho do texto
            lojaDataGridView.DefaultCellStyle.Font = new Font("TrebuchetMS", 10, FontStyle.Regular);
            lojaDataGridView.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            //configura a altura das linhas do grid
            lojaDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.Controls.Add(lojaDataGridView);
        }

        private void NovoButton_Click(object sender, EventArgs e)
        {
            AbrirForm(new View.Formulario.LojasForm.CadLoja());
            //throw new NotImplementedException();
        }

        private void AlterarButton_Click(object sender, EventArgs e)
        {
            AbrirForm(new View.Formulario.LojasForm.FormEditaLoja());
            //Adicionar Ação/código para alterar uma loja selecionada
        }

        private void ExcluirButton_Click(object sender, EventArgs e)
        {
            AbrirForm(new View.Formulario.LojasForm.FormExcluiLoja());
            //Adicionar Ação/código para excluir uma loja selecionada
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.ListaLoja();
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

        public void ListaLoja()
        {
            lojaDataGridView.Rows.Clear();
            foreach (var loja in Controller.Loja.ListaLojas())
            {
                lojaDataGridView.Rows.Add(loja.lojaId, loja.nome, loja.endereco, loja.telefone, loja.email);
            }
        }
    }
}