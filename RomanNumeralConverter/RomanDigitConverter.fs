module RomanNumeralConverter.RomanDigitConverter

open RomanNumeralConverter.RomanTypes

type ParseErrorWithDetails = { Details: string }

type ParsedRomanDigitOrError =
    | ParsedRomanDigit of int
    | ParseError of ParseErrorWithDetails

let convertRomanDigitToInt =
    function
    | RomanDigit.I -> ParsedRomanDigit 1
    | V -> ParsedRomanDigit 5
    | X -> ParsedRomanDigit 10
    | L -> ParsedRomanDigit 50
    | C -> ParsedRomanDigit 100
    | D -> ParsedRomanDigit 500
    | M -> ParsedRomanDigit 1000
    | _ -> ParseError { Details = "Aboba" }

let rec convertRomanNumeralToInt =
    function
    | [] -> 0
    | cur :: next :: rest when cur < next ->
        let a =
            match convertRomanDigitToInt next with
            | ParseError x -> failwith x.Details
            | ParsedRomanDigit y -> y

        let b =
            match convertRomanDigitToInt cur with
            | ParseError x -> failwith x.Details
            | ParsedRomanDigit y -> y

        (a - b) + convertRomanNumeralToInt rest

    | cur :: rest ->
        let a =
            match convertRomanDigitToInt cur with
            | ParseError x -> failwith x.Details
            | ParsedRomanDigit y -> y

        (a + convertRomanNumeralToInt rest)

let toInt romanNumeral = convertRomanNumeralToInt romanNumeral
