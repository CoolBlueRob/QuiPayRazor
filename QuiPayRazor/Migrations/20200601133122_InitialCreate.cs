using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuiPayRazor.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyState = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    NoteSymbol = table.Column<string>(nullable: true),
                    Coin = table.Column<string>(nullable: true),
                    CoinSymbol = table.Column<string>(nullable: true),
                    WhenCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberState = table.Column<int>(nullable: false),
                    WhenCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MemberTrust",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberTrust", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentState = table.Column<int>(nullable: false),
                    FromAccountID = table.Column<int>(nullable: false),
                    ToAccountID = table.Column<int>(nullable: false),
                    WhenProposed = table.Column<DateTime>(nullable: false),
                    WhenAccepted = table.Column<DateTime>(nullable: false),
                    WhenDeclined = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    RefundPaymentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankNoteState = table.Column<int>(nullable: false),
                    Printed = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(5, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountState = table.Column<int>(nullable: false),
                    AccountType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    MemberID = table.Column<int>(nullable: false),
                    CurrencyID = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    WhenCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Account_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberIdentity",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberDetailsState = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MemberID = table.Column<int>(nullable: false),
                    WhenCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberIdentity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MemberIdentity_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoucherAccountLut",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankNoteAccountLutState = table.Column<int>(nullable: false),
                    BankNoteID = table.Column<int>(nullable: false),
                    AccountID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherAccountLut", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VoucherAccountLut_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoucherAccountLut_Voucher_BankNoteID",
                        column: x => x.BankNoteID,
                        principalTable: "Voucher",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressType = table.Column<int>(nullable: false),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    Address3 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    WhenCreated = table.Column<DateTime>(nullable: false),
                    MemberIdentityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Address_MemberIdentity_MemberIdentityID",
                        column: x => x.MemberIdentityID,
                        principalTable: "MemberIdentity",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddress",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressTyoe = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    MemberIdentityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddress", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmailAddress_MemberIdentity_MemberIdentityID",
                        column: x => x.MemberIdentityID,
                        principalTable: "MemberIdentity",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressTyoe = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    MemberIdentityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PhoneNumber_MemberIdentity_MemberIdentityID",
                        column: x => x.MemberIdentityID,
                        principalTable: "MemberIdentity",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_MemberID",
                table: "Account",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Address_MemberIdentityID",
                table: "Address",
                column: "MemberIdentityID");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddress_MemberIdentityID",
                table: "EmailAddress",
                column: "MemberIdentityID");

            migrationBuilder.CreateIndex(
                name: "IX_MemberIdentity_MemberID",
                table: "MemberIdentity",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber_MemberIdentityID",
                table: "PhoneNumber",
                column: "MemberIdentityID");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherAccountLut_AccountID",
                table: "VoucherAccountLut",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherAccountLut_BankNoteID",
                table: "VoucherAccountLut",
                column: "BankNoteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "EmailAddress");

            migrationBuilder.DropTable(
                name: "MemberTrust");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "PhoneNumber");

            migrationBuilder.DropTable(
                name: "VoucherAccountLut");

            migrationBuilder.DropTable(
                name: "MemberIdentity");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Voucher");

            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
