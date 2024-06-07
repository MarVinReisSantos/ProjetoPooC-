using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
public class Repository
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

    public string IncreaseStock(Product product){
        var produto = productList.FirstOrDefault(p => p.code == product.code);

        try{
            if (produto != null){
                produto.stock += product.stock;
                return "Estoque incrementado com sucesso!";
            }
            return "Erro ao incrementar o estoque!";
            
        }catch{
            return "Erro ao incrementar o estoque!";
        }
    }
    public string DecrementStock(Product product){
        var produto = productList.FirstOrDefault(p => p.code == product.code);

        try{
            if (produto != null)
            {
                if((produto.stock-product.stock) >= 0){
                    produto.stock -= product.stock;
                    return "Estoque decrementado com sucesso!";
                }

                return $"Não tem no estoque {product.stock} {GetProduct(product.code).name}";
            }else{
                return "Erro ao incrementar o estoque!";
            }
        }catch{
            return "Erro ao incrementar o estoque!";
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
    public Product GetProduct(int code){
        var produto = productList.FirstOrDefault(p => p.code == code);

        if (produto != null)
            return produto;
        
        return produto;
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
    public string SaveFile(){
        XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));

        try{
            using (TextWriter writer = new StreamWriter("produtos.xml")){
                serializer.Serialize(writer, productList);
            }
            return "Arquivo Salvo com sucesso.";
        }catch{
            return "Erro ao salvar o arquivo.";
        }
    }
    public string LoadFile(){
        XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));

        try{
            using (TextReader reader = new StreamReader("produtos.xml")){
                List<Product> deserializedPeople = (List<Product>)serializer.Deserialize(reader);

                foreach (var person in deserializedPeople)
                {
                    AddProduct(person);
                }
            }
        }catch{
            return "Erro ao carregar o arquivo.";
        }
        return "Erro ao carregar o arquivo.";
    }
}