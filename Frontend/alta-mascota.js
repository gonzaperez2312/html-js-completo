document.addEventListener("DOMContentLoaded", function(event) {
    console.info("Pruebas")
});

document.getElementById('formularioMascota').addEventListener('submit', function(event) {
    event.preventDefault(); // Prevenir el envío del formulario normal

    // Obtener los valores de los campos
    const nombre = document.getElementById('nombre').value;
    const raza = document.getElementById('raza').value;
    const tipoMascota = document.getElementById('tipoMascota').value;
    const localidad = document.getElementById('localidad').value;
    const calle = document.getElementById('calle').value;
    const altura = document.getElementById('altura').value;
    const descripcion = document.getElementById('descripcion').value;

    // Crear un objeto con los datos
    const datos = {
        nombre: nombre,
        raza: raza,
        tipoMascota: tipoMascota,
        localidad: localidad,
        calle: calle,
        altura: parseInt(altura),
        descripcion: descripcion
    };

    // Enviar los datos a una API REST (sustituye la URL por la de tu API)
    fetch('https://localhost:7000/api/mascotas', {
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
        document.getElementById('formularioMascota').reset(); // Limpiar formulario
    })
    .catch(error => {
        // Manejar errores aquí
        console.error('Error al enviar los datos:', error);
        alert('Hubo un error al procesar el registro');
    });
});

