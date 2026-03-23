// wwwroot/js/peliculas.js
document.addEventListener('DOMContentLoaded', () => {
    // 1. Determinar qué estamos cargando
    const idEstado = window.location.href.includes('cartelera') ? 1 : 2;

    // 2. Hacer la petición a tu PeliculasApiController
    fetch(`/api/PeliculasApi/${idEstado}`)
        .then(res => res.json())
        .then(data => {
            let html = '';
            data.forEach(p => {
                // Usamos los nombres de propiedades que devuelve tu DAO/Modelo
                html += `
                    <div class="peli-item">
                        <br/>
                        <img src="img/pelicula/${p.id}.jpg" alt="${p.titulo}"/>
                        <div class="datos-pelicula">
                            <h2>${p.titulo}</h2><br/>
                            <p>${p.sinopsis}</p>
                            <br/>
                            <a href="pelicula.html?id=${p.id}">
                                <img src="img/varios/btn-ver-detalle.png" width="120" height="30" alt="Ver detalle"/>
                            </a>
                        </div>
                    </div>`;
            });
            document.getElementById('contenedor-peliculas').innerHTML = html;
        })
        .catch(err => console.error("Error cargando películas:", err));
});