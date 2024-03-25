function solve(firstName, lastName, hairColor){
    const info = {
        name: firstName, 
        lastName,
        hairColor,
    };

    const result = JSON.stringify(info);
    console.log(result);
}

solve(
    'George', 'Jones', 'Brown'
)