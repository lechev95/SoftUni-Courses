function subtract() {
    const fNum = Number(document.getElementById('firstNumber').value);
    const sNum = Number(document.getElementById('secondNumber').value);
    const result = document.getElementById('result');

    result.textContent = fNum - sNum;
}