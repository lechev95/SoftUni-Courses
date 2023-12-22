function mathOper(fNum, sNum, oper) {
    let result;
    switch (oper) {
        case '+':
            result = fNum + sNum;
            break;
        case '-':
            result = fNum - sNum;
            break;
        case '*':
            result = fNum * sNum;
            break;
        case '/':
            result = fNum / sNum;
            break;
        case '%':
            result = fNum % sNum;
            break;
        case '**':
            result = fNum ** sNum;
            break;
    }
    console.log(result)
}

mathOper(2, 3, '**')
mathOper(2, 3, '*')
mathOper(2, 3, '/')
mathOper(2, 3, '+')