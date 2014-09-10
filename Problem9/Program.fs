[<EntryPoint>]
let main argv = 
    let targetSum = 1000

    // Generate all possible Pythagoras triplets up to 500
    let pythagTriplets = 
        seq {
            for a in [1..500] do
                for b in [1..500] do
                    let c = targetSum - a - b 
                    if (a*a) + (b*b) = (c*c) then yield (a, b, c)
        }

    // Filter the Pythagoras triplets and select the first
    let (a, b, c) = pythagTriplets |> Seq.head
    
    // Calculate the result
    let result = a*b*c

    printfn "%A" result
    0 // return an integer exit code
