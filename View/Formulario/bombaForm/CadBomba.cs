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
        private TextBox combustivelIdTextBox;
        private TextBox limiteMaximoTextBox;
        private TextBox limiteMinimoTextBox;
        private TextBox volumeTextBox;
        private TextBox lojaIdTextBox;
        private Button gravarButton;
        private Button sairButton;
        public CadBomba()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            //Configuração da janela do formulário
            this.ClientSize = new System.Drawing.Size(300,400);
            this.Text = "Cadastro de Bombas";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            //Configurações do id
            combustivelIdLabel = new Label();
            combustivelIdLabel.Text = "Combústivel: ";
            combustivelIdLabel.Location = new Point(20, 30);
            combustivelIdLabel.Size = new Size(80, 20);
            this.Controls.Add(combustivelIdLabel);

            //Configurações do campo texto de id
            combustivelIdTextBox = new TextBox();
            combustivelIdTextBox.Location = new Point(100, 30);
            combustivelIdTextBox.Size = new Size(150, 20);
            this.Controls.Add(combustivelIdTextBox);

            //Configurações de rótulo Capacidade Máxima
            limiteMaximoLabel = new Label();
            limiteMaximoLabel.Text = "Cap. Máxima: ";
            limiteMaximoLabel.Location = new Point(20, 60);
            limiteMaximoLabel.Size = new Size(80, 20);
            this.Controls.Add(limiteMaximoLabel);
            
            //Configurando o Campo de texto Capacidade Máxima
            limiteMaximoTextBox = new TextBox();
            limiteMaximoTextBox.Location = new Point(100, 60);
            limiteMaximoTextBox.Size = new Size(150, 20);
            this.Controls.Add(limiteMaximoTextBox);

            //Configurações de rótulo Capacidade Miníma
            limiteMinimoLabel = new Label();
            limiteMinimoLabel.Text = "Cap. Miníma: ";
            limiteMinimoLabel.Location = new Point(20, 90);
            limiteMinimoLabel.Size = new Size(80, 20);
            this.Controls.Add(limiteMinimoLabel);

            //Configurando o Campo de texto Capacidade Miníma
            limiteMinimoTextBox = new TextBox();
            limiteMinimoTextBox.Location = new Point(100, 90);
            limiteMinimoTextBox.Size = new Size(150, 20 );
            this.Controls.Add(limiteMinimoTextBox);

            //Configurações de rótulo Movimentação
            volumeLabel = new Label();
            volumeLabel.Text = "Volume: ";
            volumeLabel.Location = new Point(20, 120);
            volumeLabel.Size = new Size(80, 20);
            this.Controls.Add(volumeLabel);

            //Configurando o Campo de texto movimentação
            volumeTextBox = new TextBox();
            volumeTextBox.Location = new Point(100, 120);
            volumeTextBox.Size = new Size(150, 20 );
            this.Controls.Add(volumeTextBox);

            //Configurações de rótulo identificação da loja
            lojaIdLabel = new Label();
            lojaIdLabel.Text = "Loja: ";
            lojaIdLabel.Location = new Point(20, 150);
            lojaIdLabel.Size = new Size(80, 20);
            this.Controls.Add(lojaIdLabel);

            //Configurando o Campo de texto identificação da loja
            lojaIdTextBox = new TextBox();
            lojaIdTextBox.Location = new Point(100, 150);
            lojaIdTextBox.Size = new Size(150, 20 );
            this.Controls.Add(lojaIdTextBox);

            //Configurações do botao gravar
            gravarButton = new Button();
            gravarButton.Text = "Gravar";
            gravarButton.Location = new Point(70, 180);
            gravarButton.Size = new Size(80, 30);
            gravarButton.Click += new EventHandler(gravarButton_Click);
            this.Controls.Add(gravarButton);

            //Configurações do botão sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(160, 180);
            sairButton.Size = new Size(80, 30);
            sairButton.Click += new EventHandler(sairButton_Click);
            this.Controls.Add(sairButton);
        }
        private void gravarButton_Click(object sender, EventArgs e)
        {
            try
            {
                Controller.Bomba bomba = new Controller.Bomba();//Instanciando a classe bomba
                bomba.combustivelId = combustivelIdTextBox.Text;//Atribuindo o valor do campo id ao atributo tipoCombustivelId
                if (bomba.combustivelId == null)  throw new Exception("O campo ID não pode ser vazio!");//Verificando se o campo id está vazio
                bomba.limiteMaximo = limiteMaximoTextBox.Text;//Atribuindo o valor do campo limiteMaximo ao atributo limiteMaximo
                bomba.limiteMinimo = limiteMinimoTextBox.Text;//Atribuindo o valor do campo limiteMinimo ao atributo limiteMinimo
                bomba.volume = volumeTextBox.Text;//Atribuindo o valor do campo volume ao atributo volume
                bomba.lojaId = lojaIdTextBox.Text;//Atribuindo o valor do campo lojaId ao atributo lojaId
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
            combustivelIdTextBox.Text = "";
            limiteMaximoTextBox.Text = "";
            limiteMinimoTextBox.Text = "";
            volumeTextBox.Text = "";
            lojaIdTextBox.Text = "";
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
        private ComboBox volumeCb;
        private ComboBox lojaIdCb;
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
            bombaIdCb.DisplayMember = "Id";
            bombaIdCb.ValueMember = "Id";
            bombaIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(bombaIdCb);

            //Configurações do tipoCombustivelId
            combustivelIdLabel = new Label();
            combustivelIdLabel.Text = "ID Combústivel: ";
            combustivelIdLabel.Location = new Point(20, 60);
            combustivelIdLabel.Size = new Size(80, 20);
            List<Controller.Combustivel> listaTipoCombustivel = new  List<Controller.Combustivel>();
            foreach (Model.Combustivel combustivel in Controller.Combustivel.ListaCombustivel())
            {
                combustivelIdCb.Items.Add(combustivel);
            }
            combustivelIdCb.DisplayMember = "nome";
            combustivelIdCb.ValueMember = "Id";
            combustivelIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(combustivelIdLabel);

            //Configurações do campo texto de tipoCombustivelId
            combustivelIdCb = new ComboBox();
            combustivelIdCb.Location = new Point(100, 60);
            combustivelIdCb.Size = new Size(150, 20);
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
            volumeLabel.Text = "Nome Combustível: ";
            volumeLabel.Location = new Point(20, 150);
            volumeLabel.Size = new Size(80, 20);
            this.Controls.Add(volumeLabel);

            //Configurando o Campo de texto Nome do Combustível
            volumeCb = new ComboBox();
            volumeCb.Location = new Point(100, 150);
            volumeCb.Size = new Size(150, 20);
            this.Controls.Add(volumeCb);

            //Configurações do botão Gravar
            gravarButton = new Button();
            gravarButton.Text = "Gravar";
            gravarButton.Location = new Point(20, 180);
            gravarButton.Size = new Size(80, 20);
            gravarButton.Click += (ScrollBarRenderer, e) =>{
                SalvaBomba();
                LimpaTela();
            };
            this.Controls.Add(gravarButton);

            //Configurações do botão Sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(100, 180);
            sairButton.Size = new Size(80, 20);
            sairButton.Click += (ScrollBarRenderer, e) => this.Close();
            this.Controls.Add(sairButton);
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
                var bombaSelecionada = (Controller.Bomba) bombaIdCb.SelectedItem;
                if (bombaSelecionada == null)
                {
                    MessageBox.Show("Selecione uma bomba");
                    return;
                }
                bomba.bombaId = bombaSelecionada.bombaId.ToString();
                bomba.combustivelId = combustivelIdCb.Text;
                bomba.limiteMaximo = limiteMaximoTextBox.Text;
                bomba.limiteMinimo = limiteMinimoTextBox.Text;
                bomba.volume = volumeCb.Text;
                bomba.lojaId = lojaIdCb.Text;

                Controller.Bomba controllerBomba = new Controller.Bomba();
                Controller.Bomba.AlterarBomba(bomba.bombaId, bomba.combustivelId, bomba.limiteMaximo, bomba.limiteMinimo, bomba.volume, bomba.lojaId);
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
            volumeCb.Text = "";
            lojaIdCb.Text = "";
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
            bombaIdCb.DisplayMember = "Id";
            bombaIdCb.ValueMember = "Id";
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
            this.Controls.Add(excluirButton);

            //Configurações do botão Sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(100, 60);
            sairButton.Size = new Size(80, 20);
            sairButton.Click += (ScrollBarRenderer, e) => this.Close();
            this.Controls.Add(sairButton);
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
                var bombaSelecionada = (Controller.Bomba) bombaIdCb.SelectedItem;
                if (bombaSelecionada == null)
                {
                    MessageBox.Show("Selecione uma bomba");
                    return;
                }
                bomba.bombaId = bombaSelecionada.bombaId.ToString();

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