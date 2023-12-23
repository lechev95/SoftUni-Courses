function getPrice(groupSize, groupType, day) {
    let price;
    let total;
    switch (groupType) {
        case "Students":
            switch (day) {
                case "Friday":
                    price = 8.45;
                    break;
                case "Saturday":
                    price = 9.80;
                    break;
                case "Sunday":
                    price = 10.46;
                    break;
            }

            total = price * groupSize;

            if (groupSize >= 30) {
                total = total - total * 0.15;
            }
            break;
        case "Business":
            switch (day) {
                case "Friday":
                    price = 10.9;
                    break;
                case "Saturday":
                    price = 15.6;
                    break;
                case "Sunday":
                    price = 16;
                    break;
            }

            if (groupSize >= 100) {
                groupSize -= 10;
            }

            total = price * groupSize;
            break;
        case "Regular":
            switch (day) {
                case "Friday":
                    price = 15;
                    break;
                case "Saturday":
                    price = 20;
                    break;
                case "Sunday":
                    price = 22.5;
                    break;
            }

            total = price * groupSize;

            if (groupSize >= 10 && groupSize <= 20) {
                total = total - total * 0.05;
            }
            break;
    }

    console.log(`Total price: ${total.toFixed(2)}`)
}

getPrice(30,
    "Students",
    "Sunday"
);
getPrice(40,
    "Regular",
    "Saturday"
);