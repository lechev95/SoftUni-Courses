function getList(array) {
    console.log(
        array
            .sort((a, b) => a.localeCompare(b))
            .map((name, index) => `${++index}.${name}`)
            .join("\n")
    );
}

getList(["John", "Bob", "Christina", "Ema"]);