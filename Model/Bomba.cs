/* Módulo Model Bomba
 * Classe Bomba
 * Descrição: Classe que representa a entidade Bomba
 * Autor: Jussan Igor da Silva
 * Data: 22/04/2023
 * Versão: 1.0
 */

using Banco;

namespace Model
{
    public class Bomba
    {
        public int bombaId { get; set; }
        public int tipoCombustivelId { get; set; }
        public TipoCombustivel TipoCombustivel { get; set; }
        public decimal limiteMaximo { get; set; }
        public decimal limiteMinimo { get; set; }
        public string nomeCombustivel { get; set; }
       //public int movimentacaoId { get; set; }
       //public Movimentacao Movimentacao { get; set; }

        public Bomba()
        {
        }

        public Bomba(int tipoCombustivelId, decimal limiteMaximo, decimal limiteMinimo, string nomeCombustivel)
        {
            this.tipoCombustivelId = tipoCombustivelId;
            this.limiteMaximo = limiteMaximo;
            this.limiteMinimo = limiteMinimo;
            this.nomeCombustivel = nomeCombustivel;
            //this.movimentacaoId = movimentacaoId;

            DataBase db = new DataBase();
            db.Bombas.Add(this);
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
            Bomba bomba = (Bomba)obj;
            return this.bombaId == bomba.bombaId;
        }

        public override int GetHashCode()
        {
            return this.bombaId;
        }

        public override string ToString()
        {
            return "Id: " + this.bombaId + " - Id Tipo Combustivel: " + this.tipoCombustivelId + " - Limite Máximo: " + this.limiteMaximo + " - Limite Mínimo: " + this.limiteMinimo + " - Nome Combustivel: " + this.nomeCombustivel + "\n" ;
        }

        //------------------- CRUD -------------------//

        public static List<Bomba> BuscaBomba()
        {
            DataBase db = new DataBase();
            List<Bomba> bombas = (from u in db.Bombas select u).ToList();
            return bombas;
        }

        public static Bomba BuscaBombaPorId(int bombaId)
        {
            DataBase db = new DataBase();
            Bomba bomba = (from u in db.Bombas where u.bombaId == bombaId select u).FirstOrDefault();
            return bomba;
        }

        public static Bomba UpdateBomba(int bombaId, int tipoCombustivelId, decimal limiteMaximo, decimal limiteMinimo, string nomeCombustivel)
        {
            DataBase db = new DataBase();
            Bomba bomba = db.Bombas.Find(bombaId);
            bomba.tipoCombustivelId = tipoCombustivelId;
            bomba.limiteMaximo = limiteMaximo;
            bomba.limiteMinimo = limiteMinimo;
            bomba.nomeCombustivel = nomeCombustivel;
            //bomba.movimentacaoId = movimentacaoId;
            db.SaveChanges();
            return bomba;
        }

        public static void DeletaBomba(int bombaId)
        {
            DataBase db = new DataBase();
            Bomba bomba = (from u in db.Bombas where u.bombaId == bombaId select u).FirstOrDefault();
            db.Bombas.Remove(bomba);
            db.SaveChanges();
        }
    }
}