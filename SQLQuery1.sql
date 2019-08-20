CREATE DATABASE T_RoteiroFilmes;

USE T_RoteiroFilmes;

CREATE TABLE Generos 
(
    IdGenero    INT PRIMARY KEY IDENTITY
    ,Nome       VARCHAR(200) NOT NULL UNIQUE
);

CREATE TABLE Filmes
(
    IdFilme     INT PRIMARY KEY IDENTITY
    ,Titulo     VARCHAR(200) UNIQUE
    ,IdGenero   INT FOREIGN KEY REFERENCES Generos (IdGenero)
);

SELECT * FROM Generos
INSERT INTO Generos (Nome) VALUES ('Romance') ,('Terror')

SELECT * FROM Filmes
INSERT INTO Filmes (Titulo, IdGenero) VALUES ('A culpa é das estrelas', 1)
											,('Sociedade dos poetas mortos', 2)


INSERT INTO Generos(Nome) VALUES('')

UPDATE Genero
SET Nome = Ficcao
WHERE IdGenero = 1