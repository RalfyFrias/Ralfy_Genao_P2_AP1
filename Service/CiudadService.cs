using Microsoft.EntityFrameworkCore;
using Ralfy_Genao_P2_AP1.DAL;
using Ralfy_Genao_P2_AP1.Models;
using System.Linq.Expressions;

namespace Ralfy_Genao_P2_AP1.Service
{
    public class CiudadServices(IDbContextFactory<Context> DbFactory)
    {
        public async Task<List<Ciudades>> Listar(Expression<Func<Ciudades, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Ciudades
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
