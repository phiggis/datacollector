using System;
using System.IO;
using System.Linq;
using Microsoft.Azure.Cosmos.Table;


namespace AzureDataExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=phdstorageherts;AccountKey=/P9klPWf486z8gNDNXFMK6li2PrLURhgyJHXX4kmFpF/lyurKUFrdS3faEcSbels6iIElUKGLbEzDPRM0LuxOg==;EndpointSuffix=core.windows.net");

            var client = account.CreateCloudTableClient();

            var table = client.GetTableReference("phddata");

            Console.WriteLine("(p)ulldown or (d)elete information from online and press enter");




            string result1 = Console.ReadLine();
            if (result1 == "d")
            {
                Console.WriteLine("press y and enter to delete");
                if (Console.ReadLine() == "y")
                {
                    Console.WriteLine("attempting to delete");

                //    table.exe();
                    Console.WriteLine("Please add this data to the results");
                    return;
                }

                Console.WriteLine("exiting");
                return;
            }

            if (result1 == "p")
            {
                
                string filetowrite = "d:\\personresults.csv";
                if (File.Exists(filetowrite))
                {
                    Console.WriteLine("information exists already, do you want to delete? press y for yes and press enter");
                    string result = Console.ReadLine();
                    
                    if (result == "y")
                    {
                        File.Delete(filetowrite);
                        Console.WriteLine("file deleted");

                        
                    }
                    else
                    {
                        Console.WriteLine("cannot delete the file as you decided not to");
                        return;
                    }

                }


                // https://phdstorageherts.table.core.windows.net/phddata?st=2021-08-11T09%3A57%3A08Z&se=2021-08-12T09%3A57%3A08Z&sp=r&sv=2018-03-28&tn=phddata&sig=i36ZNKm3LabfCNaUwaQyan4PlUot10CyEpPcRBOb4EQ%3D
                //    ?st=2021-08-11T09%3A57%3A08Z&se=2021-08-12T09%3A57%3A08Z&sp=r&sv=2018-03-28&tn=phddata&sig=i36ZNKm3LabfCNaUwaQyan4PlUot10CyEpPcRBOb4EQ%3D

                //DefaultEndpointsProtocol =[http | https]; AccountName = myAccountName; AccountKey = myAccountKey
             //   var account = CloudStorageAccount.Parse("https://phdstorageherts.table.core.windows.net/phddata?st=2021-08-11T10%3A10%3A27Z&se=2021-08-12T10%3A10%3A27Z&sp=r&sv=2018-03-28&tn=phddata&sig=OB9CU3jfPBYwhYavJegtRb5vQ5BGGfy7CxXPKSkKmXw%3D");

  
                //var condition = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Sbeeh");
                //var condition = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.NotEqual, "");
                //var query = new TableQuery<AzureDataExtractorResult>().Where(condition);
                var lst = table.ExecuteQuery(new TableQuery<AzureDataExtractorResult>()).ToList()
                    .OrderBy(p => p.RecordedLocalTime);

                using (StreamWriter sw = new StreamWriter(filetowrite))
                {

                    foreach (var item in lst)
                    {
                        DateTime date = DateTime.Parse(item.RecordedLocalTime);
                        string converted = date.ToLongDateString();
                        sw.WriteLine(string.Format("{0:MM/dd/yy H:mm:ss:fff},{1},{2},{3},{4},{5},{6:MM/dd/yy H:mm:ss:fff}", date,item.Device, item.Evaluation, item.EventData, item.EventName, item.Identifier, item.Timestamp));
                        
                    }
                    sw.Close();
                }



            }
        }
    }
}
