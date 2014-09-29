open System

[<EntryPoint>]
let main argv = 
    // Declare an array of digits for the multiplication LSB first e.g. lowest order digits are in index 0 and the highest order digits are in the higher indexes
    let results = [| Array.zeroCreate 400 |]
    Array.set results.[0] 0 2

    let calculateValue index value = 
        if index <> 0 then
            if (results.[index-1] >= 10) then
                ((value + ((results.[index-1]) - ((results.[index-1]) % 10 ))) * 2)
            else
                (value * 2)
        else
            // Deal with the first index seperatly as it wont have a previous value
            (value * 2)
    
    for x in 1 .. 1000 do
        Array.append (Array.mapi calculateValue results.[x - 1])       

    let result = 0        

    printfn "%i" result
    0 // return an integer exit code
