using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_il_mio_fotoalbum.Migrations
{
    public partial class CreateCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryModelPhotoModel",
                columns: table => new
                {
                    CategoriesListId = table.Column<int>(type: "int", nullable: false),
                    PhotosListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryModelPhotoModel", x => new { x.CategoriesListId, x.PhotosListId });
                    table.ForeignKey(
                        name: "FK_CategoryModelPhotoModel_Categories_CategoriesListId",
                        column: x => x.CategoriesListId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryModelPhotoModel_Photos_PhotosListId",
                        column: x => x.PhotosListId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryModelPhotoModel_PhotosListId",
                table: "CategoryModelPhotoModel",
                column: "PhotosListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryModelPhotoModel");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
