function getResult(arr) {
    let result = 0;
    for (let i = 0; i < arr.length; i++) {
        arr[i] = Number(arr[i]);
        if (arr[i] % 2 == 0) {
            result += arr[i];
        } else {
            result -= arr[i];
        }
    }

    console.log(result);
}

getResult([1, 2, 3, 4, 5, 6]);
getResult([3, 5, 7, 9]);
getResult([2, 4, 6, 8, 10]);