$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": 'Tables/GetAllTables',
            "type": "GET",
            "datatype": "json",
            "dataSrc": "data",
        },
        "columns": [
            { "data": 'tableNumber', "width": "2%" },
            { "data": 'numberOfSeats', "width": "5%" },
            {
                "data": 'isAvailable',
                "width": "10%",
                "render": function (data, type, row) {
                    return data ? 'Yes' : 'No'; // If true, show "Yes", else "No"
                }
            },
            {
                "data": 'id',
                "render": function (data, type, row) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <a href="Tables/Edit?id=${row.id}" class="btn btn-primary mx-2">
                                <i class="bi bi-pencil-square"></i> Edit
                            </a>
                            <a href="Tables/Delete?id=${row.id}" class="btn btn-danger mx-2">
                                <i class="bi bi-trash-fill"></i> Delete
                            </a>
                        </div>
                    `;
                },
                "width": "35%"
            }
        ]
    });
}
