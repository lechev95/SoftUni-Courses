function getExpenses(lossCount, helmet, sword, shield, armor) {
    let helmetCount = 0;
    let swordCount = 0;
    let shieldCount = 0;
    let armorCount = 0;

    for (let i = 1; i <= lossCount; i++) {
        if (i % 2 === 0) {
            helmetCount++;
        }
        if (i % 3 === 0) {
            swordCount++;
        }
        if (i % 2 === 0 && i % 3 === 0) {
            shieldCount++;
            if (shieldCount % 2 === 0) {
                armorCount++;
            }
        }
    }

    let expenses = helmet * helmetCount + sword * swordCount + shield * shieldCount + armor * armorCount;
    console.log(`Gladiator expenses: ${expenses.toFixed(2)} aureus`);
}

getExpenses(7,
    2,
    3,
    4,
    5
);

getExpenses(23,
    12.50,
    21.50,
    40,
    200
);