using PRUEBA_BRAHAN_ACOSTA.Models;
using System.Data;
using System.Data.SqlClient;

namespace PRUEBA_BRAHAN_ACOSTA.Data
{
    public class PacientesData
    {
        #region CREAR PACIENTE

        public static bool crearPaciente(Paciente _paciente)
        {
            using (SqlConnection _coon = new SqlConnection(Conexion.ConexionName))
            {
                SqlCommand cmd = new SqlCommand("SP_NUEVO_PACIENTE", _coon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@XTIPO_DOCUMENTO", _paciente.TIPO_DOCUMENTO);
                cmd.Parameters.AddWithValue("@XNUMERO_DOCUMENTO", _paciente.NUMERO_DOCUMENTO);
                cmd.Parameters.AddWithValue("@XNOMBRE", _paciente.NOMBRE);
                cmd.Parameters.AddWithValue("@XAPELLIDOS", _paciente.APELLIDOS);
                cmd.Parameters.AddWithValue("@XCORREO_ELECTRONICO", _paciente.CORREO_ELECTRONICO);
                cmd.Parameters.AddWithValue("@XTELEFONO", _paciente.TELEFONO);
                cmd.Parameters.AddWithValue("@XFECHA_NACIMIENTO", _paciente.FECHA_NACIMIENTO);
                cmd.Parameters.AddWithValue("@XESTADO_AFILIACION", _paciente.ESTADO_AFILIACION);

                try
                {
                    _coon.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        #endregion

        #region ACTUALIZAR PACIENTE

        public static bool actualizarPaciente(Paciente _paciente)
        {
            using (SqlConnection _coon = new SqlConnection(Conexion.ConexionName))
            {
                SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_PACIENTE", _coon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@XID", _paciente.ID);
                cmd.Parameters.AddWithValue("@XTIPO_DOCUMENTO", _paciente.TIPO_DOCUMENTO);
                cmd.Parameters.AddWithValue("@XNUMERO_DOCUMENTO", _paciente.NUMERO_DOCUMENTO);
                cmd.Parameters.AddWithValue("@XNOMBRE", _paciente.NOMBRE);
                cmd.Parameters.AddWithValue("@XAPELLIDOS", _paciente.APELLIDOS);
                cmd.Parameters.AddWithValue("@XCORREO_ELECTRONICO", _paciente.CORREO_ELECTRONICO);
                cmd.Parameters.AddWithValue("@XTELEFONO", _paciente.TELEFONO);
                cmd.Parameters.AddWithValue("@XFECHA_NACIMIENTO", _paciente.FECHA_NACIMIENTO);
                cmd.Parameters.AddWithValue("@XESTADO_AFILIACION", _paciente.ESTADO_AFILIACION);

                try
                {
                    _coon.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        #endregion

        #region CONSULTAR PACIENTES
        public static List<Paciente> listarPaciente()
        {
            List<Paciente> _paciente = new List<Paciente>();
            using (SqlConnection _coon = new SqlConnection(Conexion.ConexionName))
            {
                SqlCommand cmd = new SqlCommand("SP_CONSULTAR_PACIENTE", _coon);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    _coon.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _paciente.Add(new Paciente()
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                TIPO_DOCUMENTO = (reader["TIPO_DOCUMENTO"]).ToString(),
                                NUMERO_DOCUMENTO = Convert.ToInt32(reader["NUMERO_DOCUMENTO"]),
                                NOMBRE = (reader["NOMBRE"]).ToString(),
                                APELLIDOS = (reader["APELLIDOS"]).ToString(),
                                CORREO_ELECTRONICO = (reader["CORREO_ELECTRONICO"]).ToString(),
                                TELEFONO = Convert.ToInt32(reader["TELEFONO"]),
                                FECHA_NACIMIENTO = Convert.ToDateTime(reader["FECHA_NACIMIENTO"]),
                                ESTADO_AFILIACION = (reader["ESTADO_AFILIACION"]).ToString(),
                            });
                        }
                    }
                    return _paciente;
                }
                catch (Exception ex)
                {
                    return _paciente;
                }
            }
        }

        #endregion

        #region CONSULTAR PACIENTE POR ID
        public static Paciente listarPacienteId(int ID)
        {
            Paciente _paciente = new Paciente();
            using (SqlConnection _coon = new SqlConnection(Conexion.ConexionName))
            {
                SqlCommand cmd = new SqlCommand("SP_BUSCAR_ID_PACIENTE", _coon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@XID", ID);
                try
                {
                    _coon.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _paciente = (new Paciente()
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                TIPO_DOCUMENTO = (reader["TIPO_DOCUMENTO"]).ToString(),
                                NUMERO_DOCUMENTO = Convert.ToInt32(reader["NUMERO_DOCUMENTO"]),
                                NOMBRE = (reader["NOMBRE"]).ToString(),
                                APELLIDOS = (reader["APELLIDOS"]).ToString(),
                                CORREO_ELECTRONICO = (reader["CORREO_ELECTRONICO"]).ToString(),
                                TELEFONO = Convert.ToInt32(reader["TELEFONO"]),
                                FECHA_NACIMIENTO = Convert.ToDateTime(reader["FECHA_NACIMIENTO"]),
                                ESTADO_AFILIACION = (reader["ESTADO_AFILIACION"]).ToString(),
                            });
                        }
                    }
                    return _paciente;
                }
                catch (Exception ex)
                {
                    return _paciente;
                }
            }
        }

        #endregion

        #region ELIMINAR PACIENTE
        public static bool eliminarPaciente(int ID)
        {
            using (SqlConnection _conn = new SqlConnection(Conexion.ConexionName))
            {
                SqlCommand cmd = new SqlCommand("SP_ELIMINAR_PACIENTE", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@XID", ID);

                try
                {
                    _conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        #endregion
    }
}
