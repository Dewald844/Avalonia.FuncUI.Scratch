namespace ApplicationInterface

open System.Net.Http

module FromHTTP =

   let private IBMStockData = "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=IBM&interval=5min&apikey=demo"

   let getIBMData (client : HttpClient) =
      async {
         let! response =
            client.GetAsync IBMStockData
            |> Async.AwaitTask

         response.EnsureSuccessStatusCode () |> ignore

         let! content = response.Content.ReadAsStringAsync () |> Async.AwaitTask

         return content
      }


