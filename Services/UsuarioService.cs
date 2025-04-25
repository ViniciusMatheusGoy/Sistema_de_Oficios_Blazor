using GerenciamentoOficios.Models;
using Microsoft.EntityFrameworkCore;

public class UsuarioService{
    private readonly DbContextBanco _dbContext;
    public UsuarioService(DbContextBanco dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<List<Usuario>> GetUsuariosAsync(){
        var list = await _dbContext.Usuarios.ToListAsync();
        return list;
    }

    public async Task<Usuario> GetUsuarioByID(int id){
        var usuario = await _dbContext.Usuarios.Where(e => e.ID== id).FirstAsync();
        return usuario;
    }
    public async Task<List<Usuario>> GetUsuariosBySetor(Setor setor){
        var list = await _dbContext.Usuarios.Where(e => e.Setor==setor).ToListAsync();
        return list;
    }

    public async Task<Usuario> NewUsuarioAsync(Usuario newUsuario){
        _dbContext.Usuarios.Add(newUsuario);
        await _dbContext.SaveChangesAsync();
        return newUsuario;
    }

    public async Task<Usuario> RemomveUsuarioAsync(Usuario usuario){
        _dbContext.Usuarios.Remove(usuario);
        await _dbContext.SaveChangesAsync();
        return usuario;
    }
    public async Task<Usuario> UpdateUsuarioAsync(Usuario usuario){
        _dbContext.Update(usuario);
        await _dbContext.SaveChangesAsync();
        return usuario;
    }
}