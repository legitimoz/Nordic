////console.log("EN VISOR SINCRO");
//document.querySelector('#botonAlertar').addEventListener('click', alertar);
//verificamos que exista 
//var archivo = document.getElementById("botonAprobar1");
//if (archivo) {
//    document.querySelector('#botonAprobar1').addEventListener('click', Aprobar);
//    document.querySelector('#botonAprobar2').addEventListener('click', Aprobar);
//    document.querySelector('#botonAprobar3').addEventListener('click', Aprobar);
//    document.querySelector('#botonRechazar1').addEventListener('click', Rechazar);
//    document.querySelector('#botonRechazar2').addEventListener('click', Rechazar);
//    document.querySelector('#botonRechazar3').addEventListener('click', Rechazar);
//}




//function Aprobar() {
//    console.log("ejecutando alertar");
//    Swal.fire({
//        title: '¿Esta seguro de Aprobar Pedido?',
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

//function Rechazar() {
//    console.log("ejecutando alertar");
//    Swal.fire({
//        title: '¿Esta seguro en Rechazar Pedido?',
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