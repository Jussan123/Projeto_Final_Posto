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
        public string tipoOperacao { get; set; }
        public string combustivelId { get; set; }
        public string quantidade { get; set; }
        public string lojaId { get; set; }
        public string funcionarioId { get; set; }
        public string bombaId { get; set; }

        public static Model.Movimentacao CadastraMovimentacao(
            int combustivelId,
            string quantidade,
            string tipoOperacao,
            int lojaId,
            int funcionarioId,
            int bombaId
        )
        {
            decimal valor;
            if (Model.Loja.BuscaLojaId(lojaId) == null) throw new System.Exception("Erro ao cadastrar movimentação, loja não encontrada");
            if (Model.Bomba.BuscaBombaPorId(bombaId) == null) throw new System.Exception("Erro ao cadastrar movimentação, bomba não encontrada");
            if (Model.Funcionario.BuscaFuncionarioPorId(funcionarioId) == null) throw new System.Exception("Erro ao cadastrar movimentação, fornecedor não encontrado");
            if (tipoOperacao != "Entrada" && tipoOperacao != "Saida") throw new System.Exception("Erro ao cadastrar movimentação, tipo de operação inválido('Entrada' ou 'Saida')");
            if (decimal.Parse(quantidade) <= 0) throw new System.Exception("Erro ao cadastrar movimentação, quantidade inválida");
            try
            {
                if (tipoOperacao == "Entrada")
                {
                    decimal precoCompra = Model.Combustivel.BuscaPrecoCombustivel(combustivelId).precoCompra;
                    valor = decimal.Parse(quantidade) * precoCompra;
                } else {
                    decimal precoVenda = Model.Combustivel.BuscaPrecoCombustivel(combustivelId).precoVenda;
                    valor = decimal.Parse(quantidade) * precoVenda;
                }
            } catch (System.Exception e)
            {
                throw new System.Exception("Erro ao cadastrar movimentação, erro ao calcular valor");

            }
            Model.Movimentacao movimentacao = new  Model.Movimentacao(
                decimal.Parse(quantidade),
                tipoOperacao,
                valor,
                lojaId,
                funcionarioId,
                bombaId
            );
            try
            {
                if (tipoOperacao == "Entrada")
                {
                    decimal somaQuantidade = Model.Bomba.BuscaVolumeBombaPorId(bombaId) + decimal.Parse(quantidade);
                    Model.Bomba.UpdateBombaMovimentacao(bombaId, somaQuantidade);
                } else {
                    decimal subtracaoQuantidade = Model.Bomba.BuscaVolumeBombaPorId(bombaId) - decimal.Parse(quantidade);
                    Model.Bomba.UpdateBombaMovimentacao(bombaId, subtracaoQuantidade);
                } 
            } catch (System.Exception e)
            {
                throw new System.Exception("Erro ao cadastrar movimentação, erro ao atualizar volume da bomba");
            }
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
            string funcionarioId,
            string bombaId
        )
        {
            if (Model.Movimentacao.BuscaMovimentacaoPorId(int.Parse(movimentacaoId)) == null) throw new System.Exception("Erro ao alterar movimentação, movimentação não encontrada");
            if (Model.Loja.BuscaLojaId(int.Parse(lojaId)) == null) throw new System.Exception("Erro ao alterar movimentação, loja não encontrada");
            if (Model.Bomba.BuscaBombaPorId(int.Parse(bombaId)) == null) throw new System.Exception("Erro ao alterar movimentação, bomba não encontrada");
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
                int.Parse(funcionarioId),
                int.Parse(bombaId)
            );
        }

        public static void DeletaMovimentacao(string movimentacaoId)
        {
            if (Model.Movimentacao.BuscaMovimentacaoPorId(int.Parse(movimentacaoId)) == null) throw new System.Exception("Erro ao deletar movimentação, movimentação não encontrada");
            Model.Movimentacao.DeleteMovimentacao(int.Parse(movimentacaoId));
        }

        
    }
}