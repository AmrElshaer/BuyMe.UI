using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.TenantSetting.Commonds;
using BuyMe.Domain.Entities;
using BuyMe.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Infrastructure.BackgroundJobs
{
    [DisallowConcurrentExecution]
    public class MonitorTenantJob : IJob
    {
        private readonly ILogger<MonitorTenantJob> _logger;
        private readonly IEmailService _emailService;
        private readonly ITenantDbContext _context;

        public MonitorTenantJob(ILogger<MonitorTenantJob> logger
            , IEmailService emailService
            , ITenantDbContext context)
        {
            _logger = logger;
            _emailService = emailService;
            _context = context;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Check messages!");
            var messages = await _context.OutboxMessages.
                Where(c => (c.Type == TenantEvent.Created || c.Type == TenantEvent.Updated)&& c.IsProcessed == false)
                .OrderBy(c => c.Data).ToListAsync();
            foreach (var message in messages)
            {
                var data = JsonConvert.DeserializeObject<TenantEvent>(message.Data);
                
                await _emailService.SendEmailAsync("Admin@buyme.com", "BuyMe - Tenants Tracking"
                    , $"{message.Type} : Name {data.Name} at {message.Time.ToShortDateString()}");

                message.MarkAsProcessed(DateTime.Now);
                await _context.SaveChangesAsync();
            }

        }
    }
}
