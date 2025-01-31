﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cirujano:Persona 
    {
        #region Atributos
        private ERol rol;

        #endregion

        #region Constructores
        public Cirujano():this("", "", 0, 0, ERol.Cirujano)
        {
        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="nombre"> nombre del cirujano</param>
        /// <param name="apellido">apellido del cirujano</param>
        /// <param name="dni">dni del cirujano</param>
        /// <param name="rol">rol del cirujano</param>
        /// <param name="estadistica">estadistica propia del cirujano</param>
        public Cirujano(string nombre, string apellido, double dni, int edad, ERol rol)
                       : base(nombre, apellido, dni, edad)
        {
            this.rol = rol;
        }
        #endregion

        #region Propiedades
        public ERol Rol
        {
            get
            {
                return this.rol;
            }
            set
            {
                this.rol = value;
            }
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga de == ompara si dos cirujanos son iguales por DNI y rol
        /// </summary>
        /// <param name="a">cirujano</param>
        /// <param name="b">cirujano</param>
        /// <returns></returns>
        public static bool operator ==(Cirujano a, Cirujano b)
        {
            if(a is null && b is null)
            {
                return true; 
            }
            else if (a is not null && b is not null && a.Dni == b.Dni && a.Rol==b.Rol)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Cirujano a, Cirujano b)
        {
            return !(a == b);
        }
        /// <summary>
        /// Sobrecarga de metodo ToStrig
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Apellido + ", " + this.Nombre + ". " + this.Rol;
        }
        #endregion
    }
}
