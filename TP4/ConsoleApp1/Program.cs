﻿using System;
using Entidades;
using System.Collections.Generic; 

namespace ConsolaTP3
{
    class Program
    {
        static void Main(string[] args)
        {

            AccesoDatos datos = new AccesoDatos();
            List<Paciente> pacientes = Hospital.Pacientes;

            List<Cirujano> cirujanos = datos.ObtenerListaCirujanos();
            List<Cirugia> cirugias = datos.ObtenerListaCirugias();

            List<EPatologia> patologias = new List<EPatologia>();
            patologias.Add(EPatologia.Pelvis);
            // Instancio un paciente
            Paciente p1 = new Paciente("Camila", "Guerrero", 34707689, 35, patologias);
            Console.WriteLine(p1);
            //Instancio un cirujano
            Cirujano c1 = new Cirujano("Ornela", "Curcio", 34707599, 31, ERol.Cirujano);
            Console.WriteLine(c1);
            //Instancio una cirugia
            Cirugia ciru1 = new Cirugia(p1, DateTime.Now, c1, EPatologia.Pelvis, EProcedimiento.Osteotomia);

            //El cirujano ya esta en la lista de cirujanos del hospital retornara false
            if (!Hospital.CargarCirujanos(c1))
            {
                Console.WriteLine("El metodo cargar cirujano funciona corretamente");
            }
            //El paciente ya esta en la lista de cirujanos del hospital retornara false
            if (!Hospital.CargarPacientes(p1))
            {
                Console.WriteLine("El metodo cargar paciente funciona corretamente");
            }
            // Se carga la cirugia va a aparecer repetida porque la misma cirugia puede ocurrir mas de una vez en el mismo paciente
            if (Hospital.CargarCirugiaPendiente(ciru1))
            {
                Console.WriteLine("El metodo cargar cirugia funciona corretamente");
            }
            // Agrego una nueva patologia a la lista de patologia
            // si el paciente existe, actualiza la lista de patologias del paciente
            if (Hospital.ActualizarPacientePatologia(p1, EPatologia.MiembroSuperior))
            {
                Console.WriteLine("El metodo actualizar paciente funciona corretamente");
            }

        }
    }
}
