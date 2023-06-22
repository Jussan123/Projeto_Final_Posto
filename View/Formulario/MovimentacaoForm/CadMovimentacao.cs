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

        private TextBox quantidadeTextBox;
        private ComboBox tipoOperacaoComboBox;
        private ComboBox lojaIdComboBox;
        private ComboBox funcionarioIdComboBox;
        private ComboBox bombaIdComboBox;
        private ComboBox combustivelIdComboBox;
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
//            combustivelIdComboBox.DataSource = combustiveis;
            combustivelIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(combustivelIdComboBox);

            // Configurações do botão gravar
            gravarButton = new Button();
            gravarButton.Text = "Gravar";
            gravarButton.Location = new Point(20, 240);
            gravarButton.Size = new Size(80, 20);
            gravarButton.Click += (ScrollBarRenderer, e) =>{
                salvaMovimentacao();
                LimpaTela();
            };
            this.Controls.Add(gravarButton);

            // Configurações do botão sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(100, 240);
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
                movimentacao.combustivelId = combustivelSelecionado.combustivelId;
                movimentacao.bombaId = bombaSelecionada.bombaId;
                movimentacao.funcionarioId = funcionarioSelecionado.funcionarioId;
                movimentacao.lojaId = lojaSelecionada.lojaId;
                movimentacao.quantidade = Convert.ToDecimal(quantidadeTextBox.Text);
                movimentacao.tipoOperacao = tipoOperacaoComboBox.Text;
                Controller.Movimentacao.CadastraMovimentacao(movimentacao.combustivelId, movimentacao.quantidade.ToString(), movimentacao.tipoOperacao, movimentacao.lojaId, movimentacao.funcionarioId, movimentacao.bombaId);
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
        }

    }
 }