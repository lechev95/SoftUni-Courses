function printAndSum(start, end) {
    let sum = 0;
    let result = "";
    for (let index = start; index <= end; index++) {
        sum += index;
        result += index + " ";
    }

    console.log(result);
    console.log(`Sum: ${sum}`)
}

printAndSum(5, 10)
printAndSum(0, 26)
printAndSum(50, 60)