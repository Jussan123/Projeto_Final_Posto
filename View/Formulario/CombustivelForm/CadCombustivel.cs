/* Módulo View CadCombustivel
 * Descrição: Cadastro de combustivel
 * Autor: Erich Wanderley 
 * Data: 22/05/2023
 * Versão: 1.0
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Controller;

namespace View.Formulario.CombustivelForm
{
    public partial class CadCombustivel : Form
    {
        private Label combustivelIdLabel; // ERICH - ID COMBUSTIVEL
        //private Label nomeLabel; 
        //private Label limiteMinimoLabel; 
        private Label nomeCombustivelLabel; // ERICH - NOME COMBUSTIVEL
        private Label siglaLabel; // Jussan - SIGLA COMBUSTIVEL
        private Label descricaoLabel; // Jussan - DESCRIÇÃO COMBUSTIVEL
        private Label precoCompraLabel; // Jussan - PREÇO DE COMPRA COMBUSTIVEL
        private Label precoVendaLabel; // Jussan - PREÇO DE VENDA COMBUSTIVEL
        private TextBox idTextBox;
        private TextBox nomeTextBox;
        private TextBox siglaTextBox;
        private TextBox descricaoTextBox;
        private TextBox precoCompraTextBox;
        private TextBox precoVendaTextBox;
        private TextBox nomeCombustivelTextBox;
        private Button gravarButton;
        private Button sairButton;
        public CadCombustivel()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            //Configuração da janela do formulário
            this.ClientSize = new System.Drawing.Size(300,400);
            this.Text = "Cadastro de Combustivel";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            //Configurando o Campo de texto Capacidade Máxima
            nomeTextBox = new TextBox();
            nomeTextBox.Location = new Point(100, 60);
            nomeTextBox.Size = new Size(150, 20);
            this.Controls.Add(nomeTextBox);

            //Configurações de rótulo Nome do Combustivel
            nomeCombustivelLabel = new Label();
            nomeCombustivelLabel.Text = "Nome: ";
            nomeCombustivelLabel.Location = new Point(20, 60);
            nomeCombustivelLabel.Size = new Size(80, 20);
            this.Controls.Add(nomeCombustivelLabel);

            //Configurando o Campo de texto Nome do Combustivel
            nomeCombustivelTextBox = new TextBox();
            nomeCombustivelTextBox.Location = new Point(100, 60);
            nomeCombustivelTextBox.Size = new Size(160, 30 );
            this.Controls.Add(nomeCombustivelTextBox);

            //Configurações de rótulo Sigla do Combustivel
            siglaLabel = new Label();
            siglaLabel.Text = "Sigla: ";
            siglaLabel.Location = new Point(20, 90);
            siglaLabel.Size = new Size(80, 20);
            this.Controls.Add(siglaLabel);

            //Configurando o Campo de texto Sigla do Combustivel
            siglaTextBox = new TextBox();
            siglaTextBox.Location = new Point(100, 90);
            siglaTextBox.Size = new Size(160, 30 );
            this.Controls.Add(siglaTextBox);

            //Configurações de rótulo Descrição do Combustivel
            descricaoLabel = new Label();
            descricaoLabel.Text = "Descrição: ";
            descricaoLabel.Location = new Point(20, 120);
            descricaoLabel.Size = new Size(80, 20);
            this.Controls.Add(descricaoLabel);

            //Configurando o Campo de texto Descrição do Combustivel
            descricaoTextBox = new TextBox();
            descricaoTextBox.Location = new Point(100, 120);
            descricaoTextBox.Size = new Size(160, 30 );
            this.Controls.Add(descricaoTextBox);

            //Configurações de rótulo Preço de Compra do Combustivel
            precoCompraLabel = new Label();
            precoCompraLabel.Text = "Preço Compra: ";
            precoCompraLabel.Location = new Point(20, 150);
            precoCompraLabel.Size = new Size(80, 20);
            this.Controls.Add(precoCompraLabel);

            //Configurando o Campo de texto Preço de Compra do Combustivel
            precoCompraTextBox = new TextBox();
            precoCompraTextBox.Location = new Point(100, 150);
            precoCompraTextBox.Size = new Size(160, 30 );
            this.Controls.Add(precoCompraTextBox);

            //Configurações de rótulo Preço de Venda do Combustivel
            precoVendaLabel = new Label();
            precoVendaLabel.Text = "Preço Venda: ";
            precoVendaLabel.Location = new Point(20, 180);
            precoVendaLabel.Size = new Size(80, 20);
            this.Controls.Add(precoVendaLabel);

            //Configurando o Campo de texto Preço de Venda do Combustivel
            precoVendaTextBox = new TextBox();
            precoVendaTextBox.Location = new Point(100, 180);
            precoVendaTextBox.Size = new Size(160, 30 );
            this.Controls.Add(precoVendaTextBox);

            //Configurações do botao gravar
            gravarButton = new Button();
            gravarButton.Text = "Gravar";
            gravarButton.Location = new Point(70, 210);
            gravarButton.Size = new Size(80, 30);
            gravarButton.Click += new EventHandler(gravarButton_Click);
            this.Controls.Add(gravarButton);

            //Configurações do botão sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(160, 210);
            sairButton.Size = new Size(80, 30);
            sairButton.Click += new EventHandler(sairButton_Click);
            this.Controls.Add(sairButton);
        }
         private void gravarButton_Click(object sender, EventArgs e)
        {
            try
            {
                Controller.Combustivel combustivel = new Controller.Combustivel();//Instanciando a classe combustivel
                combustivel.nome = nomeCombustivelTextBox.Text;//Atribuindo o valor do campo nomeCombustivelTextBox ao atributo nome da classe combustivel
                combustivel.sigla = siglaTextBox.Text;//Atribuindo o valor do campo siglaTextBox ao atributo sigla da classe combustivel
                combustivel.descricao = descricaoTextBox.Text;//Atribuindo o valor do campo descricaoTextBox ao atributo descricao da classe combustivel
                combustivel.precoCompra = precoCompraTextBox.Text;//Atribuindo o valor do campo precoCompraTextBox ao atributo precoCompra da classe combustivel
                combustivel.precoVenda = precoVendaTextBox.Text;//Atribuindo o valor do campo precoVendaTextBox ao atributo precoVenda da classe combustivel
                Controller.Combustivel.CadastraCombustivel(combustivel.nome, combustivel.sigla, combustivel.descricao, combustivel.precoCompra, combustivel.precoVenda);//Chamando o método Cadastrarcombustivel da classe combustivel
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
            nomeCombustivelTextBox.Text = "";
            siglaTextBox.Text = "";
            descricaoTextBox.Text = "";
            precoCompraTextBox.Text = "";
            precoVendaTextBox.Text = "";
        }
    }

//---------------------Formulário de Edição de Combustivel-----------------

    public class FormEditaCombustivel : Form
    {
        private Label combustivelcombustivelIdLabel;
        private Label nomeCombustivelLabel;
        private Label siglaLabel;
        private Label descricaoLabel;
        private Label precoCompraLabel;
        private Label precoVendaLabel;
        private ComboBox combustivelIdCb;
        private TextBox nomeTextBox;
        private TextBox siglaTextBox;
        private TextBox descricaoTextBox;
        private TextBox precoCompraTextBox;
        private TextBox precoVendaTextBox;
        private Button gravarButton;
        private Button sairButton;

        public void InitializeComponent()
        {
            //Configuração da janela do formulário
            this.ClientSize = new System.Drawing.Size(300,400);
            this.Text = "Edição de combustivel";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            //Configurações do id
            combustivelcombustivelIdLabel = new Label();
            combustivelcombustivelIdLabel.Text = "ID combustivel: ";
            combustivelcombustivelIdLabel.Location = new Point(20, 30);
            combustivelcombustivelIdLabel.Size = new Size(80, 20);
            this.Controls.Add(combustivelcombustivelIdLabel);

            //Configurações do campo texto de id
            combustivelIdCb = new ComboBox();
            combustivelIdCb.Location = new Point(100, 30);
            combustivelIdCb.Size = new Size(150, 20);
            List<Controller.Combustivel> listaCombustiveis = new  List<Controller.Combustivel>();
            foreach (Model.Combustivel combustivel in Controller.Combustivel.ListaCombustivel())
            {
                combustivelIdCb.Items.Add(combustivel);
            }
            combustivelIdCb.ValueMember = "combustivelId";
            combustivelIdCb.DisplayMember = "nome";
            combustivelIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(combustivelIdCb);

            //Configurações do campo texto de nome
            nomeCombustivelLabel = new Label();
            nomeCombustivelLabel.Text = "Nome: ";
            nomeCombustivelLabel.Location = new Point(20, 60);
            nomeCombustivelLabel.Size = new Size(80, 20);
            this.Controls.Add(nomeCombustivelLabel);

            //Configurações do campo texto de nome
            nomeTextBox = new TextBox();
            nomeTextBox.Location = new Point(100, 60);
            nomeTextBox.Size = new Size(150, 20);
            this.Controls.Add(nomeTextBox);

            //Configurações do campo texto de sigla
            siglaLabel = new Label();
            siglaLabel.Text = "Sigla: ";
            siglaLabel.Location = new Point(20, 90);
            siglaLabel.Size = new Size(80, 20);
            this.Controls.Add(siglaLabel);

            //Configurações do campo texto de sigla
            siglaTextBox = new TextBox();
            siglaTextBox.Location = new Point(100, 90);
            siglaTextBox.Size = new Size(150, 20);
            this.Controls.Add(siglaTextBox);

            //Configurações do campo texto de descrição
            descricaoLabel = new Label();
            descricaoLabel.Text = "Descrição: ";
            descricaoLabel.Location = new Point(20, 120);
            descricaoLabel.Size = new Size(80, 20);
            this.Controls.Add(descricaoLabel);

            //Configurações do campo texto de descrição
            descricaoTextBox = new TextBox();
            descricaoTextBox.Location = new Point(100, 120);
            descricaoTextBox.Size = new Size(150, 20);
            this.Controls.Add(descricaoTextBox);

            //Configurações do campo texto de preço de compra
            precoCompraLabel = new Label();
            precoCompraLabel.Text = "Preço compra: ";
            precoCompraLabel.Location = new Point(20, 150);
            precoCompraLabel.Size = new Size(80, 20);
            this.Controls.Add(precoCompraLabel);

            //Configurações do campo texto de preço de compra
            precoCompraTextBox = new TextBox();
            precoCompraTextBox.Location = new Point(100, 150);
            precoCompraTextBox.Size = new Size(150, 20);
            this.Controls.Add(precoCompraTextBox);

            //Configurações do campo texto de preço de venda
            precoVendaLabel = new Label();
            precoVendaLabel.Text = "Preço venda: ";
            precoVendaLabel.Location = new Point(20, 180);
            precoVendaLabel.Size = new Size(80, 20);
            this.Controls.Add(precoVendaLabel);

            //Configurações do campo texto de preço de venda
            precoVendaTextBox = new TextBox();
            precoVendaTextBox.Location = new Point(100, 180);
            precoVendaTextBox.Size = new Size(150, 20);
            this.Controls.Add(precoVendaTextBox);

            //Configurações do botão Gravar
            gravarButton = new Button();
            gravarButton.Text = "Gravar";
            gravarButton.Location = new Point(20, 210);
            gravarButton.Size = new Size(80, 20);
            gravarButton.Click += (ScrollBarRenderer, e) =>{
                SalvaCombustivel();
                LimpaTela();
            };
            this.Controls.Add(gravarButton);

            //Configurações do botão Sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(100, 210);
            sairButton.Size = new Size(80, 20);
            sairButton.Click += (ScrollBarRenderer, e) => this.Close();
            this.Controls.Add(sairButton);
        }
        
        public FormEditaCombustivel()
        {
            InitializeComponent();
        }

        public void SalvaCombustivel()
        {
            try
            {
                Controller.Combustivel combustivel = new Controller.Combustivel();
                
                combustivel.nome = nomeTextBox.Text;
                combustivel.sigla = siglaTextBox.Text;
                combustivel.descricao = descricaoTextBox.Text;
                combustivel.precoCompra = precoCompraTextBox.Text;
                combustivel.precoVenda = precoVendaTextBox.Text;
                
                Controller.Combustivel controllerCombustivel = new Controller.Combustivel();
                Controller.Combustivel.CadastraCombustivel(nomeTextBox.Text, siglaTextBox.Text, descricaoTextBox.Text, precoCompraTextBox.Text, precoVendaTextBox.Text);
                MessageBox.Show("combustivel alterada com sucesso!");
            } catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar combustivel: " + ex.Message);
            }
        }
        
        public void LimpaTela()
        {
            nomeTextBox.Text = "";
            siglaTextBox.Text = "";
            descricaoTextBox.Text = "";
            precoCompraTextBox.Text = "";
            precoVendaTextBox.Text = "";
        }
    }

//--------------------------------------------------------------

    public class FormExcluiCombustivel : Form
    {
        private Label combustivelcombustivelIdLabel;
        private ComboBox combustivelIdCb;
        private Button excluirButton;
        private Button sairButton;

        private void InitializeComponent()
        {
            this.Text = "Excluir combustivel";
            this.Size = new Size(300, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            //Configurações do rótulo combustivelId
            combustivelcombustivelIdLabel = new Label();
            combustivelcombustivelIdLabel.Text = "ID combustivel: ";
            combustivelcombustivelIdLabel.Location = new Point(20, 30);
            combustivelcombustivelIdLabel.Size = new Size(80, 20);
            this.Controls.Add(combustivelcombustivelIdLabel);

            //Configurações do campo texto de combustivelId
            combustivelIdCb = new ComboBox();
            combustivelIdCb.Location = new Point(100, 30);
            combustivelIdCb.Size = new Size(150, 20);
            List<Model.Combustivel> listaCombustiveis = new  List<Model.Combustivel>();
            foreach (Model.Combustivel combustivel in Model.Combustivel.BuscaCombustivel())
            {
                combustivelIdCb.Items.Add(combustivel);
            }
            combustivelIdCb.DisplayMember = "Id";
            combustivelIdCb.ValueMember = "Id";
            combustivelIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(combustivelIdCb);

            //Configurações do botão Excluir
            excluirButton = new Button();
            excluirButton.Text = "Excluir";
            excluirButton.Location = new Point(20, 60);
            excluirButton.Size = new Size(80, 20);
            excluirButton.Click += (ScrollBarRenderer, e) =>{
                ExcluiCombustivel();
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

        public FormExcluiCombustivel()
        {
            InitializeComponent();
        }

        public void ExcluiCombustivel()
        {
            try
            {
                Controller.Combustivel combustivel = new Controller.Combustivel();
                var combustivelSelecionada = (Controller.Combustivel) combustivelIdCb.SelectedItem;
                if (combustivelSelecionada == null)
                {
                    MessageBox.Show("Selecione uma combustivel");
                    return;
                }
                combustivel.combustivelId = combustivelSelecionada.combustivelId.ToString();

                Controller.Combustivel.ExcluiCombustivel(combustivel.combustivelId);
                MessageBox.Show("combustivel excluída com sucesso!");
            } catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir combustivel: " + ex.Message);
            }
        }

        public void LimpaTela()
        {
            combustivelIdCb.Text = "";
        }
    }
}



























/*using System;
using System.Drawing;
using System.Windows.Forms;

namespace View.Fomulario.CadCombustivel
{
    public partial class CadCombustivel : Form
    {
        private Label combustivelIdLabel;
        private Label tcombcombustivelIdLabel;
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

            //Configurações do ID - combustivelIdLabel
            combustivelIdLabel = new Label();
            combustivelIdLabel.Text = "ID: ";
            combustivelIdLabel.Location = new Point(20, 30);
            combustivelIdLabel.Size = new Size(80, 20);
            this.Controls.Add(combustivelIdLabel);

            //Configurações do campo texto de ID - idTextBox
            idTextBox = new TextBox();
            idTextBox.Location = new Point(100, 30);
            idTextBox.Size = new Size(150, 20);
            this.Controls.Add(idTextBox);


            //Configurações do Tipo Combustivel ID - tcombcombustivelIdLabel
            tcombcombustivelIdLabel = new Label();
            tcombcombustivelIdLabel.Text = "Tipo ID: ";
            tcombcombustivelIdLabel.Location = new Point(20, 30);
            tcombcombustivelIdLabel.Size = new Size(80, 20);
            this.Controls.Add(tcombcombustivelIdLabel);

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
}*/