using GerenciamentoOficios.Models;
using Microsoft.EntityFrameworkCore;

public class OficioService{
    private readonly DbContextBanco _dbContext;
    public OficioService(DbContextBanco dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<Oficio> GetOficioByID(int id){
        var oficio = await _dbContext.Oficios.Where(e => e.ID==id).FirstAsync();
        return oficio;
    }

    public async Task<List<Oficio>> GetOficiosByRemetente(Usuario usuario){
        var list = await _dbContext.Oficios.Where(e => usuario.ID == e.RemetenteID).ToListAsync();
        return list;
    }

    public async Task<List<Oficio>> GetOficiosByDestinatario(Usuario usuario){
        var list = await _dbContext.Oficios.Where(e => usuario.ID == e.DestinatarioID).ToListAsync();
        return list;
    }

    public async Task<Oficio> NewOficio(Oficio oficio){
        _dbContext.Oficios.Add(oficio);
        await _dbContext.SaveChangesAsync();
        return oficio;
    }

    public async Task<Oficio> RemoveOficioAsync(Oficio oficio){
        _dbContext.Remove(oficio);
        await _dbContext.SaveChangesAsync();
        return oficio;
    }
}