
namespace WFA4
{
    public class EntidadSalario
    {
        private int id_salario;
        private string dsc_salario;
        private float monto;

        public int Id_Salario
        {
            get { return id_salario; }
            set { id_salario = value; }
        }

        public string Dsc_Salario
        {
            get { return dsc_salario; }
            set { dsc_salario = value; }
        }

        public float Monto
        {
            get { return monto; }
            set { monto = value; }
        }

        public EntidadSalario() {
            id_salario = int.MinValue;
            dsc_salario = string.Empty;
            monto = float.MinValue;
        }
    }
}
