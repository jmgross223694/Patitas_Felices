﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Sexo_MascotaDB
    {
        private ConexionDB conexionDB = new ConexionDB();

        public List<Sexo_Mascota> ListarActivos()
        {
            try
            {
                List<Sexo_Mascota> lista = new List<Sexo_Mascota>();
                string consulta = "select * from Pet_Sexes where _State = 1";
                conexionDB.EjecutarConsulta(consulta);
                while (conexionDB.Lector.Read())
                {
                    Sexo_Mascota sexo = new Sexo_Mascota();
                    sexo.ID = Convert.ToInt64(conexionDB.Lector["_ID"]);
                    sexo.Descripcion = conexionDB.Lector["_Description"].ToString();
                    sexo.Estado = true;
                    lista.Add(sexo);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexionDB.CerrarConexion();
            }
        }
    }
}
