﻿
using System.Diagnostics.CodeAnalysis;

namespace SmartRefund.ViewModels.Responses
{
    [ExcludeFromCodeCoverage]
    public class TranslatedReceiptResponse
    {
        public string UniqueHash { get; set; }
        public uint EmployeeId { get; set; }
        public decimal Total { get; set; }
        public string Category { get; set; }    
        public string Status { get; set; }
        public string Description { get; set; }

        public TranslatedReceiptResponse()
        {
            // required by EF
        }
        public TranslatedReceiptResponse(string uniqueHash, uint employeeId, decimal total, string category, string status, string description)
        {
            UniqueHash = uniqueHash;
            EmployeeId = employeeId;
            Total = total;
            Category = category;
            Status = status;
            Description = description;
        }
    }
}
