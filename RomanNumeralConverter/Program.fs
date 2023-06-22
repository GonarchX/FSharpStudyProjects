namespace Program

open RomanNumeralConverter.RomanDigitConverter
open RomanNumeralConverter.CharConverter
open RomanNumeralConverter.RomanTypes

module Program =

    [<EntryPoint>]
    let main argv =
        let x = [ M; C; M; L; X; X; I; X;]

        x |> toInt |> (fun x -> printfn $"{x}")

        let y = "MCMLXXIX"
        stringToRomanNumeral y |> toInt |> (fun x -> printfn $"{x}")
        
        let y = "It raise exception"
        stringToRomanNumeral y |> toInt |> (fun x -> printfn $"{x}")
        0
