module RomanNumeralConverter.RomanTypes

type RomanDigit =
    | I
    | V
    | X
    | L
    | C
    | D
    | M
    | BadDigit // for unexpected roman digit

type RomanNumeral = RomanNumeral of RomanDigit list
