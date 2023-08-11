--DQL - LINGUAGEM DE DEFINIÇÃO DE DADOS

USE [Event+_tarde]

SELECT 
Usuario.NomeUsuario,TipoUsuario.TituloTipoUsuario,Evento.DataEvento,CONCAT(Instituicao.NomeFantasia,' - ',Instituicao.Endereco) AS Endereco,TipoEvento.TituloTipoEvento,NomeEvento,Evento.Descricao AS DescricaoEvento,
CASE WHEN PresencaEvento.Situacao = 1 THEN 'Confirmado' ELSE 'Não Confirmado' END AS Presenca,ComentarioEvento.Descricao AS Comentario
FROM Evento
INNER JOIN TipoEvento ON Evento.IdTipoEvento = TipoEvento.IdTipoEvento
INNER JOIN Instituicao ON Evento.IdInstituicao = Instituicao.IdInstituicao
INNER JOIN PresencaEvento ON Evento.IdEvento = PresencaEvento.IdEvento
INNER JOIN Usuario ON Usuario.IdUsuario = PresencaEvento.IdUsuario
INNER JOIN TipoUsuario ON TipoUsuario.IdTipoUsuario = Usuario.IdTipoUsuario
LEFT JOIN ComentarioEvento ON ComentarioEvento.IdUsuario = Usuario.IdUsuario