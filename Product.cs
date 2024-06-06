using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Product
{
    public string name { get; set; }
    public double price { get; set; }
    public string category { get; set; }
    public int stock { get; set; }
    public int code { get; set; }
    public Product(string name, double price, string category, int stock, int code){
        this.name = name;
        this.price = price;
        this.category = category;
        this.stock = stock;
        this.code = code;
    }
    public Product(int stock, int code){
        this.stock = stock;
        this.code = code;
    }
    public override string ToString()
    {
        return $"Código: {code} - Nome: {name} - Preço: {price:C} - Categoria: {category} - Estoque: {stock}";
    }
}