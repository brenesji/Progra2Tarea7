using System.Data;

namespace WFA4
{
    public class ControladorSalario
    {
        Modelo mod = new Modelo();
        EntidadSalario entidad = new EntidadSalario();
        string sql;

        public DataTable leer() 
        {
            sql = "SELECT * from Salario;";
            return mod.llenarDT(sql);
        }

    }
}
