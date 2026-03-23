// wwwroot/js/peliculas.js
document.addEventListener('DOMContentLoaded', () => {
    const idEstado = window.location.href.includes('cartelera') ? 1 : 2;

    fetch(`/api/PeliculasApi/${idEstado}`)
        .then(res => res.json())
        .then(data => {
            let html = '';
            data.forEach(p => {
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
