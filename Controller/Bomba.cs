/* Módulo Controller da Bomba
 * Classe Bomba
 * Descrição: Classe que representa o controller da entidade Bomba
 * Autor: Lucas José Dias Caetano
 * Data: 23/05/2023
 * Versão: 1.0
 */

using Model;

namespace Controller
{
    public class Bomba
    {
        public string tipoCombustivelId { get; set; }
        public string limiteMaximo { get; set; }
        public string limiteMinimo { get; set; } 
        public string nomeCombustivel { get; set; }
        public static Model.Bomba CadastrarBomba( // Cadastra uma bomba
            string tipoCombustivelId, 
            string limiteMaximo, 
            string limiteMinimo,
            string nomeCombustivel) 
            //string MovimentacaoId)
        {
            int tipoCombustivelIdConvert = 0;
            decimal limiteMaximoConvert = 0;
            decimal limiteMinimoConvert = 0;
            //int movimentacaoIdConvert = 0;
            try
            {
                tipoCombustivelIdConvert = int.Parse(tipoCombustivelId);// identifica o tipo de combustivel
                limiteMaximoConvert = decimal.Parse(limiteMaximo);// insere o limite maximo
                limiteMinimoConvert = decimal.Parse(limiteMinimo);// insere o limite minimo
                //movimentacaoIdConvert = int.Parse(MovimentacaoId);// identifica a movimentação

                Model.Bomba bomba = new Model.Bomba(tipoCombustivelIdConvert, limiteMaximoConvert, limiteMinimoConvert, nomeCombustivel);// Cria uma bomba
                return bomba;
            }
            catch (FormatException ex)// Erro de formato
            {
                throw new ArgumentException("Erro ao cadastrar bomba: Valor inválido encontrado.", ex);
            }
            catch (OverflowException ex)// quando um valor excede o intervalo ou a capacidade permitida
            {
                throw new ArgumentException("Erro ao cadastrar bomba: Valor fora do intervalo válido.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar bomba: " + ex.Message, ex);
            }
        }


        public static Model.Bomba BuscaBombaPorId(string BombaId)
        {
            int bombaIdConvert = 0;
            try
            {
                bombaIdConvert = int.Parse(BombaId);
            } catch (System.Exception)
            {
                throw new System.Exception("Bomba inválida");
            }
            Model.Bomba bomba = Model.Bomba.BuscaBombaPorId(bombaIdConvert);
            return bomba;
        }

        public static Model.Bomba AlterarBomba(string bombaId, string tipoCombustivelId, string limiteMaximo, string limiteMinimo, string nomeCombustivel)
        {
            int bombaIdConvert = 0;
            int tipoCombustivelIdConvert = 0;
            decimal limiteMaximoConvert = 0;
            decimal limiteMinimoConvert = 0;
            //int movimentacaoIdConvert = 0;
            try
            {
                bombaIdConvert = int.Parse(bombaId);
                tipoCombustivelIdConvert = int.Parse(tipoCombustivelId);
                limiteMaximoConvert = decimal.Parse(limiteMaximo);
                limiteMinimoConvert = decimal.Parse(limiteMinimo);
                //movimentacaoIdConvert = int.Parse(MovimentacaoId);

                Model.Bomba.BuscaBombaPorId(bombaIdConvert);
                return Model.Bomba.UpdateBomba(bombaIdConvert, tipoCombustivelIdConvert, limiteMaximoConvert, limiteMinimoConvert, nomeCombustivel);

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

        public static List<Model.Bomba> ListarBombas()
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

        public static void DeletaBomba(int bombaId)
        {
            try
            {
                Model.Bomba.DeletaBomba(bombaId);
            } catch (System.Exception)
            {
                throw new System.Exception("Bomba inválida");
            }
        }
    }
}