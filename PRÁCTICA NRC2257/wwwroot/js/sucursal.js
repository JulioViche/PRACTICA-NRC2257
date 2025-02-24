window.onload = () => {
    renderTable();
}

let config = {
    headers: ['#', 'Nombre', 'Dirección'],
    properties: ['id', 'nombre', 'direccion'],
    deletable: true
};

function renderTable() {
    if (!getValue('nombre-input') && !getValue('direccion-input'))
        listar();
    else
        filtrar();
}

async function listar() {
    config.url = 'Sucursal/listar';
    config.method = 'get';
    createTable(config);
}

async function filtrar() {
    let form = new FormData(document.getElementById('search-form'));
    config.url = 'Sucursal/filtrar';
    config.method = 'post';
    createTable(config, form);
}

async function guardar() {
    if (!getValue('nombre-input') || !getValue('direccion-input')) return;

    let form = new FormData(document.getElementById('search-form'));
    config.url = 'Sucursal/guardar';
    config.method = 'post';
    fetchPost(config.url, 'text', form, res => {
        limpiar();
    });
}

function limpiar() {
    document.getElementById('search-form').reset();
    renderTable();
}