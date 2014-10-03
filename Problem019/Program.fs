open System

[<EntryPoint>]
let main argv = 
    let doesMonthStartOnSunday year month = if (new DateTime(year, month, 1)).DayOfWeek = DayOfWeek.Sunday then 1 else 0
    let result = {1901 .. 2000} |> Seq.map(fun y -> {1 .. 12} |> Seq.map(fun m -> doesMonthStartOnSunday y m ) |> Seq.sum ) |> Seq.sum

    printfn "%i" result
    0 // return an integer exit code
