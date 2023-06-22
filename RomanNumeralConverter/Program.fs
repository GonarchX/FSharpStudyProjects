namespace Program

open RomanNumeralConverter.RomanDigitConverter
open RomanNumeralConverter.CharConverter
open RomanNumeralConverter.RomanTypes

module Program =

    [<EntryPoint>]
    let main argv =
        // test good cases

        "IIII"  |> toRomanNumeral
        "IV"  |> toRomanNumeral
        "VI"  |> toRomanNumeral
        "IX"  |> toRomanNumeral
        "MCMLXXIX"  |> toRomanNumeral
        "MCMXLIV" |> toRomanNumeral
        "" |> toRomanNumeral

        // error cases
        "MC?I" |> toRomanNumeral
        "abc" |> toRomanNumeral

        
        0
