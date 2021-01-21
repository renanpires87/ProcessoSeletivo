using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bancos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoBanco = table.Column<string>(type: "varchar(50)", nullable: false),
                    NomeInstituicao = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContasBancarias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BancoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroDaConta = table.Column<string>(type: "varchar(100)", nullable: false),
                    NumeroDaAgencia = table.Column<string>(type: "varchar(100)", nullable: false),
                    CpfCnpj = table.Column<string>(type: "varchar(14)", nullable: false),
                    TipoPessoa = table.Column<int>(type: "int", nullable: false),
                    NomeRazaoSocialTitular = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataAbertura = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasBancarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasBancarias_Bancos_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Bancos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Bancos",
                columns: new[] { "Id", "CodigoBanco", "NomeInstituicao" },
                values: new object[,]
                {
                    { new Guid("d086cfcc-be97-475b-b848-fd6d83059578"), "001", "Banco do Brasil S.A." },
                    { new Guid("a8e54647-c264-4bcd-b577-46d700b240be"), "611", "Banco Paulista S.A." },
                    { new Guid("011d77b7-95b3-4007-a9f3-84a28ff379bb"), "610", "Banco VR S.A" },
                    { new Guid("4cc4bf96-1a03-4d1f-ad38-cbc308c64f69"), "604", "Banco Industrial Do Brasil S.A" },
                    { new Guid("bfb47f14-21ee-47c0-a910-10dc5f5745f3"), "600", "Banco Luso Brasileiro S.A" },
                    { new Guid("1baba687-24c0-4c5e-8046-d869bd319206"), "505", "Banco Credit Suisse (Brasil) S.A." },
                    { new Guid("5c578194-73d1-47bb-b73e-b75f94c01b7c"), "495", "Banco de la Provincia de Buenos Aires" },
                    { new Guid("6652f63e-0970-43aa-b86c-c7d335890d00"), "494", "Banco de la Republica Oriental del Uruguay" },
                    { new Guid("b72d2ab8-ea1f-4f85-ad68-a2cf59622d0f"), "492", "Ing Bank N.V." },
                    { new Guid("51fcd730-4a53-4bb0-9d53-40435ef0a682"), "488", "JPMorgan Chase Bank, National Association" },
                    { new Guid("adf267d7-c2e9-4997-b7b2-e37dc79e1423"), "487", "Deutsche Bank S.A. – Banco Alemao" },
                    { new Guid("75e9866b-20fa-42d6-ac6a-ff8ee33e6b3d"), "479", "Banco Itaubank S.A" },
                    { new Guid("ea1732d8-0057-4f4a-b9b0-7be83bd15002"), "477", "Citibank N.A." },
                    { new Guid("b7ff2afc-9d81-4e14-b638-84625021e512"), "473", "Banco Caixa Geral – Brasil S.A." },
                    { new Guid("0132ba76-e5d9-4bb7-87b6-d3ec7f7f15e9"), "612", "Banco Guanabara S.A." },
                    { new Guid("d49443c0-c1bc-49d2-a11f-df266ac32724"), "464", "Banco Sumitomo Mitsui Brasileiro S.A" },
                    { new Guid("1f413bed-498e-4b57-87fd-b806be885bf0"), "453", "Banco Rural S.A" },
                    { new Guid("b02c9bc2-9f7c-4b83-9e81-f3b6ffab44f9"), "422", "Banco Safra S.A." },
                    { new Guid("3e9e3801-5b7b-472d-ad6f-dd42b3552fd2"), "412", "Banco Capital S.A." },
                    { new Guid("7cd97832-4135-4dc9-8d7f-f46efb0e8a6b"), "409", "Unibanco-União de Bancos Brasileiros S.A" },
                    { new Guid("7b4591eb-7d22-4996-a0cd-9dcf06ad32fd"), "399", "HSBC Bank Brasil S.A. – Banco Múltiplo" },
                    { new Guid("69d1b4cb-667a-49b9-90a8-ae1bc91253f0"), "394", "Banco Finasa BMC S.A." },
                    { new Guid("84b88368-86cf-4476-a197-7b937b0e5741"), "389", "Banco Mercantil do Brasil S.A." },
                    { new Guid("eab1b3d8-5313-46f9-a7d8-25c9712c66de"), "376", "Banco J.P. Morgan S.A." },
                    { new Guid("4abc26bf-6e15-462c-bb48-f4fffd5946de"), "370", "Banco Westlb do Brasil S.A" },
                    { new Guid("b52d4702-894a-4cac-9dee-845fa97a595e"), "366", "Banco Societé Generale Brasil S.A." },
                    { new Guid("47f9628b-8c47-4af6-8e0c-6f3b034cbf79"), "341", "Banco Itaú S.A" },
                    { new Guid("d13de2a0-1882-4a2b-8459-4bde7c84d4f1"), "320", "Banco Industrial e Comercial S.A" },
                    { new Guid("32c5a55c-056f-4d81-8bde-29dc97aa8829"), "318", "Banco BMG S.A." },
                    { new Guid("5d82b18e-1260-4d1f-bdbe-526f9203253e"), "456", "Banco de Tokyo-Mitsubishi UFJ Brasil S/A" },
                    { new Guid("fd5a5b8f-a8f8-4081-8977-cf536c96820c"), "613", "Banco Pecunia S.A" },
                    { new Guid("c54e31fc-a5ce-4d3e-9e00-cfdd37f965a8"), "623", "Banco Panamericano S.A." },
                    { new Guid("3c0145e4-33da-43ab-9dfc-9e6f08597983"), "626", "Banco Ficsa S.A" },
                    { new Guid("3ad668eb-bd09-4f30-a839-7405e59c4bd6"), "753", "NBC Bank Brasil S. A. – Banco Múltiplo" },
                    { new Guid("bfdfeb8b-ffb6-4b3c-8bee-dc08fbb819eb"), "752", "Banco BNP Paribas Brasil S.A" },
                    { new Guid("8d1bc268-594f-4ddf-873c-0c6d8f49b3ea"), "751", "Dresdner Bank Brasil S.A. Banco Multiplo" },
                    { new Guid("9638ecd6-a03d-42d1-bcfd-7a7ea26fa619"), "749", "Banco Simples S.A" },
                    { new Guid("e5c8018d-f600-4e4a-aed2-3ae50787e6ca"), "748", "Banco Cooperativo Sicredi S.A." },
                    { new Guid("14465e81-5fd2-4ee3-bd3a-1456578982f4"), "747", "Banco Rabobank International Brasil S.A" },
                    { new Guid("7d638c3a-0ef5-4024-92f3-d10a9cdb7d7b"), "746", "Banco Modal S.A" },
                    { new Guid("da9a2c22-ad29-4b36-bab7-67ef0a9647f1"), "745", "Banco Citibank S.A." },
                    { new Guid("df8414cb-ff84-476b-b9bb-24a3d070da2f"), "743", "Banco Semear S.A." }
                });

            migrationBuilder.InsertData(
                table: "Bancos",
                columns: new[] { "Id", "CodigoBanco", "NomeInstituicao" },
                values: new object[,]
                {
                    { new Guid("f3833c8f-f80f-4360-8488-cce41198c22a"), "741", "Banco Ribeirao Preto S.A" },
                    { new Guid("c1dc2533-4900-400f-9752-fef2d5b9b693"), "740", "Banco Barclays S.A" },
                    { new Guid("48e87388-8172-41ed-8cf0-5afaa02c2d7a"), "739", "Banco BGN S.A." },
                    { new Guid("2476834d-1b9a-48ac-b0cf-96e1e4b095a2"), "738", "Banco Morada S.A" },
                    { new Guid("c69ba273-020b-455b-859e-79f4e1458699"), "735", "Banco Pottencial S.A" },
                    { new Guid("b470bf86-8133-48bf-9056-00578aeac1a9"), "734", "Banco Gerdau S.A" },
                    { new Guid("bc88fcd8-6a4e-4f0d-83af-d20a3b21437b"), "721", "Banco Credibel S.A." },
                    { new Guid("5966641f-64ab-4330-9cfc-982ab6b0602e"), "719", "Banif – Banco Internacional do Funchal (Brasil), S.A" },
                    { new Guid("99eab4dc-a7f5-4cc1-a5f9-db26a2a0768f"), "707", "Banco Daycoval S.A." },
                    { new Guid("f0fd67e3-4a58-4b5f-afdc-dc2bdf31a343"), "655", "Banco Votorantim S.A" },
                    { new Guid("77939e8e-5064-48c7-8ed2-e28b63840e9c"), "654", "Banco A.J. Renner S.A" },
                    { new Guid("abe454d9-c698-4732-a81c-33bd9dbe0b0b"), "653", "Banco Indusval S.A." },
                    { new Guid("ca7ff0a9-c5d3-47cc-8b33-a39fa527f170"), "652", "Itaú Unibanco Banco Múltiplo S.A" },
                    { new Guid("3ab75b43-1ddc-4865-96c2-24edac562b5a"), "643", "Banco Pine S.A." },
                    { new Guid("50872498-73a6-49e6-ad04-ab81cb12bc7a"), "641", "Banco Alvorada S.A." },
                    { new Guid("eacfcda3-bc62-477a-a7ab-34b71cd22759"), "638", "Banco Prosper S.A." },
                    { new Guid("e3da7144-a5af-402c-9ad9-f52666fe5385"), "637", "Banco Sofisa S.A" },
                    { new Guid("88a18136-b25e-4d67-96c6-03c9e9d607c5"), "634", "Banco Triangulo S.A." },
                    { new Guid("2da09d07-8404-4676-886f-65917d9954aa"), "633", "Banco Rendimento S.A." },
                    { new Guid("ec6d0360-4b79-4e47-b92c-312022fb2bb4"), "630", "Banco Intercap S.A" },
                    { new Guid("d599e8f4-4f9f-4ddb-9715-8112d9626e80"), "300", "Banco de La Nacion Argentina" },
                    { new Guid("18630d11-2f12-4e8e-be04-19509e2eaf05"), "266", "Banco Cedula S.A" },
                    { new Guid("48cab143-fc11-4401-a29f-8f4e45833dcc"), "265", "Banco Fator S.A" },
                    { new Guid("84107cca-72c2-4a09-99c1-f5865b51d4ba"), "263", "Banco Cacique S.A." },
                    { new Guid("7f57f382-581c-455a-8ca2-8edd708b22b5"), "076", "Banco KEB do Brasil S.A" },
                    { new Guid("fe8babe3-646b-4ad1-9446-0a5e30b5604a"), "075", "Banco CR2 S/A" },
                    { new Guid("61cd6140-7e5c-4225-8034-0ba120c695b0"), "074", "Banco J. Safra S.A" },
                    { new Guid("e6f594c2-5a25-4dee-9014-c57e2e32ae32"), "073", "BB Banco Popular do Brasil S.A." },
                    { new Guid("87729636-ed9e-4825-8950-99f71999e626"), "072", "Banco Rural Mais S.A" },
                    { new Guid("0310809a-d5e1-4330-8095-ff192a24926e"), "070", "BRB – Banco de Brasilia S.A" },
                    { new Guid("ab7126ec-5037-4166-905f-75494ed69726"), "069", "BPN Brasil Banco Múltiplo S.A." },
                    { new Guid("c0cc11ff-8fa6-443f-9395-f9f7e96ebef7"), "066", "Banco Morgan Stanley S.A" },
                    { new Guid("beeaaf93-ad7a-4fca-bc13-ef937f5388f9"), "065", "Banco Lemon S.A" },
                    { new Guid("d5855ed0-1d1c-439d-a503-9cf816981055"), "063", "Banco IBI S.A. – Banco Múltiplo" },
                    { new Guid("f107ea38-3c0a-470f-a103-d2212daacb68"), "062", "Hipercard Banco Múltiplo S.A" },
                    { new Guid("9623f30a-7915-4415-b598-e9feba6bcf24"), "047", "Banco do Estado de Sergipe S.A" },
                    { new Guid("4dabf2c2-0b62-4fe0-a985-e988ec36f8e3"), "045", "Banco Opportunity S.A." },
                    { new Guid("33f96e55-01a7-4b07-b30c-2fba43d560a5"), "044", "Banco BVA S.A" },
                    { new Guid("e923b312-5d7d-4fcd-b44c-e75af6750106"), "041", "Banco do Estado do Rio Grade do Sul S.A." },
                    { new Guid("f6933598-54bc-461a-b812-245299b7a06c"), "040", "Banco Cargil S.A" },
                    { new Guid("4be5aa59-78c3-475b-93e1-d4981f6bcb97"), "037", "Banco do Estado do Pará S.A" },
                    { new Guid("b3f9852a-35f0-41ae-8878-c99885b807b5"), "036", "Banco Bradesco BBI S.A." }
                });

            migrationBuilder.InsertData(
                table: "Bancos",
                columns: new[] { "Id", "CodigoBanco", "NomeInstituicao" },
                values: new object[,]
                {
                    { new Guid("b5617321-19dc-4e7f-b79e-99b2c7ddb562"), "033", "Banco Santander (Brasil) S.A" },
                    { new Guid("174ceb9c-108f-426b-9433-ca026013ae4a"), "031", "Banco Beg S.A." },
                    { new Guid("10a18c59-8da8-4f5f-a42a-cf46c19209f9"), "029", "Banco Banerj S.A" },
                    { new Guid("c727cd3c-ee35-4447-96d1-0fae3cf08e20"), "025", "Banco Alfa S.A" },
                    { new Guid("a1e5e4b4-10bf-4c4b-b899-6f4fccb0147c"), "024", "Banco de Pernambuco S.A. – BANDEPE" },
                    { new Guid("77b083fc-248f-411f-9b14-b313f4825931"), "021", "Banestes S.A. Banco do Estado do Espírito Santo S.A." },
                    { new Guid("f19029ad-81a2-4948-8283-8bede97434af"), "019", "Banco Azteca do Brasil S.A" },
                    { new Guid("66fe57e0-bae2-4d7f-b757-1879f0f45174"), "014", "Natixis Brasil S.A. Banco Múltiplo" },
                    { new Guid("fc54a9ea-3ce7-4683-b007-b6c4e80c942a"), "012", "Banco Standard de Investimentos S.A." },
                    { new Guid("87682ac7-9202-4c00-b5d0-cb1c87dd042e"), "004", "Banco do Nordeste do Brasil S.A." },
                    { new Guid("82806fa7-3345-45f0-ad08-a33ae7898725"), "003", "Banco da Amazonia S.A." },
                    { new Guid("c3c5fdb7-bce1-4e54-9ab3-cf87d1f155cc"), "077", "Banco Inter S/A" },
                    { new Guid("93fb55ec-1377-4267-a214-68d4a653a1ba"), "756", "Banco Cooperativo do Brasil S.A. – Bancoob" },
                    { new Guid("2c3d10c4-8906-4a36-8ed9-6949c33cfa69"), "078", "BES Investimentos do Brasil S.A." },
                    { new Guid("abfa2990-c849-416a-98b5-7912fd1f8b66"), "081", "Concórdia Banco S.A." },
                    { new Guid("e769614b-4c11-4fea-bae6-6cf66be99f9f"), "254", "Paraná Banco S.A." },
                    { new Guid("eb8fbc12-2f69-4db4-a745-d8026523c6e4"), "250", "Banco Schahin S.A." },
                    { new Guid("298a96b9-115a-49b7-9280-2931d2217183"), "249", "Banco Investicred Unibanco S.A." },
                    { new Guid("4ac281d8-657c-48be-afad-583875a7204e"), "248", "Banco Boavista Interatlantico S.A" },
                    { new Guid("5ad477f4-f394-413c-9b6d-38c867ebe1f2"), "246", "Banco ABC Brasil S.A." },
                    { new Guid("63dd9b57-d551-4161-b3d5-cc95f4946ba3"), "243", "Banco Máxima S.A." },
                    { new Guid("f96432b8-d78e-49ff-af06-2645b44e1a52"), "241", "Banco Classico S.A." },
                    { new Guid("655048a4-6814-4cb5-94ee-f10e6d2bd3d5"), "237", "Banco Bradesco S.A." },
                    { new Guid("cfc920b3-89d5-4d06-91b1-8f5729e8d3a0"), "233", "Banco GE Capital S.A." },
                    { new Guid("cf250596-6097-4225-81ea-f2a2331fca2b"), "230", "Unicard Banco Múltiplo S.A." },
                    { new Guid("0146d450-f9d2-4dec-8ff2-180c92a88289"), "229", "Banco Cruzeiro Do Sul S.A." },
                    { new Guid("0777f2dc-8615-4f92-8e4f-a4cf9dfbf62a"), "225", "Banco Brascan S.A." },
                    { new Guid("ad333ea3-0091-4583-ad8f-38e0271850be"), "224", "Banco Fibra S.A" },
                    { new Guid("2d1441db-fe02-4975-a312-c4c8688b9ad8"), "222", "Banco Calyon brasil S.A." },
                    { new Guid("6c5aa950-ab4a-41cd-ab2b-f6335a6438b0"), "218", "Banco Bonsucesso S.A." },
                    { new Guid("1e9bd700-ea58-4e5d-bf7a-ff79d073a7a6"), "217", "Banco John Deere S.A." },
                    { new Guid("80fc3993-f363-417f-b7bc-3f9ab7f0c6d7"), "215", "Banco Comercial e de Investimento Sudameris S.A." },
                    { new Guid("4cd3e561-daeb-44e3-84ff-31b36d5277be"), "214", "Banco Dibens S.A" },
                    { new Guid("fab0b568-7107-4887-9277-f19bc19a4d56"), "213", "Banco Arbi S.A." },
                    { new Guid("303a7a19-e6a4-4eef-8a37-bd16a4983fa7"), "212", "Banco Matone S.A." },
                    { new Guid("7e95a8b6-8199-45bb-b76f-59275abf81b2"), "208", "Banco UBS Pactual S.A." },
                    { new Guid("78e24099-e684-448a-ab03-4def5d3b2531"), "204", "Banco Bradesco Cartões S.A." },
                    { new Guid("c40f5cd7-90a6-4f0e-941c-e78319a86f72"), "184", "Banco Itaú BBA S.A." },
                    { new Guid("9626fa50-1087-4ef5-be92-7ac169744cff"), "151", "Banco Nossa Caixa S.A" },
                    { new Guid("6a2cdb2c-fb02-4eba-b6b7-cacb74c470e9"), "107", "Banco BBM S/A" },
                    { new Guid("1ff1f1cc-bf6c-46ed-8f2f-5b276601b88e"), "104", "Caixa Econômica Federal" },
                    { new Guid("ff8eb2d5-5e07-4fe4-8040-bfe3bc1955a0"), "096", "Banco BM&F de Serviços de Liquidação e Custodia S.A." }
                });

            migrationBuilder.InsertData(
                table: "Bancos",
                columns: new[] { "Id", "CodigoBanco", "NomeInstituicao" },
                values: new object[,]
                {
                    { new Guid("05c42d69-de0e-4f16-bf9c-5a36a5f23d0b"), "083", "Banco da China Brasil S.A" },
                    { new Guid("1cb3eb5d-8e37-4597-b0f1-70e3a2a26ca1"), "082", "Banco Topázio S.A" },
                    { new Guid("2a31b71f-fb9f-45ed-92fc-2b6746edeaf7"), "079", "JBS Banco S/A" },
                    { new Guid("2877aa43-6787-4fd3-916b-b45ef6d9d957"), "757", "Banco KEB do Brasil S.A." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContasBancarias_BancoId",
                table: "ContasBancarias",
                column: "BancoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContasBancarias");

            migrationBuilder.DropTable(
                name: "Bancos");
        }
    }
}
