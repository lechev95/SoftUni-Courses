function addItem() {
    const inputElement = document.getElementById('newItemText');
    const itemListElement = document.getElementById('items');

    const newItemElement = document.createElement('li');
    newItemElement.textContent = inputElement.value;

    if(inputElement.value !== ''){
        itemListElement.appendChild(newItemElement);
    }

    inputElement.value = '';
}