/* Módulo View CadCombustivel
 * Descrição: Cadastro de combustivel
 * Autor: Erich Wanderley 
 * Data: 22/05/2023
 * Versão: 1.0
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace View.Fomulario.CombustivelForm
{
    public partial class CadCombustivel : Form
    {
        private Label idLabel; // ERICH - ID COMBUSTIVEL
        //private Label nomeLabel; 
        //private Label limiteMinimoLabel; 
        private Label nomeCombustivelLabel; // ERICH - NOME COMBUSTIVEL
        private TextBox idTextBox;
        private TextBox nomeTextBox;
        //private TextBox limiteMinimoTextBox;
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

            //Configurações do id
            idLabel = new Label();
            idLabel.Text = "ID Combústivel: ";
            idLabel.Location = new Point(20, 30);
            idLabel.Size = new Size(80, 20);
            this.Controls.Add(idLabel);

            //Configurações do campo texto de id
            idTextBox = new TextBox();
            idTextBox.Location = new Point(100, 30);
            idTextBox.Size = new Size(150, 20);
            this.Controls.Add(idTextBox);

            //Configurações de rótulo Capacidade Máxima
            //nomeLabel = new Label();
            //nomeLabel.Text = "Cap. Máxima: ";
            //nomeLabel.Location = new Point(20, 60);
            //nomeLabel.Size = new Size(80, 20);
            //this.Controls.Add(nomeLabel);
            
            //Configurando o Campo de texto Capacidade Máxima
            nomeTextBox = new TextBox();
            nomeTextBox.Location = new Point(100, 60);
            nomeTextBox.Size = new Size(150, 20);
            this.Controls.Add(nomeTextBox);

            //Configurações de rótulo Capacidade Miníma
            //limiteMinimoLabel = new Label();
            //limiteMinimoLabel.Text = "Cap. Miníma: ";
            //limiteMinimoLabel.Location = new Point(20, 60);
            //limiteMinimoLabel.Size = new Size(80, 20);
            //this.Controls.Add(limiteMinimoLabel);

            //Configurando o Campo de texto Capacidade Miníma
            //limiteMinimoTextBox = new TextBox();
            //limiteMinimoTextBox.Location = new Point(100, 60);
            //limiteMinimoTextBox.Size = new Size(160, 30 );
            //this.Controls.Add(limiteMinimoTextBox);

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
                Controller.Combustivel combustivel = new Controller.Combustivel();//Instanciando a classe combustivel
                combustivel.id = idTextBox.Text;//Atribuindo o valor do campo id ao atributo id
                if (combustivel.id == null)  throw new Exception("O campo ID não pode ser vazio!");//Verificando se o campo id está vazio
                combustivel.nome = nomeTextBox.Text;//Atribuindo o valor do campo nome ao atributo nome
                //combustivel.limiteMinimo = limiteMinimoTextBox.Text;//Atribuindo o valor do campo limiteMinimo ao atributo limiteMinimo
                Controller.Combustivel.CadastrarCombustivel(combustivel.id, combustivel.nome, combustivel.limiteMinimo, combustivel.nomeCombustivel);//Chamando o método Cadastrarcombustivel da classe combustivel
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
            idTextBox.Text = "";
            nomeTextBox.Text = "";
            //limiteMinimoTextBox.Text = "";
            nomeCombustivelTextBox.Text = "";
        }
    }

    public class FormEditaCombustivel : Form
    {
        private Label combustivelIdLabel;
        private Label idLabel;
        //private Label nomeLabel;
        //private Label limiteMinimoLabel;
        private Label nomeCombustivelLabel;
        private ComboBox combustivelIdCb;
        private ComboBox idCb;
        private TextBox nomeTextBox;
        //private TextBox limiteMinimoTextBox;
        private TextBox nomeCombustivelTextBox;
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
            combustivelIdLabel = new Label();
            combustivelIdLabel.Text = "ID combustivel: ";
            combustivelIdLabel.Location = new Point(20, 30);
            combustivelIdLabel.Size = new Size(80, 20);
            this.Controls.Add(combustivelIdLabel);

            //Configurações do campo texto de id
            combustivelIdCb = new ComboBox();
            combustivelIdCb.Location = new Point(100, 30);
            combustivelIdCb.Size = new Size(150, 20);
            List<Model.Combustivel> listaCombustiveis = new  List<Model.Combustivel>();
            foreach (Model.Combustivel combustivel in Model.Combustivel.BuscaCombustivel())
            {
                CombustivelIdCb.Items.Add(combustivel);
            }
            combustivelIdCb.DisplayMember = "Id";
            combustivelIdCb.ValueMember = "Id";
            combustivelIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(combustivelIdCb);

            //Configurações do id
            idLabel = new Label();
            idLabel.Text = "ID Combústivel: ";
            idLabel.Location = new Point(20, 60);
            idLabel.Size = new Size(80, 20);
            List<Model.TipoCombustivel> listaTipoCombustivel = new  List<Model.TipoCombustivel>();
            foreach (Model.TipoCombustivel tipoCombustivel in Model.TipoCombustivel.BuscaTipoCombustivel())
            {
                idCb.Items.Add(tipoCombustivel);
            }
            idCb.DisplayMember = "nomeCombustivel";
            idCb.ValueMember = "Id";
            idCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(idLabel);

            //Configurações do campo texto de id
            idCb = new ComboBox();
            idCb.Location = new Point(100, 60);
            idCb.Size = new Size(150, 20);
            this.Controls.Add(idCb);

            //Configurações de rótulo Capacidade Máxima
            //nomeLabel = new Label();
            //nomeLabel.Text = "Cap. Máxima: ";
            //nomeLabel.Location = new Point(20, 90);
            //nomeLabel.Size = new Size(80, 20);
            this.Controls.Add(nomeLabel);

            //Configurando o Campo de texto Capacidade Máxima
            nomeTextBox = new TextBox();
            nomeTextBox.Location = new Point(100, 90);
            nomeTextBox.Size = new Size(150, 20);
            this.Controls.Add(nomeTextBox);

            //Configurações de rótulo Capacidade Mínima
            //limiteMinimoLabel = new Label();
            //limiteMinimoLabel.Text = "Cap. Mínima: ";
            //limiteMinimoLabel.Location = new Point(20, 120);
            //limiteMinimoLabel.Size = new Size(80, 20);
            //this.Controls.Add(limiteMinimoLabel);

            //Configurando o Campo de texto Capacidade Mínima
            //limiteMinimoTextBox = new TextBox();
            //limiteMinimoTextBox.Location = new Point(100, 120);
            //limiteMinimoTextBox.Size = new Size(150, 20);
            //this.Controls.Add(limiteMinimoTextBox);

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
                SalvaCombustivel();
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
        
        public FormEditaCombustivel()
        {
            InitializeComponent();
        }

        public void SalvaCombustivel()
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
                combustivel.id = idCb.Text;
                combustivel.nome = nomeTextBox.Text;
                //combustivel.limiteMinimo = limiteMinimoTextBox.Text;
                combustivel.nomeCombustivel = nomeCombustivelTextBox.Text;

                Controller.Combustivel controllerCombustivel = new Controller.Combustivel();
                Controller.Combustivel.AlterarCombustivel(combustivel.combustivelId, combustivel.id, combustivel.nome, combustivel.limiteMinimo, combustivel.nomeCombustivel);
                MessageBox.Show("combustivel alterada com sucesso!");
            } catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar combustivel: " + ex.Message);
            }
        }
        
        public void LimpaTela()
        {
            combustivelIdCb.Text = "";
            idCb.Text = "";
            nomeTextBox.Text = "";
            //limiteMinimoTextBox.Text = "";
            nomeCombustivelTextBox.Text = "";
        }
    }

    public class FormExcluiCombustivel : Form
    {
        private Label combustivelIdLabel;
        private ComboBox combustivelIdCb;
        private Button excluirButton;
        private Button sairButton;

        private void InitializeComponent()
        {
            this.Text = "Excluir combustivel";
            this.Size = new Size(300, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            //Configurações do rótulo combustivelId
            combustivelIdLabel = new Label();
            combustivelIdLabel.Text = "ID combustivel: ";
            combustivelIdLabel.Location = new Point(20, 30);
            combustivelIdLabel.Size = new Size(80, 20);
            this.Controls.Add(combustivelIdLabel);

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

                combustivel.DeletaCombustivel(combustivel.combustivelId);
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
        private Label idLabel;
        private Label tcombidLabel;
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

            //Configurações do ID - idLabel
            idLabel = new Label();
            idLabel.Text = "ID: ";
            idLabel.Location = new Point(20, 30);
            idLabel.Size = new Size(80, 20);
            this.Controls.Add(idLabel);

            //Configurações do campo texto de ID - idTextBox
            idTextBox = new TextBox();
            idTextBox.Location = new Point(100, 30);
            idTextBox.Size = new Size(150, 20);
            this.Controls.Add(idTextBox);


            //Configurações do Tipo Combustivel ID - tcombidLabel
            tcombidLabel = new Label();
            tcombidLabel.Text = "Tipo ID: ";
            tcombidLabel.Location = new Point(20, 30);
            tcombidLabel.Size = new Size(80, 20);
            this.Controls.Add(tcombidLabel);

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