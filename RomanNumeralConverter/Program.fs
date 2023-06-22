namespace Program

open RomanNumeralConverter.RomanDigitConverter
open RomanNumeralConverter.CharConverter
open RomanNumeralConverter.RomanTypes
open RomanNumeralConverter.RomanNumberValidator

module Program =

    [<EntryPoint>]
    let main argv =

        // test valid
        let validList = [ "IIII"; "XIV"; "MMDXC"; "IIXX"; "VV" ]

        validList
        |> List.map toRomanNumeral
        |> List.iter (function
            | n when isValidDigitList n -> printfn "%A is valid and its integer value is %i" n (toInt n)
            | n -> printfn "%A is not valid" n)

        0
