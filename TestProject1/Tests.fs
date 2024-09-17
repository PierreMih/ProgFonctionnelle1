namespace TestProject1

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open ProgFonctionnelle1.Types
open ProgFonctionnelle1.Main

[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member this.ConstruireUnStock () =
        let fruitsList = [Fruit.Apple; Fruit.Apple; Fruit.Pineapple; Fruit.Pear; Fruit.Apple; Fruit.Pear]
        Assert.IsTrue(fruitsList.Length > 0)
        
    [<TestMethod>]
    member this.ConstruireUnStockAvecDesFruitsPrecis () =
        let fruitsList = [Fruit.Apple; Fruit.Apple; Fruit.Pineapple; Fruit.Pear; Fruit.Apple; Fruit.Pear]
        let firstFruit = fruitsList.Head
        let fruitsList = fruitsList.Tail
        Assert.AreEqual(firstFruit, Fruit.Apple)
        let firstFruit = fruitsList.Head
        let fruitsList = fruitsList.Tail
        Assert.AreEqual(firstFruit, Fruit.Apple)
        let firstFruit = fruitsList.Head
        let fruitsList = fruitsList.Tail
        Assert.AreEqual(firstFruit, Fruit.Pineapple)
        let firstFruit = fruitsList.Head
        let fruitsList = fruitsList.Tail
        Assert.AreEqual(firstFruit, Fruit.Pear)
        let firstFruit = fruitsList.Head
        let fruitsList = fruitsList.Tail
        Assert.AreEqual(firstFruit, Fruit.Apple)
        let firstFruit = fruitsList.Head
        let fruitsList = fruitsList.Tail
        Assert.AreEqual(firstFruit, Fruit.Pear)
        
    [<TestMethod>]
    member this.AjouterFruitEnDebut () =
        let fruitsList = [Fruit.Apple; Fruit.Apple; Fruit.Pineapple; Fruit.Pear; Fruit.Apple; Fruit.Pear]
        let fruitsListWithPear = addFruitInFirstPlace fruitsList Fruit.Pear
        Assert.AreEqual(fruitsListWithPear.Head, Fruit.Pear)
        
    [<TestMethod>]
    member this.AjouterFruitEnFin () =
        let fruitsList = [Fruit.Apple; Fruit.Apple; Fruit.Pineapple; Fruit.Pear; Fruit.Apple; Fruit.Pear]
        let fruitsListWithPear = addFruitInLastPlace fruitsList Fruit.Pear
        Assert.AreEqual(fruitsListWithPear.Tail.Tail.Tail.Tail.Tail.Head, Fruit.Pear)
        
    [<TestMethod>]
    member this.CountSpecificFruit () =
        let fruitsList = [Fruit.Apple; Fruit.Apple; Fruit.Pineapple; Fruit.Pear; Fruit.Apple; Fruit.Pear]
        let appleCount = fruitCount fruitsList Fruit.Apple
        Assert.AreEqual(appleCount,3)
        let pearCount = fruitCount fruitsList Fruit.Pear
        Assert.AreEqual(pearCount, 2)
        let pineappleCount = fruitCount fruitsList Fruit.Pineapple
        Assert.AreEqual(pineappleCount, 1)
    
    [<TestMethod>]
    member this.AddNFruits () =
        let fruitsList = [Fruit.Apple; Fruit.Apple; Fruit.Pineapple; Fruit.Pear; Fruit.Apple; Fruit.Pear]
        let initialPineappleCount = fruitCount fruitsList Fruit.Pineapple
        let pineappleToAdd = 1000
        let aimedPineappleCount = initialPineappleCount + pineappleToAdd
        let fruitsListWithMorePineapple = addNfruitsToList fruitsList Fruit.Pineapple pineappleToAdd
        let finalPineappleCount = fruitCount fruitsListWithMorePineapple Fruit.Pineapple
        Assert.AreEqual(aimedPineappleCount, finalPineappleCount)
            
    [<TestMethod>]
    member this.RemoveOneFruit () =
        let fruitsList = [Fruit.Apple; Fruit.Apple; Fruit.Pineapple; Fruit.Pear; Fruit.Apple; Fruit.Pear]
        let initialPineappleCount = fruitCount fruitsList Fruit.Pineapple
        let fruitsListWithOneLessPineapple = RemoveOneFruitFromList fruitsList Fruit.Pineapple
        let finalPineappleCount = fruitCount fruitsListWithOneLessPineapple Fruit.Pineapple
        Assert.AreEqual(initialPineappleCount - 1, finalPineappleCount)
        
    [<TestMethod>]
    member this.CountAllFruits () =
        let fruitsList = [Fruit.Apple; Fruit.Apple; Fruit.Pineapple; Fruit.Pear; Fruit.Apple; Fruit.Pear]
        let fruitsCount = countForEachFruit fruitsList
        let appleCount = fruitsCount[Fruit.Apple]
        let pearCount = fruitsCount[Fruit.Pear]
        let pineappleCount = fruitsCount[Fruit.Pineapple]
        Assert.AreEqual(3, appleCount)
        Assert.AreEqual(2, pearCount)
        Assert.AreEqual(1, pineappleCount)
