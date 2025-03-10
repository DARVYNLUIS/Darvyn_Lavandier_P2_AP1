using Darvyn_Lavandier_P2_AP1.Models;
using Microsoft.EntityFrameworkCore;
using Darvyn_Lavandier_P2_AP1.Models;


namespace Darvyn_Lavandier_P2_AP1.DAL
{

    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    }
}