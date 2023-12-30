function formatGrade(grade) {
    let result;
    if (grade >= 2 && grade < 3) {
        result = `Fail (${grade})`;
    } else if (grade >= 3 && grade < 3.5) {
        result = `Poor (${grade.toFixed(2)})`;
    } else if (grade >= 3.5 && grade < 4.5) {
        result = `Good (${grade.toFixed(2)})`;
    }
    else if (grade >= 4.5 && grade < 5.5) {
        result = `Very good (${grade.toFixed(2)})`;
    }
    else if (grade >= 5.5 && grade <= 6) {
        result = `Excellent (${grade.toFixed(2)})`;
    }

    return result;
}

console.log(formatGrade(3.33));
console.log(formatGrade(4.5));
console.log(formatGrade(2.99));