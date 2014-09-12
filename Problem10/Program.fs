// Reference System.Core in the v3.5 framework for 'HashSet' 
#if INTERACTIVE
#r @"C:\Windows\assembly\GAC_MSIL\System.Core\3.5.0.0__b77a5c561934e089\System.Core.dll" 
#endif

open System 
open System.Collections.Generic 

let primeSequence maxValue =
 seq { 
        // First prime 
        yield 2L 

        let knownComposites = new HashSet<int64>() 
        
        // Loop through all odd numbers; evens can't be prime 
        for i in 3L .. 2L .. maxValue do 
            
            // Check if its in our list, if not, its prime 
            let found = knownComposites.Contains(i) 
            if not found then 
                yield i 

            // Add all multiples of i to our sieve, starting 
            // at i and irecementing by i. 
            do for j in i .. i .. maxValue do 
                   knownComposites.Add(j) |> ignore 
    } 

[<EntryPoint>]
let main argv = 
    let maxNumber = 2000000L

    let sumOfPrimes = primeSequence maxNumber |> Seq.sum

    printfn "%A" sumOfPrimes
    0 // return an integer exit code
