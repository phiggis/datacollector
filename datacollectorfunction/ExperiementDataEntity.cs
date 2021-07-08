using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Microsoft.Azure.Cosmos.Table;


namespace datacollectorfunction
{
    public class ExperiementDataEntity : TableEntity
    {
   /*     public ExperiementDataEntity(string Evaluation, string Identifier)
        {
            this.PartitionKey = Evaluation;
            this.RowKey = Identifier;
        }*/

        public ExperiementDataEntity()
        {
            PartitionKey = Guid.NewGuid().ToString().Replace("-","");
            RowKey= Guid.NewGuid().ToString().Replace("-", "");
        }

        public string Evaluation { get; set; }
        public string Identifier { get; set; }
        public string TestNumber { get; set; }

        public string EventName { get; set; }
        public string Device { get; set; }

        public string RecordedLocalTime { get; set; }


    };


}

