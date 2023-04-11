function countUpdate(selectElement, price, totalElementId) {
    var count = selectElement.value;
    var total = price * count;
    document.getElementById(totalElementId).textContent = total;
}
