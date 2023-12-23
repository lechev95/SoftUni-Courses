function getResult(num, ...operations) {
    let number = Number(num);
    operations.forEach((operation) => {
        switch (operation) {
            case "chop":
                number /= 2;
                break;
            case "dice":
                number = Math.sqrt(number);
                break;
            case "spice":
                number++;
                break;
            case "bake":
                number *= 3;
                break;
            case "fillet":
                number -= number * 0.2;
                break;
        }

        console.log(number);
    });
}

getResult('32', 'chop', 'chop', 'chop', 'chop', 'chop');
getResult('9', 'dice', 'spice', 'chop', 'bake', 'fillet');