﻿using AnimalRescue.Contracts.BusinessLogic.Models;
using AnimalRescue.Contracts.Common.Interfaces.CRUD;
using AnimalRescue.Contracts.Common.Query;

namespace AnimalRescue.Contracts.BusinessLogic.Interfaces.CRUD
{
    public interface IBlCollectinQueryAsyncy<TOut> : IBaseQuerAsyncy<BlCollectonResponse<TOut>, ApiQueryRequest>
    {
    }
    public interface IBlOneItemQueryAsyncy<TOut> : IBaseQuerAsyncy<TOut, string>
    {
    }
}
