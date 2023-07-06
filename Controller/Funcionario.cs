/* Módulo Controller Funcionario
* Descrição: Classe que representa o controller da entidade Funcionario
* Autor: Jussan Igor da Silva
* Data: 23/05/2023
* Versão: 1.0
*/

using Model;
using System.Security.Cryptography;
using System.Text;


namespace Controller
{
    public class Funcionario
    {
        public string funcionarioId { get; set; }
        public string lojaId { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public string funcao { get; set; }
        public string email { get; set; }
        public static Model.Funcionario CadastraFuncionario(
            string nome,
            string senha,
            string funcao,
            int lojaId,
            string email)
        {
            try{
                ValidaSenha(senha);
                if (Model.Loja.BuscaLojaId(lojaId) == null) throw new Exception("Erro ao cadastrar funcionário, loja não encontrada");
                if (Model.Funcionario.BuscaFuncionarioPorEmail(email) != null) throw new Exception("Erro ao cadastrar funcionário, email já cadastrado");
                Model.Funcionario funcionario = new Model.Funcionario(
                    nome,
                    CriptografaSenha(senha),
                    funcao,
                    lojaId,
                    email
                );
                return funcionario;
            } catch (Exception e) {
                throw new Exception($"Erro ao cadastrar funcionário. {e.Message}");
            }
        }

        public static Model.Funcionario AlteraFuncionario(
            int funcionarioId, 
            string nome,
            string senha, 
            string funcao, 
            int lojaId, 
            string email)
        {
            try
            {
                ValidaSenha(senha);
                ValidaEmail(email);
                if (Model.Funcionario.BuscaFuncionarioPorId(funcionarioId) == null) throw new Exception("Erro ao alterar funcionário, funcionário não encontrado");
                if (Model.Loja.BuscaLojaId(lojaId) == null) throw new Exception("Erro ao alterar funcionário, loja não encontrada");
                if (Model.Funcionario.BuscaFuncionarioPorEmail(email) != null) throw new Exception("Erro ao alterar funcionário, email já cadastrado");
                Model.Funcionario funcionario = new Model.Funcionario();
                return Model.Funcionario.UpdateFuncionario(
                    funcionarioId,
                    nome,
                    CriptografaSenha(senha),
                    funcao,
                    lojaId,
                    email
                );
            } catch (Exception e) {
                throw new Exception($"Erro ao alterar funcionário {e.Message}");
            }
        }

        public static List<Model.Funcionario> ListaFuncionario()
        {
            try
            {
                return Model.Funcionario.BuscaFuncionario();
            } catch (Exception) {
                throw new Exception("Erro ao listar funcionários");
            }
        }

        public static Model.Funcionario BuscaFuncionarioPorId(string funcionarioId)
        {
            try
            {
                return Model.Funcionario.BuscaFuncionarioPorId(int.Parse(funcionarioId));
            } catch (Exception) {
                throw new Exception("Erro ao buscar funcionário");
            }
        }

        public static Model.Funcionario BuscaFuncionarioPorEmail(string email)
        {
            try
            {
                return Model.Funcionario.BuscaFuncionarioPorEmail(email);
            } catch (Exception) {
                throw new Exception("Erro ao buscar funcionário");
            }
        }

        public static Model.Funcionario BuscaFuncionarioPorFuncao(string funcao)
        {
            try
            {
                return Model.Funcionario.BuscaFuncionarioPorFuncao(funcao);
            } catch (Exception) {
                throw new Exception("Erro ao buscar funcionário");
            }
        }

        public static void ExcluiFuncionario(string funcionarioId)
        {
            try
            {
                if (Model.Funcionario.BuscaFuncionarioPorId(int.Parse(funcionarioId)) == null) throw new Exception("Erro ao excluir funcionário, funcionário não encontrado");
                Model.Funcionario.DeleteFuncionario(int.Parse(funcionarioId));
            } catch (Exception) {
                throw new Exception("Erro ao excluir funcionário");
            }
        }

        public static bool Logar(string email, string senha)
        {
            try
            {
                Model.Funcionario funcionario = Model.Funcionario.BuscaFuncionarioPorEmail(email);
                if (funcionario == null) throw new Exception("Erro ao logar, funcionário não encontrado");
                if (BCrypt.Net.BCrypt.Verify(senha, funcionario.senha)) throw new Exception("Erro ao logar, senha incorreta");
                return true;
            } catch (Exception) {
                throw new Exception("Erro ao logar");
            }
        }

        private static void ValidaSenha(string senha)//Método para validar a senha do funcionário
        {
            if (senha.Length < 8) throw new Exception("Erro ao cadastrar funcionário, senha deve conter no mínimo 8 caracteres");//Verifica se a senha tem no mínimo 8 caracteres
            if (!senha.Any(char.IsUpper)) throw new Exception("Erro ao cadastrar funcionário, senha deve conter no mínimo 1 letra maiúscula");//Verifica se a senha tem no mínimo 1 letra maiúscula
            if (!senha.Any(char.IsLower)) throw new Exception("Erro ao cadastrar funcionário, senha deve conter no mínimo 1 letra minúscula");//Verifica se a senha tem no mínimo 1 letra minúscula
            if (!senha.Any(char.IsDigit)) throw new Exception("Erro ao cadastrar funcionário, senha deve conter no mínimo 1 número");//Verifica se a senha tem no mínimo 1 número
            if (!(senha.Any(char.IsSymbol) || senha.Any(char.IsPunctuation))) throw new Exception("Erro ao cadastrar funcionário, senha deve conter no mínimo 1 caractere especial");//Verifica se a senha tem no mínimo 1 caractere especial
        }

        private static void ValidaEmail(string email)
        {
            if (!email.Contains("@")) throw new Exception("Erro ao cadastrar funcionário, email inválido");//Verifica se o email contém @
            if (!email.Contains(".")) throw new Exception("Erro ao cadastrar funcionário, email inválido");//Verifica se o email contém .
        }

        private static string CriptografaSenha(string senha)//Método para criptografar a senha do funcionário
        {
            return BCrypt.Net.BCrypt.HashPassword(senha, BCrypt.Net.BCrypt.GenerateSalt(12));
        }
    }
}