/* Módulo Model Loja
 * Classe Loja
 * Descrição: Classe que representa a entidade Loja
 * Autor: Jussan Igor da Silva
 * Data: 22/05/2023
 * Versão: 1.0
 */

using Banco;

namespace Model
{
    public class Loja
    {
        public int lojaId { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }

        public Loja()
        {
        }

        public Loja(string nome, string endereco, string telefone, string email)
        {
            this.nome = nome;
            this.endereco = endereco;
            this.telefone = telefone;
            this.email = email;

            DataBase db = new DataBase();
            db.Lojas.Add(this);
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
            Loja loja = (Loja)obj;
            return this.lojaId == loja.lojaId;
        }

        public override int GetHashCode()
        {
            return this.lojaId;
        }

        public override string ToString()
        {
            return "Id: " + this.lojaId + " - nome: " + this.nome + " - Endereço: " + this.endereco + " - telefone: " + this.telefone + " - email: " + this.email + "\n" ;
        }

        //------------------- CRUD -------------------//

        public static List<Loja> BuscaLoja()
        {
            DataBase db = new DataBase();
            List<Loja> lojas = (from u in db.Lojas select u).ToList();
            return lojas;
        }

        public static Loja BuscaLojaId(int lojaId)
        {
            DataBase db = new DataBase();
            return db.Lojas.Find(lojaId);
        }

        public static Loja UpdateLoja(int lojaId, string nome, string endereco, string telefone, string email)
        {
            DataBase db = new DataBase();
            Loja loja = db.Lojas.Find(lojaId);
            loja.nome = loja.nome;
            loja.endereco = loja.endereco;
            loja.telefone = loja.telefone;
            loja.email = loja.email;
            db.SaveChanges();
            return loja;
        }

        public static void DeleteLoja(int lojaId)
        {
            DataBase db = new DataBase();
            Loja loja = db.Lojas.Find(lojaId);
            db.Lojas.Remove(loja);
            db.SaveChanges();
        }
    }
}