[<EntryPoint>]
let main argv = 

    // Generate all possible Pythagoras triplets up to 500
    let pythagTriplets = 
        seq {
            for a in [1..500] do
                for b in [1..500] do
                    for c in [1..500] do
                        if (a*a) + (b*b) = (c*c) then yield (a, b, c)
        }

    // function to sum a Triplet<int, int, int>
    let sumTriplet x = 
        let (a, b, c) = x
        a + b + c

    // Filter all the Pythagoras triplets to only the ones that add up to 1000 and select the first
    let solution = pythagTriplets |> Seq.filter (fun x -> sumTriplet x = 1000 )
    let (a, b, c) = solution |> Seq.max
    
    // Calculate the result
    let result = a*b*c

    printfn "%A" result
    0 // return an integer exit code
