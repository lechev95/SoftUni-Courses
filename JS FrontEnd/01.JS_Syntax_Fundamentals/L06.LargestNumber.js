function largest(fNum, sNum, tNum) {
    let result;
    if (fNum >= sNum && fNum >= tNum) {
        result = fNum;
    } else if (sNum >= fNum && sNum >= tNum) {
        result = sNum
    }
    else {
        result = tNum
    }
    console.log(`The largest number is ${result}.`)
}

largest(55, 22, 16)