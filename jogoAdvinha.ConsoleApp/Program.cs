namespace jogoAdvinha.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($" Bem-Vindo(a) {System.Environment.MachineName}");
            Console.WriteLine(" ####################################");
            Console.WriteLine(" ### Exercicio advinhação numeros ###");
            Console.WriteLine(" ####################################");
            Console.WriteLine(" ");

            Random eventoAleatorio = new Random();
            int numAleatorio = eventoAleatorio.Next(1, 20);

            int tentativas = 0;
            int pontos = 1000;

            tentativas = SelecionaDificuldade(tentativas);

            int tentativasIniciais = tentativas;

            LogicaJogo(numAleatorio, ref tentativas, ref pontos, ref tentativasIniciais);

            Console.ReadLine();
        }

        private static int SelecionaDificuldade(int tentativas)
        {
            Console.WriteLine("Selecione a dificuldade: (1)facil, (2) medio, (3) dificil");
            int dificuldade = Convert.ToInt32(Console.ReadLine());

            if (dificuldade == 1)
            {
                tentativas = 15;
            }
            else if (dificuldade == 2)
            {
                tentativas = 10;
            }
            else if (dificuldade == 3)
            {
                tentativas = 5;
            }

            return tentativas;
        }

        private static void LogicaJogo(int numAleatorio, ref int tentativas, ref int pontos, ref int tentativasIniciais)
        {
            while (tentativas != 0)
            {
                Console.WriteLine($"Tentativas restantes {tentativas}");

                Console.WriteLine("Informe um numero");
                int numeroAdvinha = Convert.ToInt32(Console.ReadLine());

                if (numeroAdvinha < 1 || numeroAdvinha > 20)
                {
                    Console.Clear();
                    Console.WriteLine("Apenas numeros entre 1 e 20 sao aceitos");
                    continue;
                }
                else if (numeroAdvinha < numAleatorio)
                {
                    Console.Clear();
                    Console.WriteLine("o numero informado eh MENOR");
                    pontos -= Math.Abs((numeroAdvinha - numAleatorio) / 2);
                    tentativas--;
                    continue;
                }
                else if (numeroAdvinha > numAleatorio)
                {
                    Console.Clear();
                    Console.WriteLine("o numero informado eh MAIOR");
                    pontos -= Math.Abs((numeroAdvinha - numAleatorio) / 2);
                    tentativas--;
                    continue;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"### Parabens {System.Environment.MachineName} ###");
                    Console.WriteLine($"você acertou o numero ({numAleatorio})");
                    Console.WriteLine($"sua pontuacao foi de {pontos} e voce usou {tentativasIniciais -= tentativas} tentativas");
                    break;
                }

            }
        }

    }
}
