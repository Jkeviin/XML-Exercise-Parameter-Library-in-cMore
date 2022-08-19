using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibParametro;

namespace AppLeerXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            ClsParametro ObjP = new ClsParametro();

            if (ObjP.CrearConexion())
            {
                txtCadena.Text = ObjP.CadenaConexion;
                return;
            }
            else
            {
                txtCadena.Text = ObjP.Error;
                return;
            }
        }
    }
}
