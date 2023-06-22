module RomanNumeralConverter.RomanNumberValidator

open RomanNumeralConverter.RomanTypes

let isHighDigit =
    function
    | I
    | X
    | C
    | M -> false
    | V
    | L
    | D -> true

let rec isValidDigitList digitList =
    match digitList with

    // empty list is valid
    | [] -> true

    // A run of 5 or more anything is invalid
    // Example:  XXXXX
    | d1 :: d2 :: d3 :: d4 :: d5 :: _ when d1 = d2 && d1 = d3 && d1 = d4 && d1 = d5 -> false

    // 2 or more non-runnable digits is invalid
    // Example:  VV
    | d1 :: d2 :: _ when d1 = d2 && isHighDigit d1 -> false

    // runs of 2,3,4 in the middle are invalid if next digit is higher
    // Example:  IIIX
    | d1 :: d2 :: d3 :: d4 :: higher :: _ when d1 = d2 && d1 = d3 && d1 = d4 && higher > d1 -> false

    | d1 :: d2 :: d3 :: higher :: _ when d1 = d2 && d1 = d3 && higher > d1 -> false

    | d1 :: d2 :: higher :: _ when d1 = d2 && higher > d1 -> false

    // three ascending numbers in a row is invalid
    // Example:  IVX
    | d1 :: d2 :: d3 :: _ when d1 < d2 && d2 <= d3 -> false

    // A single digit with no runs is always allowed
    | _ :: ds ->
        // check the remainder of the list
        isValidDigitList ds
