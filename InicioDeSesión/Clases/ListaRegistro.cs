using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace InicioDeSesión.Clases
{
    public class ListaRegistro
    {
        public DataTable TabladeDatos { get; set; } = new DataTable();


        public int UltimoID { get; set; } = 0;

        public ListaRegistro()
        {

            TabladeDatos.TableName = "Apartado de Registro";
            TabladeDatos.Columns.Add("Id");
            TabladeDatos.Columns.Add("Usuarios");
            TabladeDatos.Columns.Add("Contraseñas");
            VerificaArchivo();

        }

        public void VerificaArchivo()
        {
            if (System.IO.File.Exists("Lista.xml"))
            {
                TabladeDatos.ReadXml("Lista.xml");
                UltimoID = 0;

                for (int fila = 0; fila < TabladeDatos.Rows.Count; fila++)
                {
                    if (Convert.ToInt32(TabladeDatos.Rows[fila]["Id"]) > UltimoID)
                    {

                        UltimoID = Convert.ToInt32(TabladeDatos.Rows[fila]["Id"]);

                    }
                }

            }

        }


        public void CargadeDatos(Registro registro)
        {
            if (registro.Id == 0)
            {
                UltimoID = UltimoID + 1;
                registro.Id = UltimoID;

                TabladeDatos.Rows.Add();
                int renglon = TabladeDatos.Rows.Count - 1;

                TabladeDatos.Rows[renglon]["Id"] = registro.Id;
                TabladeDatos.Rows[renglon]["Usuarios"] = registro.Usuario.ToString();
                TabladeDatos.Rows[renglon]["Contraseñas"] = registro.Contraseña.ToString();
                TabladeDatos.WriteXml("Lista.xml");
            }
            else
            {
                for (int fila = 0; fila < TabladeDatos.Rows.Count; fila = fila + 1)
                {
                    if (Convert.ToInt32(TabladeDatos.Rows[fila]["Id"]) == registro.Id)
                    {
                        TabladeDatos.Rows[fila]["Id"] = registro.Id;
                        TabladeDatos.Rows[fila]["Usuario"] = registro.Usuario;
                        TabladeDatos.Rows[fila]["Contraseña"] = registro.Contraseña;
                        TabladeDatos.WriteXml("Lista.xml");
                        break;
                    }
                }
            }
        }


      


        public Registro BuscarRegistro(int id)
        {




            //UltimoID = UltimoID - 1;

            //registro.Id = UltimoID;

            Registro registro = new Registro();

            for (int fila = 0; fila < TabladeDatos.Rows.Count; fila = fila + 1)
            {
                
                if (Convert.ToInt32(TabladeDatos.Rows[fila]["Id"]) == id)
                {
                    registro.Id = Convert.ToInt32(TabladeDatos.Rows[fila]["Id"]);
                    registro.Usuario = TabladeDatos.Rows[fila]["Usuarios"].ToString();
                    registro.Contraseña = TabladeDatos.Rows[fila]["Contraseñas"].ToString();
                    break;
                   
                }

            }

            return registro;
        }

        public bool BorrarFila(Registro registro)
        {
            bool respuesta = false;
            for (int fila = 0; fila < TabladeDatos.Rows.Count; fila++)
            {
                if (Convert.ToInt32(TabladeDatos.Rows[fila]["Id"]) == registro.Id)
                {
                    TabladeDatos.Rows[fila].Delete();
                    TabladeDatos.WriteXml("Lista.xml");
                    respuesta = true;
                    break;
                }
            }

            return respuesta;
        }



    }
}
     



   

