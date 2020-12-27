namespace AutoBackupAssistant
{
    public sealed class ConfigKeys
    {
        public string sourceFolder { get; private set; }
        public string targetZipFile { get; private set; }

        public ConfigKeys()
        {
            sourceFolder = "sourceFolder";
            targetZipFile = "targetZipFile";
        }
    }
}
