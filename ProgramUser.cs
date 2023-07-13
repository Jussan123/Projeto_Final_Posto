using System;
using System.Drawing;
using System.Windows.Forms;
using View.Formulario;

using Model;


namespace View
{
    public partial class ProgramUserForm : Form
    {
        private ToolStripStatusLabel dateTimeLabel; //Adicionado o rótulo para exibir a data e a hora 

        public ProgramUserForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            //Configurações do menu de navegação
            MenuStrip menuStrip = new MenuStrip();
            menuStrip.Location = new Point(0, 0);
            menuStrip.Size = new Size(300, 24);

            ToolStripMenuItem cadastroMenuItem = new ToolStripMenuItem("Cadastro");

            //Sub-menus do menu "Cadastro"
            ToolStripMenuItem bombasMenuItem = new ToolStripMenuItem("Bombas");
            bombasMenuItem.Click += new EventHandler(BombasMenuItem_Click);
            cadastroMenuItem.DropDownItems.Add(bombasMenuItem);


            ToolStripMenuItem combustiveisMenuItem = new ToolStripMenuItem("Combustíveis");
            combustiveisMenuItem.Click += new EventHandler(CombustiveisMenuItem_Click);
            cadastroMenuItem.DropDownItems.Add(combustiveisMenuItem);

            ToolStripMenuItem fornecedorMenuItem = new ToolStripMenuItem("Fornecedor");
            fornecedorMenuItem.Click += new EventHandler(FornecedorMenuItem_Click);
            cadastroMenuItem.DropDownItems.Add(fornecedorMenuItem);

            cadastroMenuItem.DropDownItems.Add(new ToolStripSeparator()); // Separador

            cadastroMenuItem.DropDownItems.Add("Sair", null, SairMenuItem_Click);

            menuStrip.Items.Add(cadastroMenuItem);

            ToolStripMenuItem movimentacoesMenuItem = new ToolStripMenuItem("Movimentações");

            //Sub-menus do menu "Movimentações"
            ToolStripMenuItem fluxosMenuItem = new ToolStripMenuItem("Fluxos");
            fluxosMenuItem.Click += new EventHandler(FluxosMenuItem_Click);
            movimentacoesMenuItem.DropDownItems.Add(fluxosMenuItem);

            menuStrip.Items.Add(movimentacoesMenuItem);

            ToolStripMenuItem ajudaMenuItem = new ToolStripMenuItem("Ajuda");

            //Sub-menus do menu "Ajuda"
            ToolStripMenuItem sobreMenuItem = new ToolStripMenuItem("Sobre");
            sobreMenuItem.Click += new EventHandler(SobreMenuItem_Click);
            ajudaMenuItem.DropDownItems.Add(sobreMenuItem);

            menuStrip.Items.Add(ajudaMenuItem);


            this.Controls.Add(menuStrip);

            //Configurações da barra de status
            StatusStrip statusStrip = new StatusStrip();
            statusStrip.Dock = DockStyle.Bottom;

            ToolStripStatusLabel infoLabel = new ToolStripStatusLabel();
            infoLabel.Text = "Desenvolvido por: JEL Tech Company";
            statusStrip.Items.Add(infoLabel);

            dateTimeLabel = new ToolStripStatusLabel(); //Cria a instância para a data e hora
            statusStrip.Items.Add(dateTimeLabel); //Adiciona o label à barra de status

            this.Controls.Add(statusStrip);
        }

        private void SairMenuItem_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BombasMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Enter Bombas");
            View.Formulario.bombaForm.ListBomba bomba = new View.Formulario.bombaForm.ListBomba();
            bomba.ShowDialog();
        }

        private void CombustiveisMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter Combustíveis");
            View.Formulario.CombustivelForm.ListCombustivelForm combustivel = new View.Formulario.CombustivelForm.ListCombustivelForm();
            combustivel.ShowDialog();
        }

        private void FornecedorMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter Fornecedor");
            View.Formulario.FornecedorForm.ListFornecedorForm fornecedor = new View.Formulario.FornecedorForm.ListFornecedorForm();
            fornecedor.ShowDialog();
        }

        private void FluxosMenuItem_Click(object sender, EventArgs e)
        {
            View.Formulario.MovimentacaoForm.ListMovimentacao movimentacao = new View.Formulario.MovimentacaoForm.ListMovimentacao();
            movimentacao.ShowDialog();
        } 

        private void SobreMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter Sobre");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateTimeLabel.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"); //Exibe a data e a hora atual
        }
    }
}