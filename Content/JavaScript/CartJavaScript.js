function totalAmount() {
    var table = document.getElementById("tableBody");
    var total = 0;
    for (let i = 1; i < table.rows.length; i++) {
        total += parseInt(table.rows[i].cells[4].innerHTML);
    }
    document.getElementById("total").innerHTML = total + "円";
}

function countUpdateAndgetItemId(selectElement, price, totalElementId) {
    var count = selectElement.value;
    var total = price * count;

    document.getElementById(totalElementId).innerHTML = total;
    // 선택한 select 태그와 같은 줄에 있는 td 태그 중 5번째 td 태그를 찾아서 total 값을 설정합니다.
    selectElement.parentElement.nextElementSibling.nextElementSibling.nextElementSibling = total;

    var table = document.getElementById("tableBody");
    var totalAmount = 0;
    for (let i = 1; i < table.rows.length; i++) {
        totalAmount += parseInt(table.rows[i].cells[5].innerHTML);
    }
    document.getElementById("total").innerHTML = totalAmount + "円";
}

function updateCheckedCount() {
    var count = 0;
    var total = 0;
    $('#tableBody input[type=checkbox]').each(function () {
        if (this.checked) {
            var row = $(this).closest('tr');
            var price = parseFloat(row.find('td:eq(4)').text());
            var quantity = parseInt(row.find('select').val());
            total += price * quantity;
            count++;
        }
    });
    $('#checkedCount').text(count);
    $('#total').text(total);
}


function toggleCheckboxes() {
    var checkboxes = document.querySelectorAll('input[type="checkbox"]');
    var checkedCount = document.querySelectorAll('input[type="checkbox"]:checked').length;
    var shouldCheck = checkedCount !== checkboxes.length; // true: check all, false: uncheck all

    for (var i = 0; i < checkboxes.length; i++) {
        checkboxes[i].checked = shouldCheck;
    }
    var count = 0;
    var total = 0;
    $('#tableBody input[type=checkbox]').each(function () {
        if (this.checked) {
            var row = $(this).closest('tr');
            var price = parseFloat(row.find('td:eq(4)').text());
            var quantity = parseInt(row.find('select').val());
            total += price * quantity;
            count++;
        }
    });
    $('#checkedCount').text(count);
    $('#total').text(total);
    document.getElementById("checkedCount").textContent = shouldCheck ? count : 0;
}
