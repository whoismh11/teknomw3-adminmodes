namespace ns0
{
    using InfinityScript;
    using ns6;
    using ServerControll;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Net;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;

    internal sealed class Class67
    {
        [DllImport("kernel32.dll")]
        /* private scope */ internal static extern int ReadProcessMemory(IntPtr intptr_0, IntPtr intptr_1, [In, Out] byte[] byte_0, uint uint_0, out IntPtr intptr_2);
        /* private scope */ internal static void smethod_0(Entity entity_0, ServerControll serverControll_0, Entity entity_1)
        {
            ServerControll.Class16 class2 = new ServerControll.Class16 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0,
                vector3_0 = entity_1.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" })
            };
            class2.vector3_0.X -= 5f;
            class2.vector3_0.Y -= 5f;
            class2.vector3_0.Z -= 10f;
            int num = serverControll_0.Call<int>("loadfx", new Parameter[] { "explosions/sentry_gun_explosion" });
            entity_1.Call("playSound", new Parameter[] { "grenade_explode_metal" });
            serverControll_0.Call("PlayFX", new Parameter[] { num, new Vector3(entity_1.Origin.X, entity_1.Origin.Y, entity_1.Origin.Z + 25f) });
            entity_1.AfterDelay(20, new Action<Entity>(class2.method_0));
        }

        /* private scope */ internal static int smethod_1()
        {
            Random random = new Random();
            return random.Next(0x3e8, 0xfa0);
        }

        /* private scope */ internal static void smethod_10(ServerControll serverControll_0, Entity entity_0, string string_0)
        {
            string str = string.Concat(new object[] { "LogCommand_", DateTime.Now.Day, ".", DateTime.Now.Month, ".", DateTime.Now.Year, ".txt" });
            using (StreamWriter writer = new StreamWriter(ServerControll.DirLogChat + str, true))
            {
                string str2 = string.Concat(new object[] { "(", ServerControll.MapName, ":", ServerControll.TypeMap, ":", ServerControll.string_0, ") ", DateTime.Now.Hour, ":", DateTime.Now.Minute, ":", DateTime.Now.Second, " ", serverControll_0.getPlayerName(entity_0), ": ", string_0 });
                writer.WriteLine(str2);
                writer.Close();
            }
        }

        /* private scope */ internal static void smethod_100(Class75.Class78 class78_0, int int_0, int int_1)
        {
            class78_0.int_1 += int_0;
            if (class78_0.int_1 > 0x8000)
            {
                throw new InvalidOperationException();
            }
            int num = (class78_0.int_0 - int_1) & 0x7fff;
            int num2 = 0x8000 - int_0;
            if ((num > num2) || (class78_0.int_0 >= num2))
            {
                smethod_49(class78_0, num, int_0, int_1);
            }
            else if (int_0 > int_1)
            {
                while (int_0-- > 0)
                {
                    class78_0.byte_0[class78_0.int_0++] = class78_0.byte_0[num++];
                }
            }
            else
            {
                Array.Copy(class78_0.byte_0, num, class78_0.byte_0, class78_0.int_0, int_0);
                class78_0.int_0 += int_0;
            }
        }

        /* private scope */ internal static void smethod_101(ServerControll serverControll_0, string string_0)
        {
            Utilities.RawSayAll(ServerControll.BotName + "^7: " + string_0);
        }

        /* private scope */ internal static void smethod_102(ServerControll serverControll_0, Entity entity_0)
        {
            Func<Entity, bool> function = null;
            try
            {
                entity_0.SetField("visto", 0);
                if (function == null)
                {
                    function = new Func<Entity, bool>(serverControll_0.method_46);
                }
                entity_0.OnInterval(30, function);
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "AIMBotBot");
            }
        }

        /* private scope */ internal static void smethod_103(Entity entity_0, ServerControll serverControll_0)
        {
            Action<Entity> function = null;
            ServerControll.Class15 class2 = new ServerControll.Class15 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                if (function == null)
                {
                    function = new Action<Entity>(class2.method_0);
                }
                class2.entity_0.AfterDelay(0x7d0, function);
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "AntinoNick");
            }
        }

        /* private scope */ internal static void smethod_104(Entity entity_0, Entity entity_1)
        {
            entity_1.Call("setorigin", new Parameter[] { entity_0.Origin });
            entity_1.Call("iprintlnbold", new Parameter[] { "^7You Teleported From ^5" + entity_0.Name });
        }

        /* private scope */ internal static void smethod_105(ServerControll serverControll_0, Entity entity_0)
        {
            ServerControll.Class14 class2 = new ServerControll.Class14 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            if (ServerControll.FlagRadar >= 30)
            {
                ServerControll.FlagRadar = 1;
            }
            else
            {
                ServerControll.FlagRadar++;
            }
            class2.entity_0.SetField("FlagRadar", ServerControll.FlagRadar);
            class2.int_0 = class2.entity_0.GetField<int>("FlagRadar");
            smethod_101(serverControll_0, "^5" + serverControll_0.getPlayerName(class2.entity_0) + " ^7Blocked To Camp, Watch The Minimap To Find");
            class2.entity_0.OnInterval(0x1388, new Func<Entity, bool>(class2.method_0));
        }

        /* private scope */ internal static string[] smethod_106(ServerControll serverControll_0, string[] string_0)
        {
            string str = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            int index = 0;
            while (index < string_0.Length)
            {
                str = str + ServerControll.sep1 + string_0[index];
                if (str.Length > 100)
                {
                    break;
                }
                index++;
            }
            if (str != "")
            {
                str = str.TrimStart(new char[] { ServerControll.sep1 });
                index++;
            }
            int num2 = index;
            while (num2 < string_0.Length)
            {
                str2 = str2 + ServerControll.sep1 + string_0[num2];
                if (str2.Length > 100)
                {
                    break;
                }
                num2++;
            }
            if (str2 != "")
            {
                str2 = str2.TrimStart(new char[] { ServerControll.sep1 });
                num2++;
            }
            int num3 = num2;
            while (num3 < string_0.Length)
            {
                str3 = str3 + ServerControll.sep1 + string_0[num3];
                if (str3.Length > 100)
                {
                    break;
                }
                num3++;
            }
            if (str3 != "")
            {
                str3 = str3.TrimStart(new char[] { ServerControll.sep1 });
                num3++;
            }
            while (num3 < string_0.Length)
            {
                str4 = str4 + ServerControll.sep1 + string_0[num3];
                if (str4.Length > 100)
                {
                    break;
                }
                num3++;
            }
            if (str4 != "")
            {
                str4 = str4.TrimStart(new char[] { ServerControll.sep1 });
            }
            return string.Concat(new object[] { str, ServerControll.sep5, str2, ServerControll.sep5, str3, ServerControll.sep5, str4 }).TrimEnd(new char[] { ServerControll.sep5 }).Split(new char[] { ServerControll.sep5 });
        }

        /* private scope */
        internal static void smethod_107(Entity entity_0, ServerControll serverControll_0, string string_0)
        {
            ServerControll.Class9 class2 = new ServerControll.Class9
            {
                hudElem_0 = HudElem.CreateFontString(entity_0, "hudbig", 1f)
            };
            class2.hudElem_0.X = -90;
            class2.hudElem_0.Y = 225;
            Parameter[] parameterArray = new Parameter[] { 250, 8000, 1000 };
            class2.hudElem_0.Alpha = 1f;
            class2.hudElem_0.Call("setpulsefx", parameterArray);
            class2.hudElem_0.SetText(string_0);
            class2.hudElem_0.Call("moveovertime", 2f);
            class2.hudElem_0.X = 255;
            class2.hudElem_0.SetField("glowcolor", new Vector3(0f, 0.5f, 0.5f));
            serverControll_0.AfterDelay(0x2710, new Action(class2.method_0));
           ////////////////////////////////////////////////////////////////////
            str2 = ServerControll.WelcomeToMess.Replace("<nameclan>", ServerControll.NomeClan);
            BOTTOM2 = HudElem.CreateFontString(entity_0, "hudbig", 1f);
            BOTTOM2.X = 900;
            BOTTOM2.Y = 250;
            BOTTOM2.Call("setpulsefx", parameterArray);
            BOTTOM2.Alpha = 1f;
            BOTTOM2.SetField("glowcolor", new Vector3(0f, 0.5f, 0.5f));
            BOTTOM2.GlowAlpha = 2f;
            BOTTOM2.SetText(str2);
            BOTTOM2.Call("moveovertime", 2f);
            BOTTOM2.X = 225;
        }
        public static HudElem BOTTOM2 { get; set; }

        /* private scope */
        internal static void smethod_108(Entity entity_0, ServerControll serverControll_0)
        {
            ServerControll.Class29 class3 = new ServerControll.Class29 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            bool flag = false;
            if (System.IO.File.Exists(ServerControll.DirConfMove + ServerControll.FilePermBan))
            {
                string[] strArray = System.IO.File.ReadAllLines(ServerControll.DirConfMove + ServerControll.FilePermBan);
                for (int i = 0; i < strArray.Length; i++)
                {
                    Action function = null;
                    Action action2 = null;
                    ServerControll.Class30 class2 = new ServerControll.Class30 {
                        class29_0 = class3
                    };
                    string[] strArray2 = strArray[i].Split(new char[] { ServerControll.sep1 });
                    int index = strArray2.Length - 1;
                    if (!strArray2[index].Contains("."))
                    {
                        class2.string_0 = "^7PermBan For ^5" + strArray2[index];
                    }
                    else
                    {
                        class2.string_0 = "^7PermBan From The ^5" + ServerControll.NomeClan + " ^7Server";
                    }
                    if ((ServerControll.InfoBan != "null") && (ServerControll.InfoBan != null))
                    {
                        class2.string_0 = class2.string_0 + "^7, Request UnBan ^5" + ServerControll.InfoBan;
                    }
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (ServerControll.Piattaforma.StartsWith("te"))
                        {
                            if (((!(strArray2[j] == serverControll_0.getPlayerGuid(class3.entity_0)) && !(strArray2[j] == serverControll_0.getPlayerID(class3.entity_0))) && (!(strArray2[j] == serverControll_0.getPlayerXuid(class3.entity_0)) && !(strArray2[j] == serverControll_0.getPlayerHWID(class3.entity_0)))) && !(strArray2[j] == serverControll_0.getPlayerIP(class3.entity_0)))
                            {
                                continue;
                            }
                            goto Label_0233;
                        }
                        if ((((strArray2[j] == serverControll_0.getPlayerName(class3.entity_0)) || (strArray2[j] == serverControll_0.getPlayerGuid(class3.entity_0))) || ((strArray2[j] == serverControll_0.getPlayerID(class3.entity_0)) || (strArray2[j] == serverControll_0.getPlayerXuid(class3.entity_0)))) || (strArray2[j] == serverControll_0.getPlayerIP(class3.entity_0)))
                        {
                            goto Label_0257;
                        }
                    }
                    continue;
                Label_0233:
                    if (function == null)
                    {
                        function = new Action(class2.method_0);
                    }
                    serverControll_0.AfterDelay(0x7d0, function);
                    flag = true;
                    continue;
                Label_0257:
                    if (action2 == null)
                    {
                        action2 = new Action(class2.method_1);
                    }
                    serverControll_0.AfterDelay(0x7d0, action2);
                    flag = true;
                }
            }
            if (!flag)
            {
                smethod_118(serverControll_0, class3.entity_0);
            }
        }

        /* private scope */ internal static int smethod_109(Class75.Stream0 stream0_0)
        {
            return (stream0_0.ReadByte() | (stream0_0.ReadByte() << 8));
        }

        /* private scope */ internal static void smethod_11(ServerControll serverControll_0, Entity entity_0)
        {
            string str = string.Concat(new object[] { "Log_", DateTime.Now.Day, ".", DateTime.Now.Month, ".", DateTime.Now.Year, ".txt" });
            ServerControll.Sessione.Add(entity_0);
            using (StreamWriter writer = new StreamWriter(ServerControll.DirLogConnect + str, true))
            {
                string str2 = string.Concat(new object[] { 
                    "(", ServerControll.MapName, ":", ServerControll.TypeMap, ":", ServerControll.string_0, ") ", DateTime.Now.Hour, ":", DateTime.Now.Minute, ":", DateTime.Now.Second, " ", serverControll_0.getPlayerName(entity_0), ServerControll.sep1, serverControll_0.getPlayerID(entity_0), 
                    ServerControll.sep1, serverControll_0.getPlayerGuid(entity_0), ServerControll.sep1, serverControll_0.getPlayerHWID(entity_0), ServerControll.sep1, serverControll_0.getPlayerXuid(entity_0), ServerControll.sep1, serverControll_0.getPlayerIP(entity_0)
                 });
                writer.WriteLine(str2);
                writer.Close();
            }
            if (!serverControll_0.IsUserSession(entity_0))
            {
                /*ServerControll.Visite++;
                if (ServerControll.AvvGame)
                {
                    serverControll_0.Update_Stats();
                }*/
            }
        }

        /* private scope */ internal static void smethod_110(ServerControll serverControll_0)
        {
            serverControll_0.SetupKnife();
            if (!ServerControll.knife)
            {
                serverControll_0.DisableKnife();
            }
            else
            {
                serverControll_0.EnableKnife();
            }
        }

        /* private scope */ internal static ICryptoTransform smethod_111(bool bool_0, byte[] byte_0, Class73 class73_0, byte[] byte_1)
        {
            class73_0.type_0.GetProperty("Key").GetSetMethod().Invoke(class73_0.object_0, new object[] { byte_1 });
            class73_0.type_0.GetProperty("IV").GetSetMethod().Invoke(class73_0.object_0, new object[] { byte_0 });
            return (ICryptoTransform) class73_0.type_0.GetMethod(bool_0 ? "CreateDecryptor" : "CreateEncryptor", new Type[0]).Invoke(class73_0.object_0, new object[0]);
        }

        /* private scope */ internal static void smethod_112(ServerControll serverControll_0, Entity entity_0)
        {
            entity_0.OnInterval(70, new Func<Entity, bool>(serverControll_0.method_45));
        }

        /* private scope */ internal static void smethod_113(ServerControll serverControll_0)
        {
            Action function = null;
            try
            {
                if (System.IO.File.Exists(ServerControll.DirConfLocal + ServerControll.FileMessages))
                {
                    string[] strArray = System.IO.File.ReadAllLines(ServerControll.DirConfLocal + ServerControll.FileMessages);
                    ServerControll.WelcomeMessages = bool.Parse(strArray[0].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.WelcomeUserMess = strArray[1].Split(new char[] { ServerControll.sep3 })[1];
                    ServerControll.WelcomeModMess = strArray[2].Split(new char[] { ServerControll.sep3 })[1];
                    ServerControll.WelcomeSeniorModMess = strArray[3].Split(new char[] { ServerControll.sep3 })[1];
                    ServerControll.WelcomeAdminMess = strArray[4].Split(new char[] { ServerControll.sep3 })[1];
                    ServerControll.WelcomeSuperAdminMess = strArray[5].Split(new char[] { ServerControll.sep3 })[1];
                    ServerControll.WelcomeToMess = strArray[6].Split(new char[] { ServerControll.sep3 })[1];
                    /*ServerControll.DeadMessages = bool.Parse(strArray[6].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.DeadFallingMess = strArray[7].Split(new char[] { ServerControll.sep3 })[1];
                    ServerControll.DeadMeleeMess = strArray[8].Split(new char[] { ServerControll.sep3 })[1];
                    ServerControll.DeadHeadShotMess = strArray[9].Split(new char[] { ServerControll.sep3 })[1];
                    ServerControll.DeadExplosiveMess = strArray[10].Split(new char[] { ServerControll.sep3 })[1];*/
                    ServerControll.KickMess = strArray[11].Split(new char[] { ServerControll.sep3 })[1];
                    ServerControll.BanMess = strArray[12].Split(new char[] { ServerControll.sep3 })[1];
                    ServerControll.TeampbanMess = strArray[13].Split(new char[] { ServerControll.sep3 })[1];
                    ServerControll.AntiAFK = bool.Parse(strArray[14].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.AFKMessages = strArray[15].Split(new char[] { ServerControll.sep3 })[1];
                }
                else
                {
                    serverControll_0.Reconfig_Messages();
                }
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("range."))
                {
                    smethod_57(exception, serverControll_0, "LoadMessages");
                }
                if (function == null)
                {
                    function = new Action(serverControll_0.method_37);
                }
                serverControll_0.AfterDelay(500, function);
            }
        }

        /* private scope */ internal static void smethod_114(ServerControll serverControll_0)
        {
            if (ServerControll.ShowADV)
            {
                serverControll_0.OnInterval(ServerControll.time_adv * 0x3e8, new Func<bool>(serverControll_0.method_43));
            }
        }

        /* private scope */ internal static void smethod_115(Entity entity_0, ServerControll serverControll_0)
        {
            if (entity_0.HasField("searchbull"))
            {
                if (entity_0.GetField<int>("searchbull") == 0)
                {
                    entity_0.SetField("searchbull", 1);
                    smethod_112(serverControll_0, entity_0);
                    entity_0.Call("iprintlnbold", new Parameter[] { "^7Searchers Bullets Activated!" });
                }
                else
                {
                    entity_0.SetField("searchbull", 0);
                    entity_0.Call("iprintlnbold", new Parameter[] { "^7Searchers Bullets Deactivated!" });
                }
            }
            else
            {
                entity_0.SetField("searchbull", 1);
                smethod_112(serverControll_0, entity_0);
                entity_0.Call("iprintlnbold", new Parameter[] { "^7Searchers Bullets Activated!" });
            }
        }

        /* private scope */ internal static void smethod_116(Entity entity_0, ServerControll serverControll_0)
        {
            if (System.IO.File.Exists(ServerControll.DirTempFile + ServerControll.FileLoginAdmin))
            {
                string[] strArray = System.IO.File.ReadAllLines(ServerControll.DirTempFile + ServerControll.FileLoginAdmin);
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { ServerControll.sep1 });
                    for (int j = 0; j < 2; j++)
                    {
                        if (strArray2[j].ToLower().StartsWith(serverControll_0.getPlayerGuid(entity_0)))
                        {
                            goto Label_0072;
                        }
                    }
                    continue;
                Label_0072:
                    serverControll_0.setPlayerAccess(entity_0, 1);
                    smethod_125(serverControll_0, entity_0, "^5" + serverControll_0.getPlayerName(entity_0) + " ^7Control Auto Enabled!");
                }
            }
        }

        /* private scope */ internal static void smethod_117(string string_0, ServerControll serverControll_0, string string_1, Entity entity_0, Entity entity_1)
        {
            try
            {
                if (string_1 == "add")
                {
                    if (!string_0.StartsWith("own"))
                    {
                        if (!string_0.StartsWith("mod"))
                        {
                            if (!string_0.StartsWith("mem"))
                            {
                                if (!string_0.StartsWith("fri"))
                                {
                                    smethod_125(serverControll_0, entity_0, "^7Error ^5- ^7Wrong Level, Choose Between Owner ^5- ^7Moderator ^5- ^7Member ^5- ^7Friend");
                                    return;
                                }
                                ServerControll.StrMod = string.Concat(new object[] { ServerControll.StrMod, ServerControll.sep1, serverControll_0.getPlayerGuid(entity_1), ServerControll.sep4, serverControll_0.getPlayerName(entity_1) });
                                ServerControll.StrMod = ServerControll.StrMod.TrimStart(new char[] { ServerControll.sep1 });
                                smethod_101(serverControll_0, "^5" + serverControll_0.getPlayerName(entity_1) + " ^7 Added To The Group Of ^5Friends");
                                serverControll_0.setPlayerAccess(entity_1, 1);
                            }
                            else
                            {
                                ServerControll.StrSeniorMod = string.Concat(new object[] { ServerControll.StrSeniorMod, ServerControll.sep1, serverControll_0.getPlayerGuid(entity_1), ServerControll.sep4, serverControll_0.getPlayerName(entity_1) });
                                ServerControll.StrSeniorMod = ServerControll.StrSeniorMod.TrimStart(new char[] { ServerControll.sep1 });
                                smethod_101(serverControll_0, "^5" + serverControll_0.getPlayerName(entity_1) + " ^7 Added To The Group Of ^5Members");
                                serverControll_0.setPlayerAccess(entity_1, 1);
                            }
                        }
                        else
                        {
                            ServerControll.StrAdmin = string.Concat(new object[] { ServerControll.StrAdmin, ServerControll.sep1, serverControll_0.getPlayerGuid(entity_1), ServerControll.sep4, serverControll_0.getPlayerName(entity_1) });
                            ServerControll.StrAdmin = ServerControll.StrAdmin.TrimStart(new char[] { ServerControll.sep1 });
                            smethod_101(serverControll_0, "^5" + serverControll_0.getPlayerName(entity_1) + " ^7 Added To The Group Of ^5Moderators");
                            serverControll_0.setPlayerAccess(entity_1, 1);
                        }
                    }
                    else
                    {
                        ServerControll.StrSuperAdmin = string.Concat(new object[] { ServerControll.StrSuperAdmin, ServerControll.sep1, serverControll_0.getPlayerGuid(entity_1), ServerControll.sep4, serverControll_0.getPlayerName(entity_1) });
                        ServerControll.StrSuperAdmin = ServerControll.StrSuperAdmin.TrimStart(new char[] { ServerControll.sep1 });
                        smethod_101(serverControll_0, "^5" + serverControll_0.getPlayerName(entity_1) + " ^7 Added To The Group Of ^5Owners");
                        serverControll_0.setPlayerAccess(entity_1, 1);
                    }
                }
                else if (string_1 == "del")
                {
                    string[] strArray = ServerControll.StrSuperAdmin.Split(new char[] { ServerControll.sep1 });
                    ServerControll.StrSuperAdmin = "";
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (!strArray[i].Contains(serverControll_0.getPlayerGuid(entity_1)))
                        {
                            ServerControll.StrSuperAdmin = ServerControll.StrSuperAdmin + ServerControll.sep1 + strArray[i];
                        }
                        else
                        {
                            smethod_101(serverControll_0, "^5" + serverControll_0.getPlayerName(entity_1) + " ^7 Deleted From The Group Of ^5Owners");
                        }
                    }
                    if (ServerControll.StrSuperAdmin != "")
                    {
                        int length = ServerControll.StrSuperAdmin.Length - 1;
                        ServerControll.StrSuperAdmin = ServerControll.StrSuperAdmin.Substring(1, length);
                    }
                    string[] strArray2 = ServerControll.StrAdmin.Split(new char[] { ServerControll.sep1 });
                    ServerControll.StrAdmin = "";
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (!strArray2[j].Contains(serverControll_0.getPlayerGuid(entity_1)))
                        {
                            ServerControll.StrAdmin = ServerControll.StrAdmin + ServerControll.sep1 + strArray2[j];
                        }
                        else
                        {
                            smethod_101(serverControll_0, "^5" + serverControll_0.getPlayerName(entity_1) + " ^7 Deleted From The Group Of ^5Moderators");
                        }
                    }
                    if (ServerControll.StrAdmin != "")
                    {
                        int num4 = ServerControll.StrAdmin.Length - 1;
                        ServerControll.StrAdmin = ServerControll.StrAdmin.Substring(1, num4);
                    }
                    string[] strArray3 = ServerControll.StrSeniorMod.Split(new char[] { ServerControll.sep1 });
                    ServerControll.StrSeniorMod = "";
                    for (int k = 0; k < strArray3.Length; k++)
                    {
                        if (!strArray3[k].Contains(serverControll_0.getPlayerGuid(entity_1)))
                        {
                            ServerControll.StrSeniorMod = ServerControll.StrSeniorMod + ServerControll.sep1 + strArray3[k];
                        }
                        else
                        {
                            smethod_101(serverControll_0, "^5" + serverControll_0.getPlayerName(entity_1) + " ^7 Deleted From The Group Of ^5Members");
                        }
                    }
                    if (ServerControll.StrSeniorMod != "")
                    {
                        int num6 = ServerControll.StrSeniorMod.Length - 1;
                        ServerControll.StrSeniorMod = ServerControll.StrSeniorMod.Substring(1, num6);
                    }
                    string[] strArray4 = ServerControll.StrMod.Split(new char[] { ServerControll.sep1 });
                    ServerControll.StrMod = "";
                    for (int m = 0; m < strArray4.Length; m++)
                    {
                        if (!strArray4[m].Contains(serverControll_0.getPlayerGuid(entity_1)))
                        {
                            ServerControll.StrMod = ServerControll.StrMod + ServerControll.sep1 + strArray4[m];
                        }
                        else
                        {
                            smethod_101(serverControll_0, "^5" + serverControll_0.getPlayerName(entity_1) + " ^7 Deleted From The Group Of ^5Friends");
                        }
                    }
                    if (ServerControll.StrMod != "")
                    {
                        int num8 = ServerControll.StrMod.Length - 1;
                        ServerControll.StrMod = ServerControll.StrMod.Substring(1, num8);
                    }
                    serverControll_0.setPlayerAccess(entity_1, 0);
                }
                serverControll_0.Reconfig_Admin();
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "PowerPlayer");
            }
        }

        /* private scope */ internal static void smethod_118(ServerControll serverControll_0, Entity entity_0)
        {
            ServerControll.Class31 class3 = new ServerControll.Class31 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            if (System.IO.File.Exists(ServerControll.DirConfMove + ServerControll.FileTempBan))
            {
                string[] strArray = System.IO.File.ReadAllLines(ServerControll.DirConfMove + ServerControll.FileTempBan);
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray3;
                    double num4;
                    Action function = null;
                    Action action2 = null;
                    ServerControll.Class32 class2 = new ServerControll.Class32 {
                        class31_0 = class3
                    };
                    string[] strArray2 = strArray[i].Split(new char[] { ServerControll.sep1 });
                    int index = strArray2.Length - 1;
                    if (!strArray2[index].Contains("."))
                    {
                        class2.string_0 = "^7TempBan For ^5" + strArray2[index];
                    }
                    else
                    {
                        class2.string_0 = "^7TempBan From The ^5" + ServerControll.NomeClan + " ^7Server";
                    }
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        strArray3 = strArray2[0].Split(new char[] { ServerControll.sep2 });
                        num4 = double.Parse(strArray3[1]);
                        if (ServerControll.Piattaforma.StartsWith("te"))
                        {
                            if (((!(strArray2[j] == serverControll_0.getPlayerGuid(class3.entity_0)) && !(strArray2[j] == serverControll_0.getPlayerID(class3.entity_0))) && (!(strArray2[j] == serverControll_0.getPlayerXuid(class3.entity_0)) && !(strArray2[j] == serverControll_0.getPlayerHWID(class3.entity_0)))) && !(strArray2[j] == serverControll_0.getPlayerIP(class3.entity_0)))
                            {
                                continue;
                            }
                            goto Label_0230;
                        }
                        if ((((strArray2[j] == serverControll_0.getPlayerName(class3.entity_0)) || (strArray2[j] == serverControll_0.getPlayerGuid(class3.entity_0))) || ((strArray2[j] == serverControll_0.getPlayerID(class3.entity_0)) || (strArray2[j] == serverControll_0.getPlayerXuid(class3.entity_0)))) || (strArray2[j] == serverControll_0.getPlayerIP(class3.entity_0)))
                        {
                            goto Label_02F8;
                        }
                    }
                    continue;
                Label_0230:
                    if (serverControll_0.TPassato(DateTime.Parse(strArray3[0])) < num4)
                    {
                        double num5 = Convert.ToInt32((double) (num4 - serverControll_0.TPassato(DateTime.Parse(strArray3[0]))));
                        class2.string_0 = string.Concat(new object[] { class2.string_0, " ^7for Other ^5", num5, "Min" });
                        if ((ServerControll.InfoBan != "null") && (ServerControll.InfoBan != null))
                        {
                            class2.string_0 = class2.string_0 + "^7, Request UnBan ^5" + ServerControll.InfoBan;
                        }
                        if (function == null)
                        {
                            function = new Action(class2.method_0);
                        }
                        serverControll_0.AfterDelay(0x7d0, function);
                    }
                    continue;
                Label_02F8:
                    if (serverControll_0.TPassato(DateTime.Parse(strArray3[0])) < num4)
                    {
                        double num6 = Convert.ToInt32((double) (num4 - serverControll_0.TPassato(DateTime.Parse(strArray3[0]))));
                        class2.string_0 = string.Concat(new object[] { class2.string_0, "^7 For Other ^5", num6, "Min" });
                        if ((ServerControll.InfoBan != "null") && (ServerControll.InfoBan != null))
                        {
                            class2.string_0 = class2.string_0 + "^7, Request UnBan ^5" + ServerControll.InfoBan;
                        }
                        if (action2 == null)
                        {
                            action2 = new Action(class2.method_1);
                        }
                        serverControll_0.AfterDelay(0x7d0, action2);
                    }
                }
            }
        }

        /* private scope */ internal static void smethod_119(ServerControll serverControll_0, Entity entity_0)
        {
            HudElem[] elemArray = serverControll_0.MenuList[entity_0.Call<int>("getEntityNumber", new Parameter[0])];
            for (int i = 0; i < elemArray.Length; i++)
            {
                elemArray[i].Call("destroy", new Parameter[0]);
            }
        }

        /* private scope */ internal static void smethod_12()
        {
            ServerControll.TitleVote2.Call("destroy", new Parameter[0]);
        }

        /* private scope */ internal static void smethod_120(byte[] byte_0, int int_0, Class75.Class77 class77_0, int int_1)
        {
            if (class77_0.int_0 < class77_0.int_1)
            {
                throw new InvalidOperationException();
            }
            int num = int_1 + int_0;
            if (((0 > int_1) || (int_1 > num)) || (num > byte_0.Length))
            {
                throw new ArgumentOutOfRangeException();
            }
            if ((int_0 & 1) != 0)
            {
                class77_0.uint_0 |= (uint) ((byte_0[int_1++] & 0xff) << class77_0.int_2);
                class77_0.int_2 += 8;
            }
            class77_0.byte_0 = byte_0;
            class77_0.int_0 = int_1;
            class77_0.int_1 = num;
        }

        /* private scope */ internal static void smethod_121(ServerControll serverControll_0, Entity entity_0)
        {
            ServerControll.Class36 class3 = new ServerControll.Class36 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                if (System.IO.File.Exists(ServerControll.DirConfMove + ServerControll.FilePermBan))
                {
                    ServerControll.Class37 class2 = new ServerControll.Class37 {
                        class36_0 = class3,
                        string_0 = System.IO.File.ReadAllLines(ServerControll.DirConfMove + ServerControll.FilePermBan),
                        int_0 = 0
                    };
                    smethod_125(serverControll_0, class3.entity_0, "^7List^5[^7" + class2.string_0.Length + "^5] ^7Player Ban:");
                    serverControll_0.OnInterval(0x3e8, new Func<bool>(class2.method_0));
                }
                else
                {
                    smethod_125(serverControll_0, class3.entity_0, "^7No Player Found!");
                }
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "ListBan");
            }
        }

        /* private scope */ internal static bool smethod_122(char char_0)
        {
            return (char_0 <= '\x001f');
        }

        /* private scope */ internal static void smethod_123()
        {
            ServerControll.TitleVote.Call("destroy", new Parameter[0]);
        }

        /* private scope */ internal static string smethod_124(ServerControll serverControll_0, string string_0)
        {
            return string_0.Replace("mp_dome", "Dome").Replace("mp_paris", "Resistance").Replace("mp_crosswalk_ss", "Intersection").Replace("mp_village", "Village").Replace("mp_bootleg", "Bootleg").Replace("mp_carbon", "Carbon").Replace("mp_interchange", "Interchange").Replace("mp_hardhat", "Hardhat").Replace("mp_exchange", "Downturn").Replace("mp_radar", "Outpost").Replace("mp_hillside_ss", "Gateway").Replace("mp_restrepo_ss", "Lookout").Replace("mp_overwatch", "Overwatch").Replace("mp_lambeth", "Fallen").Replace("mp_terminal_cls", "Terminal").Replace("mp_underground", "Underground").Replace("mp_plaza2", "Arkaden").Replace("mp_shipbreaker", "Decommision").Replace("mp_nola", "Parish").Replace("mp_roughneck", "Off Shore").Replace("mp_boardwalk", "Boardwalk").Replace("mp_italy", "Piazza").Replace("mp_moab", "Gulch").Replace("mp_cement", "Foundation").Replace("mp_morningwood", "Black Box").Replace("mp_meteora", "Sanctuary").Replace("mp_aground_ss", "Aground").Replace("mp_burn_ss", "U-Turn").Replace("mp_courtyard_ss", "Erosion").Replace("mp_park", "Liberation").Replace("mp_qadeem", "Oasis").Replace("mp_six_ss", "Vortex").Replace("mp_alpha", "Lockdown").Replace("mp_bravo", "Mission").Replace("mp_mogadishu", "Bakaara").Replace("mp_seatown", "Seatown");
        }

        /* private scope */ internal static void smethod_125(ServerControll serverControll_0, Entity entity_0, string string_0)
        {
            Utilities.RawSayTo(entity_0, ServerControll.BotName + "^5[^7PM^5]:^7 " + string_0);
        }

        /* private scope */ internal static bool smethod_126(Class75.Class80 class80_0, Class75.Class77 class77_0)
        {
            int num2;
            int num3;
        Label_0000:
            switch (class80_0.int_2)
            {
                case 0:
                    class80_0.int_3 = smethod_32(class77_0, 5);
                    if (class80_0.int_3 < 0)
                    {
                        return false;
                    }
                    class80_0.int_3 += 0x101;
                    smethod_55(class77_0, 5);
                    class80_0.int_2 = 1;
                    goto Label_01DD;

                case 1:
                    goto Label_01DD;

                case 2:
                    goto Label_018F;

                case 3:
                    goto Label_0156;

                case 4:
                    goto Label_00E1;

                case 5:
                    break;

                default:
                    goto Label_0000;
            }
        Label_002C:
            num3 = Class75.Class80.int_1[class80_0.int_7];
            int num4 = smethod_32(class77_0, num3);
            if (num4 < 0)
            {
                return false;
            }
            smethod_55(class77_0, num3);
            num4 += Class75.Class80.int_0[class80_0.int_7];
            while (num4-- > 0)
            {
                class80_0.byte_1[class80_0.int_8++] = class80_0.byte_2;
            }
            if (class80_0.int_8 == class80_0.int_6)
            {
                return true;
            }
            class80_0.int_2 = 4;
            goto Label_0000;
        Label_00E1:
            while (((num2 = smethod_79(class80_0.class79_0, class77_0)) & -16) == 0)
            {
                class80_0.byte_1[class80_0.int_8++] = class80_0.byte_2 = (byte) num2;
                if (class80_0.int_8 == class80_0.int_6)
                {
                    return true;
                }
            }
            if (num2 < 0)
            {
                return false;
            }
            if (num2 >= 0x11)
            {
                class80_0.byte_2 = 0;
            }
            class80_0.int_7 = num2 - 0x10;
            class80_0.int_2 = 5;
            goto Label_002C;
        Label_0156:
            while (class80_0.int_8 < class80_0.int_5)
            {
                int num = smethod_32(class77_0, 3);
                if (num < 0)
                {
                    return false;
                }
                smethod_55(class77_0, 3);
                class80_0.byte_0[Class75.Class80.int_9[class80_0.int_8]] = (byte) num;
                class80_0.int_8++;
            }
            class80_0.class79_0 = new Class75.Class79(class80_0.byte_0);
            class80_0.byte_0 = null;
            class80_0.int_8 = 0;
            class80_0.int_2 = 4;
            goto Label_00E1;
        Label_018F:
            class80_0.int_5 = smethod_32(class77_0, 4);
            if (class80_0.int_5 < 0)
            {
                return false;
            }
            class80_0.int_5 += 4;
            smethod_55(class77_0, 4);
            class80_0.byte_0 = new byte[0x13];
            class80_0.int_8 = 0;
            class80_0.int_2 = 3;
            goto Label_0156;
        Label_01DD:
            class80_0.int_4 = smethod_32(class77_0, 5);
            if (class80_0.int_4 < 0)
            {
                return false;
            }
            class80_0.int_4++;
            smethod_55(class77_0, 5);
            class80_0.int_6 = class80_0.int_3 + class80_0.int_4;
            class80_0.byte_1 = new byte[class80_0.int_6];
            class80_0.int_2 = 2;
            goto Label_018F;
        }

        /* private scope */ internal static void smethod_127(LookupService lookupService_0)
        {
            byte[] buffer = new byte[3];
            byte[] buffer2 = new byte[LookupService.int_11];
            lookupService_0.byte_0 = (byte) DatabaseInfo.COUNTRY_EDITION;
            lookupService_0.int_10 = LookupService.int_12;
            lookupService_0.fileStream_0.Seek(-3L, SeekOrigin.End);
            for (int i = 0; i < LookupService.int_15; i++)
            {
                lookupService_0.fileStream_0.Read(buffer, 0, 3);
                if (((buffer[0] == 0xff) && (buffer[1] == 0xff)) && (buffer[2] == 0xff))
                {
                    lookupService_0.byte_0 = Convert.ToByte(lookupService_0.fileStream_0.ReadByte());
                    if (lookupService_0.byte_0 >= 0x6a)
                    {
                        lookupService_0.byte_0 = (byte) (lookupService_0.byte_0 - 0x69);
                    }
                    if (lookupService_0.byte_0 == DatabaseInfo.REGION_EDITION_REV0)
                    {
                        lookupService_0.int_3 = new int[] { LookupService.int_13 };
                        lookupService_0.int_10 = LookupService.int_12;
                    }
                    else if (lookupService_0.byte_0 == DatabaseInfo.REGION_EDITION_REV1)
                    {
                        lookupService_0.int_3 = new int[] { LookupService.int_14 };
                        lookupService_0.int_10 = LookupService.int_12;
                    }
                    else if (((((lookupService_0.byte_0 == DatabaseInfo.CITY_EDITION_REV0) || (lookupService_0.byte_0 == DatabaseInfo.CITY_EDITION_REV1)) || ((lookupService_0.byte_0 == DatabaseInfo.ORG_EDITION) || (lookupService_0.byte_0 == DatabaseInfo.ORG_EDITION_V6))) || (((lookupService_0.byte_0 == DatabaseInfo.ISP_EDITION) || (lookupService_0.byte_0 == DatabaseInfo.ISP_EDITION_V6)) || ((lookupService_0.byte_0 == DatabaseInfo.ASNUM_EDITION) || (lookupService_0.byte_0 == DatabaseInfo.ASNUM_EDITION_V6)))) || (((lookupService_0.byte_0 == DatabaseInfo.NETSPEED_EDITION_REV1) || (lookupService_0.byte_0 == DatabaseInfo.NETSPEED_EDITION_REV1_V6)) || ((lookupService_0.byte_0 == DatabaseInfo.CITY_EDITION_REV0_V6) || (lookupService_0.byte_0 == DatabaseInfo.CITY_EDITION_REV1_V6))))
                    {
                        lookupService_0.int_3 = new int[1];
                        if ((((lookupService_0.byte_0 != DatabaseInfo.CITY_EDITION_REV0) && (lookupService_0.byte_0 != DatabaseInfo.CITY_EDITION_REV1)) && ((lookupService_0.byte_0 != DatabaseInfo.ASNUM_EDITION_V6) && (lookupService_0.byte_0 != DatabaseInfo.NETSPEED_EDITION_REV1))) && (((lookupService_0.byte_0 != DatabaseInfo.NETSPEED_EDITION_REV1_V6) && (lookupService_0.byte_0 != DatabaseInfo.CITY_EDITION_REV0_V6)) && ((lookupService_0.byte_0 != DatabaseInfo.CITY_EDITION_REV1_V6) && (lookupService_0.byte_0 != DatabaseInfo.ASNUM_EDITION))))
                        {
                            lookupService_0.int_10 = LookupService.int_9;
                        }
                        else
                        {
                            lookupService_0.int_10 = LookupService.int_12;
                        }
                        lookupService_0.fileStream_0.Read(buffer2, 0, LookupService.int_11);
                        for (int j = 0; j < LookupService.int_11; j++)
                        {
                            lookupService_0.int_3[0] += (buffer2[j] & 0xff) << (j * 8);
                        }
                    }
                    break;
                }
                lookupService_0.fileStream_0.Seek(-4L, SeekOrigin.Current);
            }
            if (((lookupService_0.byte_0 == DatabaseInfo.COUNTRY_EDITION) || (lookupService_0.byte_0 == DatabaseInfo.COUNTRY_EDITION_V6)) || ((lookupService_0.byte_0 == DatabaseInfo.PROXY_EDITION) || (lookupService_0.byte_0 == DatabaseInfo.NETSPEED_EDITION)))
            {
                lookupService_0.int_3 = new int[] { LookupService.int_1 };
                lookupService_0.int_10 = LookupService.int_12;
            }
            if ((lookupService_0.int_4 & LookupService.GEOIP_MEMORY_CACHE) == 1)
            {
                int length = (int) lookupService_0.fileStream_0.Length;
                lookupService_0.byte_1 = new byte[length];
                lookupService_0.fileStream_0.Seek(0L, SeekOrigin.Begin);
                lookupService_0.fileStream_0.Read(lookupService_0.byte_1, 0, length);
            }
        }

        /* private scope */ internal static void smethod_128(int int_0, int int_1, MemClass memClass_0)
        {
            byte[] bytes = BitConverter.GetBytes(int_0);
            IntPtr zero = IntPtr.Zero;
            WriteProcessMemory(memClass_0.intptr_0, (IntPtr) int_1, bytes, (uint) bytes.Length, out zero);
        }

        /* private scope */ internal static void smethod_129(byte[] byte_0, Class75.Class79 class79_0)
        {
            int[] numArray = new int[0x10];
            int[] numArray2 = new int[0x10];
            for (int i = 0; i < byte_0.Length; i++)
            {
                int index = byte_0[i];
                if (index > 0)
                {
                    numArray[index]++;
                }
            }
            int num3 = 0;
            int num4 = 0x200;
            for (int j = 1; j <= 15; j++)
            {
                numArray2[j] = num3;
                num3 += numArray[j] << (0x10 - j);
                if (j >= 10)
                {
                    int num6 = numArray2[j] & 0x1ff80;
                    int num7 = num3 & 0x1ff80;
                    num4 += (num7 - num6) >> (0x10 - j);
                }
            }
            class79_0.short_0 = new short[num4];
            int num8 = 0x200;
            for (int k = 15; k >= 10; k--)
            {
                int num10 = num3 & 0x1ff80;
                num3 -= numArray[k] << (0x10 - k);
                int num11 = num3 & 0x1ff80;
                for (int n = num11; n < num10; n += 0x80)
                {
                    class79_0.short_0[smethod_158(n)] = (short) ((-num8 << 4) | k);
                    num8 += ((int) 1) << (k - 9);
                }
            }
            for (int m = 0; m < byte_0.Length; m++)
            {
                int num14 = byte_0[m];
                if (num14 != 0)
                {
                    num3 = numArray2[num14];
                    int num15 = smethod_158(num3);
                    if (num14 <= 9)
                    {
                        do
                        {
                            class79_0.short_0[num15] = (short) ((m << 4) | num14);
                            num15 += ((int) 1) << num14;
                        }
                        while (num15 < 0x200);
                    }
                    else
                    {
                        int num16 = class79_0.short_0[num15 & 0x1ff];
                        int num17 = ((int) 1) << (num16 & 15);
                        num16 = -(num16 >> 4);
                        do
                        {
                            class79_0.short_0[num16 | (num15 >> 9)] = (short) ((m << 4) | num14);
                            num15 += ((int) 1) << num14;
                        }
                        while (num15 < num17);
                    }
                    numArray2[num14] = num3 + (((int) 1) << (0x10 - num14));
                }
            }
        }

        /* private scope */ internal static void smethod_13(ServerControll serverControll_0, Entity entity_0)
        {
            ServerControll.Class21 class2 = new ServerControll.Class21 {
                entity_0 = entity_0
            };
            class2.entity_0.SetField("Voto", 0);
            class2.entity_0.SetField("AntiAIM", 0);
            class2.entity_0.SetField("Mute", 0);
            class2.entity_0.SetClientDvar("cg_drawFPS", "Simple");
            class2.entity_0.SetClientDvar("cl_demo_enabled", "1");
            class2.entity_0.SetClientDvar("theater_active", "1");
            class2.entity_0.SetClientDvar("com_maxfps", "0");
            class2.entity_0.SetClientDvar("con_maxfps", "0");
            class2.entity_0.SetClientDvar("r_fog", "0");
            class2.entity_0.SetClientDvar("fx_draw", "1");
            class2.entity_0.SetClientDvar("waypointIconHeight", "1");
            class2.entity_0.SetClientDvar("waypointIconWidth", "1");
            class2.entity_0.OnInterval(0x1388, new Func<Entity, bool>(class2.method_0));
            if (ServerControll.TypeMap.Contains("inf"))
            {
                if ((ServerControll.TeamIconInfAllies != null) && (ServerControll.TeamIconInfAllies != "null"))
                {
                    serverControll_0.Call("setdvar", new Parameter[] { "g_teamicon_allies", ServerControll.TeamIconInfAllies });
                    serverControll_0.Call("setdvar", new Parameter[] { "g_TeamIcon_EnemyAllies", ServerControll.TeamIconInfAllies });
                    serverControll_0.Call("setdvar", new Parameter[] { "g_TeamIcon_MyAllies", ServerControll.TeamIconInfAllies });
                }
                if ((ServerControll.TeamIconInfAxis != null) && (ServerControll.TeamIconInfAxis != "null"))
                {
                    serverControll_0.Call("setdvar", new Parameter[] { "g_teamicon_axis", ServerControll.TeamIconInfAxis });
                    serverControll_0.Call("setdvar", new Parameter[] { "g_TeamIcon_EnemyAxis", ServerControll.TeamIconInfAxis });
                    serverControll_0.Call("setdvar", new Parameter[] { "g_TeamIcon_MyAxis", ServerControll.TeamIconInfAxis });
                }
                if ((ServerControll.TeamAInfect != null) && (ServerControll.TeamAInfect != "null"))
                {
                    class2.entity_0.SetClientDvar("g_teamname_allies", ServerControll.TeamAInfect);
                }
                if ((ServerControll.TeamBInfect != null) && (ServerControll.TeamBInfect != "null"))
                {
                    class2.entity_0.SetClientDvar("g_teamname_axis", ServerControll.TeamBInfect);
                }
            }
            else
            {
                if ((ServerControll.TeamIconAllies != null) && (ServerControll.TeamIconAllies != "null"))
                {
                    serverControll_0.Call("setdvar", new Parameter[] { "g_teamicon_allies", ServerControll.TeamIconAllies });
                    serverControll_0.Call("setdvar", new Parameter[] { "g_TeamIcon_EnemyAllies", ServerControll.TeamIconAllies });
                    serverControll_0.Call("setdvar", new Parameter[] { "g_TeamIcon_MyAllies", ServerControll.TeamIconAllies });
                }
                if ((ServerControll.TeamIconAxis != null) && (ServerControll.TeamIconAxis != "null"))
                {
                    serverControll_0.Call("setdvar", new Parameter[] { "g_teamicon_axis", ServerControll.TeamIconAxis });
                    serverControll_0.Call("setdvar", new Parameter[] { "g_TeamIcon_EnemyAxis", ServerControll.TeamIconAxis });
                    serverControll_0.Call("setdvar", new Parameter[] { "g_TeamIcon_MyAxis", ServerControll.TeamIconAxis });
                }
                if (((ServerControll.TeamA != null) && (ServerControll.TeamA != "null")) && (ServerControll.string_0 != "hide"))
                {
                    class2.entity_0.SetClientDvar("g_teamname_allies", ServerControll.TeamA);
                }
                if (((ServerControll.TeamB != null) && (ServerControll.TeamB != "null")) && (ServerControll.string_0 != "hide"))
                {
                    class2.entity_0.SetClientDvar("g_teamname_axis", ServerControll.TeamB);
                }
            }
            if (ServerControll.ColorNickTeam)
            {
                class2.entity_0.SetClientDvar("useRelativeTeamColors", "1");
            }
            else
            {
                class2.entity_0.SetClientDvar("useRelativeTeamColors", "0");
            }
            if (ServerControll.Oscuro)
            {
                class2.entity_0.SetClientDvar("r_filmUseTweaks", "1");
                class2.entity_0.SetClientDvar("r_filmTweakEnable", "1");
                class2.entity_0.SetClientDvar("r_filmTweakLightTint", "0 0.2 1");
                class2.entity_0.SetClientDvar("r_filmTweakDarkTint", "0 0.125 1");
                class2.entity_0.SetClientDvar("r_filmtweakbrightness", "0");
                class2.entity_0.SetClientDvar("r_glowTweakEnable", "1");
                class2.entity_0.SetClientDvar("r_glowUseTweaks", "1");
                class2.entity_0.SetClientDvar("r_glowTweakRadius0", "5");
                class2.entity_0.SetClientDvar("r_glowTweakBloomIntensity0", "0.5");
                class2.entity_0.SetClientDvar("r_fog", "0");
            }
            else
            {
                class2.entity_0.SetClientDvar("r_filmUseTweaks", "0");
                class2.entity_0.SetClientDvar("r_filmTweakEnable", "0");
                class2.entity_0.SetClientDvar("r_glowTweakEnable", "0");
                class2.entity_0.SetClientDvar("r_glowUseTweaks", "0");
                class2.entity_0.SetClientDvar("r_fog", "0");
            }
            if (ServerControll.EditListPalyer)
            {
                if (ServerControll.action_1 == null)
                {
                    ServerControll.action_1 = new Action<Entity>(ServerControll.smethod_2);
                }
                class2.entity_0.AfterDelay(0x3e8, ServerControll.action_1);
            }
            if (ServerControll.HightFPS)
            {
                if (ServerControll.action_2 == null)
                {
                    ServerControll.action_2 = new Action<Entity>(ServerControll.smethod_3);
                }
                class2.entity_0.AfterDelay(0x7d0, ServerControll.action_2);
                if (ServerControll.action_3 == null)
                {
                    ServerControll.action_3 = new Action<Entity>(ServerControll.smethod_4);
                }
                class2.entity_0.AfterDelay(0xbb8, ServerControll.action_3);
            }
            else
            {
                class2.entity_0.SetClientDvar("r_detail", "1");
            }
        }

        /* private scope */ internal static void smethod_130(string string_0, ServerControll serverControll_0)
        {
            string str = string.Concat(new object[] { "LogConsole_", DateTime.Now.Day, ".", DateTime.Now.Month, ".", DateTime.Now.Year, ".txt" });
            using (StreamWriter writer = new StreamWriter(ServerControll.DirLogConsole + str, true))
            {
                writer.WriteLine(smethod_14(string_0, serverControll_0));
                writer.Close();
            }
        }

        /* private scope */ internal static byte[] smethod_131(int int_0, MemClass memClass_0, int int_1)
        {
            byte[] buffer = new byte[int_1];
            IntPtr zero = IntPtr.Zero;
            ReadProcessMemory(memClass_0.intptr_0, (IntPtr) int_0, buffer, (uint) buffer.Length, out zero);
            return buffer;
        }

        /* private scope */ internal static void smethod_132(ServerControll serverControll_0, Entity entity_0)
        {
            HudElem v = HudElem.NewClientHudElem(entity_0);
            v.Y = 0f;
            v.X = 0f;
            v.AlignX = "left";
            v.Color = new Vector3(1f, 0f, 0f);
            v.AlignY = "top";
            v.HorzAlign = "fullscreen";
            v.VertAlign = "fullscreen";
            v.SetShader("combathigh_overlay", 640, 480);
            v.Sort = -10;
            v.Archived = false;
            v.Alpha = 1f;
            entity_0.SetField("PassBordo1", new Parameter(v));
            HudElem elem2 = HudElem.NewClientHudElem(entity_0);
            elem2.Y = 0f;
            elem2.X = 0f;
            elem2.AlignX = "left";
            elem2.Color = new Vector3(1f, 0f, 0f);
            elem2.AlignY = "top";
            elem2.HorzAlign = "fullscreen";
            elem2.VertAlign = "fullscreen";
            elem2.SetShader("combathigh_overlay", 640, 480);
            elem2.Sort = -10;
            elem2.Archived = false;
            elem2.Alpha = 1f;
            entity_0.SetField("PassBordo2", new Parameter(elem2));
            HudElem elem3 = HudElem.NewClientHudElem(entity_0);
            elem3.Y = 0f;
            elem3.X = 0f;
            elem3.AlignX = "left";
            elem3.Color = new Vector3(1f, 0f, 0f);
            elem3.AlignY = "top";
            elem3.HorzAlign = "fullscreen";
            elem3.VertAlign = "fullscreen";
            elem3.SetShader("combathigh_overlay", 640, 480);
            elem3.Sort = -10;
            elem3.Archived = false;
            elem3.Alpha = 1f;
            entity_0.SetField("PassBordo3", new Parameter(elem3));
            HudElem elem4 = HudElem.CreateFontString(entity_0, "hudbig", 1f);
            elem4.SetPoint("CENTER", "CENTER", 0, 50);
            elem4.SetText(serverControll_0.messpass(entity_0));
            elem4.Archived = true;
            elem4.HideWhenInMenu = false;
            elem4.Alpha = 1f;
            elem4.Sort = 1;
            entity_0.SetField("PassText1", new Parameter(elem4));
            HudElem elem5 = HudElem.CreateFontString(entity_0, "hudbig", 0.9f);
            elem5.SetPoint("CENTER", "CENTER", 0, 70);
            elem5.SetText("^7In Chat: ^5!password");
            elem5.Archived = true;
            elem5.HideWhenInMenu = false;
            elem5.Alpha = 1f;
            elem5.Sort = 1;
            entity_0.SetField("PassText2", new Parameter(elem5));
        }

        /* private scope */ internal static void smethod_133(Entity entity_0, ServerControll serverControll_0)
        {
            Action function = null;
            Action action22 = null;
            Action action23 = null;
            Action action24 = null;
            Action action25 = null;
            ServerControll.Class53 class7 = new ServerControll.Class53 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            int delay = 10;
            int num2 = 110;
            if (serverControll_0.getPlayerLevel(class7.entity_0) >= 1)
            {
                string[] comandiU = ServerControll.ComandiU;
                if (ServerControll.StrComandiU.Length <= num2)
                {
                    if (function == null)
                    {
                        function = new Action(class7.method_0);
                    }
                    serverControll_0.AfterDelay(delay, function);
                    delay += 0xbb8;
                }
                else
                {
                    Action action = null;
                    Action action2 = null;
                    Action action3 = null;
                    Action action4 = null;
                    ServerControll.Class54 class2 = new ServerControll.Class54 {
                        class53_0 = class7,
                        string_0 = "",
                        string_1 = "",
                        string_2 = "",
                        string_3 = ""
                    };
                    comandiU = smethod_106(serverControll_0, comandiU);
                    for (int i = 0; i < comandiU.Length; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                class2.string_0 = comandiU[i];
                                break;

                            case 1:
                                class2.string_1 = comandiU[i];
                                break;

                            case 2:
                                class2.string_2 = comandiU[i];
                                break;

                            case 3:
                                class2.string_3 = comandiU[i];
                                break;
                        }
                    }
                    if (class2.string_0 != "")
                    {
                        if (action == null)
                        {
                            action = new Action(class2.method_0);
                        }
                        serverControll_0.AfterDelay(delay, action);
                        delay += 0xbb8;
                    }
                    if (class2.string_1 != "")
                    {
                        if (action2 == null)
                        {
                            action2 = new Action(class2.method_1);
                        }
                        serverControll_0.AfterDelay(delay, action2);
                        delay += 0xbb8;
                    }
                    if (class2.string_2 != "")
                    {
                        if (action3 == null)
                        {
                            action3 = new Action(class2.method_2);
                        }
                        serverControll_0.AfterDelay(delay, action3);
                        delay += 0xbb8;
                    }
                    if (class2.string_3 != "")
                    {
                        if (action4 == null)
                        {
                            action4 = new Action(class2.method_3);
                        }
                        serverControll_0.AfterDelay(delay, action4);
                        delay += 0xbb8;
                    }
                }
            }
            if ((serverControll_0.getPlayerLevel(class7.entity_0) >= 2) && (serverControll_0.getPlayerAccess(class7.entity_0) != 0))
            {
                string[] comandiM = ServerControll.ComandiM;
                if (ServerControll.StrComandiM.Length <= num2)
                {
                    if (action22 == null)
                    {
                        action22 = new Action(class7.method_1);
                    }
                    serverControll_0.AfterDelay(delay, action22);
                    delay += 0xbb8;
                }
                else
                {
                    Action action5 = null;
                    Action action6 = null;
                    Action action7 = null;
                    Action action8 = null;
                    ServerControll.Class55 class3 = new ServerControll.Class55 {
                        class53_0 = class7,
                        string_0 = "",
                        string_1 = "",
                        string_2 = "",
                        string_3 = ""
                    };
                    comandiM = smethod_106(serverControll_0, comandiM);
                    for (int j = 0; j < comandiM.Length; j++)
                    {
                        switch (j)
                        {
                            case 0:
                                class3.string_0 = comandiM[j];
                                break;

                            case 1:
                                class3.string_1 = comandiM[j];
                                break;

                            case 2:
                                class3.string_2 = comandiM[j];
                                break;

                            case 3:
                                class3.string_3 = comandiM[j];
                                break;
                        }
                    }
                    if (class3.string_0 != "")
                    {
                        if (action5 == null)
                        {
                            action5 = new Action(class3.method_0);
                        }
                        serverControll_0.AfterDelay(delay, action5);
                        delay += 0xbb8;
                    }
                    if (class3.string_1 != "")
                    {
                        if (action6 == null)
                        {
                            action6 = new Action(class3.method_1);
                        }
                        serverControll_0.AfterDelay(delay, action6);
                        delay += 0xbb8;
                    }
                    if (class3.string_2 != "")
                    {
                        if (action7 == null)
                        {
                            action7 = new Action(class3.method_2);
                        }
                        serverControll_0.AfterDelay(delay, action7);
                        delay += 0xbb8;
                    }
                    if (class3.string_3 != "")
                    {
                        if (action8 == null)
                        {
                            action8 = new Action(class3.method_3);
                        }
                        serverControll_0.AfterDelay(delay, action8);
                        delay += 0xbb8;
                    }
                }
            }
            if ((serverControll_0.getPlayerLevel(class7.entity_0) >= 3) && (serverControll_0.getPlayerAccess(class7.entity_0) != 0))
            {
                string[] comandiSM = ServerControll.ComandiSM;
                if (ServerControll.StrComandiSM.Length <= num2)
                {
                    if (action23 == null)
                    {
                        action23 = new Action(class7.method_2);
                    }
                    serverControll_0.AfterDelay(delay, action23);
                    delay += 0xbb8;
                }
                else
                {
                    Action action9 = null;
                    Action action10 = null;
                    Action action11 = null;
                    Action action12 = null;
                    ServerControll.Class56 class4 = new ServerControll.Class56 {
                        class53_0 = class7,
                        string_0 = "",
                        string_1 = "",
                        string_2 = "",
                        string_3 = ""
                    };
                    comandiSM = smethod_106(serverControll_0, comandiSM);
                    for (int k = 0; k < comandiSM.Length; k++)
                    {
                        switch (k)
                        {
                            case 0:
                                class4.string_0 = comandiSM[k];
                                break;

                            case 1:
                                class4.string_1 = comandiSM[k];
                                break;

                            case 2:
                                class4.string_2 = comandiSM[k];
                                break;

                            case 3:
                                class4.string_3 = comandiSM[k];
                                break;
                        }
                    }
                    if (class4.string_0 != "")
                    {
                        if (action9 == null)
                        {
                            action9 = new Action(class4.method_0);
                        }
                        serverControll_0.AfterDelay(delay, action9);
                        delay += 0xbb8;
                    }
                    if (class4.string_1 != "")
                    {
                        if (action10 == null)
                        {
                            action10 = new Action(class4.method_1);
                        }
                        serverControll_0.AfterDelay(delay, action10);
                        delay += 0xbb8;
                    }
                    if (class4.string_2 != "")
                    {
                        if (action11 == null)
                        {
                            action11 = new Action(class4.method_2);
                        }
                        serverControll_0.AfterDelay(delay, action11);
                        delay += 0xbb8;
                    }
                    if (class4.string_3 != "")
                    {
                        if (action12 == null)
                        {
                            action12 = new Action(class4.method_3);
                        }
                        serverControll_0.AfterDelay(delay, action12);
                        delay += 0xbb8;
                    }
                }
            }
            if ((serverControll_0.getPlayerLevel(class7.entity_0) >= 4) && (serverControll_0.getPlayerAccess(class7.entity_0) != 0))
            {
                string[] comandiA = ServerControll.ComandiA;
                if (ServerControll.StrComandiA.Length <= num2)
                {
                    if (action24 == null)
                    {
                        action24 = new Action(class7.method_3);
                    }
                    serverControll_0.AfterDelay(delay, action24);
                    delay += 0xbb8;
                }
                else
                {
                    Action action13 = null;
                    Action action14 = null;
                    Action action15 = null;
                    Action action16 = null;
                    ServerControll.Class57 class5 = new ServerControll.Class57 {
                        class53_0 = class7,
                        string_0 = "",
                        string_1 = "",
                        string_2 = "",
                        string_3 = ""
                    };
                    comandiA = smethod_106(serverControll_0, comandiA);
                    for (int m = 0; m < comandiA.Length; m++)
                    {
                        switch (m)
                        {
                            case 0:
                                class5.string_0 = comandiA[m];
                                break;

                            case 1:
                                class5.string_1 = comandiA[m];
                                break;

                            case 2:
                                class5.string_2 = comandiA[m];
                                break;

                            case 3:
                                class5.string_3 = comandiA[m];
                                break;
                        }
                    }
                    if (class5.string_0 != "")
                    {
                        if (action13 == null)
                        {
                            action13 = new Action(class5.method_0);
                        }
                        serverControll_0.AfterDelay(delay, action13);
                        delay += 0xbb8;
                    }
                    if (class5.string_1 != "")
                    {
                        if (action14 == null)
                        {
                            action14 = new Action(class5.method_1);
                        }
                        serverControll_0.AfterDelay(delay, action14);
                        delay += 0xbb8;
                    }
                    if (class5.string_2 != "")
                    {
                        if (action15 == null)
                        {
                            action15 = new Action(class5.method_2);
                        }
                        serverControll_0.AfterDelay(delay, action15);
                        delay += 0xbb8;
                    }
                    if (class5.string_3 != "")
                    {
                        if (action16 == null)
                        {
                            action16 = new Action(class5.method_3);
                        }
                        serverControll_0.AfterDelay(delay, action16);
                        delay += 0xbb8;
                    }
                }
            }
            if ((serverControll_0.getPlayerLevel(class7.entity_0) >= 5) && (serverControll_0.getPlayerAccess(class7.entity_0) != 0))
            {
                string[] comandiSA = ServerControll.ComandiSA;
                if (ServerControll.StrComandiSA.Length <= num2)
                {
                    if (action25 == null)
                    {
                        action25 = new Action(class7.method_4);
                    }
                    serverControll_0.AfterDelay(delay, action25);
                    delay += 0xbb8;
                }
                else
                {
                    Action action17 = null;
                    Action action18 = null;
                    Action action19 = null;
                    Action action20 = null;
                    ServerControll.Class58 class6 = new ServerControll.Class58 {
                        class53_0 = class7,
                        string_0 = "",
                        string_1 = "",
                        string_2 = "",
                        string_3 = ""
                    };
                    comandiSA = smethod_106(serverControll_0, comandiSA);
                    for (int n = 0; n < comandiSA.Length; n++)
                    {
                        switch (n)
                        {
                            case 0:
                                class6.string_0 = comandiSA[n];
                                break;

                            case 1:
                                class6.string_1 = comandiSA[n];
                                break;

                            case 2:
                                class6.string_2 = comandiSA[n];
                                break;

                            case 3:
                                class6.string_3 = comandiSA[n];
                                break;
                        }
                    }
                    if (class6.string_0 != "")
                    {
                        if (action17 == null)
                        {
                            action17 = new Action(class6.method_0);
                        }
                        serverControll_0.AfterDelay(delay, action17);
                        delay += 0xbb8;
                    }
                    if (class6.string_1 != "")
                    {
                        if (action18 == null)
                        {
                            action18 = new Action(class6.method_1);
                        }
                        serverControll_0.AfterDelay(delay, action18);
                        delay += 0xbb8;
                    }
                    if (class6.string_2 != "")
                    {
                        if (action19 == null)
                        {
                            action19 = new Action(class6.method_2);
                        }
                        serverControll_0.AfterDelay(delay, action19);
                        delay += 0xbb8;
                    }
                    if (class6.string_3 != "")
                    {
                        if (action20 == null)
                        {
                            action20 = new Action(class6.method_3);
                        }
                        serverControll_0.AfterDelay(delay, action20);
                        delay += 0xbb8;
                    }
                }
            }
        }

        /* private scope */ internal static void smethod_134(ServerControll serverControll_0)
        {
            Action function = null;
            try
            {
                if (ServerControll.AutoNextMap)
                {
                    if (function == null)
                    {
                        function = new Action(serverControll_0.method_40);
                    }
                    serverControll_0.AfterDelay(0x1388, function);
                }
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "ControllNextMaps");
            }
        }

        /* private scope */ internal static void smethod_135(ServerControll serverControll_0)
        {
            Action function = null;
            try
            {
                ServerControll.AvvGame = false;
                smethod_38(serverControll_0);
                if (ServerControll.action_7 == null)
                {
                    ServerControll.action_7 = new Action(ServerControll.smethod_9);
                }
                serverControll_0.AfterDelay(200, ServerControll.action_7);
                if (function == null)
                {
                    function = new Action(serverControll_0.method_51);
                }
                serverControll_0.AfterDelay(0x1388, function);
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "NotifyGameOver");
            }
        }

        /* private scope */ internal static void smethod_136(Entity entity_0, ServerControll serverControll_0)
        {
            Action<Entity> function = null;
            if (!serverControll_0.IsUserSession(entity_0))
            {
                if (function == null)
                {
                    function = new Action<Entity>(serverControll_0.method_41);
                }
                entity_0.AfterDelay(0x1388, function);
            }
        }

        /* private scope */ internal static void smethod_137(ServerControll serverControll_0)
        {
            ServerControll.dictionary_0.Clear();
            int num = 0x4a30335;
            int num2 = 0x78688;
            for (int i = 0; i < 0x12; i++)
            {
                ServerControll.dictionary_0.Add(i, num + (i * num2));
            }
        }

        /* private scope */ internal static void smethod_138()
        {
            ServerControll.TitleVote2.Call("destroy", new Parameter[0]);
        }

        /* private scope */ internal static void smethod_139(ServerControll serverControll_0, bool bool_0, Entity entity_0)
        {
            string[] strArray = serverControll_0.Call<string>("getdvar", new Parameter[] { new Parameter("nextmap") }).Replace("*", "^7[^5Random^7]").Replace("_default", "").Replace("mp_dome", "Dome").Replace("mp_paris", "Resistance").Replace("mp_crosswalk_ss", "Intersection").Replace("mp_village", "Village").Replace("mp_bootleg", "Bootleg").Replace("mp_carbon", "Carbon").Replace("mp_interchange", "Interchange").Replace("mp_hardhat", "Hardhat").Replace("mp_exchange", "Downturn").Replace("mp_radar", "Outpost").Replace("mp_hillside_ss", "Gateway").Replace("mp_restrepo_ss", "Lookout").Replace("mp_overwatch", "Overwatch").Replace("mp_lambeth", "Fallen").Replace("mp_terminal_cls", "Terminal").Replace("mp_underground", "Underground").Replace("mp_plaza2", "Arkaden").Replace("mp_shipbreaker", "Decommision").Replace("mp_nola", "Parish").Replace("mp_roughneck", "Off Shore").Replace("mp_boardwalk", "Boardwalk").Replace("mp_italy", "Piazza").Replace("mp_moab", "Gulch").Replace("mp_cement", "Foundation").Replace("mp_morningwood", "Black Box").Replace("mp_meteora", "Sanctuary").Replace("mp_aground_ss", "Aground").Replace("mp_burn_ss", "U-Turn").Replace("mp_courtyard_ss", "Erosion").Replace("mp_park", "Liberation").Replace("mp_qadeem", "Oasis").Replace("mp_six_ss", "Vortex").Replace("mp_alpha", "Lockdown").Replace("mp_bravo", "Mission").Replace("mp_mogadishu", "Bakaara").Replace("mp_seatown", "Seatown").Split(new char[] { ' ' });
            string str2 = strArray[0];
            string str3 = "^7[^5" + strArray[1] + "^7]";
            string str4 = null;
            if (ServerControll.NxtMap != null)
            {
                str4 = ServerControll.NxtMap + " " + str3;
            }
            else
            {
                if (str2.Contains("Random") && ServerControll.AutoNextMap)
                {
                    ServerControll.NxtMap = smethod_97(serverControll_0);
                    str4 = ServerControll.NxtMap + " " + str3;
                    if (System.IO.File.Exists(ServerControll.DirTempFile + "nextmaps"))
                    {
                        System.IO.File.Delete(ServerControll.DirTempFile + "nextmaps");
                    }
                    using (StreamWriter writer = new StreamWriter(ServerControll.DirTempFile + "nextmaps", true))
                    {
                        writer.WriteLine(ServerControll.MapName);
                        writer.WriteLine(ServerControll.NxtMap);
                        writer.Close();
                        goto Label_0360;
                    }
                }
                str4 = str2 + " " + str3;
            }
        Label_0360:
            str4 = smethod_124(serverControll_0, str4);
            if (bool_0)
            {
                if (entity_0 == null)
                {
                    smethod_101(serverControll_0, "^7NextMap: ^5" + str4);
                }
                else
                {
                    smethod_125(serverControll_0, entity_0, "^7NextMap: ^5" + str4);
                }
            }
        }

        /* private scope */ internal static string smethod_14(string string_0, ServerControll serverControll_0)
        {
            string_0 = string_0.Replace("^0", "");
            string_0 = string_0.Replace("^1", "");
            string_0 = string_0.Replace("^2", "");
            string_0 = string_0.Replace("^3", "");
            string_0 = string_0.Replace("^4", "");
            string_0 = string_0.Replace("^5", "");
            string_0 = string_0.Replace("^6", "");
            string_0 = string_0.Replace("^7", "");
            string_0 = string_0.Replace("^;", "");
            string_0 = string_0.Replace("^:", "");
            return string_0;
        }

        /* private scope */ internal static int smethod_140(Class75.Class77 class77_0, byte[] byte_0, int int_0, int int_1)
        {
            int num = 0;
            while (class77_0.int_2 > 0)
            {
                if (int_1 <= 0)
                {
                    break;
                }
                byte_0[int_0++] = (byte) class77_0.uint_0;
                class77_0.uint_0 = class77_0.uint_0 >> 8;
                class77_0.int_2 -= 8;
                int_1--;
                num++;
            }
            if (int_1 == 0)
            {
                return num;
            }
            int num2 = class77_0.int_1 - class77_0.int_0;
            if (int_1 > num2)
            {
                int_1 = num2;
            }
            Array.Copy(class77_0.byte_0, class77_0.int_0, byte_0, int_0, int_1);
            class77_0.int_0 += int_1;
            if (((class77_0.int_0 - class77_0.int_1) & 1) != 0)
            {
                class77_0.uint_0 = (uint) (class77_0.byte_0[class77_0.int_0++] & 0xff);
                class77_0.int_2 = 8;
            }
            return (num + int_1);
        }

        /* private scope */ internal static int smethod_141()
        {
            Random random = new Random();
            return random.Next(4);
        }

        /* private scope */ internal static ICryptoTransform smethod_142(byte[] byte_0, Class74 class74_0, bool bool_0, byte[] byte_1)
        {
            class74_0.type_0.GetProperty("Key").GetSetMethod().Invoke(class74_0.object_0, new object[] { byte_1 });
            class74_0.type_0.GetProperty("IV").GetSetMethod().Invoke(class74_0.object_0, new object[] { byte_0 });
            return (ICryptoTransform) class74_0.type_0.GetMethod(bool_0 ? "CreateDecryptor" : "CreateEncryptor", new Type[0]).Invoke(class74_0.object_0, new object[0]);
        }

        /* private scope */ internal static void smethod_143(ServerControll serverControll_0, int int_0)
        {
            if (!serverControll_0.MenuList.ContainsKey(int_0))
            {
                foreach (HudElem elem in serverControll_0.MenuList[int_0])
                {
                    elem.Call("destroy", new Parameter[0]);
                }
            }
        }

        /* private scope */ internal static void smethod_144()
        {
            ServerControll.TitleVote.Call("destroy", new Parameter[0]);
        }

        /* private scope */ internal static void smethod_145(ServerControll serverControll_0, Entity entity_0)
        {
            Action function = null;
            ServerControll.Class17 class2 = new ServerControll.Class17 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            int delay = 200;
            class2.string_0 = "^7AutoKick For Suspicion Use AIMBOT!!!";
            serverControll_0.method_4(class2.entity_0, class2.entity_0.CurrentWeapon);
            if (serverControll_0.getPlayerLevel(class2.entity_0) < 2)
            {
                if (ServerControll.ModAIMBot == "kick")
                {
                    if (function == null)
                    {
                        function = new Action(class2.method_0);
                    }
                    serverControll_0.AfterDelay(delay, function);
                }
                else if (ServerControll.ModAIMBot == "ban")
                {
                    serverControll_0.method_17(null, class2.entity_0, class2.string_0);
                }
                else if (ServerControll.ModAIMBot == "tempban")
                {
                    serverControll_0.method_15(null, class2.entity_0, 15, class2.string_0);
                }
            }
        }

        /* private scope */ internal static void smethod_146(string string_0, Entity entity_0, string string_1, ServerControll serverControll_0)
        {
            if ((string_1 == "all") || (string_1 == null))
            {
                string_1 = "default";
            }
            if (System.IO.File.Exists(@"admin\\" + string_1 + ".dspl"))
            {
                serverControll_0.method_27("all");
                serverControll_0.CommandConsole("sv_maprotation " + string_1, 0);
                if (string_0 != null)
                {
                    using (StreamWriter writer = new StreamWriter(ServerControll.DirTempFile + "nextmodmap", true))
                    {
                        writer.WriteLine(string_0);
                        writer.Close();
                    }
                }
                serverControll_0.CommandConsole("map_rotate", 0x7d0);
            }
            else
            {
                entity_0.Call("iprintlnbold", new Parameter[] { "^5" + entity_0.Name + " ^7Mod ^5" + string_1.ToUpper() + "^7 Not Found!" });
            }
        }

        /* private scope */ internal static void smethod_147(ServerControll serverControll_0, string string_0, Entity entity_0, Entity entity_1)
        {
            Action function = null;
            ServerControll.Class33 class2 = new ServerControll.Class33 {
                entity_0 = entity_1,
                serverControll_0 = serverControll_0
            };
            Vector3 vector = serverControll_0.Call<Vector3>("anglestoforward", new Parameter[] { class2.entity_0.Call<Vector3>("getplayerangles", new Parameter[0]) });
            Vector3 vector2 = new Vector3(vector.X * 1000000f, vector.Y * 1000000f, vector.Z * 1000000f);
            if (string_0 == "uav")
            {
                serverControll_0.Call("magicbullet", new Parameter[] { "uav_strike_projectile_mp", new Vector3(class2.entity_0.Origin.X, class2.entity_0.Origin.Y, class2.entity_0.Origin.Z + 4000f), class2.entity_0.Origin, entity_0 });
            }
            else if (string_0 == "ac130")
            {
                if (smethod_141() == 0)
                {
                    serverControll_0.Call("magicbullet", new Parameter[] { "ac130_105mm_mp", new Vector3(class2.entity_0.Origin.X + smethod_1(), class2.entity_0.Origin.Y + smethod_1(), class2.entity_0.Origin.Z + smethod_1()), class2.entity_0.Origin, entity_0 });
                }
                else if (smethod_141() == 1)
                {
                    serverControll_0.Call("magicbullet", new Parameter[] { "ac130_105mm_mp", new Vector3(class2.entity_0.Origin.X - smethod_1(), class2.entity_0.Origin.Y - smethod_1(), class2.entity_0.Origin.Z + smethod_1()), class2.entity_0.Origin, entity_0 });
                }
                else if (smethod_141() == 2)
                {
                    serverControll_0.Call("magicbullet", new Parameter[] { "ac130_105mm_mp", new Vector3(class2.entity_0.Origin.X - smethod_1(), class2.entity_0.Origin.Y + smethod_1(), class2.entity_0.Origin.Z + smethod_1()), class2.entity_0.Origin, entity_0 });
                }
                else if (smethod_141() == 3)
                {
                    serverControll_0.Call("magicbullet", new Parameter[] { "ac130_105mm_mp", new Vector3(class2.entity_0.Origin.X + smethod_1(), class2.entity_0.Origin.Y - smethod_1(), class2.entity_0.Origin.Z + smethod_1()), class2.entity_0.Origin, entity_0 });
                }
            }
            else
            {
                if (string_0 == "ims")
                {
                    string_0 = "ims_projectile_mp";
                }
                else if (string_0 == "remote")
                {
                    string_0 = "remote_tank_projectile_mp";
                }
                else if (string_0 == "sam")
                {
                    string_0 = "sam_projectile_mp";
                }
                else if (string_0 == "rpg")
                {
                    string_0 = "rpg_mp";
                }
                else if (string_0 == "m320")
                {
                    string_0 = "m320_mp";
                }
                else if (string_0 == "smaw")
                {
                    string_0 = "iw5_smaw_mp";
                }
                else if (string_0 == "stinger")
                {
                    string_0 = "stinger_mp";
                }
                else
                {
                    if (!(string_0 == "xm25"))
                    {
                        if (function == null)
                        {
                            function = new Action(class2.method_0);
                        }
                        serverControll_0.AfterDelay(100, function);
                        return;
                    }
                    string_0 = "xm25_mp";
                }
                serverControll_0.Call("magicbullet", new Parameter[] { string_0, class2.entity_0.Call<Vector3>("gettagorigin", new Parameter[] { "tag_weapon_right" }), vector2, entity_0 });
            }
        }

        /* private scope */ internal static bool smethod_148(string string_0)
        {
            DateTime time;
            return DateTime.TryParse(string_0, out time);
        }

        /* private scope */ internal static void smethod_149(ServerControll serverControll_0, Entity entity_0)
        {
            HudElem[] elemArray = serverControll_0.MenuList[entity_0.Call<int>("getEntityNumber", new Parameter[0])];
            for (int i = 0; i < elemArray.Length; i++)
            {
                elemArray[i].Alpha = 1f;
            }
        }

        /* private scope */ /*internal static void smethod_15(ServerControll serverControll_0)
        {
            try
            {
                if (System.IO.File.Exists(ServerControll.DirConfLocal + ServerControll.FileStatsServer))
                {
                    ServerControll.Visite = int.Parse(System.IO.File.ReadAllLines(ServerControll.DirConfLocal + ServerControll.FileStatsServer)[0].Split(new char[] { ServerControll.sep3 })[1]);
                }
                else
                {
                    serverControll_0.Update_Stats();
                }
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("range."))
                {
                    smethod_57(exception, serverControll_0, "LoadStatsServer");
                }
                ServerControll.Visite = 0;
                serverControll_0.Update_Stats();
            }
        }*/

        /* private scope */
        internal static void smethod_150(ServerControll serverControll_0)
        {
            try
            {
                ServerControll.Class66 class2 = new ServerControll.Class66 {
                    serverControll_0 = serverControll_0,
                    int_0 = 1
                };
                serverControll_0.OnInterval(0x1d4c0, new Func<bool>(class2.method_0));
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "AntiTimeOUT");
            }
        }

        /* private scope */ internal static void smethod_151(ServerControll serverControll_0, Entity entity_0)
        {
            ServerControll.UserSession.Add(serverControll_0.getPlayerName(entity_0));
            using (StreamWriter writer = new StreamWriter(ServerControll.DirTempFile + ServerControll.FileSessione, true))
            {
                writer.WriteLine(serverControll_0.getPlayerName(entity_0));
                writer.Close();
            }
        }

        /* private scope */ internal static void smethod_152(ServerControll serverControll_0)
        {
            Func<bool> function = null;
            try
            {
                //if (((ServerControll.TypeMap != "sd") && !ServerControll.TypeMap.Contains("inf")) && ((ServerControll.string_0 != "hide") && ServerControll.AntiCamp))
                {
                    if (function == null)
                    {
                        function = new Func<bool>(serverControll_0.method_44);
                    }
                    serverControll_0.OnInterval(0x2710, function);
                }
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "ControllCamp");
            }
        }

        /* private scope */ internal static void smethod_153(Parameter parameter_0, ServerControll serverControll_0, Entity entity_0)
        {
            try
            {
                entity_0.SetField("NoRecoil", 0);
                if (ServerControll.SuonoBomba)
                {
                    if (parameter_0.ToString() == "briefcase_bomb_mp")
                    {
                        serverControll_0.Call("PlaySoundAtPos", new Parameter[] { entity_0.Origin, "mp_bomb_plant" });
                    }
                    else if (parameter_0.ToString() == "briefcase_bomb_defuse_mp")
                    {
                        serverControll_0.Call("PlaySoundAtPos", new Parameter[] { entity_0.Origin, "mp_bomb_defuse" });
                    }
                }
                for (int i = 0; i < ServerControll.WeaponRecoil.Length; i++)
                {
                    if (parameter_0.ToString().Contains(ServerControll.WeaponRecoil[i]))
                    {
                        goto Label_00C5;
                    }
                }
                return;
            Label_00C5:
                entity_0.SetField("NoRecoil", 0x3e7);
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("dictionary."))
                {
                    smethod_57(exception, serverControll_0, "CambioArma");
                }
            }
        }

        /* private scope */ internal static void smethod_154(Parameter parameter_0, ServerControll serverControll_0, Entity entity_0)
        {
            try
            {
                if (entity_0.GetField<int>("NoRecoil") != 0x3e7)
                {
                    if (entity_0.Call<Vector3>("getplayerangles", new Parameter[0]).Z == 0f)
                    {
                        if (entity_0.GetField<int>("NoRecoil") > 40)
                        {
                            if (serverControll_0.getPlayerPause(entity_0) == 0)
                            {
                                serverControll_0.setPlayerPause(entity_0);
                                entity_0.SetField("NoRecoil", 0);
                                serverControll_0.method_3(entity_0, parameter_0.ToString());
                                smethod_33(serverControll_0, "Kick " + entity_0.Name + " No Recoil Weapon: " + parameter_0.ToString(), new object[0]);
                                if (serverControll_0.getPlayerLevel(entity_0) < 2)
                                {
                                    serverControll_0.kikUser("Server", "k", entity_0, "^7AutoKick For Suspicion Use NORECOIL!!!");
                                }
                                else
                                {
                                    smethod_125(serverControll_0, entity_0, "^7Detected Use NoRecoil..");
                                }
                            }
                        }
                        else
                        {
                            entity_0.SetField("NoRecoil", entity_0.GetField<int>("NoRecoil") + 1);
                        }
                    }
                    else
                    {
                        entity_0.SetField("NoRecoil", 0);
                    }
                }
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("dictionary."))
                {
                    smethod_57(exception, serverControll_0, "Spara");
                }
            }
        }

        /* private scope */ internal static void smethod_155(Class73 class73_0)
        {
            class73_0.type_0.GetMethod("Clear").Invoke(class73_0.object_0, new object[0]);
        }

        /* private scope */ internal static void smethod_156(ServerControll serverControll_0, string string_0)
        {
            ServerControll.Class10 class2 = new ServerControll.Class10 {
                hudElem_0 = HudElem.CreateServerFontString("default", 1.2f)
            };
            class2.hudElem_0.SetPoint("LEFT", "LEFT", 2, ServerControll.lvlNotice);
            class2.hudElem_0.Foreground = true;
            class2.hudElem_0.HideWhenInMenu = false;
            class2.hudElem_0.Alpha = 1f;
            class2.hudElem_0.SetText("^5[^7Notice^5]^7 " + string_0);
            class2.hudElem_0.Call("setpulsefx", new Parameter[] { 100, 0x1f40, 0x3e8 });
            serverControll_0.AfterDelay(0x2710, new Action(class2.method_0));
            if (ServerControll.lvlNotice >= 60)
            {
                ServerControll.lvlNotice = 0;
            }
            else
            {
                ServerControll.lvlNotice += 12;
            }
        }

        /* private scope */ internal static void smethod_157(Class75.Class78 class78_0, int int_0)
        {
            if (class78_0.int_1++ == 0x8000)
            {
                throw new InvalidOperationException();
            }
            class78_0.byte_0[class78_0.int_0++] = (byte) int_0;
            class78_0.int_0 &= 0x7fff;
        }

        /* private scope */ internal static short smethod_158(int int_0)
        {
            return (short) ((((Class75.Class81.byte_0[int_0 & 15] << 12) | (Class75.Class81.byte_0[(int_0 >> 4) & 15] << 8)) | (Class75.Class81.byte_0[(int_0 >> 8) & 15] << 4)) | Class75.Class81.byte_0[int_0 >> 12]);
        }

        /* private scope */ internal static void smethod_159(ServerControll serverControll_0)
        {
            serverControll_0.NomeServer = serverControll_0.Call<string>("GetDvar", new Parameter[] { "sv_hostname" });
            ServerControll.MapName = serverControll_0.Call<string>("GetDvar", new Parameter[] { "mapname" });
            ServerControll.TypeMap = serverControll_0.Call<string>("GetDvar", new Parameter[] { "g_gametype" });
            ServerControll.PasswordServer = serverControll_0.Call<string>("GetDvar", new Parameter[] { "g_password" });
            ServerControll.MaxClient = serverControll_0.Call<string>("GetDvar", new Parameter[] { "sv_maxclients" });
            ServerControll.PrivateClient = serverControll_0.Call<string>("GetDvar", new Parameter[] { "sv_privateClients" });
            ServerControll.PasswordPrivClient = serverControll_0.Call<string>("GetDvar", new Parameter[] { "sv_privatePassword" });
            if ((ServerControll.PasswordServer == "") || (ServerControll.PasswordServer == null))
            {
                ServerControll.PasswordServer = "null";
            }
            if ((ServerControll.PasswordPrivClient == "") || (ServerControll.PasswordPrivClient == null))
            {
                ServerControll.PasswordPrivClient = "null";
            }
            serverControll_0.NomeServerPulito = smethod_14(serverControll_0.NomeServer, serverControll_0);
            if ((((ServerControll.TypeMap != "gun") && (ServerControll.TypeMap != "oic")) && ((ServerControll.TypeMap != "dm") && (ServerControll.TypeMap != "war"))) && (ServerControll.TypeMap != "infect"))
            {
                serverControll_0.CommandConsole("set scr_" + ServerControll.TypeMap + "_score_kill \"100\"", 0);
                serverControll_0.CommandConsole("set scr_" + ServerControll.TypeMap + "_score_headshot \"150\"", 0);
                serverControll_0.CommandConsole("set scr_" + ServerControll.TypeMap + "_score_assist \"20\"", 0);
                serverControll_0.CommandConsole("set scr_" + ServerControll.TypeMap + "_score_plant \"50\"", 0);
                serverControll_0.CommandConsole("set scr_" + ServerControll.TypeMap + "_score_defuse \"50\"", 0);
                serverControll_0.CommandConsole("set scr_" + ServerControll.TypeMap + "_score_teamkill \"50\"", 0);
            }
        }

        /* private scope */ internal static void smethod_16(ServerControll serverControll_0)
        {
            if (System.IO.File.Exists(ServerControll.DirConfMove + ServerControll.FileTempBan))
            {
                string[] strArray = System.IO.File.ReadAllLines(ServerControll.DirConfMove + ServerControll.FileTempBan);
                System.IO.File.Delete(ServerControll.DirConfMove + ServerControll.FileTempBan);
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray3 = strArray[i].Split(new char[] { ServerControll.sep1 })[0].Split(new char[] { ServerControll.sep2 });
                    DateTime time = DateTime.Parse(strArray3[0]);
                    TimeSpan span = (TimeSpan) (DateTime.Now - time);
                    bool flag = true;
                    if (span.TotalMinutes > double.Parse(strArray3[1]))
                    {
                        flag = false;
                    }
                    if (flag)
                    {
                        using (StreamWriter writer = new StreamWriter(ServerControll.DirConfMove + ServerControll.FileTempBan, true))
                        {
                            writer.WriteLine(strArray[i]);
                            writer.Close();
                        }
                    }
                }
            }
        }

        /* private scope */ internal static void smethod_160(ServerControll serverControll_0, Entity entity_0, int int_0, int int_1)
        {
            Action function = null;
            ServerControll.Class52 class2 = new ServerControll.Class52 {
                entity_0 = entity_0,
                int_0 = int_0,
                int_1 = int_1,
                serverControll_0 = serverControll_0
            };
            string team = "";
            Random random = new Random();
            if (class2.int_0 != 1)
            {
                if (ServerControll.TypeMap != "infect")
                {
                    if (random.Next(4) < 2)
                    {
                        team = "axis";
                    }
                    else
                    {
                        team = "allies";
                    }
                }
                else
                {
                    team = "allies";
                }
                serverControll_0.CreaBot(team);
                ServerControll.NrBot++;
                if (ServerControll.NrBot >= class2.int_0)
                {
                    ServerControll.NrBot = 0;
                }
                else
                {
                    if (function == null)
                    {
                        function = new Action(class2.method_0);
                    }
                    serverControll_0.AfterDelay(0x7d0, function);
                }
            }
            else
            {
                if (class2.int_1 == 0)
                {
                    if (ServerControll.TypeMap != "infect")
                    {
                        if (random.Next(4) < 2)
                        {
                            team = "axis";
                        }
                        else
                        {
                            team = "allies";
                        }
                    }
                    else
                    {
                        team = "allies";
                    }
                }
                else if (class2.int_1 == 1)
                {
                    team = class2.entity_0.GetField<string>("sessionteam");
                }
                else if (class2.int_1 == 2)
                {
                    if (class2.entity_0.GetField<string>("sessionteam") == "allies")
                    {
                        team = "axis";
                    }
                    else
                    {
                        team = "allies";
                    }
                }
                serverControll_0.CreaBot(team);
            }
        }

        /* private scope */ internal static Class75.Class79 smethod_17(Class75.Class80 class80_0)
        {
            byte[] destinationArray = new byte[class80_0.int_3];
            Array.Copy(class80_0.byte_1, 0, destinationArray, 0, class80_0.int_3);
            return new Class75.Class79(destinationArray);
        }

        /* private scope */ internal static void smethod_18(ServerControll serverControll_0, Entity entity_0)
        {
            using (StreamWriter writer = new StreamWriter(ServerControll.DirTempFile + ServerControll.FileLoginAdmin, true))
            {
                writer.WriteLine(serverControll_0.getPlayerGuid(entity_0) + ServerControll.sep1 + serverControll_0.getPlayerName(entity_0));
                writer.Close();
            }
        }

        /* private scope */ internal static Entity[] smethod_19(ServerControll serverControll_0)
        {
            List<Entity> list = new List<Entity>();
            for (int i = 0; i < 30; i++)
            {
                Entity item = serverControll_0.Call<Entity>("getentbynum", new Parameter[] { i });
                if ((item != null) && item.IsPlayer)
                {
                    list.Add(item);
                }
            }
            return list.ToArray();
        }

        /* private scope */ internal static void smethod_2(ServerControll serverControll_0)
        {
            try
            {
                if (ServerControll.AntiBadWords)
                {
                    if (System.IO.File.Exists(ServerControll.DirConfMove + ServerControll.FileParolacce))
                    {
                        ServerControll.BadWords.AddRange(System.IO.File.ReadAllLines(ServerControll.DirConfMove + ServerControll.FileParolacce));
                    }
                    else
                    {
                        System.IO.File.CreateText(ServerControll.DirConfMove + ServerControll.FileParolacce);
                    }
                }
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "LoadBadwords");
            }
        }

        /* private scope */ internal static bool smethod_20(Class75.Class77 class77_0)
        {
            return (class77_0.int_0 == class77_0.int_1);
        }

        /* private scope */ internal static void smethod_21(ServerControll serverControll_0, Entity entity_0)
        {
            Action<Entity> function = null;
            try
            {
                if (function == null)
                {
                    function = new Action<Entity>(serverControll_0.method_50);
                }
                entity_0.AfterDelay(0x1388, function);
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "PlayerRitardo5Sec");
            }
        }

        /* private scope */ internal static Entity smethod_22(string string_0, ServerControll serverControll_0, Entity entity_0)
        {
            try
            {
                int num = 0;
                Entity entity = null;
                foreach (Entity entity2 in smethod_19(serverControll_0))
                {
                    if (string_0.Length < 3)
                    {
                        if (serverControll_0.getPlayerSlot(entity2) == string_0)
                        {
                            entity = entity2;
                            num++;
                        }
                    }
                    else if ((entity2.Name.ToLower().Contains(string_0) || (serverControll_0.getPlayerID(entity2) == string_0)) || ((serverControll_0.getPlayerGuid(entity2) == string_0) || (serverControll_0.getPlayerXuid(entity2) == string_0)))
                    {
                        entity = entity2;
                        num++;
                    }
                }
                if (num == 1)
                {
                    return entity;
                }
                if (num > 1)
                {
                    entity_0.Call("iprintlnbold", new Parameter[] { "^7Error ^5- ^7Multiple Matches Found!" });
                    return null;
                }
                entity_0.Call("iprintlnbold", new Parameter[] { "^7Error ^5- ^7No Player Found!" });
                return null;
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "TrovaPlayerME");
                return null;
            }
        }

        /* private scope */ internal static void smethod_23(Entity entity_0, ServerControll serverControll_0)
        {
            entity_0.GetField<HudElem>("PassText1").SetText(serverControll_0.messpass(entity_0));
            entity_0.Call("iprintlnbold", new Parameter[] { serverControll_0.messpass(entity_0) });
            smethod_125(serverControll_0, entity_0, "^7Private Game Or Training In Progress, If You Are Not Allowed Go Out... Tnx!");
        }

        /* private scope */ internal static void smethod_24(ServerControll serverControll_0)
        {
            if (!System.IO.File.Exists(ServerControll.DirConfLocal + ServerControll.FileAdv))
            {
                using (StreamWriter writer = new StreamWriter(ServerControll.DirConfLocal + ServerControll.FileAdv, true))
                {
                    writer.WriteLine("#time");
                    writer.WriteLine("^5Telegram: ^7@NaaB_Bax");
                    writer.WriteLine("#report");
                    writer.WriteLine("^5TeamSpeak: ^7ts.naabbax.ir");
                    writer.WriteLine("#nextmap");
                    writer.WriteLine("^5WebSite: ^7naabbax.ir");
                    writer.Close();
                }
            }
            if (!System.IO.File.Exists(ServerControll.DirConfLocal + ServerControll.FileRules))
            {
                using (StreamWriter writer2 = new StreamWriter(ServerControll.DirConfLocal + ServerControll.FileRules, true))
                {
                    writer2.WriteLine("^5No Rules!");
                    writer2.Close();
                }
            }
        }

        /* private scope */ internal static void smethod_25(ServerControll serverControll_0)
        {
            ServerControll.JumpHeight = ServerControll.salto;
            ServerControll.Speed = ServerControll.int_0;
            ServerControll.Gravity = ServerControll.int_1;
        }

        /* private scope */ internal static void smethod_26(string string_0, ServerControll serverControll_0, Entity entity_0)
        {
            ServerControll.NxtMap = string_0;
            smethod_125(serverControll_0, entity_0, "^7NextMap Set ^5" + smethod_124(serverControll_0, ServerControll.NxtMap));
            if (System.IO.File.Exists(ServerControll.DirTempFile + "nextmaps"))
            {
                System.IO.File.Delete(ServerControll.DirTempFile + "nextmaps");
            }
            using (StreamWriter writer = new StreamWriter(ServerControll.DirTempFile + "nextmaps", true))
            {
                writer.WriteLine(ServerControll.MapName);
                writer.WriteLine(ServerControll.NxtMap);
                writer.Close();
            }
        }

        /* private scope */ internal static void smethod_27(ServerControll serverControll_0)
        {
            serverControll_0.AfterDelay(0x1f40, new Action(serverControll_0.method_53));
        }

        /* private scope */ internal static void smethod_28(ServerControll serverControll_0, Entity entity_0)
        {
            ServerControll.Class44 class3 = new ServerControll.Class44 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                ServerControll.Class45 class2 = new ServerControll.Class45 {
                    class44_0 = class3
                };
                smethod_125(serverControll_0, class3.entity_0, "^7All Player^5[^7" + ServerControll.AllGiocatori.Count + "^5] ^7List In Game^5:^7");
                class2.int_0 = 0;
                class2.entity_0 = ServerControll.AllGiocatori.ToArray();
                serverControll_0.OnInterval(0x3e8, new Func<bool>(class2.method_0));
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "ListAllPlayer");
            }
        }

        /* private scope */ internal static void smethod_29(Entity entity_0, Entity entity_1, ServerControll serverControll_0)
        {
            if (System.IO.File.Exists(ServerControll.DirConfMove + ServerControll.FileAlias))
            {
                string[] strArray = System.IO.File.ReadAllLines(ServerControll.DirConfMove + ServerControll.FileAlias);
                System.IO.File.Delete(ServerControll.DirConfMove + ServerControll.FileAlias);
                bool flag = false;
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { ServerControll.sep1 });
                    bool flag2 = true;
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (strArray2[j].Equals(serverControll_0.getPlayerName(entity_0)))
                        {
                            goto Label_0090;
                        }
                    }
                    goto Label_00AD;
                Label_0090:
                    flag2 = false;
                    flag = true;
                    smethod_125(serverControll_0, entity_1, "^7Alias Eliminated Player ^5" + serverControll_0.getPlayerName(entity_0));
                Label_00AD:
                    if (flag2)
                    {
                        using (StreamWriter writer = new StreamWriter(ServerControll.DirConfMove + ServerControll.FileAlias, true))
                        {
                            writer.WriteLine(strArray[i]);
                            writer.Close();
                        }
                    }
                }
                if (!flag)
                {
                    smethod_125(serverControll_0, entity_1, "^7No Player Found!");
                }
            }
        }

        /* private scope */ internal static void smethod_3(Entity entity_0, ServerControll serverControll_0)
        {
            ServerControll.Class22 class2 = new ServerControll.Class22 {
                serverControll_0 = serverControll_0
            };
            if (ServerControll.string_0 != "hide")
            {
                class2.hudElem_0 = HudElem.NewHudElem();
                class2.hudElem_0 = HudElem.CreateFontString(entity_0, "hudbig", 0.5f);
                class2.hudElem_0.SetPoint("CENTER", "CENTER", 0, 220);
                class2.hudElem_0.HideWhenInMenu = true;
                entity_0.OnInterval(0x3e8, new Func<Entity, bool>(class2.method_0));
            }
        }

        /* private scope */ internal static void smethod_30(Class74 class74_0)
        {
            class74_0.type_0.GetMethod("Clear").Invoke(class74_0.object_0, new object[0]);
        }

        /* private scope */ internal static void smethod_31(string string_0, ServerControll serverControll_0, Entity entity_0)
        {
            using (StreamWriter writer = new StreamWriter(ServerControll.DirConfLocal + ServerControll.FileAdv, true))
            {
                writer.WriteLine(string_0);
                writer.Close();
                if (entity_0 != null)
                {
                    smethod_125(serverControll_0, entity_0, "^7New ADV Added To The List!");
                }
            }
        }

        /* private scope */ internal static int smethod_32(Class75.Class77 class77_0, int int_0)
        {
            if (class77_0.int_2 < int_0)
            {
                if (class77_0.int_0 == class77_0.int_1)
                {
                    return -1;
                }
                class77_0.uint_0 |= (uint) (((class77_0.byte_0[class77_0.int_0++] & 0xff) | ((class77_0.byte_0[class77_0.int_0++] & 0xff) << 8)) << class77_0.int_2);
                class77_0.int_2 += 0x10;
            }
            return (((int) class77_0.uint_0) & ((((int) 1) << int_0) - 1));
        }

        /* private scope */ internal static void smethod_33(ServerControll serverControll_0, string string_0, object[] object_0)
        {
            smethod_130(string_0, serverControll_0);
            Log.Write(InfinityScript.LogLevel.All, string_0, object_0);
        }

        /* private scope */ /*internal static void smethod_34(ServerControll serverControll_0, string string_0)
        {
            try
            {
                ServerControll.downGPS = false;
                ServerControll.PercDownLoad = 0;
                string[] strArray = string_0.Split(new char[] { '/' });
                int index = strArray.Length - 1;
                string fileName = ServerControll.executionPath + @"\" + ServerControll.FileAdm + @"\" + strArray[index];
                smethod_33(serverControll_0, "Start Download Files... [" + strArray[index] + "]", new object[0]);
                Uri address = new Uri(string_0);
                WebClient client = new WebClient();
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(serverControll_0.method_30);
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(serverControll_0.method_29);
                client.DownloadFileAsync(address, fileName);
            }
            catch (Exception exception)
            {
                string[] strArray2 = string_0.Split(new char[] { '/' });
                int num2 = strArray2.Length - 1;
                string path = ServerControll.executionPath + @"\" + ServerControll.FileAdm + @"\" + strArray2[num2];
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                ServerControll.ScanGPS = false;
                smethod_33(serverControll_0, "Error - Download The GPS File Manually: https://naabbax.ir And Put It In The Folder ServerControll", new object[0]);
                smethod_57(exception, serverControll_0, "DownloadGPS");
            }
        }*/

        /* private scope */ internal static void smethod_35(string string_0, string string_1, ServerControll serverControll_0)
        {
            try
            {
                string[] strArray = string_0.Split(new char[] { '/' });
                int index = strArray.Length - 1;
                Uri address = new Uri(string_0);
                new WebClient().DownloadFile(address, string_1 + strArray[index]);
            }
            catch (Exception exception)
            {
                string[] strArray2 = string_0.Split(new char[] { '/' });
                int num2 = strArray2.Length - 1;
                if (System.IO.File.Exists(string_1 + strArray2[num2]))
                {
                    System.IO.File.Delete(string_1 + strArray2[num2]);
                }
                /*ServerControll.AutoUpdate = false;
                smethod_33(serverControll_0, "Error - Problem Automatic Updates, Check For Updates Manually On The Official Page: https://naabbax.ir", new object[0]);
                smethod_57(exception, serverControll_0, "DownloadUpdate");*/
            }
        }

        /* private scope */ internal static int smethod_36(Class75.Class78 class78_0)
        {
            return class78_0.int_1;
        }

        /* private scope */ internal static void smethod_37(ServerControll serverControll_0)
        {
            ServerControll.GRTitleServer = HudElem.CreateServerFontString("hudbig", 0.5f);
            ServerControll.GRTitleServer.SetPoint("RIGHT", "TOPRIGHT", -5, 8);
            ServerControll.GRTitleServer.SetText(serverControll_0.NomeServer + "^7 ^5\"^7" + smethod_124(serverControll_0, ServerControll.MapName) + "^5\"^7");
            ServerControll.GRTitleServer.HideWhenInMenu = false;
            if (((ServerControll.TitleClan != null) && (ServerControll.TitleClan != "null")) && (ServerControll.string_0 != "hide"))
            {
                ServerControll.GRTitleClan = HudElem.CreateServerFontString("hudbig", 0.5f);
                ServerControll.GRTitleClan.SetPoint("CENTER", "TOPCENTER", 0, 20);
                ServerControll.GRTitleClan.SetText(ServerControll.TitleClan);
                ServerControll.GRTitleClan.HideWhenInMenu = false;
            }
            if ((ServerControll.TitoloScorr != null) && (ServerControll.TitoloScorr != "null"))
            {
                ServerControll.motd = HudElem.CreateServerFontString("boldFont", 1f);
                ServerControll.motd.SetPoint("CENTER", "BOTTOM", 0, -19);
                ServerControll.motd.Foreground = true;
                ServerControll.motd.HideWhenInMenu = true;
                if (ServerControll.func_0 == null)
                {
                    ServerControll.func_0 = new Func<bool>(ServerControll.smethod_1);
                }
                serverControll_0.OnInterval(0x61a8, ServerControll.func_0);
            }
        }

        /* private scope */ internal static void smethod_38(ServerControll serverControll_0)
        {
            if (System.IO.File.Exists(ServerControll.DirTempFile + ServerControll.FileSessione))
            {
                System.IO.File.Delete(ServerControll.DirTempFile + ServerControll.FileSessione);
            }
            if (ServerControll.UserSession.Count != 0)
            {
                for (int i = 0; i < ServerControll.UserSession.Count; i++)
                {
                    using (StreamWriter writer = new StreamWriter(ServerControll.DirTempFile + ServerControll.FileSessione, true))
                    {
                        writer.WriteLine(ServerControll.UserSession[i]);
                        writer.Close();
                    }
                }
            }
        }

        /* private scope */ internal static int smethod_39(string string_0, ServerControll serverControll_0)
        {
            try
            {
                int num = 1;
                for (int i = 0; i < ServerControll.Mod.Length; i++)
                {
                    if (ServerControll.Mod[i].StartsWith(string_0))
                    {
                        num = 2;
                    }
                }
                for (int j = 0; j < ServerControll.SeniorMod.Length; j++)
                {
                    if (ServerControll.SeniorMod[j].StartsWith(string_0))
                    {
                        num = 3;
                    }
                }
                for (int k = 0; k < ServerControll.Admin.Length; k++)
                {
                    if (ServerControll.Admin[k].StartsWith(string_0))
                    {
                        num = 4;
                    }
                }
                for (int m = 0; m < ServerControll.SuperAdmin.Length; m++)
                {
                    if (ServerControll.SuperAdmin[m].StartsWith(string_0))
                    {
                        num = 5;
                    }
                }
                return num;
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "ControllAdminExit");
                return 1;
            }
        }

        /* private scope */  internal static unsafe void smethod_4(ServerControll serverControll_0)
        {
            if (ServerControll.AntiSoundADS)
            {
                int num = 0x41da56;
                if (*(int*)(0x41da56) == 0x8b)
                {
                    uint num2;
                    byte[] buffer = new byte[] { 
                        80, 0x8b, 0x40, 12, 0xa9, 80, 0, 0, 0, 0x58, 0x74, 3, 0x31, 0xc0, 0xc3, 0x8b, 
                        0x80, 100, 1, 0, 0, 0xe9
                     };
                    IntPtr ptr = VirtualAlloc(IntPtr.Zero, (UIntPtr) (buffer.Length + 5), 0x1000, 0x40);
                    VirtualProtect((IntPtr) num, (IntPtr) 5, 0x40, out num2);
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        ((int*) ptr)[i] = (sbyte) buffer[i];
                    }
                    int num4 = (num + 6) - ((((int) ptr) + buffer.Length) + 4);
                    *(int*)((IntPtr)(((int)ptr) + buffer.Length)) = num4;
                    *(int*)((IntPtr)num) = -23;
                    int num5 = ((int) ptr) - (num + 5);
                    *(int*)((IntPtr)(num + 1)) = num5;
                    *(int*)((IntPtr)(num + 5)) = -112;
                    VirtualProtect((IntPtr) num, (IntPtr) 5, num2, out num2);
                }
            }
        }

        /* private scope */ internal static long smethod_40(byte[] byte_0)
        {
            long num = 0L;
            for (int i = 0; i < 4; i++)
            {
                long num3 = byte_0[i];
                if (num3 < 0L)
                {
                    num3 += 0x100L;
                }
                num += num3 << ((3 - i) * 8);
            }
            return num;
        }

        /* private scope */ internal static bool smethod_41(Class75.Class76 class76_0)
        {
            int num = smethod_69(class76_0.class78_0);
            while (num >= 0x102)
            {
                int num2;
                switch (class76_0.int_4)
                {
                    case 7:
                        goto Label_0052;

                    case 8:
                        goto Label_009E;

                    case 9:
                        goto Label_00EE;

                    case 10:
                        goto Label_0121;

                    default:
                    {
                        continue;
                    }
                }
            Label_0037:
                smethod_157(class76_0.class78_0, num2);
                if (--num < 0x102)
                {
                    return true;
                }
            Label_0052:
                if (((num2 = smethod_79(class76_0.class79_0, class76_0.class77_0)) & -256) == 0)
                {
                    goto Label_0037;
                }
                if (num2 < 0x101)
                {
                    if (num2 < 0)
                    {
                        return false;
                    }
                    class76_0.class79_1 = null;
                    class76_0.class79_0 = null;
                    class76_0.int_4 = 2;
                    return true;
                }
                class76_0.int_6 = Class75.Class76.int_0[num2 - 0x101];
                class76_0.int_5 = Class75.Class76.int_1[num2 - 0x101];
            Label_009E:
                if (class76_0.int_5 > 0)
                {
                    class76_0.int_4 = 8;
                    int num3 = smethod_32(class76_0.class77_0, class76_0.int_5);
                    if (num3 < 0)
                    {
                        return false;
                    }
                    smethod_55(class76_0.class77_0, class76_0.int_5);
                    class76_0.int_6 += num3;
                }
                class76_0.int_4 = 9;
            Label_00EE:
                num2 = smethod_79(class76_0.class79_1, class76_0.class77_0);
                if (num2 < 0)
                {
                    return false;
                }
                class76_0.int_7 = Class75.Class76.int_2[num2];
                class76_0.int_5 = Class75.Class76.int_3[num2];
            Label_0121:
                if (class76_0.int_5 > 0)
                {
                    class76_0.int_4 = 10;
                    int num4 = smethod_32(class76_0.class77_0, class76_0.int_5);
                    if (num4 < 0)
                    {
                        return false;
                    }
                    smethod_55(class76_0.class77_0, class76_0.int_5);
                    class76_0.int_7 += num4;
                }
                smethod_100(class76_0.class78_0, class76_0.int_6, class76_0.int_7);
                num -= class76_0.int_6;
                class76_0.int_4 = 7;
            }
            return true;
        }

        /* private scope */ internal static void smethod_42(ServerControll serverControll_0, Entity entity_0)
        {
            try
            {
                string[] strArray = null;
                bool flag = false;
                if (!System.IO.File.Exists(ServerControll.DirConfLocal + ServerControll.FileXlrStats))
                {
                    goto Label_0159;
                }
                strArray = System.IO.File.ReadAllLines(ServerControll.DirConfLocal + ServerControll.FileXlrStats);
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i].StartsWith(serverControll_0.getPlayerGuid(entity_0)))
                    {
                        goto Label_0053;
                    }
                }
                goto Label_0061;
            Label_0053:
                smethod_125(serverControll_0, entity_0, "^7You Are Already Registered!");
                flag = true;
            Label_0061:
                if (flag)
                {
                    return;
                }
                using (StreamWriter writer = new StreamWriter(ServerControll.DirConfLocal + ServerControll.FileXlrStats, true))
                {
                    writer.WriteLine(string.Concat(new object[] { serverControll_0.getPlayerGuid(entity_0), ServerControll.sep5, serverControll_0.getPlayerName(entity_0), ServerControll.sep5, DateTime.Now, ServerControll.sep2, ServerControll.xlrDay, ServerControll.sep5, "0", ServerControll.sep5, "0", ServerControll.sep5, "0" }));
                    writer.Close();
                    smethod_125(serverControll_0, entity_0, "^7Successfully Registered On XlrStats!");
                    return;
                }
            Label_0159:
                using (StreamWriter writer2 = new StreamWriter(ServerControll.DirConfLocal + ServerControll.FileXlrStats, true))
                {
                    writer2.WriteLine(string.Concat(new object[] { serverControll_0.getPlayerGuid(entity_0), ServerControll.sep5, serverControll_0.getPlayerName(entity_0), ServerControll.sep5, DateTime.Now, ServerControll.sep2, ServerControll.xlrDay, ServerControll.sep5, "0", ServerControll.sep5, "0", ServerControll.sep5, "0" }));
                    writer2.Close();
                    smethod_125(serverControll_0, entity_0, "^7Successfully Registered!");
                }
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "XlrRegister");
            }
        }

        /* private scope */ internal static void smethod_43(ServerControll serverControll_0, Entity entity_0)
        {
            ServerControll.Class34 class3 = new ServerControll.Class34 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                if (System.IO.File.Exists(ServerControll.DirConfMove + ServerControll.FileTempBan))
                {
                    ServerControll.Class35 class2 = new ServerControll.Class35 {
                        class34_0 = class3,
                        string_0 = System.IO.File.ReadAllLines(ServerControll.DirConfMove + ServerControll.FileTempBan),
                        int_0 = 0
                    };
                    smethod_125(serverControll_0, class3.entity_0, "^7List^5[^7" + class2.string_0.Length + "^5] ^7Player TempBan:^5");
                    serverControll_0.OnInterval(0x3e8, new Func<bool>(class2.method_0));
                }
                else
                {
                    smethod_125(serverControll_0, class3.entity_0, "^7No Player Found!");
                }
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "ListTempBan");
            }
        }

        /* private scope */ internal static void smethod_44(ServerControll serverControll_0, Entity entity_0)
        {
            ServerControll.Class40 class3 = new ServerControll.Class40 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                if (System.IO.File.Exists(ServerControll.DirConfLocal + ServerControll.FileXlrStats))
                {
                    Action function = null;
                    Action action2 = null;
                    Action action3 = null;
                    Action action4 = null;
                    Action action5 = null;
                    Action action6 = null;
                    ServerControll.Class41 class2 = new ServerControll.Class41 {
                        class40_0 = class3
                    };
                    double num = 0.0;
                    string str = null;
                    double num2 = 0.0;
                    string str2 = null;
                    double num3 = 0.0;
                    string str3 = null;
                    int num4 = 0;
                    int num5 = 0;
                    class2.string_0 = null;
                    class2.string_1 = null;
                    class2.string_2 = null;
                    string[] strArray = System.IO.File.ReadAllLines(ServerControll.DirConfLocal + ServerControll.FileXlrStats);
                    if (strArray.Length > 2)
                    {
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            string[] strArray2 = strArray[i].Split(new char[] { ServerControll.sep5 });
                            string str4 = strArray2[1];
                            double num7 = Convert.ToDouble(strArray2[5]);
                            double num8 = Convert.ToDouble(strArray2[3]);
                            if ((num7 > num) && (num8 >= 50.0))
                            {
                                num = num7;
                                str = str4;
                                num4 = i;
                            }
                        }
                        class2.string_0 = string.Concat(new object[] { "^71\x00b0 ^5", str, " ^7Skill: ^5", num });
                        for (int j = 0; j < strArray.Length; j++)
                        {
                            string[] strArray3 = strArray[j].Split(new char[] { ServerControll.sep5 });
                            string str5 = strArray3[1];
                            double num10 = Convert.ToDouble(strArray3[5]);
                            double num11 = Convert.ToDouble(strArray3[3]);
                            if (((j != num4) && (num10 > num2)) && (num11 >= 50.0))
                            {
                                num2 = num10;
                                str2 = str5;
                                num5 = j;
                            }
                        }
                        class2.string_1 = string.Concat(new object[] { "^72\x00b0 ^5", str2, " ^7Skill: ^5", num2 });
                        for (int k = 0; k < strArray.Length; k++)
                        {
                            string[] strArray4 = strArray[k].Split(new char[] { ServerControll.sep5 });
                            string str6 = strArray4[1];
                            double num13 = Convert.ToDouble(strArray4[5]);
                            double num14 = Convert.ToDouble(strArray4[3]);
                            if (((k != num4) && (k != num5)) && ((num13 > num3) && (num14 >= 50.0)))
                            {
                                num3 = num13;
                                str3 = str6;
                            }
                        }
                        class2.string_2 = string.Concat(new object[] { "^73\x00b0 ^5", str3, " ^7Skill: ^5", num3 });
                        if (class3.entity_0 != null)
                        {
                            if (function == null)
                            {
                                function = new Action(class2.method_0);
                            }
                            serverControll_0.AfterDelay(10, function);
                            if (action2 == null)
                            {
                                action2 = new Action(class2.method_1);
                            }
                            serverControll_0.AfterDelay(0x3e8, action2);
                            if (action3 == null)
                            {
                                action3 = new Action(class2.method_2);
                            }
                            serverControll_0.AfterDelay(0x7d0, action3);
                        }
                        else
                        {
                            if (action4 == null)
                            {
                                action4 = new Action(class2.method_3);
                            }
                            serverControll_0.AfterDelay(10, action4);
                            if (action5 == null)
                            {
                                action5 = new Action(class2.method_4);
                            }
                            serverControll_0.AfterDelay(0x3e8, action5);
                            if (action6 == null)
                            {
                                action6 = new Action(class2.method_5);
                            }
                            serverControll_0.AfterDelay(0x7d0, action6);
                        }
                    }
                    else if (class3.entity_0 != null)
                    {
                        smethod_125(serverControll_0, class3.entity_0, "^7It Takes At Least 3 Player Statistics");
                    }
                }
                else if (class3.entity_0 != null)
                {
                    smethod_125(serverControll_0, class3.entity_0, "^7Could Not Find You In The Stats Database, Type ^5!register ^7To Save Your Stats");
                }
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "XlrTopStats");
            }
        }

        /* private scope */ internal static int smethod_45(int int_0, int int_1, Class75.Class78 class78_0, byte[] byte_0)
        {
            int num = class78_0.int_0;
            if (int_1 > class78_0.int_1)
            {
                int_1 = class78_0.int_1;
            }
            else
            {
                num = ((class78_0.int_0 - class78_0.int_1) + int_1) & 0x7fff;
            }
            int num2 = int_1;
            int length = int_1 - num;
            if (length > 0)
            {
                Array.Copy(class78_0.byte_0, 0x8000 - length, byte_0, int_0, length);
                int_0 += length;
                int_1 = num;
            }
            Array.Copy(class78_0.byte_0, num - int_1, byte_0, int_0, int_1);
            class78_0.int_1 -= num2;
            if (class78_0.int_1 < 0)
            {
                throw new InvalidOperationException();
            }
            return num2;
        }

        /* private scope */ internal static int smethod_46(byte[] byte_0, int int_0, Class75.Class76 class76_0, int int_1)
        {
            int num = 0;
            goto Label_0048;
        Label_0004:
            if (!smethod_71(class76_0) && ((class76_0.class78_0.int_1 <= 0) || (class76_0.int_4 == 11)))
            {
                return num;
            }
        Label_0048:
            if (class76_0.int_4 == 11)
            {
                goto Label_0004;
            }
            int num2 = smethod_45(int_1, int_0, class76_0.class78_0, byte_0);
            int_1 += num2;
            num += num2;
            int_0 -= num2;
            if (int_0 != 0)
            {
                goto Label_0004;
            }
            return num;
        }

        /* private scope */ internal static int smethod_47(Class75.Stream0 stream0_0)
        {
            return (smethod_109(stream0_0) | (smethod_109(stream0_0) << 0x10));
        }

        /* private scope */ internal static void smethod_48(Entity entity_0, ServerControll serverControll_0)
        {
            if (System.IO.File.Exists(ServerControll.DirTempFile + ServerControll.FileLastExit))
            {
                string[] strArray = System.IO.File.ReadAllLines(ServerControll.DirTempFile + ServerControll.FileLastExit);
                int num = 9;
                if (strArray.Length >= 10)
                {
                    System.IO.File.Delete(ServerControll.DirTempFile + ServerControll.FileLastExit);
                    using (StreamWriter writer = new StreamWriter(ServerControll.DirTempFile + ServerControll.FileLastExit, true))
                    {
                        string str = string.Concat(new object[] { serverControll_0.getPlayerName(entity_0), ServerControll.sep1, serverControll_0.getPlayerID(entity_0), ServerControll.sep1, serverControll_0.getPlayerGuid(entity_0), ServerControll.sep1, serverControll_0.getPlayerHWID(entity_0), ServerControll.sep1, serverControll_0.getPlayerXuid(entity_0), ServerControll.sep1, serverControll_0.getPlayerIP(entity_0) });
                        for (int i = 1; i < num; i++)
                        {
                            writer.WriteLine(strArray[i]);
                        }
                        writer.WriteLine(str);
                        writer.Close();
                        return;
                    }
                }
                using (StreamWriter writer2 = new StreamWriter(ServerControll.DirTempFile + ServerControll.FileLastExit, true))
                {
                    string str2 = string.Concat(new object[] { serverControll_0.getPlayerName(entity_0), ServerControll.sep1, serverControll_0.getPlayerID(entity_0), ServerControll.sep1, serverControll_0.getPlayerGuid(entity_0), ServerControll.sep1, serverControll_0.getPlayerHWID(entity_0), ServerControll.sep1, serverControll_0.getPlayerXuid(entity_0), ServerControll.sep1, serverControll_0.getPlayerIP(entity_0) });
                    writer2.WriteLine(str2);
                    writer2.Close();
                    return;
                }
            }
            using (StreamWriter writer3 = new StreamWriter(ServerControll.DirTempFile + ServerControll.FileLastExit, true))
            {
                string str3 = string.Concat(new object[] { serverControll_0.getPlayerName(entity_0), ServerControll.sep1, serverControll_0.getPlayerID(entity_0), ServerControll.sep1, serverControll_0.getPlayerGuid(entity_0), ServerControll.sep1, serverControll_0.getPlayerHWID(entity_0), ServerControll.sep1, serverControll_0.getPlayerXuid(entity_0), ServerControll.sep1, serverControll_0.getPlayerIP(entity_0) });
                writer3.WriteLine(str3);
                writer3.Close();
            }
        }

        /* private scope */ internal static void smethod_49(Class75.Class78 class78_0, int int_0, int int_1, int int_2)
        {
            while (int_1-- > 0)
            {
                class78_0.byte_0[class78_0.int_0++] = class78_0.byte_0[int_0++];
                class78_0.int_0 &= 0x7fff;
                int_0 &= 0x7fff;
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        /* private scope */ internal static int smethod_5(LookupService lookupService_0, IPAddress ipaddress_0)
        {
            byte[] addressBytes = ipaddress_0.GetAddressBytes();
            byte[] buffer = new byte[2 * LookupService.int_8];
            int[] numArray = new int[2];
            int num = 0;
            int num2 = 0x7f;
            while (true)
            {
                if (num2 < 0)
                {
                    Console.Write("Error Seeking Country While Seeking " + ipaddress_0);
                    return 0;
                }
                try
                {
                    if ((lookupService_0.int_4 & LookupService.GEOIP_MEMORY_CACHE) == 1)
                    {
                        for (int j = 0; j < (2 * LookupService.int_8); j++)
                        {
                            buffer[j] = lookupService_0.byte_1[j + ((2 * lookupService_0.int_10) * num)];
                        }
                    }
                    else
                    {
                        lookupService_0.fileStream_0.Seek((long) ((2 * lookupService_0.int_10) * num), SeekOrigin.Begin);
                        lookupService_0.fileStream_0.Read(buffer, 0, 2 * LookupService.int_8);
                    }
                }
                catch (IOException)
                {
                    Console.Write("IO Exception");
                }
                for (int i = 0; i < 2; i++)
                {
                    numArray[i] = 0;
                    for (int k = 0; k < lookupService_0.int_10; k++)
                    {
                        int num6 = buffer[(i * lookupService_0.int_10) + k];
                        if (num6 < 0)
                        {
                            num6 += 0x100;
                        }
                        numArray[i] += num6 << (k * 8);
                    }
                }
                int num7 = 0x7f - num2;
                int index = num7 >> 3;
                int num9 = ((int) 1) << ((num7 & 7) ^ 7);
                if ((addressBytes[index] & num9) > 0)
                {
                    if (numArray[1] >= lookupService_0.int_3[0])
                    {
                        return numArray[1];
                    }
                    num = numArray[1];
                }
                else
                {
                    if (numArray[0] >= lookupService_0.int_3[0])
                    {
                        return numArray[0];
                    }
                    num = numArray[0];
                }
                num2--;
            }
        }

        /* private scope */ internal static bool smethod_50(char char_0)
        {
            return (char_0 >= '\x007f');
        }

        /* private scope */ internal static void smethod_51(ServerControll serverControll_0)
        {
            int num;
            byte? nullable = null;
            byte?[] nullableArray = new byte?[15];
            byte[] buffer = new byte[] { 0x90, 0x90 };
            byte[] buffer2 = new byte[] { 0x90, 0x90, 0x90 };
            nullableArray = new byte?[20];
            nullableArray[0] = 0xd9;
            nullable = null;
            nullableArray[1] = nullable;
            nullable = null;
            nullableArray[2] = nullable;
            nullableArray[3] = 0x74;
            nullableArray[4] = 14;
            nullableArray[5] = 0xa1;
            nullable = null;
            nullableArray[6] = nullable;
            nullable = null;
            nullableArray[7] = nullable;
            nullable = null;
            nullableArray[8] = nullable;
            nullable = null;
            nullableArray[9] = nullable;
            nullableArray[10] = 0xd9;
            nullable = null;
            nullableArray[11] = nullable;
            nullable = null;
            nullableArray[12] = nullable;
            nullableArray[13] = 0xd8;
            nullable = null;
            nullableArray[14] = nullable;
            nullable = null;
            nullableArray[15] = nullable;
            nullableArray[0x10] = 0xd9;
            nullable = null;
            nullableArray[0x11] = nullable;
            nullable = null;
            nullableArray[0x12] = nullable;
            nullableArray[0x13] = 0xd9;
            byte?[] nullableArray2 = nullableArray;
            //smethod_80(0x400000, serverControll_0, nullableArray2, 1, 0x480000);
            smethod_80(1, nullableArray2, 0x400000, serverControll_0, 0x480000);
            nullableArray = new byte?[15];
            nullableArray[0] = 0x74;
            nullableArray[1] = 0x1d;
            nullableArray[2] = 0xf7;
            nullable = null;
            nullableArray[3] = nullable;
            nullable = null;
            nullableArray[4] = nullable;
            nullable = null;
            nullableArray[5] = nullable;
            nullable = null;
            nullableArray[6] = nullable;
            nullable = null;
            nullableArray[7] = nullable;
            nullableArray[8] = 0;
            nullableArray[9] = 0;
            nullableArray[10] = 0;
            nullableArray[11] = 4;
            nullableArray[12] = 0x74;
            nullableArray[13] = 0x11;
            nullableArray[14] = 0x8b;
            byte?[] nullableArray3 = nullableArray;
            //int num2 = smethod_80(0x400000, serverControll_0, nullableArray3, 1, 0x480000) + 12;
            int num2 = smethod_80(1, nullableArray3, 0x400000, serverControll_0, 0x480000) + 12;
            WriteProcessMemory_1((IntPtr) (-1), (IntPtr) num2, buffer, (IntPtr) buffer.Length, out num);
            nullableArray = new byte?[15];
            nullableArray[0] = 0x74;
            nullableArray[1] = 0x35;
            nullableArray[2] = 0xf7;
            nullable = null;
            nullableArray[3] = nullable;
            nullable = null;
            nullableArray[4] = nullable;
            nullable = null;
            nullableArray[5] = nullable;
            nullable = null;
            nullableArray[6] = nullable;
            nullable = null;
            nullableArray[7] = nullable;
            nullableArray[8] = 0;
            nullableArray[9] = 0;
            nullableArray[10] = 0;
            nullableArray[11] = 4;
            nullableArray[12] = 0x74;
            nullableArray[13] = 0x29;
            nullableArray[14] = 0x8b;
            byte?[] nullableArray4 = nullableArray;
            //int num3 = smethod_80(0x400000, serverControll_0, nullableArray4, 1, 0x480000) + 12;
            int num3 = smethod_80(1, nullableArray4, 0x400000, serverControll_0, 0x480000) + 12;
            WriteProcessMemory_1((IntPtr) (-1), (IntPtr) num3, buffer, (IntPtr) buffer.Length, out num);
            nullableArray = new byte?[13];
            nullableArray[0] = 0xf7;
            nullable = null;
            nullableArray[1] = nullable;
            nullable = null;
            nullableArray[2] = nullable;
            nullable = null;
            nullableArray[3] = nullable;
            nullable = null;
            nullableArray[4] = nullable;
            nullable = null;
            nullableArray[5] = nullable;
            nullableArray[6] = 0;
            nullableArray[7] = 0x80;
            nullableArray[8] = 0;
            nullableArray[9] = 0;
            nullableArray[10] = 0x74;
            nullableArray[11] = 0x11;
            nullableArray[12] = 0x8b;
            byte?[] nullableArray5 = nullableArray;
            //smethod_80(0x400000, serverControll_0, nullableArray5, 1, 0x480000);
            smethod_80(1, nullableArray5, 0x400000, serverControll_0, 0x480000);
            nullableArray = new byte?[13];
            nullableArray[0] = 0x74;
            nullableArray[1] = 7;
            nullableArray[2] = 0x2b;
            nullable = null;
            nullableArray[3] = nullable;
            nullable = null;
            nullableArray[4] = nullable;
            nullable = null;
            nullableArray[5] = nullable;
            nullableArray[6] = 0x89;
            nullable = null;
            nullableArray[7] = nullable;
            nullable = null;
            nullableArray[8] = nullable;
            nullableArray[9] = 0x83;
            nullable = null;
            nullableArray[10] = nullable;
            nullable = null;
            nullableArray[11] = nullable;
            nullableArray[12] = 0;
            byte?[] nullableArray6 = nullableArray;
            if (ServerControll.EsplosioneBomba && (ServerControll.TypeMap != "infect"))
            {
                //int num4 = smethod_80(0x400000, serverControll_0, nullableArray6, 1, 0x480000) + 6;
                int num4 = smethod_80(1, nullableArray6, 0x400000, serverControll_0, 0x480000) + 6;
                WriteProcessMemory_1((IntPtr) (-1), (IntPtr) num4, buffer2, (IntPtr) buffer2.Length, out num);
            }
            nullableArray = new byte?[20];
            nullableArray[0] = 0x83;
            nullable = null;
            nullableArray[1] = nullable;
            nullable = null;
            nullableArray[2] = nullable;
            nullable = null;
            nullableArray[3] = nullable;
            nullable = null;
            nullableArray[4] = nullable;
            nullable = null;
            nullableArray[5] = nullable;
            nullable = null;
            nullableArray[6] = nullable;
            nullableArray[7] = 0x7d;
            nullableArray[8] = 10;
            nullableArray[9] = 0xc7;
            nullable = null;
            nullableArray[10] = nullable;
            nullable = null;
            nullableArray[11] = nullable;
            nullable = null;
            nullableArray[12] = nullable;
            nullable = null;
            nullableArray[13] = nullable;
            nullable = null;
            nullableArray[14] = nullable;
            nullableArray[15] = 0;
            nullableArray[0x10] = 0;
            nullableArray[0x11] = 0;
            nullableArray[0x12] = 0;
            nullableArray[0x13] = 0x85;
            byte?[] nullableArray7 = nullableArray;
            if (ServerControll.RespiroInfinito)
            {
                //int num5 = smethod_80(0x400000, serverControll_0, nullableArray7, 1, 0x480000) + 7;
                int num5 = smethod_80(1, nullableArray7, 0x400000, serverControll_0, 0x480000) + 7;
                WriteProcessMemory_1((IntPtr) (-1), (IntPtr) num5, buffer, (IntPtr) buffer.Length, out num);
            }
        }

        /* private scope */ internal static string[] smethod_52(ServerControll serverControll_0, Entity entity_0)
        {
            if (System.IO.File.Exists(ServerControll.DirConfLocal + ServerControll.FileXlrStats))
            {
                string[] strArray2 = System.IO.File.ReadAllLines(ServerControll.DirConfLocal + ServerControll.FileXlrStats);
                for (int i = 0; i < strArray2.Length; i++)
                {
                    if (strArray2[i].StartsWith(serverControll_0.getPlayerGuid(entity_0)))
                    {
                        return strArray2[i].Split(new char[] { ServerControll.sep5 });
                    }
                }
            }
            return null;
        }

        /* private scope */ internal static void smethod_53(ServerControll serverControll_0)
        {
            string[] strArray = ServerControll.executionPath.Split(new char[] { '\\' });
            string str = "";
            int length = strArray.Length;
            length = --length;
            for (int i = 0; i < length; i++)
            {
                str = str + '\\' + strArray[i];
            }
            int num3 = str.Length - 1;
            ServerControll.primarydir = str.Substring(1, num3);
        }

        /* private scope */ internal static byte[] smethod_54(byte[] byte_0)
        {
            Assembly callingAssembly = Assembly.GetCallingAssembly();
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            if ((callingAssembly != executingAssembly) && !smethod_88(callingAssembly, executingAssembly))
            {
                return null;
            }
            Class75.Stream0 stream = new Class75.Stream0(byte_0);
            byte[] buffer = new byte[0];
            int num = smethod_47(stream);
            if (num == 0x4034b50)
            {
                short num2 = (short) smethod_109(stream);
                int num3 = smethod_109(stream);
                int num4 = smethod_109(stream);
                if ((((num != 0x4034b50) || (num2 != 20)) || (num3 != 0)) || (num4 != 8))
                {
                    throw new FormatException("Wrong Header Signature");
                }
                smethod_47(stream);
                smethod_47(stream);
                smethod_47(stream);
                int num5 = smethod_47(stream);
                int count = smethod_109(stream);
                int num7 = smethod_109(stream);
                if (count > 0)
                {
                    byte[] buffer2 = new byte[count];
                    stream.Read(buffer2, 0, count);
                }
                if (num7 > 0)
                {
                    byte[] buffer3 = new byte[num7];
                    stream.Read(buffer3, 0, num7);
                }
                byte[] buffer4 = new byte[stream.Length - stream.Position];
                stream.Read(buffer4, 0, buffer4.Length);
                Class75.Class76 class2 = new Class75.Class76(buffer4);
                buffer = new byte[num5];
                smethod_46(buffer, buffer.Length, class2, 0);
                buffer4 = null;
            }
            else
            {
                int num8 = num >> 0x18;
                num -= num8 << 0x18;
                if (num == 0x7d7a7b)
                {
                    switch (num8)
                    {
                        case 1:
                        {
                            int num12;
                            int num9 = smethod_47(stream);
                            buffer = new byte[num9];
                            for (int i = 0; i < num9; i += num12)
                            {
                                int num11 = smethod_47(stream);
                                num12 = smethod_47(stream);
                                byte[] buffer5 = new byte[num11];
                                stream.Read(buffer5, 0, buffer5.Length);
                                Class75.Class76 class3 = new Class75.Class76(buffer5);
                                smethod_46(buffer, num12, class3, i);
                            }
                            break;
                        }
                        case 2:
                        {
                            byte[] buffer6 = new byte[] { 0xe0, 0x6b, 0x52, 80, 0x13, 120, 0xd8, 0xc0 };
                            byte[] buffer7 = new byte[] { 0xea, 0x9c, 0xf5, 0x59, 0x7d, 0x1a, 0xbc, 0x20 };
                            using (Class74 class4 = new Class74())
                            {
                                using (ICryptoTransform transform = smethod_142(buffer7, class4, true, buffer6))
                                {
                                    buffer = smethod_54(transform.TransformFinalBlock(byte_0, 4, byte_0.Length - 4));
                                }
                            }
                            break;
                        }
                    }
                    if (num8 != 3)
                    {
                        goto Label_02A7;
                    }
                    byte[] buffer9 = new byte[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                    byte[] buffer10 = new byte[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
                    using (Class73 class5 = new Class73())
                    {
                        using (ICryptoTransform transform2 = smethod_111(true, buffer10, class5, buffer9))
                        {
                            buffer = smethod_54(transform2.TransformFinalBlock(byte_0, 4, byte_0.Length - 4));
                        }
                        goto Label_02A7;
                    }
                }
                throw new FormatException("Unknown Header");
            }
        Label_02A7:
            stream.Close();
            stream = null;
            return buffer;
        }

        /* private scope */ internal static void smethod_55(Class75.Class77 class77_0, int int_0)
        {
            class77_0.uint_0 = class77_0.uint_0 >> int_0;
            class77_0.int_2 -= int_0;
        }

        /* private scope */ internal static void smethod_56(Entity entity_0, ServerControll serverControll_0)
        {
            ServerControll.Class1 class3 = new ServerControll.Class1 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                if (System.IO.File.Exists(ServerControll.DirTempFile + ServerControll.FileLastExit))
                {
                    ServerControll.Class2 class2 = new ServerControll.Class2 {
                        class1_0 = class3,
                        string_0 = System.IO.File.ReadAllLines(ServerControll.DirTempFile + ServerControll.FileLastExit),
                        int_0 = 0
                    };
                    smethod_125(serverControll_0, class3.entity_0, "^7List^5[^7" + class2.string_0.Length + "^5] ^7Player Last Exit:^5");
                    serverControll_0.OnInterval(0x3e8, new Func<bool>(class2.method_0));
                }
                else
                {
                    smethod_125(serverControll_0, class3.entity_0, "^7No Player Found!");
                }
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "ListExit");
            }
        }

        /* private scope */ internal static void smethod_57(Exception exception_0, ServerControll serverControll_0, string string_0)
        {
            try
            {
                string str = string.Concat(new object[] { "LogError_", DateTime.Now.Day, ".", DateTime.Now.Month, ".", DateTime.Now.Year, ".txt" });
                string str2 = "";
                using (StreamWriter writer = new StreamWriter(ServerControll.DirLogErrori + str, true))
                {
                    writer.WriteLine(string.Concat(new object[] { "Date: ", DateTime.Now.Day, ".", DateTime.Now.Month, ".", DateTime.Now.Year }));
                    writer.WriteLine(string.Concat(new object[] { "Time: ", DateTime.Now.Hour, ":", DateTime.Now.Minute, ":", DateTime.Now.Second }));
                    writer.WriteLine("Map: " + ServerControll.MapName);
                    writer.WriteLine("MapType: " + ServerControll.TypeMap);
                    writer.WriteLine("Mod: " + ServerControll.string_0);
                    writer.WriteLine("Nr. Player: " + ServerControll.Giocatori.Count);
                    for (int i = 0; i < ServerControll.Giocatori.Count; i++)
                    {
                        str2 = str2 + ServerControll.sep1 + ServerControll.Giocatori[i].Name;
                    }
                    writer.WriteLine("Player: " + str2.TrimStart(new char[] { ServerControll.sep1 }));
                    writer.WriteLine("Version: " + ServerControll.version);
                    writer.WriteLine("Function: " + string_0);
                    writer.WriteLine("Target: " + exception_0.TargetSite);
                    writer.WriteLine("Message: " + exception_0.Message);
                    writer.WriteLine("==================================================================================================================");
                    writer.Close();
                }
            }
            catch (Exception exception)
            {
                smethod_33(serverControll_0, "Error LogErrori => " + exception.Message, new object[0]);
            }
        }

        /* private scope */ internal static void smethod_58(ServerControll serverControll_0)
        {
            serverControll_0.AfterDelay(0xbb8, new Action(serverControll_0.method_52));
        }

        /* private scope */ internal static void smethod_59(string string_0, ServerControll serverControll_0, bool bool_0, Entity entity_0)
        {
            for (int i = 0; i < ServerControll.WeaponSniper.Length; i++)
            {
                if (string_0.Contains(ServerControll.WeaponSniper[i]))
                {
                    string[] strArray = ServerControll.WeaponSniper[i].Split(new char[] { '_' });
                    string_0 = ServerControll.WeaponSniper[i] + "_mp_" + strArray[1] + "scope";
                }
            }
            if (bool_0)
            {
                entity_0.TakeAllWeapons();
            }
            entity_0.GiveWeapon(string_0);
            entity_0.Call("giveMaxAmmo", new Parameter[] { string_0 });
            entity_0.SwitchToWeaponImmediate(string_0);
        }

        /* private scope */ internal static int smethod_6(byte byte_0)
        {
            return (byte_0 & 0xff);
        }

        /* private scope */ internal static void smethod_60(ServerControll serverControll_0)
        {
            try
            {
                serverControll_0.Call("setdvar", new Parameter[] { "bg_weaponBobMax", "0" });
                serverControll_0.Call("setdvar", new Parameter[] { "bg_viewBobMax", "0" });
                serverControll_0.Call("setdvar", new Parameter[] { "bg_viewBobAmplitudeStandingAds", "0 0" });
                serverControll_0.Call("setdvar", new Parameter[] { "bg_viewBobAmplitudeSprinting", "0 0" });
                serverControll_0.Call("setdvar", new Parameter[] { "bg_viewBobAmplitudeDucked", "0 0" });
                serverControll_0.Call("setdvar", new Parameter[] { "bg_viewBobAmplitudeDuckedAds", "0 0" });
                serverControll_0.Call("setdvar", new Parameter[] { "bg_viewBobAmplitudeProne", "0 0" });
                serverControll_0.Call("setdvar", new Parameter[] { "scr_team_teamkillpointloss", "1" });
                serverControll_0.Call("setdvar", new Parameter[] { "g_knockback", "0" });
                serverControll_0.Call("setdvar", new Parameter[] { "bg_viewKickRandom", "0.2" });
                serverControll_0.Call("setdvar", new Parameter[] { "bg_viewKickMin", "1" });
                serverControll_0.Call("setdvar", new Parameter[] { "bg_viewKickScale", "0.15" });
                serverControll_0.Call("setdvar", new Parameter[] { "bg_viewKickMax", "75" });
                serverControll_0.Call("setdvar", new Parameter[] { "glass_DamageToDestroy", "50" });
                serverControll_0.Call("setdvar", new Parameter[] { "g_playerCollisionEjectSpeed", "15" });
                serverControll_0.Call("setdvar", new Parameter[] { "sv_network_fps", "100" });
                serverControll_0.Call("setdvar", new Parameter[] { "g_earthquakeenable", "0" });
                serverControll_0.Call("setdvar", new Parameter[] { "scr_showperksonspawn", "0" });
                serverControll_0.Call("setdvar", new Parameter[] { "scr_sd_score_kill", "100" });
                serverControll_0.Call("setdvar", new Parameter[] { "scr_sd_score_headshot", "150" });
                serverControll_0.Call("setdvar", new Parameter[] { "scr_sd_score_assist", "20" });
                serverControll_0.Call("setdvar", new Parameter[] { "scr_sd_score_plant", "50" });
                serverControll_0.Call("setdvar", new Parameter[] { "scr_sd_score_defuse", "50" });
                serverControll_0.Call("setdvar", new Parameter[] { "scr_sd_score_teamkill", "50" });
                serverControll_0.Call("setdvar", new Parameter[] { "scr_sd_score_capture", "50" });
                serverControll_0.Call("setdvar", new Parameter[] { "scr_sd_score_defend", "50" });
                serverControll_0.Call("setdvar", new Parameter[] { "scr_sd_score_defend_assist", "20" });
                serverControll_0.Call("setdvar", new Parameter[] { "scr_sd_score_assault", "50" });
                serverControll_0.Call("setdvar", new Parameter[] { "scr_sd_score_assault_assist", "20" });
                serverControll_0.Call("setdvar", new Parameter[] { "ui_hud_showdeathicons", "0" });
                serverControll_0.Call("setdvar", new Parameter[] { "perk_sprintMultiplier", "1.25" });
                serverControll_0.Call("setdvar", new Parameter[] { "perk_bulletPenetrationMultiplier", "1.6" });
                serverControll_0.Call("setdvar", new Parameter[] { "perk_quickDrawSpeedScale", "1.1" });
                serverControll_0.Call("setdvar", new Parameter[] { "player_throwBackInnerRadius", "0" });
                serverControll_0.Call("setdvar", new Parameter[] { "player_throwBackOuterRadius", "0" });
                if (ServerControll.action_0 == null)
                {
                    ServerControll.action_0 = new Action(ServerControll.smethod_0);
                }
                serverControll_0.AfterDelay(0x3e8, ServerControll.action_0);
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "AvvModPromod");
            }
        }

        /* private scope */ internal static int smethod_61(Class75.Class78 class78_0, Class75.Class77 class77_0, int int_0)
        {
            int num;
            int_0 = Math.Min(Math.Min(int_0, 0x8000 - class78_0.int_1), smethod_87(class77_0));
            int num2 = 0x8000 - class78_0.int_0;
            if (int_0 > num2)
            {
                num = smethod_140(class77_0, class78_0.byte_0, class78_0.int_0, num2);
                if (num == num2)
                {
                    num += smethod_140(class77_0, class78_0.byte_0, 0, int_0 - num2);
                }
            }
            else
            {
                num = smethod_140(class77_0, class78_0.byte_0, class78_0.int_0, int_0);
            }
            class78_0.int_0 = (class78_0.int_0 + num) & 0x7fff;
            class78_0.int_1 += num;
            return num;
        }

        /* private scope */ internal static void smethod_62(ServerControll serverControll_0, Entity entity_0)
        {
            if (ServerControll.ControllGrafica)
            {
                if (ServerControll.func_1 == null)
                {
                    ServerControll.func_1 = new Func<Entity, bool>(ServerControll.smethod_5);
                }
                entity_0.OnInterval(0x1388, ServerControll.func_1);
            }
        }

        /* private scope */ internal static void smethod_63(ServerControll serverControll_0, Entity entity_0)
        {
            Action function = null;
            Action action2 = null;
            ServerControll.Class64 class2 = new ServerControll.Class64 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                if (ServerControll.stato_passSS)
                {
                    if (serverControll_0.getPlayerLevel(class2.entity_0) > 1)
                    {
                        if (function == null)
                        {
                            function = new Action(class2.method_0);
                        }
                        serverControll_0.AfterDelay(0xbb8, function);
                        if (!serverControll_0.IsUserSession(class2.entity_0))
                        {
                            smethod_151(serverControll_0, class2.entity_0);
                        }
                    }
                    else if (serverControll_0.IsUserSession(class2.entity_0))
                    {
                        if (action2 == null)
                        {
                            action2 = new Action(class2.method_1);
                        }
                        serverControll_0.AfterDelay(0xbb8, action2);
                    }
                    else
                    {
                        smethod_76(serverControll_0, class2.entity_0);
                    }
                }
                else if (!serverControll_0.IsUserSession(class2.entity_0))
                {
                    smethod_151(serverControll_0, class2.entity_0);
                }
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "ControlloRichPassword");
            }
        }

        /* private scope */ internal static void smethod_64()
        {
            RegionName.hashtable_0 = new Hashtable();
            Hashtable hashtable = new Hashtable();
            hashtable.Add("02", "Canillo");
            hashtable.Add("03", "Encamp");
            hashtable.Add("04", "La Massana");
            hashtable.Add("05", "Ordino");
            hashtable.Add("06", "Sant Julia de Loria");
            hashtable.Add("07", "Andorra la Vella");
            hashtable.Add("08", "Escaldes-Engordany");
            RegionName.hashtable_0.Add("AD", hashtable);
            Hashtable hashtable2 = new Hashtable();
            hashtable2.Add("01", "Abu Dhabi");
            hashtable2.Add("02", "Ajman");
            hashtable2.Add("03", "Dubai");
            hashtable2.Add("04", "Fujairah");
            hashtable2.Add("05", "Ras Al Khaimah");
            hashtable2.Add("06", "Sharjah");
            hashtable2.Add("07", "Umm Al Quwain");
            RegionName.hashtable_0.Add("AE", hashtable2);
            Hashtable hashtable3 = new Hashtable();
            hashtable3.Add("01", "Badakhshan");
            hashtable3.Add("02", "Badghis");
            hashtable3.Add("03", "Baghlan");
            hashtable3.Add("05", "Bamian");
            hashtable3.Add("06", "Farah");
            hashtable3.Add("07", "Faryab");
            hashtable3.Add("08", "Ghazni");
            hashtable3.Add("09", "Ghowr");
            hashtable3.Add("10", "Helmand");
            hashtable3.Add("11", "Herat");
            hashtable3.Add("13", "Kabol");
            hashtable3.Add("14", "Kapisa");
            hashtable3.Add("17", "Lowgar");
            hashtable3.Add("18", "Nangarhar");
            hashtable3.Add("19", "Nimruz");
            hashtable3.Add("23", "Kandahar");
            hashtable3.Add("24", "Kondoz");
            hashtable3.Add("26", "Takhar");
            hashtable3.Add("27", "Vardak");
            hashtable3.Add("28", "Zabol");
            hashtable3.Add("29", "Paktika");
            hashtable3.Add("30", "Balkh");
            hashtable3.Add("31", "Jowzjan");
            hashtable3.Add("32", "Samangan");
            hashtable3.Add("33", "Sar-e Pol");
            hashtable3.Add("34", "Konar");
            hashtable3.Add("35", "Laghman");
            hashtable3.Add("36", "Paktia");
            hashtable3.Add("37", "Khowst");
            hashtable3.Add("38", "Nurestan");
            hashtable3.Add("39", "Oruzgan");
            hashtable3.Add("40", "Parvan");
            hashtable3.Add("41", "Daykondi");
            hashtable3.Add("42", "Panjshir");
            RegionName.hashtable_0.Add("AF", hashtable3);
            Hashtable hashtable4 = new Hashtable();
            hashtable4.Add("01", "Barbuda");
            hashtable4.Add("03", "Saint George");
            hashtable4.Add("04", "Saint John");
            hashtable4.Add("05", "Saint Mary");
            hashtable4.Add("06", "Saint Paul");
            hashtable4.Add("07", "Saint Peter");
            hashtable4.Add("08", "Saint Philip");
            hashtable4.Add("09", "Redonda");
            RegionName.hashtable_0.Add("AG", hashtable4);
            Hashtable hashtable5 = new Hashtable();
            hashtable5.Add("40", "Berat");
            hashtable5.Add("41", "Diber");
            hashtable5.Add("42", "Durres");
            hashtable5.Add("43", "Elbasan");
            hashtable5.Add("44", "Fier");
            hashtable5.Add("45", "Gjirokaster");
            hashtable5.Add("46", "Korce");
            hashtable5.Add("47", "Kukes");
            hashtable5.Add("48", "Lezhe");
            hashtable5.Add("49", "Shkoder");
            hashtable5.Add("50", "Tirane");
            hashtable5.Add("51", "Vlore");
            RegionName.hashtable_0.Add("AL", hashtable5);
            Hashtable hashtable6 = new Hashtable();
            hashtable6.Add("01", "Aragatsotn");
            hashtable6.Add("02", "Ararat");
            hashtable6.Add("03", "Armavir");
            hashtable6.Add("04", "Geghark'unik'");
            hashtable6.Add("05", "Kotayk'");
            hashtable6.Add("06", "Lorri");
            hashtable6.Add("07", "Shirak");
            hashtable6.Add("08", "Syunik'");
            hashtable6.Add("09", "Tavush");
            hashtable6.Add("10", "Vayots' Dzor");
            hashtable6.Add("11", "Yerevan");
            RegionName.hashtable_0.Add("AM", hashtable6);
            Hashtable hashtable7 = new Hashtable();
            hashtable7.Add("01", "Benguela");
            hashtable7.Add("02", "Bie");
            hashtable7.Add("03", "Cabinda");
            hashtable7.Add("04", "Cuando Cubango");
            hashtable7.Add("05", "Cuanza Norte");
            hashtable7.Add("06", "Cuanza Sul");
            hashtable7.Add("07", "Cunene");
            hashtable7.Add("08", "Huambo");
            hashtable7.Add("09", "Huila");
            hashtable7.Add("12", "Malanje");
            hashtable7.Add("13", "Namibe");
            hashtable7.Add("14", "Moxico");
            hashtable7.Add("15", "Uige");
            hashtable7.Add("16", "Zaire");
            hashtable7.Add("17", "Lunda Norte");
            hashtable7.Add("18", "Lunda Sul");
            hashtable7.Add("19", "Bengo");
            hashtable7.Add("20", "Luanda");
            RegionName.hashtable_0.Add("AO", hashtable7);
            Hashtable hashtable8 = new Hashtable();
            hashtable8.Add("01", "Buenos Aires");
            hashtable8.Add("02", "Catamarca");
            hashtable8.Add("03", "Chaco");
            hashtable8.Add("04", "Chubut");
            hashtable8.Add("05", "Cordoba");
            hashtable8.Add("06", "Corrientes");
            hashtable8.Add("07", "Distrito Federal");
            hashtable8.Add("08", "Entre Rios");
            hashtable8.Add("09", "Formosa");
            hashtable8.Add("10", "Jujuy");
            hashtable8.Add("11", "La Pampa");
            hashtable8.Add("12", "La Rioja");
            hashtable8.Add("13", "Mendoza");
            hashtable8.Add("14", "Misiones");
            hashtable8.Add("15", "Neuquen");
            hashtable8.Add("16", "Rio Negro");
            hashtable8.Add("17", "Salta");
            hashtable8.Add("18", "San Juan");
            hashtable8.Add("19", "San Luis");
            hashtable8.Add("20", "Santa Cruz");
            hashtable8.Add("21", "Santa Fe");
            hashtable8.Add("22", "Santiago del Estero");
            hashtable8.Add("23", "Tierra del Fuego");
            hashtable8.Add("24", "Tucuman");
            RegionName.hashtable_0.Add("AR", hashtable8);
            Hashtable hashtable9 = new Hashtable();
            hashtable9.Add("01", "Burgenland");
            hashtable9.Add("02", "Karnten");
            hashtable9.Add("03", "Niederosterreich");
            hashtable9.Add("04", "Oberosterreich");
            hashtable9.Add("05", "Salzburg");
            hashtable9.Add("06", "Steiermark");
            hashtable9.Add("07", "Tirol");
            hashtable9.Add("08", "Vorarlberg");
            hashtable9.Add("09", "Wien");
            RegionName.hashtable_0.Add("AT", hashtable9);
            Hashtable hashtable10 = new Hashtable();
            hashtable10.Add("01", "Australian Capital Territory");
            hashtable10.Add("02", "New South Wales");
            hashtable10.Add("03", "Northern Territory");
            hashtable10.Add("04", "Queensland");
            hashtable10.Add("05", "South Australia");
            hashtable10.Add("06", "Tasmania");
            hashtable10.Add("07", "Victoria");
            hashtable10.Add("08", "Western Australia");
            RegionName.hashtable_0.Add("AU", hashtable10);
            Hashtable hashtable11 = new Hashtable();
            hashtable11.Add("01", "Abseron");
            hashtable11.Add("02", "Agcabadi");
            hashtable11.Add("03", "Agdam");
            hashtable11.Add("04", "Agdas");
            hashtable11.Add("05", "Agstafa");
            hashtable11.Add("06", "Agsu");
            hashtable11.Add("07", "Ali Bayramli");
            hashtable11.Add("08", "Astara");
            hashtable11.Add("09", "Baki");
            hashtable11.Add("10", "Balakan");
            hashtable11.Add("11", "Barda");
            hashtable11.Add("12", "Beylaqan");
            hashtable11.Add("13", "Bilasuvar");
            hashtable11.Add("14", "Cabrayil");
            hashtable11.Add("15", "Calilabad");
            hashtable11.Add("16", "Daskasan");
            hashtable11.Add("17", "Davaci");
            hashtable11.Add("18", "Fuzuli");
            hashtable11.Add("19", "Gadabay");
            hashtable11.Add("20", "Ganca");
            hashtable11.Add("21", "Goranboy");
            hashtable11.Add("22", "Goycay");
            hashtable11.Add("23", "Haciqabul");
            hashtable11.Add("24", "Imisli");
            hashtable11.Add("25", "Ismayilli");
            hashtable11.Add("26", "Kalbacar");
            hashtable11.Add("27", "Kurdamir");
            hashtable11.Add("28", "Lacin");
            hashtable11.Add("29", "Lankaran");
            hashtable11.Add("30", "Lankaran");
            hashtable11.Add("31", "Lerik");
            hashtable11.Add("32", "Masalli");
            hashtable11.Add("33", "Mingacevir");
            hashtable11.Add("34", "Naftalan");
            hashtable11.Add("35", "Naxcivan");
            hashtable11.Add("36", "Neftcala");
            hashtable11.Add("37", "Oguz");
            hashtable11.Add("38", "Qabala");
            hashtable11.Add("39", "Qax");
            hashtable11.Add("40", "Qazax");
            hashtable11.Add("41", "Qobustan");
            hashtable11.Add("42", "Quba");
            hashtable11.Add("43", "Qubadli");
            hashtable11.Add("44", "Qusar");
            hashtable11.Add("45", "Saatli");
            hashtable11.Add("46", "Sabirabad");
            hashtable11.Add("47", "Saki");
            hashtable11.Add("48", "Saki");
            hashtable11.Add("49", "Salyan");
            hashtable11.Add("50", "Samaxi");
            hashtable11.Add("51", "Samkir");
            hashtable11.Add("52", "Samux");
            hashtable11.Add("53", "Siyazan");
            hashtable11.Add("54", "Sumqayit");
            hashtable11.Add("55", "Susa");
            hashtable11.Add("56", "Susa");
            hashtable11.Add("57", "Tartar");
            hashtable11.Add("58", "Tovuz");
            hashtable11.Add("59", "Ucar");
            hashtable11.Add("60", "Xacmaz");
            hashtable11.Add("61", "Xankandi");
            hashtable11.Add("62", "Xanlar");
            hashtable11.Add("63", "Xizi");
            hashtable11.Add("64", "Xocali");
            hashtable11.Add("65", "Xocavand");
            hashtable11.Add("66", "Yardimli");
            hashtable11.Add("67", "Yevlax");
            hashtable11.Add("68", "Yevlax");
            hashtable11.Add("69", "Zangilan");
            hashtable11.Add("70", "Zaqatala");
            hashtable11.Add("71", "Zardab");
            RegionName.hashtable_0.Add("AZ", hashtable11);
            Hashtable hashtable12 = new Hashtable();
            hashtable12.Add("01", "Federation of Bosnia and Herzegovina");
            hashtable12.Add("02", "Republika Srpska");
            RegionName.hashtable_0.Add("BA", hashtable12);
            Hashtable hashtable13 = new Hashtable();
            hashtable13.Add("01", "Christ Church");
            hashtable13.Add("02", "Saint Andrew");
            hashtable13.Add("03", "Saint George");
            hashtable13.Add("04", "Saint James");
            hashtable13.Add("05", "Saint John");
            hashtable13.Add("06", "Saint Joseph");
            hashtable13.Add("07", "Saint Lucy");
            hashtable13.Add("08", "Saint Michael");
            hashtable13.Add("09", "Saint Peter");
            hashtable13.Add("10", "Saint Philip");
            hashtable13.Add("11", "Saint Thomas");
            RegionName.hashtable_0.Add("BB", hashtable13);
            Hashtable hashtable14 = new Hashtable();
            hashtable14.Add("81", "Dhaka");
            hashtable14.Add("82", "Khulna");
            hashtable14.Add("83", "Rajshahi");
            hashtable14.Add("84", "Chittagong");
            hashtable14.Add("85", "Barisal");
            hashtable14.Add("86", "Sylhet");
            RegionName.hashtable_0.Add("BD", hashtable14);
            Hashtable hashtable15 = new Hashtable();
            hashtable15.Add("01", "Antwerpen");
            hashtable15.Add("03", "Hainaut");
            hashtable15.Add("04", "Liege");
            hashtable15.Add("05", "Limburg");
            hashtable15.Add("06", "Luxembourg");
            hashtable15.Add("07", "Namur");
            hashtable15.Add("08", "Oost-Vlaanderen");
            hashtable15.Add("09", "West-Vlaanderen");
            hashtable15.Add("10", "Brabant Wallon");
            hashtable15.Add("11", "Brussels Hoofdstedelijk Gewest");
            hashtable15.Add("12", "Vlaams-Brabant");
            hashtable15.Add("13", "Flanders");
            hashtable15.Add("14", "Wallonia");
            RegionName.hashtable_0.Add("BE", hashtable15);
            Hashtable hashtable16 = new Hashtable();
            hashtable16.Add("15", "Bam");
            hashtable16.Add("19", "Boulkiemde");
            hashtable16.Add("20", "Ganzourgou");
            hashtable16.Add("21", "Gnagna");
            hashtable16.Add("28", "Kouritenga");
            hashtable16.Add("33", "Oudalan");
            hashtable16.Add("34", "Passore");
            hashtable16.Add("36", "Sanguie");
            hashtable16.Add("40", "Soum");
            hashtable16.Add("42", "Tapoa");
            hashtable16.Add("44", "Zoundweogo");
            hashtable16.Add("45", "Bale");
            hashtable16.Add("46", "Banwa");
            hashtable16.Add("47", "Bazega");
            hashtable16.Add("48", "Bougouriba");
            hashtable16.Add("49", "Boulgou");
            hashtable16.Add("50", "Gourma");
            hashtable16.Add("51", "Houet");
            hashtable16.Add("52", "Ioba");
            hashtable16.Add("53", "Kadiogo");
            hashtable16.Add("54", "Kenedougou");
            hashtable16.Add("55", "Komoe");
            hashtable16.Add("56", "Komondjari");
            hashtable16.Add("57", "Kompienga");
            hashtable16.Add("58", "Kossi");
            hashtable16.Add("59", "Koulpelogo");
            hashtable16.Add("60", "Kourweogo");
            hashtable16.Add("61", "Leraba");
            hashtable16.Add("62", "Loroum");
            hashtable16.Add("63", "Mouhoun");
            hashtable16.Add("64", "Namentenga");
            hashtable16.Add("65", "Naouri");
            hashtable16.Add("66", "Nayala");
            hashtable16.Add("67", "Noumbiel");
            hashtable16.Add("68", "Oubritenga");
            hashtable16.Add("69", "Poni");
            hashtable16.Add("70", "Sanmatenga");
            hashtable16.Add("71", "Seno");
            hashtable16.Add("72", "Sissili");
            hashtable16.Add("73", "Sourou");
            hashtable16.Add("74", "Tuy");
            hashtable16.Add("75", "Yagha");
            hashtable16.Add("76", "Yatenga");
            hashtable16.Add("77", "Ziro");
            hashtable16.Add("78", "Zondoma");
            RegionName.hashtable_0.Add("BF", hashtable16);
            Hashtable hashtable17 = new Hashtable();
            hashtable17.Add("33", "Mikhaylovgrad");
            hashtable17.Add("38", "Blagoevgrad");
            hashtable17.Add("39", "Burgas");
            hashtable17.Add("40", "Dobrich");
            hashtable17.Add("41", "Gabrovo");
            hashtable17.Add("42", "Grad Sofiya");
            hashtable17.Add("43", "Khaskovo");
            hashtable17.Add("44", "Kurdzhali");
            hashtable17.Add("45", "Kyustendil");
            hashtable17.Add("46", "Lovech");
            hashtable17.Add("47", "Montana");
            hashtable17.Add("48", "Pazardzhik");
            hashtable17.Add("49", "Pernik");
            hashtable17.Add("50", "Pleven");
            hashtable17.Add("51", "Plovdiv");
            hashtable17.Add("52", "Razgrad");
            hashtable17.Add("53", "Ruse");
            hashtable17.Add("54", "Shumen");
            hashtable17.Add("55", "Silistra");
            hashtable17.Add("56", "Sliven");
            hashtable17.Add("57", "Smolyan");
            hashtable17.Add("58", "Sofiya");
            hashtable17.Add("59", "Stara Zagora");
            hashtable17.Add("60", "Turgovishte");
            hashtable17.Add("61", "Varna");
            hashtable17.Add("62", "Veliko Turnovo");
            hashtable17.Add("63", "Vidin");
            hashtable17.Add("64", "Vratsa");
            hashtable17.Add("65", "Yambol");
            RegionName.hashtable_0.Add("BG", hashtable17);
            Hashtable hashtable18 = new Hashtable();
            hashtable18.Add("01", "Al Hadd");
            hashtable18.Add("02", "Al Manamah");
            hashtable18.Add("05", "Jidd Hafs");
            hashtable18.Add("06", "Sitrah");
            hashtable18.Add("08", "Al Mintaqah al Gharbiyah");
            hashtable18.Add("09", "Mintaqat Juzur Hawar");
            hashtable18.Add("10", "Al Mintaqah ash Shamaliyah");
            hashtable18.Add("11", "Al Mintaqah al Wusta");
            hashtable18.Add("12", "Madinat");
            hashtable18.Add("13", "Ar Rifa");
            hashtable18.Add("14", "Madinat Hamad");
            hashtable18.Add("15", "Al Muharraq");
            hashtable18.Add("16", "Al Asimah");
            hashtable18.Add("17", "Al Janubiyah");
            hashtable18.Add("18", "Ash Shamaliyah");
            hashtable18.Add("19", "Al Wusta");
            RegionName.hashtable_0.Add("BH", hashtable18);
            Hashtable hashtable19 = new Hashtable();
            hashtable19.Add("02", "Bujumbura");
            hashtable19.Add("09", "Bubanza");
            hashtable19.Add("10", "Bururi");
            hashtable19.Add("11", "Cankuzo");
            hashtable19.Add("12", "Cibitoke");
            hashtable19.Add("13", "Gitega");
            hashtable19.Add("14", "Karuzi");
            hashtable19.Add("15", "Kayanza");
            hashtable19.Add("16", "Kirundo");
            hashtable19.Add("17", "Makamba");
            hashtable19.Add("18", "Muyinga");
            hashtable19.Add("19", "Ngozi");
            hashtable19.Add("20", "Rutana");
            hashtable19.Add("21", "Ruyigi");
            hashtable19.Add("22", "Muramvya");
            hashtable19.Add("23", "Mwaro");
            RegionName.hashtable_0.Add("BI", hashtable19);
            Hashtable hashtable20 = new Hashtable();
            hashtable20.Add("07", "Alibori");
            hashtable20.Add("08", "Atakora");
            hashtable20.Add("09", "Atlanyique");
            hashtable20.Add("10", "Borgou");
            hashtable20.Add("11", "Collines");
            hashtable20.Add("12", "Kouffo");
            hashtable20.Add("13", "Donga");
            hashtable20.Add("14", "Littoral");
            hashtable20.Add("15", "Mono");
            hashtable20.Add("16", "Oueme");
            hashtable20.Add("17", "Plateau");
            hashtable20.Add("18", "Zou");
            RegionName.hashtable_0.Add("BJ", hashtable20);
            Hashtable hashtable21 = new Hashtable();
            hashtable21.Add("01", "Devonshire");
            hashtable21.Add("02", "Hamilton");
            hashtable21.Add("03", "Hamilton");
            hashtable21.Add("04", "Paget");
            hashtable21.Add("05", "Pembroke");
            hashtable21.Add("06", "Saint George");
            hashtable21.Add("07", "Saint George's");
            hashtable21.Add("08", "Sandys");
            hashtable21.Add("09", "Smiths");
            hashtable21.Add("10", "Southampton");
            hashtable21.Add("11", "Warwick");
            RegionName.hashtable_0.Add("BM", hashtable21);
            Hashtable hashtable22 = new Hashtable();
            hashtable22.Add("07", "Alibori");
            hashtable22.Add("08", "Belait");
            hashtable22.Add("09", "Brunei and Muara");
            hashtable22.Add("10", "Temburong");
            hashtable22.Add("11", "Collines");
            hashtable22.Add("12", "Kouffo");
            hashtable22.Add("13", "Donga");
            hashtable22.Add("14", "Littoral");
            hashtable22.Add("15", "Tutong");
            hashtable22.Add("16", "Oueme");
            hashtable22.Add("17", "Plateau");
            hashtable22.Add("18", "Zou");
            RegionName.hashtable_0.Add("BN", hashtable22);
            Hashtable hashtable23 = new Hashtable();
            hashtable23.Add("01", "Chuquisaca");
            hashtable23.Add("02", "Cochabamba");
            hashtable23.Add("03", "El Beni");
            hashtable23.Add("04", "La Paz");
            hashtable23.Add("05", "Oruro");
            hashtable23.Add("06", "Pando");
            hashtable23.Add("07", "Potosi");
            hashtable23.Add("08", "Santa Cruz");
            hashtable23.Add("09", "Tarija");
            RegionName.hashtable_0.Add("BO", hashtable23);
            Hashtable hashtable24 = new Hashtable();
            hashtable24.Add("01", "Acre");
            hashtable24.Add("02", "Alagoas");
            hashtable24.Add("03", "Amapa");
            hashtable24.Add("04", "Amazonas");
            hashtable24.Add("05", "Bahia");
            hashtable24.Add("06", "Ceara");
            hashtable24.Add("07", "Distrito Federal");
            hashtable24.Add("08", "Espirito Santo");
            hashtable24.Add("11", "Mato Grosso do Sul");
            hashtable24.Add("13", "Maranhao");
            hashtable24.Add("14", "Mato Grosso");
            hashtable24.Add("15", "Minas Gerais");
            hashtable24.Add("16", "Para");
            hashtable24.Add("17", "Paraiba");
            hashtable24.Add("18", "Parana");
            hashtable24.Add("20", "Piaui");
            hashtable24.Add("21", "Rio de Janeiro");
            hashtable24.Add("22", "Rio Grande do Norte");
            hashtable24.Add("23", "Rio Grande do Sul");
            hashtable24.Add("24", "Rondonia");
            hashtable24.Add("25", "Roraima");
            hashtable24.Add("26", "Santa Catarina");
            hashtable24.Add("27", "Sao Paulo");
            hashtable24.Add("28", "Sergipe");
            hashtable24.Add("29", "Goias");
            hashtable24.Add("30", "Pernambuco");
            hashtable24.Add("31", "Tocantins");
            RegionName.hashtable_0.Add("BR", hashtable24);
            Hashtable hashtable25 = new Hashtable();
            hashtable25.Add("05", "Bimini");
            hashtable25.Add("06", "Cat Island");
            hashtable25.Add("10", "Exuma");
            hashtable25.Add("13", "Inagua");
            hashtable25.Add("15", "Long Island");
            hashtable25.Add("16", "Mayaguana");
            hashtable25.Add("18", "Ragged Island");
            hashtable25.Add("22", "Harbour Island");
            hashtable25.Add("23", "New Providence");
            hashtable25.Add("24", "Acklins and Crooked Islands");
            hashtable25.Add("25", "Freeport");
            hashtable25.Add("26", "Fresh Creek");
            hashtable25.Add("27", "Governor's Harbour");
            hashtable25.Add("28", "Green Turtle Cay");
            hashtable25.Add("29", "High Rock");
            hashtable25.Add("30", "Kemps Bay");
            hashtable25.Add("31", "Marsh Harbour");
            hashtable25.Add("32", "Nichollstown and Berry Islands");
            hashtable25.Add("33", "Rock Sound");
            hashtable25.Add("34", "Sandy Point");
            hashtable25.Add("35", "San Salvador and Rum Cay");
            RegionName.hashtable_0.Add("BS", hashtable25);
            Hashtable hashtable26 = new Hashtable();
            hashtable26.Add("05", "Bumthang");
            hashtable26.Add("06", "Chhukha");
            hashtable26.Add("07", "Chirang");
            hashtable26.Add("08", "Daga");
            hashtable26.Add("09", "Geylegphug");
            hashtable26.Add("10", "Ha");
            hashtable26.Add("11", "Lhuntshi");
            hashtable26.Add("12", "Mongar");
            hashtable26.Add("13", "Paro");
            hashtable26.Add("14", "Pemagatsel");
            hashtable26.Add("15", "Punakha");
            hashtable26.Add("16", "Samchi");
            hashtable26.Add("17", "Samdrup");
            hashtable26.Add("18", "Shemgang");
            hashtable26.Add("19", "Tashigang");
            hashtable26.Add("20", "Thimphu");
            hashtable26.Add("21", "Tongsa");
            hashtable26.Add("22", "Wangdi Phodrang");
            RegionName.hashtable_0.Add("BT", hashtable26);
            Hashtable hashtable27 = new Hashtable();
            hashtable27.Add("01", "Central");
            hashtable27.Add("03", "Ghanzi");
            hashtable27.Add("04", "Kgalagadi");
            hashtable27.Add("05", "Kgatleng");
            hashtable27.Add("06", "Kweneng");
            hashtable27.Add("08", "North-East");
            hashtable27.Add("09", "South-East");
            hashtable27.Add("10", "Southern");
            hashtable27.Add("11", "North-West");
            RegionName.hashtable_0.Add("BW", hashtable27);
            Hashtable hashtable28 = new Hashtable();
            hashtable28.Add("01", "Brestskaya Voblasts'");
            hashtable28.Add("02", "Homyel'skaya Voblasts'");
            hashtable28.Add("03", "Hrodzyenskaya Voblasts'");
            hashtable28.Add("04", "Minsk");
            hashtable28.Add("05", "Minskaya Voblasts'");
            hashtable28.Add("06", "Mahilyowskaya Voblasts'");
            hashtable28.Add("07", "Vitsyebskaya Voblasts'");
            RegionName.hashtable_0.Add("BY", hashtable28);
            Hashtable hashtable29 = new Hashtable();
            hashtable29.Add("01", "Belize");
            hashtable29.Add("02", "Cayo");
            hashtable29.Add("03", "Corozal");
            hashtable29.Add("04", "Orange Walk");
            hashtable29.Add("05", "Stann Creek");
            hashtable29.Add("06", "Toledo");
            RegionName.hashtable_0.Add("BZ", hashtable29);
            Hashtable hashtable30 = new Hashtable();
            hashtable30.Add("AB", "Alberta");
            hashtable30.Add("BC", "British Columbia");
            hashtable30.Add("MB", "Manitoba");
            hashtable30.Add("NB", "New Brunswick");
            hashtable30.Add("NL", "Newfoundland");
            hashtable30.Add("NS", "Nova Scotia");
            hashtable30.Add("NT", "Northwest Territories");
            hashtable30.Add("NU", "Nunavut");
            hashtable30.Add("ON", "Ontario");
            hashtable30.Add("PE", "Prince Edward Island");
            hashtable30.Add("QC", "Quebec");
            hashtable30.Add("SK", "Saskatchewan");
            hashtable30.Add("YT", "Yukon Territory");
            RegionName.hashtable_0.Add("CA", hashtable30);
            Hashtable hashtable31 = new Hashtable();
            hashtable31.Add("01", "Bandundu");
            hashtable31.Add("02", "Equateur");
            hashtable31.Add("04", "Kasai-Oriental");
            hashtable31.Add("05", "Katanga");
            hashtable31.Add("06", "Kinshasa");
            hashtable31.Add("08", "Bas-Congo");
            hashtable31.Add("09", "Orientale");
            hashtable31.Add("10", "Maniema");
            hashtable31.Add("11", "Nord-Kivu");
            hashtable31.Add("12", "Sud-Kivu");
            RegionName.hashtable_0.Add("CD", hashtable31);
            Hashtable hashtable32 = new Hashtable();
            hashtable32.Add("01", "Bamingui-Bangoran");
            hashtable32.Add("02", "Basse-Kotto");
            hashtable32.Add("03", "Haute-Kotto");
            hashtable32.Add("04", "Mambere-Kadei");
            hashtable32.Add("05", "Haut-Mbomou");
            hashtable32.Add("06", "Kemo");
            hashtable32.Add("07", "Lobaye");
            hashtable32.Add("08", "Mbomou");
            hashtable32.Add("09", "Nana-Mambere");
            hashtable32.Add("11", "Ouaka");
            hashtable32.Add("12", "Ouham");
            hashtable32.Add("13", "Ouham-Pende");
            hashtable32.Add("14", "Cuvette-Ouest");
            hashtable32.Add("15", "Nana-Grebizi");
            hashtable32.Add("16", "Sangha-Mbaere");
            hashtable32.Add("17", "Ombella-Mpoko");
            hashtable32.Add("18", "Bangui");
            RegionName.hashtable_0.Add("CF", hashtable32);
            Hashtable hashtable33 = new Hashtable();
            hashtable33.Add("01", "Bouenza");
            hashtable33.Add("04", "Kouilou");
            hashtable33.Add("05", "Lekoumou");
            hashtable33.Add("06", "Likouala");
            hashtable33.Add("07", "Niari");
            hashtable33.Add("08", "Plateaux");
            hashtable33.Add("10", "Sangha");
            hashtable33.Add("11", "Pool");
            hashtable33.Add("12", "Brazzaville");
            hashtable33.Add("13", "Cuvette");
            hashtable33.Add("14", "Cuvette-Ouest");
            RegionName.hashtable_0.Add("CG", hashtable33);
            Hashtable hashtable34 = new Hashtable();
            hashtable34.Add("01", "Aargau");
            hashtable34.Add("02", "Ausser-Rhoden");
            hashtable34.Add("03", "Basel-Landschaft");
            hashtable34.Add("04", "Basel-Stadt");
            hashtable34.Add("05", "Bern");
            hashtable34.Add("06", "Fribourg");
            hashtable34.Add("07", "Geneve");
            hashtable34.Add("08", "Glarus");
            hashtable34.Add("09", "Graubunden");
            hashtable34.Add("10", "Inner-Rhoden");
            hashtable34.Add("11", "Luzern");
            hashtable34.Add("12", "Neuchatel");
            hashtable34.Add("13", "Nidwalden");
            hashtable34.Add("14", "Obwalden");
            hashtable34.Add("15", "Sankt Gallen");
            hashtable34.Add("16", "Schaffhausen");
            hashtable34.Add("17", "Schwyz");
            hashtable34.Add("18", "Solothurn");
            hashtable34.Add("19", "Thurgau");
            hashtable34.Add("20", "Ticino");
            hashtable34.Add("21", "Uri");
            hashtable34.Add("22", "Valais");
            hashtable34.Add("23", "Vaud");
            hashtable34.Add("24", "Zug");
            hashtable34.Add("25", "Zurich");
            hashtable34.Add("26", "Jura");
            RegionName.hashtable_0.Add("CH", hashtable34);
            Hashtable hashtable35 = new Hashtable();
            hashtable35.Add("74", "Agneby");
            hashtable35.Add("75", "Bafing");
            hashtable35.Add("76", "Bas-Sassandra");
            hashtable35.Add("77", "Denguele");
            hashtable35.Add("78", "Dix-Huit Montagnes");
            hashtable35.Add("79", "Fromager");
            hashtable35.Add("80", "Haut-Sassandra");
            hashtable35.Add("81", "Lacs");
            hashtable35.Add("82", "Lagunes");
            hashtable35.Add("83", "Marahoue");
            hashtable35.Add("84", "Moyen-Cavally");
            hashtable35.Add("85", "Moyen-Comoe");
            hashtable35.Add("86", "N'zi-Comoe");
            hashtable35.Add("87", "Savanes");
            hashtable35.Add("88", "Sud-Bandama");
            hashtable35.Add("89", "Sud-Comoe");
            hashtable35.Add("90", "Vallee du Bandama");
            hashtable35.Add("91", "Worodougou");
            hashtable35.Add("92", "Zanzan");
            RegionName.hashtable_0.Add("CI", hashtable35);
            Hashtable hashtable36 = new Hashtable();
            hashtable36.Add("01", "Valparaiso");
            hashtable36.Add("02", "Aisen del General Carlos Ibanez del Campo");
            hashtable36.Add("03", "Antofagasta");
            hashtable36.Add("04", "Araucania");
            hashtable36.Add("05", "Atacama");
            hashtable36.Add("06", "Bio-Bio");
            hashtable36.Add("07", "Coquimbo");
            hashtable36.Add("08", "Libertador General Bernardo O'Higgins");
            hashtable36.Add("09", "Los Lagos");
            hashtable36.Add("10", "Magallanes y de la Antartica Chilena");
            hashtable36.Add("11", "Maule");
            hashtable36.Add("12", "Region Metropolitana");
            hashtable36.Add("13", "Tarapaca");
            hashtable36.Add("14", "Los Lagos");
            hashtable36.Add("15", "Tarapaca");
            hashtable36.Add("16", "Arica y Parinacota");
            hashtable36.Add("17", "Los Rios");
            RegionName.hashtable_0.Add("CL", hashtable36);
            Hashtable hashtable37 = new Hashtable();
            hashtable37.Add("04", "Est");
            hashtable37.Add("05", "Littoral");
            hashtable37.Add("07", "Nord-Ouest");
            hashtable37.Add("08", "Ouest");
            hashtable37.Add("09", "Sud-Ouest");
            hashtable37.Add("10", "Adamaoua");
            hashtable37.Add("11", "Centre");
            hashtable37.Add("12", "Extreme-Nord");
            hashtable37.Add("13", "Nord");
            hashtable37.Add("14", "Sud");
            RegionName.hashtable_0.Add("CM", hashtable37);
            Hashtable hashtable38 = new Hashtable();
            hashtable38.Add("01", "Anhui");
            hashtable38.Add("02", "Zhejiang");
            hashtable38.Add("03", "Jiangxi");
            hashtable38.Add("04", "Jiangsu");
            hashtable38.Add("05", "Jilin");
            hashtable38.Add("06", "Qinghai");
            hashtable38.Add("07", "Fujian");
            hashtable38.Add("08", "Heilongjiang");
            hashtable38.Add("09", "Henan");
            hashtable38.Add("10", "Hebei");
            hashtable38.Add("11", "Hunan");
            hashtable38.Add("12", "Hubei");
            hashtable38.Add("13", "Xinjiang");
            hashtable38.Add("14", "Xizang");
            hashtable38.Add("15", "Gansu");
            hashtable38.Add("16", "Guangxi");
            hashtable38.Add("18", "Guizhou");
            hashtable38.Add("19", "Liaoning");
            hashtable38.Add("20", "Nei Mongol");
            hashtable38.Add("21", "Ningxia");
            hashtable38.Add("22", "Beijing");
            hashtable38.Add("23", "Shanghai");
            hashtable38.Add("24", "Shanxi");
            hashtable38.Add("25", "Shandong");
            hashtable38.Add("26", "Shaanxi");
            hashtable38.Add("28", "Tianjin");
            hashtable38.Add("29", "Yunnan");
            hashtable38.Add("30", "Guangdong");
            hashtable38.Add("31", "Hainan");
            hashtable38.Add("32", "Sichuan");
            hashtable38.Add("33", "Chongqing");
            RegionName.hashtable_0.Add("CN", hashtable38);
            Hashtable hashtable39 = new Hashtable();
            hashtable39.Add("01", "Amazonas");
            hashtable39.Add("02", "Antioquia");
            hashtable39.Add("03", "Arauca");
            hashtable39.Add("04", "Atlantico");
            hashtable39.Add("08", "Caqueta");
            hashtable39.Add("09", "Cauca");
            hashtable39.Add("10", "Cesar");
            hashtable39.Add("11", "Choco");
            hashtable39.Add("12", "Cordoba");
            hashtable39.Add("14", "Guaviare");
            hashtable39.Add("15", "Guainia");
            hashtable39.Add("16", "Huila");
            hashtable39.Add("17", "La Guajira");
            hashtable39.Add("19", "Meta");
            hashtable39.Add("20", "Narino");
            hashtable39.Add("21", "Norte de Santander");
            hashtable39.Add("22", "Putumayo");
            hashtable39.Add("23", "Quindio");
            hashtable39.Add("24", "Risaralda");
            hashtable39.Add("25", "San Andres y Providencia");
            hashtable39.Add("26", "Santander");
            hashtable39.Add("27", "Sucre");
            hashtable39.Add("28", "Tolima");
            hashtable39.Add("29", "Valle del Cauca");
            hashtable39.Add("30", "Vaupes");
            hashtable39.Add("31", "Vichada");
            hashtable39.Add("32", "Casanare");
            hashtable39.Add("33", "Cundinamarca");
            hashtable39.Add("34", "Distrito Especial");
            hashtable39.Add("35", "Bolivar");
            hashtable39.Add("36", "Boyaca");
            hashtable39.Add("37", "Caldas");
            hashtable39.Add("38", "Magdalena");
            RegionName.hashtable_0.Add("CO", hashtable39);
            Hashtable hashtable40 = new Hashtable();
            hashtable40.Add("01", "Alajuela");
            hashtable40.Add("02", "Cartago");
            hashtable40.Add("03", "Guanacaste");
            hashtable40.Add("04", "Heredia");
            hashtable40.Add("06", "Limon");
            hashtable40.Add("07", "Puntarenas");
            hashtable40.Add("08", "San Jose");
            RegionName.hashtable_0.Add("CR", hashtable40);
            Hashtable hashtable41 = new Hashtable();
            hashtable41.Add("01", "Pinar del Rio");
            hashtable41.Add("02", "Ciudad de la Habana");
            hashtable41.Add("03", "Matanzas");
            hashtable41.Add("04", "Isla de la Juventud");
            hashtable41.Add("05", "Camaguey");
            hashtable41.Add("07", "Ciego de Avila");
            hashtable41.Add("08", "Cienfuegos");
            hashtable41.Add("09", "Granma");
            hashtable41.Add("10", "Guantanamo");
            hashtable41.Add("11", "La Habana");
            hashtable41.Add("12", "Holguin");
            hashtable41.Add("13", "Las Tunas");
            hashtable41.Add("14", "Sancti Spiritus");
            hashtable41.Add("15", "Santiago de Cuba");
            hashtable41.Add("16", "Villa Clara");
            RegionName.hashtable_0.Add("CU", hashtable41);
            Hashtable hashtable42 = new Hashtable();
            hashtable42.Add("01", "Boa Vista");
            hashtable42.Add("02", "Brava");
            hashtable42.Add("04", "Maio");
            hashtable42.Add("05", "Paul");
            hashtable42.Add("07", "Ribeira Grande");
            hashtable42.Add("08", "Sal");
            hashtable42.Add("10", "Sao Nicolau");
            hashtable42.Add("11", "Sao Vicente");
            hashtable42.Add("13", "Mosteiros");
            hashtable42.Add("14", "Praia");
            hashtable42.Add("15", "Santa Catarina");
            hashtable42.Add("16", "Santa Cruz");
            hashtable42.Add("17", "Sao Domingos");
            hashtable42.Add("18", "Sao Filipe");
            hashtable42.Add("19", "Sao Miguel");
            hashtable42.Add("20", "Tarrafal");
            RegionName.hashtable_0.Add("CV", hashtable42);
            Hashtable hashtable43 = new Hashtable();
            hashtable43.Add("01", "Famagusta");
            hashtable43.Add("02", "Kyrenia");
            hashtable43.Add("03", "Larnaca");
            hashtable43.Add("04", "Nicosia");
            hashtable43.Add("05", "Limassol");
            hashtable43.Add("06", "Paphos");
            RegionName.hashtable_0.Add("CY", hashtable43);
            Hashtable hashtable44 = new Hashtable();
            hashtable44.Add("52", "Hlavni mesto Praha");
            hashtable44.Add("78", "Jihomoravsky kraj");
            hashtable44.Add("79", "Jihocesky kraj");
            hashtable44.Add("80", "Vysocina");
            hashtable44.Add("81", "Karlovarsky kraj");
            hashtable44.Add("82", "Kralovehradecky kraj");
            hashtable44.Add("83", "Liberecky kraj");
            hashtable44.Add("84", "Olomoucky kraj");
            hashtable44.Add("85", "Moravskoslezsky kraj");
            hashtable44.Add("86", "Pardubicky kraj");
            hashtable44.Add("87", "Plzensky kraj");
            hashtable44.Add("88", "Stredocesky kraj");
            hashtable44.Add("89", "Ustecky kraj");
            hashtable44.Add("90", "Zlinsky kraj");
            RegionName.hashtable_0.Add("CZ", hashtable44);
            Hashtable hashtable45 = new Hashtable();
            hashtable45.Add("01", "Baden-Wurttemberg");
            hashtable45.Add("02", "Bayern");
            hashtable45.Add("03", "Bremen");
            hashtable45.Add("04", "Hamburg");
            hashtable45.Add("05", "Hessen");
            hashtable45.Add("06", "Niedersachsen");
            hashtable45.Add("07", "Nordrhein-Westfalen");
            hashtable45.Add("08", "Rheinland-Pfalz");
            hashtable45.Add("09", "Saarland");
            hashtable45.Add("10", "Schleswig-Holstein");
            hashtable45.Add("11", "Brandenburg");
            hashtable45.Add("12", "Mecklenburg-Vorpommern");
            hashtable45.Add("13", "Sachsen");
            hashtable45.Add("14", "Sachsen-Anhalt");
            hashtable45.Add("15", "Thuringen");
            hashtable45.Add("16", "Berlin");
            RegionName.hashtable_0.Add("DE", hashtable45);
            Hashtable hashtable46 = new Hashtable();
            hashtable46.Add("01", "Ali Sabieh");
            hashtable46.Add("04", "Obock");
            hashtable46.Add("05", "Tadjoura");
            hashtable46.Add("06", "Dikhil");
            hashtable46.Add("07", "Djibouti");
            hashtable46.Add("08", "Arta");
            RegionName.hashtable_0.Add("DJ", hashtable46);
            Hashtable hashtable47 = new Hashtable();
            hashtable47.Add("17", "Hovedstaden");
            hashtable47.Add("18", "Midtjylland");
            hashtable47.Add("19", "Nordjylland");
            hashtable47.Add("20", "Sjelland");
            hashtable47.Add("21", "Syddanmark");
            RegionName.hashtable_0.Add("DK", hashtable47);
            Hashtable hashtable48 = new Hashtable();
            hashtable48.Add("02", "Saint Andrew");
            hashtable48.Add("03", "Saint David");
            hashtable48.Add("04", "Saint George");
            hashtable48.Add("05", "Saint John");
            hashtable48.Add("06", "Saint Joseph");
            hashtable48.Add("07", "Saint Luke");
            hashtable48.Add("08", "Saint Mark");
            hashtable48.Add("09", "Saint Patrick");
            hashtable48.Add("10", "Saint Paul");
            hashtable48.Add("11", "Saint Peter");
            RegionName.hashtable_0.Add("DM", hashtable48);
            Hashtable hashtable49 = new Hashtable();
            hashtable49.Add("01", "Azua");
            hashtable49.Add("02", "Baoruco");
            hashtable49.Add("03", "Barahona");
            hashtable49.Add("04", "Dajabon");
            hashtable49.Add("05", "Distrito Nacional");
            hashtable49.Add("06", "Duarte");
            hashtable49.Add("08", "Espaillat");
            hashtable49.Add("09", "Independencia");
            hashtable49.Add("10", "La Altagracia");
            hashtable49.Add("11", "Elias Pina");
            hashtable49.Add("12", "La Romana");
            hashtable49.Add("14", "Maria Trinidad Sanchez");
            hashtable49.Add("15", "Monte Cristi");
            hashtable49.Add("16", "Pedernales");
            hashtable49.Add("17", "Peravia");
            hashtable49.Add("18", "Puerto Plata");
            hashtable49.Add("19", "Salcedo");
            hashtable49.Add("20", "Samana");
            hashtable49.Add("21", "Sanchez Ramirez");
            hashtable49.Add("23", "San Juan");
            hashtable49.Add("24", "San Pedro De Macoris");
            hashtable49.Add("25", "Santiago");
            hashtable49.Add("26", "Santiago Rodriguez");
            hashtable49.Add("27", "Valverde");
            hashtable49.Add("28", "El Seibo");
            hashtable49.Add("29", "Hato Mayor");
            hashtable49.Add("30", "La Vega");
            hashtable49.Add("31", "Monsenor Nouel");
            hashtable49.Add("32", "Monte Plata");
            hashtable49.Add("33", "San Cristobal");
            hashtable49.Add("34", "Distrito Nacional");
            hashtable49.Add("35", "Peravia");
            hashtable49.Add("36", "San Jose de Ocoa");
            hashtable49.Add("37", "Santo Domingo");
            RegionName.hashtable_0.Add("DO", hashtable49);
            Hashtable hashtable50 = new Hashtable();
            hashtable50.Add("01", "Alger");
            hashtable50.Add("03", "Batna");
            hashtable50.Add("04", "Constantine");
            hashtable50.Add("06", "Medea");
            hashtable50.Add("07", "Mostaganem");
            hashtable50.Add("09", "Oran");
            hashtable50.Add("10", "Saida");
            hashtable50.Add("12", "Setif");
            hashtable50.Add("13", "Tiaret");
            hashtable50.Add("14", "Tizi Ouzou");
            hashtable50.Add("15", "Tlemcen");
            hashtable50.Add("18", "Bejaia");
            hashtable50.Add("19", "Biskra");
            hashtable50.Add("20", "Blida");
            hashtable50.Add("21", "Bouira");
            hashtable50.Add("22", "Djelfa");
            hashtable50.Add("23", "Guelma");
            hashtable50.Add("24", "Jijel");
            hashtable50.Add("25", "Laghouat");
            hashtable50.Add("26", "Mascara");
            hashtable50.Add("27", "M'sila");
            hashtable50.Add("29", "Oum el Bouaghi");
            hashtable50.Add("30", "Sidi Bel Abbes");
            hashtable50.Add("31", "Skikda");
            hashtable50.Add("33", "Tebessa");
            hashtable50.Add("34", "Adrar");
            hashtable50.Add("35", "Ain Defla");
            hashtable50.Add("36", "Ain Temouchent");
            hashtable50.Add("37", "Annaba");
            hashtable50.Add("38", "Bechar");
            hashtable50.Add("39", "Bordj Bou Arreridj");
            hashtable50.Add("40", "Boumerdes");
            hashtable50.Add("41", "Chlef");
            hashtable50.Add("42", "El Bayadh");
            hashtable50.Add("43", "El Oued");
            hashtable50.Add("44", "El Tarf");
            hashtable50.Add("45", "Ghardaia");
            hashtable50.Add("46", "Illizi");
            hashtable50.Add("47", "Khenchela");
            hashtable50.Add("48", "Mila");
            hashtable50.Add("49", "Naama");
            hashtable50.Add("50", "Ouargla");
            hashtable50.Add("51", "Relizane");
            hashtable50.Add("52", "Souk Ahras");
            hashtable50.Add("53", "Tamanghasset");
            hashtable50.Add("54", "Tindouf");
            hashtable50.Add("55", "Tipaza");
            hashtable50.Add("56", "Tissemsilt");
            RegionName.hashtable_0.Add("DZ", hashtable50);
            Hashtable hashtable51 = new Hashtable();
            hashtable51.Add("01", "Galapagos");
            hashtable51.Add("02", "Azuay");
            hashtable51.Add("03", "Bolivar");
            hashtable51.Add("04", "Canar");
            hashtable51.Add("05", "Carchi");
            hashtable51.Add("06", "Chimborazo");
            hashtable51.Add("07", "Cotopaxi");
            hashtable51.Add("08", "El Oro");
            hashtable51.Add("09", "Esmeraldas");
            hashtable51.Add("10", "Guayas");
            hashtable51.Add("11", "Imbabura");
            hashtable51.Add("12", "Loja");
            hashtable51.Add("13", "Los Rios");
            hashtable51.Add("14", "Manabi");
            hashtable51.Add("15", "Morona-Santiago");
            hashtable51.Add("17", "Pastaza");
            hashtable51.Add("18", "Pichincha");
            hashtable51.Add("19", "Tungurahua");
            hashtable51.Add("20", "Zamora-Chinchipe");
            hashtable51.Add("22", "Sucumbios");
            hashtable51.Add("23", "Napo");
            hashtable51.Add("24", "Orellana");
            RegionName.hashtable_0.Add("EC", hashtable51);
            Hashtable hashtable52 = new Hashtable();
            hashtable52.Add("01", "Harjumaa");
            hashtable52.Add("02", "Hiiumaa");
            hashtable52.Add("03", "Ida-Virumaa");
            hashtable52.Add("04", "Jarvamaa");
            hashtable52.Add("05", "Jogevamaa");
            hashtable52.Add("06", "Kohtla-Jarve");
            hashtable52.Add("07", "Laanemaa");
            hashtable52.Add("08", "Laane-Virumaa");
            hashtable52.Add("09", "Narva");
            hashtable52.Add("10", "Parnu");
            hashtable52.Add("11", "Parnumaa");
            hashtable52.Add("12", "Polvamaa");
            hashtable52.Add("13", "Raplamaa");
            hashtable52.Add("14", "Saaremaa");
            hashtable52.Add("15", "Sillamae");
            hashtable52.Add("16", "Tallinn");
            hashtable52.Add("17", "Tartu");
            hashtable52.Add("18", "Tartumaa");
            hashtable52.Add("19", "Valgamaa");
            hashtable52.Add("20", "Viljandimaa");
            hashtable52.Add("21", "Vorumaa");
            RegionName.hashtable_0.Add("EE", hashtable52);
            Hashtable hashtable53 = new Hashtable();
            hashtable53.Add("01", "Ad Daqahliyah");
            hashtable53.Add("02", "Al Bahr al Ahmar");
            hashtable53.Add("03", "Al Buhayrah");
            hashtable53.Add("04", "Al Fayyum");
            hashtable53.Add("05", "Al Gharbiyah");
            hashtable53.Add("06", "Al Iskandariyah");
            hashtable53.Add("07", "Al Isma'iliyah");
            hashtable53.Add("08", "Al Jizah");
            hashtable53.Add("09", "Al Minufiyah");
            hashtable53.Add("10", "Al Minya");
            hashtable53.Add("11", "Al Qahirah");
            hashtable53.Add("12", "Al Qalyubiyah");
            hashtable53.Add("13", "Al Wadi al Jadid");
            hashtable53.Add("14", "Ash Sharqiyah");
            hashtable53.Add("15", "As Suways");
            hashtable53.Add("16", "Aswan");
            hashtable53.Add("17", "Asyut");
            hashtable53.Add("18", "Bani Suwayf");
            hashtable53.Add("19", "Bur Sa'id");
            hashtable53.Add("20", "Dumyat");
            hashtable53.Add("21", "Kafr ash Shaykh");
            hashtable53.Add("22", "Matruh");
            hashtable53.Add("23", "Qina");
            hashtable53.Add("24", "Suhaj");
            hashtable53.Add("26", "Janub Sina'");
            hashtable53.Add("27", "Shamal Sina'");
            RegionName.hashtable_0.Add("EG", hashtable53);
            Hashtable hashtable54 = new Hashtable();
            hashtable54.Add("01", "Anseba");
            hashtable54.Add("02", "Debub");
            hashtable54.Add("03", "Debubawi K'eyih Bahri");
            hashtable54.Add("04", "Gash Barka");
            hashtable54.Add("05", "Ma'akel");
            hashtable54.Add("06", "Semenawi K'eyih Bahri");
            RegionName.hashtable_0.Add("ER", hashtable54);
            Hashtable hashtable55 = new Hashtable();
            hashtable55.Add("07", "Islas Baleares");
            hashtable55.Add("27", "La Rioja");
            hashtable55.Add("29", "Madrid");
            hashtable55.Add("31", "Murcia");
            hashtable55.Add("32", "Navarra");
            hashtable55.Add("34", "Asturias");
            hashtable55.Add("39", "Cantabria");
            hashtable55.Add("51", "Andalucia");
            hashtable55.Add("52", "Aragon");
            hashtable55.Add("53", "Canarias");
            hashtable55.Add("54", "Castilla-La Mancha");
            hashtable55.Add("55", "Castilla y Leon");
            hashtable55.Add("56", "Catalonia");
            hashtable55.Add("57", "Extremadura");
            hashtable55.Add("58", "Galicia");
            hashtable55.Add("59", "Pais Vasco");
            hashtable55.Add("60", "Comunidad Valenciana");
            RegionName.hashtable_0.Add("ES", hashtable55);
            Hashtable hashtable56 = new Hashtable();
            hashtable56.Add("44", "Adis Abeba");
            hashtable56.Add("45", "Afar");
            hashtable56.Add("46", "Amara");
            hashtable56.Add("47", "Binshangul Gumuz");
            hashtable56.Add("48", "Dire Dawa");
            hashtable56.Add("49", "Gambela Hizboch");
            hashtable56.Add("50", "Hareri Hizb");
            hashtable56.Add("51", "Oromiya");
            hashtable56.Add("52", "Sumale");
            hashtable56.Add("53", "Tigray");
            hashtable56.Add("54", "YeDebub Biheroch Bihereseboch na Hizboch");
            RegionName.hashtable_0.Add("ET", hashtable56);
            Hashtable hashtable57 = new Hashtable();
            hashtable57.Add("01", "Aland");
            hashtable57.Add("06", "Lapland");
            hashtable57.Add("08", "Oulu");
            hashtable57.Add("13", "Southern Finland");
            hashtable57.Add("14", "Eastern Finland");
            hashtable57.Add("15", "Western Finland");
            RegionName.hashtable_0.Add("FI", hashtable57);
            Hashtable hashtable58 = new Hashtable();
            hashtable58.Add("01", "Central");
            hashtable58.Add("02", "Eastern");
            hashtable58.Add("03", "Northern");
            hashtable58.Add("04", "Rotuma");
            hashtable58.Add("05", "Western");
            RegionName.hashtable_0.Add("FJ", hashtable58);
            Hashtable hashtable59 = new Hashtable();
            hashtable59.Add("01", "Kosrae");
            hashtable59.Add("02", "Pohnpei");
            hashtable59.Add("03", "Chuuk");
            hashtable59.Add("04", "Yap");
            RegionName.hashtable_0.Add("FM", hashtable59);
            Hashtable hashtable60 = new Hashtable();
            hashtable60.Add("97", "Aquitaine");
            hashtable60.Add("98", "Auvergne");
            hashtable60.Add("99", "Basse-Normandie");
            hashtable60.Add("A1", "Bourgogne");
            hashtable60.Add("A2", "Bretagne");
            hashtable60.Add("A3", "Centre");
            hashtable60.Add("A4", "Champagne-Ardenne");
            hashtable60.Add("A5", "Corse");
            hashtable60.Add("A6", "Franche-Comte");
            hashtable60.Add("A7", "Haute-Normandie");
            hashtable60.Add("A8", "Ile-de-France");
            hashtable60.Add("A9", "Languedoc-Roussillon");
            hashtable60.Add("B1", "Limousin");
            hashtable60.Add("B2", "Lorraine");
            hashtable60.Add("B3", "Midi-Pyrenees");
            hashtable60.Add("B4", "Nord-Pas-de-Calais");
            hashtable60.Add("B5", "Pays de la Loire");
            hashtable60.Add("B6", "Picardie");
            hashtable60.Add("B7", "Poitou-Charentes");
            hashtable60.Add("B8", "Provence-Alpes-Cote d'Azur");
            hashtable60.Add("B9", "Rhone-Alpes");
            hashtable60.Add("C1", "Alsace");
            RegionName.hashtable_0.Add("FR", hashtable60);
            Hashtable hashtable61 = new Hashtable();
            hashtable61.Add("01", "Estuaire");
            hashtable61.Add("02", "Haut-Ogooue");
            hashtable61.Add("03", "Moyen-Ogooue");
            hashtable61.Add("04", "Ngounie");
            hashtable61.Add("05", "Nyanga");
            hashtable61.Add("06", "Ogooue-Ivindo");
            hashtable61.Add("07", "Ogooue-Lolo");
            hashtable61.Add("08", "Ogooue-Maritime");
            hashtable61.Add("09", "Woleu-Ntem");
            RegionName.hashtable_0.Add("GA", hashtable61);
            Hashtable hashtable62 = new Hashtable();
            hashtable62.Add("A1", "Barking and Dagenham");
            hashtable62.Add("A2", "Barnet");
            hashtable62.Add("A3", "Barnsley");
            hashtable62.Add("A4", "Bath and North East Somerset");
            hashtable62.Add("A5", "Bedfordshire");
            hashtable62.Add("A6", "Bexley");
            hashtable62.Add("A7", "Birmingham");
            hashtable62.Add("A8", "Blackburn with Darwen");
            hashtable62.Add("A9", "Blackpool");
            hashtable62.Add("B1", "Bolton");
            hashtable62.Add("B2", "Bournemouth");
            hashtable62.Add("B3", "Bracknell Forest");
            hashtable62.Add("B4", "Bradford");
            hashtable62.Add("B5", "Brent");
            hashtable62.Add("B6", "Brighton and Hove");
            hashtable62.Add("B7", "Bristol, City of");
            hashtable62.Add("B8", "Bromley");
            hashtable62.Add("B9", "Buckinghamshire");
            hashtable62.Add("C1", "Bury");
            hashtable62.Add("C2", "Calderdale");
            hashtable62.Add("C3", "Cambridgeshire");
            hashtable62.Add("C4", "Camden");
            hashtable62.Add("C5", "Cheshire");
            hashtable62.Add("C6", "Cornwall");
            hashtable62.Add("C7", "Coventry");
            hashtable62.Add("C8", "Croydon");
            hashtable62.Add("C9", "Cumbria");
            hashtable62.Add("D1", "Darlington");
            hashtable62.Add("D2", "Derby");
            hashtable62.Add("D3", "Derbyshire");
            hashtable62.Add("D4", "Devon");
            hashtable62.Add("D5", "Doncaster");
            hashtable62.Add("D6", "Dorset");
            hashtable62.Add("D7", "Dudley");
            hashtable62.Add("D8", "Durham");
            hashtable62.Add("D9", "Ealing");
            hashtable62.Add("E1", "East Riding of Yorkshire");
            hashtable62.Add("E2", "East Sussex");
            hashtable62.Add("E3", "Enfield");
            hashtable62.Add("E4", "Essex");
            hashtable62.Add("E5", "Gateshead");
            hashtable62.Add("E6", "Gloucestershire");
            hashtable62.Add("E7", "Greenwich");
            hashtable62.Add("E8", "Hackney");
            hashtable62.Add("E9", "Halton");
            hashtable62.Add("F1", "Hammersmith and Fulham");
            hashtable62.Add("F2", "Hampshire");
            hashtable62.Add("F3", "Haringey");
            hashtable62.Add("F4", "Harrow");
            hashtable62.Add("F5", "Hartlepool");
            hashtable62.Add("F6", "Havering");
            hashtable62.Add("F7", "Herefordshire");
            hashtable62.Add("F8", "Hertford");
            hashtable62.Add("F9", "Hillingdon");
            hashtable62.Add("G1", "Hounslow");
            hashtable62.Add("G2", "Isle of Wight");
            hashtable62.Add("G3", "Islington");
            hashtable62.Add("G4", "Kensington and Chelsea");
            hashtable62.Add("G5", "Kent");
            hashtable62.Add("G6", "Kingston upon Hull, City of");
            hashtable62.Add("G7", "Kingston upon Thames");
            hashtable62.Add("G8", "Kirklees");
            hashtable62.Add("G9", "Knowsley");
            hashtable62.Add("H1", "Lambeth");
            hashtable62.Add("H2", "Lancashire");
            hashtable62.Add("H3", "Leeds");
            hashtable62.Add("H4", "Leicester");
            hashtable62.Add("H5", "Leicestershire");
            hashtable62.Add("H6", "Lewisham");
            hashtable62.Add("H7", "Lincolnshire");
            hashtable62.Add("H8", "Liverpool");
            hashtable62.Add("H9", "London, City of");
            hashtable62.Add("I1", "Luton");
            hashtable62.Add("I2", "Manchester");
            hashtable62.Add("I3", "Medway");
            hashtable62.Add("I4", "Merton");
            hashtable62.Add("I5", "Middlesbrough");
            hashtable62.Add("I6", "Milton Keynes");
            hashtable62.Add("I7", "Newcastle upon Tyne");
            hashtable62.Add("I8", "Newham");
            hashtable62.Add("I9", "Norfolk");
            hashtable62.Add("J1", "Northamptonshire");
            hashtable62.Add("J2", "North East Lincolnshire");
            hashtable62.Add("J3", "North Lincolnshire");
            hashtable62.Add("J4", "North Somerset");
            hashtable62.Add("J5", "North Tyneside");
            hashtable62.Add("J6", "Northumberland");
            hashtable62.Add("J7", "North Yorkshire");
            hashtable62.Add("J8", "Nottingham");
            hashtable62.Add("J9", "Nottinghamshire");
            hashtable62.Add("K1", "Oldham");
            hashtable62.Add("K2", "Oxfordshire");
            hashtable62.Add("K3", "Peterborough");
            hashtable62.Add("K4", "Plymouth");
            hashtable62.Add("K5", "Poole");
            hashtable62.Add("K6", "Portsmouth");
            hashtable62.Add("K7", "Reading");
            hashtable62.Add("K8", "Redbridge");
            hashtable62.Add("K9", "Redcar and Cleveland");
            hashtable62.Add("L1", "Richmond upon Thames");
            hashtable62.Add("L2", "Rochdale");
            hashtable62.Add("L3", "Rotherham");
            hashtable62.Add("L4", "Rutland");
            hashtable62.Add("L5", "Salford");
            hashtable62.Add("L6", "Shropshire");
            hashtable62.Add("L7", "Sandwell");
            hashtable62.Add("L8", "Sefton");
            hashtable62.Add("L9", "Sheffield");
            hashtable62.Add("M1", "Slough");
            hashtable62.Add("M2", "Solihull");
            hashtable62.Add("M3", "Somerset");
            hashtable62.Add("M4", "Southampton");
            hashtable62.Add("M5", "Southend-on-Sea");
            hashtable62.Add("M6", "South Gloucestershire");
            hashtable62.Add("M7", "South Tyneside");
            hashtable62.Add("M8", "Southwark");
            hashtable62.Add("M9", "Staffordshire");
            hashtable62.Add("N1", "St. Helens");
            hashtable62.Add("N2", "Stockport");
            hashtable62.Add("N3", "Stockton-on-Tees");
            hashtable62.Add("N4", "Stoke-on-Trent");
            hashtable62.Add("N5", "Suffolk");
            hashtable62.Add("N6", "Sunderland");
            hashtable62.Add("N7", "Surrey");
            hashtable62.Add("N8", "Sutton");
            hashtable62.Add("N9", "Swindon");
            hashtable62.Add("O1", "Tameside");
            hashtable62.Add("O2", "Telford and Wrekin");
            hashtable62.Add("O3", "Thurrock");
            hashtable62.Add("O4", "Torbay");
            hashtable62.Add("O5", "Tower Hamlets");
            hashtable62.Add("O6", "Trafford");
            hashtable62.Add("O7", "Wakefield");
            hashtable62.Add("O8", "Walsall");
            hashtable62.Add("O9", "Waltham Forest");
            hashtable62.Add("P1", "Wandsworth");
            hashtable62.Add("P2", "Warrington");
            hashtable62.Add("P3", "Warwickshire");
            hashtable62.Add("P4", "West Berkshire");
            hashtable62.Add("P5", "Westminster");
            hashtable62.Add("P6", "West Sussex");
            hashtable62.Add("P7", "Wigan");
            hashtable62.Add("P8", "Wiltshire");
            hashtable62.Add("P9", "Windsor and Maidenhead");
            hashtable62.Add("Q1", "Wirral");
            hashtable62.Add("Q2", "Wokingham");
            hashtable62.Add("Q3", "Wolverhampton");
            hashtable62.Add("Q4", "Worcestershire");
            hashtable62.Add("Q5", "York");
            hashtable62.Add("Q6", "Antrim");
            hashtable62.Add("Q7", "Ards");
            hashtable62.Add("Q8", "Armagh");
            hashtable62.Add("Q9", "Ballymena");
            hashtable62.Add("R1", "Ballymoney");
            hashtable62.Add("R2", "Banbridge");
            hashtable62.Add("R3", "Belfast");
            hashtable62.Add("R4", "Carrickfergus");
            hashtable62.Add("R5", "Castlereagh");
            hashtable62.Add("R6", "Coleraine");
            hashtable62.Add("R7", "Cookstown");
            hashtable62.Add("R8", "Craigavon");
            hashtable62.Add("R9", "Down");
            hashtable62.Add("S1", "Dungannon");
            hashtable62.Add("S2", "Fermanagh");
            hashtable62.Add("S3", "Larne");
            hashtable62.Add("S4", "Limavady");
            hashtable62.Add("S5", "Lisburn");
            hashtable62.Add("S6", "Derry");
            hashtable62.Add("S7", "Magherafelt");
            hashtable62.Add("S8", "Moyle");
            hashtable62.Add("S9", "Newry and Mourne");
            hashtable62.Add("T1", "Newtownabbey");
            hashtable62.Add("T2", "North Down");
            hashtable62.Add("T3", "Omagh");
            hashtable62.Add("T4", "Strabane");
            hashtable62.Add("T5", "Aberdeen City");
            hashtable62.Add("T6", "Aberdeenshire");
            hashtable62.Add("T7", "Angus");
            hashtable62.Add("T8", "Argyll and Bute");
            hashtable62.Add("T9", "Scottish Borders, The");
            hashtable62.Add("U1", "Clackmannanshire");
            hashtable62.Add("U2", "Dumfries and Galloway");
            hashtable62.Add("U3", "Dundee City");
            hashtable62.Add("U4", "East Ayrshire");
            hashtable62.Add("U5", "East Dunbartonshire");
            hashtable62.Add("U6", "East Lothian");
            hashtable62.Add("U7", "East Renfrewshire");
            hashtable62.Add("U8", "Edinburgh, City of");
            hashtable62.Add("U9", "Falkirk");
            hashtable62.Add("V1", "Fife");
            hashtable62.Add("V2", "Glasgow City");
            hashtable62.Add("V3", "Highland");
            hashtable62.Add("V4", "Inverclyde");
            hashtable62.Add("V5", "Midlothian");
            hashtable62.Add("V6", "Moray");
            hashtable62.Add("V7", "North Ayrshire");
            hashtable62.Add("V8", "North Lanarkshire");
            hashtable62.Add("V9", "Orkney");
            hashtable62.Add("W1", "Perth and Kinross");
            hashtable62.Add("W2", "Renfrewshire");
            hashtable62.Add("W3", "Shetland Islands");
            hashtable62.Add("W4", "South Ayrshire");
            hashtable62.Add("W5", "South Lanarkshire");
            hashtable62.Add("W6", "Stirling");
            hashtable62.Add("W7", "West Dunbartonshire");
            hashtable62.Add("W8", "Eilean Siar");
            hashtable62.Add("W9", "West Lothian");
            hashtable62.Add("X1", "Isle of Anglesey");
            hashtable62.Add("X2", "Blaenau Gwent");
            hashtable62.Add("X3", "Bridgend");
            hashtable62.Add("X4", "Caerphilly");
            hashtable62.Add("X5", "Cardiff");
            hashtable62.Add("X6", "Ceredigion");
            hashtable62.Add("X7", "Carmarthenshire");
            hashtable62.Add("X8", "Conwy");
            hashtable62.Add("X9", "Denbighshire");
            hashtable62.Add("Y1", "Flintshire");
            hashtable62.Add("Y2", "Gwynedd");
            hashtable62.Add("Y3", "Merthyr Tydfil");
            hashtable62.Add("Y4", "Monmouthshire");
            hashtable62.Add("Y5", "Neath Port Talbot");
            hashtable62.Add("Y6", "Newport");
            hashtable62.Add("Y7", "Pembrokeshire");
            hashtable62.Add("Y8", "Powys");
            hashtable62.Add("Y9", "Rhondda Cynon Taff");
            hashtable62.Add("Z1", "Swansea");
            hashtable62.Add("Z2", "Torfaen");
            hashtable62.Add("Z3", "Vale of Glamorgan, The");
            hashtable62.Add("Z4", "Wrexham");
            RegionName.hashtable_0.Add("GB", hashtable62);
            Hashtable hashtable63 = new Hashtable();
            hashtable63.Add("01", "Saint Andrew");
            hashtable63.Add("02", "Saint David");
            hashtable63.Add("03", "Saint George");
            hashtable63.Add("04", "Saint John");
            hashtable63.Add("05", "Saint Mark");
            hashtable63.Add("06", "Saint Patrick");
            RegionName.hashtable_0.Add("GD", hashtable63);
            Hashtable hashtable64 = new Hashtable();
            hashtable64.Add("01", "Abashis Raioni");
            hashtable64.Add("02", "Abkhazia");
            hashtable64.Add("03", "Adigenis Raioni");
            hashtable64.Add("04", "Ajaria");
            hashtable64.Add("05", "Akhalgoris Raioni");
            hashtable64.Add("06", "Akhalk'alak'is Raioni");
            hashtable64.Add("07", "Akhalts'ikhis Raioni");
            hashtable64.Add("08", "Akhmetis Raioni");
            hashtable64.Add("09", "Ambrolauris Raioni");
            hashtable64.Add("10", "Aspindzis Raioni");
            hashtable64.Add("11", "Baghdat'is Raioni");
            hashtable64.Add("12", "Bolnisis Raioni");
            hashtable64.Add("13", "Borjomis Raioni");
            hashtable64.Add("14", "Chiat'ura");
            hashtable64.Add("15", "Ch'khorotsqus Raioni");
            hashtable64.Add("16", "Ch'okhatauris Raioni");
            hashtable64.Add("17", "Dedop'listsqaros Raioni");
            hashtable64.Add("18", "Dmanisis Raioni");
            hashtable64.Add("19", "Dushet'is Raioni");
            hashtable64.Add("20", "Gardabanis Raioni");
            hashtable64.Add("21", "Gori");
            hashtable64.Add("22", "Goris Raioni");
            hashtable64.Add("23", "Gurjaanis Raioni");
            hashtable64.Add("24", "Javis Raioni");
            hashtable64.Add("25", "K'arelis Raioni");
            hashtable64.Add("26", "Kaspis Raioni");
            hashtable64.Add("27", "Kharagaulis Raioni");
            hashtable64.Add("28", "Khashuris Raioni");
            hashtable64.Add("29", "Khobis Raioni");
            hashtable64.Add("30", "Khonis Raioni");
            hashtable64.Add("31", "K'ut'aisi");
            hashtable64.Add("32", "Lagodekhis Raioni");
            hashtable64.Add("33", "Lanch'khut'is Raioni");
            hashtable64.Add("34", "Lentekhis Raioni");
            hashtable64.Add("35", "Marneulis Raioni");
            hashtable64.Add("36", "Martvilis Raioni");
            hashtable64.Add("37", "Mestiis Raioni");
            hashtable64.Add("38", "Mts'khet'is Raioni");
            hashtable64.Add("39", "Ninotsmindis Raioni");
            hashtable64.Add("40", "Onis Raioni");
            hashtable64.Add("41", "Ozurget'is Raioni");
            hashtable64.Add("42", "P'ot'i");
            hashtable64.Add("43", "Qazbegis Raioni");
            hashtable64.Add("44", "Qvarlis Raioni");
            hashtable64.Add("45", "Rust'avi");
            hashtable64.Add("46", "Sach'kheris Raioni");
            hashtable64.Add("47", "Sagarejos Raioni");
            hashtable64.Add("48", "Samtrediis Raioni");
            hashtable64.Add("49", "Senakis Raioni");
            hashtable64.Add("50", "Sighnaghis Raioni");
            hashtable64.Add("51", "T'bilisi");
            hashtable64.Add("52", "T'elavis Raioni");
            hashtable64.Add("53", "T'erjolis Raioni");
            hashtable64.Add("54", "T'et'ritsqaros Raioni");
            hashtable64.Add("55", "T'ianet'is Raioni");
            hashtable64.Add("56", "Tqibuli");
            hashtable64.Add("57", "Ts'ageris Raioni");
            hashtable64.Add("58", "Tsalenjikhis Raioni");
            hashtable64.Add("59", "Tsalkis Raioni");
            hashtable64.Add("60", "Tsqaltubo");
            hashtable64.Add("61", "Vanis Raioni");
            hashtable64.Add("62", "Zestap'onis Raioni");
            hashtable64.Add("63", "Zugdidi");
            hashtable64.Add("64", "Zugdidis Raioni");
            RegionName.hashtable_0.Add("GE", hashtable64);
            Hashtable hashtable65 = new Hashtable();
            hashtable65.Add("01", "Greater Accra");
            hashtable65.Add("02", "Ashanti");
            hashtable65.Add("03", "Brong-Ahafo");
            hashtable65.Add("04", "Central");
            hashtable65.Add("05", "Eastern");
            hashtable65.Add("06", "Northern");
            hashtable65.Add("08", "Volta");
            hashtable65.Add("09", "Western");
            hashtable65.Add("10", "Upper East");
            hashtable65.Add("11", "Upper West");
            RegionName.hashtable_0.Add("GH", hashtable65);
            Hashtable hashtable66 = new Hashtable();
            hashtable66.Add("01", "Nordgronland");
            hashtable66.Add("02", "Ostgronland");
            hashtable66.Add("03", "Vestgronland");
            RegionName.hashtable_0.Add("GL", hashtable66);
            Hashtable hashtable67 = new Hashtable();
            hashtable67.Add("01", "Banjul");
            hashtable67.Add("02", "Lower River");
            hashtable67.Add("03", "Central River");
            hashtable67.Add("04", "Upper River");
            hashtable67.Add("05", "Western");
            hashtable67.Add("07", "North Bank");
            RegionName.hashtable_0.Add("GM", hashtable67);
            Hashtable hashtable68 = new Hashtable();
            hashtable68.Add("01", "Beyla");
            hashtable68.Add("02", "Boffa");
            hashtable68.Add("03", "Boke");
            hashtable68.Add("04", "Conakry");
            hashtable68.Add("05", "Dabola");
            hashtable68.Add("06", "Dalaba");
            hashtable68.Add("07", "Dinguiraye");
            hashtable68.Add("09", "Faranah");
            hashtable68.Add("10", "Forecariah");
            hashtable68.Add("11", "Fria");
            hashtable68.Add("12", "Gaoual");
            hashtable68.Add("13", "Gueckedou");
            hashtable68.Add("15", "Kerouane");
            hashtable68.Add("16", "Kindia");
            hashtable68.Add("17", "Kissidougou");
            hashtable68.Add("18", "Koundara");
            hashtable68.Add("19", "Kouroussa");
            hashtable68.Add("21", "Macenta");
            hashtable68.Add("22", "Mali");
            hashtable68.Add("23", "Mamou");
            hashtable68.Add("25", "Pita");
            hashtable68.Add("27", "Telimele");
            hashtable68.Add("28", "Tougue");
            hashtable68.Add("29", "Yomou");
            hashtable68.Add("30", "Coyah");
            hashtable68.Add("31", "Dubreka");
            hashtable68.Add("32", "Kankan");
            hashtable68.Add("33", "Koubia");
            hashtable68.Add("34", "Labe");
            hashtable68.Add("35", "Lelouma");
            hashtable68.Add("36", "Lola");
            hashtable68.Add("37", "Mandiana");
            hashtable68.Add("38", "Nzerekore");
            hashtable68.Add("39", "Siguiri");
            RegionName.hashtable_0.Add("GN", hashtable68);
            Hashtable hashtable69 = new Hashtable();
            hashtable69.Add("03", "Annobon");
            hashtable69.Add("04", "Bioko Norte");
            hashtable69.Add("05", "Bioko Sur");
            hashtable69.Add("06", "Centro Sur");
            hashtable69.Add("07", "Kie-Ntem");
            hashtable69.Add("08", "Litoral");
            hashtable69.Add("09", "Wele-Nzas");
            RegionName.hashtable_0.Add("GQ", hashtable69);
            Hashtable hashtable70 = new Hashtable();
            hashtable70.Add("01", "Evros");
            hashtable70.Add("02", "Rodhopi");
            hashtable70.Add("03", "Xanthi");
            hashtable70.Add("04", "Drama");
            hashtable70.Add("05", "Serrai");
            hashtable70.Add("06", "Kilkis");
            hashtable70.Add("07", "Pella");
            hashtable70.Add("08", "Florina");
            hashtable70.Add("09", "Kastoria");
            hashtable70.Add("10", "Grevena");
            hashtable70.Add("11", "Kozani");
            hashtable70.Add("12", "Imathia");
            hashtable70.Add("13", "Thessaloniki");
            hashtable70.Add("14", "Kavala");
            hashtable70.Add("15", "Khalkidhiki");
            hashtable70.Add("16", "Pieria");
            hashtable70.Add("17", "Ioannina");
            hashtable70.Add("18", "Thesprotia");
            hashtable70.Add("19", "Preveza");
            hashtable70.Add("20", "Arta");
            hashtable70.Add("21", "Larisa");
            hashtable70.Add("22", "Trikala");
            hashtable70.Add("23", "Kardhitsa");
            hashtable70.Add("24", "Magnisia");
            hashtable70.Add("25", "Kerkira");
            hashtable70.Add("26", "Levkas");
            hashtable70.Add("27", "Kefallinia");
            hashtable70.Add("28", "Zakinthos");
            hashtable70.Add("29", "Fthiotis");
            hashtable70.Add("30", "Evritania");
            hashtable70.Add("31", "Aitolia kai Akarnania");
            hashtable70.Add("32", "Fokis");
            hashtable70.Add("33", "Voiotia");
            hashtable70.Add("34", "Evvoia");
            hashtable70.Add("35", "Attiki");
            hashtable70.Add("36", "Argolis");
            hashtable70.Add("37", "Korinthia");
            hashtable70.Add("38", "Akhaia");
            hashtable70.Add("39", "Ilia");
            hashtable70.Add("40", "Messinia");
            hashtable70.Add("41", "Arkadhia");
            hashtable70.Add("42", "Lakonia");
            hashtable70.Add("43", "Khania");
            hashtable70.Add("44", "Rethimni");
            hashtable70.Add("45", "Iraklion");
            hashtable70.Add("46", "Lasithi");
            hashtable70.Add("47", "Dhodhekanisos");
            hashtable70.Add("48", "Samos");
            hashtable70.Add("49", "Kikladhes");
            hashtable70.Add("50", "Khios");
            hashtable70.Add("51", "Lesvos");
            RegionName.hashtable_0.Add("GR", hashtable70);
            Hashtable hashtable71 = new Hashtable();
            hashtable71.Add("01", "Alta Verapaz");
            hashtable71.Add("02", "Baja Verapaz");
            hashtable71.Add("03", "Chimaltenango");
            hashtable71.Add("04", "Chiquimula");
            hashtable71.Add("05", "El Progreso");
            hashtable71.Add("06", "Escuintla");
            hashtable71.Add("07", "Guatemala");
            hashtable71.Add("08", "Huehuetenango");
            hashtable71.Add("09", "Izabal");
            hashtable71.Add("10", "Jalapa");
            hashtable71.Add("11", "Jutiapa");
            hashtable71.Add("12", "Peten");
            hashtable71.Add("13", "Quetzaltenango");
            hashtable71.Add("14", "Quiche");
            hashtable71.Add("15", "Retalhuleu");
            hashtable71.Add("16", "Sacatepequez");
            hashtable71.Add("17", "San Marcos");
            hashtable71.Add("18", "Santa Rosa");
            hashtable71.Add("19", "Solola");
            hashtable71.Add("20", "Suchitepequez");
            hashtable71.Add("21", "Totonicapan");
            hashtable71.Add("22", "Zacapa");
            RegionName.hashtable_0.Add("GT", hashtable71);
            Hashtable hashtable72 = new Hashtable();
            hashtable72.Add("01", "Bafata");
            hashtable72.Add("02", "Quinara");
            hashtable72.Add("04", "Oio");
            hashtable72.Add("05", "Bolama");
            hashtable72.Add("06", "Cacheu");
            hashtable72.Add("07", "Tombali");
            hashtable72.Add("10", "Gabu");
            hashtable72.Add("11", "Bissau");
            hashtable72.Add("12", "Biombo");
            RegionName.hashtable_0.Add("GW", hashtable72);
            Hashtable hashtable73 = new Hashtable();
            hashtable73.Add("10", "Barima-Waini");
            hashtable73.Add("11", "Cuyuni-Mazaruni");
            hashtable73.Add("12", "Demerara-Mahaica");
            hashtable73.Add("13", "East Berbice-Corentyne");
            hashtable73.Add("14", "Essequibo Islands-West Demerara");
            hashtable73.Add("15", "Mahaica-Berbice");
            hashtable73.Add("16", "Pomeroon-Supenaam");
            hashtable73.Add("17", "Potaro-Siparuni");
            hashtable73.Add("18", "Upper Demerara-Berbice");
            hashtable73.Add("19", "Upper Takutu-Upper Essequibo");
            RegionName.hashtable_0.Add("GY", hashtable73);
            Hashtable hashtable74 = new Hashtable();
            hashtable74.Add("01", "Atlantida");
            hashtable74.Add("02", "Choluteca");
            hashtable74.Add("03", "Colon");
            hashtable74.Add("04", "Comayagua");
            hashtable74.Add("05", "Copan");
            hashtable74.Add("06", "Cortes");
            hashtable74.Add("07", "El Paraiso");
            hashtable74.Add("08", "Francisco Morazan");
            hashtable74.Add("09", "Gracias a Dios");
            hashtable74.Add("10", "Intibuca");
            hashtable74.Add("11", "Islas de la Bahia");
            hashtable74.Add("12", "La Paz");
            hashtable74.Add("13", "Lempira");
            hashtable74.Add("14", "Ocotepeque");
            hashtable74.Add("15", "Olancho");
            hashtable74.Add("16", "Santa Barbara");
            hashtable74.Add("17", "Valle");
            hashtable74.Add("18", "Yoro");
            RegionName.hashtable_0.Add("HN", hashtable74);
            Hashtable hashtable75 = new Hashtable();
            hashtable75.Add("01", "Bjelovarsko-Bilogorska");
            hashtable75.Add("02", "Brodsko-Posavska");
            hashtable75.Add("03", "Dubrovacko-Neretvanska");
            hashtable75.Add("04", "Istarska");
            hashtable75.Add("05", "Karlovacka");
            hashtable75.Add("06", "Koprivnicko-Krizevacka");
            hashtable75.Add("07", "Krapinsko-Zagorska");
            hashtable75.Add("08", "Licko-Senjska");
            hashtable75.Add("09", "Medimurska");
            hashtable75.Add("10", "Osjecko-Baranjska");
            hashtable75.Add("11", "Pozesko-Slavonska");
            hashtable75.Add("12", "Primorsko-Goranska");
            hashtable75.Add("13", "Sibensko-Kninska");
            hashtable75.Add("14", "Sisacko-Moslavacka");
            hashtable75.Add("15", "Splitsko-Dalmatinska");
            hashtable75.Add("16", "Varazdinska");
            hashtable75.Add("17", "Viroviticko-Podravska");
            hashtable75.Add("18", "Vukovarsko-Srijemska");
            hashtable75.Add("19", "Zadarska");
            hashtable75.Add("20", "Zagrebacka");
            hashtable75.Add("21", "Grad Zagreb");
            RegionName.hashtable_0.Add("HR", hashtable75);
            Hashtable hashtable76 = new Hashtable();
            hashtable76.Add("03", "Nord-Ouest");
            hashtable76.Add("06", "Artibonite");
            hashtable76.Add("07", "Centre");
            hashtable76.Add("09", "Nord");
            hashtable76.Add("10", "Nord-Est");
            hashtable76.Add("11", "Ouest");
            hashtable76.Add("12", "Sud");
            hashtable76.Add("13", "Sud-Est");
            hashtable76.Add("14", "Grand' Anse");
            hashtable76.Add("15", "Nippes");
            RegionName.hashtable_0.Add("HT", hashtable76);
            Hashtable hashtable77 = new Hashtable();
            hashtable77.Add("01", "Bacs-Kiskun");
            hashtable77.Add("02", "Baranya");
            hashtable77.Add("03", "Bekes");
            hashtable77.Add("04", "Borsod-Abauj-Zemplen");
            hashtable77.Add("05", "Budapest");
            hashtable77.Add("06", "Csongrad");
            hashtable77.Add("07", "Debrecen");
            hashtable77.Add("08", "Fejer");
            hashtable77.Add("09", "Gyor-Moson-Sopron");
            hashtable77.Add("10", "Hajdu-Bihar");
            hashtable77.Add("11", "Heves");
            hashtable77.Add("12", "Komarom-Esztergom");
            hashtable77.Add("13", "Miskolc");
            hashtable77.Add("14", "Nograd");
            hashtable77.Add("15", "Pecs");
            hashtable77.Add("16", "Pest");
            hashtable77.Add("17", "Somogy");
            hashtable77.Add("18", "Szabolcs-Szatmar-Bereg");
            hashtable77.Add("19", "Szeged");
            hashtable77.Add("20", "Jasz-Nagykun-Szolnok");
            hashtable77.Add("21", "Tolna");
            hashtable77.Add("22", "Vas");
            hashtable77.Add("23", "Veszprem");
            hashtable77.Add("24", "Zala");
            hashtable77.Add("25", "Gyor");
            hashtable77.Add("26", "Bekescsaba");
            hashtable77.Add("27", "Dunaujvaros");
            hashtable77.Add("28", "Eger");
            hashtable77.Add("29", "Hodmezovasarhely");
            hashtable77.Add("30", "Kaposvar");
            hashtable77.Add("31", "Kecskemet");
            hashtable77.Add("32", "Nagykanizsa");
            hashtable77.Add("33", "Nyiregyhaza");
            hashtable77.Add("34", "Sopron");
            hashtable77.Add("35", "Szekesfehervar");
            hashtable77.Add("36", "Szolnok");
            hashtable77.Add("37", "Szombathely");
            hashtable77.Add("38", "Tatabanya");
            hashtable77.Add("39", "Veszprem");
            hashtable77.Add("40", "Zalaegerszeg");
            hashtable77.Add("41", "Salgotarjan");
            hashtable77.Add("42", "Szekszard");
            hashtable77.Add("43", "Erd");
            RegionName.hashtable_0.Add("HU", hashtable77);
            Hashtable hashtable78 = new Hashtable();
            hashtable78.Add("01", "Aceh");
            hashtable78.Add("02", "Bali");
            hashtable78.Add("03", "Bengkulu");
            hashtable78.Add("04", "Jakarta Raya");
            hashtable78.Add("05", "Jambi");
            hashtable78.Add("07", "Jawa Tengah");
            hashtable78.Add("08", "Jawa Timur");
            hashtable78.Add("10", "Yogyakarta");
            hashtable78.Add("11", "Kalimantan Barat");
            hashtable78.Add("12", "Kalimantan Selatan");
            hashtable78.Add("13", "Kalimantan Tengah");
            hashtable78.Add("14", "Kalimantan Timur");
            hashtable78.Add("15", "Lampung");
            hashtable78.Add("17", "Nusa Tenggara Barat");
            hashtable78.Add("18", "Nusa Tenggara Timur");
            hashtable78.Add("21", "Sulawesi Tengah");
            hashtable78.Add("22", "Sulawesi Tenggara");
            hashtable78.Add("24", "Sumatera Barat");
            hashtable78.Add("26", "Sumatera Utara");
            hashtable78.Add("28", "Maluku");
            hashtable78.Add("29", "Maluku Utara");
            hashtable78.Add("30", "Jawa Barat");
            hashtable78.Add("31", "Sulawesi Utara");
            hashtable78.Add("32", "Sumatera Selatan");
            hashtable78.Add("33", "Banten");
            hashtable78.Add("34", "Gorontalo");
            hashtable78.Add("35", "Kepulauan Bangka Belitung");
            hashtable78.Add("36", "Papua");
            hashtable78.Add("37", "Riau");
            hashtable78.Add("38", "Sulawesi Selatan");
            hashtable78.Add("39", "Irian Jaya Barat");
            hashtable78.Add("40", "Kepulauan Riau");
            hashtable78.Add("41", "Sulawesi Barat");
            RegionName.hashtable_0.Add("ID", hashtable78);
            Hashtable hashtable79 = new Hashtable();
            hashtable79.Add("01", "Carlow");
            hashtable79.Add("02", "Cavan");
            hashtable79.Add("03", "Clare");
            hashtable79.Add("04", "Cork");
            hashtable79.Add("06", "Donegal");
            hashtable79.Add("07", "Dublin");
            hashtable79.Add("10", "Galway");
            hashtable79.Add("11", "Kerry");
            hashtable79.Add("12", "Kildare");
            hashtable79.Add("13", "Kilkenny");
            hashtable79.Add("14", "Leitrim");
            hashtable79.Add("15", "Laois");
            hashtable79.Add("16", "Limerick");
            hashtable79.Add("18", "Longford");
            hashtable79.Add("19", "Louth");
            hashtable79.Add("20", "Mayo");
            hashtable79.Add("21", "Meath");
            hashtable79.Add("22", "Monaghan");
            hashtable79.Add("23", "Offaly");
            hashtable79.Add("24", "Roscommon");
            hashtable79.Add("25", "Sligo");
            hashtable79.Add("26", "Tipperary");
            hashtable79.Add("27", "Waterford");
            hashtable79.Add("29", "Westmeath");
            hashtable79.Add("30", "Wexford");
            hashtable79.Add("31", "Wicklow");
            RegionName.hashtable_0.Add("IE", hashtable79);
            Hashtable hashtable80 = new Hashtable();
            hashtable80.Add("01", "HaDarom");
            hashtable80.Add("02", "HaMerkaz");
            hashtable80.Add("03", "HaZafon");
            hashtable80.Add("04", "Hefa");
            hashtable80.Add("05", "Tel Aviv");
            hashtable80.Add("06", "Yerushalayim");
            RegionName.hashtable_0.Add("IL", hashtable80);
            Hashtable hashtable81 = new Hashtable();
            hashtable81.Add("01", "Andaman and Nicobar Islands");
            hashtable81.Add("02", "Andhra Pradesh");
            hashtable81.Add("03", "Assam");
            hashtable81.Add("05", "Chandigarh");
            hashtable81.Add("06", "Dadra and Nagar Haveli");
            hashtable81.Add("07", "Delhi");
            hashtable81.Add("09", "Gujarat");
            hashtable81.Add("10", "Haryana");
            hashtable81.Add("11", "Himachal Pradesh");
            hashtable81.Add("12", "Jammu and Kashmir");
            hashtable81.Add("13", "Kerala");
            hashtable81.Add("14", "Lakshadweep");
            hashtable81.Add("16", "Maharashtra");
            hashtable81.Add("17", "Manipur");
            hashtable81.Add("18", "Meghalaya");
            hashtable81.Add("19", "Karnataka");
            hashtable81.Add("20", "Nagaland");
            hashtable81.Add("21", "Orissa");
            hashtable81.Add("22", "Puducherry");
            hashtable81.Add("23", "Punjab");
            hashtable81.Add("24", "Rajasthan");
            hashtable81.Add("25", "Tamil Nadu");
            hashtable81.Add("26", "Tripura");
            hashtable81.Add("28", "West Bengal");
            hashtable81.Add("29", "Sikkim");
            hashtable81.Add("30", "Arunachal Pradesh");
            hashtable81.Add("31", "Mizoram");
            hashtable81.Add("32", "Daman and Diu");
            hashtable81.Add("33", "Goa");
            hashtable81.Add("34", "Bihar");
            hashtable81.Add("35", "Madhya Pradesh");
            hashtable81.Add("36", "Uttar Pradesh");
            hashtable81.Add("37", "Chhattisgarh");
            hashtable81.Add("38", "Jharkhand");
            hashtable81.Add("39", "Uttarakhand");
            RegionName.hashtable_0.Add("IN", hashtable81);
            Hashtable hashtable82 = new Hashtable();
            hashtable82.Add("01", "Al Anbar");
            hashtable82.Add("02", "Al Basrah");
            hashtable82.Add("03", "Al Muthanna");
            hashtable82.Add("04", "Al Qadisiyah");
            hashtable82.Add("05", "As Sulaymaniyah");
            hashtable82.Add("06", "Babil");
            hashtable82.Add("07", "Baghdad");
            hashtable82.Add("08", "Dahuk");
            hashtable82.Add("09", "Dhi Qar");
            hashtable82.Add("10", "Diyala");
            hashtable82.Add("11", "Arbil");
            hashtable82.Add("12", "Karbala'");
            hashtable82.Add("13", "At Ta'mim");
            hashtable82.Add("14", "Maysan");
            hashtable82.Add("15", "Ninawa");
            hashtable82.Add("16", "Wasit");
            hashtable82.Add("17", "An Najaf");
            hashtable82.Add("18", "Salah ad Din");
            RegionName.hashtable_0.Add("IQ", hashtable82);
            Hashtable hashtable83 = new Hashtable();
            hashtable83.Add("01", "Azarbayjan-e Bakhtari");
            hashtable83.Add("03", "Chahar Mahall va Bakhtiari");
            hashtable83.Add("04", "Sistan va Baluchestan");
            hashtable83.Add("05", "Kohkiluyeh va Buyer Ahmadi");
            hashtable83.Add("07", "Fars");
            hashtable83.Add("08", "Gilan");
            hashtable83.Add("09", "Hamadan");
            hashtable83.Add("10", "Ilam");
            hashtable83.Add("11", "Hormozgan");
            hashtable83.Add("12", "Kerman");
            hashtable83.Add("13", "Bakhtaran");
            hashtable83.Add("15", "Khuzestan");
            hashtable83.Add("16", "Kordestan");
            hashtable83.Add("17", "Mazandaran");
            hashtable83.Add("18", "Semnan Province");
            hashtable83.Add("19", "Markazi");
            hashtable83.Add("21", "Zanjan");
            hashtable83.Add("22", "Bushehr");
            hashtable83.Add("23", "Lorestan");
            hashtable83.Add("24", "Markazi");
            hashtable83.Add("25", "Semnan");
            hashtable83.Add("26", "Tehran");
            hashtable83.Add("27", "Zanjan");
            hashtable83.Add("28", "Esfahan");
            hashtable83.Add("29", "Kerman");
            hashtable83.Add("30", "Khorasan");
            hashtable83.Add("31", "Yazd");
            hashtable83.Add("32", "Ardabil");
            hashtable83.Add("33", "East Azarbaijan");
            hashtable83.Add("34", "Markazi");
            hashtable83.Add("35", "Mazandaran");
            hashtable83.Add("36", "Zanjan");
            hashtable83.Add("37", "Golestan");
            hashtable83.Add("38", "Qazvin");
            hashtable83.Add("39", "Qom");
            hashtable83.Add("40", "Yazd");
            hashtable83.Add("41", "Khorasan-e Janubi");
            hashtable83.Add("42", "Khorasan-e Razavi");
            hashtable83.Add("43", "Khorasan-e Shemali");
            RegionName.hashtable_0.Add("IR", hashtable83);
            Hashtable hashtable84 = new Hashtable();
            hashtable84.Add("03", "Arnessysla");
            hashtable84.Add("05", "Austur-Hunavatnssysla");
            hashtable84.Add("06", "Austur-Skaftafellssysla");
            hashtable84.Add("07", "Borgarfjardarsysla");
            hashtable84.Add("09", "Eyjafjardarsysla");
            hashtable84.Add("10", "Gullbringusysla");
            hashtable84.Add("15", "Kjosarsysla");
            hashtable84.Add("17", "Myrasysla");
            hashtable84.Add("20", "Nordur-Mulasysla");
            hashtable84.Add("21", "Nordur-Tingeyjarsysla");
            hashtable84.Add("23", "Rangarvallasysla");
            hashtable84.Add("28", "Skagafjardarsysla");
            hashtable84.Add("29", "Snafellsnes- og Hnappadalssysla");
            hashtable84.Add("30", "Strandasysla");
            hashtable84.Add("31", "Sudur-Mulasysla");
            hashtable84.Add("32", "Sudur-Tingeyjarsysla");
            hashtable84.Add("34", "Vestur-Bardastrandarsysla");
            hashtable84.Add("35", "Vestur-Hunavatnssysla");
            hashtable84.Add("36", "Vestur-Isafjardarsysla");
            hashtable84.Add("37", "Vestur-Skaftafellssysla");
            hashtable84.Add("40", "Norourland Eystra");
            hashtable84.Add("41", "Norourland Vestra");
            hashtable84.Add("42", "Suourland");
            hashtable84.Add("43", "Suournes");
            hashtable84.Add("44", "Vestfiroir");
            hashtable84.Add("45", "Vesturland");
            RegionName.hashtable_0.Add("IS", hashtable84);
            Hashtable hashtable85 = new Hashtable();
            hashtable85.Add("01", "Abruzzi");
            hashtable85.Add("02", "Basilicata");
            hashtable85.Add("03", "Calabria");
            hashtable85.Add("04", "Campania");
            hashtable85.Add("05", "Emilia-Romagna");
            hashtable85.Add("06", "Friuli-Venezia Giulia");
            hashtable85.Add("07", "Lazio");
            hashtable85.Add("08", "Liguria");
            hashtable85.Add("09", "Lombardia");
            hashtable85.Add("10", "Marche");
            hashtable85.Add("11", "Molise");
            hashtable85.Add("12", "Piemonte");
            hashtable85.Add("13", "Puglia");
            hashtable85.Add("14", "Sardegna");
            hashtable85.Add("15", "Sicilia");
            hashtable85.Add("16", "Toscana");
            hashtable85.Add("17", "Trentino-Alto Adige");
            hashtable85.Add("18", "Umbria");
            hashtable85.Add("19", "Valle d'Aosta");
            hashtable85.Add("20", "Veneto");
            RegionName.hashtable_0.Add("IT", hashtable85);
            Hashtable hashtable86 = new Hashtable();
            hashtable86.Add("01", "Clarendon");
            hashtable86.Add("02", "Hanover");
            hashtable86.Add("04", "Manchester");
            hashtable86.Add("07", "Portland");
            hashtable86.Add("08", "Saint Andrew");
            hashtable86.Add("09", "Saint Ann");
            hashtable86.Add("10", "Saint Catherine");
            hashtable86.Add("11", "Saint Elizabeth");
            hashtable86.Add("12", "Saint James");
            hashtable86.Add("13", "Saint Mary");
            hashtable86.Add("14", "Saint Thomas");
            hashtable86.Add("15", "Trelawny");
            hashtable86.Add("16", "Westmoreland");
            hashtable86.Add("17", "Kingston");
            RegionName.hashtable_0.Add("JM", hashtable86);
            Hashtable hashtable87 = new Hashtable();
            hashtable87.Add("02", "Al Balqa'");
            hashtable87.Add("09", "Al Karak");
            hashtable87.Add("12", "At Tafilah");
            hashtable87.Add("15", "Al Mafraq");
            hashtable87.Add("16", "Amman");
            hashtable87.Add("17", "Az Zaraqa");
            hashtable87.Add("18", "Irbid");
            hashtable87.Add("19", "Ma'an");
            hashtable87.Add("20", "Ajlun");
            hashtable87.Add("21", "Al Aqabah");
            hashtable87.Add("22", "Jarash");
            hashtable87.Add("23", "Madaba");
            RegionName.hashtable_0.Add("JO", hashtable87);
            Hashtable hashtable88 = new Hashtable();
            hashtable88.Add("01", "Aichi");
            hashtable88.Add("02", "Akita");
            hashtable88.Add("03", "Aomori");
            hashtable88.Add("04", "Chiba");
            hashtable88.Add("05", "Ehime");
            hashtable88.Add("06", "Fukui");
            hashtable88.Add("07", "Fukuoka");
            hashtable88.Add("08", "Fukushima");
            hashtable88.Add("09", "Gifu");
            hashtable88.Add("10", "Gumma");
            hashtable88.Add("11", "Hiroshima");
            hashtable88.Add("12", "Hokkaido");
            hashtable88.Add("13", "Hyogo");
            hashtable88.Add("14", "Ibaraki");
            hashtable88.Add("15", "Ishikawa");
            hashtable88.Add("16", "Iwate");
            hashtable88.Add("17", "Kagawa");
            hashtable88.Add("18", "Kagoshima");
            hashtable88.Add("19", "Kanagawa");
            hashtable88.Add("20", "Kochi");
            hashtable88.Add("21", "Kumamoto");
            hashtable88.Add("22", "Kyoto");
            hashtable88.Add("23", "Mie");
            hashtable88.Add("24", "Miyagi");
            hashtable88.Add("25", "Miyazaki");
            hashtable88.Add("26", "Nagano");
            hashtable88.Add("27", "Nagasaki");
            hashtable88.Add("28", "Nara");
            hashtable88.Add("29", "Niigata");
            hashtable88.Add("30", "Oita");
            hashtable88.Add("31", "Okayama");
            hashtable88.Add("32", "Osaka");
            hashtable88.Add("33", "Saga");
            hashtable88.Add("34", "Saitama");
            hashtable88.Add("35", "Shiga");
            hashtable88.Add("36", "Shimane");
            hashtable88.Add("37", "Shizuoka");
            hashtable88.Add("38", "Tochigi");
            hashtable88.Add("39", "Tokushima");
            hashtable88.Add("40", "Tokyo");
            hashtable88.Add("41", "Tottori");
            hashtable88.Add("42", "Toyama");
            hashtable88.Add("43", "Wakayama");
            hashtable88.Add("44", "Yamagata");
            hashtable88.Add("45", "Yamaguchi");
            hashtable88.Add("46", "Yamanashi");
            hashtable88.Add("47", "Okinawa");
            RegionName.hashtable_0.Add("JP", hashtable88);
            Hashtable hashtable89 = new Hashtable();
            hashtable89.Add("01", "Central");
            hashtable89.Add("02", "Coast");
            hashtable89.Add("03", "Eastern");
            hashtable89.Add("05", "Nairobi Area");
            hashtable89.Add("06", "North-Eastern");
            hashtable89.Add("07", "Nyanza");
            hashtable89.Add("08", "Rift Valley");
            hashtable89.Add("09", "Western");
            RegionName.hashtable_0.Add("KE", hashtable89);
            Hashtable hashtable90 = new Hashtable();
            hashtable90.Add("01", "Bishkek");
            hashtable90.Add("02", "Chuy");
            hashtable90.Add("03", "Jalal-Abad");
            hashtable90.Add("04", "Naryn");
            hashtable90.Add("05", "Osh");
            hashtable90.Add("06", "Talas");
            hashtable90.Add("07", "Ysyk-Kol");
            hashtable90.Add("08", "Osh");
            hashtable90.Add("09", "Batken");
            RegionName.hashtable_0.Add("KG", hashtable90);
            Hashtable hashtable91 = new Hashtable();
            hashtable91.Add("01", "Batdambang");
            hashtable91.Add("02", "Kampong Cham");
            hashtable91.Add("03", "Kampong Chhnang");
            hashtable91.Add("04", "Kampong Speu");
            hashtable91.Add("05", "Kampong Thum");
            hashtable91.Add("06", "Kampot");
            hashtable91.Add("07", "Kandal");
            hashtable91.Add("08", "Koh Kong");
            hashtable91.Add("09", "Kracheh");
            hashtable91.Add("10", "Mondulkiri");
            hashtable91.Add("11", "Phnum Penh");
            hashtable91.Add("12", "Pursat");
            hashtable91.Add("13", "Preah Vihear");
            hashtable91.Add("14", "Prey Veng");
            hashtable91.Add("15", "Ratanakiri Kiri");
            hashtable91.Add("16", "Siem Reap");
            hashtable91.Add("17", "Stung Treng");
            hashtable91.Add("18", "Svay Rieng");
            hashtable91.Add("19", "Takeo");
            hashtable91.Add("25", "Banteay Meanchey");
            hashtable91.Add("29", "Batdambang");
            hashtable91.Add("30", "Pailin");
            RegionName.hashtable_0.Add("KH", hashtable91);
            Hashtable hashtable92 = new Hashtable();
            hashtable92.Add("01", "Gilbert Islands");
            hashtable92.Add("02", "Line Islands");
            hashtable92.Add("03", "Phoenix Islands");
            RegionName.hashtable_0.Add("KI", hashtable92);
            Hashtable hashtable93 = new Hashtable();
            hashtable93.Add("01", "Anjouan");
            hashtable93.Add("02", "Grande Comore");
            hashtable93.Add("03", "Moheli");
            RegionName.hashtable_0.Add("KM", hashtable93);
            Hashtable hashtable94 = new Hashtable();
            hashtable94.Add("01", "Christ Church Nichola Town");
            hashtable94.Add("02", "Saint Anne Sandy Point");
            hashtable94.Add("03", "Saint George Basseterre");
            hashtable94.Add("04", "Saint George Gingerland");
            hashtable94.Add("05", "Saint James Windward");
            hashtable94.Add("06", "Saint John Capisterre");
            hashtable94.Add("07", "Saint John Figtree");
            hashtable94.Add("08", "Saint Mary Cayon");
            hashtable94.Add("09", "Saint Paul Capisterre");
            hashtable94.Add("10", "Saint Paul Charlestown");
            hashtable94.Add("11", "Saint Peter Basseterre");
            hashtable94.Add("12", "Saint Thomas Lowland");
            hashtable94.Add("13", "Saint Thomas Middle Island");
            hashtable94.Add("15", "Trinity Palmetto Point");
            RegionName.hashtable_0.Add("KN", hashtable94);
            Hashtable hashtable95 = new Hashtable();
            hashtable95.Add("01", "Chagang-do");
            hashtable95.Add("03", "Hamgyong-namdo");
            hashtable95.Add("06", "Hwanghae-namdo");
            hashtable95.Add("07", "Hwanghae-bukto");
            hashtable95.Add("08", "Kaesong-si");
            hashtable95.Add("09", "Kangwon-do");
            hashtable95.Add("11", "P'yongan-bukto");
            hashtable95.Add("12", "P'yongyang-si");
            hashtable95.Add("13", "Yanggang-do");
            hashtable95.Add("14", "Namp'o-si");
            hashtable95.Add("15", "P'yongan-namdo");
            hashtable95.Add("17", "Hamgyong-bukto");
            hashtable95.Add("18", "Najin Sonbong-si");
            RegionName.hashtable_0.Add("KP", hashtable95);
            Hashtable hashtable96 = new Hashtable();
            hashtable96.Add("01", "Cheju-do");
            hashtable96.Add("03", "Cholla-bukto");
            hashtable96.Add("05", "Ch'ungch'ong-bukto");
            hashtable96.Add("06", "Kangwon-do");
            hashtable96.Add("10", "Pusan-jikhalsi");
            hashtable96.Add("11", "Seoul-t'ukpyolsi");
            hashtable96.Add("12", "Inch'on-jikhalsi");
            hashtable96.Add("13", "Kyonggi-do");
            hashtable96.Add("14", "Kyongsang-bukto");
            hashtable96.Add("15", "Taegu-jikhalsi");
            hashtable96.Add("16", "Cholla-namdo");
            hashtable96.Add("17", "Ch'ungch'ong-namdo");
            hashtable96.Add("18", "Kwangju-jikhalsi");
            hashtable96.Add("19", "Taejon-jikhalsi");
            hashtable96.Add("20", "Kyongsang-namdo");
            hashtable96.Add("21", "Ulsan-gwangyoksi");
            RegionName.hashtable_0.Add("KR", hashtable96);
            Hashtable hashtable97 = new Hashtable();
            hashtable97.Add("01", "Al Ahmadi");
            hashtable97.Add("02", "Al Kuwayt");
            hashtable97.Add("05", "Al Jahra");
            hashtable97.Add("07", "Al Farwaniyah");
            hashtable97.Add("08", "Hawalli");
            hashtable97.Add("09", "Mubarak al Kabir");
            RegionName.hashtable_0.Add("KW", hashtable97);
            Hashtable hashtable98 = new Hashtable();
            hashtable98.Add("01", "Creek");
            hashtable98.Add("02", "Eastern");
            hashtable98.Add("03", "Midland");
            hashtable98.Add("04", "South Town");
            hashtable98.Add("05", "Spot Bay");
            hashtable98.Add("06", "Stake Bay");
            hashtable98.Add("07", "West End");
            hashtable98.Add("08", "Western");
            RegionName.hashtable_0.Add("KY", hashtable98);
            Hashtable hashtable99 = new Hashtable();
            hashtable99.Add("01", "Almaty");
            hashtable99.Add("02", "Almaty City");
            hashtable99.Add("03", "Aqmola");
            hashtable99.Add("04", "Aqtobe");
            hashtable99.Add("05", "Astana");
            hashtable99.Add("06", "Atyrau");
            hashtable99.Add("07", "West Kazakhstan");
            hashtable99.Add("08", "Bayqonyr");
            hashtable99.Add("09", "Mangghystau");
            hashtable99.Add("10", "South Kazakhstan");
            hashtable99.Add("11", "Pavlodar");
            hashtable99.Add("12", "Qaraghandy");
            hashtable99.Add("13", "Qostanay");
            hashtable99.Add("14", "Qyzylorda");
            hashtable99.Add("15", "East Kazakhstan");
            hashtable99.Add("16", "North Kazakhstan");
            hashtable99.Add("17", "Zhambyl");
            RegionName.hashtable_0.Add("KZ", hashtable99);
            Hashtable hashtable100 = new Hashtable();
            hashtable100.Add("01", "Attapu");
            hashtable100.Add("02", "Champasak");
            hashtable100.Add("03", "Houaphan");
            hashtable100.Add("04", "Khammouan");
            hashtable100.Add("05", "Louang Namtha");
            hashtable100.Add("07", "Oudomxai");
            hashtable100.Add("08", "Phongsali");
            hashtable100.Add("09", "Saravan");
            hashtable100.Add("10", "Savannakhet");
            hashtable100.Add("11", "Vientiane");
            hashtable100.Add("13", "Xaignabouri");
            hashtable100.Add("14", "Xiangkhoang");
            hashtable100.Add("17", "Louangphrabang");
            RegionName.hashtable_0.Add("LA", hashtable100);
            Hashtable hashtable101 = new Hashtable();
            hashtable101.Add("01", "Beqaa");
            hashtable101.Add("02", "Al Janub");
            hashtable101.Add("03", "Liban-Nord");
            hashtable101.Add("04", "Beyrouth");
            hashtable101.Add("05", "Mont-Liban");
            hashtable101.Add("06", "Liban-Sud");
            hashtable101.Add("07", "Nabatiye");
            hashtable101.Add("08", "Beqaa");
            hashtable101.Add("09", "Liban-Nord");
            hashtable101.Add("10", "Aakk,r");
            hashtable101.Add("11", "Baalbek-Hermel");
            RegionName.hashtable_0.Add("LB", hashtable101);
            Hashtable hashtable102 = new Hashtable();
            hashtable102.Add("01", "Anse-la-Raye");
            hashtable102.Add("02", "Dauphin");
            hashtable102.Add("03", "Castries");
            hashtable102.Add("04", "Choiseul");
            hashtable102.Add("05", "Dennery");
            hashtable102.Add("06", "Gros-Islet");
            hashtable102.Add("07", "Laborie");
            hashtable102.Add("08", "Micoud");
            hashtable102.Add("09", "Soufriere");
            hashtable102.Add("10", "Vieux-Fort");
            hashtable102.Add("11", "Praslin");
            RegionName.hashtable_0.Add("LC", hashtable102);
            Hashtable hashtable103 = new Hashtable();
            hashtable103.Add("01", "Balzers");
            hashtable103.Add("02", "Eschen");
            hashtable103.Add("03", "Gamprin");
            hashtable103.Add("04", "Mauren");
            hashtable103.Add("05", "Planken");
            hashtable103.Add("06", "Ruggell");
            hashtable103.Add("07", "Schaan");
            hashtable103.Add("08", "Schellenberg");
            hashtable103.Add("09", "Triesen");
            hashtable103.Add("10", "Triesenberg");
            hashtable103.Add("11", "Vaduz");
            hashtable103.Add("21", "Gbarpolu");
            hashtable103.Add("22", "River Gee");
            RegionName.hashtable_0.Add("LI", hashtable103);
            Hashtable hashtable104 = new Hashtable();
            hashtable104.Add("01", "Amparai");
            hashtable104.Add("02", "Anuradhapura");
            hashtable104.Add("03", "Badulla");
            hashtable104.Add("04", "Batticaloa");
            hashtable104.Add("06", "Galle");
            hashtable104.Add("07", "Hambantota");
            hashtable104.Add("09", "Kalutara");
            hashtable104.Add("10", "Kandy");
            hashtable104.Add("11", "Kegalla");
            hashtable104.Add("12", "Kurunegala");
            hashtable104.Add("14", "Matale");
            hashtable104.Add("15", "Matara");
            hashtable104.Add("16", "Moneragala");
            hashtable104.Add("17", "Nuwara Eliya");
            hashtable104.Add("18", "Polonnaruwa");
            hashtable104.Add("19", "Puttalam");
            hashtable104.Add("20", "Ratnapura");
            hashtable104.Add("21", "Trincomalee");
            hashtable104.Add("23", "Colombo");
            hashtable104.Add("24", "Gampaha");
            hashtable104.Add("25", "Jaffna");
            hashtable104.Add("26", "Mannar");
            hashtable104.Add("27", "Mullaittivu");
            hashtable104.Add("28", "Vavuniya");
            hashtable104.Add("29", "Central");
            hashtable104.Add("30", "North Central");
            hashtable104.Add("31", "Northern");
            hashtable104.Add("32", "North Western");
            hashtable104.Add("33", "Sabaragamuwa");
            hashtable104.Add("34", "Southern");
            hashtable104.Add("35", "Uva");
            hashtable104.Add("36", "Western");
            RegionName.hashtable_0.Add("LK", hashtable104);
            Hashtable hashtable105 = new Hashtable();
            hashtable105.Add("01", "Bong");
            hashtable105.Add("04", "Grand Cape Mount");
            hashtable105.Add("05", "Lofa");
            hashtable105.Add("06", "Maryland");
            hashtable105.Add("07", "Monrovia");
            hashtable105.Add("09", "Nimba");
            hashtable105.Add("10", "Sino");
            hashtable105.Add("11", "Grand Bassa");
            hashtable105.Add("12", "Grand Cape Mount");
            hashtable105.Add("13", "Maryland");
            hashtable105.Add("14", "Montserrado");
            hashtable105.Add("17", "Margibi");
            hashtable105.Add("18", "River Cess");
            hashtable105.Add("19", "Grand Gedeh");
            hashtable105.Add("20", "Lofa");
            hashtable105.Add("21", "Gbarpolu");
            hashtable105.Add("22", "River Gee");
            RegionName.hashtable_0.Add("LR", hashtable105);
            Hashtable hashtable106 = new Hashtable();
            hashtable106.Add("10", "Berea");
            hashtable106.Add("11", "Butha-Buthe");
            hashtable106.Add("12", "Leribe");
            hashtable106.Add("13", "Mafeteng");
            hashtable106.Add("14", "Maseru");
            hashtable106.Add("15", "Mohales Hoek");
            hashtable106.Add("16", "Mokhotlong");
            hashtable106.Add("17", "Qachas Nek");
            hashtable106.Add("18", "Quthing");
            hashtable106.Add("19", "Thaba-Tseka");
            RegionName.hashtable_0.Add("LS", hashtable106);
            Hashtable hashtable107 = new Hashtable();
            hashtable107.Add("56", "Alytaus Apskritis");
            hashtable107.Add("57", "Kauno Apskritis");
            hashtable107.Add("58", "Klaipedos Apskritis");
            hashtable107.Add("59", "Marijampoles Apskritis");
            hashtable107.Add("60", "Panevezio Apskritis");
            hashtable107.Add("61", "Siauliu Apskritis");
            hashtable107.Add("62", "Taurages Apskritis");
            hashtable107.Add("63", "Telsiu Apskritis");
            hashtable107.Add("64", "Utenos Apskritis");
            hashtable107.Add("65", "Vilniaus Apskritis");
            RegionName.hashtable_0.Add("LT", hashtable107);
            Hashtable hashtable108 = new Hashtable();
            hashtable108.Add("01", "Diekirch");
            hashtable108.Add("02", "Grevenmacher");
            hashtable108.Add("03", "Luxembourg");
            RegionName.hashtable_0.Add("LU", hashtable108);
            Hashtable hashtable109 = new Hashtable();
            hashtable109.Add("01", "Aizkraukles");
            hashtable109.Add("02", "Aluksnes");
            hashtable109.Add("03", "Balvu");
            hashtable109.Add("04", "Bauskas");
            hashtable109.Add("05", "Cesu");
            hashtable109.Add("06", "Daugavpils");
            hashtable109.Add("07", "Daugavpils");
            hashtable109.Add("08", "Dobeles");
            hashtable109.Add("09", "Gulbenes");
            hashtable109.Add("10", "Jekabpils");
            hashtable109.Add("11", "Jelgava");
            hashtable109.Add("12", "Jelgavas");
            hashtable109.Add("13", "Jurmala");
            hashtable109.Add("14", "Kraslavas");
            hashtable109.Add("15", "Kuldigas");
            hashtable109.Add("16", "Liepaja");
            hashtable109.Add("17", "Liepajas");
            hashtable109.Add("18", "Limbazu");
            hashtable109.Add("19", "Ludzas");
            hashtable109.Add("20", "Madonas");
            hashtable109.Add("21", "Ogres");
            hashtable109.Add("22", "Preilu");
            hashtable109.Add("23", "Rezekne");
            hashtable109.Add("24", "Rezeknes");
            hashtable109.Add("25", "Riga");
            hashtable109.Add("26", "Rigas");
            hashtable109.Add("27", "Saldus");
            hashtable109.Add("28", "Talsu");
            hashtable109.Add("29", "Tukuma");
            hashtable109.Add("30", "Valkas");
            hashtable109.Add("31", "Valmieras");
            hashtable109.Add("32", "Ventspils");
            hashtable109.Add("33", "Ventspils");
            RegionName.hashtable_0.Add("LV", hashtable109);
            Hashtable hashtable110 = new Hashtable();
            hashtable110.Add("03", "Al Aziziyah");
            hashtable110.Add("05", "Al Jufrah");
            hashtable110.Add("08", "Al Kufrah");
            hashtable110.Add("13", "Ash Shati'");
            hashtable110.Add("30", "Murzuq");
            hashtable110.Add("34", "Sabha");
            hashtable110.Add("41", "Tarhunah");
            hashtable110.Add("42", "Tubruq");
            hashtable110.Add("45", "Zlitan");
            hashtable110.Add("47", "Ajdabiya");
            hashtable110.Add("48", "Al Fatih");
            hashtable110.Add("49", "Al Jabal al Akhdar");
            hashtable110.Add("50", "Al Khums");
            hashtable110.Add("51", "An Nuqat al Khams");
            hashtable110.Add("52", "Awbari");
            hashtable110.Add("53", "Az Zawiyah");
            hashtable110.Add("54", "Banghazi");
            hashtable110.Add("55", "Darnah");
            hashtable110.Add("56", "Ghadamis");
            hashtable110.Add("57", "Gharyan");
            hashtable110.Add("58", "Misratah");
            hashtable110.Add("59", "Sawfajjin");
            hashtable110.Add("60", "Surt");
            hashtable110.Add("61", "Tarabulus");
            hashtable110.Add("62", "Yafran");
            RegionName.hashtable_0.Add("LY", hashtable110);
            Hashtable hashtable111 = new Hashtable();
            hashtable111.Add("45", "Grand Casablanca");
            hashtable111.Add("46", "Fes-Boulemane");
            hashtable111.Add("47", "Marrakech-Tensift-Al Haouz");
            hashtable111.Add("48", "Meknes-Tafilalet");
            hashtable111.Add("49", "Rabat-Sale-Zemmour-Zaer");
            hashtable111.Add("50", "Chaouia-Ouardigha");
            hashtable111.Add("51", "Doukkala-Abda");
            hashtable111.Add("52", "Gharb-Chrarda-Beni Hssen");
            hashtable111.Add("53", "Guelmim-Es Smara");
            hashtable111.Add("54", "Oriental");
            hashtable111.Add("55", "Souss-Massa-Dr,a");
            hashtable111.Add("56", "Tadla-Azilal");
            hashtable111.Add("57", "Tanger-Tetouan");
            hashtable111.Add("58", "Taza-Al Hoceima-Taounate");
            hashtable111.Add("59", "La,youne-Boujdour-Sakia El Hamra");
            RegionName.hashtable_0.Add("MA", hashtable111);
            Hashtable hashtable112 = new Hashtable();
            hashtable112.Add("01", "La Condamine");
            hashtable112.Add("02", "Monaco");
            hashtable112.Add("03", "Monte-Carlo");
            RegionName.hashtable_0.Add("MC", hashtable112);
            Hashtable hashtable113 = new Hashtable();
            hashtable113.Add("51", "Gagauzia");
            hashtable113.Add("57", "Chisinau");
            hashtable113.Add("58", "Stinga Nistrului");
            hashtable113.Add("59", "Anenii Noi");
            hashtable113.Add("60", "Balti");
            hashtable113.Add("61", "Basarabeasca");
            hashtable113.Add("62", "Bender");
            hashtable113.Add("63", "Briceni");
            hashtable113.Add("64", "Cahul");
            hashtable113.Add("65", "Cantemir");
            hashtable113.Add("66", "Calarasi");
            hashtable113.Add("67", "Causeni");
            hashtable113.Add("68", "Cimislia");
            hashtable113.Add("69", "Criuleni");
            hashtable113.Add("70", "Donduseni");
            hashtable113.Add("71", "Drochia");
            hashtable113.Add("72", "Dubasari");
            hashtable113.Add("73", "Edinet");
            hashtable113.Add("74", "Falesti");
            hashtable113.Add("75", "Floresti");
            hashtable113.Add("76", "Glodeni");
            hashtable113.Add("77", "Hincesti");
            hashtable113.Add("78", "Ialoveni");
            hashtable113.Add("79", "Leova");
            hashtable113.Add("80", "Nisporeni");
            hashtable113.Add("81", "Ocnita");
            hashtable113.Add("82", "Orhei");
            hashtable113.Add("83", "Rezina");
            hashtable113.Add("84", "Riscani");
            hashtable113.Add("85", "Singerei");
            hashtable113.Add("86", "Soldanesti");
            hashtable113.Add("87", "Soroca");
            hashtable113.Add("88", "Stefan-Voda");
            hashtable113.Add("89", "Straseni");
            hashtable113.Add("90", "Taraclia");
            hashtable113.Add("91", "Telenesti");
            hashtable113.Add("92", "Ungheni");
            RegionName.hashtable_0.Add("MD", hashtable113);
            Hashtable hashtable114 = new Hashtable();
            hashtable114.Add("01", "Antsiranana");
            hashtable114.Add("02", "Fianarantsoa");
            hashtable114.Add("03", "Mahajanga");
            hashtable114.Add("04", "Toamasina");
            hashtable114.Add("05", "Antananarivo");
            hashtable114.Add("06", "Toliara");
            RegionName.hashtable_0.Add("MG", hashtable114);
            Hashtable hashtable115 = new Hashtable();
            hashtable115.Add("01", "Aracinovo");
            hashtable115.Add("02", "Bac");
            hashtable115.Add("03", "Belcista");
            hashtable115.Add("04", "Berovo");
            hashtable115.Add("05", "Bistrica");
            hashtable115.Add("06", "Bitola");
            hashtable115.Add("07", "Blatec");
            hashtable115.Add("08", "Bogdanci");
            hashtable115.Add("09", "Bogomila");
            hashtable115.Add("10", "Bogovinje");
            hashtable115.Add("11", "Bosilovo");
            hashtable115.Add("12", "Brvenica");
            hashtable115.Add("13", "Cair");
            hashtable115.Add("14", "Capari");
            hashtable115.Add("15", "Caska");
            hashtable115.Add("16", "Cegrane");
            hashtable115.Add("17", "Centar");
            hashtable115.Add("18", "Centar Zupa");
            hashtable115.Add("19", "Cesinovo");
            hashtable115.Add("20", "Cucer-Sandevo");
            hashtable115.Add("21", "Debar");
            hashtable115.Add("22", "Delcevo");
            hashtable115.Add("23", "Delogozdi");
            hashtable115.Add("24", "Demir Hisar");
            hashtable115.Add("25", "Demir Kapija");
            hashtable115.Add("26", "Dobrusevo");
            hashtable115.Add("27", "Dolna Banjica");
            hashtable115.Add("28", "Dolneni");
            hashtable115.Add("29", "Dorce Petrov");
            hashtable115.Add("30", "Drugovo");
            hashtable115.Add("31", "Dzepciste");
            hashtable115.Add("32", "Gazi Baba");
            hashtable115.Add("33", "Gevgelija");
            hashtable115.Add("34", "Gostivar");
            hashtable115.Add("35", "Gradsko");
            hashtable115.Add("36", "Ilinden");
            hashtable115.Add("37", "Izvor");
            hashtable115.Add("38", "Jegunovce");
            hashtable115.Add("39", "Kamenjane");
            hashtable115.Add("40", "Karbinci");
            hashtable115.Add("41", "Karpos");
            hashtable115.Add("42", "Kavadarci");
            hashtable115.Add("43", "Kicevo");
            hashtable115.Add("44", "Kisela Voda");
            hashtable115.Add("45", "Klecevce");
            hashtable115.Add("46", "Kocani");
            hashtable115.Add("47", "Konce");
            hashtable115.Add("48", "Kondovo");
            hashtable115.Add("49", "Konopiste");
            hashtable115.Add("50", "Kosel");
            hashtable115.Add("51", "Kratovo");
            hashtable115.Add("52", "Kriva Palanka");
            hashtable115.Add("53", "Krivogastani");
            hashtable115.Add("54", "Krusevo");
            hashtable115.Add("55", "Kuklis");
            hashtable115.Add("56", "Kukurecani");
            hashtable115.Add("57", "Kumanovo");
            hashtable115.Add("58", "Labunista");
            hashtable115.Add("59", "Lipkovo");
            hashtable115.Add("60", "Lozovo");
            hashtable115.Add("61", "Lukovo");
            hashtable115.Add("62", "Makedonska Kamenica");
            hashtable115.Add("63", "Makedonski Brod");
            hashtable115.Add("64", "Mavrovi Anovi");
            hashtable115.Add("65", "Meseista");
            hashtable115.Add("66", "Miravci");
            hashtable115.Add("67", "Mogila");
            hashtable115.Add("68", "Murtino");
            hashtable115.Add("69", "Negotino");
            hashtable115.Add("70", "Negotino-Polosko");
            hashtable115.Add("71", "Novaci");
            hashtable115.Add("72", "Novo Selo");
            hashtable115.Add("73", "Oblesevo");
            hashtable115.Add("74", "Ohrid");
            hashtable115.Add("75", "Orasac");
            hashtable115.Add("76", "Orizari");
            hashtable115.Add("77", "Oslomej");
            hashtable115.Add("78", "Pehcevo");
            hashtable115.Add("79", "Petrovec");
            hashtable115.Add("80", "Plasnica");
            hashtable115.Add("81", "Podares");
            hashtable115.Add("82", "Prilep");
            hashtable115.Add("83", "Probistip");
            hashtable115.Add("84", "Radovis");
            hashtable115.Add("85", "Rankovce");
            hashtable115.Add("86", "Resen");
            hashtable115.Add("87", "Rosoman");
            hashtable115.Add("88", "Rostusa");
            hashtable115.Add("89", "Samokov");
            hashtable115.Add("90", "Saraj");
            hashtable115.Add("91", "Sipkovica");
            hashtable115.Add("92", "Sopiste");
            hashtable115.Add("93", "Sopotnica");
            hashtable115.Add("94", "Srbinovo");
            hashtable115.Add("95", "Staravina");
            hashtable115.Add("96", "Star Dojran");
            hashtable115.Add("97", "Staro Nagoricane");
            hashtable115.Add("98", "Stip");
            hashtable115.Add("99", "Struga");
            hashtable115.Add("A1", "Strumica");
            hashtable115.Add("A2", "Studenicani");
            hashtable115.Add("A3", "Suto Orizari");
            hashtable115.Add("A4", "Sveti Nikole");
            hashtable115.Add("A5", "Tearce");
            hashtable115.Add("A6", "Tetovo");
            hashtable115.Add("A7", "Topolcani");
            hashtable115.Add("A8", "Valandovo");
            hashtable115.Add("A9", "Vasilevo");
            hashtable115.Add("B1", "Veles");
            hashtable115.Add("B2", "Velesta");
            hashtable115.Add("B3", "Vevcani");
            hashtable115.Add("B4", "Vinica");
            hashtable115.Add("B5", "Vitoliste");
            hashtable115.Add("B6", "Vranestica");
            hashtable115.Add("B7", "Vrapciste");
            hashtable115.Add("B8", "Vratnica");
            hashtable115.Add("B9", "Vrutok");
            hashtable115.Add("C1", "Zajas");
            hashtable115.Add("C2", "Zelenikovo");
            hashtable115.Add("C3", "Zelino");
            hashtable115.Add("C4", "Zitose");
            hashtable115.Add("C5", "Zletovo");
            hashtable115.Add("C6", "Zrnovci");
            RegionName.hashtable_0.Add("MK", hashtable115);
            Hashtable hashtable116 = new Hashtable();
            hashtable116.Add("01", "Bamako");
            hashtable116.Add("03", "Kayes");
            hashtable116.Add("04", "Mopti");
            hashtable116.Add("05", "Segou");
            hashtable116.Add("06", "Sikasso");
            hashtable116.Add("07", "Koulikoro");
            hashtable116.Add("08", "Tombouctou");
            hashtable116.Add("09", "Gao");
            hashtable116.Add("10", "Kidal");
            RegionName.hashtable_0.Add("ML", hashtable116);
            Hashtable hashtable117 = new Hashtable();
            hashtable117.Add("01", "Rakhine State");
            hashtable117.Add("02", "Chin State");
            hashtable117.Add("03", "Irrawaddy");
            hashtable117.Add("04", "Kachin State");
            hashtable117.Add("05", "Karan State");
            hashtable117.Add("06", "Kayah State");
            hashtable117.Add("07", "Magwe");
            hashtable117.Add("08", "Mandalay");
            hashtable117.Add("09", "Pegu");
            hashtable117.Add("10", "Sagaing");
            hashtable117.Add("11", "Shan State");
            hashtable117.Add("12", "Tenasserim");
            hashtable117.Add("13", "Mon State");
            hashtable117.Add("14", "Rangoon");
            hashtable117.Add("17", "Yangon");
            RegionName.hashtable_0.Add("MM", hashtable117);
            Hashtable hashtable118 = new Hashtable();
            hashtable118.Add("01", "Arhangay");
            hashtable118.Add("02", "Bayanhongor");
            hashtable118.Add("03", "Bayan-Olgiy");
            hashtable118.Add("05", "Darhan");
            hashtable118.Add("06", "Dornod");
            hashtable118.Add("07", "Dornogovi");
            hashtable118.Add("08", "Dundgovi");
            hashtable118.Add("09", "Dzavhan");
            hashtable118.Add("10", "Govi-Altay");
            hashtable118.Add("11", "Hentiy");
            hashtable118.Add("12", "Hovd");
            hashtable118.Add("13", "Hovsgol");
            hashtable118.Add("14", "Omnogovi");
            hashtable118.Add("15", "Ovorhangay");
            hashtable118.Add("16", "Selenge");
            hashtable118.Add("17", "Suhbaatar");
            hashtable118.Add("18", "Tov");
            hashtable118.Add("19", "Uvs");
            hashtable118.Add("20", "Ulaanbaatar");
            hashtable118.Add("21", "Bulgan");
            hashtable118.Add("22", "Erdenet");
            hashtable118.Add("23", "Darhan-Uul");
            hashtable118.Add("24", "Govisumber");
            hashtable118.Add("25", "Orhon");
            RegionName.hashtable_0.Add("MN", hashtable118);
            Hashtable hashtable119 = new Hashtable();
            hashtable119.Add("01", "Ilhas");
            hashtable119.Add("02", "Macau");
            RegionName.hashtable_0.Add("MO", hashtable119);
            Hashtable hashtable120 = new Hashtable();
            hashtable120.Add("01", "Hodh Ech Chargui");
            hashtable120.Add("02", "Hodh El Gharbi");
            hashtable120.Add("03", "Assaba");
            hashtable120.Add("04", "Gorgol");
            hashtable120.Add("05", "Brakna");
            hashtable120.Add("06", "Trarza");
            hashtable120.Add("07", "Adrar");
            hashtable120.Add("08", "Dakhlet Nouadhibou");
            hashtable120.Add("09", "Tagant");
            hashtable120.Add("10", "Guidimaka");
            hashtable120.Add("11", "Tiris Zemmour");
            hashtable120.Add("12", "Inchiri");
            RegionName.hashtable_0.Add("MR", hashtable120);
            Hashtable hashtable121 = new Hashtable();
            hashtable121.Add("01", "Saint Anthony");
            hashtable121.Add("02", "Saint Georges");
            hashtable121.Add("03", "Saint Peter");
            RegionName.hashtable_0.Add("MS", hashtable121);
            Hashtable hashtable122 = new Hashtable();
            hashtable122.Add("12", "Black River");
            hashtable122.Add("13", "Flacq");
            hashtable122.Add("14", "Grand Port");
            hashtable122.Add("15", "Moka");
            hashtable122.Add("16", "Pamplemousses");
            hashtable122.Add("17", "Plaines Wilhems");
            hashtable122.Add("18", "Port Louis");
            hashtable122.Add("19", "Riviere du Rempart");
            hashtable122.Add("20", "Savanne");
            hashtable122.Add("21", "Agalega Islands");
            hashtable122.Add("22", "Cargados Carajos");
            hashtable122.Add("23", "Rodrigues");
            RegionName.hashtable_0.Add("MU", hashtable122);
            Hashtable hashtable123 = new Hashtable();
            hashtable123.Add("01", "Seenu");
            hashtable123.Add("05", "Laamu");
            hashtable123.Add("30", "Alifu");
            hashtable123.Add("31", "Baa");
            hashtable123.Add("32", "Dhaalu");
            hashtable123.Add("33", "Faafu ");
            hashtable123.Add("34", "Gaafu Alifu");
            hashtable123.Add("35", "Gaafu Dhaalu");
            hashtable123.Add("36", "Haa Alifu");
            hashtable123.Add("37", "Haa Dhaalu");
            hashtable123.Add("38", "Kaafu");
            hashtable123.Add("39", "Lhaviyani");
            hashtable123.Add("40", "Maale");
            hashtable123.Add("41", "Meemu");
            hashtable123.Add("42", "Gnaviyani");
            hashtable123.Add("43", "Noonu");
            hashtable123.Add("44", "Raa");
            hashtable123.Add("45", "Shaviyani");
            hashtable123.Add("46", "Thaa");
            hashtable123.Add("47", "Vaavu");
            RegionName.hashtable_0.Add("MV", hashtable123);
            Hashtable hashtable124 = new Hashtable();
            hashtable124.Add("02", "Chikwawa");
            hashtable124.Add("03", "Chiradzulu");
            hashtable124.Add("04", "Chitipa");
            hashtable124.Add("05", "Thyolo");
            hashtable124.Add("06", "Dedza");
            hashtable124.Add("07", "Dowa");
            hashtable124.Add("08", "Karonga");
            hashtable124.Add("09", "Kasungu");
            hashtable124.Add("11", "Lilongwe");
            hashtable124.Add("12", "Mangochi");
            hashtable124.Add("13", "Mchinji");
            hashtable124.Add("15", "Mzimba");
            hashtable124.Add("16", "Ntcheu");
            hashtable124.Add("17", "Nkhata Bay");
            hashtable124.Add("18", "Nkhotakota");
            hashtable124.Add("19", "Nsanje");
            hashtable124.Add("20", "Ntchisi");
            hashtable124.Add("21", "Rumphi");
            hashtable124.Add("22", "Salima");
            hashtable124.Add("23", "Zomba");
            hashtable124.Add("24", "Blantyre");
            hashtable124.Add("25", "Mwanza");
            hashtable124.Add("26", "Balaka");
            hashtable124.Add("27", "Likoma");
            hashtable124.Add("28", "Machinga");
            hashtable124.Add("29", "Mulanje");
            hashtable124.Add("30", "Phalombe");
            RegionName.hashtable_0.Add("MW", hashtable124);
            Hashtable hashtable125 = new Hashtable();
            hashtable125.Add("01", "Aguascalientes");
            hashtable125.Add("02", "Baja California");
            hashtable125.Add("03", "Baja California Sur");
            hashtable125.Add("04", "Campeche");
            hashtable125.Add("05", "Chiapas");
            hashtable125.Add("06", "Chihuahua");
            hashtable125.Add("07", "Coahuila de Zaragoza");
            hashtable125.Add("08", "Colima");
            hashtable125.Add("09", "Distrito Federal");
            hashtable125.Add("10", "Durango");
            hashtable125.Add("11", "Guanajuato");
            hashtable125.Add("12", "Guerrero");
            hashtable125.Add("13", "Hidalgo");
            hashtable125.Add("14", "Jalisco");
            hashtable125.Add("15", "Mexico");
            hashtable125.Add("16", "Michoacan de Ocampo");
            hashtable125.Add("17", "Morelos");
            hashtable125.Add("18", "Nayarit");
            hashtable125.Add("19", "Nuevo Leon");
            hashtable125.Add("20", "Oaxaca");
            hashtable125.Add("21", "Puebla");
            hashtable125.Add("22", "Queretaro de Arteaga");
            hashtable125.Add("23", "Quintana Roo");
            hashtable125.Add("24", "San Luis Potosi");
            hashtable125.Add("25", "Sinaloa");
            hashtable125.Add("26", "Sonora");
            hashtable125.Add("27", "Tabasco");
            hashtable125.Add("28", "Tamaulipas");
            hashtable125.Add("29", "Tlaxcala");
            hashtable125.Add("30", "Veracruz-Llave");
            hashtable125.Add("31", "Yucatan");
            hashtable125.Add("32", "Zacatecas");
            RegionName.hashtable_0.Add("MX", hashtable125);
            Hashtable hashtable126 = new Hashtable();
            hashtable126.Add("01", "Johor");
            hashtable126.Add("02", "Kedah");
            hashtable126.Add("03", "Kelantan");
            hashtable126.Add("04", "Melaka");
            hashtable126.Add("05", "Negeri Sembilan");
            hashtable126.Add("06", "Pahang");
            hashtable126.Add("07", "Perak");
            hashtable126.Add("08", "Perlis");
            hashtable126.Add("09", "Pulau Pinang");
            hashtable126.Add("11", "Sarawak");
            hashtable126.Add("12", "Selangor");
            hashtable126.Add("13", "Terengganu");
            hashtable126.Add("14", "Kuala Lumpur");
            hashtable126.Add("15", "Labuan");
            hashtable126.Add("16", "Sabah");
            hashtable126.Add("17", "Putrajaya");
            RegionName.hashtable_0.Add("MY", hashtable126);
            Hashtable hashtable127 = new Hashtable();
            hashtable127.Add("01", "Cabo Delgado");
            hashtable127.Add("02", "Gaza");
            hashtable127.Add("03", "Inhambane");
            hashtable127.Add("04", "Maputo");
            hashtable127.Add("05", "Sofala");
            hashtable127.Add("06", "Nampula");
            hashtable127.Add("07", "Niassa");
            hashtable127.Add("08", "Tete");
            hashtable127.Add("09", "Zambezia");
            hashtable127.Add("10", "Manica");
            hashtable127.Add("11", "Maputo");
            RegionName.hashtable_0.Add("MZ", hashtable127);
            Hashtable hashtable128 = new Hashtable();
            hashtable128.Add("01", "Bethanien");
            hashtable128.Add("02", "Caprivi Oos");
            hashtable128.Add("03", "Boesmanland");
            hashtable128.Add("04", "Gobabis");
            hashtable128.Add("05", "Grootfontein");
            hashtable128.Add("06", "Kaokoland");
            hashtable128.Add("07", "Karibib");
            hashtable128.Add("08", "Keetmanshoop");
            hashtable128.Add("09", "Luderitz");
            hashtable128.Add("10", "Maltahohe");
            hashtable128.Add("11", "Okahandja");
            hashtable128.Add("12", "Omaruru");
            hashtable128.Add("13", "Otjiwarongo");
            hashtable128.Add("14", "Outjo");
            hashtable128.Add("15", "Owambo");
            hashtable128.Add("16", "Rehoboth");
            hashtable128.Add("17", "Swakopmund");
            hashtable128.Add("18", "Tsumeb");
            hashtable128.Add("20", "Karasburg");
            hashtable128.Add("21", "Windhoek");
            hashtable128.Add("22", "Damaraland");
            hashtable128.Add("23", "Hereroland Oos");
            hashtable128.Add("24", "Hereroland Wes");
            hashtable128.Add("25", "Kavango");
            hashtable128.Add("26", "Mariental");
            hashtable128.Add("27", "Namaland");
            hashtable128.Add("28", "Caprivi");
            hashtable128.Add("29", "Erongo");
            hashtable128.Add("30", "Hardap");
            hashtable128.Add("31", "Karas");
            hashtable128.Add("32", "Kunene");
            hashtable128.Add("33", "Ohangwena");
            hashtable128.Add("34", "Okavango");
            hashtable128.Add("35", "Omaheke");
            hashtable128.Add("36", "Omusati");
            hashtable128.Add("37", "Oshana");
            hashtable128.Add("38", "Oshikoto");
            hashtable128.Add("39", "Otjozondjupa");
            RegionName.hashtable_0.Add("NA", hashtable128);
            Hashtable hashtable129 = new Hashtable();
            hashtable129.Add("01", "Agadez");
            hashtable129.Add("02", "Diffa");
            hashtable129.Add("03", "Dosso");
            hashtable129.Add("04", "Maradi");
            hashtable129.Add("05", "Niamey");
            hashtable129.Add("06", "Tahoua");
            hashtable129.Add("07", "Zinder");
            hashtable129.Add("08", "Niamey");
            RegionName.hashtable_0.Add("NE", hashtable129);
            Hashtable hashtable130 = new Hashtable();
            hashtable130.Add("05", "Lagos");
            hashtable130.Add("11", "Federal Capital Territory");
            hashtable130.Add("16", "Ogun");
            hashtable130.Add("21", "Akwa Ibom");
            hashtable130.Add("22", "Cross River");
            hashtable130.Add("23", "Kaduna");
            hashtable130.Add("24", "Katsina");
            hashtable130.Add("25", "Anambra");
            hashtable130.Add("26", "Benue");
            hashtable130.Add("27", "Borno");
            hashtable130.Add("28", "Imo");
            hashtable130.Add("29", "Kano");
            hashtable130.Add("30", "Kwara");
            hashtable130.Add("31", "Niger");
            hashtable130.Add("32", "Oyo");
            hashtable130.Add("35", "Adamawa");
            hashtable130.Add("36", "Delta");
            hashtable130.Add("37", "Edo");
            hashtable130.Add("39", "Jigawa");
            hashtable130.Add("40", "Kebbi");
            hashtable130.Add("41", "Kogi");
            hashtable130.Add("42", "Osun");
            hashtable130.Add("43", "Taraba");
            hashtable130.Add("44", "Yobe");
            hashtable130.Add("45", "Abia");
            hashtable130.Add("46", "Bauchi");
            hashtable130.Add("47", "Enugu");
            hashtable130.Add("48", "Ondo");
            hashtable130.Add("49", "Plateau");
            hashtable130.Add("50", "Rivers");
            hashtable130.Add("51", "Sokoto");
            hashtable130.Add("52", "Bayelsa");
            hashtable130.Add("53", "Ebonyi");
            hashtable130.Add("54", "Ekiti");
            hashtable130.Add("55", "Gombe");
            hashtable130.Add("56", "Nassarawa");
            hashtable130.Add("57", "Zamfara");
            RegionName.hashtable_0.Add("NG", hashtable130);
            Hashtable hashtable131 = new Hashtable();
            hashtable131.Add("01", "Boaco");
            hashtable131.Add("02", "Carazo");
            hashtable131.Add("03", "Chinandega");
            hashtable131.Add("04", "Chontales");
            hashtable131.Add("05", "Esteli");
            hashtable131.Add("06", "Granada");
            hashtable131.Add("07", "Jinotega");
            hashtable131.Add("08", "Leon");
            hashtable131.Add("09", "Madriz");
            hashtable131.Add("10", "Managua");
            hashtable131.Add("11", "Masaya");
            hashtable131.Add("12", "Matagalpa");
            hashtable131.Add("13", "Nueva Segovia");
            hashtable131.Add("14", "Rio San Juan");
            hashtable131.Add("15", "Rivas");
            hashtable131.Add("16", "Zelaya");
            hashtable131.Add("17", "Autonoma Atlantico Norte");
            hashtable131.Add("18", "Region Autonoma Atlantico Sur");
            RegionName.hashtable_0.Add("NI", hashtable131);
            Hashtable hashtable132 = new Hashtable();
            hashtable132.Add("01", "Drenthe");
            hashtable132.Add("02", "Friesland");
            hashtable132.Add("03", "Gelderland");
            hashtable132.Add("04", "Groningen");
            hashtable132.Add("05", "Limburg");
            hashtable132.Add("06", "Noord-Brabant");
            hashtable132.Add("07", "Noord-Holland");
            hashtable132.Add("09", "Utrecht");
            hashtable132.Add("10", "Zeeland");
            hashtable132.Add("11", "Zuid-Holland");
            hashtable132.Add("15", "Overijssel");
            hashtable132.Add("16", "Flevoland");
            RegionName.hashtable_0.Add("NL", hashtable132);
            Hashtable hashtable133 = new Hashtable();
            hashtable133.Add("01", "Akershus");
            hashtable133.Add("02", "Aust-Agder");
            hashtable133.Add("04", "Buskerud");
            hashtable133.Add("05", "Finnmark");
            hashtable133.Add("06", "Hedmark");
            hashtable133.Add("07", "Hordaland");
            hashtable133.Add("08", "More og Romsdal");
            hashtable133.Add("09", "Nordland");
            hashtable133.Add("10", "Nord-Trondelag");
            hashtable133.Add("11", "Oppland");
            hashtable133.Add("12", "Oslo");
            hashtable133.Add("13", "Ostfold");
            hashtable133.Add("14", "Rogaland");
            hashtable133.Add("15", "Sogn og Fjordane");
            hashtable133.Add("16", "Sor-Trondelag");
            hashtable133.Add("17", "Telemark");
            hashtable133.Add("18", "Troms");
            hashtable133.Add("19", "Vest-Agder");
            hashtable133.Add("20", "Vestfold");
            RegionName.hashtable_0.Add("NO", hashtable133);
            Hashtable hashtable134 = new Hashtable();
            hashtable134.Add("01", "Bagmati");
            hashtable134.Add("02", "Bheri");
            hashtable134.Add("03", "Dhawalagiri");
            hashtable134.Add("04", "Gandaki");
            hashtable134.Add("05", "Janakpur");
            hashtable134.Add("06", "Karnali");
            hashtable134.Add("07", "Kosi");
            hashtable134.Add("08", "Lumbini");
            hashtable134.Add("09", "Mahakali");
            hashtable134.Add("10", "Mechi");
            hashtable134.Add("11", "Narayani");
            hashtable134.Add("12", "Rapti");
            hashtable134.Add("13", "Sagarmatha");
            hashtable134.Add("14", "Seti");
            RegionName.hashtable_0.Add("NP", hashtable134);
            Hashtable hashtable135 = new Hashtable();
            hashtable135.Add("01", "Aiwo");
            hashtable135.Add("02", "Anabar");
            hashtable135.Add("03", "Anetan");
            hashtable135.Add("04", "Anibare");
            hashtable135.Add("05", "Baiti");
            hashtable135.Add("06", "Boe");
            hashtable135.Add("07", "Buada");
            hashtable135.Add("08", "Denigomodu");
            hashtable135.Add("09", "Ewa");
            hashtable135.Add("10", "Ijuw");
            hashtable135.Add("11", "Meneng");
            hashtable135.Add("12", "Nibok");
            hashtable135.Add("13", "Uaboe");
            hashtable135.Add("14", "Yaren");
            RegionName.hashtable_0.Add("NR", hashtable135);
            Hashtable hashtable136 = new Hashtable();
            hashtable136.Add("10", "Chatham Islands");
            hashtable136.Add("E7", "Auckland");
            hashtable136.Add("E8", "Bay of Plenty");
            hashtable136.Add("E9", "Canterbury");
            hashtable136.Add("F1", "Gisborne");
            hashtable136.Add("F2", "Hawke's Bay");
            hashtable136.Add("F3", "Manawatu-Wanganui");
            hashtable136.Add("F4", "Marlborough");
            hashtable136.Add("F5", "Nelson");
            hashtable136.Add("F6", "Northland");
            hashtable136.Add("F7", "Otago");
            hashtable136.Add("F8", "Southland");
            hashtable136.Add("F9", "Taranaki");
            hashtable136.Add("G1", "Waikato");
            hashtable136.Add("G2", "Wellington");
            hashtable136.Add("G3", "West Coast");
            RegionName.hashtable_0.Add("NZ", hashtable136);
            Hashtable hashtable137 = new Hashtable();
            hashtable137.Add("01", "Ad Dakhiliyah");
            hashtable137.Add("02", "Al Batinah");
            hashtable137.Add("03", "Al Wusta");
            hashtable137.Add("04", "Ash Sharqiyah");
            hashtable137.Add("05", "Az Zahirah");
            hashtable137.Add("06", "Masqat");
            hashtable137.Add("07", "Musandam");
            hashtable137.Add("08", "Zufar");
            RegionName.hashtable_0.Add("OM", hashtable137);
            Hashtable hashtable138 = new Hashtable();
            hashtable138.Add("01", "Bocas del Toro");
            hashtable138.Add("02", "Chiriqui");
            hashtable138.Add("03", "Cocle");
            hashtable138.Add("04", "Colon");
            hashtable138.Add("05", "Darien");
            hashtable138.Add("06", "Herrera");
            hashtable138.Add("07", "Los Santos");
            hashtable138.Add("08", "Panama");
            hashtable138.Add("09", "San Blas");
            hashtable138.Add("10", "Veraguas");
            RegionName.hashtable_0.Add("PA", hashtable138);
            Hashtable hashtable139 = new Hashtable();
            hashtable139.Add("01", "Amazonas");
            hashtable139.Add("02", "Ancash");
            hashtable139.Add("03", "Apurimac");
            hashtable139.Add("04", "Arequipa");
            hashtable139.Add("05", "Ayacucho");
            hashtable139.Add("06", "Cajamarca");
            hashtable139.Add("07", "Callao");
            hashtable139.Add("08", "Cusco");
            hashtable139.Add("09", "Huancavelica");
            hashtable139.Add("10", "Huanuco");
            hashtable139.Add("11", "Ica");
            hashtable139.Add("12", "Junin");
            hashtable139.Add("13", "La Libertad");
            hashtable139.Add("14", "Lambayeque");
            hashtable139.Add("15", "Lima");
            hashtable139.Add("16", "Loreto");
            hashtable139.Add("17", "Madre de Dios");
            hashtable139.Add("18", "Moquegua");
            hashtable139.Add("19", "Pasco");
            hashtable139.Add("20", "Piura");
            hashtable139.Add("21", "Puno");
            hashtable139.Add("22", "San Martin");
            hashtable139.Add("23", "Tacna");
            hashtable139.Add("24", "Tumbes");
            hashtable139.Add("25", "Ucayali");
            RegionName.hashtable_0.Add("PE", hashtable139);
            Hashtable hashtable140 = new Hashtable();
            hashtable140.Add("01", "Central");
            hashtable140.Add("02", "Gulf");
            hashtable140.Add("03", "Milne Bay");
            hashtable140.Add("04", "Northern");
            hashtable140.Add("05", "Southern Highlands");
            hashtable140.Add("06", "Western");
            hashtable140.Add("07", "North Solomons");
            hashtable140.Add("08", "Chimbu");
            hashtable140.Add("09", "Eastern Highlands");
            hashtable140.Add("10", "East New Britain");
            hashtable140.Add("11", "East Sepik");
            hashtable140.Add("12", "Madang");
            hashtable140.Add("13", "Manus");
            hashtable140.Add("14", "Morobe");
            hashtable140.Add("15", "New Ireland");
            hashtable140.Add("16", "Western Highlands");
            hashtable140.Add("17", "West New Britain");
            hashtable140.Add("18", "Sandaun");
            hashtable140.Add("19", "Enga");
            hashtable140.Add("20", "National Capital");
            RegionName.hashtable_0.Add("PG", hashtable140);
            Hashtable hashtable141 = new Hashtable();
            hashtable141.Add("01", "Abra");
            hashtable141.Add("02", "Agusan del Norte");
            hashtable141.Add("03", "Agusan del Sur");
            hashtable141.Add("04", "Aklan");
            hashtable141.Add("05", "Albay");
            hashtable141.Add("06", "Antique");
            hashtable141.Add("07", "Bataan");
            hashtable141.Add("08", "Batanes");
            hashtable141.Add("09", "Batangas");
            hashtable141.Add("10", "Benguet");
            hashtable141.Add("11", "Bohol");
            hashtable141.Add("12", "Bukidnon");
            hashtable141.Add("13", "Bulacan");
            hashtable141.Add("14", "Cagayan");
            hashtable141.Add("15", "Camarines Norte");
            hashtable141.Add("16", "Camarines Sur");
            hashtable141.Add("17", "Camiguin");
            hashtable141.Add("18", "Capiz");
            hashtable141.Add("19", "Catanduanes");
            hashtable141.Add("20", "Cavite");
            hashtable141.Add("21", "Cebu");
            hashtable141.Add("22", "Basilan");
            hashtable141.Add("23", "Eastern Samar");
            hashtable141.Add("24", "Davao");
            hashtable141.Add("25", "Davao del Sur");
            hashtable141.Add("26", "Davao Oriental");
            hashtable141.Add("27", "Ifugao");
            hashtable141.Add("28", "Ilocos Norte");
            hashtable141.Add("29", "Ilocos Sur");
            hashtable141.Add("30", "Iloilo");
            hashtable141.Add("31", "Isabela");
            hashtable141.Add("32", "Kalinga-Apayao");
            hashtable141.Add("33", "Laguna");
            hashtable141.Add("34", "Lanao del Norte");
            hashtable141.Add("35", "Lanao del Sur");
            hashtable141.Add("36", "La Union");
            hashtable141.Add("37", "Leyte");
            hashtable141.Add("38", "Marinduque");
            hashtable141.Add("39", "Masbate");
            hashtable141.Add("40", "Mindoro Occidental");
            hashtable141.Add("41", "Mindoro Oriental");
            hashtable141.Add("42", "Misamis Occidental");
            hashtable141.Add("43", "Misamis Oriental");
            hashtable141.Add("44", "Mountain");
            hashtable141.Add("45", "Negros Occidental");
            hashtable141.Add("46", "Negros Oriental");
            hashtable141.Add("47", "Nueva Ecija");
            hashtable141.Add("48", "Nueva Vizcaya");
            hashtable141.Add("49", "Palawan");
            hashtable141.Add("50", "Pampanga");
            hashtable141.Add("51", "Pangasinan");
            hashtable141.Add("53", "Rizal");
            hashtable141.Add("54", "Romblon");
            hashtable141.Add("55", "Samar");
            hashtable141.Add("56", "Maguindanao");
            hashtable141.Add("57", "North Cotabato");
            hashtable141.Add("58", "Sorsogon");
            hashtable141.Add("59", "Southern Leyte");
            hashtable141.Add("60", "Sulu");
            hashtable141.Add("61", "Surigao del Norte");
            hashtable141.Add("62", "Surigao del Sur");
            hashtable141.Add("63", "Tarlac");
            hashtable141.Add("64", "Zambales");
            hashtable141.Add("65", "Zamboanga del Norte");
            hashtable141.Add("66", "Zamboanga del Sur");
            hashtable141.Add("67", "Northern Samar");
            hashtable141.Add("68", "Quirino");
            hashtable141.Add("69", "Siquijor");
            hashtable141.Add("70", "South Cotabato");
            hashtable141.Add("71", "Sultan Kudarat");
            hashtable141.Add("72", "Tawitawi");
            hashtable141.Add("A1", "Angeles");
            hashtable141.Add("A2", "Bacolod");
            hashtable141.Add("A3", "Bago");
            hashtable141.Add("A4", "Baguio");
            hashtable141.Add("A5", "Bais");
            hashtable141.Add("A6", "Basilan City");
            hashtable141.Add("A7", "Batangas City");
            hashtable141.Add("A8", "Butuan");
            hashtable141.Add("A9", "Cabanatuan");
            hashtable141.Add("B1", "Cadiz");
            hashtable141.Add("B2", "Cagayan de Oro");
            hashtable141.Add("B3", "Calbayog");
            hashtable141.Add("B4", "Caloocan");
            hashtable141.Add("B5", "Canlaon");
            hashtable141.Add("B6", "Cavite City");
            hashtable141.Add("B7", "Cebu City");
            hashtable141.Add("B8", "Cotabato");
            hashtable141.Add("B9", "Dagupan");
            hashtable141.Add("C1", "Danao");
            hashtable141.Add("C2", "Dapitan");
            hashtable141.Add("C3", "Davao City");
            hashtable141.Add("C4", "Dipolog");
            hashtable141.Add("C5", "Dumaguete");
            hashtable141.Add("C6", "General Santos");
            hashtable141.Add("C7", "Gingoog");
            hashtable141.Add("C8", "Iligan");
            hashtable141.Add("C9", "Iloilo City");
            hashtable141.Add("D1", "Iriga");
            hashtable141.Add("D2", "La Carlota");
            hashtable141.Add("D3", "Laoag");
            hashtable141.Add("D4", "Lapu-Lapu");
            hashtable141.Add("D5", "Legaspi");
            hashtable141.Add("D6", "Lipa");
            hashtable141.Add("D7", "Lucena");
            hashtable141.Add("D8", "Mandaue");
            hashtable141.Add("D9", "Manila");
            hashtable141.Add("E1", "Marawi");
            hashtable141.Add("E2", "Naga");
            hashtable141.Add("E3", "Olongapo");
            hashtable141.Add("E4", "Ormoc");
            hashtable141.Add("E5", "Oroquieta");
            hashtable141.Add("E6", "Ozamis");
            hashtable141.Add("E7", "Pagadian");
            hashtable141.Add("E8", "Palayan");
            hashtable141.Add("E9", "Pasay");
            hashtable141.Add("F1", "Puerto Princesa");
            hashtable141.Add("F2", "Quezon City");
            hashtable141.Add("F3", "Roxas");
            hashtable141.Add("F4", "San Carlos");
            hashtable141.Add("F5", "San Carlos");
            hashtable141.Add("F6", "San Jose");
            hashtable141.Add("F7", "San Pablo");
            hashtable141.Add("F8", "Silay");
            hashtable141.Add("F9", "Surigao");
            hashtable141.Add("G1", "Tacloban");
            hashtable141.Add("G2", "Tagaytay");
            hashtable141.Add("G3", "Tagbilaran");
            hashtable141.Add("G4", "Tangub");
            hashtable141.Add("G5", "Toledo");
            hashtable141.Add("G6", "Trece Martires");
            hashtable141.Add("G7", "Zamboanga");
            hashtable141.Add("G8", "Aurora");
            hashtable141.Add("H2", "Quezon");
            hashtable141.Add("H3", "Negros Occidental");
            RegionName.hashtable_0.Add("PH", hashtable141);
            Hashtable hashtable142 = new Hashtable();
            hashtable142.Add("01", "Federally Administered Tribal Areas");
            hashtable142.Add("02", "Balochistan");
            hashtable142.Add("03", "North-West Frontier");
            hashtable142.Add("04", "Punjab");
            hashtable142.Add("05", "Sindh");
            hashtable142.Add("06", "Azad Kashmir");
            hashtable142.Add("07", "Northern Areas");
            hashtable142.Add("08", "Islamabad");
            RegionName.hashtable_0.Add("PK", hashtable142);
            Hashtable hashtable143 = new Hashtable();
            hashtable143.Add("72", "Dolnoslaskie");
            hashtable143.Add("73", "Kujawsko-Pomorskie");
            hashtable143.Add("74", "Lodzkie");
            hashtable143.Add("75", "Lubelskie");
            hashtable143.Add("76", "Lubuskie");
            hashtable143.Add("77", "Malopolskie");
            hashtable143.Add("78", "Mazowieckie");
            hashtable143.Add("79", "Opolskie");
            hashtable143.Add("80", "Podkarpackie");
            hashtable143.Add("81", "Podlaskie");
            hashtable143.Add("82", "Pomorskie");
            hashtable143.Add("83", "Slaskie");
            hashtable143.Add("84", "Swietokrzyskie");
            hashtable143.Add("85", "Warminsko-Mazurskie");
            hashtable143.Add("86", "Wielkopolskie");
            hashtable143.Add("87", "Zachodniopomorskie");
            RegionName.hashtable_0.Add("PL", hashtable143);
            Hashtable hashtable144 = new Hashtable();
            hashtable144.Add("GZ", "Gaza");
            hashtable144.Add("WE", "West Bank");
            RegionName.hashtable_0.Add("PS", hashtable144);
            Hashtable hashtable145 = new Hashtable();
            hashtable145.Add("02", "Aveiro");
            hashtable145.Add("03", "Beja");
            hashtable145.Add("04", "Braga");
            hashtable145.Add("05", "Braganca");
            hashtable145.Add("06", "Castelo Branco");
            hashtable145.Add("07", "Coimbra");
            hashtable145.Add("08", "Evora");
            hashtable145.Add("09", "Faro");
            hashtable145.Add("10", "Madeira");
            hashtable145.Add("11", "Guarda");
            hashtable145.Add("13", "Leiria");
            hashtable145.Add("14", "Lisboa");
            hashtable145.Add("16", "Portalegre");
            hashtable145.Add("17", "Porto");
            hashtable145.Add("18", "Santarem");
            hashtable145.Add("19", "Setubal");
            hashtable145.Add("20", "Viana do Castelo");
            hashtable145.Add("21", "Vila Real");
            hashtable145.Add("22", "Viseu");
            hashtable145.Add("23", "Azores");
            RegionName.hashtable_0.Add("PT", hashtable145);
            Hashtable hashtable146 = new Hashtable();
            hashtable146.Add("01", "Alto Parana");
            hashtable146.Add("02", "Amambay");
            hashtable146.Add("03", "Boqueron");
            hashtable146.Add("04", "Caaguazu");
            hashtable146.Add("05", "Caazapa");
            hashtable146.Add("06", "Central");
            hashtable146.Add("07", "Concepcion");
            hashtable146.Add("08", "Cordillera");
            hashtable146.Add("10", "Guaira");
            hashtable146.Add("11", "Itapua");
            hashtable146.Add("12", "Misiones");
            hashtable146.Add("13", "Neembucu");
            hashtable146.Add("15", "Paraguari");
            hashtable146.Add("16", "Presidente Hayes");
            hashtable146.Add("17", "San Pedro");
            hashtable146.Add("19", "Canindeyu");
            hashtable146.Add("20", "Chaco");
            hashtable146.Add("21", "Nueva Asuncion");
            hashtable146.Add("23", "Alto Paraguay");
            RegionName.hashtable_0.Add("PY", hashtable146);
            Hashtable hashtable147 = new Hashtable();
            hashtable147.Add("01", "Ad Dawhah");
            hashtable147.Add("02", "Al Ghuwariyah");
            hashtable147.Add("03", "Al Jumaliyah");
            hashtable147.Add("04", "Al Khawr");
            hashtable147.Add("05", "Al Wakrah Municipality");
            hashtable147.Add("06", "Ar Rayyan");
            hashtable147.Add("08", "Madinat ach Shamal");
            hashtable147.Add("09", "Umm Salal");
            hashtable147.Add("10", "Al Wakrah");
            hashtable147.Add("11", "Jariyan al Batnah");
            hashtable147.Add("12", "Umm Sa'id");
            RegionName.hashtable_0.Add("QA", hashtable147);
            Hashtable hashtable148 = new Hashtable();
            hashtable148.Add("01", "Alba");
            hashtable148.Add("02", "Arad");
            hashtable148.Add("03", "Arges");
            hashtable148.Add("04", "Bacau");
            hashtable148.Add("05", "Bihor");
            hashtable148.Add("06", "Bistrita-Nasaud");
            hashtable148.Add("07", "Botosani");
            hashtable148.Add("08", "Braila");
            hashtable148.Add("09", "Brasov");
            hashtable148.Add("10", "Bucuresti");
            hashtable148.Add("11", "Buzau");
            hashtable148.Add("12", "Caras-Severin");
            hashtable148.Add("13", "Cluj");
            hashtable148.Add("14", "Constanta");
            hashtable148.Add("15", "Covasna");
            hashtable148.Add("16", "Dambovita");
            hashtable148.Add("17", "Dolj");
            hashtable148.Add("18", "Galati");
            hashtable148.Add("19", "Gorj");
            hashtable148.Add("20", "Harghita");
            hashtable148.Add("21", "Hunedoara");
            hashtable148.Add("22", "Ialomita");
            hashtable148.Add("23", "Iasi");
            hashtable148.Add("25", "Maramures");
            hashtable148.Add("26", "Mehedinti");
            hashtable148.Add("27", "Mures");
            hashtable148.Add("28", "Neamt");
            hashtable148.Add("29", "Olt");
            hashtable148.Add("30", "Prahova");
            hashtable148.Add("31", "Salaj");
            hashtable148.Add("32", "Satu Mare");
            hashtable148.Add("33", "Sibiu");
            hashtable148.Add("34", "Suceava");
            hashtable148.Add("35", "Teleorman");
            hashtable148.Add("36", "Timis");
            hashtable148.Add("37", "Tulcea");
            hashtable148.Add("38", "Vaslui");
            hashtable148.Add("39", "Valcea");
            hashtable148.Add("40", "Vrancea");
            hashtable148.Add("41", "Calarasi");
            hashtable148.Add("42", "Giurgiu");
            hashtable148.Add("43", "Ilfov");
            RegionName.hashtable_0.Add("RO", hashtable148);
            Hashtable hashtable149 = new Hashtable();
            hashtable149.Add("01", "Kosovo");
            hashtable149.Add("02", "Vojvodina");
            RegionName.hashtable_0.Add("RS", hashtable149);
            Hashtable hashtable150 = new Hashtable();
            hashtable150.Add("01", "Adygeya, Republic of");
            hashtable150.Add("02", "Aginsky Buryatsky AO");
            hashtable150.Add("03", "Gorno-Altay");
            hashtable150.Add("04", "Altaisky krai");
            hashtable150.Add("05", "Amur");
            hashtable150.Add("06", "Arkhangel'sk");
            hashtable150.Add("07", "Astrakhan'");
            hashtable150.Add("08", "Bashkortostan");
            hashtable150.Add("09", "Belgorod");
            hashtable150.Add("10", "Bryansk");
            hashtable150.Add("11", "Buryat");
            hashtable150.Add("12", "Chechnya");
            hashtable150.Add("13", "Chelyabinsk");
            hashtable150.Add("14", "Chita");
            hashtable150.Add("15", "Chukot");
            hashtable150.Add("16", "Chuvashia");
            hashtable150.Add("17", "Dagestan");
            hashtable150.Add("18", "Evenk");
            hashtable150.Add("19", "Ingush");
            hashtable150.Add("20", "Irkutsk");
            hashtable150.Add("21", "Ivanovo");
            hashtable150.Add("22", "Kabardin-Balkar");
            hashtable150.Add("23", "Kaliningrad");
            hashtable150.Add("24", "Kalmyk");
            hashtable150.Add("25", "Kaluga");
            hashtable150.Add("26", "Kamchatka");
            hashtable150.Add("27", "Karachay-Cherkess");
            hashtable150.Add("28", "Karelia");
            hashtable150.Add("29", "Kemerovo");
            hashtable150.Add("30", "Khabarovsk");
            hashtable150.Add("31", "Khakass");
            hashtable150.Add("32", "Khanty-Mansiy");
            hashtable150.Add("33", "Kirov");
            hashtable150.Add("34", "Komi");
            hashtable150.Add("35", "Komi-Permyak");
            hashtable150.Add("36", "Koryak");
            hashtable150.Add("37", "Kostroma");
            hashtable150.Add("38", "Krasnodar");
            hashtable150.Add("39", "Krasnoyarsk");
            hashtable150.Add("40", "Kurgan");
            hashtable150.Add("41", "Kursk");
            hashtable150.Add("42", "Leningrad");
            hashtable150.Add("43", "Lipetsk");
            hashtable150.Add("44", "Magadan");
            hashtable150.Add("45", "Mariy-El");
            hashtable150.Add("46", "Mordovia");
            hashtable150.Add("47", "Moskva");
            hashtable150.Add("48", "Moscow City");
            hashtable150.Add("49", "Murmansk");
            hashtable150.Add("50", "Nenets");
            hashtable150.Add("51", "Nizhegorod");
            hashtable150.Add("52", "Novgorod");
            hashtable150.Add("53", "Novosibirsk");
            hashtable150.Add("54", "Omsk");
            hashtable150.Add("55", "Orenburg");
            hashtable150.Add("56", "Orel");
            hashtable150.Add("57", "Penza");
            hashtable150.Add("58", "Perm'");
            hashtable150.Add("59", "Primor'ye");
            hashtable150.Add("60", "Pskov");
            hashtable150.Add("61", "Rostov");
            hashtable150.Add("62", "Ryazan'");
            hashtable150.Add("63", "Sakha");
            hashtable150.Add("64", "Sakhalin");
            hashtable150.Add("65", "Samara");
            hashtable150.Add("66", "Saint Petersburg City");
            hashtable150.Add("67", "Saratov");
            hashtable150.Add("68", "North Ossetia");
            hashtable150.Add("69", "Smolensk");
            hashtable150.Add("70", "Stavropol'");
            hashtable150.Add("71", "Sverdlovsk");
            hashtable150.Add("72", "Tambovskaya oblast");
            hashtable150.Add("73", "Tatarstan");
            hashtable150.Add("74", "Taymyr");
            hashtable150.Add("75", "Tomsk");
            hashtable150.Add("76", "Tula");
            hashtable150.Add("77", "Tver'");
            hashtable150.Add("78", "Tyumen'");
            hashtable150.Add("79", "Tuva");
            hashtable150.Add("80", "Udmurt");
            hashtable150.Add("81", "Ul'yanovsk");
            hashtable150.Add("82", "Ust-Orda Buryat");
            hashtable150.Add("83", "Vladimir");
            hashtable150.Add("84", "Volgograd");
            hashtable150.Add("85", "Vologda");
            hashtable150.Add("86", "Voronezh");
            hashtable150.Add("87", "Yamal-Nenets");
            hashtable150.Add("88", "Yaroslavl'");
            hashtable150.Add("89", "Yevrey");
            hashtable150.Add("90", "Permskiy Kray");
            hashtable150.Add("91", "Krasnoyarskiy Kray");
            hashtable150.Add("92", "Kamchatskiy Kray");
            hashtable150.Add("93", "Zabaykal'skiy Kray");
            RegionName.hashtable_0.Add("RU", hashtable150);
            Hashtable hashtable151 = new Hashtable();
            hashtable151.Add("01", "Butare");
            hashtable151.Add("06", "Gitarama");
            hashtable151.Add("07", "Kibungo");
            hashtable151.Add("09", "Kigali");
            hashtable151.Add("11", "Est");
            hashtable151.Add("12", "Kigali");
            hashtable151.Add("13", "Nord");
            hashtable151.Add("14", "Ouest");
            hashtable151.Add("15", "Sud");
            RegionName.hashtable_0.Add("RW", hashtable151);
            Hashtable hashtable152 = new Hashtable();
            hashtable152.Add("02", "Al Bahah");
            hashtable152.Add("05", "Al Madinah");
            hashtable152.Add("06", "Ash Sharqiyah");
            hashtable152.Add("08", "Al Qasim");
            hashtable152.Add("10", "Ar Riyad");
            hashtable152.Add("11", "Asir Province");
            hashtable152.Add("13", "Ha'il");
            hashtable152.Add("14", "Makkah");
            hashtable152.Add("15", "Al Hudud ash Shamaliyah");
            hashtable152.Add("16", "Najran");
            hashtable152.Add("17", "Jizan");
            hashtable152.Add("19", "Tabuk");
            hashtable152.Add("20", "Al Jawf");
            RegionName.hashtable_0.Add("SA", hashtable152);
            Hashtable hashtable153 = new Hashtable();
            hashtable153.Add("03", "Malaita");
            hashtable153.Add("06", "Guadalcanal");
            hashtable153.Add("07", "Isabel");
            hashtable153.Add("08", "Makira");
            hashtable153.Add("09", "Temotu");
            hashtable153.Add("10", "Central");
            hashtable153.Add("11", "Western");
            hashtable153.Add("12", "Choiseul");
            hashtable153.Add("13", "Rennell and Bellona");
            RegionName.hashtable_0.Add("SB", hashtable153);
            Hashtable hashtable154 = new Hashtable();
            hashtable154.Add("01", "Anse aux Pins");
            hashtable154.Add("02", "Anse Boileau");
            hashtable154.Add("03", "Anse Etoile");
            hashtable154.Add("04", "Anse Louis");
            hashtable154.Add("05", "Anse Royale");
            hashtable154.Add("06", "Baie Lazare");
            hashtable154.Add("07", "Baie Sainte Anne");
            hashtable154.Add("08", "Beau Vallon");
            hashtable154.Add("09", "Bel Air");
            hashtable154.Add("10", "Bel Ombre");
            hashtable154.Add("11", "Cascade");
            hashtable154.Add("12", "Glacis");
            hashtable154.Add("13", "Grand' Anse");
            hashtable154.Add("14", "Grand' Anse");
            hashtable154.Add("15", "La Digue");
            hashtable154.Add("16", "La Riviere Anglaise");
            hashtable154.Add("17", "Mont Buxton");
            hashtable154.Add("18", "Mont Fleuri");
            hashtable154.Add("19", "Plaisance");
            hashtable154.Add("20", "Pointe La Rue");
            hashtable154.Add("21", "Port Glaud");
            hashtable154.Add("22", "Saint Louis");
            hashtable154.Add("23", "Takamaka");
            RegionName.hashtable_0.Add("SC", hashtable154);
            Hashtable hashtable155 = new Hashtable();
            hashtable155.Add("27", "Al Wusta");
            hashtable155.Add("28", "Al Istiwa'iyah");
            hashtable155.Add("29", "Al Khartum");
            hashtable155.Add("30", "Ash Shamaliyah");
            hashtable155.Add("31", "Ash Sharqiyah");
            hashtable155.Add("32", "Bahr al Ghazal");
            hashtable155.Add("33", "Darfur");
            hashtable155.Add("34", "Kurdufan");
            hashtable155.Add("35", "Upper Nile");
            hashtable155.Add("40", "Al Wahadah State");
            hashtable155.Add("44", "Central Equatoria State");
            RegionName.hashtable_0.Add("SD", hashtable155);
            Hashtable hashtable156 = new Hashtable();
            hashtable156.Add("02", "Blekinge Lan");
            hashtable156.Add("03", "Gavleborgs Lan");
            hashtable156.Add("05", "Gotlands Lan");
            hashtable156.Add("06", "Hallands Lan");
            hashtable156.Add("07", "Jamtlands Lan");
            hashtable156.Add("08", "Jonkopings Lan");
            hashtable156.Add("09", "Kalmar Lan");
            hashtable156.Add("10", "Dalarnas Lan");
            hashtable156.Add("12", "Kronobergs Lan");
            hashtable156.Add("14", "Norrbottens Lan");
            hashtable156.Add("15", "Orebro Lan");
            hashtable156.Add("16", "Ostergotlands Lan");
            hashtable156.Add("18", "Sodermanlands Lan");
            hashtable156.Add("21", "Uppsala Lan");
            hashtable156.Add("22", "Varmlands Lan");
            hashtable156.Add("23", "Vasterbottens Lan");
            hashtable156.Add("24", "Vasternorrlands Lan");
            hashtable156.Add("25", "Vastmanlands Lan");
            hashtable156.Add("26", "Stockholms Lan");
            hashtable156.Add("27", "Skane Lan");
            hashtable156.Add("28", "Vastra Gotaland");
            RegionName.hashtable_0.Add("SE", hashtable156);
            Hashtable hashtable157 = new Hashtable();
            hashtable157.Add("01", "Ascension");
            hashtable157.Add("02", "Saint Helena");
            hashtable157.Add("03", "Tristan da Cunha");
            RegionName.hashtable_0.Add("SH", hashtable157);
            Hashtable hashtable158 = new Hashtable();
            hashtable158.Add("01", "Ajdovscina");
            hashtable158.Add("02", "Beltinci");
            hashtable158.Add("03", "Bled");
            hashtable158.Add("04", "Bohinj");
            hashtable158.Add("05", "Borovnica");
            hashtable158.Add("06", "Bovec");
            hashtable158.Add("07", "Brda");
            hashtable158.Add("08", "Brezice");
            hashtable158.Add("09", "Brezovica");
            hashtable158.Add("11", "Celje");
            hashtable158.Add("12", "Cerklje na Gorenjskem");
            hashtable158.Add("13", "Cerknica");
            hashtable158.Add("14", "Cerkno");
            hashtable158.Add("15", "Crensovci");
            hashtable158.Add("16", "Crna na Koroskem");
            hashtable158.Add("17", "Crnomelj");
            hashtable158.Add("19", "Divaca");
            hashtable158.Add("20", "Dobrepolje");
            hashtable158.Add("22", "Dol pri Ljubljani");
            hashtable158.Add("24", "Dornava");
            hashtable158.Add("25", "Dravograd");
            hashtable158.Add("26", "Duplek");
            hashtable158.Add("27", "Gorenja Vas-Poljane");
            hashtable158.Add("28", "Gorisnica");
            hashtable158.Add("29", "Gornja Radgona");
            hashtable158.Add("30", "Gornji Grad");
            hashtable158.Add("31", "Gornji Petrovci");
            hashtable158.Add("32", "Grosuplje");
            hashtable158.Add("34", "Hrastnik");
            hashtable158.Add("35", "Hrpelje-Kozina");
            hashtable158.Add("36", "Idrija");
            hashtable158.Add("37", "Ig");
            hashtable158.Add("38", "Ilirska Bistrica");
            hashtable158.Add("39", "Ivancna Gorica");
            hashtable158.Add("40", "Izola-Isola");
            hashtable158.Add("42", "Jursinci");
            hashtable158.Add("44", "Kanal");
            hashtable158.Add("45", "Kidricevo");
            hashtable158.Add("46", "Kobarid");
            hashtable158.Add("47", "Kobilje");
            hashtable158.Add("49", "Komen");
            hashtable158.Add("50", "Koper-Capodistria");
            hashtable158.Add("51", "Kozje");
            hashtable158.Add("52", "Kranj");
            hashtable158.Add("53", "Kranjska Gora");
            hashtable158.Add("54", "Krsko");
            hashtable158.Add("55", "Kungota");
            hashtable158.Add("57", "Lasko");
            hashtable158.Add("61", "Ljubljana");
            hashtable158.Add("62", "Ljubno");
            hashtable158.Add("64", "Logatec");
            hashtable158.Add("66", "Loski Potok");
            hashtable158.Add("68", "Lukovica");
            hashtable158.Add("71", "Medvode");
            hashtable158.Add("72", "Menges");
            hashtable158.Add("73", "Metlika");
            hashtable158.Add("74", "Mezica");
            hashtable158.Add("76", "Mislinja");
            hashtable158.Add("77", "Moravce");
            hashtable158.Add("78", "Moravske Toplice");
            hashtable158.Add("79", "Mozirje");
            hashtable158.Add("80", "Murska Sobota");
            hashtable158.Add("81", "Muta");
            hashtable158.Add("82", "Naklo");
            hashtable158.Add("83", "Nazarje");
            hashtable158.Add("84", "Nova Gorica");
            hashtable158.Add("86", "Odranci");
            hashtable158.Add("87", "Ormoz");
            hashtable158.Add("88", "Osilnica");
            hashtable158.Add("89", "Pesnica");
            hashtable158.Add("91", "Pivka");
            hashtable158.Add("92", "Podcetrtek");
            hashtable158.Add("94", "Postojna");
            hashtable158.Add("97", "Puconci");
            hashtable158.Add("98", "Racam");
            hashtable158.Add("99", "Radece");
            hashtable158.Add("A1", "Radenci");
            hashtable158.Add("A2", "Radlje ob Dravi");
            hashtable158.Add("A3", "Radovljica");
            hashtable158.Add("A6", "Rogasovci");
            hashtable158.Add("A7", "Rogaska Slatina");
            hashtable158.Add("A8", "Rogatec");
            hashtable158.Add("B1", "Semic");
            hashtable158.Add("B2", "Sencur");
            hashtable158.Add("B3", "Sentilj");
            hashtable158.Add("B4", "Sentjernej");
            hashtable158.Add("B6", "Sevnica");
            hashtable158.Add("B7", "Sezana");
            hashtable158.Add("B8", "Skocjan");
            hashtable158.Add("B9", "Skofja Loka");
            hashtable158.Add("C1", "Skofljica");
            hashtable158.Add("C2", "Slovenj Gradec");
            hashtable158.Add("C4", "Slovenske Konjice");
            hashtable158.Add("C5", "Smarje pri Jelsah");
            hashtable158.Add("C6", "Smartno ob Paki");
            hashtable158.Add("C7", "Sostanj");
            hashtable158.Add("C8", "Starse");
            hashtable158.Add("C9", "Store");
            hashtable158.Add("D1", "Sveti Jurij");
            hashtable158.Add("D2", "Tolmin");
            hashtable158.Add("D3", "Trbovlje");
            hashtable158.Add("D4", "Trebnje");
            hashtable158.Add("D5", "Trzic");
            hashtable158.Add("D6", "Turnisce");
            hashtable158.Add("D7", "Velenje");
            hashtable158.Add("D8", "Velike Lasce");
            hashtable158.Add("E1", "Vipava");
            hashtable158.Add("E2", "Vitanje");
            hashtable158.Add("E3", "Vodice");
            hashtable158.Add("E5", "Vrhnika");
            hashtable158.Add("E6", "Vuzenica");
            hashtable158.Add("E7", "Zagorje ob Savi");
            hashtable158.Add("E9", "Zavrc");
            hashtable158.Add("F1", "Zelezniki");
            hashtable158.Add("F2", "Ziri");
            hashtable158.Add("F3", "Zrece");
            hashtable158.Add("G4", "Dobrova-Horjul-Polhov Gradec");
            hashtable158.Add("G7", "Domzale");
            hashtable158.Add("H4", "Jesenice");
            hashtable158.Add("H6", "Kamnik");
            hashtable158.Add("H7", "Kocevje");
            hashtable158.Add("I2", "Kuzma");
            hashtable158.Add("I3", "Lenart");
            hashtable158.Add("I5", "Litija");
            hashtable158.Add("I6", "Ljutomer");
            hashtable158.Add("I7", "Loska Dolina");
            hashtable158.Add("I9", "Luce");
            hashtable158.Add("J1", "Majsperk");
            hashtable158.Add("J2", "Maribor");
            hashtable158.Add("J5", "Miren-Kostanjevica");
            hashtable158.Add("J7", "Novo Mesto");
            hashtable158.Add("J9", "Piran");
            hashtable158.Add("K5", "Preddvor");
            hashtable158.Add("K7", "Ptuj");
            hashtable158.Add("L1", "Ribnica");
            hashtable158.Add("L3", "Ruse");
            hashtable158.Add("L7", "Sentjur pri Celju");
            hashtable158.Add("L8", "Slovenska Bistrica");
            hashtable158.Add("N2", "Videm");
            hashtable158.Add("N3", "Vojnik");
            hashtable158.Add("N5", "Zalec");
            RegionName.hashtable_0.Add("SI", hashtable158);
            Hashtable hashtable159 = new Hashtable();
            hashtable159.Add("01", "Banska Bystrica");
            hashtable159.Add("02", "Bratislava");
            hashtable159.Add("03", "Kosice");
            hashtable159.Add("04", "Nitra");
            hashtable159.Add("05", "Presov");
            hashtable159.Add("06", "Trencin");
            hashtable159.Add("07", "Trnava");
            hashtable159.Add("08", "Zilina");
            RegionName.hashtable_0.Add("SK", hashtable159);
            Hashtable hashtable160 = new Hashtable();
            hashtable160.Add("01", "Eastern");
            hashtable160.Add("02", "Northern");
            hashtable160.Add("03", "Southern");
            hashtable160.Add("04", "Western Area");
            RegionName.hashtable_0.Add("SL", hashtable160);
            Hashtable hashtable161 = new Hashtable();
            hashtable161.Add("01", "Acquaviva");
            hashtable161.Add("02", "Chiesanuova");
            hashtable161.Add("03", "Domagnano");
            hashtable161.Add("04", "Faetano");
            hashtable161.Add("05", "Fiorentino");
            hashtable161.Add("06", "Borgo Maggiore");
            hashtable161.Add("07", "San Marino");
            hashtable161.Add("08", "Monte Giardino");
            hashtable161.Add("09", "Serravalle");
            RegionName.hashtable_0.Add("SM", hashtable161);
            Hashtable hashtable162 = new Hashtable();
            hashtable162.Add("01", "Dakar");
            hashtable162.Add("03", "Diourbel");
            hashtable162.Add("05", "Tambacounda");
            hashtable162.Add("07", "Thies");
            hashtable162.Add("09", "Fatick");
            hashtable162.Add("10", "Kaolack");
            hashtable162.Add("11", "Kolda");
            hashtable162.Add("12", "Ziguinchor");
            hashtable162.Add("13", "Louga");
            hashtable162.Add("14", "Saint-Louis");
            hashtable162.Add("15", "Matam");
            RegionName.hashtable_0.Add("SN", hashtable162);
            Hashtable hashtable163 = new Hashtable();
            hashtable163.Add("01", "Bakool");
            hashtable163.Add("02", "Banaadir");
            hashtable163.Add("03", "Bari");
            hashtable163.Add("04", "Bay");
            hashtable163.Add("05", "Galguduud");
            hashtable163.Add("06", "Gedo");
            hashtable163.Add("07", "Hiiraan");
            hashtable163.Add("08", "Jubbada Dhexe");
            hashtable163.Add("09", "Jubbada Hoose");
            hashtable163.Add("10", "Mudug");
            hashtable163.Add("11", "Nugaal");
            hashtable163.Add("12", "Sanaag");
            hashtable163.Add("13", "Shabeellaha Dhexe");
            hashtable163.Add("14", "Shabeellaha Hoose");
            hashtable163.Add("16", "Woqooyi Galbeed");
            hashtable163.Add("18", "Nugaal");
            hashtable163.Add("19", "Togdheer");
            hashtable163.Add("20", "Woqooyi Galbeed");
            hashtable163.Add("21", "Awdal");
            hashtable163.Add("22", "Sool");
            RegionName.hashtable_0.Add("SO", hashtable163);
            Hashtable hashtable164 = new Hashtable();
            hashtable164.Add("10", "Brokopondo");
            hashtable164.Add("11", "Commewijne");
            hashtable164.Add("12", "Coronie");
            hashtable164.Add("13", "Marowijne");
            hashtable164.Add("14", "Nickerie");
            hashtable164.Add("15", "Para");
            hashtable164.Add("16", "Paramaribo");
            hashtable164.Add("17", "Saramacca");
            hashtable164.Add("18", "Sipaliwini");
            hashtable164.Add("19", "Wanica");
            RegionName.hashtable_0.Add("SR", hashtable164);
            Hashtable hashtable165 = new Hashtable();
            hashtable165.Add("01", "Principe");
            hashtable165.Add("02", "Sao Tome");
            RegionName.hashtable_0.Add("ST", hashtable165);
            Hashtable hashtable166 = new Hashtable();
            hashtable166.Add("01", "Ahuachapan");
            hashtable166.Add("02", "Cabanas");
            hashtable166.Add("03", "Chalatenango");
            hashtable166.Add("04", "Cuscatlan");
            hashtable166.Add("05", "La Libertad");
            hashtable166.Add("06", "La Paz");
            hashtable166.Add("07", "La Union");
            hashtable166.Add("08", "Morazan");
            hashtable166.Add("09", "San Miguel");
            hashtable166.Add("10", "San Salvador");
            hashtable166.Add("11", "Santa Ana");
            hashtable166.Add("12", "San Vicente");
            hashtable166.Add("13", "Sonsonate");
            hashtable166.Add("14", "Usulutan");
            RegionName.hashtable_0.Add("SV", hashtable166);
            Hashtable hashtable167 = new Hashtable();
            hashtable167.Add("01", "Al Hasakah");
            hashtable167.Add("02", "Al Ladhiqiyah");
            hashtable167.Add("03", "Al Qunaytirah");
            hashtable167.Add("04", "Ar Raqqah");
            hashtable167.Add("05", "As Suwayda'");
            hashtable167.Add("06", "Dar");
            hashtable167.Add("07", "Dayr az Zawr");
            hashtable167.Add("08", "Rif Dimashq");
            hashtable167.Add("09", "Halab");
            hashtable167.Add("10", "Hamah");
            hashtable167.Add("11", "Hims");
            hashtable167.Add("12", "Idlib");
            hashtable167.Add("13", "Dimashq");
            hashtable167.Add("14", "Tartus");
            RegionName.hashtable_0.Add("SY", hashtable167);
            Hashtable hashtable168 = new Hashtable();
            hashtable168.Add("01", "Hhohho");
            hashtable168.Add("02", "Lubombo");
            hashtable168.Add("03", "Manzini");
            hashtable168.Add("04", "Shiselweni");
            hashtable168.Add("05", "Praslin");
            RegionName.hashtable_0.Add("SZ", hashtable168);
            Hashtable hashtable169 = new Hashtable();
            hashtable169.Add("01", "Batha");
            hashtable169.Add("02", "Biltine");
            hashtable169.Add("03", "Borkou-Ennedi-Tibesti");
            hashtable169.Add("04", "Chari-Baguirmi");
            hashtable169.Add("05", "Guera");
            hashtable169.Add("06", "Kanem");
            hashtable169.Add("07", "Lac");
            hashtable169.Add("08", "Logone Occidental");
            hashtable169.Add("09", "Logone Oriental");
            hashtable169.Add("10", "Mayo-Kebbi");
            hashtable169.Add("11", "Moyen-Chari");
            hashtable169.Add("12", "Ouaddai");
            hashtable169.Add("13", "Salamat");
            hashtable169.Add("14", "Tandjile");
            RegionName.hashtable_0.Add("TD", hashtable169);
            Hashtable hashtable170 = new Hashtable();
            hashtable170.Add("22", "Centrale");
            hashtable170.Add("23", "Kara");
            hashtable170.Add("24", "Maritime");
            hashtable170.Add("25", "Plateaux");
            hashtable170.Add("26", "Savanes");
            RegionName.hashtable_0.Add("TG", hashtable170);
            Hashtable hashtable171 = new Hashtable();
            hashtable171.Add("01", "Mae Hong Son");
            hashtable171.Add("02", "Chiang Mai");
            hashtable171.Add("03", "Chiang Rai");
            hashtable171.Add("04", "Nan");
            hashtable171.Add("05", "Lamphun");
            hashtable171.Add("06", "Lampang");
            hashtable171.Add("07", "Phrae");
            hashtable171.Add("08", "Tak");
            hashtable171.Add("09", "Sukhothai");
            hashtable171.Add("10", "Uttaradit");
            hashtable171.Add("11", "Kamphaeng Phet");
            hashtable171.Add("12", "Phitsanulok");
            hashtable171.Add("13", "Phichit");
            hashtable171.Add("14", "Phetchabun");
            hashtable171.Add("15", "Uthai Thani");
            hashtable171.Add("16", "Nakhon Sawan");
            hashtable171.Add("17", "Nong Khai");
            hashtable171.Add("18", "Loei");
            hashtable171.Add("20", "Sakon Nakhon");
            hashtable171.Add("21", "Nakhon Phanom");
            hashtable171.Add("22", "Khon Kaen");
            hashtable171.Add("23", "Kalasin");
            hashtable171.Add("24", "Maha Sarakham");
            hashtable171.Add("25", "Roi Et");
            hashtable171.Add("26", "Chaiyaphum");
            hashtable171.Add("27", "Nakhon Ratchasima");
            hashtable171.Add("28", "Buriram");
            hashtable171.Add("29", "Surin");
            hashtable171.Add("30", "Sisaket");
            hashtable171.Add("31", "Narathiwat");
            hashtable171.Add("32", "Chai Nat");
            hashtable171.Add("33", "Sing Buri");
            hashtable171.Add("34", "Lop Buri");
            hashtable171.Add("35", "Ang Thong");
            hashtable171.Add("36", "Phra Nakhon Si Ayutthaya");
            hashtable171.Add("37", "Saraburi");
            hashtable171.Add("38", "Nonthaburi");
            hashtable171.Add("39", "Pathum Thani");
            hashtable171.Add("40", "Krung Thep");
            hashtable171.Add("41", "Phayao");
            hashtable171.Add("42", "Samut Prakan");
            hashtable171.Add("43", "Nakhon Nayok");
            hashtable171.Add("44", "Chachoengsao");
            hashtable171.Add("45", "Prachin Buri");
            hashtable171.Add("46", "Chon Buri");
            hashtable171.Add("47", "Rayong");
            hashtable171.Add("48", "Chanthaburi");
            hashtable171.Add("49", "Trat");
            hashtable171.Add("50", "Kanchanaburi");
            hashtable171.Add("51", "Suphan Buri");
            hashtable171.Add("52", "Ratchaburi");
            hashtable171.Add("53", "Nakhon Pathom");
            hashtable171.Add("54", "Samut Songkhram");
            hashtable171.Add("55", "Samut Sakhon");
            hashtable171.Add("56", "Phetchaburi");
            hashtable171.Add("57", "Prachuap Khiri Khan");
            hashtable171.Add("58", "Chumphon");
            hashtable171.Add("59", "Ranong");
            hashtable171.Add("60", "Surat Thani");
            hashtable171.Add("61", "Phangnga");
            hashtable171.Add("62", "Phuket");
            hashtable171.Add("63", "Krabi");
            hashtable171.Add("64", "Nakhon Si Thammarat");
            hashtable171.Add("65", "Trang");
            hashtable171.Add("66", "Phatthalung");
            hashtable171.Add("67", "Satun");
            hashtable171.Add("68", "Songkhla");
            hashtable171.Add("69", "Pattani");
            hashtable171.Add("70", "Yala");
            hashtable171.Add("71", "Ubon Ratchathani");
            hashtable171.Add("72", "Yasothon");
            hashtable171.Add("73", "Nakhon Phanom");
            hashtable171.Add("75", "Ubon Ratchathani");
            hashtable171.Add("76", "Udon Thani");
            hashtable171.Add("77", "Amnat Charoen");
            hashtable171.Add("78", "Mukdahan");
            hashtable171.Add("79", "Nong Bua Lamphu");
            hashtable171.Add("80", "Sa Kaeo");
            RegionName.hashtable_0.Add("TH", hashtable171);
            Hashtable hashtable172 = new Hashtable();
            hashtable172.Add("01", "Kuhistoni Badakhshon");
            hashtable172.Add("02", "Khatlon");
            hashtable172.Add("03", "Sughd");
            RegionName.hashtable_0.Add("TJ", hashtable172);
            Hashtable hashtable173 = new Hashtable();
            hashtable173.Add("01", "Ahal");
            hashtable173.Add("02", "Balkan");
            hashtable173.Add("03", "Dashoguz");
            hashtable173.Add("04", "Lebap");
            hashtable173.Add("05", "Mary");
            RegionName.hashtable_0.Add("TM", hashtable173);
            Hashtable hashtable174 = new Hashtable();
            hashtable174.Add("02", "Kasserine");
            hashtable174.Add("03", "Kairouan");
            hashtable174.Add("06", "Jendouba");
            hashtable174.Add("10", "Qafsah");
            hashtable174.Add("14", "El Kef");
            hashtable174.Add("15", "Al Mahdia");
            hashtable174.Add("16", "Al Munastir");
            hashtable174.Add("17", "Bajah");
            hashtable174.Add("18", "Bizerte");
            hashtable174.Add("19", "Nabeul");
            hashtable174.Add("22", "Siliana");
            hashtable174.Add("23", "Sousse");
            hashtable174.Add("27", "Ben Arous");
            hashtable174.Add("28", "Madanin");
            hashtable174.Add("29", "Gabes");
            hashtable174.Add("31", "Kebili");
            hashtable174.Add("32", "Sfax");
            hashtable174.Add("33", "Sidi Bou Zid");
            hashtable174.Add("34", "Tataouine");
            hashtable174.Add("35", "Tozeur");
            hashtable174.Add("36", "Tunis");
            hashtable174.Add("37", "Zaghouan");
            hashtable174.Add("38", "Aiana");
            hashtable174.Add("39", "Manouba");
            RegionName.hashtable_0.Add("TN", hashtable174);
            Hashtable hashtable175 = new Hashtable();
            hashtable175.Add("01", "Ha");
            hashtable175.Add("02", "Tongatapu");
            hashtable175.Add("03", "Vava");
            RegionName.hashtable_0.Add("TO", hashtable175);
            Hashtable hashtable176 = new Hashtable();
            hashtable176.Add("02", "Adiyaman");
            hashtable176.Add("03", "Afyonkarahisar");
            hashtable176.Add("04", "Agri");
            hashtable176.Add("05", "Amasya");
            hashtable176.Add("07", "Antalya");
            hashtable176.Add("08", "Artvin");
            hashtable176.Add("09", "Aydin");
            hashtable176.Add("10", "Balikesir");
            hashtable176.Add("11", "Bilecik");
            hashtable176.Add("12", "Bingol");
            hashtable176.Add("13", "Bitlis");
            hashtable176.Add("14", "Bolu");
            hashtable176.Add("15", "Burdur");
            hashtable176.Add("16", "Bursa");
            hashtable176.Add("17", "Canakkale");
            hashtable176.Add("19", "Corum");
            hashtable176.Add("20", "Denizli");
            hashtable176.Add("21", "Diyarbakir");
            hashtable176.Add("22", "Edirne");
            hashtable176.Add("23", "Elazig");
            hashtable176.Add("24", "Erzincan");
            hashtable176.Add("25", "Erzurum");
            hashtable176.Add("26", "Eskisehir");
            hashtable176.Add("28", "Giresun");
            hashtable176.Add("31", "Hatay");
            hashtable176.Add("32", "Mersin");
            hashtable176.Add("33", "Isparta");
            hashtable176.Add("34", "Istanbul");
            hashtable176.Add("35", "Izmir");
            hashtable176.Add("37", "Kastamonu");
            hashtable176.Add("38", "Kayseri");
            hashtable176.Add("39", "Kirklareli");
            hashtable176.Add("40", "Kirsehir");
            hashtable176.Add("41", "Kocaeli");
            hashtable176.Add("43", "Kutahya");
            hashtable176.Add("44", "Malatya");
            hashtable176.Add("45", "Manisa");
            hashtable176.Add("46", "Kahramanmaras");
            hashtable176.Add("48", "Mugla");
            hashtable176.Add("49", "Mus");
            hashtable176.Add("50", "Nevsehir");
            hashtable176.Add("52", "Ordu");
            hashtable176.Add("53", "Rize");
            hashtable176.Add("54", "Sakarya");
            hashtable176.Add("55", "Samsun");
            hashtable176.Add("57", "Sinop");
            hashtable176.Add("58", "Sivas");
            hashtable176.Add("59", "Tekirdag");
            hashtable176.Add("60", "Tokat");
            hashtable176.Add("61", "Trabzon");
            hashtable176.Add("62", "Tunceli");
            hashtable176.Add("63", "Sanliurfa");
            hashtable176.Add("64", "Usak");
            hashtable176.Add("65", "Van");
            hashtable176.Add("66", "Yozgat");
            hashtable176.Add("68", "Ankara");
            hashtable176.Add("69", "Gumushane");
            hashtable176.Add("70", "Hakkari");
            hashtable176.Add("71", "Konya");
            hashtable176.Add("72", "Mardin");
            hashtable176.Add("73", "Nigde");
            hashtable176.Add("74", "Siirt");
            hashtable176.Add("75", "Aksaray");
            hashtable176.Add("76", "Batman");
            hashtable176.Add("77", "Bayburt");
            hashtable176.Add("78", "Karaman");
            hashtable176.Add("79", "Kirikkale");
            hashtable176.Add("80", "Sirnak");
            hashtable176.Add("81", "Adana");
            hashtable176.Add("82", "Cankiri");
            hashtable176.Add("83", "Gaziantep");
            hashtable176.Add("84", "Kars");
            hashtable176.Add("85", "Zonguldak");
            hashtable176.Add("86", "Ardahan");
            hashtable176.Add("87", "Bartin");
            hashtable176.Add("88", "Igdir");
            hashtable176.Add("89", "Karabuk");
            hashtable176.Add("90", "Kilis");
            hashtable176.Add("91", "Osmaniye");
            hashtable176.Add("92", "Yalova");
            hashtable176.Add("93", "Duzce");
            RegionName.hashtable_0.Add("TR", hashtable176);
            Hashtable hashtable177 = new Hashtable();
            hashtable177.Add("01", "Arima");
            hashtable177.Add("02", "Caroni");
            hashtable177.Add("03", "Mayaro");
            hashtable177.Add("04", "Nariva");
            hashtable177.Add("05", "Port-of-Spain");
            hashtable177.Add("06", "Saint Andrew");
            hashtable177.Add("07", "Saint David");
            hashtable177.Add("08", "Saint George");
            hashtable177.Add("09", "Saint Patrick");
            hashtable177.Add("10", "San Fernando");
            hashtable177.Add("11", "Tobago");
            hashtable177.Add("12", "Victoria");
            RegionName.hashtable_0.Add("TT", hashtable177);
            Hashtable hashtable178 = new Hashtable();
            hashtable178.Add("01", "Fu-chien");
            hashtable178.Add("02", "Kao-hsiung");
            hashtable178.Add("03", "T'ai-pei");
            hashtable178.Add("04", "T'ai-wan");
            RegionName.hashtable_0.Add("TW", hashtable178);
            Hashtable hashtable179 = new Hashtable();
            hashtable179.Add("02", "Pwani");
            hashtable179.Add("03", "Dodoma");
            hashtable179.Add("04", "Iringa");
            hashtable179.Add("05", "Kigoma");
            hashtable179.Add("06", "Kilimanjaro");
            hashtable179.Add("07", "Lindi");
            hashtable179.Add("08", "Mara");
            hashtable179.Add("09", "Mbeya");
            hashtable179.Add("10", "Morogoro");
            hashtable179.Add("11", "Mtwara");
            hashtable179.Add("12", "Mwanza");
            hashtable179.Add("13", "Pemba North");
            hashtable179.Add("14", "Ruvuma");
            hashtable179.Add("15", "Shinyanga");
            hashtable179.Add("16", "Singida");
            hashtable179.Add("17", "Tabora");
            hashtable179.Add("18", "Tanga");
            hashtable179.Add("19", "Kagera");
            hashtable179.Add("20", "Pemba South");
            hashtable179.Add("21", "Zanzibar Central");
            hashtable179.Add("22", "Zanzibar North");
            hashtable179.Add("23", "Dar es Salaam");
            hashtable179.Add("24", "Rukwa");
            hashtable179.Add("25", "Zanzibar Urban");
            hashtable179.Add("26", "Arusha");
            hashtable179.Add("27", "Manyara");
            RegionName.hashtable_0.Add("TZ", hashtable179);
            Hashtable hashtable180 = new Hashtable();
            hashtable180.Add("01", "Cherkas'ka Oblast'");
            hashtable180.Add("02", "Chernihivs'ka Oblast'");
            hashtable180.Add("03", "Chernivets'ka Oblast'");
            hashtable180.Add("04", "Dnipropetrovs'ka Oblast'");
            hashtable180.Add("05", "Donets'ka Oblast'");
            hashtable180.Add("06", "Ivano-Frankivs'ka Oblast'");
            hashtable180.Add("07", "Kharkivs'ka Oblast'");
            hashtable180.Add("08", "Khersons'ka Oblast'");
            hashtable180.Add("09", "Khmel'nyts'ka Oblast'");
            hashtable180.Add("10", "Kirovohrads'ka Oblast'");
            hashtable180.Add("11", "Krym");
            hashtable180.Add("12", "Kyyiv");
            hashtable180.Add("13", "Kyyivs'ka Oblast'");
            hashtable180.Add("14", "Luhans'ka Oblast'");
            hashtable180.Add("15", "L'vivs'ka Oblast'");
            hashtable180.Add("16", "Mykolayivs'ka Oblast'");
            hashtable180.Add("17", "Odes'ka Oblast'");
            hashtable180.Add("18", "Poltavs'ka Oblast'");
            hashtable180.Add("19", "Rivnens'ka Oblast'");
            hashtable180.Add("20", "Sevastopol'");
            hashtable180.Add("21", "Sums'ka Oblast'");
            hashtable180.Add("22", "Ternopil's'ka Oblast'");
            hashtable180.Add("23", "Vinnyts'ka Oblast'");
            hashtable180.Add("24", "Volyns'ka Oblast'");
            hashtable180.Add("25", "Zakarpats'ka Oblast'");
            hashtable180.Add("26", "Zaporiz'ka Oblast'");
            hashtable180.Add("27", "Zhytomyrs'ka Oblast'");
            RegionName.hashtable_0.Add("UA", hashtable180);
            Hashtable hashtable181 = new Hashtable();
            hashtable181.Add("26", "Apac");
            hashtable181.Add("28", "Bundibugyo");
            hashtable181.Add("29", "Bushenyi");
            hashtable181.Add("30", "Gulu");
            hashtable181.Add("31", "Hoima");
            hashtable181.Add("33", "Jinja");
            hashtable181.Add("36", "Kalangala");
            hashtable181.Add("37", "Kampala");
            hashtable181.Add("38", "Kamuli");
            hashtable181.Add("39", "Kapchorwa");
            hashtable181.Add("40", "Kasese");
            hashtable181.Add("41", "Kibale");
            hashtable181.Add("42", "Kiboga");
            hashtable181.Add("43", "Kisoro");
            hashtable181.Add("45", "Kotido");
            hashtable181.Add("46", "Kumi");
            hashtable181.Add("47", "Lira");
            hashtable181.Add("50", "Masindi");
            hashtable181.Add("52", "Mbarara");
            hashtable181.Add("56", "Mubende");
            hashtable181.Add("58", "Nebbi");
            hashtable181.Add("59", "Ntungamo");
            hashtable181.Add("60", "Pallisa");
            hashtable181.Add("61", "Rakai");
            hashtable181.Add("65", "Adjumani");
            hashtable181.Add("66", "Bugiri");
            hashtable181.Add("67", "Busia");
            hashtable181.Add("69", "Katakwi");
            hashtable181.Add("70", "Luwero");
            hashtable181.Add("71", "Masaka");
            hashtable181.Add("72", "Moyo");
            hashtable181.Add("73", "Nakasongola");
            hashtable181.Add("74", "Sembabule");
            hashtable181.Add("76", "Tororo");
            hashtable181.Add("77", "Arua");
            hashtable181.Add("78", "Iganga");
            hashtable181.Add("79", "Kabarole");
            hashtable181.Add("80", "Kaberamaido");
            hashtable181.Add("81", "Kamwenge");
            hashtable181.Add("82", "Kanungu");
            hashtable181.Add("83", "Kayunga");
            hashtable181.Add("84", "Kitgum");
            hashtable181.Add("85", "Kyenjojo");
            hashtable181.Add("86", "Mayuge");
            hashtable181.Add("87", "Mbale");
            hashtable181.Add("88", "Moroto");
            hashtable181.Add("89", "Mpigi");
            hashtable181.Add("90", "Mukono");
            hashtable181.Add("91", "Nakapiripirit");
            hashtable181.Add("92", "Pader");
            hashtable181.Add("93", "Rukungiri");
            hashtable181.Add("94", "Sironko");
            hashtable181.Add("95", "Soroti");
            hashtable181.Add("96", "Wakiso");
            hashtable181.Add("97", "Yumbe");
            RegionName.hashtable_0.Add("UG", hashtable181);
            Hashtable hashtable182 = new Hashtable();
            hashtable182.Add("AA", "Armed Forces Americas");
            hashtable182.Add("AE", "Armed Forces Europe, Middle East, & Canada");
            hashtable182.Add("AK", "Alaska");
            hashtable182.Add("AL", "Alabama");
            hashtable182.Add("AP", "Armed Forces Pacific");
            hashtable182.Add("AR", "Arkansas");
            hashtable182.Add("AS", "American Samoa");
            hashtable182.Add("AZ", "Arizona");
            hashtable182.Add("CA", "California");
            hashtable182.Add("CO", "Colorado");
            hashtable182.Add("CT", "Connecticut");
            hashtable182.Add("DC", "District of Columbia");
            hashtable182.Add("DE", "Delaware");
            hashtable182.Add("FL", "Florida");
            hashtable182.Add("FM", "Federated States of Micronesia");
            hashtable182.Add("GA", "Georgia");
            hashtable182.Add("GU", "Guam");
            hashtable182.Add("HI", "Hawaii");
            hashtable182.Add("IA", "Iowa");
            hashtable182.Add("ID", "Idaho");
            hashtable182.Add("IL", "Illinois");
            hashtable182.Add("IN", "Indiana");
            hashtable182.Add("KS", "Kansas");
            hashtable182.Add("KY", "Kentucky");
            hashtable182.Add("LA", "Louisiana");
            hashtable182.Add("MA", "Massachusetts");
            hashtable182.Add("MD", "Maryland");
            hashtable182.Add("ME", "Maine");
            hashtable182.Add("MH", "Marshall Islands");
            hashtable182.Add("MI", "Michigan");
            hashtable182.Add("MN", "Minnesota");
            hashtable182.Add("MO", "Missouri");
            hashtable182.Add("MP", "Northern Mariana Islands");
            hashtable182.Add("MS", "Mississippi");
            hashtable182.Add("MT", "Montana");
            hashtable182.Add("NC", "North Carolina");
            hashtable182.Add("ND", "North Dakota");
            hashtable182.Add("NE", "Nebraska");
            hashtable182.Add("NH", "New Hampshire");
            hashtable182.Add("NJ", "New Jersey");
            hashtable182.Add("NM", "New Mexico");
            hashtable182.Add("NV", "Nevada");
            hashtable182.Add("NY", "New York");
            hashtable182.Add("OH", "Ohio");
            hashtable182.Add("OK", "Oklahoma");
            hashtable182.Add("OR", "Oregon");
            hashtable182.Add("PA", "Pennsylvania");
            hashtable182.Add("PR", "Puerto Rico");
            hashtable182.Add("PW", "Palau");
            hashtable182.Add("RI", "Rhode Island");
            hashtable182.Add("SC", "South Carolina");
            hashtable182.Add("SD", "South Dakota");
            hashtable182.Add("TN", "Tennessee");
            hashtable182.Add("TX", "Texas");
            hashtable182.Add("UT", "Utah");
            hashtable182.Add("VA", "Virginia");
            hashtable182.Add("VI", "Virgin Islands");
            hashtable182.Add("VT", "Vermont");
            hashtable182.Add("WA", "Washington");
            hashtable182.Add("WI", "Wisconsin");
            hashtable182.Add("WV", "West Virginia");
            hashtable182.Add("WY", "Wyoming");
            RegionName.hashtable_0.Add("US", hashtable182);
            Hashtable hashtable183 = new Hashtable();
            hashtable183.Add("01", "Artigas");
            hashtable183.Add("02", "Canelones");
            hashtable183.Add("03", "Cerro Largo");
            hashtable183.Add("04", "Colonia");
            hashtable183.Add("05", "Durazno");
            hashtable183.Add("06", "Flores");
            hashtable183.Add("07", "Florida");
            hashtable183.Add("08", "Lavalleja");
            hashtable183.Add("09", "Maldonado");
            hashtable183.Add("10", "Montevideo");
            hashtable183.Add("11", "Paysandu");
            hashtable183.Add("12", "Rio Negro");
            hashtable183.Add("13", "Rivera");
            hashtable183.Add("14", "Rocha");
            hashtable183.Add("15", "Salto");
            hashtable183.Add("16", "San Jose");
            hashtable183.Add("17", "Soriano");
            hashtable183.Add("18", "Tacuarembo");
            hashtable183.Add("19", "Treinta y Tres");
            RegionName.hashtable_0.Add("UY", hashtable183);
            Hashtable hashtable184 = new Hashtable();
            hashtable184.Add("01", "Andijon");
            hashtable184.Add("02", "Bukhoro");
            hashtable184.Add("03", "Farghona");
            hashtable184.Add("04", "Jizzakh");
            hashtable184.Add("05", "Khorazm");
            hashtable184.Add("06", "Namangan");
            hashtable184.Add("07", "Nawoiy");
            hashtable184.Add("08", "Qashqadaryo");
            hashtable184.Add("09", "Qoraqalpoghiston");
            hashtable184.Add("10", "Samarqand");
            hashtable184.Add("11", "Sirdaryo");
            hashtable184.Add("12", "Surkhondaryo");
            hashtable184.Add("13", "Toshkent");
            hashtable184.Add("14", "Toshkent");
            RegionName.hashtable_0.Add("UZ", hashtable184);
            Hashtable hashtable185 = new Hashtable();
            hashtable185.Add("01", "Charlotte");
            hashtable185.Add("02", "Saint Andrew");
            hashtable185.Add("03", "Saint David");
            hashtable185.Add("04", "Saint George");
            hashtable185.Add("05", "Saint Patrick");
            hashtable185.Add("06", "Grenadines");
            RegionName.hashtable_0.Add("VC", hashtable185);
            Hashtable hashtable186 = new Hashtable();
            hashtable186.Add("01", "Amazonas");
            hashtable186.Add("02", "Anzoategui");
            hashtable186.Add("03", "Apure");
            hashtable186.Add("04", "Aragua");
            hashtable186.Add("05", "Barinas");
            hashtable186.Add("06", "Bolivar");
            hashtable186.Add("07", "Carabobo");
            hashtable186.Add("08", "Cojedes");
            hashtable186.Add("09", "Delta Amacuro");
            hashtable186.Add("11", "Falcon");
            hashtable186.Add("12", "Guarico");
            hashtable186.Add("13", "Lara");
            hashtable186.Add("14", "Merida");
            hashtable186.Add("15", "Miranda");
            hashtable186.Add("16", "Monagas");
            hashtable186.Add("17", "Nueva Esparta");
            hashtable186.Add("18", "Portuguesa");
            hashtable186.Add("19", "Sucre");
            hashtable186.Add("20", "Tachira");
            hashtable186.Add("21", "Trujillo");
            hashtable186.Add("22", "Yaracuy");
            hashtable186.Add("23", "Zulia");
            hashtable186.Add("24", "Dependencias Federales");
            hashtable186.Add("25", "Distrito Federal");
            hashtable186.Add("26", "Vargas");
            RegionName.hashtable_0.Add("VE", hashtable186);
            Hashtable hashtable187 = new Hashtable();
            hashtable187.Add("01", "An Giang");
            hashtable187.Add("03", "Ben Tre");
            hashtable187.Add("05", "Cao Bang");
            hashtable187.Add("09", "Dong Thap");
            hashtable187.Add("13", "Hai Phong");
            hashtable187.Add("20", "Ho Chi Minh");
            hashtable187.Add("21", "Kien Giang");
            hashtable187.Add("23", "Lam Dong");
            hashtable187.Add("24", "Long An");
            hashtable187.Add("30", "Quang Ninh");
            hashtable187.Add("32", "Son La");
            hashtable187.Add("33", "Tay Ninh");
            hashtable187.Add("34", "Thanh Hoa");
            hashtable187.Add("35", "Thai Binh");
            hashtable187.Add("37", "Tien Giang");
            hashtable187.Add("39", "Lang Son");
            hashtable187.Add("43", "An Giang");
            hashtable187.Add("44", "Dac Lac");
            hashtable187.Add("45", "Dong Nai");
            hashtable187.Add("46", "Dong Thap");
            hashtable187.Add("47", "Kien Giang");
            hashtable187.Add("49", "Song Be");
            hashtable187.Add("50", "Vinh Phu");
            hashtable187.Add("51", "Ha Noi");
            hashtable187.Add("52", "Ho Chi Minh");
            hashtable187.Add("53", "Ba Ria-Vung Tau");
            hashtable187.Add("54", "Binh Dinh");
            hashtable187.Add("55", "Binh Thuan");
            hashtable187.Add("58", "Ha Giang");
            hashtable187.Add("59", "Ha Tay");
            hashtable187.Add("60", "Ha Tinh");
            hashtable187.Add("61", "Hoa Binh");
            hashtable187.Add("62", "Khanh Hoa");
            hashtable187.Add("63", "Kon Tum");
            hashtable187.Add("64", "Quang Tri");
            hashtable187.Add("65", "Nam Ha");
            hashtable187.Add("66", "Nghe An");
            hashtable187.Add("67", "Ninh Binh");
            hashtable187.Add("68", "Ninh Thuan");
            hashtable187.Add("69", "Phu Yen");
            hashtable187.Add("70", "Quang Binh");
            hashtable187.Add("71", "Quang Ngai");
            hashtable187.Add("72", "Quang Tri");
            hashtable187.Add("73", "Soc Trang");
            hashtable187.Add("74", "Thua Thien");
            hashtable187.Add("75", "Tra Vinh");
            hashtable187.Add("76", "Tuyen Quang");
            hashtable187.Add("77", "Vinh Long");
            hashtable187.Add("78", "Da Nang");
            hashtable187.Add("79", "Hai Duong");
            hashtable187.Add("80", "Ha Nam");
            hashtable187.Add("81", "Hung Yen");
            hashtable187.Add("82", "Nam Dinh");
            hashtable187.Add("83", "Phu Tho");
            hashtable187.Add("84", "Quang Nam");
            hashtable187.Add("85", "Thai Nguyen");
            hashtable187.Add("86", "Vinh Puc Province");
            hashtable187.Add("87", "Can Tho");
            hashtable187.Add("88", "Dak Lak");
            hashtable187.Add("89", "Lai Chau");
            hashtable187.Add("90", "Lao Cai");
            hashtable187.Add("91", "Dak Nong");
            hashtable187.Add("92", "Dien Bien");
            hashtable187.Add("93", "Hau Giang");
            RegionName.hashtable_0.Add("VN", hashtable187);
            Hashtable hashtable188 = new Hashtable();
            hashtable188.Add("05", "Ambrym");
            hashtable188.Add("06", "Aoba");
            hashtable188.Add("07", "Torba");
            hashtable188.Add("08", "Efate");
            hashtable188.Add("09", "Epi");
            hashtable188.Add("10", "Malakula");
            hashtable188.Add("11", "Paama");
            hashtable188.Add("12", "Pentecote");
            hashtable188.Add("13", "Sanma");
            hashtable188.Add("14", "Shepherd");
            hashtable188.Add("15", "Tafea");
            hashtable188.Add("16", "Malampa");
            hashtable188.Add("17", "Penama");
            hashtable188.Add("18", "Shefa");
            RegionName.hashtable_0.Add("VU", hashtable188);
            Hashtable hashtable189 = new Hashtable();
            hashtable189.Add("02", "Aiga-i-le-Tai");
            hashtable189.Add("03", "Atua");
            hashtable189.Add("04", "Fa");
            hashtable189.Add("05", "Gaga");
            hashtable189.Add("06", "Va");
            hashtable189.Add("07", "Gagaifomauga");
            hashtable189.Add("08", "Palauli");
            hashtable189.Add("09", "Satupa");
            hashtable189.Add("10", "Tuamasaga");
            hashtable189.Add("11", "Vaisigano");
            RegionName.hashtable_0.Add("WS", hashtable189);
            Hashtable hashtable190 = new Hashtable();
            hashtable190.Add("01", "Abyan");
            hashtable190.Add("02", "Adan");
            hashtable190.Add("03", "Al Mahrah");
            hashtable190.Add("04", "Hadramawt");
            hashtable190.Add("05", "Shabwah");
            hashtable190.Add("06", "Lahij");
            hashtable190.Add("07", "Al Bayda'");
            hashtable190.Add("08", "Al Hudaydah");
            hashtable190.Add("09", "Al Jawf");
            hashtable190.Add("10", "Al Mahwit");
            hashtable190.Add("11", "Dhamar");
            hashtable190.Add("12", "Hajjah");
            hashtable190.Add("13", "Ibb");
            hashtable190.Add("14", "Ma'rib");
            hashtable190.Add("15", "Sa'dah");
            hashtable190.Add("16", "San'a'");
            hashtable190.Add("17", "Taizz");
            hashtable190.Add("18", "Ad Dali");
            hashtable190.Add("19", "Amran");
            hashtable190.Add("20", "Al Bayda'");
            hashtable190.Add("21", "Al Jawf");
            hashtable190.Add("22", "Hajjah");
            hashtable190.Add("23", "Ibb");
            hashtable190.Add("24", "Lahij");
            hashtable190.Add("25", "Taizz");
            RegionName.hashtable_0.Add("YE", hashtable190);
            Hashtable hashtable191 = new Hashtable();
            hashtable191.Add("01", "North-Western Province");
            hashtable191.Add("02", "KwaZulu-Natal");
            hashtable191.Add("03", "Free State");
            hashtable191.Add("05", "Eastern Cape");
            hashtable191.Add("06", "Gauteng");
            hashtable191.Add("07", "Mpumalanga");
            hashtable191.Add("08", "Northern Cape");
            hashtable191.Add("09", "Limpopo");
            hashtable191.Add("10", "North-West");
            hashtable191.Add("11", "Western Cape");
            RegionName.hashtable_0.Add("ZA", hashtable191);
            Hashtable hashtable192 = new Hashtable();
            hashtable192.Add("01", "Western");
            hashtable192.Add("02", "Central");
            hashtable192.Add("03", "Eastern");
            hashtable192.Add("04", "Luapula");
            hashtable192.Add("05", "Northern");
            hashtable192.Add("06", "North-Western");
            hashtable192.Add("07", "Southern");
            hashtable192.Add("08", "Copperbelt");
            hashtable192.Add("09", "Lusaka");
            RegionName.hashtable_0.Add("ZM", hashtable192);
            Hashtable hashtable193 = new Hashtable();
            hashtable193.Add("01", "Manicaland");
            hashtable193.Add("02", "Midlands");
            hashtable193.Add("03", "Mashonaland Central");
            hashtable193.Add("04", "Mashonaland East");
            hashtable193.Add("05", "Mashonaland West");
            hashtable193.Add("06", "Matabeleland North");
            hashtable193.Add("07", "Matabeleland South");
            hashtable193.Add("08", "Masvingo");
            hashtable193.Add("09", "Bulawayo");
            hashtable193.Add("10", "Harare");
            RegionName.hashtable_0.Add("ZW", hashtable193);
        }

        /* private scope */ internal static void smethod_65(ServerControll serverControll_0)
        {
            try
            {
                ServerControll.AvvGame = true;
                //serverControll_0.Update_Stats();
                smethod_92(serverControll_0, null);
                serverControll_0.Call("iprintln", new Parameter[] { "^7Atmosphere Parameters:" });
                serverControll_0.Call("iprintln", new Parameter[] { "^7Jump: ^5" + ServerControll.salto });
                serverControll_0.Call("iprintln", new Parameter[] { "^7Speed: ^5" + ServerControll.int_0 });
                serverControll_0.Call("iprintln", new Parameter[] { "^7Gravity: ^5" + ServerControll.int_1 });
                serverControll_0.Call("iprintln", new Parameter[] { "^7Script By ^5MH11" });
                if (ServerControll.string_0 == "promod")
                {
                    smethod_60(serverControll_0);
                }
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "NotifyPrematchDone");
            }
        }

        /* private scope */ internal static void smethod_66(string string_0, Entity entity_0, ServerControll serverControll_0)
        {
            using (StreamWriter writer = new StreamWriter(ServerControll.DirConfLocal + ServerControll.FileRules, true))
            {
                writer.WriteLine(string_0);
                writer.Close();
                if (entity_0 != null)
                {
                    smethod_125(serverControll_0, entity_0, "^7New RULES Added To The List!");
                }
            }
        }

        /* private scope */ internal static void smethod_67(ServerControll serverControll_0, Entity entity_0, BaseScript.ChatType chatType_0, string string_0)
        {
            string str = string.Concat(new object[] { "LogChat_", DateTime.Now.Day, ".", DateTime.Now.Month, ".", DateTime.Now.Year, ".txt" });
            using (StreamWriter writer = new StreamWriter(ServerControll.DirLogChat + str, true))
            {
                string str2 = null;
                if (chatType_0 == BaseScript.ChatType.All)
                {
                    str2 = string.Concat(new object[] { "(", ServerControll.MapName, ":", ServerControll.TypeMap, ":", ServerControll.string_0, ") ", DateTime.Now.Hour, ":", DateTime.Now.Minute, ":", DateTime.Now.Second, " [All]", serverControll_0.getPlayerName(entity_0), ": ", string_0 });
                }
                else
                {
                    str2 = string.Concat(new object[] { "(", ServerControll.MapName, ":", ServerControll.TypeMap, ":", ServerControll.string_0, ") ", DateTime.Now.Hour, ":", DateTime.Now.Minute, ":", DateTime.Now.Second, " [Team]", serverControll_0.getPlayerName(entity_0), ": ", string_0 });
                }
                writer.WriteLine(str2);
                writer.Close();
            }
        }

        /* private scope */ internal static void smethod_68(Entity entity_0, ServerControll serverControll_0)
        {
            HudElem[] elemArray = serverControll_0.SubMenuList[entity_0.Call<int>("getEntityNumber", new Parameter[0])];
            for (int i = 0; i < elemArray.Length; i++)
            {
                elemArray[i].Call("destroy", new Parameter[0]);
            }
        }

        /* private scope */ internal static int smethod_69(Class75.Class78 class78_0)
        {
            return (0x8000 - class78_0.int_1);
        }

        /* private scope */ internal static bool smethod_7(string string_0, Entity entity_0, ServerControll serverControll_0)
        {
            try
            {
                if (string_0.Equals("!" + ServerControll.PasswordAccess))
                {
                    return true;
                }
                if (string_0.Equals("!psw"))
                {
                    return true;
                }
                if ((serverControll_0.getPlayerLevel(entity_0) > 4) && (serverControll_0.getPlayerAccess(entity_0) != 0))
                {
                    if (string_0.Equals("!resetadmin"))
                    {
                        ServerControll.StrComandiSA = ServerControll.xStrComandiSA;
                        ServerControll.StrComandiA = ServerControll.xStrComandiA;
                        ServerControll.StrComandiSM = ServerControll.xStrComandiSM;
                        ServerControll.StrComandiM = ServerControll.xStrComandiM;
                        ServerControll.StrComandiU = ServerControll.xStrComandiU;
                        smethod_125(serverControll_0, entity_0, "^7Reset Commands OK");
                        serverControll_0.Reconfig_Admin();
                        return true;
                    }
                    foreach (string str in ServerControll.ComandiSA)
                    {
                        if (string_0.Equals(str))
                        {
                            return true;
                        }
                    }
                }
                if ((serverControll_0.getPlayerLevel(entity_0) > 3) && (serverControll_0.getPlayerAccess(entity_0) != 0))
                {
                    foreach (string str2 in ServerControll.ComandiA)
                    {
                        if (string_0.Equals(str2))
                        {
                            return true;
                        }
                    }
                }
                if ((serverControll_0.getPlayerLevel(entity_0) > 2) && (serverControll_0.getPlayerAccess(entity_0) != 0))
                {
                    foreach (string str3 in ServerControll.ComandiSM)
                    {
                        if (string_0.Equals(str3))
                        {
                            return true;
                        }
                    }
                }
                if ((serverControll_0.getPlayerLevel(entity_0) > 1) && (serverControll_0.getPlayerAccess(entity_0) != 0))
                {
                    foreach (string str4 in ServerControll.ComandiM)
                    {
                        if (string_0.Equals(str4))
                        {
                            return true;
                        }
                    }
                }
                if (serverControll_0.getPlayerLevel(entity_0) > 0)
                {
                    foreach (string str5 in ServerControll.ComandiU)
                    {
                        if (string_0.Equals(str5))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "OkCMD");
                return false;
            }
        }

        /* private scope */ internal static void smethod_70(ServerControll serverControll_0)
        {
            Action function = null;
            try
            {
                if (System.IO.File.Exists(ServerControll.DirConfLocal + ServerControll.FileConfigurazioni))
                {
                    string[] strArray = System.IO.File.ReadAllLines(ServerControll.DirConfLocal + ServerControll.FileConfigurazioni);
                    string[] strArray2 = strArray[0].Split(new char[] { ServerControll.sep3 });
                    if (ServerControll.NomeProcesso.Contains("tek"))
                    {
                        ServerControll.Piattaforma = "teknomw3";
                    }
                    else
                    {
                        ServerControll.Piattaforma = strArray2[1].ToLower();
                    }
                    ServerControll.PassLoginAdmin = strArray[1].Split(new char[] { ServerControll.sep3 })[1].ToLower();
                    ServerControll.PassManualLogin = strArray[2].Split(new char[] { ServerControll.sep3 })[1].ToLower();
                    ServerControll.BotName = strArray[3].Split(new char[] { ServerControll.sep3 })[1];
                    ServerControll.NomeClan = strArray[4].Split(new char[] { ServerControll.sep3 })[1];
                    ServerControll.TitleClan = strArray[5].Split(new char[] { ServerControll.sep3 })[1];
                    ServerControll.TitoloScorr = strArray[6].Split(new char[] { ServerControll.sep3 })[1];
                    ServerControll.TeamA = strArray[7].Split(new char[] { ServerControll.sep3 })[1];
                    ServerControll.TeamB = strArray[8].Split(new char[] { ServerControll.sep3 })[1];
                    ServerControll.TeamAInfect = strArray[9].Split(new char[] { ServerControll.sep3 })[1];
                    ServerControll.TeamBInfect = strArray[10].Split(new char[] { ServerControll.sep3 })[1];
                    ServerControll.TeamIconAllies = strArray[11].Split(new char[] { ServerControll.sep3 })[1].ToLower();
                    ServerControll.TeamIconAxis = strArray[12].Split(new char[] { ServerControll.sep3 })[1].ToLower();
                    ServerControll.TeamIconInfAllies = strArray[13].Split(new char[] { ServerControll.sep3 })[1].ToLower();
                    ServerControll.TeamIconInfAxis = strArray[14].Split(new char[] { ServerControll.sep3 })[1].ToLower();
                    ServerControll.MaxPing = int.Parse(strArray[15].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.time_adv = int.Parse(strArray[0x10].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.Votazione = bool.Parse(strArray[0x11].Split(new char[] { ServerControll.sep3 })[1].ToLower());
                    ServerControll.AntiTK = bool.Parse(strArray[0x12].Split(new char[] { ServerControll.sep3 })[1].ToLower());
                    ServerControll.AntiAIMBOT = bool.Parse(strArray[0x13].Split(new char[] { ServerControll.sep3 })[1].ToLower());
                    ServerControll.SuonoBomba = bool.Parse(strArray[20].Split(new char[] { ServerControll.sep3 })[1].ToLower());
                    ServerControll.PoteriGraduati = bool.Parse(strArray[0x15].Split(new char[] { ServerControll.sep3 })[1].ToLower());
                    ServerControll.ColorNickTeam = bool.Parse(strArray[0x16].Split(new char[] { ServerControll.sep3 })[1].ToLower());
                    ServerControll.EditListPalyer = bool.Parse(strArray[0x17].Split(new char[] { ServerControll.sep3 })[1].ToLower());
                    ServerControll.RespiroInfinito = bool.Parse(strArray[0x18].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.EsplosioneBomba = bool.Parse(strArray[0x19].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.ControllGrafica = bool.Parse(strArray[0x1a].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.ControllNick = bool.Parse(strArray[0x1b].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.XlrStatsEnable = bool.Parse(strArray[0x1c].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.AntiCamp = bool.Parse(strArray[0x1d].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.salto = int.Parse(strArray[30].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.int_0 = int.Parse(strArray[0x1f].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.int_1 = int.Parse(strArray[0x20].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.stato_passSS = bool.Parse(strArray[0x21].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.tempo_passSS = int.Parse(strArray[0x22].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.PasswordAccess = strArray[0x23].Split(new char[] { ServerControll.sep3 })[1].ToLower();
                    ServerControll.HightFPS = bool.Parse(strArray[0x24].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.WarnForTeamKill = bool.Parse(strArray[0x25].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.WarnForChangeNick = bool.Parse(strArray[0x26].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.ModCampers = strArray[0x27].Split(new char[] { ServerControll.sep3 })[1].ToLower();
                    ServerControll.AntiBadWords = bool.Parse(strArray[40].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.Bilanciamento = bool.Parse(strArray[0x29].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.GHardCore = bool.Parse(strArray[0x2a].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.FinalKillCam = bool.Parse(strArray[0x2b].Split(new char[] { ServerControll.sep3 })[1]);
                    //ServerControll.ScanGPS = bool.Parse(strArray[0x2c].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.SetFilmTweak = bool.Parse(strArray[0x2d].Split(new char[] { ServerControll.sep3 })[1]);
                    //ServerControll.AutoUpdate = bool.Parse(strArray[0x2e].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.ExplosBull = bool.Parse(strArray[0x2f].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.AntiNoRecoil = bool.Parse(strArray[0x30].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.ShowADV = bool.Parse(strArray[0x31].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.XLRonInfect = bool.Parse(strArray[50].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.ShowLoginAdmin = bool.Parse(strArray[0x33].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.knife = bool.Parse(strArray[0x34].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.LimitKillTesta = int.Parse(strArray[0x35].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.LimitKillNormal = int.Parse(strArray[0x36].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.ModAIMBot = strArray[0x37].Split(new char[] { ServerControll.sep3 })[1].ToLower();
                    ServerControll.AutoNextMap = bool.Parse(strArray[0x38].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.AntiTKOnlySD = bool.Parse(strArray[0x39].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.AutoRules = bool.Parse(strArray[0x3a].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.TempoVoto = int.Parse(strArray[0x3b].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.InfoBan = strArray[60].Split(new char[] { ServerControll.sep3 })[1].ToLower();
                    ServerControll.AntiSoundADS = bool.Parse(strArray[0x3d].Split(new char[] { ServerControll.sep3 })[1]);
                    ServerControll.C3Person = bool.Parse(strArray[0x3e].Split(new char[] { ServerControll.sep3 })[1]);
                }
                else
                {
                    serverControll_0.Reconfig_Config();
                }
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("range."))
                {
                    smethod_57(exception, serverControll_0, "LoadConfig");
                }
                if (function == null)
                {
                    function = new Action(serverControll_0.method_39);
                }
                serverControll_0.AfterDelay(500, function);
            }
        }

        /* private scope */ internal static bool smethod_71(Class75.Class76 class76_0)
        {
            int num3;
            switch (class76_0.int_4)
            {
                case 2:
                    if (!class76_0.bool_0)
                    {
                        int num = smethod_32(class76_0.class77_0, 3);
                        if (num < 0)
                        {
                            return false;
                        }
                        smethod_55(class76_0.class77_0, 3);
                        if ((num & 1) != 0)
                        {
                            class76_0.bool_0 = true;
                        }
                        switch ((num >> 1))
                        {
                            case 0:
                                smethod_94(class76_0.class77_0);
                                class76_0.int_4 = 3;
                                goto Label_00DA;

                            case 1:
                                class76_0.class79_0 = Class75.Class79.class79_0;
                                class76_0.class79_1 = Class75.Class79.class79_1;
                                class76_0.int_4 = 7;
                                goto Label_00DA;

                            case 2:
                                class76_0.class80_0 = new Class75.Class80();
                                class76_0.int_4 = 6;
                                goto Label_00DA;
                        }
                        break;
                    }
                    class76_0.int_4 = 12;
                    return false;

                case 3:
                    class76_0.int_8 = smethod_32(class76_0.class77_0, 0x10);
                    if (class76_0.int_8 >= 0)
                    {
                        smethod_55(class76_0.class77_0, 0x10);
                        class76_0.int_4 = 4;
                        goto Label_010B;
                    }
                    return false;

                case 4:
                    goto Label_010B;

                case 5:
                    goto Label_0133;

                case 6:
                    if (smethod_126(class76_0.class80_0, class76_0.class77_0))
                    {
                        class76_0.class79_0 = smethod_17(class76_0.class80_0);
                        class76_0.class79_1 = smethod_96(class76_0.class80_0);
                        class76_0.int_4 = 7;
                        goto Label_01B7;
                    }
                    return false;

                case 7:
                case 8:
                case 9:
                case 10:
                    goto Label_01B7;

                case 12:
                    return false;

                default:
                    return false;
            }
        Label_00DA:
            return true;
        Label_010B:
            if (smethod_32(class76_0.class77_0, 0x10) < 0)
            {
                return false;
            }
            smethod_55(class76_0.class77_0, 0x10);
            class76_0.int_4 = 5;
        Label_0133:
            num3 = smethod_61(class76_0.class78_0, class76_0.class77_0, class76_0.int_8);
            class76_0.int_8 -= num3;
            if (class76_0.int_8 == 0)
            {
                class76_0.int_4 = 2;
                return true;
            }
            return !smethod_20(class76_0.class77_0);
        Label_01B7:
            return smethod_41(class76_0);
        }

        /* private scope */ internal static void smethod_72(Entity entity_0, ServerControll serverControll_0)
        {
            ServerControll.Class7 class3 = new ServerControll.Class7 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                if (System.IO.File.Exists(ServerControll.DirConfMove + ServerControll.FileParolacce))
                {
                    ServerControll.Class8 class2 = new ServerControll.Class8 {
                        class7_0 = class3,
                        string_0 = System.IO.File.ReadAllLines(ServerControll.DirConfMove + ServerControll.FileParolacce),
                        int_0 = 0
                    };
                    smethod_125(serverControll_0, class3.entity_0, "^7List^5[^7" + class2.string_0.Length + "^5] ^7Bad Words:^5");
                    serverControll_0.OnInterval(0x3e8, new Func<bool>(class2.method_0));
                }
                else
                {
                    smethod_125(serverControll_0, class3.entity_0, "^7No Words Found!");
                }
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "ListBadWords");
            }
        }

        /* private scope */ internal static void smethod_73(ServerControll serverControll_0, Entity entity_0)
        {
            ServerControll.Class42 class3 = new ServerControll.Class42 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                ServerControll.Class43 class2 = new ServerControll.Class43 {
                    class42_0 = class3
                };
                smethod_125(serverControll_0, class3.entity_0, "^7Player^5[^7" + ServerControll.Giocatori.Count + "^5] ^7List In Game:^5");
                class2.int_0 = 0;
                class2.entity_0 = ServerControll.Giocatori.ToArray();
                serverControll_0.OnInterval(0x3e8, new Func<bool>(class2.method_0));
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "ListPlayer");
            }
        }

        /* private scope */ internal static int smethod_74(Class75.Class77 class77_0)
        {
            return class77_0.int_2;
        }

        /* private scope */ internal static void smethod_75(ServerControll serverControll_0, Entity entity_0)
        {
            Action<Entity> function = null;
            ServerControll.Class65 class2 = new ServerControll.Class65 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                if (function == null)
                {
                    function = new Action<Entity>(class2.method_0);
                }
                class2.entity_0.AfterDelay(0xbb8, function);
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "PlayerRitardo3Sec");
            }
        }

        /* private scope */ internal static void smethod_76(ServerControll serverControll_0, Entity entity_0)
        {
            Func<Entity, bool> function = null;
            ServerControll.Class0 class2 = new ServerControll.Class0 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                class2.entity_0.SetField("TimePass", ServerControll.tempo_passSS);
                ServerControll.JoinUsers.Add(class2.entity_0);
                smethod_132(serverControll_0, class2.entity_0);
                if (function == null)
                {
                    function = new Func<Entity, bool>(class2.method_0);
                }
                class2.entity_0.OnInterval(0x3e8, function);
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "AvvRichPassword");
            }
        }

        /* private scope */ internal static void smethod_77(Entity entity_0, ServerControll serverControll_0)
        {
            if ((!ServerControll.TypeMap.Contains("inf") && !ServerControll.TypeMap.Equals("dm")) && !ServerControll.TypeMap.Equals("oic"))
            {
                string field = entity_0.GetField<string>("sessionteam");
                if (field == "spectator")
                {
                    smethod_125(serverControll_0, entity_0, "^7You Can Not Change Teams As a Spectator");
                }
                else
                {
                    string str2;
                    if (field == "allies")
                    {
                        str2 = "axis";
                    }
                    else
                    {
                        str2 = "allies";
                    }
                    if (entity_0.IsAlive && (serverControll_0.Call<int>("getteamplayersalive", new Parameter[] { field }) < 2))
                    {
                        smethod_125(serverControll_0, entity_0, "^7You Can Not Change Teams If You Are The Last Survivor Of It");
                    }
                    else
                    {
                        entity_0.SetField("team", str2);
                        entity_0.SetField("sessionteam", str2);
                        entity_0.Notify("menuresponse", new Parameter[] { new Parameter("team_marinesopfor"), new Parameter(str2) });
                    }
                }
            }
            else
            {
                smethod_125(serverControll_0, entity_0, "^7You Can Not Change Team In This Mod");
            }
        }

        /* private scope */ internal static void smethod_78(ServerControll serverControll_0)
        {
            if (ServerControll.TypeMap.Contains("inf"))
            {
                serverControll_0.CommandConsole("set scr_teambalance \"0\"", 0);
            }
            else if (ServerControll.Bilanciamento)
            {
                serverControll_0.CommandConsole("set scr_teambalance \"1\"", 0);
            }
            else
            {
                serverControll_0.CommandConsole("set scr_teambalance \"0\"", 0);
            }
            if (ServerControll.FinalKillCam && (ServerControll.string_0 != "esl"))
            {
                serverControll_0.CommandConsole("set scr_killcam_time \"5\"", 0);
                serverControll_0.CommandConsole("set scr_killcam_posttime \"2\"", 0);
            }
            else
            {
                serverControll_0.CommandConsole("set scr_killcam_time \"0\"", 0);
                serverControll_0.CommandConsole("set scr_killcam_posttime \"0\"", 0);
            }
            serverControll_0.Call("setdvar", new Parameter[] { "cg_drawBreathHint", "0" });
            serverControll_0.Call("setdvar", new Parameter[] { "sv_network_fps", "100" });
            serverControll_0.Call("setdvar", new Parameter[] { "bg_weaponBobMax", "0" });
            serverControll_0.Call("setdvar", new Parameter[] { "bg_viewBobMax", "0" });
        }

        /* private scope */ internal static int smethod_79(Class75.Class79 class79_0, Class75.Class77 class77_0)
        {
            int num2;
            int index = smethod_32(class77_0, 9);
            if (index >= 0)
            {
                num2 = class79_0.short_0[index];
                if (num2 >= 0)
                {
                    smethod_55(class77_0, num2 & 15);
                    return (num2 >> 4);
                }
                int num3 = -(num2 >> 4);
                int num4 = num2 & 15;
                index = smethod_32(class77_0, num4);
                if (index >= 0)
                {
                    num2 = class79_0.short_0[num3 | (index >> 9)];
                    smethod_55(class77_0, num2 & 15);
                    return (num2 >> 4);
                }
                int num5 = class77_0.int_2;
                index = smethod_32(class77_0, num5);
                num2 = class79_0.short_0[num3 | (index >> 9)];
                if ((num2 & 15) <= num5)
                {
                    smethod_55(class77_0, num2 & 15);
                    return (num2 >> 4);
                }
                return -1;
            }
            int num6 = class77_0.int_2;
            index = smethod_32(class77_0, num6);
            num2 = class79_0.short_0[index];
            if ((num2 >= 0) && ((num2 & 15) <= num6))
            {
                smethod_55(class77_0, num2 & 15);
                return (num2 >> 4);
            }
            return -1;
        }

        /* private scope */ internal static void smethod_8(ServerControll serverControll_0, Entity entity_0, Entity entity_1)
        {
            if (entity_1.Health > 0)
            {
                entity_1.Health = 0;
                smethod_125(serverControll_0, entity_1, "^7Invisible GodMod Enabled");
                if ((entity_0 != null) && (entity_0 != entity_1))
                {
                    smethod_125(serverControll_0, entity_0, "^7Invisible GodMod Enabled For: ^5" + entity_1.Name);
                }
            }
            else
            {
                entity_1.Health = entity_1.GetField<int>("Vita");
                smethod_125(serverControll_0, entity_1, "^7Invisible GodMod Disabled");
                if ((entity_0 != null) && (entity_0 != entity_1))
                {
                    smethod_125(serverControll_0, entity_0, "^7Invisible GodMod Disabled For: ^5" + entity_1.Name);
                }
            }
        }

        /* private scope static unsafe int smethod_80(int int_0, ServerControll serverControll_0 = 1, byte?[] nullable_0 = 0x1000000, int int_1 = 0x3d00000, int int_2) */
        /* private scope */ internal static unsafe int smethod_80(int int_0, byte?[] nullable_0, int int_1, ServerControll serverControll_0, int int_2)
        {
            try
            {
                int num = 0;
                for (int i = int_1; i < int_2; i++)
                {
                    byte* numPtr = (byte*) i;
                    bool flag = false;
                    for (int j = 0; j < nullable_0.Length; j++)
                    {
                        if (nullable_0[j].HasValue)
                        {
                            int num4 = numPtr[0];
                            byte? nullable = nullable_0[j];
                            if (((num4 != nullable.GetValueOrDefault()) ? 1 : (!nullable.HasValue ? 1 : 0)) != 0)
                            {
                                break;
                            }
                        }
                        if (j == (nullable_0.Length - 1))
                        {
                            if (int_0 == 1)
                            {
                                flag = true;
                            }
                            else
                            {
                                num++;
                                if (num == int_0)
                                {
                                    flag = true;
                                }
                            }
                        }
                        else
                        {
                            numPtr++;
                        }
                    }
                    if (flag)
                    {
                        return i;
                    }
                }
            }
            catch (Exception exception)
            {
                Log.Write(InfinityScript.LogLevel.All, "Error in Knife:" + exception.Message, new object[0]);
            }
            return 0;
        }

        /* private scope */ internal static void smethod_81(ServerControll serverControll_0, Entity entity_0)
        {
            ServerControll.Class38 class3 = new ServerControll.Class38 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                if (System.IO.File.Exists(ServerControll.DirConfMove + ServerControll.FileReports))
                {
                    ServerControll.Class39 class2 = new ServerControll.Class39 {
                        class38_0 = class3,
                        string_0 = System.IO.File.ReadAllLines(ServerControll.DirConfMove + ServerControll.FileReports),
                        int_0 = 0
                    };
                    smethod_125(serverControll_0, class3.entity_0, "^7List^5[^7" + class2.string_0.Length + "^5] ^7Player Hack:^5");
                    serverControll_0.OnInterval(0x514, new Func<bool>(class2.method_0));
                }
                else
                {
                    smethod_125(serverControll_0, class3.entity_0, "^7No Player Found!");
                }
            }
            catch (Exception exception)
            {
                smethod_57(exception, serverControll_0, "ListHack");
            }
        }

        /* private scope */ internal static void smethod_82(Entity entity_0, Entity entity_1, ServerControll serverControll_0)
        {
            ServerControll.Class51 class2 = new ServerControll.Class51 {
                serverControll_0 = serverControll_0,
                int_0 = serverControll_0.Call<int>("loadfx", new Parameter[] { "misc/flares_cobra" })
            };
            entity_1.OnInterval(200, new Func<Entity, bool>(class2.method_0));
            smethod_125(serverControll_0, entity_0, "^7Fire Activeted For ^5" + entity_1.Name);
        }

        /* private scope */ internal static void smethod_83(Entity entity_0, ServerControll serverControll_0)
        {
            HudElem[] elemArray = serverControll_0.SubMenuList[entity_0.Call<int>("getEntityNumber", new Parameter[0])];
            for (int i = 0; i < elemArray.Length; i++)
            {
                elemArray[i].Alpha = 1f;
            }
        }

        /* private scope */ internal static void smethod_84(Entity entity_0, ServerControll serverControll_0)
        {
            ServerControll.Class11 class2 = new ServerControll.Class11 {
                hudElem_0 = entity_0.GetField<HudElem>("PassText1"),
                hudElem_1 = entity_0.GetField<HudElem>("PassText2"),
                hudElem_2 = entity_0.GetField<HudElem>("PassBordo1"),
                hudElem_3 = entity_0.GetField<HudElem>("PassBordo2"),
                hudElem_4 = entity_0.GetField<HudElem>("PassBordo3")
            };
            class2.hudElem_0.Alpha = 0f;
            class2.hudElem_1.Alpha = 0f;
            class2.hudElem_2.Alpha = 0f;
            class2.hudElem_3.Alpha = 0f;
            class2.hudElem_4.Alpha = 0f;
            serverControll_0.AfterDelay(100, new Action(class2.method_0));
            serverControll_0.AfterDelay(200, new Action(class2.method_1));
            serverControll_0.AfterDelay(300, new Action(class2.method_2));
            serverControll_0.AfterDelay(400, new Action(class2.method_3));
            serverControll_0.AfterDelay(500, new Action(class2.method_4));
        }

        /* private scope */ internal static void smethod_85(string string_0, string string_1, Entity entity_0, ServerControll serverControll_0)
        {
            if (string_0 == "add")
            {
                using (StreamWriter writer = new StreamWriter(ServerControll.DirConfMove + ServerControll.FileParolacce, true))
                {
                    ServerControll.BadWords.Add(string_1);
                    writer.WriteLine(string_1);
                    writer.Close();
                    if (entity_0 != null)
                    {
                        smethod_125(serverControll_0, entity_0, "^5" + string_1 + "^7 Added To The BadWords List!");
                    }
                    return;
                }
            }
            if (string_0 == "del")
            {
                if (System.IO.File.Exists(ServerControll.DirConfMove + ServerControll.FileParolacce))
                {
                    string[] strArray = System.IO.File.ReadAllLines(ServerControll.DirConfMove + ServerControll.FileParolacce);
                    System.IO.File.Delete(ServerControll.DirConfMove + ServerControll.FileParolacce);
                    bool flag = false;
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        bool flag2 = true;
                        if (strArray[i].ToLower().Contains(string_1))
                        {
                            flag2 = false;
                            flag = true;
                            ServerControll.BadWords.Remove(strArray[i]);
                            smethod_125(serverControll_0, entity_0, "^7Word ^5" + strArray[i] + " ^7Found And Eliminated!");
                        }
                        if (flag2)
                        {
                            using (StreamWriter writer2 = new StreamWriter(ServerControll.DirConfMove + ServerControll.FileParolacce, true))
                            {
                                writer2.WriteLine(strArray[i]);
                                writer2.Close();
                            }
                        }
                    }
                    if (!flag)
                    {
                        smethod_125(serverControll_0, entity_0, "^7No Words Found");
                    }
                }
                else
                {
                    smethod_125(serverControll_0, entity_0, "^7No Words Found!");
                }
            }
        }

        /* private scope */ internal static void smethod_86(ServerControll serverControll_0)
        {
            ServerControll.CtrBots = true;
            serverControll_0.OnInterval(0x2710, new Func<bool>(serverControll_0.method_47));
        }

        /* private scope */ internal static int smethod_87(Class75.Class77 class77_0)
        {
            return ((class77_0.int_1 - class77_0.int_0) + (class77_0.int_2 >> 3));
        }

        /* private scope */ internal static bool smethod_88(Assembly assembly_0, Assembly assembly_1)
        {
            byte[] publicKey = assembly_1.GetName().GetPublicKey();
            byte[] buffer2 = assembly_0.GetName().GetPublicKey();
            if ((buffer2 == null) != (publicKey == null))
            {
                return false;
            }
            if (buffer2 != null)
            {
                for (int i = 0; i < buffer2.Length; i++)
                {
                    if (buffer2[i] != publicKey[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /* private scope */ internal static void smethod_89(ServerControll serverControll_0, Entity entity_0)
        {
            ServerControll.Class60 class2 = new ServerControll.Class60 {
                hudElem_0 = HudElem.CreateFontString(entity_0, "hudbig", 0.9f)
            };
            class2.hudElem_0.SetPoint("CENTER", "BOTTOM", 0, -20);
            class2.hudElem_0.Call("settext", new Parameter[] { "^7NaaBAdmin iSniPe ^5v1.3^7 by ^5MH11" });
            class2.hudElem_0.Alpha = 0f;
            class2.hudElem_0.SetField("glowcolor", new Vector3(0f, 0.5f, 0.5f));
            class2.hudElem_0.GlowAlpha = 1f;
            class2.hudElem_1 = HudElem.CreateFontString(entity_0, "hudbig", 0.6f);
            class2.hudElem_1.SetPoint("CENTER", "TOPCENTER", 0, 8);
            class2.hudElem_1.Call("settext", new Parameter[] { "^5NaaB" });
            class2.hudElem_1.Alpha = 0f;
            class2.hudElem_1.SetField("glowcolor", new Vector3(0f, 0.5f, 0.5f));
            class2.hudElem_1.GlowAlpha = 1f;
            entity_0.OnNotify("CRD", new Action<Entity>(class2.method_0));
            entity_0.OnNotify("-CRD", new Action<Entity>(class2.method_1));
        }

        /* private scope */ internal static void smethod_9(ServerControll serverControll_0, Entity entity_0)
        {
            if (System.IO.File.Exists(ServerControll.DirTempFile + ServerControll.FileLoginAdmin))
            {
                string[] strArray = System.IO.File.ReadAllLines(ServerControll.DirTempFile + ServerControll.FileLoginAdmin);
                System.IO.File.Delete(ServerControll.DirTempFile + ServerControll.FileLoginAdmin);
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { ServerControll.sep1 });
                    bool flag = true;
                    for (int j = 0; j < 2; j++)
                    {
                        if (strArray2[j].ToLower().StartsWith(serverControll_0.getPlayerGuid(entity_0)))
                        {
                            goto Label_0090;
                        }
                    }
                    goto Label_0092;
                Label_0090:
                    flag = false;
                Label_0092:
                    if (flag)
                    {
                        using (StreamWriter writer = new StreamWriter(ServerControll.DirTempFile + ServerControll.FileLoginAdmin, true))
                        {
                            writer.WriteLine(strArray[i]);
                            writer.Close();
                        }
                    }
                }
            }
        }

        /* private scope */ internal static void smethod_90(ServerControll serverControll_0, int int_0)
        {
            if (!serverControll_0.SubMenuList.ContainsKey(int_0))
            {
                foreach (HudElem elem in serverControll_0.SubMenuList[int_0])
                {
                    elem.Call("destroy", new Parameter[0]);
                }
            }
        }

        /* private scope */ internal static bool smethod_91(string string_0)
        {
            int num;
            return int.TryParse(string_0, out num);
        }

        /* private scope */ internal static void smethod_92(ServerControll serverControll_0, Entity entity_0)
        {
            /*Action function = null;
            try
            {
                Action action = null;
                ServerControll.Class3 class3 = new ServerControll.Class3 {
                    serverControll_0 = serverControll_0
                };
                if (!ServerControll.AutoUpdate)
                {
                    if (entity_0 != null)
                    {
                        smethod_125(serverControll_0, entity_0, "^7Update Disabled!");
                    }
                }
                else
                {
                    class3.string_0 = DateTime.Now.ToShortDateString();
                    string version = ServerControll.version;
                    class3.char_0 = '|';
                    if (System.IO.File.Exists(ServerControll.LocalFileUpdate))
                    {
                        Func<bool> func = null;
                        ServerControll.Class4 class2 = new ServerControll.Class4 {
                            class3_0 = class3
                        };
                        string[] strArray2 = System.IO.File.ReadAllLines(ServerControll.LocalFileUpdate)[0].Split(new char[] { class3.char_0 });
                        class2.string_0 = strArray2[0];
                        class2.string_1 = strArray2[1];
                        string str2 = strArray2[2];
                        if (str2 != class3.string_0)
                        {
                            System.IO.File.Delete(ServerControll.LocalFileUpdate);
                            if (function == null)
                            {
                                function = new Action(serverControll_0.method_36);
                            }
                            serverControll_0.AfterDelay(0x7d0, function);
                        }
                        else if (version != class2.string_1)
                        {
                            if (entity_0 != null)
                            {
                                smethod_125(serverControll_0, entity_0, "^7Available To Download The New Version NaaBAdmin_iSniPe ^5" + class2.string_1 + "^7 Link:^5 " + class2.string_0);
                            }
                            else
                            {
                                if (func == null)
                                {
                                    func = new Func<bool>(class2.method_0);
                                }
                                serverControll_0.OnInterval(0x124f80, func);
                            }
                        }
                        else if ((version == class2.string_1) && (entity_0 != null))
                        {
                            smethod_125(serverControll_0, entity_0, "^7Not Update Available");
                        }
                    }
                    else if (ServerControll.Giocatori.Count > 0)
                    {
                        string fileUpdate = ServerControll.FileUpdate;
                        string dirTempFile = ServerControll.DirTempFile;
                        smethod_35(fileUpdate, dirTempFile, serverControll_0);
                        if (action == null)
                        {
                            action = new Action(class3.method_0);
                        }
                        serverControll_0.AfterDelay(0x1388, action);
                    }
                }
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("range."))
                {
                    smethod_57(exception, serverControll_0, "ControllUpdate");
                }
                else
                {
                    System.IO.File.Delete(ServerControll.LocalFileUpdate);
                }
            }*/
        }

        /* private scope */
        internal static void smethod_93(ServerControll serverControll_0, Entity entity_0)
        {
            try
            {
                serverControll_0.setPlayerLevel(entity_0, 1);
                serverControll_0.setPlayerAccess(entity_0, 0);
                for (int i = 0; i < ServerControll.Mod.Length; i++)
                {
                    if (ServerControll.Mod[i].StartsWith(serverControll_0.getPlayerGuid(entity_0)))
                    {
                        serverControll_0.setPlayerLevel(entity_0, 2);
                        if ((ServerControll.PassLoginAdmin == null) || (ServerControll.PassLoginAdmin == "null"))
                        {
                            serverControll_0.setPlayerAccess(entity_0, 1);
                        }
                    }
                }
                for (int j = 0; j < ServerControll.SeniorMod.Length; j++)
                {
                    if (ServerControll.SeniorMod[j].StartsWith(serverControll_0.getPlayerGuid(entity_0)))
                    {
                        serverControll_0.setPlayerLevel(entity_0, 3);
                        if ((ServerControll.PassLoginAdmin == null) || (ServerControll.PassLoginAdmin == "null"))
                        {
                            serverControll_0.setPlayerAccess(entity_0, 1);
                        }
                    }
                }
                for (int k = 0; k < ServerControll.Admin.Length; k++)
                {
                    if (ServerControll.Admin[k].StartsWith(serverControll_0.getPlayerGuid(entity_0)))
                    {
                        serverControll_0.setPlayerLevel(entity_0, 4);
                        if ((ServerControll.PassLoginAdmin == null) || (ServerControll.PassLoginAdmin == "null"))
                        {
                            serverControll_0.setPlayerAccess(entity_0, 1);
                        }
                    }
                }
                for (int m = 0; m < ServerControll.SuperAdmin.Length; m++)
                {
                    if (ServerControll.SuperAdmin[m].StartsWith(serverControll_0.getPlayerGuid(entity_0)))
                    {
                        serverControll_0.setPlayerLevel(entity_0, 5);
                        if ((ServerControll.PassLoginAdmin == null) || (ServerControll.PassLoginAdmin == "null"))
                        {
                            serverControll_0.setPlayerAccess(entity_0, 1);
                        }
                    }
                }
            }
            catch (Exception)
            {
               // smethod_57(exception, serverControll_0, "AutoLoginAdmin");
            }
        }

        /* private scope */ internal static void smethod_94(Class75.Class77 class77_0)
        {
            class77_0.uint_0 = class77_0.uint_0 >> (class77_0.int_2 & 7);
            class77_0.int_2 &= -8;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        /* private scope */ internal static int smethod_95(LookupService lookupService_0, long long_0)
        {
            byte[] buffer = new byte[2 * LookupService.int_8];
            int[] numArray = new int[2];
            int num = 0;
            int num2 = 0x1f;
            while (true)
            {
                if (num2 < 0)
                {
                    Console.Write("Error Seeking Country While Seeking " + long_0);
                    return 0;
                }
                try
                {
                    if ((lookupService_0.int_4 & LookupService.GEOIP_MEMORY_CACHE) == 1)
                    {
                        for (int j = 0; j < (2 * LookupService.int_8); j++)
                        {
                            buffer[j] = lookupService_0.byte_1[j + ((2 * lookupService_0.int_10) * num)];
                        }
                    }
                    else
                    {
                        lookupService_0.fileStream_0.Seek((long) ((2 * lookupService_0.int_10) * num), SeekOrigin.Begin);
                        lookupService_0.fileStream_0.Read(buffer, 0, 2 * LookupService.int_8);
                    }
                }
                catch (IOException)
                {
                    Console.Write("IO Exception");
                }
                for (int i = 0; i < 2; i++)
                {
                    numArray[i] = 0;
                    for (int k = 0; k < lookupService_0.int_10; k++)
                    {
                        int num6 = buffer[(i * lookupService_0.int_10) + k];
                        if (num6 < 0)
                        {
                            num6 += 0x100;
                        }
                        numArray[i] += num6 << (k * 8);
                    }
                }
                if ((long_0 & (((int) 1) << num2)) > 0L)
                {
                    if (numArray[1] >= lookupService_0.int_3[0])
                    {
                        return numArray[1];
                    }
                    num = numArray[1];
                }
                else
                {
                    if (numArray[0] >= lookupService_0.int_3[0])
                    {
                        return numArray[0];
                    }
                    num = numArray[0];
                }
                num2--;
            }
        }

        /* private scope */ internal static Class75.Class79 smethod_96(Class75.Class80 class80_0)
        {
            byte[] destinationArray = new byte[class80_0.int_4];
            Array.Copy(class80_0.byte_1, class80_0.int_3, destinationArray, 0, class80_0.int_4);
            return new Class75.Class79(destinationArray);
        }

        /* private scope */ internal static string smethod_97(ServerControll serverControll_0)
        {
            switch (ServerControll.RanMap)
            {
                case 0:
                    return "mp_exchange";

                case 1:
                case 0x24:
                    return "mp_dome";

                case 2:
                case 0x25:
                case 0x34:
                    return "mp_bootleg";

                case 3:
                case 0x26:
                case 0x35:
                    return "mp_hardhat";

                case 4:
                case 0x27:
                case 0x36:
                    return "mp_alpha";

                case 5:
                case 40:
                case 0x37:
                    return "mp_bravo";

                case 6:
                case 0x29:
                case 0x38:
                    return "mp_carbon";

                case 7:
                case 0x2a:
                    return "mp_interchange";

                case 8:
                case 0x2b:
                    return "mp_lambeth";

                case 9:
                case 0x2c:
                    return "mp_mogadishu";

                case 10:
                case 0x2d:
                    return "mp_paris";

                case 11:
                case 0x2e:
                case 0x39:
                    return "mp_plaza2";

                case 12:
                    return "mp_radar";

                case 13:
                case 0x2f:
                    return "mp_seatown";

                case 14:
                case 0x30:
                case 0x3a:
                    return "mp_underground";

                case 15:
                    return "mp_village";

                case 0x10:
                case 0x31:
                    return "mp_terminal_cls";

                case 0x11:
                case 50:
                    return "mp_overwatch";

                case 0x12:
                    return "mp_park";

                case 0x13:
                    return "mp_italy";

                case 20:
                    return "mp_morningwood";

                case 0x15:
                case 0x33:
                    return "mp_meteora";

                case 0x16:
                    return "mp_cement";

                case 0x17:
                    return "mp_qadeem";

                case 0x18:
                    return "mp_aground_ss";

                case 0x19:
                    return "mp_courtyard_ss";

                case 0x1a:
                    return "mp_hillside_ss";

                case 0x1b:
                    return "mp_restrepo_ss";

                case 0x1c:
                    return "mp_burn_ss";

                case 0x1d:
                    return "mp_crosswalk_ss";

                case 30:
                    return "mp_six_ss";

                case 0x1f:
                    return "mp_shipbreaker";

                case 0x20:
                    return "mp_roughneck";

                case 0x21:
                    return "mp_moab";

                case 0x22:
                    return "mp_boardwalk";

                case 0x23:
                    return "mp_nola";
            }
            return null;
        }

        /* private scope */ internal static void smethod_98(ServerControll serverControll_0)
        {
            Action function = null;
            try
            {
                if (System.IO.File.Exists(ServerControll.DirConfLocal + ServerControll.FileAdm + ".txt"))
                {
                    string[] strArray = System.IO.File.ReadAllLines(ServerControll.DirConfLocal + ServerControll.FileAdm + ".txt");
                    string[] strArray2 = strArray[1].Split(new char[] { ServerControll.sep3 });
                    ServerControll.StrSuperAdmin = strArray2[1];
                    ServerControll.SuperAdmin = strArray2[1].Split(new char[] { ServerControll.sep1 });
                    strArray2 = strArray[2].Split(new char[] { ServerControll.sep3 });
                    ServerControll.StrAdmin = strArray2[1];
                    ServerControll.Admin = strArray2[1].Split(new char[] { ServerControll.sep1 });
                    strArray2 = strArray[3].Split(new char[] { ServerControll.sep3 });
                    ServerControll.StrSeniorMod = strArray2[1];
                    ServerControll.SeniorMod = strArray2[1].Split(new char[] { ServerControll.sep1 });
                    strArray2 = strArray[4].Split(new char[] { ServerControll.sep3 });
                    ServerControll.StrMod = strArray2[1];
                    ServerControll.Mod = strArray2[1].Split(new char[] { ServerControll.sep1 });
                    strArray2 = strArray[6].ToLower().Split(new char[] { ServerControll.sep3 });
                    ServerControll.StrComandiSA = strArray2[1];
                    ServerControll.ComandiSA = strArray2[1].Split(new char[] { ServerControll.sep1 });
                    strArray2 = strArray[7].ToLower().Split(new char[] { ServerControll.sep3 });
                    ServerControll.StrComandiA = strArray2[1];
                    ServerControll.ComandiA = strArray2[1].Split(new char[] { ServerControll.sep1 });
                    strArray2 = strArray[8].ToLower().Split(new char[] { ServerControll.sep3 });
                    ServerControll.StrComandiSM = strArray2[1];
                    ServerControll.ComandiSM = strArray2[1].Split(new char[] { ServerControll.sep1 });
                    strArray2 = strArray[9].ToLower().Split(new char[] { ServerControll.sep3 });
                    ServerControll.StrComandiM = strArray2[1];
                    ServerControll.ComandiM = strArray2[1].Split(new char[] { ServerControll.sep1 });
                    strArray2 = strArray[10].ToLower().Split(new char[] { ServerControll.sep3 });
                    ServerControll.StrComandiU = strArray2[1];
                    ServerControll.ComandiU = strArray2[1].Split(new char[] { ServerControll.sep1 });
                    ServerControll.ColorNickAdmin = bool.Parse(strArray[12].Split(new char[] { ServerControll.sep3 })[1].ToLower());
                    ServerControll.ColorSuperAdmin = int.Parse(strArray[13].Split(new char[] { ServerControll.sep3 })[1].TrimStart(new char[] { '^' }));
                    ServerControll.ColorAdmin = int.Parse(strArray[14].Split(new char[] { ServerControll.sep3 })[1].TrimStart(new char[] { '^' }));
                    ServerControll.ColorSeniorMod = int.Parse(strArray[15].Split(new char[] { ServerControll.sep3 })[1].TrimStart(new char[] { '^' }));
                    ServerControll.ColorMod = int.Parse(strArray[0x10].Split(new char[] { ServerControll.sep3 })[1].TrimStart(new char[] { '^' }));
                    ServerControll.DirConfMove = strArray[0x12].Split(new char[] { ServerControll.sep3 })[1];
                    if (!Directory.Exists(ServerControll.DirConfMove))
                    {
                        Directory.CreateDirectory(ServerControll.DirConfMove);
                    }
                }
                else
                {
                    serverControll_0.Reconfig_Admin();
                }
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("range."))
                {
                    smethod_57(exception, serverControll_0, "LoadAdmin");
                }
                if (function == null)
                {
                    function = new Action(serverControll_0.method_38);
                }
                serverControll_0.AfterDelay(500, function);
            }
        }

        /* private scope */ internal static void smethod_99(ServerControll serverControll_0)
        {
            serverControll_0.OnInterval(0x4e20, new Func<bool>(serverControll_0.method_42));
        }

        [DllImport("kernel32.dll", SetLastError=true)]
        /* private scope */ internal static extern IntPtr VirtualAlloc(IntPtr intptr_0, UIntPtr uintptr_0, uint uint_0, uint uint_1);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll")]
        /* private scope */ internal static extern bool VirtualProtect(IntPtr intptr_0, IntPtr intptr_1, uint uint_0, out uint uint_1);
        [DllImport("kernel32.dll")]
        /* private scope */ internal static extern int WriteProcessMemory(IntPtr intptr_0, IntPtr intptr_1, [In, Out] byte[] byte_0, uint uint_0, out IntPtr intptr_2);
        [DllImport("kernel32.dll", EntryPoint="WriteProcessMemory", SetLastError=true)]
        /* private scope */ internal static extern bool WriteProcessMemory_1(IntPtr intptr_0, IntPtr intptr_1, byte[] byte_0, IntPtr intptr_2, out int int_0);

        public static string str2 { get; set; }

      

        internal static void drunk(Entity player,ServerControll serverControll)
        {
            player.OnInterval(2, (ent) =>
            {
                if (player.GetField<int>("drunk") == 1)
                {
                    player.Call("shellshock", "default", 4F);
                }
                else if (player.GetField<int>("drunk") == 0)
                {
                    player.Call("setmovespeedscale", new Parameter[] { new Parameter(1f) });
                }
                return player.IsAlive;
            });
            if (player.GetField<int>("drunk") == 1)
            {
                TellAll("^5" + player.Name + " ^7is" + " ^5Drunk");
            }
            else if (player.GetField<int>("drunk") == 0)
            {
                player.Call("shellshock", "default", 0F);
                TellAll("^5" + player.Name + " ^7is" + " ^5Drowsy" + " ^7XD");
            }
        }

        public static void TellAll(string Message)
        {
            ServerControll.DC.Call("iprintlnbold", new Parameter[] { Message });
        }
    }
}
