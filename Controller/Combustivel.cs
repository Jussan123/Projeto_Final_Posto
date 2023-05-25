/* Módulo Controller de Combustível
 * Descrição: Classe que representa o controller da entidade Combustível
 * Autor: Jussan Igor da Silva
 * Data: 23/05/2023
 * Versão: 1.0
 */

using Model;

namespace Controller
{
    public class combustivel
    {
            public static Model.Combustivel CadastraCombustivel(
                string TipoCombustivelId,
                string QuantidadeEstoque,
                string Preco)
            {
                try
                {
                    Model.Combustivel combustivel = new Model.Combustivel(
                        int.Parse(TipoCombustivelId),
                        decimal.Parse(QuantidadeEstoque),
                        decimal.Parse(Preco)
                    );
                    return combustivel;
                }
                catch (FormatException ex)
                {
                    throw new ArgumentException("Erro ao cadastrar combustível: Valor inválido encontrado.", ex);
                }
                catch (OverflowException ex)
                {
                    throw new ArgumentException("Erro ao cadastrar combustível: Valor fora do intervalo válido.", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao alterar bomba: " + ex.Message, ex);
                }
            }

            public static Model.Combustivel AlteraCombustivel(
                string CombustivelId,
                string TipoCombustivelId,
                string QuantidadeEstoque,
                string Preco)
            {
                try
                {
                    Model.Combustivel.BuscaCombustivelPorId(int.Parse(CombustivelId));
                    return Model.Combustivel.UpdateCombustivel(
                        int.Parse(CombustivelId),
                        int.Parse(TipoCombustivelId),
                        decimal.Parse(QuantidadeEstoque),
                        decimal.Parse(Preco)
                    );
                }
                catch (FormatException ex)
                {
                    throw new ArgumentException("Erro ao alterar bomba: Valor inválido encontrado.", ex);
                }
                catch (OverflowException ex)
                {
                    throw new ArgumentException("Erro ao alterar bomba: Valor fora do intervalo válido.", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao alterar bomba: " + ex.Message, ex);
                }
            }

            public static List<Model.Combustivel> ListaCombustivel()
            {
                return Model.Combustivel.BuscaCombustivel();
            }

            public static Model.Combustivel BuscaCombustivelPorId(string CombustivelId)
            {
                try
                {
                    return Model.Combustivel.BuscaCombustivelPorId(int.Parse(CombustivelId));
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao buscar combustível: " + ex.Message, ex);
                }
            }

            public static void ExcluiCombustivel(string combustivelId)
            {
                try
                {
                    Model.Combustivel.DeleteCombustivel(int.Parse(combustivelId));
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao excluir combustível: " + ex.Message, ex);
            }
        }
    }
}