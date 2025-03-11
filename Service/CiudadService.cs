using Microsoft.EntityFrameworkCore;
using Ralfy_Genao_P2_AP1.DAL;
using Ralfy_Genao_P2_AP1.Models;
using System.Linq.Expressions;

namespace Ralfy_Genao_P2_AP1.Service
{
    public class CiudadService
    {
        public class CiudadServices(IDbContextFactory<Contexto> DbFactory)
        {
            public async Task<bool> Existe(int CiudadId)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                return await contexto.ciudades.AnyAsync(c => c.CiudadId == CiudadId);
            }

            private async Task<bool> Insertar(Ciudades ciudad)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                contexto.ciudades.Add(ciudad);
                return await contexto.SaveChangesAsync() > 0;
            }

            private async Task<bool> Modificar(Ciudades ciudad)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                contexto.ciudades.Update(ciudad);
                return await contexto.SaveChangesAsync() > 0;
            }

            public async Task<bool> Guardar(Ciudades ciudad)
            {
                if (!await Existe(ciudad.CiudadId))
                    return await Insertar(ciudad);
                else
                    return await Modificar(ciudad);
            }
           
            public async Task<bool> Eliminar(int id)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                var eliminado = await contexto.ciudades
                .Where(c => c.CiudadId == id)
                    .ExecuteDeleteAsync();
                return eliminado > 0;
            }

            public async Task<Ciudades?> Buscar(int id)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                return await contexto.ciudades
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CiudadId == id);
            }

            public async Task<List<Ciudades>> Listar(Expression<Func<Ciudades, bool>> Criterio)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                return await contexto.ciudades
                    .AsNoTracking()
                    .Where(Criterio)
                    .ToListAsync();
            }
        }

    }
}
