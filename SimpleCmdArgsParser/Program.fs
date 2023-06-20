type OrderByOption =
    | OrderBySize
    | OrderByName
    | None

type SubdirectoryOption =
    | IncludeSubdirectories
    | ExcludeSubdirectories

type VerboseOption =
    | VerboseOutput
    | TerseOutput

type CommandLineOptions =
    { verbose: VerboseOption
      subdirectories: SubdirectoryOption
      orderBy: OrderByOption }

let rec parseCommandLineRec args curOptions =
    match args with
    // empty list means we're done.
    | [] -> curOptions

    // match verbose flag
    | "/v" :: xs ->
        let newOptionsSoFar = { curOptions with verbose = VerboseOutput }
        parseCommandLineRec xs newOptionsSoFar

    // match subdirectories flag
    | "/s" :: xs ->
        let newOptionsSoFar = { curOptions with subdirectories = IncludeSubdirectories }
        parseCommandLineRec xs newOptionsSoFar

    // match orderBy by flag
    | "/o" :: orderByFlag ->
        //start a submatch on the next arg
        match orderByFlag with
        | "S" :: xss ->
            let newOptionsSoFar = { curOptions with orderBy = OrderBySize }
            parseCommandLineRec xss newOptionsSoFar

        | "N" :: xss ->
            let newOptionsSoFar = { curOptions with orderBy = OrderByName }
            parseCommandLineRec xss newOptionsSoFar

        // handle unrecognized option and keep looping
        | _ ->
            eprintfn "OrderBy needs a second argument"
            parseCommandLineRec orderByFlag curOptions

    // handle unrecognized option and keep looping
    | x :: xs ->
        eprintfn $"Option '%s{x}' is unrecognized"
        parseCommandLineRec xs curOptions

// parse command line args for building cmd options
let parseCommandLine args =
    let defaultOptions =
        { verbose = TerseOutput
          subdirectories = ExcludeSubdirectories
          orderBy = None }

    parseCommandLineRec args defaultOptions

[<EntryPoint>]
let main argv =
    
    // test cases
    let mutable res = parseCommandLine [ "/v" ]
    printfn $"{res}"
    res <- parseCommandLine [ "/v"; "/s" ]
    printfn $"{res}"
    res <- parseCommandLine [ "/o"; "S" ]
    printfn $"{res}"
    0
