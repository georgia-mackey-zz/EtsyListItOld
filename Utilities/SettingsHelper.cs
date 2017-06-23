/*using System.Configuration;
using EtsyListingCreator;
using NDesk.Options;

namespace EtsyServices
{
    public static class SettingsHelper
    {
        public static Properties ParseCommandLineArguments(string[] args)
        {

            var commandLineArgs = new Properties();
            var p = new OptionSet() {
                { "wd|Working Directory=", "Sets or changes the directory of the base file.",
                    v => commandLineArgs.WorkingDirectory = v },
                { "od|Output Directory=",
                    "Sets or changes the directory of the output files",
                    v => commandLineArgs.OutputDirectory = v},
                { "wm|Watermark File=",
                    "Sets or changes the path of the watermark files",
                    v => commandLineArgs.WatermarkFile = v}
            };
            try
            {
                p.Parse(args);
                if (commandLineArgs.WorkingDirectory.IsNullOrEmpty())
                {
                    var workingDirectory = GetAppSetting("workingDirectory");
                    if (workingDirectory.IsNullOrEmpty())
                    {
                        throw new AppException("User must specify working directory!  Use -wd {directory} to specify.");
                    }

                    SetAppSetting("workingDirectory", workingDirectory);
                }

                if (commandLineArgs.OutputDirectory.IsNullOrEmpty())
                {
                    var outputDirectory = GetAppSetting("outputDirectory");
                    if (outputDirectory.IsNullOrEmpty())
                    {
                        throw new AppException("User must specify output directory!  Use -od {directory} to specify.");
                    }

                    SetAppSetting("outputDirectory", outputDirectory);
                }

                if (commandLineArgs.WatermarkFile.IsNullOrEmpty())
                {
                    var watermarkFile = GetAppSetting("watermarkFile");
                    if (watermarkFile.IsNullOrEmpty())
                    {
                        throw new AppException("User must specify watermark file!  Use -wm {filePath} to specify.");
                    }

                    SetAppSetting("watermarkFile", watermarkFile);
                }
            }
            catch (OptionException e)
            {
                throw new AppException("Unable to parse commandLine args.  OptionsException: {0}".QuickFormat(e.Message));
            }
            return commandLineArgs;
        }

        public static string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static void SetAppSetting(string key, string value)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            var settings = configFile.AppSettings.Settings;

            if (settings[key] == null || settings[key].ToString().Trim() == string.Empty)
            {
                settings.Add(key, value);
            }
            else
            {
                settings[key].Value = value;
            }

            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }
    }

}*/