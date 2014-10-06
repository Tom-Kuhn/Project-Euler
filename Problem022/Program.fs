open System
open System.IO

[<EntryPoint>]
let main argv = 
    let getData (path: string) = Array.sort(String.Join(",", File.ReadAllLines(path)).Split(',') |> Array.map (fun x -> x.Replace("\"", "")))
    let result = getData "names.txt"|> Seq.map(fun x -> x.ToCharArray() |> Seq.map(fun y -> (int y) - 64) |> Seq.sum) |> Seq.mapi (fun i x -> (i+1) * x) |> Seq.sum
    printfn "%i" result
    0 // return an integer exit code