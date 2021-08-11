using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.VisualBasic;


namespace AzureDataExtractor
{
    class AzureDataExtractorResult : TableEntity
    {
        public AzureDataExtractorResult(string lastName, string firstName)
        {
            this.PartitionKey = lastName; this.RowKey = firstName;
        }
        public AzureDataExtractorResult() { }
        public string Evaluation { get; set; }
        public string Identifier { get; set; }
        public string EventData { get; set; }
        public string EventName{ get; set; }
        public string Device { get; set; }
        public string RecordedLocalTime { get; set; }
    }
}
