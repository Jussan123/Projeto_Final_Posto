/* Módulo View CadFornecedor
 * Descrição: cadastro de fornecedor
 * Autor: Erich Wanderley 
 * Data: 22/05/2023
 * Versão: 1.0
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace View.Formulario.FornecedorForm
{
    public partial class CadFornecedor : Form
    {
        private Label fornecedorIdLabel;
        private Label nomeLabel;
        private Label contatoLabel;
        private Label enderecoLabel;
        private TextBox nomeTextBox;
        private TextBox contatoTextBox;
        private TextBox enderecoTextBox;
        private ComboBox fornecedorIdComboBox;
        private Button gravarButton;
        private Button sairButton;
        public CadFornecedor()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            //Configuração da janela do formulário
            this.ClientSize = new System.Drawing.Size(300,400);
            this.Text = "Cadastro de Fornecedors";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = ColorTranslator.FromHtml("#CFCFCF");

            //Configurações do id
            nomeLabel = new Label();
            nomeLabel.Text = "Nome: ";
            nomeLabel.Location = new Point(20, 30);
            nomeLabel.Size = new Size(80, 20);
            this.Controls.Add(nomeLabel);

            //Configurações do campo texto de id
            nomeTextBox = new TextBox();
            nomeTextBox.Location = new Point(100, 30);
            nomeTextBox.Size = new Size(150, 20);
            this.Controls.Add(nomeTextBox);

            //Configurações de rótulo Capacidade Máxima
            contatoLabel = new Label();
            contatoLabel.Text = "Contato: ";
            contatoLabel.Location = new Point(20, 60);
            contatoLabel.Size = new Size(80, 20);
            this.Controls.Add(contatoLabel);
            
            //Configurando o Campo de texto Capacidade Máxima
            contatoTextBox = new TextBox();
            contatoTextBox.Location = new Point(100, 60);
            contatoTextBox.Size = new Size(150, 20);
            this.Controls.Add(contatoTextBox);

            //Configurações de rótulo Capacidade Miníma
            enderecoLabel = new Label();
            enderecoLabel.Text = "Endereço: ";
            enderecoLabel.Location = new Point(20, 90);
            enderecoLabel.Size = new Size(80, 20);
            this.Controls.Add(enderecoLabel);

            //Configurando o Campo de texto Capacidade Miníma
            enderecoTextBox = new TextBox();
            enderecoTextBox.Location = new Point(100, 90);
            enderecoTextBox.Size = new Size(150, 30 );
            this.Controls.Add(enderecoTextBox);

            //Configurações do botao gravar
            gravarButton = new Button();
            gravarButton.Text = "Gravar";
            gravarButton.Location = new Point(70, 120);
            gravarButton.Size = new Size(80, 30);
            gravarButton.Click += new EventHandler(gravarButton_Click);
            gravarButton.BackColor = ColorTranslator.FromHtml("#FFFDE8");
            this.Controls.Add(gravarButton);

            //Configurações do botão sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(160, 120);
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
                Controller.Fornecedor fornecedor = new Controller.Fornecedor();
                fornecedor.nome = nomeTextBox.Text;
                fornecedor.contato = contatoTextBox.Text;
                fornecedor.endereco = enderecoTextBox.Text;

                Controller.Fornecedor.CadastraFornecedor(fornecedor.nome, fornecedor.contato, fornecedor.endereco);
                MessageBox.Show("Fornecedor cadastrado com sucesso!");
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
            contatoTextBox.Text = "";
            enderecoTextBox.Text = "";
        }
    }

//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    public class FormEditaFornecedor : Form
    {
        private Label fornecedorIdLabel;
        private Label nomeLabel;
        private Label contatoLabel;
        private Label enderecoLabel;
        private ComboBox fornecedorIdCb;
        private TextBox contatoTextBox;
        private TextBox enderecoTextBox;
        private TextBox nomeTextBox;
        private Button gravarButton;
        private Button sairButton;

        public void InitializeComponent()
        {
            //Configuração da janela do formulário
            this.ClientSize = new System.Drawing.Size(300,400);
            this.Text = "Edição de fornecedor";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = ColorTranslator.FromHtml("#CFCFCF");

            //Configurações do id
            fornecedorIdLabel = new Label();
            fornecedorIdLabel.Text = "ID fornecedor: ";
            fornecedorIdLabel.Location = new Point(20, 30);
            fornecedorIdLabel.Size = new Size(80, 20);
            this.Controls.Add(fornecedorIdLabel);

            //Configurações do campo texto de id
            fornecedorIdCb = new ComboBox();
            fornecedorIdCb.Location = new Point(100, 30);
            fornecedorIdCb.Size = new Size(150, 20);
            List<Controller.Fornecedor> listaFornecedors = new  List<Controller.Fornecedor>();
            foreach (Model.Fornecedor fornecedor in Model.Fornecedor.BuscaFornecedor())
            {
                fornecedorIdCb.Items.Add(fornecedor);
            }
            fornecedorIdCb.DisplayMember = "nome";
            fornecedorIdCb.ValueMember = "fornecedorId";
            fornecedorIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(fornecedorIdCb);

            //Configurações de rótulo Nome
            nomeLabel = new Label();
            nomeLabel.Text = "Nome: ";
            nomeLabel.Location = new Point(20, 60);
            nomeLabel.Size = new Size(80, 20);
            this.Controls.Add(nomeLabel);

            //Configurando o Campo de texto Nome
            nomeTextBox = new TextBox();
            nomeTextBox.Location = new Point(100, 60);
            nomeTextBox.Size = new Size(150, 20);
            this.Controls.Add(nomeTextBox);

            //Configurações de rótulo Contato
            contatoLabel = new Label();
            contatoLabel.Text = "Contato: ";
            contatoLabel.Location = new Point(20, 90);
            contatoLabel.Size = new Size(80, 20);
            this.Controls.Add(contatoLabel);

            //Configurando o Campo de texto Contato
            contatoTextBox = new TextBox();
            contatoTextBox.Location = new Point(100, 90);
            contatoTextBox.Size = new Size(150, 20);
            this.Controls.Add(contatoTextBox);

            //Configurações de rótulo Endereço
            enderecoLabel = new Label();
            enderecoLabel.Text = "Endereço: ";
            enderecoLabel.Location = new Point(20, 120);
            enderecoLabel.Size = new Size(80, 20);
            this.Controls.Add(enderecoLabel);

            //Configurando o Campo de texto Endereço
            enderecoTextBox = new TextBox();
            enderecoTextBox.Location = new Point(100, 120);
            enderecoTextBox.Size = new Size(150, 20);
            this.Controls.Add(enderecoTextBox);

            //Configurações do botão Gravar
            gravarButton = new Button();
            gravarButton.Text = "Gravar";
            gravarButton.Location = new Point(80, 360);
            gravarButton.Size = new Size(80, 30);
            gravarButton.Click += (ScrollBarRenderer, e) =>{
                SalvaFornecedor();
                LimpaTela();
            };
            gravarButton.BackColor = ColorTranslator.FromHtml("#FFFDE8");
            this.Controls.Add(gravarButton);

            //Configurações do botão Sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(170, 360);
            sairButton.Size = new Size(80, 30);
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
        
        public FormEditaFornecedor()
        {
            InitializeComponent();
        }

        public void SalvaFornecedor()
        {
            try
            {
                Controller.Fornecedor fornecedor = new Controller.Fornecedor();
                var fornecedorSelecionada = ((Model.Fornecedor)fornecedorIdCb.SelectedItem).fornecedorId.ToString();
                if (fornecedorSelecionada == null)
                {
                    MessageBox.Show("Selecione uma fornecedor");
                    return;
                }
                fornecedor.fornecedorId = fornecedorSelecionada.ToString();
                fornecedor.nome = nomeTextBox.Text;
                fornecedor.contato = contatoTextBox.Text;
                fornecedor.endereco = enderecoTextBox.Text;
                

                Controller.Fornecedor.AlteraFornecedor(fornecedor.fornecedorId, fornecedor.nome, fornecedor.contato, fornecedor.endereco);
                MessageBox.Show("fornecedor alterada com sucesso!");
            } catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar fornecedor: " + ex.Message);
            }
        }
        
        public void LimpaTela()
        {
            nomeTextBox.Text = "";
            contatoTextBox.Text = "";
            enderecoTextBox.Text = "";
        }
    }

//------------------ Formulário de exclusão de fornecedor ---------


    public class FormExcluiFornecedor : Form
    {
        private Label fornecedorIdLabel;
        private ComboBox fornecedorIdCb;
        private Button excluirButton;
        private Button sairButton;

        private void InitializeComponent()
        {
            this.Text = "Excluir fornecedor";
            this.Size = new Size(300, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = ColorTranslator.FromHtml("#CFCFCF");

            //Configurações do rótulo fornecedorId
            fornecedorIdLabel = new Label();
            fornecedorIdLabel.Text = "ID fornecedor: ";
            fornecedorIdLabel.Location = new Point(20, 30);
            fornecedorIdLabel.Size = new Size(80, 20);
            this.Controls.Add(fornecedorIdLabel);

            //Configurações do campo texto de fornecedorId
            fornecedorIdCb = new ComboBox();
            fornecedorIdCb.Location = new Point(100, 30);
            fornecedorIdCb.Size = new Size(150, 20);
            List<Model.Fornecedor> listaFornecedors = new  List<Model.Fornecedor>();
            foreach (Model.Fornecedor fornecedor in Model.Fornecedor.BuscaFornecedor())
            {
                fornecedorIdCb.Items.Add(fornecedor);
            }
            fornecedorIdCb.DisplayMember = "Id";
            fornecedorIdCb.ValueMember = "fornecedorId";
            fornecedorIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(fornecedorIdCb);

            //Configurações do botão Excluir
            excluirButton = new Button();
            excluirButton.Text = "Excluir";
            excluirButton.Location = new Point(80, 260);
            excluirButton.Size = new Size(80, 30);
            excluirButton.Click += (ScrollBarRenderer, e) =>{
                ExcluiFornecedor();
                LimpaTela();
            };
            excluirButton.BackColor = ColorTranslator.FromHtml("#FFFDE8");
            this.Controls.Add(excluirButton);

            //Configurações do botão Sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(170, 260);
            sairButton.Size = new Size(80, 30);
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

        public FormExcluiFornecedor()
        {
            InitializeComponent();
        }

        public void ExcluiFornecedor()
        {
            try
            {
                Controller.Fornecedor fornecedor = new Controller.Fornecedor();
                var fornecedorSelecionada = ((Model.Fornecedor)fornecedorIdCb.SelectedItem).fornecedorId.ToString();
                if (fornecedorSelecionada == null)
                {
                    MessageBox.Show("Selecione uma fornecedor");
                    return;
                }
                fornecedor.fornecedorId = fornecedorSelecionada.ToString();

                Controller.Fornecedor.ExcluiFornecedor(fornecedor.fornecedorId);
                MessageBox.Show("fornecedor excluída com sucesso!");
            } catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir fornecedor: " + ex.Message);
            }
        }

        public void LimpaTela()
        {
            fornecedorIdCb.Text = "";
        }
    }
}