﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Logstore.Domain.Interfaces
{
    public interface IEntityBase
    {
        Guid Id { get; }
    }
}
