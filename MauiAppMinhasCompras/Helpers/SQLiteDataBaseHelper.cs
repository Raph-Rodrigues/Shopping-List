using System;
using SQLite;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Helpers;

public class SQLiteDataBaseHelper
{
    readonly SQLiteAsyncConnection _connection;

    public SQLiteDataBaseHelper(string path) {
        _connection = new SQLiteAsyncConnection(path);
        _connection.CreateTableAsync<Produto>().Wait();
    }

    public Task<int> Insert(Produto p) {
        return _connection.InsertAsync(p);
    }

    public Task<List<Produto>> Update(Produto p) {
        string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE Id=?";
        return _connection.QueryAsync<Produto>(
            sql, p.Descricao, p.Quantidade, p.Preco, p.Id);
    }

    public Task<int> Delete(int Id) {
        return _connection.Table<Produto>().DeleteAsync(i => i.Id == Id);
    }

    public Task<List<Produto>> GetAll() {
        return _connection.Table<Produto>().ToListAsync();
    }

    public Task<List<Produto>> Search(string p) {
        string sql = "SELECT * FROM Produto WHERE Descricao LIKE '%" + p + "%'";
        return _connection.QueryAsync<Produto>(sql);
    }
}
