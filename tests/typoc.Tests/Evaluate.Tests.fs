module Evaluate_Tests

open NUnit.Framework
open FsUnit
open typoc

[<Test>]
let ``2 + 2 = 4`` () =
    let result = Evaluate.evaluate "2 + 2"
    match result with
    | Ok v -> v |> should equal 4
    | Error e -> failwith e

[<Test>]
let ``3 - 1 = 2`` () =
    let result = Evaluate.evaluate "3 - 1"
    match result with
    | Ok v -> v |> should equal 2
    | Error e -> failwith e

[<Test>]
let ``3 * 3 = 9`` () =
    let result = Evaluate.evaluate "3 * 3"
    match result with
    | Ok v -> v |> should equal 9
    | Error e -> failwith e

[<Test>]
let ``6 / 3 = 2`` () =
    let result = Evaluate.evaluate "6 / 3"
    match result with
    | Ok v -> v |> should equal 2
    | Error e -> failwith e

[<Test>]
let ``Invalid term returns failure`` () =
    let result = Evaluate.evaluate "6 * (2"
    match result with
    | Ok _ -> failwith "Should not be Ok"
    | Error e -> e |> should equal "Invalid expression"

[<Test>]
let ``Invalid operator returns failure`` () =
    let result = Evaluate.evaluate "6 # 2"
    match result with
    | Ok _ -> failwith "Should not be Ok"
    | Error e -> e |> should equal "Invalid operator"
