/* Módulo Controller da Movimentacao
 * Classe Movimentacao
 * Descrição: Classe que representa o controlador da entidade Movimentacao
 * Autor: Jussan Igor da Silva
 * Data: 24/05/2023
 * Versão: 1.0
 */

using Model;

namespace Controller
{
    public class Movimentacao
    {
        public string movimentacaoId { get; set; }
        public string combustivelId { get; set; }
        public string quantidade { get; set; }
        public string lojaId { get; set; }
        public string valor { get; set; }
        public string funcionarioId { get; set; }

        public static Model.Movimentacao CadastraMovimentacao(
            string combustivelId,
            string quantidade,
            string tipoOperacao,
            string valor,
            string lojaId,
            string funcionarioId
        )
        {
            if (Model.Loja.BuscaLojaId(int.Parse(lojaId)) == null) throw new System.Exception("Erro ao cadastrar movimentação, loja não encontrada");
            if (Model.Funcionario.BuscaFuncionarioPorId(int.Parse(funcionarioId)) == null) throw new System.Exception("Erro ao cadastrar movimentação, fornecedor não encontrado");
            if (tipoOperacao != "Entrada" && tipoOperacao != "Saida") throw new System.Exception("Erro ao cadastrar movimentação, tipo de operação inválido('Entrada' ou 'Saida')");
            if (decimal.Parse(quantidade) <= 0) throw new System.Exception("Erro ao cadastrar movimentação, quantidade inválida");
            if (decimal.Parse(valor) <= 0) throw new System.Exception("Erro ao cadastrar movimentação, valor inválido");
            Model.Movimentacao movimentacao = new  Model.Movimentacao(
                decimal.Parse(quantidade),
                tipoOperacao,
                decimal.Parse(valor),
                int.Parse(lojaId),
                int.Parse(funcionarioId)
            );
            return movimentacao;
        }

        public static List<Model.Movimentacao> ListaMovimentacoes()
        {
            return Model.Movimentacao.BuscaMovimentacao();
        }

        public static Model.Movimentacao EncontraMovimentacaoPorId(string movimentacaoId)
        {
            if (Model.Movimentacao.BuscaMovimentacaoPorId(int.Parse(movimentacaoId)) == null) throw new System.Exception("Erro ao encontrar movimentação, movimentação não encontrada");
            return Model.Movimentacao.BuscaMovimentacaoPorId(int.Parse(movimentacaoId));
        }

        public static Model.Movimentacao AlteraMovimentacao(
            string movimentacaoId,
            string quantidade,
            string tipoOperacao,
            string valor,
            string lojaId,
            string funcionarioId
        )
        {
            if (Model.Movimentacao.BuscaMovimentacaoPorId(int.Parse(movimentacaoId)) == null) throw new System.Exception("Erro ao alterar movimentação, movimentação não encontrada");
            if (Model.Loja.BuscaLojaId(int.Parse(lojaId)) == null) throw new System.Exception("Erro ao alterar movimentação, loja não encontrada");
            if (Model.Funcionario.BuscaFuncionarioPorId(int.Parse(funcionarioId)) == null) throw new System.Exception("Erro ao alterar movimentação, fornecedor não encontrado");
            if (tipoOperacao != "Entrada" && tipoOperacao != "Saida") throw new System.Exception("Erro ao alterar movimentação, tipo de operação inválido('Entrada' ou 'Saida')");
            if (decimal.Parse(quantidade) <= 0) throw new System.Exception("Erro ao alterar movimentação, quantidade inválida");
            if (decimal.Parse(valor) <= 0) throw new System.Exception("Erro ao alterar movimentação, valor inválido");
            return Model.Movimentacao.UpdateMovimentacao(
                int.Parse(movimentacaoId),
                decimal.Parse(quantidade),
                tipoOperacao,
                decimal.Parse(valor),
                int.Parse(lojaId),
                int.Parse(funcionarioId)
            );
        }

        public static void DeletaMovimentacao(string movimentacaoId)
        {
            if (Model.Movimentacao.BuscaMovimentacaoPorId(int.Parse(movimentacaoId)) == null) throw new System.Exception("Erro ao deletar movimentação, movimentação não encontrada");
            Model.Movimentacao.DeleteMovimentacao(int.Parse(movimentacaoId));
        }
    }
}