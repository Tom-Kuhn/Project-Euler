open System

[<EntryPoint>]
let main argv = 

    let calculateValue previousValue value  = 
        if previousValue >= 0 then
            let prevTotal = previousValue * 2
            if (prevTotal >= 10) then
                (value * 2) + ((prevTotal - (prevTotal % 10 )) / 10)
            else
                value * 2
        else
            value * 2 // Deal with the first index seperatly as it wont have a previous value

    let multiplyByTwo input =
        let d = input |> Array.mapi ( fun index x -> 
                if index <> 0 then
                    calculateValue (input.[index - 1]) x
                else
                    calculateValue -1 x
        ) 

        let output = d |> Array.map (fun x -> 
            if x >= 10 then 
                x % 10 
            else 
                x)

        let v1 = d.[d.Length - 1]
        if v1 >= 10 then
            Array.append output [| (v1 - (v1 % 10)) / 10 |]
        else
            output

    let targetPower = 1000

    let powersOfTwo = Seq.unfold(fun current -> Some(current, multiplyByTwo current)) [|2|]

    let result = powersOfTwo |> Seq.nth (targetPower - 1) |> Array.sum

    printfn "%O" result
    0 // return an integer exit code
