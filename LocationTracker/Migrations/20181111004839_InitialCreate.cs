using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocationTracker.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    address_1 = table.Column<string>(maxLength: 50, nullable: true),
                    address_2 = table.Column<string>(maxLength: 50, nullable: true),
                    city = table.Column<string>(maxLength: 50, nullable: true),
                    state_province = table.Column<string>(maxLength: 50, nullable: true),
                    country = table.Column<string>(maxLength: 50, nullable: false),
                    postal_code = table.Column<string>(maxLength: 10, nullable: true),
                    lattitude = table.Column<float>(nullable: true),
                    longitude = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    iso_alpha_2 = table.Column<string>(maxLength: 2, nullable: false),
                    iso_alpha_3 = table.Column<string>(maxLength: 3, nullable: false),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "division",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_division", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "study",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    size = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_study", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "study_type",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_study_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vendor",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    number = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subdivision",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    country_id = table.Column<int>(nullable: false),
                    iso_alpha_2 = table.Column<string>(maxLength: 2, nullable: false),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subdivision", x => x.id);
                    table.ForeignKey(
                        name: "FK_subdivision_country_country_id",
                        column: x => x.country_id,
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "business_unit",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    division_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_business_unit", x => x.id);
                    table.ForeignKey(
                        name: "FK_business_unit_division_division_id",
                        column: x => x.division_id,
                        principalTable: "division",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "study_result",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    study_id = table.Column<int>(nullable: false),
                    StudyTypeID = table.Column<int>(nullable: false),
                    StatusID = table.Column<int>(nullable: false),
                    underrated_issues = table.Column<int>(nullable: false),
                    arc_flash_issues = table.Column<int>(nullable: false),
                    equipment_protection_issues = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    date_completed = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_study_result", x => x.id);
                    table.ForeignKey(
                        name: "FK_study_result_study_study_id",
                        column: x => x.study_id,
                        principalTable: "study",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "study_history",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    study_id = table.Column<int>(nullable: false),
                    status_id = table.Column<int>(nullable: false),
                    study_type_id = table.Column<int>(nullable: false),
                    performed_by = table.Column<string>(nullable: true),
                    start_date = table.Column<DateTime>(type: "date", nullable: false),
                    end_date = table.Column<DateTime>(type: "date", nullable: true),
                    comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_study_history", x => x.id);
                    table.ForeignKey(
                        name: "FK_study_history_status_status_id",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_study_history_study_study_id",
                        column: x => x.study_id,
                        principalTable: "study",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_study_history_study_type_study_type_id",
                        column: x => x.study_type_id,
                        principalTable: "study_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    location_code = table.Column<string>(maxLength: 3, nullable: false),
                    division_id = table.Column<int>(nullable: true),
                    business_unit_id = table.Column<int>(nullable: true),
                    address_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.id);
                    table.ForeignKey(
                        name: "FK_location_address_address_id",
                        column: x => x.address_id,
                        principalTable: "address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_location_business_unit_business_unit_id",
                        column: x => x.business_unit_id,
                        principalTable: "business_unit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_location_division_division_id",
                        column: x => x.division_id,
                        principalTable: "division",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "assessment",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    location_id = table.Column<int>(nullable: false),
                    vendor_id = table.Column<int>(nullable: false),
                    status_id = table.Column<int>(nullable: false),
                    study_required = table.Column<bool>(nullable: true),
                    start_date = table.Column<DateTime>(type: "date", nullable: false),
                    end_date = table.Column<DateTime>(type: "date", nullable: true),
                    comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment", x => x.id);
                    table.ForeignKey(
                        name: "FK_assessment_location_location_id",
                        column: x => x.location_id,
                        principalTable: "location",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_assessment_status_status_id",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_assessment_vendor_vendor_id",
                        column: x => x.vendor_id,
                        principalTable: "vendor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "location_study",
                columns: table => new
                {
                    study_id = table.Column<int>(nullable: false),
                    location_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location_study", x => new { x.study_id, x.location_id });
                    table.ForeignKey(
                        name: "FK_location_study_location_location_id",
                        column: x => x.location_id,
                        principalTable: "location",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_location_study_study_study_id",
                        column: x => x.study_id,
                        principalTable: "study",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assessment_location_id",
                table: "assessment",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_status_id",
                table: "assessment",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_vendor_id",
                table: "assessment",
                column: "vendor_id");

            migrationBuilder.CreateIndex(
                name: "IX_business_unit_name",
                table: "business_unit",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_business_unit_division_id",
                table: "business_unit",
                column: "division_id");

            migrationBuilder.CreateIndex(
                name: "IX_country_iso_alpha_3",
                table: "country",
                column: "iso_alpha_3",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_country_iso_alpha_2",
                table: "country",
                column: "iso_alpha_2",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_division_name",
                table: "division",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_location_address_id",
                table: "location",
                column: "address_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_location_business_unit_id",
                table: "location",
                column: "business_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_location_division_id",
                table: "location",
                column: "division_id");

            migrationBuilder.CreateIndex(
                name: "IX_location_location_code",
                table: "location",
                column: "location_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_location_study_location_id",
                table: "location_study",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_study_history_status_id",
                table: "study_history",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_study_history_study_id",
                table: "study_history",
                column: "study_id");

            migrationBuilder.CreateIndex(
                name: "IX_study_history_study_type_id",
                table: "study_history",
                column: "study_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_study_result_study_id",
                table: "study_result",
                column: "study_id");

            migrationBuilder.CreateIndex(
                name: "IX_subdivision_iso_alpha_2",
                table: "subdivision",
                column: "iso_alpha_2",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_subdivision_country_id",
                table: "subdivision",
                column: "country_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assessment");

            migrationBuilder.DropTable(
                name: "location_study");

            migrationBuilder.DropTable(
                name: "study_history");

            migrationBuilder.DropTable(
                name: "study_result");

            migrationBuilder.DropTable(
                name: "subdivision");

            migrationBuilder.DropTable(
                name: "vendor");

            migrationBuilder.DropTable(
                name: "location");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "study_type");

            migrationBuilder.DropTable(
                name: "study");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "business_unit");

            migrationBuilder.DropTable(
                name: "division");
        }
    }
}
