using Microsoft.EntityFrameworkCore;

namespace ApiLenxy.Infrastructure.ExtensionsMethods;
public static partial class ModelBuilderExtensions
{
    public static void ConfigureOwnedTypeNavigationsAsRequired(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (entityType.IsOwned())
            {
                var ownership = entityType.FindOwnership();

                if (ownership is null) return;

                if (ownership.IsUnique)
                {
                    ownership.IsRequiredDependent = true;
                }
            }
        }
    }
}