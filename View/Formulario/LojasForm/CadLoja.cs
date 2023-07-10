/* Módulo View CadLoja
 * Descrição: cadastro de loja
 * Autor: Erich Wanderley 
 * Data: 22/05/2023
 * Versão: 1.0
 */


 using System;
using System.Drawing;
using System.Windows.Forms;

namespace View.Formulario.LojasForm
{
    public partial class CadLoja : Form
    {
        private Label nomeLabel;
        private Label enderecoLabel;
        private Label telefoneLabel;
        private Label emailLabel;
        private TextBox nomeTextBox;
        private TextBox enderecoTextBox;
        private TextBox telefoneTextBox;
        private TextBox emailTextBox;
        private Button gravarButton;
        private Button sairButton;
        public CadLoja()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            //Configuração da janela do formulário
            this.ClientSize = new System.Drawing.Size(300,400);
            this.Text = "Cadastro de lojas";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = ColorTranslator.FromHtml("#CFCFCF");

            //Configurações do rótulo Nome
            nomeLabel = new Label();
            nomeLabel.Text = "Nome Loja: ";
            nomeLabel.Location = new Point(20, 30);
            nomeLabel.Size = new Size(80, 20);
            this.Controls.Add(nomeLabel);

            //Configurações do campo texto de Nome
            nomeTextBox = new TextBox();
            nomeTextBox.Location = new Point(100, 30);
            nomeTextBox.Size = new Size(150, 20);
            this.Controls.Add(nomeTextBox);

            //Configurações do rótulo Endereço
            enderecoLabel = new Label();
            enderecoLabel.Text = "Endereço: ";
            enderecoLabel.Location = new Point(20, 60);
            enderecoLabel.Size = new Size(80, 20);
            this.Controls.Add(enderecoLabel);

            //Configurações do campo texto de Endereço
            enderecoTextBox = new TextBox();
            enderecoTextBox.Location = new Point(100, 60);
            enderecoTextBox.Size = new Size(150, 20);
            this.Controls.Add(enderecoTextBox);

            //Configurações do rótulo Telefone
            telefoneLabel = new Label();
            telefoneLabel.Text = "Telefone: ";
            telefoneLabel.Location = new Point(20, 90);
            telefoneLabel.Size = new Size(80, 20);
            this.Controls.Add(telefoneLabel);

            //Configurações do campo texto de Telefone
            telefoneTextBox = new TextBox();
            telefoneTextBox.Location = new Point(100, 90);
            telefoneTextBox.Size = new Size(150, 20);
            this.Controls.Add(telefoneTextBox);

            //Configurações do rótulo Email
            emailLabel = new Label();
            emailLabel.Text = "Email: ";
            emailLabel.Location = new Point(20, 120);
            emailLabel.Size = new Size(80, 20);
            this.Controls.Add(emailLabel);

            //Configurações do campo texto de Email
            emailTextBox = new TextBox();
            emailTextBox.Location = new Point(100, 120);
            emailTextBox.Size = new Size(150, 20);
            this.Controls.Add(emailTextBox);

            //Configurações do botao gravar
            gravarButton = new Button();
            gravarButton.Text = "Gravar";
            gravarButton.Location = new Point(70, 100);
            gravarButton.Size = new Size(80, 30);
            gravarButton.Click += new EventHandler(gravarButton_Click);
            gravarButton.BackColor = ColorTranslator.FromHtml("#FFFDE8");
            this.Controls.Add(gravarButton);

            //Configurações do botão sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(160, 100);
            sairButton.Size = new Size(80, 30);
            sairButton.Click += new EventHandler(sairButton_Click);
            sairButton.BackColor = ColorTranslator.FromHtml("#FFFDE8");
            this.Controls.Add(sairButton);

            //Painel para os botões
            Panel panel = new Panel();
            panel.Size = new Size(100, 50);
            panel.BackColor = ColorTranslator.FromHtml("#4056A1");
            panel.Dock = DockStyle.Bottom;
            this.Controls.Add(panel);
        }
         private void gravarButton_Click(object sender, EventArgs e)
        {
            try
            {
                Controller.Loja loja = new Controller.Loja();//Instanciando a classe loja
                loja.nome = nomeTextBox.Text;//Atribuindo o valor do campo texto Nome para a propriedade Nome
                loja.endereco = enderecoTextBox.Text;//Atribuindo o valor do campo texto Endereco para a propriedade Endereco
                loja.telefone = telefoneTextBox.Text;//Atribuindo o valor do campo texto Telefone para a propriedade Telefone
                loja.email = emailTextBox.Text;//Atribuindo o valor do campo texto Email para a propriedade Email
                Controller.Loja.CadastraLoja(loja.nome, loja.endereco, loja.telefone, loja.email);//Chamando o método CadastraLoja da classe Loja
                MessageBox.Show("Loja cadastrada com sucesso!");//Exibindo mensagem de sucesso
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
            enderecoTextBox.Text = "";
            telefoneTextBox.Text = "";
            emailTextBox.Text = "";
        }
    }

//----------------------    Formulário de edição de loja   ----------------------//

    public class FormEditaLoja : Form
    {
        private Label lojaIdLabel;
        private Label nomeLabel;
        private Label enderecoLabel;
        private Label telefoneLabel;
        private Label emailLabel;
        private ComboBox lojaIdCb;
        private TextBox nomeTextBox;
        private TextBox enderecoTextBox;
        private TextBox telefoneTextBox;
        private TextBox emailTextBox;
        private Button gravarButton;
        private Button sairButton;

        public void InitializeComponent()
        {
            //Configuração da janela do formulário
            this.ClientSize = new System.Drawing.Size(300,400);
            this.Text = "Edição de loja";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = ColorTranslator.FromHtml("#CFCFCF");

            //Configurações do id
            lojaIdLabel = new Label();
            lojaIdLabel.Text = "ID loja: ";
            lojaIdLabel.Location = new Point(20, 30);
            lojaIdLabel.Size = new Size(80, 20);
            this.Controls.Add(lojaIdLabel);

            //Configurações do campo texto de id
            lojaIdCb = new ComboBox();
            lojaIdCb.Location = new Point(100, 30);
            lojaIdCb.Size = new Size(150, 20);
            List<Controller.Loja> listaLojas = new  List<Controller.Loja>();
            foreach (Model.Loja loja in Model.Loja.BuscaLoja())
            {
                lojaIdCb.Items.Add(loja);
            }
            lojaIdCb.DisplayMember = "nome";
            lojaIdCb.ValueMember = "lojaId";
            lojaIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(lojaIdCb);

            //Configurações do rótulo Nome
            nomeLabel = new Label();
            nomeLabel.Text = "Nome: ";
            nomeLabel.Location = new Point(20, 60);
            nomeLabel.Size = new Size(80, 20);
            this.Controls.Add(nomeLabel);

            //Configurações do campo texto de Nome
            nomeTextBox = new TextBox();
            nomeTextBox.Location = new Point(100, 60);
            nomeTextBox.Size = new Size(150, 20);
            this.Controls.Add(nomeTextBox);

            //Configurações do rótulo Endereço
            enderecoLabel = new Label();
            enderecoLabel.Text = "Endereço: ";
            enderecoLabel.Location = new Point(20, 90);
            enderecoLabel.Size = new Size(80, 20);
            this.Controls.Add(enderecoLabel);

            //Configurações do campo texto de Endereço
            enderecoTextBox = new TextBox();
            enderecoTextBox.Location = new Point(100, 90);
            enderecoTextBox.Size = new Size(150, 20);
            this.Controls.Add(enderecoTextBox);

            //Configurações do rótulo Telefone
            telefoneLabel = new Label();
            telefoneLabel.Text = "Telefone: ";
            telefoneLabel.Location = new Point(20, 120);
            telefoneLabel.Size = new Size(80, 20);
            this.Controls.Add(telefoneLabel);

            //Configurações do campo texto de Telefone
            telefoneTextBox = new TextBox();
            telefoneTextBox.Location = new Point(100, 120);
            telefoneTextBox.Size = new Size(150, 20);
            this.Controls.Add(telefoneTextBox);

            //Configurações do rótulo Email
            emailLabel = new Label();
            emailLabel.Text = "Email: ";
            emailLabel.Location = new Point(20, 150);
            emailLabel.Size = new Size(80, 20);
            this.Controls.Add(emailLabel);

            //Configurações do campo texto de Email
            emailTextBox = new TextBox();
            emailTextBox.Location = new Point(100, 150);
            emailTextBox.Size = new Size(150, 20);
            this.Controls.Add(emailTextBox);

            //Configurações do botão Gravar
            gravarButton = new Button();
            gravarButton.Text = "Gravar";
            gravarButton.Location = new Point(20, 180);
            gravarButton.Size = new Size(80, 20);
            gravarButton.Click += (ScrollBarRenderer, e) =>{
                SalvaLoja();
                LimpaTela();
            };
            gravarButton.BackColor = ColorTranslator.FromHtml("#FFFDE8");
            this.Controls.Add(gravarButton);

            //Configurações do botão Sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(100, 180);
            sairButton.Size = new Size(80, 20);
            sairButton.Click += (ScrollBarRenderer, e) => this.Close();
            sairButton.BackColor = ColorTranslator.FromHtml("#FFFDE8");
            this.Controls.Add(sairButton);
        }
        
        public FormEditaLoja()
        {
            InitializeComponent();
        }

        public void SalvaLoja()
        {
            try
            {
                Controller.Loja loja = new Controller.Loja();
                var lojaId = (Controller.Loja) lojaIdCb.SelectedItem;
                if (lojaId == null)
                {
                    MessageBox.Show("Selecione uma loja!");
                    return;
                }
                loja.lojaId = lojaId.lojaId;
                loja.nome = nomeTextBox.Text;
                loja.endereco = enderecoTextBox.Text;
                loja.telefone = telefoneTextBox.Text;
                loja.email = emailTextBox.Text;

                Controller.Loja.AlteraLoja(loja.lojaId, loja.nome, loja.endereco, loja.telefone, loja.email);
                MessageBox.Show("loja alterada com sucesso!");
            } catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar loja: " + ex.Message);
            }
        }
        
        public void LimpaTela()
        {
            nomeTextBox.Text = "";
            enderecoTextBox.Text = "";
            telefoneTextBox.Text = "";
            emailTextBox.Text = "";
        }
    }


// -------------- Formulário de exclusão de loja --------------//
    public class FormExcluiLoja : Form
    {
        private Label lojaIdLabel;
        private ComboBox lojaIdCb;
        private Button excluirButton;
        private Button sairButton;

        private void InitializeComponent()
        {
            this.Text = "Excluir loja";
            this.Size = new Size(300, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = ColorTranslator.FromHtml("#CFCFCF");

            //Configurações do rótulo lojaId
            lojaIdLabel = new Label();
            lojaIdLabel.Text = "ID loja: ";
            lojaIdLabel.Location = new Point(20, 30);
            lojaIdLabel.Size = new Size(80, 20);
            this.Controls.Add(lojaIdLabel);

            //Configurações do campo texto de lojaId
            lojaIdCb = new ComboBox();
            lojaIdCb.Location = new Point(100, 30);
            lojaIdCb.Size = new Size(150, 20);
            List<Model.Loja> listaLojas = new  List<Model.Loja>();
            foreach (Model.Loja loja in Model.Loja.BuscaLoja())
            {
                lojaIdCb.Items.Add(loja);
            }
            lojaIdCb.DisplayMember = "nome";
            lojaIdCb.ValueMember = "lojaId";
            lojaIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(lojaIdCb);

            //Configurações do botão Excluir
            excluirButton = new Button();
            excluirButton.Text = "Excluir";
            excluirButton.Location = new Point(20, 60);
            excluirButton.Size = new Size(80, 20);
            excluirButton.Click += (ScrollBarRenderer, e) =>{
                ExcluiLoja();
                LimpaTela();
            };
            excluirButton.BackColor = ColorTranslator.FromHtml("#FFFDE8");
            this.Controls.Add(excluirButton);

            //Configurações do botão Sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(100, 60);
            sairButton.Size = new Size(80, 20);
            sairButton.Click += (ScrollBarRenderer, e) => this.Close();
            sairButton.BackColor = ColorTranslator.FromHtml("#FFFDE8");
            this.Controls.Add(sairButton);

            //Painel para os botões
            Panel panel = new Panel();
            panel.Size = new Size(100, 50);
            panel.BackColor = ColorTranslator.FromHtml("#4056A1");
            panel.Dock = DockStyle.Bottom;
            this.Controls.Add(panel);
        }

        public FormExcluiLoja()
        {
            InitializeComponent();
        }

        public void ExcluiLoja()
        {
            try
            {
                Controller.Loja loja = new Controller.Loja();
                var lojaSelecionada = (Controller.Loja) lojaIdCb.SelectedItem;
                if (lojaSelecionada == null)
                {
                    MessageBox.Show("Selecione uma loja");
                    return;
                }
                loja.lojaId = lojaSelecionada.lojaId.ToString();

                Controller.Loja.ExcluiLoja(loja.lojaId);
                MessageBox.Show("loja excluída com sucesso!");
            } catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir loja: " + ex.Message);
            }
        }

        public void LimpaTela()
        {
            lojaIdCb.Text = "";
        }
    }
}