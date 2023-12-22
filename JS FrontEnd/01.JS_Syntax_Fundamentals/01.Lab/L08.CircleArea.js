function getArea(num) {
    if (typeof (num) === 'number') {
        console.log((Math.pow(num, 2) * Math.PI).toFixed(2));
    } else {
        console.log(`We can not calculate the circle area, because we receive a ${typeof (num)}.`);
    }
}

getArea(5)
getArea('name')
getArea(true)
getArea([1, 2, 3])
getArea(['John', 18])