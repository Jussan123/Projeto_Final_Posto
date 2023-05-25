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
        public int tipocombustivelId { get; set; }
        public TipoCombustivel tipoCombustivel { get; set; }
        public decimal quantidadeEstoque { get; set; }
        public decimal preco { get; set; }

        public Combustivel()
        {
        }

        public Combustivel(int tipocombustivelId, decimal quantidadeEstoque, decimal preco)
        {
            this.tipocombustivelId = tipocombustivelId;
            this.quantidadeEstoque = quantidadeEstoque;
            this.preco = preco;

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
            return "Id: " + this.combustivelId + " - Id Tipo Combustivel: " + this.tipocombustivelId + " - Quantidade Estoque: " + this.quantidadeEstoque + " - Preço: " + this.preco + "\n";
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

        public static Combustivel UpdateCombustivel(int combustivelId, int tipocombustivelId, decimal quantidadeEstoque, decimal preco)
        {
            DataBase db = new DataBase();
            Combustivel combustivel = db.Combustiveis.Find(combustivelId);
            combustivel.tipocombustivelId = tipocombustivelId;
            combustivel.quantidadeEstoque = quantidadeEstoque;
            combustivel.preco = preco;
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