﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartRefund.Domain.Models;
using SmartRefund.Domain.Models.Enums;

namespace SmartRefund.ViewModels.Responses
{
    public class InternalReceiptResponse
    {
        public uint EmployeeId { get; private set; }
        public DateTime CreationDate { get; private set; }
        public InternalReceiptStatusEnum Status { get; private set; }
        public string Image { get; private set; }


        public InternalReceiptResponse(InternalReceipt internalReceipt)
        {
            EmployeeId = internalReceipt.EmployeeId;
            CreationDate = internalReceipt.CreationDate;
            Status = internalReceipt.Status;
            if (internalReceipt.Image != null) { Image = "Saved Image"; }
                else { Image = "The file is missing"; };
        }
    }
}