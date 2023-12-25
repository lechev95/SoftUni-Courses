function getText(text, word) {
    const wordLength = word.length;
    const stars = '*'.repeat(wordLength);

    const replacedText = text.replace(new RegExp(word, 'gi'), stars);
    console.log(replacedText);
}

getText('A small sentence with some words',

    'small');
getText('Find the hidden word', 'hidden');