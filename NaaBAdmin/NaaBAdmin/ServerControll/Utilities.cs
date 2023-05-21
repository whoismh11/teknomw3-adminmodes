using System;
using System.Text;
using InfinityScript;
using System.Collections.Generic;
using System.IO;

namespace ServerControll
{
    public partial class NaaBAdmin
    {
        public static Dictionary<string, string> Lang = new Dictionary<string, string>();
        public static Dictionary<string, string> Settings = new Dictionary<string, string>();

        public static Dictionary<string, string> DefaultSettings = new Dictionary<string, string>()
        {
            { "UnfreezeOnGameEnd", "True"},
            { "SpreeMessages", "True"},
        };
        public static Dictionary<string, string> DefaultLang = new Dictionary<string, string>()
        {
            { "Spree_Headshot", "^7: ^2<attacker>^7 Killed ^1<victim>^7 By HeadShot!"},
            { "Spree_Kills_5", "^7: ^2<attacker>^7 Got 5 Kills In A Row!"},
            { "Spree_Kills_10", "^7: ^2<attacker>^7 Got 10 Kills In A Row!"},
            { "Spree_Ended", "^7: ^1<victim>^7's Killing Spree Ended! (^5<killstreak>^7 Kills) He Was Killed By ^2<attacker>^7!"},
            { "Spree_Explosivekill", "^7: ^1<victim>^7 Has Exploded!"},
            { "Spree_Trophykill", "^7: ^2<attacker>^7 Killed ^1<victim>^7 By Trophy!"},
            { "Spree_KnifeKill", "^7: ^2<attacker>^7 Humiliated ^1<victim>^7!"}
        };
        public static string Sett_GetString(string key)
        {
            string value;
            if (!Settings.TryGetValue(key, out value))
            {
                string defval;
                if (DefaultSettings.TryGetValue(key, out defval))
                    return defval;
                else
                    throw new Exception("Settings string not found");
            }
            return value;
        }
        public static string Lang_GetString(string key)
        {
            string value;
            if (!Lang.TryGetValue(key, out value))
            {
                string defval;
                if (DefaultLang.TryGetValue(key, out defval))
                    return defval;
                else
                    throw new Exception("Settings string not found");
            }
            return value;
        }
        public static void CFG_CreateConfig()
        {

            CFG_WriteDictionary(DefaultSettings, ConfigValues.ConfigPath + @"Settings.txt");

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
        public static void CFG_WriteDictionary(Dictionary<string, string> dict, string path)
        {
            List<string> lines = new List<string>();
            foreach (KeyValuePair<string, string> pair in dict)
            {
                lines.Add(string.Join("=", pair.Key, pair.Value));
            }
            File.WriteAllLines(path, lines.ToArray());
        }
        public static partial class ConfigValues
        {
            public static string ConfigPath = @"scripts\NaaBAdmin\";
        }

        public static class Data
        {
            public static int ClantagOffset = 0x01AC5564;
            public static int ClantagPlayerDataSize = 0x38A4;
        }
        public static class Mem
        {
            public static unsafe string ReadString(int address, int maxlen = 0)
            {
                string ret = "";
                maxlen = (maxlen == 0) ? int.MaxValue : maxlen;
                for (; address < address + maxlen && *(byte*)address != 0; address++)
                {
                    ret += Encoding.ASCII.GetString(new byte[] { *(byte*)address });
                }
                return ret;
            }

            public static unsafe void WriteString(int address, string str)
            {
                byte[] strarr = Encoding.ASCII.GetBytes(str);
                foreach (byte ch in strarr)
                {
                    *(byte*)address = ch;
                    address++;
                }
                *(byte*)address = 0;
            }
        }
    }
    public static class WriteLog
    {
        public static void Info(string message)
        {
            Log.Write(LogLevel.Info, message);
        }


        public static string GetClantag(this Entity player)
        {
            if (player == null || !player.IsPlayer)
                return null;
            int address = NaaBAdmin.Data.ClantagPlayerDataSize * player.GetEntityNumber() + NaaBAdmin.Data.ClantagOffset;
            return NaaBAdmin.Mem.ReadString(address, 8);
        }
        public static string Format(this string str, Dictionary<string, string> format)
        {
            foreach (KeyValuePair<string, string> pair in format)
                str = str.Replace(pair.Key, pair.Value);
            return str;
        }
        public static int GetEntityNumber(this Entity player)
        {
            return player.Call<int>("getentitynumber");
        }
    }
}
