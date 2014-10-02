open System
open System.IO

// Quick and easy function to read the data into an array containing the data in an upside down triangle
let getData (path: string) = 
    Array.rev 
        ( seq {
            use reader = new StreamReader(path)
            while not reader.EndOfStream do
                yield( reader.ReadLine().Split(' ') |> Array.map (fun x -> int x) |> Array.toList )
        } |> Seq.toArray )
          
let rec findMaximum (values: int list []) = 
    let len = values.Length
    let leaves = values.[0]

    if len = 1 then
        values.[0] |> List.max
    else 
        let rowToCalculate = values.[1]
        let maxValues = rowToCalculate |> List.mapi ( fun i x -> 
                    let leftNode = List.nth leaves i
                    let rightNode = List.nth leaves (i + 1)
                    x + Math.Max(leftNode, rightNode)
                )

        if len = 2 then
            findMaximum [| maxValues |]
        else
            findMaximum (Array.append [| maxValues |] (Array.sub values 2 (len - 2))) // recursively find the next max depth

[<EntryPoint>]
let main argv = 
    let data = getData "problem67data.txt"

    let max = findMaximum data

    printfn "%i" max
    0 // return an integer exit code
