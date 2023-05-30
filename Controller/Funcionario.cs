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
        public static Model.Funcionario CadastraFuncionario(
            string nome,
            string senha,
            string funcao,
            string lojaId,
            string email)
        {
            try{
                CriptografaSenha(senha);
                if (Model.Loja.BuscaLojaId(int.Parse(lojaId)) == null) throw new Exception("Erro ao cadastrar funcionário, loja não encontrada");
                Model.Funcionario funcionario = new Model.Funcionario(
                    nome,
                    senha,
                    funcao,
                    int.Parse(lojaId),
                    email
                );
                return funcionario;
            } catch (Exception) {
                throw new Exception("Erro ao cadastrar funcionário");
            }
        }

        public static Model.Funcionario AlteraFuncionario(
            string funcionarioId, 
            string nome,
            string senha, 
            string funcao, 
            string lojaId, 
            string email)
        {
            try
            {
                CriptografaSenha(senha);
                if (Model.Funcionario.BuscaFuncionarioPorId(int.Parse(funcionarioId)) == null) throw new Exception("Erro ao alterar funcionário, funcionário não encontrado");
                if (Model.Loja.BuscaLojaId(int.Parse(lojaId)) == null) throw new Exception("Erro ao alterar funcionário, loja não encontrada");
                return Model.Funcionario.UpdateFuncionario(
                    int.Parse(funcionarioId),
                    nome,
                    senha,
                    funcao,
                    int.Parse(lojaId),
                    email
                );
            } catch (Exception) {
                throw new Exception("Erro ao alterar funcionário");
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

        private static bool Logar(string email, string senha)
        {
            try
            {
                Model.Funcionario funcionario = Model.Funcionario.BuscaFuncionarioPorEmail(email);
                CriptografaSenha(senha);
                if (funcionario == null) throw new System.Exception("Erro ao logar, funcionário não encontrado");
                if (funcionario.senha != senha) throw new System.Exception("Erro ao logar, senha incorreta");
                return true;
            } catch (System.Exception) {
                throw new System.Exception("Erro ao logar");
                return false;
            }
        }



        private static string CriptografaSenha(string senha)//Método para criptografar a senha do funcionário
        {
            try
            {
                using (SHA256 sha256 = SHA256.Create())//Cria um objeto SHA256(Secure Hash Algorithm 256 bits) para criptografar a senha do funcionário
                // SHA256 refere-se a um algoritmo de hash criptográfico que calcula o hash de 256 bits de uma entrada arbitrária
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(senha);// Converte a senha em bytes
                    byte[] hash = sha256.ComputeHash(bytes);// Calcula o hash dos bytes

                    StringBuilder builder = new StringBuilder();// Cria um objeto StringBuilder para armazenar o hash
                    for (int i = 0; i < hash.Length; i++)// Percorre o hash
                    {
                        builder.Append(hash[i].ToString("X2"));// Converte o hash em hexadecimal e adiciona ao objeto StringBuilder
                    }
                    return builder.ToString();// Retorna o hash criptografado
                }
            } catch (Exception) {
                throw new Exception("Erro ao criptografar senha");// Caso ocorra algum erro, retorna uma mensagem de erroMemoria
            }
        }
    }
}