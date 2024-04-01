using System;
using System.Collections.Generic;
//Importamos LINQ
using System.Linq;

namespace uso_linq
{
    class Program
    {
        static void Main(string[]args) 
        {
            controlEmpresaEmpleado ce = new controlEmpresaEmpleado();
            ce.getCargo();
        }
     }


    class controlEmpresaEmpleado
    {
        public controlEmpresaEmpleado()
        {
            listaEmpresas = new List<Empresa>();
            listaEmpleados = new List<Empleado>();

            //Instanciar objetos Empresa
            listaEmpresas.Add(new Empresa { Id = 1, Nombre = "Google" });
            listaEmpresas.Add(new Empresa { Id = 2, Nombre = "Oracle" });
            //Instanciar objetos Empleados
            listaEmpleados.Add(new Empleado { Id = 1, Nombre = "Deniss", Cargo = "FOX", IdEmpresa= 1, Salario = 2400});
            listaEmpleados.Add(new Empleado { Id = 2, Nombre = "Gansey", Cargo = "FOX", IdEmpresa = 1, Salario = 2400 });
            listaEmpleados.Add(new Empleado { Id = 3, Nombre = "Jenessy", Cargo = "RER", IdEmpresa = 2, Salario = 2500 });
            listaEmpleados.Add(new Empleado { Id = 4, Nombre = "Mattew", Cargo = "CO-RER", IdEmpresa = 2, Salario = 2400 });


        }

        public void getCargo()
        {
            IEnumerable<Empleado> cargo = from empleado in listaEmpleados where empleado.Cargo == "FOX" select empleado;
            foreach (Empleado empleado1 in cargo)
            {
                empleado1.showDatosEmpleado();
            }
        }

        public List<Empresa> listaEmpresas;
        public List<Empleado> listaEmpleados;
    }

    class Empresa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public void showDatosEmpresa()
        {
            Console.WriteLine("Empresa{0}con Id{1}", Nombre, Id);
        }
    }

    class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }
        public int IdEmpresa { get; set; }
        public void showDatosEmpleado()
        {
            Console.WriteLine("Empleado{0} con Id{1}, cargo{2} con salario{3}, pertenece a la empresa{4}", Nombre, Id,Cargo, Salario, IdEmpresa);
        }
    }
}
