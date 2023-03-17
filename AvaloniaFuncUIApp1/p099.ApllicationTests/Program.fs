namespace ApplicationTests

open System.Net.Http
open System.Security.Cryptography
open System.Text.Json
open System.Text.Json.Nodes

module Domain =

   open ApplicationDomain.StockTypes
   open ApplicationInterface.FromHTTP

   let checkDeserializer () =

      printf "Registering new Http Client ........ \n"
      let client = new HttpClient()

      let data =
         printf "Requesting data ........ \n"
         getIBMData client
         |> Async.RunSynchronously

      let jsonData =
         DataList.fromStringFn data
         |> fun j -> j.Item "Meta Data"

      printf $"Datalist from json %A{jsonData} \n"


module Main =

   [<EntryPoint>]
   let main argv =
      Domain.checkDeserializer ()
      0
