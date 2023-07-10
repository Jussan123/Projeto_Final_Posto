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
        public int combustivelId { get; set; }
        public Combustivel Combustivel { get; set; }
        public decimal quantidade { get; set; }
        public string tipoOperacao { get; set; }
        public DateTime dataHora { get; set; }
        public decimal valor { get; set; }
        public int lojaId { get; set; }
        public Loja loja { get; set; }
        public int funcionarioId { get; set; }
        public Funcionario funcionario { get; set; }
        public int bombaId { get; set; }
        public Bomba bomba { get; set; }
        public int fornecedorId { get; set; }
        public Fornecedor fornecedor { get; set; }

        public Movimentacao()
        {
        }

        public Movimentacao(int combustivelId, decimal quantidade, string tipoOperacao, decimal valor, int lojaId, int funcionarioId, int bombaId, int fornecedorId)
        {
            this.combustivelId = combustivelId;
            this.quantidade = quantidade;
            this.tipoOperacao = tipoOperacao;
            this.dataHora = DateTime.Now;
            this.valor = valor;
            this.lojaId = lojaId;
            this.funcionarioId = funcionarioId;
            this.bombaId = bombaId;
            this.fornecedorId = fornecedorId;

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
            return "Id: " + this.movimentacaoId + " Quantidade: " + this.quantidade + " Tipo de Operação: " + this.tipoOperacao + " Data e Hora: " + this.dataHora + " Valor: " + this.valor + " Loja: " + this.lojaId + " Funcionário: " + this.funcionarioId + " Bomba: " + this.bombaId + " Combustivel: " + this.combustivelId + " Fornecedor: " + this.fornecedorId + " \n" ;
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

        public static Movimentacao BuscaTipoOperacaoPorId(int movimentacaoId)
        {
            DataBase db = new DataBase();
            Movimentacao tipoOperacao = (from u in db.Movimentacoes where u.movimentacaoId == movimentacaoId select u).FirstOrDefault();
            // Retorna o tipo de operação se for entrada ou saída
            return tipoOperacao;
        }

        public static Movimentacao UpdateMovimentacao(int movimentacaoId, int combustivelId, decimal quantidade, string tipoOperacao, decimal valor, int lojaId, int funcionarioId, int bombaId)
        {
            DataBase db = new DataBase();
            Movimentacao movimentacao = db.Movimentacoes.Find(movimentacaoId);
            movimentacao.combustivelId = combustivelId;
            movimentacao.quantidade = quantidade;
            movimentacao.tipoOperacao = tipoOperacao;
            movimentacao.dataHora = DateTime.Now;
            movimentacao.valor = valor;
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