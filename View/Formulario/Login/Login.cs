/* Módulo View de Login
 * Descrição: Login
 * Autor: Jussan Igor da Silva 
 * Data: 11/06/2023
 * Versão: 1.0
 */

 namespace View.Formulario.Login
 {
    internal class Login : Form
    {
        private Label loginLabel;
        private Label senhaLabel;
        private TextBox loginTextBox;
        private TextBox senhaTextBox;
        private Button entrarButton;
        private Button sairButton;

        public Login()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Configurações da janela do formulário
            this.ClientSize = new System.Drawing.Size(300, 140);
            this.Text = "Login";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Configurações do label de E-mail
            loginLabel = new Label();
            loginLabel.Text = "E-mail:";
            loginLabel.Location = new Point(10, 25);
            loginLabel.AutoSize = true;
            this.Controls.Add(loginLabel);

            // Configurações do label de senha
            senhaLabel = new Label();
            senhaLabel.Text = "Senha:";
            senhaLabel.Location = new Point(10, 55);
            senhaLabel.AutoSize = true;
            this.Controls.Add(senhaLabel);

            // Configurações do textbox de login
            loginTextBox = new TextBox();
            loginTextBox.Location = new Point(80, 20);
            loginTextBox.Size = new Size(200, 20);
            this.Controls.Add(loginTextBox);

            // Configurações do textbox de senha
            senhaTextBox = new TextBox();
            senhaTextBox.Location = new Point(80, 50);
            senhaTextBox.Size = new Size(200, 20);
            senhaTextBox.PasswordChar = '*';
            this.Controls.Add(senhaTextBox);

            // Configurações do botão de entrar
            entrarButton = new Button();
            entrarButton.Text = "Entrar";
            entrarButton.Location = new Point(130, 100);
            entrarButton.Size = new Size(80, 30);
            entrarButton.Click += new EventHandler(EntrarButton_Click);
            this.Controls.Add(entrarButton);

            // Configurações do botão de sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(210, 100);
            sairButton.Size = new Size(80, 30);
            sairButton.Click += new EventHandler(SairButton_Click);
            this.Controls.Add(sairButton);
            // Manipulador de evento para a tecla "ESC"
            this.KeyDown += new KeyEventHandler(Form_KeyDown);
        }

        private void EntrarButton_Click(object sender, EventArgs e)
        {
            Controller.Funcionario funcionario = new Controller.Funcionario();
            funcionario.email = loginTextBox.Text;
            funcionario.senha = senhaTextBox.Text;
            if (Controller.Funcionario.Logar(funcionario.email, funcionario.senha))
            {
                MessageBox.Show("Login efetuado com sucesso!");
                this.Hide();
                View.Formulario.bombaForm.ListBomba listBomba = new View.Formulario.bombaForm.ListBomba();
                listBomba.ShowDialog();
            }
            else
            {
                MessageBox.Show("Login ou senha incorretos!");
                LimpaTela();
            }
        }

        private void SairButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        public void LimpaTela()
        {
            loginTextBox.Text = "";
            senhaTextBox.Text = "";
        }
    }
 }