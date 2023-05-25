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
        public static Model.Movimentacao CadastraMovimentacao(
            string combustivelId,
            string quantidade,
            string tipoOperacao,
            string lojaId,
            string fornecedorId
        )
        {
            if (Model.Loja.BuscaLojaId(int.Parse(lojaId)) == null) throw new System.Exception("Erro ao cadastrar movimentação, loja não encontrada");
            if (Model.Combustivel.BuscaCombustivelPorId(int.Parse(combustivelId)) == null) throw new System.Exception("Erro ao cadastrar movimentação, combustível não encontrado");
            if (Model.Fornecedor.BuscaFornecedorPorId(int.Parse(fornecedorId)) == null) throw new System.Exception("Erro ao cadastrar movimentação, fornecedor não encontrado");
            if (tipoOperacao != "Entrada" && tipoOperacao != "Saida") throw new System.Exception("Erro ao cadastrar movimentação, tipo de operação inválido('Entrada' ou 'Saida')");
            Model.Movimentacao movimentacao = new  Model.Movimentacao(
                int.Parse(combustivelId),
                decimal.Parse(quantidade),
                tipoOperacao,
                int.Parse(lojaId),
                int.Parse(fornecedorId)
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
            string combustivelId,
            string quantidade,
            string tipoOperacao,
            string lojaId,
            string fornecedorId
        )
        {
            if (Model.Movimentacao.BuscaMovimentacaoPorId(int.Parse(movimentacaoId)) == null) throw new System.Exception("Erro ao alterar movimentação, movimentação não encontrada");
            if (Model.Loja.BuscaLojaId(int.Parse(lojaId)) == null) throw new System.Exception("Erro ao alterar movimentação, loja não encontrada");
            if (Model.Combustivel.BuscaCombustivelPorId(int.Parse(combustivelId)) == null) throw new System.Exception("Erro ao alterar movimentação, combustível não encontrado");
            if (Model.Fornecedor.BuscaFornecedorPorId(int.Parse(fornecedorId)) == null) throw new System.Exception("Erro ao alterar movimentação, fornecedor não encontrado");
            if (tipoOperacao != "Entrada" && tipoOperacao != "Saida") throw new System.Exception("Erro ao alterar movimentação, tipo de operação inválido('Entrada' ou 'Saida')");
            return Model.Movimentacao.UpdateMovimentacao(
                int.Parse(movimentacaoId),
                int.Parse(combustivelId),
                decimal.Parse(quantidade),
                tipoOperacao,
                int.Parse(lojaId),
                int.Parse(fornecedorId)
            );
        }

        public static void DeletaMovimentacao(string movimentacaoId)
        {
            if (Model.Movimentacao.BuscaMovimentacaoPorId(int.Parse(movimentacaoId)) == null) throw new System.Exception("Erro ao deletar movimentação, movimentação não encontrada");
            Model.Movimentacao.DeleteMovimentacao(int.Parse(movimentacaoId));
        }
    }
}