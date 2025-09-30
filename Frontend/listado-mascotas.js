// Función para llenar la tabla de mascotas
function llenarTablaMascotas() {
    fetch('https://localhost:7000/api/mascotas') // URL de la API
    .then(response => response.json())
    .then(data => {
        var tablaMascotas = document.getElementById("cuerpoTabla");
        // Limpiar tabla antes de llenar
        tablaMascotas.innerHTML = '';
        
        data.forEach(mascota => {
            var fila = document.createElement("tr");
            fila.innerHTML = `
                <td>${mascota.codigo}</td>
                <td>${mascota.nombre}</td>
                <td>${mascota.tipoMascota}</td>
                <td>${mascota.raza}</td>
                <td>${mascota.localidad}</td>
                <td>${mascota.calle} ${mascota.altura}</td>
                <td>${mascota.descripcion || 'Sin descripción'}</td>
            `;
            tablaMascotas.appendChild(fila);
        });
    })
    .catch(error => {
        console.error('Error al obtener datos:', error);
        var mensajeDiv = document.getElementById('mensaje');
        mensajeDiv.textContent = 'Error de conexión. Verifique que la API esté ejecutándose.';
        mensajeDiv.className = 'mensaje error';
        mensajeDiv.style.display = 'block';
    });
}

// Llama a la función para llenar la tabla cuando el DOM esté listo
document.addEventListener("DOMContentLoaded", function() {
    console.log('Página de listado de mascotas cargada');
    
    // Obtener referencias a los elementos
    const btnCargarMascotas = document.getElementById('btnCargarMascotas');
    const btnActualizar = document.getElementById('btnActualizar');
    
    // Agregar eventos a los botones
    btnCargarMascotas.addEventListener('click', llenarTablaMascotas);
    btnActualizar.addEventListener('click', llenarTablaMascotas);
    
    // Cargar mascotas automáticamente al cargar la página
    llenarTablaMascotas();
});

