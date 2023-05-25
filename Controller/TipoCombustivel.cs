/* Módulo Controller do TipoCombustivel
 * Classe TipoCombustivel
 * Descrição: Classe que representa o controlador da entidade TipoCombustivel
 * Autor: Jussan Igor da Silva
 * Data: 24/05/2023
 * Versão: 1.0
 */

using Model;

namespace Controller
{
    public class TipoCombustivel
    {
        public static Model.TipoCombustivel CadastraTipoCombustivel(
            string nomeCombustivel,
            string descricao,
            string codigo
        )
        {
            try
            {
                Model.TipoCombustivel tipoCombustivel = new Model.TipoCombustivel(
                    nomeCombustivel,
                    descricao,
                    codigo
                );
                return tipoCombustivel;
            } catch (Exception) {
                throw new System.Exception("Erro ao cadastrar tipo de combustível");
            }
        }

        public static List<Model.TipoCombustivel> ListaTipoCombustiveis()
        {
            try
            {
                return Model.TipoCombustivel.BuscaTipoCombustivel();
            } catch (Exception) {
                throw new System.Exception("Erro ao listar tipos de combustíveis");
            }
        }

        public static Model.TipoCombustivel EncontraTipoCombustivelPorId(string tipoCombustivelId)
        {
            if (Model.TipoCombustivel.BuscaTipoCombustivelPorId(int.Parse(tipoCombustivelId)) == null) throw new System.Exception("Erro ao encontrar tipo de combustível, tipo de combustível não encontrado");
            return Model.TipoCombustivel.BuscaTipoCombustivelPorId(int.Parse(tipoCombustivelId));
        }

        public static Model.TipoCombustivel AlteraTipoCombustivel(
            string tipoCombustivelId,
            string nomeCombustivel,
            string descricao,
            string codigo
        )
        {
            if (Model.TipoCombustivel.BuscaTipoCombustivelPorId(int.Parse(tipoCombustivelId)) == null) throw new System.Exception("Erro ao alterar tipo de combustível, tipo de combustível não encontrado");
            try
            {
                return Model.TipoCombustivel.UpdateTipoCombustivel(
                    int.Parse(tipoCombustivelId),
                    nomeCombustivel,
                    descricao,
                    codigo
                );
            } catch (Exception) {
                throw new System.Exception("Erro ao alterar tipo de combustível");
            }
        }

        public static void ExcluiTipoCombustivel(string tipoCombustivelId)
        {
            if (Model.TipoCombustivel.BuscaTipoCombustivelPorId(int.Parse(tipoCombustivelId)) == null) throw new System.Exception("Erro ao excluir tipo de combustível, tipo de combustível não encontrado");
            try
            {
                Model.TipoCombustivel.DeleteTipoCombustivel(int.Parse(tipoCombustivelId));
            } catch (Exception) {
                throw new System.Exception("Erro ao excluir tipo de combustível");
            }
        }
    }
}