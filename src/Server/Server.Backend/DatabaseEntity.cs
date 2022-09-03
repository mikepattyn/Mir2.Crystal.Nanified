using System.Collections;
using MediatR;
using Server.Database.Models;

public class DatabaseEntity
{
    Type entityType;
    public DatabaseEntity(Type type)
    {
        entityType = type;
    }
    public string Name => entityType.Name.Replace("Domain", "");
    public string[] Headers
    {
        get
        {
            var retVal = entityType
                .GetProperties()
                .Select(x =>
                {
                    if (x.PropertyType.Name.Contains(nameof(ICollection)))
                        return $"{x.Name} ({x.PropertyType.GenericTypeArguments.First().Name.Replace("Domain", "")})";
                    return $"{x.Name} ({x.PropertyType.Name})";
                })
                .ToArray();

            if (entityType.BaseType!.GetFields().Any(x => x.Name.Contains("Id")))
            {
                retVal = retVal.Prepend($"Id ({entityType.BaseType!.GetProperties().First()!.Name})").ToArray();
            }

            return retVal;
        }
    }
    public IEnumerable<string> Values { get; set; }
}