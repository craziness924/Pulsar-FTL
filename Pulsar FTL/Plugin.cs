using PulsarPluginLoader; //

namespace SlowerThanLight
{
    public class Plugin : PulsarPlugin
    {
        public override string Version => "0.1";

        public override string Author => "craziness924";

        public override string Name => "SlowerThanLight";

        public override string HarmonyIdentifier()
        {
            return "craziness924.SlowerThanLight";
        }
    }
}
