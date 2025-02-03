using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TouristSpot.Infrastructure;

namespace IntegrationTests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test")
                .ConfigureServices(services =>
                {
                    var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<APIDbContext>));
                    if (descriptor is not null)
                        services.Remove(descriptor);

                    var provider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                    services.AddDbContext<APIDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryDbForTesting");
                        options.UseInternalServiceProvider(provider);
                    });

                    var scope = services.BuildServiceProvider().CreateScope();

                    var dbContext = scope.ServiceProvider.GetRequiredService<APIDbContext>();

                    dbContext.Database.EnsureCreated();

                    StartDataBase(dbContext);
                });
        }

        private void StartDataBase(APIDbContext dbContext)
        {
            var touristSpots = new List<TouristSpot.Domain.Entities.TouristSpot>
            {
                new TouristSpot.Domain.Entities.TouristSpot(1, "Praia do Sol", "Praia com águas cristalinas.", "Rua A, 100", "Fortaleza", "CE", DateTime.UtcNow),
                new TouristSpot.Domain.Entities.TouristSpot(2, "Serra Azul", "Local ideal para trilhas.", "Rua B, 200", "Teresópolis", "RJ", DateTime.UtcNow.AddMinutes(5)),
                new TouristSpot.Domain.Entities.TouristSpot(3, "Parque das Aves", "Santuário de aves tropicais.", "Rua C, 300", "Foz do Iguaçu", "PR", DateTime.UtcNow.AddMinutes(10)),
                new TouristSpot.Domain.Entities.TouristSpot(4, "Cachoeira do Dragão", "Cachoeira com queda de 50 metros.", "Estrada 123", "Chapada dos Veadeiros", "GO", DateTime.UtcNow.AddMinutes(15)),
                new TouristSpot.Domain.Entities.TouristSpot(5, "Museu de História Natural", "Exposição sobre biodiversidade.", "Avenida das Flores, 456", "Curitiba", "PR", DateTime.UtcNow.AddMinutes(20)),
                new TouristSpot.Domain.Entities.TouristSpot(6, "Lago dos Cisnes", "Lago com pedalinho.", "Praça do Sol, 789", "Gramado", "RS", DateTime.UtcNow.AddMinutes(25)),
                new TouristSpot.Domain.Entities.TouristSpot(7, "Parque Ecológico Verde", "Área de preservação ambiental.", "Rodovia BR-101", "Vitória", "ES", DateTime.UtcNow.AddMinutes(30)),
                new TouristSpot.Domain.Entities.TouristSpot(8, "Pico do Horizonte", "Montanha com vista panorâmica.", "Trilha da Pedra", "Monte Verde", "MG", DateTime.UtcNow.AddMinutes(35)),
                new TouristSpot.Domain.Entities.TouristSpot(9, "Dunas do Norte", "Formações naturais de areia.", "Praia Grande", "Natal", "RN", DateTime.UtcNow.AddMinutes(40)),
                new TouristSpot.Domain.Entities.TouristSpot(10, "Caverna dos Mistérios", "Sistema de cavernas subterrâneas.", "Estrada do Vale", "Petrolina", "PE", DateTime.UtcNow.AddMinutes(45)),
                new TouristSpot.Domain.Entities.TouristSpot(11, "Jardim Botânico Tropical", "Coleção de plantas tropicais.", "Rua Verde, 900", "Manaus", "AM", DateTime.UtcNow.AddMinutes(50)),
                new TouristSpot.Domain.Entities.TouristSpot(12, "Farol do Pôr do Sol", "Farol histórico.", "Praia do Norte", "Recife", "PE", DateTime.UtcNow.AddMinutes(55)),
                new TouristSpot.Domain.Entities.TouristSpot(13, "Vale Encantado", "Paisagem com cachoeiras.", "Estrada Real", "Diamantina", "MG", DateTime.UtcNow.AddMinutes(60)),
                new TouristSpot.Domain.Entities.TouristSpot(14, "Museu do Café", "História da produção de café.", "Rua XV, 150", "Santos", "SP", DateTime.UtcNow.AddMinutes(65)),
                new TouristSpot.Domain.Entities.TouristSpot(15, "Praça das Artes", "Espaço cultural aberto.", "Centro Histórico", "Olinda", "PE", DateTime.UtcNow.AddMinutes(70)),
                new TouristSpot.Domain.Entities.TouristSpot(16, "Parque das Montanhas", "Área de camping e trilhas.", "Estrada Montanha Azul", "Canela", "RS", DateTime.UtcNow.AddMinutes(75)),
                new TouristSpot.Domain.Entities.TouristSpot(17, "Ilha do Paraíso", "Ilha com resort.", "Mar Azul", "Florianópolis", "SC", DateTime.UtcNow.AddMinutes(80)),
                new TouristSpot.Domain.Entities.TouristSpot(18, "Sítio Arqueológico X", "Ruínas históricas.", "Região Sul", "São Raimundo Nonato", "PI", DateTime.UtcNow.AddMinutes(85)),
                new TouristSpot.Domain.Entities.TouristSpot(19, "Aquário da Amazônia", "Exposição de vida marinha.", "Beira Rio", "Belém", "PA", DateTime.UtcNow.AddMinutes(90)),
                new TouristSpot.Domain.Entities.TouristSpot(20, "Fortaleza Real", "Fortaleza histórica do século XVIII.", "Avenida dos Navegantes", "Salvador", "BA", DateTime.UtcNow.AddMinutes(95))
            };

            if (!dbContext.TouristSpots.Any())
            {
                dbContext.TouristSpots.AddRange(touristSpots);
                dbContext.SaveChanges();
            }
        }
    }
}
