using System;
using System.Collections.Generic;
using System.Text;

namespace Ivory.TesteEstagio.CampoMinado
{
    public class MensagensDeErros
    {
        /// <summary>
        /// Exibe mensagem de erro para o usuário.
        /// Valor informado fora do intervalo entre 1 e 9.
        /// </summary>  
       public void MensagemErroValorForaDoIntervalo(int valor)
        {
            // Altera cor do texto para amarelo.
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Escreve Mensagem de erro para entrada inválida.
            Console.WriteLine("\n\n\t\tENTRADA INVÁLIDA");
            Console.WriteLine("\n\t\tA entrada: {0} é inválida", valor);
            Console.WriteLine("\n\tPor favor informe uma entrada entre 1 e 9");
            Console.ReadKey();
        }

        /// <summary>
        /// Exibe mensagem de erro para o usuário.
        /// Posição do Linha x Coluna já preenchida.
        /// </summary>  
       public void MensagemErroPosicaoPreenchida()
        {
            // Altera a cor do texto para amarelo.
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Escreve mensagem de erro para posição já preenchida.
            Console.WriteLine("\n\n\t\tPOSIÇÃO JÁ PREENCHIDA NO TABULEIRO");
            Console.WriteLine("\n\tPor favor, informe novas entradas não preenchidas");
            Console.ReadKey();
        }
    }
}
