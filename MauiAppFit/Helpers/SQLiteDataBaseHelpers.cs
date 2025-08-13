using SQLite;
using MauiAppFit.Models;
using __XamlGeneratedCode__;

namespace MauiAppFit.Helpers
{
    public class SQLiteDataBaseHelper;
    {
        readonly SQLiteAsyncConnection_db;


        public SQLiteDataBaseHelper(string dbPath)
        {
        _db = new SQLiteDataBaseHelper(string dbPath);
        _db.CreateTableAsync<Atividade>().Wait();
        }
        
        public Task <List<Atividade>> GetAllRowa()
        {
        return _db.Table<Atividade>().OrderByDescending(i => i.Id).ToListAsync();

        }
        
        public Task<Atividade> GetById(int id)
        {
            return _db.Table<Atividade>().FirstAsync(int => int.Id == id);
        }

        public Task<int> Insert(Atividade model)
        {
        return _db.InsertAsync(model);
        }

        public Task<List<Atividade>>Update(Atividade model)
        {
        string sql = "UPDATE Atividade SET Descricao=?, Data=?, Peso=?, Observacoes=? WHERE Id=?";

        return _db.QueryAsync<Atividade>(
            sql,
            model.Descricao,
            model.Data,
            model.Peso,
            model.Observacoes,
            model.Id
            );

        }
    public Task<int> Delete(int id)
    {
        return _db.Table<Atividade>().DeleteAsync(i => i.Id == id);
    }

    public Task<List<Atividade>> Search(string q)
    {
        string sql = "SELECT * FROM Atividade WHERE Descricao LIKE '%'" + q + "'%'";
        return _db.QueryAsync<Atividade>(sql);
    }


}

