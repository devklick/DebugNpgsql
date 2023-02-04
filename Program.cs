using DebugNpgsql.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Npgsql;
using Npgsql.NameTranslation;

namespace DebugNpgsql;

internal class Program
{
    static void Main(string[] args)
    {
        Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                var dataSourceBuilder = new NpgsqlDataSourceBuilder("Server=127.0.0.1;Port=5432;Database=DebugNpgsql;User Id=postgres;Password=MyPassword;")
                {
                    DefaultNameTranslator = new NpgsqlSnakeCaseNameTranslator()
                };

                dataSourceBuilder.MapEnum<MyEnum>();
                var dataSource = dataSourceBuilder.Build();

                services.AddDbContext<MyDbContext>(options => options.UseNpgsql(dataSource));
                services.AddHostedService<MyHost>();
            })
            .Build()
            .Start();
    }
}