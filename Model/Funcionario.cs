/* Módulo Model Funcionario
 * Classe Funcionario
 * Descrição: Classe que representa a entidade Funcionario
 * Autor: Lucas José Dias Caetano
 * Data: 22/05/2023
 * Versão: 1.0
 */

using Banco;

namespace Model
{
    public class Funcionario
    {
        public int funcionarioId { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public string funcao { get; set; }
        public int lojaId { get; set; }
        public Loja loja { get; set; }
        public string email { get; set; }

        public Funcionario()
        {
        }

        public Funcionario(string nome, string senha, string funcao, int lojaId, string email)
        {
            this.nome = nome;
            this.senha = senha;
            this.funcao = funcao;
            this.lojaId = lojaId;
            this.email = email;

            DataBase db = new DataBase();
            db.Funcionarios.Add(this);
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
            Funcionario funcionario = (Funcionario)obj;
            return this.funcionarioId == funcionario.funcionarioId;
        }

        public override int GetHashCode()
        {
            return this.funcionarioId;
        }

        public override string ToString()
        {
            return "Id: " + this.funcionarioId + " - nome: " + this.nome + " - senha: " + this.senha + " - Função: " + this.funcao + " - Id loja: " + this.lojaId + " - E-Mail: " + this.email + "\n" ;
        }

        //------------------- CRUD -------------------//

        public static List<Funcionario> BuscaFuncionario()
        {
            DataBase db = new DataBase();
            List<Funcionario> funcionarios = (from u in db.Funcionarios select u).ToList();
            return funcionarios;
        }

        public static Funcionario BuscaFuncionarioPorId(int funcionarioId)
        {
            DataBase db = new DataBase();
            return db.Funcionarios.Find(funcionarioId);
        }

        public static Funcionario BuscaFuncionarioPorEmail(string email)
        {
            DataBase db = new DataBase();
            return db.Funcionarios.Where(x => x.email == email).FirstOrDefault();
        }

        public static Funcionario BuscaFuncionarioPorFuncao(string funcao)
        {
            DataBase db = new DataBase();
            return db.Funcionarios.Where(x => x.funcao == funcao).FirstOrDefault();
        }
        
        public static Funcionario UpdateFuncionario(int funcionarioId, string nome, string senha, string funcao, int lojaId, string email)
        {
            DataBase db = new DataBase();
            Funcionario funcionario = db.Funcionarios.Find(funcionarioId);
            funcionario.nome = nome;
            funcionario.senha = senha;
            funcionario.funcao = funcao;
            funcionario.lojaId = lojaId;
            funcionario.email = email;
            db.SaveChanges();
            return funcionario;
        }

        public static void DeleteFuncionario(int funcionarioId)
        {
            DataBase db = new DataBase();
            Funcionario funcionario = db.Funcionarios.Find(funcionarioId);
            db.Funcionarios.Remove(funcionario);
            db.SaveChanges();
        }
    }
}