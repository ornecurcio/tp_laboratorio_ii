﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades; 
namespace Formulario
{
    public partial class Form1 : Form
    {
        bool esMedico;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = "Servicio de Ortopedia y Traumatologia\nHospital UTN"; 
        }

        private void btnPaciente_Click(object sender, EventArgs e)
        {
            esMedico = false;
            FrmSubMenu subMenu = new FrmSubMenu(esMedico);
            subMenu.ShowDialog();
        }

        private void btnMenuCirujano_Click(object sender, EventArgs e)
        {
            esMedico = true;
            FrmSubMenu subMenu = new FrmSubMenu(esMedico);
            subMenu.ShowDialog();
        }

        private void btnVerListado_Click(object sender, EventArgs e)
        {
            FrmEstadistica estadistica = new FrmEstadistica(false, true);
            estadistica.ShowDialog();
        }

        private void btnEstadisticaHospital_Click(object sender, EventArgs e)
        {
            FrmEstadisticaHospital estadistica = new FrmEstadisticaHospital();

            estadistica.Show();
        }

        private void pacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            esMedico = false;
            FrmIngresoDatos ingresoDatos = new FrmIngresoDatos(esMedico);
            ingresoDatos.ShowDialog();
        }

        private void cirujanoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            esMedico = true;
            FrmIngresoDatos ingresoDatos = new FrmIngresoDatos(esMedico);
            ingresoDatos.ShowDialog();
        }

        private void btnQuirofano_Click(object sender, EventArgs e)
        {
            FrmQuirofano quirofano = new FrmQuirofano();
            quirofano.Show(); 
        }
    }
}
