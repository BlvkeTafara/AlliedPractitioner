using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Practitioner.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PracContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PractitionerId = table.Column<int>(type: "integer", nullable: false),
                    PrimaryPhone = table.Column<int>(type: "integer", nullable: false),
                    SecondaryPhone = table.Column<int>(type: "integer", nullable: false),
                    ProvinceId = table.Column<int>(type: "integer", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhysicalAddress = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PracEmployers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BusinessAddress = table.Column<string>(type: "text", nullable: false),
                    PractitionerId = table.Column<int>(type: "integer", nullable: false),
                    ProvinceId = table.Column<int>(type: "integer", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    ContactPerson = table.Column<string>(type: "text", nullable: false),
                    JobTitle = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    CommencementDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracEmployers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PracExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BusinessAddress = table.Column<string>(type: "text", nullable: false),
                    ContactPerson = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    JobTitle = table.Column<string>(type: "text", nullable: false),
                    PractitionerId = table.Column<int>(type: "integer", nullable: false),
                    ProvinceId = table.Column<int>(type: "integer", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    CommencementDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ResignationDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracExperiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PracBalances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PracEmployerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PracBalances_PracEmployers_PracEmployerId",
                        column: x => x.PracEmployerId,
                        principalTable: "PracEmployers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PracContactPracEmployer",
                columns: table => new
                {
                    pracContactsId = table.Column<int>(type: "integer", nullable: false),
                    pracEmployersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracContactPracEmployer", x => new { x.pracContactsId, x.pracEmployersId });
                    table.ForeignKey(
                        name: "FK_PracContactPracEmployer_PracContacts_pracContactsId",
                        column: x => x.pracContactsId,
                        principalTable: "PracContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PracContactPracEmployer_PracEmployers_pracEmployersId",
                        column: x => x.pracEmployersId,
                        principalTable: "PracEmployers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PracCpdPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PractitionerId = table.Column<int>(type: "integer", nullable: false),
                    RenewalPeriodId = table.Column<int>(type: "integer", nullable: false),
                    Point = table.Column<string>(type: "text", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    PracContactId = table.Column<int>(type: "integer", nullable: true),
                    PracEmployerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracCpdPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PracCpdPoints_PracContacts_PracContactId",
                        column: x => x.PracContactId,
                        principalTable: "PracContacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PracCpdPoints_PracEmployers_PracEmployerId",
                        column: x => x.PracEmployerId,
                        principalTable: "PracEmployers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PracDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PracEmployerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PracDocuments_PracEmployers_PracEmployerId",
                        column: x => x.PracEmployerId,
                        principalTable: "PracEmployers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PracPaymentInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PractitionerId = table.Column<int>(type: "integer", nullable: false),
                    RenewalCategoryId = table.Column<int>(type: "integer", nullable: false),
                    RegisterCategoryId = table.Column<int>(type: "integer", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "integer", nullable: false),
                    PracContactId = table.Column<int>(type: "integer", nullable: true),
                    PracEmployerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracPaymentInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PracPaymentInformation_PracContacts_PracContactId",
                        column: x => x.PracContactId,
                        principalTable: "PracContacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PracPaymentInformation_PracEmployers_PracEmployerId",
                        column: x => x.PracEmployerId,
                        principalTable: "PracEmployers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PracPlacement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PractitonerId = table.Column<int>(type: "integer", nullable: false),
                    RenewalPeriodId = table.Column<string>(type: "text", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    PracContactId = table.Column<int>(type: "integer", nullable: true),
                    PracEmployerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracPlacement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PracPlacement_PracContacts_PracContactId",
                        column: x => x.PracContactId,
                        principalTable: "PracContacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PracPlacement_PracEmployers_PracEmployerId",
                        column: x => x.PracEmployerId,
                        principalTable: "PracEmployers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PracQualifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PractitionerId = table.Column<int>(type: "integer", nullable: false),
                    PractitonerQualificationId = table.Column<int>(type: "integer", nullable: false),
                    ProfessionId = table.Column<int>(type: "integer", nullable: false),
                    AccreditedInstitutionId = table.Column<int>(type: "integer", nullable: false),
                    QualificationCategoryId = table.Column<int>(type: "integer", nullable: false),
                    Institution = table.Column<string>(type: "text", nullable: false),
                    ProfessionalQualificationName = table.Column<string>(type: "text", nullable: false),
                    AwardedBy = table.Column<string>(type: "text", nullable: false),
                    CommencementDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompletionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AwardedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PracContactId = table.Column<int>(type: "integer", nullable: true),
                    PracEmployerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracQualifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PracQualifications_PracContacts_PracContactId",
                        column: x => x.PracContactId,
                        principalTable: "PracContacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PracQualifications_PracEmployers_PracEmployerId",
                        column: x => x.PracEmployerId,
                        principalTable: "PracEmployers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PracRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PractitionerId = table.Column<int>(type: "integer", nullable: false),
                    PracRequirementsId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    MemberStatus = table.Column<bool>(type: "boolean", nullable: false),
                    PracContactId = table.Column<int>(type: "integer", nullable: true),
                    PracEmployerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PracRequirements_PracContacts_PracContactId",
                        column: x => x.PracContactId,
                        principalTable: "PracContacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PracRequirements_PracEmployers_PracEmployerId",
                        column: x => x.PracEmployerId,
                        principalTable: "PracEmployers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PracStudentApproval",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PractitionerId = table.Column<int>(type: "integer", nullable: false),
                    RegistrationOfficer = table.Column<string>(type: "text", nullable: false),
                    Registrar = table.Column<string>(type: "text", nullable: false),
                    Accountant = table.Column<string>(type: "text", nullable: false),
                    Member = table.Column<string>(type: "text", nullable: false),
                    PracContactId = table.Column<int>(type: "integer", nullable: true),
                    PracEmployerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracStudentApproval", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PracStudentApproval_PracContacts_PracContactId",
                        column: x => x.PracContactId,
                        principalTable: "PracContacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PracStudentApproval_PracEmployers_PracEmployerId",
                        column: x => x.PracEmployerId,
                        principalTable: "PracEmployers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PracContactPracExperience",
                columns: table => new
                {
                    pracContactsId = table.Column<int>(type: "integer", nullable: false),
                    pracExperiencesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracContactPracExperience", x => new { x.pracContactsId, x.pracExperiencesId });
                    table.ForeignKey(
                        name: "FK_PracContactPracExperience_PracContacts_pracContactsId",
                        column: x => x.pracContactsId,
                        principalTable: "PracContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PracContactPracExperience_PracExperiences_pracExperiencesId",
                        column: x => x.pracExperiencesId,
                        principalTable: "PracExperiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PracEmployerPracExperience",
                columns: table => new
                {
                    pracEmployersId = table.Column<int>(type: "integer", nullable: false),
                    pracExperiencesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracEmployerPracExperience", x => new { x.pracEmployersId, x.pracExperiencesId });
                    table.ForeignKey(
                        name: "FK_PracEmployerPracExperience_PracEmployers_pracEmployersId",
                        column: x => x.pracEmployersId,
                        principalTable: "PracEmployers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PracEmployerPracExperience_PracExperiences_pracExperiencesId",
                        column: x => x.pracExperiencesId,
                        principalTable: "PracExperiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PracBalances_PracEmployerId",
                table: "PracBalances",
                column: "PracEmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_PracContactPracEmployer_pracEmployersId",
                table: "PracContactPracEmployer",
                column: "pracEmployersId");

            migrationBuilder.CreateIndex(
                name: "IX_PracContactPracExperience_pracExperiencesId",
                table: "PracContactPracExperience",
                column: "pracExperiencesId");

            migrationBuilder.CreateIndex(
                name: "IX_PracCpdPoints_PracContactId",
                table: "PracCpdPoints",
                column: "PracContactId");

            migrationBuilder.CreateIndex(
                name: "IX_PracCpdPoints_PracEmployerId",
                table: "PracCpdPoints",
                column: "PracEmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_PracDocuments_PracEmployerId",
                table: "PracDocuments",
                column: "PracEmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_PracEmployerPracExperience_pracExperiencesId",
                table: "PracEmployerPracExperience",
                column: "pracExperiencesId");

            migrationBuilder.CreateIndex(
                name: "IX_PracPaymentInformation_PracContactId",
                table: "PracPaymentInformation",
                column: "PracContactId");

            migrationBuilder.CreateIndex(
                name: "IX_PracPaymentInformation_PracEmployerId",
                table: "PracPaymentInformation",
                column: "PracEmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_PracPlacement_PracContactId",
                table: "PracPlacement",
                column: "PracContactId");

            migrationBuilder.CreateIndex(
                name: "IX_PracPlacement_PracEmployerId",
                table: "PracPlacement",
                column: "PracEmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_PracQualifications_PracContactId",
                table: "PracQualifications",
                column: "PracContactId");

            migrationBuilder.CreateIndex(
                name: "IX_PracQualifications_PracEmployerId",
                table: "PracQualifications",
                column: "PracEmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_PracRequirements_PracContactId",
                table: "PracRequirements",
                column: "PracContactId");

            migrationBuilder.CreateIndex(
                name: "IX_PracRequirements_PracEmployerId",
                table: "PracRequirements",
                column: "PracEmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_PracStudentApproval_PracContactId",
                table: "PracStudentApproval",
                column: "PracContactId");

            migrationBuilder.CreateIndex(
                name: "IX_PracStudentApproval_PracEmployerId",
                table: "PracStudentApproval",
                column: "PracEmployerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PracBalances");

            migrationBuilder.DropTable(
                name: "PracContactPracEmployer");

            migrationBuilder.DropTable(
                name: "PracContactPracExperience");

            migrationBuilder.DropTable(
                name: "PracCpdPoints");

            migrationBuilder.DropTable(
                name: "PracDocuments");

            migrationBuilder.DropTable(
                name: "PracEmployerPracExperience");

            migrationBuilder.DropTable(
                name: "PracPaymentInformation");

            migrationBuilder.DropTable(
                name: "PracPlacement");

            migrationBuilder.DropTable(
                name: "PracQualifications");

            migrationBuilder.DropTable(
                name: "PracRequirements");

            migrationBuilder.DropTable(
                name: "PracStudentApproval");

            migrationBuilder.DropTable(
                name: "PracExperiences");

            migrationBuilder.DropTable(
                name: "PracContacts");

            migrationBuilder.DropTable(
                name: "PracEmployers");
        }
    }
}
