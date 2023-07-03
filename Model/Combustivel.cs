/* Módulo Model Combustivel
 * Classe Combustivel
 * Descrição: Classe que representa a entidade Combustivel
 * Autor: Lucas José Dias Caetano
 * Data: 22/05/2023
 * Versão: 1.0
 */
using Banco;

namespace Model
{
    public class Combustivel
    {
        public int combustivelId { get; set; }
        public string nome { get; set; }
        public string sigla { get; set; }
        public string descricao { get; set; }
        public decimal precoCompra { get; set; }
        public decimal precoVenda { get; set; }

        public Combustivel()
        {
        }

    public Combustivel(string nome, string sigla, string descricao, decimal precoCompra, decimal precoVenda)
        {
            this.nome = nome;
            this.sigla = sigla;
            this.descricao = descricao;
            this.precoCompra = precoCompra;
            this.precoVenda = precoVenda;

            DataBase db = new DataBase();
            db.Combustiveis.Add(this);
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
            Combustivel combustivel = (Combustivel)obj;
            return this.combustivelId == combustivel.combustivelId;
        }

        public override int GetHashCode()
        {
            return this.combustivelId;
        }

        public override string ToString()
        {
            return "Combustivel: " + this.nome + " - sigla: " + this.sigla + " - descricao: " + this.descricao + " - Valor Compra R$ " + this.precoCompra + " - Valor Venda R$ " + this.precoVenda + " \n";
        }

        //------------------- CRUD -------------------//

        public static List<Combustivel> BuscaCombustivel()
        {
            DataBase db = new DataBase();
            List<Combustivel> combustiveis = (from u in db.Combustiveis select u).ToList();
            return combustiveis;
        }

        public static Combustivel BuscaCombustivelPorId(int combustivelId)
        {
            DataBase db = new DataBase();
            Combustivel combustivel = db.Combustiveis.Find(combustivelId);
            return combustivel;
        }

        public static (decimal precoCompra, decimal precoVenda) BuscaPrecoCombustivel(int combustivelId)
        {
            DataBase db = new DataBase();
            Combustivel combustivel = db.Combustiveis.Find(combustivelId);
            return (combustivel.precoVenda, combustivel.precoCompra);
        }

        public static Combustivel UpdateCombustivel(int combustivelId, string nome, string sigla, string descricao, decimal precoCompra, decimal precoVenda)
        {
            DataBase db = new DataBase();
            Combustivel combustivel = db.Combustiveis.Find(combustivelId);
            combustivel.nome = nome;
            combustivel.sigla = sigla;
            combustivel.descricao = descricao;
            combustivel.precoCompra = precoCompra;
            combustivel.precoVenda = precoVenda;
            db.SaveChanges();
            return combustivel;
        }

        public static void DeleteCombustivel(int combustivelId)
        {
            DataBase db = new DataBase();
            Combustivel combustivel = db.Combustiveis.Find(combustivelId);
            db.Combustiveis.Remove(combustivel);
            db.SaveChanges();
        }
    }
}