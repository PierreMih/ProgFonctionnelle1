// Crée un OBJET Typescript
let fruitsStock = [
    { id: 1, name: "Pomme", quantity: 10 },
    { id: 2, name: "Poire", quantity: 5 },
    { id: 3, name: "Ananas", quantity: 8 }
];

// Ne retourne pas de résultat
function addFruitToStock(name: string, quantity: number) {
    // utilisation de fruitsStock, externe à la fonction
    // p.name est une propriété (objet)
    // .find peut être acceptable
    // @ts-ignore
    const existingProduct = fruitsStock.find((p) => p.name === name);

    if (existingProduct) {
        // modifie une propriété d'instance d'objet
        existingProduct.quantity += quantity;
    } else {
        //fruitsStock n'est pas passé en paramètre
        fruitsStock.push({ id: fruitsStock.length + 1, name, quantity });
    }
}

// Ne retourne pas de résultat
function deleteFruit(name: string) {
    fruitsStock = fruitsStock.filter((p) => p.name !== name);
    console.log(`${name} deleted from stock`);
}

function showStock() {
    fruitsStock.forEach((fruit) => {
        console.log(`Fruit : ${fruit.name} | Quantity : ${fruit.quantity}`);
    });
}

// Ne retourne pas de résultat
function sellFruit(name: string, quantity: number) {
    // Utilise fruitsStock qui n'est pas passé en paramètre
    // @ts-ignore
    const fruit = fruitsStock.find((p) => p.name === name);

    // Utilise un tricks de syntaxe TS : if (fruit)
    if (fruit && fruit.quantity >= quantity) {
        // Exploite la mutabilité de la propriété
        fruit.quantity -= quantity;
        console.log(`${quantity} ${name} sold`);
    } else {
        console.log(`Not enough ${name} or unknown fruit`);
    }
}

// Pas de résultat, pas de vérification des résultats
addFruitToStock("Pomme", 5);
addFruitToStock("Citron", 10);
sellFruit("Ananas", 2);
showStock();
deleteFruit("Ananas");
showStock();

/*
2 Ananas sold
Fruit : Pomme | Quantity : 15
Fruit : Poire | Quantity : 5
Fruit : Ananas | Quantity : 6
Fruit : Citron | Quantity : 10
Ananas deleted from stock
Fruit : Pomme | Quantity : 15
Fruit : Poire | Quantity : 5
Fruit : Citron | Quantity : 10
*/