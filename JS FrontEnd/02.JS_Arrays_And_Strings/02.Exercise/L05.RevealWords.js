function reveal(words, text) {
    words = words.split(", ");
    for (const word of words) {
        text = text.replace('*'.repeat(word.length), word);
    }

    console.log(text)
}

reveal('great', 'softuni is ***** place for learning new programming languages');
reveal('great, learning', 'softuni is ***** place for ******** new programming languages');