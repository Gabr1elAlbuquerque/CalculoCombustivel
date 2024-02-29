namespace CalculoCombustivel
{
    internal class Program
    {
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
                    Console.WriteLine("\nSaindo do programa...");
                    System.Threading.Thread.Sleep(1500);
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

            float proporcaoTemp = 0.0f, kmGasolina = 0.0f, kmEtanol = 0.0f;
            Console.Write("\nDigite o consumo do carro utilizando gasolina Km/L: ");
            kmGasolina = float.Parse(Console.ReadLine());
            Console.Write("Digite o consumo do carro utilizando etanol Km/L: ");
            kmEtanol = float.Parse(Console.ReadLine());

            proporcaoTemp = ((kmEtanol * 100) / kmGasolina) / 100;
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
