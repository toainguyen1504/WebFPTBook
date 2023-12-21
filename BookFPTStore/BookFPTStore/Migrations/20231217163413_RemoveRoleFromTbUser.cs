using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookFPTStore.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRoleFromTbUser : Migration
    {
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "role",
				table: "tb_User");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "role",
				table: "tb_User",
				type: "nvarchar(15)",
				maxLength: 15,
				nullable: false,
				defaultValue: "");
		}
	}
}
