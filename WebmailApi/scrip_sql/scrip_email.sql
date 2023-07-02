-- Crear la base de datos
CREATE DATABASE EmailDB;

-- Usar la base de datos
USE EmailDB;

-- Crear la tabla de usuarios
CREATE TABLE Usuarios (
    UsuarioId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
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
    FOREIGN KEY (RemitenteId) REFERENCES Usuarios(UsuarioId),
    FOREIGN KEY (DestinatarioId) REFERENCES Usuarios(UsuarioId)
);

-- Crear la tabla de bandeja de entrada
CREATE TABLE BandejaEntrada (
    BandejaEntradaId INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT NOT NULL,
    EmailId INT NOT NULL,
    Leido BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(UsuarioId),
    FOREIGN KEY (EmailId) REFERENCES Emails(EmailId)
);

-- Crear la tabla de bandeja de salida
CREATE TABLE BandejaSalida (
    BandejaSalidaId INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT NOT NULL,
    EmailId INT NOT NULL,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(UsuarioId),
    FOREIGN KEY (EmailId) REFERENCES Emails(EmailId)
);
