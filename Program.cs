using System;
using System.Drawing;
using System.Windows.Forms;
using View.Formulario;


namespace View
{
    public partial class ProgramForm : Form
    {
        private ToolStripStatusLabel dateTimeLabel; //Adicionado o rótulo para exibir a data e a hora

        public ProgramForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            //Configurações do menu de navegação
            MenuStrip menuStrip = new MenuStrip();
            menuStrip.Location = new Point(0, 0);
            menuStrip.Size = new Size(300, 24);

            ToolStripMenuItem sistemaMenuItem = new ToolStripMenuItem("Sistema");

            //Sub-menus do menu "Sistema"
            ToolStripMenuItem produtosMenuItem = new ToolStripMenuItem("Login"); //Renomeado para "Login"
            ////produtosMenuItem.Click += new EventHandler(ProdutosMenuItem_Click);
            sistemaMenuItem.DropDownItems.Add(produtosMenuItem);

            ToolStripMenuItem alxMenuItem = new ToolStripMenuItem("Funcionários"); //Renomeado para "Funcionários"
            ////alxMenuItem.Click += new EventHandler(AlxMenuItem_Click);
            sistemaMenuItem.DropDownItems.Add(alxMenuItem);

            sistemaMenuItem.DropDownItems.Add(new ToolStripSeparator()); //Separador

            ////sistemaMenuItem.DropDownItems.Add("Sair", null, SairMenuItem_Click);

            menuStrip.Items.Add(sistemaMenuItem);

            ToolStripMenuItem cadastroMenuItem = new ToolStripMenuItem("Cadastro");

            //Sub-menus do menu "Cadastro"
            ToolStripMenuItem bobasMenuItem = new ToolStripMenuItem("Bobas");
            ////bobasMenuItem.Click += new EventHandler(BobasMenuItem_Click);
            cadastroMenuItem.DropDownItems.Add(bobasMenuItem);

            ToolStripMenuItem combustiveisMenuItem = new ToolStripMenuItem("Combustíveis");
            ////combustiveisMenuItem.Click += new EventHandler(CombustiveisMenuItem_Click);
            cadastroMenuItem.DropDownItems.Add(combustiveisMenuItem);

            ToolStripMenuItem tipoCombustiveisMenuItem = new ToolStripMenuItem("Tipo Combustíveis");
            ////tipoCombustiveisMenuItem.Click += new EventHandler(TipoCombustiveisMenuItem_Click);
            cadastroMenuItem.DropDownItems.Add(tipoCombustiveisMenuItem);

            ToolStripMenuItem fornecedorMenuItem = new ToolStripMenuItem("Fornecedor");
            ////fornecedorMenuItem.Click += new EventHandler(FornecedorMenuItem_Click);
            cadastroMenuItem.DropDownItems.Add(fornecedorMenuItem);

            cadastroMenuItem.DropDownItems.Add(new ToolStripSeparator()); // Separador

            ////cadastroMenuItem.DropDownItems.Add("Sair", null, SairMenuItem_Click);

            menuStrip.Items.Add(cadastroMenuItem);

            ToolStripMenuItem movimentacoesMenuItem = new ToolStripMenuItem("Movimentações");

            //Sub-menus do menu "Movimentações"
            ToolStripMenuItem fluxosMenuItem = new ToolStripMenuItem("Fluxos");
            ////fluxosMenuItem.Click += new EventHandler(FluxosMenuItem_Click);
            movimentacoesMenuItem.DropDownItems.Add(fluxosMenuItem);

            menuStrip.Items.Add(movimentacoesMenuItem);

            ToolStripMenuItem ajudaMenuItem = new ToolStripMenuItem("Ajuda");

            //Sub-menus do menu "Ajuda"
            ToolStripMenuItem sobreMenuItem = new ToolStripMenuItem("Sobre");
            ////obreMenuItem.Click += new EventHandler(SobreMenuItem_Click);
            ajudaMenuItem.DropDownItems.Add(sobreMenuItem);

            menuStrip.Items.Add(ajudaMenuItem);

            this.Controls.Add(menuStrip);

            //Configurações da barra de status
            StatusStrip statusStrip = new StatusStrip();
            statusStrip.Dock = DockStyle.Bottom;

            ToolStripStatusLabel infoLabel = new ToolStripStatusLabel();
            infoLabel.Text = ".gitignore .jussan";
            statusStrip.Items.Add(infoLabel);

            dateTimeLabel = new ToolStripStatusLabel(); //Cria a instância para a data e hora
            statusStrip.Items.Add(dateTimeLabel); //Adiciona o label à barra de status

            this.Controls.Add(statusStrip);
        }

        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ProgramForm());
            }
        }
    }
}