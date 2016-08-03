
namespace WFA4
{
    public class EntidadEmpleado
    {
        private int cedula;
        private string nombre;
        private string apellido;
        private string ubicacion;
        private int id_salario;

        public int Cedula
        {
            get
            {
                return cedula;
            }
            set 
            {
                cedula = value;
            }            
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }
            set
            {
                apellido = value;
            }
        }

        public string Ubicacion
        {
            get
            {
                return ubicacion;
            }
            set
            {
                ubicacion = value;
            }
        }

        public int Id_Salario
        {
            get
            {
                return id_salario;
            }
            set
            {
                id_salario = value;
            }
        }

        public EntidadEmpleado()
        {
            cedula = int.MinValue;
            nombre = string.Empty;
            apellido = string.Empty;
            ubicacion = string.Empty;
            id_salario = int.MinValue;
        }
    }

}
