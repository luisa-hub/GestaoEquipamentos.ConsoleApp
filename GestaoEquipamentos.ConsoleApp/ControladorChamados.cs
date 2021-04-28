using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipamentos.ConsoleApp
{
    class ControladorChamados
    {
        const int CAPACIDADE_REGISTROS = 100;
        private static Chamados[] listaChamados = new Chamados[CAPACIDADE_REGISTROS];
        
        private static int IdChamados;

       
        public static void ExcluirChamado()
        {
           
            Console.Clear();

            VisualizarChamados();

            Console.WriteLine();

            Console.Write("Digite o número do chamado que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());


            foreach (var chamado in listaChamados)
            {
                if (chamado != null && chamado.idChamados == idSelecionado)
                {
                    chamado.idChamados = 0;
                    chamado.idsEquipamentoChamado = 0;
                    chamado.titulosChamado = null;
                    chamado.descricaoChamado = null;
                    chamado.dataAberturaChamado = DateTime.MinValue;

                    break;
                }
            }
           
        }

        public static void EditarChamado()
        {
            Console.Clear();

            VisualizarChamados();

            Console.WriteLine();

            Console.Write("Digite o número do chamado que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            RegistrarChamado(idSelecionado);
        }

        public static void VisualizarChamados()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-30} | {2,-55} | {3,-25}", "Id", "Equipamento", "Título", "Dias em Aberto");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            int numeroChamadosRegistrados = 0;

            for (int indiceChamados = 0; indiceChamados < listaChamados.Length; indiceChamados++)
            {
                if (listaChamados[indiceChamados] != null)
                {
                    string nomeEquipamento = "";

                    for (int indiceEquipamentos = 0; indiceEquipamentos < ControladorEquipamento.listaEquipamento.Length; 
                        indiceEquipamentos++)
                    {
                        if (ControladorEquipamento.listaEquipamento[indiceEquipamentos]!= null && ControladorEquipamento.listaEquipamento[indiceEquipamentos].idEquipamento
                            == listaChamados[indiceChamados].idsEquipamentoChamado)
                        {
                            nomeEquipamento = ControladorEquipamento.listaEquipamento[indiceEquipamentos].nomeEquipamento;
                            break;
                        }
                    }

                    TimeSpan diasEmAberto = DateTime.Now - listaChamados[indiceChamados].dataAberturaChamado;

                    Console.Write("{0,-10} | {1,-30} | {2,-55} | {3,-25}",
                       listaChamados[indiceChamados].idChamados,
                       nomeEquipamento,
                       listaChamados[indiceChamados].titulosChamado,
                       diasEmAberto.ToString("dd"));

                    Console.WriteLine();

                    numeroChamadosRegistrados++;
                }
            }

            if (numeroChamadosRegistrados == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhum chamado registrado!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        public static void RegistrarChamado(int idChamadoSelecionado)
        {
            Console.Clear();

            int posicao = ObterPosicaoParaChamados(idChamadoSelecionado);

           
            ControladorEquipamento.VisualizarEquipamentos();

            Console.Write("Digite o Id do equipamento para manutenção: ");
            int idEquipamentoChamado = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o titulo do chamado: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descricao do chamado: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite a data de abertura do chamado: ");
            DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

            Chamados chamado;

            if (idChamadoSelecionado == 0)
                chamado = new Chamados();

            else
                chamado = listaChamados[posicao];

            chamado.idChamados = IdChamados;
            chamado.idsEquipamentoChamado = idEquipamentoChamado;
            chamado.titulosChamado = titulo;
            chamado.descricaoChamado = descricao;
            chamado.dataAberturaChamado = dataFabricacao;

            listaChamados[posicao] = chamado;
        }

        public static int ObterPosicaoParaChamados(int idChamadoSelecionado)
        {
            int posicao = 0;

            for (int i = 0; i < listaChamados.Length; i++)
            {
                if (idChamadoSelecionado == 0 && listaChamados[i] == null) //inserindo...
                {
                    IdChamados++;
                    posicao = i;
                    break;
                }
                else if (listaChamados[i] != null && idChamadoSelecionado == listaChamados[i].idChamados) //editando...
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }

        public static string ObterOpcaoControleChamados()
        {
            string opcao;

            do
            {
                Console.WriteLine("Digite 1 para inserir novo chamadp");
                Console.WriteLine("Digite 2 para visualizar chamados");
                Console.WriteLine("Digite 3 para editar um chamado");
                Console.WriteLine("Digite 4 para excluir um chamado");

                Console.WriteLine("Digite S para sair");

                opcao = Console.ReadLine();

                if (!ValidaOpcaoMenuChamado(opcao))
                {
                    Console.WriteLine("Opção Inválida. Tente Novamente!");
                    Console.Clear();

                }

            } while (!ValidaOpcaoMenuChamado(opcao));

            return opcao;
        }

        private static bool ValidaOpcaoMenuChamado(string opcao)
        {
            return (opcao == "1" || opcao == "2" || opcao == "3" || opcao == "4" || opcao == "S" || opcao == "s");
        }



    }


}

