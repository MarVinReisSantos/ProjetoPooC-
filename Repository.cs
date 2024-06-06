using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Repository
{
    private List<Product> productList = new List<Product>();
    public Repository(){

    }

    public string AddProduct(Product product){

        var produto = productList.FirstOrDefault(p => p.code == product.code);

        try{
            if (produto != null)
            {
                produto.stock = product.stock;
                return "Produto já Existente, estoque atualizado!";
            }else{
                productList.Add(product);
                return "Novo produto inserido com sucesso!";
            }
        }catch{
            return "Erro ao cadastrar novo produto!";
        }
    }
    public string UpdateProduct(Product product){

        var produto = productList.FirstOrDefault(p => p.code == product.code);

        try{
            if (produto != null)
            {
                produto.name = product.name;
                produto.price = product.price;
                produto.category = product.category;
                produto.stock = product.stock;
            
                return "Produto atualizado!";
            }else{
                return "Produto não encontrado!";
            }
        }catch{
            return "Erro ao cadastrar novo produto!";
        }
    }
    public bool checkProductAlreadyRegistered(int code){
        var produto = productList.FirstOrDefault(p => p.code == code);

        if (produto != null)
            return true;
        
        return false;
    }
    public string RemoveProduct(int code){
        var produto = productList.FirstOrDefault(p => p.code == code);

        try{
            if (produto != null){
                productList.Remove(produto);
                return "Produto removido com sucesso!";
            }else{
                return "Produto não encontrado.";
            }
        }catch{
            return "Erro excluir o produto!";
        }
    }
    public List<Product> GetAllProduct(){
        return productList;
    }
}