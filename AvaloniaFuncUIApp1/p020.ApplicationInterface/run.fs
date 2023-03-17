
open System
open System.Net.Http
open ApplicationInterface

module Main =
   [<EntryPoint>]
   let main (args : string []) =

      let newClient = new HttpClient ()

      let getRequest =
         FromHTTP.getIBMData newClient
         |> Async.RunSynchronously

      printfn $"Response from API \n {getRequest}"

      newClient.Dispose ()

      0

