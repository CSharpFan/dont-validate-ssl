open System
open System.Net
open System.Net.Security

type Result =
| Ok of string
| Error of exn

[<EntryPoint>]
let main _ = 
    
    // option 1
    // ServicePointManager.ServerCertificateValidationCallback <- new RemoteCertificateValidationCallback(fun _ _ _ _ -> true)

    let result = 
        try
            let request = 
                "https://somewebsite/with/expired/ssl/certificate/data.json?paramx=1&paramy=2"
                |> WebRequest.CreateHttp

            // option 2
            // request.ServerCertificateValidationCallback <- new RemoteCertificateValidationCallback(fun _ _ _ _ -> true)

            let response = 
                request.GetResponse ()

            // parse data
            let parsed = "..." 

            Ok parsed
        with
        | ex ->      
            Error ex

    // process result
    // ...

    0 
