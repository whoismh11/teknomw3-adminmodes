//namespace MyAdmin.ServerControll
using System;
using System.Text;
using InfinityScript;
using System.IO;
using System.Collections.Generic;

namespace ServerControll
{
    public partial class MyAdmin : BaseScript
    {
        public static partial class ConfigValues
        {
        }
        event Action<Entity, Entity, Entity, int, string, string, Vector3, string> OnPlayerKilledEvent = (t1, t2, t3, t4, t5, t6, t7, t8) => { };
        public MyAdmin()
            : base()
        {
            WriteLog.Info("Script by MH11");
            WriteLog.Info("MyAdmin is starting...");

            if (!Directory.Exists(ConfigValues.ConfigPath))
            {
                WriteLog.Info("Creating directory...");
                Directory.CreateDirectory(ConfigValues.ConfigPath);
            }
            WriteLog.Info("Reading config...");
            if (!System.IO.Directory.Exists(ConfigValues.ConfigPath + @"Settings"))
                System.IO.Directory.CreateDirectory(ConfigValues.ConfigPath + @"Settings");

            if (!File.Exists(ConfigValues.ConfigPath + @"Settings\Settings.txt"))
                CFG_CreateConfig();
            CFG_ReadDictionary(ConfigValues.ConfigPath + @"Settings\Settings.txt", ref Settings);
            WriteLog.Info("Done reading config...");
            PlayerConnected += BAD_OnPlayerConnect;
            PlayerConnecting += BAD_OnPlayerConnecting;
            OnPlayerKilledEvent += CMDS_OnPlayerKilled;

            /*if (!System.IO.File.Exists(ConfigValues.ConfigPath + @"Settings\BlackListNickName.txt"))
                System.IO.File.WriteAllLines(ConfigValues.ConfigPath + @"Settings\BlackListNickName.txt", new string[]
                    {
                        "thisguyhax.",
                    });

            if (!System.IO.File.Exists(ConfigValues.ConfigPath + @"Settings\BlackListClanTag.txt"))
                System.IO.File.WriteAllLines(ConfigValues.ConfigPath + @"Settings\BlackListClanTag.txt", new string[]
                    {
                        "hkClan",
                    });*/

            OnNotify("game_ended", (level) =>
            {
                OnGameEnded();
            });
        }
        public override void OnPlayerKilled(Entity player, Entity inflictor, Entity attacker, int damage, string mod, string weapon, Vector3 dir, string hitLoc)
        {
            OnPlayerKilledEvent(player, inflictor, attacker, damage, mod, weapon, dir, hitLoc);
            base.OnPlayerKilled(player, inflictor, attacker, damage, mod, weapon, dir, hitLoc);
        }
        public void CMDS_OnPlayerKilled(Entity player, Entity inflictor, Entity attacker, int damage, string mod, string weapon, Vector3 dir, string hitLoc)
        {
            if (!settings_enable_spree_messages)
            {
                if (attacker.IsAlive)
                {
                    attacker.SetField("killstreak", attacker.GetField<int>("killstreak") + 1);
                }
                else
                {
                    attacker.SetField("killstreak", 0);
                }

                if (!player.IsAlive)
                {
                    player.SetField("killstreak", 0);
                }
            }
            if (settings_enable_spree_messages)
            {
                if (!attacker.HasField("killstreak"))
                    attacker.SetField("killstreak", new Parameter((int)0));
                if (!player.HasField("killstreak"))
                    player.SetField("killstreak", new Parameter((int)0));

                int attacker_killstreak = UTILS_GetFieldSafe<int>(attacker, "killstreak") + 1;
                int victim_killstreak = UTILS_GetFieldSafe<int>(player, "killstreak");

                attacker.SetField("killstreak", attacker_killstreak);
                player.SetField("killstreak", (int)0);

                if (mod == "MOD_HEAD_SHOT")
                    Utilities.RawSayAll(ServerControll.string_4 + Lang_GetString("Spree_Headshot").Format(new Dictionary<string, string>()
                    {
                        {"<attacker>", attacker.Name},
                        {"<victim>", player.Name}
                    }));

                if (attacker_killstreak == 5)
                    Utilities.RawSayAll(ServerControll.string_4 + Lang_GetString("Spree_Kills_5").Format(new Dictionary<string, string>()
                    {
                        {"<attacker>", attacker.Name}
                    }));

                if (attacker_killstreak == 10)
                    Utilities.RawSayAll(ServerControll.string_4 + Lang_GetString("Spree_Kills_10").Format(new Dictionary<string, string>()
                    {
                        {"<attacker>", attacker.Name}
                    }));

                switch (weapon)
                {
                    case "moab":
                    case "briefcase_bomb_mp":
                    case "destructible_car":
                    case "barrel_mp":
                    case "destructible_toy":
                        Utilities.RawSayAll(ServerControll.string_4 + Lang_GetString("Spree_Explosivekill").Format(new Dictionary<string, string>()
                        {
                            {"<victim>", player.Name}
                        }));
                        break;
                    case "trophy_mp":
                        Utilities.RawSayAll(ServerControll.string_4 + Lang_GetString("Spree_Trophykill").Format(new Dictionary<string, string>()
                        {
                            {"<attacker>", attacker.Name},
                            {"<victim>", player.Name}
                        }));
                        break;
                    case "knife":
                        Utilities.RawSayAll(ServerControll.string_4 + Lang_GetString("Spree_KnifeKill").Format(new Dictionary<string, string>()
                        {
                            {"<attacker>", attacker.Name},
                            {"<victim>", player.Name}
                        }));
                        break;
                }

                if (victim_killstreak >= 5)
                    Utilities.RawSayAll(ServerControll.string_4 + Lang_GetString("Spree_Ended").Format(new Dictionary<string, string>()
                    {
                        {"<attacker>", attacker.Name},
                        {"<victim>", player.Name},
                        {"<killstreak>", victim_killstreak.ToString()}
                    }));
            }
        }
        public T UTILS_GetFieldSafe<T>(Entity player, string field)
        {
            if (player.HasField(field))
                return player.GetField<T>(field);
            return default(T);
        }
        public void BAD_OnPlayerConnect(Entity player)
        {
            //check if bad name
            /*foreach (string identifier in System.IO.File.ReadAllLines(ConfigValues.ConfigPath + @"Settings\BlackListNickName.txt"))
                if (player.Name == identifier)
                {
                    CMD_tmpban(player, "^7Your ^5NickName^7 Is In The BlackList!");
                    Utilities.RawSayAll("^5" + player.Name + "^7 Was TempBanned. Reason: ^5Bad NickName.");
                    return;
                }

            //check if bad clantag
            foreach (string identifier in System.IO.File.ReadAllLines(ConfigValues.ConfigPath + @"Settings\BlackListClanTag.txt"))
                if (player.GetClantag() == identifier)
                {
                    CMD_tmpban(player, "^7Your ^5ClanTag^7 Is In The BlackList!");
                    Utilities.RawSayAll("^5" + player.Name + "^7 Was TempBanned. Reason: ^5Bad ClanTag.");
                    return;
                }*/
            AfterDelay(1100, () =>
            {
                /*if (settings_ColorScoreboard)
                {
                    player.SetClientDvar("useRelativeTeamColors", "1");

                    string mapname = base.Call<string>("getdvar", new Parameter[] { "mapname" });
                    this.ColorScoreboard(player, mapname);*/
                /* Colors:
                 Here are colors so you can change it if you want .. (by BlackLabel :-) )
                 1.Black = 0 0 0 1
                 2.Purple = 0.33333
                 3.Blue = 0 0 1 1
                 4.Cyan = 0 1 1 1
                 5.Green = 0 1 0 1
                 6.lgreen = 0.498 1 0 1
                 7.Yellow = 1 1 0 1
                 8.Orange = 1 0.498 0 1
                 9.Red = 1 0 0 1
                 10.Pink = 1 0.411 0.705 1
                 11.White = 1 1 1 1
                 12.Def = 1 0.8 0.4 1
                 */
                /*player.SpawnedPlayer += new Action(() =>
                {
                    if (player.GetField<string>("sessionteam") == "axis")
                    {
                        foreach (Entity pl in Players)
                        {
                                pl.SetClientDvar("cg_teamcolor_axis", "0 1 0 1");
                                pl.SetClientDvar("cg_teamcolor_allies", "1 0 0 1");
                            }
                    }
                    else if (player.GetField<string>("sessionteam") == "allies")
                            {
                                foreach (Entity pla in Players)
                                {
                                    pla.SetClientDvar("cg_teamcolor_allies", "0 1 0 1");
                                    pla.SetClientDvar("cg_teamcolor_axis", "1 0 0 1");
                                }
                            }
                        });
                    }*/
            });
        }

        public void BAD_OnPlayerConnecting(Entity player)
        {
            if (player.GetClantag().Contains(Encoding.ASCII.GetString(new byte[] { 0x5E, 0x02 })))
                ExecuteCommand("dropclient " + player.GetEntityNumber() + " \"Get out.\"");
        }

        public void CMD_tmpban(Entity target, string reason = "You Have Been TempBanned!")
        {
            AfterDelay(100, () =>
            {
                ExecuteCommand("TempBanClient " + target.GetEntityNumber() + " \"" + reason + "\"");
            });
        }
        public static bool settings_enable_spree_messages
        {
            get
            {
                return bool.Parse(Sett_GetString("SpreeMessages"));
            }
        }
        public static bool settings_unfreezeongameend
        {
            get
            {
                return bool.Parse(Sett_GetString("UnfreezeOnGameEnd"));
            }
        }
        /*public static bool settings_ColorScoreboard
        {
            get
            {
                return bool.Parse(Sett_GetString("ColorScoreboard"));
            }
        }*/
        public void OnGameEnded()
        {
            AfterDelay(1100, () =>
            {
                // UNFREEZE PLAYERS ON GAME END
                if (settings_unfreezeongameend)
                {
                    foreach (Entity player in Players)
                        player.Call("freezecontrols", false);
                }
            });
        }
        /*private void ColorScoreboard(Entity player, string mapname)
       {
           switch (mapname)
           {
               case "mp_aground_ss":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_alpha":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_boardwalk":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_bravo":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_bootleg":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_burn_ss":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_carbon":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_cement":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_courtyard_ss":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_crosswalk_ss":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_dome":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_exchange":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_hardhat":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_hillside_ss":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_interchange":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_italy":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_lambeth":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_meteora":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_moab":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_mogadishu":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_morningwood":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_nola":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_overwatch":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_paris":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_park":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_plaza2":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_qadeem":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_radar":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_restrepo_ss":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_roughneck":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_seatown":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_shipbreaker":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_six_ss":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_terminal_cls":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_underground":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;

               case "mp_village":
                   player.SetClientDvar("g_ScoresColor_Axis", "1 0.498 0 1");
                   player.SetClientDvar("g_ScoresColor_Allies", "1 0.411 0.705 1");
                   player.SetClientDvar("g_ScoresColor_Spectator", "1 0.8 0.4 1");
                   player.SetClientDvar("g_ScoresColor_Free", "1 1 1 1");
                   break;
           }
       }*/
        private void ExecuteCommand(string command)
        {
            Utilities.ExecuteCommand(command);
        }
    }
}