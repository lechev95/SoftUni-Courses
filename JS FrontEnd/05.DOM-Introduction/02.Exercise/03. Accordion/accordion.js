function toggle() {
    const toggleButtonElement = document.querySelector('.head span.button');
    const extraInfoElement = document.getElementById('extra');

    const currButtonText = toggleButtonElement.textContent;
    if(currButtonText === 'More'){
        extraInfoElement.style.display = 'block';
        toggleButtonElement.textContent = 'Less';
    } else if(currButtonText === 'Less'){
        extraInfoElement.style.display = 'none';
        toggleButtonElement.textContent = 'More';
    }

}