using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EksiSozluk.Migrations
{
    public partial class Db_Akademi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdı = table.Column<string>(name: "Kategori Adı", type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    KonuID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KonuBaşlığı = table.Column<string>(name: "Konu Başlığı", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TarihSaat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KonuYaziSayisi = table.Column<bool>(type: "bit", nullable: false),
                    Açıklama = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Catg_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Subject_Categories_Catg_ID",
                        column: x => x.Catg_ID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KonuKullanici",
                columns: table => new
                {
                    KonularID = table.Column<int>(type: "int", nullable: false),
                    KullanicilarID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KonuKullanici", x => new { x.KonularID, x.KullanicilarID });
                    table.ForeignKey(
                        name: "FK_KonuKullanici_Subject_KonularID",
                        column: x => x.KonularID,
                        principalTable: "Subject",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KonuKullanici_User_KullanicilarID",
                        column: x => x.KullanicilarID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KonuKullanici_KullanicilarID",
                table: "KonuKullanici",
                column: "KullanicilarID");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_Catg_ID",
                table: "Subject",
                column: "Catg_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KonuKullanici");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
