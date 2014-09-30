// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv = 
    let generateOnesText x = 
        match x with 
            | 1 -> "One"
            | 2 -> "Two"
            | 3 -> "Three"
            | 4 -> "Four"
            | 5 -> "Five"
            | 6 -> "Six"
            | 7 -> "Seven"
            | 8 -> "Eight"
            | 9 -> "Nine"
            | _ -> null
                        
    let generateTeensText x = 
        match x with 
            | 10 -> "Ten"
            | 11 -> "Eleven"
            | 12 -> "Twelve"
            | 13 -> "Thirteen"
            | 14 -> "Fourteen"
            | 15 -> "Fifteen"
            | 16 -> "Sixteen"
            | 17 -> "Seventeen"
            | 18 -> "Eighteen"
            | 19 -> "Nineteen"
            | _ -> null
            
    let generateTensText x = 
        match x with 
            | 2 -> "Twenty"
            | 3 -> "Thirty"
            | 4 -> "Forty"
            | 5 -> "Fifty"
            | 6 -> "Sixty"
            | 7 -> "Seventy"
            | 8 -> "Eighty"
            | 9 -> "Ninety"
            | _ -> null
        
    let rec generateWords x =
        if x >= 1000 then
            let thousands = (x - (x % 1000))/1000
            let result = generateOnesText thousands + "thousand" + generateWords (x - (thousands * 1000))
            result
        else if x >= 100 then
            let hundreds = (x - (x % 100))/100
            let result = generateOnesText hundreds + "hundred"
            if x % 100 > 0 then
                 result + "and" + generateWords (x - (hundreds * 100))
            else
                result
        else if x > 19 then
            let tens = (x - (x % 10))/10
            let result = generateTensText tens + generateWords (x - (tens * 10))
            result
        else if x > 9 then
            let result = generateTeensText x
            result
        else
            let result = generateOnesText x
            result

    let text = [1 .. 1000] |> Seq.map generateWords
    let output = text |> Seq.map(fun x -> x.Length) |> Seq.sum

    printfn "%O" output
    0 // return an integer exit code
