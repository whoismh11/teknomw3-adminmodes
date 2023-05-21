using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using InfinityScript;

namespace changeGametype
{
    public partial class CGT
    {
        public static Dictionary<string, string> Settings = new Dictionary<string, string>();


        public static Dictionary<string, string> DefaultSettings = new Dictionary<string, string>()
        {
            { "settings_dynamic_properties", "true" },
            { "settings_dynamic_properties_delay", "400" },
            { "settings_servertitle", "true" },
        };
        public static void CFG_ReadConfig()
        {
            WriteLog.Info("Reading config...");
            if (!File.Exists(ConfigValues.ConfigPath + @"gtSettings.txt"))
                CFG_CreateConfig();
            CFG_ReadDictionary(ConfigValues.ConfigPath + @"gtSettings.txt", ref Settings);

            WriteLog.Info("Done reading config...");
        }

        public static void CFG_CreateConfig()
        {
            WriteLog.Warning("Config files not found. Creating new ones...");

            CFG_WriteDictionary(DefaultSettings, ConfigValues.ConfigPath + @"gtSettings.txt");
        }

        /* ############## DYNAMIC_PROPERTIES ############### */
        /* ############# basic implementation ############## */
        public void CFG_Dynprop_Init()
        {
            if (System.IO.Directory.Exists(@"admin\"))
            {
                WriteLog.Error("Failed loading dynamic_properties feature");
                WriteLog.Error("\"admin/\" folder exsists! Delete it, and use \"players2/\" instead!");
                return;
            }
            else
            {

                string DSR = @"players2/" + ConfigValues.sv_current_dsr;
                List<string> DSRData = new List<string>();
                if (System.IO.File.Exists(DSR))
                    DSRData = System.IO.File.ReadAllLines(DSR).ToList();
                else
                {
                    WriteLog.Error("Error loading dynamic_properties feature: DSR not exists! \"" + DSR + "\"");
                    return;
                }

                List<Dvar> dvars = new List<Dvar>();

                // start of parsing

                int count = 0;

                Action _h_settings = () =>
                {
                    DSRData.ForEach((s) =>
                    {

                        /* 
                         *  //#changeGametype settings <setting> = <value> 
                         */
                        Match match = (new Regex(@"^[\s]{0,31}\/\/#changeGametype[\s]{1,31}settings[\s]{1,31}([a-z_]{0,63})[\s]{0,31}=[\s]{0,31}(.*)?$", RegexOptions.IgnoreCase))
                                      .Match(s);

                        if (match.Success)
                        {
                            string prop = match.Groups[1].Value.ToLower();
                            if (Settings.Keys.Contains(prop))
                            {
                                count++;
                                switch (prop)
                                {
                                    case "settings_dynamic_properties_delay":
                                        WriteLog.Debug("dynamic_properties:: unable to override \"" + prop + "\"");
                                        break;
                                    case "settings_dynamic_properties":
                                        WriteLog.Debug("dynamic_properties:: I like the way you're thinking, but nope.");
                                        break;
                                }
                                Settings[prop] = match.Groups[2].Value;
                            }
                            else
                            {
                                WriteLog.Warning("Unknown setting: " + prop);
                            }
                        }
                        if (ConfigValues.settings_servertitle)
                        {
                            /* 
                             *  //#changeGametype servertitle map = <value> 
                             *  //#changeGametype servertitle mode = <value> 
                             */
                            match = (new Regex(@"^[\s]{0,31}\/\/#changeGametype[\s]{1,31}servertitle[\s]{1,31}([a-z_]{0,63})[\s]{0,31}=[\s]{0,31}(.*)?$", RegexOptions.IgnoreCase))
                                          .Match(s);
                            switch (match.Groups[1].Value.ToLowerInvariant())
                            {
                                case "map":
                                    ConfigValues.servertitle_map = match.Groups[2].Value + this.Call<string>("getdvar", "mapname").Replace("mp_dome", "Dome").Replace("mp_paris", "Resistance").Replace("mp_village", "Village").Replace("mp_bootleg", "Bootleg").Replace("mp_carbon", "Carbon").Replace("mp_interchange", "Interchange").Replace("mp_hardhat", "Hardhat").Replace("mp_exchange", "Downturn").Replace("mp_radar", "Outpost").Replace("mp_hillside_ss", "Gateway").Replace("mp_restrepo_ss", "Lookout").Replace("mp_overwatch", "Overwatch").Replace("mp_lambeth", "Fallen").Replace("mp_terminal_cls", "Terminal").Replace("mp_underground", "Underground").Replace("mp_plaza2", "Arkaden").Replace("mp_shipbreaker", "Decommision").Replace("mp_nola", "Parish").Replace("mp_roughneck", "Off Shore").Replace("mp_boardwalk", "Boardwalk").Replace("mp_italy", "Pizza").Replace("mp_moab", "Gulch").Replace("mp_cement", "Foundation").Replace("mp_morningwood", "Black Box").Replace("mp_meteora", "Sanctuary").Replace("mp_aground_ss", "Aground").Replace("mp_burn_ss", "U-Turn").Replace("mp_courtyard_ss", "Erosion").Replace("mp_park", "Liberation").Replace("mp_qadeem", "Oasis").Replace("mp_six_ss", "Vortex").Replace("mp_alpha", "Lockdown").Replace("mp_bravo", "Mission").Replace("mp_mogadishu", "Bakaara").Replace("mp_seatown", "Seatown");
                                    count++;
                                    break;
                                case "mode":
                                    ConfigValues.servertitle_mode = match.Groups[2].Value;
                                    count++;
                                    break;
                            }
                        }
                    });
                };

                _h_settings();

                if (count > 0)
                    WriteLog.Info(string.Format("dynamic_properties:: Done reading {0} settings from \"{1}\"", count, DSR));

            }
        }

        public void CFG_Dynprop_Apply()
        {
            WriteLog.Debug(String.Format("Sleep({0})", ConfigValues.settings_dynamic_properties_delay.ToString()));
            ConfigValues.sv_current_dsr = UTILS_GetDSRName();
            WriteLog.Debug("dsr: " + ConfigValues.sv_current_dsr);
            CFG_Dynprop_Init();


            if (ConfigValues.settings_servertitle)
                UTILS_ServerTitle_MapFormat();
        }


        public static void CFG_OnServerStart()
        {
            CFG_ReadConfig();
        }

        public static void CFG_WriteDictionary(Dictionary<string, string> dict, string path)
        {
            List<string> lines = new List<string>();
            foreach (KeyValuePair<string, string> pair in dict)
            {
                lines.Add(string.Join("=", pair.Key, pair.Value));
            }
            File.WriteAllLines(path, lines.ToArray());
        }

        public static void CFG_ReadDictionary(string path, ref Dictionary<string, string> dict)
        {
            foreach (string line in File.ReadAllLines(path))
            {
                int index = line.IndexOf('=');
                if (index == line.Length || index == 0)
                    continue;
                string key = line.Substring(0, index);
                string value = line.Substring(index + 1);
                dict[key] = value;
            }
        }
    }
}
