using System;
using System.Collections.Generic;

namespace Aula14_07_2020
{
    class Program
    {
        static void Main(string[] args)
        {

         
        //Variáveis de sistema
            String[] usuarios = new String[10];  //Guarda os usuarios
            String[] senhas = new String[10];   //Guarda as senhas
            int ultimoIndice = 0; //Primeiro indice vago

            //Debug - Criação manual de primeiro usuario
            /*
            usuarios[0] = "Marcos";
            senhas[0] = "qwert@123";
            */

            //Dados de login
            bool estaLogado = false;
            int indexUserLogado = -1;



         //Funções
            //Valida senha para cadastro
            bool validaSenha(String senha)
            {
                if (senha.Length < 5 || senha.Length >= 15 || !senha.Contains('@'))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            //Verifica senha e usuario para login
            bool senhaCorreta(string usuario, string senha)
            {
                int indexUser = -1;

                for (int i = 0; i < usuarios.Length; i++)
                {
                    if (usuarios[i] == usuario)
                    {
                        indexUser = i;
                        break;
                    }
                }
                if (indexUser >= 0)
                {
                    if (senhas[indexUser] == senha)
                    {
                        indexUserLogado = indexUser;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }


            void login()
            {
                Console.WriteLine();
                Console.WriteLine("--------------- LOGIN ---------------");

                int tentativas = 4;
                while (tentativas > 0)
                {
                    Console.WriteLine();
                    Console.Write("Digite o nome de usuario: ");
                    string nomeDigitado = Console.ReadLine();
                    Console.Write("Digite a senha do usuario: ");
                    string senhaDigitada = Console.ReadLine();

                    if (senhaCorreta(nomeDigitado, senhaDigitada))
                    {
                        estaLogado = true;
                        Console.WriteLine("Acesso liberado!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Senha ou usuario incorretos");
                        tentativas--;
                        Console.WriteLine("Restam " + tentativas + " tentativas");
                    }

                }
            }


            void cadastro()
            {
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("--------------- CADASTRO ---------------");

                    Console.Write("Digite o nome do novo usuario: ");
                    string novoUsuario = Console.ReadLine();

                    Console.Write("Digite a senha do novo usuario: ");
                    string novaSenha = Console.ReadLine();

                    Console.Write("Realmente deseja cadastrar ( s / n ) ? ");
                    string resposta1 = Console.ReadLine();
                    if (resposta1 == "n")
                    {
                        break;
                    }
                    else if (validaSenha(novaSenha))
                    {
                        Console.WriteLine("Dados inválidos! ");
                        continue;
                    }

                    usuarios[ultimoIndice] = novoUsuario;
                    senhas[ultimoIndice] = novaSenha;
                    ultimoIndice++;
                    Console.WriteLine("Usuario cadastrado com sucesso!");

                    //Debug contas
                    /*for (int i = 0; i < usuarios.Length; i++)
                    {
                        Console.WriteLine("Usuario " + usuarios[i] + " possui a senha " + senhas[i]);
                    }*/
                    Console.Write("Deseja sair ( s / n ) ? ");
                    string resposta = Console.ReadLine();
                    if (resposta == "s")
                    {
                        break;
                    }
                }
            }




            void sistema()
            {
                Console.WriteLine();
                Console.WriteLine("--------------- SISTEMA ---------------");

                string nomeDeUsuario = usuarios[indexUserLogado];

                string nomeDaAssistente = "Pan";
                string falaUsuario = "";
                string respostaAssistente = "";
                bool saiu = false;
                bool inicio = true;

                //Inicio do sistema, informa ao usuario como sair e inicia o dialogo
                Console.WriteLine(" Para sair, a qualquer momento digite S ");
                Console.WriteLine();
                Console.WriteLine();

                /*
                    Padrão fala e resposta 
                Console.Write("(username) : ");
                Console.ReadLine();
                Console.Write("(" + nome + "): ");
                Console.WriteLine("RESPOSTA");*/


                //Função que transita entre as respostas dependendo da fala
                void respondeUsuario(string fala)
                {
                    switch (fala)
                    {
                        //casos padrões
                        case "s":
                            respostaAssistente = "Ahhh, então vc não quer mais falar cmg??? Tchau!!";
                            saiu = true;
                            break;
                        case "tchau":
                            respostaAssistente = "Ahhh, então vc não quer mais falar cmg??? Tchau!!";
                            saiu = true;
                            break;
                        case "":
                            respostaAssistente = "";
                            break;



                        //casos específicos
                        case "oi":
                            respostaAssistente = "Oiiiiii " + nomeDeUsuario;
                            break;
                        case "to bem":
                        case "to bão":
                        case "estou ótimo":
                        case "muito bem":
                        case "to normal":
                            respostaAssistente = "Que ótimo!!! E como está sendo seu dia " + nomeDeUsuario + "?? ";
                            break;
                        case "não estou bem":
                        case "não estou tão bem":
                        case "não estou legal":
                            respostaAssistente = "Nossa, porque? Quer falar sobre isso? ";
                            break;
                        case "está sendo ótimo":
                        case "muito bom":
                        case "legal":
                        case "top":
                        case "ótimo":
                            respostaAssistente = "Que incrível, fico feliz :) ";
                            break;
                        case "ruim":
                        case "péssimo":
                        case "horrivel":
                            respostaAssistente = "Eita, amanhã vai ser melhor! Não desanime :) ";
                            break;
                        case "não":
                            respostaAssistente = "ok então";
                            break;
                        case "1":
                            respostaAssistente = "2";
                            break;
                        case "3":
                            respostaAssistente = "4";
                            break;
                        case "5":
                            respostaAssistente = "Para com isso kkkkkkk";
                            break;
                        case "vamos conversar?":
                        case "quer conversar?":
                            respostaAssistente = "É para isso que eu existo";
                            break;

                        case "quem te criou?":
                            respostaAssistente = "Fui programada em C#, pelo talentoso desenvolvedor HeronPBV em 2020! Com intuito educacional, módulo de lógica de progamação do curso de desenvolvimento web, com os grandes alunos Edi Carlos e Marcos Machado";
                            break;




                        //caso não especificado
                        default:
                            respostaAssistente = "Desculpe, não entendi";
                            break;
                    }

                    //Usuario falou algo. Para evitar uma resposta caso ele não tenha dito nada
                    if (respostaAssistente != "")
                    {
                        Console.WriteLine();
                        Console.WriteLine("(" + nomeDaAssistente + "): " + respostaAssistente);

                    }
                }


                //Seção de dialogo
                while (true)
                {

                    //primeira fala da assistente
                    if (inicio)
                    {
                        inicio = false;
                        if (nomeDeUsuario == "HeronPBV") Console.WriteLine("(" + nomeDaAssistente + "): " + "Nossa, olá mestre!! Bom te ver por aqui, como o senhor está?");
                        else Console.WriteLine("(" + nomeDaAssistente + "): " + "Olá, eu sou a " + nomeDaAssistente + ", como você está? ");
                            
                        Console.Write("(" + nomeDeUsuario + "): "); falaUsuario = Console.ReadLine();
                        falaUsuario = falaUsuario.ToLower();
                        respondeUsuario(falaUsuario);
                    }
                    //usuário digitou "S" para sair
                    else if (saiu) break;
                    //fala usuário
                    else
                    {
                        Console.Write("(" + nomeDeUsuario + "): "); falaUsuario = Console.ReadLine();
                        falaUsuario = falaUsuario.ToLower();
                        respondeUsuario(falaUsuario);
                    }

                }

            }






            //-------------------------------------------------------------------------


            //Sessão geral
            while (true)
            {

                if (estaLogado == true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Logado como " + usuarios[indexUserLogado]);
                    Console.WriteLine();
                    Console.Write("Sistema, cadastro, login ou fechar ( S / C / L / F ): ");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Para acessar o sistema você precisa fazer o login! ");
                    Console.WriteLine();
                    Console.Write("Cadastro, login ou fechar ( C / L / F ): ");
                }

                string caminho = Console.ReadLine();

                //Sessão de login
                if (caminho == "L")
                {
                    login();
                }
                //Sessão de criação de usuario
                else if (caminho == "C")
                {
                    cadastro();
                }
                else if (caminho == "S" && estaLogado == true)
                {
                    sistema();
                }
                else if (caminho == "F")
                {
                    Console.WriteLine("Obrigado por estar conosco! ");
                    break;
                }
                else
                {
                    Console.WriteLine("Opção inválida!");
                }

            }

        }
    }
}



/*
                To do list
    
     
     



     by: HeronPBV
*/

