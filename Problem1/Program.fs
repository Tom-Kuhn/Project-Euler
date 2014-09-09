
let isNumberInteresting x = if (x % 3 = 0 || x % 5 = 0) then x else 0    

[<EntryPoint>]
let main argv = 
    
    let multiples = [1 .. 999] |> List.map isNumberInteresting
    let sum = multiples |> List.sum

    printfn "%i" sum

    0 // return an integer exit code
