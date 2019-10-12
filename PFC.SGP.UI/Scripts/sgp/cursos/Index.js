$("#modalCadastroCurso").on('hide.bs.modal', function () {
    $('#UserFeedback').text('')
});
$("#editModal").on('hide.bs.modal', function () {
    $('#UserFeedbackEdit').text('')
});
$('#editModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var id = button.data('id-curso')
    var nome = button.data('nome-curso') // Extract info from data-* attributes
    var qtd = button.data('qtd-curso')
    // If necessary, we could initiate an AJAX request here (and then do the updating in a callback).
    var modal = $(this)
    modal.find('#modal-title-aluno').text('Editando curso "' + nome + '"')
    modal.find('#inputEditId').val(id)
    modal.find('#inputEditNome').val(nome)
    modal.find('#inputEditQtdSemestres').val(qtd)
})
function ConfirmDelCurso(id, nome) {
    $('#nomeCursoModal').text(nome)
    $('#delModal').data('id', id).modal('show')
}

function DelCurso() {
    let id = $('#delModal').data('id');
    let xhr = new XMLHttpRequest(); // Api para requisição ajax
    const url = `/Cursos/DelCurso/${id}`

    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 404) {
            toastr.error('Curso não encontrado na base de dados.', 'Operação mal-sucedida')
            $('#delModal').data('id', '0').modal('hide')
        }
        if (this.readyState === 4 && this.status === 400) {
            $('#delModal').data('id', '0').modal('hide')
            toastr.error('Não se pode deletar um curso com uma turma atrelada.', 'Operação mal-sucedida')
        }
        if (this.readyState === 4 && this.status === 200) {
            let tr = document.querySelector(`#curso-${id}`);
            if (tr != null) {
                let id = $('#delModal').data('id');
                var table = $('#table_id').DataTable();
                table.row(`#curso-${id}`).remove().draw()
            }
            $('#delModal').data('id', '0').modal('hide')
            toastr.success('Curso excluído da base de dados.', 'Operação bem sucedida')
        }
    }

    xhr.open('get', url) // Iniciar Solicitação | 'via url'
    xhr.send() // Envia para o servidor
}

$('#modalInfoCoordenador').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var codigo = button.data('codigo') // Extract info from data-* attributes
    var nome = button.data('nome')
    var sobrenome = button.data('sobrenome')
    var email = button.data('email')
    var telefone = button.data('telefone')
    // If necessary, we could initiate an AJAX request here (and then do the updating in a callback).
    var modal = $(this)
    modal.find('.modal-title').text('Detalhes do coordenador "' + nome + '"')
    modal.find('#txtCodigo').val(codigo)
    modal.find('#txtNome').val(nome)
    modal.find('#txtSobrenome').val(sobrenome)
    modal.find('#txtEmail').val(email)
    modal.find('#txtTelefone').val(telefone)
})

$(document).ready(function () {
    $('#table_id').dataTable({
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