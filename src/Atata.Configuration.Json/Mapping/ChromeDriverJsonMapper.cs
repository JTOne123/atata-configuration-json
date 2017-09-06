﻿using System.Linq;
using OpenQA.Selenium.Chrome;

namespace Atata
{
    public class ChromeDriverJsonMapper : DriverJsonMapper<ChromeAtataContextBuilder, ChromeDriverService, ChromeOptions>
    {
        protected override ChromeAtataContextBuilder CreateDriverBuilder(AtataContextBuilder builder)
        {
            return builder.UseChrome();
        }

        protected override void MapOptions(DriverOptionsJsonSection section, ChromeOptions options)
        {
            base.MapOptions(section, options);

            if (section.GlobalAdditionalCapabilities != null)
            {
                foreach (var item in section.GlobalAdditionalCapabilities.ExtraPropertiesMap)
                    options.AddAdditionalCapability(item.Key, item.Value, true);
            }

            if (section.Proxy != null)
                options.Proxy = CreateProxy(section.Proxy);

            if (section.Arguments?.Any() ?? false)
                options.AddArguments(section.Arguments);

            if (section.ExcludedArguments?.Any() ?? false)
                options.AddExcludedArguments(section.ExcludedArguments);

            if (section.Extensions?.Any() ?? false)
                options.AddExtensions(section.Extensions);

            if (section.EncodedExtensions?.Any() ?? false)
                options.AddEncodedExtensions(section.EncodedExtensions);

            if (section.WindowTypes?.Any() ?? false)
                options.AddWindowTypes(section.WindowTypes);

            if (section.UserProfilePreferences != null)
            {
                foreach (var item in section.UserProfilePreferences.ExtraPropertiesMap)
                    options.AddUserProfilePreference(item.Key, item.Value);
            }

            if (section.LocalStatePreferences != null)
            {
                foreach (var item in section.LocalStatePreferences.ExtraPropertiesMap)
                    options.AddLocalStatePreference(item.Key, item.Value);
            }

            if (!string.IsNullOrWhiteSpace(section.MobileEmulationDeviceName))
                options.EnableMobileEmulation(section.MobileEmulationDeviceName);

            if (section.MobileEmulationDeviceSettings != null)
                options.EnableMobileEmulation(section.MobileEmulationDeviceSettings);
        }
    }
}