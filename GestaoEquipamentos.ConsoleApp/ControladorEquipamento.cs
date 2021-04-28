using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipamentos.ConsoleApp
{

    
    class ControladorEquipamento
    {

        const int CAPACIDADE_REGISTROS = 100;
        public static Equipamento[] listaEquipamento = new Equipamento[CAPACIDADE_REGISTROS];
        
        private static int IdEquipamento;

        
    public static void RegistrarEquipamento(int idEquipamentoSelecionado)
        {
            
            Console.Clear();
            
            string nome = "";
            bool nomeInvalido;
            do
            {
                nomeInvalido = false;
                Console.Write("Digite o nome do equipamento: ");
                nome = Console.ReadLine();
                if (nome.Length < 6)
                {
                    nomeInvalido = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nome inválido. No mínimo 6 caracteres");
                    Console.ResetColor(); 
                }

            } while (nomeInvalido);


            Console.Write("Digite o preço do equipamento: ");
            double preco = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o número do equipamento: ");
            string numeroSerie = Console.ReadLine();

            Console.Write("Digite a data de fabricação do equipamento: ");
            DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite o fabricante do equipamento: ");
            string fabricante = Console.ReadLine();

            int posicao = ObterPosicaoParaEquipamentos(idEquipamentoSelecionado);

            Equipamento equipamento = null;

            if (idEquipamentoSelecionado == 0)
                equipamento = new Equipamento();
            
            else
                equipamento = listaEquipamento[posicao];

            equipamento.idEquipamento = IdEquipamento;
            equipamento.nomeEquipamento = nome;
            equipamento.numeroSerieEquipamento = numeroSerie;
            equipamento.precoEquipamento = preco;
            equipamento.dataFabricacaoEquipamento = dataFabricacao;
            equipamento.fabricanteEquipamento = fabricante;

            listaEquipamento[posicao] = equipamento;
        }

        public static int ObterPosicaoParaEquipamentos(int idEquipamentoSelecionado)
        {
            int posicao = 0;
            
            for (int i = 0; i < listaEquipamento.Length; i++)
            {
                
                if (idEquipamentoSelecionado == 0 && listaEquipamento[i] == null) //inserindo...
                {
                    IdEquipamento++;
                    posicao = i;
                    break;
                }
                else if (listaEquipamento[i]!= null && (idEquipamentoSelecionado == listaEquipamento[i].idEquipamento)) //editando...
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;

        }
                
        public static void EditarEquipamento()
        {
            Console.Clear();

            VisualizarEquipamentos();

            Console.WriteLine();

            Console.Write("Digite o número do equipamento que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            RegistrarEquipamento(idSelecionado);
        }
        
        public static void ExcluirEquipamento()
        {
            Console.Clear();

            VisualizarEquipamentos();

            Console.WriteLine();

            Console.Write("Digite o número do equipamento que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < listaEquipamento.Length; i++)
            {
                if (listaEquipamento[i] != null && listaEquipamento[i].idEquipamento == idSelecionado)
                {
                    listaEquipamento[i].idEquipamento = 0;
                    listaEquipamento[i].nomeEquipamento = null;
                    listaEquipamento[i].precoEquipamento = 0;
                    listaEquipamento[i].numeroSerieEquipamento = null;
                    listaEquipamento[i].dataFabricacaoEquipamento = DateTime.MinValue;
                    listaEquipamento[i].fabricanteEquipamento = null;

                    break;
                }
            }
        }

        public static void VisualizarEquipamentos()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-55} | {2,-35}", "Id", "Nome", "Fabricante");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            int numeroEquipamentosCadastrados = 0;

            foreach (var equipamento in listaEquipamento)
            {

                if (equipamento != null)
                {
                    Console.Write("{0,-10} | {1,-55} | {2,-35}",
                       equipamento.idEquipamento, equipamento.nomeEquipamento,
                      equipamento.fabricanteEquipamento);

                    Console.WriteLine();

                    numeroEquipamentosCadastrados++;
                }
            }
            

            if (numeroEquipamentosCadastrados == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhum equipmaneto cadastrado!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        public static string ObterOpcaoCadastroEquipamentos()
        {
            string opcao;
            do
            {
                Console.WriteLine("Digite 1 para inserir novo equipamento");
                Console.WriteLine("Digite 2 para visualizar equipamentos");
                Console.WriteLine("Digite 3 para editar um equipamento");
                Console.WriteLine("Digite 4 para excluir um equipamento");

                Console.WriteLine("Digite S para sair");

                opcao = Console.ReadLine();

                if (!ValidaOpcaoMenuEquipamento(opcao))
                {
                    Console.WriteLine("Opção Inválida. Tente Novamente!");
                    Console.Clear();

                }

            } while (!ValidaOpcaoMenuEquipamento(opcao));
            return opcao;
        }

        private static bool ValidaOpcaoMenuEquipamento(string opcao)
        {
            return (opcao == "1" || opcao == "2" || opcao == "3" || opcao == "4" || opcao == "S" || opcao == "s");
        }





    }

   
}
