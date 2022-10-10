////$(document).ready(function () {

////    $.ajax({
////        dataType: "json",
////        type: 'POST',
////        contentType: "application/json; charset=utf-8",
////        url: '/Index/ObtenerPermisos',
////        data: "{ 'idperfil': '" + 6 + "','idusuario': '" + 6 + "'}",
////        success: function (data) {

////            var menu = document.getElementById("menu_dinamico");
////            var contenido;
////            for (var item in data) {


////                if (data[item].idperfil == 4) {
////                    console.log("PERFIL VENDEDOR");
////                }

////                else if (ata[item].idperfil == 6) {
////                    console.log("PERFIL COBRANZAS");
////                }

////                //       var li = document.createElement("li");
////                //       var a = document.createElement("a");
////                //       li.setAttribute("class","nav-item");
////                //       contenido = data[item].nombrePermiso;
////                //       var url = data[item].nombreFormulario+"/"+data[item].nombrePermiso

////                //       a.setAttribute("href", data[item].nombrePermiso);
////                //    //   console.log(data[item].nombrePermiso);

////                //      // menu.appendChild(data[a].nombrePermiso);
////                //       a.appendChild(document.createTextNode(contenido));
////                //       a.setAttribute("class","nav-link");
////                //       document.querySelector("#menu_dinamico").appendChild(li).appendChild(a);
////                //   }
////                ////   document.body.appendChild(menu);

////                //   var p = document.createElement("p");
////                //   document.querySelector("#menu_dinamico").appendChild(li).appendChild(p);



////            }
////        }
////    }
////        );

////});