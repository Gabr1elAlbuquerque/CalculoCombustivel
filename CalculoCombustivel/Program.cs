namespace CalculoCombustivel
{
    internal class Program
    {

        static bool validaPositivo(float n)
        {
            bool x = true;

            if (n < 0)
            {
                x = false;
            }
            return x;

        }


        static float validaNreal(float n)
        {
            float x = 0.0f;
            string opc = "";

            while (true)
            {


                opc = Console.ReadLine();
                bool isNumberFloat = float.TryParse(opc, out x);

                if (isNumberFloat && validaPositivo(x))
                {
                    break;
                }
                else
                {
                    Console.Write("\nDigite um número real positivo:");
                }
            }
            return x;

        }


        static void inicoPrograma(float proporcao)
        {
            int opcaoMenu = 0;
            Console.WriteLine("[1] Calcular Combustível\n[2] Editar Dados\n[3] Sair do Programa\n");
            opcaoMenu = validaOpcao();


            switch (opcaoMenu)
            {
                case 1:
                    verificaTipoCarro(proporcao);
                    Console.WriteLine();
                    inicoPrograma(proporcao);
                    break;
                case 2:
                    proporcao = calculaProporcao();
                    Console.WriteLine();
                    inicoPrograma(proporcao);
                    break;
                case 3:
                    Console.WriteLine("Digite 1 para confirmar a saída e qualquer outra tecla para cancelar");
                    string confirmar = Console.ReadLine();
                    if (confirmar == "1")
                    {
                        Console.WriteLine("\nSaindo do programa...");
                        System.Threading.Thread.Sleep(1500);
                    }
                    else
                    {
                        inicoPrograma(proporcao);
                    }
                    break;
            }
        }
        static int validaOpcao()
        {
            bool isNumberResult = false;
            int opcao = 0;
            string opcaoAuxiliar = "";

            while (true)
            {
                Console.Write("Digite sua escolha: ");
                opcaoAuxiliar = Console.ReadLine();

                isNumberResult = int.TryParse(opcaoAuxiliar, out opcao);
                if (isNumberResult == false || opcao < 1 || opcao > 3)
                {
                    Console.WriteLine("Digite uma opção válida!");
                }
                else
                {
                    break;
                }
            }
            return opcao;
        }
        static void verificaTipoCarro(float proporcao)
        {
            int tipoCarro = 0;
            Console.WriteLine("\nSelecione o Tipo do Carro:");
            Console.WriteLine("\n[1] Apenas Gasolina\n[2] Apenas Etanol\n[3] Flex\n");
            tipoCarro = validaOpcao();
            if (tipoCarro == 1)
            {
                Console.WriteLine("\nAbasteça com gasolina!");
                Console.Write("\nDigite qualquer tecla para continuar!");
                Console.ReadKey();
                Console.WriteLine();

            }
            else if (tipoCarro == 2)
            {
                Console.WriteLine("\nAbasteça com etanol!");
                Console.Write("\nDigite qualquer tecla para continuar!");
                Console.ReadKey();
                Console.WriteLine();
            }
            else
            {
                calculaCombustivel(proporcao);
                Console.Write("\nDigite qualquer tecla para continuar!");
                Console.ReadKey();
                Console.WriteLine();

            }
        }

        static float calculaProporcao()
        {

            float proporcaoTemp = 0.7f, kmGasolina = 0.0f, kmEtanol = 0.0f;
            Console.Write("\nDigite o consumo do carro utilizando gasolina Km/L: ");
            kmGasolina = validaNreal(kmGasolina);

            Console.Write("Digite o consumo do carro utilizando etanol Km/L: ");
            kmEtanol = validaNreal(kmEtanol);


            if (kmGasolina == 0 && kmEtanol != 0)
            {
                Console.WriteLine("Seu carro é somente etanol");
               
            }
         
            else if (kmEtanol == 0 && kmGasolina != 0)
            {
                Console.WriteLine("Seu carro é somente gasolina");
              

            }
            else if (kmEtanol == 0 & kmGasolina == 0)
            {
                Console.WriteLine("Você deve digitar um número real positivo" +
                    " para pelos menos uma das duas opções, voltando para o menu");


            }
            else
            {
                 proporcaoTemp = ((kmEtanol * 100) / kmGasolina) / 100;
               
        
            }
            Console.WriteLine("Proporção: " + proporcaoTemp);

            return proporcaoTemp;
        }

        static void calculaCombustivel(float proporcao)
        {
            float precoGasolina = 0.00f, precoEtanol = 0.00f;
            String custoBeneficio = "";

            Console.Write("\nDigite o preço da gasolina R$: ");
            precoGasolina = float.Parse(Console.ReadLine());
            Console.Write("Digite o preço do etanol R$: ");
            precoEtanol = float.Parse(Console.ReadLine());
            if ((precoGasolina * proporcao) <= precoEtanol)
            {
                custoBeneficio = "Gasolina";
            }
            else
            {
                custoBeneficio = "Etanol";
            }

            Console.WriteLine($"\nAbasteça com {custoBeneficio}!");

        }
        static void Main(string[] args)
        {
            float proporcao = 0.70f; ;
            inicoPrograma(proporcao);

        }
    }
}
