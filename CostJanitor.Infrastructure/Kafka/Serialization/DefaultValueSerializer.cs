﻿using Confluent.Kafka;
using System.Text.Json;

namespace CostJanitor.Infrastructure.Kafka.Serialization
{
    public class DefaultValueSerializer<T> : ISerializer<T>
    {
        public byte[] Serialize(T data, SerializationContext context)
        {
            return JsonSerializer.SerializeToUtf8Bytes(data, typeof(T));
        }
    }
}
