
let isFactor x value = (value % x) = 0L

let getFactors x =  
    let maxFactor = float >> sqrt >> int64 <| x
    [2L .. maxFactor] |> Seq.filter (fun i -> isFactor i x)

let isPrime x = 
    let factors = getFactors x
    let result = Seq.isEmpty factors
    result

[<EntryPoint>]
let main argv = 
    let target = 600851475143L;
    
    let factors = getFactors target     
    let primeFactors = factors |> Seq.filter isPrime
    
    let largestPrime = Seq.max primeFactors   

    printfn "%A" argv
    0 // return an integer exit code
