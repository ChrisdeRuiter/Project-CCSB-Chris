using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_CCSB.Migrations
{
    public partial class vehicles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Appointments_AppointmentId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_AppointmentId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "AppointmentOphalenId",
                table: "Vehicles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "Appointments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "OphalenId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "OphalenId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_AppointmentOphalenId",
                table: "Vehicles",
                column: "AppointmentOphalenId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ApplicationUserId",
                table: "Appointments",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_ApplicationUserId",
                table: "Appointments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Appointments_AppointmentOphalenId",
                table: "Vehicles",
                column: "AppointmentOphalenId",
                principalTable: "Appointments",
                principalColumn: "OphalenId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_ApplicationUserId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Appointments_AppointmentOphalenId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_AppointmentOphalenId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ApplicationUserId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "AppointmentOphalenId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "OphalenId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Vehicles",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "Appointments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_AppointmentId",
                table: "Vehicles",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Appointments_AppointmentId",
                table: "Vehicles",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
