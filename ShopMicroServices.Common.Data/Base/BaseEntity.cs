﻿

namespace ShopMicroServices.Common.Data.Base
{
    public abstract class BaseEntity<TType>
    {
        public abstract TType Id { get; set; }
    }
}
