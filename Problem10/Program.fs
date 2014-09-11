let isPrime x primes =
    let isEvenDivisor num div = num % div

    let result = primes |> Seq.map (fun p -> isEvenDivisor x p) |> Seq.forall (fun y -> y != 0)
    result
    

let primeSequence maxValue =
   let primes = {2L .. 3L}
   
   let result = 
        Seq.append (seq {
          for i in 2L..maxValue do        
             if isPrime i primes then
                Seq.append primes (Seq.singleton i) |> ignore
                yield i
       }) primes

   primes = Seq.append (Seq.singleton 1) primes


[<EntryPoint>]
let main argv = 
    let maxNumber = 2000000000L

    let sumOfPrimes = primeSequence maxNumber |> Seq.sum

    printfn "%i" sumOfPrimes
    0 // return an integer exit code
