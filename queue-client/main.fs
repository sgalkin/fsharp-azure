// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.    

let tuple a = (a)         

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    //use client = new System.Net.Http.HttpClient()
    //using ("https://google.com" |> tuple |> client.GetAsync |> Async.AwaitTask |> Async.RunSynchronously) (fun x -> 

    use client = new httpclient.Client()
    using ("https://google.com" |> client.get |> Async.RunSynchronously) (fun x ->
        let content = x.Content.ReadAsStringAsync()
        printf "%s" content.Result
    )
    0 // return an integer exit code
