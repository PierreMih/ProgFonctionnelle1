open System.Linq

type Fruit =
    | Apple = 1
    | Pear = 2
    | Pineapple = 3
    
let fruitsList = [Fruit.Apple; Fruit.Apple; Fruit.Pineapple; Fruit.Pear; Fruit.Apple; Fruit.Pear]
let fruitsListWithPear = Fruit.Pear :: fruitsList
let fruitsListComplete = fruitsListWithPear @ [Fruit.Apple]

let fruitCount (fruits: Fruit list) (fruitToCount: Fruit) =
    fruits
    |> List.filter(fun fruit -> fruit = fruitToCount)
    |> List.length
    
let appleCount (fruits: Fruit list) =
    fruitCount fruits Fruit.Apple
let pearCount (fruits: Fruit list) =
    fruitCount fruits Fruit.Pear
let pineappleCount (fruits: Fruit list) =
    fruitCount fruits Fruit.Pineapple

let displayCountForEachFruit (fruits: Fruit list) =
    let listOfPossibleFruits = Fruit.GetValues()
    for possibleFruit in listOfPossibleFruits do
        let thisFruitCount = fruitCount fruits possibleFruit
        let addSIfRequired (count: int) =
            if count > 1 then "s" else ""
        printfn $"{thisFruitCount} {Fruit.GetName(possibleFruit)}{addSIfRequired thisFruitCount}"

printfn "Affichage du compte à partir de la liste"
displayCountForEachFruit fruitsListComplete
printfn ""

let rec addNfruitsToList (fruits : Fruit list) (fruitToAdd : Fruit) (n : int) =
    if(n > 0) then
        let fruitsResult = fruitToAdd :: fruits
        let n2 = n-1
        addNfruitsToList fruitsResult fruitToAdd n2 
    else
        fruits
let fruitsListComplete2 = addNfruitsToList fruitsListComplete Fruit.Pineapple 100
printfn "Ajout de 100 Pineapple"
displayCountForEachFruit fruitsListComplete2
printfn ""

let RemoveOneFruitFromList (fruits : Fruit list) (fruitToRemove : Fruit) =
    let isFruitToRemove fruit = fruit = fruitToRemove
    let indexToRemove = fruits |> List.findIndex isFruitToRemove
    List.removeAt indexToRemove fruits

let fruitsListComplete3 = RemoveOneFruitFromList fruitsListComplete2 Fruit.Pineapple
printfn "Retrait d'un Pineapple"
displayCountForEachFruit fruitsListComplete3
printfn ""

//Renvoyer un dictionnaire/map
let countForEachFruit (fruits : Fruit list) =
    let listOfPossibleFruits = Fruit.GetValues()
    Map (listOfPossibleFruits.Select(fun f -> (f, fruitCount fruits f)))

let fruitsCountMap = countForEachFruit fruitsListComplete3
printfn "Affichage du compte à partir d'une fonction qui retourne une Map<Fruit,int>"
for keyValuePair in fruitsCountMap do
    let addSIfRequired (count: int) =
            if count > 1 then "s" else ""
    printfn $"{keyValuePair.Value} {Fruit.GetName(keyValuePair.Key)}{addSIfRequired keyValuePair.Value}"
printfn ""
