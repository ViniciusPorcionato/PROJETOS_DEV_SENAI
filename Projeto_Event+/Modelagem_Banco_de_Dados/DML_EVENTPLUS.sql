-- DML - LINGUAGEM DE MANIPULAÇÃO DE DADOS

USE [Event+_tarde]


INSERT INTO TipoUsuario(TituloTipoUsuario)
VALUES('Administrador'),('Comum')

INSERT INTO TipoEvento(TituloTipoEvento)
VALUES('SQL Server')

INSERT INTO Instituicao(NomeFantasia,Endereco,CNPJ)
VALUES('DevSchool','Rua Niterói, 180 São Caetano do Sul','24797595000116')

INSERT INTO Usuario(IdTipoUsuario,NomeUsuario,EmailUsuario,SenhaUsuario)
VALUES(2,'Vinicius Porcionato','vinicius@email.com','123'),(1,'Carlos','carlos@email.com','123')

INSERT INTO Evento(IdInstituicao,IdTipoEvento,NomeEvento,Descricao,DataEvento,HorarioEvento)
VALUES(1,1,'Introdução ao Banco de Dados','Aula introdutória ao SQL Server','2023-08-14','14:15:00')

INSERT INTO PresencaEvento(IdUsuario,IdEvento,Situacao)
VALUES(1,1,1)

INSERT INTO ComentarioEvento(IdUsuario,IdEvento,Descricao,Exibe)
VALUES(1,1,'Professores mt top!',1)

SELECT * FROM TipoUsuario
SELECT * FROM TipoEvento
SELECT * FROM Instituicao
SELECT * FROM Usuario
SELECT * FROM Evento
SELECT * FROM PresencaEvento
SELECT * FROM ComentarioEvento
