function getCount(text, search) {
    let words = text.split(' ');
    let counter = 0;
    for (const word of words) {
        if (word === search) {
            counter++;
        }
    }

    console.log(counter);
}

getCount('softuni is great place for learning new programming languages', 'softuni');
getCount('This is a word and it also is a sentence', 'is');