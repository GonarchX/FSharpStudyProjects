module RomanNumeralConverter.RomanNumberValidator

open RomanNumeralConverter.CharConverter


let rec isValidDigitList (digitList: ParsedChar list) =
    match digitList with

    // empty list is valid
    | [] -> true

    // a following digit that is equal or larger is an error
    | d1 :: d2 :: _ when d1 <= d2 -> false

    // A single digit is always allowed
    | _ :: ds ->
        // check the remainder of the list
        isValidDigitList ds
