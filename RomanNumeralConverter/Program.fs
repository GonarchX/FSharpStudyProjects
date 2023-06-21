namespace Program

open RomanNumeralConverter.RomanDigitConverter
open RomanNumeralConverter.RomanTypes

module Program =

    [<EntryPoint>]
    let main argv =
        let x = [ M; C; M; L; X; X; I; X ]

        x |> toInt |> (fun x -> printfn $"{x}")

        0
