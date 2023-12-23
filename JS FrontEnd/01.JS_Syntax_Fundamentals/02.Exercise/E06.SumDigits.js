function sum(num) {
    let sum = 0;
    while (num > 0) {
        sum += Math.floor(num) % 10;
        num /= 10;
    }

    console.log(sum);
}

sum(245678)
sum(97561)
sum(543)