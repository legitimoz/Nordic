//console.log("EN VISOR SINCRO");
//verificamos que exista 
//var archivo = document.getElementById("botonGenerar1");
//if (archivo) {
//    document.querySelector('#botonGenerar1').addEventListener('click', generarPDF);
//    document.querySelector('#botonAnular1').addEventListener('click', AnularCotizacion);
   
//    document.querySelector('#botonAlertarAnular1').addEventListener('click', motivo);
//    document.querySelector('#botonAlertarAnular2').addEventListener('click', motivo);
//    document.querySelector('#botonAlertarAnular3').addEventListener('click', motivo);
//}


//function generarPDF() {
//    console.log("ejecutando alertar");
//    Swal.fire({
//        title: '¿Esta seguro en Generar PDF?',
//        showDenyButton: true,
//        showCancelButton: true,
//        confirmButtonText: 'Generar',
//        denyButtonText: `No Guardar`,
//    }).then((result) => {
//        /* Read more about isConfirmed, isDenied below */
//        if (result.isConfirmed) {
//           // Swal.fire('Gauardado!', '', 'success')

//            var doc = new jsPDF();

//            doc.text(20, 20, 'Sujeto a disponibilidad Stock');

//           // doc.setFont("courier");
//           // doc.text(20, 30, 'This is courier normal.');

//            //doc.setFont("times");
//            //doc.setFontType("italic");
//            //doc.text(20, 40, 'This is times italic.');

//            //doc.setFont("helvetica");
//            //doc.setFontType("bold");
//            //doc.text(20, 50, 'This is helvetica bold.');
//            //doc.setFont("courier");
//            //doc.setFontType("bolditalic");
//            //doc.text(20, 60, 'This is courier bolditalic.');
//          //  doc.setFontType("bolditalic");
//          // doc.text(20, 120, 'Sujeto a disponibilidad Stock');
//            doc.save('Test.pdf');
//            if (doc) {
//                Swal.fire('Generado!',
//                    'ok',
//                    'success')
//            }
            
//        } else if (result.isDenied) {
//            Swal.fire('Cambios no Guardados', '', 'info')
//        }
//    })

//}

//async function motivo() {
//    console.log("EJECUTANDO ANULACION");
    
//    const { value: text } = await Swal.fire({
//        input: 'text',
//        inputLabel: 'Motivo',
//        inputPlaceholder: 'Escribe motivo de anulacion...',
//        inputAttributes: {
//            'aria-label': 'Type your message here'
//        },
//        showCancelButton: true
//    })

//    if (text) {
//        Swal.fire(text)
//    }
//}

//function AnularCotizacion() {
//    console.log("ejecutando alertar");
//    Swal.fire({
//        title: '¿Esta seguro en Anular Cotizacion?',
//        showDenyButton: true,
//        showCancelButton: true,
//        confirmButtonText: 'Guardar',
//        denyButtonText: `No Guardar`,
//    }).then((result) => {
//        /* Read more about isConfirmed, isDenied below */
//        if (result.isConfirmed) {
//            Swal.fire('Gauardado!', '', 'success')
//        } else if (result.isDenied) {
//            Swal.fire('Cambios no Guardados', '', 'info')
//        }
//    })

//}