using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Usar:
using System.Windows.Forms;
using System.Web.UI.WebControls;
using LibConexionBD;


namespace LibLlenarGrids
{
    public class ClsLLenarGrids
    {
        #region"Constructor"
            public ClsLLenarGrids()
            {
                strNombreTabla = "";
                strSQL = "";
                strError = "";
            }
        #endregion


        #region"Atributos"
            private string strNombreTabla;
            private string strSQL;
            private string strError;
        #endregion


        #region"Propiedades"
            public string NombreTabla
            {
                get { return strNombreTabla; }
                set { strNombreTabla = value; }
            }
            public string SQL
            {
                get { return strSQL; }
                set { strSQL = value; }
            }
            public string ERROR
            {
                get { return strError; }
            }
        #endregion


        #region "Metodos Publicos"
            public bool LlenarGridWeb(System.Web.UI.WebControls.GridView grdGenerico)
            {
                if (strSQL == "")
                {
                    strError = "Debe definir una instruccion SQL";
                    return false;
                }
                ClsConexion objConexionBD = new ClsConexion();
                if (strNombreTabla == "")
                { 
                    strNombreTabla = "DatosGridWeb"; 
                }
                if (objConexionBD.LlenarDataSet(strNombreTabla, strSQL, false))
                {
                    grdGenerico.DataSource = objConexionBD.DataSet_Retornado.Tables[strNombreTabla];
                    grdGenerico.DataBind();
                    objConexionBD.CerrarConexion();
                    objConexionBD = null;
                    return true;
                }
                else
                {
                    strError = objConexionBD.Error;
                    objConexionBD.CerrarConexion();
                    objConexionBD = null;
                    return false;
                }
            }



            public bool LlenarGrid(DataGridView grdGenerico)
            {
                if (strSQL == "")
                { 
                    strError = "Debe definir una instruccion SQL"; 
                }

                ClsConexion objConexionBD = new ClsConexion();
                if (strNombreTabla == "")
                { 
                    strNombreTabla = "LlenarGrid"; 
                }

                if (objConexionBD.LlenarDataSet(strNombreTabla, strSQL, true))
                {
                    grdGenerico.DataSource = objConexionBD.DataSet_Retornado.Tables[strNombreTabla];
                    objConexionBD.CerrarConexion();
                    objConexionBD = null;
                    return true;
                }
                else
                {
                    strError = objConexionBD.Error;
                    objConexionBD.CerrarConexion();
                    objConexionBD = null;
                    return false;
                }
            }
        #endregion
    }
}
      
     