/* Módulo View CadFuncionario
 * Descrição: cadastro de funcionario
 * Autor: Erich Wanderley 
 * Data: 22/05/2023
 * Versão: 1.0
 */

 using System;
using System.Drawing;
using System.Windows.Forms;

namespace View.Fomulario.FuncionarioForm
{
    public partial class CadFuncionario : Form
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
                Controller.Funcionario funcionario = new Controller.Funcionario();//Instanciando a classe funcionario
                funcionario.tipoCombustivelId = tipoCombustivelIdTextBox.Text;//Atribuindo o valor do campo id ao atributo tipoCombustivelId
                if (funcionario.tipoCombustivelId == null)  throw new Exception("O campo ID não pode ser vazio!");//Verificando se o campo id está vazio
                funcionario.limiteMaximo = limiteMaximoTextBox.Text;//Atribuindo o valor do campo limiteMaximo ao atributo limiteMaximo
                funcionario.limiteMinimo = limiteMinimoTextBox.Text;//Atribuindo o valor do campo limiteMinimo ao atributo limiteMinimo
                Controller.Funcionario.CadastrarFuncionario(funcionario.tipoCombustivelId, funcionario.limiteMaximo, funcionario.limiteMinimo, funcionario.nomeCombustivel);//Chamando o método Cadastrarfuncionario da classe funcionario
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

    public class FormEditaFuncionario : Form
    {
        private Label funcionarioIdLabel;
        private Label tipoCombustivelIdLabel;
        private Label limiteMaximoLabel;
        private Label limiteMinimoLabel;
        private Label nomeCombustivelLabel;
        private ComboBox funcionarioIdCb;
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
            List<Model.Funcionario> listaFuncionarios = new  List<Model.Funcionario>();
            foreach (Model.Funcionario funcionario in Model.Funcionario.BuscaFuncionario())
            {
                funcionarioIdCb.Items.Add(funcionario);
            }
            funcionarioIdCb.DisplayMember = "Id";
            funcionarioIdCb.ValueMember = "Id";
            funcionarioIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(funcionarioIdCb);

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
                SalvaFuncionario();
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

        public void Salvafuncionario()
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
                funcionario.tipoCombustivelId = tipoCombustivelIdCb.Text;
                funcionario.limiteMaximo = limiteMaximoTextBox.Text;
                funcionario.limiteMinimo = limiteMinimoTextBox.Text;
                funcionario.nomeCombustivel = nomeCombustivelTextBox.Text;

                Controller.Funcionario controllerFuncionario = new Controller.Funcionario();
                Controller.Funcionario.AlterarFuncionario(funcionario.funcionarioId, funcionario.tipoCombustivelId, funcionario.limiteMaximo, funcionario.limiteMinimo, funcionario.nomeCombustivel);
                MessageBox.Show("funcionario alterada com sucesso!");
            } catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar funcionario: " + ex.Message);
            }
        }
        
        public void LimpaTela()
        {
            funcionarioIdCb.Text = "";
            tipoCombustivelIdCb.Text = "";
            limiteMaximoTextBox.Text = "";
            limiteMinimoTextBox.Text = "";
            nomeCombustivelTextBox.Text = "";
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
            List<Model.Funcionario> listaFuncionarios = new  List<Model.Funcionario>();
            foreach (Model.Funcionario funcionario in Model.Funcionario.BuscaFuncionario())
            {
                funcionarioIdCb.Items.Add(funcionario);
            }
            funcionarioIdCb.DisplayMember = "Id";
            funcionarioIdCb.ValueMember = "Id";
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

                funcionario.DeletaFuncionario(funcionario.funcionarioId);
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