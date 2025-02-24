window.onload = () => {
    renderTable();
}

let config = {
    headers: ['#', 'Nombre', 'Dirección', 'Persona de contacto'],
    properties: ['id', 'nombre', 'direccion', 'contacto'],
};

function renderTable() {
    if (!getValue('nombre-input') && !getValue('direccion-input') && !getValue('contacto-input'))
        listar();
    else
        filtrar();
}

async function listar() {
    config.url = 'Laboratorio/listar';
    config.method = 'get';
    createTable(config);
}

async function filtrar() {
    let form = new FormData(document.getElementById('search-form'));
    config.url = 'Laboratorio/filtrar';
    config.method = 'post';
    createTable(config, form);
}

function limpiar() {
    document.getElementById('search-form').reset();
    renderTable();
}