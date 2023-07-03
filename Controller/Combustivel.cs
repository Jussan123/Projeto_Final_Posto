/* Módulo Controller de Combustível
 * Descrição: Classe que representa o controller da entidade Combustível
 * Autor: Jussan Igor da Silva
 * Data: 23/05/2023
 * Versão: 1.0
 */

using Model;

namespace Controller
{
    public class Combustivel
    {
        public string combustivelId { get; set; }
        public string precoCompra { get; set; }
        public string precoVenda { get; set; }
        public string nome { get; set; }
        public string sigla { get; set; }
        public string descricao { get; set; }

        

        public static Model.Combustivel CadastraCombustivel(
                string nome,
                string sigla,
                string descricao,
                string precoCompra,
                string precoVenda)
            {
                try
                {
                    Model.Combustivel combustivel = new Model.Combustivel(
                        nome,
                        sigla,
                        descricao,
                        decimal.Parse(precoCompra),
                        decimal.Parse(precoVenda)
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
                string combustivelId,
                string nome,
                string sigla,
                string descricao,
                string precoCompra,
                string precoVenda)
            {
                try
                {
                    Model.Combustivel.BuscaCombustivelPorId(int.Parse(combustivelId));
                    return Model.Combustivel.UpdateCombustivel(
                        int.Parse(combustivelId),
                        nome,
                        sigla,
                        descricao,
                        decimal.Parse(precoCompra),
                        decimal.Parse(precoVenda)
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

            public static Model.Combustivel BuscaCombustivelPorId(string combustivelId)
            {
                try
                {
                    return Model.Combustivel.BuscaCombustivelPorId(int.Parse(combustivelId));
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