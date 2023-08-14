--DDL - DATA DEFINITION LANGUAGE

CREATE DATABASE Health_Clinic_TD

USE Health_Clinic_TD

CREATE TABLE Clinica(

IdClinica INT PRIMARY KEY IDENTITY,
NomeFantasia VARCHAR(50),
RazaoSocial VARCHAR(150),
CNPJ CHAR(14),
Endereco VARCHAR(200),
HorarioAbertura TIME,
HoraFechamento TIME

);


CREATE TABLE TipoUsuario(

IdTipoUsuario INT PRIMARY KEY IDENTITY,
TituloTipoUsuario VARCHAR(50)

);

CREATE TABLE Especialidade(

IdEspecialidade INT PRIMARY KEY IDENTITY,
TituloEspecialidade VARCHAR(100)

);


CREATE TABLE Usuario(

IdUsuario INT PRIMARY KEY IDENTITY,
IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario),
Nome VARCHAR(100),
Email VARCHAR(100),
Senha VARCHAR(50)
);

CREATE TABLE Paciente(

IdPaciente INT PRIMARY KEY IDENTITY,
IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
RG CHAR(9),
CPF CHAR(11),
DataNascimento DATE,
Endereco VARCHAR(100),
Telefone VARCHAR(9)
);

CREATE TABLE Medico(

IdMedico INT PRIMARY KEY IDENTITY,
IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica),
IdEspecialidade INT FOREIGN KEY REFERENCES Especialidade(IdEspecialidade),
IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
CRM CHAR(8)

);


CREATE TABLE Consulta(

IdConsulta INT PRIMARY KEY IDENTITY,
IdMedico INT FOREIGN KEY REFERENCES Medico(IdMedico),
IdPaciente INT FOREIGN KEY REFERENCES Paciente(IdPaciente),
IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica),
Descricao VARCHAR(250),
HoraConsulta DATE

);