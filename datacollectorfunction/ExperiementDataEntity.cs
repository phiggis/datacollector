using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Microsoft.Azure.Cosmos.Table;


namespace datacollectorfunction
{
   [Serializable]
    public class ExperiementDataEntity 
    {

        public string Evaluation { get; set; }
        public string Identifier { get; set; }
        public string EventData { get; set; }

        public string EventName { get; set; }
        public string Device { get; set; }

        public string RecordedLocalTime { get; set; }


    };


}

