function solve(input){
    //Define structure
    const employees = {};
    //Read employee names
    for (const name of input) {
        employees[name] = name.length;
    }
    //Print result
    for (const employee in employees) {
        console.log(`Name: ${employee} -- Personal Number: ${employees[employee]}`);
    }
}

solve([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
    ]
    );