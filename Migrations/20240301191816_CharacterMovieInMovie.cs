using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace challangedisney.Migrations
{
    /// <inheritdoc />
    public partial class CharacterMovieInMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterMovie_Characters_CharactersId",
                table: "CharacterMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterMovie_Movies_MoviesId",
                table: "CharacterMovie");

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                table: "CharacterMovie",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "CharactersId",
                table: "CharacterMovie",
                newName: "CharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterMovie_MoviesId",
                table: "CharacterMovie",
                newName: "IX_CharacterMovie_MovieId");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "CharacterMovie",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "CharacterMovie",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMovie_Characters_CharacterId",
                table: "CharacterMovie",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMovie_Movies_MovieId",
                table: "CharacterMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterMovie_Characters_CharacterId",
                table: "CharacterMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterMovie_Movies_MovieId",
                table: "CharacterMovie");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "CharacterMovie",
                newName: "MoviesId");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "CharacterMovie",
                newName: "CharactersId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterMovie_MovieId",
                table: "CharacterMovie",
                newName: "IX_CharacterMovie_MoviesId");

            migrationBuilder.AlterColumn<int>(
                name: "MoviesId",
                table: "CharacterMovie",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "CharactersId",
                table: "CharacterMovie",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMovie_Characters_CharactersId",
                table: "CharacterMovie",
                column: "CharactersId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMovie_Movies_MoviesId",
                table: "CharacterMovie",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
