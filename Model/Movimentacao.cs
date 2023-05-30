/* Módulo Model Movimentação
 * Classe Movimentação
 * Descrição: Classe que representa a entidade Movimentação
 * Autor: Jussan Igor da Silva
 * Data: 22/05/2023
 * Versão: 1.0
 */

using Banco;

namespace Model
{
    public class Movimentacao
    {
        public int movimentacaoId { get; set; }
       // public int combustivelId { get; set; }
        //public Combustivel Combustivel { get; set; }
        public decimal quantidade { get; set; }
        public string tipoOperacao { get; set; }
        public DateTime dataHora { get; set; }
        public int lojaId { get; set; }
        public Loja Loja { get; set; }
        public int fornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public int funcionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public int bombaId { get; set; }
        public Bomba Bomba { get; set; }

        public Movimentacao()
        {
        }

        public Movimentacao(decimal quantidade, string tipoOperacao, int lojaId, int fornecedorId, int funcionarioId, int bombaId)
        {
            this.quantidade = quantidade;
            this.tipoOperacao = tipoOperacao;
            this.dataHora = DateTime.Now;
            this.lojaId = lojaId;
            this.fornecedorId = fornecedorId;
            this.funcionarioId = funcionarioId;
            this.bombaId = bombaId;

            DataBase db = new DataBase();
            db.Movimentacoes.Add(this);
            db.SaveChanges();
        }

        public Movimentacao(decimal quantidade, string tipoOperacao, int lojaId, int funcionarioId, int bombaId)
        {
            this.quantidade = quantidade;
            this.tipoOperacao = tipoOperacao;
            this.dataHora = DateTime.Now;
            this.lojaId = lojaId;
            this.funcionarioId = funcionarioId;
            this.bombaId = bombaId;

            DataBase db = new DataBase();
            db.Movimentacoes.Add(this);
            db.SaveChanges();
        }


        public override bool Equals(object obj)
        {
            if (obj ==null)
            {
                return false;
            }
            if (obj == this)
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            Movimentacao movimentacao = (Movimentacao)obj;
            return this.movimentacaoId == movimentacao.movimentacaoId;
        }

        public override int GetHashCode()
        {
            return this.movimentacaoId;
        }

        public override string ToString()
        {
            return "Id: " + this.movimentacaoId + " - quantidade: " + this.quantidade + " - Tipo Operação: " + this.tipoOperacao + " - Data/Hora: " + this.dataHora + " - Id Loja: " + this.lojaId + " - Id Fornecedor: " + this.fornecedorId + " - Id Funcionário: " + this.funcionarioId + " - Id Bomba: " + this.bombaId + "\n";
        }

        //------------------- CRUD -------------------//

        public static List<Movimentacao> BuscaMovimentacao()
        {
            DataBase db = new DataBase();
            List<Movimentacao> movimentacoes = (from u in db.Movimentacoes select u).ToList();
            return movimentacoes;
        }

        public static Movimentacao BuscaMovimentacaoPorId(int movimentacaoId)
        {
            DataBase db = new DataBase();
            return db.Movimentacoes.Find(movimentacaoId);
        }

        public static Movimentacao UpdateMovimentacao(int movimentacaoId, decimal quantidade, string tipoOperacao, int lojaId, int fornecedorId, int funcionarioId, int bombaId)
        {
            DataBase db = new DataBase();
            Movimentacao movimentacao = db.Movimentacoes.Find(movimentacaoId);
            //movimentacao.combustivelId = combustivelId;
            movimentacao.quantidade = quantidade;
            movimentacao.tipoOperacao = tipoOperacao;
            movimentacao.dataHora = DateTime.Now;
            movimentacao.lojaId = lojaId;
            movimentacao.fornecedorId = fornecedorId;
            movimentacao.funcionarioId = funcionarioId;
            movimentacao.bombaId = bombaId;
            db.SaveChanges();
            return movimentacao;
        }

        public static Movimentacao UpdateMovimentacaoVenda(int movimentacaoId, decimal quantidade, string tipoOperacao, int lojaId, int funcionarioId, int bombaId)
        {
            DataBase db = new DataBase();
            Movimentacao movimentacao = db.Movimentacoes.Find(movimentacaoId);
            //movimentacao.combustivelId = combustivelId;
            movimentacao.quantidade = quantidade;
            movimentacao.tipoOperacao = tipoOperacao;
            movimentacao.dataHora = DateTime.Now;
            movimentacao.lojaId = lojaId;
            movimentacao.funcionarioId = funcionarioId;
            movimentacao.bombaId = bombaId;
            db.SaveChanges();
            return movimentacao;
        }

        public static void DeleteMovimentacao(int movimentacaoId)
        {
            DataBase db = new DataBase();
            Movimentacao movimentacao = db.Movimentacoes.Find(movimentacaoId);
            db.Movimentacoes.Remove(movimentacao);
            db.SaveChanges();
        }
    }
}