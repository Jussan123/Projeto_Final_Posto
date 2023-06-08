/* Módulo View CadFornecedor
 * Descrição: cadastro de fornecedor
 * Autor: Erich Wanderley 
 * Data: 22/05/2023
 * Versão: 1.0
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace View.Fomulario.Cad.FornecedorForm
{
    public partial class CadFornecedor : Form
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
                Controller.Fornecedor fornecedor = new Controller.Fornecedor();//Instanciando a classe fornecedor
                fornecedor.tipoCombustivelId = tipoCombustivelIdTextBox.Text;//Atribuindo o valor do campo id ao atributo tipoCombustivelId
                if (fornecedor.tipoCombustivelId == null)  throw new Exception("O campo ID não pode ser vazio!");//Verificando se o campo id está vazio
                fornecedor.limiteMaximo = limiteMaximoTextBox.Text;//Atribuindo o valor do campo limiteMaximo ao atributo limiteMaximo
                fornecedor.limiteMinimo = limiteMinimoTextBox.Text;//Atribuindo o valor do campo limiteMinimo ao atributo limiteMinimo
                Controller.Fornecedor.CadastrarFornecedor(fornecedor.tipoCombustivelId, fornecedor.limiteMaximo, fornecedor.limiteMinimo, fornecedor.nomeCombustivel);//Chamando o método Cadastrarfornecedor da classe fornecedor
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

    public class FormEditaFornecedor : Form
    {
        private Label fornecedorIdLabel;
        private Label tipoCombustivelIdLabel;
        private Label limiteMaximoLabel;
        private Label limiteMinimoLabel;
        private Label nomeCombustivelLabel;
        private ComboBox fornecedorIdCb;
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
            this.Text = "Edição de fornecedor";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

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
            List<Model.Fornecedor> listaFornecedors = new  List<Model.Fornecedor>();
            foreach (Model.ornecedor fornecedor in Model.Fornecedor.BuscaFornecedor())
            {
                fornecedorIdCb.Items.Add(fornecedor);
            }
            fornecedorIdCb.DisplayMember = "Id";
            fornecedorIdCb.ValueMember = "Id";
            fornecedorIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(fornecedorIdCb);

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
                SalvaFornecedor();
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
        
        public FormEditaFornecedor()
        {
            InitializeComponent();
        }

        public void SalvaFornecedor()
        {
            try
            {
                Controller.Fornecedor fornecedor = new Controller.Fornecedor();
                var fornecedorSelecionada = (Controller.Fornecedor) fornecedorIdCb.SelectedItem;
                if (fornecedorSelecionada == null)
                {
                    MessageBox.Show("Selecione uma fornecedor");
                    return;
                }
                fornecedor.fornecedorId = fornecedorSelecionada.fornecedorId.ToString();
                fornecedor.tipoCombustivelId = tipoCombustivelIdCb.Text;
                fornecedor.limiteMaximo = limiteMaximoTextBox.Text;
                fornecedor.limiteMinimo = limiteMinimoTextBox.Text;
                fornecedor.nomeCombustivel = nomeCombustivelTextBox.Text;

                Controller.Fornecedor controllerFornecedor = new Controller.Fornecedor();
                Controller.Fornecedor.AlterarFornecedor(fornecedor.fornecedorId, fornecedor.tipoCombustivelId, fornecedor.limiteMaximo, fornecedor.limiteMinimo, fornecedor.nomeCombustivel);
                MessageBox.Show("fornecedor alterada com sucesso!");
            } catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar fornecedor: " + ex.Message);
            }
        }
        
        public void LimpaTela()
        {
            fornecedorIdCb.Text = "";
            tipoCombustivelIdCb.Text = "";
            limiteMaximoTextBox.Text = "";
            limiteMinimoTextBox.Text = "";
            nomeCombustivelTextBox.Text = "";
        }
    }

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
            fornecedorIdCb.ValueMember = "Id";
            fornecedorIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(fornecedorIdCb);

            //Configurações do botão Excluir
            excluirButton = new Button();
            excluirButton.Text = "Excluir";
            excluirButton.Location = new Point(20, 60);
            excluirButton.Size = new Size(80, 20);
            excluirButton.Click += (ScrollBarRenderer, e) =>{
                ExcluiFornecedor();
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

        public FormExcluiFornecedor()
        {
            InitializeComponent();
        }

        public void ExcluiFornecedor()
        {
            try
            {
                Controller.Fornecedor fornecedor = new Controller.Fornecedor();
                var fornecedorSelecionada = (Controller.Fornecedor) fornecedorIdCb.SelectedItem;
                if (fornecedorSelecionada == null)
                {
                    MessageBox.Show("Selecione uma fornecedor");
                    return;
                }
                fornecedor.fornecedorId = fornecedorSelecionada.fornecedorId.ToString();

                fornecedor.DeletaFornecedor(fornecedor.fornecedorId);
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