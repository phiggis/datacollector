using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.DTO
{
    [Serializable]
    public class ExperimentData
    {

        public string Evaluation { get; set; }
        public string Identifier { get; set; }
        public string EventData { get; set; }

        public string EventName { get; set; }
        public string Device { get; set; }

        public string RecordedLocalTime { get; set; }
        public string SimulatorLastUpdate { get; set; }

        public override string ToString()
        {
            return $"Evaluation: {Evaluation} Identifier {Identifier} EventData {EventData} EventName {EventName} Device {Device} RecordedLocalTime {RecordedLocalTime} SimulatorLastUpdate {SimulatorLastUpdate}";
        }

    }
}
