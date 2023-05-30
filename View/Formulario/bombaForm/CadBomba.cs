/* Módulo View BombaForm 
 * Descrição: Cadastro de Bomba de combustivel
 * Autor: Erich Wanderley
 * Data: 20/04/2023
 * Versão: 1.0
 */

 using System;
using System.Drawing;
using System.Windows.Forms;
using ListarProduto;

namespace View.Fomulario.BombaForm
{
    public partial class CadBombaForm : Form
    {
        private Label idLabel;
        private Label capmaxLabel;
        private Label capminLabel;
        private TextBox idTextBox;
        private TextBox capmaxTextBox;
        private TextBox capminTextBox;
        private Button gravarButton;
        private Button sairButton;

        public CadBombaFomr()
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
            idLabel.Text = "ID: ";
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

            // Configurando o Campo de texto de nome do Almoxarifado
            capmaxTextBox = new TextBox();
            capmaxTextBox.Location = new Point(100, 60);
            capmaxTextBox.Size = new Size(150, 20);
            this.Controls.Add(capmaxTextBox);

            // Configurações do botao gravar
            gravarButton = new Button();
            gravarButton.Text = "Gravar";
            gravarButton.Location = new Point(70, 100);
            gravarButton.Size = new Size(80, 30);
            gravarButton.Click += new EventHandler(gravarButton_Click);
            this.Controls.Add(gravarButton);

            // Configurações do botão sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(160, 100);
            sairButton.Size = new Size(80, 30);
            sairButton.Click += new EventHandler(sairButton_Click);
            this.Controls.Add(sairButton);
        }

         private void gravarButton_Click(object sender, EventArgs e)
        {
            // Autenticar usuário

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