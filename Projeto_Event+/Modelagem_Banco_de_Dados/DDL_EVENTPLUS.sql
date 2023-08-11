--DDL - Data Definition Language

--Criar banco de dados
CREATE DATABASE [Event+_Tarde]

USE [Event+_Tarde]
--Criar as tabelas

CREATE TABLE TipoUsuario(
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	TituloTipoUsuario VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE TipoEvento(
	IdTipoEvento INT PRIMARY KEY IDENTITY,
	TituloTipoEvento VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Instituicao(
	IdInstituicao INT PRIMARY KEY IDENTITY,
	NomeFantasia VARCHAR(200) NOT NULL,
	Endereco VARCHAR(200) NOT NULL,
	CNPJ CHAR(14) NOT NULL UNIQUE,
);



CREATE TABLE Usuario( 
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario) NOT NULL,
	NomeUsuario VARCHAR(50) NOT NULL,
	EmailUsuario VARCHAR(50) NOT NULL UNIQUE,
	SenhaUsuario VARCHAR(50) NOT NULL,
);

CREATE TABLE Evento(
	IdEvento INT PRIMARY KEY IDENTITY,
	IdInstituicao INT FOREIGN KEY REFERENCES Instituicao (IdInstituicao) NOT NULL,
	IdTipoEvento INT FOREIGN KEY REFERENCES TipoEvento (IdTipoEvento) NOT NULL,
	NomeEvento VARCHAR(50) NOT NULL,
	Descricao VARCHAR(50) NOT NULL,
	DataEvento DATE NOT NULL,
	HorarioEvento TIME NOT NULL
);

CREATE TABLE PresencaEvento
(
	IdPresencaEvento INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento) NOT NULL,
	Situacao BIT DEFAULT(0)
);

CREATE TABLE ComentarioEvento(
	IdComentarioEvento INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento) NOT NULL,
	Descricao VARCHAR(200) NOT NULL,
	Exibe BIT DEFAULT(0)
);
