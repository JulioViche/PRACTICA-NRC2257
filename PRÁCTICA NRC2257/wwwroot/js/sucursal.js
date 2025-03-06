window.onload = () => {
    renderTable();
}

let config = {
    headers: ['#', 'Nombre', 'Dirección'],
    properties: ['id', 'nombre', 'direccion'],
    idProperty: 'id',
    editable: true,
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
    if (!getValue('modal-nombre-input') || !getValue('modal-direccion-input')) {
        alert('Campos vacíos');
        return;
    }

    confirmacion('¿Desea guardar el registro?', '', () => {
        let form = new FormData(document.getElementById('modal-form'));
        config.url = 'Sucursal/guardar';
        config.method = 'post';

        fetchPost(config.url, 'text', form, res => {
            renderTable();
            exito('Guardado', 'Registro guardado exitosamente');
        });

    });

    $('#save-modal').modal('hide');
}

async function editar(id) {
    document.getElementById('modal-label').textContent = 'Editar Sucursal';
    document.getElementById('modal-id-group').style.display = 'block';
    config.url = 'Sucursal/recuperar?id=' + id;
    config.method = 'get';
    fetchGet(config.url, 'json', res => {
        setValue('modal-id-input', res['id']);
        setValue('modal-nombre-input', res['nombre']);
        setValue('modal-direccion-input', res['direccion']);
    });
    $('#save-modal').modal('show');
}

async function eliminar(id, nombre) {
    confirmacion('¿Desea eliminar el registro ' + nombre + '?', 'No es revertible', () => {
        config.url = 'Sucursal/eliminar?id=' + id;
        config.method = 'get';
        fetchGet(config.url, 'text', res => {
            renderTable();
        });
        exito('Eliminado', 'Registro eliminado exitosamente');
    });
}

async function crear(id) {
    document.getElementById('modal-label').textContent = 'Crear Sucursal';
    document.getElementById('modal-id-group').style.display = 'none';
    document.getElementById('modal-form').reset();
    setValue('modal-id-input', 0);
    $('#save-modal').modal('show');
}

function limpiar() {
    document.getElementById('search-form').reset();
    renderTable();
}