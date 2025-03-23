using Darvyn_Lavandier_P2_AP1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Darvyn_Lavandier_P2_AP1.Services
{
    public class CiudadServices(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<List<Ciudad>> Listar(Expression<Func<Ciudad, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Ciudades
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Ciudad?> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Ciudades
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CiudadesId == id);
        }

        public async Task<bool> Guardar(Ciudad ciudad)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var ciudadExistente = await contexto.Ciudades
                .FirstOrDefaultAsync(c => c.CiudadesId == ciudad.CiudadesId);

            if (ciudadExistente != null)
            {
             
                contexto.Entry(ciudadExistente).CurrentValues.SetValues(ciudad);
            }
            else
            {
            
                contexto.Ciudades.Add(ciudad);
            }

            return await contexto.SaveChangesAsync() > 0;
        }
    }
}