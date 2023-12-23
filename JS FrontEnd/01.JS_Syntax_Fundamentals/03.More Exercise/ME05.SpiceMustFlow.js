function getResult(yield) {
    let totalAmount = 0;
    let days = 0;

    while (yield >= 100) {
        totalAmount += yield;
        yield -= 10;
        totalAmount -= 26;
        days++;
        if (yield < 100) {
            totalAmount -= 26;
        }
    }

    console.log(days);
    console.log(totalAmount);
}

getResult(111);
getResult(450);