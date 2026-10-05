using System;
using System.Collections.Generic;
using System.Text;
using SDVE.Models;

namespace SDVE.Services
{
    internal class DatosService
    {
        public static List<Convocatoria> Convocatorias { get; } = new List<Convocatoria>
        {
            new Convocatoria
            {
                Id = 1,
                Nombre = "Sociedad de Alumnos",
                Activa = true
            },

            new Convocatoria
            {
                Id = 2,
                Nombre = "Consejo Univesitario",
                Activa = true
            },

            new Convocatoria
            {
                Id = 3,
                Nombre = "Consejo de Representantes",
                Activa = true
            }
        };

        public static List<Candidato> Candidatos { get; } = new List<Candidato>
        {
            // Sociedad de Alumnos
            new Candidato
            {
                Id = 1,
                Nombre = "Jose Sebastian Valadez Silva",
                ConvocatoriaId = 1,
                EsRegistrado = true
            },

            new Candidato
            {
                Id = 2,
                Nombre = "Valeria Alejandra Centeno Solorzano",
                ConvocatoriaId = 1,
                EsRegistrado = true
            },

            new Candidato
            {
                Id = 3,
                Nombre = "Analy Iridian Sánchez Ruiz",
                ConvocatoriaId = 1,
                EsRegistrado = true
            },

            // Consejo Universitario
            new Candidato
            {
                Id = 4,
                Nombre = "Miguel Angel Aguilar Granados",
                ConvocatoriaId = 2,
                EsRegistrado = true
            },

            new Candidato
            {
                Id = 5,
                Nombre = "Daana Paola Diaz Loza",
                ConvocatoriaId = 2,
                EsRegistrado = true
            },

            // Consejo de Representantes
            new Candidato
            {
                Id = 6,
                Nombre = "Karla Andrea Llamas Valle",
                ConvocatoriaId = 3,
                EsRegistrado = true
            },

            new Candidato
            {
                Id = 7,
                Nombre = "Geraldyn Irene Campos Aguirre",
                ConvocatoriaId = 3,
                EsRegistrado = true
            }
        };

        public static List<Alumno> Alumnos { get; } = new List<Alumno>
        {
            new Alumno
            {
                Matricula = "0001",
                Nombre = "Jose Sebastian Valadez Silva",
                Grupo = "5A",
                Carrera = "Infortmatica y Tecnologías Computacionales",
                CentroUniversitario = "Centro de Ciencias Básicas"
            },
             new Alumno
            {
                Matricula = "0002",
                Nombre = "Valeria Alejandra Centeno Solorzano",
                Grupo = "5A",
                Carrera = "Infortmatica y Tecnologías Computacionales",
                CentroUniversitario = "Centro de Ciencias Básicas"
            },
              new Alumno
            {
                Matricula = "0003",
                Nombre = "Analy Iridian Sánchez Ruiz",
                Grupo = "5A",
                Carrera = "Infortmatica y Tecnologías Computacionales",
                CentroUniversitario = "Centro de Ciencias Básicas"
            },
               new Alumno
            {
                Matricula = "0004",
                Nombre = "Miguel Angel Aguilar Granados",
                Grupo = "5A",
                Carrera = "Infortmatica y Tecnologías Computacionales",
                CentroUniversitario = "Centro de Ciencias Básicas"
            },
                new Alumno
            {
                Matricula = "0005",
                Nombre = "Daana Paola Diaz Loza",
                Grupo = "5A",
                Carrera = "Infortmatica y Tecnologías Computacionales",
                CentroUniversitario = "Centro de Ciencias Básicas"
            },
                 new Alumno
            {
                Matricula = "0006",
                Nombre = "Karla Andrea Llamas Valle",
                Grupo = "5A",
                Carrera = "Infortmatica y Tecnologías Computacionales",
                CentroUniversitario = "Centro de Ciencias Básicas"
            },
            new Alumno
            {
                Matricula = "0007",
                Nombre = "Geraldyn Irene Campos Aguirre",
                Grupo = "5B",
                Carrera = "Diseño de Interiores",
                CentroUniversitario = "Centro de Ciencias del Diseño y la Construcción"
            },


        };
            
        public static List<Voto> Votos { get; } = new List<Voto>();
    }
}
