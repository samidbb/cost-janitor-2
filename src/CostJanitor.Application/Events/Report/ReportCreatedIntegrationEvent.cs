using System;
using System.Text.Json;
using CloudEngineering.CodeOps.Abstractions.Events;

namespace CostJanitor.Application.Events.Report
{
    public class ReportCreatedIntegrationEvent : IIntegrationEvent
    {
        public string Id { get; init; }

        public string CorrelationId  { get; init; }

        public DateTime CreationDate  { get; init; }

        public string SchemaVersion  { get; init; }

        public string Type  { get; init; }

        public JsonElement? Payload  { get; init; }
    }
}