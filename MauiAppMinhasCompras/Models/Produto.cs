using System;
using SQLite;

namespace MauiAppMinhasCompras.Models;

public class Produto
{
    string _descricao;

    public int Id { get; set; }
    public string Descricao {
        get => _descricao;
        set 
        {
            if (value == null)
            {
                throw new Exception("Por Favor, preencha a descrição");
            }

            _descricao = value;
        }
    }

    [PrimaryKey, AutoIncrement]
    public double Quantidade { get; set; }
    public double Preco { get; set; }
    public double Total { get => Quantidade * Preco; }
}
