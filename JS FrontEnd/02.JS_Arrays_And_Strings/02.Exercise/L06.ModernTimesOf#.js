function hashtag(sentence) {
    let words = sentence.split(' ');
    for (const word of words) {
        if (word.startsWith('#') && word.length > 1) {
            const ascii = word.charCodeAt(1);
            const isLetter = ascii >= 65 && ascii <= 90 ||
                ascii >= 97 && ascii <= 122;
            if (isLetter) {
                console.log(word.substring(1));
            }
        }
    }
}

hashtag('Nowadays everyone uses # to tag a #special word in #socialMedia');
hashtag('The symbol # is known #variously in English-speaking #regions as the #number sign');