
let isFactor x value = (value % x) = 0L

let getFactors x =  
    let maxFactor = float >> sqrt >> int64 <| x
    [2L .. maxFactor] |> Seq.filter (fun i -> isFactor i x)

let isPrime x = 
    Seq.isEmpty (getFactors x)

///
/// Recursive function to determine the next prime
///
let rec nextPrime x =
    if isPrime x then x
    else nextPrime(x + 1L)

[<EntryPoint>]
let main argv = 
    let target = 10001

    let primes = Seq.unfold(fun (current) -> Some(current, (nextPrime(current + 1L)))) (1L)

    let result = Seq.nth target primes

    printfn "%i" result

    0 // return an integer exit code
