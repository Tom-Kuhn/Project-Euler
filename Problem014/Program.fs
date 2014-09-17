[<EntryPoint>]
let main argv = 
    let collatz n =
        Seq.unfold (
            fun x -> 
                if x < 1L then None // Stop condition
                elif x = 1L then Some(1L, -1L) // Special case to indicate last value reached
                elif ( x % 2L = 0L ) then Some(x, (x / 2L))
                else Some(x, (3L * x) + 1L)
        ) n

    let sequences = [750000L .. 999999L] |> Seq.map (fun x -> (x, Seq.length (collatz x)))
    let (num, length) = Seq.maxBy snd sequences 

    printfn "%A" num
    0 // return an integer exit code
