using Microsoft.EntityFrameworkCore;
using Ralfy_Genao_P2_AP1.DAL;
using Ralfy_Genao_P2_AP1.Models;
using System.Linq.Expressions;

namespace Ralfy_Genao_P2_AP1.Service
{
    public class EncuestaServices(IDbContextFactory<Context> DbFactory)
    {
        public async Task<bool> Existe(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Encuestas.AnyAsync(c => c.EncuestasId == id);
        }

        private async Task<bool> Insertar(Encuestas encuesta)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            
            contexto.Encuestas.Add(encuesta);

            
            foreach (var detalle in encuesta.EncuestaDetalles)
            {
                if (detalle.Ciudad != null && detalle.Ciudad.CiudadesId > 0)
                {
                    contexto.Entry(detalle.Ciudad).State = EntityState.Unchanged;
                }
                else if (detalle.CiudadId <= 0)
                {
                    throw new InvalidOperationException($"El CiudadId {detalle.CiudadId} no es válido para el detalle.");
                }
            }

            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Encuestas encuesta)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

      
            contexto.Entry(encuesta).State = EntityState.Modified;

            
            foreach (var detalle in encuesta.EncuestaDetalles)
            {
                if (detalle.DetallesId== 0) 
                {
                    contexto.Entry(detalle).State = EntityState.Added;
                }
                else 
                {
                    contexto.Entry(detalle).State = EntityState.Modified;
                }

                
                if (detalle.CiudadId <= 0)
                {
                    throw new InvalidOperationException($"El CiudadId {detalle.CiudadId} no es válido para el detalle.");
                }

                
                if (detalle.Ciudad != null && detalle.Ciudad.CiudadesId > 0)
                {
                    contexto.Entry(detalle.Ciudad).State = EntityState.Unchanged;
                }
            }

            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Encuestas encuesta)
        {
            if (!await Existe(encuesta.EncuestasId))
                return await Insertar(encuesta);
            else
                return await Modificar(encuesta);
        }

        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var encuesta = await contexto.Encuestas
                .Where(i => i.EncuestasId == id)
                .ExecuteDeleteAsync();
            return encuesta > 0;
        }

        public async Task<Encuestas?> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Encuestas
                .Include(e => e.EncuestaDetalles)
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.EncuestasId == id);
        }

        public async Task<List<Encuestas>> Listar(Expression<Func<Encuestas, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Encuestas
                .Include(e => e.EncuestaDetalles)
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}