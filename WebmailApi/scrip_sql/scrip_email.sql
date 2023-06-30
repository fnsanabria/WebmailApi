-- Crear la base de datos
CREATE DATABASE EmailDB;

-- Usar la base de datos
USE EmailDB;

-- Crear la tabla de usuarios
CREATE TABLE Usuarios (
    UsuarioId INT IDENTITY(1,1) PRIMARY KEY,    
    CorreoElectronico NVARCHAR(100) NOT NULL,
    Pass NVARCHAR(100) NOT NULL
);

-- Crear la tabla de correos electrónicos
CREATE TABLE Emails (
    EmailId INT IDENTITY(1,1) PRIMARY KEY,
    RemitenteId INT NOT NULL,
    DestinatarioId INT NOT NULL,
    Asunto NVARCHAR(200) NOT NULL,
    Contenido NVARCHAR(MAX) NOT NULL,
    Fecha DATETIME NOT NULL,
    Leido BIT NOT NULL DEFAULT 0,
    Bandeja BIT NOT NULL, --bandeja se usa para 1 entrada 0 salida
    FOREIGN KEY (RemitenteId) REFERENCES Usuarios(UsuarioId),
    FOREIGN KEY (DestinatarioId) REFERENCES Usuarios(UsuarioId)
);

