using Darvyn_Lavandier_P2_AP1.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;


namespace Darvyn_Lavandier_P2_AP1.Services
{
    public class EncuestaService
    {
        private readonly IDbContextFactory<Contexto> _dbFactory;

        public EncuestaService(IDbContextFactory<Contexto> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<bool> Existe(int encuestaId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Encuestas.AnyAsync(e => e.EncuestaId == encuestaId);
        }

        public async Task<bool> Insertar(Encuesta encuesta)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            contexto.Encuestas.Add(encuesta);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Encuesta encuesta)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            contexto.Update(encuesta);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Encuesta encuesta)
        {
            if (!await Existe(encuesta.EncuestaId))
            {
                return await Insertar(encuesta);
            }
            else
            {
                return await Modificar(encuesta);
            }
        }

        public async Task<Encuesta> Buscar(int encuestaId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Encuestas.FirstOrDefaultAsync(e => e.EncuestaId == encuestaId);
        }

        public async Task<bool> Eliminar(int encuestaId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            var encuesta = await contexto.Encuestas.FirstOrDefaultAsync(e => e.EncuestaId == encuestaId);
            if (encuesta == null) return false;

            contexto.Encuestas.Remove(encuesta);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<List<Encuesta>> Listar(Expression<Func<Encuesta, bool>> criterio)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Encuestas.Where(criterio).AsNoTracking().ToListAsync();
        }
    }
}
