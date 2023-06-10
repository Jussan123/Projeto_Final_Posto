/* Módulo Controller Fornecedor
 * Descrição: Classe que representa o controller da entidade Fornecedor
 * Autor: Lucas José Dias Caetano
 * Data: 23/05/2023
 * Versão: 1.0
*/

using Model;

namespace Controller
{
    public class Fornecedor
    {
        public string fornecedorId { get; set; }
        public string movimentacaoId { get; set; }
        public string nome { get; set; }
        public string contato { get; set; }
        public string endereco { get; set; }
        public static Model.Fornecedor CadastraFornecedor(
            string nome,
            string contato,
            string endereco,
            string movimentacaoId)
            {
                Model.Fornecedor fornecedor = new Model.Fornecedor(
                    nome,
                    contato,
                    endereco,
                    int.Parse(movimentacaoId)
                );
                return fornecedor;
            }

        public static Model.Fornecedor AlteraFornecedor(
            string fornecedorId,
            string nome,
            string contato,
            string endereco,
            string movimentacaoId)
        {
            try
            {
                Model.Fornecedor.BuscaFornecedorPorId(int.Parse(fornecedorId));
                return Model.Fornecedor.UpdateFornecedor(int.Parse(fornecedorId), nome, contato, endereco, int.Parse(movimentacaoId));
            } catch (Exception) {
                throw new Exception("Fornecedor não encontrado");
            }
        }

        public static List<Model.Fornecedor> BuscaFornecedores()
        {
            return Model.Fornecedor.BuscaFornecedor();
        }

        public static Model.Fornecedor EncontraFornecedorPorId(string fornecedorId)
        {
            try
            {
                return Model.Fornecedor.BuscaFornecedorPorId(int.Parse(fornecedorId));
            } catch (Exception) {
                throw new Exception("Fornecedor não encontrado");
            }
        }

        public static void ExcluiFornecedor(string fornecedorId)
        {
            try
            {
                Model.Fornecedor.DeleteFornecedor(int.Parse(fornecedorId));
            } catch (Exception) {
                throw new Exception("Fornecedor não encontrado");
            }
        }
    }
}