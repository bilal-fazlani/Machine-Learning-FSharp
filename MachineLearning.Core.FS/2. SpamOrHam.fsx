// for more datasets, visit http://archive.ics.uci.edu/ml/
open System.IO
let dataPath = Path.Combine (__SOURCE_DIRECTORY__ ,"SMSSpamCollection")

type DocType =
    | Ham
    | Spam

let parseDocType label =
    match label with
    | "ham" -> Ham
    | "spam" -> Spam
    | _ -> failwith ("Unknown label: " + label)

let parseLine (line:string) = 
    let split = line.Split('\t')
    let label = split.[0] |> parseDocType
    let message = split.[1]
    (label,message)

let dataset = 
    File.ReadAllLines dataPath
    |> Array.map parseLine
  