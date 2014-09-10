// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv = 
    let range = [1 .. 100]

    let square x = x*x

    let sumOfSquares = range |> Seq.map square |> Seq.sum
    let squareOfSum = square (range |> Seq.sum)

    let difference = squareOfSum - sumOfSquares

    printfn "%i" difference

    0 // return an integer exit code
