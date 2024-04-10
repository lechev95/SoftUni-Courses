function colorize() {
    const evenRowElements = Array.from(document.querySelectorAll('table tr:nth-child(2n)'));
    evenRowElements.forEach(element => element.style.backgroundColor = 'teal');
}