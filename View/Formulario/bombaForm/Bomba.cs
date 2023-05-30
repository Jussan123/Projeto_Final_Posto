/* Módulo Formulário Opções da Bomba
* Descrição: Formulário de Opções da Bomba
* Autor: Jussan Igor da Silva
* Data: 22/04/2023
* Versão: 1.0
*/

using View.Fomulario.BombaForm;

namespace View.Fomulario.BombaForm
{
    public class FormEditaBomba : Form
    {
        private Label bombaIdLabel;
        private Label tipoCombustivelIdLabel;
        private Label capmaxLabel;
        private Label capminLabel;
        private Label nomeCombustivelLabel;
        private ComboBox bombaIdCb;
        private ComboBox tipoCombustivelIdCb;
        private TextBox capmaxTextBox;
        private TextBox capminTextBox;
        private TextBox nomeCombustivelTextBox;
        private Button gravarButton;
        private Button sairButton;

        public void InitializeComponent()
        {
            //Configuração da janela do formulário
            this.ClientSize = new System.Drawing.Size(300,400);
            this.Text = "Edição de Bomba";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            //Configurações do id
            bombaIdLabel = new Label();
            bombaIdLabel.Text = "ID Bomba: ";
            bombaIdLabel.Location = new Point(20, 30);
            bombaIdLabel.Size = new Size(80, 20);
            this.Controls.Add(bombaIdLabel);

            //Configurações do campo texto de id
            bombaIdCb = new TextBox();
            bombaIdCb.Location = new Point(100, 30);
            bombaIdCb.Size = new Size(150, 20);
            List<Model.Bomba> listaBombas = new  List<Model.Bomba>();
            foreach (Model.Bomba bomba in Model.Bomba.BuscaBomba())
            {
                bombaIdCb.Items.Add(bomba);
            }
            bombaIdCb.DisplayMember = "Id";
            bombaIdCb.ValueMember = "Id";
            bombaIdCb.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(bombaIdCb);

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
            tipoCombustivelIdCb = new TextBox();
            tipoCombustivelIdCb.Location = new Point(100, 60);
            tipoCombustivelIdCb.Size = new Size(150, 20);
            this.Controls.Add(tipoCombustivelIdCb);

            //Configurações de rótulo Capacidade Máxima
            capmaxLabel = new Label();
            capmaxLabel.Text = "Cap. Máxima: ";
            capmaxLabel.Location = new Point(20, 90);
            capmaxLabel.Size = new Size(80, 20);
            this.Controls.Add(capmaxLabel);

            //Configurando o Campo de texto Capacidade Máxima
            capmaxTextBox = new TextBox();
            capmaxTextBox.Location = new Point(100, 90);
            capmaxTextBox.Size = new Size(150, 20);
            this.Controls.Add(capmaxTextBox);

            //Configurações de rótulo Capacidade Mínima
            capminLabel = new Label();
            capminLabel.Text = "Cap. Mínima: ";
            capminLabel.Location = new Point(20, 120);
            capminLabel.Size = new Size(80, 20);
            this.Controls.Add(capminLabel);

            //Configurando o Campo de texto Capacidade Mínima
            capminTextBox = new TextBox();
            capminTextBox.Location = new Point(100, 120);
            capminTextBox.Size = new Size(150, 20);
            this.Controls.Add(capminTextBox);

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
                SalvaBomba();
                LimpaTela();
            }
            this.Controls.Add(gravarButton);

            //Configurações do botão Sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(100, 180);
            sairButton.Size = new Size(80, 20);
            sairButton.Click += (ScrollBarRenderer, e) => this.Close();
            this.Controls.Add(sairButton);
        }
        
        public FormEditaBomba()
        {
            InitializeComponent();
        }

        public void SalvaBomba()
        {
            try
            {
                Controller.Bomba bomba = new Controller.Bomba();
                var bombaSelecionada = (Controller.Bomba) bombaIdCb.SelectedItem;
                if (bombaSelecionada == null)
                {
                    MessageBox.Show("Selecione uma bomba");
                    return;
                }
                bomba.bombaId = bombaSelecionada.bombaId.Text;
                bomba.tipoCombustivelId = tipoCombustivelIdCb.Text;
                bomba.capmax = capmaxTextBox.Text;
                bomba.capmin = capminTextBox.Text;
                bomba.nomeCombustivel = nomeCombustivelTextBox.Text;

                Controller.Bomba controllerBomba = new Controller.Bomba();
                Controller.Bomba.AlterarBomba(bomba.bombaId, bomba.tipoCombustivelId, bomba.capmax, bomba.capmin, bomba.nomeCombustivel);
                MessageBox.Show("Bomba alterada com sucesso!");
            } catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar bomba: " + ex.Message);
            }
        }
    }
}