/* Módulo View de Login
 * Descrição: Login
 * Autor: Jussan Igor da Silva 
 * Data: 11/06/2023
 * Versão: 1.0
 */



namespace View.Formulario.Login
{
    public class Login : Form
    {
        public Label loginLabel;
        public Label senhaLabel;
        public TextBox loginTextBox; // usar esse
        public TextBox senhaTextBox;
        public Button entrarButton;
        public Button sairButton;

        public Login()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            //Configurações do PictureBox
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile(@"imagens\login1_img.png");
            //@"C:\\img\\login_img.png"
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Location = new Point(100, 0);
            pictureBox.Size = new Size(90, 74);
            this.Controls.Add(pictureBox);
            

            // Configurações da janela do formulário
            //this.ClientSize = new System.Drawing.Size(270, 140);
            this.ClientSize = new System.Drawing.Size(270, 185);
            this.Text = "Login";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Configurações do label de E-mail
            loginLabel = new Label();
            loginLabel.Text = "E-mail:";
            loginLabel.Location = new Point(10, 85);
            loginLabel.AutoSize = true;
            this.Controls.Add(loginLabel);

            // Configurações do label de senha
            senhaLabel = new Label();
            senhaLabel.Text = "Senha:";
            senhaLabel.Location = new Point(10, 110);
            senhaLabel.AutoSize = true;
            this.Controls.Add(senhaLabel);

            // Configurações do textbox de login
            loginTextBox = new TextBox();
            loginTextBox.Location = new Point(60, 80);
            loginTextBox.Size = new Size(200, 20);
            this.Controls.Add(loginTextBox);

            // Configurações do textbox de senha
            senhaTextBox = new TextBox();
            senhaTextBox.Location = new Point(60, 110);
            senhaTextBox.Size = new Size(200, 20);
            senhaTextBox.PasswordChar = '*';
            this.Controls.Add(senhaTextBox);

            // Configurações do botão de entrar
            entrarButton = new Button();
            entrarButton.Text = "Entrar";
            entrarButton.Location = new Point(100, 140);
            entrarButton.Size = new Size(80, 30);
            entrarButton.Click += new EventHandler(EntrarButton_Click);
            this.Controls.Add(entrarButton);

            // Configurações do botão de sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(180, 140);
            sairButton.Size = new Size(80, 30);
            sairButton.Click += new EventHandler(SairButton_Click);
            this.Controls.Add(sairButton);
            // Manipulador de evento para a tecla "ESC"
            this.KeyDown += new KeyEventHandler(Form_KeyDown);
        }

        private bool admin = false;
        public void EntrarButton_Click(object sender, EventArgs e)
        {
            
            Controller.Funcionario funcionario = new Controller.Funcionario();
            funcionario.email = loginTextBox.Text;
            Controller.Funcionario.BuscaFuncionarioPorEmail(funcionario.email);
            if (funcionario.email == null || funcionario.email == "") throw new Exception("E-mail não cadastrado! Login Incorreto!");
            funcionario.senha = senhaTextBox.Text;
            if (Controller.Funcionario.Logar(funcionario.email, funcionario.senha))
            {
                MessageBox.Show("Login efetuado com sucesso!");
                this.Hide();
                funcionarioPorEmail(funcionario.email);
                if (admin)
                {
                    AbrirForm(new View.ProgramForm());
                } else {
                    AbrirForm(new View.ProgramUserForm());
                }
                
            }
            else
            {
                MessageBox.Show("Senha incorreta!");
                LimpaTela();
            }
        }
        public void SairButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Form_KeyDown(object sender, KeyEventArgs e)
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

        public void funcionarioPorEmail(string email)
        {
            Model.Funcionario funcionario = Controller.Funcionario.BuscaFuncionarioPorEmail(email);
            if (funcionario != null)
            {
                admin = funcionario.funcao.Equals("Admin");
            }
        }

        public void AbrirForm(Form form){
            form.ShowDialog();
        }
    }
}