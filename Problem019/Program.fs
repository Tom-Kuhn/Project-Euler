open System

[<EntryPoint>]
let main argv = 
    let result = {1901 .. 2000} |> Seq.map(fun y -> {1 .. 12} |> Seq.filter(fun m -> (new DateTime(y, m, 1)).DayOfWeek = DayOfWeek.Sunday) |> Seq.length) |> Seq.sum
    printfn "%i" result
    0 // return an integer exit code
