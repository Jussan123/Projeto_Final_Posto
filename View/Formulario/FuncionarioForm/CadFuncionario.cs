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
        private ComboBox funcaoComboBox;
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
            this.ClientSize = new System.Drawing.Size(300, 220);
            this.Text = "Cadastro de funcionarios";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            //Configurações do Nome
            nomeLabel = new Label();
            nomeLabel.Text = "Nome:";
            nomeLabel.Location = new Point(16, 35);
            nomeLabel.Size = new Size(80, 20);
            this.Controls.Add(nomeLabel);

            //Configurações do campo texto do Nome
            nomeTextBox = new TextBox();
            nomeTextBox.Location = new Point(60, 30);
            nomeTextBox.Size = new Size(150, 20);
            this.Controls.Add(nomeTextBox);

            //Configurações do senha
            senhaLabel = new Label();
            senhaLabel.Text = "Senha:";
            senhaLabel.Location = new Point(16, 65);
            senhaLabel.Size = new Size(80, 20);
            this.Controls.Add(senhaLabel);

            //Configurações do campo texto do senha
            senhaTextBox = new TextBox();
            senhaTextBox.Location = new Point(60, 60);
            senhaTextBox.Size = new Size(150, 20);
            this.Controls.Add(senhaTextBox);

            //Configurações do funcao
            funcaoLabel = new Label();
            funcaoLabel.Text = "Função:";
            funcaoLabel.Location = new Point(10, 95);
            funcaoLabel.Size = new Size(80, 20);
            this.Controls.Add(funcaoLabel);

            //Configurações do campo texto do funcao
            funcaoComboBox = new ComboBox();
            funcaoComboBox.Location = new Point(60, 90);
            funcaoComboBox.Size = new Size(150, 20);
            string [] funcao = {"Admin", "User"};
            funcaoComboBox.Items.AddRange(funcao);
            funcaoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(funcaoComboBox);

            //Configurações do lojaId
            lojaIdLabel = new Label();
            lojaIdLabel.Text = "Loja:";
            lojaIdLabel.Location = new Point(25, 125);
            lojaIdLabel.Size = new Size(80, 20);
            this.Controls.Add(lojaIdLabel);

            //Configurações do campo texto do lojaId
            lojaIdCb = new ComboBox();
            lojaIdCb.Location = new Point(60, 120);
            lojaIdCb.Size = new Size(150, 20);
            List<Model.Loja> listaLoja = new List<Model.Loja>();
            foreach (Model.Loja loja in Controller.Loja.ListaLojas())
            {
                lojaIdCb.Items.Add(loja);
            }
            lojaIdCb.DisplayMember = "nome";
            lojaIdCb.ValueMember = "lojaId";
            lojaIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(lojaIdCb);

            //Configurações do email
            emailLabel = new Label();
            emailLabel.Text = "Email:";
            emailLabel.Location = new Point(19, 155);
            emailLabel.Size = new Size(80, 20);
            this.Controls.Add(emailLabel);

            //Configurações do campo texto do email
            emailTextBox = new TextBox();
            emailTextBox.Location = new Point(60, 150);
            emailTextBox.Size = new Size(150, 20);
            this.Controls.Add(emailTextBox);
            
            //Configurações do botao gravar
            gravarButton = new Button();
            gravarButton.Text = "Gravar";
            gravarButton.Location = new Point(40, 180);
            gravarButton.Size = new Size(80, 30);
            gravarButton.Click += new EventHandler(gravarButton_Click);
            this.Controls.Add(gravarButton);

            //Configurações do botão sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(120, 180);
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
                funcionario.funcao = funcaoComboBox.Text;//Atribuindo o valor do campo funcao para a propriedade funcao
                var lojaSelecionada = ((Model.Loja)lojaIdCb.SelectedItem).lojaId.ToString();
                //var lojaSelecionada = (Model.Loja) lojaIdCb.SelectedItem;
                if (lojaSelecionada == null)
                {
                    MessageBox.Show("Selecione uma loja");
                    return;
                }
                funcionario.lojaId = lojaSelecionada.ToString();
                if (funcionario.lojaId == null) throw new Exception("Loja não encontrada" + funcionario.lojaId);
                funcionario.email = emailTextBox.Text;//Atribuindo o valor do campo email para a propriedade email
                Controller.Funcionario.CadastraFuncionario(funcionario.nome, funcionario.senha, funcionario.funcao, Convert.ToInt32(funcionario.lojaId), funcionario.email);//Chamando o método CadastraFuncionario e passando os valores como parâmetro
                MessageBox.Show("Funcionário cadastrado com sucesso!");//Exibindo mensagem de sucesso
                LimpaTela();//Chamando o método LimpaTela
    
            }
            catch (Exception ex)//Tratamento de exceção
            {
                MessageBox.Show("Erro ao Cadastrar funcionário: " + ex.Message);
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
            funcaoComboBox.Text = "";
            lojaIdCb.Text = "";
            emailTextBox.Text = "";
        }
    
    }

//----------------------- Formulário de Edição de Funcionário -------------------------------------

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
        private TextBox emailTextBox;
        private ComboBox funcaoComboBox;
        private ComboBox funcionarioIdCb;
        private ComboBox lojaIdCb;
        private Button gravarButton;
        private Button sairButton;

        public void InitializeComponent()
        {
            //Configuração da janela do formulário
            this.ClientSize = new System.Drawing.Size(300, 400);
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
            List<Model.Funcionario> listaFuncionarios = new List<Model.Funcionario>();
            foreach (Model.Funcionario funcionario in Controller.Funcionario.ListaFuncionario())
            {
                funcionarioIdCb.Items.Add(funcionario);
            }
            funcionarioIdCb.ValueMember = "funcionarioId";
            funcionarioIdCb.DisplayMember = "nome";
            funcionarioIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(funcionarioIdCb);

            //Configurações da lojaId
            lojaIdLabel = new Label();
            lojaIdLabel.Text = "Loja: ";
            lojaIdLabel.Location = new Point(20, 60);
            lojaIdLabel.Size = new Size(80, 20);
            this.Controls.Add(lojaIdLabel);

            //Configurações do campo texto de tipoCombustivelId
            lojaIdCb = new ComboBox();
            lojaIdCb.Location = new Point(100, 60);
            lojaIdCb.Size = new Size(150, 20);
            List<Model.Loja> listaLojas = new List<Model.Loja>();
            foreach (Model.Loja loja in Controller.Loja.ListaLojas())
            {
                lojaIdCb.Items.Add(loja);
            }
            lojaIdCb.DisplayMember = "nome";
            lojaIdCb.ValueMember = "lojaId";
            lojaIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
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
            funcaoComboBox = new ComboBox();
            funcaoComboBox.Location = new Point(100, 150);
            funcaoComboBox.Size = new Size(150, 20);
            string [] funcao = {"Admin", "User"};
            funcaoComboBox.Items.AddRange(funcao);
            funcaoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(funcaoComboBox);

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
            gravarButton.Location = new Point(20, 220);
            gravarButton.Size = new Size(80, 20);
            gravarButton.Click += (ScrollBarRenderer, e) =>
            {
                salvaFuncionario();
                LimpaTela();
            };
            this.Controls.Add(gravarButton);

            //Configurações do botão Sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(100, 220);
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
                var funcionarioSelecionado = ((Model.Funcionario)funcionarioIdCb.SelectedItem).funcionarioId.ToString();
                if (funcionarioSelecionado == null)
                {
                    MessageBox.Show("Selecione um funcionário");
                    return;
                }
                var lojaSelecionada = ((Model.Loja)lojaIdCb.SelectedItem).lojaId.ToString();
                //var lojaSelecionada = (Model.Loja) lojaIdCb.SelectedItem;
                if (lojaSelecionada == null)
                {
                    MessageBox.Show("Selecione uma loja");
                    return;
                }
                funcionario.funcionarioId = funcionarioSelecionado.ToString();
                if (funcionario.funcionarioId == null) throw new Exception("Funcionário não encontrado" + funcionario.funcionarioId);
                funcionario.nome = nomeTextBox.Text;
                if (funcionario.nome == null) throw new Exception("Nome não encontrado" + funcionario.nome);
                funcionario.senha = senhaTextBox.Text;
                if (funcionario.senha == null) throw new Exception("Senha não encontrada" + funcionario.senha);
                funcionario.funcao = funcaoComboBox.Text;
                if (funcionario.funcao == null) throw new Exception("Função não encontrada" + funcionario.funcao);
                funcionario.email = emailTextBox.Text;
                if (funcionario.email == null) throw new Exception("Email não encontrado" + funcionario.email);
                funcionario.lojaId = lojaSelecionada.ToString();
                if (funcionario.lojaId == null) throw new Exception("Loja não encontrada" + funcionario.lojaId);
                //Controller.Funcionario funcionarioController = new Controller.Funcionario();
                Controller.Funcionario.AlteraFuncionario(funcionario.funcionarioId, funcionario.nome, funcionario.senha, funcionario.funcao, funcionario.lojaId, funcionario.email);
                MessageBox.Show("Funcionário alterado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar funcionário: " + ex.Message);
            }
        }

        public void LimpaTela()
        {
            nomeTextBox.Text = "";
            senhaTextBox.Text = "";
            funcaoComboBox.Text = "";
            emailTextBox.Text = "";
        }
    }

// ------------------------ EXCLUI FUNCIONARIO ------------------------

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
            List<Controller.Funcionario> listaFuncionarios = new List<Controller.Funcionario>();
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
            excluirButton.Click += (ScrollBarRenderer, e) =>
            {
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
                var funcionarioSelecionado = ((Model.Funcionario)funcionarioIdCb.SelectedItem).funcionarioId.ToString();
                if (funcionarioSelecionado == null)
                {
                    MessageBox.Show("Selecione uma funcionario");
                    return;
                }
                funcionario.funcionarioId = funcionarioSelecionado.ToString();

                Controller.Funcionario.ExcluiFuncionario(funcionario.funcionarioId);
                MessageBox.Show("funcionario excluída com sucesso!");
            }
            catch (Exception ex)
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