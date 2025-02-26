toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": false,
    "progressBar": false,
    "positionClass": "toast-top-right",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}

async function fetchGet(url, type, callback) {
    try {
        let root = document.getElementById('root').value;
        let absoluteUrl = window.location.protocol + '//' + window.location.host + '/' + root + url;
        let res = await fetch(absoluteUrl);

        if (type === 'json') res = await res.json();
        if (type === 'text') res = await res.text();

        callback(res);

    } catch (error) {
        alert(error);
    }
}

async function fetchPost(url, type, form, callback) {
    try {
        let root = document.getElementById('root').value;
        let absoluteUrl = window.location.protocol + '//' + window.location.host + '/' + root + url;
        let res = await fetch(absoluteUrl, {
            method: 'POST',
            body: form
        });

        if (type === 'json') res = await res.json();
        if (type === 'text') res = await res.text();

        callback(res);
    } catch (error) {
        alert(error);
    }
}

function getValue(id) {
    return document.getElementById(id).value;
}

function setValue(id, value) {
    document.getElementById(id).value = value;
}

function createTable(config, form) {
    let tableContainer = document.getElementById('datatable-container');
    let table = document.getElementById('datatable');

    if (!table) {
        table = document.createElement('table');
        table.setAttribute('id', 'datatable');
        table.classList.add('table', 'table-sm', 'table-hover', 'table-responsive', 'w-100');
        tableContainer.appendChild(table);
    }

    if (config.method === 'get')
        fetchGet(config.url, 'json', res => table.innerHTML = generateTableContent(config, res));
    if (config.method === 'post')
        fetchPost(config.url, 'json', form, res => table.innerHTML = generateTableContent(config, res));
}

function generateTableContent(config, res) {
    let content = '';

    content += '<thead><tr>';
    for (header of config.headers) content += `<th class="px-lg-3 px-1">${header}</th>`;
    content += config.editable ? '<th></th>' : '';
    content += '</tr></thead>';

    content += '<tbody class"table-group-divider">';
    for (obj of res) {
        content += '<tr>';
        for (property of config.properties) content += `<td class="px-lg-3 px-1">${obj[property]}</td>`;
        if (config.editable || config.deletable) {
            content += '<td>';
            if (config.editable) content += `<a title="Editar" class="px-2 text-primary" onclick="editar(${obj[config.idProperty]})"><i class="fa-solid fa-pen-to-square"></i></a>`;
            if (config.deletable) content += `<a title="Eliminar" class="px-2 text-danger" onclick="eliminar(${obj[config.idProperty]}, '${obj['nombre']}')"><i class="fa-solid fa-trash-can"></i></a>`;
            content += '</td>';
        }
        content += '</tr>';
    }
    content += '</tbody>';

    return content;
}

function confirmacion(titulo = 'Confirmación', texto = 'No se puede revertir', callback) {
    Swal.fire({
        title: titulo,
        text: texto,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Sí",
        cancelButtonText: "No"
    }).then((result) => {
        if (result.isConfirmed) {
            callback();
        } else {
            error('Cancelado', 'Acción cancelada');
        }
    });
}

function error(titulo, texto) {
    toastr.error(texto, titulo);
}
function exito(titulo, texto) {
    toastr.success(texto, titulo);
}