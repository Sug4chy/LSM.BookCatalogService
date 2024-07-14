using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LSM.BookCatalogService.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "book_category",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "publishing_house",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    isbn_code = table.Column<short>(type: "smallint", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publishing_house", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    full_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    contact_information = table.Column<Dictionary<string, string>>(type: "jsonb", nullable: true),
                    death_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    short_biography = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    country_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.id);
                    table.ForeignKey(
                        name: "FK_author_country_country_id",
                        column: x => x.country_id,
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "illustrator",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    full_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    contact_information = table.Column<Dictionary<string, string>>(type: "jsonb", nullable: true),
                    death_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    short_biography = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    country_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_illustrator", x => x.id);
                    table.ForeignKey(
                        name: "FK_illustrator_country_country_id",
                        column: x => x.country_id,
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "portrait_creator",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    full_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    contact_information = table.Column<Dictionary<string, string>>(type: "jsonb", nullable: true),
                    death_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    short_biography = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    country_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portrait_creator", x => x.id);
                    table.ForeignKey(
                        name: "FK_portrait_creator_country_country_id",
                        column: x => x.country_id,
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "voice_actor",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    full_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    contact_information = table.Column<Dictionary<string, string>>(type: "jsonb", nullable: true),
                    death_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    short_biography = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    country_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voice_actor", x => x.id);
                    table.ForeignKey(
                        name: "FK_voice_actor_country_country_id",
                        column: x => x.country_id,
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "portrait",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    file_path = table.Column<string>(type: "character varying(32767)", maxLength: 32767, nullable: false),
                    discriminator = table.Column<int>(type: "integer", nullable: false),
                    author_id = table.Column<Guid>(type: "uuid", nullable: false),
                    creator_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portrait", x => x.id);
                    table.ForeignKey(
                        name: "FK_portrait_author_author_id",
                        column: x => x.author_id,
                        principalTable: "author",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_portrait_portrait_creator_creator_id",
                        column: x => x.creator_id,
                        principalTable: "portrait_creator",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    publishing_year = table.Column<short>(type: "smallint", nullable: false),
                    isbn = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    is_available = table.Column<bool>(type: "boolean", nullable: false),
                    annotation = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    discriminator = table.Column<int>(type: "integer", nullable: false),
                    available_count = table.Column<int>(type: "integer", nullable: true),
                    count_in_library = table.Column<int>(type: "integer", nullable: true),
                    pages_count = table.Column<int>(type: "integer", nullable: true),
                    file_path = table.Column<string>(type: "character varying(32767)", maxLength: 32767, nullable: true),
                    voice_actor_id = table.Column<Guid>(type: "uuid", nullable: true),
                    PublishingHouseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.id);
                    table.ForeignKey(
                        name: "FK_book_publishing_house_PublishingHouseId",
                        column: x => x.PublishingHouseId,
                        principalTable: "publishing_house",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_book_voice_actor_voice_actor_id",
                        column: x => x.voice_actor_id,
                        principalTable: "voice_actor",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "author_book",
                columns: table => new
                {
                    book_id = table.Column<Guid>(type: "uuid", nullable: false),
                    author_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author_book", x => new { x.book_id, x.author_id });
                    table.ForeignKey(
                        name: "FK_author_book_author_author_id",
                        column: x => x.author_id,
                        principalTable: "author",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_author_book_book_book_id",
                        column: x => x.book_id,
                        principalTable: "book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_category_book",
                columns: table => new
                {
                    book_id = table.Column<Guid>(type: "uuid", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_category_book", x => new { x.book_id, x.category_id });
                    table.ForeignKey(
                        name: "FK_book_category_book_book_book_id",
                        column: x => x.book_id,
                        principalTable: "book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_book_category_book_book_category_category_id",
                        column: x => x.category_id,
                        principalTable: "book_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_genre",
                columns: table => new
                {
                    book_id = table.Column<Guid>(type: "uuid", nullable: false),
                    genre_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_genre", x => new { x.book_id, x.genre_id });
                    table.ForeignKey(
                        name: "FK_book_genre_book_book_id",
                        column: x => x.book_id,
                        principalTable: "book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_book_genre_genre_genre_id",
                        column: x => x.genre_id,
                        principalTable: "genre",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "illustration",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    file_path = table.Column<string>(type: "character varying(32767)", maxLength: 32767, nullable: false),
                    book_id = table.Column<Guid>(type: "uuid", nullable: false),
                    illustrator_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_illustration", x => x.id);
                    table.ForeignKey(
                        name: "FK_illustration_book_book_id",
                        column: x => x.book_id,
                        principalTable: "book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_illustration_illustrator_illustrator_id",
                        column: x => x.illustrator_id,
                        principalTable: "illustrator",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_author_country_id",
                table: "author",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_author_full_name",
                table: "author",
                column: "full_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_author_book_author_id",
                table: "author_book",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_book_isbn",
                table: "book",
                column: "isbn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_book_name",
                table: "book",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_book_PublishingHouseId",
                table: "book",
                column: "PublishingHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_book_voice_actor_id",
                table: "book",
                column: "voice_actor_id");

            migrationBuilder.CreateIndex(
                name: "IX_book_category_name",
                table: "book_category",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_book_category_book_category_id",
                table: "book_category_book",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_book_genre_genre_id",
                table: "book_genre",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_country_name",
                table: "country",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_genre_name",
                table: "genre",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_illustration_book_id",
                table: "illustration",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_illustration_file_path",
                table: "illustration",
                column: "file_path",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_illustration_illustrator_id",
                table: "illustration",
                column: "illustrator_id");

            migrationBuilder.CreateIndex(
                name: "IX_illustration_title",
                table: "illustration",
                column: "title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_illustrator_country_id",
                table: "illustrator",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_illustrator_full_name",
                table: "illustrator",
                column: "full_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_portrait_author_id",
                table: "portrait",
                column: "author_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_portrait_creator_id",
                table: "portrait",
                column: "creator_id");

            migrationBuilder.CreateIndex(
                name: "IX_portrait_file_path",
                table: "portrait",
                column: "file_path",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_portrait_title",
                table: "portrait",
                column: "title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_portrait_creator_country_id",
                table: "portrait_creator",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_portrait_creator_full_name",
                table: "portrait_creator",
                column: "full_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_publishing_house_isbn_code",
                table: "publishing_house",
                column: "isbn_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_publishing_house_name",
                table: "publishing_house",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_voice_actor_country_id",
                table: "voice_actor",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_voice_actor_full_name",
                table: "voice_actor",
                column: "full_name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "author_book");

            migrationBuilder.DropTable(
                name: "book_category_book");

            migrationBuilder.DropTable(
                name: "book_genre");

            migrationBuilder.DropTable(
                name: "illustration");

            migrationBuilder.DropTable(
                name: "portrait");

            migrationBuilder.DropTable(
                name: "book_category");

            migrationBuilder.DropTable(
                name: "genre");

            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "illustrator");

            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.DropTable(
                name: "portrait_creator");

            migrationBuilder.DropTable(
                name: "publishing_house");

            migrationBuilder.DropTable(
                name: "voice_actor");

            migrationBuilder.DropTable(
                name: "country");
        }
    }
}
