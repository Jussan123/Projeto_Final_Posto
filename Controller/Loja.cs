/* Módulo Controller da Loja
 * Classe Loja
 * Descrição: Classe que representa o controlador da entidade Loja
 * Autor: Jussan Igor da Silva
 * Data: 24/05/2023
 * Versão: 1.0
 */

using Model;

namespace Controller
{
    public class Loja
    {
        public string lojaId { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public static Model.Loja CadastraLoja(
            string Nome,
            string Endereco,
            string Telefone,
            string Email
        )
        {
            Model.Loja loja = new Model.Loja(
                Nome,
                Endereco,
                Telefone,
                Email
            );
            return loja;
        }
        
        public static Model.Loja AlteraLoja(
            string lojaId,
            string Nome,
            string Endereco,
            string Telefone,
            string Email
        )
        {
            try
            {
                if (Model.Loja.BuscaLojaId(int.Parse(lojaId)) == null) throw new System.Exception("Erro ao alterar loja, loja não encontrada");
                return Model.Loja.UpdateLoja(
                int.Parse(lojaId),
                Nome,
                Endereco,
                Telefone,
                Email
            );            
            } catch (Exception) {
                throw new System.Exception("Erro ao alterar loja");
            }
        }

        public static List<Model.Loja> ListaLojas()
        {
            return Model.Loja.BuscaLoja();
        }

        public static Model.Loja EncontraLojaPorId(string lojaId)
        {
            try
            {
                return Model.Loja.BuscaLojaId(int.Parse(lojaId));
            } catch (Exception) {
                throw new System.Exception("Erro ao encontrar loja");
            }
        }

        public static void ExcluiLoja(string lojaId)
        {
            if (Model.Loja.BuscaLojaId(int.Parse(lojaId)) == null) throw new System.Exception("Erro ao excluir loja, loja não encontrada");
            Model.Loja.DeleteLoja(int.Parse(lojaId));
        }
    }
}