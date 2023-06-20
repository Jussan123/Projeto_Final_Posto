/* Módulo Model Bomba
 * Classe Bomba
 * Descrição: Classe que representa a entidade Bomba
 * Autor: Jussan Igor da Silva
 * Data: 22/04/2023
 * Versão: 1.0
 */

using Banco;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class Bomba
    {
        public int bombaId { get; set; }
        public int combustivelId { get; set; }
        public virtual Combustivel combustivel { get; set; }
        public decimal limiteMaximo { get; set; }
        public decimal limiteMinimo { get; set; }
        public int movimentacaoId { get; set; }
        public Movimentacao movimentacao { get; set; }
        public int lojaId { get; set; }
        public Loja loja { get; set; }

        public Bomba()
        {
        }

        public Bomba(int combustivelId, decimal limiteMaximo, decimal limiteMinimo, int movimentacaoId, int lojaId)
        {
            this.combustivelId = combustivelId;
            this.limiteMaximo = limiteMaximo;
            this.limiteMinimo = limiteMinimo;
            this.movimentacaoId = movimentacaoId;
            this.lojaId = lojaId;

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
            return "Id: " + this.bombaId + " - Id Tipo Combustivel: " + this.combustivelId + " - Limite Máximo: " + this.limiteMaximo + " - Limite Mínimo: " + this.limiteMinimo + " - Combustivel: " + this.combustivelId + " - Loja: " + this.lojaId + "\n" ;
        }

        //------------------- CRUD -------------------//
        public static IEnumerable<Bomba> BuscaBomba()
        {
            DataBase db = new DataBase();
            return db.Bombas.Include(b => b.combustivel).Include(b => b.loja);
        }

        public static Bomba BuscaBombaPorId(int bombaId)
        {
            DataBase db = new DataBase();
            Bomba bomba = (from u in db.Bombas where u.bombaId == bombaId select u).FirstOrDefault();
            return bomba;
        }

        public static Bomba UpdateBomba(int bombaId, int combustivelId, decimal limiteMaximo, decimal limiteMinimo, int movimentacaoId, int lojaId)
        {
            DataBase db = new DataBase();
            Bomba bomba = db.Bombas.Find(bombaId);
            bomba.combustivelId = combustivelId;
            bomba.limiteMaximo = limiteMaximo;
            bomba.limiteMinimo = limiteMinimo;
            bomba.movimentacaoId = movimentacaoId;
            bomba.lojaId = lojaId;
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