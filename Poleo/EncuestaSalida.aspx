<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncuestaSalida.aspx.cs" Inherits="Poleo.EncuestaSalida" %>
<link href="../Content/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('.forgot-pass').click(function (event) {
                $(".pr-wrap").toggleClass("show-pass-reset");
            });

            $('.pass-reset-submit').click(function (event) {
                $(".pr-wrap").removeClass("show-pass-reset");
            });
        });
        function activeall()
        {
            var arraySelects = document.getElementsByClassName('ASPL2');
            var arraySelects1 = document.getElementsByClassName('ASPL1');
            var arraySelects2 = document.getElementsByClassName('ASPL3');
            arraySelects[0].options[1].disabled = false;
            arraySelects[0].options[2].disabled = false;
            arraySelects[0].options[3].disabled = false;
            arraySelects[0].options[4].disabled = false;
            arraySelects[0].options[5].disabled = false;
            arraySelects[0].options[6].disabled = false;
            arraySelects[0].options[7].disabled = false;
            arraySelects[0].options[8].disabled = false;
            arraySelects[0].options[9].disabled = false;
            arraySelects[0].options[10].disabled = false;
            arraySelects[0].options[11].disabled = false;
            arraySelects[0].options[12].disabled = false;
            arraySelects[0].options[13].disabled = false;
            arraySelects1[0].options[1].disabled = false;
            arraySelects1[0].options[2].disabled = false;
            arraySelects1[0].options[3].disabled = false;
            arraySelects1[0].options[4].disabled = false;
            arraySelects1[0].options[5].disabled = false;
            arraySelects1[0].options[6].disabled = false;
            arraySelects1[0].options[7].disabled = false;
            arraySelects1[0].options[8].disabled = false;
            arraySelects1[0].options[9].disabled = false;
            arraySelects1[0].options[10].disabled = false;
            arraySelects1[0].options[11].disabled = false;
            arraySelects1[0].options[12].disabled = false;
            arraySelects1[0].options[13].disabled = false;
            arraySelects2[0].options[1].disabled = false;
            arraySelects2[0].options[2].disabled = false;
            arraySelects2[0].options[3].disabled = false;
            arraySelects2[0].options[4].disabled = false;
            arraySelects2[0].options[5].disabled = false;
            arraySelects2[0].options[6].disabled = false;
            arraySelects2[0].options[7].disabled = false;
            arraySelects2[0].options[8].disabled = false;
            arraySelects2[0].options[9].disabled = false;
            arraySelects2[0].options[10].disabled = false;
            arraySelects2[0].options[11].disabled = false;
            arraySelects2[0].options[12].disabled = false;
            arraySelects2[0].options[13].disabled = false;
        }

        function activeallMOL() {
            var arraySelects = document.getElementsByClassName('MOL1');
            var arraySelects1 = document.getElementsByClassName('MOL2');
            var arraySelects2 = document.getElementsByClassName('MOL3');
            arraySelects[0].options[1].disabled = false;
            arraySelects[0].options[2].disabled = false;
            arraySelects[0].options[3].disabled = false;
            arraySelects[0].options[4].disabled = false;
            arraySelects[0].options[5].disabled = false;
            arraySelects[0].options[6].disabled = false;
            arraySelects[0].options[7].disabled = false;
            arraySelects[0].options[8].disabled = false;
            
            arraySelects1[0].options[1].disabled = false;
            arraySelects1[0].options[2].disabled = false;
            arraySelects1[0].options[3].disabled = false;
            arraySelects1[0].options[4].disabled = false;
            arraySelects1[0].options[5].disabled = false;
            arraySelects1[0].options[6].disabled = false;
            arraySelects1[0].options[7].disabled = false;
            arraySelects1[0].options[8].disabled = false;
            
            arraySelects2[0].options[1].disabled = false;
            arraySelects2[0].options[2].disabled = false;
            arraySelects2[0].options[3].disabled = false;
            arraySelects2[0].options[4].disabled = false;
            arraySelects2[0].options[5].disabled = false;
            arraySelects2[0].options[6].disabled = false;
            arraySelects2[0].options[7].disabled = false;
            arraySelects2[0].options[8].disabled = false;
        }
        function check() {
            activeall();
            var select = ASPL1.selectedIndex;
            var aspl1 = document.getElementById("ASPL1Hidden");
            aspl1.value = ASPL1.value;
            var arraySelects = document.getElementsByClassName('ASPL2');
            var arraySelects2 = document.getElementsByClassName('ASPL3');
            arraySelects[0].options[select].disabled = true;
            arraySelects2[0].options[select].disabled = true;
        }
        function checkMOL() {
            activeallMOL();
            var prd = document.getElementById("TROtroMOL")
            var select = MOL1.selectedIndex;
            var select2 = MOL2.selectedIndex;
            var select3 = MOL3.selectedIndex;
            var mol1 = document.getElementById("MOL1Hidden");
            mol1.value=MOL1.value;
            var arraySelects = document.getElementsByClassName('MOL2');
            var arraySelects2 = document.getElementsByClassName('MOL3');
            arraySelects[0].options[select].disabled = true;
            arraySelects2[0].options[select].disabled = true;
            if (select == 8 || select2 == 8 || select3 == 8) {
                prd.style.display = "contents"
            }
            else {
                prd.style.display = "none"
            }
        }
        function check2() {
            activeall();
            var select = ASPL2.selectedIndex;
            var select1 = ASPL1.selectedIndex;
            var arraySelects = document.getElementsByClassName('ASPL1');
            var arraySelects2 = document.getElementsByClassName('ASPL3');
            arraySelects[0].options[select].disabled = true;
            arraySelects[0].options[select1].disabled = true;
            arraySelects2[0].options[select].disabled = true;
            arraySelects2[0].options[select1].disabled = true;
        }
        function checkMOL2() {
            activeallMOL();
            var prd = document.getElementById("TROtroMOL")
            var select = MOL2.selectedIndex;
            var select1 = MOL1.selectedIndex;
            var select2 = MOL3.selectedIndex;
            var arraySelects = document.getElementsByClassName('MOL1');
            var arraySelects2 = document.getElementsByClassName('MOL3');
            arraySelects[0].options[select].disabled = true;
            arraySelects[0].options[select1].disabled = true;
            arraySelects2[0].options[select].disabled = true;
            arraySelects2[0].options[select1].disabled = true;
            if (select == 8 || select1 == 8 || select2 == 8) {
                prd.style.display = "contents"
            }
            else {
                prd.style.display = "none"
            }
        }
        function checkMOL3() {
            var select = MOL3.selectedIndex;
            var selec2 = MOL2.selectedIndex;
            var select3 = MOL1.selectedIndex;
            var prd = document.getElementById("TROtroMOL")
            if (select == 8 || selec2 == 8 || select3 == 8) {
                prd.style.display = "contents"
            }
            else {
                prd.style.display = "none"
            }
        }
        function checkMPF() {
            var select = MPF.selectedIndex;
            var prd = document.getElementById("TROtroMPF")
            if (select == 6) {
                prd.style.display = "contents"
            }
            else {
                prd.style.display = "none"
            }
        }
        function checkEIP() {
            var select = EIP.selectedIndex;
            var prd = document.getElementById("TROtroEIP")
            if (select == 5) {
                prd.style.display = "contents"
            }
            else {
                prd.style.display = "none"
            }
        }
    </script>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <style>
        body
        {
            background: url('../Content/Fondo11360.jpg') fixed;
            background-size: cover;
            padding: 0;
            margin: 0;
            font-
            /*font-family:"Helvetica Neue";*/
        }

        .wrap
        {
            width: 100%;
            height: 100%;
            min-height: 100%;
            position: absolute;
            top: 0;
            left: 0;
            z-index: 99;
        }

        p.form-title
        {
            font-family: 'Open Sans' , sans-serif;
            font-size: 20px;
            font-weight: 600;
            text-align: center;
            color: #FFFFFF;
            margin-top: 5%;
            text-transform: uppercase;
            letter-spacing: 4px;
        }

        form
        {
            width: 100%;
            margin: 0 auto;
        }

        form.login input[type="text"], form.login input[type="password"]
        {
            width: 100% !important;
            margin: 0 !important;
            padding: 5px 10px !important;
            background: 0 !important;
            border: 0 !important;
            border-bottom: 1px solid #FFFFFF !important;
            outline: 0 !important;
            font-style: italic !important;
            font-size: 12px !important;
            font-weight: 400 !important;
            letter-spacing: 1px !important;
            margin-bottom: 5px !important;
            color: #FFFFFF !important;
            outline: 0 !important;
        }

        form.login input[type="submit"]
        {
            width: 100%;
            font-size: 14px;
            text-transform: uppercase;
            font-weight: 500;
            margin-top: 16px;
            outline: 0;
            cursor: pointer;
            letter-spacing: 1px;
        }

        form.login input[type="submit"]:hover
        {
            transition: background-color 0.5s ease;
        }

        form.login .remember-forgot
        {
            float: left;
            width: 100%;
            margin: 10px 0 0 0;
        }
        form.login .forgot-pass-content
        {
            min-height: 20px;
            margin-top: 10px;
            margin-bottom: 10px;
        }
        form.login label, form.login a
        {
            font-size: 12px;
            font-weight: 400;
            color: #FFFFFF;
        }

        form.login a
        {
            transition: color 0.5s ease;
        }

        form.login a:hover
        {
            color: #2ecc71;
        }

        .pr-wrap
        {
            width: 100%;
            height: 100%;
            min-height: 100%;
            position: absolute;
            top: 0;
            left: 0;
            z-index: 999;
            display: none;
        }

        .show-pass-reset
        {
            display: block !important;
        }

        .pass-reset
        {
            margin: 0 auto;
            width: 250px;
            position: relative;
            margin-top: 22%;
            z-index: 999;
            background: #FFFFFF;
            padding: 20px 15px;
        }

        .pass-reset label
        {
            font-size: 12px;
            font-weight: 400;
            margin-bottom: 15px;
        }

        .pass-reset input[type="email"]
        {
            width: 100%;
            margin: 5px 0 0 0;
            padding: 5px 10px;
            background: 0;
            border: 0;
            border-bottom: 1px solid #000000;
            outline: 0;
            font-style: italic;
            font-size: 12px;
            font-weight: 400;
            letter-spacing: 1px;
            margin-bottom: 5px;
            color: #000000;
            outline: 0;
        }

        .pass-reset input[type="submit"]
        {
            width: 100%;
            border: 0;
            font-size: 14px;
            text-transform: uppercase;
            font-weight: 500;
            margin-top: 10px;
            outline: 0;
            cursor: pointer;
            letter-spacing: 1px;
        }

        .pass-reset input[type="submit"]:hover
        {
            transition: background-color 0.5s ease;
        }
        .posted-by
        {
            position: absolute;
            bottom: 26px;
            margin: 0 auto;
            color: #FFF;
            background-color: rgba(0, 0, 0, 0.66);
            padding: 10px;
            left: 45%;
        }
    </style>
     <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="pr-wrap">
                    <div class="pass-reset">
                        <label>
                            Enter the email you signed up with</label>
                        <input type="email" placeholder="Email" />
                        <input type="submit" value="Submit" class="pass-reset-submit btn btn-success btn-sm" />
                    </div>
                </div>
                <div class="wrap">
                    <p class="form-title">
                        Encuenta de Salida</p>
                    <form class="login" runat="server">
                        <div>
                            <div>
                                <p style="text-align:center">
                                    Gracias por tu tiempo invertido en este cuestionario y compartir tu experiencia en la empresa.
                                    Con tus comentarios queremos conocer porque los colaboradores deciden dejar de laborar con nosotros  para que de esta manera podamos mejorar continuamente.
                                </p>
                            </div>
                            <table style="width:100%">
                              <tr>
                                <td>
                                    <b > Nombre</b > 
                                    <br />
                                    <input type="text" placeholder="Respuesta" id="TxtName" runat="server" />
                                </td>
                                  <td ><p></p></td>
                                <td>
                                    <b > Fecha de ingreso</b > 
                                    <br />
                                    <input type="date" id="DateStar" name="trip-Start"
                                   min="1989-01-01" max="2054-12-31" runat="server">
                                </td>

                              </tr>
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                              <tr>
                                <td>
                                    <b > Puesto</b > 
                                    <br />
                                    <input type="text" placeholder="Respuesta" id="TxtPuesto" runat="server" />
                                </td>
                                  <td >
                                      <p></p>
                                  </td>
                                <td>
                                    <b > Fecha de Salida</b > 
                                    <br />
                                    <input type="date" id="DateFinish" name="trip-finish"
                                   min="1989-01-01" max="2054-12-31" runat="server">
                                </td>
                              </tr>
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr>
                                <td>
                                    <b > Nombre de Jefe Inmediato</b > 
                                    <br />
                                    <input type="text" placeholder="Respuesta" id="TxtNombreJefe" runat="server" />
                                </td>
                                  <td >
                                      <p style="visibility: hidden;" >celda</p>
                                  </td>
                                <td>
                                    <b > Marca</b > 
                                    <br />
                                    <div class="pregresp">
                                      <div class="Marca"<br />
                                      </div>
                                      <div class="Marca">
                                        <select id="SMarca" name="SMarca" runat="server">
                                          <option value="" disabled selected>Seleccione una Marca...</option>
                                          <option value="Domino's Pizza">Domino's Pizza</option>
                                          <option value="Dairy Queen" >Dairy Queen</option>
                                          <option value="Tony Roma's">Tony Roma's</option>
                                          <option value="Madapal" >Madapal</option>
                                        </select>
                                      </div>
                                </td>
                                    <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>

                                <tr>
                                <td>
                                    <b > Puesto de Jefe Inmediato</b > 
                                    <br />
                                    <input type="text" placeholder="Respuesta" id="TxtPjefe" runat="server" />
                                </td>
                                  <td >
                                      <p style="visibility: hidden;" >celda</p>
                                  </td>
                                <td>
                                    <b > Sucursal / Departamento</b > 
                                    <br />
                                    <div class="pregresp">
                                      <div class="Marca"<br />
                                      </div>
                                      <div class="Marca">
                                        <input type="text" placeholder="Respuesta" id="TxtMarca" runat="server" />
                                    </div>
                                </td>
                                    <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                              </tr>


                            </table>   
                            <table style="width:100%">
                                <tr>
                                <td>
                                    <b > ¿Cuál es tu principal motivo de salida?</b >
                                    <br />
                                    <textarea id="TxtMotivo" name="Motivo" rows="5" cols="40" style="width:100%" placeholder="Escribe aquí tus comentarios" runat="server"></textarea>
                                </td>

                              </tr>
                            </table>
                            <br />
                            <div>
                                <p style="text-align:left">
                                    Para conocer a detalle el MOTIVO DE TU SALIDA por favor elige entre LOS SIGUIENTES SEGMENTOS la que más aplique para ti: 
                                </p>
                                <b>ASPECTO LABORAL</b><br />
                                <b>MEJOR OPORTUNIDAD LABORAL</b><br />
                                <b>MOTIVOS PERSONALES y/o FAMILIARES</b><br />
                                <b>ESTUDIOS U OTRO INTERESES PROFESIONALES</b>
                            </div>
                            <br />
                            <div>
                                <p style="text-align:center">
                                    <b>ASPECTO LABORAL</b>
                                </p>
                            </div>
                            <div>
                                <p>Indica las<b> 3 razones principales</b>, CALIFICANDO CON  “1” la razón más importante, hasta  “3” la menos RELEVANTE.</p>
                            </div>
                            <table style="width:100%">
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr>
                                <td>
                                    <b >1</b >
                                    <input type="text" id="ASPL1Hidden" name="ASPL1Hidden" value=""  style="display:none;" runat="server"/>
                                    <select id="ASPL1" name="ASPL1" style="width: 97%;" class="ASPL1" onchange="check()" runat="server">
                                          <option value="" disabled selected>Seleccione una opción...</option>
                                          <option value="Cambiaron al Jefe del área">Cambiaron al Jefe del área</option>
                                          <option value="Cambio de lugar de trabajo (tienda /oficina)" >Cambio de lugar de trabajo (tienda /oficina)</option>
                                          <option value="Inversión de Tiempo  de llegar al trabajo y a mi casa">Inversión de Tiempo  de llegar al trabajo y a mi casa</option>
                                          <option value="No respetaron mis vacaciones">No respetaron mis vacaciones</option>
                                          <option value="Falta de oportunidades para crecer y desarrollarme en la compañía ">Falta de oportunidades para crecer y desarrollarme en la compañía </option>
                                          <option value="Falta de capacitación y entrenamiento en mi puesto">Falta de capacitación y entrenamiento en mi puesto</option>
                                          <option value="Falta de claridad en los objetivos de mi trabajo">Falta de claridad en los objetivos de mi trabajo</option>
                                          <option value="Falta de reconocimiento">Falta de reconocimiento</option>
                                          <option value="Incumplimiento al sueldo ofrecido en mi contratación">Incumplimiento al sueldo ofrecido en mi contratación</option>
                                          <option value="Incumplimiento de las funciones descritas en mi contratación">Incumplimiento de las funciones descritas en mi contratación</option>
                                          <option value="Incumplimiento en los horarios ofrecidos en mi contratación">Incumplimiento en los horarios ofrecidos en mi contratación</option>
                                          <option value="No respetaban mis días de descanso">No respetaban mis días de descanso</option>
                                          <option value="Falta de transporte">Falta de transporte</option>
                                        </select>
                                </td>
                              </tr>
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                              <tr>
                                <td>
                                    <b >2</b >
                                    <select id="ASPL2" name="ASPL2" style="width: 97%;" class="ASPL2" onchange="check2()" runat="server">
                                          <option value="" disabled selected>Seleccione una opción...</option>
                                          <option value="Cambiaron al Jefe del área">Cambiaron al Jefe del área</option>
                                          <option value="Cambio de lugar de trabajo (tienda /oficina)" >Cambio de lugar de trabajo (tienda /oficina)</option>
                                          <option value="Inversión de Tiempo  de llegar al trabajo y a mi casa">Inversión de Tiempo  de llegar al trabajo y a mi casa</option>
                                          <option value="No respetaron mis vacaciones">No respetaron mis vacaciones</option>
                                          <option value="Falta de oportunidades para crecer y desarrollarme en la compañía ">Falta de oportunidades para crecer y desarrollarme en la compañía </option>
                                          <option value="Falta de capacitación y entrenamiento en mi puesto">Falta de capacitación y entrenamiento en mi puesto</option>
                                          <option value="Falta de claridad en los objetivos de mi trabajo">Falta de claridad en los objetivos de mi trabajo</option>
                                          <option value="Falta de reconocimiento">Falta de reconocimiento</option>
                                          <option value="Incumplimiento al sueldo ofrecido en mi contratación">Incumplimiento al sueldo ofrecido en mi contratación</option>
                                          <option value="Incumplimiento de las funciones descritas en mi contratación">Incumplimiento de las funciones descritas en mi contratación</option>
                                          <option value="Incumplimiento en los horarios ofrecidos en mi contratación">Incumplimiento en los horarios ofrecidos en mi contratación</option>
                                          <option value="No respetaban mis días de descanso">No respetaban mis días de descanso</option>
                                          <option value="Falta de transporte">Falta de transporte</option>
                                        </select>
                                </td>
                              </tr>
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                              <tr>
                                <td>
                                    <b >3</b >
                                    <select id="ASPL3" name="ASPL3" style="width: 97%;" class="ASPL3" runat="server">
                                          <option value="" disabled selected>Seleccione una opción...</option>
                                          <option value="Cambiaron al Jefe del área">Cambiaron al Jefe del área</option>
                                          <option value="Cambio de lugar de trabajo (tienda /oficina)" >Cambio de lugar de trabajo (tienda /oficina)</option>
                                          <option value="Inversión de Tiempo  de llegar al trabajo y a mi casa">Inversión de Tiempo  de llegar al trabajo y a mi casa</option>
                                          <option value="No respetaron mis vacaciones">No respetaron mis vacaciones</option>
                                          <option value="Falta de oportunidades para crecer y desarrollarme en la compañía ">Falta de oportunidades para crecer y desarrollarme en la compañía </option>
                                          <option value="Falta de capacitación y entrenamiento en mi puesto">Falta de capacitación y entrenamiento en mi puesto</option>
                                          <option value="Falta de claridad en los objetivos de mi trabajo">Falta de claridad en los objetivos de mi trabajo</option>
                                          <option value="Falta de reconocimiento">Falta de reconocimiento</option>
                                          <option value="Incumplimiento al sueldo ofrecido en mi contratación">Incumplimiento al sueldo ofrecido en mi contratación</option>
                                          <option value="Incumplimiento de las funciones descritas en mi contratación">Incumplimiento de las funciones descritas en mi contratación</option>
                                          <option value="Incumplimiento en los horarios ofrecidos en mi contratación">Incumplimiento en los horarios ofrecidos en mi contratación</option>
                                          <option value="No respetaban mis días de descanso">No respetaban mis días de descanso</option>
                                          <option value="Falta de transporte">Falta de transporte</option>
                                        </select>
                                </td>
                              </tr>
                            </table>
                            <br />
                            <div>
                                <p style="text-align:center">
                                    <b>MEJOR OPORTUNIDAD LABORAL</b>
                                </p>
                            </div>
                            <div>
                                <p>Indica las<b> 3 razones principales</b>, CALIFICANDO CON  “1” la razón más importante, hasta  “3” la menos RELEVANTE.</p>
                            </div>
                            <table style="width:100%">
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr>
                                <td>
                                    <b >1</b >
                                    <input type="text" id="MOL1Hidden" name="MOL1Hidden" value=""  style="display:none;" runat="server"/>
                                    <select id="MOL1" name="MOL1" style="width: 97%;" class="MOL1" onchange="checkMOL()" runat="server">
                                          <option value="" disabled selected>Seleccione una opción...</option>
                                          <option value="Mejores oportunidades para crecer">Mejores oportunidades para crecer</option>
                                          <option value="Mejor entrenamiento/capacitación" >Mejor entrenamiento/capacitación</option>
                                          <option value="Mejora en la distancia a mi casa">Mejora en la distancia a mi casa</option>
                                          <option value="Mejor paquete de prestaciones">Mejor paquete de prestaciones</option>
                                          <option value="Mejor horario de trabajo">Mejor horario de trabajo</option>
                                          <option value="Más responsabilidad, autonomía o crecimiento dentro de la compañía">Más responsabilidad, autonomía o crecimiento dentro de la compañía</option>
                                          <option value="Ofrecen transporte">Ofrecen transporte</option>
                                          <option value="Otra">Otra</option>
                                        </select>
                                </td>
                              </tr>
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                              <tr>
                                <td>
                                    <b >2</b >
                                    <select id="MOL2" name="MOL2" style="width: 97%;" class="MOL2" onchange="checkMOL2()" runat="server">
                                          <option value="" disabled selected>Seleccione una opción...</option>
                                          <option value="Mejores oportunidades para crecer">Mejores oportunidades para crecer</option>
                                          <option value="Mejor entrenamiento/capacitación" >Mejor entrenamiento/capacitación</option>
                                          <option value="Mejora en la distancia a mi casa">Mejora en la distancia a mi casa</option>
                                          <option value="Mejor paquete de prestaciones">Mejor paquete de prestaciones</option>
                                          <option value="Mejor horario de trabajo">Mejor horario de trabajo</option>
                                          <option value="Más responsabilidad, autonomía o crecimiento dentro de la compañía">Más responsabilidad, autonomía o crecimiento dentro de la compañía</option>
                                          <option value="Ofrecen transporte">Ofrecen transporte</option>
                                          <option value="Otra">Otra</option>
                                        </select>
                                </td>
                              </tr>
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                              <tr>
                                <td>
                                    <b >3</b >
                                    <select id="MOL3" name="MOL3" style="width: 97%;" class="MOL3" onchange="checkMOL3()" runat="server">
                                          <option value="" disabled selected>Seleccione una opción...</option>
                                          <option value="Mejores oportunidades para crecer">Mejores oportunidades para crecer</option>
                                          <option value="Mejor entrenamiento/capacitación" >Mejor entrenamiento/capacitación</option>
                                          <option value="Mejora en la distancia a mi casa">Mejora en la distancia a mi casa</option>
                                          <option value="Mejor paquete de prestaciones">Mejor paquete de prestaciones</option>
                                          <option value="Mejor horario de trabajo">Mejor horario de trabajo</option>
                                          <option value="Más responsabilidad, autonomía o crecimiento dentro de la compañía">Más responsabilidad, autonomía o crecimiento dentro de la compañía</option>
                                          <option value="Ofrecen transporte">Ofrecen transporte</option>
                                          <option value="Otra">Otra</option>
                                        </select>
                                </td>
                              </tr>
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                            </table>
                            <table style="width:100%">
                                <tr id="TROtroMOL" style="display:none" >
                                <td>
                                    <b >Si alguna de las opciones fue otra, por favor especifica</b >
                                    <br />
                                    <textarea runat="server" id="TxtOtroMOL" name="OtroMOL" rows="5" cols="40" style="width:100%" placeholder="Escribe aquí tus comentarios"></textarea>
                                </td>
                              </tr>
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                            </table>

                            <%--Seccion de motivos personales y/o familiares--%>

                            <div>
                                <p style="text-align:center">
                                    <b>MOTIVOS PERSONALES y/o FAMILIARES</b>
                                </p>
                            </div>
                            <div>
                                <p>Selecciona la razón principal</p>
                            </div>
                            <table style="width:100%">
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr>
                                <td>
                                    <select id="MPF" name="MPF" style="width: 97%;" class="MPF" onchange="checkMPF()" runat="server">
                                          <option value="" disabled selected>Seleccione una opción...</option>
                                          <option value="Cambio de residencia">Cambio de residencia</option>
                                          <option value="Cuidado de niño(a)/cuidado de familiares/mayor atención a mi familia">Cuidado de niño(a)/cuidado de familiares/mayor atención a mi familia</option>
                                          <option value="Salud">Salud</option>
                                          <option value="Cambió mi estado civil">Cambió mi estado civil</option>
                                          <option value="Falta de permiso de mis padres">Falta de permiso de mis padres</option>
                                          <option value="Otra">Otra</option>
                                        </select>
                                </td>
                              </tr>
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                            </table>
                            <table style="width:100%">
                                <tr id="TROtroMPF" style="display:none">
                                <td>
                                    <b >Si tu seleccion fue otra, por favor especifica</b >
                                    <br />
                                    <textarea id="TxtOtroMPF" name="OtroMOL" rows="5" cols="40" style="width:100%" placeholder="Escribe aquí tus comentarios" runat="server"></textarea>
                                </td>
                              </tr>
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                            </table>
                        </div>

                        <%--ESTUDIOS U OTROS INTERESES PROFESIONALES--%>

                         <div>
                                <p style="text-align:center">
                                    <b>ESTUDIOS U OTROS INTERESES PROFESIONALES</b>
                                </p>
                            </div>
                            <div>
                                <p>Selecciona la razón principal</p>
                            </div>
                            <table style="width:100%">
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr>
                                <td>
                                    <select id="EIP" name="EIP" style="width: 97%;" class="EIP" onchange="checkEIP()" runat="server">
                                          <option value="" disabled selected>Seleccione una opción...</option>
                                          <option value="Retomé mis estudios">Retomé mis estudios</option>
                                          <option value="Terminé mis estudios (ej. Graduación de la Universidad).">Terminé mis estudios (ej. Graduación de la Universidad).</option>
                                          <option value="Inicie mis estudios">Inicie mis estudios</option>
                                          <option value="Incluí más materias para terminar prontol">Incluí más materias para terminar pronto</option>
                                          <option value="Otra">Otra</option>
                                        </select>
                                </td>
                              </tr>
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                            </table>
                            <table style="width:100%">
                                <tr id="TROtroEIP" style="display:none">
                                <td>
                                    <b >Si tu seleccion fue otra, por favor especifica</b >
                                    <br />
                                    <textarea id="TxtOtroEIP" name="OtroMOL" rows="5" cols="40" style="width:100%" placeholder="Escribe aquí tus comentarios" runat="server"></textarea>
                                </td>
                              </tr>
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                            </table>


                        <%--Cuestionario final--%>
                            <div>
                                <p>POR FAVOR CONTINÚA  CONTESTANDO EL CUESTIONARIO EN BASE A LO SIGUIENTE:</p>
                            </div>
                            <table style="width:100%">
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr >
                                    <td >
                                        <p style="text-align:left">
                                           <b>3.	¿Te dieron la bienvenida cuando ingresaste a la empresa/tienda?</b>
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                <td>
                                    <br />
                                    <input type="text" placeholder="Respuesta" id="TxtP3" runat="server" />
                                </td>
                              </tr>
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr >
                                    <td >
                                        <p style="text-align:left">
                                           <b>4.	¿Quién te dio la bienvenida y te mostro lo que tenías que hacer? Escribe su nombre</b>
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                <td>
                                    <br />
                                    <input type="text" placeholder="Respuesta" id="TxtP4" runat="server" />
                                </td>
                              </tr>
                              <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr >
                                    <td >
                                        <p style="text-align:left">
                                           <b>5.	¿Te capacitaron en tu puesto desde el primer día?</b>
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                <td>
                                    <br />
                                    <input type="text" placeholder="Respuesta" id="TxtP5" runat="server" />
                                </td>
                              </tr>
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr >
                                    <td >
                                        <p style="text-align:left">
                                           <b>6.	¿Te dieron  las reglas o políticas que debías acatar  día a día?</b>
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                <td>
                                    <br />
                                    <input type="text" placeholder="Respuesta" id="TxtP6" runat="server" />
                                </td>
                              </tr>

                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr >
                                    <td >
                                        <p style="text-align:left">
                                           <b>7.	¿Te dijeron tus objetivos?</b>
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                <td>
                                    <br />
                                    <input type="text" placeholder="Respuesta" id="TxtP7" runat="server" />
                                </td>
                              </tr>


                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr >
                                    <td >
                                        <p style="text-align:left">
                                           <b>8.	¿Tenías claras tus funciones y actividades, de ser así, menciona 2</b>
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                <td>
                                    <br />
                                    <input type="text" placeholder="Respuesta" id="TxtP8" runat="server" />
                                </td>
                              </tr>

                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr >
                                    <td >
                                        <p style="text-align:left">
                                           <b>9.	¿Tu horario de trabajo fue el que te mencionaron en la entrevista?</b>
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                <td>
                                    <br />
                                    <input type="text" placeholder="Respuesta" id="TxtP9" runat="server" />
                                </td>
                              </tr>

                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr >
                                    <td >
                                        <p style="text-align:left">
                                           <b>10.	En caso de haber cambiado ¿fue de común acuerdo?</b>
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                <td>
                                    <br />
                                    <input type="text" placeholder="Respuesta" id="TxtP10" runat="server" />
                                </td>
                              </tr>


                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr >
                                    <td >
                                        <p style="text-align:left">
                                           <b>11.	¿Te dieron retroalimentación sobre el avance de tus objetivos  y áreas de mejora?</b>
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                <td>
                                    <br />
                                    <input type="text" placeholder="Respuesta" id="TxtP11" runat="server" />
                                </td>
                              </tr>


                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr >
                                    <td >
                                        <p style="text-align:left">
                                           <b>12.	¿Si tenías dudas se te aclaraban oportunamente?</b>
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                <td>
                                    <br />
                                    <input type="text" placeholder="Respuesta" id="TxtP12" runat="server" />
                                </td>
                              </tr>


                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr >
                                    <td >
                                        <p style="text-align:left">
                                           <b>13.	¿Crees que en esta empresa tienes oportunidades de crecimiento?</b>
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                <td>
                                    <br />
                                    <input type="text" placeholder="Respuesta" id="TxtP13" runat="server" />
                                </td>
                              </tr>

                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr >
                                    <td >
                                        <p style="text-align:left">
                                           <b>14.	¿Conoces algún sistema de reconocimiento? De ser así menciónalo</b>
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                <td>
                                    <br />
                                    <input type="text" placeholder="Respuesta" id="TxtP14" runat="server" />
                                </td>
                              </tr>

                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr >
                                    <td >
                                        <div class="PregF15">
                                              <div class="pregunta"><b> 15.¿Cómo fue tu relación con tus compañeros de trabajo?</b>
                                              </div>
                                              <br />
                                              <div class="respuestas15">
                                                <input type="radio" name="Prg15" value="Mala" /> Mala<br />
                                                <input type="radio" name="Prg15" value="Regular" /> Regular<br />
                                                <input type="radio" name="Prg15" value="Buena" /> Buena<br />
                                                <input type="radio" name="Prg15" value="Muy Buena" /> Muy Buena<br />
                                                <input type="radio" name="Prg15" value="Excelente" /> Excelente<br />
                                              </div>
                                            </div>
                                    </td>
                                </tr>
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr id="TROtroP15" style="display:contents">
                                <td>
                                    <b >Menciona porque</b >
                                    <br />
                                    <textarea id="TxtOtroP15" name="OtroP15" rows="5" cols="20" style="width:100%" placeholder="Escribe aquí tus comentarios" runat="server"></textarea>
                                </td>
                              </tr>


                             <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr >
                                    <td >
                                        <div class="PregF16">
                                              <div class="pregunta"><b>16.¿La relación con tu jefe directo fue?</b>
                                              </div>
                                              <br />
                                                <input type="radio" name="Prg16" value="Mala" /> Mala<br />
                                                <input type="radio" name="Prg16" value="Regular" /> Regular<br />
                                                <input type="radio" name="Prg16" value="Buena" /> Buena<br />
                                                <input type="radio" name="Prg16" value="Muy Buena" /> Muy Buena<br />
                                                <input type="radio" name="Prg16" value="Excelente" /> Excelente<br />
                                              </div>
                                    </td>
                                </tr>
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr id="TROtroP16" style="display:contents">
                                <td>
                                    <b >Menciona porque</b >
                                    <br />
                                    <textarea id="TxtOtroP16" name="OtroP16" rows="5" cols="20" style="width:100%" placeholder="Escribe aquí tus comentarios" runat="server"></textarea>
                                </td>
                              </tr>
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>

                            <tr >
                                    <td >
                                        <div class="PregF17">
                                              <div class="pregunta"><b>17. ¿El horario que cubrías fue?</b>
                                              </div>
                                              <br />
                                              <div class="respuestas17">
                                                <input type="radio" name="Prg17" value="El adecuado a sus necesidades" />El adecuado a sus necesidades<br />
                                                <input type="radio" name="Prg17" value="El acordado cuando lo contrataron" /> El acordado cuando lo contrataron<br />
                                                <input type="radio" name="Prg17" value="Cambiado constantemente sin su autorización" /> Cambiado constantemente sin su autorización<br />
                                                <input type="radio" name="Prg17" value="flexible en coordinación con su jefe" /> flexible en coordinación con su jefea<br />
                                              </div>
                                            </div>
                                    </td>
                                </tr>



                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="PregF18">
                                              <div class="pregunta">18. ¿Cómo consideras el sueldo que percibías de acuerdo a las actividades de tu puesto?<br />
                                              </div>
                                              <div class="respuestas">
                                                <input type="radio" name="Prg18" value="Muy bajo" />Muy bajo<br />
                                                <input type="radio" name="Prg18" value="Bajo" />Bajo<br />
                                                <input type="radio" name="Prg18" value="Suficiente" />Suficiente<br />
                                                <input type="radio" name="Prg18" value="Bueno" />Bueno<br />
                                                <input type="radio" name="Prg18" value="Muy Bueno" />Muy Bueno<br />
                                              </div>
                                            </div>
                                    </td>
                                </tr>

                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="PregF19">
                                              <div class="pregunta">19. ¿Cómo consideras las prestaciones que percibías?<br />
                                              </div>
                                              <div class="respuestas">
                                                <input type="radio" name="Prg19" value="Muy bajo" />Muy bajo<br />
                                                <input type="radio" name="Prg19" value="Bajo" />Bajo<br />
                                                <input type="radio" name="Prg19" value="Suficiente" />Suficiente<br />
                                                <input type="radio" name="Prg19" value="Bueno" />Bueno<br />
                                                <input type="radio" name="Prg19" value="Muy Bueno" />Muy Bueno<br />
                                              </div>
                                            </div>
                                    </td>
                                </tr>

                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="PregF20">
                                              <div class="pregunta">20. ¿Las funciones que desempeñabas fueron?<br />
                                              </div>
                                              <div class="respuestas">
                                                <input type="radio" name="Prg20" value="Tediosas" />Tediosas<br />
                                                <input type="radio" name="Prg20" value="Rutinarias" />Rutinarias<br />
                                                <input type="radio" name="Prg20" value="Ordinarias" />Ordinarias<br />
                                                <input type="radio" name="Prg20" value="Interesantes" />Interesantes<br />
                                                <input type="radio" name="Prg20" value="Muy interesantes" />Muy interesantes<br />
                                              </div>
                                            </div>
                                    </td>
                                </tr>

                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="PregF21">
                                              <div class="pregunta">21. ¿Se te facilitaron las herramientas adecuadas para desempeñar tus funciones?<br />
                                              </div>
                                              <div class="respuestas">
                                                <input type="radio" name="Prg21" value="Nunca" />Nunca<br />
                                                <input type="radio" name="Prg21" value="En algunas ocasiones" />En algunas ocasiones<br />
                                                <input type="radio" name="Prg21" value="Normalmente" />Normalmente<br />
                                                <input type="radio" name="Prg21" value="Casi Siempre" />Casi Siempre<br />
                                                <input type="radio" name="Prg21" value="Siempre" />Siempre<br />
                                              </div>
                                            </div>
                                    </td>
                                </tr>

                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr>
                                <td>
                                    <b >22.¿Qué hubiera podido cambiar/mejorar para prevenir tu salida de la empresa?</b >
                                    <br />
                                    <textarea id="TxtPrg22" name="Motivo" rows="5" cols="40" style="width:100%" placeholder="Escribe aquí tus comentarios" runat="server"></textarea>
                                </td>

                              </tr>


                            <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                             <tr>
                                <td>
                                    <b >23. Algún otro comentario que te gustaría compartir con nosotros</b >
                                    <br />
                                    <textarea id="TxtPrg23" name="Motivo" rows="5" cols="40" style="width:100%" placeholder="Escribe aquí tus comentarios" runat="server"></textarea>
                                </td>

                              </tr>


                            <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="PregF24">
                                              <div class="pregunta">De acuerdo a tu experiencia, ¿Recomendarías a un familiar y/o amigo trabajar en esta empresa?<br />
                                              </div>
                                              <div class="respuestas">
                                                <input type="radio" name="Prg24" value="Si" />Si<br />
                                                <input type="radio" name="Prg24" value="No" />No<br />
                                              </div>
                                            </div>
                                    </td>
                                </tr>

                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="PregF25">
                                              <div class="pregunta">Si las políticas lo permitieran, ¿Te gustaría regresar a trabajar con nosotros?<br />
                                              </div>
                                              <div class="respuestas">
                                                <input type="radio" name="Prg25" value="Si" />Si<br />
                                                <input type="radio" name="Prg25" value="No" />No<br />
                                              </div>
                                            </div>
                                    </td>
                                </tr>


                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b style="text-align:center">Gracias por tu tiempo. Agradecemos tu valiosa retroalimentación.</b>
                                    </td>
                                </tr>
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-success btn-sm" OnClick="cmdSummit_Click" Text="Enviar" />
                                    </td>
                                </tr>
                                <tr  style="visibility:hidden">
                                    <td>
                                    <b > Nombre</b > 
                                    <br />
                                </td>
                                </tr>
                            </table>
                        </div>
                        </div>
                    </form>

                    
                </div>
            </div>
        </div>

    </div>
</body>
</html>
