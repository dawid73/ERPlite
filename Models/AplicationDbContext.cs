using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace erplite.Models
{
    /**
     * Klasa która zapewnia interakcję aplikacji z danymi w bazie danych
     * Klasa korzysta z paczki Microsoft.EntityFrameworkCore
     */
    public class AplicationDbContext:DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }

        //Tabela "Contractors" w SQL
        public DbSet<NewContractorClass> Contractors { get; set; }
    }
}
