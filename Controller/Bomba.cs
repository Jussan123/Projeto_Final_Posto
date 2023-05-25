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
        public static Model.Bomba CadastrarBomba( // Cadastra uma bomba
            string TipoCombustivelId, 
            string LimiteMaximo, 
            string LimiteMinimo, 
            string MovimentacaoId)
        {
            int tipoCombustivelIdConvert = 0;
            decimal limiteMaximoConvert = 0;
            decimal limiteMinimoConvert = 0;
            int movimentacaoIdConvert = 0;
            try
            {
                tipoCombustivelIdConvert = int.Parse(TipoCombustivelId);// identifica o tipo de combustivel
                limiteMaximoConvert = decimal.Parse(LimiteMaximo);// insere o limite maximo
                limiteMinimoConvert = decimal.Parse(LimiteMinimo);// insere o limite minimo
                movimentacaoIdConvert = int.Parse(MovimentacaoId);// identifica a movimentação

                Model.Bomba bomba = new Model.Bomba(tipoCombustivelIdConvert, limiteMaximoConvert, limiteMinimoConvert, movimentacaoIdConvert);// Cria uma bomba
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

        public static Model.Bomba AlterarBomba(string bombaId, string TipoCombustivelId, string LimiteMaximo, string LimiteMinimo, string MovimentacaoId)
        {
            int bombaIdConvert = 0;
            int tipoCombustivelIdConvert = 0;
            decimal limiteMaximoConvert = 0;
            decimal limiteMinimoConvert = 0;
            int movimentacaoIdConvert = 0;
            try
            {
                bombaIdConvert = int.Parse(bombaId);
                tipoCombustivelIdConvert = int.Parse(TipoCombustivelId);
                limiteMaximoConvert = decimal.Parse(LimiteMaximo);
                limiteMinimoConvert = decimal.Parse(LimiteMinimo);
                movimentacaoIdConvert = int.Parse(MovimentacaoId);

                Model.Bomba.BuscaBombaPorId(bombaIdConvert);
                return Model.Bomba.UpdateBomba(bombaIdConvert, tipoCombustivelIdConvert, limiteMaximoConvert, limiteMinimoConvert, movimentacaoIdConvert);

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