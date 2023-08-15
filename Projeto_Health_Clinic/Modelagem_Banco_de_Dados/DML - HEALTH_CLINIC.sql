--DML - DATA MANIPULATION LANGUAGE

USE Health_Clinic_TD

INSERT INTO Clinica(NomeFantasia,RazaoSocial,CNPJ,Endereco,HorarioAbertura,HoraFechamento)
VALUES('Health Clinic','Health Clinic Atendimentos Ltda.','90023595000193','Rua Niterói, São Caetano do Sul - SP','06:00:00','22:00:00')
SELECT * FROM Clinica

INSERT INTO TipoUsuario(TituloTipoUsuario)
VALUES('Adiministrador'),('Médico'),('Comum')
SELECT * FROM TipoUsuario

INSERT INTO Especialidade(TituloEspecialidade)
VALUES('Pediatria'),('Pneumologia'),('Psiquiatria'),('Neurologia'),('Ortopedia')
SELECT * FROM Especialidade

INSERT INTO Usuario(IdTipoUsuario,Nome,Email,Senha,DataNascimento)
VALUES(1,'Vinicius','vinicius@email.com','123','2000-08-14'),(2,'Vitor','vitor@email.com','456','1998-08-14'),(3,'Tiago','tiago@email.com','789','2001-07-01')
SELECT * FROM Usuario

INSERT INTO Paciente(IdUsuario,RG,CPF,Endereco,Telefone)
VALUES(3,'340864965','90419973001','Avenida Alameda das Travessas,nº111','3303-3333')
SELECT * FROM Paciente

INSERT INTO Medico(IdClinica,IdEspecialidade,IdUsuario,CRM)
VALUES(1,4,2,'123456SP')
SELECT * FROM Medico

INSERT INTO Consulta(IdMedico,IdPaciente,IdClinica,Descricao,HoraConsulta,DataConsulta)
VALUES(1,1,1,'Foi realizado um consulta onde após o atendimento o paciente passou pelo exame: Ressonância magnética','13:30:00','2023-05-26')
SELECT * FROM Consulta

INSERT INTO Comentario(IdPaciente,IdConsulta,Descricao)
VALUES(1,3,'Ótima consulta, bom atendimento e e ótimos profissionais')
SELECT * FROM Comentario