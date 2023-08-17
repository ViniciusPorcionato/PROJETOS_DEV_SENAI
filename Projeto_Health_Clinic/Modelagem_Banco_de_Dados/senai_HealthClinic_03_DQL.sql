--DQL - DATA QUERY LANGUAGE

USE Health_Clinic_TD

SELECT Consulta.IdConsulta,
Consulta.DataConsulta,
Consulta.HoraConsulta,
Clinica.NomeFantasia,
P.Nome AS NomePaciente, 
M.Nome AS NomeMedico,
Especialidade.TituloEspecialidade AS EspecialidadeMedico,
Medico.CRM,
Consulta.Descricao AS Prontuario,
Comentario.Descricao AS Feedback

FROM Consulta
INNER JOIN Paciente ON Consulta.IdPaciente = Paciente.IdPaciente
INNER JOIN Medico ON Consulta.IdMedico = Medico.IdMedico
INNER JOIN Usuario M ON Medico.IdUsuario = M.IdUsuario
INNER JOIN Usuario P ON Paciente.IdUsuario = P.IdUsuario
INNER JOIN Especialidade ON Medico.IdEspecialidade = Especialidade.IdEspecialidade
INNER JOIN Clinica ON Consulta.IdClinica = Clinica.IdClinica
LEFT JOIN Comentario ON Paciente.IdPaciente = Comentario.IdPaciente
