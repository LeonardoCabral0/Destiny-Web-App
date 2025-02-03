using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TouristSpot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedTouristSpotsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TouristSpots",
                columns: new[] { "Id", "City", "CreatedDate", "Description", "Localization", "Name", "State" },
                values: new object[,]
                {
                    { 1, "Rio de Janeiro", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Estátua gigante de Jesus Cristo, localizada no Rio de Janeiro.", "Parque Nacional da Tijuca", "Cristo Redentor", "RJ" },
                    { 2, "Foz do Iguaçu", new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cataratas do Iguaçu, uma das maiores quedas d'água do mundo.", "Parque Nacional do Iguaçu", "Iguazu Falls", "PR" },
                    { 3, "Rio de Janeiro", new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Praia mundialmente famosa no Rio de Janeiro.", "Avenida Atlântica", "Copacabana Beach", "RJ" },
                    { 4, "Rio de Janeiro", new DateTime(2022, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Montanha famosa do Rio de Janeiro com vista panorâmica.", "Urca", "Pão de Açúcar", "RJ" },
                    { 5, "Manaus", new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Floresta tropical famosa pela biodiversidade.", "Amazônia", "Amazônia", "AM" },
                    { 6, "Cuiabá", new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "A maior área úmida do mundo, rica em fauna e flora.", "Pantanal Mato-Grossense", "Pantanal", "MT" },
                    { 7, "Salvador", new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Centro histórico de Salvador, conhecido por sua arquitetura colonial.", "Centro Histórico", "Pelourinho", "BA" },
                    { 8, "São Paulo", new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Catedral gótica imponente localizada em São Paulo.", "Praça da Sé", "Catedral da Sé", "SP" },
                    { 9, "Manaus", new DateTime(2022, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teatro histórico situado no coração de Manaus.", "Centro de Manaus", "Teatro Amazonas", "AM" },
                    { 10, "São Paulo", new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mercado tradicional em São Paulo, com produtos típicos.", "Rua da Cantareira", "Mercado Municipal", "SP" },
                    { 11, "Rio de Janeiro", new DateTime(2022, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lagoa famosa no Rio de Janeiro, rodeada por montanhas.", "Zona Sul", "Lagoa Rodrigo de Freitas", "RJ" },
                    { 12, "Rio de Janeiro", new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Museu de História Natural e Antropologia no Rio de Janeiro.", "Quinta da Boa Vista", "Museu Nacional", "RJ" },
                    { 13, "Ouro Preto", new DateTime(2022, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cidade histórica conhecida por sua arquitetura colonial.", "Ouro Preto", "Centro Histórico de Ouro Preto", "MG" },
                    { 14, "Camaçari", new DateTime(2022, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Praia paradisíaca e ponto de observação de tartarugas.", "Costa do Sauípe", "Praia do Forte", "BA" },
                    { 15, "Itatiaia", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reserva natural em Penedo, com cachoeiras e trilhas.", "Alambari", "Serrinha do Alambari", "RJ" },
                    { 16, "Ceará", new DateTime(2022, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Área de conservação no Ceará com belas praias e dunas.", "Jericoacoara", "Parque Nacional de Jericoacoara", "CE" },
                    { 17, "Foz do Iguaçu", new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Impressionante conjunto de quedas d'água na fronteira entre Brasil e Argentina.", "Parque Nacional do Iguaçu", "Cataratas do Iguaçu", "PR" },
                    { 18, "Cananéia", new DateTime(2022, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ilha paradisíaca e parque natural no litoral paulista.", "Ilha Cardoso", "Ilha do Cardoso", "SP" },
                    { 19, "Chapada dos Veadeiros", new DateTime(2022, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vila no Parque Nacional da Chapada dos Veadeiros, famosa por suas trilhas.", "Chapada dos Veadeiros", "São Jorge", "GO" },
                    { 20, "Angra dos Reis", new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ilha famosa por suas praias e biodiversidade.", "Angra dos Reis", "Ilha Grande", "RJ" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TouristSpots",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TouristSpots",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TouristSpots",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TouristSpots",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TouristSpots",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TouristSpots",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TouristSpots",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TouristSpots",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TouristSpots",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TouristSpots",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TouristSpots",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TouristSpots",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TouristSpots",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TouristSpots",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TouristSpots",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TouristSpots",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TouristSpots",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TouristSpots",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TouristSpots",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TouristSpots",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
