using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Poleo.Objects;
using Poleo.BLL;
using System.Web.Mvc;

namespace Poleo
{
    [Authorize]
    public partial class EncuestaSalida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void cmdSummit_Click(object sender, EventArgs e)
        {
            string pr1 = ASPL1Hidden.Value;
            string pr2=ASPL2.Value;
            string pr3=ASPL3.Value;
            string pr4 = MOL1Hidden.Value;
            string pr5 = MOL2.Value;
            string pr6 = MOL3.Value;

            EncuestaHeader encuestaHeader = new EncuestaHeader();
            if (verificaheader()==true)
            {
                if (verificainsert() == true)
                {
                    encuestaHeader = insertheader();

                    if (string.IsNullOrEmpty(ASPL1Hidden.Value) != true && ASPL2.SelectedIndex != 0 && ASPL3.SelectedIndex != 0)
                    {
                        Encuesta_ASPECTOLABORAL(encuestaHeader);
                    }
                    if (string.IsNullOrEmpty(MOL1Hidden.Value) != true && MOL2.SelectedIndex != 0 && MOL3.SelectedIndex != 0)
                    {
                        Encuesta_OportunidadLaboral(encuestaHeader);
                    }
                    if (MPF.SelectedIndex != 0)
                    {
                        Encuesta_MOTIVOSPERSONALES_FAMILIARES(encuestaHeader);
                    }
                    if (EIP.SelectedIndex != 0)
                    {
                        Encuesta_ESTUDIOS_U_OTROS_INTERESES_PROFESIONALES(encuestaHeader);
                    }
                    if (verificaencuestafooter() == true)
                    {
                        EncuestaFooter(encuestaHeader);
                    }
                    clearcampos();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError",
           "alert('Favor de verificar los campos personales esten completos);", true);
            }
        }

        public bool verificainsert()
        {
            bool insert=false;
            if(verificaencuestafooter()==true)
            {
                insert=true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError",
                    "alert('Favor de verificar que los datos esten completos');", true);
            }
            return insert;
        }
        public bool verificaencuestafooter()
        {
            bool contestada = false;
            if(TxtP3.Value != "" && TxtP4.Value != "" && TxtP5.Value != "" && TxtP6.Value != "" && TxtP7.Value != ""
            && TxtP8.Value != "" && TxtP9.Value != "" && TxtP10.Value != "" && TxtP11.Value != "" && TxtP12.Value != ""
            && TxtP13.Value != "" && TxtP14.Value != "" && this.Request.Form["Prg15"] != "" && this.Request.Form["Prg16"] != "" 
            && this.Request.Form["Prg17"] != "" && this.Request.Form["Prg18"] != "" && this.Request.Form["Prg19"] != "" 
            && this.Request.Form["Prg20"] != "" && this.Request.Form["Prg21"] != "" && TxtPrg23.Value != "" 
            && TxtPrg23.Value != "" && this.Request.Form["Prg24"] != "" && this.Request.Form["Prg25"] != ""
            && TxtOtroP15.Value!="" && TxtOtroP16.Value!="")
            {
                contestada = true;
            }
            return contestada;
        }
        public void EncuestaFooter(EncuestaHeader encuesta)
        {
            EncuestaBLL encuestaBLL = new EncuestaBLL();
            EncuestaFooter encuestafooter=new EncuestaFooter();
            encuestafooter.Pregunta1 = TxtP3.Value;
            encuestafooter.Pregunta2 = TxtP4.Value;
            encuestafooter.Pregunta3 = TxtP5.Value;
            encuestafooter.Pregunta4 = TxtP6.Value;
            encuestafooter.Pregunta5 = TxtP7.Value;
            encuestafooter.Pregunta6 = TxtP8.Value;
            encuestafooter.Pregunta7 = TxtP9.Value;
            encuestafooter.Pregunta8 = TxtP10.Value;
            encuestafooter.Pregunta9 = TxtP11.Value;
            encuestafooter.Pregunta10 = TxtP12.Value;
            encuestafooter.Pregunta11 = TxtP13.Value;
            encuestafooter.Pregunta12 = TxtP14.Value;
            encuestafooter.Pregunta13 = this.Request.Form["Prg15"];
            encuestafooter.Pregunta13Des = TxtOtroP15.Value;
            encuestafooter.Pregunta14 = this.Request.Form["Prg16"];
            encuestafooter.Pregunta14Des = TxtOtroP16.Value;
            encuestafooter.Pregunta15 = this.Request.Form["Prg17"];
            encuestafooter.Pregunta16 = this.Request.Form["Prg18"];
            encuestafooter.Pregunta17 = this.Request.Form["Prg19"];
            encuestafooter.Pregunta18 = this.Request.Form["Prg20"];
            encuestafooter.Pregunta19 = this.Request.Form["Prg21"];
            encuestafooter.Pregunta20 = TxtPrg22.Value;
            encuestafooter.Pregunta21 = TxtPrg23.Value;
            encuestafooter.Pregunta22 = this.Request.Form["Prg24"];
            encuestafooter.Pregunta23 = this.Request.Form["Prg25"];
            encuestafooter.IdEncuesta = encuesta.IdEncuesta;
            encuestaBLL.InsertEncuesta_Footer(encuestafooter);
        }
        public void Encuesta_ESTUDIOS_U_OTROS_INTERESES_PROFESIONALES(EncuestaHeader encuesta)
        {
            EncuestaBLL encuestaBLL=new EncuestaBLL();
            Encuesta_ESTUDIOS_U_OTROS_INTERESES_PROFESIONALES EstudiosProfesionales = new Encuesta_ESTUDIOS_U_OTROS_INTERESES_PROFESIONALES();
            EstudiosProfesionales.Razon1 = EIP.Value;
            if(EIP.Value.Equals("Otra")==true)
            {
                EstudiosProfesionales.Otro=TxtOtroEIP.Value;
            }
            EstudiosProfesionales.IdEncuesta = encuesta.IdEncuesta;
            encuestaBLL.InsertEncuesta_ESTUDIOS_U_OTROS_INTERESES_PROFESIONALES(EstudiosProfesionales);
        }
        public void Encuesta_MOTIVOSPERSONALES_FAMILIARES(EncuestaHeader encuesta)
        {
            EncuestaBLL encuestaBLL = new EncuestaBLL();
            Encuesta_FamiliaresPersonales familiaresPersonales=new  Encuesta_FamiliaresPersonales();
            familiaresPersonales.Razon1 = MPF.Value;
            if(MPF.Value.Equals("Otra")==true)
            {
                familiaresPersonales.Otro = TxtOtroMPF.Value;
            }
            familiaresPersonales.IdEncuesta = encuesta.IdEncuesta;
            encuestaBLL.InsertEncuesta_MOTIVOSPERSONALES_FAMILIARES(familiaresPersonales);
        }
        public void Encuesta_OportunidadLaboral(EncuestaHeader encuesta)
        {
            EncuestaBLL EncuestaBLL=new EncuestaBLL();
            Encuesta_OportunidadLaboral oportunidadLaboral=new Encuesta_OportunidadLaboral();
            oportunidadLaboral.Razon1 = MOL1Hidden.Value;
            oportunidadLaboral.Razon2 = MOL2.Value;
            oportunidadLaboral.Razon3 = MOL3.Value;
            if(MOL3.Value.Equals("Otra")==true || MOL2.Value.Equals("Otra") == true || MOL1Hidden.Value=="Otra") 
            {
                oportunidadLaboral.Otro = TxtOtroMOL.Value;
            }
            oportunidadLaboral.IdEncuesta = encuesta.IdEncuesta;
            EncuestaBLL.InsertEncuesta_OportunidadLaboral(oportunidadLaboral);
        }
        public void Encuesta_ASPECTOLABORAL(EncuestaHeader encuesta)
        {
            EncuestaBLL EncuestaBLL = new EncuestaBLL();
            Encuesta_ASPECTOLABORAL aspectolaboral=new Encuesta_ASPECTOLABORAL();
            aspectolaboral.Razon1 = ASPL1Hidden.Value;
            aspectolaboral.Razon2 = ASPL2.Value;
            aspectolaboral.Razon3 = ASPL3.Value;
            aspectolaboral.IdEncuesta = encuesta.IdEncuesta;
            EncuestaBLL.InsertAspectoLaboral(aspectolaboral);
        }
        public void clearcampos()
        {
            TxtMarca.Value = "";
            SMarca.Value = "";
            TxtPjefe.Value = "";
            TxtNombreJefe.Value = "";
            TxtPuesto.Value = "";
            TxtName.Value = "";
            TxtMotivo.Value = "";
            ASPL1.SelectedIndex = 0;
            ASPL2.SelectedIndex = 0;
            ASPL3.SelectedIndex = 0;
            ASPL1Hidden.Value = "";
            MOL1Hidden.Value = "";
            TxtOtroMOL.Value = "";
            MOL1.SelectedIndex = 0;
            MOL2.SelectedIndex = 0;
            MOL3.SelectedIndex = 0;
            MPF.SelectedIndex = 0;
            EIP.SelectedIndex = 0;
            TxtOtroEIP.Value = "";
        }
        public EncuestaHeader insertheader()
        {
            EncuestaBLL EncuestaBLL = new EncuestaBLL();
            EncuestaHeader HeaderEncuesta = new EncuestaHeader();
            DateTime fechaingreso = Convert.ToDateTime(DateStar.Value);
            DateTime fechasalida = Convert.ToDateTime(DateFinish.Value);
            HeaderEncuesta.FechaEncuesta = DateTime.Now;
            HeaderEncuesta.Ingreso = fechaingreso;
            HeaderEncuesta.Salida = fechasalida;
            HeaderEncuesta.Sucursal_Departamento = TxtMarca.Value;
            HeaderEncuesta.Marca = SMarca.Value;
            HeaderEncuesta.PuestoJefe = TxtPjefe.Value;
            HeaderEncuesta.NombreJefe = TxtNombreJefe.Value;
            HeaderEncuesta.Puesto = TxtPuesto.Value;
            HeaderEncuesta.Nombre = TxtName.Value;
            HeaderEncuesta.Razon=TxtMotivo.Value;
            EncuestaBLL.InsertHEaderEncuesta(HeaderEncuesta);
            return EncuestaBLL.SearchEncuesta(HeaderEncuesta);
        }
        public bool verificaheader()
        {
            bool insert = false;
            if (string.IsNullOrEmpty(DateStar.Value)!=true && string.IsNullOrEmpty(DateFinish.Value)!= true && string.IsNullOrEmpty(TxtMarca.Value)!= true &&
                string.IsNullOrEmpty(SMarca.Value)!= true && string.IsNullOrEmpty(TxtPjefe.Value)!= true && string.IsNullOrEmpty(TxtNombreJefe.Value)!= true &&
                string.IsNullOrEmpty(TxtPuesto.Value)!= true && string.IsNullOrEmpty(TxtName.Value)!= true && string.IsNullOrEmpty(TxtMotivo.Value)!=true)
            {
                insert = true;
            }
            return insert;
        }
    }
}