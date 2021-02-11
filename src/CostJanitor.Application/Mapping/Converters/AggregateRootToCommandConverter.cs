﻿using AutoMapper;
using CostJanitor.Application.Commands;
using CostJanitor.Domain.Aggregates;
using ResourceProvisioning.Abstractions.Aggregates;
using ResourceProvisioning.Abstractions.Commands;
using System;

namespace CostJanitor.Application.Mapping.Converters
{
    public class AggregateRootToCommandConverter : ITypeConverter<IAggregateRoot, ICommand<IAggregateRoot>>
    {
        public ICommand<IAggregateRoot> Convert(IAggregateRoot source, ICommand<IAggregateRoot> destination = default, ResolutionContext context = default)
        {
            switch (source)
            {
                case ReportRoot report:
                    if (report.Id == Guid.Empty)
                    {
                        return new CreateReportCommand(report.CostItems);
                    }
                    else
                    {
                        return new UpdateReportCommand(report);
                    }

                case null:
                default:
                    break;
            }

            return null;
        }
    }
}
