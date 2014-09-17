let numberOfFactors n =
    let isFactor number divisor = number % divisor = 0L

    // Recursive call to count the number of divisors in a particular number
    let rec countDivisors number divisor =
        if isFactor number divisor then // If the divisor is 
            let multiple, count = countDivisors (number/divisor) divisor
            multiple, count + 1L
        else
            number, 0L // No divisors remaining for number
 
    // Recursive function to collate all the possible factors 
    let rec collate number divisor =
        if number < divisor then 
            1L // Stop condition
        // If the divisor is a factor, calculate the number of multiples present for this divisor
        elif isFactor number divisor then
            let multiple, count = countDivisors number divisor
            (count + 1L) * (collate multiple divisor) // Return the number of factors for this divisor
        else
            collate number (divisor + 1L) // Iterate onto the next possible divisor
    
    collate n 2L // Start the recursive calls to find the number of divisors

[<EntryPoint>]
let main argv = 
    let triangleNumbers = Seq.initInfinite (fun n -> (((int64 n) * ((int64 n) + 1L)) / 2L))
    let n = triangleNumbers |> Seq.find(fun x -> (numberOfFactors x) > 500L)
    
    printfn "%i" n
    0 // return an integer exit code
