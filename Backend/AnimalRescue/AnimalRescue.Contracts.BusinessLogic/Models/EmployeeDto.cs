﻿using AnimalRescue.Contracts.BusinessLogic.Attributes;
using common = AnimalRescue.Contracts.Common.Constants.PropertyConstants.Common;

namespace AnimalRescue.Contracts.BusinessLogic.Models
{
    public class EmployeeDto : BaseAndTimeDto
    {
        [CouplingPropertyDto(common.Name)]
        public string Name { get; set; }

        [CouplingPropertyDto(common.Description)]
        public string Description { get; set; }
    }
}
