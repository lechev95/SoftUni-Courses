function isLeapYear(year) {
    let result;
    if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0) {
        result = "yes";
    } else {
        result = "no";
    }

    console.log(result);
}

isLeapYear(1984);
isLeapYear(2003);
isLeapYear(4);