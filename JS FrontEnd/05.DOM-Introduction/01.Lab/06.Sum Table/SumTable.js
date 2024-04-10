function sumTable() {
    const tdCostElement = document.querySelectorAll('tr td:last-of-type:not(#sum)');
    const tdSumElement = document.getElementById('sum');

    tdSumElement.textContent = Array
        .from(tdCostElement)
        .reduce((sum, element) => sum + Number(element.textContent), 0);

}