/* Módulo View CadCombustivel
 * Descrição: Cadastro de combustivel
 * Autor: Erich Wanderley 
 * Data: 22/05/2023
 * Versão: 1.0
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace View.Fomulario.CadCombustivel
{
    public partial class CadCombustivel : Form
    {
        private Label idLabel;
        private Label tcombidLabel;
        private Label tcombLabel;
        private Label qtdecombLabel;
        private Label precombLabel;
        private TextBox idTextBox;
        private TextBox tcombidTextBox;
        private TextBox tcombTextBox;
        private TextBox qtdecomTextBox;
        private TextBox precobombTextBox;
        private Button gravarButton;
        private Button sairButton;

        public CadCombustivelFomr()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            //Configuração da janela do formulário
            this.ClientSize = new System.Drawing.Size(300, 400);
            this.Text = "Cadastro de Combustíveis";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            //Configurações do ID - idLabel
            idLabel = new Label();
            idLabel.Text = "ID: ";
            idLabel.Location = new Point(20, 30);
            idLabel.Size = new Size(80, 20);
            this.Controls.Add(idLabel);

            //Configurações do campo texto de ID - idTextBox
            idTextBox = new TextBox();
            idTextBox.Location = new Point(100, 30);
            idTextBox.Size = new Size(150, 20);
            this.Controls.Add(idTextBox);


            //Configurações do Tipo Combustivel ID - tcombidLabel
            tcombidLabel = new Label();
            tcombidLabel.Text = "Tipo ID: ";
            tcombidLabel.Location = new Point(20, 30);
            tcombidLabel.Size = new Size(80, 20);
            this.Controls.Add(tcombidLabel);

            //Configurações do campo texto de Tipo Combustivel ID - tcombidTextBox
            tcombidTextBox = new TextBox();
            tcombidTextBox.Location = new Point(100, 30);
            tcombidTextBox.Size = new Size(150, 20);
            this.Controls.Add(tcombidTextBox);


            //Configurações de rótulo Capacidade Máxima - tcombLabel
            tcombLabel = new Label();
            tcombLabel.Text = "Tipo de Combustível: ";
            tcombLabel.Location = new Point(20, 60);
            tcombLabel.Size = new Size(80, 20);
            this.Controls.Add(tcombLabel);

            //Configurando o Campo de texto Capacidade Máxima - tcombTextBox
            tcombTextBox = new TextBox();
            tcombTextBox.Location = new Point(100, 60);
            tcombTextBox.Size = new Size(150, 20);
            this.Controls.Add(tcombTextBox);

            //Configurações de rótulo -- qtdecombLabel
            qtdecombLabel = new Label();
            qtdecombLabel.Text = "Quantidade: ";
            qtdecombLabel.Location = new Point(20, 60);
            qtdecombLabel.Size = new Size(80, 20);
            this.Controls.Add(qtdecombLabel);

            //Configurando o Campo de texto -- qtdecomTextBox
            qtdecomTextBox = new TextBox();
            qtdecomTextBox.Location = new Point(100, 60);
            qtdecomTextBox.Size = new Size(160, 30);
            this.Controls.Add(qtdecomTextBox);

            //Configurações de rótulo -- 
            qtdecombLabel = new Label();
            qtdecombLabel.Text = "Cap. Miníma: ";
            qtdecombLabel.Location = new Point(20, 60);
            qtdecombLabel.Size = new Size(80, 20);
            this.Controls.Add(qtdecombLabel);

            //Configurando o Campo de texto -- 
            qtdecomTextBox = new TextBox();
            qtdecomTextBox.Location = new Point(100, 60);
            qtdecomTextBox.Size = new Size(160, 30);
            this.Controls.Add(qtdecomTextBox);





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

            MessageBox.Show("Criar a função de Gravar!");
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
    }
}