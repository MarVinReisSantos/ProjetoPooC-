using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class View
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
     public void ShowProduct(Product product){
      Console.WriteLine("Detalhes do produto:");
      Console.WriteLine($"Nome:{product.name} - Categoria: {product.category} - Estoque: {product.stock} - Estoque Minimo: {product.stock}");
      Console.ReadKey();
     }

    public Product InputStock(int code = 0){
      int stock = 0;

      Console.Write("Quantos: ");
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
      int stockMin = 0;

      Console.Write("Nome: ");
      name = Console.ReadLine();
      
      Console.Write("Preço: ");
      while (!double.TryParse(Console.ReadLine(), out price))
      {
        Console.Write("Preço inválido. Digite novamente: ");
      }
      
      Console.Write("Categoria: ");
      category = Console.ReadLine();
      
      Console.Write("Quantidade: ");
      while (!int.TryParse(Console.ReadLine(), out stock))
      {
        Console.Write("Quantidade inválida. Digite novamente: ");
      }
      
      Console.Write("Quantidade minima: ");
      while (!int.TryParse(Console.ReadLine(), out stockMin))
      {
        Console.Write("Quantidade minima inválida. Digite novamente: ");
      }

      return new Product(name, price, category, stock, stockMin, code);
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
      if(products.Count == 0){
        Console.WriteLine("Não há produtos cadastrados!");
      }else{
        foreach (Product product in products){
          Console.WriteLine(product);
        }
      }
      
      Console.ReadKey();
    }
    public int ShowMenu(){
      int choice = 0;
      do{
        Console.WriteLine(" 1. Cadastrar novo produto");
        Console.WriteLine(" 2. Excluir produto");
        Console.WriteLine(" 3. Atualizar o produto");
        Console.WriteLine(" 4. Adicionar no estoque");
        Console.WriteLine(" 5. Remover do estoque");
        Console.WriteLine(" 6. Procurar por um produto");
        Console.WriteLine(" 7. Visualizar todos os produtos");
        Console.WriteLine(" 8. Visualizar os produtos pelo nome");
        Console.WriteLine(" 9. Visualizar os produtos pelo preço");
        Console.WriteLine("10. Visualizar os produtos por categoria");
        Console.WriteLine("11. Visualizar os produtos com estoque baixo");
        Console.WriteLine("12. Salvar arquivo");
        Console.WriteLine("13. Carregar arquivo salvo");
        Console.WriteLine("14. Sair");
        Console.Write("\nDigite sua escolha: ");

        try
        {
          while (!int.TryParse(Console.ReadLine(), out choice)){
            Console.Write("Código inválido. Digite novamente: ");
          }

          if(choice>14 || choice<1) 
            throw new Exception("");
        }
        catch (System.Exception)
        {
          Console.WriteLine("Opção inválida. Digite novamente: ");
          Console.ReadKey();
        }

      }while(choice>14 || choice<1);
      
      return choice;
    }
}