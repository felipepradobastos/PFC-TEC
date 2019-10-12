$("#modalCadastroTurma").on('hide.bs.modal', function () {
    $('#UserFeedback').text('')
});
$("#editModalTurma").on('hide.bs.modal', function () {
    $('#UserFeedbackEdit').text('')
});
$(document).ready(function () {
    $('.selectpicker').selectpicker({
        noneSelectedText: 'Nada selecionado',
        noneResultsText: 'Nada encontrado',
        countSelectedText: '{0} de {1} selecionados'
    });
});

$('#editModalTurma').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var id = button.data('id-turma')
    var cod = button.data('cod-turma') // Extract info from data-* attributes
    // If necessary, we could initiate an AJAX request here (and then do the updating in a callback).
    var modal = $(this)
    modal.find('#modal-title-edit-turma').text('Editando turma "' + cod + '"')
    modal.find('#inputEditIdTurma').val(id)
    modal.find('#inputEditCodigoTurma').val(cod)
})

function ConfirmDelTurma(id, cod) {

    $('#codTurmaModal').text(cod)
    $('#delModal').data('id', id).modal('show')
}

function DelTurma() {
    let id = $('#delModal').data('id');
    let xhr = new XMLHttpRequest(); // Api para requisição ajax
    const url = `/Turmas/DelTurma/${id}`

    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 404) {
            toastr.error('Turma não encontrada na base de dados.', 'Operação mal-sucedida')
            $('#delModal').data('id', '0').modal('hide')
        }
        if (this.readyState === 4 && this.status === 400) {
            $('#delModal').data('id', '0').modal('hide')
            toastr.error('Não se pode deletar uma turma com algum aluno ativo.', 'Operação mal-sucedida')
        }
        if (this.readyState === 4 && this.status === 200) {
            let tr = document.querySelector(`#turma-${id}`);
            if (tr != null) {
                let id = $('#delModal').data('id');
                var table = $('#table_id').DataTable();
                table.row(`#turma-${id}`).remove().draw()
            }
            $('#delModal').data('id', '0').modal('hide')
            toastr.success('Turma excluída da base de dados.', 'Operação bem sucedida')
        }
    }

    xhr.open('get', url) // Iniciar Solicitação | 'via url'
    xhr.send() // Envia para o servidor
}

$(document).ready(function () {
    myTable = $('#table_id').DataTable({
        "language": {
            "sEmptyTable": "Nenhum registro encontrado",
            "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
            "sInfoFiltered": "(Filtrados de _MAX_ registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "_MENU_ resultados por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Próximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Último"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });

});