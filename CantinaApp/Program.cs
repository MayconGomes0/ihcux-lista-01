﻿/*
Exercício Prático: Caos na Cantina
Professor: Daniel Henrique Matos de Paiva
Disciplina: Interação Humano Computador e UX
Centro Universitário UNA

Heurísticas aplicadas:
1. Visibilidade do Status (#1): Mensagens claras indicando o passo atual do pedido.
2. Controle e Liberdade (#3): Usuário pode digitar "voltar" para corrigir ou "cancelar" para abortar.
3. Ajuda e Erros (#9): Mensagens específicas quando o código do produto não existe ou entrada inválida.
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<int, string> produtos = new Dictionary<int, string>()
        {
            {1, "Coxinha"},
            {2, "Pastel"},
            {3, "Suco"},
            {4, "Refrigerante"},
            {5, "Hambúrguer"},
            {6, "Pizza"},
            {7, "Salada"},
            {8, "Pão de Queijo"},
            {9, "Café"},
            {10, "Chocolate"}
        };

        Console.WriteLine("Bem-vindo à Cantina Digital!");
        Console.WriteLine("Digite 'voltar' para corrigir ou 'cancelar' para sair a qualquer momento.\n");

        int codigoProduto = 0;
        int quantidade = 0;

        // Passo 1: Seleção de Produto
        while (true)
        {
            Console.WriteLine("[Passo 1 de 3] Digite o código do produto (1 a 10):");
            string entrada = Console.ReadLine()?.Trim().ToLower();

            if (entrada == "cancelar")
            {
                Console.WriteLine("Pedido cancelado.");
                return;
            }

            if (int.TryParse(entrada, out codigoProduto))
            {
                if (produtos.ContainsKey(codigoProduto))
                {
                    Console.WriteLine($"Produto selecionado: {produtos[codigoProduto]}");
                    break;
                }
                else
                {
                    Console.WriteLine($"Código {codigoProduto} não encontrado. Nossos códigos vão de 1 a 10. Tente novamente.");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Digite apenas números entre 1 e 10.");
            }
        }

        // Passo 2: Seleção de Quantidade
        while (true)
        {
            Console.WriteLine("[Passo 2 de 3] Digite a quantidade desejada:");
            string entrada = Console.ReadLine()?.Trim().ToLower();

            if (entrada == "cancelar")
            {
                Console.WriteLine("Pedido cancelado.");
                return;
            }
            if (entrada == "voltar")
            {
                // Volta para o passo anterior
                Main();
                return;
            }

            if (int.TryParse(entrada, out quantidade) && quantidade > 0)
            {
                Console.WriteLine($"Quantidade selecionada: {quantidade}");
                break;
            }
            else
            {
                Console.WriteLine("Quantidade inválida. Digite um número inteiro positivo.");
            }
        }

        // Passo 3: Confirmação
        Console.WriteLine("[Passo 3 de 3] Confirmação do Pedido:");
        Console.WriteLine($"Você pediu {quantidade}x {produtos[codigoProduto]}.");
        Console.WriteLine("Digite 'confirmar' para finalizar ou 'voltar' para corrigir.");

        while (true)
        {
            string entrada = Console.ReadLine()?.Trim().ToLower();

            if (entrada == "confirmar")
            {
                Console.WriteLine("Pedido finalizado com sucesso! Obrigado.");
                break;
            }
            else if (entrada == "voltar")
            {
                Main();
                return;
            }
            else if (entrada == "cancelar")
            {
                Console.WriteLine("Pedido cancelado.");
                return;
            }
            else
            {
                Console.WriteLine("Opção inválida. Digite 'confirmar', 'voltar' ou 'cancelar'.");
            }
        }
    }
}
