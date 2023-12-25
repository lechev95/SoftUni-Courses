function print(array, step) {
    let newArr = [];
    for (let i = 0; i < array.length; i += step) {
        newArr.push(array[i]);
    }

    //console.log(newArr.join("\n"));
    return newArr;
}

print(['5',

    '20',

    '31',

    '4',

    '20'],

    2);

print(['dsa', 'asd', 'test', 'tset'], 2);

print(['1', '2', '3', '4', '5'], 6);