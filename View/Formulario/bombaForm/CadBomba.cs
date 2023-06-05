/* Módulo View BombaForm 
 * Descrição: Cadastro de Bomba de combustivel
 * Autor: Erich Wanderley
 * Data: 20/04/2023
 * Versão: 1.0
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace View.Fomulario.BombaForm
{
    public partial class CadBomba : Form
    {
        private Label tipoCombustivelIdLabel;
        private Label limiteMaximoLabel;
        private Label limiteMinimoLabel;
        private Label nomeCombustivelLabel;
        private TextBox tipoCombustivelIdTextBox;
        private TextBox limiteMaximoTextBox;
        private TextBox limiteMinimoTextBox;
        private TextBox nomeCombustivelTextBox;
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
            tipoCombustivelIdLabel = new Label();
            tipoCombustivelIdLabel.Text = "ID Combústivel: ";
            tipoCombustivelIdLabel.Location = new Point(20, 30);
            tipoCombustivelIdLabel.Size = new Size(80, 20);
            this.Controls.Add(tipoCombustivelIdLabel);

            //Configurações do campo texto de id
            tipoCombustivelIdTextBox = new TextBox();
            tipoCombustivelIdTextBox.Location = new Point(100, 30);
            tipoCombustivelIdTextBox.Size = new Size(150, 20);
            this.Controls.Add(tipoCombustivelIdTextBox);

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
            limiteMinimoLabel.Location = new Point(20, 60);
            limiteMinimoLabel.Size = new Size(80, 20);
            this.Controls.Add(limiteMinimoLabel);

            //Configurando o Campo de texto Capacidade Miníma
            limiteMinimoTextBox = new TextBox();
            limiteMinimoTextBox.Location = new Point(100, 60);
            limiteMinimoTextBox.Size = new Size(160, 30 );
            this.Controls.Add(limiteMinimoTextBox);

            //Configurações de rótulo Nome do Combustivel
            nomeCombustivelLabel = new Label();
            nomeCombustivelLabel.Text = "Nome Combustivel: ";
            nomeCombustivelLabel.Location = new Point(20, 60);
            nomeCombustivelLabel.Size = new Size(80, 20);
            this.Controls.Add(nomeCombustivelLabel);

            //Configurando o Campo de texto Nome do Combustivel
            nomeCombustivelTextBox = new TextBox();
            nomeCombustivelTextBox.Location = new Point(100, 60);
            nomeCombustivelTextBox.Size = new Size(160, 30 );
            this.Controls.Add(nomeCombustivelTextBox);

            //Configurações do botao gravar
            gravarButton = new Button();
            gravarButton.Text = "Gravar";
            gravarButton.Location = new Point(70, 100);
            gravarButton.Size = new Size(80, 30);
            gravarButton.Click += new EventHandler(gravarButton_Click);
            this.Controls.Add(gravarButton);

            //Configurações do botão sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(160, 100);
            sairButton.Size = new Size(80, 30);
            sairButton.Click += new EventHandler(sairButton_Click);
            this.Controls.Add(sairButton);
        }
         private void gravarButton_Click(object sender, EventArgs e)
        {
            try
            {
                Controller.Bomba bomba = new Controller.Bomba();//Instanciando a classe bomba
                bomba.tipoCombustivelId = tipoCombustivelIdTextBox.Text;//Atribuindo o valor do campo id ao atributo tipoCombustivelId
                if (bomba.tipoCombustivelId == null)  throw new Exception("O campo ID não pode ser vazio!");//Verificando se o campo id está vazio
                bomba.limiteMaximo = limiteMaximoTextBox.Text;//Atribuindo o valor do campo limiteMaximo ao atributo limiteMaximo
                bomba.limiteMinimo = limiteMinimoTextBox.Text;//Atribuindo o valor do campo limiteMinimo ao atributo limiteMinimo
                Controller.Bomba.CadastrarBomba(bomba.tipoCombustivelId, bomba.limiteMaximo, bomba.limiteMinimo, bomba.nomeCombustivel);//Chamando o método CadastrarBomba da classe Bomba
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
            tipoCombustivelIdTextBox.Text = "";
            limiteMaximoTextBox.Text = "";
            limiteMinimoTextBox.Text = "";
            nomeCombustivelTextBox.Text = "";
        }
    }

    public class FormEditaBomba : Form
    {
        private Label bombaIdLabel;
        private Label tipoCombustivelIdLabel;
        private Label limiteMaximoLabel;
        private Label limiteMinimoLabel;
        private Label nomeCombustivelLabel;
        private ComboBox bombaIdCb;
        private ComboBox tipoCombustivelIdCb;
        private TextBox limiteMaximoTextBox;
        private TextBox limiteMinimoTextBox;
        private TextBox nomeCombustivelTextBox;
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
            List<Model.Bomba> listaBombas = new  List<Model.Bomba>();
            foreach (Model.Bomba bomba in Model.Bomba.BuscaBomba())
            {
                bombaIdCb.Items.Add(bomba);
            }
            bombaIdCb.DisplayMember = "Id";
            bombaIdCb.ValueMember = "Id";
            bombaIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(bombaIdCb);

            //Configurações do tipoCombustivelId
            tipoCombustivelIdLabel = new Label();
            tipoCombustivelIdLabel.Text = "ID Combústivel: ";
            tipoCombustivelIdLabel.Location = new Point(20, 60);
            tipoCombustivelIdLabel.Size = new Size(80, 20);
            List<Model.TipoCombustivel> listaTipoCombustivel = new  List<Model.TipoCombustivel>();
            foreach (Model.TipoCombustivel tipoCombustivel in Model.TipoCombustivel.BuscaTipoCombustivel())
            {
                tipoCombustivelIdCb.Items.Add(tipoCombustivel);
            }
            tipoCombustivelIdCb.DisplayMember = "nomeCombustivel";
            tipoCombustivelIdCb.ValueMember = "Id";
            tipoCombustivelIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(tipoCombustivelIdLabel);

            //Configurações do campo texto de tipoCombustivelId
            tipoCombustivelIdCb = new ComboBox();
            tipoCombustivelIdCb.Location = new Point(100, 60);
            tipoCombustivelIdCb.Size = new Size(150, 20);
            this.Controls.Add(tipoCombustivelIdCb);

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
            nomeCombustivelLabel = new Label();
            nomeCombustivelLabel.Text = "Nome Combustível: ";
            nomeCombustivelLabel.Location = new Point(20, 150);
            nomeCombustivelLabel.Size = new Size(80, 20);
            this.Controls.Add(nomeCombustivelLabel);

            //Configurando o Campo de texto Nome do Combustível
            nomeCombustivelTextBox = new TextBox();
            nomeCombustivelTextBox.Location = new Point(100, 150);
            nomeCombustivelTextBox.Size = new Size(150, 20);
            this.Controls.Add(nomeCombustivelTextBox);

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
                bomba.tipoCombustivelId = tipoCombustivelIdCb.Text;
                bomba.limiteMaximo = limiteMaximoTextBox.Text;
                bomba.limiteMinimo = limiteMinimoTextBox.Text;
                bomba.nomeCombustivel = nomeCombustivelTextBox.Text;

                Controller.Bomba controllerBomba = new Controller.Bomba();
                Controller.Bomba.AlterarBomba(bomba.bombaId, bomba.tipoCombustivelId, bomba.limiteMaximo, bomba.limiteMinimo, bomba.nomeCombustivel);
                MessageBox.Show("Bomba alterada com sucesso!");
            } catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar bomba: " + ex.Message);
            }
        }
        
        public void LimpaTela()
        {
            bombaIdCb.Text = "";
            tipoCombustivelIdCb.Text = "";
            limiteMaximoTextBox.Text = "";
            limiteMinimoTextBox.Text = "";
            nomeCombustivelTextBox.Text = "";
        }
    }

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
            List<Model.Bomba> listaBombas = new  List<Model.Bomba>();
            foreach (Model.Bomba bomba in Model.Bomba.BuscaBomba())
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

                bomba.DeletaBomba(bomba.bombaId);
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