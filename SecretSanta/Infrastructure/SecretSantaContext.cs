using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecretSanta.Domain;

namespace SecretSanta.Infrastructure
{
  public class SecretSantaContext: IdentityDbContext<ApplicationUser>
  {
    /// <summary>
    /// Инициализирует новый экземпляр контекста базы данных с указанными параметрами
    /// </summary>
    /// <param name="options">Опции для конфигурации контекста базы данных</param>
    public SecretSantaContext(DbContextOptions<SecretSantaContext> options)
      : base(options)
    {
    }
    
    public DbSet<Participant> Participants { get; set; } = default!;
    public DbSet<Box> Boxes { get; set; } = default!;
  }
}
