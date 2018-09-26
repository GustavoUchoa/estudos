using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RepositorioGeek.Migrations
{
    public partial class FilmePopular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Filmes(Nome, Concluido, Classificacao, DataCadastro, DataConclusao) VALUES('Destino de Uma Nação', 1, 3, '20180118', '20180118')");
            migrationBuilder.Sql("INSERT INTO Filmes(Nome, Concluido, Classificacao, DataCadastro, DataConclusao) VALUES('Me Chame Pelo Seu Nome', 1, 2, '20180118', '20180118')");
            migrationBuilder.Sql("INSERT INTO Filmes(Nome, Concluido, Classificacao, DataCadastro, DataConclusao) VALUES('Dunkirk', 1, 3, '20170216', '20170216')");
            migrationBuilder.Sql("INSERT INTO Filmes(Nome, Concluido, Classificacao, DataCadastro, DataConclusao) VALUES('Corra!', 1, 1, '20180106', '20180106')");
            migrationBuilder.Sql("INSERT INTO Filmes(Nome, Concluido, Classificacao, DataCadastro, DataConclusao) VALUES('The Post: A Guerra Secreta', 1, 2, '20180126', '20180126')");

            migrationBuilder.Sql("INSERT INTO Filmes(Nome, Concluido, Classificacao, DataCadastro, DataConclusao) VALUES('Lady Bird: É Hora de Voar', 0, 0, '20180127', null)");
            migrationBuilder.Sql("INSERT INTO Filmes(Nome, Concluido, Classificacao, DataCadastro, DataConclusao) VALUES('Trama Fantasma', 0, 0, '20180127', null)");
            migrationBuilder.Sql("INSERT INTO Filmes(Nome, Concluido, Classificacao, DataCadastro, DataConclusao) VALUES('A Forma da Água', 0, 0, '20180127', null)");
            migrationBuilder.Sql("INSERT INTO Filmes(Nome, Concluido, Classificacao, DataCadastro, DataConclusao) VALUES('Três Anúncios Para Um Crime', 0, 0, '20180127', null)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Filmes");
        }
    }
}
