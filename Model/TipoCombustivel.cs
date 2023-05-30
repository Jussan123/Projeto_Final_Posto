/* Módulo Model TipoCombustivel
 * Classe TipoCombustivel
 * Descrição: Classe que representa a entidade TipoCombustivel
 * Autor: Lucas José Dias Caetano
 * Data: 22/05/2023
 * Versão: 1.0
 */

using Banco;

namespace Model
{
    public class TipoCombustivel
    {
        public int tipoCombustivelId { get; set; }
        public string nomeCombustivel { get; set; }
        public string descricao { get; set; }
        public string codigo { get; set; }
        public decimal preco { get; set; } 

        public TipoCombustivel()
        {
        }

        public TipoCombustivel(string nomeCombustivel, string descricao, string codigo, decimal preco)
        {
            this.nomeCombustivel = nomeCombustivel;
            this.descricao = descricao;
            this.codigo = codigo;
            this.preco = preco;

            DataBase db = new DataBase();
            db.TiposCombustivel.Add(this);
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
            TipoCombustivel tipoCombustivel = (TipoCombustivel)obj;
            return this.tipoCombustivelId == tipoCombustivel.tipoCombustivelId;
        }

        public override int GetHashCode()
        {
            return this.tipoCombustivelId;
        }

        public override string ToString()
        {
            return "Id: " + this.tipoCombustivelId + " - Nome: " + this.nomeCombustivel + " - Descrição: " + this.descricao + " - Código: " + this.codigo + " - Preço R$" + "\n";
        }

        //------------------- CRUD -------------------//

        public static List<TipoCombustivel> BuscaTipoCombustivel()
        {
            DataBase db = new DataBase();
            List<TipoCombustivel> tiposCombustivel = (from u in db.TiposCombustivel select u).ToList();
            return tiposCombustivel;
        }

        public static TipoCombustivel BuscaTipoCombustivelPorId(int tipoCombustivelId)
        {
            DataBase db = new DataBase();
            return db.TiposCombustivel.Find(tipoCombustivelId);
        }

        public static TipoCombustivel UpdateTipoCombustivel(int tipoCombustivelId, string nomeCombustivel, string descricao, string codigo, decimal preco)
        {
            DataBase db = new DataBase();
            TipoCombustivel tipoCombustivel = db.TiposCombustivel.Find(tipoCombustivelId);
            tipoCombustivel.nomeCombustivel = nomeCombustivel;
            tipoCombustivel.descricao = descricao;
            tipoCombustivel.codigo = codigo;
            tipoCombustivel.preco = preco;
            db.SaveChanges();
            return tipoCombustivel;
        }

        public static void DeleteTipoCombustivel(int tipoCombustivelId)
        {
            DataBase db = new DataBase();
            TipoCombustivel tipoCombustivel = db.TiposCombustivel.Find(tipoCombustivelId);
            db.TiposCombustivel.Remove(tipoCombustivel);
            db.SaveChanges();
        }
    }
}