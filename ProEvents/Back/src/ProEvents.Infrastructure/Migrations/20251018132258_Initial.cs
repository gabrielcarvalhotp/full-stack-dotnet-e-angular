using System;
using FirebirdSql.EntityFrameworkCore.Firebird.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProEvents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_events",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Fb:ValueGenerationStrategy", FbValueGenerationStrategy.IdentityColumn),
                    location = table.Column<string>(type: "VARCHAR(120)", maxLength: 120, nullable: true),
                    event_date = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    theme = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    number_people = table.Column<int>(type: "INTEGER", nullable: false),
                    image_url = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    phone = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    created_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_events", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_speakers",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Fb:ValueGenerationStrategy", FbValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    mini_curriculum = table.Column<string>(type: "VARCHAR(2000)", maxLength: 2000, nullable: true),
                    image_url = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    phone = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    created_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_speakers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_batches",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Fb:ValueGenerationStrategy", FbValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    price = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    start_date = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    end_date = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    event_id = table.Column<int>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_batches", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_batches_tb_events_event_~",
                        column: x => x.event_id,
                        principalTable: "tb_events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_event_speakers",
                columns: table => new
                {
                    speaker_id = table.Column<int>(type: "INTEGER", nullable: false),
                    event_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_event_speakers", x => new { x.event_id, x.speaker_id });
                    table.ForeignKey(
                        name: "FK_tb_event_speakers_tb_events~",
                        column: x => x.event_id,
                        principalTable: "tb_events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_event_speakers_tb_speake~",
                        column: x => x.speaker_id,
                        principalTable: "tb_speakers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_social_medias",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Fb:ValueGenerationStrategy", FbValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    url = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    event_id = table.Column<int>(type: "INTEGER", nullable: false),
                    speaker_id = table.Column<int>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_social_medias", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_social_medias_tb_events_~",
                        column: x => x.event_id,
                        principalTable: "tb_events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_social_medias_tb_speaker~",
                        column: x => x.speaker_id,
                        principalTable: "tb_speakers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_batches_created_at",
                table: "tb_batches",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "IX_tb_batches_event_id",
                table: "tb_batches",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_event_speakers_speaker_id",
                table: "tb_event_speakers",
                column: "speaker_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_events_created_at",
                table: "tb_events",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "IX_tb_social_medias_created_at",
                table: "tb_social_medias",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "IX_tb_social_medias_event_id",
                table: "tb_social_medias",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_social_medias_speaker_id",
                table: "tb_social_medias",
                column: "speaker_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_speakers_created_at",
                table: "tb_speakers",
                column: "created_at");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_batches");

            migrationBuilder.DropTable(
                name: "tb_event_speakers");

            migrationBuilder.DropTable(
                name: "tb_social_medias");

            migrationBuilder.DropTable(
                name: "tb_events");

            migrationBuilder.DropTable(
                name: "tb_speakers");
        }
    }
}
