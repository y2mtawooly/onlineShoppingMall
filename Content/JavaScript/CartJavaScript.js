function totalAmount() {

    var table = document.getElementById("tableBody");
    var total = 0;
    for (let l = 1; l < table.rows.length; l++) {
        total += parseInt(table.rows[l].cells[3].innerHTML);
    }
    document.getElementById("total").innerHTML = total;
}

function TaxRate(stock, deleteNum) {
    var stockCount =  stock + 1;
    var table = document.getElementById("tableBody");
    for (let i = 1; i < table.rows.length; i++) {

        for (var p = 0; p < table.rows.length; p++) {

            var selectId = "select_" + (deleteNum + p); // select 태그의 id 값

            for (var j = 1; j < stockCount; j++) {
                var select = document.getElementById(selectId);
                var selectOption = document.createElement("option");

                select.appendChild(selectOption);

                selectOption.value = [j];
                selectOption.innerHTML = [j];
            }
    }
        
    }
}

window.addEventListener("load", function () {
    var stockValue = document.getElementById("stock").innerHTML;
    var stock = parseInt(stockValue);

    var deleteId = document.getElementById("delete").innerHTML;
    var deleteNum = parseInt(deleteId);
    TaxRate(stock, deleteNum);
});
    

function countUpdateAndgetItemId(selectElement, price, totalElementId) {

    var count = selectElement.value;
    var total = price * count;

    document.getElementById(totalElementId).innerHTML = total;
    // 선택한 select 태그와 같은 줄에 있는 td 태그 중 5번째 td 태그를 찾아서 total 값을 설정합니다.
    selectElement.parentElement.nextElementSibling.nextElementSibling.nextElementSibling = total;

    var table = document.getElementById("tableBody");
    var totalAmount = 0;
    for (let i = 1; i < table.rows.length; i++) {
        totalAmount += parseInt(table.rows[i].cells[3].innerHTML);
    }
    document.getElementById("total").innerHTML = totalAmount;
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

function deleteItem(itemId) {

    var requestData = {
        "Id": itemId,
        "UserAccountIdGoodsId": 0,
        "SaleId": 0,
        "ConsumptionTaxId": 0,
        "AddDate": "",
        "AddBy": "",
        "UpdateDate": "",
        "UpdateBy": ""
    }
    var uri = 'Delete';
    $.ajax({
        url: uri,
        method: "POST",
        data: requestData,
        headers: {
            'Accept': 'application/json'
        }
    }).then(function (r) {
        var json = JSON.parse(r);

    }, function (e) {
        alert("error: " + e);
    });

    $(location).attr("href", "https://localhost:44376/Home/Cart");
}