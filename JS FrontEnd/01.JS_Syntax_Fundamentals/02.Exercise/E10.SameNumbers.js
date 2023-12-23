function getSameNums(number){
    const numStr = number.toString();
    const firstDigit = numStr[0];
    
    const allSame = numStr.split('').every(digit => digit === firstDigit);
    console.log(allSame);
    
    const digitSum = numStr.split('').reduce((sum, digit) => sum + parseInt(digit), 0);
    console.log(digitSum);
}

getSameNums(2222222);
getSameNums(1234);