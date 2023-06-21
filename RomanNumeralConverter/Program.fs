﻿type RomanDigit =
    | I
    | V
    | X
    | L
    | C
    | D
    | M

type RomanNumeral = RomanNumeral of RomanDigit list

let convertRomanDigitToInt =
    function
    | I -> 1
    | V -> 5
    | X -> 10
    | L -> 50
    | C -> 100
    | D -> 500
    | M -> 1000

let rec convertRomanNumeralToInt =
    function
    | [] -> 0
    | cur :: next :: rest when cur < next ->
        (convertRomanDigitToInt next - convertRomanDigitToInt cur)
        + convertRomanNumeralToInt rest
    | cur :: rest -> convertRomanDigitToInt cur + convertRomanNumeralToInt rest

let toInt romanNumeral = convertRomanNumeralToInt romanNumeral

let x = [ M; C; M; L; X; X; I; X ]

x |> toInt |> (fun x -> printfn $"{x}")
