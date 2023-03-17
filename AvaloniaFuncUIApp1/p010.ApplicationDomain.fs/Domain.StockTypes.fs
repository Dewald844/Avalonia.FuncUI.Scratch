namespace ApplicationDomain

open System

open System.Text.Json.Nodes


module StockTypes =

   type StockValue = {
      Open   : double
      High   : double
      Low    : double
      Close  : double
      Volume : double
   }

   type StockData = DateTime * StockValue

   type DataList = List<StockData>


   module DataList =

      let fromStringFn (s : string) = JsonValue.Parse s