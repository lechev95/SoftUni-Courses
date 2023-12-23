function validityChecker(x1, y1, x2, y2) {
    function calculateDistance(x1, y1, x2, y2) {
        return Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));
    }

    function isValidDistance(x1, y1, x2, y2) {
        const distance = calculateDistance(x1, y1, x2, y2);
        return Number.isInteger(distance);
    }

    let firstToOrigin = isValidDistance(x1, y1, 0, 0);
    let secondToOrigin = isValidDistance(x2, y2, 0, 0);
    let firstToSecond = isValidDistance(x1, y1, x2, y2);

    if (firstToOrigin) {
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }

    if (secondToOrigin) {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    } else {
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }

    if (firstToSecond) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}

validityChecker(3, 0, 0, 4);
validityChecker(2, 1, 1, 1);