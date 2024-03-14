﻿
using System.Diagnostics.CodeAnalysis;

namespace SmartRefund.ViewModels.Responses
{
    [ExcludeFromCodeCoverage]
    public class RawVisionResponse
    {
        public string IsReceipt { get; set; }
        public string Total { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public RawVisionResponse()
        {
            
        }
    }
}