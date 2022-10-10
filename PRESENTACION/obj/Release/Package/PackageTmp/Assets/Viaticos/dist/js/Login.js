//cotizadorRepuestos


//$(document).ready(function () {

//    //METODO PARA INICIAR SESION : 1 CAPTURA LOS DATOS DEL USUARIO 
//    $('#boton_sesion').click(function () {
//        console.log(baserul);
//       var usuario= document.getElementById("input_").value ;
//       var contraseña = document.getElementById("input_pas").value;

//        //if (usuario == "FGB" && contraseña == "FGB" ) {
//        //    window.location.href = "/Cotizador/Index";
//        //}
//        //else if (usuario == "VND" && contraseña == "VND") {
//        //    window.location.href = "/Cotizador/Index";
//        //}
       
//        //else {
//        //    window.location.href = "/Index/Index";
//        //    alert("ERROR DE INGRESO");
//        //}

//        var baserul = '@Url.Action("ObtenerUsuario","Index")';
//        $.ajax({
//            dataType: "json",
//            type: 'POST',
//            contentType: "application/json; charset=utf-8",
//            url: baserul,
//            data: "{ 'usr': '" + usuario + "','cod': '" + contraseña + "'}",
//            success: function (data) {
//                if (data.idusuario != 0 && data.alias!=null && data.clave!=null ) {
//                   // console.log(data);
//                    console.log("Logeado");
//                    enviar_id_usu(data.idusuario, data.nombre_usuario);
//                    var username = '<%= Session["id_usuario_logeado"]%>';
//                    username = data.idusuario;
//                    //alert(username);
//                    //'<%=Session["id_usuario_logeado"] = "' + data.idusuario + '"%>';
//                 document.getElementById('id_usuario_oculto').value = data.idusuario;
//                    console.log(username);
//                   /* alert( '<%= Session["id_usuario_logeado"]%>' );*/
//                  //  alert('<["ID_USUARIO"]>');
//                    window.location.href = baserul+"/Cotizador/Index";
//                }
//                else if (data.alias == null || data.clave == null) {
//                    console.log("No puede Logearse");
//                    $('#identificador_error').html('<h5>Error en Logeo</h5>');
//                }
//            }
//        });


        

//    });
//});

//function enviar_id_usu(usu,nombre) {
//    $.ajax({
//        dataType: "json",
//        type: 'POST',
//        contentType: "application/json; charset=utf-8",
//        url: baserul+'/Cotizador/Variable_sesion',
//        data: "{ 'cod': '" + usu + "', 'nombre': '" + nombre + "'}",
//        success: function (data) {
          




//        }
//    });
//}