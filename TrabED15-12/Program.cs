using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabED15_12.Models;

namespace TrabED15_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Livros ac = new Livros();
            int opc;
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Adicionar livro");
            Console.WriteLine("2. Pesquisar livro (sintético)");
            Console.WriteLine("3. Pesquisar livro (analítico)");
            Console.WriteLine("4. Adicionar exemplar");
            Console.WriteLine("5. Registrar empréstimo");
            Console.WriteLine("6. Registrar devolução");
            Console.WriteLine("Escolha uma opção: ");
            opc = int.Parse(Console.ReadLine());

            while (opc != 0)
            {
                if (opc == 1)
                {
                    Livro lv = new Livro();

                    Console.WriteLine("Digite o isbn: ");
                    lv.Isbn = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite o titulo: ");
                    lv.Titulo = Console.ReadLine();

                    Console.WriteLine("Digite o autor: ");
                    lv.Autor = Console.ReadLine();

                    Console.WriteLine("Digite a editora: ");
                    lv.Editora = Console.ReadLine();

                    ac.adicionar(lv);

                }
                if (opc == 2)
                {
                    Livro lv = new Livro();
                    Console.WriteLine("Digite o isbn: ");
                    lv.Isbn = int.Parse(Console.ReadLine());
                    lv = ac.pesquisar(lv);
                    if (lv.Titulo != "")
                    {
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("ISBN: " + lv.Isbn);
                        Console.WriteLine("TITULO: " + lv.Titulo);
                        Console.WriteLine("AUTOR: " + lv.Autor);
                        Console.WriteLine("EDITORA: " + lv.Editora);
                        Console.WriteLine("totais de exemplares são: " + lv.qtdeExemplares());
                        Console.WriteLine("exemplares disponiveis são: " + lv.qtdeDisponiveis());
                        Console.WriteLine("exemplares emprestados são: " + lv.qtdeEmprestimos());
                        Console.WriteLine("porcentagem de disponibilidade: " + lv.percDisponibilidade());
                    }
                    else
                    {
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("Livro não encontrado!");
                    }

                }
                if (opc == 3)
                {
                    Livro lv = new Livro();
                    Console.WriteLine("Digite o isbn: ");
                    lv.Isbn = int.Parse(Console.ReadLine());
                    lv = ac.pesquisar(lv);
                    if (lv.Titulo != "")
                    {
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("ISBN: " + lv.Isbn);
                        Console.WriteLine("TITULO: " + lv.Titulo);
                        Console.WriteLine("AUTOR: " + lv.Autor);
                        Console.WriteLine("EDITORA: " + lv.Editora);
                        Console.WriteLine("totais de exemplares são: " + lv.qtdeExemplares());
                        Console.WriteLine("exemplares disponiveis são: " + lv.qtdeDisponiveis());
                        Console.WriteLine("exemplares emprestados são: " + lv.qtdeEmprestimos());
                        Console.WriteLine("porcentagem de disponibilidade: " + lv.percDisponibilidade());

                        foreach (Exemplar e in lv.Exemplares)
                        {
                            Console.WriteLine("TOMBO: " + e.Tombo);
                            foreach (Emprestimo em in e.Emprestimos)
                            {
                                if (em.DtEmprestimo != DateTime.MinValue && em.DtDevolucao == DateTime.MinValue)
                                {
                                    Console.WriteLine("Data do emprestimo: " + em.DtEmprestimo);
                                }
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("Livro não encontrado!");
                    }

                }
                if (opc == 4)
                {
                    Livro lv = new Livro();
                    Console.WriteLine("Digite o isbn: ");
                    lv.Isbn = int.Parse(Console.ReadLine());
                    lv = ac.pesquisar(lv);
                    if (lv.Titulo != "")
                    {
                        Console.WriteLine("Digite o tombo: ");
                        lv.Exemplares.Add(new Exemplar(int.Parse(Console.ReadLine())));
                    }
                    else
                    {
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("Livro não encontrado!");
                    }
                }
                if (opc == 5)
                {
                    Livro lv = new Livro();
                    Console.WriteLine("Digite o isbn: ");
                    lv.Isbn = int.Parse(Console.ReadLine());
                    lv = ac.pesquisar(lv);
                    if (lv.Titulo != "")
                    {
                        foreach (Exemplar e in lv.Exemplares)
                        {
                            if (e.disponivel())
                            {
                                e.emprestar();
                            }
                            else
                            {
                                Console.WriteLine("-------------------------------");
                                Console.WriteLine("Sem exemplares disponiveis! ");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("Livro não encontrado!");
                    }

                }
                if (opc == 6)
                {
                    bool a = false;
                    Livro lv = new Livro();
                    Console.WriteLine("Digite o isbn: ");
                    lv.Isbn = int.Parse(Console.ReadLine());
                    lv = ac.pesquisar(lv);
                    if (lv.Titulo != "")
                    {
                        foreach (Exemplar e in lv.Exemplares)
                        {

                            if (a == false)
                            {
                                a = e.devolver();
                            }
                        }
                        if (a == false)
                        {
                            Console.WriteLine("-------------------------------");
                            Console.WriteLine("Não ah Exemplar esperando ser devolvido!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("Livro não encontrado!");
                    }
                }
                Console.WriteLine("-------------------------------");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar livro");
                Console.WriteLine("2. Pesquisar livro (sintético)");
                Console.WriteLine("3. Pesquisar livro (analítico)");
                Console.WriteLine("4. Adicionar exemplar");
                Console.WriteLine("5. Registrar empréstimo");
                Console.WriteLine("6. Registrar devolução");
                Console.WriteLine("Escolha uma opção: ");
                opc = int.Parse(Console.ReadLine());
            }


        }
    }
}
