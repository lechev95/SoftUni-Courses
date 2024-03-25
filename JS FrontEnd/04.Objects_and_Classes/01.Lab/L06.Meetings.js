function solve(input){
    const meeting = [];

    for (const line of input) {
        const [day, name] = line.split(' ');

        if(meeting.hasOwnProperty(day)){
            console.log(`Conflict on ${day}!`); 
        } else{
            console.log(`Scheduled for ${day}`);
            meeting[day] = name;
        }
    }

    for (const line in meeting) {
        console.log(`${line} -> ${meeting[line]}`);
    }
}

solve(['Monday Peter',
'Wednesday Bill',
'Monday Tim',
'Friday Tim']
);