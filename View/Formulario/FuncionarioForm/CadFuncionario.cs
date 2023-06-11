/* Módulo View CadFuncionario
 * Descrição: cadastro de funcionario
 * Autor: Erich Wanderley 
 * Data: 22/05/2023
 * Versão: 1.0
 */

 using System;
using System.Drawing;
using System.Windows.Forms;

namespace View.Formulario.FuncionarioForm
{
    public partial class CadFuncionario : Form
    {
        private Label funcionarioIdLabel;
        private Label nomeLabel;
        private Label senhaLabel;
        private Label funcaoLabel;
        private Label lojaIdLabel;
        private Label emailLabel;
        private TextBox nomeTextBox;
        private TextBox senhaTextBox;
        private TextBox funcaoTextBox;
        private TextBox emailTextBox;
        private ComboBox lojaIdCb;
        private Button gravarButton;
        private Button sairButton;
        public CadFuncionario()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            //Configuração da janela do formulário
            this.ClientSize = new System.Drawing.Size(300,400);
            this.Text = "Cadastro de funcionarios";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            //Configurações do Nome
            nomeLabel = new Label();
            nomeLabel.Text = "Nome do Funcionário: ";
            nomeLabel.Location = new Point(20, 30);
            nomeLabel.Size = new Size(80, 20);
            this.Controls.Add(nomeLabel);

            //Configurações do campo texto do Nome
            nomeTextBox = new TextBox();
            nomeTextBox.Location = new Point(100, 30);
            nomeTextBox.Size = new Size(150, 20);
            this.Controls.Add(nomeTextBox);

            //Configurações do senha
            senhaLabel = new Label();
            senhaLabel.Text = "Senha: ";
            senhaLabel.Location = new Point(20, 60);
            senhaLabel.Size = new Size(80, 20);
            this.Controls.Add(senhaLabel);

            //Configurações do campo texto do senha
            senhaTextBox = new TextBox();
            senhaTextBox.Location = new Point(100, 60);
            senhaTextBox.Size = new Size(150, 20);
            this.Controls.Add(senhaTextBox);

            //Configurações do funcao
            funcaoLabel = new Label();
            funcaoLabel.Text = "Função: ";
            funcaoLabel.Location = new Point(20, 90);
            funcaoLabel.Size = new Size(80, 20);
            this.Controls.Add(funcaoLabel);

            //Configurações do campo texto do funcao
            funcaoTextBox = new TextBox();
            funcaoTextBox.Location = new Point(100, 90);
            funcaoTextBox.Size = new Size(150, 20);
            this.Controls.Add(funcaoTextBox);

            //Configurações do lojaId
            lojaIdLabel = new Label();
            lojaIdLabel.Text = "Loja: ";
            lojaIdLabel.Location = new Point(20, 120);
            lojaIdLabel.Size = new Size(80, 20);
            this.Controls.Add(lojaIdLabel);

            //Configurações do campo texto do lojaId
            lojaIdCb = new ComboBox();
            lojaIdCb.Location = new Point(100, 120);
            lojaIdCb.Size = new Size(150, 20);
            this.Controls.Add(lojaIdCb);

            //Configurações do email
            emailLabel = new Label();
            emailLabel.Text = "Email: ";
            emailLabel.Location = new Point(20, 150);
            emailLabel.Size = new Size(80, 20);
            this.Controls.Add(emailLabel);

            //Configurações do campo texto do email
            emailTextBox = new TextBox();
            emailTextBox.Location = new Point(100, 150);
            emailTextBox.Size = new Size(150, 20);
            this.Controls.Add(emailTextBox);

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
                Controller.Funcionario funcionario = new Controller.Funcionario();//Instanciando a classe funcionario
                funcionario.nome = nomeTextBox.Text;//Atribuindo o valor do campo nome para a propriedade nome
                funcionario.senha = senhaTextBox.Text;//Atribuindo o valor do campo senha para a propriedade senha
                funcionario.funcao = funcaoTextBox.Text;//Atribuindo o valor do campo funcao para a propriedade funcao
                funcionario.lojaId = lojaIdCb.Text;//Atribuindo o valor do campo lojaId para a propriedade lojaId
                funcionario.email = emailTextBox.Text;//Atribuindo o valor do campo email para a propriedade email
                Controller.Funcionario.CadastraFuncionario(funcionario.nome, funcionario.senha, funcionario.funcao, funcionario.lojaId, funcionario.email);//Chamando o método CadastraFuncionario e passando os valores como parâmetro
                MessageBox.Show("Funcionário cadastrado com sucesso!");//Exibindo mensagem de sucesso
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
            nomeTextBox.Text = "";
            senhaTextBox.Text = "";
            funcaoTextBox.Text = "";
            lojaIdCb.Text = "";
            emailTextBox.Text = "";
        }
    }

//------------------------------------------------------------

    public class FormEditaFuncionario : Form
    {
        private Label funcionarioIdLabel;
        private Label nomeLabel;
        private Label senhaLabel;
        private Label funcaoLabel;
        private Label lojaIdLabel;
        private Label emailLabel;
        private TextBox nomeTextBox;
        private TextBox senhaTextBox;
        private TextBox funcaoTextBox;
        private TextBox emailTextBox;
        private ComboBox funcionarioIdCb;
        private ComboBox lojaIdCb;
        private Button gravarButton;
        private Button sairButton;

        public void InitializeComponent()
        {
            //Configuração da janela do formulário
            this.ClientSize = new System.Drawing.Size(300,400);
            this.Text = "Edição de funcionario";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            //Configurações do id
            funcionarioIdLabel = new Label();
            funcionarioIdLabel.Text = "ID funcionario: ";
            funcionarioIdLabel.Location = new Point(20, 30);
            funcionarioIdLabel.Size = new Size(80, 20);
            this.Controls.Add(funcionarioIdLabel);

            //Configurações do campo texto de id
            funcionarioIdCb = new ComboBox();
            funcionarioIdCb.Location = new Point(100, 30);
            funcionarioIdCb.Size = new Size(150, 20);
            List<Controller.Funcionario> listaFuncionarios = new  List<Controller.Funcionario>();
            foreach (Model.Funcionario funcionario in Model.Funcionario.BuscaFuncionario())
            {
                funcionarioIdCb.Items.Add(funcionario);
            }
            funcionarioIdCb.DisplayMember = "nome";
            funcionarioIdCb.ValueMember = "funcionarioId";
            funcionarioIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(funcionarioIdCb);

            //Configurações da lojaId
            lojaIdLabel = new Label();
            lojaIdLabel.Text = "Loja: ";
            lojaIdLabel.Location = new Point(20, 60);
            lojaIdLabel.Size = new Size(80, 20);
            List<Controller.Loja> listaLoja = new  List<Controller.Loja>();
            foreach (Model.Loja loja in Model.Loja.BuscaLoja())
            {
                lojaIdCb.Items.Add(listaLoja);
            }
            lojaIdCb.DisplayMember = "nome";
            lojaIdCb.ValueMember = "lojaId";
            lojaIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(lojaIdLabel);

            //Configurações do campo texto de tipoCombustivelId
            lojaIdCb = new ComboBox();
            lojaIdCb.Location = new Point(100, 60);
            lojaIdCb.Size = new Size(150, 20);
            this.Controls.Add(lojaIdCb);

            //Configurações de rótulo do campo nome
            nomeLabel = new Label();
            nomeLabel.Text = "Nome: ";
            nomeLabel.Location = new Point(20, 90);
            nomeLabel.Size = new Size(80, 20);
            this.Controls.Add(nomeLabel);

            //Configurações do campo texto de nome
            nomeTextBox = new TextBox();
            nomeTextBox.Location = new Point(100, 90);
            nomeTextBox.Size = new Size(150, 20);
            this.Controls.Add(nomeTextBox);

            //Configurações de rótulo do campo senha
            senhaLabel = new Label();
            senhaLabel.Text = "Senha: ";
            senhaLabel.Location = new Point(20, 120);
            senhaLabel.Size = new Size(80, 20);
            this.Controls.Add(senhaLabel);

            //Configurações do campo texto de senha
            senhaTextBox = new TextBox();
            senhaTextBox.Location = new Point(100, 120);
            senhaTextBox.Size = new Size(150, 20);
            this.Controls.Add(senhaTextBox);

            //Configurações de rótulo do campo funcao
            funcaoLabel = new Label();
            funcaoLabel.Text = "Função: ";
            funcaoLabel.Location = new Point(20, 150);
            funcaoLabel.Size = new Size(80, 20);
            this.Controls.Add(funcaoLabel);

            //Configurações do campo texto de funcao
            funcaoTextBox = new TextBox();
            funcaoTextBox.Location = new Point(100, 150);
            funcaoTextBox.Size = new Size(150, 20);
            this.Controls.Add(funcaoTextBox);

            //Configurações de rótulo do campo email
            emailLabel = new Label();
            emailLabel.Text = "Email: ";
            emailLabel.Location = new Point(20, 180);
            emailLabel.Size = new Size(80, 20);
            this.Controls.Add(emailLabel);

            //Configurações do campo texto de email
            emailTextBox = new TextBox();
            emailTextBox.Location = new Point(100, 180);
            emailTextBox.Size = new Size(150, 20);
            this.Controls.Add(emailTextBox);

            //Configurações do botão Gravar
            gravarButton = new Button();
            gravarButton.Text = "Gravar";
            gravarButton.Location = new Point(20, 180);
            gravarButton.Size = new Size(80, 20);
            gravarButton.Click += (ScrollBarRenderer, e) =>{
                salvaFuncionario();
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
        
        public FormEditaFuncionario()
        {
            InitializeComponent();
        }

        public void salvaFuncionario()
        {
            try
            {
                Controller.Funcionario funcionario = new Controller.Funcionario();
                var funcionarioSelecionada = (Controller.Funcionario) funcionarioIdCb.SelectedItem;
                if (funcionarioSelecionada == null)
                {
                    MessageBox.Show("Selecione um funcionario");
                    return;
                }
                funcionario.funcionarioId = funcionarioSelecionada.funcionarioId.ToString();
                funcionario.nome = nomeTextBox.Text;
                funcionario.senha = senhaTextBox.Text;
                funcionario.funcao = funcaoTextBox.Text;
                funcionario.email = emailTextBox.Text;

                Controller.Funcionario.AlteraFuncionario(funcionario.funcionarioId, funcionario.nome, funcionario.senha, funcionario.funcao, funcionario.lojaId, funcionario.email);
                MessageBox.Show("funcionario alterado com sucesso!");
            } catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar funcionario: " + ex.Message);
            }
        }
        
        public void LimpaTela()
        {
            nomeTextBox.Text = "";
            senhaTextBox.Text = "";
            funcaoTextBox.Text = "";
            emailTextBox.Text = "";
        }
    }



    public class FormExcluiFuncionario : Form
    {
        private Label funcionarioIdLabel;
        private ComboBox funcionarioIdCb;
        private Button excluirButton;
        private Button sairButton;

        private void InitializeComponent()
        {
            this.Text = "Excluir funcionario";
            this.Size = new Size(300, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            //Configurações do rótulo funcionarioId
            funcionarioIdLabel = new Label();
            funcionarioIdLabel.Text = "ID funcionario: ";
            funcionarioIdLabel.Location = new Point(20, 30);
            funcionarioIdLabel.Size = new Size(80, 20);
            this.Controls.Add(funcionarioIdLabel);

            //Configurações do campo texto de funcionarioId
            funcionarioIdCb = new ComboBox();
            funcionarioIdCb.Location = new Point(100, 30);
            funcionarioIdCb.Size = new Size(150, 20);
            List<Controller.Funcionario> listaFuncionarios = new  List<Controller.Funcionario>();
            foreach (Model.Funcionario funcionario in Model.Funcionario.BuscaFuncionario())
            {
                funcionarioIdCb.Items.Add(funcionario);
            }
            funcionarioIdCb.DisplayMember = "nome";
            funcionarioIdCb.ValueMember = "funcionarioId";
            funcionarioIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(funcionarioIdCb);

            //Configurações do botão Excluir
            excluirButton = new Button();
            excluirButton.Text = "Excluir";
            excluirButton.Location = new Point(20, 60);
            excluirButton.Size = new Size(80, 20);
            excluirButton.Click += (ScrollBarRenderer, e) =>{
                ExcluiFuncionario();
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

        public FormExcluiFuncionario()
        {
            InitializeComponent();
        }

        public void ExcluiFuncionario()
        {
            try
            {
                Controller.Funcionario funcionario = new Controller.Funcionario();
                var funcionarioSelecionada = (Controller.Funcionario) funcionarioIdCb.SelectedItem;
                if (funcionarioSelecionada == null)
                {
                    MessageBox.Show("Selecione uma funcionario");
                    return;
                }
                funcionario.funcionarioId = funcionarioSelecionada.funcionarioId.ToString();

                Controller.Funcionario.ExcluiFuncionario(funcionario.funcionarioId);
                MessageBox.Show("funcionario excluída com sucesso!");
            } catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir funcionario: " + ex.Message);
            }
        }

        public void LimpaTela()
        {
            funcionarioIdCb.Text = "";
        }
    }
}