document.addEventListener("DOMContentLoaded", function(event) {
    console.info("Ya se cargo todo el contenido del html");

    //Todo el codigo necesario cuando termina de cargar el html
});

document.getElementById('registroForm').addEventListener('submit', function(event) {
    event.preventDefault(); // Prevenir el envío del formulario normal

    // Obtener los valores de los campos
    const nombre = document.getElementById('nombre').value;
    const apellido = document.getElementById('apellido').value;
    const email = document.getElementById('email').value;

    // Crear un objeto con los datos
    const datos = {
        Nombre: nombre,
        Apellido: apellido,
        CorreoElectronico: email
    };

    // Enviar los datos a una API REST (sustituye la URL por la de tu API)
    fetch('http://localhost:5133/usuarios', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(datos)
    })
    .then(response => response.json())
    .then(data => {
        // Manejar la respuesta de la API aquí
        console.log('Respuesta de la API:', data);
        alert('Registro exitoso');
    })
    .catch(error => {
        // Manejar errores aquí
        console.error('Error al enviar los datos:', error);
        alert('Hubo un error al procesar el registro');
    });
});