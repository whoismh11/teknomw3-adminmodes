using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityScript;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Threading;

namespace changeGametype
{
    public partial class CGT
    {
        System.Globalization.CultureInfo Culture = System.Globalization.CultureInfo.InvariantCulture;

        //typedef
        public struct Dvar
        {
            [XmlAttribute]
            public string key;
            [XmlAttribute]
            public string value;
        }
        public class Dvars : List<Dvar> { };
        //-------
        public static partial class ConfigValues
        {
#if DEBUG
            public static string Version = "v1.3d";
#else
            public static string Version = "v1.3";
#endif
            public static string ConfigPath = @"scripts\NaaBAdmin_iSniPe\Settings\";



#if DEBUG
            public static bool DEBUG = true;
#else
            public static bool DEBUG = false;
#endif
            public static Dictionary<string, string> AvailableMaps = Data.StandardMapNames;
            public static class DEBUGOPT
            {
                public static bool PERMSFORALL = false;
            }
        }

        public static class Data
        {

            public static int XNADDROffset = 0x049EBD00;
            public static int XNADDRDataSize = 0x78688;


            public static List<char> HexChars = new List<char>()
            {
                'a', 'b', 'c', 'd', 'e', 'f', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            };

            public static Dictionary<string, string> Colors = new Dictionary<string, string>()
            {
                {"^1", "red"},
                {"^2", "green"},
                {"^3", "yellow"},
                {"^4", "blue"},
                {"^5", "lightblue"},
                {"^6", "purple"},
                {"^7", "white"},
                {"^8", "defmapcolor"},
                {"^9", "grey"},
                {"^0", "black"},
                {"^;", "yaleblue"},
                {"^:", "orange"}
            };
            public static Dictionary<string, string> StandardMapNames = new Dictionary<string, string>()
            {
                {"dome", "mp_dome"},
                {"mission", "mp_bravo"},
                {"lockdown", "mp_alpha"},
                {"bootleg", "mp_bootleg"},
                {"hardhat", "mp_hardhat"},
                {"bakaara", "mp_mogadishu"},
                {"arkaden", "mp_plaza2"},
                {"carbon", "mp_carbon"},
                {"fallen", "mp_lambeth"},
                {"outpost", "mp_radar"},
                {"downturn", "mp_exchange"},
                {"interchange", "mp_interchange"},
                {"resistance", "mp_paris"},
                {"seatown", "mp_seatown"},
                {"village", "mp_village"},
                {"underground", "mp_underground"}
            };

            public static Dictionary<string, string> DLCMapNames = new Dictionary<string, string>()
            {
                {"piazza", "mp_piazza"},
                {"liberation", "mp_italy"},
                {"blackbox", "mp_plane"},
                {"overwatch", "mp_overwatch"},
                {"aground", "mp_aground_ss"},
                {"erosion", "mp_courtyard_ss"},
                {"foundation", "mp_cement"},
                {"getaway", "mp_hillside_ss"},
                {"sanctuary", "mp_museum"},
                {"oasis", "mp_qadeem"},
                {"lookout", "mp_restrepo_ss"},
                {"terminal", "mp_terminal_cls"},
                {"intersection", "mp_crosswalk_ss"},
                {"u-turn", "mp_burn_ss"},
                {"vortex", "mp_six_ss"},
                {"gulch", "mp_moab"},
                {"boardwalk", "mp_boardwalk"},
                {"parish", "mp_parish"},
                {"offshore", "mp_roughneck"},
                {"decommision", "mp_shipbreaker"}   
            };
            public static Dictionary<string, string> AllMapNames = StandardMapNames.Concat(DLCMapNames).GroupBy(d => d.Key).ToDictionary(d => d.Key, d => d.First().Value);
        }

        public static class WriteLog
        {
            public static void Info(string message)
            {
                Log.Write(LogLevel.Info, message);
            }

            public static void Error(string message)
            {
                Log.Write(LogLevel.Error, message);
            }

            public static void Warning(string message)
            {
                Log.Write(LogLevel.Warning, message);
            }

            public static void Debug(string message)
            {
                if (ConfigValues.DEBUG)
                    Log.Write(LogLevel.Debug, message);
            }
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






        public List<string> FindMaps(string identifier)
        {
            return (from map in ConfigValues.AvailableMaps
                    where map.Key.Contains(identifier) || map.Value.Contains(identifier)
                    select map.Value).ToList();
        }

        public string FindSingleMap(string identifier)
        {
            List<string> maps = FindMaps(identifier);
            if (maps.Count != 1)
                return null;
            return maps[0];
        }

        public string DevMapName2Mapname(string devMapname)
        {
            List<string> maps =
                (from map in ConfigValues.AvailableMaps
                 where map.Value.Contains(devMapname)
                 select map.Key).ToList();
            if (maps.Count != 1)
                return null;
            return maps[0];
        }

        public static bool ParseCommand(string CommandToBeParsed, int ArgumentAmount, out string[] arguments, out string optionalarguments)
        {
            CommandToBeParsed = CommandToBeParsed.TrimEnd(' ');
            List<string> list = new List<string>();
            if (CommandToBeParsed.IndexOf(' ') == -1)
            {
                arguments = new string[0];
                optionalarguments = null;
                if (ArgumentAmount == 0)
                    return true;
                else
                    return false;
            }
            CommandToBeParsed = CommandToBeParsed.Substring(CommandToBeParsed.IndexOf(' ') + 1);
            while (list.Count < ArgumentAmount)
            {
                int length = CommandToBeParsed.IndexOf(' ');
                if (length == -1)
                {
                    list.Add(CommandToBeParsed);
                    CommandToBeParsed = null;
                }
                else
                {
                    if (CommandToBeParsed == null)
                    {
                        arguments = new string[0];
                        optionalarguments = null;
                        return false;
                    }
                    list.Add(CommandToBeParsed.Substring(0, length));
                    CommandToBeParsed = CommandToBeParsed.Substring(CommandToBeParsed.IndexOf(' ') + 1);
                }
            }
            arguments = list.ToArray();
            optionalarguments = CommandToBeParsed;
            return true;
        }

        public IEnumerable<Entity> GetEntities()
        {
            for (int i = 0; i < 2048; i++)
                yield return Entity.GetEntity(i);
        }





        public bool UTILS_ParseBool(string message)
        {
            message = message.ToLowerInvariant().Trim();
            if (message == "y" || message == "ye" || message == "yes" || message == "on" || message == "true" || message == "1")
                return true;
            return false;
        }

        public bool UTILS_ParseTimeSpan(string message, out TimeSpan timespan)
        {
            timespan = TimeSpan.Zero;
            try
            {
                string[] parts = message.Split(',');
                foreach (string part in parts)
                {
                    int time = int.Parse(part.Substring(0, part.Length - 1));
                    if (time == 0)
                        return false;
                    if (part.EndsWith("h"))
                        timespan += new TimeSpan(time, 0, 0);
                    if (part.EndsWith("m"))
                        timespan += new TimeSpan(0, time, 0);
                    if (part.EndsWith("s"))
                        timespan += new TimeSpan(0, 0, time);
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string UTILS_GetDvar(string dvar)
        {
            return Call<string>("getdvar", dvar);
        }

        public void UTILS_SetDvar(string dvar, string value)
        {
            Call<string>("setdvar", dvar, value);
        }


        public static void ExecuteCommand(string command)
        {
            Utilities.ExecuteCommand(command);
        }




        public string UTILS_GetDefCDvar(string key)
        {
            return Call<string>("getdvar", key);
        }


        public T UTILS_GetFieldSafe<T>(Entity player, string field)
        {
            if (player.HasField(field))
                return player.GetField<T>(field);
            return default(T);
        }




        //its not funny
        public void Delay(int delay, Action action)
        {
            bool flag = false;
            OnInterval(10, () =>
            {
                if (flag)
                {
                    action();
                    return false;
                }
                return true;
            });

            (new Thread(() =>
            {
                Thread.Sleep(delay);
                flag = true;
            })).Start();
        }

        public string UTILS_GetDSRName()
        {
            //return changeGametype.Mem.ReadString(0x01B3ECB3, 32);
            return Call<string>("getdvar", "sv_current_dsr");
        }



        public void UTILS_ServerTitle_MapFormat()
        {
            string mapname = DevMapName2Mapname(UTILS_GetDvar("mapname"));

            // ToTitleCase
            if (!String.IsNullOrEmpty(mapname))
            {
                Char[] ca = mapname.ToCharArray();
                ca[0] = Char.ToUpperInvariant(ca[0]);
                mapname = new string(ca);
            }

            UTILS_ServerTitle(ConfigValues.servertitle_map.Format(new Dictionary<string, string>()
                {
                    {"<map>", mapname }
                })
                , ConfigValues.servertitle_mode);
        }

        public List<Dvar> UTILS_DvarListUnion(List<Dvar> set1, List<Dvar> set2)
        {
            Dictionary<string, string> _dvars = set1.ToDictionary(x => x.key.ToLowerInvariant(), x => x.value);
            foreach (Dvar dvar in set2)
            {
                string key = dvar.key.ToLowerInvariant();
                if (_dvars.ContainsKey(key))
                    _dvars[key] = dvar.value;
                else
                    _dvars.Add(key, dvar.value);
            }
            set1.Clear();
            foreach (KeyValuePair<string, string> dvar in _dvars)
                set1.Add(new Dvar { key = dvar.Key, value = dvar.Value });
            return set1;
        }

        public List<Dvar> UTILS_DvarListRelativeComplement(List<Dvar> set1, List<string> set2)
        {
            Dictionary<string, string> _dvars = set1.ToDictionary(x => x.key.ToLowerInvariant(), x => x.value);
            foreach (string dvar in set2)
                if (_dvars.ContainsKey(dvar.ToLowerInvariant()))
                    _dvars.Remove(dvar.ToLowerInvariant());
            set1.Clear();
            foreach (KeyValuePair<string, string> dvar in _dvars)
                set1.Add(new Dvar { key = dvar.Key, value = dvar.Value });
            return set1;
        }

        //this is A wrong way to convert encodings :)
        public static string Win1251xUTF8(string s)
        {
            string utf8_String = s;
            byte[] bytes = Encoding.Default.GetBytes(utf8_String);
            for (int i = 0; i < bytes.Length - 1; i++)
            {
                if ((bytes[i] == 0xC3) && (bytes[i + 1] >= 0x80) && (bytes[i + 1] <= 0xAF)) //А-Яа-п
                { bytes[i] = 0xD0; bytes[i + 1] += 0x10; }
                else
                    if ((bytes[i] == 0xC3) && (bytes[i + 1] >= 0xB0) && (bytes[i + 1] <= 0xBF)) //р-я
                    { bytes[i] = 0xD1; bytes[i + 1] -= 0x30; }
                    else
                        if ((bytes[i] == 0xC2) && (bytes[i + 1] == 0xA8)) //Ё
                        { bytes[i] = 0xD0; bytes[i + 1] = 0x81; }
                        else
                            if ((bytes[i] == 0xC2) && (bytes[i + 1] == 0xB8)) //ё
                            { bytes[i] = 0xD1; bytes[i + 1] = 0x91; }
            }
            utf8_String = Encoding.UTF8.GetString(bytes);
            return utf8_String;
        }

    }

    public static partial class Extensions
    {
        public static string RemoveColors(this string message)
        {
            foreach (string color in CGT.Data.Colors.Keys)
                message = message.Replace(color, "");
            return message;
        }


        public static void IPrintLnBold(this Entity player, string message)
        {
            player.Call("iprintlnbold", message);
        }

        public static void IPrintLn(this Entity player, string message)
        {
            player.Call("iprintln", message);
        }


        public static string Format(this string str, Dictionary<string, string> format)
        {
            foreach (KeyValuePair<string, string> pair in format)
                str = str.Replace(pair.Key, pair.Value);
            return str;
        }

        public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key)
        {
            TValue value;
            if (dict.TryGetValue(key, out value))
                return value;
            throw new ArgumentOutOfRangeException();
        }

        public static string[] Condense(this string[] arr, int condenselevel = 40, string separator = ", ")
        {
            if (arr.Length < 1)
                return arr;
            List<string> lines = new List<string>();
            int index = 0;
            string line = arr[index++];
            while (index < arr.Length)
            {
                if ((line + separator + arr[index]).RemoveColors().Length > condenselevel)
                {
                    lines.Add(line);
                    line = arr[index];
                    index++;
                    continue;
                }
                line += separator + arr[index];
                index++;
            }
            lines.Add(line);
            return lines.ToArray();
        }

        public static bool IsHex(this char ch)
        {
            return CGT.Data.HexChars.Contains(ch);
        }
    }
}
