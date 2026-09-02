using System;
using System.Collections.Generic;


namespace AlimentacaoSaudavel
{
    class Program
    {
        // pontuaçao
        static int pontosPrato = 0;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool continuar = true;

            while (continuar)
            {
                MostrarMenuPrincipal();
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        MontarPrato();
                        break;
                    case "2":
                        MostrarDicas();
                        break;
                    case "3":
                        IniciarQuiz();
                        break;
                    case "4":
                        continuar = false;
                        Console.WriteLine("\nObrigado por usar o programa! Cuide bem da sua alimentação. :)");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida! Tente novamente.\n");
                        break;
                }
            }
        }

       
        // menu
        
        static void MostrarMenuPrincipal()
        {
            Console.WriteLine("=====================================================");
            Console.WriteLine("     ALIMENTAÇÃO SAUDÁVEL - ESCOLHAS CONSCIENTES");
            Console.WriteLine("=====================================================");
            Console.WriteLine("1 - Montar um prato saudável");
            Console.WriteLine("2 - Ver dicas de alimentação saudável");
            Console.WriteLine("3 - Fazer o quiz educativo");
            Console.WriteLine("4 - Sair");
            Console.WriteLine("=====================================================");
            Console.Write("Escolha uma opção: ");
        }

        
        // montagem prato
        
        static void MontarPrato()
        {
            pontosPrato = 0;

            Console.WriteLine("\n--- Vamos montar o seu prato! ---");
            Console.WriteLine("Escolha uma opção em cada categoria.\n");

            // categoria e pontuação

            string[] proteinas = { "Frango grelhado", "Ovo cozido", "Feijão", "Carne empanada frita", "Salsicha/linguiça" };
            int[] pontosProteinas = { 2, 2, 2, 0, 0 };

            string[] carboidratos = { "Arroz integral", "Arroz branco", "Batata frita", "Macarrão integral", "Pão branco" };
            int[] pontosCarboidratos = { 2, 1, 0, 2, 0 };

            string[] vegetais = { "Salada verde (alface, rúcula...)", "Legumes cozidos no vapor", "Nenhum vegetal" };
            int[] pontosVegetais = { 2, 2, 0 };

            string[] bebidas = { "Água", "Suco natural sem açúcar", "Refrigerante", "Suco em pó/artificial" };
            int[] pontosBebidas = { 2, 2, 0, 0 };

            EscolherCategoria("PROTEÍNA", proteinas, pontosProteinas);
            EscolherCategoria("CARBOIDRATO", carboidratos, pontosCarboidratos);
            EscolherCategoria("VEGETAL", vegetais, pontosVegetais);
            EscolherCategoria("BEBIDA", bebidas, pontosBebidas);

            MostrarResultadoPrato();
        }

        // mostra os itens, le a escolha e soma
        static void EscolherCategoria(string nomeCategoria, string[] itens, int[] pontos)
        {
            Console.WriteLine($"--- {nomeCategoria} ---");

            for (int i = 0; i < itens.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {itens[i]}");
            }

            int escolha = LerOpcaoValida(itens.Length);

           
            pontosPrato += pontos[escolha - 1];

            Console.WriteLine($"Você escolheu: {itens[escolha - 1]}\n");
        }

        // numero valido
        static int LerOpcaoValida(int totalOpcoes)
        {
            int numero;
            bool valido = int.TryParse(Console.ReadLine(), out numero);

            while (!valido || numero < 1 || numero > totalOpcoes)
            {
                Console.Write($"Opção inválida. Digite um número de 1 a {totalOpcoes}: ");
                valido = int.TryParse(Console.ReadLine(), out numero);
            }

            return numero;
        }

        // resultado final do prato
        static void MostrarResultadoPrato()
        {
            Console.WriteLine("=====================================================");
            Console.WriteLine($"Pontuação do seu prato: {pontosPrato} de 8 pontos possíveis");

            if (pontosPrato >= 7)
            {
                Console.WriteLine("Resultado: EXCELENTE! Seu prato está muito equilibrado e saudável.");
            }
            else if (pontosPrato >= 4)
            {
                Console.WriteLine("Resultado: BOM! Seu prato tem boas escolhas, mas ainda pode melhorar.");
            }
            else
            {
                Console.WriteLine("Resultado: ATENÇÃO! Tente incluir mais itens naturais e menos processados.");
            }
            Console.WriteLine("=====================================================\n");
        }

        
        // dicas
       
        static void MostrarDicas()
        {
            List<string> dicas = new List<string>
            {
                "Beba bastante água durante o dia, evitando refrigerantes.",
                "Prefira alimentos naturais a alimentos ultraprocessados.",
                "Inclua frutas e vegetais em pelo menos duas refeições por dia.",
                "Evite pular refeições, principalmente o café da manhã.",
                "Modere o consumo de açúcar e frituras.",
                "Preste atenção nos rótulos dos alimentos antes de comprar.",
                "Coma devagar e preste atenção aos sinais de fome e saciedade."
            };

            Console.WriteLine("\n--- Dicas de Alimentação Saudável ---");
            foreach (string dica in dicas)
            {
                Console.WriteLine("- " + dica);
            }
            Console.WriteLine();
        }

         
        // quiz
       
        static void IniciarQuiz()
        {
            string[] perguntas =
            {
                "Qual desses alimentos é considerado ultraprocessado?",
                "Qual é a bebida mais recomendada para se manter hidratado?",
                "Qual desses grupos alimentares fornece mais fibras?",
                "Pular refeições faz bem para a saúde?",
                "O que é importante verificar antes de comprar um alimento industrializado?"
            };

            string[][] alternativas =
            {
                new string[] { "Maçã", "Salgadinho de pacote", "Feijão", "Ovo" },
                new string[] { "Refrigerante", "Água", "Suco artificial", "Energético" },
                new string[] { "Frituras", "Doces", "Vegetais e frutas", "Refrigerantes" },
                new string[] { "Sim, sempre", "Não, o ideal é manter uma rotina alimentar", "Sim, se for à noite", "Não tem importância" },
                new string[] { "A cor da embalagem", "O rótulo com ingredientes e nutrientes", "O preço apenas", "A marca apenas" }
            };

            int[] respostasCorretas = { 2, 2, 3, 2, 2 }; 

            int acertos = 0;

            Console.WriteLine("\n--- Quiz Educativo: Alimentação Saudável ---\n");

            for (int i = 0; i < perguntas.Length; i++)
            {
                Console.WriteLine($"Pergunta {i + 1}: {perguntas[i]}");

                for (int j = 0; j < alternativas[i].Length; j++)
                {
                    Console.WriteLine($"{j + 1} - {alternativas[i][j]}");
                }

                int resposta = LerOpcaoValida(alternativas[i].Length);

                if (resposta == respostasCorretas[i])
                {
                    Console.WriteLine("Resposta correta!\n");
                    acertos++;
                }
                else
                {
                    string correta = alternativas[i][respostasCorretas[i] - 1];
                    Console.WriteLine($"Resposta errada. A correta era: {correta}\n");
                }
            }

            MostrarResultadoQuiz(acertos, perguntas.Length);
        }

        // resultado final
        static void MostrarResultadoQuiz(int acertos, int totalPerguntas)
        {
            Console.WriteLine("=====================================================");
            Console.WriteLine($"Você acertou {acertos} de {totalPerguntas} perguntas.");

            double porcentagem = (double)acertos / totalPerguntas * 100;

            if (porcentagem >= 80)
            {
                Console.WriteLine("Parabéns! Você entende muito bem sobre alimentação saudável.");
            }
            else if (porcentagem >= 50)
            {
                Console.WriteLine("Bom trabalho! Mas ainda há espaço para aprender mais sobre o tema.");
            }
            else
            {
                Console.WriteLine("Vale a pena estudar mais sobre alimentação saudável. Volte a este quiz depois!");
            }
            Console.WriteLine("=====================================================\n");
        }
    }
}
