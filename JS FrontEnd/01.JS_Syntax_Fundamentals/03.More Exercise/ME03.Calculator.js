function getResult(a, operator, b) {
    let sum = (a, b) => (a + b).toFixed(2);
    let subtract = (a, b) => (a - b).toFixed(2);
    let multiply = (a, b) => (a * b).toFixed(2);
    let divide = (a, b) => (a / b).toFixed(2);

    let result;

    switch (operator) {
        case '+':
            result = sum(a, b);
            break;
        case '-':
            result = subtract(a, b);
            break;
        case '*':
            result = multiply(a, b);
            break;
        case '/':
            result = divide(a, b);
            break;
    }

    console.log(result);
}

getResult(5,
    '+',
    10
);

getResult(25.5,
    '-',
    3
);
