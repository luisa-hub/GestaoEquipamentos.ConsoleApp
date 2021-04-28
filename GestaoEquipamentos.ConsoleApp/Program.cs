using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipamentos.ConsoleApp
{
    class Program
    {
        
        static void Main(string[] args)
        {


            
            
            while (true)
            {
                string opcao = ObterOpcao();

                if (OpcaoSair(opcao))
                    break;

                if (OpcaoEquipamento(opcao))
                {
                    string opcaoCadastroEquipamentos = ControladorEquipamento.ObterOpcaoCadastroEquipamentos();

                    if (OpcaoSair(opcaoCadastroEquipamentos))
                        break;

                    if (OpcaoRegistro(opcaoCadastroEquipamentos))
                                           
                        ControladorEquipamento.RegistrarEquipamento(0);
                    

                    else if (OpcaoVisualizar(opcaoCadastroEquipamentos))
                        ControladorEquipamento.VisualizarEquipamentos();

                    else if (OpcaoEditar(opcaoCadastroEquipamentos))
                        ControladorEquipamento.EditarEquipamento();

                    else if (OpcaoExcluir(opcaoCadastroEquipamentos))
                        ControladorEquipamento.ExcluirEquipamento();
                }

                else if (OpcaoChamado(opcao))
                {
                    string opcaoControleChamados = ControladorChamados.ObterOpcaoControleChamados();

                    if (OpcaoSair(opcaoControleChamados))
                        break;

                    if (OpcaoRegistro(opcaoControleChamados))
                        ControladorChamados.RegistrarChamado(0);

                    else if (OpcaoVisualizar(opcaoControleChamados))
                        ControladorChamados.VisualizarChamados();

                    else if (OpcaoEditar(opcaoControleChamados))
                        ControladorChamados.EditarChamado();

                    else if (OpcaoExcluir(opcaoControleChamados))
                        ControladorChamados.ExcluirChamado();

                }

                Console.Clear();
            }


        }


        private static bool OpcaoChamado(string opcao)
        {
            return opcao == "2";
        }

        private static bool OpcaoEquipamento(string opcao)
        {
            return opcao == "1";
        }

        private static bool OpcaoExcluir(string opcaoControleChamados)
        {
            return opcaoControleChamados == "4";
        }

        private static bool OpcaoEditar(string opcaoControleChamados)
        {
            return opcaoControleChamados == "3";
        }

        private static bool OpcaoVisualizar(string opcaoControleChamados)
        {
            return opcaoControleChamados == "2";
        }

        private static bool OpcaoRegistro(string opcaoControleChamados)
        {
            return opcaoControleChamados == "1";
        }

        private static bool OpcaoSair(string opcaoControleChamados)
        {
            return opcaoControleChamados.Equals("s", StringComparison.OrdinalIgnoreCase);
        }

        private static string ObterOpcao()
        {
            string opcao;
            do
            {
                Console.WriteLine("Digite 1 para o Cadastro de Equipamentos");
                Console.WriteLine("Digite 2 para o Controle de Chamados");
                Console.WriteLine("Digite S para Sair");

                opcao = Console.ReadLine();

                if (!ValidaOpcaoMenuInicial(opcao))
                {
                    Console.WriteLine("Opção Inválida. Tente Novamente!");
                    Console.ReadLine();
                    Console.Clear();

                }

            } while (!ValidaOpcaoMenuInicial(opcao));
            return opcao;
        }

        private static bool ValidaOpcaoMenuInicial(string opcao)
        {
            return (opcao == "1" || opcao == "2" ||  opcao == "S" || opcao == "s");
        }


    }
}
