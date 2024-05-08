use TestePositivo

select * from Aluno
select * from Endereco

SELECT COUNT(*) AS TotalAlunos
FROM Aluno;

SELECT Serie, COUNT(*) AS TotalPorSerie
FROM Aluno
GROUP BY Serie;

SELECT Segmento, COUNT(*) AS TotalPorSegmento
FROM Aluno
GROUP BY Segmento;

SELECT Segmento, COUNT(*) AS Total
FROM Aluno
WHERE DATEDIFF(year, DataNascimento, GETDATE()) BETWEEN 4 AND 8
GROUP BY Segmento;


SELECT NomePai, NomeMae, COUNT(*) AS QuantidadeDeIrmaos, STRING_AGG(NomeCompleto, ', ') AS NomesDosIrmaos
FROM Aluno
GROUP BY NomePai, NomeMae
HAVING COUNT(*) > 1;
