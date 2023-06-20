/* Módulo Model Fornecedor
 * Classe Fornecedor
 * Descrição: Classe que representa a entidade Fornecedor
 * Autor: Lucas José Dias Caetano
 * Data: 22/05/2023
 * Versão: 1.2
 */

 using Banco;

namespace Model
{
    public class Fornecedor
    {
        public int fornecedorId { get; set; }
        public string nome { get; set; }
        public string contato { get; set; }
        public string endereco { get; set; }
        public int movimentacaoId { get; set; }
        public Movimentacao movimentacao { get; set; }

        public Fornecedor()
        {
        }

        public Fornecedor(string nome, string contato, string endereco, int movimentacaoId)
        {
            this.nome = nome;
            this.contato = contato;
            this.endereco = endereco;
            this.movimentacaoId = movimentacaoId;

            DataBase db = new DataBase();
            db.Fornecedores.Add(this);
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
            Fornecedor fornecedor = (Fornecedor)obj;
            return this.fornecedorId == fornecedor.fornecedorId;
        }

        public override int GetHashCode()
        {
            return this.fornecedorId;
        }

        public override string ToString()
        {
            return "Id: " + this.fornecedorId + " - nome: " + this.nome + " - contato: " + this.contato + " - Endereço: " + this.endereco + " - Movimentacao: " + this.movimentacaoId + "\n";
        }

        //------------------- CRUD -------------------//
       
        public static List<Fornecedor> BuscaFornecedor()
        {
            DataBase db = new DataBase();
            List<Fornecedor> fornecedores = (from u in db.Fornecedores select u).ToList();
            return fornecedores;
        }

        public static Fornecedor BuscaFornecedorPorId(int fornecedorId)
        {
            DataBase db = new DataBase();
            return db.Fornecedores.Find(fornecedorId);
        }

        public static Fornecedor UpdateFornecedor(int fornecedorId, string nome, string contato, string endereco, int movimentacaoId)
        {
            DataBase db = new DataBase();
            Fornecedor fornecedor = db.Fornecedores.Find(fornecedorId);
            fornecedor.nome = nome;
            fornecedor.contato = contato;
            fornecedor.endereco = endereco;
            fornecedor.movimentacaoId = movimentacaoId;
            db.SaveChanges();
            return fornecedor;
        }

        public static void DeleteFornecedor(int fornecedorId)
        {
            DataBase db = new DataBase();
            Fornecedor fornecedor = db.Fornecedores.Find(fornecedorId);
            db.Fornecedores.Remove(fornecedor);
            db.SaveChanges();
        }
    }
}