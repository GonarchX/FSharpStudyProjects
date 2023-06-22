module RomanNumeralConverter.CharConverter

open RomanNumeralConverter.RomanTypes

type ParsedChar =
    | Digit of RomanDigit
    | BadChar of char

let rec toParsedCharListRec charList =
    match charList with
    // match the longest patterns first

    // 4 letter matches
    | 'I' :: 'I' :: 'I' :: 'I' :: ns -> Digit IIII :: (toParsedCharListRec ns)
    | 'X' :: 'X' :: 'X' :: 'X' :: ns -> Digit XXXX :: (toParsedCharListRec ns)
    | 'C' :: 'C' :: 'C' :: 'C' :: ns -> Digit CCCC :: (toParsedCharListRec ns)
    | 'M' :: 'M' :: 'M' :: 'M' :: ns -> Digit MMMM :: (toParsedCharListRec ns)

    // 3 letter matches
    | 'I' :: 'I' :: 'I' :: ns -> Digit III :: (toParsedCharListRec ns)
    | 'X' :: 'X' :: 'X' :: ns -> Digit XXX :: (toParsedCharListRec ns)
    | 'C' :: 'C' :: 'C' :: ns -> Digit CCC :: (toParsedCharListRec ns)
    | 'M' :: 'M' :: 'M' :: ns -> Digit MMM :: (toParsedCharListRec ns)

    // 2 letter matches
    | 'I' :: 'I' :: ns -> Digit II :: (toParsedCharListRec ns)
    | 'X' :: 'X' :: ns -> Digit XX :: (toParsedCharListRec ns)
    | 'C' :: 'C' :: ns -> Digit CC :: (toParsedCharListRec ns)
    | 'M' :: 'M' :: ns -> Digit MM :: (toParsedCharListRec ns)

    | 'I' :: 'V' :: ns -> Digit IV :: (toParsedCharListRec ns)
    | 'I' :: 'X' :: ns -> Digit IX :: (toParsedCharListRec ns)
    | 'X' :: 'L' :: ns -> Digit XL :: (toParsedCharListRec ns)
    | 'X' :: 'C' :: ns -> Digit XC :: (toParsedCharListRec ns)
    | 'C' :: 'D' :: ns -> Digit CD :: (toParsedCharListRec ns)
    | 'C' :: 'M' :: ns -> Digit CM :: (toParsedCharListRec ns)

    // 1 letter matches
    | 'I' :: ns -> Digit I :: (toParsedCharListRec ns)
    | 'V' :: ns -> Digit V :: (toParsedCharListRec ns)
    | 'X' :: ns -> Digit X :: (toParsedCharListRec ns)
    | 'L' :: ns -> Digit L :: (toParsedCharListRec ns)
    | 'C' :: ns -> Digit C :: (toParsedCharListRec ns)
    | 'D' :: ns -> Digit D :: (toParsedCharListRec ns)
    | 'M' :: ns -> Digit M :: (toParsedCharListRec ns)

    // bad letter matches
    | badChar :: ns -> BadChar badChar :: (toParsedCharListRec ns)

    // 0 letter matches
    | [] -> []

let parseStringToRoman (s: string) = toParsedCharListRec (Seq.toList s)

let toRomanNumeral s =
    s
    |> List.choose (function
        | Digit digit -> Some digit
        | BadChar _ -> None)
