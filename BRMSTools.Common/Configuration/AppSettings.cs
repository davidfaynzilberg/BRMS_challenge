using System.Collections.Generic;

namespace BRMSTools.Common.Configuration
{
    /// <summary>
    ///     Binder class for service related information
    /// </summary>
    public class AppSettings
    {
        public string Name { get; set; }

        public string CompassLambdaDestinations { get; set; }

        public string CompassLambdaDeleteDestination { get; set; }
        
        public string Description { get; set; }

        public string DeployedVersion { get; set; }

        public MongoDB MongoDB { get; set; }

        public ReportingSqlDB ReportingSqlDB { get; set; }

        public LogzIOConfiguration LogzIO { get; set; }

        public List<Service> Services { get; set; }

        public string AiringIdLockExpiredSeconds { get; set; }

        public string SessionExpirationTimeMinutes { get; set; }

        public string AiringDeportGraceDays { get; set; }

        public string HealthAgentLifetimeInMinutes { get; set; }

        public JobSchedules JobSchedules { get; set; }

        public CloudQueue CloudQueue { get; set; }

        public bool EnableMediaIdGenrationByPlayList { get; set; }

        public AzureAd AzureAd { get; set; }

        public Jobs Jobs { get; set; }

        public Redis Redis { get; set; }

        public PortalSettings PortalSettings { get; set; }

        public Slack Slack { get; set; }
        
        public DigitalFulfillment DigitalFulfillment { get; set; }
    }

    public class PortalSettings
    {
        public string DigitalFulfillmentUrl { get; set; }

        public string HangFireUrl { get; set; }

        public string TitleSearchApiUrl { get; set; }

        public string OdtApiUrl { get; set; }
    }

    public class DigitalFulfillment
    {
        public string Url { get; set; }
        public string ApiKey { get; set; }
    }

    public class CloudQueue
    {
        public string MqUrl { get; set; }

        public string MqExchange { get; set; }

        public string ReportingQueueID { get; set; }

        public string AmqpUrl { get; set; }

        public string AmqpHost { get; set; }
        
        public string AmqpVhost { get; set; }
    }

    public class Service
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string ApiKey { get; set; }
        
        public string Index { get; set; }
    }

    public class Slack
    {
        public string WebhookUrl { get; set; }

        public string DefaultChannel { get; set; }
    }

    public class JobSchedules
    {
        public string Publisher { get; set; }

        public string Deporter { get; set; }

        public string TitleSync { get; set; }

        public string MailBox { get; set; }

        public string TitleHoarder { get; set; }

        public string DfStatusDeporter { get; set; }

        public string TimeZone { get; set; }

        public string CloudAmqpSync { get; set; }

        public string UserSync { get; set; }

        public string GenreSync { get; set; }

        public int HeartBeatExpireMinute { get; set; }

        public int QueueLockExpireMinute { get; set; }

        public int JobLogExpirationTimeOutInDays { get; set; }

        public int PublisherBimEnabledQueueProcessingLimit { get; set; }

        public int PublisherQueueProcessingLimit { get; set; }
    }

    public class LogzIOConfiguration
    {
        public string AuthToken { get; set; }

        public string Application { get; set; }

        public string ReporterType { get; set; }

        public string Environment { get; set; }
    }

    public class MongoDB
    {
        public string ConnectionString { get; set; }

        public string ConnectionOptionsDefault { get; set; }

        public string ConnectionOptionsPrimary { get; set; }

        public string HangfireConnectionString { get; set; }

        public string HangfireConnectionOptions { get; set; }

        public string DatabaseName
        {
            get
            {
                if (!string.IsNullOrEmpty(ConnectionString))
                {
                    var bits = ConnectionString.Split('/');
                    return bits[bits.Length - 1];
                }

                return string.Empty;
            }
        }

        public string HangFireDatabaseName
        {
            get
            {
                if (!string.IsNullOrEmpty(HangfireConnectionString))
                {
                    var bits = HangfireConnectionString.Split('/');
                    return bits[bits.Length - 1];
                }

                return string.Empty;
            }
        }
    }

    public class ReportingSqlDB
    {
        public string ConnectionString { get; set; }
    }

    public class AzureAd
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Tenant { get; set; }

        public string AadInstance { get; set; }

        public string PostLogoutRedirectUri { get; set; }
    }

    public class Jobs
    {
        public string Url { get; set; }
    }

    public class Redis
    {   
        public string Url { get; set; }

        public string InstanceName { get; set; }
    }
}