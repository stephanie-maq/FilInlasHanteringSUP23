using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FISSUP23.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "import");

            migrationBuilder.EnsureSchema(
                name: "temp");

            migrationBuilder.CreateTable(
                name: "Datatyp",
                schema: "import",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    system_type_id = table.Column<byte>(type: "tinyint", nullable: false),
                    max_length = table.Column<short>(type: "smallint", nullable: false),
                    precision = table.Column<byte>(type: "tinyint", nullable: false),
                    scale = table.Column<byte>(type: "tinyint", nullable: false),
                    is_nullable = table.Column<bool>(type: "bit", nullable: true),
                    fig1 = table.Column<short>(type: "smallint", nullable: true),
                    fig2 = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datatyper", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErrorLog",
                schema: "import",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<DateTime>(type: "datetime", nullable: false),
                    ErrorText = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ErrorCode = table.Column<int>(type: "int", nullable: true),
                    InlasningId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filtyp",
                schema: "import",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Beskrivning = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Andelse = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    PunktAndelse = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false, computedColumnSql: "(concat('.',[Andelse]))", stored: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filtyp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logg",
                schema: "import",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid = table.Column<DateTime>(type: "datetime", nullable: false),
                    OverforingId = table.Column<int>(type: "int", nullable: true),
                    FilkollektionId = table.Column<int>(type: "int", nullable: true),
                    FilId = table.Column<int>(type: "int", nullable: true),
                    InlasningId = table.Column<int>(type: "int", nullable: true),
                    SokFil = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    AktuellFil = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Handelse = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Loggtext = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logg", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookupTyp",
                schema: "import",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NyOverforing",
                schema: "temp",
                columns: table => new
                {
                    Namn = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SystemNamn = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Beskrivning = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Overforing",
                schema: "import",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    SystemNamn = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Beskrivning = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Overforing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                schema: "import",
                columns: table => new
                {
                    DatumTid = table.Column<DateTime>(type: "datetime", nullable: false),
                    SystemNamn = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "FilKollektion",
                schema: "import",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Andelse = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    MatchMonster = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Beskrivning = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    OverforingId = table.Column<int>(type: "int", nullable: false),
                    FilTypId = table.Column<int>(type: "int", nullable: false),
                    FolderRoot = table.Column<string>(type: "varchar(511)", unicode: false, maxLength: 511, nullable: false),
                    FolderArkiv = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    FolderNyFil = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    FolderFelaktigFil = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilKollektion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilKollektion_Filtyp",
                        column: x => x.FilTypId,
                        principalSchema: "import",
                        principalTable: "Filtyp",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FilKollektion_Overforing",
                        column: x => x.OverforingId,
                        principalSchema: "import",
                        principalTable: "Overforing",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fil",
                schema: "import",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    MatchMonster = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Beskrivning = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    FilKollektionId = table.Column<int>(type: "int", nullable: false),
                    KolumnSeparator = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    HarKolumnamn = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fil_FilKollektion",
                        column: x => x.FilKollektionId,
                        principalSchema: "import",
                        principalTable: "FilKollektion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fil_Datatyp",
                schema: "import",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilId = table.Column<int>(type: "int", nullable: false),
                    DatatypId = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: true),
                    Precision = table.Column<int>(type: "int", nullable: true),
                    Scale = table.Column<int>(type: "int", nullable: true),
                    IsNullable = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fil_Datatyp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fil_Datatyp_Datatyper",
                        column: x => x.DatatypId,
                        principalSchema: "import",
                        principalTable: "Datatyp",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fil_Datatyp_Kolumn",
                        column: x => x.FilId,
                        principalSchema: "import",
                        principalTable: "Fil",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inlasning",
                schema: "import",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilId = table.Column<int>(type: "int", nullable: false),
                    DatumTid = table.Column<DateTime>(type: "datetime", nullable: false),
                    FilNamn = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    AntalTillagdaKolumner = table.Column<int>(type: "int", nullable: true),
                    AntalRader = table.Column<int>(type: "int", nullable: true),
                    RaderadData = table.Column<short>(type: "smallint", nullable: true),
                    Omlasning = table.Column<short>(type: "smallint", nullable: true),
                    Dubblett = table.Column<short>(type: "smallint", nullable: true),
                    Namn = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ErrorLogId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inlasning", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inlasning_ErrorLog",
                        column: x => x.ErrorLogId,
                        principalSchema: "import",
                        principalTable: "ErrorLog",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inlasning_Fil",
                        column: x => x.FilId,
                        principalSchema: "import",
                        principalTable: "Fil",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lookup",
                schema: "import",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilId = table.Column<int>(type: "int", nullable: false),
                    LookupTypId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lookup_Fil",
                        column: x => x.FilId,
                        principalSchema: "import",
                        principalTable: "Fil",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lookup_LookupTyp",
                        column: x => x.LookupTypId,
                        principalSchema: "import",
                        principalTable: "LookupTyp",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Kolumn",
                schema: "import",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InNamn = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    UtNamn = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    NyKolumn = table.Column<short>(type: "smallint", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    FilId = table.Column<int>(type: "int", nullable: false),
                    InlasningId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kolumn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kolumn_Fil",
                        column: x => x.FilId,
                        principalSchema: "import",
                        principalTable: "Fil",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Kolumn_Inlasning",
                        column: x => x.InlasningId,
                        principalSchema: "import",
                        principalTable: "Inlasning",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RawData",
                schema: "import",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RawData = table.Column<string>(type: "varchar(2047)", unicode: false, maxLength: 2047, nullable: true),
                    FilId = table.Column<int>(type: "int", nullable: false),
                    InlasningID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RawData_Fil",
                        column: x => x.FilId,
                        principalSchema: "import",
                        principalTable: "Fil",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RawData_Inlasning",
                        column: x => x.InlasningID,
                        principalSchema: "import",
                        principalTable: "Inlasning",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RawDataKolumner",
                schema: "import",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RawData = table.Column<string>(type: "varchar(2047)", unicode: false, maxLength: 2047, nullable: true),
                    FilId = table.Column<int>(type: "int", nullable: false),
                    InlasningID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawDataKolumner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RawDataKolumner_Fil",
                        column: x => x.FilId,
                        principalSchema: "import",
                        principalTable: "Fil",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RawDataKolumner_Inlasning",
                        column: x => x.InlasningID,
                        principalSchema: "import",
                        principalTable: "Inlasning",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RawDataParsed",
                schema: "import",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RawDataId = table.Column<int>(type: "int", nullable: true),
                    KolumnId = table.Column<int>(type: "int", nullable: false),
                    RawDataParsed = table.Column<string>(type: "varchar(2047)", unicode: false, maxLength: 2047, nullable: true),
                    FilId = table.Column<int>(type: "int", nullable: false),
                    InlasningID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawDataParsed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RawDataParsed_Fil",
                        column: x => x.FilId,
                        principalSchema: "import",
                        principalTable: "Fil",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RawDataParsed_Inlasning",
                        column: x => x.InlasningID,
                        principalSchema: "import",
                        principalTable: "Inlasning",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tabell",
                schema: "import",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Schema = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Namn = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    VySchema = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    VyPrefix = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Beskrivning = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    FilId = table.Column<int>(type: "int", nullable: false),
                    TabellNamn = table.Column<string>(type: "nvarchar(517)", maxLength: 517, nullable: false, computedColumnSql: "(concat_ws('.',quotename([Schema]),quotename([Namn])))", stored: false),
                    VyNamn = table.Column<string>(type: "nvarchar(517)", maxLength: 517, nullable: false, computedColumnSql: "(concat_ws('.',quotename([VySchema]),quotename(concat([VyPrefix],[Namn]))))", stored: false),
                    VyNamnLookup = table.Column<string>(type: "nvarchar(517)", maxLength: 517, nullable: false, computedColumnSql: "(concat_ws('.',quotename([VySchema]),quotename(concat([VyPrefix],[Namn],'_LookUp'))))", stored: false),
                    Skapad_InlasningId = table.Column<int>(type: "int", nullable: true),
                    Modifierad = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tabell_Fil",
                        column: x => x.FilId,
                        principalSchema: "import",
                        principalTable: "Fil",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tabell_Inlasning",
                        column: x => x.Skapad_InlasningId,
                        principalSchema: "import",
                        principalTable: "Inlasning",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Kolumn_Datatyp",
                schema: "import",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KolumnId = table.Column<int>(type: "int", nullable: false),
                    DatatypId = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: true),
                    Precision = table.Column<int>(type: "int", nullable: true),
                    Scale = table.Column<int>(type: "int", nullable: true),
                    IsNullable = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kolumn_Datatyp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kolumn_Datatyp_Datatyper",
                        column: x => x.DatatypId,
                        principalSchema: "import",
                        principalTable: "Datatyp",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Kolumn_Datatyp_Kolumn",
                        column: x => x.KolumnId,
                        principalSchema: "import",
                        principalTable: "Kolumn",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lookup_Kolumn",
                schema: "import",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LookupId = table.Column<int>(type: "int", nullable: false),
                    KolumnId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookup_Kolumn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lookup_Kolumn_Kolumn",
                        column: x => x.KolumnId,
                        principalSchema: "import",
                        principalTable: "Kolumn",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lookup_Kolumn_Lookup",
                        column: x => x.LookupId,
                        principalSchema: "import",
                        principalTable: "Lookup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fil_FilKollektionId",
                schema: "import",
                table: "Fil",
                column: "FilKollektionId");

            migrationBuilder.CreateIndex(
                name: "IX_Fil_Datatyp_DatatypId",
                schema: "import",
                table: "Fil_Datatyp",
                column: "DatatypId");

            migrationBuilder.CreateIndex(
                name: "IX_Fil_Datatyp_FilId",
                schema: "import",
                table: "Fil_Datatyp",
                column: "FilId");

            migrationBuilder.CreateIndex(
                name: "IX_FilKollektion_FilTypId",
                schema: "import",
                table: "FilKollektion",
                column: "FilTypId");

            migrationBuilder.CreateIndex(
                name: "IX_FilKollektion_OverforingId",
                schema: "import",
                table: "FilKollektion",
                column: "OverforingId");

            migrationBuilder.CreateIndex(
                name: "IX_Inlasning_ErrorLogId",
                schema: "import",
                table: "Inlasning",
                column: "ErrorLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Inlasning_FilId",
                schema: "import",
                table: "Inlasning",
                column: "FilId");

            migrationBuilder.CreateIndex(
                name: "IX_Kolumn_FilId",
                schema: "import",
                table: "Kolumn",
                column: "FilId");

            migrationBuilder.CreateIndex(
                name: "IX_Kolumn_InlasningId",
                schema: "import",
                table: "Kolumn",
                column: "InlasningId");

            migrationBuilder.CreateIndex(
                name: "IX_Kolumn_Datatyp_DatatypId",
                schema: "import",
                table: "Kolumn_Datatyp",
                column: "DatatypId");

            migrationBuilder.CreateIndex(
                name: "IX_Kolumn_Datatyp_KolumnId",
                schema: "import",
                table: "Kolumn_Datatyp",
                column: "KolumnId");

            migrationBuilder.CreateIndex(
                name: "IX_Lookup_FilId",
                schema: "import",
                table: "Lookup",
                column: "FilId");

            migrationBuilder.CreateIndex(
                name: "IX_Lookup_LookupTypId",
                schema: "import",
                table: "Lookup",
                column: "LookupTypId");

            migrationBuilder.CreateIndex(
                name: "IX_Lookup_Kolumn_KolumnId",
                schema: "import",
                table: "Lookup_Kolumn",
                column: "KolumnId");

            migrationBuilder.CreateIndex(
                name: "IX_Lookup_Kolumn_LookupId",
                schema: "import",
                table: "Lookup_Kolumn",
                column: "LookupId");

            migrationBuilder.CreateIndex(
                name: "IX_RawData_FilId",
                schema: "import",
                table: "RawData",
                column: "FilId");

            migrationBuilder.CreateIndex(
                name: "IX_RawData_InlasningID",
                schema: "import",
                table: "RawData",
                column: "InlasningID");

            migrationBuilder.CreateIndex(
                name: "IX_RawDataKolumner_FilId",
                schema: "import",
                table: "RawDataKolumner",
                column: "FilId");

            migrationBuilder.CreateIndex(
                name: "IX_RawDataKolumner_InlasningID",
                schema: "import",
                table: "RawDataKolumner",
                column: "InlasningID");

            migrationBuilder.CreateIndex(
                name: "IX_RawDataParsed_FilId",
                schema: "import",
                table: "RawDataParsed",
                column: "FilId");

            migrationBuilder.CreateIndex(
                name: "IX_RawDataParsed_InlasningID",
                schema: "import",
                table: "RawDataParsed",
                column: "InlasningID");

            migrationBuilder.CreateIndex(
                name: "IX_Tabell_FilId",
                schema: "import",
                table: "Tabell",
                column: "FilId");

            migrationBuilder.CreateIndex(
                name: "IX_Tabell_Skapad_InlasningId",
                schema: "import",
                table: "Tabell",
                column: "Skapad_InlasningId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fil_Datatyp",
                schema: "import");

            migrationBuilder.DropTable(
                name: "Kolumn_Datatyp",
                schema: "import");

            migrationBuilder.DropTable(
                name: "Logg",
                schema: "import");

            migrationBuilder.DropTable(
                name: "Lookup_Kolumn",
                schema: "import");

            migrationBuilder.DropTable(
                name: "NyOverforing",
                schema: "temp");

            migrationBuilder.DropTable(
                name: "RawData",
                schema: "import");

            migrationBuilder.DropTable(
                name: "RawDataKolumner",
                schema: "import");

            migrationBuilder.DropTable(
                name: "RawDataParsed",
                schema: "import");

            migrationBuilder.DropTable(
                name: "Tabell",
                schema: "import");

            migrationBuilder.DropTable(
                name: "Test",
                schema: "import");

            migrationBuilder.DropTable(
                name: "Datatyp",
                schema: "import");

            migrationBuilder.DropTable(
                name: "Kolumn",
                schema: "import");

            migrationBuilder.DropTable(
                name: "Lookup",
                schema: "import");

            migrationBuilder.DropTable(
                name: "Inlasning",
                schema: "import");

            migrationBuilder.DropTable(
                name: "LookupTyp",
                schema: "import");

            migrationBuilder.DropTable(
                name: "ErrorLog",
                schema: "import");

            migrationBuilder.DropTable(
                name: "Fil",
                schema: "import");

            migrationBuilder.DropTable(
                name: "FilKollektion",
                schema: "import");

            migrationBuilder.DropTable(
                name: "Filtyp",
                schema: "import");

            migrationBuilder.DropTable(
                name: "Overforing",
                schema: "import");
        }
    }
}
