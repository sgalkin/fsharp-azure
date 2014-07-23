module httpclient

open System
open System.Net.Http

let send verb (c:HttpClient) url =
    async{
        let u = new Uri(url)
        use req = new HttpRequestMessage(verb, u)
        let send = c.SendAsync(req)
        let! resp = Async.AwaitTask send
        return resp
    }

let get = send HttpMethod.Get
let post = send HttpMethod.Post
let delete = send HttpMethod.Delete
let put = send HttpMethod.Put

type Client() =
    let client = new HttpClient()

    member self.get = get client
    member self.post = post client
    member self.put = put client
    member self.delete = delete client

    interface System.IDisposable with
        member self.Dispose() = client.Dispose()
