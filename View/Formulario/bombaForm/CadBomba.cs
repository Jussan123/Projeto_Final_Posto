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
        private Label idLabel;
        private Label capmaxLabel;
        private Label capminLabel;
        private TextBox idTextBox;
        private TextBox capmaxTextBox;
        private TextBox capminTextBox;
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
            idLabel = new Label();
            idLabel.Text = "ID Combústivel: ";
            idLabel.Location = new Point(20, 30);
            idLabel.Size = new Size(80, 20);
            this.Controls.Add(idLabel);

            //Configurações do campo texto de id
            idTextBox = new TextBox();
            idTextBox.Location = new Point(100, 30);
            idTextBox.Size = new Size(150, 20);
            this.Controls.Add(idTextBox);

            //Configurações de rótulo Capacidade Máxima
            capmaxLabel = new Label();
            capmaxLabel.Text = "Cap. Máxima: ";
            capmaxLabel.Location = new Point(20, 60);
            capmaxLabel.Size = new Size(80, 20);
            this.Controls.Add(capmaxLabel);

            //Configurando o Campo de texto Capacidade Máxima
            capmaxTextBox = new TextBox();
            capmaxTextBox.Location = new Point(100, 60);
            capmaxTextBox.Size = new Size(150, 20);
            this.Controls.Add(capmaxTextBox);

            //Configurações de rótulo Capacidade Miníma
            capminLabel = new Label();
            capminLabel.Text = "Cap. Miníma: ";
            capminLabel.Location = new Point(20, 60);
            capminLabel.Size = new Size(80, 20);
            this.Controls.Add(capminLabel);

            //Configurando o Campo de texto Capacidade Miníma
            capminTextBox = new TextBox();
            capminTextBox.Location = new Point(100, 60);
            capminTextBox.Size = new Size(160, 30 );
            this.Controls.Add(capminTextBox);

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
                bomba.tipoCombustivelId = idTextBox.Text;//Atribuindo o valor do campo id ao atributo tipoCombustivelId
                if (bomba.tipoCombustivelId == null)  throw new Exception("O campo ID não pode ser vazio!");//Verificando se o campo id está vazio
                bomba.limiteMaximo = capmaxTextBox.Text;//Atribuindo o valor do campo capmax ao atributo limiteMaximo
                bomba.limiteMinimo = capminTextBox.Text;//Atribuindo o valor do campo capmin ao atributo limiteMinimo
                Controller.Bomba.CadastrarBomba(bomba.tipoCombustivelId, bomba.limiteMaximo, bomba.limiteMinimo);//Chamando o método CadastrarBomba da classe Bomba
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
            idTextBox.Text = "";
            capmaxTextBox.Text = "";
            capminTextBox.Text = "";
        }
    }
}