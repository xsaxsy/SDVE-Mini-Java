using MySqlConnector;
using SDVE.Models;

namespace SDVE.Services
{
    internal static class DatosService
    {
        public static List<Convocatoria> Convocatorias { get; } = new();
        public static List<Candidato> Candidatos { get; } = new();
        public static List<Alumno> Alumnos { get; } = new();
        public static List<Voto> Votos { get; } = new();

        public static void CargarDatos()
        {
            CargarConvocatorias();
            CargarCandidatos();
            CargarAlumnos();
            CargarVotos();
        }

        public static void CargarConvocatorias()
        {
            Convocatorias.Clear();
            using var conn = ObtenerConexionAbierta();
            using var cmd = new MySqlCommand("SELECT Id, Nombre, Activa FROM Convocatorias", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                Convocatorias.Add(new Convocatoria
                {
                    Id = reader.GetInt32("Id"),
                    Nombre = reader.GetString("Nombre"),
                    Activa = reader.GetBoolean("Activa")
                });
        }

        public static void CargarCandidatos()
        {
            Candidatos.Clear();
            using var conn = ObtenerConexionAbierta();
            using var cmd = new MySqlCommand("SELECT Id, Nombre, ConvocatoriaId, EsRegistrado FROM Candidatos", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                Candidatos.Add(new Candidato
                {
                    Id = reader.GetInt32("Id"),
                    Nombre = reader.GetString("Nombre"),
                    ConvocatoriaId = reader.GetInt32("ConvocatoriaId"),
                    EsRegistrado = reader.GetBoolean("EsRegistrado")
                });
        }

        public static void CargarAlumnos()
        {
            Alumnos.Clear();
            using var conn = ObtenerConexionAbierta();
            using var cmd = new MySqlCommand("SELECT Matricula, Nombre, Carrera, Semestre FROM Alumnos", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string semestre = Convert.ToString(reader["Semestre"]) ?? string.Empty;
                Alumnos.Add(new Alumno
                {
                    Matricula = reader.GetString("Matricula"),
                    Nombre = reader.GetString("Nombre"),
                    Semestre = semestre,
                    Grupo = semestre,
                    Carrera = reader.GetString("Carrera"),
                    CentroUniversitario = string.Empty
                });
            }
        }

        public static void CargarVotos()
        {
            Votos.Clear();
            using var conn = ObtenerConexionAbierta();
            using var cmd = new MySqlCommand("SELECT Id, MatriculaAlumno, Grupo, Carrera, CentroUniversitario, ConvocatoriaId, CandidatoId, CandidatoNoRegistrado, FechaHora FROM Votos", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                Votos.Add(new Voto
                {
                    Id = reader.GetInt32("Id"),
                    MatriculaAlumno = reader.GetString("MatriculaAlumno"),
                    Grupo = reader.GetString("Grupo"),
                    Carrera = reader.GetString("Carrera"),
                    CentroUniversitario = reader.GetString("CentroUniversitario"),
                    ConvocatoriaId = reader.GetInt32("ConvocatoriaId"),
                    CandidatoId = reader.IsDBNull(reader.GetOrdinal("CandidatoId")) ? null : reader.GetInt32("CandidatoId"),
                    CandidatoNoRegistrado = reader.IsDBNull(reader.GetOrdinal("CandidatoNoRegistrado")) ? string.Empty : reader.GetString("CandidatoNoRegistrado"),
                    FechaHora = reader.GetDateTime("FechaHora")
                });
        }

        private static MySqlConnection ObtenerConexionAbierta()
        {
            var conexion = new Conexion();
            var conn = conexion.ObtenerConexion();
            conn.Open();
            return conn;
        }

        public static int AgregarCandidato(string nombre, int convocatoriaId)
        {
            var conexion = new Conexion();
            using var conn = conexion.ObtenerConexion();
            conn.Open();
            using var cmd = new MySqlCommand("INSERT INTO Candidatos (Nombre, ConvocatoriaId, EsRegistrado) VALUES (@nombre, @convocatoriaId, TRUE)", conn);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@convocatoriaId", convocatoriaId);
            cmd.ExecuteNonQuery();
            var nuevoId = (int)cmd.LastInsertedId;
            CargarCandidatos();
            return nuevoId;
        }

        public static void ActualizarCandidato(int id, string nombre, int convocatoriaId)
        {
            var conexion = new Conexion();
            using var conn = conexion.ObtenerConexion();
            conn.Open();
            using var cmd = new MySqlCommand("UPDATE Candidatos SET Nombre = @nombre, ConvocatoriaId = @convocatoriaId WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@convocatoriaId", convocatoriaId);
            if (cmd.ExecuteNonQuery() == 0)
                throw new InvalidOperationException("No se encontró el candidato que deseas actualizar.");
            CargarCandidatos();
        }

        public static void EliminarCandidato(int id)
        {
            var conexion = new Conexion();
            using var conn = conexion.ObtenerConexion();
            conn.Open();
            using (var check = new MySqlCommand("SELECT COUNT(*) FROM Votos WHERE CandidatoId = @id", conn))
            {
                check.Parameters.AddWithValue("@id", id);
                if (Convert.ToInt32(check.ExecuteScalar()) > 0)
                    throw new InvalidOperationException("No se puede eliminar este candidato porque ya tiene votos registrados.");
            }
            using var cmd = new MySqlCommand("DELETE FROM Candidatos WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            if (cmd.ExecuteNonQuery() == 0)
                throw new InvalidOperationException("No se encontró el candidato que deseas eliminar.");
            CargarCandidatos();
        }

        public static void CambiarEstadoConvocatoria(int id, bool activa)
        {
            var conexion = new Conexion();
            using var conn = conexion.ObtenerConexion();
            conn.Open();
            using var cmd = new MySqlCommand("UPDATE Convocatorias SET Activa = @activa WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@activa", activa);
            if (cmd.ExecuteNonQuery() == 0)
                throw new InvalidOperationException("No se encontró la convocatoria seleccionada.");
            CargarConvocatorias();
        }

        public static bool YaVoto(string matricula, int convocatoriaId)
        {
            var conexion = new Conexion();
            using var conn = conexion.ObtenerConexion();
            conn.Open();
            using var cmd = new MySqlCommand("SELECT EXISTS(SELECT 1 FROM Votos WHERE MatriculaAlumno = @matricula AND ConvocatoriaId = @convocatoriaId)", conn);
            cmd.Parameters.AddWithValue("@matricula", matricula);
            cmd.Parameters.AddWithValue("@convocatoriaId", convocatoriaId);
            return Convert.ToInt32(cmd.ExecuteScalar()) == 1;
        }

        public static void GuardarVotos(IEnumerable<Voto> votos)
        {
            var conexion = new Conexion();
            using var conn = conexion.ObtenerConexion();
            conn.Open();
            using var transaction = conn.BeginTransaction();
            try
            {
                const string sql = @"INSERT INTO Votos
                    (MatriculaAlumno, Grupo, Carrera, CentroUniversitario, ConvocatoriaId, CandidatoId, CandidatoNoRegistrado, FechaHora)
                    VALUES (@matricula, @grupo, @carrera, @centro, @convocatoria, @candidatoId, @candidatoLibre, @fecha)";
                foreach (var voto in votos)
                {
                    using var cmd = new MySqlCommand(sql, conn, transaction);
                    cmd.Parameters.AddWithValue("@matricula", voto.MatriculaAlumno);
                    cmd.Parameters.AddWithValue("@grupo", voto.Grupo);
                    cmd.Parameters.AddWithValue("@carrera", voto.Carrera);
                    cmd.Parameters.AddWithValue("@centro", voto.CentroUniversitario);
                    cmd.Parameters.AddWithValue("@convocatoria", voto.ConvocatoriaId);
                    cmd.Parameters.AddWithValue("@candidatoId", voto.CandidatoId.HasValue ? voto.CandidatoId.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@candidatoLibre", string.IsNullOrWhiteSpace(voto.CandidatoNoRegistrado) ? DBNull.Value : voto.CandidatoNoRegistrado);
                    cmd.Parameters.AddWithValue("@fecha", voto.FechaHora);
                    cmd.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            CargarVotos();
        }
    }
}