//var baserul = "cotizadorRepuestos";
$(document).ready(function () {
    //FiltrarArticulos();
    $('#articulo_select').select2('');
    $('#articulo_select_modelo').select2('');
    $("[id$='articulo_select']").change(function () {
        //OBTENIES EL ARTICULO
        var selectArticulo = document.getElementById('articulo_select');
        var codigoArticulo = selectArticulo.options[selectArticulo.selectedIndex].value;
        console.log(codigoArticulo);
        //   var data = { ruccliente: RucCliente };
        $.ajax({
            dataType: "json",
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            url: '/Cotizador/ObtenerArticulo',
            data: "{ 'codigo': '" + codigoArticulo + "'}",
            success: function (data) {

                if (data.unidad==null) {

                } else {
                    //  console.log(data);
                   var stock = ObtenerStockArticulo();
                    document.getElementById('unidad_articulo').value = data.unidad;
                    var precio = parseFloat(data.preciouno);
                    document.getElementById('precio_articulo').value = precio;
                    //CONVERT A ENTERO DEL STOCK
                    document.getElementById('stock_articulo').value = stock;
                }
                
            }
        });
    });


});


function FiltrarArticulos() {
    var selectmodArticulo = document.getElementById('articulo_select_modelo');
    var codigoModArticulo = selectmodArticulo.options[selectmodArticulo.selectedIndex].value;

    var mitablaArtFiltrados = document.getElementById("tabla_art_filtrados_res");
    var cod_ar = document.getElementById('codigo_articulo_corto').value;
    var desc_ar = document.getElementById('descripcion_articulo_corto').value;
    var almacen = "CA01";
    if (cod_ar == "" && desc_ar == "" && codigoModArticulo=="") {
        alert("llenar datos");
    }
    else {
        $.ajax({
            dataType: "json",
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            url: '/Cotizador/ListadoArticulosFiltrado',
            data: "{ 'codigo': '" + cod_ar + "','descripcion': '" + desc_ar + "','modelo': '" + codigoModArticulo + "'}",
            success: function (data) {
                //  console.log(data);
                mitablaArtFiltrados.innerHTML = ``;
                var variablecod;
                for (cab in data) {
                    console.log(data);
                    variablecod = data[cab].codigo;
                    //  codigoanulacion = codigocotizaciontext + data[cab].codigo;
                    //  console.log(codigoanulacion);
                    //console.log("Cotizacion ___________________________");
                    //console.log("codigo " + data[cab].codigo + " cliente" + data[cab].cliente + " almacen " + data[cab].almacen);
                    //console.log("_______________________________________");
                    mitablaArtFiltrados.innerHTML += ` <tr>
                                  
                                  <td>${data[cab].codigo}</td>
                                  <td>${data[cab].nombre}</td>
                                  <td>${data[cab].preciouno}</td>
                                 <td>${data[cab].stock}</td>
    <td><button  id="btn_filtrado" class="btn text-white" onclick="RellenarCamposArt('${data[cab].codigo}')" style="background-color:#09B556;"><i class="bi bi-check2-square"></i></button></td>

                                </tr>
                                    `;



                }
            }
        });
    }
}

function RellenarCamposArt(codarticulo) {
    $('#articulo_select').val('Elegir').trigger('change.select2');
  //  alert(codarticulo);
  //  console.log(codarticulo);

    $.ajax({
        dataType: "json",
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: '/Cotizador/ObtenerArticulo',
        data: "{ 'codigo': '" + codarticulo + "'}",
        success: function (data) {
            //  console.log(data);
           // var stock = ObtenerStockArticulo();
            document.getElementById('unidad_articulo').value = data.unidad;
            var precio = parseFloat(data.preciouno);
            document.getElementById('precio_articulo').value = precio;
            //CONVERT A ENTERO DEL STOCK
            
            stok = parseInt(data.stock);
            //console.log(stok);
            //console.log(data.stock);
            
            document.getElementById('stock_articulo').value = stok;
            document.getElementById('codigo_articulo_ocul').value = data.codigo;
            document.getElementById('nom_articulo_2').value = data.codigo +" - " + data.nombre;
            document.getElementById('nombre_articulo_ocul').value = data.nombre;
            document.getElementById('c_disponible').value = stok;
      
                //$("#popupBusquedaParroquia").modal('hide');//ocultamos el modal
                //$('body').removeClass('modal-open');//eliminamos la clase del body para poder hacer scroll
                //$('.modal-backdrop').remove();//eliminamos el backdrop del modal
           
        }
    });
   // document.getElementById('');
    //ocultar modal articulo
    $('#exampleModalBusquedaArticulo').modal('hide');
}
function enviarparametro(){

    $.ajax({
        dataType: "json",
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: '/Cotizador/ObtenerArticulo',
        data: "{ 'codigo': '" + codigoArticulo + "'}",
        success: function (data) {
           
            document.getElementById('unidad_articulo').value = data.unidad;
            let precioArticulo = parseInt(data.preciouno, 16);
            document.getElementById('precio_articulo').value = precioArticulo;
            //document.getElementById('stock_articulo').value = stock;
           // document.getElementById('c_disponible').value = stock;
        }
    });
}

function ObtenerStockArticulo() {
    //NECESITAS ARTICULO Y EL ALMACEN
    var selectArticulo = document.getElementById('articulo_select');
    var codArticulo = selectArticulo.options[selectArticulo.selectedIndex].value;
    //var selectAlmacen = document.getElementById('almacen');
    //var codAlmacen = selectAlmacen.options[selectAlmacen.selectedIndex].value;
    var codAlmacen = document.getElementById('alamceninput').value;
   // console.log("CODIGO ALMACEN" + codAlmacen);
    //var codAlmacen = selectAlmacen.options[selectAlmacen.selectedIndex].value;
    //console.log("ESTOY HACIENDO ALGO ?");
    $.ajax({
        dataType: "json",
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: '/Cotizador/OnbtenerStockArticulo',
        data: "{ 'codigoarticulo': '" + codArticulo + "','codigoalmacen': '" + codAlmacen + "'}",
        success: function (data) {
            if (data.codigo_articulo == null) {

            }
            else {

          //  console.log(data);
            //FGB:  OBTIENE VALOR DEL STOCK AL SELECCIONAR ARTICULO
            //CONVERSION DE STRING A INT
            let valorStock = parseInt(data.stock);
            var stokkk = document.getElementById('stock_articulo').value = valorStock;
            console.log("que marca stock "  + stokkk);
            document.getElementById('c_disponible').value = valorStock;
           
            if (valorStock == 0) {
                document.getElementById('c_disponible').setAttribute("disabled", "");

            }
            else {
            
                document.getElementById('c_disponible').removeAttribute("disabled", "");
                document.getElementById('c_disponible').setAttribute("enabled", "");
                }
            }
            
        }
    });


}

async function ingresar_motivo_anulacion() {
    cargaMotivos();
  
}

  function cargaMotivos() {

    var lista = [];
        $.ajax({
        dataType: "json",
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: '/Cotizador/ListadoMotivos',
        data: "{}",
        success:  function (data)  {
           // console.log(data);
            let des = { data };
            let obj = Object.assign({}, des);
           // console.log("objeto . ." + obj[0].descripcion);
            console.log(data.id);
            let motivos_ = {  };
            var i = 1;
            for (var a in data) {
                
                motivos_[i]= data[a].descripcion;
                i++;
            }
            
            console.log("MOTIVOS . . ."+motivos_);
            const { value: text } =  Swal.fire({
                input: 'select',
                inputOptions:
                    motivos_
                ,
                inputLabel: 'Motivo',
                inputPlaceholder: 'Escribe motivo de anulacion...',
                inputAttributes: {
                    'aria-label': 'Type your message here'
                },
                showCancelButton: true
            })
            if (text) {
                Swal.fire(text)
            }
            else {
                console.log("else del swal " + text);
                
                var selectArticulo = document.getElementById('swal2-input');
                var codArticulo = selectArticulo.options[selectArticulo.selectedIndex].value;
                console.log("identificar select " + codArticulo);
            }

        }
    });

   return lista;
}