function match(word, text) {
    let lWord = word.toLowerCase();
    let lText = text.toLowerCase();
    let index = lText.indexOf(lWord);
    if (index !== -1) {
        console.log(word);
    } else {
        console.log(`${word} not found!`);
    }
}

match('javascript', 'JavaScript is the best programming language');
match('python', 'JavaScript is the best programming language');