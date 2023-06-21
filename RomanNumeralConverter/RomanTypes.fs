module RomanNumeralConverter.RomanTypes

type RomanDigit =
    | I
    | V
    | X
    | L
    | C
    | D
    | M

type RomanNumeral = RomanNumeral of RomanDigit list