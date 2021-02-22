﻿using AutoMapper;
using CostJanitor.Domain.Aggregates;
using CostJanitor.Domain.ValueObjects;
using CloudEngineering.CodeOps.Abstractions.Aggregates;
using System.Collections.Generic;
using System.Linq;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost;

namespace CostJanitor.Infrastructure.CostProviders.Aws.Mapping.Converters
{
    public class AwsCostDtoToAggregateConvert : ITypeConverter<CostDto, IAggregateRoot>
    {
        public IAggregateRoot Convert(CostDto source, IAggregateRoot destination, ResolutionContext context)
        {
            //TODO: Finish this converter
            // This assumes that only GetMonthlyTotalCostAllAccounts and GetMonthlyTotalCostByAccountId has been called. 
            // If one were to pass through a GetCostAndUsageResponse with wildly different request parameters, I'd imagine this could very likely go wrong.
            var reportAggr = new ReportRoot();
            var accountResults = new Dictionary<string, string>();
            
            foreach (var dimensionValueAttribute in source.DimensionValueAttributes)
            {
                var awsAccountName = dimensionValueAttribute.Attributes.Single(o => o.Key == "description").Value;
                var awsAccountId = dimensionValueAttribute.Value;
            
                accountResults.Add(awsAccountId, awsAccountName);
            }

            foreach (var resultByTime in source.ResultsByTime)
            {
                var awsAccountName = accountResults[resultByTime.Groups.First().Keys.First()];
                
                //TODO: Decide whether or not to do magic here
                var assumedCapabilityIdentifier = "";
                if (awsAccountName.Contains("dfds-"))
                {
                    assumedCapabilityIdentifier = awsAccountName.Remove(0, 5);
                }

                // Magic end
                var metric = resultByTime.Groups?.First().Metrics?.Single(o => o.Key == "BlendedCost").Value.Amount;
                var costItem = new CostItem("monthlyTotalCost", metric, assumedCapabilityIdentifier);
                
                reportAggr.AddCostItem(costItem);
            }

            return reportAggr;
        }
    }
}