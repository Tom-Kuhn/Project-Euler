// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv = 
    let squareSide = 20
    let latticePoints = squareSide + 1

    let paths = [| 1L .. (int64)latticePoints |] |> Array.map (fun x -> [| for i in 1L .. (int64)latticePoints -> 1L |]  )

    for i in 1 .. squareSide do
        for j in 1 .. squareSide do
            Array.set (paths.[i]) j (paths.[i - 1].[j] + paths.[i].[j - 1])


    let result = paths.[squareSide].[squareSide]

    printfn "%i" result
    0 // return an integer exit code
