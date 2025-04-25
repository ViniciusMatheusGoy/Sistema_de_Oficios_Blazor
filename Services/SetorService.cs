using System.Threading.Tasks;
using GerenciamentoOficios.Models;
using Microsoft.EntityFrameworkCore;

public class SetorService{


    private readonly DbContextBanco _dbContext;
    public SetorService(DbContextBanco dbContext)
    {
        this._dbContext = dbContext;
    }
    public async Task<List<Setor>> GetSetoresAsync(){
        var list = await _dbContext.Setores.ToListAsync();
        return list;
    }

    public async Task<Setor> GetSetorByID(int id){
        var setor = await _dbContext.Setores.Where(e => e.ID == id).FirstAsync();
        return setor;
    }

    public async Task<Setor> NewSetorAsync(Setor newSetor){
        _dbContext.Setores.Add(newSetor);
        await _dbContext.SaveChangesAsync();
        return newSetor;
    }

    public async Task<Setor> UpdateSetorAsync(Setor setor){
        _dbContext.Update(setor);
        await _dbContext.SaveChangesAsync();
        return setor;
    }

    public async Task RemoveSetor(Setor setor){
        _dbContext.Remove(setor);
        await _dbContext.SaveChangesAsync();
    }
}