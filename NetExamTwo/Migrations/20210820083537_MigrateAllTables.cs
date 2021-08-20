using Microsoft.EntityFrameworkCore.Migrations;

namespace NetExamTwo.Migrations
{
    public partial class MigrateAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfo_Phone_PhoneId",
                table: "ContactInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactPerson_ContactInfo_ContactInfoId",
                table: "ContactPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactPerson_Customer_CustomerId",
                table: "ContactPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_ContainerStatus_Container_ContainerCCTag",
                table: "ContainerStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_ContactInfo_ContactInfoId",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phone",
                table: "Phone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContainerStatus",
                table: "ContainerStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Container",
                table: "Container");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactPerson",
                table: "ContactPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactInfo",
                table: "ContactInfo");

            migrationBuilder.RenameTable(
                name: "Phone",
                newName: "Phones");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "ContainerStatus",
                newName: "ContainerStatuses");

            migrationBuilder.RenameTable(
                name: "Container",
                newName: "Containers");

            migrationBuilder.RenameTable(
                name: "ContactPerson",
                newName: "ContactPeople");

            migrationBuilder.RenameTable(
                name: "ContactInfo",
                newName: "ContactInfos");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_ContactInfoId",
                table: "Customers",
                newName: "IX_Customers_ContactInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_ContainerStatus_ContainerCCTag",
                table: "ContainerStatuses",
                newName: "IX_ContainerStatuses_ContainerCCTag");

            migrationBuilder.RenameIndex(
                name: "IX_ContactPerson_CustomerId",
                table: "ContactPeople",
                newName: "IX_ContactPeople_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactPerson_ContactInfoId",
                table: "ContactPeople",
                newName: "IX_ContactPeople_ContactInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactInfo_PhoneId",
                table: "ContactInfos",
                newName: "IX_ContactInfos_PhoneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phones",
                table: "Phones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContainerStatuses",
                table: "ContainerStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Containers",
                table: "Containers",
                column: "CCTag");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactPeople",
                table: "ContactPeople",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactInfos",
                table: "ContactInfos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfos_Phones_PhoneId",
                table: "ContactInfos",
                column: "PhoneId",
                principalTable: "Phones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPeople_ContactInfos_ContactInfoId",
                table: "ContactPeople",
                column: "ContactInfoId",
                principalTable: "ContactInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPeople_Customers_CustomerId",
                table: "ContactPeople",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerStatuses_Containers_ContainerCCTag",
                table: "ContainerStatuses",
                column: "ContainerCCTag",
                principalTable: "Containers",
                principalColumn: "CCTag",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_ContactInfos_ContactInfoId",
                table: "Customers",
                column: "ContactInfoId",
                principalTable: "ContactInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfos_Phones_PhoneId",
                table: "ContactInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactPeople_ContactInfos_ContactInfoId",
                table: "ContactPeople");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactPeople_Customers_CustomerId",
                table: "ContactPeople");

            migrationBuilder.DropForeignKey(
                name: "FK_ContainerStatuses_Containers_ContainerCCTag",
                table: "ContainerStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_ContactInfos_ContactInfoId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phones",
                table: "Phones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContainerStatuses",
                table: "ContainerStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Containers",
                table: "Containers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactPeople",
                table: "ContactPeople");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactInfos",
                table: "ContactInfos");

            migrationBuilder.RenameTable(
                name: "Phones",
                newName: "Phone");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "ContainerStatuses",
                newName: "ContainerStatus");

            migrationBuilder.RenameTable(
                name: "Containers",
                newName: "Container");

            migrationBuilder.RenameTable(
                name: "ContactPeople",
                newName: "ContactPerson");

            migrationBuilder.RenameTable(
                name: "ContactInfos",
                newName: "ContactInfo");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_ContactInfoId",
                table: "Customer",
                newName: "IX_Customer_ContactInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_ContainerStatuses_ContainerCCTag",
                table: "ContainerStatus",
                newName: "IX_ContainerStatus_ContainerCCTag");

            migrationBuilder.RenameIndex(
                name: "IX_ContactPeople_CustomerId",
                table: "ContactPerson",
                newName: "IX_ContactPerson_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactPeople_ContactInfoId",
                table: "ContactPerson",
                newName: "IX_ContactPerson_ContactInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactInfos_PhoneId",
                table: "ContactInfo",
                newName: "IX_ContactInfo_PhoneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phone",
                table: "Phone",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContainerStatus",
                table: "ContainerStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Container",
                table: "Container",
                column: "CCTag");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactPerson",
                table: "ContactPerson",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactInfo",
                table: "ContactInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfo_Phone_PhoneId",
                table: "ContactInfo",
                column: "PhoneId",
                principalTable: "Phone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPerson_ContactInfo_ContactInfoId",
                table: "ContactPerson",
                column: "ContactInfoId",
                principalTable: "ContactInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPerson_Customer_CustomerId",
                table: "ContactPerson",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerStatus_Container_ContainerCCTag",
                table: "ContainerStatus",
                column: "ContainerCCTag",
                principalTable: "Container",
                principalColumn: "CCTag",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_ContactInfo_ContactInfoId",
                table: "Customer",
                column: "ContactInfoId",
                principalTable: "ContactInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
