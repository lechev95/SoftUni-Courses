function getUppercase(text) {
    return text
        .match(/[a-zA-Z0-9]+/g)
        .join(', ')
        .toUpperCase();
}

getUppercase('Hi, how are you?');
getUppercase('hello');