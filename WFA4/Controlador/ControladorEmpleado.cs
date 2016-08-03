using System.Data;

namespace WFA4
{
    public class ControladorEmpleado
    {        
        Modelo mod = new Modelo();        
        EntidadEmpleado entidad = new EntidadEmpleado();
        string sql;
        
        public DataTable leer()
        {
            sql = "SELECT "
                + "CEDULA AS Cedula,"
                + "NOMBRE AS Nombre,"
                + "APELLIDO AS Apellido ,"
                + "UBICACION AS Ubicacion ,"
                + "ID_SALARIO AS Salario "
                + " FROM "
                + "EMPLEADO";
            return mod.llenarDT(sql);
        }

        public DataTable buscar(int id)
        {
            sql = "SELECT "
                + "CEDULA AS Cedula,"
                + "NOMBRE AS Nombre,"
                + "APELLIDO AS Apellido ,"
                + "UBICACION AS Ubicacion ,"
                + "ID_SALARIO AS Salario "
                + " FROM "
                + "EMPLEADO"
                + " WHERE "
                + "CEDULA = " + id;
            return mod.llenarDT(sql);
        }

        public void insertar(EntidadEmpleado entidad)
        {
            sql = "INSERT INTO EMPLEADO ("
                + "CEDULA,"
                + "NOMBRE,"
                + "APELLIDO,"
                + "UBICACION,"
                + "ID_SALARIO"
                + ") VALUES ("
                + entidad.Cedula + ","
                + "'" + entidad.Nombre + "',"
                + "'" + entidad.Apellido + "',"
                + "'" + entidad.Ubicacion + "',"
                + " " + entidad.Id_Salario + " "                
                + ")";
            mod.ejecutarSQL(sql);
        }

        public void modificar(EntidadEmpleado entidad)
        {
            sql = "UPDATE EMPLEADO SET "
                + "NOMBRE ='" + entidad.Nombre + "',"
                + "APELLIDO = '" + entidad.Apellido + "',"
                + "UBICACION = '" + entidad.Ubicacion + "',"
                + "ID_SALARIO = " + entidad.Id_Salario + " "                 
                + " WHERE "
                + "CEDULA = " + entidad.Cedula;
                mod.ejecutarSQL(sql);
        }

        public void eliminar(int id)
        {
            sql = "DELETE EMPLEADO "
                + "WHERE "
                + "CEDULA = " + id;
            mod.ejecutarSQL(sql);
        }
    }
}
