module RomanNumeralConverter.CharConverter

open RomanNumeralConverter.RomanTypes

type ParsedChar =
    | Digit of RomanDigit
    | BadChar of char

let charToRomanDigit =
    function
    | 'I' -> Digit I
    | 'V' -> Digit V
    | 'X' -> Digit X
    | 'L' -> Digit L
    | 'C' -> Digit C
    | 'D' -> Digit D
    | 'M' -> Digit M
    | ch -> BadChar ch

let toRomanDigitList (s: string) =
    s.ToCharArray() |> List.ofArray |> List.map charToRomanDigit

let toRomanNumeral s =
    toRomanDigitList s
    |> List.choose (function
        | Digit digit -> Some digit
        | BadChar ch ->
            eprintfn $"{ch} - Problem character"
            None)
