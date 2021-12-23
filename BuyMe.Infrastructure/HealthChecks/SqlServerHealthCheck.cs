using BuyMe.Application.Common.Models;
using BuyMe.Application.TenantSetting.Queries;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Infrastructure.HealthChecks
{
    public class SqlServerHealthCheck : IHealthCheck
    {
        private readonly string _connectionString;
        private readonly IMediator _mediator;

        public SqlServerHealthCheck(IOptions<TenantSettings> tenantSettings, IMediator medatorR)
        {
            _connectionString = tenantSettings.Value.DefaultConnection;
            _mediator = medatorR;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var tenants = await _mediator.Send(new GetAllTenantQuery());
            foreach (var ten in tenants.result)
            {
                ten.ConnectionString ??= _connectionString;
                try
                {
                    await TestConnection(ten.ConnectionString, cancellationToken);
                }
                catch (Exception ex)
                {
                    return new HealthCheckResult(context.Registration.FailureStatus, exception: ex, description: $"Organization {ten.TenantName} Failed");
                }
            }
            return HealthCheckResult.Healthy("All Organization work expected");
        }

        private static async Task TestConnection(string connString, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(connString))
            {
                await connection.OpenAsync(cancellationToken);

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select * from dbo.Companies";
                    await command.ExecuteScalarAsync();
                }
            }
        }
    }
}