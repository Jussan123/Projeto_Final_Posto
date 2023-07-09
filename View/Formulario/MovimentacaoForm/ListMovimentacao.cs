/* Módulo View ListMovimentacao
 * Descrição: listar movimentacao
 * Autor: Erich Wanderley 
 * Data: 22/05/2023
 * Versão: 1.0
 */

namespace View.Formulario.MovimentacaoForm
{
    public class ListMovimentacao : Form
    {
        private Button novoButton;
        private Button alterarButton;
        private Button excluirButton;
        private Button refreshButton;
        private Button sairButton;
        private DataGridView movimentacaoDataGridView;

        public ListMovimentacao()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Configurações da janela do formulário
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Text = "Listar movimentacoes";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Configurações do botão de novo
            novoButton = new Button();
            novoButton.Text = "Novo";
            novoButton.Location = new Point(20, 640);
            novoButton.Size = new Size(80, 30);
            novoButton.Click += new EventHandler(NovoButton_Click);
            this.Controls.Add(novoButton);

            // Configurações do botão de alterar
            alterarButton = new Button();
            alterarButton.Text = "Alterar";
            alterarButton.Location = new Point(110, 640);
            alterarButton.Size = new Size(80, 30);
            alterarButton.Click += new EventHandler(AlterarButton_Click);
            this.Controls.Add(alterarButton);

            // Configurações do botão de excluir
            excluirButton = new Button();
            excluirButton.Text = "Excluir";
            excluirButton.Location = new Point(200, 640);
            excluirButton.Size = new Size(80, 30);
            excluirButton.Click += new EventHandler(excluirButton_Click);
            this.Controls.Add(excluirButton);

            // Configurações do botão de refresh
            refreshButton = new Button();
            refreshButton.Text = "Refresh";
            refreshButton.Location = new Point(290, 640);
            refreshButton.Size = new Size(80, 30);
            refreshButton.Click += new EventHandler(RefreshButton_Click);
            this.Controls.Add(refreshButton);

            // Configurações do botão de sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(380, 640);
            sairButton.Size = new Size(80, 30);
            sairButton.Click += new EventHandler(SairButton_Click);
            this.Controls.Add(sairButton);

            // Configurações do DataGridView
            movimentacaoDataGridView = new DataGridView();
            movimentacaoDataGridView.Location = new Point(20, 40);
            movimentacaoDataGridView.Size = new Size(760, 600);
            // Configura as colunas do DataGridView
            movimentacaoDataGridView.Columns.Add("movimentacaoId", "ID");
            movimentacaoDataGridView.Columns.Add("combustivelId", "Combustivel");
            movimentacaoDataGridView.Columns.Add("quantidade", "Quantidade");
            movimentacaoDataGridView.Columns.Add("tipoOperacao", "Tipo de operação");
            movimentacaoDataGridView.Columns.Add("dataHora", "Data e hora");
            movimentacaoDataGridView.Columns.Add("valor", "Valor");
            movimentacaoDataGridView.Columns.Add("lojaId", "Loja");
            movimentacaoDataGridView.Columns.Add("funcionarioId", "Funcionario");
            movimentacaoDataGridView.Columns.Add("bombaId", "Bomba");
            movimentacaoDataGridView.Columns.Add("fornecedorId", "Fornecedor");
            foreach (var movimentacao in Controller.Movimentacao.ListaMovimentacoes())
            {
                movimentacaoDataGridView.Rows.Add(movimentacao.movimentacaoId, 
                                                    movimentacao.combustivelId, 
                                                    movimentacao.quantidade, 
                                                    movimentacao.tipoOperacao, 
                                                    movimentacao.dataHora, 
                                                    movimentacao.valor,
                                                    movimentacao.lojaId, 
                                                    movimentacao.funcionarioId, 
                                                    movimentacao.bombaId,
                                                    movimentacao.fornecedorId);
            }
            movimentacaoDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            movimentacaoDataGridView.RowsDefaultCellStyle.BackColor = Color.White;
            movimentacaoDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Aquamarine;
            movimentacaoDataGridView.DefaultCellStyle.Font = new Font("TrebuchetMS", 10, FontStyle.Regular);
            movimentacaoDataGridView.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            movimentacaoDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.Controls.Add(movimentacaoDataGridView);        
        }

        private void NovoButton_Click(object sender, EventArgs e)
        {
            AbrirForm(new CadMovimentacao());
            this.ListaMovimentacao();
        }

        private void AlterarButton_Click(object sender, EventArgs e)
        {
            AbrirForm(new FormEditaMovimentacao());
            this.ListaMovimentacao();
        }
        private void excluirButton_Click(object sender, EventArgs e)
        {
            AbrirForm(new FormExcluiMovimentacao());
            this.ListaMovimentacao();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.ListaMovimentacao();
        }

        private void SairButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void AbrirForm(Form form)
        {
            form.ShowDialog();
        }

        public void ListaMovimentacao()
        {
            movimentacaoDataGridView.Rows.Clear();
            foreach (var movimentacao in Controller.Movimentacao.ListaMovimentacoes())
            {
                movimentacaoDataGridView.Rows.Add(movimentacao.movimentacaoId, 
                                                    movimentacao.combustivelId, 
                                                    movimentacao.quantidade, 
                                                    movimentacao.tipoOperacao, 
                                                    movimentacao.dataHora, 
                                                    movimentacao.valor,
                                                    movimentacao.lojaId, 
                                                    movimentacao.funcionarioId, 
                                                    movimentacao.bombaId,
                                                    movimentacao.fornecedorId);
            }
        }

    }
}