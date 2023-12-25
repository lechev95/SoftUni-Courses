function getWord(word, start, end) {
    let result = word.substr(start, end);
    console.log(result);
}

getWord('ASentence', 1, 8);
getWord('SkipWord', 4, 7);