﻿
using Microsoft.AspNetCore.Mvc;
using SmartRefund.Application.Interfaces;
using SmartRefund.Domain.Models;
using SmartRefund.Infra.Interfaces;

namespace SmartRefund.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteController : ControllerBase
    {
        public IRawVisionReceiptRepository _rawRepository;
        public ILogger<TesteController> _logger;
        public IVisionTranslatorService _translatorService;
        //public MyBackgroundWorker _backgroundWorker;
        public TesteController(IRawVisionReceiptRepository repository, ILogger<TesteController> logger, IVisionTranslatorService service)
        {
            _rawRepository = repository;
            _logger = logger;
            _translatorService = service;
        }

        [HttpGet("{id}")]
        public async Task<RawVisionReceipt> GetItemById([FromRoute] uint id)
        {
            return await _rawRepository.GetAsync(id);
        }

        [HttpGet("testaTraducao/{id}")]
        public async Task<ActionResult<TranslatedVisionReceipt>> TryTestingTranslation([FromRoute] uint id)
        {
            var rawVisionReceipt = await _rawRepository.GetAsync(id);
            var translatedReceipt = await _translatorService.GetTranslatedVisionReceipt(rawVisionReceipt);
            //_backgroundWorker.TranslateAsync(rawVisionReceipt);
            return Ok($"Tradução iniciada para: RawVisionReceipt de Id{rawVisionReceipt.Id}" +
                $"\nResultado: {translatedReceipt}");
        }

        //  You can implement a background worker by creating a class that INHERITS FROM THE BACKGROUND SERVICE 
        //  class provided by ASP.NET Core.This base class simplifies the implementation of a hosted service 
        //  by handling the lifecycle and execution of the background task.

        //using System;
        //using System.Threading;
        //using System.Threading.Tasks;
        //using Microsoft.Extensions.Hosting;
        //using Microsoft.Extensions.Logging;

        //public class MyBackgroundWorker : BackgroundService
        //    {
        //        private readonly ILogger<MyBackgroundWorker> _logger;

        //        public MyBackgroundWorker(ILogger<MyBackgroundWorker> logger)
        //        {
        //            _logger = logger;
        //        }

        //        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        //        {
        //            while (!stoppingToken.IsCancellationRequested)
        //            {
        //                _logger.LogInformation("Background worker is running at: {time}", DateTimeOffset.Now);

        //                // Your background processing logic goes here

        //                // Simulate some work
        //                await Task.Delay(5000, stoppingToken); // Adjust delay as per your requirement
        //            }
        //        }
        //    }

    }
}