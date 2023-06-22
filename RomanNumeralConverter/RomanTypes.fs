module RomanNumeralConverter.RomanTypes

type RomanDigit =
    | I
    | II
    | III
    | IIII
    | IV
    | V
    | IX
    | X
    | XX
    | XXX
    | XXXX
    | XL
    | L
    | XC
    | C
    | CC
    | CCC
    | CCCC
    | CD
    | D
    | CM
    | M
    | MM
    | MMM
    | MMMM

let digitToInt =
    function
    | I -> 1
    | II -> 2
    | III -> 3
    | IIII -> 4
    | IV -> 4
    | V -> 5
    | IX -> 9
    | X -> 10
    | XX -> 20
    | XXX -> 30
    | XXXX -> 40
    | XL -> 40
    | L -> 50
    | XC -> 90
    | C -> 100
    | CC -> 200
    | CCC -> 300
    | CCCC -> 400
    | CD -> 400
    | D -> 500
    | CM -> 900
    | M -> 1000
    | MM -> 2000
    | MMM -> 3000
    | MMMM -> 4000

type RomanNumeral = RomanNumeral of RomanDigit list

let digitsToInt list = list |> List.sumBy digitToInt
