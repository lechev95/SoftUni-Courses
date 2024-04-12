function deleteByEmail() {
    const inputEmailElement = document.querySelector('input[name=email]');
    const resultElement = document.getElementById('result');
    const trElements = document.querySelectorAll('table#customers tbody tr');

    const resultTrElement = Array
                        .from(trElements)
                        .find(trElement => trElement.children[1].textContent.includes(inputEmailElement.value));


    if(resultTrElement){
        resultTrElement.remove();

        resultElement.textContent = 'Deleted.';
    } else{
        resultElement.textContent = 'Not found.';
    }

    inputEmailElement.value = '';
}