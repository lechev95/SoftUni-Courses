function sort(arr) {
    let array = [];
    arr.sort((a, b) => a - b);
    while (arr.length !== 0) {
        array.push(arr.shift());
        array.push(arr.pop());
    }
    return array;
}

sort([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);