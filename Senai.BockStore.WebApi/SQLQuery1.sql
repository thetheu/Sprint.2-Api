CREATE DATABASE T_BookStore;

USE T_BookStore;

SELECT Generos.Descricao, Generos.IdGenero FROM Generos
CREATE TABLE Generos
(
    IdGenero    INT PRIMARY KEY IDENTITY
    ,Descricao  VARCHAR(200) NOT NULL UNIQUE
);

CREATE TABLE Autores 
(
    IdAutor             INT PRIMARY KEY IDENTITY
    ,Nome               VARCHAR(200)
    ,Email              VARCHAR(255) UNIQUE
    ,Ativo              BIT DEFAULT(1) -- BIT/CHAR
    ,DataNascimento     DATE
);

CREATE TABLE Livros
(
    IdLivro             INT PRIMARY KEY IDENTITY
    ,Titulo             VARCHAR(255) NOT NULL UNIQUE
    ,IdAutor            INT FOREIGN KEY REFERENCES Autores (IdAutor)
    ,IdGenero           INT FOREIGN KEY REFERENCES Generos (IdGenero)
);

INSERT INTO Generos (Descricao) VALUES ('Ficção'), ('Terror')

INSERT INTO Autores (Nome, Email, Ativo, DataNascimento) VALUES ('J.K. Rowlling', 'JayJay@hotmail.com', '1', '30/07/1965')

INSERT INTO Livros (Titulo, IdAutor, IdGenero) VALUES ('Harry Potter', '1', '1')
