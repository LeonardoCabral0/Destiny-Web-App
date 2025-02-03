using Microsoft.EntityFrameworkCore;

namespace TouristSpot.Infrastructure
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Domain.Entities.TouristSpot> TouristSpots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(APIDbContext).Assembly);

            base.OnModelCreating(modelBuilder);

            var touristSpots = new Domain.Entities.TouristSpot[20];
            var startDate = new DateTime(2022, 01, 01);

            var touristSpotsData = new (string Name, string Description, string Localization, string City, string State)[]
            {
            ("Cristo Redentor", "Estátua gigante de Jesus Cristo, localizada no Rio de Janeiro.", "Parque Nacional da Tijuca", "Rio de Janeiro", "RJ"),
            ("Iguazu Falls", "Cataratas do Iguaçu, uma das maiores quedas d'água do mundo.", "Parque Nacional do Iguaçu", "Foz do Iguaçu", "PR"),
            ("Copacabana Beach", "Praia mundialmente famosa no Rio de Janeiro.", "Avenida Atlântica", "Rio de Janeiro", "RJ"),
            ("Pão de Açúcar", "Montanha famosa do Rio de Janeiro com vista panorâmica.", "Urca", "Rio de Janeiro", "RJ"),
            ("Amazônia", "Floresta tropical famosa pela biodiversidade.", "Amazônia", "Manaus", "AM"),
            ("Pantanal", "A maior área úmida do mundo, rica em fauna e flora.", "Pantanal Mato-Grossense", "Cuiabá", "MT"),
            ("Pelourinho", "Centro histórico de Salvador, conhecido por sua arquitetura colonial.", "Centro Histórico", "Salvador", "BA"),
            ("Catedral da Sé", "Catedral gótica imponente localizada em São Paulo.", "Praça da Sé", "São Paulo", "SP"),
            ("Teatro Amazonas", "Teatro histórico situado no coração de Manaus.", "Centro de Manaus", "Manaus", "AM"),
            ("Mercado Municipal", "Mercado tradicional em São Paulo, com produtos típicos.", "Rua da Cantareira", "São Paulo", "SP"),
            ("Lagoa Rodrigo de Freitas", "Lagoa famosa no Rio de Janeiro, rodeada por montanhas.", "Zona Sul", "Rio de Janeiro", "RJ"),
            ("Museu Nacional", "Museu de História Natural e Antropologia no Rio de Janeiro.", "Quinta da Boa Vista", "Rio de Janeiro", "RJ"),
            ("Centro Histórico de Ouro Preto", "Cidade histórica conhecida por sua arquitetura colonial.", "Ouro Preto",  "Ouro Preto","MG"),
            ("Praia do Forte", "Praia paradisíaca e ponto de observação de tartarugas.", "Costa do Sauípe", "Camaçari", "BA"),
            ("Serrinha do Alambari", "Reserva natural em Penedo, com cachoeiras e trilhas.", "Alambari", "Itatiaia", "RJ"),
            ("Parque Nacional de Jericoacoara", "Área de conservação no Ceará com belas praias e dunas.", "Jericoacoara", "Ceará", "CE"),
            ("Cataratas do Iguaçu", "Impressionante conjunto de quedas d'água na fronteira entre Brasil e Argentina.", "Parque Nacional do Iguaçu", "Foz do Iguaçu", "PR"),
            ("Ilha do Cardoso", "Ilha paradisíaca e parque natural no litoral paulista.", "Ilha Cardoso", "Cananéia", "SP"),
            ("São Jorge", "Vila no Parque Nacional da Chapada dos Veadeiros, famosa por suas trilhas.", "Chapada dos Veadeiros", "Chapada dos Veadeiros", "GO"),
            ("Ilha Grande", "Ilha famosa por suas praias e biodiversidade.", "Angra dos Reis", "Angra dos Reis","RJ")
            };

            for (int i = 0; i < touristSpotsData.Length; i++)
            {
                touristSpots[i] = new Domain.Entities.TouristSpot(
                    i + 1,
                    touristSpotsData[i].Name,
                    touristSpotsData[i].Description,
                    touristSpotsData[i].Localization,
                    touristSpotsData[i].City,
                    touristSpotsData[i].State,
                    startDate.AddDays(i)
                );
            }

            modelBuilder.Entity<Domain.Entities.TouristSpot>().HasData(touristSpots);
        }
    }
}
