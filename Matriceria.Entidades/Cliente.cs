using System;

namespace Matriceria.Entidades
{
    public class Cliente
    {
        private int idCliente;
        private string razon_social;
        private int cuit;
        private string telefono;
        private string domicilio;

        // Propiedad para IdCliente, que se corresponde con la columna id_cliente en SQL
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        // Propiedad para Razon_Social, que se corresponde con la columna razon_social en SQL
        public string RazonSocial  // Cambiado a PascalCase por convención en C#
        {
            get { return razon_social; }
            set { razon_social = value; }
        }

        // Propiedad para CUIT, que se corresponde con la columna cuit en SQL
        public int CUIT
        {
            get { return cuit; }
            set { cuit = value; }
        }

        // Propiedad para Telefono, que se corresponde con la columna telefono en SQL
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        // Propiedad para Domicilio, que se corresponde con la columna domicilio en SQL
        public string Domicilio
        {
            get { return domicilio; }
            set { domicilio = value; }
        }

        // Constructor por defecto
    
        // Constructor con parámetros
        public Cliente(string razonSocial, int cuit, string telefono, string domicilio)
        {
            this.idCliente = IdCliente;  // Genera automáticamente un nuevo GUID
            this.razon_social = razonSocial;
            this.cuit = cuit;
            this.telefono = telefono;
            this.domicilio = domicilio;
        }

        public Cliente() { }
    }

}