open System

[<EntryPoint>]
let main argv = 
    let factorial n = [1I .. n] |> Seq.reduce ( * )

    let result = (factorial 100I).ToString() |> Seq.map(fun x-> Int32.Parse(x.ToString())) |> Seq.sum

    printf "%A" result
    0
