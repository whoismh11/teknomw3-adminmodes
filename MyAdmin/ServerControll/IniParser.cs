namespace ServerControll
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Runtime.InteropServices;

    public class IniParser
    {
        private readonly Hashtable hashtable_0 = new Hashtable();
        private readonly string string_0;

        public IniParser(string iniPath)
        {
            TextReader reader = null;
            string str = null;
            string str2 = null;
            string[] strArray = null;
            this.string_0 = iniPath;
            if (!File.Exists(iniPath))
            {
                File.CreateText(iniPath);
            }
            try
            {
                reader = new StreamReader(iniPath);
                for (str = reader.ReadLine(); str != null; str = reader.ReadLine())
                {
                    str = str.Trim();
                    if (str != "")
                    {
                        if (str.StartsWith("[") && str.EndsWith("]"))
                        {
                            str2 = str.Substring(1, str.Length - 2);
                        }
                        else
                        {
                            Struct0 struct2;
                            strArray = str.Split(new char[] { '=' }, 2);
                            string str3 = null;
                            if (str2 == null)
                            {
                                str2 = "OLD_SETTING_NOT_USED";
                            }
                            struct2.string_0 = str2;
                            struct2.string_1 = strArray[0];
                            if (strArray.Length > 1)
                            {
                                str3 = strArray[1];
                            }
                            this.hashtable_0.Add(struct2, str3);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("IniParser", exception, "---");
                throw exception;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public void AddSetting(string sectionName, string settingName)
        {
            this.AddSetting(sectionName, settingName, null);
        }

        public void AddSetting(string sectionName, string settingName, string settingValue)
        {
            Struct0 struct2;
            struct2.string_0 = sectionName;
            struct2.string_1 = settingName;
            if (this.hashtable_0.ContainsKey(struct2))
            {
                this.hashtable_0.Remove(struct2);
            }
            this.hashtable_0.Add(struct2, settingValue);
        }

        public void DeleteSetting(string sectionName, string settingName)
        {
            Struct0 struct2;
            struct2.string_0 = sectionName;
            struct2.string_1 = settingName;
            if (this.hashtable_0.ContainsKey(struct2))
            {
                this.hashtable_0.Remove(struct2);
            }
        }

        public string[] EnumSection(string sectionName)
        {
            ArrayList list = new ArrayList();
            foreach (Struct0 struct2 in this.hashtable_0.Keys)
            {
                if (struct2.string_0 == sectionName)
                {
                    list.Add(struct2.string_1);
                }
            }
            return (string[]) list.ToArray(typeof(string));
        }

        public bool GetBoolSetting(bool predefinito, string sectionName, string settingName)
        {
            try
            {
                Struct0 struct2;
                struct2.string_0 = sectionName;
                struct2.string_1 = settingName;
                if (ServerControll.isBool((string) this.hashtable_0[struct2]))
                {
                    return bool.Parse((string) this.hashtable_0[struct2]);
                }
                this.AddSetting(sectionName, settingName, predefinito.ToString());
                return predefinito;
            }
            catch (Exception)
            {
                this.AddSetting(sectionName, settingName, predefinito.ToString());
                return predefinito;
            }
        }

        public int GetIntSetting(int predefinito, string sectionName, string settingName)
        {
            try
            {
                Struct0 struct2;
                struct2.string_0 = sectionName;
                struct2.string_1 = settingName;
                if (ServerControll.isNum((string) this.hashtable_0[struct2]))
                {
                    int num = int.Parse((string) this.hashtable_0[struct2]);
                    if (num >= 0)
                    {
                        return num;
                    }
                    this.AddSetting(sectionName, settingName, predefinito.ToString());
                    return predefinito;
                }
                this.AddSetting(sectionName, settingName, predefinito.ToString());
                return predefinito;
            }
            catch (Exception)
            {
                this.AddSetting(sectionName, settingName, predefinito.ToString());
                return predefinito;
            }
        }

        public string GetStringSetting(string predefinito, string sectionName, string settingName)
        {
            try
            {
                Struct0 struct2;
                struct2.string_0 = sectionName;
                struct2.string_1 = settingName;
                string str = (string) this.hashtable_0[struct2];
                if (str.Length > 0)
                {
                    return (string) this.hashtable_0[struct2];
                }
                this.AddSetting(sectionName, settingName, predefinito);
                return predefinito;
            }
            catch (Exception)
            {
                this.AddSetting(sectionName, settingName, predefinito);
                return predefinito;
            }
        }

        public string GetStringSettingNull(string sectionName, string settingName)
        {
            try
            {
                Struct0 struct2;
                struct2.string_0 = sectionName;
                struct2.string_1 = settingName;
                return (string) this.hashtable_0[struct2];
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public void SaveSettings()
        {
            this.SaveSettings(this.string_0);
        }

        public void SaveSettings(string newFilePath)
        {
            ArrayList list = new ArrayList();
            string str = "";
            string str2 = "";
            foreach (Struct0 struct2 in this.hashtable_0.Keys)
            {
                if (!list.Contains(struct2.string_0))
                {
                    list.Add(struct2.string_0);
                }
            }
            foreach (string str3 in list)
            {
                str2 = str2 + "[" + str3 + "]\r\n";
                foreach (Struct0 struct2 in this.hashtable_0.Keys)
                {
                    if (struct2.string_0 == str3)
                    {
                        str = (string) this.hashtable_0[struct2];
                        if (str != null)
                        {
                            str = "=" + str;
                        }
                        str2 = str2 + struct2.string_1 + str + "\r\n";
                    }
                }
                str2 = str2 + "\r\n";
            }
            try
            {
                TextWriter writer = new StreamWriter(newFilePath);
                writer.Write(str2);
                writer.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Struct0
        {
            public string string_0;
            public string string_1;
        }
    }
}

