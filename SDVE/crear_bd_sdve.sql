-- Ejecutar en MySQL Workbench para crear la base y tablas que usa SDVE.
CREATE DATABASE IF NOT EXISTS sdve
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_unicode_ci;
USE sdve;

CREATE TABLE IF NOT EXISTS Administradores (
    IdAdmin INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Usuario VARCHAR(50) NOT NULL UNIQUE,
    Contrasena VARCHAR(255) NOT NULL,
    Nombre VARCHAR(150) NOT NULL
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS Alumnos (
    Matricula VARCHAR(30) NOT NULL PRIMARY KEY,
    Nombre VARCHAR(150) NOT NULL,
    Carrera VARCHAR(150) NOT NULL,
    Semestre VARCHAR(30) NOT NULL,
    Contrasena VARCHAR(255) NOT NULL,
    YaVoto TINYINT(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS Convocatorias (
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(120) NOT NULL,
    Activa TINYINT(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS Candidatos (
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(150) NOT NULL,
    ConvocatoriaId INT NOT NULL,
    EsRegistrado TINYINT(1) NOT NULL DEFAULT 1,
    CONSTRAINT fk_candidatos_convocatoria FOREIGN KEY (ConvocatoriaId)
        REFERENCES Convocatorias(Id) ON UPDATE CASCADE ON DELETE RESTRICT
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS Votos (
    Id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    MatriculaAlumno VARCHAR(30) NOT NULL,
    Grupo VARCHAR(30) NOT NULL,
    Carrera VARCHAR(150) NOT NULL,
    CentroUniversitario VARCHAR(150) NOT NULL,
    ConvocatoriaId INT NOT NULL,
    CandidatoId INT NULL,
    CandidatoNoRegistrado VARCHAR(150) NULL,
    FechaHora DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT uq_voto_alumno_convocatoria UNIQUE (MatriculaAlumno, ConvocatoriaId),
    CONSTRAINT fk_votos_alumno FOREIGN KEY (MatriculaAlumno)
        REFERENCES Alumnos(Matricula) ON UPDATE CASCADE ON DELETE RESTRICT,
    CONSTRAINT fk_votos_convocatoria FOREIGN KEY (ConvocatoriaId)
        REFERENCES Convocatorias(Id) ON UPDATE CASCADE ON DELETE RESTRICT,
    CONSTRAINT fk_votos_candidato FOREIGN KEY (CandidatoId)
        REFERENCES Candidatos(Id) ON UPDATE CASCADE ON DELETE RESTRICT,
    CONSTRAINT ck_voto_una_opcion CHECK (
        (CandidatoId IS NOT NULL AND CandidatoNoRegistrado IS NULL) OR
        (CandidatoId IS NULL AND CandidatoNoRegistrado IS NOT NULL)
    )
) ENGINE=InnoDB;

INSERT INTO Convocatorias (Id, Nombre, Activa) VALUES
    (1, 'Sociedad de Alumnos', TRUE),
    (2, 'Consejo Universitario', TRUE),
    (3, 'Consejo de Representantes', TRUE)
ON DUPLICATE KEY UPDATE Nombre = VALUES(Nombre);

-- Agrega aquí tu administrador y alumnos. No guardes datos de prueba en producción.
-- INSERT INTO Administradores (Usuario, Contrasena) VALUES ('admin', 'cambia-esta-clave');
-- INSERT INTO Alumnos (Matricula, Nombre, Grupo, Carrera, CentroUniversitario, Contrasena)
-- VALUES ('0001', 'Nombre del alumno', '5A', 'Carrera', 'Centro Universitario', 'cambia-esta-clave');