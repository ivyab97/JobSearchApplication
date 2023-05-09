using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationStatusType",
                columns: table => new
                {
                    ApplicationStatusTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationStatusType", x => x.ApplicationStatusTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    ExperienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.ExperienceId);
                });

            migrationBuilder.CreateTable(
                name: "StudyLevel",
                columns: table => new
                {
                    StudyLevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyLevel", x => x.StudyLevelId);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    OfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    StudyLevelId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.OfferId);
                    table.ForeignKey(
                        name: "FK_Offer_Experience_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experience",
                        principalColumn: "ExperienceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offer_StudyLevel_StudyLevelId",
                        column: x => x.StudyLevelId,
                        principalTable: "StudyLevel",
                        principalColumn: "StudyLevelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationStatusTypeId = table.Column<int>(type: "int", nullable: false),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    OfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Application_ApplicationStatusType_ApplicationStatusTypeId",
                        column: x => x.ApplicationStatusTypeId,
                        principalTable: "ApplicationStatusType",
                        principalColumn: "ApplicationStatusTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application_Offer_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offer",
                        principalColumn: "OfferId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfferCategory",
                columns: table => new
                {
                    OfferCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferCategory", x => x.OfferCategoryId);
                    table.ForeignKey(
                        name: "FK_OfferCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferCategory_Offer_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offer",
                        principalColumn: "OfferId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ApplicationStatusType",
                columns: new[] { "ApplicationStatusTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Postulado" },
                    { 2, "CV Visto" },
                    { 3, "En evaluación" },
                    { 4, "Finalista" },
                    { 5, "Proceso finalizado" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Tecnología" },
                    { 2, "Marketing" },
                    { 3, "Diseño" },
                    { 4, "Administración" },
                    { 5, "Finanzas" },
                    { 6, "Recursos humanos" },
                    { 7, "Ventas" },
                    { 8, "Servicio al cliente" },
                    { 9, "Logística" },
                    { 10, "Producción" },
                    { 11, "Educación" },
                    { 12, "Salud" },
                    { 13, "Investigación" },
                    { 14, "Arte y cultura" },
                    { 15, "Medios de comunicación" },
                    { 16, "Derecho" },
                    { 17, "Profesorado" },
                    { 18, "Ingeniería" },
                    { 19, "Mecànica" },
                    { 20, "Agricultura" },
                    { 21, "Medio ambiente" },
                    { 22, "Gastronomía" },
                    { 23, "Gestión de proyectos" },
                    { 24, "Consultoría" },
                    { 25, "Análisis de datos" },
                    { 26, "Química" },
                    { 27, "Medicina" },
                    { 28, "Enfermería" },
                    { 29, "Psicología" },
                    { 30, "Trabajo social" },
                    { 31, "Arquitectura" },
                    { 32, "Fotografía" },
                    { 33, "Estadística" }
                });

            migrationBuilder.InsertData(
                table: "Experience",
                columns: new[] { "ExperienceId", "Name" },
                values: new object[,]
                {
                    { 1, "Sin Experiencia" },
                    { 2, "1 Año" },
                    { 3, "2 Años" },
                    { 4, "3 Años" },
                    { 5, "4 Años" },
                    { 6, "5 Años" },
                    { 7, "6 Años" },
                    { 8, "7 Años" },
                    { 9, "8 Años" }
                });

            migrationBuilder.InsertData(
                table: "StudyLevel",
                columns: new[] { "StudyLevelId", "Name" },
                values: new object[,]
                {
                    { 1, "Primaria" },
                    { 2, "Secundaria" },
                    { 3, "Terciario" },
                    { 4, "Universitario" },
                    { 5, "Posgrado" },
                    { 6, "Master" },
                    { 7, "Doctorado" },
                    { 8, "Sin estudios" }
                });

            migrationBuilder.InsertData(
                table: "Offer",
                columns: new[] { "OfferId", "CityId", "CompanyId", "Date", "Description", "ExperienceId", "ProvinceId", "Salary", "Status", "StudyLevelId", "Title" },
                values: new object[,]
                {
                    { new Guid("1d394678-e0eb-4620-a1de-f01c7768ddb3"), 60091, 1, new DateTime(2023, 4, 22, 10, 27, 32, 895, DateTimeKind.Unspecified).AddTicks(6499), "Importante empresa Autopartista se encuentra en la búsqueda de Programador Robotista.", 2, 6, 200000, true, 4, "Programador Robotista." },
                    { new Guid("3b4010d9-e137-465d-9a4b-d97b28b87bbe"), 60441, 4, new DateTime(2023, 4, 23, 10, 27, 32, 895, DateTimeKind.Unspecified).AddTicks(6499), "Estamos en la búsqueda de Responsable general para empresa con negocios en rubro inmobiliario y de playas de estacionamiento.", 3, 6, 200000, true, 5, "Administrador/ Contador." },
                    { new Guid("3da7995a-715f-40b8-8121-b2ffdee778b0"), 60274, 2, new DateTime(2023, 5, 22, 12, 13, 20, 71, DateTimeKind.Unspecified).AddTicks(9537), "Buscamos Desarrollador SQL Server Junior/SSR. para sumarse a importante empresa de producto IT, líder en la creación de soluciones para el sector de salud.", 3, 6, 220000, true, 4, "Desarrollador SQL Server Jr/SSr" },
                    { new Guid("4093643c-135b-4368-ace5-e1783dd3f0f8"), 60091, 3, new DateTime(2023, 4, 22, 8, 5, 20, 446, DateTimeKind.Unspecified).AddTicks(6304), "En Ecosistemas estamos en la búsqueda de un Administrador de Backups Ssr/Sr para sumarse a nuestro equipo", 3, 6, 250000, true, 3, "Administrador de Infraestructura Ssr." },
                    { new Guid("8a527fd3-962a-4abf-b18f-efcdb6004f07"), 60147, 3, new DateTime(2023, 4, 22, 7, 50, 18, 989, DateTimeKind.Unspecified).AddTicks(830), "Desde Ecosistemas nos encontramos en la búsqueda de un Analista Funcional Jr/Ssr, para sumarse al equipo de nuestro cliente, empresa agropecuaria.", 2, 6, 200000, true, 3, "Analista Funcional Jr o Ssr." },
                    { new Guid("994ec6d1-3560-4fc6-be23-e078def32527"), 60091, 3, new DateTime(2023, 3, 22, 12, 11, 59, 975, DateTimeKind.Unspecified).AddTicks(193), "En Ecosistemas, buscamos un Desarrollador Java Jr/Ssr para sumar al equipo de nuestro cliente, en relación directa con el mismo.", 1, 6, 180000, true, 2, "Desarrollador Java Jr." },
                    { new Guid("e058b366-f832-42dd-b001-647919fdfd66"), 60091, 1, new DateTime(2023, 4, 22, 8, 5, 19, 374, DateTimeKind.Unspecified).AddTicks(9336), "Buscamos Desarrollador .NET Junior/Ssr. para sumarse a importante empresa de producto IT, líder en la creación de soluciones para el sector de salud.", 3, 6, 200000, true, 4, "Desarrollador .NET Junior/Ssr." },
                    { new Guid("ee69bf0e-735f-44ff-9712-96830fddbf3a"), 60560, 2, new DateTime(2023, 4, 23, 8, 5, 19, 374, DateTimeKind.Unspecified).AddTicks(9336), "Buscamos AUXLIAR DE OPERACIONES SISTEMAS.", 1, 6, 150000, true, 4, "Analista programador/a de sistemas." },
                    { new Guid("f1b4f44e-05fb-4062-a247-6830964ef063"), 60658, 2, new DateTime(2023, 3, 22, 8, 4, 50, 928, DateTimeKind.Unspecified).AddTicks(6762), "Buscamos Desarrollador .NET Junior/Ssr. para sumarse a importante empresa de producto IT, líder en la creación de soluciones para el sector de salud.", 1, 6, 120000, true, 3, "Desarrollador .NET Junior." }
                });

            migrationBuilder.InsertData(
                table: "OfferCategory",
                columns: new[] { "OfferCategoryId", "CategoryId", "OfferId", "Status" },
                values: new object[,]
                {
                    { 1, 1, new Guid("e058b366-f832-42dd-b001-647919fdfd66"), true },
                    { 2, 3, new Guid("e058b366-f832-42dd-b001-647919fdfd66"), true },
                    { 3, 1, new Guid("f1b4f44e-05fb-4062-a247-6830964ef063"), true },
                    { 4, 3, new Guid("f1b4f44e-05fb-4062-a247-6830964ef063"), true },
                    { 5, 1, new Guid("ee69bf0e-735f-44ff-9712-96830fddbf3a"), true },
                    { 6, 25, new Guid("ee69bf0e-735f-44ff-9712-96830fddbf3a"), true },
                    { 7, 33, new Guid("e058b366-f832-42dd-b001-647919fdfd66"), true },
                    { 8, 25, new Guid("3da7995a-715f-40b8-8121-b2ffdee778b0"), true },
                    { 9, 33, new Guid("3da7995a-715f-40b8-8121-b2ffdee778b0"), true },
                    { 10, 23, new Guid("994ec6d1-3560-4fc6-be23-e078def32527"), true },
                    { 11, 25, new Guid("994ec6d1-3560-4fc6-be23-e078def32527"), true },
                    { 12, 33, new Guid("994ec6d1-3560-4fc6-be23-e078def32527"), true },
                    { 13, 4, new Guid("4093643c-135b-4368-ace5-e1783dd3f0f8"), true },
                    { 14, 18, new Guid("4093643c-135b-4368-ace5-e1783dd3f0f8"), true },
                    { 15, 23, new Guid("4093643c-135b-4368-ace5-e1783dd3f0f8"), true },
                    { 16, 25, new Guid("4093643c-135b-4368-ace5-e1783dd3f0f8"), true },
                    { 17, 31, new Guid("4093643c-135b-4368-ace5-e1783dd3f0f8"), true },
                    { 18, 1, new Guid("8a527fd3-962a-4abf-b18f-efcdb6004f07"), true },
                    { 19, 4, new Guid("8a527fd3-962a-4abf-b18f-efcdb6004f07"), true },
                    { 20, 25, new Guid("8a527fd3-962a-4abf-b18f-efcdb6004f07"), true },
                    { 21, 18, new Guid("1d394678-e0eb-4620-a1de-f01c7768ddb3"), true },
                    { 22, 19, new Guid("1d394678-e0eb-4620-a1de-f01c7768ddb3"), true },
                    { 23, 4, new Guid("3b4010d9-e137-465d-9a4b-d97b28b87bbe"), true },
                    { 24, 5, new Guid("3b4010d9-e137-465d-9a4b-d97b28b87bbe"), true },
                    { 25, 24, new Guid("3b4010d9-e137-465d-9a4b-d97b28b87bbe"), true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application_ApplicationStatusTypeId",
                table: "Application",
                column: "ApplicationStatusTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Application_OfferId",
                table: "Application",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_ExperienceId",
                table: "Offer",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_StudyLevelId",
                table: "Offer",
                column: "StudyLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferCategory_CategoryId",
                table: "OfferCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferCategory_OfferId",
                table: "OfferCategory",
                column: "OfferId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "OfferCategory");

            migrationBuilder.DropTable(
                name: "ApplicationStatusType");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropTable(
                name: "StudyLevel");
        }
    }
}
