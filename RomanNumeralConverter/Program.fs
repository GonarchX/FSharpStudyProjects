namespace Program


open RomanNumeralConverter.RomanNumberValidator
open RomanNumeralConverter.CharConverter
open RomanNumeralConverter.RomanTypes

module Program =

    [<EntryPoint>]
    let main argv =

        // test valid
        let validList = [ "IIII"; "XIV"; "MMDXC"; "IIXX"; "VV"; "ABOBA" ]

        validList
        |> List.map parseStringToRoman
        |> List.iter (function
            | n when isValidDigitList n ->
                printfn "%A is valid and its integer value is %i" n (digitsToInt (toRomanNumeral n))
            | n -> printfn "%A is not valid" n)

        0
