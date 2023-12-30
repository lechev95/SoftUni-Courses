function getCalc(a, b, action) {
    switch (action.toLowerCase()) {
        case "multiply":
            let multiply = (a, b) => a * b;
            return multiply(a, b);
        case "divide":
            let divide = (a, b) => a / b;
            return divide(a, b);
        case "add":
            let add = (a, b) => a + b;
            return add(a, b);
        case "subtract":
            let subtract = (a, b) => a - b;
            return subtract(a, b);
    }
}

console.log(getCalc(5, 5, "multiply"));

