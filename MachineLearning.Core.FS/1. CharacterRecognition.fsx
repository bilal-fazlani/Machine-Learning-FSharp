open System.IO

type Observation = {Label:string; Pixels:int[]}
        
let toObservation (csvData:string) =
    let columns = csvData.Split(',')
    let label = columns.[0]
    let pixels = columns.[1..] |> Array.map int
    {Label= label; Pixels= pixels}

let observations path =
    let data = File.ReadAllLines path 
    data.[1..]|> Array.map toObservation

type Distance = int[] *int[] -> int

let manhattenDistance (pixels1, pixels2) =
    Array.zip pixels1 pixels2 
    |> Array.map (fun (x,y)-> abs(x-y))
    |> Array.sum

let euclideanDistance (pixels1, pixels2) =
    Array.zip pixels1 pixels2 
    |> Array.map (fun (x,y)-> pown(x-y) 2)
    |> Array.sum

let train (observations:Observation[]) (dist:Distance) = 
    let model pixels = 
        observations
        |> Array.minBy (fun ob -> dist(pixels,ob.Pixels))
        |> fun x -> x.Label
    model

let training = observations @"D:\Repos\MachineLearning\MachineLearning.Core.FS\trainingsample.csv"

let manhattenModel = train training manhattenDistance

let euclideanModel = train training euclideanDistance

let validationSet = observations @"D:\Repos\MachineLearning\MachineLearning.Core.FS\validationsample.csv"

let score model obs = if model obs.Pixels = obs.Label then 1. else 0.

let printPercent number =
    let n = number * 100.
    printfn "correct: %.2f%%" n

printf "manhattenModel "
validationSet 
|> Array.averageBy (score manhattenModel)
|> printPercent

printf "euclideanModel "
validationSet 
|> Array.averageBy (score euclideanModel)
|> printPercent