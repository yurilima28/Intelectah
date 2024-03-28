using Intelectah.Models;
using Microsoft.EntityFrameworkCore;

namespace Intelectah.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options): base(options) 
        {

        }
        public DbSet<PacienteModel> Pacientes { get; set; }
        public DbSet<TipoExameModel> TipoExames { get; set; }
        public DbSet<ExameModel> Exames { get; set; }
        public DbSet<ConsultaModel> Consulta { get; set; }
    }
}
