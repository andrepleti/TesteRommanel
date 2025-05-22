using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteRommanel.Infra.Data.Migrations.MySql.Migrations
{
    /// <inheritdoc />
    public partial class CadastroTeste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO Cliente (
                                        NomeRazaoSocial,
                                        CpfCnpj,
                                        InscricaoEstadual,
                                        Isento,
                                        DataNascimento,
                                        Telefone,
                                        Email,
                                        Tipo,
                                        Cep,
                                        Logradouro,
                                        Numero,
                                        Bairro,
                                        Cidade,
                                        Estado,
                                        Status,
                                        DataCriacao,
                                        DataModificacao
                                    ) VALUES (
                                        'André',
                                        '00993564062',
                                        '',
                                        FALSE,
                                        '1990-04-09',
                                        '14999999999',
                                        'andre@email.com',
                                        1,
                                        '11111111',
                                        'Rua Um',
                                        '11',
                                        'Centro',
                                        'Bauru',
                                        'SP',
                                        1,
                                        NOW(),
                                        NOW()
                                    );
                                    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM Cliente WHERE CpfCnpj = '00993564062';");
        }
    }
}
