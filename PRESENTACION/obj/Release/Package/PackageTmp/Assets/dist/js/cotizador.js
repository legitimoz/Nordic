//console.log('UBICACION');
//traerDatosClientes();
//document.querySelector('#boton').addEventListener('click', traerDatos());
//document.querySelector('#articulo_select').select2();
//document.querySelector('#articulo_select').addEventListener('click', traerArticulos);


//document.querySelector('#clienteres').addEventListener('click', traerDatosClientes);


///COMENTADO PARA QUITAR EERORES
//function traerDatos() {
//   // console.log('dentro de la funcion');

//    const xhttp = new XMLHttpRequest();
//    xhttp.open('GET', '../Assets/dist/js/cotizaciones.json', true);
//    xhttp.send();
//    xhttp.onreadystatechange = function () {
//        if (this.readyState == 4 && this.status == 200) {
//            //captura el json en formato json
//        //    console.log(this.responseText);
//            //parsearlo y lo convierte en objeto
//            let datos = JSON.parse(this.responseText);
//           // console.log(datos);

//            //respuesta a la tabla
//            let res = document.querySelector('#res');
//            res.innerHTML = ``;

//            for (let item of datos) {
//                //convierte en variables por separado 
//                // console.log(item.numero + item.cliente);
//                let cant = parseInt(item.cantidad);
//                let sto = parseInt(item.stock);
//                if (cant > sto) {
//             //       console.log(item.cantidad+item.stock);
//                    res.innerHTML += ` <tr>
//                                  <td scope='row'>${item.cliente}</td>
//                                  <td >${item.nombrearticulo}</td>
//                                  <td>${item.unidad}</td>
//                                  <td>${item.precio}</td>
//                                  <td class="bg-danger text-white text-center">${item.cantidad}</td>
//                                  <td>${item.stock}</td>
//                                  <td>${item.disponibilidad}</td>
//                                    <td><button class="btn btn-danger">ANULAR MOTIVO</button></td>
//                                  </tr>  

//                                    `;
//                }
//                else {
//                    res.innerHTML += ` <tr>
//                                  <td scope='row'>${item.cliente}</td>
//                                  <td>${item.nombrearticulo}</td>
//                                  <td>${item.unidad}</td>
//                                  <td>${item.precio}</td>
//                                  <td class="bg-primary text-white text-center">${item.cantidad}</td>
//                                  <td>${item.stock}</td>
//                                    <td>${item.disponibilidad}</td>
//                                    <td><button class="btn btn-danger">ANULAR MOTIVO</button></td>
//                                  </tr>  

//                                    `;

//                }

//            }

//        }
//    }
//}


//function traerDatosClientes() {
    
//   // console.log('dentro de la funcion');

//    const xhttp = new XMLHttpRequest();
//    xhttp.open('GET', '../Assets/dist/js/clientes.json', true);
//    xhttp.send();
//    xhttp.onreadystatechange = function () {
//        if (this.readyState == 4 && this.status == 200) {
//            //captura el json en formato json
//         //   console.log(this.responseText);
//            //parsearlo y lo convierte en objeto
//            let datos = JSON.parse(this.responseText);
//     //       console.log(datos);

//            //respuesta a la tabla
//            let res2 = document.getElementById('clienteres2');
//           // res2.innerHTML = '';
//            for (let item of datos) {

//                //res2.innerHTML += `
//                //                    <option value="1">${item.razonsocial + ' ' + item.codigo}</option>
                                                  

//                //                    `;
                
//            }

//        }
//    }
//}


//function traerArticulos() {

//    console.log('click de la funcion');

//    const xhttp = new XMLHttpRequest();
//    xhttp.open('GET', '../Assets/dist/js/clientes.json', true);
//    xhttp.send();
//    xhttp.onreadystatechange = function () {
//        if (this.readyState == 4 && this.status == 200) {
//            //captura el json en formato json
//            console.log(this.responseText);
//            //parsearlo y lo convierte en objeto
//            let datos = JSON.parse(this.responseText);
//          //  console.log(datos);

//            //respuesta a la tabla
//            let res2 = document.getElementById('clienteres2');
//            res2.innerHTML = '';
//            for (let item of datos) {
//                res2.innerHTML += `
//                                    <option value="1">${item.razonsocial + ' ' + item.codigo}</option>                                                 
//                                    `;
//            }
//        }
//    }

//}