using Darvyn_Lavandier_P2_AP1.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Darvyn_Lavandier_P2_AP1.Services
{
    public class CiudadService
    {
        private readonly IDbContextFactory<Contexto> _dbFactory;

        public CiudadService(IDbContextFactory<Contexto> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<bool> Existe(int ciudadId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Ciudades.AnyAsync(c => c.Id == ciudadId);
        }

        public async Task<bool> Insertar(Ciudad ciudad)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            contexto.Ciudades.Add(ciudad);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Ciudad ciudad)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            contexto.Update(ciudad);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Ciudad ciudad)
        {
            if (!await Existe(ciudad.Id))
            {
                return await Insertar(ciudad);
            }
            else
            {
                return await Modificar(ciudad);
            }
        }

        public async Task<Ciudad> Buscar(int ciudadId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Ciudades.FirstOrDefaultAsync(c => c.Id == ciudadId);
        }

        public async Task<bool> Eliminar(int ciudadId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            var ciudad = await contexto.Ciudades.FirstOrDefaultAsync(c => c.Id == ciudadId);
            if (ciudad == null) return false;

            contexto.Ciudades.Remove(ciudad);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<List<Ciudad>> Listar(Expression<Func<Ciudad, bool>> criterio)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Ciudades.Where(criterio).AsNoTracking().ToListAsync();
        }

     
        public async Task<List<Ciudad>> ListarCiudades()
        {
            return await Listar(c => true); 
        }
    }
}
