/* Módulo View BombaForm 
 * Descrição: Cadastro de Bomba de combustivel
 * Autor: Erich Wanderley
 * Data: 20/04/2023
 * Versão: 1.0
 */

namespace View.Formulario.bombaForm
{
    public partial class CadBomba : Form
    {
        private Label combustivelIdLabel;
        private Label limiteMaximoLabel;
        private Label limiteMinimoLabel;
        private Label volumeLabel;
        private Label lojaIdLabel;
        private ComboBox combustivelIdComboBox;
        private TextBox limiteMaximoTextBox;
        private TextBox limiteMinimoTextBox;
        private TextBox volumeTextBox;
        private ComboBox lojaIdComboBox;
        private Button gravarButton;
        private Button sairButton;
        public CadBomba()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            //Configuração da janela do formulário
            this.ClientSize = new System.Drawing.Size(270,200);
            this.Text = "Cadastro de Bombas";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = ColorTranslator.FromHtml("#CFCFCF");

            //Configurações do id
            combustivelIdLabel = new Label();
            combustivelIdLabel.Text = "Combústivel: ";
            combustivelIdLabel.Location = new Point(20, 40);
            combustivelIdLabel.Size = new Size(80, 20);
            this.Controls.Add(combustivelIdLabel);

            //Configurações do campo texto de id
            combustivelIdComboBox = new ComboBox();
            combustivelIdComboBox.Location = new Point(100, 40);
            combustivelIdComboBox.Size = new Size(150, 20);
            List<Controller.Combustivel> combustiveis = new List<Controller.Combustivel>();
            foreach (Model.Combustivel combustivel in Model.Combustivel.BuscaCombustivel())
            {
                combustivelIdComboBox.Items.Add(combustivel);
            }
            combustivelIdComboBox.DisplayMember = "nome";
            combustivelIdComboBox.ValueMember = "id";
            combustivelIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(combustivelIdComboBox);

            //Configurações de rótulo identificação da loja
            lojaIdLabel = new Label();
            lojaIdLabel.Text = "Loja:";
            lojaIdLabel.Location = new Point(66, 10);
            lojaIdLabel.Size = new Size(32, 20);
            this.Controls.Add(lojaIdLabel);

            //Configurando o Campo de texto identificação da loja
            lojaIdComboBox = new ComboBox();
            lojaIdComboBox.Location = new Point(100, 10);
            lojaIdComboBox.Size = new Size(150, 20 );
            List<Controller.Loja> lojas = new List<Controller.Loja>();
            foreach (Model.Loja loja in Model.Loja.BuscaLoja())
            {
                lojaIdComboBox.Items.Add(loja);
            }
            lojaIdComboBox.DisplayMember = "nome";
            lojaIdComboBox.ValueMember = "id";
            lojaIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(lojaIdComboBox);

            //Configurações de rótulo Capacidade Máxima
            limiteMaximoLabel = new Label();
            limiteMaximoLabel.Text = "Cap. Máxima: ";
            limiteMaximoLabel.Location = new Point(20, 70);
            limiteMaximoLabel.Size = new Size(80, 20);
            this.Controls.Add(limiteMaximoLabel);
            
            //Configurando o Campo de texto Capacidade Máxima
            limiteMaximoTextBox = new TextBox();
            limiteMaximoTextBox.Location = new Point(100, 70);
            limiteMaximoTextBox.Size = new Size(150, 20);
            this.Controls.Add(limiteMaximoTextBox);

            //Configurações de rótulo Capacidade Miníma
            limiteMinimoLabel = new Label();
            limiteMinimoLabel.Text = "Cap. Miníma: ";
            limiteMinimoLabel.Location = new Point(20, 100);
            limiteMinimoLabel.Size = new Size(80, 20);
            this.Controls.Add(limiteMinimoLabel);

            //Configurando o Campo de texto Capacidade Miníma
            limiteMinimoTextBox = new TextBox();
            limiteMinimoTextBox.Location = new Point(100, 100);
            limiteMinimoTextBox.Size = new Size(150, 20 );
            this.Controls.Add(limiteMinimoTextBox);

            //Configurações de rótulo Movimentação
            volumeLabel = new Label();
            volumeLabel.Text = "Volume:";
            volumeLabel.Location = new Point(48, 130);
            volumeLabel.Size = new Size(50, 20);
            this.Controls.Add(volumeLabel);

            //Configurando o Campo de texto movimentação
            volumeTextBox = new TextBox();
            volumeTextBox.Location = new Point(100, 130);
            volumeTextBox.Size = new Size(150, 20 );
            this.Controls.Add(volumeTextBox);

            //Configurações do botao gravar
            gravarButton = new Button();
            gravarButton.Text = "Gravar";
            gravarButton.Location = new Point(80, 160);
            gravarButton.Size = new Size(80, 30);
            gravarButton.Click += new EventHandler(gravarButton_Click);
            gravarButton.BackColor = ColorTranslator.FromHtml("#FFFDE8");
            this.Controls.Add(gravarButton);

            //Configurações do botão sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(170, 160);
            sairButton.Size = new Size(80, 30);
            sairButton.Click += new EventHandler(sairButton_Click);
            sairButton.BackColor = ColorTranslator.FromHtml("#FFFDE8");
            this.Controls.Add(sairButton);

            //Painel para os botões
            Panel panel = new Panel();
            panel.Size = new Size(100, 50);
            panel.BackColor = ColorTranslator.FromHtml("#4056A1");
            panel.Dock = DockStyle.Bottom;
            this.Controls.Add(panel);
        }
        private void gravarButton_Click(object sender, EventArgs e)
        {
            try
            {
                Controller.Bomba bomba = new Controller.Bomba();//Instanciando a classe bomba
                var combustivelSelecionado = ((Model.Combustivel)combustivelIdComboBox.SelectedItem).combustivelId.ToString();//Criando uma variável para receber o valor do item selecionado no combobox
                if (combustivelSelecionado == "0")//Verificando se o valor da variável é igual a 0
                {
                    MessageBox.Show("Selecione um combustível!");//Exibindo mensagem de erro
                    return;//Retornando
                }
                var lojaSelecionada = ((Model.Loja)lojaIdComboBox.SelectedItem).lojaId.ToString();//Criando uma variável para receber o valor do item selecionado no combobox
                if (lojaSelecionada == "0")//Verificando se o valor da variável é igual a 0
                {
                    MessageBox.Show("Selecione uma loja!");//Exibindo mensagem de erro
                    return;//Retornando
                }

                bomba.combustivelId = combustivelSelecionado.ToString();//Atribuindo o valor do campo id ao atributo tipoCombustivelId
                bomba.limiteMaximo = limiteMaximoTextBox.Text;//Atribuindo o valor do campo limiteMaximo ao atributo limiteMaximo
                bomba.limiteMinimo = limiteMinimoTextBox.Text;//Atribuindo o valor do campo limiteMinimo ao atributo limiteMinimo
                bomba.volume = volumeTextBox.Text;//Atribuindo o valor do campo volume ao atributo volume
                bomba.lojaId = lojaSelecionada.ToString();//Atribuindo o valor do campo lojaId ao atributo lojaId
                Controller.Bomba.CadastrarBomba(bomba.combustivelId, bomba.limiteMaximo, bomba.limiteMinimo, bomba.volume, bomba.lojaId);//Chamando o método CadastrarBomba da classe Bomba
                MessageBox.Show("Bomba cadastrada com sucesso!");//Exibindo mensagem de sucesso
                LimpaTela();//Chamando o método LimpaTela
            }
            catch (Exception ex)//Tratamento de exceção
            {
                MessageBox.Show(ex.Message);//Exibindo mensagem de erro
            }
        }
        private void sairButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você realmente deseja sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                //Application.Exit();
            }
        }

        public void LimpaTela()
        {
            combustivelIdComboBox.Text = "";
            limiteMaximoTextBox.Text = "";
            limiteMinimoTextBox.Text = "";
            volumeTextBox.Text = "";
            lojaIdComboBox.Text = "";
        }
    }

// ---------------------------- Edição da Bomba ----------------------------

    public class FormEditaBomba : Form
    {
        private Label bombaIdLabel;
        private Label combustivelIdLabel;
        private Label limiteMaximoLabel;
        private Label limiteMinimoLabel;
        private Label volumeLabel;
        private Label lojaIdLabel;
        private ComboBox bombaIdCb;
        private ComboBox combustivelIdCb;
        private ComboBox lojaIdCb;
        private TextBox volumeTextBox;
        private TextBox limiteMaximoTextBox;
        private TextBox limiteMinimoTextBox;
        private Button gravarButton;
        private Button sairButton;

        public void InitializeComponent()
        {
            //Configuração da janela do formulário
            this.ClientSize = new System.Drawing.Size(300,400);
            this.Text = "Edição de Bomba";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = ColorTranslator.FromHtml("#CFCFCF");

            //Configurações do id
            bombaIdLabel = new Label();
            bombaIdLabel.Text = "ID Bomba: ";
            bombaIdLabel.Location = new Point(20, 30);
            bombaIdLabel.Size = new Size(80, 20);
            this.Controls.Add(bombaIdLabel);

            //Configurações do campo texto de id
            bombaIdCb = new ComboBox();
            bombaIdCb.Location = new Point(100, 30);
            bombaIdCb.Size = new Size(150, 20);
            List<Controller.Bomba> listaBombas = new  List<Controller.Bomba>();
            foreach (Model.Bomba bomba in Controller.Bomba.ListarBombas())
            {
                bombaIdCb.Items.Add(bomba);
            }
            bombaIdCb.DisplayMember = "bombaId";
            bombaIdCb.ValueMember = "bombaId";
            bombaIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(bombaIdCb);

            //Configurações do tipoCombustivelId
            combustivelIdLabel = new Label();
            combustivelIdLabel.Text = "ID Combústivel: ";
            combustivelIdLabel.Location = new Point(20, 60);
            combustivelIdLabel.Size = new Size(80, 20);
            this.Controls.Add(combustivelIdLabel);

            //Configurações do campo texto de tipoCombustivelId
            combustivelIdCb = new ComboBox();
            combustivelIdCb.Location = new Point(100, 60);
            combustivelIdCb.Size = new Size(150, 20);
            List<Controller.Combustivel> listaTipoCombustivel = new  List<Controller.Combustivel>();
            foreach (Model.Combustivel combustivel in Controller.Combustivel.ListaCombustivel())
            {
                combustivelIdCb.Items.Add(combustivel);
            }
            combustivelIdCb.ValueMember = "combustivelId";
            combustivelIdCb.DisplayMember = "nome";
            combustivelIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(combustivelIdCb);

            //Configurações de rótulo Capacidade Máxima
            limiteMaximoLabel = new Label();
            limiteMaximoLabel.Text = "Cap. Máxima: ";
            limiteMaximoLabel.Location = new Point(20, 90);
            limiteMaximoLabel.Size = new Size(80, 20);
            this.Controls.Add(limiteMaximoLabel);

            //Configurando o Campo de texto Capacidade Máxima
            limiteMaximoTextBox = new TextBox();
            limiteMaximoTextBox.Location = new Point(100, 90);
            limiteMaximoTextBox.Size = new Size(150, 20);
            this.Controls.Add(limiteMaximoTextBox);

            //Configurações de rótulo Capacidade Mínima
            limiteMinimoLabel = new Label();
            limiteMinimoLabel.Text = "Cap. Mínima: ";
            limiteMinimoLabel.Location = new Point(20, 120);
            limiteMinimoLabel.Size = new Size(80, 20);
            this.Controls.Add(limiteMinimoLabel);

            //Configurando o Campo de texto Capacidade Mínima
            limiteMinimoTextBox = new TextBox();
            limiteMinimoTextBox.Location = new Point(100, 120);
            limiteMinimoTextBox.Size = new Size(150, 20);
            this.Controls.Add(limiteMinimoTextBox);

            //Configurações de rótulo Nome do Combustível
            volumeLabel = new Label();
            volumeLabel.Text = "Volume: ";
            volumeLabel.Location = new Point(20, 150);
            volumeLabel.Size = new Size(80, 20);
            this.Controls.Add(volumeLabel);

            //Configurando o Campo de texto Nome do Combustível
            volumeTextBox = new TextBox();
            volumeTextBox.Location = new Point(100, 150);
            volumeTextBox.Size = new Size(150, 20);
            this.Controls.Add(volumeTextBox);

            //Configurações do botão Gravar
            gravarButton = new Button();
            gravarButton.Text = "Gravar";
            gravarButton.Location = new Point(20, 180);
            gravarButton.Size = new Size(80, 20);
            gravarButton.Click += (ScrollBarRenderer, e) =>{
                SalvaBomba();
                LimpaTela();
            };
            gravarButton.BackColor = ColorTranslator.FromHtml("#FFFDE8");
            this.Controls.Add(gravarButton);

            //Configurações do botão Sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(100, 180);
            sairButton.Size = new Size(80, 20);
            sairButton.Click += (ScrollBarRenderer, e) => this.Close();
            sairButton.BackColor = ColorTranslator.FromHtml("#FFFDE8");
            this.Controls.Add(sairButton);

            //Painel para os botões
            Panel panel = new Panel();
            panel.Size = new Size(100, 50);
            panel.BackColor = ColorTranslator.FromHtml("#4056A1");
            panel.Dock = DockStyle.Bottom;
            this.Controls.Add(panel);
        }
        
        public FormEditaBomba()
        {
            InitializeComponent();
        }

        public void SalvaBomba()
        {
            try
            {
                Controller.Bomba bomba = new Controller.Bomba();
                var bombaSelecionada = ((Model.Bomba) bombaIdCb.SelectedItem).bombaId.ToString();
                if (bombaSelecionada == null)
                {
                    MessageBox.Show("Selecione uma bomba");
                    return;
                }
                var combustivelSelecionado = ((Model.Combustivel) combustivelIdCb.SelectedItem).combustivelId.ToString();
                if (combustivelSelecionado == null)
                {
                    MessageBox.Show("Selecione um combustível");
                    return;
                }
                bomba.bombaId = bombaSelecionada.ToString();
                bomba.combustivelId = combustivelSelecionado.ToString();
                bomba.limiteMaximo = limiteMaximoTextBox.Text;
                bomba.limiteMinimo = limiteMinimoTextBox.Text;
                bomba.volume = volumeTextBox.Text;
  

                Controller.Bomba controllerBomba = new Controller.Bomba();
                Controller.Bomba.AlterarBomba(bomba.bombaId, bomba.combustivelId, bomba.limiteMaximo, bomba.limiteMinimo, bomba.volume);
                MessageBox.Show("Bomba alterada com sucesso!");
            } catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar bomba: " + ex.Message);
            }
        }
        
        public void LimpaTela()
        {
            bombaIdCb.Text = "";
            combustivelIdCb.Text = "";
            limiteMaximoTextBox.Text = "";
            limiteMinimoTextBox.Text = "";
            volumeTextBox.Text = "";
        }
    }

//--------------------------------------------------------------

    public class FormExcluiBomba : Form
    {
        private Label bombaIdLabel;
        private ComboBox bombaIdCb;
        private Button excluirButton;
        private Button sairButton;

        private void InitializeComponent()
        {
            this.Text = "Excluir Bomba";
            this.Size = new Size(300, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = ColorTranslator.FromHtml("#E6773A");

            //Configurações do rótulo bombaId
            bombaIdLabel = new Label();
            bombaIdLabel.Text = "ID Bomba: ";
            bombaIdLabel.Location = new Point(20, 30);
            bombaIdLabel.Size = new Size(80, 20);
            this.Controls.Add(bombaIdLabel);

            //Configurações do campo texto de bombaId
            bombaIdCb = new ComboBox();
            bombaIdCb.Location = new Point(100, 30);
            bombaIdCb.Size = new Size(150, 20);
            List<Controller.Bomba> listaBombas = new  List<Controller.Bomba>();
            foreach (Model.Bomba bomba in Controller.Bomba.ListarBombas())
            {
                bombaIdCb.Items.Add(bomba);
            }
            //bombaIdCb.DisplayMember = "bombaId";
            bombaIdCb.ValueMember = "BombaId";
            bombaIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(bombaIdCb);

            //Configurações do botão Excluir
            excluirButton = new Button();
            excluirButton.Text = "Excluir";
            excluirButton.Location = new Point(20, 60);
            excluirButton.Size = new Size(80, 20);
            excluirButton.Click += (ScrollBarRenderer, e) =>{
                ExcluiBomba();
                LimpaTela();
            };
            excluirButton.BackColor = ColorTranslator.FromHtml("#FFFDE8");
            this.Controls.Add(excluirButton);

            //Configurações do botão Sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(100, 60);
            sairButton.Size = new Size(80, 20);
            sairButton.Click += (ScrollBarRenderer, e) => this.Close();
            sairButton.BackColor = ColorTranslator.FromHtml("#FFFDE8");
            this.Controls.Add(sairButton);

            //Painel para os botões
            Panel panel = new Panel();
            panel.Size = new Size(100, 50);
            panel.BackColor = ColorTranslator.FromHtml("#4056A1");
            panel.Dock = DockStyle.Bottom;
            this.Controls.Add(panel);
        }

        public FormExcluiBomba()
        {
            InitializeComponent();
        }

        public void ExcluiBomba()
        {
            try
            {
                Controller.Bomba bomba = new Controller.Bomba();
                var bombaSelecionada = ((Model.Bomba) bombaIdCb.SelectedItem).bombaId.ToString();
                if (bombaSelecionada == null)
                {
                    MessageBox.Show("Selecione uma bomba");
                    return;
                }
                bomba.bombaId = bombaSelecionada.ToString();

                Controller.Bomba.DeletaBomba(bombaIdCb.Text);
                MessageBox.Show("Bomba excluída com sucesso!");
            } catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir bomba: " + ex.Message);
            }
        }

        public void LimpaTela()
        {
            bombaIdCb.Text = "";
        }
    }
}