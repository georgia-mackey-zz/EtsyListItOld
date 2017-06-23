using EtsyListingCreator;
using NDesk.Options;
using Utilities;

namespace EtsyServices
{
    public class CommandLineHelper : ICommandLineHelper
    {
        private readonly ISettingsHelper _settingsHelper;

        public CommandLineHelper(ISettingsHelper settingsHelper)
        {
            _settingsHelper = settingsHelper;
        }
        public static Args ParseCommandLineArguments(string[] args)
        {

            var commandLineArgs = new Args();
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
                    var workingDirectory = _settingsHelper.GetAppSetting("workingDirectory");
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
    }
    
}