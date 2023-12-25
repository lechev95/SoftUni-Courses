function getResult(n, arr) {
    let newArr = [];
    for (let i = 0; i < n; i++) {
        newArr.push(arr[i]);
    }

    newArr.reverse();
    let output = "";
    for (const el of newArr) {
        output += el + " ";
    }

    console.log(output);
}

getResult(3, [10, 20, 30, 40, 50]);
getResult(4, [-1, 20, 99, 5]);
getResult(2, [66, 43, 75, 89, 47]);