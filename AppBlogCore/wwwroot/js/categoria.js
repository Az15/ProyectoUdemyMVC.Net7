var dataTable;

$(document).ready(function () {
    cargarDatatable();
})

function cargarDatatable() {
    dataTable = $("#tblCategorias").DataTable({
        "ajax": {
            "url": "/admin/categorias/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "5%", },
            { "data": "nombre", "width": "50%", },
            { "data": "orden", "width": "20%", },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center" >
                                <a href="/Admin/Categorias/Edit/${data}" class="btn btn-success text-black" style= "cursor:pointer; width:100px;">
                                <i class= "far fa-edit"></i>Editar
                                </a>
                                &nbsp;
                                <a onclick="Delete(/Admin/Categorias/Edit/${data})" class="btn btn-danger text-black" style= "cursor:pointer; width:100px;">
                                <i class= "far fa-trash-alt"></i>Eliminar
                                </a>
                            </div>
                                                        `;  
                }, "width": "30%"

                }
        ],
        "language": {
            "decimal": "",
            "emptyTable": "No hay registros",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 de 0 en 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "width": "100%"


        });
}