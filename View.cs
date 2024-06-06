using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class View
{
    public View (){
     
    }
    public Product UpdateStock(int code = 0){
      int stock = 0;

      Console.Write("Quantidade fornecida ao estoque: ");
      while (!int.TryParse(Console.ReadLine(), out stock))
      {
        Console.Write("Quantidade inválida. Digite novamente: ");
      }

      return new Product(stock, code);
    }

    public Product ProductRegistration(int code = 0){
      string name = "";
      string category = "";
      double price = 0;
      int stock = 0;

      Console.Write("Nome: ");
      name = Console.ReadLine();
      
      Console.Write("Preço: ");
      while (!double.TryParse(Console.ReadLine(), out price))
      {
        Console.Write("Preço inválido. Digite novamente: ");
      }
      
      Console.Write("Categoria do produto fornecido ao estoque: ");
      category = Console.ReadLine();
      
      Console.Write("Quantidade fornecida ao estoque: ");
      while (!int.TryParse(Console.ReadLine(), out stock))
      {
        Console.Write("Quantidade inválida. Digite novamente: ");
      }

      return new Product(name, price, category, stock, code);
    }

    public int CodeInput(){
      int code = 0;

      Console.WriteLine("Insira os seguintes detalhes do produto");
      Console.Write("Código do produto: ");
      while (!int.TryParse(Console.ReadLine(), out code))
      {
        Console.Write("Código inválido. Digite novamente: ");
      }

      return code;
    }

    public void Header(string mensagem){
      Console.Clear();
      Console.WriteLine($"=============== {mensagem} ===============\n");
    }
    public void ShowGoodBye(){
      Console.Clear();
      Console.WriteLine("Volte Sempre!");
    }
    public void ReturnMessage(string message){
      Console.WriteLine("\n\t" + message);
      Console.ReadKey();
    }
    public void Message(string message){
      Console.WriteLine(message);
    }
    public void AllProducts(List<Product> products){
      foreach (Product product in products){
        Console.WriteLine(product);
      }
       Console.ReadKey();
    }
    public int ShowMenu(){
      int choice = 0;
      do{
        Console.WriteLine(" 1. Adicionar um novo produto");
        Console.WriteLine(" 2. Excluir um produto existente");
        Console.WriteLine(" 3. Atualizar o produto");
        Console.WriteLine(" 4. Visualizar todos os produtos");
        Console.WriteLine(" 5. Visualizar os produtos por categoria");
        Console.WriteLine(" 6. Visualizar os produtos pelo nome");
        Console.WriteLine(" 7. Visualizar os produtos pelo preço");
        Console.WriteLine(" 8. Procurar um produto");
        Console.WriteLine(" 9. Carregar arquivo salvo");
        Console.WriteLine(" 10. Salvar arquivo");
        Console.WriteLine(" 11. Sair");
        Console.Write("\nDigite sua escolha: ");

        try
        {
          choice = int.Parse(Console.ReadLine());
          if(choice>11 || choice<1) 
            throw new Exception("");
        }
        catch (System.Exception)
        {
          Console.WriteLine("Você digitou uma opcao invalida!");
          Console.ReadKey();
        }

      }while(choice>11 || choice<1);
      
      return choice;
    }
}