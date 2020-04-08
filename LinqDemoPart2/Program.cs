using System;
using LinqDemoPart2.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemoPart2 {
    class Program {

        //função auxiliar para fazer um foreach pra cada objeto e printar na tela
        //Print será do tipo T que ira receber string mensagem euma colecao de obj
        //do tipo T com o IEnumerable para ficar compativel com o linq
        static void Print<T>(string mensagem, IEnumerable<T> colecao) {
            //imprime a mensagem
            Console.WriteLine(mensagem);
            //usando o foreach para imprimir cada obj do tipo T da colecao
            foreach (T obj in colecao) {
                Console.WriteLine(obj);
            }
            //salta uma linha
            Console.WriteLine();
        }

        static void Main(string[] args) {


            //CLASSIFICAMOS 3 CATEGORIAS.
            Categoria c1 = new Categoria() { Id = 1, Nome = "Ferramentas", Tier = 2 };
            Categoria c2 = new Categoria() { Id = 2, Nome = "Computadores", Tier = 1 };
            Categoria c3 = new Categoria() { Id = 3, Nome = "Eletronicos", Tier = 1 };

            //instanciamos a lista de produtos (Coleção)
            List<Produto> produtos = new List<Produto>() {
                new Produto(){ Id = 1, Nome = "Computador", Preco = 1100.00, Categoria = c2 },
                new Produto(){ Id = 2, Nome = "Martelo", Preco = 90.0, Categoria = c1 },
                new Produto(){ Id = 3, Nome = "TV", Preco = 1700.00, Categoria = c3 },
                new Produto(){ Id = 4, Nome = "Notebook", Preco = 1300.00, Categoria = c2 },
                new Produto(){ Id = 5, Nome = "Serrote", Preco = 80.0, Categoria = c1 },
                new Produto(){ Id = 6, Nome = "Tablet", Preco = 700.00, Categoria = c2 },
                new Produto(){ Id = 7, Nome = "Camera", Preco = 700.00, Categoria = c3 },
                new Produto(){ Id = 8, Nome = "Printer", Preco = 350.0, Categoria = c3 },
                new Produto(){ Id = 9, Nome = "MacBook", Preco = 1800.00, Categoria = c2 },
                new Produto(){ Id = 10, Nome = "Sound Bar", Preco = 700.0, Categoria = c3 },
                new Produto(){ Id = 11, Nome = "Nivel", Preco = 70.0, Categoria = c1 }
            };
            //aqui usamos a coleção filtrada para ter somente classificação 1 e preco menor que 900.0
            //usamos o Linq e o lambda para fazer isso 
            //var r1 recebe a lista de produtos where (predicado, P tal que "=>" p.categoria.tier seja igual a 1
            // E p.preco seja menor que 900.00
            var r1 = produtos.Where(p => p.Categoria.Tier == 1 && p.Preco < 900.0);
            //aqui iremos usar a função para imprimir a mensagem em "" e depois o r1
            Print("TIER1 AND PRICE < 900:", r1);
            //aqui filtramos a categoria onde Nome da categoria seja igual a ferramentas, e iremos selecionar
            //somente o nome para ser exibido.
            var r2 = produtos.Where(p => p.Categoria.Nome == "Ferramentas").Select(p => p.Nome);
            Print("NAMES OF PRODUCTS FROM TOOLS", r2);
            //O primeiro [0] caracter do p.nome for igual a C, usando o select, vamos colocar um objeto anonimo que
            //é um objeto que não é encontrado em nenhuma das classes, usando o new criamos um "construtor" pegando o que eu quero
            //alem disso precisamos dar apelido no categoria.nome, pq o compilador vai dar erro ja que temos 2 tipos de dados
            //na mesma sentença, p.nome e p.categoria.nome.
            var r3 = produtos.Where(p => p.Nome[0] == 'C').Select(p => new { p.Nome, p.Preco, CategoriaNome = p.Categoria.Nome });
            Print("NAMES STARTED WITH 'C' AND ANONYMOUS OBJECT", r3);
            //pegamos o p.categoria.tier 1 e o ordenar por preço, se o preço for igual usando o thenby para uma segunda ordenação
            //a de nome.
            var r4 = produtos.Where(p => p.Categoria.Tier == 1).OrderBy(p => p.Preco).ThenBy(p => p.Nome);
            Print("NAMES STARTED WITH 'C' AND ANONYMOUS OBJECT", r4);
            //aqui pulamos os 2 primeiros e pegue somente os 4 elementos depois que pulou.
            var r5 = r4.Skip(2).Take(4);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME SKIP 2 TAKE 4", r5);
            //se não encontrar nenhum produto, ele retorna nulo para não ocorrer erros se tivesse colocado somente o First().
            var r6 = produtos.FirstOrDefault();
            Console.WriteLine("First or Default test1: " + r6);
            var r7 = produtos.Where(p => p.Preco > 3000.0).FirstOrDefault();
            Console.WriteLine("First or Default test2: " + r7);
            Console.WriteLine();
            //aqui controlamos se vc quer somente um elemento, não uma coleção.
            var r8 = produtos.Where(p => p.Id == 3).SingleOrDefault();
            Console.WriteLine("Single or Default test1: " + r8);
            var r9 = produtos.Where(p => p.Id == 30).SingleOrDefault();
            Console.WriteLine("Single or Default test2: " + r9);
            Console.WriteLine();
        }
    }
}
