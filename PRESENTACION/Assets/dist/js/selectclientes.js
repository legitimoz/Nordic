////var baserul = "";

    
////$(document).ready(function () {
    

////    var date = new Date();
    
////    const formatDate = (current_datetime) => {
////        let formatted_date = current_datetime.getDate() + "/" + "0" + (current_datetime.getMonth() + 1) + "/" + current_datetime.getFullYear() + " " + current_datetime.getHours() + ":" + current_datetime.getMinutes();
////        return formatted_date;
////    }
  
////    let hoy = formatDate(date);
////    var fecha = new Date();
  

////    let fechaseteada = new Date(date.getTime() - (date.getTimezoneOffset() * 60000));

////    let Fechaemision = document.getElementById("txtFechaEmision");
////    if (Fechaemision) {
////        Fechaemision = document.getElementById("txtFechaEmision").value = fechaseteada.toJSON().slice(0, 16);
////    }
  
  
////   $('#bd_select').select2('');
////   $('#clienteres3').select2('');

//// $('#vendedores').select2('');
 
////   $('#almacen').select2('');
////   $('#almacen').val('CA01').trigger('change.select2');

  


////    $("[id$='clienteres3']").change(function () {
////        rellenarDirecciones();

////        var SelectCliente = document.getElementById('clienteres3');
////        var RucCliente = SelectCliente.options[SelectCliente.selectedIndex].value;

////        $.ajax({
////            dataType: "json",
////            type: 'POST',
////            contentType: "application/json; charset=utf-8",
////            url: baserul +'/Cotizador/Buscar',
////            data: "{ 'ruccliente': '" + RucCliente + "'}",
////            success: function (data) {

////                RellenarFormaVenta(data.value_tipoventa, data.tipoventa);
    
////                $("#vendedores").select2('data', { id: data.ruc, text: data.vendedor });

////                Fechaemision = document.getElementById("txtFechaEmision").value = fechaseteada.toJSON().slice(0, 16);

////                MostrarDataFinancieraCliente(data.ruc, data.razonsocial);
////                MostrarDocumentosPendientes(data.ruc, data.razonsocial);
////            }
////        });
////    })

////    });

////function MostrarDataFinancieraCliente(rucliente,razonsocial) {

////    var btn_fnz = document.getElementById('rg_ctz_btn_fnz');
////    console.log("Data Financiera del Cliente " + rucliente+"-"+razonsocial);
////    $.ajax({
////        dataType: "json",
////        type: 'POST',
////        contentType: "application/json; charset=utf-8",
////        url: baserul +'/Cotizador/ObtenerDetalleFinanciero',
////        data: "{ 'ruccliente': '" + rucliente + "'}",
////        success: function (data) {
////            console.log(data);
////            if (data.limite_credito == null) {
////                document.getElementById('Lim_cred_cli').value = "S/. 0.00";
////                document.getElementById('rs_dt_fnz').value = razonsocial;
////            }
////            else {
////                btn_fnz.removeAttribute("disabled", "");
////                btn_fnz.setAttribute("enabled", "");
////                document.getElementById('rs_dt_fnz').value = razonsocial;
////                document.getElementById('Lim_cred_cli').value = data.limite_credito;
////            }
       
////        }
////    });



////}

////function MostrarDocumentosPendientes(ruccliente, razonsocial) {
////    var mitablaDocPendientes = document.getElementById("tabla-doc-vencidos-res");
////    $.ajax({
////        dataType: "json",
////        type: 'POST',
////        contentType: "application/json; charset=utf-8",
////        url: baserul +'/Cotizador/ListaDocumentosPendientes',
////        data: "{ 'ruccliente': '" + ruccliente + "'}",
////        success: function (data) {
           
    
////            mitablaDocPendientes.innerHTML = ``;

////            for (cab in data) {
////                console.log(data);
        
////                mitablaDocPendientes.innerHTML += ` <tr>
                                  
////                                  <td>${data[cab].tipo_documento}</td>
////                                  <td>${data[cab].numero_documento}</td>
////                                  <td>${data[cab].vendedor}</td>
////                                  <td>${data[cab].fecha_emision}</td>
////                                  <td>${data[cab].fecha_vencimiento}</td>
////                                  <td>${data[cab].fecha_cancelacion}</td>
////                                  <td >${data[cab].motivo}</td>
////                                  <td>${data[cab].importe}</td>
////                                  <td>${data[cab].saldo}</td>
////                                  <td>${data[cab].vencimiento}</td>
////                                  <td>${data[cab].tdr}</td>
////                                  <td >${data[cab].numero_doc_referencia}</td>

////                                </tr>
////                                    `;



////            }

////        }
////    });


////}

////function RellenarFormaVenta(tipoventa,descripcion) {
  
////    var formaventa = document.getElementById('formapago');
////    //inicie el select vacio
////    for (let i = formaventa.options.length; i >= 0; i--) {
////        formaventa.remove(i);
////    }

////    if (tipoventa == null && descripcion == null) {
////        //CUANDO EL CLIENTE ES NUEVO O NO TIENE AIGNADO UN F.VENTA 
////       var  tipoventa_ag = 'C01';
////        var descripcion_ag = 'CONTADO CONTRA ENTREGA ';
////        formaventa = document.getElementById('formapago');
////        var option = document.createElement("option"); //Creamos la opcion
////        option.value = tipoventa_ag;
////        option.text = descripcion_ag;
////        formaventa.appendChild(option);
////    }
////    else {
////        if (tipoventa == 'C01') {
////            console.log("ESTA EN EL O");
////            formaventa = document.getElementById('formapago');
////            var option = document.createElement("option"); //Creamos la opcion
////            option.value = tipoventa;
////            option.text = descripcion;
////            formaventa.appendChild(option);
////        }
////        else {
////            $('#formapago').val(tipoventa).trigger('change.select2');
////            formaventa = document.getElementById('formapago');
////            console.log("ESTA EN EL ELSE");
////            var option_mas_default = document.createElement("option"); //Creamos la opcion
////            var option_mas_d = document.createElement("option"); //Creamos la opcion
////            ti_v = "C01";
////            des_v = "CONTADO CONTRA ENTREGA " ;
////            //{ 'tipoventa': '" + tipoventa + "' };
////            var arr_fv = [{ 'tipoventa':tipoventa, 'descripcion': descripcion }, { 'tipoventa': ti_v, 'descripcion': des_v}];
////            console.log(arr_fv);

////            option_mas_d.value = arr_fv[0].tipoventa;
////            option_mas_d.text = arr_fv[0].descripcion;

////            for (i in arr_fv) {
////                console.log(option_mas_default);
////                option_mas_default.value = arr_fv[i].tipoventa;
////                option_mas_default.text = arr_fv[i].descripcion;
////                console.log(arr_fv[i].tipoventa);
////                formaventa.appendChild(option_mas_d);
////                formaventa.appendChild(option_mas_default);
         
////            }
            
        
            
////        }
        
////    }

      

////}

////function RellenarDatosCliente() {
////    console.log("algo aqui en rellenar cliente");
////    //let ruc = $("#clienteres3").val();
////    let ruc = document.getElementById('clienteres3');
////    let select = ruc.options[ruc.selectedIndex].value;

////    document.getElementById("codigocliente").value = select;
////    document.getElementById("direcion_cliente").value = select;

    
////    var data = { ruccliente: select };
////    console.log(data);


////    $.ajax({

////        dataType: "json",
////        type: 'POST',
////        contentType: "application/json; charset=utf-8",
////        url: baserul+'/Cotizador/Buscar',
////        data: "{ 'ruccliente': '" + insertado + "'}",
////        success: function (data) {
////            console.log(data.ruc);
                      
////        },
       
////    });


////}

////function rellenarDirecciones() {
////    ///FGB: RELLENA DATOS DE DIRECCIONES DEL CLIENTE 
////    var select = document.getElementById('direccion_cliente_se');
////    //inicie el select vacio
////    for (let i = select.options.length; i >= 0; i--) {
////        select.remove(i);
////    }
    
////    var SelectCliente = document.getElementById('clienteres3');
////    var RucCliente = SelectCliente.options[SelectCliente.selectedIndex].value;
////   // console.log("RUC CLIENTE " + RucCliente);
////    $.ajax({  
////        dataType: "json",
////        type: 'POST',
////        contentType: "application/json; charset=utf-8",
////        url: '/Cotizador/ListarDireccionesCliente',
////        data: "{ 'ruccliente': '" + RucCliente + "'}",
////        success: function (data) {
////         //   console.log(data);

           
////            // llene el select Direcciones 
////            for (var i = 0; i < data.length; i++) {
////                var option = document.createElement("option"); //Creamos la opcion
////            //    console.log(data[i].codigoUbicacion);
////                if (data==null) {
////                    //option.innerHTML = data[i].nombre; //Metemos el texto en la opción

////                    option.value = "0001";
////                    option.text = "MZ B ";
////                    select.appendChild(option); //Metemos la opción en el select
////                }
////                else {
////                    option.value = data[i].codigoUbicacion;
////                    option.text = data[i].nombre;
////                    select.appendChild(option); //Metemos la opción en el select
////                }

               

                
////            }
////            //select.appendChild().val="";
            
////        },

////    });

////}

  