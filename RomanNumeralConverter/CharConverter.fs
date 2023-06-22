module RomanNumeralConverter.CharConverter

open RomanNumeralConverter.RomanTypes

let charToRomanDigit =
    function
    | 'I' -> RomanDigit.I
    | 'V' -> V
    | 'X' -> X
    | 'L' -> L
    | 'C' -> C
    | 'D' -> D
    | 'M' -> M
    | _ -> BadDigit

let rec stringToRomanNumeralRec (acc: RomanDigit list) rest =
    match rest with
    | cur :: rest -> stringToRomanNumeralRec (acc @ [ charToRomanDigit cur ]) rest
    | _ -> acc

let rec stringToRomanNumeral stringRomanNumeral =
    stringToRomanNumeralRec [] (Seq.toList stringRomanNumeral)