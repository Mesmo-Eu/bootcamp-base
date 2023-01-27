using Dapper;
using System;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using Tarefas.DTO;

namespace Tarefas.DAO
{
    public class UsuarioDAO : BaseDAO, IUsuarioDAO
    {

        public UsuarioDAO()
        {
            if(!File.Exists(DataSourceFile))
            {
                CreateDatabase();
            }
        }
        
        private void CreateDatabase()
        {
            using(var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"CREATE TABLE Usuario
                    (
                        Id          integer primary key autoincrement,
                        Email       varchar(100) not null,
                        Senha       varchar(100) not null,
                        Nome        varchar(100) not null,
                        Ativo       bool not null
                    )"
                );
            }
        }

        public void Criar(UsuarioDTO usuario)
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"INSERT INTO Usuario (Email, Senha, Nome, Ativo) VALUES 
                    (@Email. @Senha, @Nome, @Ativo);", usuario
                ); 
            }
        }

        public List<UsuarioDTO> Consultar()
        {
            using (var con = Connection)
            {
                con.Open();
                var result = con.Query<TarefaDTO>(
                    @"SELECT Id, Email, Senha, Nome, Ativo FROM Usuario").ToList();
                    return result;
            }
        }

        public UsuarioDTO Consultar(int id)
        {
            using (var con = Connection)
            {
                con.Open();
                TarefaDTO result = con.Query<TarefaDTO>
                (
                    @"SELECT Id, Email, Senha, Nome, Ativo FROM Usuario 
                    WHERE Id = @Id", new{id}
                ).FirstOrDefault();
            return result;
            }
        }

        public void Atualizar(UsuarioDTO tarefa)
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"UPDATE Usuario
                    SET Email = @Email, Senha = @Senha, Nome = @Nome, Ativo = @Ativo
                    WHERE Id = @Id;", tarefa
                );
            }

        }

        public void Excluir(int id)
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"DELETE FROM Usuario
                    WHERE Id = @Id", new {id}
                );
            }
        }


    }
}