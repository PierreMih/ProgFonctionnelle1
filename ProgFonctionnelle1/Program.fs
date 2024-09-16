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

displayCountForEachFruit fruitsListComplete
printfn ""

let rec addNfruitsToList (fruits : Fruit list) (fruitToAdd : Fruit) (n : int) =
    let n2 = n-1
    if(n > 0) then
        let fruitsResult = fruitToAdd :: fruits
        addNfruitsToList fruitsResult fruitToAdd n2 
    else
        fruits
let fruitsListComplete2 = addNfruitsToList fruitsListComplete Fruit.Pineapple 100
displayCountForEachFruit fruitsListComplete2
