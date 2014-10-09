// Reference System.Core in the v3.5 framework for 'HashSet' 
#if INTERACTIVE
#r @"C:\Windows\assembly\GAC_MSIL\System.Core\3.5.0.0__b77a5c561934e089\System.Core.dll" 
#endif

open System 
open System.Collections.Generic 

[<EntryPoint>]
let main argv =     
    let getDivisors x =  
        let maxFactor = float >> sqrt >> int <| x
        let factors = [2 .. maxFactor] |> Seq.filter (fun i -> (x % i) = 0)
        let divisors = factors |> Seq.map(fun f -> x/f)
        Seq.append (Seq.append (Seq.singleton 1) factors ) divisors |> Seq.distinct |> Seq.sort

    let MAX_LIMIT = 28123
    let abundantNumberData = [1..MAX_LIMIT] |> Seq.mapi(fun i x -> (i+1, getDivisors x |> Seq.sum)) |> Seq.filter(fun (i,x) -> x > i) |> Seq.map(fun (i,x) -> i) |> Seq.sort |> Seq.cache
        
    let abundantNumbers = new HashSet<int>() 
    abundantNumberData |> Seq.iter(fun x -> abundantNumbers.Add(x) |> ignore)

    let isSumOfTwoAbundantNumbers x = Seq.exists (fun v -> abundantNumbers.Contains(x-v)) abundantNumberData
    let result = [1..MAX_LIMIT] |> Seq.filter(fun x -> not (isSumOfTwoAbundantNumbers x)) |> Seq.sum

    printfn "%i" result
    0 // return an integer exit code
