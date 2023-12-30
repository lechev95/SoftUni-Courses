function getOrder(product, count) {
    let price;
    switch (product.toLowerCase()) {
        case "water":
            price = 1;
            break;
        case "coffee":
            price = 1.5;
            break;
        case "coke":
            price = 1.4;
            break;
        case "snacks":
            price = 2;
            break;
    }

    return `${(price * count).toFixed(2)}`;
}

console.log(getOrder("water", 5));
console.log(getOrder("coffee", 2));