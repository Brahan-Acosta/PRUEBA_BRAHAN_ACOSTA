using PRUEBA_BRAHAN_ACOSTA.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRUEBA_BRAHAN_ACOSTA.Controllers
{
    public class PacienteController : Controller
    {
        private static string conexion = ConfigurationManager.ConnectionStrings["cadena"].ToString();

        private static List<Paciente> _paciente = new List<Paciente>();

        // GET: Paciente
        public ActionResult Inicio()
        {
            using (SqlConnection _coon = new SqlConnection(conexion))
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
                    return View(_paciente);
                }
                catch (Exception ex)
                {
                    return View(_paciente);
                }
                
            }
            
        }
    }
}