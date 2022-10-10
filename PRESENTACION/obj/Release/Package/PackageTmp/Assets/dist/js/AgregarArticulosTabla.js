
//var baserul = "cotizadorRepuestos";

$(document).ready(function () {
    //obtenemos el valor de los input
$("#selArticulosprueba").select2('');

 
    $('#BtnRegistrar_Click').click(function () {

        console.log("CLICK REGISTRAR DETALLE");
     //   ObtenerDetalle();
    //   var lista = ObtenerDetalle();
    // console.log(lista);

        //$.ajax({
        //    dataType: "json",
        //    type: 'POST',
        //    contentType: "application/json; charset=utf-8",
        //    url: '/Cotizador/AgregarDetalleCotizacion',
        //    data: lista,
        //    success: function (data) {
        //        console.log(data);
               

        //    }
        //});


    });


    $('#adicionar').click(function () {

        var nombre_oculto = document.getElementById("nombre_articulo_ocul").value;
        var codigo_oculto = document.getElementById("codigo_articulo_ocul").value;
            var codigo = document.getElementById("articulo_select").value;
            var codigo1 = document.getElementById("articulo_select");
            //OBTENER NOMBRE DEL ARTICULO
            var idx = codigo1.selectedIndex;
            var articulo = codigo1.options[idx].text;
            //var articulo = document.getElementById("articulo_select").value;
            //var text = articulo.find('option[value=' + articulo + ']').text();
            var arr = articulo.split('-');
            var articulo_nom = arr[1];
            
            console.log(articulo+"nombre");
            ///
        var unidad = document.getElementById("unidad_articulo").value;
        var precio = document.getElementById("precio_articulo").value;
        var cantidad_solicitada = document.getElementById("c_solicitada").value;
        var cantidad_disponible = document.getElementById("c_disponible").value;
         var stock = document.getElementById("stock_articulo").value;
       var cabeceramaster = document.getElementById("codigocliente").value;
            var motivo = "Registro";
        console.log(cantidad_solicitada);
        console.log(cantidad_disponible);
        if (cantidad_solicitada == "" || cantidad_disponible=="") {
            cantidad_solicitada.required = 'true';
            cantidad_disponible.required = 'true';
                      
        }
        else {
            if (codigo == "Elegir") {
                var i = 1; //contador para asignar id al boton que borrara la fila
                //original var fila = '<tr id="row' + i + '"><td>' + nombre + '</td><td>' + apellido + '</td><td>' + cedula + '</td><td><button type="button" name="remove" id="' + i + '" class="btn btn-danger btn_remove">Quitar</button></td></tr>'; //esto seria lo que contendria la fila
                //variable que pinta la fila en la tabla 

                var fila = '<tr id="row' + i + '"> <td>' + codigo_oculto + '</td><td>' + nombre_oculto + '</td> <td>' + unidad + '</td><td > ' + precio + '</td><td>' + cantidad_solicitada + '</td> <td>' + cantidad_disponible + '</td> <td>' + stock + '</td> <td><button type="button" name="remove" id="' + i + '" class="btn btn-danger btn_remove">Quitar</button></td>   <td style="visibility:hidden;"> ' + unidad + '</td>  <td style="visibility:hidden;"> ' + cabeceramaster + '</td>     </tr > '; //esto seria lo que contendria la fila

                i++;
                $('#mytable tr:first').after(fila);


                $.ajax({
                    dataType: "json",
                    type: 'POST',
                    contentType: "application/json; charset=utf-8",
                    url: '/Cotizador/AgregarDetalleCoti',
                    data: "{ 'codigo_articulo': '" + codigo_oculto + "','nombre_articulo': '" + nombre_oculto + "','uni': '" + unidad + "', 'preciocotizacion': '" + precio + "','cantidad_solicitada': '" + cantidad_solicitada + "', 'cantidad_disponible': '" + cantidad_disponible + "','stock': '" + stock + "', 'motivo': '" + motivo + "','codigo_cabecera': '" + cabeceramaster + "' }",
                    success: function (data) {
                        //si data es true agrega 
                        console.log(data);


                    }
                });
            }
            else {

                var i = 1; //contador para asignar id al boton que borrara la fila
                //original var fila = '<tr id="row' + i + '"><td>' + nombre + '</td><td>' + apellido + '</td><td>' + cedula + '</td><td><button type="button" name="remove" id="' + i + '" class="btn btn-danger btn_remove">Quitar</button></td></tr>'; //esto seria lo que contendria la fila
                //variable que pinta la fila en la tabla 

                var fila = '<tr id="row' + i + '"> <td>' + codigo + '</td><td>' + articulo_nom + '</td> <td>' + unidad + '</td><td > ' + precio + '</td><td>' + cantidad_solicitada + '</td> <td>' + cantidad_disponible + '</td> <td>' + stock + '</td> <td><button type="button" name="remove" id="' + i + '" class="btn btn-danger btn_remove">Quitar</button></td>   <td style="visibility:hidden;"> ' + unidad + '</td>  <td style="visibility:hidden;"> ' + cabeceramaster + '</td>     </tr > '; //esto seria lo que contendria la fila

                i++;
                $('#mytable tr:first').after(fila);


                $.ajax({
                    dataType: "json",
                    type: 'POST',
                    contentType: "application/json; charset=utf-8",
                    url: '/Cotizador/AgregarDetalleCoti',
                    data: "{ 'codigo_articulo': '" + codigo + "','nombre_articulo': '" + articulo_nom + "','uni': '" + unidad + "', 'preciocotizacion': '" + precio + "','cantidad_solicitada': '" + cantidad_solicitada + "', 'cantidad_disponible': '" + cantidad_disponible + "','stock': '" + stock + "', 'motivo': '" + motivo + "','codigo_cabecera': '" + cabeceramaster + "' }",
                    success: function (data) {
                        //si data es true agrega 
                        console.log(data);


                    }
                });
            }





            //var i = 1; //contador para asignar id al boton que borrara la fila
            ////original var fila = '<tr id="row' + i + '"><td>' + nombre + '</td><td>' + apellido + '</td><td>' + cedula + '</td><td><button type="button" name="remove" id="' + i + '" class="btn btn-danger btn_remove">Quitar</button></td></tr>'; //esto seria lo que contendria la fila
            ////variable que pinta la fila en la tabla 

            //var fila = '<tr id="row' + i + '"> <td>' + codigo + '</td><td>' + articulo_nom + '</td> <td>' + unidad + '</td><td > ' + precio + '</td><td>' + cantidad_solicitada + '</td> <td>' + cantidad_disponible + '</td> <td>' + stock + '</td> <td><button type="button" name="remove" id="' + i + '" class="btn btn-danger btn_remove">Quitar</button></td>   <td style="visibility:hidden;"> ' + unidad + '</td>  <td style="visibility:hidden;"> ' + cabeceramaster + '</td>     </tr > '; //esto seria lo que contendria la fila
            
            //i++;
            //$('#mytable tr:first').after(fila);


            //creando arreglo  crea el arreglo y envia a BD 
            RegistrarDetalle();

            //cerrando arreglo

          

            $("#adicionados").text(""); //esta instruccion limpia el div adicioandos para que no se vayan acumulando
            var nFilas = $("#mytable tr").length;
            $("#adicionados").append(nFilas - 1);
            //le resto 1 para no contar la fila del header
            document.getElementById("articulo_select").value = "";
            document.getElementById("articulo_select").value = "";
            document.getElementById("unidad_articulo").value = "";
            document.getElementById("precio_articulo").value = "";
            document.getElementById("c_solicitada").value = "";
            document.getElementById("c_disponible").value = "";
            document.getElementById("stock_articulo").focus();


        }
    });

    $(document).on('click', '.btn_remove', function () {
       // alert("Ingrese Motivo De eliminacion");

        ingresar_motivo_anulacion();

        var button_id = $(this).attr("id");
        //cuando da click obtenemos el id del boton
        $('#row' + button_id + '').remove(); //borra la fila
         
        //tambien edita el motivo AJAX PARA EDITAR MOTIVO
        //$.ajax({
        //    dataType: "json",
        //    type: 'POST',
        //    contentType: "application/json; charset=utf-8",
        //    url: '/Cotizador/EditarDetalleCotizacion',
        //    data: "{ 'codigo_cabecera': '" + codigocabecera + "','codigo_articulo': '" + codigoarticulo + "','motivo': '" + motivo + "'}",
        //    success: function (data) {
        //        console.log(data);


        //    }
        //});



        //limpia el para que vuelva a contar las filas de la tabla
        $("#adicionados").text("");
        var nFilas = $("#mytable tr").length;
        $("#adicionados").append(nFilas - 1);
    });
});


function RegistrarDetalle() {

    //var ListaDetalle = new Array();

    var table = document.getElementById("mytable");

    
    for (var i = table.rows.length-1 ; i < table.rows.length; i++) {
        console.log("tamaño de row en la tabla");
        console.log(table.rows.length);
        var row = table.rows[i];
        var Detalle = {};


        Detalle.codigo_articulo = row.cells[0].innerHTML;
        Detalle.nombre_articulo = row.cells[1].innerHTML;
        Detalle.uni = row.cells[2].innerHTML;
        Detalle.preciodecotizacion = row.cells[3].innerHTML;
        Detalle.cantidad_solicitada = row.cells[4].innerHTML;
        Detalle.cantidad_disponible = row.cells[5].innerHTML;
        Detalle.stock = row.cells[6].innerHTML;

        //boton es la celda 7
        Detalle.motivo = row.cells[8].innerHTML;
        Detalle.codigo_cabecera = row.cells[9].innerHTML;
       // ListaDetalle.push(Detalle);
    }

  //  var JsonDatelle = JSON.stringify(ListaDetalle);
   // console.log(JsonDatelle);
     
        
                                                                                                                                                                                                                                                           
    //$.ajax({
    //    dataType: "json",
    //    type: 'POST',
    //    contentType: "application/json; charset=utf-8",
    //    url: '/Cotizador/AgregarDetalleCoti',
    //    data: "{ 'codigo_articulo': '" + Detalle.codigo_articulo + "','nombre_articulo': '" + Detalle.nombre_articulo + "','uni': '" + Detalle.uni + "', 'preciocotizacion': '" + Detalle.preciodecotizacion + "','cantidad_solicitada': '" + Detalle.cantidad_solicitada + "', 'cantidad_disponible': '" + Detalle.cantidad_disponible + "','stock': '" + Detalle.stock + "', 'motivo': '" + Detalle.motivo + "','codigo_cabecera': '" + Detalle.codigo_cabecera + "' }",
    //    success: function (data) {
    //        console.log(data);


    //    }
    //});


   // var JsonDatelle = JSON.stringify(ListaDetalle);

    //console.log("VARIABLE J SON ");
 //  console.log(JsonDatelle);
 // return JsonDatelle;
};


function borrarRegistroDetalle() {
    console.log("BORRAR REGSITRO")


}


function lista() {

    $("#selArticulosprueba").select2({

        ajax: {
            url: "/Cotizador/ObtenerArticuloparaSelect",
            type: "post",
            dataType: 'json',
            delay: 250,
            data: function (params) {
                return {
                    codigo: params.term // search term
                };
            },
            processResults: function (response) {
                console.log(response.codigo);
                return {
                    results: response
                };
            },
            cache: true
        }
    });


};



