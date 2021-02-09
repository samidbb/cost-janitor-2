﻿using System.Collections.Generic;

namespace CostJanitor.Infrastructure.Kafka
{
    public class KafkaOptions
    {
        public const string Kafka = "Kafka";

        public IDictionary<string, string> Configuration { get; set; }

        public IEnumerable<string> Topics { get; set; }

        public bool EnablePartitionEof { get; set; } = false;

        public int StatisticsIntervalMs { get; set; } = 5000;

        public int CommitPeriod { get; set; } = 5;
    }
}