using DiscordRPC;
using DiscordRPC.Message;

namespace Discord_Rich_Presence
{
    public static class RPC
    {
        public static DiscordRpcClient Client { get; private set; }
        public static RichPresence Richprec;
        public static string Username = string.Empty;
        public static string UserPfp = "https://www.galaxyswapperv2.com/Icons/InvalidIcon.png";
        public static bool Started = false;
        public static void SetRPC(string Details, string State, bool Timestamp)
        {
            if (Started == true)
                Client.ClearPresence();
            Client = new DiscordRpcClient("878879320079229038");
            RichPresence Richprec = new RichPresence();
            Client.Initialize();
            Client.OnReady += delegate (object sender, ReadyMessage e)
            {
                Username = e.User.Username;
                UserPfp = e.User.GetAvatarURL(User.AvatarFormat.PNG);
            };
            Richprec = new RichPresence()
            {
                Details = Details,
                State = State
            };
            if (Timestamp == true)
                Richprec.Timestamps = Timestamps.Now;
            else
                Richprec.Timestamps = null;
            Client.SetPresence(Richprec);
            Started = true;
        }
    }
}
