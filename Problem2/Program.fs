[<EntryPoint>]
let main argv = 
    let takeEvenNumber y = if y &&& 0x1 = 1 then 0 else y;
    
    let fib = Seq.unfold (fun (current, next) -> Some(current, (next, current + next))) (1, 2)

    let fibTotal = fib |> Seq.takeWhile(fun x-> x < 4000000 ) |> Seq.map takeEvenNumber |> Seq.sum 
        
    printfn "%A" fibTotal
    0 // return an integer exit code
