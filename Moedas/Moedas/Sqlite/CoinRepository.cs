using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moedas.Sqlite
{
    public class CoinRepository 
    { 

    private readonly SQLiteAsyncConnection conn;

    public string StatusMessage { get; set; }

    public CoinRepository(string dbPath)
    {
        conn = new SQLiteAsyncConnection(dbPath);
        conn.CreateTableAsync<CoinSqliteModel>().Wait();
    }

    public async Task AddNewProductAsync(CoinSqliteModel lista)
    {
        try
        {
            if (lista == null)
                throw new Exception("Digite um nome valido");
            if (lista.ID != 0)
            {
                var result = await conn.UpdateAsync(lista);
            }
            else
            {
                var result = await conn.InsertAsync(lista);
            }

            StatusMessage = string.Format("Single data file inserted or updated");
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Ja foi adicionado{0}. : {1}", lista, ex.Message);
        }
    }


    public Task<List<CoinSqliteModel>> GetAllProductAsync()
    {
        return conn.Table<CoinSqliteModel>().ToListAsync();
    }

    //deleta lista inteira
    public async Task DeleteListProductsAsync()
    {
        try
        {
            //await conn.QueryAsync<Lista>("DROP TABLE lista");
            await conn.QueryAsync<CoinSqliteModel>("DELETE FROM listaShop");
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Conteudo da Lista nao Deletada:", "", ex.Message);
        }
    }

    public async Task DropTable()
    {
        try
        {
            //await conn.QueryAsync<Lista>("DROP TABLE listaShop");
            await conn.QueryAsync<CoinSqliteModel>("DELETE FROM listaShop");
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Conteudo da Lista nao Deletada:", "", ex.Message);
        }
    }
    //deletar apenas um 
    public async Task RemoveProductAsync(int id)
    {
        try
        {
            //basic validation to ensure a name was entered
            if (string.IsNullOrEmpty(id.ToString()) && string.IsNullOrEmpty(id.ToString()))
                throw new Exception("Nome Invalido para deletar");

            await conn.QueryAsync<CoinSqliteModel>("DELETE FROM [lista] WHERE [Id] = " + id);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Ja foi deletado{0}. : {1}", id.ToString(), ex.Message);
        }
    }


    public async Task DeleteAllListaAsync()
    {

        try
        {

            //await conn.QueryAsync<Lista>("DROP TABLE lista");
            await conn.QueryAsync<CoinSqliteModel>("DELETE FROM lista");

        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Conteudo da Lista nao Deletada:", "", ex.Message);
        }
    }


    public async Task UpdateItemAsync(CoinSqliteModel item)
    {
        if (item.ID != 0)
        {
            try
            {
                var result = await conn.UpdateAsync(item);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Conteudo da Lista nao Atualizado:", "", ex.Message);
            }
        }
    }

}
}