
//console.log("antes del file");
//document.querySelector('#articulo_select').select2();
//document.getElementById('articulo_select').select2();
   
//$(".custom-file-input").on("change", function () {
//    console.log("nombre del file");
//    var fileName = $(this).val().split("\\").pop();
//    $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
//});

document.querySelector('.custom-file-input').addEventListener('change', traerDatos2);


function traerDatos2() {
    var fileName = $(this).val().split("\\").pop();
    $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
}