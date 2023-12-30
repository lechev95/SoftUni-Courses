function signCheck(num1, num2, num3){
    let sign = '';
    if(num1 >= 0){
        if((num2>=0 && num3 >=0) || (num2<0 && num3<0)){
            sign = "Positive";
        } else {
            sign = "Negative";
        }
    } else {
        if((num2>=0 && num3<0) || (num2<0 && num3>=0)){
            sign = "Positive";
        } else{
            sign = "Negative";
        }
    }

    return sign;
}
