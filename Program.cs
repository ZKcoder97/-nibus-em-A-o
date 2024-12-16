using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulaçãoOnibus
{
    internal class Program
    {
        static string Ligar(bool motor, int velocidade)
        {
             string situacaoMotor = null;

            bool movimento = false;
            if (velocidade == 0) { movimento = false; }
            else { movimento = true; }

            if (movimento == false)
            {
                if (motor == false) { motor = true; situacaoMotor = "Ligado"; }
                else { motor = false; situacaoMotor = "Desligado"; }
            }
            else { motor = true; situacaoMotor = "Ligado"; }

            return situacaoMotor;
        }

        static string Portas(bool porta, bool Onibus, int velocidade)
        {
            string situacaoPortas = null;
            if(velocidade == 0)
            {
                if (porta == false) { if (Onibus == false) { porta = true; situacaoPortas = "Aberto"; } else { porta = false; situacaoPortas = "Fechado"; } }
                else { porta = false; situacaoPortas = "Fechado"; }
            }
            else
            {
                porta = false; situacaoPortas = "Fechado";
            }
            return situacaoPortas;
        }

        static int Acelerar(bool velo, int velocidade, string situacaoPortas, string situacaoMotor)
        {
            bool Porta = false;
            if(situacaoPortas == "Fechado") { Porta = false; }
            else {  Porta = true; }

            bool motor = false;
            if (situacaoMotor == "Desligado") { motor = false; }
            else { motor = true; }

            if (motor == true)
            {
                if (Porta == false)
                {
                    if (velo == false) { if (velocidade < 100) { velocidade = velocidade + 5; } else { velocidade = 100; } }
                    else { if (velocidade > 0) { velocidade = velocidade - 5; } else { velocidade = 0; } }
                }
                else { velocidade = 0; }
            }

            else { velocidade = 0; }

            return velocidade;

        }


        static void Main(string[] args)
        {
            //variaveis
            string situacaoMotor = "Desligado"; string situacaoPortas = "Fechado"; int velocidade = 0; string situacaoOnibus = "Parado";
            bool jogo = true; bool Onibus = false; 

            while (jogo)
            {
                Console.WriteLine("Simulação Ônibus\n");
                Console.WriteLine($"Motor: {situacaoMotor}");
                Console.WriteLine($"Portas: {situacaoPortas}");
                Console.WriteLine($"Ônibus: {situacaoOnibus}");
                Console.WriteLine($"Velocidade: {velocidade}");
                Console.WriteLine("Qual Opção Deseja: ");
                Console.WriteLine("L - Ligar\nD - Desligar\nA - Abrir Portas\nF - Fechar Portas\nW - Acelerar Ônibus\nS - Freiar Ônibus");
                Console.Write("Insira Aqui: ");
                string opcao = Console.ReadLine().ToLower();
                

                switch (opcao)
                {
                    case "l":
                        situacaoMotor = Ligar(false, velocidade);
                        Console.Clear();
                        jogo = true;
                        break;
                    case "d":
                        situacaoMotor = Ligar(true, velocidade);
                        Console.Clear();
                        jogo = true;
                        break;
                    case "a":
                        situacaoPortas = Portas(false, Onibus, velocidade);
                        Console.Clear();
                        jogo = true;
                        break;
                    case "f":
                        situacaoPortas = Portas(true, Onibus, velocidade);
                        Console.Clear();
                        jogo = true;
                        break;
                    case "w":
                        velocidade = Acelerar(false, velocidade, situacaoPortas, situacaoMotor);
                        Console.Clear();
                        jogo = true;
                        break;
                    case "s":
                        velocidade = Acelerar(true, velocidade, situacaoPortas, situacaoMotor);
                        Console.Clear();
                        jogo = true;
                        break;
                }
            }
            

        }
    }
}
