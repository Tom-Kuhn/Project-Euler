[<EntryPoint>]
let main argv = 
    let divisors = [2 .. 20]

    let isDivisorsFactor x = ( divisors |> Seq.map (fun factor -> x % factor) |> Seq.sum ) = 0 // All Values in the mapped array are 0 if all the divisors are factors 

    let options = [2000 .. Seq.max divisors .. 999999999] // set the list of possible options to be in multiples of the max divisor
    let result = match List.tryFind isDivisorsFactor options with
        | Some value -> value
        | None -> -1 
        
    printfn "%i" result

    0 // return an integer exit code
