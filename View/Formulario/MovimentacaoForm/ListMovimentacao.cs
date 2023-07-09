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
            this.ClientSize = new System.Drawing.Size(480, 400);
            this.Text = "Listar movimentacoes";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = ColorTranslator.FromHtml("#FFFDE8");

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

            // Configurações do botão de excluir
            excluirButton = new Button();
            excluirButton.Text = "Excluir";
            excluirButton.Location = new Point(200, 360);
            excluirButton.Size = new Size(80, 30);
            excluirButton.Click += new EventHandler(excluirButton_Click);
            excluirButton.BackColor = ColorTranslator.FromHtml("#FFFDE8");
            this.Controls.Add(excluirButton);

            // Configurações do botão de refresh
            refreshButton = new Button();
            refreshButton.Text = "Refresh";
            refreshButton.Location = new Point(290, 360);
            refreshButton.Size = new Size(80, 30);
            refreshButton.Click += new EventHandler(RefreshButton_Click);
            refreshButton.BackColor = ColorTranslator.FromHtml("#FFFDE8");
            this.Controls.Add(refreshButton);

            // Configurações do botão de sair
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

            // Configurações do DataGridView
            movimentacaoDataGridView = new DataGridView();
            movimentacaoDataGridView.Location = new Point(20, 20);
            movimentacaoDataGridView.Size = new Size(760, 600);
            // Configura as colunas do DataGridView
            movimentacaoDataGridView.ColumnCount = 9;
            movimentacaoDataGridView.ColumnHeadersVisible = true;
            movimentacaoDataGridView.Columns[0].Name = "Movimentacao";
            movimentacaoDataGridView.Columns[1].Name = "CombustivelId";
            movimentacaoDataGridView.Columns[2].Name = "Quantidade";
            movimentacaoDataGridView.Columns[3].Name = "TipoOperacao";
            movimentacaoDataGridView.Columns[4].Name = "DataHora";
            movimentacaoDataGridView.Columns[5].Name = "Valor";
            movimentacaoDataGridView.Columns[6].Name = "LojaId";
            movimentacaoDataGridView.Columns[7].Name = "FuncionarioId";
            movimentacaoDataGridView.Columns[8].Name = "BombaId";
            movimentacaoDataGridView.Columns[9].Name = "FornecedorId";
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
            //configura o modo de redimensionamento das linhas e colunas
            movimentacaoDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //configura a cor das linhas alternadas
            movimentacaoDataGridView.RowsDefaultCellStyle.BackColor = Color.White;
            movimentacaoDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Aquamarine;
            //configura a fonte e o tamanho do texto
            movimentacaoDataGridView.DefaultCellStyle.Font = new Font("TrebuchetMS", 10, FontStyle.Regular);
            movimentacaoDataGridView.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            //configura a altura das linhas do grid
            movimentacaoDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.Controls.Add(movimentacaoDataGridView);
        }

        private void NovoButton_Click(object sender, EventArgs e)
        {
            AbrirForm(new CadMovimentacao());
        }

        private void AlterarButton_Click(object sender, EventArgs e)
        {
            AbrirForm(new FormEditaMovimentacao());
        }
        private void excluirButton_Click(object sender, EventArgs e)
        {
            AbrirForm(new FormExcluiMovimentacao());
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            ListaMovimentacao();
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