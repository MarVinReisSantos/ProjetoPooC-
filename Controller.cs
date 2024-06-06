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
                    view.Header("Adicionar um novo produto");
                    code = view.CodeInput();
                    if(repository.checkProductAlreadyRegistered(code)){
                        view.Message("Produto já foi cadastrado.");
                        view.ReturnMessage(repository.AddProduct(view.UpdateStock(code))); 
                    }else{
                        view.ReturnMessage(repository.AddProduct(view.ProductRegistration(code))); 
                    }
                    break;
                case 2:
                    view.Header("Excluir um produto existente");
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
                    view.Header("Visualizar todos os produtos");
                    view.AllProducts(repository.GetAllProduct());
                    break;

                case 5:
                    view.Header("Visualizar os produtos por categoria");
                    System.Console.WriteLine("Está faltando");
                    break;

                case 6:
                    view.Header("Visualizar os produtos pelo nome");
                    System.Console.WriteLine("Está faltando");
                    break;

                case 7:
                    view.Header("Visualizar os produtos pelo nome");
                    System.Console.WriteLine("Está faltando");
                    break;

                case 8:
                    view.Header("Visualizar os produtos pelo nome");
                    System.Console.WriteLine("Está faltando");
                    break;
                case 9:
                    view.Header("Carregar arquivo salvo");
                    System.Console.WriteLine("Está faltando");
                    break;
                case 10:
                    view.Header("Salvar arquivo");
                    System.Console.WriteLine("Está faltando");
                    break;
                case 11:
                    view.ShowGoodBye();
                    break;
                default:
                    view.Message("Erro no sistema!");
                    return;
            }
        }while(choice != 11);
    }
}