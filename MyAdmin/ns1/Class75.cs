namespace ns1
{
    using InfinityScript;
    using ns0;
    using ServerControll;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading;

    internal sealed class Class75
    {
        [DllImport("kernel32.dll")]
        /* private scope */internal static extern int ReadProcessMemory(IntPtr intptr_0, IntPtr intptr_1, [In, Out] byte[] byte_0, uint uint_0, out IntPtr intptr_2);
        /* private scope */internal static void smethod_0(ServerControll serverControll_0)
        {
            if (ServerControll.string_93.Contains("inf"))
            {
                smethod_6(serverControll_0, "set scr_teambalance \"0\"", 0);
            }
            else if (ServerControll.bool_22)
            {
                smethod_6(serverControll_0, "set scr_teambalance \"1\"", 0);
            }
            else
            {
                smethod_6(serverControll_0, "set scr_teambalance \"0\"", 0);
            }
            if (ServerControll.bool_25 && (ServerControll.string_100 != "esl"))
            {
                smethod_6(serverControll_0, "set scr_killcam_time \"5\"", 0);
                smethod_6(serverControll_0, "set scr_killcam_posttime \"2\"", 0);
            }
            else
            {
                smethod_6(serverControll_0, "set scr_killcam_time \"0\"", 0);
                smethod_6(serverControll_0, "set scr_killcam_posttime \"0\"", 0);
            }
            serverControll_0.Call("setdvar", new Parameter[] { "cg_drawBreathHint", "0" });
            serverControll_0.Call("setdvar", new Parameter[] { "sv_network_fps", "100" });
            serverControll_0.Call("setdvar", new Parameter[] { "bg_weaponBobMax", "0" });
            serverControll_0.Call("setdvar", new Parameter[] { "bg_viewBobMax", "0" });
        }

        /* private scope */internal static long smethod_1(byte[] byte_0)
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

        /* private scope */internal static void smethod_10(ServerControll serverControll_0, string string_0)
        {
            serverControll_0.Call("iprintln", new Parameter[] { string_0 });
        }

        /* private scope */internal static void smethod_100(Entity entity_0, ServerControll serverControll_0)
        {
            try
            {
                if (ServerControll.list_2.Contains(entity_0))
                {
                    ServerControll.list_2.Remove(entity_0);
                    if (serverControll_0.getPlayerPsw(entity_0) != 0)
                    {
                        smethod_192(serverControll_0, entity_0);
                    }
                }
                if (ServerControll.list_3.Contains(entity_0))
                {
                    smethod_99(entity_0, serverControll_0);
                    string[] strArray = new string[] { DateTime.Now.ToShortTimeString(), " Exit... [", serverControll_0.getPlayerSlot(entity_0), "]", serverControll_0.getPlayerName(entity_0) };
                    ServerControll controll = serverControll_0;
                    smethod_84(string.Concat(strArray), controll);
                    if (ServerControll.bool_12)
                    {
                        if (ServerControll.string_2.StartsWith("pl") && ServerControll.dictionary_1.ContainsKey(serverControll_0.getPlayerHWID(entity_0)))
                        {
                            ServerControll.dictionary_1.Remove(serverControll_0.getPlayerHWID(entity_0));
                        }
                        else if (ServerControll.dictionary_1.ContainsKey(serverControll_0.getPlayerGuid(entity_0)))
                        {
                            ServerControll.dictionary_1.Remove(serverControll_0.getPlayerGuid(entity_0));
                        }
                    }
                    ServerControll.list_3.Remove(entity_0);
                    if (serverControll_0.getPlayerAccess(entity_0) != 0)
                    {
                        smethod_213(serverControll_0, entity_0);
                    }
                    if (serverControll_0.IsUserSession(entity_0))
                    {
                        ServerControll.list_11.Remove(serverControll_0.getPlayerName(entity_0));
                    }
                    smethod_52(serverControll_0, entity_0);
                }
                else if (ServerControll.list_5.Contains(entity_0))
                {
                    ServerControll.list_5.Remove(entity_0);
                }
            }
            catch (Exception exception)
            {
                if (!((exception.Message.Contains("dictionary.") || exception.Message.Contains("Sharing violation")) || exception.Message.Contains("correct format.")))
                {
                    ServerControll.LogErrori("Disconnessione_Player", exception, "---");
                }
            }
        }

        /* private scope */internal static void smethod_101(int int_0, int int_1, MemClass memClass_0)
        {
            byte[] bytes = BitConverter.GetBytes(int_1);
            IntPtr zero = IntPtr.Zero;
            WriteProcessMemory_1(memClass_0.intptr_0, (IntPtr) int_0, bytes, (uint) bytes.Length, out zero);
        }

        /* private scope */internal static byte[] smethod_102(int int_0, int int_1, MemClass memClass_0)
        {
            byte[] buffer = new byte[int_1];
            IntPtr zero = IntPtr.Zero;
            ReadProcessMemory(memClass_0.intptr_0, (IntPtr) int_0, buffer, (uint) buffer.Length, out zero);
            return buffer;
        }

        /* private scope */internal static void smethod_103(ServerControll serverControll_0)
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
            serverControll_0.Call("setdvar", new Parameter[] { "scr_sd_score_kill", "5" });
            serverControll_0.Call("setdvar", new Parameter[] { "scr_sd_score_headshot", "5" });
            serverControll_0.Call("setdvar", new Parameter[] { "scr_sd_score_assist", "3" });
            serverControll_0.Call("setdvar", new Parameter[] { "scr_sd_score_plant", "3" });
            serverControll_0.Call("setdvar", new Parameter[] { "scr_sd_score_defuse", "3" });
            serverControll_0.Call("setdvar", new Parameter[] { "scr_sd_score_teamkill", "5" });
            serverControll_0.Call("setdvar", new Parameter[] { "scr_sd_score_capture", "3" });
            serverControll_0.Call("setdvar", new Parameter[] { "scr_sd_score_defend", "1" });
            serverControll_0.Call("setdvar", new Parameter[] { "scr_sd_score_defend_assist", "1" });
            serverControll_0.Call("setdvar", new Parameter[] { "scr_sd_score_assault", "3" });
            serverControll_0.Call("setdvar", new Parameter[] { "scr_sd_score_assault_assist", "3" });
            serverControll_0.Call("setdvar", new Parameter[] { "ui_hud_showdeathicons", "0" });
            serverControll_0.Call("setdvar", new Parameter[] { "perk_sprintMultiplier", "1.25" });
            serverControll_0.Call("setdvar", new Parameter[] { "perk_bulletPenetrationMultiplier", "1.6" });
            serverControll_0.Call("setdvar", new Parameter[] { "perk_quickDrawSpeedScale", "1.1" });
            serverControll_0.Call("setdvar", new Parameter[] { "player_throwBackInnerRadius", "0" });
            serverControll_0.Call("setdvar", new Parameter[] { "player_throwBackOuterRadius", "0" });
        }

        /* private scope */internal static void smethod_104(string string_0, ServerControll serverControll_0)
        {
            string str = string.Concat(new object[] { "LogConsole_", DateTime.Now.Day, ".", DateTime.Now.Month, ".", DateTime.Now.Year, ".txt" });
            using (StreamWriter writer = new StreamWriter(ServerControll.string_90 + str, true))
            {
                writer.WriteLine(smethod_219(serverControll_0, string_0));
                writer.Close();
            }
        }

        /* private scope */internal static void smethod_105(Entity entity_0, ServerControll serverControll_0)
        {
            entity_0.SetField("ULTVote", DateTime.Now.ToString());
        }

        /* private scope */internal static void smethod_106(string string_0, ServerControll serverControll_0, string string_1)
        {
            string[] strArray;
            int num;
            try
            {
                strArray = string_0.Split(new char[] { '/' });
                num = strArray.Length - 1;
                Uri address = new Uri(string_0);
                new WebClient().DownloadFile(address, string_1 + strArray[num]);
            }
            catch (Exception exception)
            {
                strArray = string_0.Split(new char[] { '/' });
                num = strArray.Length - 1;
                if (System.IO.File.Exists(string_1 + strArray[num]))
                {
                    System.IO.File.Delete(string_1 + strArray[num]);
                }
                ServerControll.bool_28 = false;
                smethod_84("Error - Problem automatic updates, check for updates manually on the official page: http://naabclub.ir/", serverControll_0);
                ServerControll.LogErrori("DownloadUpdate", exception, "---");
            }
        }

        /* private scope */internal static Entity smethod_107(string string_0, ServerControll serverControll_0, Entity entity_0)
        {
            try
            {
                if (ServerControll.list_2.Count != 0)
                {
                    int num = 0;
                    Entity entity2 = null;
                    foreach (Entity entity3 in smethod_178(serverControll_0))
                    {
                        if (string_0.Length < 3)
                        {
                            if (serverControll_0.getPlayerSlot(entity3) == string_0)
                            {
                                entity2 = entity3;
                                num++;
                            }
                        }
                        else if (((entity3.Name.ToLower().Contains(string_0) || (serverControll_0.getPlayerID(entity3) == string_0)) || (serverControll_0.getPlayerGuid(entity3) == string_0)) || (serverControll_0.getPlayerXuid(entity3) == string_0))
                        {
                            entity2 = entity3;
                            num++;
                        }
                    }
                    if (num == 1)
                    {
                        return entity2;
                    }
                    if (num > 1)
                    {
                        entity_0.Call("iprintlnbold", new Parameter[] { "^1Error - Multiple matches found!" });
                        return null;
                    }
                    entity_0.Call("iprintlnbold", new Parameter[] { "^1Error - No Player Found!" });
                }
                return null;
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("TrovaPlayerME", exception, "---");
                return null;
            }
        }

        /* private scope */internal static void smethod_108(int int_0, Entity entity_0, ServerControll serverControll_0)
        {
            entity_0.SetField("PSWTent", int_0);
        }

        /* private scope */internal static void smethod_109(ServerControll serverControll_0)
        {
            try
            {
                IniParser parser = new IniParser(ServerControll.string_84 + ServerControll.string_47);
                if (ServerControll.string_0.Contains("tek"))
                {
                    ServerControll.string_2 = "teknomw3";
                }
                else
                {
                    ServerControll.string_2 = parser.GetStringSetting(ServerControll.string_2, "GENERAL_SETTING", "ServerMaster");
                }
                ServerControll.string_3 = parser.GetStringSetting(ServerControll.string_3, "GENERAL_SETTING", "PassLoginAdmin");
                ServerControll.string_15 = parser.GetStringSetting(ServerControll.string_15, "GENERAL_SETTING", "ManualLogin");
                ServerControll.bool_41 = parser.GetBoolSetting(ServerControll.bool_41, "GENERAL_SETTING", "PasswordUsers");
                ServerControll.int_3 = parser.GetIntSetting(ServerControll.int_3, "GENERAL_SETTING", "MaxPing");
                ServerControll.bool_1 = parser.GetBoolSetting(ServerControll.bool_1, "GENERAL_SETTING", "Vote");
                ServerControll.int_16 = parser.GetIntSetting(ServerControll.int_16, "GENERAL_SETTING", "TimeVoting");
                ServerControll.string_20 = parser.GetStringSetting(ServerControll.string_20, "GENERAL_SETTING", "InfoBan");
                ServerControll.bool_39 = parser.GetBoolSetting(ServerControll.bool_39, "GENERAL_SETTING", "NoSoundADS");
                ServerControll.bool_4 = parser.GetBoolSetting(ServerControll.bool_4, "GENERAL_SETTING", "MaxSoundBomb");
                ServerControll.bool_9 = parser.GetBoolSetting(ServerControll.bool_9, "GENERAL_SETTING", "InfinityBreath");
                ServerControll.bool_10 = parser.GetBoolSetting(ServerControll.bool_10, "GENERAL_SETTING", "AntiCookingBomb");
                ServerControll.bool_16 = parser.GetBoolSetting(ServerControll.bool_16, "GENERAL_SETTING", "XlrStats");
                ServerControll.bool_33 = parser.GetBoolSetting(ServerControll.bool_33, "GENERAL_SETTING", "XLRInfect");
                ServerControll.bool_17 = parser.GetBoolSetting(ServerControll.bool_17, "GENERAL_SETTING", "AntiCamp");
                ServerControll.int_5 = parser.GetIntSetting(ServerControll.int_5, "GENERAL_SETTING", "Jump");
                ServerControll.int_6 = parser.GetIntSetting(ServerControll.int_6, "GENERAL_SETTING", "Speed");
                ServerControll.int_7 = parser.GetIntSetting(ServerControll.int_7, "GENERAL_SETTING", "Gravity");
                ServerControll.bool_19 = parser.GetBoolSetting(ServerControll.bool_19, "GENERAL_SETTING", "WarnForTeamKill");
                ServerControll.bool_20 = parser.GetBoolSetting(ServerControll.bool_20, "GENERAL_SETTING", "WarnForChangeNick");
                ServerControll.string_18 = parser.GetStringSetting(ServerControll.string_18, "GENERAL_SETTING", "ModCampers");
                ServerControll.bool_21 = parser.GetBoolSetting(ServerControll.bool_21, "GENERAL_SETTING", "AntiBadWords");
                ServerControll.bool_22 = parser.GetBoolSetting(ServerControll.bool_22, "GENERAL_SETTING", "AutoBalanceTeam");
                ServerControll.bool_26 = parser.GetBoolSetting(ServerControll.bool_26, "GENERAL_SETTING", "ScanGPS");
                ServerControll.bool_28 = parser.GetBoolSetting(ServerControll.bool_28, "GENERAL_SETTING", "AutoUpdate");
                ServerControll.bool_29 = parser.GetBoolSetting(ServerControll.bool_29, "GENERAL_SETTING", "ExplosiveBullets");
                ServerControll.bool_34 = parser.GetBoolSetting(ServerControll.bool_34, "GENERAL_SETTING", "ShowLoginAdmin");
                ServerControll.bool_35 = parser.GetBoolSetting(ServerControll.bool_35, "GENERAL_SETTING", "Knife");
                ServerControll.bool_36 = parser.GetBoolSetting(ServerControll.bool_36, "GENERAL_SETTING", "ControllNextMap");
                ServerControll.int_11 = parser.GetIntSetting(ServerControll.int_11, "GENERAL_SETTING", "TempBanLimit");
                ServerControll.bool_44 = parser.GetBoolSetting(ServerControll.bool_44, "GENERAL_SETTING", "AutoRotationMap");
                ServerControll.bool_45 = parser.GetBoolSetting(ServerControll.bool_45, "GENERAL_SETTING", "PromodMode");
                ServerControll.bool_46 = parser.GetBoolSetting(ServerControll.bool_46, "GENERAL_SETTING", "Grafic_Menu");
                ServerControll.bool_30 = parser.GetBoolSetting(ServerControll.bool_30, "GENERAL_SETTING", "1Shot_1Kill");
                ServerControll.string_105 = parser.GetStringSetting(ServerControll.string_105, "GENERAL_SETTING", "Difficulty_Bots");
                ServerControll.int_30 = parser.GetIntSetting(ServerControll.int_30, "GENERAL_SETTING", "TempBanRageQuitINF");
                ServerControll.bool_2 = parser.GetBoolSetting(ServerControll.bool_2, "PROTECTION_SERVER", "AntiTeamKill");
                ServerControll.bool_38 = parser.GetBoolSetting(ServerControll.bool_38, "PROTECTION_SERVER", "AntiTKOnlySD");
                ServerControll.bool_24 = parser.GetBoolSetting(ServerControll.bool_24, "PROTECTION_SERVER", "AntiNoRecoil");
                ServerControll.bool_3 = parser.GetBoolSetting(ServerControll.bool_3, "PROTECTION_SERVER", "AntiAIM");
                ServerControll.int_9 = parser.GetIntSetting(ServerControll.int_9, "PROTECTION_SERVER", "LimitHeadShotAimbot");
                ServerControll.int_10 = parser.GetIntSetting(ServerControll.int_10, "PROTECTION_SERVER", "LimitOtherAimbot");
                ServerControll.bool_5 = parser.GetBoolSetting(ServerControll.bool_5, "PROTECTION_SERVER", "ControllPowers");
                ServerControll.bool_12 = parser.GetBoolSetting(ServerControll.bool_12, "PROTECTION_SERVER", "AntiChangeNick");
                ServerControll.bool_11 = parser.GetBoolSetting(ServerControll.bool_11, "PROTECTION_SERVER", "ControllGraphics");
                ServerControll.bool_40 = parser.GetBoolSetting(ServerControll.bool_40, "PROTECTION_SERVER", "Controll3Person");
                ServerControll.bool_8 = parser.GetBoolSetting(ServerControll.bool_8, "PASSWORD_ACCESS_SERVER", "Status_Password_Script");
                ServerControll.int_8 = parser.GetIntSetting(ServerControll.int_8, "PASSWORD_ACCESS_SERVER", "Time_Password_Script");
                ServerControll.string_16 = parser.GetStringSetting(ServerControll.string_16, "PASSWORD_ACCESS_SERVER", "Server_Password");
                ServerControll.string_4 = parser.GetStringSetting(ServerControll.string_4, "GRAFIC_SERVER", "BotName");
                ServerControll.string_5 = parser.GetStringSetting(ServerControll.string_5, "GRAFIC_SERVER", "NameClan");
                ServerControll.bool_42 = parser.GetBoolSetting(ServerControll.bool_42, "GRAFIC_SERVER", "ShowNameServer");
                ServerControll.string_6 = parser.GetStringSetting(ServerControll.string_6, "GRAFIC_SERVER", "ADVClan");
                ServerControll.string_17 = parser.GetStringSetting(ServerControll.string_17, "GRAFIC_SERVER", "TextSlide");
                ServerControll.bool_43 = parser.GetBoolSetting(ServerControll.bool_43, "GRAFIC_SERVER", "ShowTimer");
                ServerControll.string_7 = parser.GetStringSetting(ServerControll.string_7, "GRAFIC_SERVER", "TeamB");
                ServerControll.string_8 = parser.GetStringSetting(ServerControll.string_8, "GRAFIC_SERVER", "TeamA");
                ServerControll.string_11 = parser.GetStringSetting(ServerControll.string_11, "GRAFIC_SERVER", "IconTeamB");
                ServerControll.string_12 = parser.GetStringSetting(ServerControll.string_12, "GRAFIC_SERVER", "IconTeamA");
                ServerControll.string_9 = parser.GetStringSetting(ServerControll.string_9, "GRAFIC_SERVER", "TeamAInfect");
                ServerControll.string_10 = parser.GetStringSetting(ServerControll.string_10, "GRAFIC_SERVER", "TeamBInfect");
                ServerControll.string_13 = parser.GetStringSetting(ServerControll.string_13, "GRAFIC_SERVER", "IconInfTeamA");
                ServerControll.string_14 = parser.GetStringSetting(ServerControll.string_14, "GRAFIC_SERVER", "IconInfTeamB");
                ServerControll.bool_7 = parser.GetBoolSetting(ServerControll.bool_7, "GRAFIC_SERVER", "ColorNickTeam");
                ServerControll.bool_13 = parser.GetBoolSetting(ServerControll.bool_13, "GRAFIC_SERVER", "EditListPlayer");
                ServerControll.bool_18 = parser.GetBoolSetting(ServerControll.bool_18, "GRAFIC_SERVER", "HightFPS");
                ServerControll.bool_23 = parser.GetBoolSetting(ServerControll.bool_23, "GRAFIC_SERVER", "G_HardCore_S&D");
                ServerControll.bool_25 = parser.GetBoolSetting(ServerControll.bool_25, "GRAFIC_SERVER", "FinalKillCam");
                ServerControll.bool_27 = parser.GetBoolSetting(ServerControll.bool_27, "GRAFIC_SERVER", "FilmTweak");
                ServerControll.bool_31 = parser.GetBoolSetting(ServerControll.bool_31, "GRAFIC_SERVER", "ShowADV");
                ServerControll.int_4 = parser.GetIntSetting(ServerControll.int_4, "GRAFIC_SERVER", "TimeAdv");
                ServerControll.bool_32 = parser.GetBoolSetting(ServerControll.bool_32, "GRAFIC_SERVER", "ShowRandomRules");
                ServerControll.int_12 = parser.GetIntSetting(ServerControll.int_12, "GRAFIC_SERVER", "MaxFPS");
                ServerControll.bool_47 = parser.GetBoolSetting(ServerControll.bool_47, "GRAFIC_SERVER", "ShowConnectingPlayer");
                ServerControll.int_13 = parser.GetIntSetting(ServerControll.int_13, "GRAFIC_SERVER", "IconTargetSize");
                parser.SaveSettings();
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("LoadConfig", exception, "---");
            }
        }

        /* private scope */internal static void smethod_11(ServerControll serverControll_0, Entity entity_0)
        {
            ServerControll.Class38 class2 = new ServerControll.Class38 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            if (ServerControll.int_26 >= 30)
            {
                ServerControll.int_26 = 1;
            }
            else
            {
                ServerControll.int_26++;
            }
            class2.entity_0.SetField("FlagRadar", ServerControll.int_26);
            class2.int_0 = class2.entity_0.GetField<int>("FlagRadar");
            smethod_64(serverControll_0, "^1" + serverControll_0.getPlayerName(class2.entity_0) + " ^7blocked to camp, watch the minimap to find");
            class2.entity_0.OnInterval(0x1388, new Func<Entity, bool>(class2.method_0));
        }

        /* private scope */internal static int smethod_110()
        {
            Random random = new Random();
            return random.Next(0x3e8, 0xfa0);
        }

        /* private scope */internal static ICryptoTransform smethod_111(byte[] byte_0, Class81 class81_0, bool bool_0, byte[] byte_1)
        {
            class81_0.type_0.GetProperty("Key").GetSetMethod().Invoke(class81_0.object_0, new object[] { byte_0 });
            class81_0.type_0.GetProperty("IV").GetSetMethod().Invoke(class81_0.object_0, new object[] { byte_1 });
            return (ICryptoTransform) class81_0.type_0.GetMethod(bool_0 ? "CreateDecryptor" : "CreateEncryptor", new Type[0]).Invoke(class81_0.object_0, new object[0]);
        }

        /* private scope */internal static void smethod_112(Entity entity_0, string string_0, ServerControll serverControll_0, bool bool_0)
        {
            for (int i = 0; i < ServerControll.string_80.Length; i++)
            {
                if (string_0.Contains(ServerControll.string_80[i]))
                {
                    string[] strArray = ServerControll.string_80[i].Split(new char[] { '_' });
                    string_0 = ServerControll.string_80[i] + "_mp_" + strArray[1] + "scope";
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

        /* private scope */internal static void smethod_113(ServerControll serverControll_0)
        {
            if (ServerControll.bool_31)
            {
                serverControll_0.OnInterval(ServerControll.int_4 * 0x3e8, new Func<bool>(serverControll_0.method_54));
            }
        }

        /* private scope */internal static void smethod_114(ServerControll serverControll_0)
        {
            serverControll_0.AfterDelay(0xbb8, new Action(serverControll_0.method_40));
        }

        /* private scope */internal static int smethod_115(int int_0, byte[] byte_0, int int_1, Class82.Class83 class83_0)
        {
            int num = 0;
            goto Label_0048;
        Label_0004:
            if (!smethod_57(class83_0) && ((class83_0.class85_0.int_1 <= 0) || (class83_0.int_4 == 11)))
            {
                return num;
            }
        Label_0048:
            if (class83_0.int_4 == 11)
            {
                goto Label_0004;
            }
            int num2 = smethod_68(int_0, int_1, byte_0, class83_0.class85_0);
            int_1 += num2;
            num += num2;
            int_0 -= num2;
            if (int_0 != 0)
            {
                goto Label_0004;
            }
            return num;
        }

        /* private scope */internal static void smethod_116(ServerControll serverControll_0)
        {
            if (System.IO.File.Exists(ServerControll.string_88 + ServerControll.string_60))
            {
                string[] strArray = System.IO.File.ReadAllLines(ServerControll.string_88 + ServerControll.string_60);
                for (int i = 0; i < strArray.Length; i++)
                {
                    ServerControll.list_11.Add(strArray[i]);
                }
            }
        }

        /* private scope */internal static void smethod_117(ServerControll serverControll_0)
        {
            ServerControll.dictionary_0.Clear();
            int num = 0x4a30335;
            int num2 = 0x78688;
            for (int i = 0; i < 0x12; i++)
            {
                ServerControll.dictionary_0.Add(i, num + (i * num2));
            }
        }

        /* private scope */internal static void smethod_118(ServerControll serverControll_0, Entity entity_0, int int_0)
        {
            entity_0.SetField("visto", int_0);
        }

        /* private scope */internal static void smethod_119(ServerControll serverControll_0, Entity entity_0)
        {
            ServerControll.Class65 class2 = new ServerControll.Class65 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0,
                int_0 = 9
            };
            class2.entity_0.OnInterval(0x3e8, new Func<Entity, bool>(class2.method_0));
        }

        /* private scope */internal static void smethod_12(ServerControll serverControll_0, Entity entity_0)
        {
            smethod_173(0, serverControll_0, entity_0);
            smethod_42(0, serverControll_0, entity_0);
            if (ServerControll.bool_41)
            {
                if (System.IO.File.Exists(ServerControll.string_88 + serverControll_0.FileSession))
                {
                    string[] strArray = System.IO.File.ReadAllLines(ServerControll.string_88 + serverControll_0.FileSession);
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        string[] strArray2 = strArray[i].Split(new char[] { ',' });
                        for (int j = 0; j < 2; j++)
                        {
                            if (strArray2[j].ToLower().StartsWith(serverControll_0.getPlayerGuid(entity_0)))
                            {
                                goto Label_0092;
                            }
                        }
                        continue;
                    Label_0092:
                        smethod_42(1, serverControll_0, entity_0);
                    }
                }
                smethod_129(serverControll_0, entity_0);
            }
        }

        /* private scope */internal static void smethod_120(Entity entity_0, ServerControll serverControll_0)
        {
            HudElem[] elemArray = serverControll_0.SubMenuList[entity_0.Call<int>("getEntityNumber", new Parameter[0])];
            for (int i = 0; i < elemArray.Length; i++)
            {
                elemArray[i].Call("destroy", new Parameter[0]);
            }
        }

        /* private scope */internal static void smethod_121(Entity entity_0, Entity entity_1, ServerControll serverControll_0)
        {
            if (System.IO.File.Exists(ServerControll.string_85 + ServerControll.string_56))
            {
                string[] strArray = System.IO.File.ReadAllLines(ServerControll.string_85 + ServerControll.string_56);
                System.IO.File.Delete(ServerControll.string_85 + ServerControll.string_56);
                bool flag = false;
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { ServerControll.char_1 });
                    bool flag2 = true;
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (strArray2[j].Equals(serverControll_0.getPlayerName(entity_1)))
                        {
                            goto Label_0098;
                        }
                    }
                    goto Label_00B5;
                Label_0098:
                    flag2 = false;
                    flag = true;
                    smethod_73(serverControll_0, entity_0, "^7Alias eliminated player ^1" + serverControll_0.getPlayerName(entity_1));
                Label_00B5:
                    if (flag2)
                    {
                        using (StreamWriter writer = new StreamWriter(ServerControll.string_85 + ServerControll.string_56, true))
                        {
                            writer.WriteLine(strArray[i]);
                            writer.Close();
                        }
                    }
                }
                if (!flag)
                {
                    smethod_73(serverControll_0, entity_0, "^1No Player Found");
                }
            }
        }

        /* private scope */internal static ICryptoTransform smethod_122(bool bool_0, byte[] byte_0, byte[] byte_1, Class80 class80_0)
        {
            class80_0.type_0.GetProperty("Key").GetSetMethod().Invoke(class80_0.object_0, new object[] { byte_1 });
            class80_0.type_0.GetProperty("IV").GetSetMethod().Invoke(class80_0.object_0, new object[] { byte_0 });
            return (ICryptoTransform) class80_0.type_0.GetMethod(bool_0 ? "CreateDecryptor" : "CreateEncryptor", new Type[0]).Invoke(class80_0.object_0, new object[0]);
        }

        /* private scope */internal static void smethod_123(ServerControll serverControll_0)
        {
            try
            {
                ServerControll.string_101 = serverControll_0.Call<string>("GetDvar", new Parameter[] { "sv_hostname" });
                ServerControll.string_92 = serverControll_0.Call<string>("GetDvar", new Parameter[] { "mapname" });
                ServerControll.string_93 = serverControll_0.Call<string>("GetDvar", new Parameter[] { "g_gametype" });
                ServerControll.string_94 = serverControll_0.Call<string>("GetDvar", new Parameter[] { "g_password" });
                ServerControll.string_95 = serverControll_0.Call<string>("GetDvar", new Parameter[] { "sv_maxclients" });
                ServerControll.string_96 = serverControll_0.Call<string>("GetDvar", new Parameter[] { "sv_privateClients" });
                ServerControll.string_97 = serverControll_0.Call<string>("GetDvar", new Parameter[] { "sv_privatePassword" });
                ServerControll.string_102 = serverControll_0.Call<string>("GetDvar", new Parameter[] { "net_ip" });
                ServerControll.string_103 = serverControll_0.Call<string>("GetDvar", new Parameter[] { "net_port" });
                if ((ServerControll.string_94 == "") || (ServerControll.string_94 == null))
                {
                    ServerControll.string_94 = "null";
                }
                if ((ServerControll.string_97 == "") || (ServerControll.string_97 == null))
                {
                    ServerControll.string_97 = "null";
                }
                if ((ServerControll.string_93 == "sd") && ServerControll.bool_45)
                {
                    smethod_103(serverControll_0);
                }
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("SetVarMap", exception, "---");
            }
        }

        /* private scope */internal static void smethod_124(ServerControll serverControll_0)
        {
            serverControll_0.AfterDelay(0x1f40, new Action(serverControll_0.method_41));
        }

        /* private scope */internal static void smethod_125(ServerControll serverControll_0, Entity entity_0)
        {
            Func<Entity, bool> function = null;
            ServerControll.Class25 class2 = new ServerControll.Class25 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                class2.entity_0.SetField("TimePass", ServerControll.int_8);
                ServerControll.list_10.Add(class2.entity_0);
                smethod_3(serverControll_0, class2.entity_0);
                if (function == null)
                {
                    function = new Func<Entity, bool>(class2.method_0);
                }
                class2.entity_0.OnInterval(0x3e8, function);
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("AvvRichPassword", exception, "---");
            }
        }

        /* private scope */internal static void smethod_126(ServerControll serverControll_0)
        {
            if (ServerControll.string_105.StartsWith("easy"))
            {
                serverControll_0.int_0 = 50;
                serverControll_0.int_1 = 30;
                serverControll_0.int_2 = 300;
            }
            else if (ServerControll.string_105.StartsWith("normal"))
            {
                serverControll_0.int_0 = 30;
                serverControll_0.int_1 = 20;
                serverControll_0.int_2 = 500;
            }
            else if (ServerControll.string_105.StartsWith("hard"))
            {
                serverControll_0.int_0 = 10;
                serverControll_0.int_1 = 8;
                serverControll_0.int_2 = 800;
            }
            else
            {
                ServerControll.string_105 = "normal";
                IniParser parser = new IniParser(ServerControll.string_84 + ServerControll.string_47);
                parser.AddSetting("GENERAL_SETTING", "Difficulty_Bots", ServerControll.string_105);
                parser.SaveSettings();
                serverControll_0.int_0 = 10;
                serverControll_0.int_1 = 8;
                serverControll_0.int_2 = 600;
            }
        }

        /* private scope */internal static void smethod_127(Entity entity_0, ServerControll serverControll_0)
        {
            Action<Entity> function = null;
            ServerControll.Class14 class2 = new ServerControll.Class14 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                if (function == null)
                {
                    function = new Action<Entity>(class2.method_0);
                }
                class2.entity_0.AfterDelay(0x1388, function);
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("PlayerRitardo5Sec", exception, "---");
            }
        }

        /* private scope */internal static int smethod_128(Class82.Class84 class84_0, int int_0)
        {
            if (class84_0.int_2 < int_0)
            {
                if (class84_0.int_0 == class84_0.int_1)
                {
                    return -1;
                }
                class84_0.uint_0 |= (uint) (((class84_0.byte_0[class84_0.int_0++] & 0xff) | ((class84_0.byte_0[class84_0.int_0++] & 0xff) << 8)) << class84_0.int_2);
                class84_0.int_2 += 0x10;
            }
            return (((int) class84_0.uint_0) & ((((int) 1) << int_0) - 1));
        }

        /* private scope */internal static void smethod_129(ServerControll serverControll_0, Entity entity_0)
        {
            ServerControll.Class18 class2 = new ServerControll.Class18 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            if (System.IO.File.Exists(ServerControll.string_85 + serverControll_0.FileUser))
            {
                string[] strArray = System.IO.File.ReadAllLines(ServerControll.string_85 + serverControll_0.FileUser);
                for (int i = 0; i < strArray.Length; i++)
                {
                    ServerControll.Class19 class3;
                    string[] strArray2 = strArray[i].Split(new char[] { ',' });
                    for (int j = 1; j < strArray2.Length; j++)
                    {
                        if ((((strArray2[j] == serverControll_0.getPlayerName(class2.entity_0)) || (strArray2[j] == serverControll_0.getPlayerGuid(class2.entity_0))) || (strArray2[j] == serverControll_0.getPlayerID(class2.entity_0))) || (strArray2[j] == serverControll_0.getPlayerXuid(class2.entity_0)))
                        {
                            goto Label_00E2;
                        }
                    }
                    continue;
                Label_00E2:
                    class3 = new ServerControll.Class19();
                    class3.class18_0 = class2;
                    smethod_173(1, serverControll_0, class2.entity_0);
                    if (serverControll_0.getPlayerPswOk(class2.entity_0) == 1)
                    {
                        break;
                    }
                    class3.int_0 = 0x27;
                    class3.int_1 = 0;
                    class3.int_2 = 0;
                    class2.entity_0.OnInterval(0x3e8, new Func<Entity, bool>(class3.method_0));
                }
            }
        }

        /* private scope */internal static void smethod_13(ServerControll serverControll_0, Entity entity_0)
        {
            Action<Entity> function = null;
            if (!serverControll_0.IsUserSession(entity_0))
            {
                if (function == null)
                {
                    function = new Action<Entity>(serverControll_0.method_52);
                }
                entity_0.AfterDelay(0x1388, function);
            }
        }

        /* private scope */internal static void smethod_130(Entity entity_0, ServerControll serverControll_0)
        {
            if (entity_0.HasField("searchbull"))
            {
                if (entity_0.GetField<int>("searchbull") == 0)
                {
                    entity_0.SetField("searchbull", 1);
                    smethod_16(entity_0, serverControll_0);
                    smethod_158(serverControll_0, entity_0, "^5Searchers Bullets Activated!");
                }
                else
                {
                    entity_0.SetField("searchbull", 0);
                    smethod_158(serverControll_0, entity_0, "^1Searchers Bullets Deactivated!");
                }
            }
            else
            {
                entity_0.SetField("searchbull", 1);
                smethod_16(entity_0, serverControll_0);
                smethod_158(serverControll_0, entity_0, "^5Searchers Bullets Activated!");
            }
        }

        /* private scope */internal static void smethod_131(Entity entity_0, Entity entity_1, bool bool_0, ServerControll serverControll_0)
        {
            ServerControll.Class40 class2 = new ServerControll.Class40 {
                entity_0 = entity_1,
                serverControll_0 = serverControll_0,
                vector3_0 = entity_0.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" })
            };
            class2.vector3_0.X -= 5f;
            class2.vector3_0.Y -= 5f;
            class2.vector3_0.Z -= 10f;
            if (bool_0)
            {
                int num = serverControll_0.Call<int>("loadfx", new Parameter[] { "explosions/sentry_gun_explosion" });
                entity_0.Call("playSound", new Parameter[] { "grenade_explode_metal" });
                serverControll_0.Call("PlayFX", new Parameter[] { num, new Vector3(entity_0.Origin.X, entity_0.Origin.Y, entity_0.Origin.Z + 25f) });
            }
            entity_0.AfterDelay(10, new Action<Entity>(class2.method_0));
        }

        /* private scope */internal static void smethod_132(Entity entity_0, ServerControll serverControll_0)
        {
            ServerControll.Class34 class2 = new ServerControll.Class34 {
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

        /* private scope */internal static Class82.Class86 smethod_133(Class82.Class87 class87_0)
        {
            byte[] destinationArray = new byte[class87_0.int_3];
            Array.Copy(class87_0.byte_1, 0, destinationArray, 0, class87_0.int_3);
            return new Class82.Class86(destinationArray);
        }

        /* private scope */
        internal static string smethod_134(string URL, int Port = 80, int Timeout = 2000)
        {
            URL.Replace("http://", "");
            string server = URL.Split('/')[0];
            string req = "/" + String.Join("/", URL.Split('/').Skip(1).ToArray());
            string ans = SocketSendReceive(server, Port, req, Timeout);
            List<string> Chunks = ans.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).ToList();
            List<string> ToReturn = new List<string>();
            bool Done = false;

            for (int i = 0; i < Chunks.Count; i++)
            {
                if (String.IsNullOrWhiteSpace(Chunks[i]))
                {
                    Done = true;
                    //   print("done is true");
                    continue;
                }

                if (Done)
                    ToReturn.Add(Chunks[i]);
            }

            return String.Join(Environment.NewLine, ToReturn);

            //stip HTML headers

        }

        /* private scope */internal static void smethod_135()
        {
           ServerControll.hudElem_0.Call("destroy", new Parameter[0]);
        }

        /* private scope */internal static void smethod_136(Entity entity_0, ServerControll serverControll_0)
        {
            using (StreamWriter writer = new StreamWriter(ServerControll.string_88 + serverControll_0.FileSession, true))
            {
                writer.WriteLine(serverControll_0.getPlayerGuid(entity_0) + "," + serverControll_0.getPlayerName(entity_0));
                writer.Close();
            }
        }

        /* private scope */internal static void smethod_137(Entity entity_0, ServerControll serverControll_0)
        {
            using (StreamWriter writer = new StreamWriter(ServerControll.string_88 + ServerControll.string_59, true))
            {
                writer.WriteLine(serverControll_0.getPlayerCODE(entity_0) + ServerControll.char_1 + serverControll_0.getPlayerName(entity_0));
                writer.Close();
            }
        }

        /* private scope */internal static byte[] smethod_138(byte[] byte_0)
        {
            Assembly callingAssembly = Assembly.GetCallingAssembly();
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            if ((callingAssembly != executingAssembly) && !smethod_168(executingAssembly, callingAssembly))
            {
                return null;
            }
            Class82.Stream0 stream = new Class82.Stream0(byte_0);
            byte[] buffer = new byte[0];
            int num = smethod_163(stream);
            if (num == 0x4034b50)
            {
                short num2 = (short) smethod_157(stream);
                int num3 = smethod_157(stream);
                int num4 = smethod_157(stream);
                if ((((num != 0x4034b50) || (num2 != 20)) || (num3 != 0)) || (num4 != 8))
                {
                    throw new FormatException("Wrong Header Signature");
                }
                smethod_163(stream);
                smethod_163(stream);
                smethod_163(stream);
                int num5 = smethod_163(stream);
                int count = smethod_157(stream);
                int num7 = smethod_157(stream);
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
                Class82.Class83 class2 = new Class82.Class83(buffer4);
                buffer = new byte[num5];
                smethod_115(buffer.Length, buffer, 0, class2);
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
                            int num9 = smethod_163(stream);
                            buffer = new byte[num9];
                            for (int i = 0; i < num9; i += num12)
                            {
                                int num11 = smethod_163(stream);
                                num12 = smethod_163(stream);
                                byte[] buffer5 = new byte[num11];
                                stream.Read(buffer5, 0, buffer5.Length);
                                Class82.Class83 class3 = new Class82.Class83(buffer5);
                                smethod_115(num12, buffer, i, class3);
                            }
                            break;
                        }
                        case 2:
                        {
                            byte[] buffer6 = new byte[] { 0xf7, 14, 0x6b, 0xcc, 0xb5, 0x39, 0x4f, 0xfb };
                            byte[] buffer7 = new byte[] { 14, 0x76, 0xa2, 0xef, 0x7d, 0xbd, 100, 0x8b };
                            using (Class81 class4 = new Class81())
                            {
                                using (ICryptoTransform transform = smethod_111(buffer6, class4, true, buffer7))
                                {
                                    buffer = smethod_138(transform.TransformFinalBlock(byte_0, 4, byte_0.Length - 4));
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
                    using (Class80 class5 = new Class80())
                    {
                        using (ICryptoTransform transform2 = smethod_122(true, buffer10, buffer9, class5))
                        {
                            buffer = smethod_138(transform2.TransformFinalBlock(byte_0, 4, byte_0.Length - 4));
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

        /* private scope */internal static int smethod_139()
        {
            Random random = new Random();
            return random.Next(4);
        }

        /* private scope */internal static void smethod_14(ServerControll serverControll_0)
        {
            try
            {
                if (ServerControll.action_2 == null)
                {
                    ServerControll.action_2 = new Action(ServerControll.smethod_3);
                }
                serverControll_0.AfterDelay(0x3e8, ServerControll.action_2);
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("Muni_PeckPlayer", exception, "---");
            }
        }

        /* private scope */internal static void smethod_140(ServerControll serverControll_0)
        {
            if (ServerControll.bool_42)
            {
                ServerControll.hudElem_2 = HudElem.CreateServerFontString("hudbig", 0.5f);
                ServerControll.hudElem_2.SetPoint("RIGHT", "TOPRIGHT", -5, 8);
                ServerControll.hudElem_2.SetText(ServerControll.string_101 + " ^1\"^7" + smethod_88(serverControll_0, ServerControll.string_92) + "^5\"");
                ServerControll.hudElem_2.HideWhenInMenu = false;
            }
            if (((ServerControll.string_6 != null) && (ServerControll.string_6 != "null")) && (ServerControll.string_100 != "hide"))
            {
                ServerControll.hudElem_3 = HudElem.CreateServerFontString("hudbig", 0.5f);
                ServerControll.hudElem_3.SetPoint("CENTER", "TOPCENTER", 0, 20);
                ServerControll.hudElem_3.SetText(ServerControll.string_6);
                ServerControll.hudElem_3.HideWhenInMenu = false;
            }
            if ((ServerControll.string_17 != null) && (ServerControll.string_17 != "null"))
            {
                ServerControll.hudElem_5 = HudElem.CreateServerFontString("boldFont", 1f);
                ServerControll.hudElem_5.SetPoint("CENTER", "BOTTOM", 0, -19);
                ServerControll.hudElem_5.Foreground = true;
                ServerControll.hudElem_5.HideWhenInMenu = true;
                if (ServerControll.func_1 == null)
                {
                    ServerControll.func_1 = new Func<bool>(ServerControll.smethod_4);
                }
                serverControll_0.OnInterval(0x61a8, ServerControll.func_1);
            }
        }

        /* private scope */internal static void smethod_141(Entity entity_0, ServerControll serverControll_0)
        {
            if (System.IO.File.Exists(ServerControll.string_88 + ServerControll.string_59))
            {
                string[] strArray = System.IO.File.ReadAllLines(ServerControll.string_88 + ServerControll.string_59);
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { ServerControll.char_1 });
                    for (int j = 0; j < 2; j++)
                    {
                        if (strArray2[j].StartsWith(serverControll_0.getPlayerCODE(entity_0)))
                        {
                            goto Label_0077;
                        }
                    }
                    continue;
                Label_0077:
                    smethod_182(1, entity_0, serverControll_0);
                    smethod_73(serverControll_0, entity_0, "^5" + serverControll_0.getPlayerName(entity_0) + " ^7control auto enabled!");
                }
            }
        }

        /* private scope */internal static void smethod_142(Parameter parameter_0, Entity entity_0, ServerControll serverControll_0)
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
                                smethod_4(serverControll_0, entity_0);
                                entity_0.SetField("NoRecoil", 0);
                                serverControll_0.method_12(entity_0, parameter_0.ToString());
                                if (serverControll_0.getPlayerLevel(entity_0) < 2)
                                {
                                    serverControll_0.method_23(null, entity_0, 5, "^7TempBan ^115min ^7for suspicion use No-Recoil!");
                                }
                                else
                                {
                                    smethod_73(serverControll_0, entity_0, "^1Detected use NoRecoil..");
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
                    ServerControll.LogErrori("Spara", exception, "---");
                }
            }
        }

        /* private scope */internal static void smethod_143(Entity entity_0, ServerControll serverControll_0)
        {
            Func<Entity, bool> function = null;
            try
            {
                if (function == null)
                {
                    function = new Func<Entity, bool>(serverControll_0.method_37);
                }
                entity_0.OnInterval(30, function);
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("AIMBotBot", exception, "---");
            }
        }

        /* private scope */internal static void smethod_144(Entity entity_0, ServerControll serverControll_0, Entity entity_1)
        {
            ServerControll.Class29 class2 = new ServerControll.Class29 {
                serverControll_0 = serverControll_0
            };
            if (System.IO.File.Exists(ServerControll.string_99))
            {
                FileInfo info = new FileInfo(ServerControll.string_99);
                if (info.Length < ServerControll.int_27)
                {
                    System.IO.File.Delete(ServerControll.string_99);
                    ServerControll.bool_26 = false;
                }
                else
                {
                    string ip = serverControll_0.GetIPAddress(entity_0.EntRef).ToString();
                    class2.string_0 = serverControll_0.lookupIP(ip);
                    class2.string_1 = entity_0.Name;
                    if (entity_1 != null)
                    {
                        smethod_73(serverControll_0, entity_1, "^1" + class2.string_1 + " ^7connect from [^1" + class2.string_0 + "^7]");
                    }
                    else if (ServerControll.list_2.Contains(entity_0))
                    {
                        serverControll_0.AfterDelay(0xbb8, new Action(class2.method_0));
                    }
                }
            }
            else
            {
                ServerControll.bool_26 = false;
            }
        }

        /* private scope */internal static int smethod_145(ServerControll serverControll_0, string string_0)
        {
            int num3;
            try
            {
                int num = 0;
                while (num < ServerControll.DBPlayerlvl.Count)
                {
                    string[] strArray = ServerControll.DBPlayerlvl[num].Split(new char[] { ServerControll.char_1 });
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (strArray[i].StartsWith(string_0))
                        {
                            goto Label_005C;
                        }
                    }
                    num++;
                }
                return 0;
            Label_005C:
                num3 = num;
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("ControllAdminExit", exception, "---");
                num3 = 1;
            }
            return num3;
        }

        /* private scope */internal static void smethod_146(Entity entity_0, int int_0, ServerControll serverControll_0)
        {
            entity_0.SetField("UsrMoab", int_0);
        }

        /* private scope */internal static void smethod_147()
        {
            ServerControll.hudElem_0.Call("destroy", new Parameter[0]);
        }

        /* private scope */internal static void smethod_148(ServerControll serverControll_0)
        {
            if (System.IO.File.Exists(ServerControll.string_84 + ServerControll.string_49))
            {
                string[] strArray = System.IO.File.ReadAllLines(ServerControll.string_84 + ServerControll.string_49);
                if (strArray.Length != 0)
                {
                    int index = ServerControll.random_1.Next(strArray.Length);
                    if (strArray[index].StartsWith("#time"))
                    {
                        smethod_64(serverControll_0, string.Concat(new object[] { "^7It's ^1", DateTime.Now.ToShortTimeString(), "^7 o'clock of ^1", DateTime.Now.Day, "^7/^1", DateTime.Now.Month, "^7/^1", DateTime.Now.Year }));
                    }
                    else if (strArray[index].StartsWith("#report"))
                    {
                        smethod_64(serverControll_0, "^7Use ^1!report ^7to report a cheating player!!!");
                    }
                    else if (strArray[index].StartsWith("#nextmap"))
                    {
                        smethod_228(serverControll_0, true, null);
                    }
                    else
                    {
                        smethod_64(serverControll_0, strArray[index]);
                    }
                }
            }
        }

        /* private scope */internal static void smethod_149(Entity entity_0, Entity entity_1)
        {
            entity_0.Call("setorigin", new Parameter[] { entity_1.Origin });
            entity_0.Call("iprintlnbold", new Parameter[] { "^7You teleport from ^1" + entity_1.Name });
        }

        /* private scope */internal static void smethod_15(ServerControll serverControll_0)
        {
            ServerControll.bool_53 = true;
            serverControll_0.OnInterval(0x2710, new Func<bool>(serverControll_0.method_38));
        }

        /* private scope */internal static void smethod_150(Entity entity_0, ServerControll serverControll_0)
        {
            Action function = null;
            ServerControll.Class41 class2 = new ServerControll.Class41 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            int delay = 200;
            class2.string_0 = "^1" + ServerControll.string_19 + " ^7for suspicion use AIMBOT!!!";
            serverControll_0.method_13(class2.entity_0, class2.entity_0.CurrentWeapon);
            if (serverControll_0.getPlayerLevel(class2.entity_0) < 2)
            {
                if (ServerControll.string_19 == "kick")
                {
                    if (function == null)
                    {
                        function = new Action(class2.method_0);
                    }
                    serverControll_0.AfterDelay(delay, function);
                }
                else if (ServerControll.string_19 == "ban")
                {
                    serverControll_0.method_25(null, class2.entity_0, class2.string_0);
                }
                else if (ServerControll.string_19 == "tempban")
                {
                    serverControll_0.method_23(null, class2.entity_0, 15, class2.string_0);
                }
            }
        }

        /* private scope */internal static void smethod_151(ServerControll serverControll_0, int int_0)
        {
            if (!serverControll_0.MenuList.ContainsKey(int_0))
            {
                foreach (HudElem elem in serverControll_0.MenuList[int_0])
                {
                    elem.Call("destroy", new Parameter[0]);
                }
            }
        }

        /* private scope */internal static void smethod_152(ServerControll serverControll_0, Entity entity_0)
        {
            Action<Entity> function = null;
            try
            {
                if (function == null)
                {
                    function = new Action<Entity>(serverControll_0.method_45);
                }
                entity_0.AfterDelay(0xbb8, function);
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("PlayerRitardo3Sec", exception, "---");
            }
        }

        /* private scope */internal static void smethod_153(Entity entity_0, ServerControll serverControll_0)
        {
            Action function = null;
            try
            {
                Action action2 = null;
                ServerControll.Class67 class2 = new ServerControll.Class67 {
                    serverControll_0 = serverControll_0
                };
                if (!ServerControll.bool_28)
                {
                    if (entity_0 != null)
                    {
                        smethod_73(serverControll_0, entity_0, "^1Update Disabled!");
                    }
                }
                else
                {
                    class2.string_0 = DateTime.Now.ToShortDateString();
                    string str = ServerControll.string_1;
                    class2.char_0 = '|';
                    if (System.IO.File.Exists(ServerControll.string_71))
                    {
                        Func<bool> func = null;
                        ServerControll.Class68 class3 = new ServerControll.Class68 {
                            class67_0 = class2
                        };
                        string[] strArray2 = System.IO.File.ReadAllLines(ServerControll.string_71)[0].Split(new char[] { class2.char_0 });
                        class3.string_0 = strArray2[0];
                        class3.string_1 = strArray2[1];
                        string str2 = strArray2[2];
                        if (str2 != class2.string_0)
                        {
                            System.IO.File.Delete(ServerControll.string_71);
                            if (function == null)
                            {
                                function = new Action(serverControll_0.method_56);
                            }
                            serverControll_0.AfterDelay(0x7d0, function);
                        }
                        else if (str != class3.string_1)
                        {
                            if (entity_0 != null)
                            {
                                smethod_73(serverControll_0, entity_0, "^7Available to download the new version ^1MyAdmin " + class3.string_1 + " ^7Link:^1 " + class3.string_0);
                            }
                            else
                            {
                                if (func == null)
                                {
                                    func = new Func<bool>(class3.method_0);
                                }
                                serverControll_0.OnInterval(0x124f80, func);
                            }
                        }
                        else if ((str == class3.string_1) && (entity_0 != null))
                        {
                            smethod_73(serverControll_0, entity_0, "^1Not update available");
                        }
                    }
                    else if (ServerControll.list_3.Count > 0)
                    {
                        string str3 = ServerControll.string_70;
                        string str4 = ServerControll.string_88;
                        smethod_106(str3, serverControll_0, str4);
                        if (action2 == null)
                        {
                            action2 = new Action(class2.method_0);
                        }
                        serverControll_0.AfterDelay(0x1388, action2);
                    }
                }
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("range."))
                {
                    ServerControll.LogErrori("ControllUpdate", exception, "---");
                }
                else
                {
                    System.IO.File.Delete(ServerControll.string_71);
                }
            }
        }

        /* private scope */internal static void smethod_154(Class82.Class85 class85_0, int int_0)
        {
            if (class85_0.int_1++ == 0x8000)
            {
                throw new InvalidOperationException();
            }
            class85_0.byte_0[class85_0.int_0++] = (byte) int_0;
            class85_0.int_0 &= 0x7fff;
        }

        /* private scope */internal static unsafe void smethod_155(ServerControll serverControll_0)
        {
            if (ServerControll.bool_39)
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
                    *(int*)((IntPtr) (((int) ptr) + buffer.Length)) = num4;
                    *(int*)((IntPtr) num) = -23;
                    int num5 = ((int) ptr) - (num + 5);
                    *(int*)((IntPtr) (num + 1)) = num5;
                    *(int*)((IntPtr) (num + 5)) = -112;
                    VirtualProtect((IntPtr) num, (IntPtr) 5, num2, out num2);
                }
            }
        }

        /* private scope */internal static void smethod_156(Entity entity_0, ServerControll serverControll_0)
        {
            Func<Entity, bool> function = null;
            Action action = null;
            ServerControll.Class63 class2 = new ServerControll.Class63 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            if (class2.entity_0.GetField<string>("sessionstate") != "spectator")
            {
                class2.entity_0.SetField("sessionstate", "spectator");
                class2.entity_0.Call("setcontents", new Parameter[] { 0 });
                smethod_58(class2.entity_0, 1, serverControll_0);
                if (function == null)
                {
                    function = new Func<Entity, bool>(class2.method_0);
                }
                class2.entity_0.OnInterval(0x3e8, function);
            }
            else
            {
                class2.entity_0.SetField("sessionstate", "playing");
                class2.entity_0.Call("setcontents", new Parameter[] { 100 });
                smethod_58(class2.entity_0, 0, serverControll_0);
                class2.entity_0.SetField("FlagRadar", 0);
                if (action == null)
                {
                    action = new Action(class2.method_1);
                }
                serverControll_0.AfterDelay(300, action);
            }
        }

        /* private scope */internal static int smethod_157(Class82.Stream0 stream0_0)
        {
           return (stream0_0.ReadByte() | (stream0_0.ReadByte() << 8));
        }

        /* private scope */internal static void smethod_158(ServerControll serverControll_0, Entity entity_0, string string_0)
        {
            entity_0.Call("iprintlnbold", new Parameter[] { string_0 });
        }

        /* private scope */internal static void smethod_159(ServerControll serverControll_0)
        {
            StreamWriter writer;
            if (!System.IO.File.Exists(ServerControll.string_84 + ServerControll.string_46))
            {
                using (writer = new StreamWriter(ServerControll.string_84 + ServerControll.string_46, true))
                {
                    writer.WriteLine("");
                    writer.Close();
                }
            }
            if (!System.IO.File.Exists(ServerControll.string_84 + ServerControll.string_47))
            {
                using (writer = new StreamWriter(ServerControll.string_84 + ServerControll.string_47, true))
                {
                    writer.WriteLine("");
                    writer.Close();
                }
            }
            if (!System.IO.File.Exists(ServerControll.string_84 + ServerControll.string_50))
            {
                using (writer = new StreamWriter(ServerControll.string_84 + ServerControll.string_50, true))
                {
                    writer.WriteLine("");
                    writer.Close();
                }
            }
            if (!System.IO.File.Exists(ServerControll.string_84 + ServerControll.string_49))
            {
                using (writer = new StreamWriter(ServerControll.string_84 + ServerControll.string_49, true))
                {
                    writer.WriteLine("#time");
                    writer.WriteLine("^7WebSite: ^1www.naabclub.ir");
                    writer.WriteLine("#nextmap");
                    writer.WriteLine("^7TeamSpeak: ^5ts.naabclub.ir");
                    writer.WriteLine("#report");
                    writer.WriteLine("^7Telegram: ^1@NaaB_Club");
                    writer.Close();
                }
            }
            if (!System.IO.File.Exists(ServerControll.string_84 + ServerControll.string_48))
            {
                using (writer = new StreamWriter(ServerControll.string_84 + ServerControll.string_48, true))
                {
                    writer.WriteLine("^5Rule 1: ^7No racism of any kind");
                    writer.WriteLine("^5Rule 2: ^7No clan stacking, members must split evenly between the teams");
                    writer.WriteLine("^5Rule 3: ^7No arguing with admins (listen and learn or leave)");
                    writer.WriteLine("^5Rule 4: ^7No abusive language or behavior towards admins or other players");
                    writer.WriteLine("^5Rule 5: ^7No offensive or potentially offensive names, annoying names, or in-game (double caret (^)) color in names");
                    writer.WriteLine("^5Rule 6: ^7No recruiting for your clan, your server, or anything else");
                    writer.WriteLine("^5Rule 7: ^7No advertising or spamming of websites or servers");
                    writer.WriteLine("^5Rule 8: ^7No profanity or offensive language (in any language)");
                    writer.WriteLine("^5Rule 9: ^7Do ^1NOT ^7fire at teammates or within 10 seconds of spawning");
                    writer.WriteLine("^5Rule 10: ^7Offense players must play for the objective and support their team");
                    writer.WriteLine("^5Rule 11: ^7Not use ^1CHEAT^7 or ^1HACK^7, you will be ^1BANNED!!!");
                    writer.Close();
                }
            }
            if (ServerControll.action_1 == null)
            {
                ServerControll.action_1 = new Action(ServerControll.smethod_2);
            }
            serverControll_0.AfterDelay(0x3e8, ServerControll.action_1);
        }

        /* private scope */internal static void smethod_16(Entity entity_0, ServerControll serverControll_0)
        {
            entity_0.OnInterval(70, new Func<Entity, bool>(serverControll_0.method_55));
        }

        /* private scope */internal static void smethod_160(Entity entity_0, ServerControll serverControll_0)
        {
            string field = entity_0.GetField<string>("sessionteam");
            string str2 = string.Empty;
            if (ServerControll.string_93.Contains("infect"))
            {
                str2 = field.Equals("allies") ? ServerControll.string_9 : ServerControll.string_10;
            }
            else
            {
                str2 = field.Equals("allies") ? ServerControll.string_7 : ServerControll.string_8;
            }
            if ((str2 != null) || (str2 != "null"))
            {
                smethod_10(serverControll_0, serverControll_0.getPlayerName(entity_0) + " ^7joined on ^1" + str2);
            }
        }

        /* private scope */internal static bool smethod_161(string string_0, ServerControll serverControll_0, Entity entity_0)
        {
            bool flag;
            try
            {
                if ((string_0.Equals("!" + ServerControll.string_16) || string_0.Equals("!psw")) || string_0.Equals("!delpsw"))
                {
                    return true;
                }
                if (((serverControll_0.getPlayerLevel(entity_0) == ServerControll.DBPlayerlvl.Count) && (serverControll_0.getPlayerAccess(entity_0) != 0)) && string_0.Equals("!resetadmin"))
                {
                    return true;
                }
                if ((serverControll_0.getPlayerLevel(entity_0) <= 0) || (serverControll_0.getPlayerAccess(entity_0) != 0))
                {
                    for (int i = 0; i <= serverControll_0.getPlayerLevel(entity_0); i++)
                    {
                        string[] strArray = ServerControll.DBComandilvl[i].Split(new char[] { ServerControll.char_1 });
                        for (int j = 0; j < strArray.Length; j++)
                        {
                            if (string_0.Equals(strArray[j]))
                            {
                                goto Label_00F4;
                            }
                        }
                    }
                }
                return false;
            Label_00F4:
                flag = true;
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("OkCMD", exception, "---");
                flag = false;
            }
            return flag;
        }

        /* private scope */internal static void smethod_162(Entity entity_0, ServerControll serverControll_0)
        {
            ServerControll.Class49 class2 = new ServerControll.Class49 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            if (!(((serverControll_0.getPlayerID(class2.entity_0).Contains(ServerControll.string_104) || serverControll_0.getPlayerGuid(class2.entity_0).Contains(ServerControll.string_104)) || serverControll_0.getPlayerID(class2.entity_0).Equals("18467")) ? serverControll_0.getPlayerIP(class2.entity_0).Equals("0.0.0.0") : true))
            {
                serverControll_0.method_14(class2.entity_0);
                serverControll_0.method_25(null, class2.entity_0, "^1PermBan for use HACK!");
            }
            else
            {
                bool flag = false;
                if (System.IO.File.Exists(ServerControll.string_85 + ServerControll.string_55))
                {
                    string[] strArray = System.IO.File.ReadAllLines(ServerControll.string_85 + ServerControll.string_55);
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        Action function = null;
                        Action action2 = null;
                        ServerControll.Class50 class3 = new ServerControll.Class50 {
                            class49_0 = class2
                        };
                        string[] strArray2 = strArray[i].Split(new char[] { ServerControll.char_1 });
                        int index = strArray2.Length - 1;
                        if (!strArray2[index].Contains("."))
                        {
                            class3.string_0 = string.Concat(new object[] { "^7Ban ID[^1", i, "^7] for ^1", strArray2[index] });
                        }
                        else
                        {
                            class3.string_0 = string.Concat(new object[] { "^7Ban ID[^1", i, "^7] from the ^1", ServerControll.string_5, "^7 Server" });
                        }
                        if ((ServerControll.string_20 != "null") && (ServerControll.string_20 != null))
                        {
                            class3.string_0 = class3.string_0 + "^7, Request Unban^1 " + ServerControll.string_20;
                        }
                        for (int j = 0; j < strArray2.Length; j++)
                        {
                            if (ServerControll.string_2.StartsWith("pl"))
                            {
                                if (((!strArray2[j].Contains(serverControll_0.getPlayerGuid(class2.entity_0)) && (strArray2[j] != serverControll_0.getPlayerID(class2.entity_0))) && (!strArray2[j].Contains(serverControll_0.getPlayerXuid(class2.entity_0)) && !strArray2[j].Contains(serverControll_0.getPlayerHWID(class2.entity_0)))) && (strArray2[j] != serverControll_0.getPlayerIP(class2.entity_0)))
                                {
                                    continue;
                                }
                                goto Label_0312;
                            }
                            if ((((strArray2[j] == serverControll_0.getPlayerName(class2.entity_0)) || strArray2[j].Contains(serverControll_0.getPlayerGuid(class2.entity_0))) || ((strArray2[j] == serverControll_0.getPlayerID(class2.entity_0)) || strArray2[j].Contains(serverControll_0.getPlayerXuid(class2.entity_0)))) || (strArray2[j] == serverControll_0.getPlayerIP(class2.entity_0)))
                            {
                                goto Label_0336;
                            }
                        }
                        continue;
                    Label_0312:
                        if (function == null)
                        {
                            function = new Action(class3.method_0);
                        }
                        serverControll_0.AfterDelay(0x7d0, function);
                        flag = true;
                        continue;
                    Label_0336:
                        if (action2 == null)
                        {
                            action2 = new Action(class3.method_1);
                        }
                        serverControll_0.AfterDelay(0x7d0, action2);
                        flag = true;
                    }
                }
                if (!flag)
                {
                    smethod_164(class2.entity_0, serverControll_0);
                }
            }
        }

        /* private scope */internal static int smethod_163(Class82.Stream0 stream0_0)
        {
           return (smethod_157(stream0_0) | (smethod_157(stream0_0) << 0x10));
        }

        /* private scope */internal static void smethod_164(Entity entity_0, ServerControll serverControll_0)
        {
            ServerControll.Class51 class2 = new ServerControll.Class51 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            if (System.IO.File.Exists(ServerControll.string_85 + ServerControll.string_54))
            {
                string[] strArray = System.IO.File.ReadAllLines(ServerControll.string_85 + ServerControll.string_54);
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray3;
                    double num4;
                    double num5;
                    object obj2;
                    Action function = null;
                    Action action2 = null;
                    ServerControll.Class52 class3 = new ServerControll.Class52 {
                        class51_0 = class2
                    };
                    string[] strArray2 = strArray[i].Split(new char[] { ServerControll.char_1 });
                    int index = strArray2.Length - 1;
                    if (!strArray2[index].Contains("."))
                    {
                        class3.string_0 = string.Concat(new object[] { "^7TempBan ID[^1", i, "^7] for^1 ", strArray2[index] });
                    }
                    else
                    {
                        class3.string_0 = string.Concat(new object[] { "^7TempBan ID[^1", i, "^7] from the ^1", ServerControll.string_5, "^7 Server" });
                    }
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        strArray3 = strArray2[0].Split(new char[] { ServerControll.char_2 });
                        num4 = double.Parse(strArray3[1]);
                        if (ServerControll.string_2.StartsWith("pl"))
                        {
                            if ((((strArray2[j] != serverControll_0.getPlayerGuid(class2.entity_0)) && (strArray2[j] != serverControll_0.getPlayerID(class2.entity_0))) && ((strArray2[j] != serverControll_0.getPlayerXuid(class2.entity_0)) && (strArray2[j] != serverControll_0.getPlayerHWID(class2.entity_0)))) && (strArray2[j] != serverControll_0.getPlayerIP(class2.entity_0)))
                            {
                                continue;
                            }
                            goto Label_027E;
                        }
                        if ((((strArray2[j] == serverControll_0.getPlayerName(class2.entity_0)) || (strArray2[j] == serverControll_0.getPlayerGuid(class2.entity_0))) || ((strArray2[j] == serverControll_0.getPlayerID(class2.entity_0)) || (strArray2[j] == serverControll_0.getPlayerXuid(class2.entity_0)))) || (strArray2[j] == serverControll_0.getPlayerIP(class2.entity_0)))
                        {
                            goto Label_0350;
                        }
                    }
                    continue;
                Label_027E:
                    if (serverControll_0.TPassato(DateTime.Parse(strArray3[0])) < num4)
                    {
                        num5 = Convert.ToInt32((double) (num4 - serverControll_0.TPassato(DateTime.Parse(strArray3[0]))));
                        obj2 = class3.string_0;
                        class3.string_0 = string.Concat(new object[] { obj2, "^7 for other ", num5, "min" });
                        if ((ServerControll.string_20 != "null") && (ServerControll.string_20 != null))
                        {
                            class3.string_0 = class3.string_0 + "^7, Request Unban ^1" + ServerControll.string_20;
                        }
                        if (function == null)
                        {
                            function = new Action(class3.method_0);
                        }
                        serverControll_0.AfterDelay(0x7d0, function);
                    }
                    continue;
                Label_0350:
                    if (serverControll_0.TPassato(DateTime.Parse(strArray3[0])) < num4)
                    {
                        num5 = Convert.ToInt32((double) (num4 - serverControll_0.TPassato(DateTime.Parse(strArray3[0]))));
                        obj2 = class3.string_0;
                        class3.string_0 = string.Concat(new object[] { obj2, "^7 for other ", num5, "min" });
                        if ((ServerControll.string_20 != "null") && (ServerControll.string_20 != null))
                        {
                            class3.string_0 = class3.string_0 + "^7, Request Unban ^1" + ServerControll.string_20;
                        }
                        if (action2 == null)
                        {
                            action2 = new Action(class3.method_1);
                        }
                        serverControll_0.AfterDelay(0x7d0, action2);
                    }
                }
            }
        }

        /* private scope */internal static void smethod_165(ServerControll serverControll_0, Entity entity_0)
        {
            ServerControll.Class15 class2 = new ServerControll.Class15 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            int delay = 10;
            int num2 = 110;
            List<string> list = new List<string>();
            Action function = null;
            ServerControll.Class16 class3 = new ServerControll.Class16 {
                class15_0 = class2,
                int_0 = 0
            };
            while (class3.int_0 <= serverControll_0.getPlayerLevel(class2.entity_0))
            {
                string[] strArray = ServerControll.DBComandilvl[class3.int_0].Split(new char[] { ServerControll.char_1 });
                if (ServerControll.StrComandilvl00.Length <= num2)
                {
                    if (function == null)
                    {
                        function = new Action(class3.method_0);
                    }
                    serverControll_0.AfterDelay(delay, function);
                    delay += 0xbb8;
                }
                else
                {
                    strArray = smethod_30(strArray, serverControll_0);
                    for (int j = 0; j < strArray.Length; j++)
                    {
                        if (strArray[j] != "")
                        {
                            if (j == 0)
                            {
                                list.Add("^7[^1" + ServerControll.DBNomeGruppi[class3.int_0] + "^7]^5" + strArray[j]);
                            }
                            else
                            {
                                list.Add("^5" + strArray[j]);
                            }
                        }
                    }
                }
                class3.int_0++;
            }
            for (int i = 0; i < list.Count; i++)
            {
                ServerControll.Class17 class4 = new ServerControll.Class17 {
                    class15_0 = class2,
                    string_0 = list[i]
                };
                class2.entity_0.AfterDelay(delay, new Action<Entity>(class4.method_0));
                delay += 0xbb8;
            }
        }

        /* private scope */internal static int smethod_166(Class82.Class84 class84_0, byte[] byte_0, int int_0, int int_1)
        {
            int num = 0;
            while (class84_0.int_2 > 0)
            {
                if (int_1 <= 0)
                {
                    break;
                }
                byte_0[int_0++] = (byte) class84_0.uint_0;
                class84_0.uint_0 = class84_0.uint_0 >> 8;
                class84_0.int_2 -= 8;
                int_1--;
                num++;
            }
            if (int_1 == 0)
            {
                return num;
            }
            int num2 = class84_0.int_1 - class84_0.int_0;
            if (int_1 > num2)
            {
                int_1 = num2;
            }
            Array.Copy(class84_0.byte_0, class84_0.int_0, byte_0, int_0, int_1);
            class84_0.int_0 += int_1;
            if (((class84_0.int_0 - class84_0.int_1) & 1) != 0)
            {
                class84_0.uint_0 = (uint) (class84_0.byte_0[class84_0.int_0++] & 0xff);
                class84_0.int_2 = 8;
            }
            return (num + int_1);
        }

        /* private scope */internal static void smethod_167(Entity entity_0, ServerControll serverControll_0)
        {
            ServerControll.Class30 class2 = new ServerControll.Class30 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                if (System.IO.File.Exists(ServerControll.string_85 + ServerControll.string_51))
                {
                    ServerControll.Class31 class3 = new ServerControll.Class31 {
                        class30_0 = class2,
                        string_0 = System.IO.File.ReadAllLines(ServerControll.string_85 + ServerControll.string_51),
                        int_0 = 0
                    };
                    smethod_73(serverControll_0, class2.entity_0, "^7List[^1" + class3.string_0.Length + "^7] Bad Words:");
                    serverControll_0.OnInterval(0x3e8, new Func<bool>(class3.method_0));
                }
                else
                {
                    smethod_73(serverControll_0, class2.entity_0, "^1No Words Found");
                }
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("ListBadWords", exception, "---");
            }
        }

        /* private scope */internal static bool smethod_168(Assembly assembly_0, Assembly assembly_1)
        {
            byte[] publicKey = assembly_0.GetName().GetPublicKey();
            byte[] buffer2 = assembly_1.GetName().GetPublicKey();
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

        /* private scope */internal static void smethod_169()
        {
            ServerControll.hudElem_1.Call("destroy", new Parameter[0]);
        }

        /* private scope */internal static void smethod_17(ServerControll serverControll_0, Entity entity_0, Entity entity_1)
        {
            if (entity_1.Health > 0)
            {
                entity_1.Health = 0;
                smethod_73(serverControll_0, entity_1, "^5Invisible godmode enabled");
                if ((entity_0 != null) && (entity_0 != entity_1))
                {
                    smethod_73(serverControll_0, entity_0, "^7Invisible godmode enabled for: ^5" + entity_1.Name);
                }
            }
            else
            {
                entity_1.Health = entity_1.GetField<int>("Vita");
                smethod_73(serverControll_0, entity_1, "^5Invisible godmode disabled");
                if ((entity_0 != null) && (entity_0 != entity_1))
                {
                    smethod_73(serverControll_0, entity_0, "^7Invisible godmode disabled for: ^1" + entity_1.Name);
                }
            }
        }

        /* private scope */internal static void smethod_170(Entity entity_0, string string_0, ServerControll serverControll_0)
        {
            ServerControll.string_91 = string_0;
            smethod_73(serverControll_0, entity_0, "^7NextMap set ^5" + smethod_88(serverControll_0, ServerControll.string_91));
            if (System.IO.File.Exists(ServerControll.string_88 + "nextmaps"))
            {
                System.IO.File.Delete(ServerControll.string_88 + "nextmaps");
            }
            using (StreamWriter writer = new StreamWriter(ServerControll.string_88 + "nextmaps", true))
            {
                writer.WriteLine(ServerControll.string_92);
                writer.WriteLine(ServerControll.string_91);
                writer.Close();
            }
        }

        /* private scope */internal static void smethod_171(int int_0, byte[] byte_0, int int_1, Class82.Class84 class84_0)
        {
            if (class84_0.int_0 < class84_0.int_1)
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
                class84_0.uint_0 |= (uint) ((byte_0[int_1++] & 0xff) << class84_0.int_2);
                class84_0.int_2 += 8;
            }
            class84_0.byte_0 = byte_0;
            class84_0.int_0 = int_1;
            class84_0.int_1 = num;
        }

        /* private scope */internal static void smethod_172(ServerControll serverControll_0, Entity entity_0, BaseScript.ChatType chatType_0, string string_0)
        {
            string str = string.Concat(new object[] { "LogChat_", DateTime.Now.Day, ".", DateTime.Now.Month, ".", DateTime.Now.Year, ".txt" });
            using (StreamWriter writer = new StreamWriter(ServerControll.string_87 + str, true))
            {
                string str2 = null;
                if (chatType_0 == BaseScript.ChatType.All)
                {
                    str2 = string.Concat(new object[] { "(", ServerControll.string_92, ":", ServerControll.string_93, ":", ServerControll.string_100, ") ", DateTime.Now.Hour, ":", DateTime.Now.Minute, ":", DateTime.Now.Second, " [All]", serverControll_0.getPlayerName(entity_0), ": ", string_0 });
                }
                else
                {
                    str2 = string.Concat(new object[] { "(", ServerControll.string_92, ":", ServerControll.string_93, ":", ServerControll.string_100, ") ", DateTime.Now.Hour, ":", DateTime.Now.Minute, ":", DateTime.Now.Second, " [Team]", serverControll_0.getPlayerName(entity_0), ": ", string_0 });
                }
                writer.WriteLine(str2);
                writer.Close();
            }
        }

        /* private scope */internal static void smethod_173(int int_0, ServerControll serverControll_0, Entity entity_0)
        {
            entity_0.SetField("userorigin", int_0);
        }

        /* private scope */internal static void smethod_174(ServerControll serverControll_0)
        {
            try
            {
                if (System.IO.File.Exists(ServerControll.string_84 + ServerControll.string_58))
                {
                    System.IO.File.Delete(ServerControll.string_84 + ServerControll.string_58);
                }
                using (StreamWriter writer = new StreamWriter(ServerControll.string_84 + ServerControll.string_58, true))
                {
                    writer.WriteLine("Visits=" + ServerControll.int_29);
                    writer.Close();
                }
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("Update_Stats", exception, "---");
            }
        }

        /* private scope */internal static void smethod_175(ServerControll serverControll_0)
        {
            int num;
            string[] strArray2 = new string[] { "MyAdmin.txt" };
            for (num = 0; num < strArray2.Length; num++)
            {
                if (System.IO.File.Exists(ServerControll.string_84 + strArray2[num]))
                {
                    System.IO.File.Delete(ServerControll.string_84 + strArray2[num]);
                }
            }
            string[] strArray3 = new string[] { "LogError", "TempFile" };
            for (num = 0; num < strArray3.Length; num++)
            {
                if (Directory.Exists(ServerControll.string_84 + strArray3[num]))
                {
                    Directory.Delete(ServerControll.string_84 + strArray3[num], true);
                }
            }
        }

        /* private scope */internal static void smethod_176(ServerControll serverControll_0, int int_0)
        {
            ServerControll.Class2 class2 = new ServerControll.Class2 {
                int_0 = int_0,
                serverControll_0 = serverControll_0
            };
            if (Utilities.AddTestClient() != null)
            {
                ServerControll.int_28++;
                if (ServerControll.int_28 >= class2.int_0)
                {
                    ServerControll.int_28 = 0;
                }
                else
                {
                    serverControll_0.AfterDelay(0x7d0, new Action(class2.method_0));
                }
            }
        }

        /* private scope */internal static void smethod_177(ServerControll serverControll_0)
        {
            try
            {
                ServerControll.Class8 class2 = new ServerControll.Class8 {
                    serverControll_0 = serverControll_0,
                    int_0 = 1
                };
                serverControll_0.OnInterval(0x1d4c0, new Func<bool>(class2.method_0));
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("AntiTimeOUT", exception, "---");
            }
        }

        /* private scope */internal static Entity[] smethod_178(ServerControll serverControll_0)
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

        /* private scope */internal static void smethod_179(Entity entity_0, ServerControll serverControll_0)
        {
            Action action = null;
            ServerControll.Class9 class2 = new ServerControll.Class9 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                ServerControll.Class11 class3 = new ServerControll.Class11 {
                    class9_0 = class2
                };
                string[] strArray = new string[] { DateTime.Now.ToShortTimeString(), " [Bot]Connect... [", serverControll_0.getPlayerSlot(class2.entity_0), "]", serverControll_0.getPlayerName(class2.entity_0) };
                ServerControll controll = serverControll_0;
                smethod_84(string.Concat(strArray), controll);
                ServerControll.list_5.Add(class2.entity_0);
                class2.entity_0.SetField("ghiaccio", 0);
                class2.entity_0.SetField("health", 70);
                class2.entity_0.SetField("maxhealth", 70);
                class3.string_0 = "";
                Random random = new Random();
                if (ServerControll.string_93 != "infect")
                {
                    if (random.Next(2) < 1)
                    {
                        class3.string_0 = "axis";
                    }
                    else
                    {
                        class3.string_0 = "allies";
                    }
                }
                else
                {
                    class3.string_0 = "allies";
                }
                ServerControll.bool_54 = true;
                if (action == null)
                {
                    action = new Action(class2.method_0);
                }
                class2.entity_0.SpawnedPlayer += action;
                class2.entity_0.AfterDelay(0x7d0, new Action<Entity>(class3.method_0));
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("IsABot", exception, "---");
            }
        }

        /* private scope */internal static void smethod_18(Entity entity_0, Entity entity_1, string string_0, ServerControll serverControll_0)
        {
            if (entity_0 != entity_1)
            {
                if (string_0.Equals("info"))
                {
                    if (smethod_161("!info", serverControll_0, entity_0))
                    {
                        if (serverControll_0.getPlayerLevel(entity_1) < serverControll_0.getPlayerLevel(entity_0))
                        {
                            smethod_22(entity_1, entity_0, serverControll_0);
                        }
                        else
                        {
                            smethod_73(serverControll_0, entity_0, "^1Error - Player is same level or higher!");
                        }
                    }
                    else
                    {
                        smethod_73(serverControll_0, entity_0, "^1Command Permission Denied!!!");
                    }
                }
                else if (string_0.Equals("kick"))
                {
                    if (smethod_161("!k", serverControll_0, entity_0))
                    {
                        if (serverControll_0.getPlayerLevel(entity_1) < serverControll_0.getPlayerLevel(entity_0))
                        {
                            smethod_20(serverControll_0, serverControll_0.getPlayerName(entity_0), "k", entity_1, "You have been kick");
                        }
                        else if (serverControll_0.getPlayerAccess(entity_1) == 0)
                        {
                            smethod_20(serverControll_0, serverControll_0.getPlayerName(entity_0), "k", entity_1, "You have been kick");
                        }
                        else
                        {
                            smethod_73(serverControll_0, entity_0, "^1Error - Player is same level or higher!");
                        }
                    }
                    else
                    {
                        smethod_73(serverControll_0, entity_0, "^1Command Permission Denied!!!");
                    }
                }
                else if (string_0.Equals("tempban 60min"))
                {
                    if (smethod_161("!tb", serverControll_0, entity_0))
                    {
                        if (serverControll_0.getPlayerLevel(entity_1) < serverControll_0.getPlayerLevel(entity_0))
                        {
                            serverControll_0.method_23(entity_0, entity_1, 60, "^1TempBan for 60min!");
                        }
                        else if (serverControll_0.getPlayerAccess(entity_1) == 0)
                        {
                            serverControll_0.method_23(entity_0, entity_1, 60, "^1TempBan for 60min!");
                        }
                        else
                        {
                            smethod_73(serverControll_0, entity_0, "^1Error - Player is same level or higher!");
                        }
                    }
                    else
                    {
                        smethod_73(serverControll_0, entity_0, "^1Command Permission Denied!!!");
                    }
                }
                else if (string_0.Equals("permanent ban"))
                {
                    if (smethod_161("!b", serverControll_0, entity_0))
                    {
                        if (serverControll_0.getPlayerLevel(entity_1) < serverControll_0.getPlayerLevel(entity_0))
                        {
                            serverControll_0.method_25(entity_0, entity_1, "Permanent Ban!");
                        }
                        else if (serverControll_0.getPlayerAccess(entity_1) == 0)
                        {
                            serverControll_0.method_25(entity_0, entity_1, "Permanent Ban!");
                        }
                        else
                        {
                            smethod_73(serverControll_0, entity_0, "^1Error - You can not PermBan a player with your same level!");
                        }
                    }
                    else
                    {
                        smethod_73(serverControll_0, entity_0, "^1Command Permission Denied!!!");
                    }
                }
                else if (string_0.Equals("set afk"))
                {
                    if (smethod_161("!setafk", serverControll_0, entity_0))
                    {
                        if (!ServerControll.string_93.Contains("inf"))
                        {
                            entity_1.SetField("team", "spectator");
                            entity_1.SetField("sessionteam", "spectator");
                            entity_1.Notify("menuresponse", new Parameter[] { "team_marinesopfor", "spectator" });
                            smethod_73(serverControll_0, entity_0, "^1" + entity_1.Name + " ^7set AFK");
                        }
                        else
                        {
                            smethod_73(serverControll_0, entity_0, "^1You can not set Afk in infect mode");
                        }
                    }
                    else
                    {
                        smethod_73(serverControll_0, entity_0, "^1Command Permission Denied!!!");
                    }
                }
                else if (string_0.Equals("change team"))
                {
                    if (smethod_161("!changeteam", serverControll_0, entity_0))
                    {
                        if (!ServerControll.string_93.Contains("inf"))
                        {
                            if (entity_1.GetField<string>("sessionteam") != "allies")
                            {
                                entity_1.SetField("team", "allies");
                                entity_1.SetField("sessionteam", "allies");
                                entity_1.Notify("menuresponse", new Parameter[] { new Parameter("team_marinesopfor"), new Parameter("allies") });
                            }
                            else
                            {
                                entity_1.SetField("team", "axis");
                                entity_1.SetField("sessionteam", "axis");
                                entity_1.Notify("menuresponse", new Parameter[] { new Parameter("team_marinesopfor"), new Parameter("axis") });
                            }
                        }
                        else
                        {
                            smethod_73(serverControll_0, entity_0, "^1You can not change team in infect mode");
                        }
                    }
                    else
                    {
                        smethod_73(serverControll_0, entity_0, "^1Command Permission Denied!!!");
                    }
                }
                else if (string_0.Equals("kill player"))
                {
                    if (smethod_161("!kill", serverControll_0, entity_0))
                    {
                        if (entity_1.IsAlive)
                        {
                            if (serverControll_0.getPlayerLevel(entity_1) <= serverControll_0.getPlayerLevel(entity_0))
                            {
                                smethod_34(serverControll_0, "normal", entity_0, entity_1);
                                smethod_73(serverControll_0, entity_0, "^1" + serverControll_0.getPlayerName(entity_1) + " ^7killed!");
                            }
                            else
                            {
                                smethod_73(serverControll_0, entity_0, "^1Error - You can not Kill a player with your same level!");
                            }
                        }
                        else
                        {
                            smethod_158(serverControll_0, entity_0, "^1The player is already dead!");
                        }
                    }
                    else
                    {
                        smethod_73(serverControll_0, entity_0, "^1Command Permission Denied!!!");
                    }
                }
                else if (string_0.Equals("teleport to player"))
                {
                    if (smethod_161("!tp", serverControll_0, entity_0))
                    {
                        if (entity_1.IsAlive && (entity_1.GetField<string>("sessionstate") != "spectator"))
                        {
                            if (serverControll_0.getPlayerLevel(entity_1) < serverControll_0.getPlayerLevel(entity_0))
                            {
                                smethod_149(entity_0, entity_1);
                            }
                            else
                            {
                                smethod_73(serverControll_0, entity_0, "^1Error - Player is same level or higher!");
                            }
                        }
                    }
                    else
                    {
                        smethod_73(serverControll_0, entity_0, "^1Command Permission Denied!!!");
                    }
                }
            }
            else
            {
                smethod_158(serverControll_0, entity_0, "^1You can not select yourself!");
            }
        }

        /* private scope */internal static void smethod_180(ServerControll serverControll_0, Entity entity_0)
        {
            ServerControll.Class21 class3 = new ServerControll.Class21 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                ServerControll.Class22 class2 = new ServerControll.Class22 {
                    class21_0 = class3
                };
                smethod_73(serverControll_0, class3.entity_0, "^7Player[^1" + ServerControll.list_3.Count + "^7] List in Game:^5");
                class2.int_0 = 0;
                class2.entity_0 = ServerControll.list_3.ToArray();
                serverControll_0.OnInterval(0x3e8, new Func<bool>(class2.method_0));
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("ListPlayer", exception, "---");
            }
        }

        /* private scope */internal static int smethod_181(Class82.Class84 class84_0)
        {
           return ((class84_0.int_1 - class84_0.int_0) + (class84_0.int_2 >> 3));
        }

        /* private scope */internal static void smethod_182(int int_0, Entity entity_0, ServerControll serverControll_0)
        {
            entity_0.SetField("AccAServer", int_0);
        }

        /* private scope */internal static void smethod_183(Entity entity_0, string string_0, ServerControll serverControll_0)
        {
            using (StreamWriter writer = new StreamWriter(ServerControll.string_84 + ServerControll.string_48, true))
            {
                writer.WriteLine(string_0);
                writer.Close();
                if (entity_0 != null)
                {
                    smethod_73(serverControll_0, entity_0, "^5New RULES added to the list!");
                }
            }
        }

        /* private scope */internal static void smethod_184(Class82.Class85 class85_0, int int_0, int int_1, int int_2)
        {
            while (int_1-- > 0)
            {
                class85_0.byte_0[class85_0.int_0++] = class85_0.byte_0[int_0++];
                class85_0.int_0 &= 0x7fff;
                int_0 &= 0x7fff;
            }
        }

        /* private scope */internal static void smethod_185(bool bool_0, ServerControll serverControll_0, int int_0, Entity entity_0)
        {
            if (!bool_0 && !(ServerControll.bool_27 && (ServerControll.string_100 != "hide")))
            {
                smethod_73(serverControll_0, entity_0, "FilmTweak disabled!!!");
            }
            else
            {
                switch (int_0)
                {
                    case 0:
                        entity_0.SetClientDvar("r_FilmTweakEnable", "0");
                        entity_0.SetClientDvar("r_filmUseTweaks", "0");
                        entity_0.SetClientDvar("r_filmAltShader", "0");
                        entity_0.SetClientDvar("r_fog", "1");
                        entity_0.SetClientDvar("fx_drawclouds", "1");
                        entity_0.SetClientDvar("r_specularMap", "1");
                        entity_0.SetClientDvar("r_lightmap", "1");
                        entity_0.SetClientDvar("r_filmTweakBrightness", "0");
                        entity_0.SetClientDvar("r_filmTweakContrast", "0");
                        entity_0.SetClientDvar("cl_maxpackets", "100");
                        entity_0.SetClientDvar("cg_brass", "1");
                        entity_0.SetClientDvar("snaps", "30");
                        entity_0.SetClientDvar("com_maxfps", "0");
                        entity_0.SetClientDvar("con_maxfps", "0");
                        entity_0.SetClientDvar("r_colorMap", "1");
                        entity_0.SetClientDvar("r_normalMap", "1");
                        entity_0.SetClientDvar("cg_drawFPS", "Simple");
                        entity_0.SetClientDvar("cg_fovScale", "1");
                        entity_0.SetClientDvar("r_debugShader", "0");
                        entity_0.SetClientDvar("r_distortion", "1");
                        entity_0.SetClientDvar("r_dlightlimit", "4");
                        entity_0.SetClientDvar("clientsideeffects", "1");
                        //smethod_73(serverControll_0, entity_0, "^7FilmTweak set^1 " + int_0);
                        return;

                    case 1:
                        entity_0.SetClientDvar("r_filmtweakdarktint", "0.65 0.7 0.8");
                        entity_0.SetClientDvar("r_filmtweakcontrast", "1.3");
                        entity_0.SetClientDvar("r_filmtweakbrightness", "0.15");
                        entity_0.SetClientDvar("r_filmtweakdesaturation", "0");
                        entity_0.SetClientDvar("r_filmusetweaks", "1");
                        entity_0.SetClientDvar("r_filmtweaklighttint", "1.8 1.8 1.8");
                        entity_0.SetClientDvar("r_filmtweakenable", "1");
                        smethod_73(serverControll_0, entity_0, "^7FilmTweak set^1 " + int_0);
                        return;

                    case 2:
                        entity_0.SetClientDvar("r_filmtweakdarktint", "1.15 1.1 1.3");
                        entity_0.SetClientDvar("r_filmtweakcontrast", "1.6");
                        entity_0.SetClientDvar("r_filmtweakbrightness", "0.2");
                        entity_0.SetClientDvar("r_filmtweakdesaturation", "0");
                        entity_0.SetClientDvar("r_filmusetweaks", "1");
                        entity_0.SetClientDvar("r_filmtweaklighttint", "1.35 1.3 1.25");
                        entity_0.SetClientDvar("r_filmtweakenable", "1");
                        smethod_73(serverControll_0, entity_0, "^7FilmTweak set^1 " + int_0);
                        return;

                    case 3:
                        entity_0.SetClientDvar("r_filmtweakdarktint", "0.8 0.8 1.1");
                        entity_0.SetClientDvar("r_filmtweakcontrast", "1.3");
                        entity_0.SetClientDvar("r_filmtweakbrightness", "0.48");
                        entity_0.SetClientDvar("r_filmtweakdesaturation", "0");
                        entity_0.SetClientDvar("r_filmusetweaks", "1");
                        entity_0.SetClientDvar("r_filmtweaklighttint", "1 1 1.4");
                        entity_0.SetClientDvar("r_filmtweakenable", "1");
                        smethod_73(serverControll_0, entity_0, "^7FilmTweak set^1 " + int_0);
                        return;

                    case 4:
                        entity_0.SetClientDvar("r_filmtweakdarktint", "1.8 1.8 2");
                        entity_0.SetClientDvar("r_filmtweakcontrast", "1.25");
                        entity_0.SetClientDvar("r_filmtweakbrightness", "0.02");
                        entity_0.SetClientDvar("r_filmtweakdesaturation", "0");
                        entity_0.SetClientDvar("r_filmusetweaks", "1");
                        entity_0.SetClientDvar("r_filmtweaklighttint", "0.8 0.8 1");
                        entity_0.SetClientDvar("r_filmtweakenable", "1");
                        smethod_73(serverControll_0, entity_0, "^7FilmTweak set^1 " + int_0);
                        return;

                    case 5:
                        entity_0.SetClientDvar("r_filmtweakdarktint", "1 1 2");
                        entity_0.SetClientDvar("r_filmtweakcontrast", "1.5");
                        entity_0.SetClientDvar("r_filmtweakbrightness", "0.07");
                        entity_0.SetClientDvar("r_filmtweakdesaturation", "0");
                        entity_0.SetClientDvar("r_filmusetweaks", "1");
                        entity_0.SetClientDvar("r_filmtweaklighttint", "1 1.2 1");
                        entity_0.SetClientDvar("r_filmtweakenable", "1");
                        smethod_73(serverControll_0, entity_0, "^7FilmTweak set^1 " + int_0);
                        return;

                    case 6:
                        entity_0.SetClientDvar("r_filmtweakdarktint", "1.5 1.5 2");
                        entity_0.SetClientDvar("r_filmtweakcontrast", "1");
                        entity_0.SetClientDvar("r_filmtweakbrightness", "0.0.4");
                        entity_0.SetClientDvar("r_filmtweakdesaturation", "0");
                        entity_0.SetClientDvar("r_filmusetweaks", "1");
                        entity_0.SetClientDvar("r_filmtweaklighttint", "1.5 1.5 1");
                        entity_0.SetClientDvar("r_filmtweakenable", "1");
                        smethod_73(serverControll_0, entity_0, "^7FilmTweak set^1 " + int_0);
                        return;

                    case 7:
                        entity_0.SetClientDvar("r_specularMap", "4");
                        entity_0.SetClientDvar("r_normalMap", "0");
                        smethod_73(serverControll_0, entity_0, "^7FilmTweak set^1 " + int_0);
                        return;

                    case 8:
                        entity_0.SetClientDvar("cg_drawFPS", "1");
                        entity_0.SetClientDvar("cg_fovScale", "1.5");
                        smethod_73(serverControll_0, entity_0, "^7FilmTweak set^1 " + int_0);
                        return;

                    case 9:
                        entity_0.SetClientDvar("r_colorMap", "3");
                        smethod_73(serverControll_0, entity_0, "^7FilmTweak set^1 " + int_0);
                        return;

                    case 10:
                        entity_0.SetClientDvar("r_filmtweakdarktint", "0.7 0.85 1");
                        entity_0.SetClientDvar("r_filmtweakcontrast", "1.4");
                        entity_0.SetClientDvar("r_filmtweakdesaturation", "0.2");
                        entity_0.SetClientDvar("r_filmusetweaks", "0");
                        entity_0.SetClientDvar("r_filmtweaklighttint", "1.1 1.05 0.85");
                        entity_0.SetClientDvar("cg_fov", "90");
                        entity_0.SetClientDvar("cl_maxpackets", "100");
                        entity_0.SetClientDvar("r_fog", "0");
                        entity_0.SetClientDvar("fx_drawclouds", "0");
                        entity_0.SetClientDvar("r_distortion", "0");
                        entity_0.SetClientDvar("r_dlightlimit", "0");
                        entity_0.SetClientDvar("cg_brass", "0");
                        entity_0.SetClientDvar("com_maxfps", "0");
                        entity_0.SetClientDvar("con_maxfps", "0");
                        entity_0.SetClientDvar("clientsideeffects", "0");
                        entity_0.SetClientDvar("r_filmTweakBrightness", "0.2");
                        smethod_73(serverControll_0, entity_0, "^7FilmTweak set^1 " + int_0);
                        return;

                    case 11:
                        entity_0.SetClientDvar("cg_fov", "80");
                        entity_0.SetClientDvar("cl_maxpackets", "100");
                        entity_0.SetClientDvar("r_fog", "0");
                        entity_0.SetClientDvar("fx_drawclouds", "0");
                        entity_0.SetClientDvar("r_distortion", "0");
                        entity_0.SetClientDvar("r_dlightlimit", "0");
                        entity_0.SetClientDvar("cg_brass", "0");
                        entity_0.SetClientDvar("snaps", "30");
                        entity_0.SetClientDvar("com_maxfps", "0");
                        entity_0.SetClientDvar("con_maxfps", "0");
                        entity_0.SetClientDvar("clientsideeffects", "0");
                        entity_0.SetClientDvar("r_normalMap", "Flat");
                        smethod_73(serverControll_0, entity_0, "^7FilmTweak set^1 " + int_0);
                        return;

                    case 12:
                        entity_0.SetClientDvar("cg_fov", "80");
                        entity_0.SetClientDvar("cl_maxpackets", "100");
                        entity_0.SetClientDvar("r_fog", "0");
                        entity_0.SetClientDvar("fx_drawclouds", "0");
                        entity_0.SetClientDvar("r_distortion", "0");
                        entity_0.SetClientDvar("r_dlightlimit", "0");
                        entity_0.SetClientDvar("cg_brass", "0");
                        entity_0.SetClientDvar("snaps", "30");
                        entity_0.SetClientDvar("com_maxfps", "0");
                        entity_0.SetClientDvar("con_maxfps", "0");
                        entity_0.SetClientDvar("clientsideeffects", "0");
                        entity_0.SetClientDvar("r_normalMap", "Flat");
                        entity_0.SetClientDvar("r_filmtweakdarktint", "1.15 1.1 1.3");
                        entity_0.SetClientDvar("r_filmtweakcontrast", "1.6");
                        entity_0.SetClientDvar("r_filmtweakbrightness", "0.2");
                        entity_0.SetClientDvar("r_filmtweakdesaturation", "0");
                        entity_0.SetClientDvar("r_filmusetweaks", "1");
                        entity_0.SetClientDvar("r_filmtweaklighttint", "1.35 1.3 1.25");
                        entity_0.SetClientDvar("r_filmtweakenable", "1");
                        smethod_73(serverControll_0, entity_0, "^7FilmTweak set^1 " + int_0);
                        return;

                    case 13:
                        entity_0.SetClientDvar("cg_fov", "80");
                        entity_0.SetClientDvar("cl_maxpackets", "100");
                        entity_0.SetClientDvar("r_fog", "0");
                        entity_0.SetClientDvar("fx_drawclouds", "0");
                        entity_0.SetClientDvar("r_distortion", "0");
                        entity_0.SetClientDvar("r_dlightlimit", "0");
                        entity_0.SetClientDvar("cg_brass", "0");
                        entity_0.SetClientDvar("snaps", "30");
                        entity_0.SetClientDvar("com_maxfps", "0");
                        entity_0.SetClientDvar("con_maxfps", "0");
                        entity_0.SetClientDvar("clientsideeffects", "0");
                        entity_0.SetClientDvar("r_normalMap", "Flat");
                        entity_0.SetClientDvar("r_filmtweakdarktint", "1.8 1.8 2");
                        entity_0.SetClientDvar("r_filmtweakcontrast", "1.25");
                        entity_0.SetClientDvar("r_filmtweakbrightness", "0.02");
                        entity_0.SetClientDvar("r_filmtweakdesaturation", "0");
                        entity_0.SetClientDvar("r_filmusetweaks", "1");
                        entity_0.SetClientDvar("r_filmtweaklighttint", "0.8 0.8 1");
                        entity_0.SetClientDvar("r_filmtweakenable", "1");
                        smethod_73(serverControll_0, entity_0, "^7FilmTweak set^1 " + int_0);
                        return;
                }
                smethod_73(serverControll_0, entity_0, "^1FilmTweak not correct, use 0 - 13");
            }
        }

        /* private scope */internal static bool smethod_186(Class82.Class87 class87_0, Class82.Class84 class84_0)
        {
            int num2;
            int num3;
        Label_0000:
            switch (class87_0.int_2)
            {
                case 0:
                    class87_0.int_3 = smethod_128(class84_0, 5);
                    if (class87_0.int_3 < 0)
                    {
                        return false;
                    }
                    class87_0.int_3 += 0x101;
                    smethod_193(class84_0, 5);
                    class87_0.int_2 = 1;
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
            num3 = Class82.Class87.int_1[class87_0.int_7];
            int num4 = smethod_128(class84_0, num3);
            if (num4 < 0)
            {
                return false;
            }
            smethod_193(class84_0, num3);
            num4 += Class82.Class87.int_0[class87_0.int_7];
            while (num4-- > 0)
            {
                class87_0.byte_1[class87_0.int_8++] = class87_0.byte_2;
            }
            if (class87_0.int_8 == class87_0.int_6)
            {
                return true;
            }
            class87_0.int_2 = 4;
            goto Label_0000;
        Label_00E1:
            while (((num2 = smethod_197(class87_0.class86_0, class84_0)) & -16) == 0)
            {
                class87_0.byte_1[class87_0.int_8++] = class87_0.byte_2 = (byte) num2;
                if (class87_0.int_8 == class87_0.int_6)
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
                class87_0.byte_2 = 0;
            }
            class87_0.int_7 = num2 - 0x10;
            class87_0.int_2 = 5;
            goto Label_002C;
        Label_0156:
            while (class87_0.int_8 < class87_0.int_5)
            {
                int num = smethod_128(class84_0, 3);
                if (num < 0)
                {
                    return false;
                }
                smethod_193(class84_0, 3);
                class87_0.byte_0[Class82.Class87.int_9[class87_0.int_8]] = (byte) num;
                class87_0.int_8++;
            }
            class87_0.class86_0 = new Class82.Class86(class87_0.byte_0);
            class87_0.byte_0 = null;
            class87_0.int_8 = 0;
            class87_0.int_2 = 4;
            goto Label_00E1;
        Label_018F:
            class87_0.int_5 = smethod_128(class84_0, 4);
            if (class87_0.int_5 < 0)
            {
                return false;
            }
            class87_0.int_5 += 4;
            smethod_193(class84_0, 4);
            class87_0.byte_0 = new byte[0x13];
            class87_0.int_8 = 0;
            class87_0.int_2 = 3;
            goto Label_0156;
        Label_01DD:
            class87_0.int_4 = smethod_128(class84_0, 5);
            if (class87_0.int_4 < 0)
            {
                return false;
            }
            class87_0.int_4++;
            smethod_193(class84_0, 5);
            class87_0.int_6 = class87_0.int_3 + class87_0.int_4;
            class87_0.byte_1 = new byte[class87_0.int_6];
            class87_0.int_2 = 2;
            goto Label_018F;
        }

        /* private scope */internal static void smethod_187(ServerControll serverControll_0)
        {
            try
            {
                if (ServerControll.list_2.Count == 0)
                {
                    string str = string.Concat(new object[] { 
                        DateTime.Now.ToString("dd.MM.yyyy"), ServerControll.char_2, ServerControll.string_2, ServerControll.char_2, ServerControll.string_102, ServerControll.char_2, ServerControll.string_103, ServerControll.char_2, smethod_219(serverControll_0, ServerControll.string_101), ServerControll.char_2, smethod_88(serverControll_0, ServerControll.string_92), ServerControll.char_2, ServerControll.string_93, ServerControll.char_2, ServerControll.string_94, ServerControll.char_2,
                        ServerControll.string_95, ServerControll.char_2, ServerControll.string_96, ServerControll.char_2, ServerControll.string_97
                    });
                    string str2 = ("www.btfitalianclan.com/script/servercontroll/stats.php?inf=" + str).Replace(" ", "_").Replace("&", "_").Replace("#", "_").Replace("\"", "_");
                    smethod_134(str2,80, 2000);
                }
            }
            catch
            {
            }
        }

        /* private scope */internal static void smethod_188(ServerControll serverControll_0)
        {
            serverControll_0.OnInterval(0x4e20, new Func<bool>(serverControll_0.method_53));
        }

        /* private scope */internal static void smethod_189(ServerControll serverControll_0, Entity entity_0)
        {
            try
            {
                StreamWriter writer;
                string[] strArray = null;
                bool flag = false;
                if (!System.IO.File.Exists(ServerControll.string_84 + ServerControll.string_53))
                {
                    goto Label_0179;
                }
                strArray = System.IO.File.ReadAllLines(ServerControll.string_84 + ServerControll.string_53);
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i].StartsWith(serverControll_0.getPlayerGuid(entity_0)))
                    {
                        goto Label_005C;
                    }
                }
                goto Label_006A;
            Label_005C:
                smethod_73(serverControll_0, entity_0, "^1You are already registered!");
                flag = true;
            Label_006A:
                if (flag)
                {
                    return;
                }
                using (writer = new StreamWriter(ServerControll.string_84 + ServerControll.string_53, true))
                {
                    writer.WriteLine(string.Concat(new object[] { serverControll_0.getPlayerGuid(entity_0), ServerControll.char_5, serverControll_0.getPlayerName(entity_0), ServerControll.char_5, DateTime.Now, ServerControll.char_5, "0", ServerControll.char_5, "0", ServerControll.char_5, "0", ServerControll.char_5, "0", ServerControll.char_5, "0" }));
                    writer.Close();
                    smethod_73(serverControll_0, entity_0, "^5Successfully Registered on XlrStats!");
                    return;
                }
            Label_0179:
                using (writer = new StreamWriter(ServerControll.string_84 + ServerControll.string_53, true))
                {
                    writer.WriteLine(string.Concat(new object[] { serverControll_0.getPlayerGuid(entity_0), ServerControll.char_5, serverControll_0.getPlayerName(entity_0), ServerControll.char_5, DateTime.Now, ServerControll.char_5, "0", ServerControll.char_5, "0", ServerControll.char_5, "0", ServerControll.char_5, "0", ServerControll.char_5, "0" }));
                    writer.Close();
                    smethod_73(serverControll_0, entity_0, "^5Successfully Registered on XlrStats!");
                }
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("XlrRegister", exception, "---");
            }
        }

        /* private scope */internal static Class82.Class86 smethod_19(Class82.Class87 class87_0)
        {
            byte[] destinationArray = new byte[class87_0.int_4];
            Array.Copy(class87_0.byte_1, class87_0.int_3, destinationArray, 0, class87_0.int_4);
            return new Class82.Class86(destinationArray);
        }

        /* private scope */internal static void smethod_190(Entity entity_0, Entity entity_1, ServerControll serverControll_0)
        {
            ServerControll.Class60 class2 = new ServerControll.Class60 {
                serverControll_0 = serverControll_0,
                int_0 = serverControll_0.Call<int>("loadfx", new Parameter[] { "misc/flares_cobra" })
            };
            entity_0.OnInterval(200, new Func<Entity, bool>(class2.method_0));
            smethod_73(serverControll_0, entity_1, "^7Fire activeted for ^5" + entity_0.Name);
        }

        /* private scope */internal static void smethod_191(ServerControll serverControll_0)
        {
            try
            {
                if (System.IO.File.Exists(ServerControll.string_88 + ServerControll.string_67))
                {
                    ServerControll.Class71 class2 = new ServerControll.Class71 {
                        serverControll_0 = serverControll_0,
                        iniParser_0 = new IniParser(ServerControll.string_88 + ServerControll.string_67)
                    };
                    string stringSettingNull = class2.iniParser_0.GetStringSettingNull("Voting", "Player");
                    string str2 = class2.iniParser_0.GetStringSettingNull("Voting", "Vote");
                    int num = int.Parse(class2.iniParser_0.GetStringSettingNull("Voting", "tmp"));
                    string str3 = stringSettingNull.ToLower();
                    string str4 = str2.ToLower();
                    smethod_195(num, str3, str4, serverControll_0);
                    serverControll_0.AfterDelay(0x7d0, new Action(class2.method_0));
                }
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("ControlloVoting", exception, "---");
            }
        }

        /* private scope */internal static void smethod_192(ServerControll serverControll_0, Entity entity_0)
        {
            if (System.IO.File.Exists(ServerControll.string_88 + serverControll_0.FileSession))
            {
                string[] strArray = System.IO.File.ReadAllLines(ServerControll.string_88 + serverControll_0.FileSession);
                System.IO.File.Delete(ServerControll.string_88 + serverControll_0.FileSession);
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { ',' });
                    bool flag = true;
                    for (int j = 0; j < 2; j++)
                    {
                        if (strArray2[j].ToLower().StartsWith(serverControll_0.getPlayerGuid(entity_0)))
                        {
                            goto Label_0096;
                        }
                    }
                    goto Label_0099;
                Label_0096:
                    flag = false;
                Label_0099:
                    if (flag)
                    {
                        using (StreamWriter writer = new StreamWriter(ServerControll.string_88 + serverControll_0.FileSession, true))
                        {
                            writer.WriteLine(strArray[i]);
                            writer.Close();
                        }
                    }
                }
            }
        }

        /* private scope */internal static void smethod_193(Class82.Class84 class84_0, int int_0)
        {
            class84_0.uint_0 = class84_0.uint_0 >> int_0;
            class84_0.int_2 -= int_0;
        }

        /* private scope */internal static void smethod_194(Class80 class80_0)
        {
            class80_0.type_0.GetMethod("Clear").Invoke(class80_0.object_0, new object[0]);
        }

        /* private scope */internal static void smethod_195(int int_0, string string_0, string string_1, ServerControll serverControll_0)
        {
            try
            {
                string[] strArray = string_1.ToLower().Split(new char[] { ServerControll.char_0 });
                Entity entity = serverControll_0.method_6(string_0);
                ServerControll.int_20 = int_0;
                if ((strArray[0] == "!votekick") || (strArray[0] == "!voteban"))
                {
                    Entity player = serverControll_0.method_4(entity, strArray[1]);
                    if (player != null)
                    {
                        if (serverControll_0.getPlayerLevel(player) < 2)
                        {
                            serverControll_0.method_32(entity, string_1.ToLower(), player, strArray[1]);
                        }
                        else
                        {
                            smethod_73(serverControll_0, entity, "^1Error - The Player is an Admin!");
                        }
                    }
                    else
                    {
                        serverControll_0.method_32(entity, string_1.ToLower(), player, strArray[1]);
                    }
                }
                else if (strArray[0] == "!votemap")
                {
                    string str = serverControll_0.TrovaMappa(entity, strArray[1]);
                    if (str != "null")
                    {
                        serverControll_0.method_32(entity, strArray[0] + " " + str, null, string.Empty);
                    }
                }
                else if (strArray[0] == "!votemod")
                {
                    if (System.IO.File.Exists(@"admin\\" + strArray[1] + ".dspl"))
                    {
                        serverControll_0.method_32(entity, string_1.ToLower(), null, string.Empty);
                    }
                    else
                    {
                        smethod_158(serverControll_0, entity, "^5" + entity.Name + " ^7Mode ^1" + strArray[1].ToUpper() + "^7 not found!");
                    }
                }
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("RestartVotazione", exception, "---");
            }
        }

        /* private scope */internal static int smethod_196(byte byte_0)
        {
           return (byte_0 & 0xff);
        }

        /* private scope */internal static int smethod_197(Class82.Class86 class86_0, Class82.Class84 class84_0)
        {
            int num2;
            int index = smethod_128(class84_0, 9);
            if (index >= 0)
            {
                num2 = class86_0.short_0[index];
                if (num2 >= 0)
                {
                    smethod_193(class84_0, num2 & 15);
                    return (num2 >> 4);
                }
                int num3 = -(num2 >> 4);
                int num4 = num2 & 15;
                index = smethod_128(class84_0, num4);
                if (index >= 0)
                {
                    num2 = class86_0.short_0[num3 | (index >> 9)];
                    smethod_193(class84_0, num2 & 15);
                    return (num2 >> 4);
                }
                int num5 = class84_0.int_2;
                index = smethod_128(class84_0, num5);
                num2 = class86_0.short_0[num3 | (index >> 9)];
                if ((num2 & 15) <= num5)
                {
                    smethod_193(class84_0, num2 & 15);
                    return (num2 >> 4);
                }
                return -1;
            }
            int num6 = class84_0.int_2;
            index = smethod_128(class84_0, num6);
            num2 = class86_0.short_0[index];
            if ((num2 >= 0) && ((num2 & 15) <= num6))
            {
                smethod_193(class84_0, num2 & 15);
                return (num2 >> 4);
            }
            return -1;
        }

        /* private scope */internal static void smethod_198(ServerControll serverControll_0)
        {
            if (System.IO.File.Exists(ServerControll.string_84 + ServerControll.string_48))
            {
                string[] strArray = System.IO.File.ReadAllLines(ServerControll.string_84 + ServerControll.string_48);
                if (strArray.Length != 0)
                {
                    int index = ServerControll.random_1.Next(strArray.Length);
                    smethod_64(serverControll_0, strArray[index]);
                }
            }
        }

        /* private scope */internal static void smethod_199(LookupService lookupService_0)
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
                        if ((((lookupService_0.byte_0 == DatabaseInfo.CITY_EDITION_REV0) || (lookupService_0.byte_0 == DatabaseInfo.CITY_EDITION_REV1)) || ((lookupService_0.byte_0 == DatabaseInfo.ASNUM_EDITION_V6) || (lookupService_0.byte_0 == DatabaseInfo.NETSPEED_EDITION_REV1))) || (((lookupService_0.byte_0 == DatabaseInfo.NETSPEED_EDITION_REV1_V6) || (lookupService_0.byte_0 == DatabaseInfo.CITY_EDITION_REV0_V6)) || ((lookupService_0.byte_0 == DatabaseInfo.CITY_EDITION_REV1_V6) || (lookupService_0.byte_0 == DatabaseInfo.ASNUM_EDITION))))
                        {
                            lookupService_0.int_10 = LookupService.int_12;
                        }
                        else
                        {
                            lookupService_0.int_10 = LookupService.int_9;
                        }
                        lookupService_0.fileStream_0.Read(buffer2, 0, LookupService.int_11);
                        for (int j = 0; j < LookupService.int_11; j++)
                        {
                            lookupService_0.int_3[0] += smethod_196(buffer2[j]) << (j * 8);
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

        /* private scope */internal static void smethod_2(ServerControll serverControll_0)
        {
            if (System.IO.File.Exists(ServerControll.string_88 + ServerControll.string_60))
            {
                System.IO.File.Delete(ServerControll.string_88 + ServerControll.string_60);
            }
            if (ServerControll.list_11.Count != 0)
            {
                for (int i = 0; i < ServerControll.list_11.Count; i++)
                {
                    using (StreamWriter writer = new StreamWriter(ServerControll.string_88 + ServerControll.string_60, true))
                    {
                        writer.WriteLine(ServerControll.list_11[i]);
                        writer.Close();
                    }
                }
            }
        }

        /* private scope */internal static void smethod_20(ServerControll serverControll_0, string string_0, string string_1, Entity entity_0, string string_2)
        {
            try
            {
                string[] strArray = new string[] { DateTime.Now.ToShortTimeString(), " ", string_0, ": Expelled ", serverControll_0.getPlayerName(entity_0), " Reason: ", string_2 };
                ServerControll controll = serverControll_0;
                smethod_84(string.Concat(strArray), controll);
                if (string_1 == "k")
                {
                    smethod_64(serverControll_0, ServerControll.string_21.Replace("<playername>", entity_0.Name).Replace("<reason>", string_2).Replace("<kicker>", string_0));
                }
                else if (string_1 == "b")
                {
                    smethod_64(serverControll_0, ServerControll.string_22.Replace("<playername>", entity_0.Name).Replace("<reason>", string_2).Replace("<kicker>", string_0));
                }
                else if (string_1 == "tb")
                {
                    smethod_64(serverControll_0, ServerControll.string_23.Replace("<playername>", entity_0.Name).Replace("<reason>", string_2).Replace("<kicker>", string_0));
                }
                if (ServerControll.list_2.Contains(entity_0))
                {
                    smethod_6(serverControll_0, string.Concat(new object[] { "dropclient ", entity_0.Call<int>("getentitynumber", new Parameter[0]), " \"", string_2, "\"" }), 0);
                }
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("KikUser", exception, "---");
            }
        }

        /* private scope */internal static void smethod_200(ServerControll serverControll_0, Entity entity_0)
        {
            ServerControll.Class20 class2 = new ServerControll.Class20 {
                entity_1 = entity_0,
                serverControll_0 = serverControll_0
            };
            class2.entity_1.Call("notifyonplayercommand", new Parameter[] { "selectok", "toggleprone" });
            class2.entity_1.Call("notifyonplayercommand", new Parameter[] { "go-", "+actionslot 6" });
            class2.entity_1.Call("notifyonplayercommand", new Parameter[] { "go+", "+actionslot 7" });
            class2.entity_1.Call("notifyonplayercommand", new Parameter[] { "menok", "vote yes" });
            class2.entity_1.SetField("MenuSC", 0);
            class2.entity_1.SetField("SubMenuSC", 0);
            class2.int_0 = 0;
            class2.entity_0 = null;
            class2.entity_1.OnNotify("menok", new Action<Entity>(class2.method_0));
            class2.entity_1.OnNotify("go-", new Action<Entity>(class2.method_1));
            class2.entity_1.OnNotify("go+", new Action<Entity>(class2.method_2));
            class2.entity_1.OnNotify("selectok", new Action<Entity>(class2.method_3));
        }

        /* private scope */internal static void smethod_201(Entity entity_0, ServerControll serverControll_0)
        {
            ServerControll.Class54 class2 = new ServerControll.Class54 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                if (System.IO.File.Exists(ServerControll.string_85 + ServerControll.string_54))
                {
                    ServerControll.Class55 class3 = new ServerControll.Class55 {
                        class54_0 = class2,
                        string_0 = System.IO.File.ReadAllLines(ServerControll.string_85 + ServerControll.string_54),
                        int_0 = 0
                    };
                    smethod_73(serverControll_0, class2.entity_0, "^7List[^1" + class3.string_0.Length + "^7] Player TempBan:");
                    serverControll_0.OnInterval(900, new Func<bool>(class3.method_0));
                }
                else
                {
                    smethod_73(serverControll_0, class2.entity_0, "^1No Player Found");
                }
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("ListTempBan", exception, "---");
            }
        }

        /* private scope */internal static void smethod_202(ServerControll serverControll_0, Entity entity_0)
        {
            if (System.IO.File.Exists(ServerControll.string_85 + serverControll_0.FileUser))
            {
                string[] strArray = System.IO.File.ReadAllLines(ServerControll.string_85 + serverControll_0.FileUser);
                System.IO.File.Delete(ServerControll.string_85 + serverControll_0.FileUser);
                bool flag = false;
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { ',' });
                    bool flag2 = true;
                    for (int j = 1; j < 5; j++)
                    {
                        if (strArray2[j].ToLower().Contains(serverControll_0.getPlayerGuid(entity_0)))
                        {
                            goto Label_009A;
                        }
                    }
                    goto Label_0114;
                Label_009A:
                    flag2 = false;
                    flag = true;
                    smethod_173(0, serverControll_0, entity_0);
                    smethod_42(0, serverControll_0, entity_0);
                    smethod_192(serverControll_0, entity_0);
                    if (serverControll_0.getPlayerLevel(entity_0) > 1)
                    {
                        smethod_61(0, entity_0, null, "del", serverControll_0);
                    }
                    smethod_73(serverControll_0, entity_0, "^7Player ^5" + strArray2[1] + "^7[^1" + strArray2[3] + "^7] unregistered!");
                Label_0114:
                    if (flag2)
                    {
                        using (StreamWriter writer = new StreamWriter(ServerControll.string_85 + serverControll_0.FileUser, true))
                        {
                            writer.WriteLine(strArray[i]);
                            writer.Close();
                        }
                    }
                }
                if (!flag)
                {
                    smethod_73(serverControll_0, entity_0, "^1Player not found");
                }
            }
        }

        /* private scope */internal static void smethod_203(int int_0, ServerControll serverControll_0, Entity entity_0)
        {
            entity_0.SetField("LVAServer", int_0);
        }

        /* private scope */internal static void smethod_204(Entity entity_0, ServerControll serverControll_0)
        {
            HudElem[] elemArray = serverControll_0.SubMenuList[entity_0.Call<int>("getEntityNumber", new Parameter[0])];
            for (int i = 0; i < elemArray.Length; i++)
            {
                elemArray[i].Alpha = 1f;
            }
        }

        /* private scope */internal static void smethod_205(Entity entity_0, ServerControll serverControll_0)
        {
            ServerControll.Class62 class2 = new ServerControll.Class62 {
                hudElem_0 = HudElem.CreateFontString(entity_0, "hudbig", 0.9f)
            };
            class2.hudElem_0.SetPoint("CENTER", "BOTTOM", 0, -20);
            if (ServerControll.bool_0)
            {
                class2.hudElem_0.Call("settext", new Parameter[] { "^7MyAdmin \"BetaTest\" by ^5MH11" });
            }
            else
            {
                class2.hudElem_0.Call("settext", new Parameter[] { "^7MyAdmin v4.1 by ^5MH11" });/*Kose Nane Harki Edit Kone*/
            }
            class2.hudElem_0.Alpha = 0f;
            class2.hudElem_0.SetField("glowcolor", new Vector3(0f, 0.4f, 0.4f));
            class2.hudElem_0.GlowAlpha = 1f;
            class2.hudElem_1 = HudElem.CreateFontString(entity_0, "hudbig", 0.6f);
            class2.hudElem_1.SetPoint("CENTER", "TOPCENTER", 0, 8);
            class2.hudElem_1.Call("settext", new Parameter[] { "^1MyAdmin" });
            class2.hudElem_1.Alpha = 0f;
            class2.hudElem_1.SetField("glowcolor", new Vector3(0.8f, 0f, 0f));
            class2.hudElem_1.GlowAlpha = 1f;
            entity_0.OnNotify("CRD", new Action<Entity>(class2.method_0));
            entity_0.OnNotify("-CRD", new Action<Entity>(class2.method_1));
        }

        /* private scope */internal static bool smethod_206(char char_0)
        {
           return (char_0 <= '\x001f');
        }

        /* private scope */internal static void smethod_207(Parameter parameter_0, Entity entity_0, ServerControll serverControll_0)
        {
            try
            {
                entity_0.SetField("NoRecoil", 0);
                if (ServerControll.bool_4)
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
                for (int i = 0; i < ServerControll.string_73.Length; i++)
                {
                    if (parameter_0.ToString().Contains(ServerControll.string_73[i]))
                    {
                        goto Label_00D4;
                    }
                }
                return;
            Label_00D4:
                entity_0.SetField("NoRecoil", 0x3e7);
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("dictionary."))
                {
                    ServerControll.LogErrori("CambioArma", exception, "---");
                }
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        /* private scope */internal static int smethod_208(LookupService lookupService_0, IPAddress ipaddress_0)
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
                    Console.Write("Error Seeking country while Seeking " + ipaddress_0);
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

        /* private scope */internal static void smethod_209(Entity entity_0, ServerControll serverControll_0, string string_0)
        {
            ServerControll.Class32 class2 = new ServerControll.Class32 {
                hudElem_0 = HudElem.CreateFontString(entity_0, "hudbig", 1f)
            };
            class2.hudElem_0.SetPoint("CENTER", "TOP", 0, 100);
            class2.hudElem_0.Foreground = true;
            class2.hudElem_0.HideWhenInMenu = false;
            class2.hudElem_0.Alpha = 1f;
            class2.hudElem_0.SetText(string_0);
            class2.hudElem_0.Call("setpulsefx", new Parameter[] { 100, 0x1770, 0x3e8 });
            serverControll_0.AfterDelay(0x2710, new Action(class2.method_0));
        }

        /* private scope */internal static void smethod_21(int int_0, ServerControll serverControll_0)
        {
            if (!serverControll_0.SubMenuList.ContainsKey(int_0))
            {
                foreach (HudElem elem in serverControll_0.SubMenuList[int_0])
                {
                    elem.Call("destroy", new Parameter[0]);
                }
            }
        }

        /* private scope */internal static void smethod_210()
        {
            ServerControll.hudElem_0.Call("destroy", new Parameter[0]);
        }

        /* private scope *///internal static unsafe int smethod_211(int int_0, ServerControll serverControll_0 = 1, int int_1 = 0x1000000, byte?[] nullable_0 = 0x3d00000, int int_2)
        internal static unsafe int smethod_211(int int_0, byte?[] nullable_0, int int_1, ServerControll serverControll_0, int int_2)
        {
            try
            {
                int num = 0;
                for (int i = int_2; i < int_1; i++)
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
                Log.Write(InfinityScript.LogLevel.All, "Error in FindMem:" + exception.Message, new object[0]);
            }
            return 0;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        /* private scope */internal static int smethod_212(LookupService lookupService_0, long long_0)
        {
            byte[] buffer = new byte[2 * LookupService.int_8];
            int[] numArray = new int[2];
            int num = 0;
            int num2 = 0x1f;
            while (true)
            {
                if (num2 < 0)
                {
                    Console.Write("Error Seeking country while Seeking " + long_0);
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

        /* private scope */internal static void smethod_213(ServerControll serverControll_0, Entity entity_0)
        {
            if (System.IO.File.Exists(ServerControll.string_88 + ServerControll.string_59))
            {
                string[] strArray = System.IO.File.ReadAllLines(ServerControll.string_88 + ServerControll.string_59);
                System.IO.File.Delete(ServerControll.string_88 + ServerControll.string_59);
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { ServerControll.char_1 });
                    bool flag = true;
                    for (int j = 0; j < 2; j++)
                    {
                        if (strArray2[j].ToLower().StartsWith(serverControll_0.getPlayerCODE(entity_0)))
                        {
                            goto Label_0096;
                        }
                    }
                    goto Label_0099;
                Label_0096:
                    flag = false;
                Label_0099:
                    if (flag)
                    {
                        using (StreamWriter writer = new StreamWriter(ServerControll.string_88 + ServerControll.string_59, true))
                        {
                            writer.WriteLine(strArray[i]);
                            writer.Close();
                        }
                    }
                }
            }
        }

        /* private scope */internal static void smethod_214(Entity entity_0, ServerControll serverControll_0)
        {
            Action<Entity> function = null;
            ServerControll.Class39 class2 = new ServerControll.Class39 {
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
                ServerControll.LogErrori("AntinoNick", exception, "---");
            }
        }

        /* private scope */internal static void smethod_215(ServerControll serverControll_0)
        {
            try
            {
                if (System.IO.File.Exists(ServerControll.string_84 + ServerControll.string_58))
                {
                    ServerControll.int_29 = int.Parse(System.IO.File.ReadAllLines(ServerControll.string_84 + ServerControll.string_58)[0].Split(new char[] { ServerControll.char_3 })[1]);
                }
                else
                {
                    smethod_174(serverControll_0);
                }
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("range."))
                {
                    ServerControll.LogErrori("LoadStatsServer", exception, "---");
                }
                ServerControll.int_29 = 0;
                smethod_174(serverControll_0);
            }
        }

        /* private scope */internal static string smethod_216(ServerControll serverControll_0)
        {
            switch (ServerControll.int_14)
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

        /* private scope */internal static void smethod_217(Entity entity_0, ServerControll serverControll_0)
        {
            if (entity_0.IsAlive)
            {
                if (entity_0.GetField<string>("sessionstate") != "spectator")
                {
                    entity_0.Call("allowspectateteam", new Parameter[] { "freelook", 1 });
                    entity_0.SetField("sessionstate", "spectator");
                    entity_0.Call("setcontents", new Parameter[] { 0 });
                    smethod_158(serverControll_0, entity_0, "^5" + serverControll_0.getPlayerName(entity_0) + " ^7Fly enabled!!!");
                }
                else
                {
                    entity_0.Call("allowspectateteam", new Parameter[] { "freelook", 0 });
                    entity_0.SetField("sessionstate", "playing");
                    entity_0.Call("setcontents", new Parameter[] { 100 });
                    smethod_158(serverControll_0, entity_0, "^1" + serverControll_0.getPlayerName(entity_0) + " ^7Fly disabled!!!");
                }
            }
        }

        /* private scope */internal static void smethod_218(int int_0, ServerControll serverControll_0, Entity entity_0)
        {
            entity_0.SetField("Afk", int_0);
        }

        /* private scope */internal static string smethod_219(ServerControll serverControll_0, string string_0)
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

        /* private scope */internal static void smethod_22(Entity entity_0, Entity entity_1, ServerControll serverControll_0)
        {
            Action<Entity> function = null;
            ServerControll.Class28 class2 = new ServerControll.Class28 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            entity_1.AfterDelay(10, new Action<Entity>(class2.method_0));
            entity_1.AfterDelay(800, new Action<Entity>(class2.method_1));
            entity_1.AfterDelay(0x5dc, new Action<Entity>(class2.method_2));
            entity_1.AfterDelay(0xbb8, new Action<Entity>(class2.method_3));
            entity_1.AfterDelay(0x1194, new Action<Entity>(class2.method_4));
            entity_1.AfterDelay(0x1770, new Action<Entity>(class2.method_5));
            entity_1.AfterDelay(0x1d4c, new Action<Entity>(class2.method_6));
            entity_1.AfterDelay(0x1f40, new Action<Entity>(class2.method_7));
            if (ServerControll.bool_41)
            {
                if (function == null)
                {
                    function = new Action<Entity>(class2.method_8);
                }
                entity_1.AfterDelay(0x2328, function);
            }
            entity_1.AfterDelay(0x2710, new Action<Entity>(class2.method_9));
            if (ServerControll.bool_26 && ServerControll.bool_52)
            {
                entity_1.AfterDelay(0x2af8, new Action<Entity>(class2.method_10));
            }
        }

        /* private scope */internal static void smethod_220(Entity entity_0, ServerControll serverControll_0)
        {
            HudElem[] elemArray = serverControll_0.MenuList[entity_0.Call<int>("getEntityNumber", new Parameter[0])];
            for (int i = 0; i < elemArray.Length; i++)
            {
                elemArray[i].Alpha = 1f;
            }
        }

        /* private scope */internal static void smethod_221(ServerControll serverControll_0)
        {
            try
            {
                ServerControll.bool_51 = true;
                smethod_174(serverControll_0);
                smethod_153(null, serverControll_0);
                if (!ServerControll.bool_48)
                {
                    smethod_191(serverControll_0);
                }
                if ((ServerControll.string_93 == "sd") && (ServerControll.string_100 != "hide"))
                {
                    if ((ServerControll.string_93 == "sd") && ServerControll.bool_45)
                    {
                        smethod_14(serverControll_0);
                    }
                    smethod_83(serverControll_0);
                }
                if (ServerControll.bool_54)
                {
                    serverControll_0.method_28();
                }
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("NotifyPrematchDone", exception, "---");
            }
        }

        /* private scope */internal static void smethod_222(ServerControll serverControll_0)
        {
            Action function = null;
            try
            {
                ServerControll.bool_51 = false;
                smethod_2(serverControll_0);
                ServerControll.hudElem_2.Alpha = 0f;
                ServerControll.hudElem_3.Alpha = 0f;
                ServerControll.hudElem_4.Alpha = 0f;
                ServerControll.hudElem_5.Alpha = 0f;
                ServerControll.hudElem_2.Call("destroy", new Parameter[0]);
                ServerControll.hudElem_3.Call("destroy", new Parameter[0]);
                ServerControll.hudElem_4.Call("destroy", new Parameter[0]);
                ServerControll.hudElem_5.Call("destroy", new Parameter[0]);
                if (function == null)
                {
                    function = new Action(serverControll_0.method_39);
                }
                serverControll_0.AfterDelay(0x1388, function);
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("NotifyGameOver", exception, "---");
            }
        }

        /* private scope */internal static void smethod_223()
        {
            RegionName.hashtable_0 = new Hashtable();
            Hashtable hashtable = new Hashtable {
                { 
                    "02",
                    "Canillo"
                },
                { 
                    "03",
                    "Encamp"
                },
                { 
                    "04",
                    "La Massana"
                },
                { 
                    "05",
                    "Ordino"
                },
                { 
                    "06",
                    "Sant Julia de Loria"
                },
                { 
                    "07",
                    "Andorra la Vella"
                },
                { 
                    "08",
                    "Escaldes-Engordany"
                }
            };
            RegionName.hashtable_0.Add("AD", hashtable);
            Hashtable hashtable2 = new Hashtable {
                { 
                    "01",
                    "Abu Dhabi"
                },
                { 
                    "02",
                    "Ajman"
                },
                { 
                    "03",
                    "Dubai"
                },
                { 
                    "04",
                    "Fujairah"
                },
                { 
                    "05",
                    "Ras Al Khaimah"
                },
                { 
                    "06",
                    "Sharjah"
                },
                { 
                    "07",
                    "Umm Al Quwain"
                }
            };
            RegionName.hashtable_0.Add("AE", hashtable2);
            Hashtable hashtable3 = new Hashtable {
                { 
                    "01",
                    "Badakhshan"
                },
                { 
                    "02",
                    "Badghis"
                },
                { 
                    "03",
                    "Baghlan"
                },
                { 
                    "05",
                    "Bamian"
                },
                { 
                    "06",
                    "Farah"
                },
                { 
                    "07",
                    "Faryab"
                },
                { 
                    "08",
                    "Ghazni"
                },
                { 
                    "09",
                    "Ghowr"
                },
                { 
                    "10",
                    "Helmand"
                },
                { 
                    "11",
                    "Herat"
                },
                { 
                    "13",
                    "Kabol"
                },
                { 
                    "14",
                    "Kapisa"
                },
                { 
                    "17",
                    "Lowgar"
                },
                { 
                    "18",
                    "Nangarhar"
                },
                { 
                    "19",
                    "Nimruz"
                },
                { 
                    "23",
                    "Kandahar"
                },
                { 
                    "24",
                    "Kondoz"
                },
                { 
                    "26",
                    "Takhar"
                },
                { 
                    "27",
                    "Vardak"
                },
                { 
                    "28",
                    "Zabol"
                },
                { 
                    "29",
                    "Paktika"
                },
                { 
                    "30",
                    "Balkh"
                },
                { 
                    "31",
                    "Jowzjan"
                },
                { 
                    "32",
                    "Samangan"
                },
                { 
                    "33",
                    "Sar-e Pol"
                },
                { 
                    "34",
                    "Konar"
                },
                { 
                    "35",
                    "Laghman"
                },
                { 
                    "36",
                    "Paktia"
                },
                { 
                    "37",
                    "Khowst"
                },
                { 
                    "38",
                    "Nurestan"
                },
                { 
                    "39",
                    "Oruzgan"
                },
                { 
                    "40",
                    "Parvan"
                },
                { 
                    "41",
                    "Daykondi"
                },
                { 
                    "42",
                    "Panjshir"
                }
            };
            RegionName.hashtable_0.Add("AF", hashtable3);
            Hashtable hashtable4 = new Hashtable {
                { 
                    "01",
                    "Barbuda"
                },
                { 
                    "03",
                    "Saint George"
                },
                { 
                    "04",
                    "Saint John"
                },
                { 
                    "05",
                    "Saint Mary"
                },
                { 
                    "06",
                    "Saint Paul"
                },
                { 
                    "07",
                    "Saint Peter"
                },
                { 
                    "08",
                    "Saint Philip"
                },
                { 
                    "09",
                    "Redonda"
                }
            };
            RegionName.hashtable_0.Add("AG", hashtable4);
            Hashtable hashtable5 = new Hashtable {
                { 
                    "40",
                    "Berat"
                },
                { 
                    "41",
                    "Diber"
                },
                { 
                    "42",
                    "Durres"
                },
                { 
                    "43",
                    "Elbasan"
                },
                { 
                    "44",
                    "Fier"
                },
                { 
                    "45",
                    "Gjirokaster"
                },
                { 
                    "46",
                    "Korce"
                },
                { 
                    "47",
                    "Kukes"
                },
                { 
                    "48",
                    "Lezhe"
                },
                { 
                    "49",
                    "Shkoder"
                },
                { 
                    "50",
                    "Tirane"
                },
                { 
                    "51",
                    "Vlore"
                }
            };
            RegionName.hashtable_0.Add("AL", hashtable5);
            Hashtable hashtable6 = new Hashtable {
                { 
                    "01",
                    "Aragatsotn"
                },
                { 
                    "02",
                    "Ararat"
                },
                { 
                    "03",
                    "Armavir"
                },
                { 
                    "04",
                    "Geghark'unik'"
                },
                { 
                    "05",
                    "Kotayk'"
                },
                { 
                    "06",
                    "Lorri"
                },
                { 
                    "07",
                    "Shirak"
                },
                { 
                    "08",
                    "Syunik'"
                },
                { 
                    "09",
                    "Tavush"
                },
                { 
                    "10",
                    "Vayots' Dzor"
                },
                { 
                    "11",
                    "Yerevan"
                }
            };
            RegionName.hashtable_0.Add("AM", hashtable6);
            Hashtable hashtable7 = new Hashtable {
                { 
                    "01",
                    "Benguela"
                },
                { 
                    "02",
                    "Bie"
                },
                { 
                    "03",
                    "Cabinda"
                },
                { 
                    "04",
                    "Cuando Cubango"
                },
                { 
                    "05",
                    "Cuanza Norte"
                },
                { 
                    "06",
                    "Cuanza Sul"
                },
                { 
                    "07",
                    "Cunene"
                },
                { 
                    "08",
                    "Huambo"
                },
                { 
                    "09",
                    "Huila"
                },
                { 
                    "12",
                    "Malanje"
                },
                { 
                    "13",
                    "Namibe"
                },
                { 
                    "14",
                    "Moxico"
                },
                { 
                    "15",
                    "Uige"
                },
                { 
                    "16",
                    "Zaire"
                },
                { 
                    "17",
                    "Lunda Norte"
                },
                { 
                    "18",
                    "Lunda Sul"
                },
                { 
                    "19",
                    "Bengo"
                },
                { 
                    "20",
                    "Luanda"
                }
            };
            RegionName.hashtable_0.Add("AO", hashtable7);
            Hashtable hashtable8 = new Hashtable {
                { 
                    "01",
                    "Buenos Aires"
                },
                { 
                    "02",
                    "Catamarca"
                },
                { 
                    "03",
                    "Chaco"
                },
                { 
                    "04",
                    "Chubut"
                },
                { 
                    "05",
                    "Cordoba"
                },
                { 
                    "06",
                    "Corrientes"
                },
                { 
                    "07",
                    "Distrito Federal"
                },
                { 
                    "08",
                    "Entre Rios"
                },
                { 
                    "09",
                    "Formosa"
                },
                { 
                    "10",
                    "Jujuy"
                },
                { 
                    "11",
                    "La Pampa"
                },
                { 
                    "12",
                    "La Rioja"
                },
                { 
                    "13",
                    "Mendoza"
                },
                { 
                    "14",
                    "Misiones"
                },
                { 
                    "15",
                    "Neuquen"
                },
                { 
                    "16",
                    "Rio Negro"
                },
                { 
                    "17",
                    "Salta"
                },
                { 
                    "18",
                    "San Juan"
                },
                { 
                    "19",
                    "San Luis"
                },
                { 
                    "20",
                    "Santa Cruz"
                },
                { 
                    "21",
                    "Santa Fe"
                },
                { 
                    "22",
                    "Santiago del Estero"
                },
                { 
                    "23",
                    "Tierra del Fuego"
                },
                { 
                    "24",
                    "Tucuman"
                }
            };
            RegionName.hashtable_0.Add("AR", hashtable8);
            Hashtable hashtable9 = new Hashtable {
                { 
                    "01",
                    "Burgenland"
                },
                { 
                    "02",
                    "Karnten"
                },
                { 
                    "03",
                    "Niederosterreich"
                },
                { 
                    "04",
                    "Oberosterreich"
                },
                { 
                    "05",
                    "Salzburg"
                },
                { 
                    "06",
                    "Steiermark"
                },
                { 
                    "07",
                    "Tirol"
                },
                { 
                    "08",
                    "Vorarlberg"
                },
                { 
                    "09",
                    "Wien"
                }
            };
            RegionName.hashtable_0.Add("AT", hashtable9);
            Hashtable hashtable10 = new Hashtable {
                { 
                    "01",
                    "Australian Capital Territory"
                },
                { 
                    "02",
                    "New South Wales"
                },
                { 
                    "03",
                    "Northern Territory"
                },
                { 
                    "04",
                    "Queensland"
                },
                { 
                    "05",
                    "South Australia"
                },
                { 
                    "06",
                    "Tasmania"
                },
                { 
                    "07",
                    "Victoria"
                },
                { 
                    "08",
                    "Western Australia"
                }
            };
            RegionName.hashtable_0.Add("AU", hashtable10);
            Hashtable hashtable11 = new Hashtable {
                { 
                    "01",
                    "Abseron"
                },
                { 
                    "02",
                    "Agcabadi"
                },
                { 
                    "03",
                    "Agdam"
                },
                { 
                    "04",
                    "Agdas"
                },
                { 
                    "05",
                    "Agstafa"
                },
                { 
                    "06",
                    "Agsu"
                },
                { 
                    "07",
                    "Ali Bayramli"
                },
                { 
                    "08",
                    "Astara"
                },
                { 
                    "09",
                    "Baki"
                },
                { 
                    "10",
                    "Balakan"
                },
                { 
                    "11",
                    "Barda"
                },
                { 
                    "12",
                    "Beylaqan"
                },
                { 
                    "13",
                    "Bilasuvar"
                },
                { 
                    "14",
                    "Cabrayil"
                },
                { 
                    "15",
                    "Calilabad"
                },
                { 
                    "16",
                    "Daskasan"
                },
                { 
                    "17",
                    "Davaci"
                },
                { 
                    "18",
                    "Fuzuli"
                },
                { 
                    "19",
                    "Gadabay"
                },
                { 
                    "20",
                    "Ganca"
                },
                { 
                    "21",
                    "Goranboy"
                },
                { 
                    "22",
                    "Goycay"
                },
                { 
                    "23",
                    "Haciqabul"
                },
                { 
                    "24",
                    "Imisli"
                },
                { 
                    "25",
                    "Ismayilli"
                },
                { 
                    "26",
                    "Kalbacar"
                },
                { 
                    "27",
                    "Kurdamir"
                },
                { 
                    "28",
                    "Lacin"
                },
                { 
                    "29",
                    "Lankaran"
                },
                { 
                    "30",
                    "Lankaran"
                },
                { 
                    "31",
                    "Lerik"
                },
                { 
                    "32",
                    "Masalli"
                },
                { 
                    "33",
                    "Mingacevir"
                },
                { 
                    "34",
                    "Naftalan"
                },
                { 
                    "35",
                    "Naxcivan"
                },
                { 
                    "36",
                    "Neftcala"
                },
                { 
                    "37",
                    "Oguz"
                },
                { 
                    "38",
                    "Qabala"
                },
                { 
                    "39",
                    "Qax"
                },
                { 
                    "40",
                    "Qazax"
                },
                { 
                    "41",
                    "Qobustan"
                },
                { 
                    "42",
                    "Quba"
                },
                { 
                    "43",
                    "Qubadli"
                },
                { 
                    "44",
                    "Qusar"
                },
                { 
                    "45",
                    "Saatli"
                },
                { 
                    "46",
                    "Sabirabad"
                },
                { 
                    "47",
                    "Saki"
                },
                { 
                    "48",
                    "Saki"
                },
                { 
                    "49",
                    "Salyan"
                },
                { 
                    "50",
                    "Samaxi"
                },
                { 
                    "51",
                    "Samkir"
                },
                { 
                    "52",
                    "Samux"
                },
                { 
                    "53",
                    "Siyazan"
                },
                { 
                    "54",
                    "Sumqayit"
                },
                { 
                    "55",
                    "Susa"
                },
                { 
                    "56",
                    "Susa"
                },
                { 
                    "57",
                    "Tartar"
                },
                { 
                    "58",
                    "Tovuz"
                },
                { 
                    "59",
                    "Ucar"
                },
                { 
                    "60",
                    "Xacmaz"
                },
                { 
                    "61",
                    "Xankandi"
                },
                { 
                    "62",
                    "Xanlar"
                },
                { 
                    "63",
                    "Xizi"
                },
                { 
                    "64",
                    "Xocali"
                },
                { 
                    "65",
                    "Xocavand"
                },
                { 
                    "66",
                    "Yardimli"
                },
                { 
                    "67",
                    "Yevlax"
                },
                { 
                    "68",
                    "Yevlax"
                },
                { 
                    "69",
                    "Zangilan"
                },
                { 
                    "70",
                    "Zaqatala"
                },
                { 
                    "71",
                    "Zardab"
                }
            };
            RegionName.hashtable_0.Add("AZ", hashtable11);
            Hashtable hashtable12 = new Hashtable {
                { 
                    "01",
                    "Federation of Bosnia and Herzegovina"
                },
                { 
                    "02",
                    "Republika Srpska"
                }
            };
            RegionName.hashtable_0.Add("BA", hashtable12);
            Hashtable hashtable13 = new Hashtable {
                { 
                    "01",
                    "Christ Church"
                },
                { 
                    "02",
                    "Saint Andrew"
                },
                { 
                    "03",
                    "Saint George"
                },
                { 
                    "04",
                    "Saint James"
                },
                { 
                    "05",
                    "Saint John"
                },
                { 
                    "06",
                    "Saint Joseph"
                },
                { 
                    "07",
                    "Saint Lucy"
                },
                { 
                    "08",
                    "Saint Michael"
                },
                { 
                    "09",
                    "Saint Peter"
                },
                { 
                    "10",
                    "Saint Philip"
                },
                { 
                    "11",
                    "Saint Thomas"
                }
            };
            RegionName.hashtable_0.Add("BB", hashtable13);
            Hashtable hashtable14 = new Hashtable {
                { 
                    "81",
                    "Dhaka"
                },
                { 
                    "82",
                    "Khulna"
                },
                { 
                    "83",
                    "Rajshahi"
                },
                { 
                    "84",
                    "Chittagong"
                },
                { 
                    "85",
                    "Barisal"
                },
                { 
                    "86",
                    "Sylhet"
                }
            };
            RegionName.hashtable_0.Add("BD", hashtable14);
            Hashtable hashtable15 = new Hashtable {
                { 
                    "01",
                    "Antwerpen"
                },
                { 
                    "03",
                    "Hainaut"
                },
                { 
                    "04",
                    "Liege"
                },
                { 
                    "05",
                    "Limburg"
                },
                { 
                    "06",
                    "Luxembourg"
                },
                { 
                    "07",
                    "Namur"
                },
                { 
                    "08",
                    "Oost-Vlaanderen"
                },
                { 
                    "09",
                    "West-Vlaanderen"
                },
                { 
                    "10",
                    "Brabant Wallon"
                },
                { 
                    "11",
                    "Brussels Hoofdstedelijk Gewest"
                },
                { 
                    "12",
                    "Vlaams-Brabant"
                },
                { 
                    "13",
                    "Flanders"
                },
                { 
                    "14",
                    "Wallonia"
                }
            };
            RegionName.hashtable_0.Add("BE", hashtable15);
            Hashtable hashtable16 = new Hashtable {
                { 
                    "15",
                    "Bam"
                },
                { 
                    "19",
                    "Boulkiemde"
                },
                { 
                    "20",
                    "Ganzourgou"
                },
                { 
                    "21",
                    "Gnagna"
                },
                { 
                    "28",
                    "Kouritenga"
                },
                { 
                    "33",
                    "Oudalan"
                },
                { 
                    "34",
                    "Passore"
                },
                { 
                    "36",
                    "Sanguie"
                },
                { 
                    "40",
                    "Soum"
                },
                { 
                    "42",
                    "Tapoa"
                },
                { 
                    "44",
                    "Zoundweogo"
                },
                { 
                    "45",
                    "Bale"
                },
                { 
                    "46",
                    "Banwa"
                },
                { 
                    "47",
                    "Bazega"
                },
                { 
                    "48",
                    "Bougouriba"
                },
                { 
                    "49",
                    "Boulgou"
                },
                { 
                    "50",
                    "Gourma"
                },
                { 
                    "51",
                    "Houet"
                },
                { 
                    "52",
                    "Ioba"
                },
                { 
                    "53",
                    "Kadiogo"
                },
                { 
                    "54",
                    "Kenedougou"
                },
                { 
                    "55",
                    "Komoe"
                },
                { 
                    "56",
                    "Komondjari"
                },
                { 
                    "57",
                    "Kompienga"
                },
                { 
                    "58",
                    "Kossi"
                },
                { 
                    "59",
                    "Koulpelogo"
                },
                { 
                    "60",
                    "Kourweogo"
                },
                { 
                    "61",
                    "Leraba"
                },
                { 
                    "62",
                    "Loroum"
                },
                { 
                    "63",
                    "Mouhoun"
                },
                { 
                    "64",
                    "Namentenga"
                },
                { 
                    "65",
                    "Naouri"
                },
                { 
                    "66",
                    "Nayala"
                },
                { 
                    "67",
                    "Noumbiel"
                },
                { 
                    "68",
                    "Oubritenga"
                },
                { 
                    "69",
                    "Poni"
                },
                { 
                    "70",
                    "Sanmatenga"
                },
                { 
                    "71",
                    "Seno"
                },
                { 
                    "72",
                    "Sissili"
                },
                { 
                    "73",
                    "Sourou"
                },
                { 
                    "74",
                    "Tuy"
                },
                { 
                    "75",
                    "Yagha"
                },
                { 
                    "76",
                    "Yatenga"
                },
                { 
                    "77",
                    "Ziro"
                },
                { 
                    "78",
                    "Zondoma"
                }
            };
            RegionName.hashtable_0.Add("BF", hashtable16);
            Hashtable hashtable17 = new Hashtable {
                { 
                    "33",
                    "Mikhaylovgrad"
                },
                { 
                    "38",
                    "Blagoevgrad"
                },
                { 
                    "39",
                    "Burgas"
                },
                { 
                    "40",
                    "Dobrich"
                },
                { 
                    "41",
                    "Gabrovo"
                },
                { 
                    "42",
                    "Grad Sofiya"
                },
                { 
                    "43",
                    "Khaskovo"
                },
                { 
                    "44",
                    "Kurdzhali"
                },
                { 
                    "45",
                    "Kyustendil"
                },
                { 
                    "46",
                    "Lovech"
                },
                { 
                    "47",
                    "Montana"
                },
                { 
                    "48",
                    "Pazardzhik"
                },
                { 
                    "49",
                    "Pernik"
                },
                { 
                    "50",
                    "Pleven"
                },
                { 
                    "51",
                    "Plovdiv"
                },
                { 
                    "52",
                    "Razgrad"
                },
                { 
                    "53",
                    "Ruse"
                },
                { 
                    "54",
                    "Shumen"
                },
                { 
                    "55",
                    "Silistra"
                },
                { 
                    "56",
                    "Sliven"
                },
                { 
                    "57",
                    "Smolyan"
                },
                { 
                    "58",
                    "Sofiya"
                },
                { 
                    "59",
                    "Stara Zagora"
                },
                { 
                    "60",
                    "Turgovishte"
                },
                { 
                    "61",
                    "Varna"
                },
                { 
                    "62",
                    "Veliko Turnovo"
                },
                { 
                    "63",
                    "Vidin"
                },
                { 
                    "64",
                    "Vratsa"
                },
                { 
                    "65",
                    "Yambol"
                }
            };
            RegionName.hashtable_0.Add("BG", hashtable17);
            Hashtable hashtable18 = new Hashtable {
                { 
                    "01",
                    "Al Hadd"
                },
                { 
                    "02",
                    "Al Manamah"
                },
                { 
                    "05",
                    "Jidd Hafs"
                },
                { 
                    "06",
                    "Sitrah"
                },
                { 
                    "08",
                    "Al Mintaqah al Gharbiyah"
                },
                { 
                    "09",
                    "Mintaqat Juzur Hawar"
                },
                { 
                    "10",
                    "Al Mintaqah ash Shamaliyah"
                },
                { 
                    "11",
                    "Al Mintaqah al Wusta"
                },
                { 
                    "12",
                    "Madinat"
                },
                { 
                    "13",
                    "Ar Rifa"
                },
                { 
                    "14",
                    "Madinat Hamad"
                },
                { 
                    "15",
                    "Al Muharraq"
                },
                { 
                    "16",
                    "Al Asimah"
                },
                { 
                    "17",
                    "Al Janubiyah"
                },
                { 
                    "18",
                    "Ash Shamaliyah"
                },
                { 
                    "19",
                    "Al Wusta"
                }
            };
            RegionName.hashtable_0.Add("BH", hashtable18);
            Hashtable hashtable19 = new Hashtable {
                { 
                    "02",
                    "Bujumbura"
                },
                { 
                    "09",
                    "Bubanza"
                },
                { 
                    "10",
                    "Bururi"
                },
                { 
                    "11",
                    "Cankuzo"
                },
                { 
                    "12",
                    "Cibitoke"
                },
                { 
                    "13",
                    "Gitega"
                },
                { 
                    "14",
                    "Karuzi"
                },
                { 
                    "15",
                    "Kayanza"
                },
                { 
                    "16",
                    "Kirundo"
                },
                { 
                    "17",
                    "Makamba"
                },
                { 
                    "18",
                    "Muyinga"
                },
                { 
                    "19",
                    "Ngozi"
                },
                { 
                    "20",
                    "Rutana"
                },
                { 
                    "21",
                    "Ruyigi"
                },
                { 
                    "22",
                    "Muramvya"
                },
                { 
                    "23",
                    "Mwaro"
                }
            };
            RegionName.hashtable_0.Add("BI", hashtable19);
            Hashtable hashtable20 = new Hashtable {
                { 
                    "07",
                    "Alibori"
                },
                { 
                    "08",
                    "Atakora"
                },
                { 
                    "09",
                    "Atlanyique"
                },
                { 
                    "10",
                    "Borgou"
                },
                { 
                    "11",
                    "Collines"
                },
                { 
                    "12",
                    "Kouffo"
                },
                { 
                    "13",
                    "Donga"
                },
                { 
                    "14",
                    "Littoral"
                },
                { 
                    "15",
                    "Mono"
                },
                { 
                    "16",
                    "Oueme"
                },
                { 
                    "17",
                    "Plateau"
                },
                { 
                    "18",
                    "Zou"
                }
            };
            RegionName.hashtable_0.Add("BJ", hashtable20);
            Hashtable hashtable21 = new Hashtable {
                { 
                    "01",
                    "Devonshire"
                },
                { 
                    "02",
                    "Hamilton"
                },
                { 
                    "03",
                    "Hamilton"
                },
                { 
                    "04",
                    "Paget"
                },
                { 
                    "05",
                    "Pembroke"
                },
                { 
                    "06",
                    "Saint George"
                },
                { 
                    "07",
                    "Saint George's"
                },
                { 
                    "08",
                    "Sandys"
                },
                { 
                    "09",
                    "Smiths"
                },
                { 
                    "10",
                    "Southampton"
                },
                { 
                    "11",
                    "Warwick"
                }
            };
            RegionName.hashtable_0.Add("BM", hashtable21);
            Hashtable hashtable22 = new Hashtable {
                { 
                    "07",
                    "Alibori"
                },
                { 
                    "08",
                    "Belait"
                },
                { 
                    "09",
                    "Brunei and Muara"
                },
                { 
                    "10",
                    "Temburong"
                },
                { 
                    "11",
                    "Collines"
                },
                { 
                    "12",
                    "Kouffo"
                },
                { 
                    "13",
                    "Donga"
                },
                { 
                    "14",
                    "Littoral"
                },
                { 
                    "15",
                    "Tutong"
                },
                { 
                    "16",
                    "Oueme"
                },
                { 
                    "17",
                    "Plateau"
                },
                { 
                    "18",
                    "Zou"
                }
            };
            RegionName.hashtable_0.Add("BN", hashtable22);
            Hashtable hashtable23 = new Hashtable {
                { 
                    "01",
                    "Chuquisaca"
                },
                { 
                    "02",
                    "Cochabamba"
                },
                { 
                    "03",
                    "El Beni"
                },
                { 
                    "04",
                    "La Paz"
                },
                { 
                    "05",
                    "Oruro"
                },
                { 
                    "06",
                    "Pando"
                },
                { 
                    "07",
                    "Potosi"
                },
                { 
                    "08",
                    "Santa Cruz"
                },
                { 
                    "09",
                    "Tarija"
                }
            };
            RegionName.hashtable_0.Add("BO", hashtable23);
            Hashtable hashtable24 = new Hashtable {
                { 
                    "01",
                    "Acre"
                },
                { 
                    "02",
                    "Alagoas"
                },
                { 
                    "03",
                    "Amapa"
                },
                { 
                    "04",
                    "Amazonas"
                },
                { 
                    "05",
                    "Bahia"
                },
                { 
                    "06",
                    "Ceara"
                },
                { 
                    "07",
                    "Distrito Federal"
                },
                { 
                    "08",
                    "Espirito Santo"
                },
                { 
                    "11",
                    "Mato Grosso do Sul"
                },
                { 
                    "13",
                    "Maranhao"
                },
                { 
                    "14",
                    "Mato Grosso"
                },
                { 
                    "15",
                    "Minas Gerais"
                },
                { 
                    "16",
                    "Para"
                },
                { 
                    "17",
                    "Paraiba"
                },
                { 
                    "18",
                    "Parana"
                },
                { 
                    "20",
                    "Piaui"
                },
                { 
                    "21",
                    "Rio de Janeiro"
                },
                { 
                    "22",
                    "Rio Grande do Norte"
                },
                { 
                    "23",
                    "Rio Grande do Sul"
                },
                { 
                    "24",
                    "Rondonia"
                },
                { 
                    "25",
                    "Roraima"
                },
                { 
                    "26",
                    "Santa Catarina"
                },
                { 
                    "27",
                    "Sao Paulo"
                },
                { 
                    "28",
                    "Sergipe"
                },
                { 
                    "29",
                    "Goias"
                },
                { 
                    "30",
                    "Pernambuco"
                },
                { 
                    "31",
                    "Tocantins"
                }
            };
            RegionName.hashtable_0.Add("BR", hashtable24);
            Hashtable hashtable25 = new Hashtable {
                { 
                    "05",
                    "Bimini"
                },
                { 
                    "06",
                    "Cat Island"
                },
                { 
                    "10",
                    "Exuma"
                },
                { 
                    "13",
                    "Inagua"
                },
                { 
                    "15",
                    "Long Island"
                },
                { 
                    "16",
                    "Mayaguana"
                },
                { 
                    "18",
                    "Ragged Island"
                },
                { 
                    "22",
                    "Harbour Island"
                },
                { 
                    "23",
                    "New Providence"
                },
                { 
                    "24",
                    "Acklins and Crooked Islands"
                },
                { 
                    "25",
                    "Freeport"
                },
                { 
                    "26",
                    "Fresh Creek"
                },
                { 
                    "27",
                    "Governor's Harbour"
                },
                { 
                    "28",
                    "Green Turtle Cay"
                },
                { 
                    "29",
                    "High Rock"
                },
                { 
                    "30",
                    "Kemps Bay"
                },
                { 
                    "31",
                    "Marsh Harbour"
                },
                { 
                    "32",
                    "Nichollstown and Berry Islands"
                },
                { 
                    "33",
                    "Rock Sound"
                },
                { 
                    "34",
                    "Sandy Point"
                },
                { 
                    "35",
                    "San Salvador and Rum Cay"
                }
            };
            RegionName.hashtable_0.Add("BS", hashtable25);
            Hashtable hashtable26 = new Hashtable {
                { 
                    "05",
                    "Bumthang"
                },
                { 
                    "06",
                    "Chhukha"
                },
                { 
                    "07",
                    "Chirang"
                },
                { 
                    "08",
                    "Daga"
                },
                { 
                    "09",
                    "Geylegphug"
                },
                { 
                    "10",
                    "Ha"
                },
                { 
                    "11",
                    "Lhuntshi"
                },
                { 
                    "12",
                    "Mongar"
                },
                { 
                    "13",
                    "Paro"
                },
                { 
                    "14",
                    "Pemagatsel"
                },
                { 
                    "15",
                    "Punakha"
                },
                { 
                    "16",
                    "Samchi"
                },
                { 
                    "17",
                    "Samdrup"
                },
                { 
                    "18",
                    "Shemgang"
                },
                { 
                    "19",
                    "Tashigang"
                },
                { 
                    "20",
                    "Thimphu"
                },
                { 
                    "21",
                    "Tongsa"
                },
                { 
                    "22",
                    "Wangdi Phodrang"
                }
            };
            RegionName.hashtable_0.Add("BT", hashtable26);
            Hashtable hashtable27 = new Hashtable {
                { 
                    "01",
                    "Central"
                },
                { 
                    "03",
                    "Ghanzi"
                },
                { 
                    "04",
                    "Kgalagadi"
                },
                { 
                    "05",
                    "Kgatleng"
                },
                { 
                    "06",
                    "Kweneng"
                },
                { 
                    "08",
                    "North-East"
                },
                { 
                    "09",
                    "South-East"
                },
                { 
                    "10",
                    "Southern"
                },
                { 
                    "11",
                    "North-West"
                }
            };
            RegionName.hashtable_0.Add("BW", hashtable27);
            Hashtable hashtable28 = new Hashtable {
                { 
                    "01",
                    "Brestskaya Voblasts'"
                },
                { 
                    "02",
                    "Homyel'skaya Voblasts'"
                },
                { 
                    "03",
                    "Hrodzyenskaya Voblasts'"
                },
                { 
                    "04",
                    "Minsk"
                },
                { 
                    "05",
                    "Minskaya Voblasts'"
                },
                { 
                    "06",
                    "Mahilyowskaya Voblasts'"
                },
                { 
                    "07",
                    "Vitsyebskaya Voblasts'"
                }
            };
            RegionName.hashtable_0.Add("BY", hashtable28);
            Hashtable hashtable29 = new Hashtable {
                { 
                    "01",
                    "Belize"
                },
                { 
                    "02",
                    "Cayo"
                },
                { 
                    "03",
                    "Corozal"
                },
                { 
                    "04",
                    "Orange Walk"
                },
                { 
                    "05",
                    "Stann Creek"
                },
                { 
                    "06",
                    "Toledo"
                }
            };
            RegionName.hashtable_0.Add("BZ", hashtable29);
            Hashtable hashtable30 = new Hashtable {
                { 
                    "AB",
                    "Alberta"
                },
                { 
                    "BC",
                    "British Columbia"
                },
                { 
                    "MB",
                    "Manitoba"
                },
                { 
                    "NB",
                    "New Brunswick"
                },
                { 
                    "NL",
                    "Newfoundland"
                },
                { 
                    "NS",
                    "Nova Scotia"
                },
                { 
                    "NT",
                    "Northwest Territories"
                },
                { 
                    "NU",
                    "Nunavut"
                },
                { 
                    "ON",
                    "Ontario"
                },
                { 
                    "PE",
                    "Prince Edward Island"
                },
                { 
                    "QC",
                    "Quebec"
                },
                { 
                    "SK",
                    "Saskatchewan"
                },
                { 
                    "YT",
                    "Yukon Territory"
                }
            };
            RegionName.hashtable_0.Add("CA", hashtable30);
            Hashtable hashtable31 = new Hashtable {
                { 
                    "01",
                    "Bandundu"
                },
                { 
                    "02",
                    "Equateur"
                },
                { 
                    "04",
                    "Kasai-Oriental"
                },
                { 
                    "05",
                    "Katanga"
                },
                { 
                    "06",
                    "Kinshasa"
                },
                { 
                    "08",
                    "Bas-Congo"
                },
                { 
                    "09",
                    "Orientale"
                },
                { 
                    "10",
                    "Maniema"
                },
                { 
                    "11",
                    "Nord-Kivu"
                },
                { 
                    "12",
                    "Sud-Kivu"
                }
            };
            RegionName.hashtable_0.Add("CD", hashtable31);
            Hashtable hashtable32 = new Hashtable {
                { 
                    "01",
                    "Bamingui-Bangoran"
                },
                { 
                    "02",
                    "Basse-Kotto"
                },
                { 
                    "03",
                    "Haute-Kotto"
                },
                { 
                    "04",
                    "Mambere-Kadei"
                },
                { 
                    "05",
                    "Haut-Mbomou"
                },
                { 
                    "06",
                    "Kemo"
                },
                { 
                    "07",
                    "Lobaye"
                },
                { 
                    "08",
                    "Mbomou"
                },
                { 
                    "09",
                    "Nana-Mambere"
                },
                { 
                    "11",
                    "Ouaka"
                },
                { 
                    "12",
                    "Ouham"
                },
                { 
                    "13",
                    "Ouham-Pende"
                },
                { 
                    "14",
                    "Cuvette-Ouest"
                },
                { 
                    "15",
                    "Nana-Grebizi"
                },
                { 
                    "16",
                    "Sangha-Mbaere"
                },
                { 
                    "17",
                    "Ombella-Mpoko"
                },
                { 
                    "18",
                    "Bangui"
                }
            };
            RegionName.hashtable_0.Add("CF", hashtable32);
            Hashtable hashtable33 = new Hashtable {
                { 
                    "01",
                    "Bouenza"
                },
                { 
                    "04",
                    "Kouilou"
                },
                { 
                    "05",
                    "Lekoumou"
                },
                { 
                    "06",
                    "Likouala"
                },
                { 
                    "07",
                    "Niari"
                },
                { 
                    "08",
                    "Plateaux"
                },
                { 
                    "10",
                    "Sangha"
                },
                { 
                    "11",
                    "Pool"
                },
                { 
                    "12",
                    "Brazzaville"
                },
                { 
                    "13",
                    "Cuvette"
                },
                { 
                    "14",
                    "Cuvette-Ouest"
                }
            };
            RegionName.hashtable_0.Add("CG", hashtable33);
            Hashtable hashtable34 = new Hashtable {
                { 
                    "01",
                    "Aargau"
                },
                { 
                    "02",
                    "Ausser-Rhoden"
                },
                { 
                    "03",
                    "Basel-Landschaft"
                },
                { 
                    "04",
                    "Basel-Stadt"
                },
                { 
                    "05",
                    "Bern"
                },
                { 
                    "06",
                    "Fribourg"
                },
                { 
                    "07",
                    "Geneve"
                },
                { 
                    "08",
                    "Glarus"
                },
                { 
                    "09",
                    "Graubunden"
                },
                { 
                    "10",
                    "Inner-Rhoden"
                },
                { 
                    "11",
                    "Luzern"
                },
                { 
                    "12",
                    "Neuchatel"
                },
                { 
                    "13",
                    "Nidwalden"
                },
                { 
                    "14",
                    "Obwalden"
                },
                { 
                    "15",
                    "Sankt Gallen"
                },
                { 
                    "16",
                    "Schaffhausen"
                },
                { 
                    "17",
                    "Schwyz"
                },
                { 
                    "18",
                    "Solothurn"
                },
                { 
                    "19",
                    "Thurgau"
                },
                { 
                    "20",
                    "Ticino"
                },
                { 
                    "21",
                    "Uri"
                },
                { 
                    "22",
                    "Valais"
                },
                { 
                    "23",
                    "Vaud"
                },
                { 
                    "24",
                    "Zug"
                },
                { 
                    "25",
                    "Zurich"
                },
                { 
                    "26",
                    "Jura"
                }
            };
            RegionName.hashtable_0.Add("CH", hashtable34);
            Hashtable hashtable35 = new Hashtable {
                { 
                    "74",
                    "Agneby"
                },
                { 
                    "75",
                    "Bafing"
                },
                { 
                    "76",
                    "Bas-Sassandra"
                },
                { 
                    "77",
                    "Denguele"
                },
                { 
                    "78",
                    "Dix-Huit Montagnes"
                },
                { 
                    "79",
                    "Fromager"
                },
                { 
                    "80",
                    "Haut-Sassandra"
                },
                { 
                    "81",
                    "Lacs"
                },
                { 
                    "82",
                    "Lagunes"
                },
                { 
                    "83",
                    "Marahoue"
                },
                { 
                    "84",
                    "Moyen-Cavally"
                },
                { 
                    "85",
                    "Moyen-Comoe"
                },
                { 
                    "86",
                    "N'zi-Comoe"
                },
                { 
                    "87",
                    "Savanes"
                },
                { 
                    "88",
                    "Sud-Bandama"
                },
                { 
                    "89",
                    "Sud-Comoe"
                },
                { 
                    "90",
                    "Vallee du Bandama"
                },
                { 
                    "91",
                    "Worodougou"
                },
                { 
                    "92",
                    "Zanzan"
                }
            };
            RegionName.hashtable_0.Add("CI", hashtable35);
            Hashtable hashtable36 = new Hashtable {
                { 
                    "01",
                    "Valparaiso"
                },
                { 
                    "02",
                    "Aisen del General Carlos Ibanez del Campo"
                },
                { 
                    "03",
                    "Antofagasta"
                },
                { 
                    "04",
                    "Araucania"
                },
                { 
                    "05",
                    "Atacama"
                },
                { 
                    "06",
                    "Bio-Bio"
                },
                { 
                    "07",
                    "Coquimbo"
                },
                { 
                    "08",
                    "Libertador General Bernardo O'Higgins"
                },
                { 
                    "09",
                    "Los Lagos"
                },
                { 
                    "10",
                    "Magallanes y de la Antartica Chilena"
                },
                { 
                    "11",
                    "Maule"
                },
                { 
                    "12",
                    "Region Metropolitana"
                },
                { 
                    "13",
                    "Tarapaca"
                },
                { 
                    "14",
                    "Los Lagos"
                },
                { 
                    "15",
                    "Tarapaca"
                },
                { 
                    "16",
                    "Arica y Parinacota"
                },
                { 
                    "17",
                    "Los Rios"
                }
            };
            RegionName.hashtable_0.Add("CL", hashtable36);
            Hashtable hashtable37 = new Hashtable {
                { 
                    "04",
                    "Est"
                },
                { 
                    "05",
                    "Littoral"
                },
                { 
                    "07",
                    "Nord-Ouest"
                },
                { 
                    "08",
                    "Ouest"
                },
                { 
                    "09",
                    "Sud-Ouest"
                },
                { 
                    "10",
                    "Adamaoua"
                },
                { 
                    "11",
                    "Centre"
                },
                { 
                    "12",
                    "Extreme-Nord"
                },
                { 
                    "13",
                    "Nord"
                },
                { 
                    "14",
                    "Sud"
                }
            };
            RegionName.hashtable_0.Add("CM", hashtable37);
            Hashtable hashtable38 = new Hashtable {
                { 
                    "01",
                    "Anhui"
                },
                { 
                    "02",
                    "Zhejiang"
                },
                { 
                    "03",
                    "Jiangxi"
                },
                { 
                    "04",
                    "Jiangsu"
                },
                { 
                    "05",
                    "Jilin"
                },
                { 
                    "06",
                    "Qinghai"
                },
                { 
                    "07",
                    "Fujian"
                },
                { 
                    "08",
                    "Heilongjiang"
                },
                { 
                    "09",
                    "Henan"
                },
                { 
                    "10",
                    "Hebei"
                },
                { 
                    "11",
                    "Hunan"
                },
                { 
                    "12",
                    "Hubei"
                },
                { 
                    "13",
                    "Xinjiang"
                },
                { 
                    "14",
                    "Xizang"
                },
                { 
                    "15",
                    "Gansu"
                },
                { 
                    "16",
                    "Guangxi"
                },
                { 
                    "18",
                    "Guizhou"
                },
                { 
                    "19",
                    "Liaoning"
                },
                { 
                    "20",
                    "Nei Mongol"
                },
                { 
                    "21",
                    "Ningxia"
                },
                { 
                    "22",
                    "Beijing"
                },
                { 
                    "23",
                    "Shanghai"
                },
                { 
                    "24",
                    "Shanxi"
                },
                { 
                    "25",
                    "Shandong"
                },
                { 
                    "26",
                    "Shaanxi"
                },
                { 
                    "28",
                    "Tianjin"
                },
                { 
                    "29",
                    "Yunnan"
                },
                { 
                    "30",
                    "Guangdong"
                },
                { 
                    "31",
                    "Hainan"
                },
                { 
                    "32",
                    "Sichuan"
                },
                { 
                    "33",
                    "Chongqing"
                }
            };
            RegionName.hashtable_0.Add("CN", hashtable38);
            Hashtable hashtable39 = new Hashtable {
                { 
                    "01",
                    "Amazonas"
                },
                { 
                    "02",
                    "Antioquia"
                },
                { 
                    "03",
                    "Arauca"
                },
                { 
                    "04",
                    "Atlantico"
                },
                { 
                    "08",
                    "Caqueta"
                },
                { 
                    "09",
                    "Cauca"
                },
                { 
                    "10",
                    "Cesar"
                },
                { 
                    "11",
                    "Choco"
                },
                { 
                    "12",
                    "Cordoba"
                },
                { 
                    "14",
                    "Guaviare"
                },
                { 
                    "15",
                    "Guainia"
                },
                { 
                    "16",
                    "Huila"
                },
                { 
                    "17",
                    "La Guajira"
                },
                { 
                    "19",
                    "Meta"
                },
                { 
                    "20",
                    "Narino"
                },
                { 
                    "21",
                    "Norte de Santander"
                },
                { 
                    "22",
                    "Putumayo"
                },
                { 
                    "23",
                    "Quindio"
                },
                { 
                    "24",
                    "Risaralda"
                },
                { 
                    "25",
                    "San Andres y Providencia"
                },
                { 
                    "26",
                    "Santander"
                },
                { 
                    "27",
                    "Sucre"
                },
                { 
                    "28",
                    "Tolima"
                },
                { 
                    "29",
                    "Valle del Cauca"
                },
                { 
                    "30",
                    "Vaupes"
                },
                { 
                    "31",
                    "Vichada"
                },
                { 
                    "32",
                    "Casanare"
                },
                { 
                    "33",
                    "Cundinamarca"
                },
                { 
                    "34",
                    "Distrito Especial"
                },
                { 
                    "35",
                    "Bolivar"
                },
                { 
                    "36",
                    "Boyaca"
                },
                { 
                    "37",
                    "Caldas"
                },
                { 
                    "38",
                    "Magdalena"
                }
            };
            RegionName.hashtable_0.Add("CO", hashtable39);
            Hashtable hashtable40 = new Hashtable {
                { 
                    "01",
                    "Alajuela"
                },
                { 
                    "02",
                    "Cartago"
                },
                { 
                    "03",
                    "Guanacaste"
                },
                { 
                    "04",
                    "Heredia"
                },
                { 
                    "06",
                    "Limon"
                },
                { 
                    "07",
                    "Puntarenas"
                },
                { 
                    "08",
                    "San Jose"
                }
            };
            RegionName.hashtable_0.Add("CR", hashtable40);
            Hashtable hashtable41 = new Hashtable {
                { 
                    "01",
                    "Pinar del Rio"
                },
                { 
                    "02",
                    "Ciudad de la Habana"
                },
                { 
                    "03",
                    "Matanzas"
                },
                { 
                    "04",
                    "Isla de la Juventud"
                },
                { 
                    "05",
                    "Camaguey"
                },
                { 
                    "07",
                    "Ciego de Avila"
                },
                { 
                    "08",
                    "Cienfuegos"
                },
                { 
                    "09",
                    "Granma"
                },
                { 
                    "10",
                    "Guantanamo"
                },
                { 
                    "11",
                    "La Habana"
                },
                { 
                    "12",
                    "Holguin"
                },
                { 
                    "13",
                    "Las Tunas"
                },
                { 
                    "14",
                    "Sancti Spiritus"
                },
                { 
                    "15",
                    "Santiago de Cuba"
                },
                { 
                    "16",
                    "Villa Clara"
                }
            };
            RegionName.hashtable_0.Add("CU", hashtable41);
            Hashtable hashtable42 = new Hashtable {
                { 
                    "01",
                    "Boa Vista"
                },
                { 
                    "02",
                    "Brava"
                },
                { 
                    "04",
                    "Maio"
                },
                { 
                    "05",
                    "Paul"
                },
                { 
                    "07",
                    "Ribeira Grande"
                },
                { 
                    "08",
                    "Sal"
                },
                { 
                    "10",
                    "Sao Nicolau"
                },
                { 
                    "11",
                    "Sao Vicente"
                },
                { 
                    "13",
                    "Mosteiros"
                },
                { 
                    "14",
                    "Praia"
                },
                { 
                    "15",
                    "Santa Catarina"
                },
                { 
                    "16",
                    "Santa Cruz"
                },
                { 
                    "17",
                    "Sao Domingos"
                },
                { 
                    "18",
                    "Sao Filipe"
                },
                { 
                    "19",
                    "Sao Miguel"
                },
                { 
                    "20",
                    "Tarrafal"
                }
            };
            RegionName.hashtable_0.Add("CV", hashtable42);
            Hashtable hashtable43 = new Hashtable {
                { 
                    "01",
                    "Famagusta"
                },
                { 
                    "02",
                    "Kyrenia"
                },
                { 
                    "03",
                    "Larnaca"
                },
                { 
                    "04",
                    "Nicosia"
                },
                { 
                    "05",
                    "Limassol"
                },
                { 
                    "06",
                    "Paphos"
                }
            };
            RegionName.hashtable_0.Add("CY", hashtable43);
            Hashtable hashtable44 = new Hashtable {
                { 
                    "52",
                    "Hlavni mesto Praha"
                },
                { 
                    "78",
                    "Jihomoravsky kraj"
                },
                { 
                    "79",
                    "Jihocesky kraj"
                },
                { 
                    "80",
                    "Vysocina"
                },
                { 
                    "81",
                    "Karlovarsky kraj"
                },
                { 
                    "82",
                    "Kralovehradecky kraj"
                },
                { 
                    "83",
                    "Liberecky kraj"
                },
                { 
                    "84",
                    "Olomoucky kraj"
                },
                { 
                    "85",
                    "Moravskoslezsky kraj"
                },
                { 
                    "86",
                    "Pardubicky kraj"
                },
                { 
                    "87",
                    "Plzensky kraj"
                },
                { 
                    "88",
                    "Stredocesky kraj"
                },
                { 
                    "89",
                    "Ustecky kraj"
                },
                { 
                    "90",
                    "Zlinsky kraj"
                }
            };
            RegionName.hashtable_0.Add("CZ", hashtable44);
            Hashtable hashtable45 = new Hashtable {
                { 
                    "01",
                    "Baden-Wurttemberg"
                },
                { 
                    "02",
                    "Bayern"
                },
                { 
                    "03",
                    "Bremen"
                },
                { 
                    "04",
                    "Hamburg"
                },
                { 
                    "05",
                    "Hessen"
                },
                { 
                    "06",
                    "Niedersachsen"
                },
                { 
                    "07",
                    "Nordrhein-Westfalen"
                },
                { 
                    "08",
                    "Rheinland-Pfalz"
                },
                { 
                    "09",
                    "Saarland"
                },
                { 
                    "10",
                    "Schleswig-Holstein"
                },
                { 
                    "11",
                    "Brandenburg"
                },
                { 
                    "12",
                    "Mecklenburg-Vorpommern"
                },
                { 
                    "13",
                    "Sachsen"
                },
                { 
                    "14",
                    "Sachsen-Anhalt"
                },
                { 
                    "15",
                    "Thuringen"
                },
                { 
                    "16",
                    "Berlin"
                }
            };
            RegionName.hashtable_0.Add("DE", hashtable45);
            Hashtable hashtable46 = new Hashtable {
                { 
                    "01",
                    "Ali Sabieh"
                },
                { 
                    "04",
                    "Obock"
                },
                { 
                    "05",
                    "Tadjoura"
                },
                { 
                    "06",
                    "Dikhil"
                },
                { 
                    "07",
                    "Djibouti"
                },
                { 
                    "08",
                    "Arta"
                }
            };
            RegionName.hashtable_0.Add("DJ", hashtable46);
            Hashtable hashtable47 = new Hashtable {
                { 
                    "17",
                    "Hovedstaden"
                },
                { 
                    "18",
                    "Midtjylland"
                },
                { 
                    "19",
                    "Nordjylland"
                },
                { 
                    "20",
                    "Sjelland"
                },
                { 
                    "21",
                    "Syddanmark"
                }
            };
            RegionName.hashtable_0.Add("DK", hashtable47);
            Hashtable hashtable48 = new Hashtable {
                { 
                    "02",
                    "Saint Andrew"
                },
                { 
                    "03",
                    "Saint David"
                },
                { 
                    "04",
                    "Saint George"
                },
                { 
                    "05",
                    "Saint John"
                },
                { 
                    "06",
                    "Saint Joseph"
                },
                { 
                    "07",
                    "Saint Luke"
                },
                { 
                    "08",
                    "Saint Mark"
                },
                { 
                    "09",
                    "Saint Patrick"
                },
                { 
                    "10",
                    "Saint Paul"
                },
                { 
                    "11",
                    "Saint Peter"
                }
            };
            RegionName.hashtable_0.Add("DM", hashtable48);
            Hashtable hashtable49 = new Hashtable {
                { 
                    "01",
                    "Azua"
                },
                { 
                    "02",
                    "Baoruco"
                },
                { 
                    "03",
                    "Barahona"
                },
                { 
                    "04",
                    "Dajabon"
                },
                { 
                    "05",
                    "Distrito Nacional"
                },
                { 
                    "06",
                    "Duarte"
                },
                { 
                    "08",
                    "Espaillat"
                },
                { 
                    "09",
                    "Independencia"
                },
                { 
                    "10",
                    "La Altagracia"
                },
                { 
                    "11",
                    "Elias Pina"
                },
                { 
                    "12",
                    "La Romana"
                },
                { 
                    "14",
                    "Maria Trinidad Sanchez"
                },
                { 
                    "15",
                    "Monte Cristi"
                },
                { 
                    "16",
                    "Pedernales"
                },
                { 
                    "17",
                    "Peravia"
                },
                { 
                    "18",
                    "Puerto Plata"
                },
                { 
                    "19",
                    "Salcedo"
                },
                { 
                    "20",
                    "Samana"
                },
                { 
                    "21",
                    "Sanchez Ramirez"
                },
                { 
                    "23",
                    "San Juan"
                },
                { 
                    "24",
                    "San Pedro De Macoris"
                },
                { 
                    "25",
                    "Santiago"
                },
                { 
                    "26",
                    "Santiago Rodriguez"
                },
                { 
                    "27",
                    "Valverde"
                },
                { 
                    "28",
                    "El Seibo"
                },
                { 
                    "29",
                    "Hato Mayor"
                },
                { 
                    "30",
                    "La Vega"
                },
                { 
                    "31",
                    "Monsenor Nouel"
                },
                { 
                    "32",
                    "Monte Plata"
                },
                { 
                    "33",
                    "San Cristobal"
                },
                { 
                    "34",
                    "Distrito Nacional"
                },
                { 
                    "35",
                    "Peravia"
                },
                { 
                    "36",
                    "San Jose de Ocoa"
                },
                { 
                    "37",
                    "Santo Domingo"
                }
            };
            RegionName.hashtable_0.Add("DO", hashtable49);
            Hashtable hashtable50 = new Hashtable {
                { 
                    "01",
                    "Alger"
                },
                { 
                    "03",
                    "Batna"
                },
                { 
                    "04",
                    "Constantine"
                },
                { 
                    "06",
                    "Medea"
                },
                { 
                    "07",
                    "Mostaganem"
                },
                { 
                    "09",
                    "Oran"
                },
                { 
                    "10",
                    "Saida"
                },
                { 
                    "12",
                    "Setif"
                },
                { 
                    "13",
                    "Tiaret"
                },
                { 
                    "14",
                    "Tizi Ouzou"
                },
                { 
                    "15",
                    "Tlemcen"
                },
                { 
                    "18",
                    "Bejaia"
                },
                { 
                    "19",
                    "Biskra"
                },
                { 
                    "20",
                    "Blida"
                },
                { 
                    "21",
                    "Bouira"
                },
                { 
                    "22",
                    "Djelfa"
                },
                { 
                    "23",
                    "Guelma"
                },
                { 
                    "24",
                    "Jijel"
                },
                { 
                    "25",
                    "Laghouat"
                },
                { 
                    "26",
                    "Mascara"
                },
                { 
                    "27",
                    "M'sila"
                },
                { 
                    "29",
                    "Oum el Bouaghi"
                },
                { 
                    "30",
                    "Sidi Bel Abbes"
                },
                { 
                    "31",
                    "Skikda"
                },
                { 
                    "33",
                    "Tebessa"
                },
                { 
                    "34",
                    "Adrar"
                },
                { 
                    "35",
                    "Ain Defla"
                },
                { 
                    "36",
                    "Ain Temouchent"
                },
                { 
                    "37",
                    "Annaba"
                },
                { 
                    "38",
                    "Bechar"
                },
                { 
                    "39",
                    "Bordj Bou Arreridj"
                },
                { 
                    "40",
                    "Boumerdes"
                },
                { 
                    "41",
                    "Chlef"
                },
                { 
                    "42",
                    "El Bayadh"
                },
                { 
                    "43",
                    "El Oued"
                },
                { 
                    "44",
                    "El Tarf"
                },
                { 
                    "45",
                    "Ghardaia"
                },
                { 
                    "46",
                    "Illizi"
                },
                { 
                    "47",
                    "Khenchela"
                },
                { 
                    "48",
                    "Mila"
                },
                { 
                    "49",
                    "Naama"
                },
                { 
                    "50",
                    "Ouargla"
                },
                { 
                    "51",
                    "Relizane"
                },
                { 
                    "52",
                    "Souk Ahras"
                },
                { 
                    "53",
                    "Tamanghasset"
                },
                { 
                    "54",
                    "Tindouf"
                },
                { 
                    "55",
                    "Tipaza"
                },
                { 
                    "56",
                    "Tissemsilt"
                }
            };
            RegionName.hashtable_0.Add("DZ", hashtable50);
            Hashtable hashtable51 = new Hashtable {
                { 
                    "01",
                    "Galapagos"
                },
                { 
                    "02",
                    "Azuay"
                },
                { 
                    "03",
                    "Bolivar"
                },
                { 
                    "04",
                    "Canar"
                },
                { 
                    "05",
                    "Carchi"
                },
                { 
                    "06",
                    "Chimborazo"
                },
                { 
                    "07",
                    "Cotopaxi"
                },
                { 
                    "08",
                    "El Oro"
                },
                { 
                    "09",
                    "Esmeraldas"
                },
                { 
                    "10",
                    "Guayas"
                },
                { 
                    "11",
                    "Imbabura"
                },
                { 
                    "12",
                    "Loja"
                },
                { 
                    "13",
                    "Los Rios"
                },
                { 
                    "14",
                    "Manabi"
                },
                { 
                    "15",
                    "Morona-Santiago"
                },
                { 
                    "17",
                    "Pastaza"
                },
                { 
                    "18",
                    "Pichincha"
                },
                { 
                    "19",
                    "Tungurahua"
                },
                { 
                    "20",
                    "Zamora-Chinchipe"
                },
                { 
                    "22",
                    "Sucumbios"
                },
                { 
                    "23",
                    "Napo"
                },
                { 
                    "24",
                    "Orellana"
                }
            };
            RegionName.hashtable_0.Add("EC", hashtable51);
            Hashtable hashtable52 = new Hashtable {
                { 
                    "01",
                    "Harjumaa"
                },
                { 
                    "02",
                    "Hiiumaa"
                },
                { 
                    "03",
                    "Ida-Virumaa"
                },
                { 
                    "04",
                    "Jarvamaa"
                },
                { 
                    "05",
                    "Jogevamaa"
                },
                { 
                    "06",
                    "Kohtla-Jarve"
                },
                { 
                    "07",
                    "Laanemaa"
                },
                { 
                    "08",
                    "Laane-Virumaa"
                },
                { 
                    "09",
                    "Narva"
                },
                { 
                    "10",
                    "Parnu"
                },
                { 
                    "11",
                    "Parnumaa"
                },
                { 
                    "12",
                    "Polvamaa"
                },
                { 
                    "13",
                    "Raplamaa"
                },
                { 
                    "14",
                    "Saaremaa"
                },
                { 
                    "15",
                    "Sillamae"
                },
                { 
                    "16",
                    "Tallinn"
                },
                { 
                    "17",
                    "Tartu"
                },
                { 
                    "18",
                    "Tartumaa"
                },
                { 
                    "19",
                    "Valgamaa"
                },
                { 
                    "20",
                    "Viljandimaa"
                },
                { 
                    "21",
                    "Vorumaa"
                }
            };
            RegionName.hashtable_0.Add("EE", hashtable52);
            Hashtable hashtable53 = new Hashtable {
                { 
                    "01",
                    "Ad Daqahliyah"
                },
                { 
                    "02",
                    "Al Bahr al Ahmar"
                },
                { 
                    "03",
                    "Al Buhayrah"
                },
                { 
                    "04",
                    "Al Fayyum"
                },
                { 
                    "05",
                    "Al Gharbiyah"
                },
                { 
                    "06",
                    "Al Iskandariyah"
                },
                { 
                    "07",
                    "Al Isma'iliyah"
                },
                { 
                    "08",
                    "Al Jizah"
                },
                { 
                    "09",
                    "Al Minufiyah"
                },
                { 
                    "10",
                    "Al Minya"
                },
                { 
                    "11",
                    "Al Qahirah"
                },
                { 
                    "12",
                    "Al Qalyubiyah"
                },
                { 
                    "13",
                    "Al Wadi al Jadid"
                },
                { 
                    "14",
                    "Ash Sharqiyah"
                },
                { 
                    "15",
                    "As Suways"
                },
                { 
                    "16",
                    "Aswan"
                },
                { 
                    "17",
                    "Asyut"
                },
                { 
                    "18",
                    "Bani Suwayf"
                },
                { 
                    "19",
                    "Bur Sa'id"
                },
                { 
                    "20",
                    "Dumyat"
                },
                { 
                    "21",
                    "Kafr ash Shaykh"
                },
                { 
                    "22",
                    "Matruh"
                },
                { 
                    "23",
                    "Qina"
                },
                { 
                    "24",
                    "Suhaj"
                },
                { 
                    "26",
                    "Janub Sina'"
                },
                { 
                    "27",
                    "Shamal Sina'"
                }
            };
            RegionName.hashtable_0.Add("EG", hashtable53);
            Hashtable hashtable54 = new Hashtable {
                { 
                    "01",
                    "Anseba"
                },
                { 
                    "02",
                    "Debub"
                },
                { 
                    "03",
                    "Debubawi K'eyih Bahri"
                },
                { 
                    "04",
                    "Gash Barka"
                },
                { 
                    "05",
                    "Ma'akel"
                },
                { 
                    "06",
                    "Semenawi K'eyih Bahri"
                }
            };
            RegionName.hashtable_0.Add("ER", hashtable54);
            Hashtable hashtable55 = new Hashtable {
                { 
                    "07",
                    "Islas Baleares"
                },
                { 
                    "27",
                    "La Rioja"
                },
                { 
                    "29",
                    "Madrid"
                },
                { 
                    "31",
                    "Murcia"
                },
                { 
                    "32",
                    "Navarra"
                },
                { 
                    "34",
                    "Asturias"
                },
                { 
                    "39",
                    "Cantabria"
                },
                { 
                    "51",
                    "Andalucia"
                },
                { 
                    "52",
                    "Aragon"
                },
                { 
                    "53",
                    "Canarias"
                },
                { 
                    "54",
                    "Castilla-La Mancha"
                },
                { 
                    "55",
                    "Castilla y Leon"
                },
                { 
                    "56",
                    "Catalonia"
                },
                { 
                    "57",
                    "Extremadura"
                },
                { 
                    "58",
                    "Galicia"
                },
                { 
                    "59",
                    "Pais Vasco"
                },
                { 
                    "60",
                    "Comunidad Valenciana"
                }
            };
            RegionName.hashtable_0.Add("ES", hashtable55);
            Hashtable hashtable56 = new Hashtable {
                { 
                    "44",
                    "Adis Abeba"
                },
                { 
                    "45",
                    "Afar"
                },
                { 
                    "46",
                    "Amara"
                },
                { 
                    "47",
                    "Binshangul Gumuz"
                },
                { 
                    "48",
                    "Dire Dawa"
                },
                { 
                    "49",
                    "Gambela Hizboch"
                },
                { 
                    "50",
                    "Hareri Hizb"
                },
                { 
                    "51",
                    "Oromiya"
                },
                { 
                    "52",
                    "Sumale"
                },
                { 
                    "53",
                    "Tigray"
                },
                { 
                    "54",
                    "YeDebub Biheroch Bihereseboch na Hizboch"
                }
            };
            RegionName.hashtable_0.Add("ET", hashtable56);
            Hashtable hashtable57 = new Hashtable {
                { 
                    "01",
                    "Aland"
                },
                { 
                    "06",
                    "Lapland"
                },
                { 
                    "08",
                    "Oulu"
                },
                { 
                    "13",
                    "Southern Finland"
                },
                { 
                    "14",
                    "Eastern Finland"
                },
                { 
                    "15",
                    "Western Finland"
                }
            };
            RegionName.hashtable_0.Add("FI", hashtable57);
            Hashtable hashtable58 = new Hashtable {
                { 
                    "01",
                    "Central"
                },
                { 
                    "02",
                    "Eastern"
                },
                { 
                    "03",
                    "Northern"
                },
                { 
                    "04",
                    "Rotuma"
                },
                { 
                    "05",
                    "Western"
                }
            };
            RegionName.hashtable_0.Add("FJ", hashtable58);
            Hashtable hashtable59 = new Hashtable {
                { 
                    "01",
                    "Kosrae"
                },
                { 
                    "02",
                    "Pohnpei"
                },
                { 
                    "03",
                    "Chuuk"
                },
                { 
                    "04",
                    "Yap"
                }
            };
            RegionName.hashtable_0.Add("FM", hashtable59);
            Hashtable hashtable60 = new Hashtable {
                { 
                    "97",
                    "Aquitaine"
                },
                { 
                    "98",
                    "Auvergne"
                },
                { 
                    "99",
                    "Basse-Normandie"
                },
                { 
                    "A1",
                    "Bourgogne"
                },
                { 
                    "A2",
                    "Bretagne"
                },
                { 
                    "A3",
                    "Centre"
                },
                { 
                    "A4",
                    "Champagne-Ardenne"
                },
                { 
                    "A5",
                    "Corse"
                },
                { 
                    "A6",
                    "Franche-Comte"
                },
                { 
                    "A7",
                    "Haute-Normandie"
                },
                { 
                    "A8",
                    "Ile-de-France"
                },
                { 
                    "A9",
                    "Languedoc-Roussillon"
                },
                { 
                    "B1",
                    "Limousin"
                },
                { 
                    "B2",
                    "Lorraine"
                },
                { 
                    "B3",
                    "Midi-Pyrenees"
                },
                { 
                    "B4",
                    "Nord-Pas-de-Calais"
                },
                { 
                    "B5",
                    "Pays de la Loire"
                },
                { 
                    "B6",
                    "Picardie"
                },
                { 
                    "B7",
                    "Poitou-Charentes"
                },
                { 
                    "B8",
                    "Provence-Alpes-Cote d'Azur"
                },
                { 
                    "B9",
                    "Rhone-Alpes"
                },
                { 
                    "C1",
                    "Alsace"
                }
            };
            RegionName.hashtable_0.Add("FR", hashtable60);
            Hashtable hashtable61 = new Hashtable {
                { 
                    "01",
                    "Estuaire"
                },
                { 
                    "02",
                    "Haut-Ogooue"
                },
                { 
                    "03",
                    "Moyen-Ogooue"
                },
                { 
                    "04",
                    "Ngounie"
                },
                { 
                    "05",
                    "Nyanga"
                },
                { 
                    "06",
                    "Ogooue-Ivindo"
                },
                { 
                    "07",
                    "Ogooue-Lolo"
                },
                { 
                    "08",
                    "Ogooue-Maritime"
                },
                { 
                    "09",
                    "Woleu-Ntem"
                }
            };
            RegionName.hashtable_0.Add("GA", hashtable61);
            Hashtable hashtable62 = new Hashtable {
                { 
                    "A1",
                    "Barking and Dagenham"
                },
                { 
                    "A2",
                    "Barnet"
                },
                { 
                    "A3",
                    "Barnsley"
                },
                { 
                    "A4",
                    "Bath and North East Somerset"
                },
                { 
                    "A5",
                    "Bedfordshire"
                },
                { 
                    "A6",
                    "Bexley"
                },
                { 
                    "A7",
                    "Birmingham"
                },
                { 
                    "A8",
                    "Blackburn with Darwen"
                },
                { 
                    "A9",
                    "Blackpool"
                },
                { 
                    "B1",
                    "Bolton"
                },
                { 
                    "B2",
                    "Bournemouth"
                },
                { 
                    "B3",
                    "Bracknell Forest"
                },
                { 
                    "B4",
                    "Bradford"
                },
                { 
                    "B5",
                    "Brent"
                },
                { 
                    "B6",
                    "Brighton and Hove"
                },
                { 
                    "B7",
                    "Bristol, City of"
                },
                { 
                    "B8",
                    "Bromley"
                },
                { 
                    "B9",
                    "Buckinghamshire"
                },
                { 
                    "C1",
                    "Bury"
                },
                { 
                    "C2",
                    "Calderdale"
                },
                { 
                    "C3",
                    "Cambridgeshire"
                },
                { 
                    "C4",
                    "Camden"
                },
                { 
                    "C5",
                    "Cheshire"
                },
                { 
                    "C6",
                    "Cornwall"
                },
                { 
                    "C7",
                    "Coventry"
                },
                { 
                    "C8",
                    "Croydon"
                },
                { 
                    "C9",
                    "Cumbria"
                },
                { 
                    "D1",
                    "Darlington"
                },
                { 
                    "D2",
                    "Derby"
                },
                { 
                    "D3",
                    "Derbyshire"
                },
                { 
                    "D4",
                    "Devon"
                },
                { 
                    "D5",
                    "Doncaster"
                },
                { 
                    "D6",
                    "Dorset"
                },
                { 
                    "D7",
                    "Dudley"
                },
                { 
                    "D8",
                    "Durham"
                },
                { 
                    "D9",
                    "Ealing"
                },
                { 
                    "E1",
                    "East Riding of Yorkshire"
                },
                { 
                    "E2",
                    "East Sussex"
                },
                { 
                    "E3",
                    "Enfield"
                },
                { 
                    "E4",
                    "Essex"
                },
                { 
                    "E5",
                    "Gateshead"
                },
                { 
                    "E6",
                    "Gloucestershire"
                },
                { 
                    "E7",
                    "Greenwich"
                },
                { 
                    "E8",
                    "Hackney"
                },
                { 
                    "E9",
                    "Halton"
                },
                { 
                    "F1",
                    "Hammersmith and Fulham"
                },
                { 
                    "F2",
                    "Hampshire"
                },
                { 
                    "F3",
                    "Haringey"
                },
                { 
                    "F4",
                    "Harrow"
                },
                { 
                    "F5",
                    "Hartlepool"
                },
                { 
                    "F6",
                    "Havering"
                },
                { 
                    "F7",
                    "Herefordshire"
                },
                { 
                    "F8",
                    "Hertford"
                },
                { 
                    "F9",
                    "Hillingdon"
                },
                { 
                    "G1",
                    "Hounslow"
                },
                { 
                    "G2",
                    "Isle of Wight"
                },
                { 
                    "G3",
                    "Islington"
                },
                { 
                    "G4",
                    "Kensington and Chelsea"
                },
                { 
                    "G5",
                    "Kent"
                },
                { 
                    "G6",
                    "Kingston upon Hull, City of"
                },
                { 
                    "G7",
                    "Kingston upon Thames"
                },
                { 
                    "G8",
                    "Kirklees"
                },
                { 
                    "G9",
                    "Knowsley"
                },
                { 
                    "H1",
                    "Lambeth"
                },
                { 
                    "H2",
                    "Lancashire"
                },
                { 
                    "H3",
                    "Leeds"
                },
                { 
                    "H4",
                    "Leicester"
                },
                { 
                    "H5",
                    "Leicestershire"
                },
                { 
                    "H6",
                    "Lewisham"
                },
                { 
                    "H7",
                    "Lincolnshire"
                },
                { 
                    "H8",
                    "Liverpool"
                },
                { 
                    "H9",
                    "London, City of"
                },
                { 
                    "I1",
                    "Luton"
                },
                { 
                    "I2",
                    "Manchester"
                },
                { 
                    "I3",
                    "Medway"
                },
                { 
                    "I4",
                    "Merton"
                },
                { 
                    "I5",
                    "Middlesbrough"
                },
                { 
                    "I6",
                    "Milton Keynes"
                },
                { 
                    "I7",
                    "Newcastle upon Tyne"
                },
                { 
                    "I8",
                    "Newham"
                },
                { 
                    "I9",
                    "Norfolk"
                },
                { 
                    "J1",
                    "Northamptonshire"
                },
                { 
                    "J2",
                    "North East Lincolnshire"
                },
                { 
                    "J3",
                    "North Lincolnshire"
                },
                { 
                    "J4",
                    "North Somerset"
                },
                { 
                    "J5",
                    "North Tyneside"
                },
                { 
                    "J6",
                    "Northumberland"
                },
                { 
                    "J7",
                    "North Yorkshire"
                },
                { 
                    "J8",
                    "Nottingham"
                },
                { 
                    "J9",
                    "Nottinghamshire"
                },
                { 
                    "K1",
                    "Oldham"
                },
                { 
                    "K2",
                    "Oxfordshire"
                },
                { 
                    "K3",
                    "Peterborough"
                },
                { 
                    "K4",
                    "Plymouth"
                },
                { 
                    "K5",
                    "Poole"
                },
                { 
                    "K6",
                    "Portsmouth"
                },
                { 
                    "K7",
                    "Reading"
                },
                { 
                    "K8",
                    "Redbridge"
                },
                { 
                    "K9",
                    "Redcar and Cleveland"
                },
                { 
                    "L1",
                    "Richmond upon Thames"
                },
                { 
                    "L2",
                    "Rochdale"
                },
                { 
                    "L3",
                    "Rotherham"
                },
                { 
                    "L4",
                    "Rutland"
                },
                { 
                    "L5",
                    "Salford"
                },
                { 
                    "L6",
                    "Shropshire"
                },
                { 
                    "L7",
                    "Sandwell"
                },
                { 
                    "L8",
                    "Sefton"
                },
                { 
                    "L9",
                    "Sheffield"
                },
                { 
                    "M1",
                    "Slough"
                },
                { 
                    "M2",
                    "Solihull"
                },
                { 
                    "M3",
                    "Somerset"
                },
                { 
                    "M4",
                    "Southampton"
                },
                { 
                    "M5",
                    "Southend-on-Sea"
                },
                { 
                    "M6",
                    "South Gloucestershire"
                },
                { 
                    "M7",
                    "South Tyneside"
                },
                { 
                    "M8",
                    "Southwark"
                },
                { 
                    "M9",
                    "Staffordshire"
                },
                { 
                    "N1",
                    "St. Helens"
                },
                { 
                    "N2",
                    "Stockport"
                },
                { 
                    "N3",
                    "Stockton-on-Tees"
                },
                { 
                    "N4",
                    "Stoke-on-Trent"
                },
                { 
                    "N5",
                    "Suffolk"
                },
                { 
                    "N6",
                    "Sunderland"
                },
                { 
                    "N7",
                    "Surrey"
                },
                { 
                    "N8",
                    "Sutton"
                },
                { 
                    "N9",
                    "Swindon"
                },
                { 
                    "O1",
                    "Tameside"
                },
                { 
                    "O2",
                    "Telford and Wrekin"
                },
                { 
                    "O3",
                    "Thurrock"
                },
                { 
                    "O4",
                    "Torbay"
                },
                { 
                    "O5",
                    "Tower Hamlets"
                },
                { 
                    "O6",
                    "Trafford"
                },
                { 
                    "O7",
                    "Wakefield"
                },
                { 
                    "O8",
                    "Walsall"
                },
                { 
                    "O9",
                    "Waltham Forest"
                },
                { 
                    "P1",
                    "Wandsworth"
                },
                { 
                    "P2",
                    "Warrington"
                },
                { 
                    "P3",
                    "Warwickshire"
                },
                { 
                    "P4",
                    "West Berkshire"
                },
                { 
                    "P5",
                    "Westminster"
                },
                { 
                    "P6",
                    "West Sussex"
                },
                { 
                    "P7",
                    "Wigan"
                },
                { 
                    "P8",
                    "Wiltshire"
                },
                { 
                    "P9",
                    "Windsor and Maidenhead"
                },
                { 
                    "Q1",
                    "Wirral"
                },
                { 
                    "Q2",
                    "Wokingham"
                },
                { 
                    "Q3",
                    "Wolverhampton"
                },
                { 
                    "Q4",
                    "Worcestershire"
                },
                { 
                    "Q5",
                    "York"
                },
                { 
                    "Q6",
                    "Antrim"
                },
                { 
                    "Q7",
                    "Ards"
                },
                { 
                    "Q8",
                    "Armagh"
                },
                { 
                    "Q9",
                    "Ballymena"
                },
                { 
                    "R1",
                    "Ballymoney"
                },
                { 
                    "R2",
                    "Banbridge"
                },
                { 
                    "R3",
                    "Belfast"
                },
                { 
                    "R4",
                    "Carrickfergus"
                },
                { 
                    "R5",
                    "Castlereagh"
                },
                { 
                    "R6",
                    "Coleraine"
                },
                { 
                    "R7",
                    "Cookstown"
                },
                { 
                    "R8",
                    "Craigavon"
                },
                { 
                    "R9",
                    "Down"
                },
                { 
                    "S1",
                    "Dungannon"
                },
                { 
                    "S2",
                    "Fermanagh"
                },
                { 
                    "S3",
                    "Larne"
                },
                { 
                    "S4",
                    "Limavady"
                },
                { 
                    "S5",
                    "Lisburn"
                },
                { 
                    "S6",
                    "Derry"
                },
                { 
                    "S7",
                    "Magherafelt"
                },
                { 
                    "S8",
                    "Moyle"
                },
                { 
                    "S9",
                    "Newry and Mourne"
                },
                { 
                    "T1",
                    "Newtownabbey"
                },
                { 
                    "T2",
                    "North Down"
                },
                { 
                    "T3",
                    "Omagh"
                },
                { 
                    "T4",
                    "Strabane"
                },
                { 
                    "T5",
                    "Aberdeen City"
                },
                { 
                    "T6",
                    "Aberdeenshire"
                },
                { 
                    "T7",
                    "Angus"
                },
                { 
                    "T8",
                    "Argyll and Bute"
                },
                { 
                    "T9",
                    "Scottish Borders, The"
                },
                { 
                    "U1",
                    "Clackmannanshire"
                },
                { 
                    "U2",
                    "Dumfries and Galloway"
                },
                { 
                    "U3",
                    "Dundee City"
                },
                { 
                    "U4",
                    "East Ayrshire"
                },
                { 
                    "U5",
                    "East Dunbartonshire"
                },
                { 
                    "U6",
                    "East Lothian"
                },
                { 
                    "U7",
                    "East Renfrewshire"
                },
                { 
                    "U8",
                    "Edinburgh, City of"
                },
                { 
                    "U9",
                    "Falkirk"
                },
                { 
                    "V1",
                    "Fife"
                },
                { 
                    "V2",
                    "Glasgow City"
                },
                { 
                    "V3",
                    "Highland"
                },
                { 
                    "V4",
                    "Inverclyde"
                },
                { 
                    "V5",
                    "Midlothian"
                },
                { 
                    "V6",
                    "Moray"
                },
                { 
                    "V7",
                    "North Ayrshire"
                },
                { 
                    "V8",
                    "North Lanarkshire"
                },
                { 
                    "V9",
                    "Orkney"
                },
                { 
                    "W1",
                    "Perth and Kinross"
                },
                { 
                    "W2",
                    "Renfrewshire"
                },
                { 
                    "W3",
                    "Shetland Islands"
                },
                { 
                    "W4",
                    "South Ayrshire"
                },
                { 
                    "W5",
                    "South Lanarkshire"
                },
                { 
                    "W6",
                    "Stirling"
                },
                { 
                    "W7",
                    "West Dunbartonshire"
                },
                { 
                    "W8",
                    "Eilean Siar"
                },
                { 
                    "W9",
                    "West Lothian"
                },
                { 
                    "X1",
                    "Isle of Anglesey"
                },
                { 
                    "X2",
                    "Blaenau Gwent"
                },
                { 
                    "X3",
                    "Bridgend"
                },
                { 
                    "X4",
                    "Caerphilly"
                },
                { 
                    "X5",
                    "Cardiff"
                },
                { 
                    "X6",
                    "Ceredigion"
                },
                { 
                    "X7",
                    "Carmarthenshire"
                },
                { 
                    "X8",
                    "Conwy"
                },
                { 
                    "X9",
                    "Denbighshire"
                },
                { 
                    "Y1",
                    "Flintshire"
                },
                { 
                    "Y2",
                    "Gwynedd"
                },
                { 
                    "Y3",
                    "Merthyr Tydfil"
                },
                { 
                    "Y4",
                    "Monmouthshire"
                },
                { 
                    "Y5",
                    "Neath Port Talbot"
                },
                { 
                    "Y6",
                    "Newport"
                },
                { 
                    "Y7",
                    "Pembrokeshire"
                },
                { 
                    "Y8",
                    "Powys"
                },
                { 
                    "Y9",
                    "Rhondda Cynon Taff"
                },
                { 
                    "Z1",
                    "Swansea"
                },
                { 
                    "Z2",
                    "Torfaen"
                },
                { 
                    "Z3",
                    "Vale of Glamorgan, The"
                },
                { 
                    "Z4",
                    "Wrexham"
                }
            };
            RegionName.hashtable_0.Add("GB", hashtable62);
            Hashtable hashtable63 = new Hashtable {
                { 
                    "01",
                    "Saint Andrew"
                },
                { 
                    "02",
                    "Saint David"
                },
                { 
                    "03",
                    "Saint George"
                },
                { 
                    "04",
                    "Saint John"
                },
                { 
                    "05",
                    "Saint Mark"
                },
                { 
                    "06",
                    "Saint Patrick"
                }
            };
            RegionName.hashtable_0.Add("GD", hashtable63);
            Hashtable hashtable64 = new Hashtable {
                { 
                    "01",
                    "Abashis Raioni"
                },
                { 
                    "02",
                    "Abkhazia"
                },
                { 
                    "03",
                    "Adigenis Raioni"
                },
                { 
                    "04",
                    "Ajaria"
                },
                { 
                    "05",
                    "Akhalgoris Raioni"
                },
                { 
                    "06",
                    "Akhalk'alak'is Raioni"
                },
                { 
                    "07",
                    "Akhalts'ikhis Raioni"
                },
                { 
                    "08",
                    "Akhmetis Raioni"
                },
                { 
                    "09",
                    "Ambrolauris Raioni"
                },
                { 
                    "10",
                    "Aspindzis Raioni"
                },
                { 
                    "11",
                    "Baghdat'is Raioni"
                },
                { 
                    "12",
                    "Bolnisis Raioni"
                },
                { 
                    "13",
                    "Borjomis Raioni"
                },
                { 
                    "14",
                    "Chiat'ura"
                },
                { 
                    "15",
                    "Ch'khorotsqus Raioni"
                },
                { 
                    "16",
                    "Ch'okhatauris Raioni"
                },
                { 
                    "17",
                    "Dedop'listsqaros Raioni"
                },
                { 
                    "18",
                    "Dmanisis Raioni"
                },
                { 
                    "19",
                    "Dushet'is Raioni"
                },
                { 
                    "20",
                    "Gardabanis Raioni"
                },
                { 
                    "21",
                    "Gori"
                },
                { 
                    "22",
                    "Goris Raioni"
                },
                { 
                    "23",
                    "Gurjaanis Raioni"
                },
                { 
                    "24",
                    "Javis Raioni"
                },
                { 
                    "25",
                    "K'arelis Raioni"
                },
                { 
                    "26",
                    "Kaspis Raioni"
                },
                { 
                    "27",
                    "Kharagaulis Raioni"
                },
                { 
                    "28",
                    "Khashuris Raioni"
                },
                { 
                    "29",
                    "Khobis Raioni"
                },
                { 
                    "30",
                    "Khonis Raioni"
                },
                { 
                    "31",
                    "K'ut'aisi"
                },
                { 
                    "32",
                    "Lagodekhis Raioni"
                },
                { 
                    "33",
                    "Lanch'khut'is Raioni"
                },
                { 
                    "34",
                    "Lentekhis Raioni"
                },
                { 
                    "35",
                    "Marneulis Raioni"
                },
                { 
                    "36",
                    "Martvilis Raioni"
                },
                { 
                    "37",
                    "Mestiis Raioni"
                },
                { 
                    "38",
                    "Mts'khet'is Raioni"
                },
                { 
                    "39",
                    "Ninotsmindis Raioni"
                },
                { 
                    "40",
                    "Onis Raioni"
                },
                { 
                    "41",
                    "Ozurget'is Raioni"
                },
                { 
                    "42",
                    "P'ot'i"
                },
                { 
                    "43",
                    "Qazbegis Raioni"
                },
                { 
                    "44",
                    "Qvarlis Raioni"
                },
                { 
                    "45",
                    "Rust'avi"
                },
                { 
                    "46",
                    "Sach'kheris Raioni"
                },
                { 
                    "47",
                    "Sagarejos Raioni"
                },
                { 
                    "48",
                    "Samtrediis Raioni"
                },
                { 
                    "49",
                    "Senakis Raioni"
                },
                { 
                    "50",
                    "Sighnaghis Raioni"
                },
                { 
                    "51",
                    "T'bilisi"
                },
                { 
                    "52",
                    "T'elavis Raioni"
                },
                { 
                    "53",
                    "T'erjolis Raioni"
                },
                { 
                    "54",
                    "T'et'ritsqaros Raioni"
                },
                { 
                    "55",
                    "T'ianet'is Raioni"
                },
                { 
                    "56",
                    "Tqibuli"
                },
                { 
                    "57",
                    "Ts'ageris Raioni"
                },
                { 
                    "58",
                    "Tsalenjikhis Raioni"
                },
                { 
                    "59",
                    "Tsalkis Raioni"
                },
                { 
                    "60",
                    "Tsqaltubo"
                },
                { 
                    "61",
                    "Vanis Raioni"
                },
                { 
                    "62",
                    "Zestap'onis Raioni"
                },
                { 
                    "63",
                    "Zugdidi"
                },
                { 
                    "64",
                    "Zugdidis Raioni"
                }
            };
            RegionName.hashtable_0.Add("GE", hashtable64);
            Hashtable hashtable65 = new Hashtable {
                { 
                    "01",
                    "Greater Accra"
                },
                { 
                    "02",
                    "Ashanti"
                },
                { 
                    "03",
                    "Brong-Ahafo"
                },
                { 
                    "04",
                    "Central"
                },
                { 
                    "05",
                    "Eastern"
                },
                { 
                    "06",
                    "Northern"
                },
                { 
                    "08",
                    "Volta"
                },
                { 
                    "09",
                    "Western"
                },
                { 
                    "10",
                    "Upper East"
                },
                { 
                    "11",
                    "Upper West"
                }
            };
            RegionName.hashtable_0.Add("GH", hashtable65);
            Hashtable hashtable66 = new Hashtable {
                { 
                    "01",
                    "Nordgronland"
                },
                { 
                    "02",
                    "Ostgronland"
                },
                { 
                    "03",
                    "Vestgronland"
                }
            };
            RegionName.hashtable_0.Add("GL", hashtable66);
            Hashtable hashtable67 = new Hashtable {
                { 
                    "01",
                    "Banjul"
                },
                { 
                    "02",
                    "Lower River"
                },
                { 
                    "03",
                    "Central River"
                },
                { 
                    "04",
                    "Upper River"
                },
                { 
                    "05",
                    "Western"
                },
                { 
                    "07",
                    "North Bank"
                }
            };
            RegionName.hashtable_0.Add("GM", hashtable67);
            Hashtable hashtable68 = new Hashtable {
                { 
                    "01",
                    "Beyla"
                },
                { 
                    "02",
                    "Boffa"
                },
                { 
                    "03",
                    "Boke"
                },
                { 
                    "04",
                    "Conakry"
                },
                { 
                    "05",
                    "Dabola"
                },
                { 
                    "06",
                    "Dalaba"
                },
                { 
                    "07",
                    "Dinguiraye"
                },
                { 
                    "09",
                    "Faranah"
                },
                { 
                    "10",
                    "Forecariah"
                },
                { 
                    "11",
                    "Fria"
                },
                { 
                    "12",
                    "Gaoual"
                },
                { 
                    "13",
                    "Gueckedou"
                },
                { 
                    "15",
                    "Kerouane"
                },
                { 
                    "16",
                    "Kindia"
                },
                { 
                    "17",
                    "Kissidougou"
                },
                { 
                    "18",
                    "Koundara"
                },
                { 
                    "19",
                    "Kouroussa"
                },
                { 
                    "21",
                    "Macenta"
                },
                { 
                    "22",
                    "Mali"
                },
                { 
                    "23",
                    "Mamou"
                },
                { 
                    "25",
                    "Pita"
                },
                { 
                    "27",
                    "Telimele"
                },
                { 
                    "28",
                    "Tougue"
                },
                { 
                    "29",
                    "Yomou"
                },
                { 
                    "30",
                    "Coyah"
                },
                { 
                    "31",
                    "Dubreka"
                },
                { 
                    "32",
                    "Kankan"
                },
                { 
                    "33",
                    "Koubia"
                },
                { 
                    "34",
                    "Labe"
                },
                { 
                    "35",
                    "Lelouma"
                },
                { 
                    "36",
                    "Lola"
                },
                { 
                    "37",
                    "Mandiana"
                },
                { 
                    "38",
                    "Nzerekore"
                },
                { 
                    "39",
                    "Siguiri"
                }
            };
            RegionName.hashtable_0.Add("GN", hashtable68);
            Hashtable hashtable69 = new Hashtable {
                { 
                    "03",
                    "Annobon"
                },
                { 
                    "04",
                    "Bioko Norte"
                },
                { 
                    "05",
                    "Bioko Sur"
                },
                { 
                    "06",
                    "Centro Sur"
                },
                { 
                    "07",
                    "Kie-Ntem"
                },
                { 
                    "08",
                    "Litoral"
                },
                { 
                    "09",
                    "Wele-Nzas"
                }
            };
            RegionName.hashtable_0.Add("GQ", hashtable69);
            Hashtable hashtable70 = new Hashtable {
                { 
                    "01",
                    "Evros"
                },
                { 
                    "02",
                    "Rodhopi"
                },
                { 
                    "03",
                    "Xanthi"
                },
                { 
                    "04",
                    "Drama"
                },
                { 
                    "05",
                    "Serrai"
                },
                { 
                    "06",
                    "Kilkis"
                },
                { 
                    "07",
                    "Pella"
                },
                { 
                    "08",
                    "Florina"
                },
                { 
                    "09",
                    "Kastoria"
                },
                { 
                    "10",
                    "Grevena"
                },
                { 
                    "11",
                    "Kozani"
                },
                { 
                    "12",
                    "Imathia"
                },
                { 
                    "13",
                    "Thessaloniki"
                },
                { 
                    "14",
                    "Kavala"
                },
                { 
                    "15",
                    "Khalkidhiki"
                },
                { 
                    "16",
                    "Pieria"
                },
                { 
                    "17",
                    "Ioannina"
                },
                { 
                    "18",
                    "Thesprotia"
                },
                { 
                    "19",
                    "Preveza"
                },
                { 
                    "20",
                    "Arta"
                },
                { 
                    "21",
                    "Larisa"
                },
                { 
                    "22",
                    "Trikala"
                },
                { 
                    "23",
                    "Kardhitsa"
                },
                { 
                    "24",
                    "Magnisia"
                },
                { 
                    "25",
                    "Kerkira"
                },
                { 
                    "26",
                    "Levkas"
                },
                { 
                    "27",
                    "Kefallinia"
                },
                { 
                    "28",
                    "Zakinthos"
                },
                { 
                    "29",
                    "Fthiotis"
                },
                { 
                    "30",
                    "Evritania"
                },
                { 
                    "31",
                    "Aitolia kai Akarnania"
                },
                { 
                    "32",
                    "Fokis"
                },
                { 
                    "33",
                    "Voiotia"
                },
                { 
                    "34",
                    "Evvoia"
                },
                { 
                    "35",
                    "Attiki"
                },
                { 
                    "36",
                    "Argolis"
                },
                { 
                    "37",
                    "Korinthia"
                },
                { 
                    "38",
                    "Akhaia"
                },
                { 
                    "39",
                    "Ilia"
                },
                { 
                    "40",
                    "Messinia"
                },
                { 
                    "41",
                    "Arkadhia"
                },
                { 
                    "42",
                    "Lakonia"
                },
                { 
                    "43",
                    "Khania"
                },
                { 
                    "44",
                    "Rethimni"
                },
                { 
                    "45",
                    "Iraklion"
                },
                { 
                    "46",
                    "Lasithi"
                },
                { 
                    "47",
                    "Dhodhekanisos"
                },
                { 
                    "48",
                    "Samos"
                },
                { 
                    "49",
                    "Kikladhes"
                },
                { 
                    "50",
                    "Khios"
                },
                { 
                    "51",
                    "Lesvos"
                }
            };
            RegionName.hashtable_0.Add("GR", hashtable70);
            Hashtable hashtable71 = new Hashtable {
                { 
                    "01",
                    "Alta Verapaz"
                },
                { 
                    "02",
                    "Baja Verapaz"
                },
                { 
                    "03",
                    "Chimaltenango"
                },
                { 
                    "04",
                    "Chiquimula"
                },
                { 
                    "05",
                    "El Progreso"
                },
                { 
                    "06",
                    "Escuintla"
                },
                { 
                    "07",
                    "Guatemala"
                },
                { 
                    "08",
                    "Huehuetenango"
                },
                { 
                    "09",
                    "Izabal"
                },
                { 
                    "10",
                    "Jalapa"
                },
                { 
                    "11",
                    "Jutiapa"
                },
                { 
                    "12",
                    "Peten"
                },
                { 
                    "13",
                    "Quetzaltenango"
                },
                { 
                    "14",
                    "Quiche"
                },
                { 
                    "15",
                    "Retalhuleu"
                },
                { 
                    "16",
                    "Sacatepequez"
                },
                { 
                    "17",
                    "San Marcos"
                },
                { 
                    "18",
                    "Santa Rosa"
                },
                { 
                    "19",
                    "Solola"
                },
                { 
                    "20",
                    "Suchitepequez"
                },
                { 
                    "21",
                    "Totonicapan"
                },
                { 
                    "22",
                    "Zacapa"
                }
            };
            RegionName.hashtable_0.Add("GT", hashtable71);
            Hashtable hashtable72 = new Hashtable {
                { 
                    "01",
                    "Bafata"
                },
                { 
                    "02",
                    "Quinara"
                },
                { 
                    "04",
                    "Oio"
                },
                { 
                    "05",
                    "Bolama"
                },
                { 
                    "06",
                    "Cacheu"
                },
                { 
                    "07",
                    "Tombali"
                },
                { 
                    "10",
                    "Gabu"
                },
                { 
                    "11",
                    "Bissau"
                },
                { 
                    "12",
                    "Biombo"
                }
            };
            RegionName.hashtable_0.Add("GW", hashtable72);
            Hashtable hashtable73 = new Hashtable {
                { 
                    "10",
                    "Barima-Waini"
                },
                { 
                    "11",
                    "Cuyuni-Mazaruni"
                },
                { 
                    "12",
                    "Demerara-Mahaica"
                },
                { 
                    "13",
                    "East Berbice-Corentyne"
                },
                { 
                    "14",
                    "Essequibo Islands-West Demerara"
                },
                { 
                    "15",
                    "Mahaica-Berbice"
                },
                { 
                    "16",
                    "Pomeroon-Supenaam"
                },
                { 
                    "17",
                    "Potaro-Siparuni"
                },
                { 
                    "18",
                    "Upper Demerara-Berbice"
                },
                { 
                    "19",
                    "Upper Takutu-Upper Essequibo"
                }
            };
            RegionName.hashtable_0.Add("GY", hashtable73);
            Hashtable hashtable74 = new Hashtable {
                { 
                    "01",
                    "Atlantida"
                },
                { 
                    "02",
                    "Choluteca"
                },
                { 
                    "03",
                    "Colon"
                },
                { 
                    "04",
                    "Comayagua"
                },
                { 
                    "05",
                    "Copan"
                },
                { 
                    "06",
                    "Cortes"
                },
                { 
                    "07",
                    "El Paraiso"
                },
                { 
                    "08",
                    "Francisco Morazan"
                },
                { 
                    "09",
                    "Gracias a Dios"
                },
                { 
                    "10",
                    "Intibuca"
                },
                { 
                    "11",
                    "Islas de la Bahia"
                },
                { 
                    "12",
                    "La Paz"
                },
                { 
                    "13",
                    "Lempira"
                },
                { 
                    "14",
                    "Ocotepeque"
                },
                { 
                    "15",
                    "Olancho"
                },
                { 
                    "16",
                    "Santa Barbara"
                },
                { 
                    "17",
                    "Valle"
                },
                { 
                    "18",
                    "Yoro"
                }
            };
            RegionName.hashtable_0.Add("HN", hashtable74);
            Hashtable hashtable75 = new Hashtable {
                { 
                    "01",
                    "Bjelovarsko-Bilogorska"
                },
                { 
                    "02",
                    "Brodsko-Posavska"
                },
                { 
                    "03",
                    "Dubrovacko-Neretvanska"
                },
                { 
                    "04",
                    "Istarska"
                },
                { 
                    "05",
                    "Karlovacka"
                },
                { 
                    "06",
                    "Koprivnicko-Krizevacka"
                },
                { 
                    "07",
                    "Krapinsko-Zagorska"
                },
                { 
                    "08",
                    "Licko-Senjska"
                },
                { 
                    "09",
                    "Medimurska"
                },
                { 
                    "10",
                    "Osjecko-Baranjska"
                },
                { 
                    "11",
                    "Pozesko-Slavonska"
                },
                { 
                    "12",
                    "Primorsko-Goranska"
                },
                { 
                    "13",
                    "Sibensko-Kninska"
                },
                { 
                    "14",
                    "Sisacko-Moslavacka"
                },
                { 
                    "15",
                    "Splitsko-Dalmatinska"
                },
                { 
                    "16",
                    "Varazdinska"
                },
                { 
                    "17",
                    "Viroviticko-Podravska"
                },
                { 
                    "18",
                    "Vukovarsko-Srijemska"
                },
                { 
                    "19",
                    "Zadarska"
                },
                { 
                    "20",
                    "Zagrebacka"
                },
                { 
                    "21",
                    "Grad Zagreb"
                }
            };
            RegionName.hashtable_0.Add("HR", hashtable75);
            Hashtable hashtable76 = new Hashtable {
                { 
                    "03",
                    "Nord-Ouest"
                },
                { 
                    "06",
                    "Artibonite"
                },
                { 
                    "07",
                    "Centre"
                },
                { 
                    "09",
                    "Nord"
                },
                { 
                    "10",
                    "Nord-Est"
                },
                { 
                    "11",
                    "Ouest"
                },
                { 
                    "12",
                    "Sud"
                },
                { 
                    "13",
                    "Sud-Est"
                },
                { 
                    "14",
                    "Grand' Anse"
                },
                { 
                    "15",
                    "Nippes"
                }
            };
            RegionName.hashtable_0.Add("HT", hashtable76);
            Hashtable hashtable77 = new Hashtable {
                { 
                    "01",
                    "Bacs-Kiskun"
                },
                { 
                    "02",
                    "Baranya"
                },
                { 
                    "03",
                    "Bekes"
                },
                { 
                    "04",
                    "Borsod-Abauj-Zemplen"
                },
                { 
                    "05",
                    "Budapest"
                },
                { 
                    "06",
                    "Csongrad"
                },
                { 
                    "07",
                    "Debrecen"
                },
                { 
                    "08",
                    "Fejer"
                },
                { 
                    "09",
                    "Gyor-Moson-Sopron"
                },
                { 
                    "10",
                    "Hajdu-Bihar"
                },
                { 
                    "11",
                    "Heves"
                },
                { 
                    "12",
                    "Komarom-Esztergom"
                },
                { 
                    "13",
                    "Miskolc"
                },
                { 
                    "14",
                    "Nograd"
                },
                { 
                    "15",
                    "Pecs"
                },
                { 
                    "16",
                    "Pest"
                },
                { 
                    "17",
                    "Somogy"
                },
                { 
                    "18",
                    "Szabolcs-Szatmar-Bereg"
                },
                { 
                    "19",
                    "Szeged"
                },
                { 
                    "20",
                    "Jasz-Nagykun-Szolnok"
                },
                { 
                    "21",
                    "Tolna"
                },
                { 
                    "22",
                    "Vas"
                },
                { 
                    "23",
                    "Veszprem"
                },
                { 
                    "24",
                    "Zala"
                },
                { 
                    "25",
                    "Gyor"
                },
                { 
                    "26",
                    "Bekescsaba"
                },
                { 
                    "27",
                    "Dunaujvaros"
                },
                { 
                    "28",
                    "Eger"
                },
                { 
                    "29",
                    "Hodmezovasarhely"
                },
                { 
                    "30",
                    "Kaposvar"
                },
                { 
                    "31",
                    "Kecskemet"
                },
                { 
                    "32",
                    "Nagykanizsa"
                },
                { 
                    "33",
                    "Nyiregyhaza"
                },
                { 
                    "34",
                    "Sopron"
                },
                { 
                    "35",
                    "Szekesfehervar"
                },
                { 
                    "36",
                    "Szolnok"
                },
                { 
                    "37",
                    "Szombathely"
                },
                { 
                    "38",
                    "Tatabanya"
                },
                { 
                    "39",
                    "Veszprem"
                },
                { 
                    "40",
                    "Zalaegerszeg"
                },
                { 
                    "41",
                    "Salgotarjan"
                },
                { 
                    "42",
                    "Szekszard"
                },
                { 
                    "43",
                    "Erd"
                }
            };
            RegionName.hashtable_0.Add("HU", hashtable77);
            Hashtable hashtable78 = new Hashtable {
                { 
                    "01",
                    "Aceh"
                },
                { 
                    "02",
                    "Bali"
                },
                { 
                    "03",
                    "Bengkulu"
                },
                { 
                    "04",
                    "Jakarta Raya"
                },
                { 
                    "05",
                    "Jambi"
                },
                { 
                    "07",
                    "Jawa Tengah"
                },
                { 
                    "08",
                    "Jawa Timur"
                },
                { 
                    "10",
                    "Yogyakarta"
                },
                { 
                    "11",
                    "Kalimantan Barat"
                },
                { 
                    "12",
                    "Kalimantan Selatan"
                },
                { 
                    "13",
                    "Kalimantan Tengah"
                },
                { 
                    "14",
                    "Kalimantan Timur"
                },
                { 
                    "15",
                    "Lampung"
                },
                { 
                    "17",
                    "Nusa Tenggara Barat"
                },
                { 
                    "18",
                    "Nusa Tenggara Timur"
                },
                { 
                    "21",
                    "Sulawesi Tengah"
                },
                { 
                    "22",
                    "Sulawesi Tenggara"
                },
                { 
                    "24",
                    "Sumatera Barat"
                },
                { 
                    "26",
                    "Sumatera Utara"
                },
                { 
                    "28",
                    "Maluku"
                },
                { 
                    "29",
                    "Maluku Utara"
                },
                { 
                    "30",
                    "Jawa Barat"
                },
                { 
                    "31",
                    "Sulawesi Utara"
                },
                { 
                    "32",
                    "Sumatera Selatan"
                },
                { 
                    "33",
                    "Banten"
                },
                { 
                    "34",
                    "Gorontalo"
                },
                { 
                    "35",
                    "Kepulauan Bangka Belitung"
                },
                { 
                    "36",
                    "Papua"
                },
                { 
                    "37",
                    "Riau"
                },
                { 
                    "38",
                    "Sulawesi Selatan"
                },
                { 
                    "39",
                    "Irian Jaya Barat"
                },
                { 
                    "40",
                    "Kepulauan Riau"
                },
                { 
                    "41",
                    "Sulawesi Barat"
                }
            };
            RegionName.hashtable_0.Add("ID", hashtable78);
            Hashtable hashtable79 = new Hashtable {
                { 
                    "01",
                    "Carlow"
                },
                { 
                    "02",
                    "Cavan"
                },
                { 
                    "03",
                    "Clare"
                },
                { 
                    "04",
                    "Cork"
                },
                { 
                    "06",
                    "Donegal"
                },
                { 
                    "07",
                    "Dublin"
                },
                { 
                    "10",
                    "Galway"
                },
                { 
                    "11",
                    "Kerry"
                },
                { 
                    "12",
                    "Kildare"
                },
                { 
                    "13",
                    "Kilkenny"
                },
                { 
                    "14",
                    "Leitrim"
                },
                { 
                    "15",
                    "Laois"
                },
                { 
                    "16",
                    "Limerick"
                },
                { 
                    "18",
                    "Longford"
                },
                { 
                    "19",
                    "Louth"
                },
                { 
                    "20",
                    "Mayo"
                },
                { 
                    "21",
                    "Meath"
                },
                { 
                    "22",
                    "Monaghan"
                },
                { 
                    "23",
                    "Offaly"
                },
                { 
                    "24",
                    "Roscommon"
                },
                { 
                    "25",
                    "Sligo"
                },
                { 
                    "26",
                    "Tipperary"
                },
                { 
                    "27",
                    "Waterford"
                },
                { 
                    "29",
                    "Westmeath"
                },
                { 
                    "30",
                    "Wexford"
                },
                { 
                    "31",
                    "Wicklow"
                }
            };
            RegionName.hashtable_0.Add("IE", hashtable79);
            Hashtable hashtable80 = new Hashtable {
                { 
                    "01",
                    "HaDarom"
                },
                { 
                    "02",
                    "HaMerkaz"
                },
                { 
                    "03",
                    "HaZafon"
                },
                { 
                    "04",
                    "Hefa"
                },
                { 
                    "05",
                    "Tel Aviv"
                },
                { 
                    "06",
                    "Yerushalayim"
                }
            };
            RegionName.hashtable_0.Add("IL", hashtable80);
            Hashtable hashtable81 = new Hashtable {
                { 
                    "01",
                    "Andaman and Nicobar Islands"
                },
                { 
                    "02",
                    "Andhra Pradesh"
                },
                { 
                    "03",
                    "Assam"
                },
                { 
                    "05",
                    "Chandigarh"
                },
                { 
                    "06",
                    "Dadra and Nagar Haveli"
                },
                { 
                    "07",
                    "Delhi"
                },
                { 
                    "09",
                    "Gujarat"
                },
                { 
                    "10",
                    "Haryana"
                },
                { 
                    "11",
                    "Himachal Pradesh"
                },
                { 
                    "12",
                    "Jammu and Kashmir"
                },
                { 
                    "13",
                    "Kerala"
                },
                { 
                    "14",
                    "Lakshadweep"
                },
                { 
                    "16",
                    "Maharashtra"
                },
                { 
                    "17",
                    "Manipur"
                },
                { 
                    "18",
                    "Meghalaya"
                },
                { 
                    "19",
                    "Karnataka"
                },
                { 
                    "20",
                    "Nagaland"
                },
                { 
                    "21",
                    "Orissa"
                },
                { 
                    "22",
                    "Puducherry"
                },
                { 
                    "23",
                    "Punjab"
                },
                { 
                    "24",
                    "Rajasthan"
                },
                { 
                    "25",
                    "Tamil Nadu"
                },
                { 
                    "26",
                    "Tripura"
                },
                { 
                    "28",
                    "West Bengal"
                },
                { 
                    "29",
                    "Sikkim"
                },
                { 
                    "30",
                    "Arunachal Pradesh"
                },
                { 
                    "31",
                    "Mizoram"
                },
                { 
                    "32",
                    "Daman and Diu"
                },
                { 
                    "33",
                    "Goa"
                },
                { 
                    "34",
                    "Bihar"
                },
                { 
                    "35",
                    "Madhya Pradesh"
                },
                { 
                    "36",
                    "Uttar Pradesh"
                },
                { 
                    "37",
                    "Chhattisgarh"
                },
                { 
                    "38",
                    "Jharkhand"
                },
                { 
                    "39",
                    "Uttarakhand"
                }
            };
            RegionName.hashtable_0.Add("IN", hashtable81);
            Hashtable hashtable82 = new Hashtable {
                { 
                    "01",
                    "Al Anbar"
                },
                { 
                    "02",
                    "Al Basrah"
                },
                { 
                    "03",
                    "Al Muthanna"
                },
                { 
                    "04",
                    "Al Qadisiyah"
                },
                { 
                    "05",
                    "As Sulaymaniyah"
                },
                { 
                    "06",
                    "Babil"
                },
                { 
                    "07",
                    "Baghdad"
                },
                { 
                    "08",
                    "Dahuk"
                },
                { 
                    "09",
                    "Dhi Qar"
                },
                { 
                    "10",
                    "Diyala"
                },
                { 
                    "11",
                    "Arbil"
                },
                { 
                    "12",
                    "Karbala'"
                },
                { 
                    "13",
                    "At Ta'mim"
                },
                { 
                    "14",
                    "Maysan"
                },
                { 
                    "15",
                    "Ninawa"
                },
                { 
                    "16",
                    "Wasit"
                },
                { 
                    "17",
                    "An Najaf"
                },
                { 
                    "18",
                    "Salah ad Din"
                }
            };
            RegionName.hashtable_0.Add("IQ", hashtable82);
            Hashtable hashtable83 = new Hashtable {
                { 
                    "01",
                    "Azarbayjan-e Bakhtari"
                },
                { 
                    "03",
                    "Chahar Mahall va Bakhtiari"
                },
                { 
                    "04",
                    "Sistan va Baluchestan"
                },
                { 
                    "05",
                    "Kohkiluyeh va Buyer Ahmadi"
                },
                { 
                    "07",
                    "Fars"
                },
                { 
                    "08",
                    "Gilan"
                },
                { 
                    "09",
                    "Hamadan"
                },
                { 
                    "10",
                    "Ilam"
                },
                { 
                    "11",
                    "Hormozgan"
                },
                { 
                    "12",
                    "Kerman"
                },
                { 
                    "13",
                    "Bakhtaran"
                },
                { 
                    "15",
                    "Khuzestan"
                },
                { 
                    "16",
                    "Kordestan"
                },
                { 
                    "17",
                    "Mazandaran"
                },
                { 
                    "18",
                    "Semnan Province"
                },
                { 
                    "19",
                    "Markazi"
                },
                { 
                    "21",
                    "Zanjan"
                },
                { 
                    "22",
                    "Bushehr"
                },
                { 
                    "23",
                    "Lorestan"
                },
                { 
                    "24",
                    "Markazi"
                },
                { 
                    "25",
                    "Semnan"
                },
                { 
                    "26",
                    "Tehran"
                },
                { 
                    "27",
                    "Zanjan"
                },
                { 
                    "28",
                    "Esfahan"
                },
                { 
                    "29",
                    "Kerman"
                },
                { 
                    "30",
                    "Khorasan"
                },
                { 
                    "31",
                    "Yazd"
                },
                { 
                    "32",
                    "Ardabil"
                },
                { 
                    "33",
                    "East Azarbaijan"
                },
                { 
                    "34",
                    "Markazi"
                },
                { 
                    "35",
                    "Mazandaran"
                },
                { 
                    "36",
                    "Zanjan"
                },
                { 
                    "37",
                    "Golestan"
                },
                { 
                    "38",
                    "Qazvin"
                },
                { 
                    "39",
                    "Qom"
                },
                { 
                    "40",
                    "Yazd"
                },
                { 
                    "41",
                    "Khorasan-e Janubi"
                },
                { 
                    "42",
                    "Khorasan-e Razavi"
                },
                { 
                    "43",
                    "Khorasan-e Shemali"
                }
            };
            RegionName.hashtable_0.Add("IR", hashtable83);
            Hashtable hashtable84 = new Hashtable {
                { 
                    "03",
                    "Arnessysla"
                },
                { 
                    "05",
                    "Austur-Hunavatnssysla"
                },
                { 
                    "06",
                    "Austur-Skaftafellssysla"
                },
                { 
                    "07",
                    "Borgarfjardarsysla"
                },
                { 
                    "09",
                    "Eyjafjardarsysla"
                },
                { 
                    "10",
                    "Gullbringusysla"
                },
                { 
                    "15",
                    "Kjosarsysla"
                },
                { 
                    "17",
                    "Myrasysla"
                },
                { 
                    "20",
                    "Nordur-Mulasysla"
                },
                { 
                    "21",
                    "Nordur-Tingeyjarsysla"
                },
                { 
                    "23",
                    "Rangarvallasysla"
                },
                { 
                    "28",
                    "Skagafjardarsysla"
                },
                { 
                    "29",
                    "Snafellsnes- og Hnappadalssysla"
                },
                { 
                    "30",
                    "Strandasysla"
                },
                { 
                    "31",
                    "Sudur-Mulasysla"
                },
                { 
                    "32",
                    "Sudur-Tingeyjarsysla"
                },
                { 
                    "34",
                    "Vestur-Bardastrandarsysla"
                },
                { 
                    "35",
                    "Vestur-Hunavatnssysla"
                },
                { 
                    "36",
                    "Vestur-Isafjardarsysla"
                },
                { 
                    "37",
                    "Vestur-Skaftafellssysla"
                },
                { 
                    "40",
                    "Norourland Eystra"
                },
                { 
                    "41",
                    "Norourland Vestra"
                },
                { 
                    "42",
                    "Suourland"
                },
                { 
                    "43",
                    "Suournes"
                },
                { 
                    "44",
                    "Vestfiroir"
                },
                { 
                    "45",
                    "Vesturland"
                }
            };
            RegionName.hashtable_0.Add("IS", hashtable84);
            Hashtable hashtable85 = new Hashtable {
                { 
                    "01",
                    "Abruzzi"
                },
                { 
                    "02",
                    "Basilicata"
                },
                { 
                    "03",
                    "Calabria"
                },
                { 
                    "04",
                    "Campania"
                },
                { 
                    "05",
                    "Emilia-Romagna"
                },
                { 
                    "06",
                    "Friuli-Venezia Giulia"
                },
                { 
                    "07",
                    "Lazio"
                },
                { 
                    "08",
                    "Liguria"
                },
                { 
                    "09",
                    "Lombardia"
                },
                { 
                    "10",
                    "Marche"
                },
                { 
                    "11",
                    "Molise"
                },
                { 
                    "12",
                    "Piemonte"
                },
                { 
                    "13",
                    "Puglia"
                },
                { 
                    "14",
                    "Sardegna"
                },
                { 
                    "15",
                    "Sicilia"
                },
                { 
                    "16",
                    "Toscana"
                },
                { 
                    "17",
                    "Trentino-Alto Adige"
                },
                { 
                    "18",
                    "Umbria"
                },
                { 
                    "19",
                    "Valle d'Aosta"
                },
                { 
                    "20",
                    "Veneto"
                }
            };
            RegionName.hashtable_0.Add("IT", hashtable85);
            Hashtable hashtable86 = new Hashtable {
                { 
                    "01",
                    "Clarendon"
                },
                { 
                    "02",
                    "Hanover"
                },
                { 
                    "04",
                    "Manchester"
                },
                { 
                    "07",
                    "Portland"
                },
                { 
                    "08",
                    "Saint Andrew"
                },
                { 
                    "09",
                    "Saint Ann"
                },
                { 
                    "10",
                    "Saint Catherine"
                },
                { 
                    "11",
                    "Saint Elizabeth"
                },
                { 
                    "12",
                    "Saint James"
                },
                { 
                    "13",
                    "Saint Mary"
                },
                { 
                    "14",
                    "Saint Thomas"
                },
                { 
                    "15",
                    "Trelawny"
                },
                { 
                    "16",
                    "Westmoreland"
                },
                { 
                    "17",
                    "Kingston"
                }
            };
            RegionName.hashtable_0.Add("JM", hashtable86);
            Hashtable hashtable87 = new Hashtable {
                { 
                    "02",
                    "Al Balqa'"
                },
                { 
                    "09",
                    "Al Karak"
                },
                { 
                    "12",
                    "At Tafilah"
                },
                { 
                    "15",
                    "Al Mafraq"
                },
                { 
                    "16",
                    "Amman"
                },
                { 
                    "17",
                    "Az Zaraqa"
                },
                { 
                    "18",
                    "Irbid"
                },
                { 
                    "19",
                    "Ma'an"
                },
                { 
                    "20",
                    "Ajlun"
                },
                { 
                    "21",
                    "Al Aqabah"
                },
                { 
                    "22",
                    "Jarash"
                },
                { 
                    "23",
                    "Madaba"
                }
            };
            RegionName.hashtable_0.Add("JO", hashtable87);
            Hashtable hashtable88 = new Hashtable {
                { 
                    "01",
                    "Aichi"
                },
                { 
                    "02",
                    "Akita"
                },
                { 
                    "03",
                    "Aomori"
                },
                { 
                    "04",
                    "Chiba"
                },
                { 
                    "05",
                    "Ehime"
                },
                { 
                    "06",
                    "Fukui"
                },
                { 
                    "07",
                    "Fukuoka"
                },
                { 
                    "08",
                    "Fukushima"
                },
                { 
                    "09",
                    "Gifu"
                },
                { 
                    "10",
                    "Gumma"
                },
                { 
                    "11",
                    "Hiroshima"
                },
                { 
                    "12",
                    "Hokkaido"
                },
                { 
                    "13",
                    "Hyogo"
                },
                { 
                    "14",
                    "Ibaraki"
                },
                { 
                    "15",
                    "Ishikawa"
                },
                { 
                    "16",
                    "Iwate"
                },
                { 
                    "17",
                    "Kagawa"
                },
                { 
                    "18",
                    "Kagoshima"
                },
                { 
                    "19",
                    "Kanagawa"
                },
                { 
                    "20",
                    "Kochi"
                },
                { 
                    "21",
                    "Kumamoto"
                },
                { 
                    "22",
                    "Kyoto"
                },
                { 
                    "23",
                    "Mie"
                },
                { 
                    "24",
                    "Miyagi"
                },
                { 
                    "25",
                    "Miyazaki"
                },
                { 
                    "26",
                    "Nagano"
                },
                { 
                    "27",
                    "Nagasaki"
                },
                { 
                    "28",
                    "Nara"
                },
                { 
                    "29",
                    "Niigata"
                },
                { 
                    "30",
                    "Oita"
                },
                { 
                    "31",
                    "Okayama"
                },
                { 
                    "32",
                    "Osaka"
                },
                { 
                    "33",
                    "Saga"
                },
                { 
                    "34",
                    "Saitama"
                },
                { 
                    "35",
                    "Shiga"
                },
                { 
                    "36",
                    "Shimane"
                },
                { 
                    "37",
                    "Shizuoka"
                },
                { 
                    "38",
                    "Tochigi"
                },
                { 
                    "39",
                    "Tokushima"
                },
                { 
                    "40",
                    "Tokyo"
                },
                { 
                    "41",
                    "Tottori"
                },
                { 
                    "42",
                    "Toyama"
                },
                { 
                    "43",
                    "Wakayama"
                },
                { 
                    "44",
                    "Yamagata"
                },
                { 
                    "45",
                    "Yamaguchi"
                },
                { 
                    "46",
                    "Yamanashi"
                },
                { 
                    "47",
                    "Okinawa"
                }
            };
            RegionName.hashtable_0.Add("JP", hashtable88);
            Hashtable hashtable89 = new Hashtable {
                { 
                    "01",
                    "Central"
                },
                { 
                    "02",
                    "Coast"
                },
                { 
                    "03",
                    "Eastern"
                },
                { 
                    "05",
                    "Nairobi Area"
                },
                { 
                    "06",
                    "North-Eastern"
                },
                { 
                    "07",
                    "Nyanza"
                },
                { 
                    "08",
                    "Rift Valley"
                },
                { 
                    "09",
                    "Western"
                }
            };
            RegionName.hashtable_0.Add("KE", hashtable89);
            Hashtable hashtable90 = new Hashtable {
                { 
                    "01",
                    "Bishkek"
                },
                { 
                    "02",
                    "Chuy"
                },
                { 
                    "03",
                    "Jalal-Abad"
                },
                { 
                    "04",
                    "Naryn"
                },
                { 
                    "05",
                    "Osh"
                },
                { 
                    "06",
                    "Talas"
                },
                { 
                    "07",
                    "Ysyk-Kol"
                },
                { 
                    "08",
                    "Osh"
                },
                { 
                    "09",
                    "Batken"
                }
            };
            RegionName.hashtable_0.Add("KG", hashtable90);
            Hashtable hashtable91 = new Hashtable {
                { 
                    "01",
                    "Batdambang"
                },
                { 
                    "02",
                    "Kampong Cham"
                },
                { 
                    "03",
                    "Kampong Chhnang"
                },
                { 
                    "04",
                    "Kampong Speu"
                },
                { 
                    "05",
                    "Kampong Thum"
                },
                { 
                    "06",
                    "Kampot"
                },
                { 
                    "07",
                    "Kandal"
                },
                { 
                    "08",
                    "Koh Kong"
                },
                { 
                    "09",
                    "Kracheh"
                },
                { 
                    "10",
                    "Mondulkiri"
                },
                { 
                    "11",
                    "Phnum Penh"
                },
                { 
                    "12",
                    "Pursat"
                },
                { 
                    "13",
                    "Preah Vihear"
                },
                { 
                    "14",
                    "Prey Veng"
                },
                { 
                    "15",
                    "Ratanakiri Kiri"
                },
                { 
                    "16",
                    "Siem Reap"
                },
                { 
                    "17",
                    "Stung Treng"
                },
                { 
                    "18",
                    "Svay Rieng"
                },
                { 
                    "19",
                    "Takeo"
                },
                { 
                    "25",
                    "Banteay Meanchey"
                },
                { 
                    "29",
                    "Batdambang"
                },
                { 
                    "30",
                    "Pailin"
                }
            };
            RegionName.hashtable_0.Add("KH", hashtable91);
            Hashtable hashtable92 = new Hashtable {
                { 
                    "01",
                    "Gilbert Islands"
                },
                { 
                    "02",
                    "Line Islands"
                },
                { 
                    "03",
                    "Phoenix Islands"
                }
            };
            RegionName.hashtable_0.Add("KI", hashtable92);
            Hashtable hashtable93 = new Hashtable {
                { 
                    "01",
                    "Anjouan"
                },
                { 
                    "02",
                    "Grande Comore"
                },
                { 
                    "03",
                    "Moheli"
                }
            };
            RegionName.hashtable_0.Add("KM", hashtable93);
            Hashtable hashtable94 = new Hashtable {
                { 
                    "01",
                    "Christ Church Nichola Town"
                },
                { 
                    "02",
                    "Saint Anne Sandy Point"
                },
                { 
                    "03",
                    "Saint George Basseterre"
                },
                { 
                    "04",
                    "Saint George Gingerland"
                },
                { 
                    "05",
                    "Saint James Windward"
                },
                { 
                    "06",
                    "Saint John Capisterre"
                },
                { 
                    "07",
                    "Saint John Figtree"
                },
                { 
                    "08",
                    "Saint Mary Cayon"
                },
                { 
                    "09",
                    "Saint Paul Capisterre"
                },
                { 
                    "10",
                    "Saint Paul Charlestown"
                },
                { 
                    "11",
                    "Saint Peter Basseterre"
                },
                { 
                    "12",
                    "Saint Thomas Lowland"
                },
                { 
                    "13",
                    "Saint Thomas Middle Island"
                },
                { 
                    "15",
                    "Trinity Palmetto Point"
                }
            };
            RegionName.hashtable_0.Add("KN", hashtable94);
            Hashtable hashtable95 = new Hashtable {
                { 
                    "01",
                    "Chagang-do"
                },
                { 
                    "03",
                    "Hamgyong-namdo"
                },
                { 
                    "06",
                    "Hwanghae-namdo"
                },
                { 
                    "07",
                    "Hwanghae-bukto"
                },
                { 
                    "08",
                    "Kaesong-si"
                },
                { 
                    "09",
                    "Kangwon-do"
                },
                { 
                    "11",
                    "P'yongan-bukto"
                },
                { 
                    "12",
                    "P'yongyang-si"
                },
                { 
                    "13",
                    "Yanggang-do"
                },
                { 
                    "14",
                    "Namp'o-si"
                },
                { 
                    "15",
                    "P'yongan-namdo"
                },
                { 
                    "17",
                    "Hamgyong-bukto"
                },
                { 
                    "18",
                    "Najin Sonbong-si"
                }
            };
            RegionName.hashtable_0.Add("KP", hashtable95);
            Hashtable hashtable96 = new Hashtable {
                { 
                    "01",
                    "Cheju-do"
                },
                { 
                    "03",
                    "Cholla-bukto"
                },
                { 
                    "05",
                    "Ch'ungch'ong-bukto"
                },
                { 
                    "06",
                    "Kangwon-do"
                },
                { 
                    "10",
                    "Pusan-jikhalsi"
                },
                { 
                    "11",
                    "Seoul-t'ukpyolsi"
                },
                { 
                    "12",
                    "Inch'on-jikhalsi"
                },
                { 
                    "13",
                    "Kyonggi-do"
                },
                { 
                    "14",
                    "Kyongsang-bukto"
                },
                { 
                    "15",
                    "Taegu-jikhalsi"
                },
                { 
                    "16",
                    "Cholla-namdo"
                },
                { 
                    "17",
                    "Ch'ungch'ong-namdo"
                },
                { 
                    "18",
                    "Kwangju-jikhalsi"
                },
                { 
                    "19",
                    "Taejon-jikhalsi"
                },
                { 
                    "20",
                    "Kyongsang-namdo"
                },
                { 
                    "21",
                    "Ulsan-gwangyoksi"
                }
            };
            RegionName.hashtable_0.Add("KR", hashtable96);
            Hashtable hashtable97 = new Hashtable {
                { 
                    "01",
                    "Al Ahmadi"
                },
                { 
                    "02",
                    "Al Kuwayt"
                },
                { 
                    "05",
                    "Al Jahra"
                },
                { 
                    "07",
                    "Al Farwaniyah"
                },
                { 
                    "08",
                    "Hawalli"
                },
                { 
                    "09",
                    "Mubarak al Kabir"
                }
            };
            RegionName.hashtable_0.Add("KW", hashtable97);
            Hashtable hashtable98 = new Hashtable {
                { 
                    "01",
                    "Creek"
                },
                { 
                    "02",
                    "Eastern"
                },
                { 
                    "03",
                    "Midland"
                },
                { 
                    "04",
                    "South Town"
                },
                { 
                    "05",
                    "Spot Bay"
                },
                { 
                    "06",
                    "Stake Bay"
                },
                { 
                    "07",
                    "West End"
                },
                { 
                    "08",
                    "Western"
                }
            };
            RegionName.hashtable_0.Add("KY", hashtable98);
            Hashtable hashtable99 = new Hashtable {
                { 
                    "01",
                    "Almaty"
                },
                { 
                    "02",
                    "Almaty City"
                },
                { 
                    "03",
                    "Aqmola"
                },
                { 
                    "04",
                    "Aqtobe"
                },
                { 
                    "05",
                    "Astana"
                },
                { 
                    "06",
                    "Atyrau"
                },
                { 
                    "07",
                    "West Kazakhstan"
                },
                { 
                    "08",
                    "Bayqonyr"
                },
                { 
                    "09",
                    "Mangghystau"
                },
                { 
                    "10",
                    "South Kazakhstan"
                },
                { 
                    "11",
                    "Pavlodar"
                },
                { 
                    "12",
                    "Qaraghandy"
                },
                { 
                    "13",
                    "Qostanay"
                },
                { 
                    "14",
                    "Qyzylorda"
                },
                { 
                    "15",
                    "East Kazakhstan"
                },
                { 
                    "16",
                    "North Kazakhstan"
                },
                { 
                    "17",
                    "Zhambyl"
                }
            };
            RegionName.hashtable_0.Add("KZ", hashtable99);
            Hashtable hashtable100 = new Hashtable {
                { 
                    "01",
                    "Attapu"
                },
                { 
                    "02",
                    "Champasak"
                },
                { 
                    "03",
                    "Houaphan"
                },
                { 
                    "04",
                    "Khammouan"
                },
                { 
                    "05",
                    "Louang Namtha"
                },
                { 
                    "07",
                    "Oudomxai"
                },
                { 
                    "08",
                    "Phongsali"
                },
                { 
                    "09",
                    "Saravan"
                },
                { 
                    "10",
                    "Savannakhet"
                },
                { 
                    "11",
                    "Vientiane"
                },
                { 
                    "13",
                    "Xaignabouri"
                },
                { 
                    "14",
                    "Xiangkhoang"
                },
                { 
                    "17",
                    "Louangphrabang"
                }
            };
            RegionName.hashtable_0.Add("LA", hashtable100);
            Hashtable hashtable101 = new Hashtable {
                { 
                    "01",
                    "Beqaa"
                },
                { 
                    "02",
                    "Al Janub"
                },
                { 
                    "03",
                    "Liban-Nord"
                },
                { 
                    "04",
                    "Beyrouth"
                },
                { 
                    "05",
                    "Mont-Liban"
                },
                { 
                    "06",
                    "Liban-Sud"
                },
                { 
                    "07",
                    "Nabatiye"
                },
                { 
                    "08",
                    "Beqaa"
                },
                { 
                    "09",
                    "Liban-Nord"
                },
                { 
                    "10",
                    "Aakk,r"
                },
                { 
                    "11",
                    "Baalbek-Hermel"
                }
            };
            RegionName.hashtable_0.Add("LB", hashtable101);
            Hashtable hashtable102 = new Hashtable {
                { 
                    "01",
                    "Anse-la-Raye"
                },
                { 
                    "02",
                    "Dauphin"
                },
                { 
                    "03",
                    "Castries"
                },
                { 
                    "04",
                    "Choiseul"
                },
                { 
                    "05",
                    "Dennery"
                },
                { 
                    "06",
                    "Gros-Islet"
                },
                { 
                    "07",
                    "Laborie"
                },
                { 
                    "08",
                    "Micoud"
                },
                { 
                    "09",
                    "Soufriere"
                },
                { 
                    "10",
                    "Vieux-Fort"
                },
                { 
                    "11",
                    "Praslin"
                }
            };
            RegionName.hashtable_0.Add("LC", hashtable102);
            Hashtable hashtable103 = new Hashtable {
                { 
                    "01",
                    "Balzers"
                },
                { 
                    "02",
                    "Eschen"
                },
                { 
                    "03",
                    "Gamprin"
                },
                { 
                    "04",
                    "Mauren"
                },
                { 
                    "05",
                    "Planken"
                },
                { 
                    "06",
                    "Ruggell"
                },
                { 
                    "07",
                    "Schaan"
                },
                { 
                    "08",
                    "Schellenberg"
                },
                { 
                    "09",
                    "Triesen"
                },
                { 
                    "10",
                    "Triesenberg"
                },
                { 
                    "11",
                    "Vaduz"
                },
                { 
                    "21",
                    "Gbarpolu"
                },
                { 
                    "22",
                    "River Gee"
                }
            };
            RegionName.hashtable_0.Add("LI", hashtable103);
            Hashtable hashtable104 = new Hashtable {
                { 
                    "01",
                    "Amparai"
                },
                { 
                    "02",
                    "Anuradhapura"
                },
                { 
                    "03",
                    "Badulla"
                },
                { 
                    "04",
                    "Batticaloa"
                },
                { 
                    "06",
                    "Galle"
                },
                { 
                    "07",
                    "Hambantota"
                },
                { 
                    "09",
                    "Kalutara"
                },
                { 
                    "10",
                    "Kandy"
                },
                { 
                    "11",
                    "Kegalla"
                },
                { 
                    "12",
                    "Kurunegala"
                },
                { 
                    "14",
                    "Matale"
                },
                { 
                    "15",
                    "Matara"
                },
                { 
                    "16",
                    "Moneragala"
                },
                { 
                    "17",
                    "Nuwara Eliya"
                },
                { 
                    "18",
                    "Polonnaruwa"
                },
                { 
                    "19",
                    "Puttalam"
                },
                { 
                    "20",
                    "Ratnapura"
                },
                { 
                    "21",
                    "Trincomalee"
                },
                { 
                    "23",
                    "Colombo"
                },
                { 
                    "24",
                    "Gampaha"
                },
                { 
                    "25",
                    "Jaffna"
                },
                { 
                    "26",
                    "Mannar"
                },
                { 
                    "27",
                    "Mullaittivu"
                },
                { 
                    "28",
                    "Vavuniya"
                },
                { 
                    "29",
                    "Central"
                },
                { 
                    "30",
                    "North Central"
                },
                { 
                    "31",
                    "Northern"
                },
                { 
                    "32",
                    "North Western"
                },
                { 
                    "33",
                    "Sabaragamuwa"
                },
                { 
                    "34",
                    "Southern"
                },
                { 
                    "35",
                    "Uva"
                },
                { 
                    "36",
                    "Western"
                }
            };
            RegionName.hashtable_0.Add("LK", hashtable104);
            Hashtable hashtable105 = new Hashtable {
                { 
                    "01",
                    "Bong"
                },
                { 
                    "04",
                    "Grand Cape Mount"
                },
                { 
                    "05",
                    "Lofa"
                },
                { 
                    "06",
                    "Maryland"
                },
                { 
                    "07",
                    "Monrovia"
                },
                { 
                    "09",
                    "Nimba"
                },
                { 
                    "10",
                    "Sino"
                },
                { 
                    "11",
                    "Grand Bassa"
                },
                { 
                    "12",
                    "Grand Cape Mount"
                },
                { 
                    "13",
                    "Maryland"
                },
                { 
                    "14",
                    "Montserrado"
                },
                { 
                    "17",
                    "Margibi"
                },
                { 
                    "18",
                    "River Cess"
                },
                { 
                    "19",
                    "Grand Gedeh"
                },
                { 
                    "20",
                    "Lofa"
                },
                { 
                    "21",
                    "Gbarpolu"
                },
                { 
                    "22",
                    "River Gee"
                }
            };
            RegionName.hashtable_0.Add("LR", hashtable105);
            Hashtable hashtable106 = new Hashtable {
                { 
                    "10",
                    "Berea"
                },
                { 
                    "11",
                    "Butha-Buthe"
                },
                { 
                    "12",
                    "Leribe"
                },
                { 
                    "13",
                    "Mafeteng"
                },
                { 
                    "14",
                    "Maseru"
                },
                { 
                    "15",
                    "Mohales Hoek"
                },
                { 
                    "16",
                    "Mokhotlong"
                },
                { 
                    "17",
                    "Qachas Nek"
                },
                { 
                    "18",
                    "Quthing"
                },
                { 
                    "19",
                    "Thaba-Tseka"
                }
            };
            RegionName.hashtable_0.Add("LS", hashtable106);
            Hashtable hashtable107 = new Hashtable {
                { 
                    "56",
                    "Alytaus Apskritis"
                },
                { 
                    "57",
                    "Kauno Apskritis"
                },
                { 
                    "58",
                    "Klaipedos Apskritis"
                },
                { 
                    "59",
                    "Marijampoles Apskritis"
                },
                { 
                    "60",
                    "Panevezio Apskritis"
                },
                { 
                    "61",
                    "Siauliu Apskritis"
                },
                { 
                    "62",
                    "Taurages Apskritis"
                },
                { 
                    "63",
                    "Telsiu Apskritis"
                },
                { 
                    "64",
                    "Utenos Apskritis"
                },
                { 
                    "65",
                    "Vilniaus Apskritis"
                }
            };
            RegionName.hashtable_0.Add("LT", hashtable107);
            Hashtable hashtable108 = new Hashtable {
                { 
                    "01",
                    "Diekirch"
                },
                { 
                    "02",
                    "Grevenmacher"
                },
                { 
                    "03",
                    "Luxembourg"
                }
            };
            RegionName.hashtable_0.Add("LU", hashtable108);
            Hashtable hashtable109 = new Hashtable {
                { 
                    "01",
                    "Aizkraukles"
                },
                { 
                    "02",
                    "Aluksnes"
                },
                { 
                    "03",
                    "Balvu"
                },
                { 
                    "04",
                    "Bauskas"
                },
                { 
                    "05",
                    "Cesu"
                },
                { 
                    "06",
                    "Daugavpils"
                },
                { 
                    "07",
                    "Daugavpils"
                },
                { 
                    "08",
                    "Dobeles"
                },
                { 
                    "09",
                    "Gulbenes"
                },
                { 
                    "10",
                    "Jekabpils"
                },
                { 
                    "11",
                    "Jelgava"
                },
                { 
                    "12",
                    "Jelgavas"
                },
                { 
                    "13",
                    "Jurmala"
                },
                { 
                    "14",
                    "Kraslavas"
                },
                { 
                    "15",
                    "Kuldigas"
                },
                { 
                    "16",
                    "Liepaja"
                },
                { 
                    "17",
                    "Liepajas"
                },
                { 
                    "18",
                    "Limbazu"
                },
                { 
                    "19",
                    "Ludzas"
                },
                { 
                    "20",
                    "Madonas"
                },
                { 
                    "21",
                    "Ogres"
                },
                { 
                    "22",
                    "Preilu"
                },
                { 
                    "23",
                    "Rezekne"
                },
                { 
                    "24",
                    "Rezeknes"
                },
                { 
                    "25",
                    "Riga"
                },
                { 
                    "26",
                    "Rigas"
                },
                { 
                    "27",
                    "Saldus"
                },
                { 
                    "28",
                    "Talsu"
                },
                { 
                    "29",
                    "Tukuma"
                },
                { 
                    "30",
                    "Valkas"
                },
                { 
                    "31",
                    "Valmieras"
                },
                { 
                    "32",
                    "Ventspils"
                },
                { 
                    "33",
                    "Ventspils"
                }
            };
            RegionName.hashtable_0.Add("LV", hashtable109);
            Hashtable hashtable110 = new Hashtable {
                { 
                    "03",
                    "Al Aziziyah"
                },
                { 
                    "05",
                    "Al Jufrah"
                },
                { 
                    "08",
                    "Al Kufrah"
                },
                { 
                    "13",
                    "Ash Shati'"
                },
                { 
                    "30",
                    "Murzuq"
                },
                { 
                    "34",
                    "Sabha"
                },
                { 
                    "41",
                    "Tarhunah"
                },
                { 
                    "42",
                    "Tubruq"
                },
                { 
                    "45",
                    "Zlitan"
                },
                { 
                    "47",
                    "Ajdabiya"
                },
                { 
                    "48",
                    "Al Fatih"
                },
                { 
                    "49",
                    "Al Jabal al Akhdar"
                },
                { 
                    "50",
                    "Al Khums"
                },
                { 
                    "51",
                    "An Nuqat al Khams"
                },
                { 
                    "52",
                    "Awbari"
                },
                { 
                    "53",
                    "Az Zawiyah"
                },
                { 
                    "54",
                    "Banghazi"
                },
                { 
                    "55",
                    "Darnah"
                },
                { 
                    "56",
                    "Ghadamis"
                },
                { 
                    "57",
                    "Gharyan"
                },
                { 
                    "58",
                    "Misratah"
                },
                { 
                    "59",
                    "Sawfajjin"
                },
                { 
                    "60",
                    "Surt"
                },
                { 
                    "61",
                    "Tarabulus"
                },
                { 
                    "62",
                    "Yafran"
                }
            };
            RegionName.hashtable_0.Add("LY", hashtable110);
            Hashtable hashtable111 = new Hashtable {
                { 
                    "45",
                    "Grand Casablanca"
                },
                { 
                    "46",
                    "Fes-Boulemane"
                },
                { 
                    "47",
                    "Marrakech-Tensift-Al Haouz"
                },
                { 
                    "48",
                    "Meknes-Tafilalet"
                },
                { 
                    "49",
                    "Rabat-Sale-Zemmour-Zaer"
                },
                { 
                    "50",
                    "Chaouia-Ouardigha"
                },
                { 
                    "51",
                    "Doukkala-Abda"
                },
                { 
                    "52",
                    "Gharb-Chrarda-Beni Hssen"
                },
                { 
                    "53",
                    "Guelmim-Es Smara"
                },
                { 
                    "54",
                    "Oriental"
                },
                { 
                    "55",
                    "Souss-Massa-Dr,a"
                },
                { 
                    "56",
                    "Tadla-Azilal"
                },
                { 
                    "57",
                    "Tanger-Tetouan"
                },
                { 
                    "58",
                    "Taza-Al Hoceima-Taounate"
                },
                { 
                    "59",
                    "La,youne-Boujdour-Sakia El Hamra"
                }
            };
            RegionName.hashtable_0.Add("MA", hashtable111);
            Hashtable hashtable112 = new Hashtable {
                { 
                    "01",
                    "La Condamine"
                },
                { 
                    "02",
                    "Monaco"
                },
                { 
                    "03",
                    "Monte-Carlo"
                }
            };
            RegionName.hashtable_0.Add("MC", hashtable112);
            Hashtable hashtable113 = new Hashtable {
                { 
                    "51",
                    "Gagauzia"
                },
                { 
                    "57",
                    "Chisinau"
                },
                { 
                    "58",
                    "Stinga Nistrului"
                },
                { 
                    "59",
                    "Anenii Noi"
                },
                { 
                    "60",
                    "Balti"
                },
                { 
                    "61",
                    "Basarabeasca"
                },
                { 
                    "62",
                    "Bender"
                },
                { 
                    "63",
                    "Briceni"
                },
                { 
                    "64",
                    "Cahul"
                },
                { 
                    "65",
                    "Cantemir"
                },
                { 
                    "66",
                    "Calarasi"
                },
                { 
                    "67",
                    "Causeni"
                },
                { 
                    "68",
                    "Cimislia"
                },
                { 
                    "69",
                    "Criuleni"
                },
                { 
                    "70",
                    "Donduseni"
                },
                { 
                    "71",
                    "Drochia"
                },
                { 
                    "72",
                    "Dubasari"
                },
                { 
                    "73",
                    "Edinet"
                },
                { 
                    "74",
                    "Falesti"
                },
                { 
                    "75",
                    "Floresti"
                },
                { 
                    "76",
                    "Glodeni"
                },
                { 
                    "77",
                    "Hincesti"
                },
                { 
                    "78",
                    "Ialoveni"
                },
                { 
                    "79",
                    "Leova"
                },
                { 
                    "80",
                    "Nisporeni"
                },
                { 
                    "81",
                    "Ocnita"
                },
                { 
                    "82",
                    "Orhei"
                },
                { 
                    "83",
                    "Rezina"
                },
                { 
                    "84",
                    "Riscani"
                },
                { 
                    "85",
                    "Singerei"
                },
                { 
                    "86",
                    "Soldanesti"
                },
                { 
                    "87",
                    "Soroca"
                },
                { 
                    "88",
                    "Stefan-Voda"
                },
                { 
                    "89",
                    "Straseni"
                },
                { 
                    "90",
                    "Taraclia"
                },
                { 
                    "91",
                    "Telenesti"
                },
                { 
                    "92",
                    "Ungheni"
                }
            };
            RegionName.hashtable_0.Add("MD", hashtable113);
            Hashtable hashtable114 = new Hashtable {
                { 
                    "01",
                    "Antsiranana"
                },
                { 
                    "02",
                    "Fianarantsoa"
                },
                { 
                    "03",
                    "Mahajanga"
                },
                { 
                    "04",
                    "Toamasina"
                },
                { 
                    "05",
                    "Antananarivo"
                },
                { 
                    "06",
                    "Toliara"
                }
            };
            RegionName.hashtable_0.Add("MG", hashtable114);
            Hashtable hashtable115 = new Hashtable {
                { 
                    "01",
                    "Aracinovo"
                },
                { 
                    "02",
                    "Bac"
                },
                { 
                    "03",
                    "Belcista"
                },
                { 
                    "04",
                    "Berovo"
                },
                { 
                    "05",
                    "Bistrica"
                },
                { 
                    "06",
                    "Bitola"
                },
                { 
                    "07",
                    "Blatec"
                },
                { 
                    "08",
                    "Bogdanci"
                },
                { 
                    "09",
                    "Bogomila"
                },
                { 
                    "10",
                    "Bogovinje"
                },
                { 
                    "11",
                    "Bosilovo"
                },
                { 
                    "12",
                    "Brvenica"
                },
                { 
                    "13",
                    "Cair"
                },
                { 
                    "14",
                    "Capari"
                },
                { 
                    "15",
                    "Caska"
                },
                { 
                    "16",
                    "Cegrane"
                },
                { 
                    "17",
                    "Centar"
                },
                { 
                    "18",
                    "Centar Zupa"
                },
                { 
                    "19",
                    "Cesinovo"
                },
                { 
                    "20",
                    "Cucer-Sandevo"
                },
                { 
                    "21",
                    "Debar"
                },
                { 
                    "22",
                    "Delcevo"
                },
                { 
                    "23",
                    "Delogozdi"
                },
                { 
                    "24",
                    "Demir Hisar"
                },
                { 
                    "25",
                    "Demir Kapija"
                },
                { 
                    "26",
                    "Dobrusevo"
                },
                { 
                    "27",
                    "Dolna Banjica"
                },
                { 
                    "28",
                    "Dolneni"
                },
                { 
                    "29",
                    "Dorce Petrov"
                },
                { 
                    "30",
                    "Drugovo"
                },
                { 
                    "31",
                    "Dzepciste"
                },
                { 
                    "32",
                    "Gazi Baba"
                },
                { 
                    "33",
                    "Gevgelija"
                },
                { 
                    "34",
                    "Gostivar"
                },
                { 
                    "35",
                    "Gradsko"
                },
                { 
                    "36",
                    "Ilinden"
                },
                { 
                    "37",
                    "Izvor"
                },
                { 
                    "38",
                    "Jegunovce"
                },
                { 
                    "39",
                    "Kamenjane"
                },
                { 
                    "40",
                    "Karbinci"
                },
                { 
                    "41",
                    "Karpos"
                },
                { 
                    "42",
                    "Kavadarci"
                },
                { 
                    "43",
                    "Kicevo"
                },
                { 
                    "44",
                    "Kisela Voda"
                },
                { 
                    "45",
                    "Klecevce"
                },
                { 
                    "46",
                    "Kocani"
                },
                { 
                    "47",
                    "Konce"
                },
                { 
                    "48",
                    "Kondovo"
                },
                { 
                    "49",
                    "Konopiste"
                },
                { 
                    "50",
                    "Kosel"
                },
                { 
                    "51",
                    "Kratovo"
                },
                { 
                    "52",
                    "Kriva Palanka"
                },
                { 
                    "53",
                    "Krivogastani"
                },
                { 
                    "54",
                    "Krusevo"
                },
                { 
                    "55",
                    "Kuklis"
                },
                { 
                    "56",
                    "Kukurecani"
                },
                { 
                    "57",
                    "Kumanovo"
                },
                { 
                    "58",
                    "Labunista"
                },
                { 
                    "59",
                    "Lipkovo"
                },
                { 
                    "60",
                    "Lozovo"
                },
                { 
                    "61",
                    "Lukovo"
                },
                { 
                    "62",
                    "Makedonska Kamenica"
                },
                { 
                    "63",
                    "Makedonski Brod"
                },
                { 
                    "64",
                    "Mavrovi Anovi"
                },
                { 
                    "65",
                    "Meseista"
                },
                { 
                    "66",
                    "Miravci"
                },
                { 
                    "67",
                    "Mogila"
                },
                { 
                    "68",
                    "Murtino"
                },
                { 
                    "69",
                    "Negotino"
                },
                { 
                    "70",
                    "Negotino-Polosko"
                },
                { 
                    "71",
                    "Novaci"
                },
                { 
                    "72",
                    "Novo Selo"
                },
                { 
                    "73",
                    "Oblesevo"
                },
                { 
                    "74",
                    "Ohrid"
                },
                { 
                    "75",
                    "Orasac"
                },
                { 
                    "76",
                    "Orizari"
                },
                { 
                    "77",
                    "Oslomej"
                },
                { 
                    "78",
                    "Pehcevo"
                },
                { 
                    "79",
                    "Petrovec"
                },
                { 
                    "80",
                    "Plasnica"
                },
                { 
                    "81",
                    "Podares"
                },
                { 
                    "82",
                    "Prilep"
                },
                { 
                    "83",
                    "Probistip"
                },
                { 
                    "84",
                    "Radovis"
                },
                { 
                    "85",
                    "Rankovce"
                },
                { 
                    "86",
                    "Resen"
                },
                { 
                    "87",
                    "Rosoman"
                },
                { 
                    "88",
                    "Rostusa"
                },
                { 
                    "89",
                    "Samokov"
                },
                { 
                    "90",
                    "Saraj"
                },
                { 
                    "91",
                    "Sipkovica"
                },
                { 
                    "92",
                    "Sopiste"
                },
                { 
                    "93",
                    "Sopotnica"
                },
                { 
                    "94",
                    "Srbinovo"
                },
                { 
                    "95",
                    "Staravina"
                },
                { 
                    "96",
                    "Star Dojran"
                },
                { 
                    "97",
                    "Staro Nagoricane"
                },
                { 
                    "98",
                    "Stip"
                },
                { 
                    "99",
                    "Struga"
                },
                { 
                    "A1",
                    "Strumica"
                },
                { 
                    "A2",
                    "Studenicani"
                },
                { 
                    "A3",
                    "Suto Orizari"
                },
                { 
                    "A4",
                    "Sveti Nikole"
                },
                { 
                    "A5",
                    "Tearce"
                },
                { 
                    "A6",
                    "Tetovo"
                },
                { 
                    "A7",
                    "Topolcani"
                },
                { 
                    "A8",
                    "Valandovo"
                },
                { 
                    "A9",
                    "Vasilevo"
                },
                { 
                    "B1",
                    "Veles"
                },
                { 
                    "B2",
                    "Velesta"
                },
                { 
                    "B3",
                    "Vevcani"
                },
                { 
                    "B4",
                    "Vinica"
                },
                { 
                    "B5",
                    "Vitoliste"
                },
                { 
                    "B6",
                    "Vranestica"
                },
                { 
                    "B7",
                    "Vrapciste"
                },
                { 
                    "B8",
                    "Vratnica"
                },
                { 
                    "B9",
                    "Vrutok"
                },
                { 
                    "C1",
                    "Zajas"
                },
                { 
                    "C2",
                    "Zelenikovo"
                },
                { 
                    "C3",
                    "Zelino"
                },
                { 
                    "C4",
                    "Zitose"
                },
                { 
                    "C5",
                    "Zletovo"
                },
                { 
                    "C6",
                    "Zrnovci"
                }
            };
            RegionName.hashtable_0.Add("MK", hashtable115);
            Hashtable hashtable116 = new Hashtable {
                { 
                    "01",
                    "Bamako"
                },
                { 
                    "03",
                    "Kayes"
                },
                { 
                    "04",
                    "Mopti"
                },
                { 
                    "05",
                    "Segou"
                },
                { 
                    "06",
                    "Sikasso"
                },
                { 
                    "07",
                    "Koulikoro"
                },
                { 
                    "08",
                    "Tombouctou"
                },
                { 
                    "09",
                    "Gao"
                },
                { 
                    "10",
                    "Kidal"
                }
            };
            RegionName.hashtable_0.Add("ML", hashtable116);
            Hashtable hashtable117 = new Hashtable {
                { 
                    "01",
                    "Rakhine State"
                },
                { 
                    "02",
                    "Chin State"
                },
                { 
                    "03",
                    "Irrawaddy"
                },
                { 
                    "04",
                    "Kachin State"
                },
                { 
                    "05",
                    "Karan State"
                },
                { 
                    "06",
                    "Kayah State"
                },
                { 
                    "07",
                    "Magwe"
                },
                { 
                    "08",
                    "Mandalay"
                },
                { 
                    "09",
                    "Pegu"
                },
                { 
                    "10",
                    "Sagaing"
                },
                { 
                    "11",
                    "Shan State"
                },
                { 
                    "12",
                    "Tenasserim"
                },
                { 
                    "13",
                    "Mon State"
                },
                { 
                    "14",
                    "Rangoon"
                },
                { 
                    "17",
                    "Yangon"
                }
            };
            RegionName.hashtable_0.Add("MM", hashtable117);
            Hashtable hashtable118 = new Hashtable {
                { 
                    "01",
                    "Arhangay"
                },
                { 
                    "02",
                    "Bayanhongor"
                },
                { 
                    "03",
                    "Bayan-Olgiy"
                },
                { 
                    "05",
                    "Darhan"
                },
                { 
                    "06",
                    "Dornod"
                },
                { 
                    "07",
                    "Dornogovi"
                },
                { 
                    "08",
                    "Dundgovi"
                },
                { 
                    "09",
                    "Dzavhan"
                },
                { 
                    "10",
                    "Govi-Altay"
                },
                { 
                    "11",
                    "Hentiy"
                },
                { 
                    "12",
                    "Hovd"
                },
                { 
                    "13",
                    "Hovsgol"
                },
                { 
                    "14",
                    "Omnogovi"
                },
                { 
                    "15",
                    "Ovorhangay"
                },
                { 
                    "16",
                    "Selenge"
                },
                { 
                    "17",
                    "Suhbaatar"
                },
                { 
                    "18",
                    "Tov"
                },
                { 
                    "19",
                    "Uvs"
                },
                { 
                    "20",
                    "Ulaanbaatar"
                },
                { 
                    "21",
                    "Bulgan"
                },
                { 
                    "22",
                    "Erdenet"
                },
                { 
                    "23",
                    "Darhan-Uul"
                },
                { 
                    "24",
                    "Govisumber"
                },
                { 
                    "25",
                    "Orhon"
                }
            };
            RegionName.hashtable_0.Add("MN", hashtable118);
            Hashtable hashtable119 = new Hashtable {
                { 
                    "01",
                    "Ilhas"
                },
                { 
                    "02",
                    "Macau"
                }
            };
            RegionName.hashtable_0.Add("MO", hashtable119);
            Hashtable hashtable120 = new Hashtable {
                { 
                    "01",
                    "Hodh Ech Chargui"
                },
                { 
                    "02",
                    "Hodh El Gharbi"
                },
                { 
                    "03",
                    "Assaba"
                },
                { 
                    "04",
                    "Gorgol"
                },
                { 
                    "05",
                    "Brakna"
                },
                { 
                    "06",
                    "Trarza"
                },
                { 
                    "07",
                    "Adrar"
                },
                { 
                    "08",
                    "Dakhlet Nouadhibou"
                },
                { 
                    "09",
                    "Tagant"
                },
                { 
                    "10",
                    "Guidimaka"
                },
                { 
                    "11",
                    "Tiris Zemmour"
                },
                { 
                    "12",
                    "Inchiri"
                }
            };
            RegionName.hashtable_0.Add("MR", hashtable120);
            Hashtable hashtable121 = new Hashtable {
                { 
                    "01",
                    "Saint Anthony"
                },
                { 
                    "02",
                    "Saint Georges"
                },
                { 
                    "03",
                    "Saint Peter"
                }
            };
            RegionName.hashtable_0.Add("MS", hashtable121);
            Hashtable hashtable122 = new Hashtable {
                { 
                    "12",
                    "Black River"
                },
                { 
                    "13",
                    "Flacq"
                },
                { 
                    "14",
                    "Grand Port"
                },
                { 
                    "15",
                    "Moka"
                },
                { 
                    "16",
                    "Pamplemousses"
                },
                { 
                    "17",
                    "Plaines Wilhems"
                },
                { 
                    "18",
                    "Port Louis"
                },
                { 
                    "19",
                    "Riviere du Rempart"
                },
                { 
                    "20",
                    "Savanne"
                },
                { 
                    "21",
                    "Agalega Islands"
                },
                { 
                    "22",
                    "Cargados Carajos"
                },
                { 
                    "23",
                    "Rodrigues"
                }
            };
            RegionName.hashtable_0.Add("MU", hashtable122);
            Hashtable hashtable123 = new Hashtable {
                { 
                    "01",
                    "Seenu"
                },
                { 
                    "05",
                    "Laamu"
                },
                { 
                    "30",
                    "Alifu"
                },
                { 
                    "31",
                    "Baa"
                },
                { 
                    "32",
                    "Dhaalu"
                },
                { 
                    "33",
                    "Faafu "
                },
                { 
                    "34",
                    "Gaafu Alifu"
                },
                { 
                    "35",
                    "Gaafu Dhaalu"
                },
                { 
                    "36",
                    "Haa Alifu"
                },
                { 
                    "37",
                    "Haa Dhaalu"
                },
                { 
                    "38",
                    "Kaafu"
                },
                { 
                    "39",
                    "Lhaviyani"
                },
                { 
                    "40",
                    "Maale"
                },
                { 
                    "41",
                    "Meemu"
                },
                { 
                    "42",
                    "Gnaviyani"
                },
                { 
                    "43",
                    "Noonu"
                },
                { 
                    "44",
                    "Raa"
                },
                { 
                    "45",
                    "Shaviyani"
                },
                { 
                    "46",
                    "Thaa"
                },
                { 
                    "47",
                    "Vaavu"
                }
            };
            RegionName.hashtable_0.Add("MV", hashtable123);
            Hashtable hashtable124 = new Hashtable {
                { 
                    "02",
                    "Chikwawa"
                },
                { 
                    "03",
                    "Chiradzulu"
                },
                { 
                    "04",
                    "Chitipa"
                },
                { 
                    "05",
                    "Thyolo"
                },
                { 
                    "06",
                    "Dedza"
                },
                { 
                    "07",
                    "Dowa"
                },
                { 
                    "08",
                    "Karonga"
                },
                { 
                    "09",
                    "Kasungu"
                },
                { 
                    "11",
                    "Lilongwe"
                },
                { 
                    "12",
                    "Mangochi"
                },
                { 
                    "13",
                    "Mchinji"
                },
                { 
                    "15",
                    "Mzimba"
                },
                { 
                    "16",
                    "Ntcheu"
                },
                { 
                    "17",
                    "Nkhata Bay"
                },
                { 
                    "18",
                    "Nkhotakota"
                },
                { 
                    "19",
                    "Nsanje"
                },
                { 
                    "20",
                    "Ntchisi"
                },
                { 
                    "21",
                    "Rumphi"
                },
                { 
                    "22",
                    "Salima"
                },
                { 
                    "23",
                    "Zomba"
                },
                { 
                    "24",
                    "Blantyre"
                },
                { 
                    "25",
                    "Mwanza"
                },
                { 
                    "26",
                    "Balaka"
                },
                { 
                    "27",
                    "Likoma"
                },
                { 
                    "28",
                    "Machinga"
                },
                { 
                    "29",
                    "Mulanje"
                },
                { 
                    "30",
                    "Phalombe"
                }
            };
            RegionName.hashtable_0.Add("MW", hashtable124);
            Hashtable hashtable125 = new Hashtable {
                { 
                    "01",
                    "Aguascalientes"
                },
                { 
                    "02",
                    "Baja California"
                },
                { 
                    "03",
                    "Baja California Sur"
                },
                { 
                    "04",
                    "Campeche"
                },
                { 
                    "05",
                    "Chiapas"
                },
                { 
                    "06",
                    "Chihuahua"
                },
                { 
                    "07",
                    "Coahuila de Zaragoza"
                },
                { 
                    "08",
                    "Colima"
                },
                { 
                    "09",
                    "Distrito Federal"
                },
                { 
                    "10",
                    "Durango"
                },
                { 
                    "11",
                    "Guanajuato"
                },
                { 
                    "12",
                    "Guerrero"
                },
                { 
                    "13",
                    "Hidalgo"
                },
                { 
                    "14",
                    "Jalisco"
                },
                { 
                    "15",
                    "Mexico"
                },
                { 
                    "16",
                    "Michoacan de Ocampo"
                },
                { 
                    "17",
                    "Morelos"
                },
                { 
                    "18",
                    "Nayarit"
                },
                { 
                    "19",
                    "Nuevo Leon"
                },
                { 
                    "20",
                    "Oaxaca"
                },
                { 
                    "21",
                    "Puebla"
                },
                { 
                    "22",
                    "Queretaro de Arteaga"
                },
                { 
                    "23",
                    "Quintana Roo"
                },
                { 
                    "24",
                    "San Luis Potosi"
                },
                { 
                    "25",
                    "Sinaloa"
                },
                { 
                    "26",
                    "Sonora"
                },
                { 
                    "27",
                    "Tabasco"
                },
                { 
                    "28",
                    "Tamaulipas"
                },
                { 
                    "29",
                    "Tlaxcala"
                },
                { 
                    "30",
                    "Veracruz-Llave"
                },
                { 
                    "31",
                    "Yucatan"
                },
                { 
                    "32",
                    "Zacatecas"
                }
            };
            RegionName.hashtable_0.Add("MX", hashtable125);
            Hashtable hashtable126 = new Hashtable {
                { 
                    "01",
                    "Johor"
                },
                { 
                    "02",
                    "Kedah"
                },
                { 
                    "03",
                    "Kelantan"
                },
                { 
                    "04",
                    "Melaka"
                },
                { 
                    "05",
                    "Negeri Sembilan"
                },
                { 
                    "06",
                    "Pahang"
                },
                { 
                    "07",
                    "Perak"
                },
                { 
                    "08",
                    "Perlis"
                },
                { 
                    "09",
                    "Pulau Pinang"
                },
                { 
                    "11",
                    "Sarawak"
                },
                { 
                    "12",
                    "Selangor"
                },
                { 
                    "13",
                    "Terengganu"
                },
                { 
                    "14",
                    "Kuala Lumpur"
                },
                { 
                    "15",
                    "Labuan"
                },
                { 
                    "16",
                    "Sabah"
                },
                { 
                    "17",
                    "Putrajaya"
                }
            };
            RegionName.hashtable_0.Add("MY", hashtable126);
            Hashtable hashtable127 = new Hashtable {
                { 
                    "01",
                    "Cabo Delgado"
                },
                { 
                    "02",
                    "Gaza"
                },
                { 
                    "03",
                    "Inhambane"
                },
                { 
                    "04",
                    "Maputo"
                },
                { 
                    "05",
                    "Sofala"
                },
                { 
                    "06",
                    "Nampula"
                },
                { 
                    "07",
                    "Niassa"
                },
                { 
                    "08",
                    "Tete"
                },
                { 
                    "09",
                    "Zambezia"
                },
                { 
                    "10",
                    "Manica"
                },
                { 
                    "11",
                    "Maputo"
                }
            };
            RegionName.hashtable_0.Add("MZ", hashtable127);
            Hashtable hashtable128 = new Hashtable {
                { 
                    "01",
                    "Bethanien"
                },
                { 
                    "02",
                    "Caprivi Oos"
                },
                { 
                    "03",
                    "Boesmanland"
                },
                { 
                    "04",
                    "Gobabis"
                },
                { 
                    "05",
                    "Grootfontein"
                },
                { 
                    "06",
                    "Kaokoland"
                },
                { 
                    "07",
                    "Karibib"
                },
                { 
                    "08",
                    "Keetmanshoop"
                },
                { 
                    "09",
                    "Luderitz"
                },
                { 
                    "10",
                    "Maltahohe"
                },
                { 
                    "11",
                    "Okahandja"
                },
                { 
                    "12",
                    "Omaruru"
                },
                { 
                    "13",
                    "Otjiwarongo"
                },
                { 
                    "14",
                    "Outjo"
                },
                { 
                    "15",
                    "Owambo"
                },
                { 
                    "16",
                    "Rehoboth"
                },
                { 
                    "17",
                    "Swakopmund"
                },
                { 
                    "18",
                    "Tsumeb"
                },
                { 
                    "20",
                    "Karasburg"
                },
                { 
                    "21",
                    "Windhoek"
                },
                { 
                    "22",
                    "Damaraland"
                },
                { 
                    "23",
                    "Hereroland Oos"
                },
                { 
                    "24",
                    "Hereroland Wes"
                },
                { 
                    "25",
                    "Kavango"
                },
                { 
                    "26",
                    "Mariental"
                },
                { 
                    "27",
                    "Namaland"
                },
                { 
                    "28",
                    "Caprivi"
                },
                { 
                    "29",
                    "Erongo"
                },
                { 
                    "30",
                    "Hardap"
                },
                { 
                    "31",
                    "Karas"
                },
                { 
                    "32",
                    "Kunene"
                },
                { 
                    "33",
                    "Ohangwena"
                },
                { 
                    "34",
                    "Okavango"
                },
                { 
                    "35",
                    "Omaheke"
                },
                { 
                    "36",
                    "Omusati"
                },
                { 
                    "37",
                    "Oshana"
                },
                { 
                    "38",
                    "Oshikoto"
                },
                { 
                    "39",
                    "Otjozondjupa"
                }
            };
            RegionName.hashtable_0.Add("NA", hashtable128);
            Hashtable hashtable129 = new Hashtable {
                { 
                    "01",
                    "Agadez"
                },
                { 
                    "02",
                    "Diffa"
                },
                { 
                    "03",
                    "Dosso"
                },
                { 
                    "04",
                    "Maradi"
                },
                { 
                    "05",
                    "Niamey"
                },
                { 
                    "06",
                    "Tahoua"
                },
                { 
                    "07",
                    "Zinder"
                },
                { 
                    "08",
                    "Niamey"
                }
            };
            RegionName.hashtable_0.Add("NE", hashtable129);
            Hashtable hashtable130 = new Hashtable {
                { 
                    "05",
                    "Lagos"
                },
                { 
                    "11",
                    "Federal Capital Territory"
                },
                { 
                    "16",
                    "Ogun"
                },
                { 
                    "21",
                    "Akwa Ibom"
                },
                { 
                    "22",
                    "Cross River"
                },
                { 
                    "23",
                    "Kaduna"
                },
                { 
                    "24",
                    "Katsina"
                },
                { 
                    "25",
                    "Anambra"
                },
                { 
                    "26",
                    "Benue"
                },
                { 
                    "27",
                    "Borno"
                },
                { 
                    "28",
                    "Imo"
                },
                { 
                    "29",
                    "Kano"
                },
                { 
                    "30",
                    "Kwara"
                },
                { 
                    "31",
                    "Niger"
                },
                { 
                    "32",
                    "Oyo"
                },
                { 
                    "35",
                    "Adamawa"
                },
                { 
                    "36",
                    "Delta"
                },
                { 
                    "37",
                    "Edo"
                },
                { 
                    "39",
                    "Jigawa"
                },
                { 
                    "40",
                    "Kebbi"
                },
                { 
                    "41",
                    "Kogi"
                },
                { 
                    "42",
                    "Osun"
                },
                { 
                    "43",
                    "Taraba"
                },
                { 
                    "44",
                    "Yobe"
                },
                { 
                    "45",
                    "Abia"
                },
                { 
                    "46",
                    "Bauchi"
                },
                { 
                    "47",
                    "Enugu"
                },
                { 
                    "48",
                    "Ondo"
                },
                { 
                    "49",
                    "Plateau"
                },
                { 
                    "50",
                    "Rivers"
                },
                { 
                    "51",
                    "Sokoto"
                },
                { 
                    "52",
                    "Bayelsa"
                },
                { 
                    "53",
                    "Ebonyi"
                },
                { 
                    "54",
                    "Ekiti"
                },
                { 
                    "55",
                    "Gombe"
                },
                { 
                    "56",
                    "Nassarawa"
                },
                { 
                    "57",
                    "Zamfara"
                }
            };
            RegionName.hashtable_0.Add("NG", hashtable130);
            Hashtable hashtable131 = new Hashtable {
                { 
                    "01",
                    "Boaco"
                },
                { 
                    "02",
                    "Carazo"
                },
                { 
                    "03",
                    "Chinandega"
                },
                { 
                    "04",
                    "Chontales"
                },
                { 
                    "05",
                    "Esteli"
                },
                { 
                    "06",
                    "Granada"
                },
                { 
                    "07",
                    "Jinotega"
                },
                { 
                    "08",
                    "Leon"
                },
                { 
                    "09",
                    "Madriz"
                },
                { 
                    "10",
                    "Managua"
                },
                { 
                    "11",
                    "Masaya"
                },
                { 
                    "12",
                    "Matagalpa"
                },
                { 
                    "13",
                    "Nueva Segovia"
                },
                { 
                    "14",
                    "Rio San Juan"
                },
                { 
                    "15",
                    "Rivas"
                },
                { 
                    "16",
                    "Zelaya"
                },
                { 
                    "17",
                    "Autonoma Atlantico Norte"
                },
                { 
                    "18",
                    "Region Autonoma Atlantico Sur"
                }
            };
            RegionName.hashtable_0.Add("NI", hashtable131);
            Hashtable hashtable132 = new Hashtable {
                { 
                    "01",
                    "Drenthe"
                },
                { 
                    "02",
                    "Friesland"
                },
                { 
                    "03",
                    "Gelderland"
                },
                { 
                    "04",
                    "Groningen"
                },
                { 
                    "05",
                    "Limburg"
                },
                { 
                    "06",
                    "Noord-Brabant"
                },
                { 
                    "07",
                    "Noord-Holland"
                },
                { 
                    "09",
                    "Utrecht"
                },
                { 
                    "10",
                    "Zeeland"
                },
                { 
                    "11",
                    "Zuid-Holland"
                },
                { 
                    "15",
                    "Overijssel"
                },
                { 
                    "16",
                    "Flevoland"
                }
            };
            RegionName.hashtable_0.Add("NL", hashtable132);
            Hashtable hashtable133 = new Hashtable {
                { 
                    "01",
                    "Akershus"
                },
                { 
                    "02",
                    "Aust-Agder"
                },
                { 
                    "04",
                    "Buskerud"
                },
                { 
                    "05",
                    "Finnmark"
                },
                { 
                    "06",
                    "Hedmark"
                },
                { 
                    "07",
                    "Hordaland"
                },
                { 
                    "08",
                    "More og Romsdal"
                },
                { 
                    "09",
                    "Nordland"
                },
                { 
                    "10",
                    "Nord-Trondelag"
                },
                { 
                    "11",
                    "Oppland"
                },
                { 
                    "12",
                    "Oslo"
                },
                { 
                    "13",
                    "Ostfold"
                },
                { 
                    "14",
                    "Rogaland"
                },
                { 
                    "15",
                    "Sogn og Fjordane"
                },
                { 
                    "16",
                    "Sor-Trondelag"
                },
                { 
                    "17",
                    "Telemark"
                },
                { 
                    "18",
                    "Troms"
                },
                { 
                    "19",
                    "Vest-Agder"
                },
                { 
                    "20",
                    "Vestfold"
                }
            };
            RegionName.hashtable_0.Add("NO", hashtable133);
            Hashtable hashtable134 = new Hashtable {
                { 
                    "01",
                    "Bagmati"
                },
                { 
                    "02",
                    "Bheri"
                },
                { 
                    "03",
                    "Dhawalagiri"
                },
                { 
                    "04",
                    "Gandaki"
                },
                { 
                    "05",
                    "Janakpur"
                },
                { 
                    "06",
                    "Karnali"
                },
                { 
                    "07",
                    "Kosi"
                },
                { 
                    "08",
                    "Lumbini"
                },
                { 
                    "09",
                    "Mahakali"
                },
                { 
                    "10",
                    "Mechi"
                },
                { 
                    "11",
                    "Narayani"
                },
                { 
                    "12",
                    "Rapti"
                },
                { 
                    "13",
                    "Sagarmatha"
                },
                { 
                    "14",
                    "Seti"
                }
            };
            RegionName.hashtable_0.Add("NP", hashtable134);
            Hashtable hashtable135 = new Hashtable {
                { 
                    "01",
                    "Aiwo"
                },
                { 
                    "02",
                    "Anabar"
                },
                { 
                    "03",
                    "Anetan"
                },
                { 
                    "04",
                    "Anibare"
                },
                { 
                    "05",
                    "Baiti"
                },
                { 
                    "06",
                    "Boe"
                },
                { 
                    "07",
                    "Buada"
                },
                { 
                    "08",
                    "Denigomodu"
                },
                { 
                    "09",
                    "Ewa"
                },
                { 
                    "10",
                    "Ijuw"
                },
                { 
                    "11",
                    "Meneng"
                },
                { 
                    "12",
                    "Nibok"
                },
                { 
                    "13",
                    "Uaboe"
                },
                { 
                    "14",
                    "Yaren"
                }
            };
            RegionName.hashtable_0.Add("NR", hashtable135);
            Hashtable hashtable136 = new Hashtable {
                { 
                    "10",
                    "Chatham Islands"
                },
                { 
                    "E7",
                    "Auckland"
                },
                { 
                    "E8",
                    "Bay of Plenty"
                },
                { 
                    "E9",
                    "Canterbury"
                },
                { 
                    "F1",
                    "Gisborne"
                },
                { 
                    "F2",
                    "Hawke's Bay"
                },
                { 
                    "F3",
                    "Manawatu-Wanganui"
                },
                { 
                    "F4",
                    "Marlborough"
                },
                { 
                    "F5",
                    "Nelson"
                },
                { 
                    "F6",
                    "Northland"
                },
                { 
                    "F7",
                    "Otago"
                },
                { 
                    "F8",
                    "Southland"
                },
                { 
                    "F9",
                    "Taranaki"
                },
                { 
                    "G1",
                    "Waikato"
                },
                { 
                    "G2",
                    "Wellington"
                },
                { 
                    "G3",
                    "West Coast"
                }
            };
            RegionName.hashtable_0.Add("NZ", hashtable136);
            Hashtable hashtable137 = new Hashtable {
                { 
                    "01",
                    "Ad Dakhiliyah"
                },
                { 
                    "02",
                    "Al Batinah"
                },
                { 
                    "03",
                    "Al Wusta"
                },
                { 
                    "04",
                    "Ash Sharqiyah"
                },
                { 
                    "05",
                    "Az Zahirah"
                },
                { 
                    "06",
                    "Masqat"
                },
                { 
                    "07",
                    "Musandam"
                },
                { 
                    "08",
                    "Zufar"
                }
            };
            RegionName.hashtable_0.Add("OM", hashtable137);
            Hashtable hashtable138 = new Hashtable {
                { 
                    "01",
                    "Bocas del Toro"
                },
                { 
                    "02",
                    "Chiriqui"
                },
                { 
                    "03",
                    "Cocle"
                },
                { 
                    "04",
                    "Colon"
                },
                { 
                    "05",
                    "Darien"
                },
                { 
                    "06",
                    "Herrera"
                },
                { 
                    "07",
                    "Los Santos"
                },
                { 
                    "08",
                    "Panama"
                },
                { 
                    "09",
                    "San Blas"
                },
                { 
                    "10",
                    "Veraguas"
                }
            };
            RegionName.hashtable_0.Add("PA", hashtable138);
            Hashtable hashtable139 = new Hashtable {
                { 
                    "01",
                    "Amazonas"
                },
                { 
                    "02",
                    "Ancash"
                },
                { 
                    "03",
                    "Apurimac"
                },
                { 
                    "04",
                    "Arequipa"
                },
                { 
                    "05",
                    "Ayacucho"
                },
                { 
                    "06",
                    "Cajamarca"
                },
                { 
                    "07",
                    "Callao"
                },
                { 
                    "08",
                    "Cusco"
                },
                { 
                    "09",
                    "Huancavelica"
                },
                { 
                    "10",
                    "Huanuco"
                },
                { 
                    "11",
                    "Ica"
                },
                { 
                    "12",
                    "Junin"
                },
                { 
                    "13",
                    "La Libertad"
                },
                { 
                    "14",
                    "Lambayeque"
                },
                { 
                    "15",
                    "Lima"
                },
                { 
                    "16",
                    "Loreto"
                },
                { 
                    "17",
                    "Madre de Dios"
                },
                { 
                    "18",
                    "Moquegua"
                },
                { 
                    "19",
                    "Pasco"
                },
                { 
                    "20",
                    "Piura"
                },
                { 
                    "21",
                    "Puno"
                },
                { 
                    "22",
                    "San Martin"
                },
                { 
                    "23",
                    "Tacna"
                },
                { 
                    "24",
                    "Tumbes"
                },
                { 
                    "25",
                    "Ucayali"
                }
            };
            RegionName.hashtable_0.Add("PE", hashtable139);
            Hashtable hashtable140 = new Hashtable {
                { 
                    "01",
                    "Central"
                },
                { 
                    "02",
                    "Gulf"
                },
                { 
                    "03",
                    "Milne Bay"
                },
                { 
                    "04",
                    "Northern"
                },
                { 
                    "05",
                    "Southern Highlands"
                },
                { 
                    "06",
                    "Western"
                },
                { 
                    "07",
                    "North Solomons"
                },
                { 
                    "08",
                    "Chimbu"
                },
                { 
                    "09",
                    "Eastern Highlands"
                },
                { 
                    "10",
                    "East New Britain"
                },
                { 
                    "11",
                    "East Sepik"
                },
                { 
                    "12",
                    "Madang"
                },
                { 
                    "13",
                    "Manus"
                },
                { 
                    "14",
                    "Morobe"
                },
                { 
                    "15",
                    "New Ireland"
                },
                { 
                    "16",
                    "Western Highlands"
                },
                { 
                    "17",
                    "West New Britain"
                },
                { 
                    "18",
                    "Sandaun"
                },
                { 
                    "19",
                    "Enga"
                },
                { 
                    "20",
                    "National Capital"
                }
            };
            RegionName.hashtable_0.Add("PG", hashtable140);
            Hashtable hashtable141 = new Hashtable {
                { 
                    "01",
                    "Abra"
                },
                { 
                    "02",
                    "Agusan del Norte"
                },
                { 
                    "03",
                    "Agusan del Sur"
                },
                { 
                    "04",
                    "Aklan"
                },
                { 
                    "05",
                    "Albay"
                },
                { 
                    "06",
                    "Antique"
                },
                { 
                    "07",
                    "Bataan"
                },
                { 
                    "08",
                    "Batanes"
                },
                { 
                    "09",
                    "Batangas"
                },
                { 
                    "10",
                    "Benguet"
                },
                { 
                    "11",
                    "Bohol"
                },
                { 
                    "12",
                    "Bukidnon"
                },
                { 
                    "13",
                    "Bulacan"
                },
                { 
                    "14",
                    "Cagayan"
                },
                { 
                    "15",
                    "Camarines Norte"
                },
                { 
                    "16",
                    "Camarines Sur"
                },
                { 
                    "17",
                    "Camiguin"
                },
                { 
                    "18",
                    "Capiz"
                },
                { 
                    "19",
                    "Catanduanes"
                },
                { 
                    "20",
                    "Cavite"
                },
                { 
                    "21",
                    "Cebu"
                },
                { 
                    "22",
                    "Basilan"
                },
                { 
                    "23",
                    "Eastern Samar"
                },
                { 
                    "24",
                    "Davao"
                },
                { 
                    "25",
                    "Davao del Sur"
                },
                { 
                    "26",
                    "Davao Oriental"
                },
                { 
                    "27",
                    "Ifugao"
                },
                { 
                    "28",
                    "Ilocos Norte"
                },
                { 
                    "29",
                    "Ilocos Sur"
                },
                { 
                    "30",
                    "Iloilo"
                },
                { 
                    "31",
                    "Isabela"
                },
                { 
                    "32",
                    "Kalinga-Apayao"
                },
                { 
                    "33",
                    "Laguna"
                },
                { 
                    "34",
                    "Lanao del Norte"
                },
                { 
                    "35",
                    "Lanao del Sur"
                },
                { 
                    "36",
                    "La Union"
                },
                { 
                    "37",
                    "Leyte"
                },
                { 
                    "38",
                    "Marinduque"
                },
                { 
                    "39",
                    "Masbate"
                },
                { 
                    "40",
                    "Mindoro Occidental"
                },
                { 
                    "41",
                    "Mindoro Oriental"
                },
                { 
                    "42",
                    "Misamis Occidental"
                },
                { 
                    "43",
                    "Misamis Oriental"
                },
                { 
                    "44",
                    "Mountain"
                },
                { 
                    "45",
                    "Negros Occidental"
                },
                { 
                    "46",
                    "Negros Oriental"
                },
                { 
                    "47",
                    "Nueva Ecija"
                },
                { 
                    "48",
                    "Nueva Vizcaya"
                },
                { 
                    "49",
                    "Palawan"
                },
                { 
                    "50",
                    "Pampanga"
                },
                { 
                    "51",
                    "Pangasinan"
                },
                { 
                    "53",
                    "Rizal"
                },
                { 
                    "54",
                    "Romblon"
                },
                { 
                    "55",
                    "Samar"
                },
                { 
                    "56",
                    "Maguindanao"
                },
                { 
                    "57",
                    "North Cotabato"
                },
                { 
                    "58",
                    "Sorsogon"
                },
                { 
                    "59",
                    "Southern Leyte"
                },
                { 
                    "60",
                    "Sulu"
                },
                { 
                    "61",
                    "Surigao del Norte"
                },
                { 
                    "62",
                    "Surigao del Sur"
                },
                { 
                    "63",
                    "Tarlac"
                },
                { 
                    "64",
                    "Zambales"
                },
                { 
                    "65",
                    "Zamboanga del Norte"
                },
                { 
                    "66",
                    "Zamboanga del Sur"
                },
                { 
                    "67",
                    "Northern Samar"
                },
                { 
                    "68",
                    "Quirino"
                },
                { 
                    "69",
                    "Siquijor"
                },
                { 
                    "70",
                    "South Cotabato"
                },
                { 
                    "71",
                    "Sultan Kudarat"
                },
                { 
                    "72",
                    "Tawitawi"
                },
                { 
                    "A1",
                    "Angeles"
                },
                { 
                    "A2",
                    "Bacolod"
                },
                { 
                    "A3",
                    "Bago"
                },
                { 
                    "A4",
                    "Baguio"
                },
                { 
                    "A5",
                    "Bais"
                },
                { 
                    "A6",
                    "Basilan City"
                },
                { 
                    "A7",
                    "Batangas City"
                },
                { 
                    "A8",
                    "Butuan"
                },
                { 
                    "A9",
                    "Cabanatuan"
                },
                { 
                    "B1",
                    "Cadiz"
                },
                { 
                    "B2",
                    "Cagayan de Oro"
                },
                { 
                    "B3",
                    "Calbayog"
                },
                { 
                    "B4",
                    "Caloocan"
                },
                { 
                    "B5",
                    "Canlaon"
                },
                { 
                    "B6",
                    "Cavite City"
                },
                { 
                    "B7",
                    "Cebu City"
                },
                { 
                    "B8",
                    "Cotabato"
                },
                { 
                    "B9",
                    "Dagupan"
                },
                { 
                    "C1",
                    "Danao"
                },
                { 
                    "C2",
                    "Dapitan"
                },
                { 
                    "C3",
                    "Davao City"
                },
                { 
                    "C4",
                    "Dipolog"
                },
                { 
                    "C5",
                    "Dumaguete"
                },
                { 
                    "C6",
                    "General Santos"
                },
                { 
                    "C7",
                    "Gingoog"
                },
                { 
                    "C8",
                    "Iligan"
                },
                { 
                    "C9",
                    "Iloilo City"
                },
                { 
                    "D1",
                    "Iriga"
                },
                { 
                    "D2",
                    "La Carlota"
                },
                { 
                    "D3",
                    "Laoag"
                },
                { 
                    "D4",
                    "Lapu-Lapu"
                },
                { 
                    "D5",
                    "Legaspi"
                },
                { 
                    "D6",
                    "Lipa"
                },
                { 
                    "D7",
                    "Lucena"
                },
                { 
                    "D8",
                    "Mandaue"
                },
                { 
                    "D9",
                    "Manila"
                },
                { 
                    "E1",
                    "Marawi"
                },
                { 
                    "E2",
                    "Naga"
                },
                { 
                    "E3",
                    "Olongapo"
                },
                { 
                    "E4",
                    "Ormoc"
                },
                { 
                    "E5",
                    "Oroquieta"
                },
                { 
                    "E6",
                    "Ozamis"
                },
                { 
                    "E7",
                    "Pagadian"
                },
                { 
                    "E8",
                    "Palayan"
                },
                { 
                    "E9",
                    "Pasay"
                },
                { 
                    "F1",
                    "Puerto Princesa"
                },
                { 
                    "F2",
                    "Quezon City"
                },
                { 
                    "F3",
                    "Roxas"
                },
                { 
                    "F4",
                    "San Carlos"
                },
                { 
                    "F5",
                    "San Carlos"
                },
                { 
                    "F6",
                    "San Jose"
                },
                { 
                    "F7",
                    "San Pablo"
                },
                { 
                    "F8",
                    "Silay"
                },
                { 
                    "F9",
                    "Surigao"
                },
                { 
                    "G1",
                    "Tacloban"
                },
                { 
                    "G2",
                    "Tagaytay"
                },
                { 
                    "G3",
                    "Tagbilaran"
                },
                { 
                    "G4",
                    "Tangub"
                },
                { 
                    "G5",
                    "Toledo"
                },
                { 
                    "G6",
                    "Trece Martires"
                },
                { 
                    "G7",
                    "Zamboanga"
                },
                { 
                    "G8",
                    "Aurora"
                },
                { 
                    "H2",
                    "Quezon"
                },
                { 
                    "H3",
                    "Negros Occidental"
                }
            };
            RegionName.hashtable_0.Add("PH", hashtable141);
            Hashtable hashtable142 = new Hashtable {
                { 
                    "01",
                    "Federally Administered Tribal Areas"
                },
                { 
                    "02",
                    "Balochistan"
                },
                { 
                    "03",
                    "North-West Frontier"
                },
                { 
                    "04",
                    "Punjab"
                },
                { 
                    "05",
                    "Sindh"
                },
                { 
                    "06",
                    "Azad Kashmir"
                },
                { 
                    "07",
                    "Northern Areas"
                },
                { 
                    "08",
                    "Islamabad"
                }
            };
            RegionName.hashtable_0.Add("PK", hashtable142);
            Hashtable hashtable143 = new Hashtable {
                { 
                    "72",
                    "Dolnoslaskie"
                },
                { 
                    "73",
                    "Kujawsko-Pomorskie"
                },
                { 
                    "74",
                    "Lodzkie"
                },
                { 
                    "75",
                    "Lubelskie"
                },
                { 
                    "76",
                    "Lubuskie"
                },
                { 
                    "77",
                    "Malopolskie"
                },
                { 
                    "78",
                    "Mazowieckie"
                },
                { 
                    "79",
                    "Opolskie"
                },
                { 
                    "80",
                    "Podkarpackie"
                },
                { 
                    "81",
                    "Podlaskie"
                },
                { 
                    "82",
                    "Pomorskie"
                },
                { 
                    "83",
                    "Slaskie"
                },
                { 
                    "84",
                    "Swietokrzyskie"
                },
                { 
                    "85",
                    "Warminsko-Mazurskie"
                },
                { 
                    "86",
                    "Wielkopolskie"
                },
                { 
                    "87",
                    "Zachodniopomorskie"
                }
            };
            RegionName.hashtable_0.Add("PL", hashtable143);
            Hashtable hashtable144 = new Hashtable {
                { 
                    "GZ",
                    "Gaza"
                },
                { 
                    "WE",
                    "West Bank"
                }
            };
            RegionName.hashtable_0.Add("PS", hashtable144);
            Hashtable hashtable145 = new Hashtable {
                { 
                    "02",
                    "Aveiro"
                },
                { 
                    "03",
                    "Beja"
                },
                { 
                    "04",
                    "Braga"
                },
                { 
                    "05",
                    "Braganca"
                },
                { 
                    "06",
                    "Castelo Branco"
                },
                { 
                    "07",
                    "Coimbra"
                },
                { 
                    "08",
                    "Evora"
                },
                { 
                    "09",
                    "Faro"
                },
                { 
                    "10",
                    "Madeira"
                },
                { 
                    "11",
                    "Guarda"
                },
                { 
                    "13",
                    "Leiria"
                },
                { 
                    "14",
                    "Lisboa"
                },
                { 
                    "16",
                    "Portalegre"
                },
                { 
                    "17",
                    "Porto"
                },
                { 
                    "18",
                    "Santarem"
                },
                { 
                    "19",
                    "Setubal"
                },
                { 
                    "20",
                    "Viana do Castelo"
                },
                { 
                    "21",
                    "Vila Real"
                },
                { 
                    "22",
                    "Viseu"
                },
                { 
                    "23",
                    "Azores"
                }
            };
            RegionName.hashtable_0.Add("PT", hashtable145);
            Hashtable hashtable146 = new Hashtable {
                { 
                    "01",
                    "Alto Parana"
                },
                { 
                    "02",
                    "Amambay"
                },
                { 
                    "03",
                    "Boqueron"
                },
                { 
                    "04",
                    "Caaguazu"
                },
                { 
                    "05",
                    "Caazapa"
                },
                { 
                    "06",
                    "Central"
                },
                { 
                    "07",
                    "Concepcion"
                },
                { 
                    "08",
                    "Cordillera"
                },
                { 
                    "10",
                    "Guaira"
                },
                { 
                    "11",
                    "Itapua"
                },
                { 
                    "12",
                    "Misiones"
                },
                { 
                    "13",
                    "Neembucu"
                },
                { 
                    "15",
                    "Paraguari"
                },
                { 
                    "16",
                    "Presidente Hayes"
                },
                { 
                    "17",
                    "San Pedro"
                },
                { 
                    "19",
                    "Canindeyu"
                },
                { 
                    "20",
                    "Chaco"
                },
                { 
                    "21",
                    "Nueva Asuncion"
                },
                { 
                    "23",
                    "Alto Paraguay"
                }
            };
            RegionName.hashtable_0.Add("PY", hashtable146);
            Hashtable hashtable147 = new Hashtable {
                { 
                    "01",
                    "Ad Dawhah"
                },
                { 
                    "02",
                    "Al Ghuwariyah"
                },
                { 
                    "03",
                    "Al Jumaliyah"
                },
                { 
                    "04",
                    "Al Khawr"
                },
                { 
                    "05",
                    "Al Wakrah Municipality"
                },
                { 
                    "06",
                    "Ar Rayyan"
                },
                { 
                    "08",
                    "Madinat ach Shamal"
                },
                { 
                    "09",
                    "Umm Salal"
                },
                { 
                    "10",
                    "Al Wakrah"
                },
                { 
                    "11",
                    "Jariyan al Batnah"
                },
                { 
                    "12",
                    "Umm Sa'id"
                }
            };
            RegionName.hashtable_0.Add("QA", hashtable147);
            Hashtable hashtable148 = new Hashtable {
                { 
                    "01",
                    "Alba"
                },
                { 
                    "02",
                    "Arad"
                },
                { 
                    "03",
                    "Arges"
                },
                { 
                    "04",
                    "Bacau"
                },
                { 
                    "05",
                    "Bihor"
                },
                { 
                    "06",
                    "Bistrita-Nasaud"
                },
                { 
                    "07",
                    "Botosani"
                },
                { 
                    "08",
                    "Braila"
                },
                { 
                    "09",
                    "Brasov"
                },
                { 
                    "10",
                    "Bucuresti"
                },
                { 
                    "11",
                    "Buzau"
                },
                { 
                    "12",
                    "Caras-Severin"
                },
                { 
                    "13",
                    "Cluj"
                },
                { 
                    "14",
                    "Constanta"
                },
                { 
                    "15",
                    "Covasna"
                },
                { 
                    "16",
                    "Dambovita"
                },
                { 
                    "17",
                    "Dolj"
                },
                { 
                    "18",
                    "Galati"
                },
                { 
                    "19",
                    "Gorj"
                },
                { 
                    "20",
                    "Harghita"
                },
                { 
                    "21",
                    "Hunedoara"
                },
                { 
                    "22",
                    "Ialomita"
                },
                { 
                    "23",
                    "Iasi"
                },
                { 
                    "25",
                    "Maramures"
                },
                { 
                    "26",
                    "Mehedinti"
                },
                { 
                    "27",
                    "Mures"
                },
                { 
                    "28",
                    "Neamt"
                },
                { 
                    "29",
                    "Olt"
                },
                { 
                    "30",
                    "Prahova"
                },
                { 
                    "31",
                    "Salaj"
                },
                { 
                    "32",
                    "Satu Mare"
                },
                { 
                    "33",
                    "Sibiu"
                },
                { 
                    "34",
                    "Suceava"
                },
                { 
                    "35",
                    "Teleorman"
                },
                { 
                    "36",
                    "Timis"
                },
                { 
                    "37",
                    "Tulcea"
                },
                { 
                    "38",
                    "Vaslui"
                },
                { 
                    "39",
                    "Valcea"
                },
                { 
                    "40",
                    "Vrancea"
                },
                { 
                    "41",
                    "Calarasi"
                },
                { 
                    "42",
                    "Giurgiu"
                },
                { 
                    "43",
                    "Ilfov"
                }
            };
            RegionName.hashtable_0.Add("RO", hashtable148);
            Hashtable hashtable149 = new Hashtable {
                { 
                    "01",
                    "Kosovo"
                },
                { 
                    "02",
                    "Vojvodina"
                }
            };
            RegionName.hashtable_0.Add("RS", hashtable149);
            Hashtable hashtable150 = new Hashtable {
                { 
                    "01",
                    "Adygeya, Republic of"
                },
                { 
                    "02",
                    "Aginsky Buryatsky AO"
                },
                { 
                    "03",
                    "Gorno-Altay"
                },
                { 
                    "04",
                    "Altaisky krai"
                },
                { 
                    "05",
                    "Amur"
                },
                { 
                    "06",
                    "Arkhangel'sk"
                },
                { 
                    "07",
                    "Astrakhan'"
                },
                { 
                    "08",
                    "Bashkortostan"
                },
                { 
                    "09",
                    "Belgorod"
                },
                { 
                    "10",
                    "Bryansk"
                },
                { 
                    "11",
                    "Buryat"
                },
                { 
                    "12",
                    "Chechnya"
                },
                { 
                    "13",
                    "Chelyabinsk"
                },
                { 
                    "14",
                    "Chita"
                },
                { 
                    "15",
                    "Chukot"
                },
                { 
                    "16",
                    "Chuvashia"
                },
                { 
                    "17",
                    "Dagestan"
                },
                { 
                    "18",
                    "Evenk"
                },
                { 
                    "19",
                    "Ingush"
                },
                { 
                    "20",
                    "Irkutsk"
                },
                { 
                    "21",
                    "Ivanovo"
                },
                { 
                    "22",
                    "Kabardin-Balkar"
                },
                { 
                    "23",
                    "Kaliningrad"
                },
                { 
                    "24",
                    "Kalmyk"
                },
                { 
                    "25",
                    "Kaluga"
                },
                { 
                    "26",
                    "Kamchatka"
                },
                { 
                    "27",
                    "Karachay-Cherkess"
                },
                { 
                    "28",
                    "Karelia"
                },
                { 
                    "29",
                    "Kemerovo"
                },
                { 
                    "30",
                    "Khabarovsk"
                },
                { 
                    "31",
                    "Khakass"
                },
                { 
                    "32",
                    "Khanty-Mansiy"
                },
                { 
                    "33",
                    "Kirov"
                },
                { 
                    "34",
                    "Komi"
                },
                { 
                    "35",
                    "Komi-Permyak"
                },
                { 
                    "36",
                    "Koryak"
                },
                { 
                    "37",
                    "Kostroma"
                },
                { 
                    "38",
                    "Krasnodar"
                },
                { 
                    "39",
                    "Krasnoyarsk"
                },
                { 
                    "40",
                    "Kurgan"
                },
                { 
                    "41",
                    "Kursk"
                },
                { 
                    "42",
                    "Leningrad"
                },
                { 
                    "43",
                    "Lipetsk"
                },
                { 
                    "44",
                    "Magadan"
                },
                { 
                    "45",
                    "Mariy-El"
                },
                { 
                    "46",
                    "Mordovia"
                },
                { 
                    "47",
                    "Moskva"
                },
                { 
                    "48",
                    "Moscow City"
                },
                { 
                    "49",
                    "Murmansk"
                },
                { 
                    "50",
                    "Nenets"
                },
                { 
                    "51",
                    "Nizhegorod"
                },
                { 
                    "52",
                    "Novgorod"
                },
                { 
                    "53",
                    "Novosibirsk"
                },
                { 
                    "54",
                    "Omsk"
                },
                { 
                    "55",
                    "Orenburg"
                },
                { 
                    "56",
                    "Orel"
                },
                { 
                    "57",
                    "Penza"
                },
                { 
                    "58",
                    "Perm'"
                },
                { 
                    "59",
                    "Primor'ye"
                },
                { 
                    "60",
                    "Pskov"
                },
                { 
                    "61",
                    "Rostov"
                },
                { 
                    "62",
                    "Ryazan'"
                },
                { 
                    "63",
                    "Sakha"
                },
                { 
                    "64",
                    "Sakhalin"
                },
                { 
                    "65",
                    "Samara"
                },
                { 
                    "66",
                    "Saint Petersburg City"
                },
                { 
                    "67",
                    "Saratov"
                },
                { 
                    "68",
                    "North Ossetia"
                },
                { 
                    "69",
                    "Smolensk"
                },
                { 
                    "70",
                    "Stavropol'"
                },
                { 
                    "71",
                    "Sverdlovsk"
                },
                { 
                    "72",
                    "Tambovskaya oblast"
                },
                { 
                    "73",
                    "Tatarstan"
                },
                { 
                    "74",
                    "Taymyr"
                },
                { 
                    "75",
                    "Tomsk"
                },
                { 
                    "76",
                    "Tula"
                },
                { 
                    "77",
                    "Tver'"
                },
                { 
                    "78",
                    "Tyumen'"
                },
                { 
                    "79",
                    "Tuva"
                },
                { 
                    "80",
                    "Udmurt"
                },
                { 
                    "81",
                    "Ul'yanovsk"
                },
                { 
                    "82",
                    "Ust-Orda Buryat"
                },
                { 
                    "83",
                    "Vladimir"
                },
                { 
                    "84",
                    "Volgograd"
                },
                { 
                    "85",
                    "Vologda"
                },
                { 
                    "86",
                    "Voronezh"
                },
                { 
                    "87",
                    "Yamal-Nenets"
                },
                { 
                    "88",
                    "Yaroslavl'"
                },
                { 
                    "89",
                    "Yevrey"
                },
                { 
                    "90",
                    "Permskiy Kray"
                },
                { 
                    "91",
                    "Krasnoyarskiy Kray"
                },
                { 
                    "92",
                    "Kamchatskiy Kray"
                },
                { 
                    "93",
                    "Zabaykal'skiy Kray"
                }
            };
            RegionName.hashtable_0.Add("RU", hashtable150);
            Hashtable hashtable151 = new Hashtable {
                { 
                    "01",
                    "Butare"
                },
                { 
                    "06",
                    "Gitarama"
                },
                { 
                    "07",
                    "Kibungo"
                },
                { 
                    "09",
                    "Kigali"
                },
                { 
                    "11",
                    "Est"
                },
                { 
                    "12",
                    "Kigali"
                },
                { 
                    "13",
                    "Nord"
                },
                { 
                    "14",
                    "Ouest"
                },
                { 
                    "15",
                    "Sud"
                }
            };
            RegionName.hashtable_0.Add("RW", hashtable151);
            Hashtable hashtable152 = new Hashtable {
                { 
                    "02",
                    "Al Bahah"
                },
                { 
                    "05",
                    "Al Madinah"
                },
                { 
                    "06",
                    "Ash Sharqiyah"
                },
                { 
                    "08",
                    "Al Qasim"
                },
                { 
                    "10",
                    "Ar Riyad"
                },
                { 
                    "11",
                    "Asir Province"
                },
                { 
                    "13",
                    "Ha'il"
                },
                { 
                    "14",
                    "Makkah"
                },
                { 
                    "15",
                    "Al Hudud ash Shamaliyah"
                },
                { 
                    "16",
                    "Najran"
                },
                { 
                    "17",
                    "Jizan"
                },
                { 
                    "19",
                    "Tabuk"
                },
                { 
                    "20",
                    "Al Jawf"
                }
            };
            RegionName.hashtable_0.Add("SA", hashtable152);
            Hashtable hashtable153 = new Hashtable {
                { 
                    "03",
                    "Malaita"
                },
                { 
                    "06",
                    "Guadalcanal"
                },
                { 
                    "07",
                    "Isabel"
                },
                { 
                    "08",
                    "Makira"
                },
                { 
                    "09",
                    "Temotu"
                },
                { 
                    "10",
                    "Central"
                },
                { 
                    "11",
                    "Western"
                },
                { 
                    "12",
                    "Choiseul"
                },
                { 
                    "13",
                    "Rennell and Bellona"
                }
            };
            RegionName.hashtable_0.Add("SB", hashtable153);
            Hashtable hashtable154 = new Hashtable {
                { 
                    "01",
                    "Anse aux Pins"
                },
                { 
                    "02",
                    "Anse Boileau"
                },
                { 
                    "03",
                    "Anse Etoile"
                },
                { 
                    "04",
                    "Anse Louis"
                },
                { 
                    "05",
                    "Anse Royale"
                },
                { 
                    "06",
                    "Baie Lazare"
                },
                { 
                    "07",
                    "Baie Sainte Anne"
                },
                { 
                    "08",
                    "Beau Vallon"
                },
                { 
                    "09",
                    "Bel Air"
                },
                { 
                    "10",
                    "Bel Ombre"
                },
                { 
                    "11",
                    "Cascade"
                },
                { 
                    "12",
                    "Glacis"
                },
                { 
                    "13",
                    "Grand' Anse"
                },
                { 
                    "14",
                    "Grand' Anse"
                },
                { 
                    "15",
                    "La Digue"
                },
                { 
                    "16",
                    "La Riviere Anglaise"
                },
                { 
                    "17",
                    "Mont Buxton"
                },
                { 
                    "18",
                    "Mont Fleuri"
                },
                { 
                    "19",
                    "Plaisance"
                },
                { 
                    "20",
                    "Pointe La Rue"
                },
                { 
                    "21",
                    "Port Glaud"
                },
                { 
                    "22",
                    "Saint Louis"
                },
                { 
                    "23",
                    "Takamaka"
                }
            };
            RegionName.hashtable_0.Add("SC", hashtable154);
            Hashtable hashtable155 = new Hashtable {
                { 
                    "27",
                    "Al Wusta"
                },
                { 
                    "28",
                    "Al Istiwa'iyah"
                },
                { 
                    "29",
                    "Al Khartum"
                },
                { 
                    "30",
                    "Ash Shamaliyah"
                },
                { 
                    "31",
                    "Ash Sharqiyah"
                },
                { 
                    "32",
                    "Bahr al Ghazal"
                },
                { 
                    "33",
                    "Darfur"
                },
                { 
                    "34",
                    "Kurdufan"
                },
                { 
                    "35",
                    "Upper Nile"
                },
                { 
                    "40",
                    "Al Wahadah State"
                },
                { 
                    "44",
                    "Central Equatoria State"
                }
            };
            RegionName.hashtable_0.Add("SD", hashtable155);
            Hashtable hashtable156 = new Hashtable {
                { 
                    "02",
                    "Blekinge Lan"
                },
                { 
                    "03",
                    "Gavleborgs Lan"
                },
                { 
                    "05",
                    "Gotlands Lan"
                },
                { 
                    "06",
                    "Hallands Lan"
                },
                { 
                    "07",
                    "Jamtlands Lan"
                },
                { 
                    "08",
                    "Jonkopings Lan"
                },
                { 
                    "09",
                    "Kalmar Lan"
                },
                { 
                    "10",
                    "Dalarnas Lan"
                },
                { 
                    "12",
                    "Kronobergs Lan"
                },
                { 
                    "14",
                    "Norrbottens Lan"
                },
                { 
                    "15",
                    "Orebro Lan"
                },
                { 
                    "16",
                    "Ostergotlands Lan"
                },
                { 
                    "18",
                    "Sodermanlands Lan"
                },
                { 
                    "21",
                    "Uppsala Lan"
                },
                { 
                    "22",
                    "Varmlands Lan"
                },
                { 
                    "23",
                    "Vasterbottens Lan"
                },
                { 
                    "24",
                    "Vasternorrlands Lan"
                },
                { 
                    "25",
                    "Vastmanlands Lan"
                },
                { 
                    "26",
                    "Stockholms Lan"
                },
                { 
                    "27",
                    "Skane Lan"
                },
                { 
                    "28",
                    "Vastra Gotaland"
                }
            };
            RegionName.hashtable_0.Add("SE", hashtable156);
            Hashtable hashtable157 = new Hashtable {
                { 
                    "01",
                    "Ascension"
                },
                { 
                    "02",
                    "Saint Helena"
                },
                { 
                    "03",
                    "Tristan da Cunha"
                }
            };
            RegionName.hashtable_0.Add("SH", hashtable157);
            Hashtable hashtable158 = new Hashtable {
                { 
                    "01",
                    "Ajdovscina"
                },
                { 
                    "02",
                    "Beltinci"
                },
                { 
                    "03",
                    "Bled"
                },
                { 
                    "04",
                    "Bohinj"
                },
                { 
                    "05",
                    "Borovnica"
                },
                { 
                    "06",
                    "Bovec"
                },
                { 
                    "07",
                    "Brda"
                },
                { 
                    "08",
                    "Brezice"
                },
                { 
                    "09",
                    "Brezovica"
                },
                { 
                    "11",
                    "Celje"
                },
                { 
                    "12",
                    "Cerklje na Gorenjskem"
                },
                { 
                    "13",
                    "Cerknica"
                },
                { 
                    "14",
                    "Cerkno"
                },
                { 
                    "15",
                    "Crensovci"
                },
                { 
                    "16",
                    "Crna na Koroskem"
                },
                { 
                    "17",
                    "Crnomelj"
                },
                { 
                    "19",
                    "Divaca"
                },
                { 
                    "20",
                    "Dobrepolje"
                },
                { 
                    "22",
                    "Dol pri Ljubljani"
                },
                { 
                    "24",
                    "Dornava"
                },
                { 
                    "25",
                    "Dravograd"
                },
                { 
                    "26",
                    "Duplek"
                },
                { 
                    "27",
                    "Gorenja Vas-Poljane"
                },
                { 
                    "28",
                    "Gorisnica"
                },
                { 
                    "29",
                    "Gornja Radgona"
                },
                { 
                    "30",
                    "Gornji Grad"
                },
                { 
                    "31",
                    "Gornji Petrovci"
                },
                { 
                    "32",
                    "Grosuplje"
                },
                { 
                    "34",
                    "Hrastnik"
                },
                { 
                    "35",
                    "Hrpelje-Kozina"
                },
                { 
                    "36",
                    "Idrija"
                },
                { 
                    "37",
                    "Ig"
                },
                { 
                    "38",
                    "Ilirska Bistrica"
                },
                { 
                    "39",
                    "Ivancna Gorica"
                },
                { 
                    "40",
                    "Izola-Isola"
                },
                { 
                    "42",
                    "Jursinci"
                },
                { 
                    "44",
                    "Kanal"
                },
                { 
                    "45",
                    "Kidricevo"
                },
                { 
                    "46",
                    "Kobarid"
                },
                { 
                    "47",
                    "Kobilje"
                },
                { 
                    "49",
                    "Komen"
                },
                { 
                    "50",
                    "Koper-Capodistria"
                },
                { 
                    "51",
                    "Kozje"
                },
                { 
                    "52",
                    "Kranj"
                },
                { 
                    "53",
                    "Kranjska Gora"
                },
                { 
                    "54",
                    "Krsko"
                },
                { 
                    "55",
                    "Kungota"
                },
                { 
                    "57",
                    "Lasko"
                },
                { 
                    "61",
                    "Ljubljana"
                },
                { 
                    "62",
                    "Ljubno"
                },
                { 
                    "64",
                    "Logatec"
                },
                { 
                    "66",
                    "Loski Potok"
                },
                { 
                    "68",
                    "Lukovica"
                },
                { 
                    "71",
                    "Medvode"
                },
                { 
                    "72",
                    "Menges"
                },
                { 
                    "73",
                    "Metlika"
                },
                { 
                    "74",
                    "Mezica"
                },
                { 
                    "76",
                    "Mislinja"
                },
                { 
                    "77",
                    "Moravce"
                },
                { 
                    "78",
                    "Moravske Toplice"
                },
                { 
                    "79",
                    "Mozirje"
                },
                { 
                    "80",
                    "Murska Sobota"
                },
                { 
                    "81",
                    "Muta"
                },
                { 
                    "82",
                    "Naklo"
                },
                { 
                    "83",
                    "Nazarje"
                },
                { 
                    "84",
                    "Nova Gorica"
                },
                { 
                    "86",
                    "Odranci"
                },
                { 
                    "87",
                    "Ormoz"
                },
                { 
                    "88",
                    "Osilnica"
                },
                { 
                    "89",
                    "Pesnica"
                },
                { 
                    "91",
                    "Pivka"
                },
                { 
                    "92",
                    "Podcetrtek"
                },
                { 
                    "94",
                    "Postojna"
                },
                { 
                    "97",
                    "Puconci"
                },
                { 
                    "98",
                    "Racam"
                },
                { 
                    "99",
                    "Radece"
                },
                { 
                    "A1",
                    "Radenci"
                },
                { 
                    "A2",
                    "Radlje ob Dravi"
                },
                { 
                    "A3",
                    "Radovljica"
                },
                { 
                    "A6",
                    "Rogasovci"
                },
                { 
                    "A7",
                    "Rogaska Slatina"
                },
                { 
                    "A8",
                    "Rogatec"
                },
                { 
                    "B1",
                    "Semic"
                },
                { 
                    "B2",
                    "Sencur"
                },
                { 
                    "B3",
                    "Sentilj"
                },
                { 
                    "B4",
                    "Sentjernej"
                },
                { 
                    "B6",
                    "Sevnica"
                },
                { 
                    "B7",
                    "Sezana"
                },
                { 
                    "B8",
                    "Skocjan"
                },
                { 
                    "B9",
                    "Skofja Loka"
                },
                { 
                    "C1",
                    "Skofljica"
                },
                { 
                    "C2",
                    "Slovenj Gradec"
                },
                { 
                    "C4",
                    "Slovenske Konjice"
                },
                { 
                    "C5",
                    "Smarje pri Jelsah"
                },
                { 
                    "C6",
                    "Smartno ob Paki"
                },
                { 
                    "C7",
                    "Sostanj"
                },
                { 
                    "C8",
                    "Starse"
                },
                { 
                    "C9",
                    "Store"
                },
                { 
                    "D1",
                    "Sveti Jurij"
                },
                { 
                    "D2",
                    "Tolmin"
                },
                { 
                    "D3",
                    "Trbovlje"
                },
                { 
                    "D4",
                    "Trebnje"
                },
                { 
                    "D5",
                    "Trzic"
                },
                { 
                    "D6",
                    "Turnisce"
                },
                { 
                    "D7",
                    "Velenje"
                },
                { 
                    "D8",
                    "Velike Lasce"
                },
                { 
                    "E1",
                    "Vipava"
                },
                { 
                    "E2",
                    "Vitanje"
                },
                { 
                    "E3",
                    "Vodice"
                },
                { 
                    "E5",
                    "Vrhnika"
                },
                { 
                    "E6",
                    "Vuzenica"
                },
                { 
                    "E7",
                    "Zagorje ob Savi"
                },
                { 
                    "E9",
                    "Zavrc"
                },
                { 
                    "F1",
                    "Zelezniki"
                },
                { 
                    "F2",
                    "Ziri"
                },
                { 
                    "F3",
                    "Zrece"
                },
                { 
                    "G4",
                    "Dobrova-Horjul-Polhov Gradec"
                },
                { 
                    "G7",
                    "Domzale"
                },
                { 
                    "H4",
                    "Jesenice"
                },
                { 
                    "H6",
                    "Kamnik"
                },
                { 
                    "H7",
                    "Kocevje"
                },
                { 
                    "I2",
                    "Kuzma"
                },
                { 
                    "I3",
                    "Lenart"
                },
                { 
                    "I5",
                    "Litija"
                },
                { 
                    "I6",
                    "Ljutomer"
                },
                { 
                    "I7",
                    "Loska Dolina"
                },
                { 
                    "I9",
                    "Luce"
                },
                { 
                    "J1",
                    "Majsperk"
                },
                { 
                    "J2",
                    "Maribor"
                },
                { 
                    "J5",
                    "Miren-Kostanjevica"
                },
                { 
                    "J7",
                    "Novo Mesto"
                },
                { 
                    "J9",
                    "Piran"
                },
                { 
                    "K5",
                    "Preddvor"
                },
                { 
                    "K7",
                    "Ptuj"
                },
                { 
                    "L1",
                    "Ribnica"
                },
                { 
                    "L3",
                    "Ruse"
                },
                { 
                    "L7",
                    "Sentjur pri Celju"
                },
                { 
                    "L8",
                    "Slovenska Bistrica"
                },
                { 
                    "N2",
                    "Videm"
                },
                { 
                    "N3",
                    "Vojnik"
                },
                { 
                    "N5",
                    "Zalec"
                }
            };
            RegionName.hashtable_0.Add("SI", hashtable158);
            Hashtable hashtable159 = new Hashtable {
                { 
                    "01",
                    "Banska Bystrica"
                },
                { 
                    "02",
                    "Bratislava"
                },
                { 
                    "03",
                    "Kosice"
                },
                { 
                    "04",
                    "Nitra"
                },
                { 
                    "05",
                    "Presov"
                },
                { 
                    "06",
                    "Trencin"
                },
                { 
                    "07",
                    "Trnava"
                },
                { 
                    "08",
                    "Zilina"
                }
            };
            RegionName.hashtable_0.Add("SK", hashtable159);
            Hashtable hashtable160 = new Hashtable {
                { 
                    "01",
                    "Eastern"
                },
                { 
                    "02",
                    "Northern"
                },
                { 
                    "03",
                    "Southern"
                },
                { 
                    "04",
                    "Western Area"
                }
            };
            RegionName.hashtable_0.Add("SL", hashtable160);
            Hashtable hashtable161 = new Hashtable {
                { 
                    "01",
                    "Acquaviva"
                },
                { 
                    "02",
                    "Chiesanuova"
                },
                { 
                    "03",
                    "Domagnano"
                },
                { 
                    "04",
                    "Faetano"
                },
                { 
                    "05",
                    "Fiorentino"
                },
                { 
                    "06",
                    "Borgo Maggiore"
                },
                { 
                    "07",
                    "San Marino"
                },
                { 
                    "08",
                    "Monte Giardino"
                },
                { 
                    "09",
                    "Serravalle"
                }
            };
            RegionName.hashtable_0.Add("SM", hashtable161);
            Hashtable hashtable162 = new Hashtable {
                { 
                    "01",
                    "Dakar"
                },
                { 
                    "03",
                    "Diourbel"
                },
                { 
                    "05",
                    "Tambacounda"
                },
                { 
                    "07",
                    "Thies"
                },
                { 
                    "09",
                    "Fatick"
                },
                { 
                    "10",
                    "Kaolack"
                },
                { 
                    "11",
                    "Kolda"
                },
                { 
                    "12",
                    "Ziguinchor"
                },
                { 
                    "13",
                    "Louga"
                },
                { 
                    "14",
                    "Saint-Louis"
                },
                { 
                    "15",
                    "Matam"
                }
            };
            RegionName.hashtable_0.Add("SN", hashtable162);
            Hashtable hashtable163 = new Hashtable {
                { 
                    "01",
                    "Bakool"
                },
                { 
                    "02",
                    "Banaadir"
                },
                { 
                    "03",
                    "Bari"
                },
                { 
                    "04",
                    "Bay"
                },
                { 
                    "05",
                    "Galguduud"
                },
                { 
                    "06",
                    "Gedo"
                },
                { 
                    "07",
                    "Hiiraan"
                },
                { 
                    "08",
                    "Jubbada Dhexe"
                },
                { 
                    "09",
                    "Jubbada Hoose"
                },
                { 
                    "10",
                    "Mudug"
                },
                { 
                    "11",
                    "Nugaal"
                },
                { 
                    "12",
                    "Sanaag"
                },
                { 
                    "13",
                    "Shabeellaha Dhexe"
                },
                { 
                    "14",
                    "Shabeellaha Hoose"
                },
                { 
                    "16",
                    "Woqooyi Galbeed"
                },
                { 
                    "18",
                    "Nugaal"
                },
                { 
                    "19",
                    "Togdheer"
                },
                { 
                    "20",
                    "Woqooyi Galbeed"
                },
                { 
                    "21",
                    "Awdal"
                },
                { 
                    "22",
                    "Sool"
                }
            };
            RegionName.hashtable_0.Add("SO", hashtable163);
            Hashtable hashtable164 = new Hashtable {
                { 
                    "10",
                    "Brokopondo"
                },
                { 
                    "11",
                    "Commewijne"
                },
                { 
                    "12",
                    "Coronie"
                },
                { 
                    "13",
                    "Marowijne"
                },
                { 
                    "14",
                    "Nickerie"
                },
                { 
                    "15",
                    "Para"
                },
                { 
                    "16",
                    "Paramaribo"
                },
                { 
                    "17",
                    "Saramacca"
                },
                { 
                    "18",
                    "Sipaliwini"
                },
                { 
                    "19",
                    "Wanica"
                }
            };
            RegionName.hashtable_0.Add("SR", hashtable164);
            Hashtable hashtable165 = new Hashtable {
                { 
                    "01",
                    "Principe"
                },
                { 
                    "02",
                    "Sao Tome"
                }
            };
            RegionName.hashtable_0.Add("ST", hashtable165);
            Hashtable hashtable166 = new Hashtable {
                { 
                    "01",
                    "Ahuachapan"
                },
                { 
                    "02",
                    "Cabanas"
                },
                { 
                    "03",
                    "Chalatenango"
                },
                { 
                    "04",
                    "Cuscatlan"
                },
                { 
                    "05",
                    "La Libertad"
                },
                { 
                    "06",
                    "La Paz"
                },
                { 
                    "07",
                    "La Union"
                },
                { 
                    "08",
                    "Morazan"
                },
                { 
                    "09",
                    "San Miguel"
                },
                { 
                    "10",
                    "San Salvador"
                },
                { 
                    "11",
                    "Santa Ana"
                },
                { 
                    "12",
                    "San Vicente"
                },
                { 
                    "13",
                    "Sonsonate"
                },
                { 
                    "14",
                    "Usulutan"
                }
            };
            RegionName.hashtable_0.Add("SV", hashtable166);
            Hashtable hashtable167 = new Hashtable {
                { 
                    "01",
                    "Al Hasakah"
                },
                { 
                    "02",
                    "Al Ladhiqiyah"
                },
                { 
                    "03",
                    "Al Qunaytirah"
                },
                { 
                    "04",
                    "Ar Raqqah"
                },
                { 
                    "05",
                    "As Suwayda'"
                },
                { 
                    "06",
                    "Dar"
                },
                { 
                    "07",
                    "Dayr az Zawr"
                },
                { 
                    "08",
                    "Rif Dimashq"
                },
                { 
                    "09",
                    "Halab"
                },
                { 
                    "10",
                    "Hamah"
                },
                { 
                    "11",
                    "Hims"
                },
                { 
                    "12",
                    "Idlib"
                },
                { 
                    "13",
                    "Dimashq"
                },
                { 
                    "14",
                    "Tartus"
                }
            };
            RegionName.hashtable_0.Add("SY", hashtable167);
            Hashtable hashtable168 = new Hashtable {
                { 
                    "01",
                    "Hhohho"
                },
                { 
                    "02",
                    "Lubombo"
                },
                { 
                    "03",
                    "Manzini"
                },
                { 
                    "04",
                    "Shiselweni"
                },
                { 
                    "05",
                    "Praslin"
                }
            };
            RegionName.hashtable_0.Add("SZ", hashtable168);
            Hashtable hashtable169 = new Hashtable {
                { 
                    "01",
                    "Batha"
                },
                { 
                    "02",
                    "Biltine"
                },
                { 
                    "03",
                    "Borkou-Ennedi-Tibesti"
                },
                { 
                    "04",
                    "Chari-Baguirmi"
                },
                { 
                    "05",
                    "Guera"
                },
                { 
                    "06",
                    "Kanem"
                },
                { 
                    "07",
                    "Lac"
                },
                { 
                    "08",
                    "Logone Occidental"
                },
                { 
                    "09",
                    "Logone Oriental"
                },
                { 
                    "10",
                    "Mayo-Kebbi"
                },
                { 
                    "11",
                    "Moyen-Chari"
                },
                { 
                    "12",
                    "Ouaddai"
                },
                { 
                    "13",
                    "Salamat"
                },
                { 
                    "14",
                    "Tandjile"
                }
            };
            RegionName.hashtable_0.Add("TD", hashtable169);
            Hashtable hashtable170 = new Hashtable {
                { 
                    "22",
                    "Centrale"
                },
                { 
                    "23",
                    "Kara"
                },
                { 
                    "24",
                    "Maritime"
                },
                { 
                    "25",
                    "Plateaux"
                },
                { 
                    "26",
                    "Savanes"
                }
            };
            RegionName.hashtable_0.Add("TG", hashtable170);
            Hashtable hashtable171 = new Hashtable {
                { 
                    "01",
                    "Mae Hong Son"
                },
                { 
                    "02",
                    "Chiang Mai"
                },
                { 
                    "03",
                    "Chiang Rai"
                },
                { 
                    "04",
                    "Nan"
                },
                { 
                    "05",
                    "Lamphun"
                },
                { 
                    "06",
                    "Lampang"
                },
                { 
                    "07",
                    "Phrae"
                },
                { 
                    "08",
                    "Tak"
                },
                { 
                    "09",
                    "Sukhothai"
                },
                { 
                    "10",
                    "Uttaradit"
                },
                { 
                    "11",
                    "Kamphaeng Phet"
                },
                { 
                    "12",
                    "Phitsanulok"
                },
                { 
                    "13",
                    "Phichit"
                },
                { 
                    "14",
                    "Phetchabun"
                },
                { 
                    "15",
                    "Uthai Thani"
                },
                { 
                    "16",
                    "Nakhon Sawan"
                },
                { 
                    "17",
                    "Nong Khai"
                },
                { 
                    "18",
                    "Loei"
                },
                { 
                    "20",
                    "Sakon Nakhon"
                },
                { 
                    "21",
                    "Nakhon Phanom"
                },
                { 
                    "22",
                    "Khon Kaen"
                },
                { 
                    "23",
                    "Kalasin"
                },
                { 
                    "24",
                    "Maha Sarakham"
                },
                { 
                    "25",
                    "Roi Et"
                },
                { 
                    "26",
                    "Chaiyaphum"
                },
                { 
                    "27",
                    "Nakhon Ratchasima"
                },
                { 
                    "28",
                    "Buriram"
                },
                { 
                    "29",
                    "Surin"
                },
                { 
                    "30",
                    "Sisaket"
                },
                { 
                    "31",
                    "Narathiwat"
                },
                { 
                    "32",
                    "Chai Nat"
                },
                { 
                    "33",
                    "Sing Buri"
                },
                { 
                    "34",
                    "Lop Buri"
                },
                { 
                    "35",
                    "Ang Thong"
                },
                { 
                    "36",
                    "Phra Nakhon Si Ayutthaya"
                },
                { 
                    "37",
                    "Saraburi"
                },
                { 
                    "38",
                    "Nonthaburi"
                },
                { 
                    "39",
                    "Pathum Thani"
                },
                { 
                    "40",
                    "Krung Thep"
                },
                { 
                    "41",
                    "Phayao"
                },
                { 
                    "42",
                    "Samut Prakan"
                },
                { 
                    "43",
                    "Nakhon Nayok"
                },
                { 
                    "44",
                    "Chachoengsao"
                },
                { 
                    "45",
                    "Prachin Buri"
                },
                { 
                    "46",
                    "Chon Buri"
                },
                { 
                    "47",
                    "Rayong"
                },
                { 
                    "48",
                    "Chanthaburi"
                },
                { 
                    "49",
                    "Trat"
                },
                { 
                    "50",
                    "Kanchanaburi"
                },
                { 
                    "51",
                    "Suphan Buri"
                },
                { 
                    "52",
                    "Ratchaburi"
                },
                { 
                    "53",
                    "Nakhon Pathom"
                },
                { 
                    "54",
                    "Samut Songkhram"
                },
                { 
                    "55",
                    "Samut Sakhon"
                },
                { 
                    "56",
                    "Phetchaburi"
                },
                { 
                    "57",
                    "Prachuap Khiri Khan"
                },
                { 
                    "58",
                    "Chumphon"
                },
                { 
                    "59",
                    "Ranong"
                },
                { 
                    "60",
                    "Surat Thani"
                },
                { 
                    "61",
                    "Phangnga"
                },
                { 
                    "62",
                    "Phuket"
                },
                { 
                    "63",
                    "Krabi"
                },
                { 
                    "64",
                    "Nakhon Si Thammarat"
                },
                { 
                    "65",
                    "Trang"
                },
                { 
                    "66",
                    "Phatthalung"
                },
                { 
                    "67",
                    "Satun"
                },
                { 
                    "68",
                    "Songkhla"
                },
                { 
                    "69",
                    "Pattani"
                },
                { 
                    "70",
                    "Yala"
                },
                { 
                    "71",
                    "Ubon Ratchathani"
                },
                { 
                    "72",
                    "Yasothon"
                },
                { 
                    "73",
                    "Nakhon Phanom"
                },
                { 
                    "75",
                    "Ubon Ratchathani"
                },
                { 
                    "76",
                    "Udon Thani"
                },
                { 
                    "77",
                    "Amnat Charoen"
                },
                { 
                    "78",
                    "Mukdahan"
                },
                { 
                    "79",
                    "Nong Bua Lamphu"
                },
                { 
                    "80",
                    "Sa Kaeo"
                }
            };
            RegionName.hashtable_0.Add("TH", hashtable171);
            Hashtable hashtable172 = new Hashtable {
                { 
                    "01",
                    "Kuhistoni Badakhshon"
                },
                { 
                    "02",
                    "Khatlon"
                },
                { 
                    "03",
                    "Sughd"
                }
            };
            RegionName.hashtable_0.Add("TJ", hashtable172);
            Hashtable hashtable173 = new Hashtable {
                { 
                    "01",
                    "Ahal"
                },
                { 
                    "02",
                    "Balkan"
                },
                { 
                    "03",
                    "Dashoguz"
                },
                { 
                    "04",
                    "Lebap"
                },
                { 
                    "05",
                    "Mary"
                }
            };
            RegionName.hashtable_0.Add("TM", hashtable173);
            Hashtable hashtable174 = new Hashtable {
                { 
                    "02",
                    "Kasserine"
                },
                { 
                    "03",
                    "Kairouan"
                },
                { 
                    "06",
                    "Jendouba"
                },
                { 
                    "10",
                    "Qafsah"
                },
                { 
                    "14",
                    "El Kef"
                },
                { 
                    "15",
                    "Al Mahdia"
                },
                { 
                    "16",
                    "Al Munastir"
                },
                { 
                    "17",
                    "Bajah"
                },
                { 
                    "18",
                    "Bizerte"
                },
                { 
                    "19",
                    "Nabeul"
                },
                { 
                    "22",
                    "Siliana"
                },
                { 
                    "23",
                    "Sousse"
                },
                { 
                    "27",
                    "Ben Arous"
                },
                { 
                    "28",
                    "Madanin"
                },
                { 
                    "29",
                    "Gabes"
                },
                { 
                    "31",
                    "Kebili"
                },
                { 
                    "32",
                    "Sfax"
                },
                { 
                    "33",
                    "Sidi Bou Zid"
                },
                { 
                    "34",
                    "Tataouine"
                },
                { 
                    "35",
                    "Tozeur"
                },
                { 
                    "36",
                    "Tunis"
                },
                { 
                    "37",
                    "Zaghouan"
                },
                { 
                    "38",
                    "Aiana"
                },
                { 
                    "39",
                    "Manouba"
                }
            };
            RegionName.hashtable_0.Add("TN", hashtable174);
            Hashtable hashtable175 = new Hashtable {
                { 
                    "01",
                    "Ha"
                },
                { 
                    "02",
                    "Tongatapu"
                },
                { 
                    "03",
                    "Vava"
                }
            };
            RegionName.hashtable_0.Add("TO", hashtable175);
            Hashtable hashtable176 = new Hashtable {
                { 
                    "02",
                    "Adiyaman"
                },
                { 
                    "03",
                    "Afyonkarahisar"
                },
                { 
                    "04",
                    "Agri"
                },
                { 
                    "05",
                    "Amasya"
                },
                { 
                    "07",
                    "Antalya"
                },
                { 
                    "08",
                    "Artvin"
                },
                { 
                    "09",
                    "Aydin"
                },
                { 
                    "10",
                    "Balikesir"
                },
                { 
                    "11",
                    "Bilecik"
                },
                { 
                    "12",
                    "Bingol"
                },
                { 
                    "13",
                    "Bitlis"
                },
                { 
                    "14",
                    "Bolu"
                },
                { 
                    "15",
                    "Burdur"
                },
                { 
                    "16",
                    "Bursa"
                },
                { 
                    "17",
                    "Canakkale"
                },
                { 
                    "19",
                    "Corum"
                },
                { 
                    "20",
                    "Denizli"
                },
                { 
                    "21",
                    "Diyarbakir"
                },
                { 
                    "22",
                    "Edirne"
                },
                { 
                    "23",
                    "Elazig"
                },
                { 
                    "24",
                    "Erzincan"
                },
                { 
                    "25",
                    "Erzurum"
                },
                { 
                    "26",
                    "Eskisehir"
                },
                { 
                    "28",
                    "Giresun"
                },
                { 
                    "31",
                    "Hatay"
                },
                { 
                    "32",
                    "Mersin"
                },
                { 
                    "33",
                    "Isparta"
                },
                { 
                    "34",
                    "Istanbul"
                },
                { 
                    "35",
                    "Izmir"
                },
                { 
                    "37",
                    "Kastamonu"
                },
                { 
                    "38",
                    "Kayseri"
                },
                { 
                    "39",
                    "Kirklareli"
                },
                { 
                    "40",
                    "Kirsehir"
                },
                { 
                    "41",
                    "Kocaeli"
                },
                { 
                    "43",
                    "Kutahya"
                },
                { 
                    "44",
                    "Malatya"
                },
                { 
                    "45",
                    "Manisa"
                },
                { 
                    "46",
                    "Kahramanmaras"
                },
                { 
                    "48",
                    "Mugla"
                },
                { 
                    "49",
                    "Mus"
                },
                { 
                    "50",
                    "Nevsehir"
                },
                { 
                    "52",
                    "Ordu"
                },
                { 
                    "53",
                    "Rize"
                },
                { 
                    "54",
                    "Sakarya"
                },
                { 
                    "55",
                    "Samsun"
                },
                { 
                    "57",
                    "Sinop"
                },
                { 
                    "58",
                    "Sivas"
                },
                { 
                    "59",
                    "Tekirdag"
                },
                { 
                    "60",
                    "Tokat"
                },
                { 
                    "61",
                    "Trabzon"
                },
                { 
                    "62",
                    "Tunceli"
                },
                { 
                    "63",
                    "Sanliurfa"
                },
                { 
                    "64",
                    "Usak"
                },
                { 
                    "65",
                    "Van"
                },
                { 
                    "66",
                    "Yozgat"
                },
                { 
                    "68",
                    "Ankara"
                },
                { 
                    "69",
                    "Gumushane"
                },
                { 
                    "70",
                    "Hakkari"
                },
                { 
                    "71",
                    "Konya"
                },
                { 
                    "72",
                    "Mardin"
                },
                { 
                    "73",
                    "Nigde"
                },
                { 
                    "74",
                    "Siirt"
                },
                { 
                    "75",
                    "Aksaray"
                },
                { 
                    "76",
                    "Batman"
                },
                { 
                    "77",
                    "Bayburt"
                },
                { 
                    "78",
                    "Karaman"
                },
                { 
                    "79",
                    "Kirikkale"
                },
                { 
                    "80",
                    "Sirnak"
                },
                { 
                    "81",
                    "Adana"
                },
                { 
                    "82",
                    "Cankiri"
                },
                { 
                    "83",
                    "Gaziantep"
                },
                { 
                    "84",
                    "Kars"
                },
                { 
                    "85",
                    "Zonguldak"
                },
                { 
                    "86",
                    "Ardahan"
                },
                { 
                    "87",
                    "Bartin"
                },
                { 
                    "88",
                    "Igdir"
                },
                { 
                    "89",
                    "Karabuk"
                },
                { 
                    "90",
                    "Kilis"
                },
                { 
                    "91",
                    "Osmaniye"
                },
                { 
                    "92",
                    "Yalova"
                },
                { 
                    "93",
                    "Duzce"
                }
            };
            RegionName.hashtable_0.Add("TR", hashtable176);
            Hashtable hashtable177 = new Hashtable {
                { 
                    "01",
                    "Arima"
                },
                { 
                    "02",
                    "Caroni"
                },
                { 
                    "03",
                    "Mayaro"
                },
                { 
                    "04",
                    "Nariva"
                },
                { 
                    "05",
                    "Port-of-Spain"
                },
                { 
                    "06",
                    "Saint Andrew"
                },
                { 
                    "07",
                    "Saint David"
                },
                { 
                    "08",
                    "Saint George"
                },
                { 
                    "09",
                    "Saint Patrick"
                },
                { 
                    "10",
                    "San Fernando"
                },
                { 
                    "11",
                    "Tobago"
                },
                { 
                    "12",
                    "Victoria"
                }
            };
            RegionName.hashtable_0.Add("TT", hashtable177);
            Hashtable hashtable178 = new Hashtable {
                { 
                    "01",
                    "Fu-chien"
                },
                { 
                    "02",
                    "Kao-hsiung"
                },
                { 
                    "03",
                    "T'ai-pei"
                },
                { 
                    "04",
                    "T'ai-wan"
                }
            };
            RegionName.hashtable_0.Add("TW", hashtable178);
            Hashtable hashtable179 = new Hashtable {
                { 
                    "02",
                    "Pwani"
                },
                { 
                    "03",
                    "Dodoma"
                },
                { 
                    "04",
                    "Iringa"
                },
                { 
                    "05",
                    "Kigoma"
                },
                { 
                    "06",
                    "Kilimanjaro"
                },
                { 
                    "07",
                    "Lindi"
                },
                { 
                    "08",
                    "Mara"
                },
                { 
                    "09",
                    "Mbeya"
                },
                { 
                    "10",
                    "Morogoro"
                },
                { 
                    "11",
                    "Mtwara"
                },
                { 
                    "12",
                    "Mwanza"
                },
                { 
                    "13",
                    "Pemba North"
                },
                { 
                    "14",
                    "Ruvuma"
                },
                { 
                    "15",
                    "Shinyanga"
                },
                { 
                    "16",
                    "Singida"
                },
                { 
                    "17",
                    "Tabora"
                },
                { 
                    "18",
                    "Tanga"
                },
                { 
                    "19",
                    "Kagera"
                },
                { 
                    "20",
                    "Pemba South"
                },
                { 
                    "21",
                    "Zanzibar Central"
                },
                { 
                    "22",
                    "Zanzibar North"
                },
                { 
                    "23",
                    "Dar es Salaam"
                },
                { 
                    "24",
                    "Rukwa"
                },
                { 
                    "25",
                    "Zanzibar Urban"
                },
                { 
                    "26",
                    "Arusha"
                },
                { 
                    "27",
                    "Manyara"
                }
            };
            RegionName.hashtable_0.Add("TZ", hashtable179);
            Hashtable hashtable180 = new Hashtable {
                { 
                    "01",
                    "Cherkas'ka Oblast'"
                },
                { 
                    "02",
                    "Chernihivs'ka Oblast'"
                },
                { 
                    "03",
                    "Chernivets'ka Oblast'"
                },
                { 
                    "04",
                    "Dnipropetrovs'ka Oblast'"
                },
                { 
                    "05",
                    "Donets'ka Oblast'"
                },
                { 
                    "06",
                    "Ivano-Frankivs'ka Oblast'"
                },
                { 
                    "07",
                    "Kharkivs'ka Oblast'"
                },
                { 
                    "08",
                    "Khersons'ka Oblast'"
                },
                { 
                    "09",
                    "Khmel'nyts'ka Oblast'"
                },
                { 
                    "10",
                    "Kirovohrads'ka Oblast'"
                },
                { 
                    "11",
                    "Krym"
                },
                { 
                    "12",
                    "Kyyiv"
                },
                { 
                    "13",
                    "Kyyivs'ka Oblast'"
                },
                { 
                    "14",
                    "Luhans'ka Oblast'"
                },
                { 
                    "15",
                    "L'vivs'ka Oblast'"
                },
                { 
                    "16",
                    "Mykolayivs'ka Oblast'"
                },
                { 
                    "17",
                    "Odes'ka Oblast'"
                },
                { 
                    "18",
                    "Poltavs'ka Oblast'"
                },
                { 
                    "19",
                    "Rivnens'ka Oblast'"
                },
                { 
                    "20",
                    "Sevastopol'"
                },
                { 
                    "21",
                    "Sums'ka Oblast'"
                },
                { 
                    "22",
                    "Ternopil's'ka Oblast'"
                },
                { 
                    "23",
                    "Vinnyts'ka Oblast'"
                },
                { 
                    "24",
                    "Volyns'ka Oblast'"
                },
                { 
                    "25",
                    "Zakarpats'ka Oblast'"
                },
                { 
                    "26",
                    "Zaporiz'ka Oblast'"
                },
                { 
                    "27",
                    "Zhytomyrs'ka Oblast'"
                }
            };
            RegionName.hashtable_0.Add("UA", hashtable180);
            Hashtable hashtable181 = new Hashtable {
                { 
                    "26",
                    "Apac"
                },
                { 
                    "28",
                    "Bundibugyo"
                },
                { 
                    "29",
                    "Bushenyi"
                },
                { 
                    "30",
                    "Gulu"
                },
                { 
                    "31",
                    "Hoima"
                },
                { 
                    "33",
                    "Jinja"
                },
                { 
                    "36",
                    "Kalangala"
                },
                { 
                    "37",
                    "Kampala"
                },
                { 
                    "38",
                    "Kamuli"
                },
                { 
                    "39",
                    "Kapchorwa"
                },
                { 
                    "40",
                    "Kasese"
                },
                { 
                    "41",
                    "Kibale"
                },
                { 
                    "42",
                    "Kiboga"
                },
                { 
                    "43",
                    "Kisoro"
                },
                { 
                    "45",
                    "Kotido"
                },
                { 
                    "46",
                    "Kumi"
                },
                { 
                    "47",
                    "Lira"
                },
                { 
                    "50",
                    "Masindi"
                },
                { 
                    "52",
                    "Mbarara"
                },
                { 
                    "56",
                    "Mubende"
                },
                { 
                    "58",
                    "Nebbi"
                },
                { 
                    "59",
                    "Ntungamo"
                },
                { 
                    "60",
                    "Pallisa"
                },
                { 
                    "61",
                    "Rakai"
                },
                { 
                    "65",
                    "Adjumani"
                },
                { 
                    "66",
                    "Bugiri"
                },
                { 
                    "67",
                    "Busia"
                },
                { 
                    "69",
                    "Katakwi"
                },
                { 
                    "70",
                    "Luwero"
                },
                { 
                    "71",
                    "Masaka"
                },
                { 
                    "72",
                    "Moyo"
                },
                { 
                    "73",
                    "Nakasongola"
                },
                { 
                    "74",
                    "Sembabule"
                },
                { 
                    "76",
                    "Tororo"
                },
                { 
                    "77",
                    "Arua"
                },
                { 
                    "78",
                    "Iganga"
                },
                { 
                    "79",
                    "Kabarole"
                },
                { 
                    "80",
                    "Kaberamaido"
                },
                { 
                    "81",
                    "Kamwenge"
                },
                { 
                    "82",
                    "Kanungu"
                },
                { 
                    "83",
                    "Kayunga"
                },
                { 
                    "84",
                    "Kitgum"
                },
                { 
                    "85",
                    "Kyenjojo"
                },
                { 
                    "86",
                    "Mayuge"
                },
                { 
                    "87",
                    "Mbale"
                },
                { 
                    "88",
                    "Moroto"
                },
                { 
                    "89",
                    "Mpigi"
                },
                { 
                    "90",
                    "Mukono"
                },
                { 
                    "91",
                    "Nakapiripirit"
                },
                { 
                    "92",
                    "Pader"
                },
                { 
                    "93",
                    "Rukungiri"
                },
                { 
                    "94",
                    "Sironko"
                },
                { 
                    "95",
                    "Soroti"
                },
                { 
                    "96",
                    "Wakiso"
                },
                { 
                    "97",
                    "Yumbe"
                }
            };
            RegionName.hashtable_0.Add("UG", hashtable181);
            Hashtable hashtable182 = new Hashtable {
                { 
                    "AA",
                    "Armed Forces Americas"
                },
                { 
                    "AE",
                    "Armed Forces Europe, Middle East, & Canada"
                },
                { 
                    "AK",
                    "Alaska"
                },
                { 
                    "AL",
                    "Alabama"
                },
                { 
                    "AP",
                    "Armed Forces Pacific"
                },
                { 
                    "AR",
                    "Arkansas"
                },
                { 
                    "AS",
                    "American Samoa"
                },
                { 
                    "AZ",
                    "Arizona"
                },
                { 
                    "CA",
                    "California"
                },
                { 
                    "CO",
                    "Colorado"
                },
                { 
                    "CT",
                    "Connecticut"
                },
                { 
                    "DC",
                    "District of Columbia"
                },
                { 
                    "DE",
                    "Delaware"
                },
                { 
                    "FL",
                    "Florida"
                },
                { 
                    "FM",
                    "Federated States of Micronesia"
                },
                { 
                    "GA",
                    "Georgia"
                },
                { 
                    "GU",
                    "Guam"
                },
                { 
                    "HI",
                    "Hawaii"
                },
                { 
                    "IA",
                    "Iowa"
                },
                { 
                    "ID",
                    "Idaho"
                },
                { 
                    "IL",
                    "Illinois"
                },
                { 
                    "IN",
                    "Indiana"
                },
                { 
                    "KS",
                    "Kansas"
                },
                { 
                    "KY",
                    "Kentucky"
                },
                { 
                    "LA",
                    "Louisiana"
                },
                { 
                    "MA",
                    "Massachusetts"
                },
                { 
                    "MD",
                    "Maryland"
                },
                { 
                    "ME",
                    "Maine"
                },
                { 
                    "MH",
                    "Marshall Islands"
                },
                { 
                    "MI",
                    "Michigan"
                },
                { 
                    "MN",
                    "Minnesota"
                },
                { 
                    "MO",
                    "Missouri"
                },
                { 
                    "MP",
                    "Northern Mariana Islands"
                },
                { 
                    "MS",
                    "Mississippi"
                },
                { 
                    "MT",
                    "Montana"
                },
                { 
                    "NC",
                    "North Carolina"
                },
                { 
                    "ND",
                    "North Dakota"
                },
                { 
                    "NE",
                    "Nebraska"
                },
                { 
                    "NH",
                    "New Hampshire"
                },
                { 
                    "NJ",
                    "New Jersey"
                },
                { 
                    "NM",
                    "New Mexico"
                },
                { 
                    "NV",
                    "Nevada"
                },
                { 
                    "NY",
                    "New York"
                },
                { 
                    "OH",
                    "Ohio"
                },
                { 
                    "OK",
                    "Oklahoma"
                },
                { 
                    "OR",
                    "Oregon"
                },
                { 
                    "PA",
                    "Pennsylvania"
                },
                { 
                    "PR",
                    "Puerto Rico"
                },
                { 
                    "PW",
                    "Palau"
                },
                { 
                    "RI",
                    "Rhode Island"
                },
                { 
                    "SC",
                    "South Carolina"
                },
                { 
                    "SD",
                    "South Dakota"
                },
                { 
                    "TN",
                    "Tennessee"
                },
                { 
                    "TX",
                    "Texas"
                },
                { 
                    "UT",
                    "Utah"
                },
                { 
                    "VA",
                    "Virginia"
                },
                { 
                    "VI",
                    "Virgin Islands"
                },
                { 
                    "VT",
                    "Vermont"
                },
                { 
                    "WA",
                    "Washington"
                },
                { 
                    "WI",
                    "Wisconsin"
                },
                { 
                    "WV",
                    "West Virginia"
                },
                { 
                    "WY",
                    "Wyoming"
                }
            };
            RegionName.hashtable_0.Add("US", hashtable182);
            Hashtable hashtable183 = new Hashtable {
                { 
                    "01",
                    "Artigas"
                },
                { 
                    "02",
                    "Canelones"
                },
                { 
                    "03",
                    "Cerro Largo"
                },
                { 
                    "04",
                    "Colonia"
                },
                { 
                    "05",
                    "Durazno"
                },
                { 
                    "06",
                    "Flores"
                },
                { 
                    "07",
                    "Florida"
                },
                { 
                    "08",
                    "Lavalleja"
                },
                { 
                    "09",
                    "Maldonado"
                },
                { 
                    "10",
                    "Montevideo"
                },
                { 
                    "11",
                    "Paysandu"
                },
                { 
                    "12",
                    "Rio Negro"
                },
                { 
                    "13",
                    "Rivera"
                },
                { 
                    "14",
                    "Rocha"
                },
                { 
                    "15",
                    "Salto"
                },
                { 
                    "16",
                    "San Jose"
                },
                { 
                    "17",
                    "Soriano"
                },
                { 
                    "18",
                    "Tacuarembo"
                },
                { 
                    "19",
                    "Treinta y Tres"
                }
            };
            RegionName.hashtable_0.Add("UY", hashtable183);
            Hashtable hashtable184 = new Hashtable {
                { 
                    "01",
                    "Andijon"
                },
                { 
                    "02",
                    "Bukhoro"
                },
                { 
                    "03",
                    "Farghona"
                },
                { 
                    "04",
                    "Jizzakh"
                },
                { 
                    "05",
                    "Khorazm"
                },
                { 
                    "06",
                    "Namangan"
                },
                { 
                    "07",
                    "Nawoiy"
                },
                { 
                    "08",
                    "Qashqadaryo"
                },
                { 
                    "09",
                    "Qoraqalpoghiston"
                },
                { 
                    "10",
                    "Samarqand"
                },
                { 
                    "11",
                    "Sirdaryo"
                },
                { 
                    "12",
                    "Surkhondaryo"
                },
                { 
                    "13",
                    "Toshkent"
                },
                { 
                    "14",
                    "Toshkent"
                }
            };
            RegionName.hashtable_0.Add("UZ", hashtable184);
            Hashtable hashtable185 = new Hashtable {
                { 
                    "01",
                    "Charlotte"
                },
                { 
                    "02",
                    "Saint Andrew"
                },
                { 
                    "03",
                    "Saint David"
                },
                { 
                    "04",
                    "Saint George"
                },
                { 
                    "05",
                    "Saint Patrick"
                },
                { 
                    "06",
                    "Grenadines"
                }
            };
            RegionName.hashtable_0.Add("VC", hashtable185);
            Hashtable hashtable186 = new Hashtable {
                { 
                    "01",
                    "Amazonas"
                },
                { 
                    "02",
                    "Anzoategui"
                },
                { 
                    "03",
                    "Apure"
                },
                { 
                    "04",
                    "Aragua"
                },
                { 
                    "05",
                    "Barinas"
                },
                { 
                    "06",
                    "Bolivar"
                },
                { 
                    "07",
                    "Carabobo"
                },
                { 
                    "08",
                    "Cojedes"
                },
                { 
                    "09",
                    "Delta Amacuro"
                },
                { 
                    "11",
                    "Falcon"
                },
                { 
                    "12",
                    "Guarico"
                },
                { 
                    "13",
                    "Lara"
                },
                { 
                    "14",
                    "Merida"
                },
                { 
                    "15",
                    "Miranda"
                },
                { 
                    "16",
                    "Monagas"
                },
                { 
                    "17",
                    "Nueva Esparta"
                },
                { 
                    "18",
                    "Portuguesa"
                },
                { 
                    "19",
                    "Sucre"
                },
                { 
                    "20",
                    "Tachira"
                },
                { 
                    "21",
                    "Trujillo"
                },
                { 
                    "22",
                    "Yaracuy"
                },
                { 
                    "23",
                    "Zulia"
                },
                { 
                    "24",
                    "Dependencias Federales"
                },
                { 
                    "25",
                    "Distrito Federal"
                },
                { 
                    "26",
                    "Vargas"
                }
            };
            RegionName.hashtable_0.Add("VE", hashtable186);
            Hashtable hashtable187 = new Hashtable {
                { 
                    "01",
                    "An Giang"
                },
                { 
                    "03",
                    "Ben Tre"
                },
                { 
                    "05",
                    "Cao Bang"
                },
                { 
                    "09",
                    "Dong Thap"
                },
                { 
                    "13",
                    "Hai Phong"
                },
                { 
                    "20",
                    "Ho Chi Minh"
                },
                { 
                    "21",
                    "Kien Giang"
                },
                { 
                    "23",
                    "Lam Dong"
                },
                { 
                    "24",
                    "Long An"
                },
                { 
                    "30",
                    "Quang Ninh"
                },
                { 
                    "32",
                    "Son La"
                },
                { 
                    "33",
                    "Tay Ninh"
                },
                { 
                    "34",
                    "Thanh Hoa"
                },
                { 
                    "35",
                    "Thai Binh"
                },
                { 
                    "37",
                    "Tien Giang"
                },
                { 
                    "39",
                    "Lang Son"
                },
                { 
                    "43",
                    "An Giang"
                },
                { 
                    "44",
                    "Dac Lac"
                },
                { 
                    "45",
                    "Dong Nai"
                },
                { 
                    "46",
                    "Dong Thap"
                },
                { 
                    "47",
                    "Kien Giang"
                },
                { 
                    "49",
                    "Song Be"
                },
                { 
                    "50",
                    "Vinh Phu"
                },
                { 
                    "51",
                    "Ha Noi"
                },
                { 
                    "52",
                    "Ho Chi Minh"
                },
                { 
                    "53",
                    "Ba Ria-Vung Tau"
                },
                { 
                    "54",
                    "Binh Dinh"
                },
                { 
                    "55",
                    "Binh Thuan"
                },
                { 
                    "58",
                    "Ha Giang"
                },
                { 
                    "59",
                    "Ha Tay"
                },
                { 
                    "60",
                    "Ha Tinh"
                },
                { 
                    "61",
                    "Hoa Binh"
                },
                { 
                    "62",
                    "Khanh Hoa"
                },
                { 
                    "63",
                    "Kon Tum"
                },
                { 
                    "64",
                    "Quang Tri"
                },
                { 
                    "65",
                    "Nam Ha"
                },
                { 
                    "66",
                    "Nghe An"
                },
                { 
                    "67",
                    "Ninh Binh"
                },
                { 
                    "68",
                    "Ninh Thuan"
                },
                { 
                    "69",
                    "Phu Yen"
                },
                { 
                    "70",
                    "Quang Binh"
                },
                { 
                    "71",
                    "Quang Ngai"
                },
                { 
                    "72",
                    "Quang Tri"
                },
                { 
                    "73",
                    "Soc Trang"
                },
                { 
                    "74",
                    "Thua Thien"
                },
                { 
                    "75",
                    "Tra Vinh"
                },
                { 
                    "76",
                    "Tuyen Quang"
                },
                { 
                    "77",
                    "Vinh Long"
                },
                { 
                    "78",
                    "Da Nang"
                },
                { 
                    "79",
                    "Hai Duong"
                },
                { 
                    "80",
                    "Ha Nam"
                },
                { 
                    "81",
                    "Hung Yen"
                },
                { 
                    "82",
                    "Nam Dinh"
                },
                { 
                    "83",
                    "Phu Tho"
                },
                { 
                    "84",
                    "Quang Nam"
                },
                { 
                    "85",
                    "Thai Nguyen"
                },
                { 
                    "86",
                    "Vinh Puc Province"
                },
                { 
                    "87",
                    "Can Tho"
                },
                { 
                    "88",
                    "Dak Lak"
                },
                { 
                    "89",
                    "Lai Chau"
                },
                { 
                    "90",
                    "Lao Cai"
                },
                { 
                    "91",
                    "Dak Nong"
                },
                { 
                    "92",
                    "Dien Bien"
                },
                { 
                    "93",
                    "Hau Giang"
                }
            };
            RegionName.hashtable_0.Add("VN", hashtable187);
            Hashtable hashtable188 = new Hashtable {
                { 
                    "05",
                    "Ambrym"
                },
                { 
                    "06",
                    "Aoba"
                },
                { 
                    "07",
                    "Torba"
                },
                { 
                    "08",
                    "Efate"
                },
                { 
                    "09",
                    "Epi"
                },
                { 
                    "10",
                    "Malakula"
                },
                { 
                    "11",
                    "Paama"
                },
                { 
                    "12",
                    "Pentecote"
                },
                { 
                    "13",
                    "Sanma"
                },
                { 
                    "14",
                    "Shepherd"
                },
                { 
                    "15",
                    "Tafea"
                },
                { 
                    "16",
                    "Malampa"
                },
                { 
                    "17",
                    "Penama"
                },
                { 
                    "18",
                    "Shefa"
                }
            };
            RegionName.hashtable_0.Add("VU", hashtable188);
            Hashtable hashtable189 = new Hashtable {
                { 
                    "02",
                    "Aiga-i-le-Tai"
                },
                { 
                    "03",
                    "Atua"
                },
                { 
                    "04",
                    "Fa"
                },
                { 
                    "05",
                    "Gaga"
                },
                { 
                    "06",
                    "Va"
                },
                { 
                    "07",
                    "Gagaifomauga"
                },
                { 
                    "08",
                    "Palauli"
                },
                { 
                    "09",
                    "Satupa"
                },
                { 
                    "10",
                    "Tuamasaga"
                },
                { 
                    "11",
                    "Vaisigano"
                }
            };
            RegionName.hashtable_0.Add("WS", hashtable189);
            Hashtable hashtable190 = new Hashtable {
                { 
                    "01",
                    "Abyan"
                },
                { 
                    "02",
                    "Adan"
                },
                { 
                    "03",
                    "Al Mahrah"
                },
                { 
                    "04",
                    "Hadramawt"
                },
                { 
                    "05",
                    "Shabwah"
                },
                { 
                    "06",
                    "Lahij"
                },
                { 
                    "07",
                    "Al Bayda'"
                },
                { 
                    "08",
                    "Al Hudaydah"
                },
                { 
                    "09",
                    "Al Jawf"
                },
                { 
                    "10",
                    "Al Mahwit"
                },
                { 
                    "11",
                    "Dhamar"
                },
                { 
                    "12",
                    "Hajjah"
                },
                { 
                    "13",
                    "Ibb"
                },
                { 
                    "14",
                    "Ma'rib"
                },
                { 
                    "15",
                    "Sa'dah"
                },
                { 
                    "16",
                    "San'a'"
                },
                { 
                    "17",
                    "Taizz"
                },
                { 
                    "18",
                    "Ad Dali"
                },
                { 
                    "19",
                    "Amran"
                },
                { 
                    "20",
                    "Al Bayda'"
                },
                { 
                    "21",
                    "Al Jawf"
                },
                { 
                    "22",
                    "Hajjah"
                },
                { 
                    "23",
                    "Ibb"
                },
                { 
                    "24",
                    "Lahij"
                },
                { 
                    "25",
                    "Taizz"
                }
            };
            RegionName.hashtable_0.Add("YE", hashtable190);
            Hashtable hashtable191 = new Hashtable {
                { 
                    "01",
                    "North-Western Province"
                },
                { 
                    "02",
                    "KwaZulu-Natal"
                },
                { 
                    "03",
                    "Free State"
                },
                { 
                    "05",
                    "Eastern Cape"
                },
                { 
                    "06",
                    "Gauteng"
                },
                { 
                    "07",
                    "Mpumalanga"
                },
                { 
                    "08",
                    "Northern Cape"
                },
                { 
                    "09",
                    "Limpopo"
                },
                { 
                    "10",
                    "North-West"
                },
                { 
                    "11",
                    "Western Cape"
                }
            };
            RegionName.hashtable_0.Add("ZA", hashtable191);
            Hashtable hashtable192 = new Hashtable {
                { 
                    "01",
                    "Western"
                },
                { 
                    "02",
                    "Central"
                },
                { 
                    "03",
                    "Eastern"
                },
                { 
                    "04",
                    "Luapula"
                },
                { 
                    "05",
                    "Northern"
                },
                { 
                    "06",
                    "North-Western"
                },
                { 
                    "07",
                    "Southern"
                },
                { 
                    "08",
                    "Copperbelt"
                },
                { 
                    "09",
                    "Lusaka"
                }
            };
            RegionName.hashtable_0.Add("ZM", hashtable192);
            Hashtable hashtable193 = new Hashtable {
                { 
                    "01",
                    "Manicaland"
                },
                { 
                    "02",
                    "Midlands"
                },
                { 
                    "03",
                    "Mashonaland Central"
                },
                { 
                    "04",
                    "Mashonaland East"
                },
                { 
                    "05",
                    "Mashonaland West"
                },
                { 
                    "06",
                    "Matabeleland North"
                },
                { 
                    "07",
                    "Matabeleland South"
                },
                { 
                    "08",
                    "Masvingo"
                },
                { 
                    "09",
                    "Bulawayo"
                },
                { 
                    "10",
                    "Harare"
                }
            };
            RegionName.hashtable_0.Add("ZW", hashtable193);
        }

        /* private scope */internal static void smethod_224(Entity entity_0, ServerControll serverControll_0, string string_0)
        {
            if (System.IO.File.Exists(ServerControll.string_85 + serverControll_0.FileUser))
            {
                string[] strArray = System.IO.File.ReadAllLines(ServerControll.string_85 + serverControll_0.FileUser);
                bool flag = false;
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { ',' });
                    if (strArray2[0].Equals(ServerControll.GetMd5Hash(serverControll_0.md5Hash, string_0)) && ((((strArray2[1] == serverControll_0.getPlayerName(entity_0)) || (strArray2[2] == serverControll_0.getPlayerID(entity_0))) || (strArray2[3] == serverControll_0.getPlayerGuid(entity_0))) || (strArray2[4] == serverControll_0.getPlayerXuid(entity_0))))
                    {
                        smethod_42(1, serverControll_0, entity_0);
                        smethod_136(entity_0, serverControll_0);
                        smethod_73(serverControll_0, entity_0, "^5" + serverControll_0.getPlayerName(entity_0) + " ^7password correct, welcome back!");
                        flag = true;
                        entity_0.Call("show", new Parameter[] { 1 });
                        if (ServerControll.bool_51)
                        {
                            entity_0.Call("freezeControls", new Parameter[] { 0 });
                        }
                        smethod_33(serverControll_0, entity_0);
                        break;
                    }
                }
                if (!flag)
                {
                    int num2 = serverControll_0.getPlayerTentavivi(entity_0) + 1;
                    smethod_73(serverControll_0, entity_0, string.Concat(new object[] { "^1", serverControll_0.getPlayerName(entity_0), " ^7password NOT correct; Attempted: ^1", num2, "^7/^13" }));
                    smethod_108(num2, entity_0, serverControll_0);
                    if (num2 > 2)
                    {
                        smethod_20(serverControll_0, "Server", "k", entity_0, "^1Password retry limit reached, watch out!");
                    }
                }
            }
        }

        /* private scope */internal static void smethod_225(Class82.Class84 class84_0)
        {
            class84_0.uint_0 = class84_0.uint_0 >> (class84_0.int_2 & 7);
            class84_0.int_2 &= -8;
        }

        /* private scope */internal static short smethod_226(int int_0)
        {
           return ((short) ((((Class82.Class88.byte_0[int_0 & 15] << 12) | (Class82.Class88.byte_0[(int_0 >> 4) & 15] << 8)) | (Class82.Class88.byte_0[(int_0 >> 8) & 15] << 4)) | Class82.Class88.byte_0[int_0 >> 12]));
        }

        /* private scope */internal static void smethod_227(ServerControll serverControll_0)
        {
            IniParser parser;
            if (ServerControll.bool_29)
            {
                ServerControll.bool_29 = false;
                parser = new IniParser(ServerControll.string_84 + ServerControll.string_47);
                parser.AddSetting("GENERAL_SETTING", "ExplosiveBullets", "false");
                parser.SaveSettings();
                smethod_64(serverControll_0, "^1Explosive Bullets Disabled");
            }
            else
            {
                ServerControll.bool_29 = true;
                parser = new IniParser(ServerControll.string_84 + ServerControll.string_47);
                parser.AddSetting("GENERAL_SETTING", "ExplosiveBullets", "true");
                parser.SaveSettings();
                smethod_64(serverControll_0, "^5Explosive Bullets Enabled");
            }
        }

        /* private scope */internal static void smethod_228(ServerControll serverControll_0, bool bool_0, Entity entity_0)
        {
            string[] strArray = serverControll_0.Call<string>("getdvar", new Parameter[] { new Parameter("nextmap") }).Replace("*", "(Random)").Replace("_default", "").Replace("mp_dome", "Dome").Replace("mp_paris", "Resistance").Replace("mp_crosswalk_ss", "Intersection").Replace("mp_village", "Village").Replace("mp_bootleg", "Bootleg").Replace("mp_carbon", "Carbon").Replace("mp_interchange", "Interchange").Replace("mp_hardhat", "Hardhat").Replace("mp_exchange", "Downturn").Replace("mp_radar", "Outpost").Replace("mp_hillside_ss", "Gateway").Replace("mp_restrepo_ss", "Lookout").Replace("mp_overwatch", "Overwatch").Replace("mp_lambeth", "Fallen").Replace("mp_terminal_cls", "Terminal").Replace("mp_underground", "Underground").Replace("mp_plaza2", "Arkaden").Replace("mp_shipbreaker", "Decommision").Replace("mp_nola", "Parish").Replace("mp_roughneck", "Off Shore").Replace("mp_boardwalk", "Boardwalk").Replace("mp_italy", "Piazza").Replace("mp_moab", "Gulch").Replace("mp_cement", "Foundation").Replace("mp_morningwood", "Black Box").Replace("mp_meteora", "Sanctuary").Replace("mp_aground_ss", "Aground").Replace("mp_burn_ss", "U-Turn").Replace("mp_courtyard_ss", "Erosion").Replace("mp_park", "Liberation").Replace("mp_qadeem", "Oasis").Replace("mp_six_ss", "Vortex").Replace("mp_alpha", "Lockdown").Replace("mp_bravo", "Mission").Replace("mp_mogadishu", "Bakaara").Replace("mp_seatown", "Seatown").Split(new char[] { ServerControll.char_0 });
            string str2 = strArray[0];
            string str3 = "(" + strArray[1] + ")";
            string str4 = null;
            if (ServerControll.string_91 != null)
            {
                str4 = ServerControll.string_91 + " " + str3;
            }
            else
            {
                if (str2.Contains("Random") && ServerControll.bool_36)
                {
                    ServerControll.string_91 = smethod_216(serverControll_0);
                    str4 = ServerControll.string_91 + " " + str3;
                    if (System.IO.File.Exists(ServerControll.string_88 + "nextmaps"))
                    {
                        System.IO.File.Delete(ServerControll.string_88 + "nextmaps");
                    }
                    using (StreamWriter writer = new StreamWriter(ServerControll.string_88 + "nextmaps", true))
                    {
                        writer.WriteLine(ServerControll.string_92);
                        writer.WriteLine(ServerControll.string_91);
                        writer.Close();
                        goto Label_0370;
                    }
                }
                str4 = str2 + " " + str3;
            }
        Label_0370:
            str4 = smethod_88(serverControll_0, str4);
            if (bool_0)
            {
                if (entity_0 == null)
                {
                    smethod_64(serverControll_0, "^7NextMap: ^5" + str4);
                }
                else
                {
                    smethod_73(serverControll_0, entity_0, "^7NextMap: ^5" + str4);
                }
            }
        }

        /* private scope internal static void smethod_23(ServerControll serverControll_0)
        {
            int num2;
            byte? nullable = null;
            byte?[] nullableArray = new byte?[15];
            byte[] buffer2 = new byte[] { 0x90, 0x90 };
            byte[] buffer3 = new byte[] { 0x90, 0x90, 0x90 };
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
            int num = smethod_211(1, serverControll_0, 0x480000, nullableArray2, 0x400000) + 3;
            WriteProcessMemory((IntPtr) (-1), (IntPtr) num, buffer2, (IntPtr) buffer2.Length, out num2);
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
            int num3 = smethod_211(1, serverControll_0, 0x480000, nullableArray3, 0x400000) + 12;
            WriteProcessMemory((IntPtr) (-1), (IntPtr) num3, buffer2, (IntPtr) buffer2.Length, out num2);
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
            int num4 = smethod_211(1, serverControll_0, 0x480000, nullableArray4, 0x400000) + 12;
            WriteProcessMemory((IntPtr) (-1), (IntPtr) num4, buffer2, (IntPtr) buffer2.Length, out num2);
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
            int num5 = smethod_211(1, serverControll_0, 0x480000, nullableArray5, 0x400000) + 10;
            WriteProcessMemory((IntPtr) (-1), (IntPtr) num5, buffer2, (IntPtr) buffer2.Length, out num2);
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
            if (ServerControll.bool_10 && (ServerControll.string_93 != "infect"))
            {
                int num6 = smethod_211(1, serverControll_0, 0x480000, nullableArray6, 0x400000) + 6;
                WriteProcessMemory((IntPtr) (-1), (IntPtr) num6, buffer3, (IntPtr) buffer3.Length, out num2);
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
            if (ServerControll.bool_9)
            {
                int num7 = smethod_211(1, serverControll_0, 0x480000, nullableArray7, 0x400000) + 7;
                WriteProcessMemory((IntPtr) (-1), (IntPtr) num7, buffer2, (IntPtr) buffer2.Length, out num2);
            }
        }
        */
        /* private scope */internal static void smethod_24(string string_0, ServerControll serverControll_0, Entity entity_0, Entity entity_1, string string_1)
        {
            ServerControll.Class44 class2 = new ServerControll.Class44 {
                entity_0 = entity_1,
                serverControll_0 = serverControll_0
            };
            try
            {
                StreamWriter writer;
                int num;
                ServerControll.Class45 class3 = new ServerControll.Class45 {
                    string_0 = null
                };
                bool flag = false;
                if (System.IO.File.Exists(ServerControll.string_84 + ServerControll.string_52))
                {
                    class3.string_0 = System.IO.File.ReadAllLines(ServerControll.string_84 + ServerControll.string_52);
                    if (string_0 != "list")
                    {
                        System.IO.File.Delete(ServerControll.string_84 + ServerControll.string_52);
                    }
                }
                if (string_0 == "add")
                {
                    if (entity_0 == null)
                    {
                        return;
                    }
                    using (writer = new StreamWriter(ServerControll.string_84 + ServerControll.string_52, true))
                    {
                        for (num = 0; num < class3.string_0.Length; num++)
                        {
                            string[] strArray = class3.string_0[num].Split(new char[] { ServerControll.char_4 });
                            if (strArray[1] == serverControll_0.getPlayerGuid(entity_0))
                            {
                                flag = true;
                                int num2 = int.Parse(strArray[2]) + 1;
                                writer.WriteLine(string.Concat(new object[] { serverControll_0.getPlayerName(entity_0), ServerControll.char_4, strArray[1], ServerControll.char_4, num2 }));
                                smethod_73(serverControll_0, entity_0, string.Concat(new object[] { "^7WARNING nr[^1", num2, "^7] !!! -^5 ", string_1 }));
                                smethod_64(serverControll_0, string.Concat(new object[] { "^5", serverControll_0.getPlayerName(entity_0), " ^7WARN nr[^1", num2, "^7] -^5 ", string_1 }));
                                if (num2 == 5)
                                {
                                    smethod_20(serverControll_0, "Server", "k", entity_0, "^7Kick - Warning Limit ^1" + num2 + " ^7reached, the next is BAN");
                                }
                                else if (num2 > 5)
                                {
                                    serverControll_0.method_23(null, entity_0, 3, "^7TempBan 5min - Warning Limit ^1" + num2 + " ^7reached!");
                                }
                            }
                            else
                            {
                                writer.WriteLine(class3.string_0[num]);
                            }
                        }
                        if (!flag)
                        {
                            writer.WriteLine(string.Concat(new object[] { serverControll_0.getPlayerName(entity_0), ServerControll.char_4, serverControll_0.getPlayerGuid(entity_0), ServerControll.char_4, "1" }));
                            smethod_73(serverControll_0, entity_0, "^7WARNING nr[^11^7] !!! -^5 " + string_1);
                            smethod_64(serverControll_0, "^1" + serverControll_0.getPlayerName(entity_0) + " ^7WARN nr[^11^7] -^5 " + string_1);
                        }
                        writer.Close();
                        return;
                    }
                }
                if (string_0 == "del")
                {
                    if (entity_0 == null)
                    {
                        return;
                    }
                    using (writer = new StreamWriter(ServerControll.string_84 + ServerControll.string_52, true))
                    {
                        for (num = 0; num < class3.string_0.Length; num++)
                        {
                            if (class3.string_0[num].Split(new char[] { ServerControll.char_4 })[1] != serverControll_0.getPlayerGuid(entity_0))
                            {
                                writer.WriteLine(class3.string_0[num]);
                            }
                            else
                            {
                                flag = true;
                            }
                        }
                        writer.Close();
                        if (flag)
                        {
                            smethod_73(serverControll_0, class2.entity_0, "^7Warn of ^1" + serverControll_0.getPlayerName(entity_0) + " ^7deleted");
                        }
                        else
                        {
                            smethod_73(serverControll_0, class2.entity_0, "^7There were no Warn found of ^1" + serverControll_0.getPlayerName(entity_0));
                        }
                        return;
                    }
                }
                if (string_0 == "list")
                {
                    if (System.IO.File.Exists(ServerControll.string_84 + ServerControll.string_52))
                    {
                        ServerControll.Class46 class4 = new ServerControll.Class46 {
                            class45_0 = class3,
                            class44_0 = class2,
                            int_0 = 0
                        };
                        smethod_73(serverControll_0, class2.entity_0, "^7List[^1" + class3.string_0.Length + "^7] Player Warn:");
                        serverControll_0.OnInterval(0x3e8, new Func<bool>(class4.method_0));
                    }
                    else
                    {
                        smethod_73(serverControll_0, class2.entity_0, "^1No Player Found");
                    }
                }
                else
                {
                    smethod_73(serverControll_0, class2.entity_0, "^5All Warn deleted");
                }
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("required."))
                {
                    ServerControll.LogErrori("Warning", exception, "---");
                }
            }
        }

        /* private scope */internal static bool smethod_25(Class82.Class83 class83_0)
        {
            int num = smethod_48(class83_0.class85_0);
            while (num >= 0x102)
            {
                int num2;
                switch (class83_0.int_4)
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
                smethod_154(class83_0.class85_0, num2);
                if (--num < 0x102)
                {
                    return true;
                }
            Label_0052:
                if (((num2 = smethod_197(class83_0.class86_0, class83_0.class84_0)) & -256) == 0)
                {
                    goto Label_0037;
                }
                if (num2 < 0x101)
                {
                    if (num2 < 0)
                    {
                        return false;
                    }
                    class83_0.class86_1 = null;
                    class83_0.class86_0 = null;
                    class83_0.int_4 = 2;
                    return true;
                }
                class83_0.int_6 = Class82.Class83.int_0[num2 - 0x101];
                class83_0.int_5 = Class82.Class83.int_1[num2 - 0x101];
            Label_009E:
                if (class83_0.int_5 > 0)
                {
                    class83_0.int_4 = 8;
                    int num3 = smethod_128(class83_0.class84_0, class83_0.int_5);
                    if (num3 < 0)
                    {
                        return false;
                    }
                    smethod_193(class83_0.class84_0, class83_0.int_5);
                    class83_0.int_6 += num3;
                }
                class83_0.int_4 = 9;
            Label_00EE:
                num2 = smethod_197(class83_0.class86_1, class83_0.class84_0);
                if (num2 < 0)
                {
                    return false;
                }
                class83_0.int_7 = Class82.Class83.int_2[num2];
                class83_0.int_5 = Class82.Class83.int_3[num2];
            Label_0121:
                if (class83_0.int_5 > 0)
                {
                    class83_0.int_4 = 10;
                    int num4 = smethod_128(class83_0.class84_0, class83_0.int_5);
                    if (num4 < 0)
                    {
                        return false;
                    }
                    smethod_193(class83_0.class84_0, class83_0.int_5);
                    class83_0.int_7 += num4;
                }
                smethod_27(class83_0.class85_0, class83_0.int_6, class83_0.int_7);
                num -= class83_0.int_6;
                class83_0.int_4 = 7;
            }
            return true;
        }

        /* private scope */internal static void smethod_26(ServerControll serverControll_0, Entity entity_0)
        {
            if ((!ServerControll.string_93.Contains("inf") && !ServerControll.string_93.Equals("dm")) && !ServerControll.string_93.Equals("oic"))
            {
                string field = entity_0.GetField<string>("sessionteam");
                if (field == "spectator")
                {
                    smethod_73(serverControll_0, entity_0, "^1You can not change teams as a spectator");
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
                        smethod_73(serverControll_0, entity_0, "^1You can not change teams if you are the last survivor of it");
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
                smethod_73(serverControll_0, entity_0, "^1You can not change team in this mode");
            }
        }

        /* private scope */internal static void smethod_27(Class82.Class85 class85_0, int int_0, int int_1)
        {
            class85_0.int_1 += int_0;
            if (class85_0.int_1 > 0x8000)
            {
                throw new InvalidOperationException();
            }
            int num = (class85_0.int_0 - int_1) & 0x7fff;
            int num2 = 0x8000 - int_0;
            if ((num > num2) || (class85_0.int_0 >= num2))
            {
                smethod_184(class85_0, num, int_0, int_1);
            }
            else if (int_0 > int_1)
            {
                while (int_0-- > 0)
                {
                    class85_0.byte_0[class85_0.int_0++] = class85_0.byte_0[num++];
                }
            }
            else
            {
                Array.Copy(class85_0.byte_0, num, class85_0.byte_0, class85_0.int_0, int_0);
                class85_0.int_0 += int_0;
            }
        }

        /* private scope */internal static void smethod_28(ServerControll serverControll_0)
        {
            if (ServerControll.list_0.Count == 0)
            {
                ServerControll.list_0.Clear();
                ServerControll.list_0.Add(0x1ac5564);
                ServerControll.list_0.Add(0x1ac8e08);
                ServerControll.list_0.Add(0x1acc6ac);
                ServerControll.list_0.Add(0x1acff50);
                ServerControll.list_0.Add(0x1ad37f4);
                ServerControll.list_0.Add(0x1ad7098);
                ServerControll.list_0.Add(0x1ada93c);
                ServerControll.list_0.Add(0x1ade1e0);
                ServerControll.list_0.Add(0x1ae1a84);
                ServerControll.list_0.Add(0x1ae5328);
                ServerControll.list_0.Add(0x1ae8bcc);
                ServerControll.list_0.Add(0x1aec470);
                ServerControll.list_0.Add(0x1aefd14);
                ServerControll.list_0.Add(0x1af35b8);
                ServerControll.list_0.Add(0x1af6e5c);
                ServerControll.list_0.Add(0x1afa700);
                ServerControll.list_0.Add(0x1afdfa4);
                ServerControll.list_0.Add(0x1b01848);
            }
        }

        /* private scope */internal static void smethod_29(ServerControll serverControll_0)
        {
            string[] strArray = ServerControll.string_43.Split(new char[] { '\\' });
            string str = "";
            int length = strArray.Length;
            length = --length;
            for (int i = 0; i < length; i++)
            {
                str = str + '\\' + strArray[i];
            }
            int num3 = str.Length - 1;
            ServerControll.string_44 = str.Substring(1, num3);
        }

        /* private scope */internal static void smethod_3(ServerControll serverControll_0, Entity entity_0)
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
            elem5.SetText("^7In Chat: ^1!password");
            elem5.Archived = true;
            elem5.HideWhenInMenu = false;
            elem5.Alpha = 1f;
            elem5.Sort = 1;
            entity_0.SetField("PassText2", new Parameter(elem5));
        }

        /* private scope */internal static string[] smethod_30(string[] string_0, ServerControll serverControll_0)
        {
            string str = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            int num = 90;
            int index = 0;
            while (index < string_0.Length)
            {
                str = str + ServerControll.char_1 + string_0[index];
                if (str.Length > num)
                {
                    break;
                }
                index++;
            }
            if (str != "")
            {
                str = str.TrimStart(new char[] { ServerControll.char_1 });
                index++;
            }
            int num3 = index;
            while (num3 < string_0.Length)
            {
                str2 = str2 + ServerControll.char_1 + string_0[num3];
                if (str2.Length > num)
                {
                    break;
                }
                num3++;
            }
            if (str2 != "")
            {
                str2 = str2.TrimStart(new char[] { ServerControll.char_1 });
                num3++;
            }
            int num4 = num3;
            while (num4 < string_0.Length)
            {
                str3 = str3 + ServerControll.char_1 + string_0[num4];
                if (str3.Length > num)
                {
                    break;
                }
                num4++;
            }
            if (str3 != "")
            {
                str3 = str3.TrimStart(new char[] { ServerControll.char_1 });
                num4++;
            }
            while (num4 < string_0.Length)
            {
                str4 = str4 + ServerControll.char_1 + string_0[num4];
                if (str4.Length > num)
                {
                    break;
                }
                num4++;
            }
            if (str4 != "")
            {
                str4 = str4.TrimStart(new char[] { ServerControll.char_1 });
            }
            return string.Concat(new object[] { str, ServerControll.char_5, str2, ServerControll.char_5, str3, ServerControll.char_5, str4 }).TrimEnd(new char[] { ServerControll.char_5 }).Split(new char[] { ServerControll.char_5 });
        }

        /* private scope */internal static void smethod_31(Entity entity_0, ServerControll serverControll_0, int int_0)
        {
            HudElem[] elemArray = serverControll_0.MenuList[entity_0.Call<int>("getEntityNumber", new Parameter[0])];
            for (int i = 0; i < elemArray.Length; i++)
            {
                if (i == int_0)
                {
                    elemArray[i].SetField("color", new Vector3(1f, 0f, 0f));
                }
                else
                {
                    elemArray[i].SetField("color", new Vector3(1f, 1f, 1f));
                }
            }
        }

        /* private scope */internal static void smethod_32(ServerControll serverControll_0)
        {
            try
            {
                if (ServerControll.bool_21)
                {
                    if (System.IO.File.Exists(ServerControll.string_85 + ServerControll.string_51))
                    {
                        ServerControll.list_1.AddRange(System.IO.File.ReadAllLines(ServerControll.string_85 + ServerControll.string_51));
                    }
                    else
                    {
                        System.IO.File.CreateText(ServerControll.string_85 + ServerControll.string_51);
                    }
                }
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("LoadBadwords", exception, "---");
            }
        }

        /* private scope */internal static void smethod_33(ServerControll serverControll_0, Entity entity_0)
        {
            try
            {
                smethod_203(0, serverControll_0, entity_0);
                smethod_182(0, entity_0, serverControll_0);
                if (!ServerControll.bool_41 || ((serverControll_0.getPlayerPsw(entity_0) == 1) && (serverControll_0.getPlayerPswOk(entity_0) == 1)))
                {
                    for (int i = 1; i < ServerControll.DBPlayerlvl.Count; i++)
                    {
                        string[] strArray = ServerControll.DBPlayerlvl[i].Split(new char[] { ServerControll.char_1 });
                        for (int j = 0; j < strArray.Length; j++)
                        {
                            if (strArray[j].StartsWith(serverControll_0.getPlayerCODE(entity_0)))
                            {
                                smethod_203(i, serverControll_0, entity_0);
                                if ((ServerControll.string_3 == null) || (ServerControll.string_3 == "null"))
                                {
                                    smethod_182(1, entity_0, serverControll_0);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("AutoLoginAdmin", exception, "---");
            }
        }

        /* private scope */internal static void smethod_34(ServerControll serverControll_0, string string_0, Entity entity_0, Entity entity_1)
        {
            Action function = null;
            ServerControll.Class53 class2 = new ServerControll.Class53 {
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
                if (smethod_139() == 0)
                {
                    serverControll_0.Call("magicbullet", new Parameter[] { "ac130_105mm_mp", new Vector3(class2.entity_0.Origin.X + smethod_110(), class2.entity_0.Origin.Y + smethod_110(), class2.entity_0.Origin.Z + smethod_110()), class2.entity_0.Origin, entity_0 });
                }
                else if (smethod_139() == 1)
                {
                    serverControll_0.Call("magicbullet", new Parameter[] { "ac130_105mm_mp", new Vector3(class2.entity_0.Origin.X - smethod_110(), class2.entity_0.Origin.Y - smethod_110(), class2.entity_0.Origin.Z + smethod_110()), class2.entity_0.Origin, entity_0 });
                }
                else if (smethod_139() == 2)
                {
                    serverControll_0.Call("magicbullet", new Parameter[] { "ac130_105mm_mp", new Vector3(class2.entity_0.Origin.X - smethod_110(), class2.entity_0.Origin.Y + smethod_110(), class2.entity_0.Origin.Z + smethod_110()), class2.entity_0.Origin, entity_0 });
                }
                else if (smethod_139() == 3)
                {
                    serverControll_0.Call("magicbullet", new Parameter[] { "ac130_105mm_mp", new Vector3(class2.entity_0.Origin.X + smethod_110(), class2.entity_0.Origin.Y - smethod_110(), class2.entity_0.Origin.Z + smethod_110()), class2.entity_0.Origin, entity_0 });
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
                    if (string_0 != "xm25")
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

        /* private scope */internal static bool smethod_35(char char_0)
        {
           return (char_0 >= '\x007f');
        }

        /* private scope */internal static void smethod_36(Entity entity_0, ServerControll serverControll_0, string string_0)
        {
            using (StreamWriter writer = new StreamWriter(ServerControll.string_85 + serverControll_0.FileUser, true))
            {
                string str = ServerControll.GetMd5Hash(serverControll_0.md5Hash, string_0) + "," + serverControll_0.getPlayerName(entity_0) + "," + serverControll_0.getPlayerID(entity_0) + "," + serverControll_0.getPlayerGuid(entity_0) + "," + serverControll_0.getPlayerXuid(entity_0);
                writer.WriteLine(str);
                writer.Close();
                smethod_173(1, serverControll_0, entity_0);
                smethod_42(1, serverControll_0, entity_0);
                smethod_136(entity_0, serverControll_0);
                smethod_73(serverControll_0, entity_0, "^5Successfully registered username, password: ^1" + string_0);
            }
        }

        /* private scope */internal static void smethod_37(Class81 class81_0)
        {
            class81_0.type_0.GetMethod("Clear").Invoke(class81_0.object_0, new object[0]);
        }

        /* private scope */
        internal static string[] smethod_38(ServerControll serverControll_0, Entity entity_0)
        {
            string[] result = null;
            if (File.Exists(ServerControll.string_84 + ServerControll.string_53))
            {
                string[] array = File.ReadAllLines(ServerControll.string_84 + ServerControll.string_53);
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].StartsWith(serverControll_0.getPlayerGuid(entity_0)))
                    {
                        if (array[i].Split(new char[]
				{
					ServerControll.char_5
				}).Length < 7)
                        {
                            string[] array2;
                            string[] expr_7F = array2 = array;
                            IntPtr intPtr;
                            int expr_83 = (int)(intPtr = (IntPtr)i);
                            object obj = array2[(int)intPtr];
                            expr_7F[expr_83] = string.Concat(new object[]
					{
						obj,
						ServerControll.char_5,
						"0",
						ServerControll.char_5,
						"0"
					});
                        }
                        result = array[i].Split(new char[]
				{
					ServerControll.char_5
				});
                        break;
                    }
                }
            }
            return result;
        }


        /* private scope */internal static void smethod_39(string string_0, string string_1, ServerControll serverControll_0, Entity entity_0)
        {
            if ((string_0 == "all") || (string_0 == null))
            {
                string_0 = "default";
            }
            if (System.IO.File.Exists(@"admin\\" + string_0 + ".dspl"))
            {
                serverControll_0.method_0("all");
                smethod_6(serverControll_0, "sv_maprotation " + string_0, 0);
                if (string_1 != null)
                {
                    using (StreamWriter writer = new StreamWriter(ServerControll.string_88 + "nextmodmap", true))
                    {
                        writer.WriteLine(string_1);
                        writer.Close();
                    }
                }
                smethod_6(serverControll_0, "map_rotate", 0x7d0);
            }
            else
            {
                smethod_158(serverControll_0, entity_0, "^5" + entity_0.Name + " ^7Mode ^1" + string_0.ToUpper() + "^7 not found!");
            }
        }

        /* private scope */internal static void smethod_4(ServerControll serverControll_0, Entity entity_0)
        {
            ServerControll.Class64 class2 = new ServerControll.Class64 {
                entity_0 = entity_0
            };
            class2.entity_0.SetField("VarPause", 1);
            class2.entity_0.AfterDelay(0x1388, new Action<Entity>(class2.method_0));
        }

        /* private scope */internal static void smethod_40(ServerControll serverControll_0, Entity entity_0)
        {
            if (ServerControll.bool_11)
            {
                if (ServerControll.func_2 == null)
                {
                    ServerControll.func_2 = new Func<Entity, bool>(ServerControll.smethod_8);
                }
                entity_0.OnInterval(0x1388, ServerControll.func_2);
            }
        }

        /* private scope */internal static void smethod_41(Entity entity_0, ServerControll serverControll_0, int int_0)
        {
            HudElem[] elemArray = serverControll_0.SubMenuList[entity_0.Call<int>("getEntityNumber", new Parameter[0])];
            for (int i = 0; i < elemArray.Length; i++)
            {
                if (i == int_0)
                {
                    elemArray[i].SetField("color", new Vector3(1f, 0f, 0f));
                }
                else
                {
                    elemArray[i].SetField("color", new Vector3(1f, 1f, 1f));
                }
            }
        }

        /* private scope */internal static void smethod_42(int int_0, ServerControll serverControll_0, Entity entity_0)
        {
            entity_0.SetField("useroriginok", int_0);
        }

        /* private scope */internal static int smethod_43(ServerControll serverControll_0)
        {
           return (serverControll_0.Call<int>("gettime", new Parameter[0]) - serverControll_0.Call<int>("getstarttime", new Parameter[0]));
        }

        /* private scope */internal static void smethod_44(Entity entity_0, ServerControll serverControll_0)
        {
            Action function = null;
            ServerControll.Class47 class2 = new ServerControll.Class47 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                if (!System.IO.File.Exists(ServerControll.string_84 + ServerControll.string_48))
                {
                    System.IO.File.CreateText(ServerControll.string_84 + ServerControll.string_48);
                }
                if (function == null)
                {
                    function = new Action(class2.method_0);
                }
                serverControll_0.AfterDelay(200, function);
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("ShowRules", exception, "---");
            }
        }

        /* private scope */internal static void smethod_45(Entity entity_0, ServerControll serverControll_0)
        {
            ServerControll.Class26 class2 = new ServerControll.Class26 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                if (System.IO.File.Exists(ServerControll.string_88 + ServerControll.string_57))
                {
                    ServerControll.Class27 class3 = new ServerControll.Class27 {
                        class26_0 = class2,
                        string_0 = System.IO.File.ReadAllLines(ServerControll.string_88 + ServerControll.string_57),
                        int_0 = 0
                    };
                    smethod_73(serverControll_0, class2.entity_0, "^7List[^1" + class3.string_0.Length + "^7] Player Last Exit:");
                    serverControll_0.OnInterval(0x3e8, new Func<bool>(class3.method_0));
                }
                else
                {
                    smethod_73(serverControll_0, class2.entity_0, "^1No Player Found");
                }
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("ListExit", exception, "---");
            }
        }

        /* private scope */internal static void smethod_46(Entity entity_0, ServerControll serverControll_0)
        {
            ServerControll.Class58 class2 = new ServerControll.Class58 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                if (System.IO.File.Exists(ServerControll.string_85 + ServerControll.string_64))
                {
                    ServerControll.Class59 class3 = new ServerControll.Class59 {
                        class58_0 = class2,
                        string_0 = System.IO.File.ReadAllLines(ServerControll.string_85 + ServerControll.string_64),
                        int_0 = 0
                    };
                    smethod_73(serverControll_0, class2.entity_0, "^7List[^1" + class3.string_0.Length + "^7] Player Hack:");
                    serverControll_0.OnInterval(0x514, new Func<bool>(class3.method_0));
                }
                else
                {
                    smethod_73(serverControll_0, class2.entity_0, "^1No Player Found");
                }
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("ListHack", exception, "---");
            }
        }

        /* private scope */internal static bool smethod_47(Class82.Class84 class84_0)
        {
           return (class84_0.int_0 == class84_0.int_1);
        }

        /* private scope */internal static int smethod_48(Class82.Class85 class85_0)
        {
           return (0x8000 - class85_0.int_1);
        }
        /* private scope */internal static void smethod_49(string string_0, ServerControll serverControll_0, Entity entity_0)
        {
            string str = string.Concat(new object[] { "LogCommand_", DateTime.Now.Day, ".", DateTime.Now.Month, ".", DateTime.Now.Year, ".txt" });
            using (StreamWriter writer = new StreamWriter(ServerControll.string_87 + str, true))
            {
                string str2 = string.Concat(new object[] { "(", ServerControll.string_92, ":", ServerControll.string_93, ":", ServerControll.string_100, ") ", DateTime.Now.Hour, ":", DateTime.Now.Minute, ":", DateTime.Now.Second, " ", serverControll_0.getPlayerName(entity_0), ": ", string_0 });
                writer.WriteLine(str2);
                writer.Close();
            }
        }

        /* private scope */internal static void smethod_5(ServerControll serverControll_0)
        {
            ServerControll.JumpHeight = ServerControll.int_5;
            ServerControll.Speed = ServerControll.int_6;
            ServerControll.Gravity = ServerControll.int_7;
        }

        /* private scope */internal static void smethod_50(string string_0, Entity entity_0, Entity entity_1, ServerControll serverControll_0)
        {
            Utilities.RawSayTo(entity_1, "^7[^1" + serverControll_0.getPlayerName(entity_0) + "^7][^5PM^7]: " + string_0);
        }

        /* private scope */internal static void smethod_51(ServerControll serverControll_0)
        {
            try
            {
                IniParser parser = new IniParser(ServerControll.string_84 + ServerControll.string_50);
                ServerControll.bool_15 = parser.GetBoolSetting(ServerControll.bool_15, "WELCOME_MESSAGES", "WelcomeMessages");
                ServerControll.string_24 = parser.GetStringSetting(ServerControll.string_24, "WELCOME_MESSAGES", "WelcomeMessageslvl00");
                ServerControll.string_25 = parser.GetStringSetting(ServerControll.string_25, "WELCOME_MESSAGES", "WelcomeMessageslvl01");
                ServerControll.string_26 = parser.GetStringSetting(ServerControll.string_26, "WELCOME_MESSAGES", "WelcomeMessageslvl02");
                ServerControll.string_27 = parser.GetStringSetting(ServerControll.string_27, "WELCOME_MESSAGES", "WelcomeMessageslvl03");
                ServerControll.string_28 = parser.GetStringSetting(ServerControll.string_28, "WELCOME_MESSAGES", "WelcomeMessageslvl04");
                ServerControll.string_29 = parser.GetStringSetting(ServerControll.string_29, "WELCOME_MESSAGES", "WelcomeMessageslvl05");
                ServerControll.string_30 = parser.GetStringSetting(ServerControll.string_30, "WELCOME_MESSAGES", "WelcomeMessageslvl06");
                ServerControll.string_31 = parser.GetStringSetting(ServerControll.string_31, "WELCOME_MESSAGES", "WelcomeMessageslvl07");
                ServerControll.string_32 = parser.GetStringSetting(ServerControll.string_32, "WELCOME_MESSAGES", "WelcomeMessageslvl08");
                ServerControll.string_33 = parser.GetStringSetting(ServerControll.string_33, "WELCOME_MESSAGES", "WelcomeMessageslvl09");
                ServerControll.bool_14 = parser.GetBoolSetting(ServerControll.bool_15, "DEAD_MESSAGES", "DeadMessages");
                ServerControll.string_34 = parser.GetStringSetting(ServerControll.string_34, "DEAD_MESSAGES", "DeadFallingMessages");
                ServerControll.string_35 = parser.GetStringSetting(ServerControll.string_35, "DEAD_MESSAGES", "DeadMeleeMessages");
                ServerControll.string_36 = parser.GetStringSetting(ServerControll.string_36, "DEAD_MESSAGES", "DeadHeadShotMessages");
                ServerControll.string_37 = parser.GetStringSetting(ServerControll.string_37, "DEAD_MESSAGES", "DeadExplosiveMessages");
                ServerControll.string_39 = parser.GetStringSetting(ServerControll.string_39, "DEAD_MESSAGES", "DeadMoabMessages");
                ServerControll.string_40 = parser.GetStringSetting(ServerControll.string_40, "DEAD_MESSAGES", "DeadFailMoabMessages");
                ServerControll.string_21 = parser.GetStringSetting(ServerControll.string_21, "PENALTIES", "KickMessages");
                ServerControll.string_22 = parser.GetStringSetting(ServerControll.string_22, "PENALTIES", "BanMessages");
                ServerControll.string_23 = parser.GetStringSetting(ServerControll.string_23, "PENALTIES", "TeampbanMessages");
                ServerControll.string_41 = parser.GetStringSetting(ServerControll.string_41, "PENALTIES", "BlackListNickMessages");
                ServerControll.string_42 = parser.GetStringSetting(ServerControll.string_42, "PENALTIES", "BlackListTagMessages");
                ServerControll.bool_37 = parser.GetBoolSetting(ServerControll.bool_37, "AFK_MESSAGES", "ControllAFK");
                ServerControll.string_38 = parser.GetStringSetting(ServerControll.string_38, "AFK_MESSAGES", "AfkMessages");
                parser.SaveSettings();
                ServerControll.list_12.Add(ServerControll.string_24);
                ServerControll.list_12.Add(ServerControll.string_25);
                ServerControll.list_12.Add(ServerControll.string_26);
                ServerControll.list_12.Add(ServerControll.string_27);
                ServerControll.list_12.Add(ServerControll.string_28);
                ServerControll.list_12.Add(ServerControll.string_29);
                ServerControll.list_12.Add(ServerControll.string_30);
                ServerControll.list_12.Add(ServerControll.string_31);
                ServerControll.list_12.Add(ServerControll.string_32);
                ServerControll.list_12.Add(ServerControll.string_33);
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("LoadMessages", exception, "---");
            }
        }

        /* private scope */internal static void smethod_52(ServerControll serverControll_0, Entity entity_0)
        {
            if (((((entity_0.GetField<string>("sessionteam") == "axis") && (serverControll_0.getPlayerAccess(entity_0) != 1)) && (serverControll_0.Call<int>("getteamplayersalive", new Parameter[] { "allies" }) > 0)) && (smethod_95(serverControll_0) > 0x2710)) && (serverControll_0.getPlayerTmpINF(entity_0) != "null"))
            {
                DateTime time = DateTime.Parse(serverControll_0.getPlayerTmpINF(entity_0));
                double num = 3.0;
                TimeSpan span = (TimeSpan) (DateTime.Now - time);
                if (span.TotalMinutes < num)
                {
                    serverControll_0.method_23(null, entity_0, ServerControll.int_30, "^7Tempban for RageQuit Infect for " + ServerControll.int_30 + "min");
                    smethod_64(serverControll_0, string.Concat(new object[] { serverControll_0.getPlayerName(entity_0), " ^7- Tempban for RageQuit Infect for ", ServerControll.int_30, "min" }));
                }
            }
        }

        /* private scope */internal static void smethod_53(ServerControll serverControll_0, Entity entity_0)
        {
            ServerControll.Class66 class2 = new ServerControll.Class66 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0,
                int_0 = ServerControll.DBNomeGruppi.Count - 1
            };
            class2.entity_0.OnInterval(0x3e8, new Func<Entity, bool>(class2.method_0));
        }

        /* private scope */internal static void smethod_54(ServerControll serverControll_0)
        {
            IniParser parser;
            if (ServerControll.bool_30)
            {
                ServerControll.bool_30 = false;
                parser = new IniParser(ServerControll.string_84 + ServerControll.string_47);
                parser.AddSetting("GENERAL_SETTING", "1Shot_1Kill", "false");
                parser.SaveSettings();
                smethod_64(serverControll_0, "^11Shot 1Kill Disabled");
            }
            else
            {
                ServerControll.bool_30 = true;
                parser = new IniParser(ServerControll.string_84 + ServerControll.string_47);
                parser.AddSetting("GENERAL_SETTING", "1Shot_1Kill", "true");
                parser.SaveSettings();
                smethod_64(serverControll_0, "^51Shot 1Kill Enabled");
            }
        }

        /* private scope */internal static void smethod_55(ServerControll serverControll_0, string string_0)
        {
            ServerControll.Class33 class2 = new ServerControll.Class33 {
                hudElem_0 = HudElem.CreateServerFontString("default", 1.2f)
            };
            class2.hudElem_0.SetPoint("LEFT", "LEFT", 2, ServerControll.int_21);
            class2.hudElem_0.Foreground = true;
            class2.hudElem_0.HideWhenInMenu = false;
            class2.hudElem_0.Alpha = 1f;
            class2.hudElem_0.SetText("^7[^1Notice^7] " + string_0);
            class2.hudElem_0.Call("setpulsefx", new Parameter[] { 100, 0x1f40, 0x3e8 });
            serverControll_0.AfterDelay(0x2710, new Action(class2.method_0));
            if (ServerControll.int_21 >= 60)
            {
                ServerControll.int_21 = 0;
            }
            else
            {
                ServerControll.int_21 += 12;
            }
        }

        /* private scope */internal static void smethod_56(Entity entity_0, string string_0, ServerControll serverControll_0)
        {
            entity_0.SetField("tmpinfect", string_0);
        }

        /* private scope */internal static bool smethod_57(Class82.Class83 class83_0)
        {
            int num3;
            switch (class83_0.int_4)
            {
                case 2:
                    if (!class83_0.bool_0)
                    {
                        int num = smethod_128(class83_0.class84_0, 3);
                        if (num < 0)
                        {
                            return false;
                        }
                        smethod_193(class83_0.class84_0, 3);
                        if ((num & 1) != 0)
                        {
                            class83_0.bool_0 = true;
                        }
                        switch ((num >> 1))
                        {
                            case 0:
                                smethod_225(class83_0.class84_0);
                                class83_0.int_4 = 3;
                                goto Label_00DA;

                            case 1:
                                class83_0.class86_0 = Class82.Class86.class86_0;
                                class83_0.class86_1 = Class82.Class86.class86_1;
                                class83_0.int_4 = 7;
                                goto Label_00DA;

                            case 2:
                                class83_0.class87_0 = new Class82.Class87();
                                class83_0.int_4 = 6;
                                goto Label_00DA;
                        }
                        break;
                    }
                    class83_0.int_4 = 12;
                    return false;

                case 3:
                    class83_0.int_8 = smethod_128(class83_0.class84_0, 0x10);
                    if (class83_0.int_8 >= 0)
                    {
                        smethod_193(class83_0.class84_0, 0x10);
                        class83_0.int_4 = 4;
                        goto Label_010B;
                    }
                    return false;

                case 4:
                    goto Label_010B;

                case 5:
                    goto Label_0133;

                case 6:
                    if (smethod_186(class83_0.class87_0, class83_0.class84_0))
                    {
                        class83_0.class86_0 = smethod_133(class83_0.class87_0);
                        class83_0.class86_1 = smethod_19(class83_0.class87_0);
                        class83_0.int_4 = 7;
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
            if (smethod_128(class83_0.class84_0, 0x10) < 0)
            {
                return false;
            }
            smethod_193(class83_0.class84_0, 0x10);
            class83_0.int_4 = 5;
        Label_0133:
            num3 = smethod_76(class83_0.class85_0, class83_0.class84_0, class83_0.int_8);
            class83_0.int_8 -= num3;
            if (class83_0.int_8 == 0)
            {
                class83_0.int_4 = 2;
                return true;
            }
            return !smethod_47(class83_0.class84_0);
        Label_01B7:
            return smethod_25(class83_0);
        }

        /* private scope */internal static void smethod_58(Entity entity_0, int int_0, ServerControll serverControll_0)
        {
            entity_0.SetField("UsrSpect", int_0);
        }

        /* private scope */
        internal static void smethod_59(ServerControll serverControll_0, Entity entity_0)
        {
            ServerControll.Class43 class2 = new ServerControll.Class43
            {
                serverControll_0 = serverControll_0,
            };
            class2.hudElem_0 = HudElem.NewHudElem();
            class2.hudElem_0 = HudElem.CreateFontString(entity_0, "hudbig", 0.4f);
            class2.hudElem_0.SetPoint("CENTER", "CENTER", 0, 220);
            class2.hudElem_0.HideWhenInMenu = true;
            entity_0.OnInterval(0x3e8, new Func<Entity, bool>(class2.method_0));
        }

        /* private scope */internal static void smethod_6(ServerControll serverControll_0, string string_0, int int_0)
        {
            if (int_0 > 0)
            {
                Thread.Sleep(int_0);
            }
            Utilities.ExecuteCommand(string_0);
        }

        /* private scope */internal static void smethod_60(ServerControll serverControll_0, Entity entity_0)
        {
            HudElem[] elemArray = serverControll_0.MenuList[entity_0.Call<int>("getEntityNumber", new Parameter[0])];
            for (int i = 0; i < elemArray.Length; i++)
            {
                elemArray[i].Call("destroy", new Parameter[0]);
            }
        }

        /* private scope */internal static void smethod_61(int int_0, Entity entity_0, Entity entity_1, string string_0, ServerControll serverControll_0)
        {
            try
            {
                if (string_0 == "add")
                {
                    if (entity_1 != null)
                    {
                        if (!(((serverControll_0.getPlayerPsw(entity_0) == 0) || (serverControll_0.getPlayerPswOk(entity_0) == 0)) ? !ServerControll.bool_41 : true))
                        {
                            smethod_73(serverControll_0, entity_1, "^1You can not give powers to a player not registered or logged!");
                            return;
                        }
                        if ((ServerControll.DBNomeGruppi[int_0] == "null") || (ServerControll.DBNomeGruppi[int_0] == ""))
                        {
                            smethod_73(serverControll_0, entity_1, "^1Admin Group is not actived!");
                            return;
                        }
                        if ((int_0 >= serverControll_0.getPlayerLevel(entity_1)) && (serverControll_0.getPlayerLevel(entity_1) < (ServerControll.DBPlayerlvl.Count - 1)))
                        {
                            smethod_73(serverControll_0, entity_1, "^1You can not assign a power greater than or equal to yours!");
                            return;
                        }
                        if (serverControll_0.getPlayerLevel(entity_0) == int_0)
                        {
                            smethod_73(serverControll_0, entity_1, "^1Player already in the group ^5" + ServerControll.DBNomeGruppi[int_0]);
                            return;
                        }
                        if (serverControll_0.getPlayerLevel(entity_0) > int_0)
                        {
                            smethod_73(serverControll_0, entity_1, "^1Player is already in a higher group, is in the group ^5" + ServerControll.DBNomeGruppi[serverControll_0.getPlayerLevel(entity_0)]);
                            return;
                        }
                    }
                    string str = ServerControll.DBPlayerlvl[int_0];
                    object obj2 = str;
                    str = string.Concat(new object[] { obj2, ServerControll.char_1, serverControll_0.getPlayerCODE(entity_0), ServerControll.char_4, serverControll_0.getPlayerName(entity_0) }).TrimStart(new char[] { ServerControll.char_1 }).TrimEnd(new char[] { ServerControll.char_1 });
                    ServerControll.DBPlayerlvl[int_0] = str;
                    smethod_64(serverControll_0, "^5" + serverControll_0.getPlayerName(entity_0) + " ^7 added to the group of ^5" + ServerControll.DBNomeGruppi[int_0]);
                    smethod_203(int_0, serverControll_0, entity_0);
                    smethod_182(1, entity_0, serverControll_0);
                }
                else if (string_0 == "del")
                {
                    for (int i = 0; i < ServerControll.DBPlayerlvl.Count; i++)
                    {
                        string[] strArray = ServerControll.DBPlayerlvl[i].Split(new char[] { ServerControll.char_1 });
                        string str2 = string.Empty;
                        for (int j = 0; j < strArray.Length; j++)
                        {
                            if (!strArray[j].StartsWith(serverControll_0.getPlayerCODE(entity_0)))
                            {
                                str2 = str2 + ServerControll.char_1 + strArray[j];
                            }
                            else
                            {
                                smethod_203(0, serverControll_0, entity_0);
                                smethod_182(0, entity_0, serverControll_0);
                                smethod_64(serverControll_0, "^1" + serverControll_0.getPlayerName(entity_0) + " ^7 deleted from the group of ^1" + ServerControll.DBNomeGruppi[i]);
                            }
                        }
                        str2 = str2.TrimStart(new char[] { ServerControll.char_1 });
                        ServerControll.DBPlayerlvl[i] = str2;
                    }
                }
                IniParser parser = new IniParser(ServerControll.string_84 + ServerControll.string_46);
                parser.AddSetting("HeadShip", "Playerlvl09", ServerControll.DBPlayerlvl[9]);
                parser.AddSetting("HeadShip", "Playerlvl08", ServerControll.DBPlayerlvl[8]);
                parser.AddSetting("HeadShip", "Playerlvl07", ServerControll.DBPlayerlvl[7]);
                parser.AddSetting("HeadShip", "Playerlvl06", ServerControll.DBPlayerlvl[6]);
                parser.AddSetting("HeadShip", "Playerlvl05", ServerControll.DBPlayerlvl[5]);
                parser.AddSetting("HeadShip", "Playerlvl04", ServerControll.DBPlayerlvl[4]);
                parser.AddSetting("HeadShip", "Playerlvl03", ServerControll.DBPlayerlvl[3]);
                parser.AddSetting("HeadShip", "Playerlvl02", ServerControll.DBPlayerlvl[2]);
                parser.AddSetting("HeadShip", "Playerlvl01", ServerControll.DBPlayerlvl[1]);
                parser.SaveSettings();
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("PowerPlayer", exception, string_0);
            }
        }

        /* private scope */
        internal static string SocketSendReceive(string server, int port, string Request, int Timeout)
        {
            string request = "GET " + Request + " HTTP/1.1\r\nHost: " + server + "\r\nConnection: Close\r\n\r\n";
            byte[] bytesSent = Encoding.ASCII.GetBytes(request);
            byte[] bytesReceived = new byte[256];
            Socket socket = ConnectSocket(port, server);
            if (socket == null)
            {
                return "Connection failed";
            }
            socket.ReceiveTimeout = Timeout;
            socket.Send(bytesSent, bytesSent.Length, SocketFlags.None);
            int count = 0;
            string str2 = "";
            do
            {
                count = socket.Receive(bytesReceived, bytesReceived.Length, SocketFlags.None);
                str2 = str2 + Encoding.ASCII.GetString(bytesReceived, 0, count);
            }
            while (count > 0);
            return str2;
        }

        private static Socket ConnectSocket(int port, string server)
        {
            foreach (IPAddress address in Dns.GetHostEntry(server).AddressList)
            {
                IPEndPoint remoteEP = new IPEndPoint(address, port);
                if (remoteEP.AddressFamily.ToString() == "InterNetwork")
                {
                    Socket socket2 = new Socket(remoteEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    socket2.Connect(remoteEP);
                    if (socket2.Connected)
                    {
                        return socket2;
                    }
                }
            }
            return null;
        }

        /* private scope */internal static void smethod_63(Entity entity_0, ServerControll serverControll_0)
        {
            ServerControll.Class23 class3 = new ServerControll.Class23 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                ServerControll.Class24 class2 = new ServerControll.Class24 {
                    class23_0 = class3
                };
                smethod_73(serverControll_0, class3.entity_0, "^7All Player[^1" + ServerControll.list_2.Count + "^7] List in Game:");
                class2.int_0 = 0;
                class2.entity_0 = ServerControll.list_2.ToArray();
                serverControll_0.OnInterval(0x3e8, new Func<bool>(class2.method_0));
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("ListAllPlayer", exception, "---");
            }
        }

        /* private scope */internal static void smethod_64(ServerControll serverControll_0, string string_0)
        {
            Utilities.RawSayAll(ServerControll.string_4 + "^7: " + string_0);
        }

        /* private scope */internal static Version smethod_65()
        {
           return Assembly.GetCallingAssembly().GetName().Version;
        }
        /* private scope */internal static void smethod_66(ServerControll serverControll_0)
        {
            if (System.IO.File.Exists(ServerControll.string_85 + ServerControll.string_54))
            {
                string[] strArray = System.IO.File.ReadAllLines(ServerControll.string_85 + ServerControll.string_54);
                System.IO.File.Delete(ServerControll.string_85 + ServerControll.string_54);
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray3 = strArray[i].Split(new char[] { ServerControll.char_1 })[0].Split(new char[] { ServerControll.char_2 });
                    DateTime time = DateTime.Parse(strArray3[0]);
                    TimeSpan span = (TimeSpan) (DateTime.Now - time);
                    bool flag = true;
                    if (span.TotalMinutes > double.Parse(strArray3[1]))
                    {
                        flag = false;
                    }
                    if (flag)
                    {
                        using (StreamWriter writer = new StreamWriter(ServerControll.string_85 + ServerControll.string_54, true))
                        {
                            writer.WriteLine(strArray[i]);
                            writer.Close();
                        }
                    }
                }
            }
        }

        /* private scope */internal static void smethod_67(ServerControll serverControll_0)
        {
            try
            {
                IniParser parser = new IniParser(ServerControll.string_84 + ServerControll.string_46);
                ServerControll.StrPlayerlvl09 = parser.GetStringSetting(ServerControll.StrPlayerlvl09, "HeadShip", "Playerlvl09");
                ServerControll.StrPlayerlvl08 = parser.GetStringSetting(ServerControll.StrPlayerlvl08, "HeadShip", "Playerlvl08");
                ServerControll.StrPlayerlvl07 = parser.GetStringSetting(ServerControll.StrPlayerlvl07, "HeadShip", "Playerlvl07");
                ServerControll.StrPlayerlvl06 = parser.GetStringSetting(ServerControll.StrPlayerlvl06, "HeadShip", "Playerlvl06");
                ServerControll.StrPlayerlvl05 = parser.GetStringSetting(ServerControll.StrPlayerlvl05, "HeadShip", "Playerlvl05");
                ServerControll.StrPlayerlvl04 = parser.GetStringSetting(ServerControll.StrPlayerlvl04, "HeadShip", "Playerlvl04");
                ServerControll.StrPlayerlvl03 = parser.GetStringSetting(ServerControll.StrPlayerlvl03, "HeadShip", "Playerlvl03");
                ServerControll.StrPlayerlvl02 = parser.GetStringSetting(ServerControll.StrPlayerlvl02, "HeadShip", "Playerlvl02");
                ServerControll.StrPlayerlvl01 = parser.GetStringSetting(ServerControll.StrPlayerlvl01, "HeadShip", "Playerlvl01");
                parser.AddSetting("HeadShip", "Playerlvl00", "Group players normal, can not be modified");
                ServerControll.StrComandilvl09 = parser.GetStringSetting(ServerControll.xStrComandilvl09, "Function", "Commandlvl09");
                ServerControll.StrComandilvl08 = parser.GetStringSetting(ServerControll.xStrComandilvl08, "Function", "Commandlvl08");
                ServerControll.StrComandilvl07 = parser.GetStringSetting(ServerControll.xStrComandilvl07, "Function", "Commandlvl07");
                ServerControll.StrComandilvl06 = parser.GetStringSetting(ServerControll.xStrComandilvl06, "Function", "Commandlvl06");
                ServerControll.StrComandilvl05 = parser.GetStringSetting(ServerControll.xStrComandilvl05, "Function", "Commandlvl05");
                ServerControll.StrComandilvl04 = parser.GetStringSetting(ServerControll.xStrComandilvl04, "Function", "Commandlvl04");
                ServerControll.StrComandilvl03 = parser.GetStringSetting(ServerControll.xStrComandilvl03, "Function", "Commandlvl03");
                ServerControll.StrComandilvl02 = parser.GetStringSetting(ServerControll.xStrComandilvl02, "Function", "Commandlvl02");
                ServerControll.StrComandilvl01 = parser.GetStringSetting(ServerControll.xStrComandilvl01, "Function", "Commandlvl01");
                ServerControll.StrComandilvl00 = parser.GetStringSetting(ServerControll.xStrComandilvl00, "Function", "Commandlvl00");
                ServerControll.NomeGruppo09 = parser.GetStringSetting(ServerControll.NomeGruppo09, "Names_Groups_Player", "NameGroup09");
                ServerControll.NomeGruppo08 = parser.GetStringSetting(ServerControll.NomeGruppo08, "Names_Groups_Player", "NameGroup08");
                ServerControll.NomeGruppo07 = parser.GetStringSetting(ServerControll.NomeGruppo07, "Names_Groups_Player", "NameGroup07");
                ServerControll.NomeGruppo06 = parser.GetStringSetting(ServerControll.NomeGruppo06, "Names_Groups_Player", "NameGroup06");
                ServerControll.NomeGruppo05 = parser.GetStringSetting(ServerControll.NomeGruppo05, "Names_Groups_Player", "NameGroup05");
                ServerControll.NomeGruppo04 = parser.GetStringSetting(ServerControll.NomeGruppo04, "Names_Groups_Player", "NameGroup04");
                ServerControll.NomeGruppo03 = parser.GetStringSetting(ServerControll.NomeGruppo03, "Names_Groups_Player", "NameGroup03");
                ServerControll.NomeGruppo02 = parser.GetStringSetting(ServerControll.NomeGruppo02, "Names_Groups_Player", "NameGroup02");
                ServerControll.NomeGruppo01 = parser.GetStringSetting(ServerControll.NomeGruppo01, "Names_Groups_Player", "NameGroup01");
                parser.AddSetting("Names_Groups_Player", "NameGroup00", "Group players normal, can not be modified");
                ServerControll.bool_6 = parser.GetBoolSetting(ServerControll.bool_6, "Color", "ColorNickAdmin");
                ServerControll.Colorlvl09 = parser.GetIntSetting(ServerControll.Colorlvl09, "Color", "Colorlvl09");
                ServerControll.Colorlvl08 = parser.GetIntSetting(ServerControll.Colorlvl08, "Color", "Colorlvl08");
                ServerControll.Colorlvl07 = parser.GetIntSetting(ServerControll.Colorlvl07, "Color", "Colorlvl07");
                ServerControll.Colorlvl06 = parser.GetIntSetting(ServerControll.Colorlvl06, "Color", "Colorlvl06");
                ServerControll.Colorlvl05 = parser.GetIntSetting(ServerControll.Colorlvl05, "Color", "Colorlvl05");
                ServerControll.Colorlvl04 = parser.GetIntSetting(ServerControll.Colorlvl04, "Color", "Colorlvl04");
                ServerControll.Colorlvl03 = parser.GetIntSetting(ServerControll.Colorlvl03, "Color", "Colorlvl03");
                ServerControll.Colorlvl02 = parser.GetIntSetting(ServerControll.Colorlvl02, "Color", "Colorlvl02");
                ServerControll.Colorlvl01 = parser.GetIntSetting(ServerControll.Colorlvl01, "Color", "Colorlvl01");
                parser.AddSetting("Color", "Colorlvl00", "Group players normal, can not be modified");
                ServerControll.Taglvl09 = parser.GetStringSetting(ServerControll.Taglvl09, "TagStaff", "Taglvl09");
                ServerControll.Taglvl08 = parser.GetStringSetting(ServerControll.Taglvl08, "TagStaff", "Taglvl08");
                ServerControll.Taglvl07 = parser.GetStringSetting(ServerControll.Taglvl07, "TagStaff", "Taglvl07");
                ServerControll.Taglvl06 = parser.GetStringSetting(ServerControll.Taglvl06, "TagStaff", "Taglvl06");
                ServerControll.Taglvl05 = parser.GetStringSetting(ServerControll.Taglvl05, "TagStaff", "Taglvl05");
                ServerControll.Taglvl04 = parser.GetStringSetting(ServerControll.Taglvl04, "TagStaff", "Taglvl04");
                ServerControll.Taglvl03 = parser.GetStringSetting(ServerControll.Taglvl03, "TagStaff", "Taglvl03");
                ServerControll.Taglvl02 = parser.GetStringSetting(ServerControll.Taglvl02, "TagStaff", "Taglvl02");
                ServerControll.Taglvl01 = parser.GetStringSetting(ServerControll.Taglvl01, "TagStaff", "Taglvl01");
                parser.AddSetting("TagStaff", "Taglvl00", "Group players normal, can not be modified");
                ServerControll.string_85 = parser.GetStringSetting(ServerControll.string_85, "FolderShare", "Folder");
                parser.SaveSettings();
                if (!Directory.Exists(ServerControll.string_85))
                {
                    Directory.CreateDirectory(ServerControll.string_85);
                }
                serverControll_0.method_31();
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("LoadAdmin", exception, "---");
            }
        }

        /* private scope */internal static int smethod_68(int int_0, int int_1, byte[] byte_0, Class82.Class85 class85_0)
        {
            int num = class85_0.int_0;
            if (int_0 > class85_0.int_1)
            {
                int_0 = class85_0.int_1;
            }
            else
            {
                num = ((class85_0.int_0 - class85_0.int_1) + int_0) & 0x7fff;
            }
            int num2 = int_0;
            int length = int_0 - num;
            if (length > 0)
            {
                Array.Copy(class85_0.byte_0, 0x8000 - length, byte_0, int_1, length);
                int_1 += length;
                int_0 = num;
            }
            Array.Copy(class85_0.byte_0, num - int_0, byte_0, int_1, int_0);
            class85_0.int_1 -= num2;
            if (class85_0.int_1 < 0)
            {
                throw new InvalidOperationException();
            }
            return num2;
        }

        /* private scope */internal static void smethod_69(Entity entity_0, ServerControll serverControll_0)
        {
            try
            {
                if (!(!ServerControll.bool_47 || serverControll_0.IsUserSession(entity_0)))
                {
                    Utilities.RawSayAll(ServerControll.string_4 + "^7: ^5" + entity_0.Name + " ^7Connecting...");
                }
            }
            catch (Exception exception)
            {
                if (!((exception.Message.Contains("dictionary.") || exception.Message.Contains("Sharing violation")) || exception.Message.Contains("correct format.")))
                {
                    ServerControll.LogErrori("InConnessione_Player", exception, "---");
                }
            }
        }

        /* private scope */internal static int smethod_7(Class82.Class85 class85_0)
        {
           return class85_0.int_1;
        }
        /* private scope */internal static void smethod_70(ServerControll serverControll_0)
        {
            if (System.IO.File.Exists(ServerControll.string_84 + ServerControll.string_68))
            {
                string str = System.IO.File.ReadAllLines(ServerControll.string_84 + ServerControll.string_68)[0];
                if (str == ServerControll.string_1)
                {
                    return;
                }
                System.IO.File.Delete(ServerControll.string_84 + ServerControll.string_68);
                smethod_175(serverControll_0);
            }
            else
            {
                smethod_175(serverControll_0);
            }
            using (StreamWriter writer = new StreamWriter(ServerControll.string_84 + ServerControll.string_68, true))
            {
                writer.WriteLine(ServerControll.string_1);
                writer.Close();
            }
        }

        /* private scope */internal static void smethod_71(Entity entity_0, ServerControll serverControll_0)
        {
            try
            {
                ServerControll.Class36 class2 = new ServerControll.Class36 {
                    serverControll_0 = serverControll_0
                };
                if ((((ServerControll.string_93 != "sd") && !ServerControll.string_93.Contains("inf")) && (ServerControll.string_100 != "hide")) && ServerControll.bool_17)
                {
                    class2.int_0 = 5;
                    entity_0.OnInterval(0x1388, new Func<Entity, bool>(class2.method_0));
                }
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("ControllCamp", exception, "---");
            }
        }

        /* private scope */internal static Socket smethod_72(int int_0, string string_0)
        {
            foreach (IPAddress address in Dns.GetHostEntry(string_0).AddressList)
            {
                IPEndPoint remoteEP = new IPEndPoint(address, int_0);
                if (remoteEP.AddressFamily.ToString() == "InterNetwork")
                {
                    Socket socket2 = new Socket(remoteEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    socket2.Connect(remoteEP);
                    if (socket2.Connected)
                    {
                        return socket2;
                    }
                }
            }
            return null;
        }

        /* private scope */internal static void smethod_73(ServerControll serverControll_0, Entity entity_0, string string_0)
        {
            Utilities.RawSayTo(entity_0, ServerControll.string_4 + "^7[^5PM^7]: " + string_0);
        }

        /* private scope */internal static void smethod_74(Entity entity_0, ServerControll serverControll_0)
        {
            try
            {
                smethod_214(entity_0, serverControll_0);
                ServerControll.list_2.Add(entity_0);
                smethod_8(serverControll_0, entity_0);
                if ((((serverControll_0.getPlayerName(entity_0).StartsWith("bot") && serverControll_0.getPlayerID(entity_0).Contains(ServerControll.string_104)) && (serverControll_0.getPlayerGuid(entity_0).Contains(ServerControll.string_104) && !ServerControll.list_5.Contains(entity_0))) && !ServerControll.string_2.StartsWith("pl")) && serverControll_0.getPlayerIP(entity_0).Equals("0.0.0.0"))
                {
                    smethod_179(entity_0, serverControll_0);
                }
                else
                {
                    serverControll_0.method_3(entity_0);
                }
            }
            catch (Exception exception)
            {
                if (!((exception.Message.Contains("dictionary.") || exception.Message.Contains("Sharing violation")) || exception.Message.Contains("correct format.")))
                {
                    ServerControll.LogErrori("Connessione_Player", exception, "---");
                }
            }
        }

        /* private scope */internal static void smethod_75(ServerControll serverControll_0, Entity entity_0, string string_0)
        {
            try
            {
                string[] strArray = string_0.ToLower().Trim().Split(new char[] { ServerControll.char_0 });
                if ((strArray[0] == "!votekick") || (strArray[0] == "!voteban"))
                {
                    Entity player = serverControll_0.method_4(entity_0, strArray[1]);
                    if (player != null)
                    {
                        if (serverControll_0.getPlayerLevel(player) < 2)
                        {
                            serverControll_0.method_32(entity_0, string_0.Replace(strArray[1], serverControll_0.getPlayerName(player)).ToLower(), player, serverControll_0.getPlayerName(player));
                        }
                        else
                        {
                            smethod_73(serverControll_0, entity_0, "^1Error - The Player is an Admin!");
                        }
                    }
                    else
                    {
                        smethod_73(serverControll_0, entity_0, "^1Player not found! Use ID");
                        smethod_180(serverControll_0, entity_0);
                    }
                }
                else if (strArray[0] == "!votemap")
                {
                    string str = serverControll_0.TrovaMappa(entity_0, strArray[1]);
                    if (str != "null")
                    {
                        serverControll_0.method_32(entity_0, strArray[0] + " " + str, null, null);
                    }
                }
                else if (strArray[0] == "!votemod")
                {
                    if (System.IO.File.Exists(@"admin\\" + strArray[1] + ".dspl"))
                    {
                        serverControll_0.method_32(entity_0, string_0.ToLower(), null, null);
                    }
                    else
                    {
                        smethod_158(serverControll_0, entity_0, "^5" + entity_0.Name + " ^7Mode ^1" + strArray[1].ToUpper() + "^7 not found!");
                    }
                }
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("GoVotazione", exception, "---");
            }
        }

        /* private scope */internal static int smethod_76(Class82.Class85 class85_0, Class82.Class84 class84_0, int int_0)
        {
            int num;
            int_0 = Math.Min(Math.Min(int_0, 0x8000 - class85_0.int_1), smethod_181(class84_0));
            int num2 = 0x8000 - class85_0.int_0;
            if (int_0 > num2)
            {
                num = smethod_166(class84_0, class85_0.byte_0, class85_0.int_0, num2);
                if (num == num2)
                {
                    num += smethod_166(class84_0, class85_0.byte_0, 0, int_0 - num2);
                }
            }
            else
            {
                num = smethod_166(class84_0, class85_0.byte_0, class85_0.int_0, int_0);
            }
            class85_0.int_0 = (class85_0.int_0 + num) & 0x7fff;
            class85_0.int_1 += num;
            return num;
        }

        /* private scope */internal static void smethod_77(Entity entity_0, ServerControll serverControll_0, Entity entity_1)
        {
            if (System.IO.File.Exists(ServerControll.string_85 + ServerControll.string_56))
            {
                string str;
                if (ServerControll.string_2.StartsWith("pl"))
                {
                    str = serverControll_0.getPlayerHWID(entity_0);
                }
                else
                {
                    str = serverControll_0.getPlayerIP(entity_0);
                }
                string[] strArray = System.IO.File.ReadAllLines(ServerControll.string_85 + ServerControll.string_56);
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (!strArray[i].StartsWith(str))
                    {
                        continue;
                    }
                    string[] strArray2 = strArray[i].Split(new char[] { ServerControll.char_1 });
                    bool flag = false;
                    for (int j = 1; j < strArray2.Length; j++)
                    {
                        if (strArray2[j] != serverControll_0.getPlayerName(entity_0))
                        {
                            goto Label_00BC;
                        }
                    }
                    goto Label_013E;
                Label_00BC:
                    flag = true;
                    string str2 = string.Empty;
                    smethod_73(serverControll_0, entity_1, "^7Player: ^1" + serverControll_0.getPlayerName(entity_0) + " ^7also known as:^5");
                    for (int k = 1; k < strArray2.Length; k++)
                    {
                        if (strArray2[k] != serverControll_0.getPlayerName(entity_0))
                        {
                            str2 = str2 + "^1" + strArray2[k] + "^5<>";
                        }
                    }
                    smethod_73(serverControll_0, entity_1, str2.Substring(0, str2.Length - 2));
                Label_013E:
                    if (!flag)
                    {
                        smethod_73(serverControll_0, entity_1, "^7Player ^1" + serverControll_0.getPlayerName(entity_0) + " ^7not use alias");
                    }
                }
            }
        }

        /* private scope */internal static void smethod_78()
        {
            ServerControll.hudElem_1.Call("destroy", new Parameter[0]);
        }

        /* private scope */internal static void smethod_79(Entity entity_0, ServerControll serverControll_0)
        {
            try
            {
                string str = string.Empty;
                smethod_28(serverControll_0);
                int num = entity_0.Call<int>("getentitynumber", new Parameter[0]);
                str = ServerControll.Mem.ReadString(ServerControll.list_0[num], 7);
                if (str != "")
                {
                    smethod_92(entity_0, serverControll_0, str.Trim());
                    for (int i = 0; i < ServerControll.string_83.Length; i++)
                    {
                        if (str.ToLower().Contains(ServerControll.string_83[i].ToLower()))
                        {
                            goto Label_0085;
                        }
                    }
                }
                return;
            Label_0085:
                serverControll_0.method_25(null, entity_0, ServerControll.string_42);
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("ControllTAG", exception, "---");
            }
        }

        /* private scope */internal static void smethod_8(ServerControll serverControll_0, Entity entity_0)
        {
            string str = string.Concat(new object[] { "Log_", DateTime.Now.Day, ".", DateTime.Now.Month, ".", DateTime.Now.Year, ".txt" });
            ServerControll.list_4.Add(entity_0);
            using (StreamWriter writer = new StreamWriter(ServerControll.string_86 + str, true))
            {
                string str2 = string.Concat(new object[] { 
                    "(", ServerControll.string_92, ":", ServerControll.string_93, ":", ServerControll.string_100, ") ", DateTime.Now.Hour, ":", DateTime.Now.Minute, ":", DateTime.Now.Second, " ", serverControll_0.getPlayerName(entity_0), ServerControll.char_1, serverControll_0.getPlayerID(entity_0),
                    ServerControll.char_1, serverControll_0.getPlayerGuid(entity_0), ServerControll.char_1, serverControll_0.getPlayerHWID(entity_0), ServerControll.char_1, serverControll_0.getPlayerXuid(entity_0), ServerControll.char_1, serverControll_0.getPlayerIP(entity_0)
                });
                writer.WriteLine(str2);
                writer.Close();
            }
        }

        /* private scope */internal static void smethod_80(ServerControll serverControll_0)
        {
            Action function = null;
            try
            {
                if (ServerControll.bool_36)
                {
                    if (function == null)
                    {
                        function = new Action(serverControll_0.method_51);
                    }
                    serverControll_0.AfterDelay(0x1388, function);
                }
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("ControllNextMaps", exception, "---");
            }
        }

        /* private scope */internal static void smethod_81(Entity entity_0, ServerControll serverControll_0)
        {
            if ((((ServerControll.string_93 != "sd") && !ServerControll.string_93.Contains("inf")) && (ServerControll.string_100 != "hide")) && ServerControll.bool_17)
            {
                entity_0.SetField("LPCamp", new Vector3(0f, 0f, 0f));
                entity_0.SetField("Camp", 0);
            }
            if (((ServerControll.string_93.Contains("inf") && (entity_0.GetField<string>("sessionteam") == "axis")) && (ServerControll.int_30 > 0)) && (serverControll_0.getPlayerTmpINF(entity_0) == "null"))
            {
                DateTime now = DateTime.Now;
                Entity entity = entity_0;
                string str = now.ToString();
                smethod_56(entity, str, serverControll_0);
            }
        }

        /* private scope */internal static void smethod_82()
        {
            ServerControll.hudElem_1.Call("destroy", new Parameter[0]);
        }

        /* private scope */internal static void smethod_83(ServerControll serverControll_0)
        {
            if (ServerControll.bool_43)
            {
                ServerControll.hudElem_4 = HudElem.CreateServerFontString("hudbig", 0.4f);
                ServerControll.hudElem_4.SetPoint("CENTER", "CENTER", 0, 0xd4);
                ServerControll.hudElem_4.HideWhenInMenu = true;
                ServerControll.hudElem_4.SetField("color", new Vector3(1f, 1f, 1f));
                ServerControll.hudElem_4.Call("settimer", new Parameter[] { (float.Parse(serverControll_0.Call<string>("getdvar", new Parameter[] { "scr_" + ServerControll.string_93 + "_timelimit" })) * 60f) - 1f });
            }
        }

        /* private scope */internal static void smethod_84(string string_0, ServerControll serverControll_0)
        {
            string_0 = smethod_219(serverControll_0, string_0);
            smethod_104(string_0, serverControll_0);
            Log.Write(InfinityScript.LogLevel.All, string_0);
        }

        /* private scope */internal static void smethod_85(Entity entity_0, ServerControll serverControll_0)
        {
            entity_0.GetField<HudElem>("PassText1").SetText(serverControll_0.messpass(entity_0));
            smethod_158(serverControll_0, entity_0, serverControll_0.messpass(entity_0));
            smethod_73(serverControll_0, entity_0, "^1Private game or training in progress, if you are not allowed go out... tnx");
        }

        /* private scope */internal static void smethod_86(Entity entity_0, ServerControll serverControll_0)
        {
            ServerControll.Class56 class2 = new ServerControll.Class56 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                if (System.IO.File.Exists(ServerControll.string_85 + ServerControll.string_55))
                {
                    ServerControll.Class57 class3 = new ServerControll.Class57 {
                        class56_0 = class2,
                        string_0 = System.IO.File.ReadAllLines(ServerControll.string_85 + ServerControll.string_55),
                        int_0 = 0
                    };
                    smethod_73(serverControll_0, class2.entity_0, "^7List[^1" + class3.string_0.Length + "^7] Player Ban:");
                    serverControll_0.OnInterval(900, new Func<bool>(class3.method_0));
                }
                else
                {
                    smethod_73(serverControll_0, class2.entity_0, "^1No Player Found");
                }
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("ListBan", exception, "---");
            }
        }

        /* private scope */internal static void smethod_87(ServerControll serverControll_0, Entity entity_0)
        {
            if (entity_0.HasField("DioInTerra"))
            {
                if (entity_0.GetField<int>("DioInTerra") == 1)
                {
                    smethod_158(serverControll_0, entity_0, "^1" + serverControll_0.getPlayerName(entity_0) + " ^7GodMode disabled!!!");
                    entity_0.SetField("DioInTerra", 0);
                }
                else if (entity_0.GetField<int>("DioInTerra") == 0)
                {
                    smethod_158(serverControll_0, entity_0, "^5" + serverControll_0.getPlayerName(entity_0) + " ^7GodMode enabled!!!");
                    entity_0.SetField("DioInTerra", 1);
                }
            }
            else
            {
                smethod_158(serverControll_0, entity_0, "^5" + serverControll_0.getPlayerName(entity_0) + " ^7GodMode enabled!!!");
                entity_0.SetField("DioInTerra", 1);
            }
        }

        /* private scope */internal static string smethod_88(ServerControll serverControll_0, string string_0)
        {
           return string_0.Replace("mp_dome", "Dome").Replace("mp_paris", "Resistance").Replace("mp_crosswalk_ss", "Intersection").Replace("mp_village", "Village").Replace("mp_bootleg", "Bootleg").Replace("mp_carbon", "Carbon").Replace("mp_interchange", "Interchange").Replace("mp_hardhat", "Hardhat").Replace("mp_exchange", "Downturn").Replace("mp_radar", "Outpost").Replace("mp_hillside_ss", "Gateway").Replace("mp_restrepo_ss", "Lookout").Replace("mp_overwatch", "Overwatch").Replace("mp_lambeth", "Fallen").Replace("mp_terminal_cls", "Terminal").Replace("mp_underground", "Underground").Replace("mp_plaza2", "Arkaden").Replace("mp_shipbreaker", "Decommision").Replace("mp_nola", "Parish").Replace("mp_roughneck", "Off Shore").Replace("mp_boardwalk", "Boardwalk").Replace("mp_italy", "Piazza").Replace("mp_moab", "Gulch").Replace("mp_cement", "Foundation").Replace("mp_morningwood", "Black Box").Replace("mp_meteora", "Sanctuary").Replace("mp_aground_ss", "Aground").Replace("mp_burn_ss", "U-Turn").Replace("mp_courtyard_ss", "Erosion").Replace("mp_park", "Liberation").Replace("mp_qadeem", "Oasis").Replace("mp_six_ss", "Vortex").Replace("mp_alpha", "Lockdown").Replace("mp_bravo", "Mission").Replace("mp_mogadishu", "Bakaara").Replace("mp_seatown", "Seatown");
        }

        /* private scope */
        internal static int smethod_89(Class82.Class84 class84_0)
        {
            return class84_0.int_2;
        }

        /* private scope */
        internal static void smethod_9(Entity entity_0, string string_0, ServerControll serverControll_0)
        {
            HudElem[] elemArray = new HudElem[serverControll_0.comandiplayer.Length + 1];
            for (int i = 0; i < serverControll_0.comandiplayer.Length; i++)
            {
                HudElem elem = HudElem.CreateFontString(entity_0, "default", 1.3f);
                elem.Alpha = 0f;
                elem.SetPoint("TopRight", "TopRight", -15, 50 + (13 * i));
                elem.Call("settext", new Parameter[] { serverControll_0.comandiplayer[i] });
                elemArray[i] = elem;
            }
            HudElem elem2 = HudElem.CreateFontString(entity_0, "default", 1.5f);
            elem2.SetPoint("TopRight", "TopRight", -15, 30);
            elem2.Call("settext", new Parameter[] { "^7Press ^1[{+actionslot 7}] ^7to go down, ^1[{+actionslot 6}] ^7to go up and ^1[{toggleprone}] ^7to select action for ^5" + string_0 });
            elem2.Alpha = 0f;
            elemArray[serverControll_0.comandiplayer.Length] = elem2;
            int key = entity_0.Call<int>("getEntityNumber", new Parameter[0]);
            if (serverControll_0.SubMenuList.ContainsKey(key))
            {
                smethod_21(key, serverControll_0);
                serverControll_0.SubMenuList[key] = elemArray;
            }
            else
            {
                serverControll_0.SubMenuList.Add(key, elemArray);
            }
        }

        /* private scope */
        internal static void smethod_90(ServerControll serverControll_0, Entity entity_0)
        {
            HudElem[] elemArray = new HudElem[ServerControll.list_3.Count + 1];
            for (int i = 0; i < ServerControll.list_3.Count; i++)
            {
                HudElem elem = HudElem.CreateFontString(entity_0, "default", 1.3f);
                elem.Alpha = 0f;
                elem.SetPoint("TopRight", "TopRight", -15, 50 + (13 * i));
                elem.Call("settext", new Parameter[] { ServerControll.list_3[i] });
                elemArray[i] = elem;
            }
            HudElem elem2 = HudElem.CreateFontString(entity_0, "default", 1.5f);
            elem2.SetPoint("TopRight", "TopRight", -15, 30);
            elem2.Call("settext", new Parameter[] { "Press^1 [{+actionslot 7}] ^7to go down,^1 [{+actionslot 6}] ^7to go up and^1 [{toggleprone}] ^7to select player (^5" + ServerControll.list_3.Count + "^7)" });
            elem2.Alpha = 0f;
            elemArray[ServerControll.list_3.Count] = elem2;
            int key = entity_0.Call<int>("getEntityNumber", new Parameter[0]);
            if (serverControll_0.MenuList.ContainsKey(key))
            {
                smethod_151(serverControll_0, key);
                serverControll_0.MenuList[key] = elemArray;
            }
            else
            {
                serverControll_0.MenuList.Add(key, elemArray);
            }
        }

        /* private scope */
        internal static void smethod_91(string string_0, ServerControll serverControll_0, Entity entity_0)
        {
            using (StreamWriter writer = new StreamWriter(ServerControll.string_84 + ServerControll.string_49, true))
            {
                writer.WriteLine(string_0);
                writer.Close();
                if (entity_0 != null)
                {
                    smethod_73(serverControll_0, entity_0, "^5New ADV added to the list!");
                }
            }
        }

        /* private scope */
        internal static void smethod_92(Entity entity_0, ServerControll serverControll_0, string string_0)
        {
            entity_0.SetField("TagPlayer", string_0);
        }

        /* private scope */
        internal static void smethod_93(ServerControll serverControll_0, Entity entity_0)
        {
            Action function = null;
            Action action2 = null;
            ServerControll.Class13 class2 = new ServerControll.Class13 {
                entity_0 = entity_0,
                serverControll_0 = serverControll_0
            };
            try
            {
                if (ServerControll.bool_8)
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
                            smethod_98(serverControll_0, class2.entity_0);
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
                        smethod_125(serverControll_0, class2.entity_0);
                    }
                }
                else if (!serverControll_0.IsUserSession(class2.entity_0))
                {
                    smethod_98(serverControll_0, class2.entity_0);
                }
            }
            catch (Exception exception)
            {
                ServerControll.LogErrori("ControlloRichPassword", exception, "---");
            }
        }

        /* private scope */
        internal static void smethod_94(Class82.Class86 class86_0, byte[] byte_0)
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
            class86_0.short_0 = new short[num4];
            int num8 = 0x200;
            for (int k = 15; k >= 10; k--)
            {
                int num10 = num3 & 0x1ff80;
                num3 -= numArray[k] << (0x10 - k);
                int num11 = num3 & 0x1ff80;
                for (int n = num11; n < num10; n += 0x80)
                {
                    class86_0.short_0[smethod_226(n)] = (short) ((-num8 << 4) | k);
                    num8 += ((int) 1) << (k - 9);
                }
            }
            for (int m = 0; m < byte_0.Length; m++)
            {
                int num14 = byte_0[m];
                if (num14 != 0)
                {
                    num3 = numArray2[num14];
                    int num15 = smethod_226(num3);
                    if (num14 <= 9)
                    {
                        do
                        {
                            class86_0.short_0[num15] = (short) ((m << 4) | num14);
                            num15 += ((int) 1) << num14;
                        }
                        while (num15 < 0x200);
                    }
                    else
                    {
                        int num16 = class86_0.short_0[num15 & 0x1ff];
                        int num17 = ((int) 1) << (num16 & 15);
                        num16 = -(num16 >> 4);
                        do
                        {
                            class86_0.short_0[num16 | (num15 >> 9)] = (short) ((m << 4) | num14);
                            num15 += ((int) 1) << num14;
                        }
                        while (num15 < num17);
                    }
                    numArray2[num14] = num3 + (((int) 1) << (0x10 - num14));
                }
            }
        }

        /* private scope */
        internal static int smethod_95(ServerControll serverControll_0)
        {
            float num = float.Parse(serverControll_0.Call<string>("getdvar", new Parameter[] { "scr_" + ServerControll.string_93 + "_timelimit" })) * 60f;
            int num2 = (int) (num * 1000f);
            int num3 = smethod_43(serverControll_0);
            return (num2 - num3);
        }

        /* private scope */
        internal static void smethod_96(string string_0, ServerControll serverControll_0, string string_1, Entity entity_0)
        {
            StreamWriter writer;
            if (string_0 == "add")
            {
                using (writer = new StreamWriter(ServerControll.string_85 + ServerControll.string_51, true))
                {
                    ServerControll.list_1.Add(string_1);
                    writer.WriteLine(string_1);
                    writer.Close();
                    if (entity_0 != null)
                    {
                        smethod_73(serverControll_0, entity_0, "^1" + string_1 + "^7 added to the BadWords list!");
                    }
                    return;
                }
            }
            if (string_0 == "del")
            {
                if (System.IO.File.Exists(ServerControll.string_85 + ServerControll.string_51))
                {
                    string[] strArray = System.IO.File.ReadAllLines(ServerControll.string_85 + ServerControll.string_51);
                    System.IO.File.Delete(ServerControll.string_85 + ServerControll.string_51);
                    bool flag = false;
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        bool flag2 = true;
                        if (strArray[i].ToLower().Contains(string_1))
                        {
                            flag2 = false;
                            flag = true;
                            ServerControll.list_1.Remove(strArray[i]);
                            smethod_73(serverControll_0, entity_0, "^7Word ^1" + strArray[i] + "^7 found and eliminated!");
                        }
                        if (flag2)
                        {
                            using (writer = new StreamWriter(ServerControll.string_85 + ServerControll.string_51, true))
                            {
                                writer.WriteLine(strArray[i]);
                                writer.Close();
                            }
                        }
                    }
                    if (!flag)
                    {
                        smethod_73(serverControll_0, entity_0, "^1No Words Found");
                    }
                }
                else
                {
                    smethod_73(serverControll_0, entity_0, "^1No Words Found");
                }
            }
        }

        /* private scope */
        internal static void smethod_97(string string_0, ServerControll serverControll_0)
        {
            string[] strArray;
            int num;
            string str;
            try
            {
                ServerControll.bool_52 = false;
                ServerControll.int_23 = 0;
                strArray = string_0.Split(new char[] { '/' });
                num = strArray.Length - 1;
                str = ServerControll.string_43 + @"\" + ServerControll.string_45 + @"\" + strArray[num];
                smethod_84("Start download files... [" + strArray[num] + "]", serverControll_0);
                Uri address = new Uri(string_0);
                WebClient client = new WebClient();
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(serverControll_0.method_8);
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(serverControll_0.method_7);
                client.DownloadFileAsync(address, str);
            }
            catch (Exception exception)
            {
                strArray = string_0.Split(new char[] { '/' });
                num = strArray.Length - 1;
                str = ServerControll.string_43 + @"\" + ServerControll.string_45 + @"\" + strArray[num];
                if (System.IO.File.Exists(str))
                {
                    System.IO.File.Delete(str);
                }
                ServerControll.bool_26 = false;
                smethod_84("Error - Download the GPS file manually: http://goo.gl/1bdIYt and put it in the folder ServerControll", serverControll_0);
                ServerControll.LogErrori("DownloadGPS", exception, "---");
            }
        }

        /* private scope */
        internal static void smethod_98(ServerControll serverControll_0, Entity entity_0)
        {
            ServerControll.list_11.Add(serverControll_0.getPlayerName(entity_0));
            using (StreamWriter writer = new StreamWriter(ServerControll.string_88 + ServerControll.string_60, true))
            {
                writer.WriteLine(serverControll_0.getPlayerName(entity_0));
                writer.Close();
            }
        }

        /* private scope */
        internal static void smethod_99(Entity entity_0, ServerControll serverControll_0)
        {
            StreamWriter writer;
            string str;
            if (System.IO.File.Exists(ServerControll.string_88 + ServerControll.string_57))
            {
                string[] strArray = System.IO.File.ReadAllLines(ServerControll.string_88 + ServerControll.string_57);
                int num = 10 - 1;
                if (strArray.Length >= 10)
                {
                    System.IO.File.Delete(ServerControll.string_88 + ServerControll.string_57);
                    using (writer = new StreamWriter(ServerControll.string_88 + ServerControll.string_57, true))
                    {
                        str = string.Concat(new object[] { serverControll_0.getPlayerName(entity_0), ServerControll.char_1, serverControll_0.getPlayerID(entity_0), ServerControll.char_1, serverControll_0.getPlayerGuid(entity_0), ServerControll.char_1, serverControll_0.getPlayerHWID(entity_0), ServerControll.char_1, serverControll_0.getPlayerXuid(entity_0), ServerControll.char_1, serverControll_0.getPlayerIP(entity_0) });
                        for (int i = 1; i < num; i++)
                        {
                            writer.WriteLine(strArray[i]);
                        }
                        writer.WriteLine(str);
                        writer.Close();
                        return;
                    }
                }
                using (writer = new StreamWriter(ServerControll.string_88 + ServerControll.string_57, true))
                {
                    str = string.Concat(new object[] { serverControll_0.getPlayerName(entity_0), ServerControll.char_1, serverControll_0.getPlayerID(entity_0), ServerControll.char_1, serverControll_0.getPlayerGuid(entity_0), ServerControll.char_1, serverControll_0.getPlayerHWID(entity_0), ServerControll.char_1, serverControll_0.getPlayerXuid(entity_0), ServerControll.char_1, serverControll_0.getPlayerIP(entity_0) });
                    writer.WriteLine(str);
                    writer.Close();
                    return;
                }
            }
            using (writer = new StreamWriter(ServerControll.string_88 + ServerControll.string_57, true))
            {
                str = string.Concat(new object[] { serverControll_0.getPlayerName(entity_0), ServerControll.char_1, serverControll_0.getPlayerID(entity_0), ServerControll.char_1, serverControll_0.getPlayerGuid(entity_0), ServerControll.char_1, serverControll_0.getPlayerHWID(entity_0), ServerControll.char_1, serverControll_0.getPlayerXuid(entity_0), ServerControll.char_1, serverControll_0.getPlayerIP(entity_0) });
                writer.WriteLine(str);
                writer.Close();
            }
        }

        [DllImport("kernel32.dll", SetLastError=true)]
        /* private scope */
        internal static extern IntPtr VirtualAlloc(IntPtr intptr_0, UIntPtr uintptr_0, uint uint_0, uint uint_1);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll")]
        /* private scope */
        internal static extern bool VirtualProtect(IntPtr intptr_0, IntPtr intptr_1, uint uint_0, out uint uint_1);
        [DllImport("kernel32.dll", SetLastError=true)]
        /* private scope */
        internal static extern bool WriteProcessMemory(IntPtr intptr_0, IntPtr intptr_1, byte[] byte_0, IntPtr intptr_2, out int int_0);
        [DllImport("kernel32.dll", EntryPoint="WriteProcessMemory")]
        /* private scope */
        internal static extern int WriteProcessMemory_1(IntPtr intptr_0, IntPtr intptr_1, [In, Out] byte[] byte_0, uint uint_0, out IntPtr intptr_2);
    }
}

