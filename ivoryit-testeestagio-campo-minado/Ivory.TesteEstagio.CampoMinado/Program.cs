using System;

namespace Ivory.TesteEstagio.CampoMinado
{
    class Program
    {
        static void Main(string[] args)
        {
            var campoMinado = new CampoMinado();
            Console.WriteLine("Início do jogo\n=========");
            Console.WriteLine(campoMinado.Tabuleiro);
            // Realize sua codificação a partir deste ponto, boa sorte!

            // Define as cores padrão do console.
            Console.ForegroundColor = ConsoleColor.White;

            // Variável para armazenar a informação da tecla.
            ConsoleKeyInfo key;

            //Menu para continuação do jogo.
            Console.WriteLine("      -----------------------------------------------------------");
            Console.WriteLine("     |            BEM VINDO AO JOGO CAMPO MINADO                 |");
            Console.WriteLine("     |                                                           |");
            Console.WriteLine("     |   Pressione ENTER para continuar ou ESC para sair do jogo  |");
            Console.WriteLine("      -----------------------------------------------------------");

            // Executa um bloco de instruções para continuar o jogo.
            // Critério de saída: Pressionar tecla ESC.
            do
            {
                // Recebe uma entrada do usuário.
                key = Console.ReadKey(true);

                // Condicional para continuar o jogo.
                if (key.Key == ConsoleKey.Enter)
                {
                    // Executa um bloco de instruções para inserir o número da linha e coluna no tabuleiro.
                    // Condição de saída: Status do jogo diferente de 0 - Em aberto.
                    do
                    {   
                        // Instância da classe MensagensDeErros.
                        var mensagensDeErros = new MensagensDeErros();

                        // Limpa a tela inicial.
                        Console.Clear();

                        // Define as cores padrão do console.
                        Console.ForegroundColor = ConsoleColor.White;

                        // Váriaveis para validar entradas dos valores.
                        bool linhaValida = false;
                        bool colunaValida = false;  
                        bool PosicaoPreechida = false;
                        int linhaInserir = 0;
                        int colunaInserir = 0;

                        // Exibe para o usuário o status do jogo atual.
                        Console.WriteLine(" -------------------------STATUS DO JOGO------------------------------");
                        Console.WriteLine("| Jogo em aberto, continue procurando as casas que não possuem bombas |");
                        Console.WriteLine(" ---------------------------------------------------------------------");

                        // Recebe o tabuleiro para ser formatado.
                        char[,] tabuleiroReverso = ObterTabuleiroReverso(campoMinado.Tabuleiro);

                        // Imprimi um tabuleiro formatado.
                        ImprimirTabaleiroFormatado(tabuleiroReverso);

                        // Executa um bloco de instruções para entradas do usuário.
                        // Condições de saída: Intervelo Linha e Coluna entre 1 e 9, posição informada no tabuleiro não estar preenchida.  
                        do
                        {
                            // Tratativa de exceções.
                            try
                            {   // Enquanto linhaValida for falsa repete o laço para receber entrada do usuário. 
                                while (!(linhaValida))
                                {
                                    // Defini as cores padrão do console.
                                    Console.ResetColor();
                                    Console.Write("\n\nPor favor, selecione a linha no intervalo entre 1 e 9 que deseja abrir: ");
                                    int linha = int.Parse(Console.ReadLine());

                                    // Recebe o resultado valor válido ou inválido. 
                                    linhaValida = ValidarIntervalo(linha);

                                    // Condicional se o valor da linhaValida for falso, fora do intervalo de 1 a 9.
                                    if (!(linhaValida))
                                    {
                                        // Exibe mensagem de erro para valor fora do intervalo.
                                        mensagensDeErros.MensagemErroValorForaDoIntervalo(linha);
                                    }

                                    // Condicional se o retorno for verdadeiro. 
                                    else
                                    {   // Armazena na variável o valor da linha validado.
                                        linhaInserir = linha;
                                    }
                                }

                                // Enquanto ColunaValida for falsa repete o laço para receber uma entrada do usuário.
                                while (!(colunaValida))
                                {
                                    // Defini as cores padrão do console.
                                    Console.ResetColor();
                                    Console.Write("\nPor favor, selecione a coluna no intervalo entre 1 e 9 que deseja abrir: ");
                                    int coluna = int.Parse(Console.ReadLine());

                                    // Recebe o resultado valor válido ou inválido. 
                                    colunaValida = ValidarIntervalo(coluna);

                                    // Condicional se o valor da ColunaValida for falso, fora do intervalo de 1 a 9.
                                    if (!(colunaValida))
                                    {
                                        // Exibe mensagem de erro para valor fora do intervalo.
                                        mensagensDeErros.MensagemErroValorForaDoIntervalo(coluna);
                                    }

                                    else
                                    {   // Armazena na variável o valor da coluna validado.
                                        colunaInserir = coluna;
                                    }
                                }
                            }

                            // Tratativa de exceção - Não armazena a mensagem de erro.
                            catch (Exception)
                            {
                                // Altera cor do texto para amarelo.
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                // Exibe Mensagem de erro para entrada inválida.
                                Console.WriteLine("\n\n\t\tENTRADA INVÁLIDA");
                                Console.WriteLine("\n Você informou um valor fora do intervalo entre 1 e 9 ");
                                continue;
                            }
                         
                            // Recebe se o a posição selecionada está preenchida ou não. 
                            bool resultado = PosicaoPreenchida(tabuleiroReverso, linhaInserir, colunaInserir);

                            // Condicional se a posição está preenchida.
                            if (resultado == true)
                            {
                                // Exibe mensagem de erro para posição já preenchida.
                                mensagensDeErros.MensagemErroPosicaoPreenchida();
                            }

                            // Condicional se a posição não preenchida.
                            else
                            {
                                PosicaoPreechida = false;
                            }

                            // Repete o laço enquanto linhaValida e colunaValida forem falso e posição preenchida verdadeiro.
                        } while ((!linhaValida) && (!colunaValida) && (!PosicaoPreechida));

                        // Função envia os valores para classe CampoMinado - método Abrir os valores da linha e coluna.
                        campoMinado.Abrir(linhaInserir, colunaInserir);

                        // Repetição do laço enquanto o status do jogo for diferente de 2 e 1.
                    } while (campoMinado.JogoStatus != 2 && campoMinado.JogoStatus != 1);

                    // Recebe o tabuleiro para ser formatado.
                    char[,] tabuleiroReversoAtualizado= ObterTabuleiroReverso(campoMinado.Tabuleiro);

                    // Condicional de vitória se o status do jogo for igual 1.
                    if (campoMinado.JogoStatus == 1)
                    {
                        Console.Clear();
                        // Altera a cor do texto para verde.
                        Console.ForegroundColor = ConsoleColor.Green;

                        // Exibe mensagem de vitória para o usuário.
                        Console.WriteLine("\t   ------------------STATUS DO JOGO-----------------");
                        Console.WriteLine("\t  |VOCÊ ENCONTROU TODAS AS CASAS QUE NÃO POSSUI BOMBA|");
                        Console.WriteLine("\t   --------------------------------------------------");

                        // Exibe com todas as casas que não possuem bomba.
                        ImprimirTabaleiroFormatado(tabuleiroReversoAtualizado);

                        Console.WriteLine("\t __   __  ___  _______  _______  ______    ___  _______   __ ");
                        Console.WriteLine("\t|  | |  ||   ||       ||       ||    _ |  |   |    _   | |  | ");
                        Console.WriteLine("\t|  |_|  ||   ||_     _||   _   ||   | ||  |   ||  |_|  | |  | ");
                        Console.WriteLine("\t|       ||   |  |   |  |  | |  ||   |_||_ |   ||       | |  | ");
                        Console.WriteLine("\t|       ||   |  |   |  |  |_|  ||    __  ||   ||       | |__| ");
                        Console.WriteLine("\t |     | |   |  |   |  |       ||   |  | ||   ||   _   |  __  ");
                        Console.WriteLine("\t  |___|  |___|  |___|  |_______||___|  |_||___||__| |__| |__|\n ");  

                        Console.WriteLine(" Pressione ESC para sair do jogo ");

                        // Finaliza a aplicação.
                        Environment.Exit(0);
                    }

                    // Condicional de derrota se o status do jogo não for igual a 1.
                    else
                    {   
                        // Limpa a tela do jogo em aberto.
                        Console.Clear();

                        // Altera a cor do texto para vermelho.
                        Console.ForegroundColor = ConsoleColor.Red;

                        // Exibe mensagem de derrota para o usuário.
                        Console.WriteLine("\t      ----------------STATUS DO JOGO---------------- ");
                        Console.WriteLine("\t     |      GAME OVER, VOCÊ ENCONTROU UMA BOMBA     |");
                        Console.WriteLine("\t      ----------------------------------------------- ");

                        // Exibe o tabuleiro com a posição da bomba.
                        ImprimirTabaleiroFormatado(tabuleiroReversoAtualizado);

                        Console.WriteLine("\t\t _______  _______  _______  __   __   __ ");
                        Console.WriteLine("\t\t|  _    ||       ||       ||  |_|  | |  | ");
                        Console.WriteLine("\t\t| |_|   ||   _   ||   _   ||       | |  | ");
                        Console.WriteLine("\t\t|       ||  | |  ||  | |  ||       | |  | ");
                        Console.WriteLine("\t\t|  _   | |  |_|  ||  |_|  ||       | |__| ");
                        Console.WriteLine("\t\t| |_|   ||       ||       || ||_|| |  __  ");
                        Console.WriteLine("\t\t|_______||_______||_______||_|   |_| |__|\n ");

                        Console.WriteLine(" Pressione ESC para sair do jogo ");
                        
                        // Finaliza a aplicação.
                        Environment.Exit(0);                
                    }
                }
      
                // Repetição do laço enquanto a tecla ESC for falsa.    
            } while (key.Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Obter o tabuleiro da classe CampoMinado.
        /// </summary>   
        static char[,] ObterTabuleiroReverso(string tabuleiro)
        {
            int contadorLinha = 0;
            int contadorColuna = 0;

            char[,] TabuleiroReverso = new char[9, 9];

            // Percorre o tabuleiro até o último caractere. 
            foreach (char caractere in tabuleiro)
            {
                if (caractere != '\r' && caractere != '\n')
                {   
                    // Recebe os caractere diferentes de \r \n.
                    TabuleiroReverso[contadorColuna, contadorLinha] = caractere;
                    
                    // Conta o número de linhas.
                    contadorLinha++;
                }

                else
                {
                    contadorLinha = 0;
                    if (caractere != '\n')
                    {   
                        // Conta o número de colunas.
                        contadorColuna++;
                    }
                    if (contadorColuna >= 9)
                    {
                        contadorColuna = 0;
                    }
                }
            }
            return TabuleiroReverso;
        }

        /// <summary>
        /// Construir um tabuleiro formatado.
        /// </summary>   
        static void ImprimirTabaleiroFormatado(Char[,] TabuleiroReverso)
        {
            // Cabeçalho do tabuleiro.
            Console.WriteLine("\t\t+----------------------------------------+");
            Console.WriteLine("\t\t|JOGO| C | C | C | C | C | C | C | C | C |");
            Console.WriteLine("\t\t|GAME| 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |");
           
            // Loop para formatar e inserir caracteres no tabuleiro.
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("\t\t+----------------------------------------+");

                // Escreve o número da linha.
                int linhaAtual = i + 1;
                Console.Write("\t\t| L" + linhaAtual + "");

                // Loop para inserir caracteres na coluna.
                for (int j = 0; j < 9; j++)
                {
                    Console.Write($" | {TabuleiroReverso[i,j]}");
                }
                 
                Console.WriteLine(" |");
            }
            Console.WriteLine("\t\t+----------------------------------------+");
        }

        /// <summary>
        /// Tabuleiro no formato 9x9.
        /// Verifica se o valor da entrada estar fora do intervalo.
        /// </summary>    
        static bool ValidarIntervalo(int n)
        {

            // Condicional para verificar valor da linha e coluna estar fora dentro do intervalo 1 a 9.
            if (n < 1 || n > 9)
            {
                return false;
            }

            // Retorna o valor válido.
            return true;
        }

        /// <summary>
        /// Verifica se a posição informada já está preenchida no tabuleiro.
        /// </summary>        
        static bool PosicaoPreenchida(Char[,] TabuleiroReverso, int linha, int coluna)
        {

            // Se a posição for igual '-' não há elemento posição. 
            if (TabuleiroReverso[linha - 1, coluna - 1] == '-')
            {
                return false;
            }

            // Posição preenchida com elemento.
            else
            {
                return true;
            }
        }
    }
}


