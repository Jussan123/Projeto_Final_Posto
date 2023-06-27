/* Módulo View ListBomba
 * Descrição: Listar bomba de combustivel
 * Autor: Erich Wanderley 
 * Data: 22/05/2023
 * Versão: 1.0
 */


namespace View.Formulario.bombaForm
{
    public partial class ListBomba : Form
    {
        private Button novoButton;
        private Button alterarButton;
        private Button excluirButton;
        private Button refreshButton;
        private Button sairButton;
        private DataGridView bombaDataGridView;

        public ListBomba()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            // Configurações da janela do formulário
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Text = "Listar Bombas";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Configurações do botão de novo 
            novoButton = new Button();
            novoButton.Text = "Novo";
            novoButton.Location = new Point(20, 340);
            novoButton.Size = new Size(80, 30);
            novoButton.Click += new EventHandler(NovoButton_Click);
            this.Controls.Add(novoButton);

            // Configurações do botão de alterar 
            alterarButton = new Button();
            alterarButton.Text = "Alterar";
            alterarButton.Location = new Point(110, 340);
            alterarButton.Size = new Size(80, 30);
            alterarButton.Click += new EventHandler(AlterarButton_Click);
            this.Controls.Add(alterarButton);

            //Configurações do botão de excluir
            excluirButton = new Button();
            excluirButton.Text = "Excluir";
            excluirButton.Location = new Point(200, 340);
            excluirButton.Size = new Size(80, 30);
            excluirButton.Click += new EventHandler(ExcluirButton_Click);
            this.Controls.Add(excluirButton);

            //Configurações do botão de cancelar
            refreshButton = new Button();
            refreshButton.Text = "Cancelar";
            refreshButton.Location = new Point(290, 340);
            refreshButton.Size = new Size(80, 30);
            refreshButton.Click += new EventHandler(RefreshButton_Click);
            this.Controls.Add(refreshButton);

            //Configurações do botão de sair
            sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Location = new Point(380, 340);
            sairButton.Size = new Size(80, 30);
            sairButton.Click += new EventHandler(SairButton_Click);
            this.Controls.Add(sairButton);

            //Configurações do grid de Bombas
            //Data Grid View Jussan
            DataGridView bombaDataGridView = new DataGridView();
            bombaDataGridView.Location = new Point(20, 40);
            bombaDataGridView.Size = new Size(440, 280);
            //Configura as colunas do grid
            bombaDataGridView.Columns.Add("bombaId", "Bomba");
            bombaDataGridView.Columns.Add("nome", "Nome Combustível");
            bombaDataGridView.Columns.Add("limiteMaximo", "Capacidade Máxima");
            bombaDataGridView.Columns.Add("limiteMinimo", "Capacidade Mínima");
            bombaDataGridView.Columns.Add("volume", "Volume");
            bombaDataGridView.Columns.Add("lojaId", "Loja");
            foreach (var bomba in Controller.Bomba.ListarBombas())
            {
                bombaDataGridView.Rows.Add(bomba.bombaId, bomba.combustivel.nome, bomba.limiteMaximo, bomba.limiteMinimo, bomba.volume, bomba.lojaId);
            }
            //configura o modo de redimensionamento das linhas e colunas
            bombaDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //configura a cor das linhas alternadas
            bombaDataGridView.RowsDefaultCellStyle.BackColor = Color.White;
            bombaDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Aquamarine;
            //configura a fonte e o tamanho do texto
            bombaDataGridView.DefaultCellStyle.Font = new Font("TrebuchetMS", 10, FontStyle.Regular);
            bombaDataGridView.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            //configura a altura das linhas do grid
            bombaDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.Controls.Add(bombaDataGridView);
        }

        private void NovoButton_Click(object sender, EventArgs e)
        {
            AbrirForm(new View.Formulario.bombaForm.CadBomba());
            //throw new NotImplementedException();
        }

        private void AlterarButton_Click(object sender, EventArgs e)
        {
            AbrirForm(new View.Formulario.bombaForm.FormEditaBomba());
            //Adicionar Ação/código para alterar uma bomba selecionada
        }

        private void ExcluirButton_Click(object sender, EventArgs e)
        {
            AbrirForm(new View.Formulario.bombaForm.FormExcluiBomba());
            //Adicionar Ação/código para excluir uma bomba selecionada
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.ListaBomba();
            //Adicionar Ação/código para cancelar a operação atual
        }

        private void SairButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você realmente deseja sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                //Application.Exit();
            }
        }

        public void AbrirForm(Form form){
            form.ShowDialog();
        }

        public void ListaBomba()
        {
            bombaDataGridView.Rows.Clear();
            foreach (var bomba in Controller.Bomba.ListarBombas())
            {
                bombaDataGridView.Rows.Add(bomba.bombaId, bomba.combustivel.nome, bomba.limiteMaximo, bomba.limiteMinimo, bomba.volume, bomba.lojaId);
            }
        }
    }
}