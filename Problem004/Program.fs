open System
open System.Globalization

let isPallendrome x = 
    let forward = x.ToString()
    let backward = String(forward.ToCharArray() |> Array.rev)
    forward = backward // If the forward string == the reversed string return true

[<EntryPoint>]
let main argv = 
    // Set the range 999 -> 900 decending, assume that the largest product will be in the 9xx * 9xx range
    let val1 = [999 .. -1 .. 900]
    let val2 = [999 .. -1 .. 900]

    let maxVal = 
        seq { 
            for i in val1 do
                for j in val2 do
                    yield i * j // Generate a sequence of products for all combinations of values within the two ranges above
        } |>  Seq.sort |> Seq.filter isPallendrome |>Seq.max

    printfn "%i" maxVal
    0 // return an integer exit code
