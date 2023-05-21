using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityScript;
using System.IO;
using System.Net;
using System.Threading;

namespace changeGametype
{
    public partial class CGT : BaseScript
    {

        public static partial class ConfigValues
        {
            public static string sv_current_dsr = "";

            public static bool settings_servertitle
            {
                get
                {
                    return bool.Parse(Sett_GetString("settings_servertitle"));
                }
            }

            public static string Sett_GetString(string key)
            {
                string value;
                if (!Settings.TryGetValue(key, out value))
                {
                    string defval;
                    if (DefaultSettings.TryGetValue(key, out defval))
                        return defval;
                    else
                        throw new Exception("Setting string not found");
                }
                return value;
            }
            public static string servertitle_map = "";
            public static string servertitle_mode = "";
            public static string mapname = "";
            public static string g_gametype = "";
            public static int settings_dynamic_properties_delay
            {
                get
                {
                    return int.Parse(Sett_GetString("settings_dynamic_properties_delay"));
                }
            }

            public static bool settings_dynamic_properties
            {
                get
                {
                    return bool.Parse(Sett_GetString("settings_dynamic_properties"));
                }
            }
        }

        public CGT()
            : base()
        {
            WriteLog.Info("changeGametype is starting...");

            if (!Directory.Exists(ConfigValues.ConfigPath))
            {
                WriteLog.Info("Creating directory...");
                Directory.CreateDirectory(ConfigValues.ConfigPath);
            }

            #region MODULE LOADING
            MAIN_OnServerStart();
            CFG_OnServerStart();


            if (ConfigValues.settings_dynamic_properties)
                Delay(400, () =>
                {
                    CFG_Dynprop_Apply();
                });
            else
            {

                if (ConfigValues.settings_servertitle)
                    WriteLog.Info("You have to enable \"settings_dynamic_properties\" if you wish to use \"Server Title\"");
            }
            #endregion

        }

        public override void OnStartGameType()
        {
            base.OnStartGameType();
        }


        public void MAIN_OnServerStart()
        {
            WriteLog.Info("Setting up internal stuff...");

        }
    }
}
