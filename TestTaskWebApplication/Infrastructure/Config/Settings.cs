using System.Configuration;
using System.Web.Configuration;

namespace TestTaskWebApplication.Infrastructure.Config
{
    public class Settings : ConfigurationSection
    {
        [ConfigurationProperty("email")]
        public EmailElement Email
        {
            get { return (EmailElement)base["email"]; }
        }

        public ConnectionStringSettingsCollection ConnectionStrings { get; private set; }

        public static Settings GetSettings()
        {
            var settings = WebConfigurationManager
                  .OpenWebConfiguration("~")
                  .GetSection("settings") as Settings;

            settings.ConnectionStrings = ConfigurationManager.ConnectionStrings;

            return settings;
        }
    }
}