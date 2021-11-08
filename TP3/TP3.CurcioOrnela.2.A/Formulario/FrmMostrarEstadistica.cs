﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades; 

namespace Formulario
{
    public partial class FrmMostrarEstadistica : Form
    {
        List<Cirugia> cirugias;
        List<Paciente> pacientes;
        bool hayPacientes; 
        public FrmMostrarEstadistica()
        {
            InitializeComponent();
            cirugias = new List<Cirugia>();
            pacientes = new List<Paciente>();
        }
        public FrmMostrarEstadistica(EPatologia patologia) : this()
        {
            lblDescripcion.Text = $"Pacientes por {patologia}";
            foreach (Paciente item in Hospital.Pacientes)
            {
                if(item.Patologia.Contains(patologia))
                {
                    pacientes.Add(item);
                }
            }
            hayPacientes = true; 
        }
        public FrmMostrarEstadistica(bool esServicio):this()
        {
            lblDescripcion.Text = "Cirugias Totales";
            if (esServicio)
            {
                cirugias = Hospital.Cirugias;
            } 
        }
        public FrmMostrarEstadistica(bool esServicio, EPatologia patologia) : this()
        {
            if (esServicio)
            {
                lblDescripcion.Text = $"Cirugias de {patologia}";
                cirugias = Hospital.CirugiasXPatologia(patologia);
            }
        }
        public FrmMostrarEstadistica(bool esServicio, EProcedimiento procedimiento) : this()
        {
            lblDescripcion.Text = $"Cirugias de {procedimiento}";
            if (esServicio && Hospital.Cirugias.Count > 0)
            {
                cirugias = Hospital.CirugiasXProcedimiento(procedimiento);
            }
        }
        public FrmMostrarEstadistica(Cirujano cirujano) : this()
        {
            lblDescripcion.Text = $"Cirugias de {cirujano}";
            cirugias = Hospital.CirugiasXCirujano(cirujano);
        }
        public FrmMostrarEstadistica(Cirujano cirujano, EPatologia patologia) : this()
        {
            lblDescripcion.Text = $"Cirugias de {cirujano} de {patologia}";
            cirugias = Hospital.CirugiasXPatologiaYCirujano(patologia,cirujano);

        }
        public FrmMostrarEstadistica(Cirujano cirujano, EProcedimiento procedimiento) : this()
        {
            lblDescripcion.Text = $"Cirugias de {cirujano} de {procedimiento}";
            cirugias = Hospital.CirugiasXProcedimientoYCirujano(procedimiento, cirujano);
        }
        private void FrmMostrarEstadistica_Load(object sender, EventArgs e)
        {
            if (cirugias.Count > 0)
            {
                dataEstadistica.DataSource = null;
                dataEstadistica.DataSource = cirugias;
                dataEstadistica.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if(pacientes.Count>0)
            {
                dataEstadistica.DataSource = null;
                dataEstadistica.DataSource = pacientes;
            }
        }

        private void btnExportarAJson_Click(object sender, EventArgs e)
        {
            string ruta = SerializacionAJason.GenerarRuta(lblDescripcion.Text + ".json");
            if (hayPacientes)
            {
                SerializacionAJason.SerializarAJason(ruta, pacientes);
            }
            else
            {
                SerializacionAJason.SerializarAJason(ruta, cirugias);
            }

            MessageBox.Show("Archivo generado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnExportarAXml_Click(object sender, EventArgs e)
        {
            string ruta = SerializacionAJason.GenerarRuta(lblDescripcion.Text + ".xml");

            if (hayPacientes)
            {
                SerializacionAXml<List<Paciente>>.SerializarAXmlLista(ruta, pacientes);
            }
            else
            {
                SerializacionAXml<List<Cirugia>>.SerializarAXmlLista(ruta, cirugias);
            }
            MessageBox.Show("Archivo generado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }
    }
}
