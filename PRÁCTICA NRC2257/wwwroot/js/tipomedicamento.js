window.onload = () => {
    renderTable();
}

let config = {
    headers: ['#', 'Nombre', 'Descripción'],
    properties: ['id', 'nombre', 'descripcion'],
    idProperty: 'id',
    editable: true,
    deletable: true
};

function renderTable() {
    if (!getValue('descripcion-input'))
        listar();
    else
        filtrar();
}

async function listar() {
    config.url = 'TipoMedicamento/listar';
    config.method = 'get';
    createTable(config);
}

async function filtrar() {
    let form = new FormData(document.getElementById('search-form'));
    config.url = 'TipoMedicamento/filtrar';
    config.method = 'post';
    createTable(config, form);
}

async function guardar() {
    if (!getValue('nombre-input') || !getValue('descripcion-input')) return;

    let form = new FormData(document.getElementById('search-form'));
    config.url = 'TipoMedicamento/guardar';
    config.method = 'post';
    fetchPost(config.url, 'text', form, res => {
        limpiar();
    });
}

async function editar(id) {
    config.url = 'TipoMedicamento/recuperar?id=' + id;
    config.method = 'get';
    fetchGet(config.url, 'json', res => {
        setValue('id-input', res['id']);
        setValue('nombre-input', res['nombre']);
        setValue('descripcion-input', res['descripcion']);
    });
}

function limpiar() {
    document.getElementById('search-form').reset();
    renderTable();
}