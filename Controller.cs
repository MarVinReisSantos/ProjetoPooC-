using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Controller
{
    private View view;
    private Repository repository;

    public Controller(View view, Repository repository){
        this.view = view;
        this.repository = repository;
    }
    public void Start(){
        int choice = 0;
        int code = 0;
        do{
            view.Header("Menu Principal");
            choice = view.ShowMenu();

            switch (choice)
            {
                case 1:
                    view.Header("Cadastrar novo produto");
                    code = view.CodeInput();
                    if(repository.checkProductAlreadyRegistered(code)){
                        view.ReturnMessage("Id já foi cadastrado para outro produto.");
                    }else{
                        view.ReturnMessage(repository.AddProduct(view.ProductRegistration(code))); 
                    }
                break;

                case 2:
                    view.Header("Excluir produto");
                    code = view.CodeInput();
                    view.ReturnMessage(repository.RemoveProduct(code));
                break;

                case 3:
                    view.Header("Atualizar o produto");
                    code = view.CodeInput();
                    if(repository.checkProductAlreadyRegistered(code)){
                        view.ReturnMessage(repository.UpdateProduct(view.ProductRegistration(code))); 
                    }else{
                        view.ReturnMessage("Produto não encontrado!");
                    }
                break;

                case 4:
                    view.Header("Adicionar no estoque");
                    code = view.CodeInput();
                    if(repository.checkProductAlreadyRegistered(code)){
                        view.ShowProduct(repository.GetProduct(code));
                        view.ReturnMessage(repository.IncreaseStock(view.InputStock(code)));   
                    }else{
                         view.ReturnMessage("Produto não encontrado!");
                    }
                break;

                case 5:
                    view.Header("Remover do estoque");
                    code = view.CodeInput();
                    if(repository.checkProductAlreadyRegistered(code)){
                        view.ShowProduct(repository.GetProduct(code));
                        view.ReturnMessage(repository.DecrementStock(view.InputStock(code)));   
                    }else{
                         view.ReturnMessage("Produto não encontrado!");
                    }
                break;
                
                case 6:
                    view.Header("Procurar por um produto");
                    code = view.CodeInput();
                    if(repository.checkProductAlreadyRegistered(code)){
                         view.ShowProduct(repository.GetProduct(code));
                    }else{
                         view.ReturnMessage("Produto não encontrado!");
                    }
                break;

                case 7:
                    view.Header("Visualizar todos os produtos");
                    view.AllProducts(repository.GetAllProduct());
                break;

                case 8:
                    view.Header("Visualizar os produtos pelo nome");
                    System.Console.WriteLine("Está faltando");
                break;

                case 9:
                    view.Header("Visualizar os produtos pelo preço");
                    System.Console.WriteLine("Está faltando");
                break;
                
                case 10:
                    view.Header("Visualizar os produtos por categoria");
                    System.Console.WriteLine("Está faltando");
                break;
                
                case 11:
                    view.Header("Visualizar os produtos com estoque baixo");
                    System.Console.WriteLine("Está faltando");
                break;
                
                case 12:
                    view.Header("Salvar arquivo");
                    view.ReturnMessage(repository.SaveFile());
                break;
                
                case 13:
                    view.Header("Carregar arquivo salvo");
                    view.ReturnMessage(repository.LoadFile());
                break;
                
                case 14:
                    view.ShowGoodBye();
                    return;
                
                default:
                    view.Message("Erro no sistema!");
                    return;
            }
        }while(true);
    }
}