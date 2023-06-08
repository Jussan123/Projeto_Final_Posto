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
using View.Fomulario.FornecedorForm;
//using CadFornecedorForm;


namespace View.Formulario.List.ForneceedorForm
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
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Text = "Listar fornecedors";
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

            //Configurações do grid de fornecedors
            //Data Grid View Jussan
            DataGridView fornecedorDataGridView = new DataGridView();
            fornecedorDataGridView.Location = new Point(20, 40);
            fornecedorDataGridView.Size = new Size(440, 280);
            //Configura as colunas do grid
            fornecedorDataGridView.Columns.Add("fornecedorId", "fornecedor");
            fornecedorDataGridView.Columns.Add("nomeCombustivel", "Nome Combustível");
            fornecedorDataGridView.Columns.Add("limiteMaximo", "Capacidade Máxima");
            fornecedorDataGridView.Columns.Add("limiteMinimo", "Capacidade Mínima");
            foreach (var fornecedor in Controller.Fornecedor.ListarFornecedors())
            {
                fornecedorDataGridView.Rows.Add(fornecedor.fornecedorId, fornecedor.nomeCombustivel, fornecedor.limiteMaximo, fornecedor.limiteMinimo);
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


/* DataGridView montado pelo Erich
            //Configurações do grid de fornecedors
            fornecedorDataGridView = new DataGridView();
            fornecedorDataGridView.Location = new Point(20, 40);
            fornecedorDataGridView.Size = new Size(440, 280);
            fornecedorDataGridView.AllowUserToAddRows = false;
            fornecedorDataGridView.AllowUserToDeleteRows = false;
            fornecedorDataGridView.ReadOnly = true;
            fornecedorDataGridView.MultiSelect = false;
            fornecedorDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            fornecedorDataGridView.AutoGenerateColumns = false;

            //Configuração das colunas do grid
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "fornecedor";//Lembrar que a exibição é o ID 
            idColumn.HeaderText = "fornecedor";
            idColumn.Width = 50;
            idColumn.ReadOnly = true;
            fornecedorDataGridView.Columns.Add(idColumn);

            DataGridViewTextBoxColumn nomeColumn = new DataGridViewTextBoxColumn();
            nomeColumn.DataPropertyName = "Nome Combustível"; //JUSSAN - Lembrar de preparar a controller para buscar o nome do combustível no tipo combustível
            nomeColumn.HeaderText = "Nome Combustível";
            nomeColumn.Width = 70;
            nomeColumn.ReadOnly = true;
            fornecedorDataGridView.Columns.Add(nomeColumn);

            DataGridViewTextBoxColumn capmaxColumn = new DataGridViewTextBoxColumn();
            capmaxColumn.DataPropertyName = "Cap_Max";
            capmaxColumn.HeaderText = "Capacidade Maxima";
            capmaxColumn.Width = 80;
            capmaxColumn.ReadOnly = true;
            fornecedorDataGridView.Columns.Add(capmaxColumn);

            DataGridViewTextBoxColumn capminColumn = new DataGridViewTextBoxColumn();
            capminColumn.DataPropertyName = "Cap_Min";
            capminColumn.HeaderText = "Capacidade Minima";
            capminColumn.Width = 90;
            capminColumn.ReadOnly = true;
            fornecedorDataGridView.Columns.Add(capminColumn);
            this.Controls.Add(fornecedorDataGridView);
*/

        }

        private void NovoButton_Click(object sender, EventArgs e)
        {
            AbrirForm(new CadFornecedor());
            this.ListaFornecedor();
            //throw new NotImplementedException();
        }

        private void AlterarButton_Click(object sender, EventArgs e)
        {
            AbrirForm(new FormEditaFornecedor());
            this.ListaFornecedor();
            //Adicionar Ação/código para alterar uma fornecedor selecionada
        }

        private void ExcluirButton_Click(object sender, EventArgs e)
        {
            AbrirForm(new FormExcluiFornecedor());
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
            dataGridView.Rows.Clear();
            foreach (var fornecedor in Controller.Fornecedor.ListarFornecedors())
            {
                dataGridView.Rows.Add(fornecedor.fornecedorId, fornecedor.nomeCombustivel, fornecedor.limiteMaximo, fornecedor.limiteMinimo);
            }
        }
    }
}