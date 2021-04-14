using Microsoft.EntityFrameworkCore.Migrations;

namespace Birth_Clinic.Migrations
{
    public partial class ChangedIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Clinicians_ClinicianFirstName_ClinicianLastName",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Rooms_ClinicRoomRoomId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_ClinicianFirstName_ClinicianLastName",
                table: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mother",
                table: "Mother");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinicians",
                table: "Clinicians");

            migrationBuilder.DropColumn(
                name: "ClinicianFirstName",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "ClinicianLastName",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Clinicians");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Clinicians");

            migrationBuilder.RenameColumn(
                name: "ClinicRoomRoomId",
                table: "Schedule",
                newName: "ClinicianId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_ClinicRoomRoomId",
                table: "Schedule",
                newName: "IX_Schedule_ClinicianId");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Rooms",
                newName: "ClinicRoomId");

            migrationBuilder.AddColumn<int>(
                name: "ClinicRoomId",
                table: "Schedule",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Mother",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Mother",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "MotherId",
                table: "Mother",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ClinicianId",
                table: "Clinicians",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mother",
                table: "Mother",
                column: "MotherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinicians",
                table: "Clinicians",
                column: "ClinicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_ClinicRoomId",
                table: "Schedule",
                column: "ClinicRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Clinicians_ClinicianId",
                table: "Schedule",
                column: "ClinicianId",
                principalTable: "Clinicians",
                principalColumn: "ClinicianId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Rooms_ClinicRoomId",
                table: "Schedule",
                column: "ClinicRoomId",
                principalTable: "Rooms",
                principalColumn: "ClinicRoomId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Clinicians_ClinicianId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Rooms_ClinicRoomId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_ClinicRoomId",
                table: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mother",
                table: "Mother");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinicians",
                table: "Clinicians");

            migrationBuilder.DropColumn(
                name: "ClinicRoomId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "MotherId",
                table: "Mother");

            migrationBuilder.DropColumn(
                name: "ClinicianId",
                table: "Clinicians");

            migrationBuilder.RenameColumn(
                name: "ClinicianId",
                table: "Schedule",
                newName: "ClinicRoomRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_ClinicianId",
                table: "Schedule",
                newName: "IX_Schedule_ClinicRoomRoomId");

            migrationBuilder.RenameColumn(
                name: "ClinicRoomId",
                table: "Rooms",
                newName: "RoomId");

            migrationBuilder.AddColumn<string>(
                name: "ClinicianFirstName",
                table: "Schedule",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClinicianLastName",
                table: "Schedule",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Mother",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Mother",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Clinicians",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Clinicians",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mother",
                table: "Mother",
                columns: new[] { "FirstName", "LastName" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinicians",
                table: "Clinicians",
                columns: new[] { "FirstName", "LastName" });

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_ClinicianFirstName_ClinicianLastName",
                table: "Schedule",
                columns: new[] { "ClinicianFirstName", "ClinicianLastName" });

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Clinicians_ClinicianFirstName_ClinicianLastName",
                table: "Schedule",
                columns: new[] { "ClinicianFirstName", "ClinicianLastName" },
                principalTable: "Clinicians",
                principalColumns: new[] { "FirstName", "LastName" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Rooms_ClinicRoomRoomId",
                table: "Schedule",
                column: "ClinicRoomRoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
