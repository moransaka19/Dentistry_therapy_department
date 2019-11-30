// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function search() {
    var input = document.getElementById('input');
    var target = input.value.toUpperCase();
    //alert(target)
    //var tabl = document.getElementsByClassName("tbody");
    var tr = document.getElementsByClassName('123');

    for (var i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName('td')[0, 1, 2, 3, 4, 5];
        txtValue = td.textContent || td.innerText;
        //alert(txtValue)
        if (txtValue.toUpperCase().indexOf(target) > -1) {
            tr[i].style.color = 'red'

        }
    }
}

function remove() {

    var tr = document.getElementsByClassName("123")
    //var tr = tabl.getElementsByTagName('tr')

    for (var i = 0; i < tr.length; i++) {
        tr[i].style.color = 'black'
    }
}