// RA: 315115982
// NOME: Leonardo Henrique Cerqueira

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeonardoCerqueira_315115982
{
    class Program
    {
        //////////////////////////////////////////////////////////// QUESTAO 1
        static void questao1()
        {
            int p=0, r=0;
            Console.WriteLine("Informe 1 ou 0 para P");
            
            do
            {
                if (p != 1 && p != 0) Console.WriteLine("somente 0 ou 1 para P");
                p = Int32.Parse(Console.ReadLine());
            }
            while (p != 1 && p != 0);
            Console.WriteLine("Informe 1 ou 0 para R");
            
            do
            {
                if (r != 1 && r != 0) Console.WriteLine("somente 0 ou 1 para R");
                r = Int32.Parse(Console.ReadLine());    
            }
            while (r != 1 && r != 0);
            Console.WriteLine(p == 0 ? "C" : r == 0 ? "B" : "A");

            Console.ReadKey();
        }




        //////////////////////////////////////////////////////////// QUESTAO 2
        static void questao2()
        {
            int p1, p2, c1, c2;

            Console.WriteLine("Informe as 4 medidas");

            p1 = Int32.Parse(Console.ReadLine());
            c1 = Int32.Parse(Console.ReadLine());
            p2 = Int32.Parse(Console.ReadLine());
            c2 = Int32.Parse(Console.ReadLine());

            double
                f1 = p1 * c1,
                f2 = p2 * c2;

            if (f1 == f2)
                Console.WriteLine("0");
            else if (f1 > f2)
                Console.WriteLine("-1");
            else
                Console.WriteLine("1");

            Console.ReadKey();
        }




        //////////////////////////////////////////////////////////// QUESTAO 3
        static void questao3()
        {
            double mIr;

            int
                capacidade     = 100, // mude para testar
                total          = capacidade,
                totalOtimas    = 0,
                mediaIdadeRuin = 0,
                maiorIdade     = 0,
                contIdadeRuin  = 0,
                contRespPess   = 0,
                idade;

            char opiniao;

            for (;capacidade > 0; capacidade--)
            {
                Console.WriteLine("Informe a idade");
	        idade = Int32.Parse(Console.ReadLine());
	        Console.WriteLine("Avalie o filme como A, B, C, D ou E");
            	opiniao = Convert.ToChar(Console.ReadLine().ToUpper());
	            
                if (opiniao == 'A') 
                {
            		totalOtimas += 1;
                }
		
		else if (opiniao == 'D')
		{
			contIdadeRuin  += 1;
			mediaIdadeRuin += idade;
		}
		
		else if (opiniao == 'E') 
		{
			contRespPess += 1;
			if (idade > maiorIdade) maiorIdade = idade;
		}
            }

            double porcResp = (double)contRespPess / (double)total * 100;

            if (mediaIdadeRuin == 0 || contIdadeRuin == 0)
                mIr = 0;
            else
                mIr = mediaIdadeRuin / contIdadeRuin;

            Console.WriteLine("Respostas ótimas: " + totalOtimas);
            Console.WriteLine("Media idade de pessoas que responderam ruin: " + mIr );
            Console.WriteLine("Porcentagem de respostas péssimo: " + porcResp + "%" );
            Console.WriteLine("Maior idade que avaliou como péssimo: " + maiorIdade);
            
            Console.ReadKey();
        }




        //////////////////////////////////////////////////////////// MAIN
        static void Main(string[] args)
        {
            Console.WriteLine("Questão 1, 2 ou 3 (qualquer outro número para sair)");
            int op = Int32.Parse(Console.ReadLine());
            
            if      (op == 1) questao1();
            else if (op == 2) questao2();
            else if (op == 3) questao3();
            else
	    	return;
            
        }
    }
}
