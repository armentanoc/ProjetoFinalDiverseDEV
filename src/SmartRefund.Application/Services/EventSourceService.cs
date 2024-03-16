﻿using SmartRefund.Infra.Interfaces;
using SmartRefund.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartRefund.ViewModels.Responses;
using SmartRefund.Application.Interfaces;
using SmartRefund.CustomExceptions;

namespace SmartRefund.Application.Services
{
    public class EventSourceService : IEventSourceService
    {
        private IEventSourceRepository _repository;

        public EventSourceService(IEventSourceRepository repository)
        {
            _repository = repository;
        }

        public async Task<ReceiptEventSourceResponse> GetReceiptEventSourceResponseAsync(string hash, bool isFrontEndpoint)
        {
            var eventSource = await _repository.GetByUniqueHashAsync(hash);
            
            if(eventSource is ReceiptEventSource)
                return new ReceiptEventSourceResponse(eventSource, isFrontEndpoint);

            throw new EntityNotFoundException(hash);
        }
    }
}
