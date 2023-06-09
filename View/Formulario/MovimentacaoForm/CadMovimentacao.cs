/* Módulo View CadMovimentacao
 * Descrição: cadastro de movimentacao
 * Autor: Erich Wanderley
 * Data: 20/04/2023
 * Versão: 1.0
 */

 namespace View.Formulario.MovimentacaoForm
 {
    public partial class CadMovimentacao : Form
    {
        private Label quantidadeLabel;
        private Label tipoOperacaoLabel;
        private Label lojaIdLabel;
        private Label funcionarioIdLabel;
        private Label bombaIdLabel;
        private Label combustivelIdLabel;
        private Label fornecedorIdLabel;
        private TextBox quantidadeTextBox;
        private ComboBox tipoOperacaoComboBox;
        private ComboBox lojaIdComboBox;
        private ComboBox funcionarioIdComboBox;
        private ComboBox bombaIdComboBox;
        private ComboBox combustivelIdComboBox;
        private ComboBox fornecedorIdComboBox;
        private Button gravarButton;
        private Button sairButton;

        public CadMovimentacao()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Configurações da janela do formulário
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Text = "Cadastro de Movimentação";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Configurações do label de quantidade
            quantidadeLabel = new Label();
            quantidadeLabel.Text = "Quantidade";
            quantidadeLabel.Location = new Point(20, 60);
            quantidadeLabel.Size = new Size(80, 20);
            this.Controls.Add(quantidadeLabel);

            // Configurações do textbox de quantidade
            quantidadeTextBox = new TextBox();
            quantidadeTextBox.Location = new Point(100, 60);
            quantidadeTextBox.Size = new Size(150, 20);
            this.Controls.Add(quantidadeTextBox);

            // Configurações do label de tipoOperacao
            tipoOperacaoLabel = new Label();
            tipoOperacaoLabel.Text = "Tipo de Operação";
            tipoOperacaoLabel.Location = new Point(20, 90);
            tipoOperacaoLabel.Size = new Size(80, 20);
            this.Controls.Add(tipoOperacaoLabel);

            // Configurações do combobox de tipoOperacao
            tipoOperacaoComboBox = new ComboBox();
            tipoOperacaoComboBox.Location = new Point(100, 90);
            tipoOperacaoComboBox.Size = new Size(150, 20);
            string [] tipoOperacao = {"Entrada", "Saida"};
            tipoOperacaoComboBox.Items.AddRange(tipoOperacao);
            tipoOperacaoComboBox.TextChanged += new EventHandler(TipoOperacaoComboBox_TextChanged);
            this.Controls.Add(tipoOperacaoComboBox);

            // Configurações do label de lojaId
            lojaIdLabel = new Label();
            lojaIdLabel.Text = "Loja";
            lojaIdLabel.Location = new Point(20, 120);
            lojaIdLabel.Size = new Size(80, 20);
            this.Controls.Add(lojaIdLabel);

            // Configurações do combobox de lojaId
            lojaIdComboBox = new ComboBox();
            lojaIdComboBox.Location = new Point(100, 120);
            lojaIdComboBox.Size = new Size(150, 20);
            List<Model.Loja> lojas = new List<Model.Loja>();
            foreach (Model.Loja loja in Model.Loja.BuscaLoja())
            {
                lojas.Add(loja);
            }
            lojaIdComboBox.ValueMember = "lojaId";
            lojaIdComboBox.DisplayMember = "nome";
//            lojaIdComboBox.DataSource = lojas;
            lojaIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(lojaIdComboBox);

            // Configurações do label de funcionarioId
            funcionarioIdLabel = new Label();
            funcionarioIdLabel.Text = "Funcionário";
            funcionarioIdLabel.Location = new Point(20, 150);
            funcionarioIdLabel.Size = new Size(80, 20);
            this.Controls.Add(funcionarioIdLabel);

            // Configurações do combobox de funcionarioId
            funcionarioIdComboBox = new ComboBox();
            funcionarioIdComboBox.Location = new Point(100, 150);
            funcionarioIdComboBox.Size = new Size(150, 20);
            List<Model.Funcionario> funcionarios = new List<Model.Funcionario>();
            foreach (Model.Funcionario funcionario in Model.Funcionario.BuscaFuncionario())
            {
                funcionarios.Add(funcionario);
            }
            funcionarioIdComboBox.ValueMember = "funcionarioId";
            funcionarioIdComboBox.DisplayMember = "nome";
//            funcionarioIdComboBox.DataSource = funcionarios;
            funcionarioIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(funcionarioIdComboBox);

            // Configurações do label de bombaId
            bombaIdLabel = new Label();
            bombaIdLabel.Text = "Bomba";
            bombaIdLabel.Location = new Point(20, 180);
            bombaIdLabel.Size = new Size(80, 20);
            this.Controls.Add(bombaIdLabel);

            // Configurações do combobox de bombaId
            bombaIdComboBox = new ComboBox();
            bombaIdComboBox.Location = new Point(100, 180);
            bombaIdComboBox.Size = new Size(150, 20);
            List<Model.Bomba> bombas = new List<Model.Bomba>();
            foreach (Model.Bomba bomba in Model.Bomba.BuscaBomba())
            {
                bombas.Add(bomba);
            }
            bombaIdComboBox.ValueMember = "bombaId";
            bombaIdComboBox.DisplayMember = "nome";
//            bombaIdComboBox.DataSource = bombas;
            bombaIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(bombaIdComboBox);

            // Configurações do label de combustivelId
            combustivelIdLabel = new Label();
            combustivelIdLabel.Text = "Combustível";
            combustivelIdLabel.Location = new Point(20, 210);
            combustivelIdLabel.Size = new Size(80, 20);
            this.Controls.Add(combustivelIdLabel);

            // Configurações do combobox de combustivelId
            combustivelIdComboBox = new ComboBox();
            combustivelIdComboBox.Location = new Point(100, 210);
            combustivelIdComboBox.Size = new Size(150, 20);
            List<Model.Combustivel> combustiveis = new List<Model.Combustivel>();
            foreach (Model.Combustivel combustivel in Model.Combustivel.BuscaCombustivel())
            {
                combustiveis.Add(combustivel);
            }
            combustivelIdComboBox.ValueMember = "combustivelId";
            combustivelIdComboBox.DisplayMember = "nome";
            combustivelIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(combustivelIdComboBox);

            // Configurações do Label Fornecedor
            fornecedorIdLabel = new Label();
            fornecedorIdLabel.Text = "Fornecedor";
            fornecedorIdLabel.Location = new Point(20, 240);
            fornecedorIdLabel.Size = new Size(80, 20);
            this.Controls.Add(fornecedorIdLabel);

            // Configurações do combobox de fornecedorId
            fornecedorIdComboBox = new ComboBox();
            fornecedorIdComboBox.Location = new Point(100, 240);
            fornecedorIdComboBox.Size = new Size(150, 20);
            List<Model.Fornecedor> fornecedores = new List<Model.Fornecedor>();
            foreach (Model.Fornecedor fornecedor in Model.Fornecedor.BuscaFornecedor())
            {
                fornecedores.Add(fornecedor);
            }
            fornecedorIdComboBox.ValueMember = "fornecedorId";
            fornecedorIdComboBox.DisplayMember = "nome";
            fornecedorIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(fornecedorIdComboBox);


            // Configurações do botão gravar
            gravarButton = new Button();
            gravarButton.Text = "Gravar";
            gravarButton.Location = new Point(20, 270);
            gravarButton.Size = new Size(80, 20);
            gravarButton.Click += (ScrollBarRenderer, e) =>{
                salvaMovimentacao();
                LimpaTela();
            };
            this.Controls.Add(gravarButton);

            // Configurações do botão sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(100, 270);
            sairButton.Size = new Size(80, 20);
            sairButton.Click += (ScrollBarRenderer, e) => this.Close();
            this.Controls.Add(sairButton);
        }

        private void salvaMovimentacao()
        {
            try
            {
                Model.Movimentacao movimentacao = new Model.Movimentacao();
                var combustivelSelecionado = (Model.Combustivel)combustivelIdComboBox.SelectedItem;
                if (combustivelSelecionado == null)
                {
                    MessageBox.Show("Selecione um combustível");
                    return;  
                }
                var bombaSelecionada = (Model.Bomba)bombaIdComboBox.SelectedItem;
                if (bombaSelecionada == null)
                {
                    MessageBox.Show("Selecione uma bomba");
                    return;
                }
                var funcionarioSelecionado = (Model.Funcionario)funcionarioIdComboBox.SelectedItem;
                if (funcionarioSelecionado == null)
                {
                    MessageBox.Show("Selecione um funcionário");
                    return;
                }
                var lojaSelecionada = (Model.Loja)lojaIdComboBox.SelectedItem;
                if (lojaSelecionada == null)
                {
                    MessageBox.Show("Selecione uma loja");
                    return;
                }
                var fornecedorSelecionado = (Model.Fornecedor)fornecedorIdComboBox.SelectedItem;
                movimentacao.combustivelId = combustivelSelecionado.combustivelId;
                movimentacao.bombaId = bombaSelecionada.bombaId;
                movimentacao.funcionarioId = funcionarioSelecionado.funcionarioId;
                movimentacao.lojaId = lojaSelecionada.lojaId;
                movimentacao.quantidade = Convert.ToDecimal(quantidadeTextBox.Text);
                movimentacao.tipoOperacao = tipoOperacaoComboBox.Text;
                if (movimentacao.tipoOperacao == "Entrada")
                {
                    movimentacao.fornecedorId = fornecedorSelecionado.fornecedorId;
                }
                else
                {
                    movimentacao.fornecedorId = 0;
                }
                Controller.Movimentacao.CadastraMovimentacao(movimentacao.combustivelId, movimentacao.quantidade.ToString(), movimentacao.tipoOperacao, movimentacao.lojaId, movimentacao.funcionarioId, movimentacao.bombaId, movimentacao.fornecedorId);
                MessageBox.Show("Movimentação cadastrada com sucesso!");
            } catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar movimentação: " + ex.Message);
            }


        }

        private void LimpaTela()
        {
            quantidadeTextBox.Text = "";
            tipoOperacaoComboBox.Text = "";
            lojaIdComboBox.Text = "";
            funcionarioIdComboBox.Text = "";
            bombaIdComboBox.Text = "";
            combustivelIdComboBox.Text = "";
            fornecedorIdComboBox.Text = "";
        }

        private void TipoOperacaoComboBox_TextChanged(object sender, EventArgs e)
        {
            if (tipoOperacaoComboBox.Text == "Entrada")
            {
                fornecedorIdComboBox.Enabled = true;
            }
            else
            {
                fornecedorIdComboBox.Enabled = false;
            }
            fornecedorIdComboBox.Refresh();
        }

    }

//------------------ Formulário de edição de movimentação -------------------------------

    public class FormEditaMovimentacao : Form
    {
        private Label movimentacaoIdLabel;
        private Label quantidadeLabel;
        private Label tipoOperacaoLabel;
        private Label lojaIdLabel;
        private Label funcionarioIdLabel;
        private Label bombaIdLabel;
        private Label combustivelIdLabel;
        private Label fornecedorIdLabel;
        private TextBox quantidadeTextBox;
        private ComboBox movimentacaoIdComboBox;
        private ComboBox tipoOperacaoComboBox;
        private ComboBox lojaIdComboBox;
        private ComboBox funcionarioIdComboBox;
        private ComboBox bombaIdComboBox;
        private ComboBox combustivelIdComboBox;
        private ComboBox fornecedorIdComboBox;
        private Button gravarButton;
        private Button sairButton;

        public void InitializeComponent()
        {
            // Configurações da janela do formulário
            this.ClientSize = new Size(300, 400);
            this.Text = "Edição de movimentação";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Configurações do label de movimentacaoId
            movimentacaoIdLabel = new Label();
            movimentacaoIdLabel.Text = "Movimentação";
            movimentacaoIdLabel.Location = new Point(20, 30);
            movimentacaoIdLabel.Size = new Size(80, 20);
            this.Controls.Add(movimentacaoIdLabel);

            // Configurações do combobox de movimentacaoId
            ComboBox movimentacaoIdComboBox = new ComboBox();
            movimentacaoIdComboBox.Location = new Point(100, 30);
            movimentacaoIdComboBox.Size = new Size(150, 20);
            List<Model.Movimentacao> movimentacoes = new List<Model.Movimentacao>();
            foreach (Model.Movimentacao movimentacao in Model.Movimentacao.BuscaMovimentacao())
            {
                movimentacoes.Add(movimentacao);
            }
            movimentacaoIdComboBox.ValueMember = "movimentacaoId";
            movimentacaoIdComboBox.DisplayMember = "movimentacaoId";
            movimentacaoIdComboBox.DataSource = movimentacoes;
            movimentacaoIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(movimentacaoIdComboBox);

            // Configurações do label de quantidade
            quantidadeLabel = new Label();
            quantidadeLabel.Text = "Quantidade";
            quantidadeLabel.Location = new Point(20, 60);
            quantidadeLabel.Size = new Size(80, 20);
            this.Controls.Add(quantidadeLabel);

            // Configurações do textbox de quantidade
            quantidadeTextBox = new TextBox();
            quantidadeTextBox.Location = new Point(100, 60);
            quantidadeTextBox.Size = new Size(150, 20);
            this.Controls.Add(quantidadeTextBox);

            // Configurações do label de tipoOperacao
            tipoOperacaoLabel = new Label();
            tipoOperacaoLabel.Text = "Tipo de operação";
            tipoOperacaoLabel.Location = new Point(20, 90);
            tipoOperacaoLabel.Size = new Size(80, 20);
            this.Controls.Add(tipoOperacaoLabel);

            // Configurações do combobox de tipoOperacao
            tipoOperacaoComboBox = new ComboBox();
            tipoOperacaoComboBox.Location = new Point(100, 90);
            tipoOperacaoComboBox.Size = new Size(150, 20);
            tipoOperacaoComboBox.Items.Add("Entrada");
            tipoOperacaoComboBox.Items.Add("Saída");
            tipoOperacaoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(tipoOperacaoComboBox);

            // Configurações do label de lojaId
            lojaIdLabel = new Label();
            lojaIdLabel.Text = "Loja";
            lojaIdLabel.Location = new Point(20, 120);
            lojaIdLabel.Size = new Size(80, 20);
            this.Controls.Add(lojaIdLabel);

            // Configurações do combobox de lojaId
            lojaIdComboBox = new ComboBox();
            lojaIdComboBox.Location = new Point(100, 120);
            lojaIdComboBox.Size = new Size(150, 20);
            List<Model.Loja> lojas = new List<Model.Loja>();
            foreach (Model.Loja loja in Model.Loja.BuscaLoja())
            {
                lojas.Add(loja);
            }
            lojaIdComboBox.ValueMember = "lojaId";
            lojaIdComboBox.DisplayMember = "nome";
            lojaIdComboBox.DataSource = lojas;
            lojaIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(lojaIdComboBox);

            // Configurações do label de funcionarioId
            funcionarioIdLabel = new Label();
            funcionarioIdLabel.Text = "Funcionário";
            funcionarioIdLabel.Location = new Point(20, 150);
            funcionarioIdLabel.Size = new Size(80, 20);
            this.Controls.Add(funcionarioIdLabel);

            // Configurações do combobox de funcionarioId
            funcionarioIdComboBox = new ComboBox();
            funcionarioIdComboBox.Location = new Point(100, 150);
            funcionarioIdComboBox.Size = new Size(150, 20);
            List<Model.Funcionario> funcionarios = new List<Model.Funcionario>();
            foreach (Model.Funcionario funcionario in Model.Funcionario.BuscaFuncionario())
            {
                funcionarios.Add(funcionario);
            }
            funcionarioIdComboBox.ValueMember = "funcionarioId";
            funcionarioIdComboBox.DisplayMember = "nome";
            funcionarioIdComboBox.DataSource = funcionarios;
            funcionarioIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(funcionarioIdComboBox);

            // Configurações do label de bombaId
            bombaIdLabel = new Label();
            bombaIdLabel.Text = "Bomba";
            bombaIdLabel.Location = new Point(20, 180);
            bombaIdLabel.Size = new Size(80, 20);
            this.Controls.Add(bombaIdLabel);

            // Configurações do combobox de bombaId
            bombaIdComboBox = new ComboBox();
            bombaIdComboBox.Location = new Point(100, 180);
            bombaIdComboBox.Size = new Size(150, 20);
            List<Model.Bomba> bombas = new List<Model.Bomba>();
            foreach (Model.Bomba bomba in Model.Bomba.BuscaBomba())
            {
                bombas.Add(bomba);
            }
            bombaIdComboBox.ValueMember = "bombaId";
            bombaIdComboBox.DisplayMember = "bombaId";
            bombaIdComboBox.DataSource = bombas;
            bombaIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(bombaIdComboBox);

            // Configurações do label de combustivelId
            combustivelIdLabel = new Label();
            combustivelIdLabel.Text = "Combustível";
            combustivelIdLabel.Location = new Point(20, 210);
            combustivelIdLabel.Size = new Size(80, 20);
            combustivelIdLabel.Visible = false;
            this.Controls.Add(combustivelIdLabel);

            // Configurações do combobox de combustivelId
            combustivelIdComboBox = new ComboBox();
            combustivelIdComboBox.Location = new Point(100, 210);
            combustivelIdComboBox.Size = new Size(150, 20);
            combustivelIdComboBox.Visible = false;
            List<Model.Combustivel> combustiveis = new List<Model.Combustivel>();
            foreach (Model.Combustivel combustivel in Model.Combustivel.BuscaCombustivel())
            {
                combustiveis.Add(combustivel);
            }
            combustivelIdComboBox.ValueMember = "combustivelId";
            combustivelIdComboBox.DisplayMember = "nome";
            combustivelIdComboBox.DataSource = combustiveis;
            combustivelIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(combustivelIdComboBox);

            // Configurações do Label FornecedorId
            fornecedorIdLabel = new Label();
            fornecedorIdLabel.Text = "Fornecedor";
            fornecedorIdLabel.Location = new Point(20, 240);
            fornecedorIdLabel.Size = new Size(80, 20);
            fornecedorIdLabel.Visible = false;
            this.Controls.Add(fornecedorIdLabel);

            // Configurações do combobox de fornecedorId
            fornecedorIdComboBox = new ComboBox();
            fornecedorIdComboBox.Location = new Point(100, 240);
            fornecedorIdComboBox.Size = new Size(150, 20);
            fornecedorIdComboBox.Visible = false;
            List<Model.Fornecedor> fornecedores = new List<Model.Fornecedor>();
            foreach (Model.Fornecedor fornecedor in Model.Fornecedor.BuscaFornecedor())
            {
                fornecedores.Add(fornecedor);
            }
            fornecedorIdComboBox.ValueMember = "fornecedorId";
            fornecedorIdComboBox.DisplayMember = "nome";
            fornecedorIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(fornecedorIdComboBox);

            // Configurações do botão de gravar
            gravarButton = new Button();
            gravarButton.Text = "Gravar";
            gravarButton.Location = new Point(20, 270);
            gravarButton.Size = new Size(80, 20);
            gravarButton.Click += (sender, e) => {
                salvarMovimentacao();
                LimpaTela();
            };
            this.Controls.Add(gravarButton);

            // Configurações do botão de sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(100, 270);
            sairButton.Size = new Size(80, 20);
            sairButton.Click += (sender, e) => this.Close();
            this.Controls.Add(sairButton);
        }

        public FormEditaMovimentacao()
        {
            InitializeComponent();
        }

        public void salvarMovimentacao()
        {
            try
            {
                Controller.Movimentacao movimentacao = new Controller.Movimentacao();
                var movimentacaoSelecionada = (Controller.Movimentacao) movimentacaoIdComboBox.SelectedItem;
                if (movimentacaoSelecionada == null)
                {
                    MessageBox.Show("Selecione a movimentação");
                    return;
                }
                var tipoOperacaoSelecionada = (Controller.Movimentacao) tipoOperacaoComboBox.SelectedItem;
                if (tipoOperacaoSelecionada == null)
                {
                    MessageBox.Show("Selecione o tipo de operação");
                    return;
                }
                var lojaSelecionada = (Model.Loja) lojaIdComboBox.SelectedItem;
                if (lojaSelecionada == null)
                {
                    MessageBox.Show("Selecione a loja");
                    return;
                }
                var funcionarioSelecionado = (Model.Funcionario) funcionarioIdComboBox.SelectedItem;
                if (funcionarioSelecionado == null)
                {
                    MessageBox.Show("Selecione o funcionário");
                    return;
                }
                var bombaSelecionada = (Model.Bomba) bombaIdComboBox.SelectedItem;
                if (bombaSelecionada == null)
                {
                    MessageBox.Show("Selecione a bomba");
                    return;                }
                var combustivelSelecionado = (Model.Combustivel) combustivelIdComboBox.SelectedItem;
                if (combustivelSelecionado == null)
                {
                    MessageBox.Show("Selecione o combustível");
                    return;
                }
                var fornecedorSelecionado = (Model.Fornecedor) fornecedorIdComboBox.SelectedItem;
                movimentacao.movimentacaoId = movimentacaoSelecionada.movimentacaoId.ToString();
                movimentacao.tipoOperacao = tipoOperacaoSelecionada.tipoOperacao;
                movimentacao.quantidade = quantidadeTextBox.Text;
                movimentacao.lojaId = lojaSelecionada.lojaId.ToString();
                movimentacao.funcionarioId = funcionarioSelecionado.funcionarioId.ToString();
                movimentacao.bombaId = bombaSelecionada.bombaId.ToString();
                movimentacao.combustivelId = combustivelSelecionado.combustivelId.ToString();
                if (movimentacao.tipoOperacao == "Entrada")
                {
                    movimentacao.fornecedorId = fornecedorSelecionado.fornecedorId.ToString();
                }
                else
                {
                    movimentacao.fornecedorId = "0";
                }
                Controller.Movimentacao.AlteraMovimentacao( movimentacao.movimentacaoId, movimentacao.combustivelId, movimentacao.quantidade, movimentacao.tipoOperacao, movimentacao.lojaId, movimentacao.funcionarioId, movimentacao.bombaId, movimentacao.fornecedorId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar movimentação: " + ex.Message);
            }
        }

        public void LimpaTela()
        {
            quantidadeTextBox.Text = "";
            tipoOperacaoComboBox.Text = "";
            lojaIdComboBox.Text = "";
            funcionarioIdComboBox.Text = "";
            bombaIdComboBox.Text = "";
            combustivelIdComboBox.Text = "";
        }
    }

//----------------------- Formulário de exclusão de movimentação ---------------------------
    public class FormExcluiMovimentacao : Form
    {
        private Label movimentacaoIdLabel;
        private ComboBox movimentacaoIdComboBox;
        private Button excluirButton;
        private Button sairButton;

        private void InitializeComponent()
        {
            // Configurações do Formulário
            this.Text = "Excluir Movimentação";
            this.Size = new Size(300, 150);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Configurações do label de movimentacaoId
            movimentacaoIdLabel = new Label();
            movimentacaoIdLabel.Text = "Movimentação";
            movimentacaoIdLabel.Location = new Point(20, 20);
            movimentacaoIdLabel.Size = new Size(80, 20);
            this.Controls.Add(movimentacaoIdLabel);

            // Configurações do combobox de movimentacaoId
            movimentacaoIdComboBox = new ComboBox();
            movimentacaoIdComboBox.Location = new Point(100, 20);
            movimentacaoIdComboBox.Size = new Size(150, 20);
            List<Model.Movimentacao> movimentacoes = new List<Model.Movimentacao>();
            foreach (Model.Movimentacao movimentacao in Model.Movimentacao.BuscaMovimentacao())
            {
                movimentacoes.Add(movimentacao);
            }
            movimentacaoIdComboBox.ValueMember = "movimentacaoId";
            movimentacaoIdComboBox.DisplayMember = "movimentacaoId";
            movimentacaoIdComboBox.DataSource = movimentacoes;
            movimentacaoIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(movimentacaoIdComboBox);

            // Configurações do botão de excluir
            excluirButton = new Button();
            excluirButton.Text = "Excluir";
            excluirButton.Location = new Point(20, 60);
            excluirButton.Size = new Size(80, 20);
            excluirButton.Click += (sender, e) => {
                excluirMovimentacao();
                LimpaTela();
            };
            this.Controls.Add(excluirButton);

            // Configurações do botão de sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(100, 60);
            sairButton.Size = new Size(80, 20);
            sairButton.Click += (sender, e) => this.Close();
            this.Controls.Add(sairButton);
        }

        public FormExcluiMovimentacao()
        {
            InitializeComponent();
        }

        public void excluirMovimentacao()
        {
            try
            {
                Controller.Movimentacao movimentacao = new Controller.Movimentacao();
                var movimentacaoSelecionada = (Controller.Movimentacao) movimentacaoIdComboBox.SelectedItem;
                if (movimentacaoSelecionada == null)
                {
                    MessageBox.Show("Selecione a movimentação");
                    return;
                }
                movimentacao.movimentacaoId = movimentacaoSelecionada.movimentacaoId.ToString();
                Controller.Movimentacao.DeletaMovimentacao(movimentacao.movimentacaoId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir movimentação: " + ex.Message);
            }
        }

        public void LimpaTela()
        {
            movimentacaoIdComboBox.Text = "";
        }
    }
 }