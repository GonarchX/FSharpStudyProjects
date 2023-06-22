module RomanNumeralConverter.RomanDigitConverter

open RomanNumeralConverter.RomanTypes

type ParseErrorWithDetails = { Details: string }


let convertRomanDigitToInt =
    function
    | RomanDigit.I -> 1
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
    | cur :: rest -> (convertRomanDigitToInt cur + convertRomanNumeralToInt rest)

let toInt romanNumeral = convertRomanNumeralToInt romanNumeral
