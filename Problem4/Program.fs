open System
open System.Globalization

let isPallendrome x = 
    let forward = x.ToString()
    let backward = String(forward.ToCharArray() |> Array.rev)
    forward = backward

[<EntryPoint>]
let main argv = 
    let val1 = [999 .. -1 .. 900]
    let val2 = [999 .. -1 .. 900]

    let maxVal = 
        seq { 
            for i in val1 do
                for j in val2 do
                    yield i * j
        } |>  Seq.sort |> Seq.filter isPallendrome |>Seq.max

    printfn "%A" argv
    0 // return an integer exit code
