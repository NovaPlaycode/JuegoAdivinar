using System;

namespace JuegoAdivinar
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Configuracion inicial
            Random random = new Random();
            int numeroSecreto = random.Next(1, 101); // Genera numeros entre el 1 y el 100
            int intentosRestantes = 10;
            bool haGanado = false;

            Console.WriteLine("--- Bienvenido al desafio de adivinar el numero secreto ---");
            Console.WriteLine("He pensado un numero entre el 1 y el 100");
            Console.WriteLine($"Tienes {intentosRestantes} intentos restantes.");

            // 2. El bucle del juego (Mientras tenga intentos y no haya ganado)
            while (intentosRestantes > 0 && !haGanado)
            {
                Console.Write("Introduce tu numero: ");
                string input = Console.ReadLine();
                int guess;

                // 3. Control de errores  (Para que no explote si metes letras)
                if (int.TryParse(input, out guess))
                {
                    if (guess == numeroSecreto)
                    {
                        Console.WriteLine("¡Brutal! Has ganado. Cada día estás más cerca de tu objetivo.");
                        haGanado = true;
                    }
                    else if (guess < numeroSecreto)
                    {
                        intentosRestantes--;
                        Console.WriteLine("Demasiado bajo.");
                        Console.WriteLine($"Intentos restantes: {intentosRestantes}");
                    }
                    else // guess > numeroSecreto
                    {
                        intentosRestantes--;
                        Console.WriteLine("Demasiado alto.");
                        Console.WriteLine($"Intentos restantes: {intentosRestantes}");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor introduce un número entero.");
                }
            }

            if (!haGanado)
            {
                Console.WriteLine($"Se han agotado los intentos. El número secreto era: {numeroSecreto}");
            }

            // 4. Fin del juego
            if ( haGanado)
            {
                Console.WriteLine("¡Felicidades! Has adivinado el número secreto.");
            }
            else
            {
                Console.WriteLine("Game Over ¡Inténtalo de nuevo la próxima vez!");
                Console.ReadKey();
            }
        }
    }
}