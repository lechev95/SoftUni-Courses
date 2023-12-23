function getResult(speed, area) {
    let limit;
    let status;
    let isAbove = true;
    switch (area) {
        case "motorway":
            limit = 130;
            if (speed - limit > 0 && speed - limit <= 20) {
                status = "speeding";
            } else if (speed - limit > 20 && speed - limit <= 40) {
                status = "excessive speeding";
            } else if (speed - limit > 40) {
                status = "reckless driving";
            } else {
                isAbove = false;
            }
            break;
        case "interstate":
            limit = 90;
            if (speed - limit > 0 && speed - limit <= 20) {
                status = "speeding";
            } else if (speed - limit > 20 && speed - limit <= 40) {
                status = "excessive speeding";
            } else if (speed - limit > 40) {
                status = "reckless driving";
            } else {
                isAbove = false;
            }
            break;
        case "city":
            limit = 50;
            if (speed - limit > 0 && speed - limit <= 20) {
                status = "speeding";
            } else if (speed - limit > 20 && speed - limit <= 40) {
                status = "excessive speeding";
            } else if (speed - limit > 40) {
                status = "reckless driving";
            } else {
                isAbove = false;
            }
            break;
        case "residential":
            limit = 20;
            if (speed - limit > 0 && speed - limit <= 20) {
                status = "speeding";
            } else if (speed - limit > 20 && speed - limit <= 40) {
                status = "excessive speeding";
            } else if (speed - limit > 40) {
                status = "reckless driving";
            } else {
                isAbove = false;
            }
            break;
    }

    if (isAbove) {
        console.log(`The speed is ${speed - limit} km/h faster than the allowed speed of ${limit} - ${status}`);
    } else {
        console.log(`Driving ${speed} km/h in a ${limit} zone`);
    }
}

getResult(40, 'city');
getResult(21, 'residential');
getResult(120, 'interstate');
getResult(200, 'motorway');