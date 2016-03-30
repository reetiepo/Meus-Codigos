--SELECT 1 - Mostrar a situação de cada aluno em cada matéria
SELECT 
	A.alu_nome Nome
    , A.alu_CPF CPF
    , M.mat_nome 'Matéria'
    , CASE SA.sit_situacao
    	WHEN 0 THEN 'Cursando'
    	WHEN 1 THEN 'Aprovado'
        WHEN 2 THEN 'Reprovado'
      END 'Situação'
FROM aluno A 
INNER JOIN situacao_aluno SA
	ON A.alu_cod = SA.alu_cod
INNER JOIN materia M
	ON SA.mat_cod = M.mat_cod
    AND SA.ser_cod = M.ser_cod
ORDER BY
	A.alu_nome
	
--SELECT 2 - Pesquisa alunos aprovados
SELECT 
	A.alu_nome Nome
    , A.alu_CPF CPF
    , S.ser_descricao 'Série'
    , SA.sit_media 'Média'
    , SA.sit_frequencia 'Frequência'
FROM aluno A 
INNER JOIN situacao_aluno SA
	ON A.alu_cod = SA.alu_cod
INNER JOIN serie S
	ON SA.ser_cod = S.ser_cod
WHERE
	 SA.sit_situacao = 1
	 
--SELECT 3 - Calcula Média
SELECT 
	A.alu_nome Nome
    , A.alu_CPF CPF
    , S.ser_descricao 'Série'
    , M.mat_nome 'Matéria'
    , (SUM(P.not_nota)/COUNT(P.not_cod) * 0.7) + (SUM(T.not_nota)/COUNT(T.not_cod) * 0.3) 'Média'
    , SA.sit_frequencia 'Frequência'
FROM aluno A 
INNER JOIN situacao_aluno SA
	ON A.alu_cod = SA.alu_cod
INNER JOIN notas P
  ON SA.sit_cod = P.sit_cod
  AND P.not_tipo = 1
INNER JOIN notas T
  ON SA.sit_cod = T.sit_cod
  AND T.not_tipo = 2
INNER JOIN materia M
  ON SA.mat_cod = M.mat_cod
INNER JOIN serie S
  ON SA.ser_cod = S.ser_cod
GROUP BY
	A.alu_cod
    , SA.sit_cod
	 
-- SELECT 4 - Seleciona os professores e sua especialidade
SELECT 
	F.fun_nome Nome
    , F.fun_CPF CPF
    , E.esp_nome 'Especialidade'
FROM funcionario F
INNER JOIN professor P
	ON F.fun_cod = P.fun_cod
INNER JOIN especialidade E
	ON P.esp_cod = E.esp_cod
