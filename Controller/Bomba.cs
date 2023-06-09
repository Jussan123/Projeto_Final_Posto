/* Módulo Controller da Bomba
 * Classe Bomba
 * Descrição: Classe que representa o controller da entidade Bomba
 * Autor: Lucas José Dias Caetano
 * Data: 23/05/2023
 * Versão: 1.0
 */

using Model;
using System.Linq;

namespace Controller
{
    public class Bomba
    {
        public string combustivelId { get; set; }
        public string limiteMaximo { get; set; }
        public string limiteMinimo { get; set; } 
        public string lojaId { get; set; }
        public string bombaId { get; set; }
        public string volume { get; set; }

        public static Model.Bomba CadastrarBomba( // Cadastra uma bomba
            string combustivelId, 
            string limiteMaximo, 
            string limiteMinimo,
            string volume,
            string lojaId) 
        {
            try
            {
                if(Model.Combustivel.BuscaCombustivelPorId(int.Parse(combustivelId)) == null) throw new System.Exception("Combustível inválido");
                int combustivelIdConvert = int.Parse(combustivelId);// identifica o tipo de combustivel
                decimal limiteMaximoConvert = decimal.Parse(limiteMaximo);// insere o limite maximo
                decimal limiteMinimoConvert = decimal.Parse(limiteMinimo);// insere o limite minimo
                decimal volumeConvert = decimal.Parse(volume);// insere o volume
                int lojaIdConvert = int.Parse(lojaId);// identifica a loja

                Model.Bomba bomba = new Model.Bomba(combustivelIdConvert, limiteMaximoConvert, limiteMinimoConvert, volumeConvert, lojaIdConvert);// Cria uma bomba
                return bomba;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar bomba: " + ex.Message, ex);
            }
        }


        public static Model.Bomba BuscaBombaPorId(string bombaId)
        {
            int bombaIdConvert = 0;
            try
            {
                bombaIdConvert = int.Parse(bombaId);
            } catch (System.Exception)
            {
                throw new System.Exception("Bomba inválida");
            }
            Model.Bomba bomba = Model.Bomba.BuscaBombaPorId(bombaIdConvert);
            return bomba;
        }

        public static Model.Bomba AlterarBomba(string bombaId, string combustivelId, string limiteMaximo, string limiteMinimo, string volume)
        {
            try
            {
                int bombaIdConvert = int.Parse(bombaId);
                int combustivelIdConvert = int.Parse(combustivelId);
                decimal limiteMaximoConvert = decimal.Parse(limiteMaximo);
                decimal limiteMinimoConvert = decimal.Parse(limiteMinimo);
                decimal volumeConvert = decimal.Parse(volume);
                

                Model.Bomba.BuscaBombaPorId(bombaIdConvert);
                return Model.Bomba.UpdateBomba(bombaIdConvert, combustivelIdConvert, limiteMaximoConvert, limiteMinimoConvert, volumeConvert);

            }
            catch (FormatException ex)
            {
                throw new ArgumentException("Erro ao alterar bomba: Valor inválido encontrado.", ex);
            }
            catch (OverflowException ex)
            {
                throw new ArgumentException("Erro ao alterar bomba: Valor fora do intervalo válido.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar bomba: " + ex.Message, ex);
            }
        }

        public static IEnumerable<Model.Bomba> ListarBombas()
        {
            return Model.Bomba.BuscaBomba();
        }

        public static Model.Bomba EncontraBomba(int bombaId)
        {
            try
            {
                return Model.Bomba.BuscaBombaPorId(bombaId);
            } catch (System.Exception)
            {
                throw new System.Exception("Bomba inválida");
            }
        }

        public static void DeletaBomba(string bombaId)
        {
            try
            {
                int bombaIdConvert = int.Parse(bombaId);
                Model.Bomba.DeletaBomba(bombaIdConvert);
            } catch (System.Exception)
            {
                throw new System.Exception("Bomba inválida");
            }
        }
    }
}