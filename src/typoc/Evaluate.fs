module typoc.Evaluate

open System.Text.RegularExpressions

let evaluate str =
  let regex = Regex @"(\d+) (.) (\d+)"
  let match' = regex.Match str
  
  if match'.Success then
    let a = int match'.Groups[1].Value
    let b = int match'.Groups[3].Value
    let op = match'.Groups[2].Value
        
    match op with
    | "+" -> a + b |> Ok
    | "-" -> a - b |> Ok
    | "*" -> a * b |> Ok
    | "/" -> a / b |> Ok
    | _ -> Error "Invalid operator"
  else Error "Invalid expression"
