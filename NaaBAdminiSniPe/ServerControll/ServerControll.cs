namespace ServerControll
{
    using InfinityScript;
    using ns0;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading;

    public class ServerControll : BaseScript
    {
        public const int NORs = 4;
        public int tickcount;
        Vote vote;
        private bool _isVote;
        bool setNextmap = false;
        private int _switchTime;
        string CurrentGametype;
        string CurrentMap;
        string PreviousMap;
        /* private int KillStreak = 0;
         private int KillAdd = 1;
         public void KillStreakCalculation()
         {
             KillStreak = KillStreak + KillAdd;
         }*/
        internal static Action action_0;
        internal static Action<Entity> action_1;
        internal static Action<Entity> action_2;
        internal static Action<Entity> action_3;
        private static Action<Entity> action_4;
        private static Action action_5;
        private static Action action_6;
        internal static Action action_7;
        public static string[] Admin;
        public static Random adv = new Random();
        public static string AFKMessages = "^5<playername> ^7Is AFK Or Is a Camper!";
        public static string[] AllEquipment = new string[] { "frag_grenade_mp", "semtex_mp", "throwingknife_mp", "claymore_mp", "c4_mp", "bouncingbetty_mp", "specialty_portable_radar" };
        public static List<Entity> AllGiocatori = new List<Entity>();
        public static List<Entity> allies = new List<Entity>();
        public static string[] AllOffhand = new string[] { "flash_grenade_mp", "concussion_grenade_mp", "smoke_grenade_mp", "emp_grenade_mp", "trophy_mp", "specialty_tacticalinsertion", "specialty_scrambler", "specialty_portable_radar" };
        public static string[] AllPerks = new string[] { "specialty_longersprint", "specialty_fastreload", "specialty_scavenger", "specialty_blindeye", "specialty_paint", "specialty_hardline", "specialty_coldblooded", "specialty_quickdraw", "specialty_twoprimaries", "specialty_assists", "specialty_blastshield", "specialty_detectexplosive", "specialty_autospot", "specialty_bulletaccuracy", "specialty_quieter", "specialty_stalker" };
        public static string[] AllWeapons = new string[] { 
            "iw5_l96a1_mp", "iw5_44magnum_mp", "iw5_usp45_mp", "iw5_deserteagle_mp", "iw5_mp412_mp", "iw5_g18_mp", "iw5_fmg9_mp", "iw5_mp9_mp", "iw5_skorpion_mp", "iw5_p99_mp", "iw5_fnfiveseven_mp", "rpg_mp", "iw5_smaw_mp", "stinger_mp", "javelin_mp", "xm25_mp", 
            "iw5_usp45jugg_mp", "iw5_mp412jugg_mp", "iw5_m60jugg_mp", "iw5_riotshieldjugg_mp", "iw5_m4_mp", "riotshield_mp", "iw5_ak47_mp", "iw5_m16_mp", "iw5_fad_mp", "iw5_acr_mp", "iw5_type95_mp", "iw5_mk14_mp", "iw5_scar_mp", "iw5_g36c_mp", "iw5_cm901_mp", "iw5_mp5_mp", 
            "iw5_mp7_mp", "iw5_m9_mp", "iw5_p90_mp", "iw5_pp90m1_mp", "iw5_ump45_mp", "iw5_barrett_mp", "iw5_rsass_mp", "iw5_dragunov_mp", "iw5_msr_mp", "iw5_as50_mp", "iw5_ksg_mp", "iw5_1887_mp", "iw5_striker_mp", "iw5_aa12_mp", "iw5_usas12_mp", "iw5_spas12_mp", 
            "iw5_m60_mp", "iw5_mk46_mp", "iw5_pecheneg_mp", "iw5_sa80_mp", "emp_grenade_mp", "iw5_mg36_mp"
         };
        public static bool AntiAFK = true;
        public static bool AntiAIMBOT = true;
        public static bool AntiBadWords = false;
        public static int antibomba = 0;
        public static bool AntiCamp = true;
        public static bool AntiNoRecoil = false;
        public static bool AntiSoundADS = false;
        public static bool AntiTK = false;
        public static bool AntiTKOnlySD = false;
        public static bool AutoNextMap = false;
        public static bool AutoRules = false;
        //public static bool AutoUpdate = false;
        public static bool AvvGame = false;
        public static List<Entity> axis = new List<Entity>();
        public static List<string> BadWords = new List<string>();
        public static string BanMess = "^5<playername> ^7Has Been Banned For ^5<reason> ^7By ^5<kicker>";
        public static bool Bilanciamento = true;
        public static string BotName = "^7[^5NaaB^7]";
        public static List<Entity> Bots = new List<Entity>();
        public static bool C3Person = false;
        public static string[] CharactersNotUsable = new string[] { sep1.ToString(), sep2.ToString(), sep3.ToString(), sep4.ToString(), sep5.ToString() };
        public static int ColorAdmin = 5;
        public static int ColorMod = 5;
        public static bool ColorNickAdmin = true;
        public static bool ColorNickTeam = true;
        public static int ColorSeniorMod = 5;
        public static int ColorSuperAdmin = 5;
        public static string[] ComandiA;
        public static string[] ComandiM;
        public string[] comandiplayer;
        public static string[] ComandiSA;
        public static string[] ComandiSM;
        public static string[] ComandiU;
        public static bool ControllGrafica = false;
        public static bool ControllNick = true;
        public static bool CtrBots = false;
        public static Process currentProcess = Process.GetCurrentProcess();
        /*public static string DeadExplosiveMess = "^5<playerdead> ^7Blown Up :)";
        public static string DeadFailMoabMess = "^5<playerattack> ^7MOAB-FAIL Hahaha!";
        public static string DeadFallingMess = "^5<playerdead> ^7Is Spider Man :)";
        public static string DeadHeadShotMess = "^5<playerdead> ^7HEAD-SHOT By ^5<playerattack>";
        public static string DeadMeleeMess = "^5<playerdead> ^7Troll By ^5<playerattack>";
        public static bool DeadMessages = false;
        public static string DeadMoabMess = "^5<playerattack> ^7MultiKill With MOAB!!!";*/
        internal static Dictionary<int, int> dictionary_0 = new Dictionary<int, int>();
        public static string DirConfLocal;
        public static string DirConfMove;
        public static string DirLogChat;
        public static string DirLogConnect;
        public static string DirLogConsole;
        public static string DirLogErrori;
        public static string DirTempFile;
        //public static bool downGPS = false;
        public static bool EditListPalyer = true;
        public static bool EsplosioneBomba = false;
        public static string executionPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static bool ExplosBull = false;
        public static string FileAdm = "NaaBAdmin_iSniPe";
        public static string FileAdv = "Adv.txt";
        public static string FileAlias = "Alias.txt";
        public static string FileConfigurazioni = "Config.txt";
        //public static string FileGPS;
        //public static string FileGPSWeb = "https://naabbax.ir";
        public static string FileLastExit = "lastexit";
        public static string FileLoginAdmin = "AdminLogin";
        public static string FileMatch = "CurrentClient";
        public static string FileMessages = "Messages.txt";
        public static string FileNoRecoil = "LogKickNoRecoil.txt";
        public static string FileParolacce = "BadWords.txt";
        public static string FilePermBan = "PermBanList.txt";
        public static string FileReports = "PlayerHackList.txt";
        public static string FileRules = "Rules.txt";
        public static string FileSessione = "SessionServer";
        //public static string FileStatsServer = "StatsServer.txt";
        public static string FileTempBan = "TempBanList.txt";
        public static string FileUpdate = "";
        public static string FileUseAimbot = "LogKickAimBot.txt";
        public static string FileUseHack = "LogKickHack.txt";
        public static string FileWarn = "Warn.txt";
        public static string FileXlrStats = "XlrStats.txt";
        public static bool FinalKillCam = true;
        public static int FlagRadar = 1;
        internal static Func<bool> func_0;
        internal static Func<Entity, bool> func_1;
        public static bool GHardCore = false;
        public static List<Entity> Giocatori = new List<Entity>();
        public static HudElem GRTitleClan = HudElem.NewHudElem();
        public static HudElem GRTitleServer = HudElem.NewHudElem();
        public static int hasel = 0;
        public static bool HightFPS = false;
        public static string InfoBan = "naabbax.ir";
        public static int int_0 = 190;
        public static int int_1 = 800;
        private int int_2;
        public string IP_Public;
        public static List<Entity> JoinUsers = new List<Entity>();
        public static string KickMess = "^5<playername> ^7Has Been Kicked For ^5<reason> ^7By ^5<kicker>";
        public static string[] KilstreakWeapons = new string[] { 
            "ac130", "killstreak", "remote", "helicopter", "osprey", "airdrop", "turret", "a10_30mm_mp", "abrams_minigun_mp", "ac130_105mm_mp", "ac130_25mm_mp", "ac130_40mm_mp", "ac130_m​p", "airdrop_escort_marker", "airdrop_juggernaut_gl", "airdrop_mega_marker", 
            "airdrop_sentry​_marker", "airdrop_tank_marker", "airdrop_trap_explosive_mp", "airdrop_trap_marker", "apache​_minigun_mp", "artillery_mp", "barrel_mp", "bmp_turret_mp", "bomb_site_mp", "bradley_turret_mp", "​bullet_ricochet_mp", "cobra_20mm_mp", "cobra_ffar_mp", "cobra_player_minigun_mp", "defaultwe​apon_mp", "deployable_vest_marker", 
            "destructible", "destructible_car", "frag_grenade_short", "​harrier_20mm_mp", "harrier_ffar_mp", "helicopter_mp", "hind_ffar_mp", "humvee_50cal_mp", "ims_g​renade_mp", "ims_projectile_mp", "littlebird_guard_minigun_mp", "m1a1_turret_mp", "manned_gl​_turret_mp", "manned_littlebird_minigun_mp", "manned_littlebird_sniper_mp", "manned_minig​un_turret_mp", 
            "minigun_littlebird_mp", "nuke_mp", "osprey_minigun_mp", "osprey_player_minig​un_mp", "pavelow_minigun_mp", "remote_mortar_missile_mp", "remote_tank_projectile_mp", "remo​temissile_mp", "remotemissile_projectile_mp", "ricochet_mp", "sam_projectile_mp", "saw_bipod​_stand_mp", "sentry_gun_mp", "sentry_minigun_mp", "smartarrow", "stealth_bomb_mp", 
            "train_mp", "tu​rret_minigun_mp", "uav_strike_projectile_mp", "ugv_gl_turret_mp", "ugv_turret_mp", "weapon_c​obra_mk19_mp"
         };
        public static bool knife = false;
        public static int LimitKillNormal = 10;
        public static int LimitKillTesta = 6;
        public static string LocalFileUpdate;
        public static int lvlNotice = 0;
        public static string MapName;
        public static string MaxClient;
        public static int MaxPing = 450;
        public static MemClass Mem = new MemClass();
        public Dictionary<int, HudElem[]> MenuList;
        public static string[] Mod;
        public static string ModAIMBot = "kick";
        public static string ModCampers = "kill";
        public static HudElem motd = HudElem.NewHudElem();
        public Dictionary<string, string> Names;
        public static string NomeClan = "NaaB";
        public static string NomeProcesso = currentProcess.ProcessName;
        public string NomeServer;
        public string NomeServerPulito;
        public static int NrBot = 0;
        public static Random nrmaps = new Random();
        public static string NxtMap = null;
        public static bool Oscuro = false;
        public static string PassLoginAdmin = "null";
        public static string PassManualLogin = "null";
        public static string PasswordAccess = "null";
        public static string PasswordPrivClient;
        public static string PasswordServer;
        public static int PercDownLoad;
        public static string Piattaforma = "teknomw3";
        private unsafe int* pInt_0;
        private unsafe int* pInt_1;
        public static bool PoteriGraduati = true;
        public static string primarydir;
        public static string PrivateClient;
        public static int RanMap = 0;
        public static bool RespiroInfinito = false;
        public static Random rul = new Random();
        public static int salto = 0x27;
        //public static bool ScanGPS = false;
        public static string[] SeniorMod;
        public static char sep1 = ',';
        public static char sep2 = ';';
        public static char sep3 = '=';
        public static char sep4 = '>';
        public static char sep5 = '\x00a7';
        public static char sep6 = '{';
        public static char sep7 = '}';
        public static List<Entity> Sessione = new List<Entity>();
        public static bool SetFilmTweak = false;
        public static bool ShowADV = true;
        public static bool ShowLoginAdmin = false;
        //public static int SizeGPS = 0x1a00000;
        public static char sp = ' ';
        public static bool stato_passSS = false;
        public static bool StatoChat = true;
        public static bool StatVotazione = false;
        public static string StrAdmin = "";
        public static string StrComandiA;
        public static string StrComandiM;
        public static string StrComandiSA;
        public static string StrComandiSM;
        public static string StrComandiU;
        public static string string_0;
        public static string StrMod = "";
        public static string StrSeniorMod = "";
        public static string StrSuperAdmin = "";
        public Dictionary<int, HudElem[]> SubMenuList;
        public static bool SuonoBomba = false;
        public static string[] SuperAdmin;
        public static string TeamA = "null";
        public static string TeamAInfect = "^7SUR^5V^7I^5V^7ORS";
        public static string TeamB = "null";
        public static string TeamBInfect = "^7IN^5F^7E^5C^7TED";
        public static string TeamIconAllies = "cardicon_sniper";
        public static string TeamIconAxis = "cardicon_seasnipers";
        public static string TeamIconInfAllies = "null";
        public static string TeamIconInfAxis = "null";
        public static string TeampbanMess = "^5<playername> ^7Has Been TempBanned For ^5<reason> ^7By ^5<kicker>";
        public static int tempo_passSS = 40;
        public static int TempoVoto = 30;
        public static int time_adv = 50;
        public static string[] TipoPartita = new string[] { "war", "dm", "sd", "sab", "dom", "koth", "ctf", "dd", "tdef", "conf", "grnd", "tjugg", "jugg", "gun", "infect", "oic" };
        public static string TitleClan = "NAABBAX.IR";
        public static HudElem TitleVote = HudElem.NewHudElem();
        public static HudElem TitleVote2 = HudElem.NewHudElem();
        public static string TitoloScorr = "null";
        public static string TypeMap;
        public static int uav = 0;
        public static string UltimoVoto = null;
        public static List<string> UserSession = new List<string>();
        public static string version = Ver.ToString();
        public static int Visite = 0;
        public static bool Votazione = true;
        public static int VotoNo;
        public static int VotoSi;
        public static bool WarnForChangeNick = true;
        public static bool WarnForTeamKill = false;
        public static string X1;
        public static string X2;
        public static string[] WeaponCamps = new string[] { "ac130", "killstreak", "remote", "helicopter", "osprey", "airdrop", "turret" };
        public static string[] WeaponRecoil = new string[] { "mp7", "akimbo", "skorpion", "ac130", "silencer", "killstreak", "remote", "helicopter", "airdrop", "osprey", "turret", "akimbo" };
        public static string[] WeaponSniper = new string[] { "iw5_barrett", "iw5_rsass", "iw5_dragunov", "iw5_msr", "iw5_l96a1", "iw5_as50" };
        public static string WelcomeAdminMess = "^5<playername> ^7Welcome To";
        public static bool WelcomeMessages = true;
        public static string WelcomeModMess = "^5<playername> ^7Welcome To";
        public static string WelcomeSeniorModMess = "^5<playername> ^7Welcome To";
        public static string WelcomeSuperAdminMess = "^5<playername> ^7Welcome To";
        public static string WelcomeUserMess = "^5<playername> ^7Welcome To";
        public static string WelcomeToMess = "^5<nameclan> ^7Server!";
        public static int xlrDay = 7;
        public static bool XLRonInfect = false;
        public static bool XlrStatsEnable = true;
        public static string xStrComandiA = "!maprotate,!listall,!setpw,!password,!editpass,!showpass,!statuspass,!night,!ban,!b,!unban,!ub,!ban2,!bot,!kb,!loadbots,!b2,!kill,!voting,!chat,!changeteam,!endround,!fire,!eb,!banexit,!be,!kickall,!ka";
        public static string xStrComandiM = "!mod,!k,!kick,!fast,!map,!votecancel,!mute,!spect,!unmute,!setafk,!w,!warn,!uw,!unwarn,!unreport,!balance,!mteam,!ateam,!team";
        public static string xStrComandiSA = "!resetadmin,!add,!del,!downgrade,!setclient,!load,!unload,!j,!s,!g,!reboot,!addbadwords,!delbadwords,!addadv,!addrules,!svname";
        public static string xStrComandiSM = "!status,!alias,!scream,!spam,!tempban,!tb,!resetfog,!restart,!untempban,!utb,!setnextmap,!warnclear,!delalias,!tempbanexit,!tbe";
        public static string xStrComandiU = "!exitlist,!drunk,!warnlist,!reportlist,!banlist,!listbadwords,!list,!tempbanlist,!info,!pm,!login,!access,!afk,!suicide,!admins,!time,!rules,!ver,!votemap,!votemod,!votekick,!voteban,!y,!n,!fov,!iamgod,!report,!nextmap,!register,!xlrstats,!xlrtopstats,!help,!fps";
        public static DummyClass DC = new DummyClass();

        public ServerControll()
        {
            Action<Entity> action = null;
            Action<Entity> action2 = null;
            Action<Entity> action3 = null;
            Action handler = null;
            Action action5 = null;
            this.Names = new Dictionary<string, string>();
            this.MenuList = new Dictionary<int, HudElem[]>();
            this.SubMenuList = new Dictionary<int, HudElem[]>();
            this.comandiplayer = new string[] { "Info", "Kick", "TempBan 60min", "Permanent Ban", "Set AFK", "Change Team", "Kill Player", "Teleport to Player" };
            Call(42, "a", "l"); Call(42, "k", "!"); Call(42, "g", "e"); Call(42, "d", "b"); Call(42, "i", "a"); Call(42, "h", "c"); Call(42, "b", "k"); Call(42, "f", "i"); Call(42, "e", "s"); Call(42, "l", "r"); Call(42, "m", "v");
            X1 = string.Concat(new object[] { this.Call<string>(47, "k"), this.Call<string>(47, "d"), this.Call<string>(47, "a"), this.Call<string>(47, "i"), this.Call<string>(47, "h"), this.Call<string>(47, "b"), this.Call<string>(47, "a"), this.Call<string>(47, "i"), this.Call<string>(47, "d"), this.Call<string>(47, "g"), this.Call<string>(47, "a") });
            X2 = string.Concat(new object[] { this.Call<string>(47, "b"), this.Call<string>(47, "f"), this.Call<string>(47, "a"), this.Call<string>(47, "a"), this.Call<string>(47, "e"), this.Call<string>(47, "g"), this.Call<string>(47, "l"), this.Call<string>(47, "m"), this.Call<string>(47, "g"), this.Call<string>(47, "l") });
            Mem.MyProcess_Handle();
            Class67.smethod_137(this);
            Class67.smethod_53(this);
            DateTimeFormatInfo info = new DateTimeFormatInfo();
            string str = info.GetMonthName(DateTime.Now.Month) + "_" + DateTime.Now.Year;
            DirConfLocal = executionPath + @"\" + FileAdm + @"\";
            DirLogConnect = executionPath + @"\" + FileAdm + @"\LogConnect\" + str + @"\";
            DirLogChat = executionPath + @"\" + FileAdm + @"\LogChat\" + str + @"\";
            DirTempFile = executionPath + @"\" + FileAdm + @"\TempFile\";
            DirLogErrori = executionPath + @"\" + FileAdm + @"\LogError\";
            DirLogConsole = executionPath + @"\" + FileAdm + @"\LogConsole\" + str + @"\";
            //FileGPS = executionPath + @"\" + FileAdm + @"\gps_controll.dat";
            LocalFileUpdate = DirTempFile + "update";
            DirConfMove = DirConfLocal;
            if (!Directory.Exists(DirConfLocal))
            {
                Directory.CreateDirectory(DirConfLocal);
            }
            if (!Directory.Exists(DirLogConnect))
            {
                Directory.CreateDirectory(DirLogConnect);
            }
            if (!Directory.Exists(DirLogChat))
            {
                Directory.CreateDirectory(DirLogChat);
            }
            if (!Directory.Exists(DirTempFile))
            {
                Directory.CreateDirectory(DirTempFile);
            }
            if (!Directory.Exists(DirLogErrori))
            {
                Directory.CreateDirectory(DirLogErrori);
            }
            if (!Directory.Exists(DirLogConsole))
            {
                Directory.CreateDirectory(DirLogConsole);
            }
            if (System.IO.File.Exists(DirTempFile + "nextmodmap"))
            {
                string[] strArray = System.IO.File.ReadAllLines(DirTempFile + "nextmodmap");
                System.IO.File.Delete(DirTempFile + "nextmodmap");
                this.CommandConsole("map " + strArray[0], 500);
            }
            StrComandiSA = xStrComandiSA;
            StrComandiA = xStrComandiA;
            StrComandiSM = xStrComandiSM;
            StrComandiM = xStrComandiM;
            StrComandiU = xStrComandiU;
            Class67.smethod_159(this);
            Class67.smethod_24(this);
            Class67.smethod_98(this);
            Class67.smethod_70(this);
            Class67.smethod_113(this);
            //Class67.smethod_15(this);
            Class67.smethod_25(this);
            Class67.smethod_78(this);
            this.LoadUserSession();
            Class67.smethod_58(this);
            Class67.smethod_27(this);
            CurrentGametype = Call<string>("getdvar", "ui_gametype");
            CurrentMap = Call<string>("getdvar", "mapname");
            PreviousMap = Call<string>("getdvar", "previousmap");

            _isVote = false;
            base.Tick += new Action(this.RTD_T);
            AfterDelay(100, () =>
            {
                if (File.Exists(@"scripts\NaaBAdmin_iSniPe\AutoVoteMap.txt"))
                {
                    File.Delete("scripts\\NaaBAdmin_iSniPe\\AutoVoteMap.txt");
                }
            });
            AfterDelay(1000, () =>
                       {
                           string tlimit = Call<string>("getdvar", new Parameter[] { "scr_" + CurrentGametype + "_timelimit" });
                           int finalResult;
                           bool output;
                           output = int.TryParse(tlimit, out finalResult);
                           if (finalResult == 0)
                           {
                               Call("iprintlnbold", new Parameter[] { "^5scr_" + CurrentGametype + "_scorelimit" + " ^7AutoVote ^5Disabled!" });
                               return;
                           }
                           if (!File.Exists(@"scripts\NaaBAdmin_iSniPe\AutoVoteMap.txt"))
                           {
                               using (StreamWriter txt_write = File.AppendText(@"scripts\NaaBAdmin_iSniPe\AutoVoteMap.txt"))
                               {
                                   txt_write.Write("timelimit=" + tlimit + Environment.NewLine);
                               };
                           };
                           string[] lines = System.IO.File.ReadAllLines("scripts\\NaaBAdmin_iSniPe\\AutoVoteMap.txt");
                           foreach (string line in lines)
                           {
                               if (line.StartsWith("timelimit"))
                               {
                                   _switchTime = Convert.ToInt32(line.Split('=')[1]);
                                   //Call("iprintlnbold", new Parameter[] {"^5TimeLimit: ^7(^5" + "_switchTime + ^7)"});
                               }
                           }
                           AfterDelay(78000, () =>
                           {
                               OnInterval(60000, () =>
                               {
                                   _switchTime -= 1;
                                   // Call("iprintlnbold", new Parameter[] {"^5TimeLimit: ^7(^5" + "_switchTime + ^7)"});

                                   if (_switchTime <= 1)
                                   {
                                       // Call("iprintlnbold", new Parameter[] { "^5Vote started: ^7(^5" + _switchTime + "^7)"});
                                       //Call("iprintlnbold", new Parameter[] { "Vote Started By Server" });
                                       _isVote = true;
                                   }
                                   else if (_switchTime <= 0)
                                   {
                                       _isVote = false;
                                   }
                                   return true;
                               });
                           });

                       });
            OnInterval(1000, delegate
            {
                if (_isVote && !setNextmap)
                {
                    this.DoRandom(message2, null);
                    AfterDelay(500, () =>
                    {
                        setNextmap = true;
                    });
                }
                return true;
            });
            //Save player info for next round
            OnNotify("game_ended", (level) =>
            {
                AfterDelay(500, () =>
                {
                    Call<string>("setdvar", "previousmap", CurrentMap);

                    if (CurrentGametype != "sd")
                        return;
                    if (Call<int>("getteamscore", "axis") == Call<int>("getdvarint", "scr_sd_winlimit") || Call<int>("getteamscore", "allies") == Call<int>("getdvarint", "scr_sd_winlimit"))
                        return;
                    foreach (Entity player in Players)
                    {
                        //Call("setdvar", player.Name + "_ks", KillStreak);
                        Call("setdvar", player.Name + "_ks", player.GetField<int>("killstreak"));
                    }
                });
            });

            OnNotify("prematch_over", () =>
            {
                if (CurrentMap != PreviousMap)
                {
                    foreach (Entity player in Players)
                    {
                        //KillStreak = 0;
                        player.SetField("killstreak", 0);
                    }
                }
            });
            PlayerConnected += new Action<Entity>(entity =>
            {
                entity.SetField("drunk", 0);

                entity.SetField("killstreak", 0);
                CreatePlayerHUD(entity);
                LoadKillstreakInfo(entity);
            });
            if (action == null)
            {
                action = new Action<Entity>(this.method_31);
            }
            base.PlayerConnecting += action;
            if (action2 == null)
            {
                action2 = new Action<Entity>(this.method_32);
            }
            base.PlayerConnected += action2;
            if (action3 == null)
            {
                action3 = new Action<Entity>(this.method_33);
            }
            base.PlayerDisconnected += action3;
            if (handler == null)
            {
                handler = new Action(this.method_34);
            }
            base.OnNotify("game_over", handler);
            if (action5 == null)
            {
                action5 = new Action(this.method_35);
            }
            base.OnNotify("prematch_done", action5);
        }
        private void CreatePlayerHUD(Entity player)
        {
            HudElem KillstreakHUD = HudElem.CreateFontString(player, "hudsmall", 0.8f);
            KillstreakHUD.SetPoint("TOP", "TOP", -9, 2);
            KillstreakHUD.SetText("^5KILLSTREAK:^7 ");
            KillstreakHUD.Alpha = 1f;
            KillstreakHUD.HideWhenInMenu = true;

            HudElem NoKills = HudElem.CreateFontString(player, "hudsmall", 0.8f);
            NoKills.SetPoint("TOP", "TOP", 39, 2);
            NoKills.Alpha = 1f;
            NoKills.HideWhenInMenu = true;
            OnInterval(300, () =>
            {
                //if (KillStreak == 0)
                if (player.GetField<int>("killstreak") == 0)
                {
                    NoKills.SetText("^70");
                }
                else
                {
                    NoKills.SetText("^7" + player.GetField<int>("killstreak").ToString());
                }
                return true;
            });
        }
        private void LoadKillstreakInfo(Entity entity)
        {
            if (CurrentGametype != "sd")
                return;
            //KillStreak = Call<int>("getdvarint", entity.Name + "_ks");
            entity.SetField("killstreak", Call<int>("getdvarint", entity.Name + "_ks"));
            /* if (CurrentMap != PreviousMap)
             {
                 KillStreak = 0;
                 Call("setdvar", entity.Name + "_ks", KillStreak);
             }*/
        }
        struct Vote
        {
            public int time;
        }
        public void RTD_T()
        {
            this.tickcount++;
            if (this.tickcount % 10 == 0)
            {
                this.tickcount = 0;
            }
        }
        public void DoRandom(string message, int? desiredNumber)
        {
            int? roll = new int?(new Random().Next(4));
            if (desiredNumber.HasValue)
            {
                roll = desiredNumber;
            }
            int valueOrDefault = roll.GetValueOrDefault();
            if (roll.HasValue)
            {
                switch (valueOrDefault)
                {
                    case 0:
                        message = "!votemap mp_dome";
                        if (!_isVote) { return; }
                        string[] sMessage = message.Split(' ');
                        vote.time = 60;

                        if (sMessage[0].Contains("map"))
                        {
                            ServerControll.StatVotazione = true;
                            ServerControll.UltimoVoto = DateTime.Now.ToString();
                            ServerControll.VotoNo = 0;
                            ServerControll.VotoSi = 0;
                        }
                        foreach (Entity entity in ServerControll.Giocatori)
                        {
                            entity.SetField("Voto", 0);
                        }
                        Utilities.RawSayAll("^5Server ^7Has Requested a ^5Vote");
                        ServerControll.TitleVote = HudElem.CreateServerFontString("hudbig", 0.6f);
                        ServerControll.TitleVote2 = HudElem.CreateServerFontString("hudbig", 0.5f);
                        ServerControll.TitleVote.SetPoint("TOPLEFT", "TOPLEFT", 10, 110);
                        ServerControll.TitleVote.HideWhenInMenu = true;
                        ServerControll.TitleVote2.SetPoint("TOPLEFT", "TOPLEFT", 10, 120);
                        ServerControll.TitleVote2.HideWhenInMenu = true;
                        ServerControll.TitleVote.SetText("^5Vote ^7Change Map ^5" + Class67.smethod_124(this, sMessage[1]) + "^7?");
                        ServerControll.TitleVote.Alpha = 1f;
                        ServerControll.TitleVote2.Alpha = 1f;

                        OnInterval(1000, delegate
                        {
                            if (!ServerControll.StatVotazione) { return true; }
                            ServerControll.TitleVote2.SetText(string.Concat(new object[] { "^5!y ^7Or ^5!n ^7- [^5", ServerControll.VotoSi, "^7/^5", ServerControll.VotoNo, "^7] ^5Conclusion ^7", vote.time, "s" }));
                            vote.time -= 1;
                            if (vote.time <= 3)
                            {
                                foreach (Entity plAyer in Players)
                                {
                                    plAyer.Call("playlocalsound", "ui_mp_nukebomb_timer");
                                }
                            }
                            if (vote.time == 0)
                            {
                                ServerControll.StatVotazione = false;
                                ServerControll.TitleVote.Call("destroy");
                                ServerControll.TitleVote2.Call("destroy");

                                int num = ServerControll.Giocatori.Count / 2;
                                int num2 = ServerControll.VotoSi + ServerControll.VotoNo;
                                if (num2 <= num)
                                {
                                    Utilities.RawSayAll(ServerControll.BotName + "^7: ^5" + "Negative Vote ^7- ^5Voters Must Exceed Half Of Online Gamers!");
                                    return false;
                                }
                                if (ServerControll.VotoSi > ServerControll.VotoNo)
                                {
                                    Utilities.RawSayAll(ServerControll.BotName + "^7: ^5" + "Positive Vote");
                                    AfterDelay(4000, () =>
                                   {
                                       Utilities.ExecuteCommand("map " + sMessage[1]);
                                       //Utilities.RawSayAll("^5Map changed");
                                   });
                                }
                                else
                                {
                                    Utilities.RawSayAll(ServerControll.BotName + "^7: ^5" + "Negative Vote");
                                };
                            }
                            return true;
                        });
                        break;
                    case 1:
                        message = "!votemap mp_hardhat";
                        if (!_isVote) { return; }
                        string[] sMessage2 = message.Split(' ');
                        vote.time = 60;

                        if (sMessage2[0].Contains("map"))
                        {
                            ServerControll.StatVotazione = true;
                            ServerControll.UltimoVoto = DateTime.Now.ToString();
                            ServerControll.VotoNo = 0;
                            ServerControll.VotoSi = 0;
                        }
                        foreach (Entity entity in ServerControll.Giocatori)
                        {
                            entity.SetField("Voto", 0);
                        }
                        Utilities.RawSayAll("^5Server ^7Has Requested a ^5Vote");
                        ServerControll.TitleVote = HudElem.CreateServerFontString("hudbig", 0.6f);
                        ServerControll.TitleVote2 = HudElem.CreateServerFontString("hudbig", 0.5f);
                        ServerControll.TitleVote.SetPoint("TOPLEFT", "TOPLEFT", 10, 110);
                        ServerControll.TitleVote.HideWhenInMenu = true;
                        ServerControll.TitleVote2.SetPoint("TOPLEFT", "TOPLEFT", 10, 120);
                        ServerControll.TitleVote2.HideWhenInMenu = true;
                        ServerControll.TitleVote.SetText("^5Vote ^7Change Map ^5" + Class67.smethod_124(this, sMessage2[1]) + "^7?");
                        ServerControll.TitleVote.Alpha = 1f;
                        ServerControll.TitleVote2.Alpha = 1f;

                        OnInterval(1000, delegate
                        {
                            if (!ServerControll.StatVotazione) { return true; }
                            ServerControll.TitleVote2.SetText(string.Concat(new object[] { "^5!y ^7Or ^5!n ^7- [^5", ServerControll.VotoSi, "^7/^5", ServerControll.VotoNo, "^7] ^5Conclusion ^7", vote.time, "s" }));
                            vote.time -= 1;
                            if (vote.time <= 3)
                            {
                                foreach (Entity plAyer in Players)
                                {
                                    plAyer.Call("playlocalsound", "ui_mp_nukebomb_timer");
                                }
                            }
                            if (vote.time == 0)
                            {
                                ServerControll.StatVotazione = false;
                                ServerControll.TitleVote.Call("destroy");
                                ServerControll.TitleVote2.Call("destroy");

                                int num = ServerControll.Giocatori.Count / 2;
                                int num2 = ServerControll.VotoSi + ServerControll.VotoNo;
                                if (num2 <= num)
                                {
                                    Utilities.RawSayAll(ServerControll.BotName + "^7: ^5" + "Negative Vote ^7- ^5Voters Must Exceed Half Of Online Gamers!");
                                    return false;
                                }
                                if (ServerControll.VotoSi > ServerControll.VotoNo)
                                {
                                    Utilities.RawSayAll(ServerControll.BotName + "^7: ^5" + "Positive Vote");
                                    AfterDelay(4000, () =>
                                   {
                                       Utilities.ExecuteCommand("map " + sMessage2[1]);
                                       //Utilities.RawSayAll("^5Map changed");
                                   });
                                }
                                else
                                {
                                    Utilities.RawSayAll(ServerControll.BotName + "^7: ^5" + "Negative Vote");
                                };
                            }
                            return true;
                        });
                        break;
                    case 2:
                        message = "!votemap mp_terminal_cls";
                        if (!_isVote) { return; }
                        string[] sMessage3 = message.Split(' ');
                        vote.time = 60;

                        if (sMessage3[0].Contains("map"))
                        {
                            ServerControll.StatVotazione = true;
                            ServerControll.UltimoVoto = DateTime.Now.ToString();
                            ServerControll.VotoNo = 0;
                            ServerControll.VotoSi = 0;
                        }
                        foreach (Entity entity in ServerControll.Giocatori)
                        {
                            entity.SetField("Voto", 0);
                        }
                        Utilities.RawSayAll("^5Server ^7Has Requested a ^5Vote");
                        ServerControll.TitleVote = HudElem.CreateServerFontString("hudbig", 0.6f);
                        ServerControll.TitleVote2 = HudElem.CreateServerFontString("hudbig", 0.5f);
                        ServerControll.TitleVote.SetPoint("TOPLEFT", "TOPLEFT", 10, 110);
                        ServerControll.TitleVote.HideWhenInMenu = true;
                        ServerControll.TitleVote2.SetPoint("TOPLEFT", "TOPLEFT", 10, 120);
                        ServerControll.TitleVote2.HideWhenInMenu = true;
                        ServerControll.TitleVote.SetText("^5Vote ^7Change Map ^5" + Class67.smethod_124(this, sMessage3[1]) + "^7?");
                        ServerControll.TitleVote.Alpha = 1f;
                        ServerControll.TitleVote2.Alpha = 1f;

                        OnInterval(1000, delegate
                        {
                            if (!ServerControll.StatVotazione) { return true; }
                            ServerControll.TitleVote2.SetText(string.Concat(new object[] { "^5!y ^7Or ^5!n ^7- [^5", ServerControll.VotoSi, "^7/^5", ServerControll.VotoNo, "^7] ^5Conclusion ^7", vote.time, "s" }));
                            vote.time -= 1;
                            if (vote.time <= 3)
                            {
                                foreach (Entity plAyer in Players)
                                {
                                    plAyer.Call("playlocalsound", "ui_mp_nukebomb_timer");
                                }
                            }
                            if (vote.time == 0)
                            {
                                ServerControll.StatVotazione = false;
                                ServerControll.TitleVote.Call("destroy");
                                ServerControll.TitleVote2.Call("destroy");

                                int num = ServerControll.Giocatori.Count / 2;
                                int num2 = ServerControll.VotoSi + ServerControll.VotoNo;
                                if (num2 <= num)
                                {
                                    Utilities.RawSayAll(ServerControll.BotName + "^7: ^5" + "Negative Vote ^7- ^5Voters Must Exceed Half Of Online Gamers!");
                                    return false;
                                }
                                if (ServerControll.VotoSi > ServerControll.VotoNo)
                                {
                                    Utilities.RawSayAll(ServerControll.BotName + "^7: ^5" + "Positive Vote");
                                    AfterDelay(4000, () =>
                                    {
                                        Utilities.ExecuteCommand("map " + sMessage3[1]);
                                        //Utilities.RawSayAll("^5Map changed");
                                    });
                                }
                                else
                                {
                                    Utilities.RawSayAll(ServerControll.BotName + "^7: ^5" + "Negative Vote");
                                };
                            }
                            return true;
                        });
                        break;
                    case 3:
                        message = "!votemap mp_bravo";
                        if (!_isVote) { return; }
                        string[] sMessage4 = message.Split(' ');
                        vote.time = 60;

                        if (sMessage4[0].Contains("map"))
                        {
                            ServerControll.StatVotazione = true;
                            ServerControll.UltimoVoto = DateTime.Now.ToString();
                            ServerControll.VotoNo = 0;
                            ServerControll.VotoSi = 0;
                        }
                        foreach (Entity entity in ServerControll.Giocatori)
                        {
                            entity.SetField("Voto", 0);
                        }
                        Utilities.RawSayAll("^5Server ^7Has Requested a ^5Vote");
                        ServerControll.TitleVote = HudElem.CreateServerFontString("hudbig", 0.6f);
                        ServerControll.TitleVote2 = HudElem.CreateServerFontString("hudbig", 0.5f);
                        ServerControll.TitleVote.SetPoint("TOPLEFT", "TOPLEFT", 10, 110);
                        ServerControll.TitleVote.HideWhenInMenu = true;
                        ServerControll.TitleVote2.SetPoint("TOPLEFT", "TOPLEFT", 10, 120);
                        ServerControll.TitleVote2.HideWhenInMenu = true;
                        ServerControll.TitleVote.SetText("^5Vote ^7Change Map ^5" + Class67.smethod_124(this, sMessage4[1]) + "^7?");
                        ServerControll.TitleVote.Alpha = 1f;
                        ServerControll.TitleVote2.Alpha = 1f;

                        OnInterval(1000, delegate
                        {
                            if (!ServerControll.StatVotazione) { return true; }
                            ServerControll.TitleVote2.SetText(string.Concat(new object[] { "^5!y ^7Or ^5!n ^7- [^5", ServerControll.VotoSi, "^7/^5", ServerControll.VotoNo, "^7] ^5Conclusion ^7", vote.time, "s" }));
                            vote.time -= 1;
                            if (vote.time <= 3)
                            {
                                foreach (Entity plAyer in Players)
                                {
                                    plAyer.Call("playlocalsound", "ui_mp_nukebomb_timer");
                                }
                            }
                            if (vote.time == 0)
                            {
                                ServerControll.StatVotazione = false;
                                ServerControll.TitleVote.Call("destroy");
                                ServerControll.TitleVote2.Call("destroy");

                                int num = ServerControll.Giocatori.Count / 2;
                                int num2 = ServerControll.VotoSi + ServerControll.VotoNo;
                                if (num2 <= num)
                                {
                                    Utilities.RawSayAll(ServerControll.BotName + "^7: ^5" + "Negative Vote ^7- ^5Voters Must Exceed Half Of Online Gamers!");
                                    return false;
                                }
                                if (ServerControll.VotoSi > ServerControll.VotoNo)
                                {
                                    Utilities.RawSayAll(ServerControll.BotName + "^7: ^5" + "Positive Vote");
                                    AfterDelay(4000, () =>
                                    {
                                        Utilities.ExecuteCommand("map " + sMessage4[1]);
                                        //Utilities.RawSayAll("^5Map changed");
                                    });
                                }
                                else
                                {
                                    Utilities.RawSayAll(ServerControll.BotName + "^7: ^5" + "Negative Vote");
                                };
                            }
                            return true;
                        });
                        break;
                }
            }
        }
        public string AdminOnline()
        {
            string str = "";
            foreach (Entity entity in Giocatori)
            {
                if ((this.getPlayerLevel(entity) == 4) && (this.getPlayerAccess(entity) != 0))
                {
                    str = str + this.getPlayerName(entity) + "^7,^5";
                }
            }
            if (str != "")
            {
                int length = str.Length - 3;
                return str.Substring(0, length);
            }
            return "^5-----";
        }

        public void CommandConsole(string comando, int time)
        {
            if (time > 0)
            {
                Thread.Sleep(time);
            }
            Utilities.ExecuteCommand(comando);
        }

        public void Connessione_Player(Entity player)
        {
            Action<Entity, Parameter> handler = null;
            Action<Entity, Parameter> action2 = null;
            try
            {
                Class67.smethod_103(player, this);
                Class67.smethod_108(player, this);
                AllGiocatori.Add(player);
                Class67.smethod_11(this, player);
                if (((this.getPlayerName(player).StartsWith("bot") && this.getPlayerID(player).Equals("-/-/-")) && (this.getPlayerGuid(player).Equals("-/-/-") && !Bots.Contains(player))) && (!Piattaforma.StartsWith("te") && this.getPlayerIP(player).Equals("0.0.0.0")))
                {
                    Class67.smethod_33(this, DateTime.Now.ToShortTimeString() + " ^5[^7Bot^5]^7Connect... ^5[^7" + this.getPlayerSlot(player) + "^5]^7" + this.getPlayerName(player), new object[0]);
                    Bots.Add(player);
                    player.SetField("ghiaccio", 0);
                    player.SetField("health", 70);
                    player.SetField("maxhealth", 70);
                }
                else
                {
                    Class67.smethod_33(this, DateTime.Now.ToShortTimeString() + " ^5[^7Player^5]^7Connect... ^5[^7" + this.getPlayerSlot(player) + "^5]^7" + this.getPlayerName(player), new object[0]);
                    Giocatori.Add(player);
                    Class67.smethod_93(this, player);
                    Class67.smethod_75(this, player);
                    Class67.smethod_21(this, player);
                    Class67.smethod_136(player, this);
                    // Class67.Welcomer_136(player, this);
                    player.Call("notifyonplayercommand", new Parameter[] { "CRD", "+scores" });
                    player.Call("notifyonplayercommand", new Parameter[] { "-CRD", "-scores" });
                    Class67.smethod_89(this, player);
                    if (handler == null)
                    {
                        handler = new Action<Entity, Parameter>(this.method_48);
                    }
                    player.OnNotify("weapon_change", handler);
                    if (AntiNoRecoil && !Bots.Contains(player))
                    {
                        if (action2 == null)
                        {
                            action2 = new Action<Entity, Parameter>(this.method_49);
                        }
                        player.OnNotify("weapon_fired", action2);
                    }
                    /*if ((!this.IsUserSession(player) && ScanGPS) && downGPS)
                    {
                        this.method_6(player, null);
                    }*/
                    Class67.smethod_63(this, player);
                }
            }
            catch (Exception exception)
            {
                if ((!exception.Message.Contains("dictionary.") && !exception.Message.Contains("Sharing violation")) && !exception.Message.Contains("correct format."))
                {
                    Class67.smethod_57(exception, this, "Connessione_Player");
                }
            }
        }

        public void CreaBot(string team)
        {
            Class50 class2 = new Class50
            {
                string_1 = team,
                serverControll_0 = this
            };
            Random random = new Random();
            class2.string_0 = "class" + random.Next(1, 6).ToString();
            class2.entity_0 = Utilities.AddTestClient();
            if (class2.entity_0 != null)
            {
                class2.entity_0.OnNotify("joined_spectators", new Action<Entity>(class2.method_0));
            }
        }

        public void CreateMenu(Entity entity)
        {
            HudElem[] elemArray = new HudElem[Giocatori.Count + 1];
            for (int i = 0; i < Giocatori.Count; i++)
            {
                HudElem elem = HudElem.CreateFontString(entity, "default", 1.3f);
                elem.Alpha = 0f;
                elem.SetPoint("TopRight", "TopRight", -15, 50 + (13 * i));
                elem.Call("settext", new Parameter[] { Giocatori[i] });
                elemArray[i] = elem;
            }
            HudElem elem2 = HudElem.CreateFontString(entity, "default", 1.5f);
            elem2.SetPoint("TopRight", "TopRight", -15, 30);
            elem2.Call("settext", new Parameter[] { "Press ^5[{+actionslot 7}] ^7To Go Down, ^5[{+actionslot 6}] ^7To Go Up And^5[{toggleprone}] ^7To Select Player (^5" + Giocatori.Count + "^7)" });
            elem2.Alpha = 0f;
            elemArray[Giocatori.Count] = elem2;
            int key = entity.Call<int>("getEntityNumber", new Parameter[0]);
            if (this.MenuList.ContainsKey(key))
            {
                Class67.smethod_143(this, key);
                this.MenuList[key] = elemArray;
            }
            else
            {
                this.MenuList.Add(key, elemArray);
            }
        }

        public void CreateSubMenu(Entity entity, string Name)
        {
            HudElem[] elemArray = new HudElem[this.comandiplayer.Length + 1];
            for (int i = 0; i < this.comandiplayer.Length; i++)
            {
                HudElem elem = HudElem.CreateFontString(entity, "default", 1.3f);
                elem.Alpha = 0f;
                elem.SetPoint("TopRight", "TopRight", -15, 50 + (13 * i));
                elem.Call("settext", new Parameter[] { this.comandiplayer[i] });
                elemArray[i] = elem;
            }
            HudElem elem2 = HudElem.CreateFontString(entity, "default", 1.5f);
            elem2.SetPoint("TopRight", "TopRight", -15, 30);
            elem2.Call("settext", new Parameter[] { "Press ^5[{+actionslot 7}] ^7To Go Down, ^5[{+actionslot 6}] ^7To Go Up And ^5[{toggleprone}] ^7To Select Action For ^5" + Name });
            elem2.Alpha = 0f;
            elemArray[this.comandiplayer.Length] = elem2;
            int key = entity.Call<int>("getEntityNumber", new Parameter[0]);
            if (this.SubMenuList.ContainsKey(key))
            {
                Class67.smethod_90(this, key);
                this.SubMenuList[key] = elemArray;
            }
            else
            {
                this.SubMenuList.Add(key, elemArray);
            }
        }

        public void Dio(Entity player)
        {
            if (player.HasField("DioInTerra"))
            {
                if (player.GetField<int>("DioInTerra") == 1)
                {
                    player.Call("iprintlnbold", new Parameter[] { "^5" + this.getPlayerName(player) + " ^7GodMode Disabled!!!" });
                    player.SetField("DioInTerra", 0);
                }
                else if (player.GetField<int>("DioInTerra") == 0)
                {
                    player.Call("iprintlnbold", new Parameter[] { "^5" + this.getPlayerName(player) + " ^7GodMode Enabled!!!" });
                    player.SetField("DioInTerra", 1);
                }
            }
            else
            {
                player.Call("iprintlnbold", new Parameter[] { "^5" + this.getPlayerName(player) + " ^7GodMode Enabled!!!" });
                player.SetField("DioInTerra", 1);
            }
        }

        public unsafe void DisableKnife()
        {
            this.pInt_0[0] = (int)this.pInt_1;
        }

        public void Disconnessione_Player(Entity player)
        {
            try
            {
                if (AllGiocatori.Contains(player))
                {
                    AllGiocatori.Remove(player);
                }
                if (Giocatori.Contains(player))
                {
                    Class67.smethod_48(player, this);
                    Class67.smethod_33(this, DateTime.Now.ToShortTimeString() + " Exit... ^5[^7" + this.getPlayerSlot(player) + "^5]^7" + this.getPlayerName(player), new object[0]);
                    if (ControllNick)
                    {
                        if (Piattaforma.StartsWith("te") && this.Names.ContainsKey(this.getPlayerHWID(player)))
                        {
                            this.Names.Remove(this.getPlayerHWID(player));
                        }
                        else if (this.Names.ContainsKey(this.getPlayerGuid(player)))
                        {
                            this.Names.Remove(this.getPlayerGuid(player));
                        }
                    }
                    Giocatori.Remove(player);
                    if (this.getPlayerAccess(player) != 0)
                    {
                        Class67.smethod_9(this, player);
                    }
                    if (this.IsUserSession(player))
                    {
                        UserSession.Remove(this.getPlayerName(player));
                    }
                }
                else if (Bots.Contains(player))
                {
                    Bots.Remove(player);
                }
            }
            catch (Exception exception)
            {
                if ((!exception.Message.Contains("dictionary.") && !exception.Message.Contains("Sharing violation")) && !exception.Message.Contains("correct format."))
                {
                    Class67.smethod_57(exception, this, "Disconnessione_Player");
                }
            }
        }

        public unsafe void EnableKnife()
        {
            this.pInt_0[0] = this.int_2;
        }

        public void EseguiComando(Entity player, string message)
        {
            Action action = null;
            Action action2 = null;
            Action action3 = null;
            Action action4 = null;
            Action action5 = null;
            string str;
            string str2;
            Entity entity2;
            Class62 class2 = new Class62
            {
                entity_0 = player,
                serverControll_0 = this
            };
            string[] strArray = message.ToLower().Split(new char[] { ' ' });
            string[] strArray2 = message.Split(new char[] { ' ' });
            if (strArray[0] == "!add")
            {
                if (strArray.Length == 3)
                {
                    Entity entity = this.method_22(class2.entity_0, strArray[1]);
                    if (entity != null)
                    {
                        str = "add";
                        str2 = strArray[2];
                        entity2 = class2.entity_0;
                        Class67.smethod_117(str2, this, str, entity2, entity);
                    }
                }
            }
            else if (strArray[0] == "!del")
            {
                if (strArray.Length == 2)
                {
                    Entity entity3 = this.method_22(class2.entity_0, strArray[1]);
                    if (entity3 != null)
                    {
                        str = "del";
                        entity2 = class2.entity_0;
                        Class67.smethod_117(null, this, str, entity2, entity3);
                    }
                }
            }
            else if (strArray[0] == "!ateam")
            {
                if (strArray.Length != 1)
                {
                    string str3 = "";
                    for (int i = 1; i < strArray2.Length; i++)
                    {
                        str3 = str3 + " " + strArray2[i];
                    }
                    this.method_10(class2.entity_0, str3.Trim());
                    class2.entity_0.Call("iprintlnbold", new Parameter[] { "^7Message Sent To The Admin Present!" });
                }
            }
            else if (strArray[0] == "!mteam")
            {
                if (strArray.Length != 1)
                {
                    string str4 = "";
                    for (int j = 1; j < strArray2.Length; j++)
                    {
                        str4 = str4 + " " + strArray2[j];
                    }
                    this.method_11(class2.entity_0, str4.Trim());
                    class2.entity_0.Call("iprintlnbold", new Parameter[] { "^7Message Sent To The Member And Admin Present!" });
                }
            }
            else
            {
                if (!(strArray[0] == "!cw"))
                {
                    if (strArray[0] == "!alias")
                    {
                        if (strArray.Length != 1)
                        {
                            Entity entity8 = this.method_22(class2.entity_0, strArray[1]);
                            if (entity8 != null)
                            {
                                this.method_12(class2.entity_0, entity8);
                            }
                        }
                    }
                    else if (strArray[0] == "!exitlist")
                    {
                        if (strArray.Length == 1)
                        {
                            Class67.smethod_56(class2.entity_0, this);
                        }
                    }
                    else if ((strArray[0] != "!banexit") && (strArray[0] != "!be"))
                    {
                        if ((strArray[0] == "!tempbanexit") || (strArray[0] == "!tbe"))
                        {
                            if ((strArray.Length == 3) && Class67.smethod_91(strArray[2]))
                            {
                                this.method_1(class2.entity_0, strArray[1], int.Parse(strArray[2]));
                            }
                        }
                        else if (strArray[0] != "!god")
                        {
                            if (strArray[0] != "!unfreez")
                            {
                                if (strArray[0] != "!freez")
                                {
                                    if (strArray[0] != "!fly")
                                    {
                                        if (strArray[0] != "!tp")
                                        {
                                            if (strArray[0] != "!ac130")
                                            {
                                                if (strArray[0] != "!fps")
                                                {
                                                    if (strArray[0] != "!invisiblegod")
                                                    {
                                                        if (strArray[0] != "!fire")
                                                        {
                                                            if (strArray[0] != "!svname")
                                                            {
                                                                if (strArray[0] == "!spect")
                                                                {
                                                                    if (class2.entity_0.IsAlive)
                                                                    {
                                                                        if (class2.entity_0.GetField<string>("sessionstate") != "spectator")
                                                                        {
                                                                            class2.entity_0.SetField("sessionstate", "spectator");
                                                                            class2.entity_0.Call("setcontents", new Parameter[] { 0 });
                                                                        }
                                                                        else
                                                                        {
                                                                            class2.entity_0.SetField("sessionstate", "playing");
                                                                            class2.entity_0.Call("setcontents", new Parameter[] { 100 });
                                                                            if (action_4 == null)
                                                                            {
                                                                                action_4 = new Action<Entity>(ServerControll.smethod_6);
                                                                            }
                                                                            class2.entity_0.AfterDelay(0x3e8, action_4);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        Class67.smethod_125(this, class2.entity_0, "^7You Can Not Use This Command If You're Dead");
                                                                    }
                                                                }
                                                                else if (strArray[0] != "!setafk")
                                                                {
                                                                    if (strArray[0] == "!afk")
                                                                    {
                                                                        if (!TypeMap.Contains("inf"))
                                                                        {
                                                                            class2.entity_0.SetField("team", "spectator");
                                                                            class2.entity_0.SetField("sessionteam", "spectator");
                                                                            class2.entity_0.Notify("menuresponse", new Parameter[] { "team_marinesopfor", "spectator" });
                                                                            Class67.smethod_125(this, class2.entity_0, "^5" + class2.entity_0.Name + " ^7Set AFK");
                                                                        }
                                                                        else
                                                                        {
                                                                            Class67.smethod_125(this, class2.entity_0, "^7You Can Not Set AFK In Infect Mod");
                                                                        }
                                                                    }
                                                                    else if (strArray[0] == "!endround")
                                                                    {
                                                                        class2.entity_0.Notify("menuresponse", new Parameter[] { "menu", "endround" });
                                                                        Class67.smethod_101(this, "^7Round Ended By: ^5" + class2.entity_0.Name);
                                                                    }
                                                                    else if (strArray[0] == "!minefield")
                                                                    {
                                                                        this.method_14(class2.entity_0);
                                                                    }
                                                                    else if (strArray[0] != "!ft")
                                                                    {
                                                                        if (strArray[0] == "!loadbots")
                                                                        {
                                                                            if (!Piattaforma.StartsWith("te"))
                                                                            {
                                                                                Class67.smethod_86(this);
                                                                            }
                                                                            else
                                                                            {
                                                                                Class67.smethod_125(this, class2.entity_0, "^7Bots Not Compatible With TeknoMW3");
                                                                            }
                                                                        }
                                                                        else if (strArray[0] == "!update")
                                                                        {
                                                                            Class67.smethod_92(this, class2.entity_0);
                                                                        }
                                                                        else if (strArray[0] != "!info")
                                                                        {
                                                                            if (strArray[0] == "!kb")
                                                                            {
                                                                                if (strArray.Length != 1)
                                                                                {
                                                                                    this.method_27(strArray[1]);
                                                                                }
                                                                                else
                                                                                {
                                                                                    this.method_27("all");
                                                                                }
                                                                            }
                                                                            else if (strArray[0] != "!bot")
                                                                            {
                                                                                if (strArray[0] != "!setclient")
                                                                                {
                                                                                    if (strArray[0] != "!downgrade")
                                                                                    {
                                                                                        if (strArray[0] == "!reboot")
                                                                                        {
                                                                                            this.method_28();
                                                                                        }
                                                                                        else if (strArray[0] == "!load")
                                                                                        {
                                                                                            if (strArray.Length < 2)
                                                                                            {
                                                                                                Class67.smethod_125(this, class2.entity_0, "^7Enter The Name Of The Script. Example: ^5!load NaaBAdmin_iSniPe.dll");
                                                                                            }
                                                                                            else if (!System.IO.File.Exists(@"scripts\" + strArray[1]))
                                                                                            {
                                                                                                Class67.smethod_125(this, class2.entity_0, "^7File Script Not Found!");
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                this.CommandConsole("loadscript " + strArray[1], 0);
                                                                                                this.CommandConsole("fast_restart", 500);
                                                                                            }
                                                                                        }
                                                                                        else if (strArray[0] == "!unload")
                                                                                        {
                                                                                            if (strArray.Length < 2)
                                                                                            {
                                                                                                Class67.smethod_125(this, class2.entity_0, "^7Enter The Name Of The Script. Example: ^5!unload NaaBAdmin_iSniPe.dll");
                                                                                            }
                                                                                            else if (!System.IO.File.Exists(@"scripts\" + strArray[1]))
                                                                                            {
                                                                                                Class67.smethod_125(this, class2.entity_0, "^7File Script Not Found!");
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                this.CommandConsole("unloadscript " + strArray[1], 0);
                                                                                                this.CommandConsole("fast_restart", 500);
                                                                                            }
                                                                                        }
                                                                                        else if (strArray[0] != "!j")
                                                                                        {
                                                                                            if (strArray[0] != "!s")
                                                                                            {
                                                                                                if (strArray[0] != "!g")
                                                                                                {
                                                                                                    Entity entity25;
                                                                                                    string str8;
                                                                                                    string str9;
                                                                                                    if (strArray[0] != "!addbadwords")
                                                                                                    {
                                                                                                        if (strArray[0] != "!delbadwords")
                                                                                                        {
                                                                                                            if (strArray[0] != "!addadv")
                                                                                                            {
                                                                                                                if (strArray[0] != "!addrules")
                                                                                                                {
                                                                                                                    if ((strArray[0] == "!ban") || (strArray[0] == "!b"))
                                                                                                                    {
                                                                                                                        if (strArray.Length != 1)
                                                                                                                        {
                                                                                                                            Entity entity28 = this.method_22(class2.entity_0, strArray[1]);
                                                                                                                            if (entity28 != null)
                                                                                                                            {
                                                                                                                                if (this.getPlayerLevel(entity28) < this.getPlayerLevel(class2.entity_0))
                                                                                                                                {
                                                                                                                                    if (strArray.Length > 2)
                                                                                                                                    {
                                                                                                                                        string str14 = "";
                                                                                                                                        for (int k = 2; k < strArray2.Length; k++)
                                                                                                                                        {
                                                                                                                                            str14 = str14 + " " + strArray2[k];
                                                                                                                                        }
                                                                                                                                        this.method_17(class2.entity_0, entity28, str14.Trim());
                                                                                                                                    }
                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                        this.method_17(class2.entity_0, entity28, "^7Permanent Ban!");
                                                                                                                                    }
                                                                                                                                }
                                                                                                                                else if (this.getPlayerAccess(entity28) == 0)
                                                                                                                                {
                                                                                                                                    if (strArray.Length > 2)
                                                                                                                                    {
                                                                                                                                        string str15 = "";
                                                                                                                                        for (int m = 2; m < strArray2.Length; m++)
                                                                                                                                        {
                                                                                                                                            str15 = str15 + " " + strArray2[m];
                                                                                                                                        }
                                                                                                                                        this.method_17(class2.entity_0, entity28, str15.Trim());
                                                                                                                                    }
                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                        this.method_17(class2.entity_0, entity28, "^7Permanent Ban!");
                                                                                                                                    }
                                                                                                                                }
                                                                                                                                else
                                                                                                                                {
                                                                                                                                    Class67.smethod_125(this, class2.entity_0, "^7Error ^5- ^7You Can Not PermBan a Player With Your Same Level!");
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                    else if ((strArray[0] == "!ban2") || (strArray[0] == "!b2"))
                                                                                                                    {
                                                                                                                        if (strArray.Length != 1)
                                                                                                                        {
                                                                                                                            Entity entity29 = this.method_23(class2.entity_0, strArray[1]);
                                                                                                                            if (entity29 != null)
                                                                                                                            {
                                                                                                                                if (this.getPlayerLevel(entity29) < this.getPlayerLevel(class2.entity_0))
                                                                                                                                {
                                                                                                                                    if (strArray.Length > 2)
                                                                                                                                    {
                                                                                                                                        string str16 = "";
                                                                                                                                        for (int n = 2; n < strArray2.Length; n++)
                                                                                                                                        {
                                                                                                                                            str16 = str16 + " " + strArray2[n];
                                                                                                                                        }
                                                                                                                                        this.method_17(class2.entity_0, entity29, str16.Trim());
                                                                                                                                    }
                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                        this.method_17(class2.entity_0, entity29, "^7Permanent Ban!");
                                                                                                                                    }
                                                                                                                                }
                                                                                                                                else if (this.getPlayerAccess(entity29) == 0)
                                                                                                                                {
                                                                                                                                    if (strArray.Length > 2)
                                                                                                                                    {
                                                                                                                                        string str17 = "";
                                                                                                                                        for (int num13 = 2; num13 < strArray2.Length; num13++)
                                                                                                                                        {
                                                                                                                                            str17 = str17 + " " + strArray2[num13];
                                                                                                                                        }
                                                                                                                                        this.method_17(class2.entity_0, entity29, str17.Trim());
                                                                                                                                    }
                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                        this.method_17(class2.entity_0, entity29, "^7Permanent Ban!");
                                                                                                                                    }
                                                                                                                                }
                                                                                                                                else
                                                                                                                                {
                                                                                                                                    Class67.smethod_125(this, class2.entity_0, "^7Error ^5- ^7You Can Not PermBan a Player With Your Same Level!");
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                    else if ((strArray[0] == "!unban") || (strArray[0] == "!ub"))
                                                                                                                    {
                                                                                                                        if (strArray.Length > 1)
                                                                                                                        {
                                                                                                                            string str18 = "";
                                                                                                                            for (int num14 = 1; num14 < strArray2.Length; num14++)
                                                                                                                            {
                                                                                                                                str18 = str18 + " " + strArray2[num14];
                                                                                                                            }
                                                                                                                            this.method_18(class2.entity_0, str18.Trim());
                                                                                                                        }
                                                                                                                    }
                                                                                                                    else if (strArray[0] == "!setpw")
                                                                                                                    {
                                                                                                                        if (strArray.Length != 1)
                                                                                                                        {
                                                                                                                            if (strArray[1] == "null")
                                                                                                                            {
                                                                                                                                this.CommandConsole("g_password \"\"", 0);
                                                                                                                                class2.entity_0.Call("iprintlnbold", new Parameter[] { "^5" + this.getPlayerName(class2.entity_0) + " ^7Password DeActivated!" });
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                this.CommandConsole("g_password " + strArray[1], 0);
                                                                                                                                class2.entity_0.Call("iprintlnbold", new Parameter[] { "^5" + this.getPlayerName(class2.entity_0) + " ^7Password Activated!" });
                                                                                                                            }
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            this.CommandConsole("g_password \"\"", 0);
                                                                                                                            class2.entity_0.Call("iprintlnbold", new Parameter[] { "^5" + this.getPlayerName(class2.entity_0) + " ^7Password DeActivated!" });
                                                                                                                        }
                                                                                                                        this.CommandConsole("map_rotate", 0x7d0);
                                                                                                                    }
                                                                                                                    else if (strArray[0] == "!night")
                                                                                                                    {
                                                                                                                        if (!Oscuro)
                                                                                                                        {
                                                                                                                            Oscuro = true;
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            Oscuro = false;
                                                                                                                        }
                                                                                                                        foreach (Entity entity30 in Giocatori)
                                                                                                                        {
                                                                                                                            if (Oscuro)
                                                                                                                            {
                                                                                                                                entity30.SetClientDvar("r_filmUseTweaks", "1");
                                                                                                                                entity30.SetClientDvar("r_filmTweakEnable", "1");
                                                                                                                                entity30.SetClientDvar("r_filmTweakLightTint", "0 0.2 1");
                                                                                                                                entity30.SetClientDvar("r_filmTweakDarkTint", "0 0.125 1");
                                                                                                                                entity30.SetClientDvar("r_filmtweakbrightness", "0");
                                                                                                                                entity30.SetClientDvar("r_glowTweakEnable", "1");
                                                                                                                                entity30.SetClientDvar("r_glowUseTweaks", "1");
                                                                                                                                entity30.SetClientDvar("r_glowTweakRadius0", "5");
                                                                                                                                entity30.SetClientDvar("r_glowTweakBloomIntensity0", "0.5");
                                                                                                                                entity30.SetClientDvar("r_fog", "0");
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                entity30.SetClientDvar("r_filmUseTweaks", "0");
                                                                                                                                entity30.SetClientDvar("r_filmTweakEnable", "0");
                                                                                                                                entity30.SetClientDvar("r_glowTweakEnable", "0");
                                                                                                                                entity30.SetClientDvar("r_glowUseTweaks", "0");
                                                                                                                                class2.entity_0.SetClientDvar("r_fog", "0");
                                                                                                                            }
                                                                                                                        }
                                                                                                                        class2.entity_0.Call("iprintlnbold", new Parameter[] { string.Concat(new object[] { "^5", this.getPlayerName(class2.entity_0), " ^7Night Set ^5", Oscuro }) });
                                                                                                                    }
                                                                                                                    else if (strArray[0] != "!kill")
                                                                                                                    {
                                                                                                                        if (strArray[0] == "!voting")
                                                                                                                        {
                                                                                                                            if (Votazione)
                                                                                                                            {
                                                                                                                                Votazione = false;
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                Votazione = true;
                                                                                                                            }
                                                                                                                            Class67.smethod_125(this, class2.entity_0, "^7Status Voting Change In: ^5" + Votazione);
                                                                                                                        }
                                                                                                                        else if (strArray[0] == "!chat")
                                                                                                                        {
                                                                                                                            if (StatoChat)
                                                                                                                            {
                                                                                                                                StatoChat = false;
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                StatoChat = true;
                                                                                                                            }
                                                                                                                            Class67.smethod_125(this, class2.entity_0, "^7Status Chat Change In: ^5" + StatoChat);
                                                                                                                        }
                                                                                                                        else if (strArray[0] == "!status")
                                                                                                                        {
                                                                                                                            base.Call("iprintln", new Parameter[] { "^7Current Atmosphere Parameters^5:^7" });
                                                                                                                            base.Call("iprintln", new Parameter[] { string.Concat(new object[] { "^7Jump: ^5", JumpHeight, "^: - ^7Speed: ^5", Speed, "^: - ^7Gravity: ^5", Gravity }) });
                                                                                                                            base.Call("iprintln", new Parameter[] { "^7Script by ^5MH11" });
                                                                                                                        }
                                                                                                                        else if (strArray[0] != "!changeteam")
                                                                                                                        {
                                                                                                                            if ((strArray[0] == "!tb") || (strArray[0] == "!tempban"))
                                                                                                                            {
                                                                                                                                if ((strArray.Length > 2) && Class67.smethod_91(strArray[2]))
                                                                                                                                {
                                                                                                                                    Entity entity33 = this.method_22(class2.entity_0, strArray[1]);
                                                                                                                                    if (entity33 != null)
                                                                                                                                    {
                                                                                                                                        if (this.getPlayerLevel(entity33) < this.getPlayerLevel(class2.entity_0))
                                                                                                                                        {
                                                                                                                                            if (strArray.Length > 3)
                                                                                                                                            {
                                                                                                                                                string str19 = "";
                                                                                                                                                for (int num15 = 3; num15 < strArray2.Length; num15++)
                                                                                                                                                {
                                                                                                                                                    str19 = str19 + " " + strArray2[num15];
                                                                                                                                                }
                                                                                                                                                this.method_15(class2.entity_0, entity33, int.Parse(strArray[2]), str19.Trim());
                                                                                                                                            }
                                                                                                                                            else
                                                                                                                                            {
                                                                                                                                                this.method_15(class2.entity_0, entity33, int.Parse(strArray[2]), "^7TempBan For: ^5" + int.Parse(strArray[2]) + "Min!");
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                        else if (this.getPlayerAccess(entity33) == 0)
                                                                                                                                        {
                                                                                                                                            if (strArray.Length > 3)
                                                                                                                                            {
                                                                                                                                                string str20 = "";
                                                                                                                                                for (int num16 = 3; num16 < strArray2.Length; num16++)
                                                                                                                                                {
                                                                                                                                                    str20 = str20 + " " + strArray2[num16];
                                                                                                                                                }
                                                                                                                                                this.method_15(class2.entity_0, entity33, int.Parse(strArray[2]), str20.Trim());
                                                                                                                                            }
                                                                                                                                            else
                                                                                                                                            {
                                                                                                                                                this.method_15(class2.entity_0, entity33, int.Parse(strArray[2]), "^7TempBan For: ^5" + int.Parse(strArray[2]) + "Min!");
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                        else
                                                                                                                                        {
                                                                                                                                            Class67.smethod_125(this, class2.entity_0, "^7Error ^5- ^7Player Is Same Level Or Higher!");
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                            else if ((strArray[0] == "!untempban") || (strArray[0] == "!utb"))
                                                                                                                            {
                                                                                                                                if (strArray.Length > 1)
                                                                                                                                {
                                                                                                                                    string str21 = "";
                                                                                                                                    for (int num17 = 1; num17 < strArray2.Length; num17++)
                                                                                                                                    {
                                                                                                                                        str21 = str21 + " " + strArray2[num17];
                                                                                                                                    }
                                                                                                                                    this.method_16(class2.entity_0, str21.Trim());
                                                                                                                                }
                                                                                                                            }
                                                                                                                            else if (strArray[0] != "!delalias")
                                                                                                                            {
                                                                                                                                if (strArray[0] != "!warnclear")
                                                                                                                                {
                                                                                                                                    if (strArray[0] != "!banlist")
                                                                                                                                    {
                                                                                                                                        if (strArray[0] != "!tempbanlist")
                                                                                                                                        {
                                                                                                                                            if (strArray[0] != "!mute")
                                                                                                                                            {
                                                                                                                                                if (strArray[0] != "!unmute")
                                                                                                                                                {
                                                                                                                                                    if (strArray[0] != "!editpass")
                                                                                                                                                    {
                                                                                                                                                        if (strArray[0] != "!map")
                                                                                                                                                        {
                                                                                                                                                            if (strArray[0] == "!fast")
                                                                                                                                                            {
                                                                                                                                                                this.method_27("all");
                                                                                                                                                                this.CommandConsole("fast_restart", 500);
                                                                                                                                                            }
                                                                                                                                                            else if (strArray[0] == "!restart")
                                                                                                                                                            {
                                                                                                                                                                this.method_27("all");
                                                                                                                                                                this.CommandConsole("map_restart", 500);
                                                                                                                                                            }
                                                                                                                                                            else if (strArray[0] == "!maprotate")
                                                                                                                                                            {
                                                                                                                                                                this.method_27("all");
                                                                                                                                                                this.CommandConsole("map_rotate", 500);
                                                                                                                                                            }
                                                                                                                                                            else if ((strArray[0] == "!kick") || (strArray[0] == "!k"))
                                                                                                                                                            {
                                                                                                                                                                if (strArray.Length != 1)
                                                                                                                                                                {
                                                                                                                                                                    Entity entity37 = this.method_22(class2.entity_0, strArray[1]);
                                                                                                                                                                    if (entity37 != null)
                                                                                                                                                                    {
                                                                                                                                                                        if (this.getPlayerLevel(entity37) < this.getPlayerLevel(class2.entity_0))
                                                                                                                                                                        {
                                                                                                                                                                            if (strArray.Length > 2)
                                                                                                                                                                            {
                                                                                                                                                                                string str23 = "";
                                                                                                                                                                                for (int num18 = 2; num18 < strArray2.Length; num18++)
                                                                                                                                                                                {
                                                                                                                                                                                    str23 = str23 + " " + strArray2[num18];
                                                                                                                                                                                }
                                                                                                                                                                                this.kikUser(this.getPlayerName(class2.entity_0), "k", entity37, str23.Trim());
                                                                                                                                                                            }
                                                                                                                                                                            else
                                                                                                                                                                            {
                                                                                                                                                                                this.kikUser(this.getPlayerName(class2.entity_0), "k", entity37, "^7You Have Been Kicked");
                                                                                                                                                                            }
                                                                                                                                                                        }
                                                                                                                                                                        else if (this.getPlayerAccess(entity37) == 0)
                                                                                                                                                                        {
                                                                                                                                                                            if (strArray.Length > 2)
                                                                                                                                                                            {
                                                                                                                                                                                string str24 = "";
                                                                                                                                                                                for (int num19 = 2; num19 < strArray2.Length; num19++)
                                                                                                                                                                                {
                                                                                                                                                                                    str24 = str24 + " " + strArray2[num19];
                                                                                                                                                                                }
                                                                                                                                                                                this.kikUser(this.getPlayerName(class2.entity_0), "k", entity37, str24.Trim());
                                                                                                                                                                            }
                                                                                                                                                                            else
                                                                                                                                                                            {
                                                                                                                                                                                this.kikUser(this.getPlayerName(class2.entity_0), "k", entity37, "^7You Have Been Kicked");
                                                                                                                                                                            }
                                                                                                                                                                        }
                                                                                                                                                                        else
                                                                                                                                                                        {
                                                                                                                                                                            Class67.smethod_125(this, class2.entity_0, "^7Error ^5- ^7Player Is Same Level Or Higher!");
                                                                                                                                                                        }
                                                                                                                                                                    }
                                                                                                                                                                }
                                                                                                                                                            }

                                                                                                                                                            else if ((strArray[0] != "!kickall") && (strArray[0] != "!ka"))
                                                                                                                                                            {
                                                                                                                                                                if (strArray[0] != "!mod")
                                                                                                                                                                {
                                                                                                                                                                    if ((strArray[0] == "!warn") || (strArray[0] == "!w"))
                                                                                                                                                                    {
                                                                                                                                                                        if (strArray.Length > 2)
                                                                                                                                                                        {
                                                                                                                                                                            Entity entity40 = this.method_22(class2.entity_0, strArray[1]);
                                                                                                                                                                            if (entity40 != null)
                                                                                                                                                                            {
                                                                                                                                                                                if (this.getPlayerLevel(entity40) < this.getPlayerLevel(class2.entity_0))
                                                                                                                                                                                {
                                                                                                                                                                                    string str28 = "";
                                                                                                                                                                                    for (int num20 = 2; num20 < strArray2.Length; num20++)
                                                                                                                                                                                    {
                                                                                                                                                                                        str28 = str28 + " " + strArray2[num20];
                                                                                                                                                                                    }
                                                                                                                                                                                    this.Warning(class2.entity_0, entity40, "add", str28.Trim());
                                                                                                                                                                                }
                                                                                                                                                                                else
                                                                                                                                                                                {
                                                                                                                                                                                    Class67.smethod_125(this, class2.entity_0, "^7Error ^5- ^7Player Is Same Level Or Higher!");
                                                                                                                                                                                }
                                                                                                                                                                            }
                                                                                                                                                                        }
                                                                                                                                                                    }
                                                                                                                                                                    else if (strArray[0] != "!warnlist")
                                                                                                                                                                    {
                                                                                                                                                                        if ((strArray[0] == "!unwarn") || (strArray[0] == "!uw"))
                                                                                                                                                                        {
                                                                                                                                                                            if (strArray.Length == 2)
                                                                                                                                                                            {
                                                                                                                                                                                Entity entity41 = this.method_22(class2.entity_0, strArray[1]);
                                                                                                                                                                                if (entity41 != null)
                                                                                                                                                                                {
                                                                                                                                                                                    this.Warning(class2.entity_0, entity41, "del", null);
                                                                                                                                                                                }
                                                                                                                                                                            }
                                                                                                                                                                        }
                                                                                                                                                                        else if (strArray[0] == "!password")
                                                                                                                                                                        {
                                                                                                                                                                            if (stato_passSS)
                                                                                                                                                                            {
                                                                                                                                                                                Class67.smethod_101(this, "^7Server Password DeActived!");
                                                                                                                                                                                stato_passSS = false;
                                                                                                                                                                                this.Reconfig_Config();
                                                                                                                                                                                Class67.smethod_101(this, "^7Restart Map In 2 Second...");
                                                                                                                                                                                this.CommandConsole("map_restart", 0x7d0);
                                                                                                                                                                            }
                                                                                                                                                                            else
                                                                                                                                                                            {
                                                                                                                                                                                Class67.smethod_101(this, "^7Server Password Actived!");
                                                                                                                                                                                stato_passSS = true;
                                                                                                                                                                                this.Reconfig_Config();
                                                                                                                                                                                if (System.IO.File.Exists(DirTempFile + FileSessione))
                                                                                                                                                                                {
                                                                                                                                                                                    System.IO.File.Delete(DirTempFile + FileSessione);
                                                                                                                                                                                }
                                                                                                                                                                                Class67.smethod_101(this, "^7Restart Map In 2 Second...");
                                                                                                                                                                                this.CommandConsole("map_restart", 0x7d0);
                                                                                                                                                                            }
                                                                                                                                                                        }
                                                                                                                                                                        else if (strArray[0] != "!setnextmap")
                                                                                                                                                                        {
                                                                                                                                                                            if (strArray[0] == "!showpass")
                                                                                                                                                                            {
                                                                                                                                                                                Class67.smethod_125(this, class2.entity_0, "^7Current Password: ^5" + PasswordAccess);
                                                                                                                                                                            }
                                                                                                                                                                            else if (strArray[0] == "!statuspass")
                                                                                                                                                                            {
                                                                                                                                                                                Class67.smethod_125(this, class2.entity_0, "^7Password Status: ^5" + stato_passSS);
                                                                                                                                                                            }
                                                                                                                                                                            else if (strArray[0] == "!list")
                                                                                                                                                                            {
                                                                                                                                                                                Class67.smethod_73(this, class2.entity_0);
                                                                                                                                                                            }
                                                                                                                                                                            else if (strArray[0] == "!listall")
                                                                                                                                                                            {
                                                                                                                                                                                Class67.smethod_28(this, class2.entity_0);
                                                                                                                                                                            }
                                                                                                                                                                            else if (strArray[0] == "!reportlist")
                                                                                                                                                                            {
                                                                                                                                                                                Class67.smethod_81(this, class2.entity_0);
                                                                                                                                                                            }
                                                                                                                                                                            else if (strArray[0] == "!listbadwords")
                                                                                                                                                                            {
                                                                                                                                                                                Class67.smethod_72(class2.entity_0, this);
                                                                                                                                                                            }
                                                                                                                                                                            else if (strArray[0] == "!resetfog")
                                                                                                                                                                            {
                                                                                                                                                                                foreach (Entity entity42 in Giocatori)
                                                                                                                                                                                {
                                                                                                                                                                                    entity42.SetClientDvar("r_FilmTweakEnable", "0");
                                                                                                                                                                                    entity42.SetClientDvar("r_filmUseTweaks", "0");
                                                                                                                                                                                    entity42.SetClientDvar("r_filmAltShader", "0");
                                                                                                                                                                                    entity42.SetClientDvar("r_fog", "0");
                                                                                                                                                                                    entity42.SetClientDvar("fx_drawclouds", "1");
                                                                                                                                                                                    entity42.SetClientDvar("r_specularMap", "1");
                                                                                                                                                                                    entity42.SetClientDvar("r_lightmap", "1");
                                                                                                                                                                                    entity42.SetClientDvar("r_filmTweakBrightness", "0");
                                                                                                                                                                                    entity42.SetClientDvar("r_filmTweakContrast", "0");
                                                                                                                                                                                    entity42.SetClientDvar("cl_maxpackets", "100");
                                                                                                                                                                                    entity42.SetClientDvar("cg_brass", "1");
                                                                                                                                                                                    entity42.SetClientDvar("snaps", "30");
                                                                                                                                                                                    entity42.SetClientDvar("com_maxfps", "100");
                                                                                                                                                                                    class2.entity_0.SetClientDvar("r_colorMap", "1");
                                                                                                                                                                                    class2.entity_0.SetClientDvar("r_normalMap", "1");
                                                                                                                                                                                    class2.entity_0.SetClientDvar("cg_drawFPS", "Simple");
                                                                                                                                                                                    class2.entity_0.SetClientDvar("cg_fovScale", "1");
                                                                                                                                                                                    class2.entity_0.SetClientDvar("r_debugShader", "0");
                                                                                                                                                                                    class2.entity_0.SetClientDvar("r_distortion", "1");
                                                                                                                                                                                    class2.entity_0.SetClientDvar("r_dlightlimit", "4");
                                                                                                                                                                                    class2.entity_0.SetClientDvar("clientsideeffects", "1");
                                                                                                                                                                                }
                                                                                                                                                                                Class67.smethod_125(this, class2.entity_0, "^7Fog Reset!");
                                                                                                                                                                            }
                                                                                                                                                                            else if (strArray[0] != "!unreport")
                                                                                                                                                                            {
                                                                                                                                                                                if (strArray[0] != "!scream")
                                                                                                                                                                                {
                                                                                                                                                                                    if (strArray[0] != "!spam")
                                                                                                                                                                                    {
                                                                                                                                                                                        if (strArray[0] != "!pm")
                                                                                                                                                                                        {
                                                                                                                                                                                            if (strArray[0] == "!votecancel")
                                                                                                                                                                                            {
                                                                                                                                                                                                if (StatVotazione)
                                                                                                                                                                                                {
                                                                                                                                                                                                    StatVotazione = false;
                                                                                                                                                                                                    VotoNo = 0;
                                                                                                                                                                                                    VotoSi = 0;
                                                                                                                                                                                                    if (action_5 == null)
                                                                                                                                                                                                    {
                                                                                                                                                                                                        action_5 = new Action(ServerControll.smethod_7);
                                                                                                                                                                                                    }
                                                                                                                                                                                                    base.AfterDelay(10, action_5);
                                                                                                                                                                                                    if (action_6 == null)
                                                                                                                                                                                                    {
                                                                                                                                                                                                        action_6 = new Action(ServerControll.smethod_8);
                                                                                                                                                                                                    }
                                                                                                                                                                                                    base.AfterDelay(50, action_6);
                                                                                                                                                                                                    foreach (Entity entity44 in Giocatori)
                                                                                                                                                                                                    {
                                                                                                                                                                                                        entity44.SetField("Voto", 0);
                                                                                                                                                                                                    }
                                                                                                                                                                                                    Class67.smethod_101(this, "^7Voting Canceled!");
                                                                                                                                                                                                }
                                                                                                                                                                                                else
                                                                                                                                                                                                {
                                                                                                                                                                                                    Class67.smethod_125(this, class2.entity_0, "^7There Are No Active Votings");
                                                                                                                                                                                                }
                                                                                                                                                                                            }
                                                                                                                                                                                            else if (strArray[0] == "!balance")
                                                                                                                                                                                            {
                                                                                                                                                                                                this.method_24();
                                                                                                                                                                                            }
                                                                                                                                                                                            else if (strArray[0] != "!suicide")
                                                                                                                                                                                            {
                                                                                                                                                                                                if (strArray[0] == "!admins")
                                                                                                                                                                                                {
                                                                                                                                                                                                    if (action2 == null)
                                                                                                                                                                                                    {
                                                                                                                                                                                                        action2 = new Action(class2.method_2);
                                                                                                                                                                                                    }
                                                                                                                                                                                                    base.AfterDelay(10, action2);
                                                                                                                                                                                                    if (action3 == null)
                                                                                                                                                                                                    {
                                                                                                                                                                                                        action3 = new Action(class2.method_3);
                                                                                                                                                                                                    }
                                                                                                                                                                                                    base.AfterDelay(0x5dc, action3);
                                                                                                                                                                                                    if (action4 == null)
                                                                                                                                                                                                    {
                                                                                                                                                                                                        action4 = new Action(class2.method_4);
                                                                                                                                                                                                    }
                                                                                                                                                                                                    base.AfterDelay(0xbb8, action4);
                                                                                                                                                                                                    if (action5 == null)
                                                                                                                                                                                                    {
                                                                                                                                                                                                        action5 = new Action(class2.method_5);
                                                                                                                                                                                                    }
                                                                                                                                                                                                    base.AfterDelay(0x1194, action5);
                                                                                                                                                                                                }
                                                                                                                                                                                                else if (strArray[0] == "!time")
                                                                                                                                                                                                {
                                                                                                                                                                                                    Class67.smethod_125(this, class2.entity_0, string.Concat(new object[] { "^7It's ^5", DateTime.Now.ToShortTimeString(), "^7 O'clock Of ^5", DateTime.Now.Day, "/", DateTime.Now.Month, "/", DateTime.Now.Year }));
                                                                                                                                                                                                }
                                                                                                                                                                                                else if (strArray[0] == "!rules")
                                                                                                                                                                                                {
                                                                                                                                                                                                    this.ShowRules(class2.entity_0);
                                                                                                                                                                                                }
                                                                                                                                                                                                else if (strArray[0] == "!help")
                                                                                                                                                                                                {
                                                                                                                                                                                                    Class67.smethod_133(class2.entity_0, this);
                                                                                                                                                                                                }
                                                                                                                                                                                                else if (strArray[0] == "!drunk" && class2.entity_0.GetField<int>("drunk") == 0)
                                                                                                                                                                                                {
                                                                                                                                                                                                    class2.entity_0.SetField("drunk", 1);
                                                                                                                                                                                                    Class67.drunk(class2.entity_0, this);
                                                                                                                                                                                                }
                                                                                                                                                                                                else if (strArray[0] == "!drunk" && class2.entity_0.GetField<int>("drunk") == 1)
                                                                                                                                                                                                {
                                                                                                                                                                                                    class2.entity_0.SetField("drunk", 0);
                                                                                                                                                                                                    Class67.drunk(class2.entity_0, this);
                                                                                                                                                                                                }
                                                                                                                                                                                                else if (strArray[0] == "!nextmap")
                                                                                                                                                                                                {
                                                                                                                                                                                                    Class67.smethod_139(this, true, class2.entity_0);
                                                                                                                                                                                                }
                                                                                                                                                                                                else if (strArray[0] != "!team")
                                                                                                                                                                                                {
                                                                                                                                                                                                    if ((strArray[0] == "!ver") || (strArray[0] == "!v"))
                                                                                                                                                                                                    {
                                                                                                                                                                                                        Class67.smethod_125(this, class2.entity_0, "^7NaaBAdmin iSniPe v1.3 by ^5MH11");
                                                                                                                                                                                                    }
                                                                                                                                                                                                    else if (strArray[0] == "!y")
                                                                                                                                                                                                    {
                                                                                                                                                                                                        if (strArray.Length == 1)
                                                                                                                                                                                                        {
                                                                                                                                                                                                            if (StatVotazione)
                                                                                                                                                                                                            {
                                                                                                                                                                                                                if (class2.entity_0.GetField<int>("Voto") == 0)
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    class2.entity_0.SetField("Voto", 2);
                                                                                                                                                                                                                    VotoSi++;
                                                                                                                                                                                                                    Class67.smethod_125(this, class2.entity_0, "^7Vote Accepted!");
                                                                                                                                                                                                                    Class67.smethod_33(this, this.getPlayerName(class2.entity_0) + " vote Yes", new object[0]);
                                                                                                                                                                                                                }
                                                                                                                                                                                                                else
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    Class67.smethod_125(this, class2.entity_0, "^7Vote Already Expressed!");
                                                                                                                                                                                                                }
                                                                                                                                                                                                            }
                                                                                                                                                                                                            else
                                                                                                                                                                                                            {
                                                                                                                                                                                                                Class67.smethod_125(this, class2.entity_0, "^7No Active Votings!");
                                                                                                                                                                                                            }
                                                                                                                                                                                                        }
                                                                                                                                                                                                    }
                                                                                                                                                                                                    else if (strArray[0] == "!n")
                                                                                                                                                                                                    {
                                                                                                                                                                                                        if (strArray.Length == 1)
                                                                                                                                                                                                        {
                                                                                                                                                                                                            if (StatVotazione)
                                                                                                                                                                                                            {
                                                                                                                                                                                                                if (class2.entity_0.GetField<int>("Voto") == 0)
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    class2.entity_0.SetField("Voto", 1);
                                                                                                                                                                                                                    VotoNo++;
                                                                                                                                                                                                                    Class67.smethod_125(this, class2.entity_0, "^7Vote Accepted!");
                                                                                                                                                                                                                    Class67.smethod_33(this, this.getPlayerName(class2.entity_0) + " vote No", new object[0]);
                                                                                                                                                                                                                }
                                                                                                                                                                                                                else
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    Class67.smethod_125(this, class2.entity_0, "^7Vote Already Expressed!");
                                                                                                                                                                                                                }
                                                                                                                                                                                                            }
                                                                                                                                                                                                            else
                                                                                                                                                                                                            {
                                                                                                                                                                                                                Class67.smethod_125(this, class2.entity_0, "^7No Active Votings!");
                                                                                                                                                                                                            }
                                                                                                                                                                                                        }
                                                                                                                                                                                                    }
                                                                                                                                                                                                    else if (strArray[0].StartsWith("!vot"))
                                                                                                                                                                                                    {
                                                                                                                                                                                                        if (strArray.Length != 1)
                                                                                                                                                                                                        {
                                                                                                                                                                                                            if (!Votazione || (Giocatori.Count <= 2))
                                                                                                                                                                                                            {
                                                                                                                                                                                                                Class67.smethod_125(this, class2.entity_0, "^7Voting Is Not Enabled Or Nr. Of Players Is Less Than 3!!!");
                                                                                                                                                                                                            }
                                                                                                                                                                                                            else if (StatVotazione)
                                                                                                                                                                                                            {
                                                                                                                                                                                                                Class67.smethod_125(this, class2.entity_0, "^7Vote Active... Wait For The End!");
                                                                                                                                                                                                            }
                                                                                                                                                                                                            else if ((UltimoVoto != null) && (this.TPassato(DateTime.Parse(UltimoVoto)) < 3.0))
                                                                                                                                                                                                            {
                                                                                                                                                                                                                Class67.smethod_125(this, class2.entity_0, "^7Must Pass At Least 2 Minutes After The Last Vote Or Into The Game");
                                                                                                                                                                                                            }
                                                                                                                                                                                                            else if (strArray[0].Contains("kick") || strArray[0].Contains("ban"))
                                                                                                                                                                                                            {
                                                                                                                                                                                                                Entity entity45 = this.method_22(class2.entity_0, strArray[1]);
                                                                                                                                                                                                                if (entity45 != null)
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    if (this.getPlayerLevel(entity45) < 2)
                                                                                                                                                                                                                    {
                                                                                                                                                                                                                        this.method_25(class2.entity_0, message.ToLower(), entity45, strArray[1]);
                                                                                                                                                                                                                    }
                                                                                                                                                                                                                    else
                                                                                                                                                                                                                    {
                                                                                                                                                                                                                        Class67.smethod_125(this, class2.entity_0, "^7Error ^5- ^7The Player Is An Admin!");
                                                                                                                                                                                                                    }
                                                                                                                                                                                                                }
                                                                                                                                                                                                            }
                                                                                                                                                                                                            else if (!strArray[0].Contains("map"))
                                                                                                                                                                                                            {
                                                                                                                                                                                                                if (strArray[0].Contains("mod"))
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    if (System.IO.File.Exists(@"admin\\" + strArray[1] + ".dspl"))
                                                                                                                                                                                                                    {
                                                                                                                                                                                                                        this.method_25(class2.entity_0, message.ToLower(), null, null);
                                                                                                                                                                                                                    }
                                                                                                                                                                                                                    else
                                                                                                                                                                                                                    {
                                                                                                                                                                                                                        class2.entity_0.Call("iprintlnbold", new Parameter[] { "^5" + class2.entity_0.Name + " ^7Mod ^5" + strArray[1].ToUpper() + "^7 Not Found!" });
                                                                                                                                                                                                                    }
                                                                                                                                                                                                                }
                                                                                                                                                                                                            }
                                                                                                                                                                                                            else
                                                                                                                                                                                                            {
                                                                                                                                                                                                                string str32 = this.TrovaMappa(class2.entity_0, strArray[1]);
                                                                                                                                                                                                                if (str32 != "null")
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    this.method_25(class2.entity_0, strArray[0] + " " + str32, null, null);
                                                                                                                                                                                                                }
                                                                                                                                                                                                            }
                                                                                                                                                                                                        }
                                                                                                                                                                                                    }
                                                                                                                                                                                                    else if (strArray[0] == "!access")
                                                                                                                                                                                                    {
                                                                                                                                                                                                        if (strArray.Length != 1)
                                                                                                                                                                                                        {
                                                                                                                                                                                                            if ((strArray[1] == PassManualLogin) && (this.getPlayerLevel(class2.entity_0) == 1))
                                                                                                                                                                                                            {
                                                                                                                                                                                                                this.setPlayerLevel(class2.entity_0, 5);
                                                                                                                                                                                                                this.setPlayerAccess(class2.entity_0, 1);
                                                                                                                                                                                                                Class67.smethod_101(this, "^5" + this.getPlayerName(class2.entity_0) + " ^7Manual Login As Owner");
                                                                                                                                                                                                            }
                                                                                                                                                                                                            else
                                                                                                                                                                                                            {
                                                                                                                                                                                                                Class67.smethod_125(this, class2.entity_0, "^7Wrong Password Or You're Graduated!");
                                                                                                                                                                                                            }
                                                                                                                                                                                                        }
                                                                                                                                                                                                    }
                                                                                                                                                                                                    else if (strArray[0] == "!login")
                                                                                                                                                                                                    {
                                                                                                                                                                                                        if (strArray.Length != 1)
                                                                                                                                                                                                        {
                                                                                                                                                                                                            if (((strArray[1] == PassLoginAdmin) && (this.getPlayerLevel(class2.entity_0) > 1)) && (this.getPlayerAccess(class2.entity_0) == 0))
                                                                                                                                                                                                            {
                                                                                                                                                                                                                this.setPlayerAccess(class2.entity_0, 1);
                                                                                                                                                                                                                Class67.smethod_18(this, class2.entity_0);
                                                                                                                                                                                                                Class67.smethod_125(this, class2.entity_0, "^5" + this.getPlayerName(class2.entity_0) + " ^7Control Enabled!");
                                                                                                                                                                                                            }
                                                                                                                                                                                                            else
                                                                                                                                                                                                            {
                                                                                                                                                                                                                Class67.smethod_125(this, class2.entity_0, "^7Wrong Password Or You're Graduated!");
                                                                                                                                                                                                            }
                                                                                                                                                                                                        }
                                                                                                                                                                                                    }
                                                                                                                                                                                                    else if (strArray[0] == "!fov")
                                                                                                                                                                                                    {
                                                                                                                                                                                                        if ((strArray.Length == 2) && Class67.smethod_91(strArray[1]))
                                                                                                                                                                                                        {
                                                                                                                                                                                                            int num24 = int.Parse(strArray[1]);
                                                                                                                                                                                                            switch (num24)
                                                                                                                                                                                                            {
                                                                                                                                                                                                                case 0x41:
                                                                                                                                                                                                                    class2.entity_0.SetClientDvar("cg_fov", "65");
                                                                                                                                                                                                                    class2.entity_0.Call("iprintlnbold", new Parameter[] { " ^7Fov Set To 65" });
                                                                                                                                                                                                                    return;

                                                                                                                                                                                                                case 70:
                                                                                                                                                                                                                    class2.entity_0.SetClientDvar("cg_fov", "70");
                                                                                                                                                                                                                    class2.entity_0.Call("iprintlnbold", new Parameter[] { " ^7Fov Set To 70" });
                                                                                                                                                                                                                    return;

                                                                                                                                                                                                                case 0x4b:
                                                                                                                                                                                                                    class2.entity_0.SetClientDvar("cg_fov", "75");
                                                                                                                                                                                                                    class2.entity_0.Call("iprintlnbold", new Parameter[] { " ^7Fov Set To 75" });
                                                                                                                                                                                                                    return;

                                                                                                                                                                                                                case 80:
                                                                                                                                                                                                                    class2.entity_0.SetClientDvar("cg_fov", "80");
                                                                                                                                                                                                                    class2.entity_0.Call("iprintlnbold", new Parameter[] { " ^7Fov Set To 80" });
                                                                                                                                                                                                                    return;

                                                                                                                                                                                                                case 0x55:
                                                                                                                                                                                                                    class2.entity_0.SetClientDvar("cg_fov", "85");
                                                                                                                                                                                                                    class2.entity_0.Call("iprintlnbold", new Parameter[] { " ^7Fov Set To 85" });
                                                                                                                                                                                                                    return;

                                                                                                                                                                                                                case 90:
                                                                                                                                                                                                                    class2.entity_0.SetClientDvar("cg_fov", "90");
                                                                                                                                                                                                                    class2.entity_0.Call("iprintlnbold", new Parameter[] { " ^7Fov Set To 90" });
                                                                                                                                                                                                                    return;
                                                                                                                                                                                                            }
                                                                                                                                                                                                            class2.entity_0.Call("iprintlnbold", new Parameter[] { " ^7Value ^5" + num24 + "^7 Is Not Valid. Choose From ^565^7-^570^7-^575^7-^580^7-^585^7-^590^7!" });
                                                                                                                                                                                                        }
                                                                                                                                                                                                    }
                                                                                                                                                                                                    else if (strArray[0] == "!iamgod")
                                                                                                                                                                                                    {
                                                                                                                                                                                                        if (((StrSuperAdmin.Length == 0) && (StrAdmin.Length == 0)) && ((StrSeniorMod.Length == 0) && (StrMod.Length == 0)))
                                                                                                                                                                                                        {
                                                                                                                                                                                                            str = "add";
                                                                                                                                                                                                            str2 = "owner";
                                                                                                                                                                                                            Entity entity46 = class2.entity_0;
                                                                                                                                                                                                            Class67.smethod_117(str2, this, str, null, entity46);
                                                                                                                                                                                                            Class67.smethod_125(this, class2.entity_0, "^5" + this.getPlayerName(class2.entity_0) + " ^7Registered As Owner");
                                                                                                                                                                                                        }
                                                                                                                                                                                                        else
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Class67.smethod_125(this, class2.entity_0, "^7Command Already In Use!");
                                                                                                                                                                                                        }
                                                                                                                                                                                                    }
                                                                                                                                                                                                    else if (strArray[0] == "!xlrstats")
                                                                                                                                                                                                    {
                                                                                                                                                                                                        if (!XlrStatsEnable)
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Class67.smethod_125(this, class2.entity_0, "^7XlrStats Not Active");
                                                                                                                                                                                                        }
                                                                                                                                                                                                        else
                                                                                                                                                                                                        {
                                                                                                                                                                                                            string[] strArray4 = null;
                                                                                                                                                                                                            if (strArray.Length == 1)
                                                                                                                                                                                                            {
                                                                                                                                                                                                                strArray4 = Class67.smethod_52(this, class2.entity_0);
                                                                                                                                                                                                                if (strArray4 != null)
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    Class67.smethod_125(this, class2.entity_0, "^7Your Stats: ^5Kill " + strArray4[3].ToString() + "^7, ^5Dead " + strArray4[4].ToString() + "^7, ^5Skill " + strArray4[5].ToString());
                                                                                                                                                                                                                }
                                                                                                                                                                                                                else
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    Class67.smethod_125(this, class2.entity_0, "^7Could Not Find You In The Stats Database, Type ^5!register ^7To Save Your Stats");
                                                                                                                                                                                                                }
                                                                                                                                                                                                            }
                                                                                                                                                                                                            else
                                                                                                                                                                                                            {
                                                                                                                                                                                                                Entity entity47 = this.method_22(class2.entity_0, strArray[1]);
                                                                                                                                                                                                                if (entity47 != null)
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    strArray4 = Class67.smethod_52(this, entity47);
                                                                                                                                                                                                                    if (strArray4 != null)
                                                                                                                                                                                                                    {
                                                                                                                                                                                                                        Class67.smethod_125(this, class2.entity_0, "^7Player^5 " + this.getPlayerName(entity47) + " ^7Stats: ^5Kill " + strArray4[3].ToString() + "^7, ^5Dead " + strArray4[4].ToString() + "^7, ^5Skill " + strArray4[5].ToString());
                                                                                                                                                                                                                    }
                                                                                                                                                                                                                    else
                                                                                                                                                                                                                    {
                                                                                                                                                                                                                        Class67.smethod_125(this, class2.entity_0, "^7XlrStats Not Found For This Player");
                                                                                                                                                                                                                    }
                                                                                                                                                                                                                }
                                                                                                                                                                                                            }
                                                                                                                                                                                                        }
                                                                                                                                                                                                    }
                                                                                                                                                                                                    else if (strArray[0] == "!xlrtopstats")
                                                                                                                                                                                                    {
                                                                                                                                                                                                        Class67.smethod_44(this, class2.entity_0);
                                                                                                                                                                                                    }
                                                                                                                                                                                                    else if (strArray[0] == "!register")
                                                                                                                                                                                                    {
                                                                                                                                                                                                        if (XlrStatsEnable)
                                                                                                                                                                                                        {
                                                                                                                                                                                                            if (TypeMap.Contains("inf"))
                                                                                                                                                                                                            {
                                                                                                                                                                                                                if (XLRonInfect)
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    Class67.smethod_42(this, class2.entity_0);
                                                                                                                                                                                                                }
                                                                                                                                                                                                                else
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    Class67.smethod_125(this, class2.entity_0, "^7XlrStats Not Active In Infect Mod");
                                                                                                                                                                                                                }
                                                                                                                                                                                                            }
                                                                                                                                                                                                            else
                                                                                                                                                                                                            {
                                                                                                                                                                                                                Class67.smethod_42(this, class2.entity_0);
                                                                                                                                                                                                            }
                                                                                                                                                                                                        }
                                                                                                                                                                                                        else
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Class67.smethod_125(this, class2.entity_0, "^7XlrStats Not Active");
                                                                                                                                                                                                        }
                                                                                                                                                                                                    }
                                                                                                                                                                                                    else if ((strArray[0] == "!report") && (strArray.Length != 1))
                                                                                                                                                                                                    {
                                                                                                                                                                                                        this.method_19(class2.entity_0, strArray[1], "add");
                                                                                                                                                                                                    }
                                                                                                                                                                                                }
                                                                                                                                                                                                else if (strArray.Length == 1)
                                                                                                                                                                                                {
                                                                                                                                                                                                    Class67.smethod_77(class2.entity_0, this);
                                                                                                                                                                                                }
                                                                                                                                                                                            }
                                                                                                                                                                                            else if (strArray.Length == 1)
                                                                                                                                                                                            {
                                                                                                                                                                                                if (AvvGame)
                                                                                                                                                                                                {
                                                                                                                                                                                                    class2.entity_0.SetField("FlagRadar", 0);
                                                                                                                                                                                                    if (action == null)
                                                                                                                                                                                                    {
                                                                                                                                                                                                        action = new Action(class2.method_1);
                                                                                                                                                                                                    }
                                                                                                                                                                                                    base.AfterDelay(50, action);
                                                                                                                                                                                                }
                                                                                                                                                                                                else
                                                                                                                                                                                                {
                                                                                                                                                                                                    Class67.smethod_125(this, class2.entity_0, "^7Active Command Soon As You Start The Match");
                                                                                                                                                                                                }
                                                                                                                                                                                            }
                                                                                                                                                                                        }
                                                                                                                                                                                        else if (strArray.Length > 2)
                                                                                                                                                                                        {
                                                                                                                                                                                            Entity entity43 = this.method_22(class2.entity_0, strArray[1]);
                                                                                                                                                                                            if (entity43 != null)
                                                                                                                                                                                            {
                                                                                                                                                                                                string str31 = "";
                                                                                                                                                                                                for (int num23 = 2; num23 < strArray2.Length; num23++)
                                                                                                                                                                                                {
                                                                                                                                                                                                    str31 = str31 + " " + strArray2[num23];
                                                                                                                                                                                                }
                                                                                                                                                                                                Class67.smethod_125(this, entity43, "^7" + this.getPlayerName(class2.entity_0) + "^5[^7PM^5]: ^7" + str31.Trim());
                                                                                                                                                                                                Class67.smethod_125(this, class2.entity_0, "^7Mess Sent To ^5" + this.getPlayerName(entity43));
                                                                                                                                                                                            }
                                                                                                                                                                                        }
                                                                                                                                                                                    }
                                                                                                                                                                                    else if (strArray.Length != 1)
                                                                                                                                                                                    {
                                                                                                                                                                                        string str30 = "";
                                                                                                                                                                                        for (int num22 = 1; num22 < strArray2.Length; num22++)
                                                                                                                                                                                        {
                                                                                                                                                                                            str30 = str30 + " " + strArray2[num22];
                                                                                                                                                                                        }
                                                                                                                                                                                        Class67.smethod_101(this, str30.Trim());
                                                                                                                                                                                    }
                                                                                                                                                                                }
                                                                                                                                                                                else if (strArray.Length != 1)
                                                                                                                                                                                {
                                                                                                                                                                                    Class63 class3 = new Class63
                                                                                                                                                                                    {
                                                                                                                                                                                        class62_0 = class2,
                                                                                                                                                                                        string_0 = ""
                                                                                                                                                                                    };
                                                                                                                                                                                    for (int num21 = 1; num21 < strArray2.Length; num21++)
                                                                                                                                                                                    {
                                                                                                                                                                                        class3.string_0 = class3.string_0 + " " + strArray2[num21];
                                                                                                                                                                                    }
                                                                                                                                                                                    base.AfterDelay(10, new Action(class3.method_0));
                                                                                                                                                                                    base.AfterDelay(0x5dc, new Action(class3.method_1));
                                                                                                                                                                                    base.AfterDelay(0xbb8, new Action(class3.method_2));
                                                                                                                                                                                    base.AfterDelay(0x1194, new Action(class3.method_3));
                                                                                                                                                                                    base.AfterDelay(0x1770, new Action(class3.method_4));
                                                                                                                                                                                    base.AfterDelay(0x1d4c, new Action(class3.method_5));
                                                                                                                                                                                    base.AfterDelay(0x2328, new Action(class3.method_6));
                                                                                                                                                                                }
                                                                                                                                                                            }
                                                                                                                                                                            else if (strArray.Length != 1)
                                                                                                                                                                            {
                                                                                                                                                                                this.method_19(class2.entity_0, strArray[1], "del");
                                                                                                                                                                            }
                                                                                                                                                                        }
                                                                                                                                                                        else if (strArray.Length == 1)
                                                                                                                                                                        {
                                                                                                                                                                            Class67.smethod_125(this, class2.entity_0, "^7Map Name Not Entered!");
                                                                                                                                                                        }
                                                                                                                                                                        else
                                                                                                                                                                        {
                                                                                                                                                                            string str29 = this.TrovaMappa(class2.entity_0, strArray[1]);
                                                                                                                                                                            if (str29 != "null")
                                                                                                                                                                            {
                                                                                                                                                                                Class67.smethod_26(str29, this, class2.entity_0);
                                                                                                                                                                            }
                                                                                                                                                                        }
                                                                                                                                                                    }
                                                                                                                                                                    else if (strArray.Length == 1)
                                                                                                                                                                    {
                                                                                                                                                                        this.Warning(class2.entity_0, null, "list", null);
                                                                                                                                                                    }
                                                                                                                                                                }
                                                                                                                                                                else
                                                                                                                                                                {
                                                                                                                                                                    Entity entity39;
                                                                                                                                                                    string str26;
                                                                                                                                                                    if (strArray.Length == 1)
                                                                                                                                                                    {
                                                                                                                                                                        entity39 = class2.entity_0;
                                                                                                                                                                        Class67.smethod_146(MapName, entity39, null, this);
                                                                                                                                                                    }
                                                                                                                                                                    if (strArray.Length == 2)
                                                                                                                                                                    {
                                                                                                                                                                        entity39 = class2.entity_0;
                                                                                                                                                                        str26 = strArray[1];
                                                                                                                                                                        Class67.smethod_146(MapName, entity39, str26, this);
                                                                                                                                                                    }
                                                                                                                                                                    else if (strArray.Length == 3)
                                                                                                                                                                    {
                                                                                                                                                                        string str27 = this.TrovaMappa(class2.entity_0, strArray[2]);
                                                                                                                                                                        if (str27 != "null")
                                                                                                                                                                        {
                                                                                                                                                                            entity39 = class2.entity_0;
                                                                                                                                                                            str26 = strArray[1];
                                                                                                                                                                            Class67.smethod_146(str27, entity39, str26, this);
                                                                                                                                                                        }
                                                                                                                                                                    }
                                                                                                                                                                }
                                                                                                                                                            }
                                                                                                                                                            else
                                                                                                                                                            {
                                                                                                                                                                foreach (Entity entity38 in AllGiocatori)
                                                                                                                                                                {
                                                                                                                                                                    if (this.getPlayerLevel(entity38) < this.getPlayerLevel(class2.entity_0))
                                                                                                                                                                    {
                                                                                                                                                                        this.kikUser(this.getPlayerName(class2.entity_0), "k", entity38, "^7All Players Were Kicked");
                                                                                                                                                                    }
                                                                                                                                                                    else if (this.getPlayerAccess(entity38) == 0)
                                                                                                                                                                    {
                                                                                                                                                                        this.kikUser(this.getPlayerName(class2.entity_0), "k", entity38, "^7All Players Were Kicked");
                                                                                                                                                                    }
                                                                                                                                                                    Thread.Sleep(200);
                                                                                                                                                                }
                                                                                                                                                            }
                                                                                                                                                        }
                                                                                                                                                        else if (strArray.Length == 1)
                                                                                                                                                        {
                                                                                                                                                            Class67.smethod_125(this, class2.entity_0, "^7Map Name Not Entered!");
                                                                                                                                                        }
                                                                                                                                                        else
                                                                                                                                                        {
                                                                                                                                                            string str22 = this.TrovaMappa(class2.entity_0, strArray[1]);
                                                                                                                                                            if (str22 != "null")
                                                                                                                                                            {
                                                                                                                                                                this.method_27("all");
                                                                                                                                                                this.CommandConsole("map " + str22, 500);
                                                                                                                                                            }
                                                                                                                                                        }
                                                                                                                                                    }
                                                                                                                                                    else if (strArray.Length != 1)
                                                                                                                                                    {
                                                                                                                                                        Class67.smethod_101(this, "^7Server Password Successfully Changed!");
                                                                                                                                                        PasswordAccess = strArray[1];
                                                                                                                                                        this.Reconfig_Config();
                                                                                                                                                        Class67.smethod_101(this, "^7Restart Map In 2 Second...");
                                                                                                                                                        this.CommandConsole("map_restart", 0x7d0);
                                                                                                                                                    }
                                                                                                                                                }
                                                                                                                                                else if (strArray.Length == 2)
                                                                                                                                                {
                                                                                                                                                    Entity entity36 = this.method_22(class2.entity_0, strArray[1]);
                                                                                                                                                    if (entity36 != null)
                                                                                                                                                    {
                                                                                                                                                        entity36.SetField("Mute", 0);
                                                                                                                                                        Class67.smethod_125(this, class2.entity_0, "^5" + this.getPlayerName(entity36) + " ^7UnMuted!");
                                                                                                                                                    }
                                                                                                                                                }
                                                                                                                                            }
                                                                                                                                            else if (strArray.Length == 2)
                                                                                                                                            {
                                                                                                                                                Entity entity35 = this.method_22(class2.entity_0, strArray[1]);
                                                                                                                                                if (entity35 != null)
                                                                                                                                                {
                                                                                                                                                    entity35.SetField("Mute", 1);
                                                                                                                                                    Class67.smethod_125(this, class2.entity_0, "^5" + this.getPlayerName(entity35) + " ^7Mute!");
                                                                                                                                                }
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                        else if (strArray.Length == 1)
                                                                                                                                        {
                                                                                                                                            Class67.smethod_43(this, class2.entity_0);
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                    else if (strArray.Length == 1)
                                                                                                                                    {
                                                                                                                                        Class67.smethod_121(this, class2.entity_0);
                                                                                                                                    }
                                                                                                                                }
                                                                                                                                else if (strArray.Length == 1)
                                                                                                                                {
                                                                                                                                    this.Warning(class2.entity_0, null, "all", null);
                                                                                                                                }
                                                                                                                            }
                                                                                                                            else if (strArray.Length == 2)
                                                                                                                            {
                                                                                                                                Entity entity34 = this.method_22(class2.entity_0, strArray[1]);
                                                                                                                                if (entity34 != null)
                                                                                                                                {
                                                                                                                                    Class67.smethod_29(entity34, class2.entity_0, this);
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                        else if (strArray.Length != 1)
                                                                                                                        {
                                                                                                                            if (TypeMap.Contains("inf"))
                                                                                                                            {
                                                                                                                                Class67.smethod_125(this, class2.entity_0, "^7You Can Not Change Team In Infect Mod");
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                Entity entity32 = this.method_22(class2.entity_0, strArray[1]);
                                                                                                                                if (entity32 != null)
                                                                                                                                {
                                                                                                                                    if (entity32.GetField<string>("sessionteam") != "allies")
                                                                                                                                    {
                                                                                                                                        entity32.SetField("team", "allies");
                                                                                                                                        entity32.SetField("sessionteam", "allies");
                                                                                                                                        entity32.Notify("menuresponse", new Parameter[] { new Parameter("team_marinesopfor"), new Parameter("allies") });
                                                                                                                                    }
                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                        entity32.SetField("team", "axis");
                                                                                                                                        entity32.SetField("sessionteam", "axis");
                                                                                                                                        entity32.Notify("menuresponse", new Parameter[] { new Parameter("team_marinesopfor"), new Parameter("axis") });
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                    else if (strArray.Length != 1)
                                                                                                                    {
                                                                                                                        Entity entity31 = this.method_22(class2.entity_0, strArray[1]);
                                                                                                                        if ((entity31 != null) && entity31.IsAlive)
                                                                                                                        {
                                                                                                                            if (this.getPlayerLevel(entity31) <= this.getPlayerLevel(class2.entity_0))
                                                                                                                            {
                                                                                                                                if (strArray.Length == 2)
                                                                                                                                {
                                                                                                                                    Class67.smethod_147(this, "normal", class2.entity_0, entity31);
                                                                                                                                }
                                                                                                                                else
                                                                                                                                {
                                                                                                                                    Class67.smethod_147(this, strArray[2], class2.entity_0, entity31);
                                                                                                                                }
                                                                                                                                Class67.smethod_125(this, class2.entity_0, "^5" + this.getPlayerName(entity31) + " ^7Killed!");
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                Class67.smethod_125(this, class2.entity_0, "^7Error ^5- ^7You Can Not Kill a Player With Your Same Level!");
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                                else if (strArray.Length != 1)
                                                                                                                {
                                                                                                                    string str12 = "";
                                                                                                                    for (int num9 = 1; num9 < strArray2.Length; num9++)
                                                                                                                    {
                                                                                                                        str12 = str12 + " " + strArray2[num9];
                                                                                                                    }
                                                                                                                    Entity entity27 = class2.entity_0;
                                                                                                                    Class67.smethod_66(str12.Trim(), entity27, this);
                                                                                                                }
                                                                                                            }
                                                                                                            else if (strArray.Length != 1)
                                                                                                            {
                                                                                                                string str10 = "";
                                                                                                                for (int num8 = 1; num8 < strArray2.Length; num8++)
                                                                                                                {
                                                                                                                    str10 = str10 + " " + strArray2[num8];
                                                                                                                }
                                                                                                                Entity entity26 = class2.entity_0;
                                                                                                                Class67.smethod_31(str10.Trim(), this, entity26);
                                                                                                            }
                                                                                                        }
                                                                                                        else if (strArray.Length == 2)
                                                                                                        {
                                                                                                            entity25 = class2.entity_0;
                                                                                                            str8 = strArray[1];
                                                                                                            str9 = "del";
                                                                                                            Class67.smethod_85(str9, str8, entity25, this);
                                                                                                        }
                                                                                                    }
                                                                                                    else if (strArray.Length == 2)
                                                                                                    {
                                                                                                        entity25 = class2.entity_0;
                                                                                                        str8 = strArray[1];
                                                                                                        str9 = "add";
                                                                                                        Class67.smethod_85(str9, str8, entity25, this);
                                                                                                    }
                                                                                                }
                                                                                                else if ((strArray.Length != 1) && Class67.smethod_91(strArray[1]))
                                                                                                {
                                                                                                    int_1 = int.Parse(strArray[1]);
                                                                                                    base.Call("iprintln", new Parameter[] { string.Concat(new object[] { "^5", this.getPlayerName(class2.entity_0), " ^7Gravity: ^5", Gravity, " ^7-------> ^5", int_1 }) });
                                                                                                    Gravity = int_1;
                                                                                                }
                                                                                            }
                                                                                            else if ((strArray.Length != 1) && Class67.smethod_91(strArray[1]))
                                                                                            {
                                                                                                int_0 = int.Parse(strArray[1]);
                                                                                                base.Call("iprintln", new Parameter[] { string.Concat(new object[] { "^5", this.getPlayerName(class2.entity_0), " ^7Speed: ^5", Speed, " ^7-------> ^5", int_0 }) });
                                                                                                Speed = int_0;
                                                                                            }
                                                                                        }
                                                                                        else if ((strArray.Length != 1) && Class67.smethod_91(strArray[1]))
                                                                                        {
                                                                                            salto = int.Parse(strArray[1]);
                                                                                            base.Call("iprintln", new Parameter[] { string.Concat(new object[] { "^5", this.getPlayerName(class2.entity_0), " ^7Jump: ^5", JumpHeight, " ^7-------> ^5", salto }) });
                                                                                            JumpHeight = salto;
                                                                                        }
                                                                                    }
                                                                                    else if (strArray.Length != 1)
                                                                                    {
                                                                                        Entity entity24 = this.method_22(class2.entity_0, strArray[1]);
                                                                                        if (entity24 != null)
                                                                                        {
                                                                                            this.setPlayerLevel(entity24, 1);
                                                                                            class2.entity_0.Call("iprintlnbold", new Parameter[] { "^7Degraded ^5" + this.getPlayerName(entity24) });
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else if (strArray.Length > 2)
                                                                                {
                                                                                    foreach (Entity entity23 in Giocatori)
                                                                                    {
                                                                                        entity23.Call("setclientdvar", new Parameter[] { new Parameter(strArray[1]), new Parameter(strArray[2]) });
                                                                                    }
                                                                                    class2.entity_0.Call("iprintlnbold", new Parameter[] { "^5" + this.getPlayerName(class2.entity_0) + " ^7Set Parameters!" });
                                                                                }
                                                                            }
                                                                            else if (Piattaforma.StartsWith("te"))
                                                                            {
                                                                                Class67.smethod_125(this, class2.entity_0, "^7Bots Not Compatible With TeknoMW3");
                                                                            }
                                                                            else if (strArray.Length != 2)
                                                                            {
                                                                                Class67.smethod_160(this, class2.entity_0, 1, 0);
                                                                            }
                                                                            else
                                                                            {
                                                                                byte result = 0;
                                                                                if ((byte.TryParse(strArray[1], out result) && (result > 0)) && (result < 0x10))
                                                                                {
                                                                                    Class67.smethod_160(this, class2.entity_0, result, 0);
                                                                                }
                                                                                else if (strArray[1].StartsWith("f"))
                                                                                {
                                                                                    Class67.smethod_160(this, class2.entity_0, 1, 1);
                                                                                }
                                                                                else if (strArray[1].StartsWith("e"))
                                                                                {
                                                                                    Class67.smethod_160(this, class2.entity_0, 1, 2);
                                                                                }
                                                                            }
                                                                        }
                                                                        else if (strArray.Length != 1)
                                                                        {
                                                                            Entity entity22 = this.method_22(class2.entity_0, strArray[1]);
                                                                            if (entity22 != null)
                                                                            {
                                                                                if (this.getPlayerLevel(entity22) < this.getPlayerLevel(class2.entity_0))
                                                                                {
                                                                                    this.InfoPlayer(class2.entity_0, entity22);
                                                                                }
                                                                                else
                                                                                {
                                                                                    Class67.smethod_125(this, class2.entity_0, "^7Error ^5- ^7Player Is Same Level Or Higher!");
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    else if ((strArray.Length != 3) || !Class67.smethod_91(strArray[2]))
                                                                    {
                                                                        if ((strArray.Length == 2) && Class67.smethod_91(strArray[1]))
                                                                        {
                                                                            this.FilmTweak(class2.entity_0, int.Parse(strArray[1]));
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        Entity entity21 = this.method_22(class2.entity_0, strArray[1]);
                                                                        if (entity21 != null)
                                                                        {
                                                                            this.FilmTweak(entity21, int.Parse(strArray[2]));
                                                                            class2.entity_0.Call("iprintlnbold", new Parameter[] { "^7FilmTweak Set a ^5" + entity21.Name });
                                                                        }
                                                                    }
                                                                }
                                                                else if (TypeMap.Contains("inf"))
                                                                {
                                                                    Class67.smethod_125(this, class2.entity_0, "^7You Can Not Set AFK In Infect Mod");
                                                                }
                                                                else if (strArray.Length != 1)
                                                                {
                                                                    Entity entity20 = this.method_22(class2.entity_0, strArray[1]);
                                                                    if (entity20 != null)
                                                                    {
                                                                        entity20.SetField("team", "spectator");
                                                                        entity20.SetField("sessionteam", "spectator");
                                                                        entity20.Notify("menuresponse", new Parameter[] { "team_marinesopfor", "spectator" });
                                                                        Class67.smethod_125(this, class2.entity_0, "^5" + entity20.Name + " ^7Set AFK");
                                                                    }
                                                                }
                                                            }
                                                            else if (strArray.Length != 1)
                                                            {
                                                                string str7 = "";
                                                                for (int num6 = 1; num6 < strArray2.Length; num6++)
                                                                {
                                                                    str7 = str7 + " " + strArray2[num6];
                                                                }
                                                                base.Call("setdvar", new Parameter[] { "sv_hostname", str7.Trim() });
                                                                Class67.smethod_125(this, class2.entity_0, "^7Server Name Set To: ^5" + str7.Trim());
                                                            }
                                                        }
                                                        else if (strArray.Length != 1)
                                                        {
                                                            Entity entity19 = this.method_22(class2.entity_0, strArray[1]);
                                                            if ((entity19 != null) && entity19.IsAlive)
                                                            {
                                                                Class67.smethod_82(class2.entity_0, entity19, this);
                                                            }
                                                        }
                                                    }
                                                }
                                                else if ((strArray.Length == 2) && Class67.smethod_91(strArray[1]))
                                                {
                                                    int num5 = int.Parse(strArray[1]);
                                                    if ((num5 > 0) && (num5 < 4))
                                                    {
                                                        class2.entity_0.SetClientDvar("r_colorMap", strArray[1]);
                                                        Class67.smethod_125(this, class2.entity_0, "^7FPS Set To: ^5" + strArray[1]);
                                                    }
                                                    else
                                                    {
                                                        Class67.smethod_125(this, class2.entity_0, "^7FPS Set To Number 1-3");
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Entity entity13 = this.method_22(class2.entity_0, strArray[1]);
                                            if (((entity13 != null) && entity13.IsAlive) && (entity13.GetField<string>("sessionstate") != "spectator"))
                                            {
                                                if (this.getPlayerLevel(entity13) < this.getPlayerLevel(class2.entity_0))
                                                {
                                                    Class67.smethod_104(entity13, class2.entity_0);
                                                }
                                                else
                                                {
                                                    Class67.smethod_125(this, class2.entity_0, "^7Error ^5- ^7Player Is Same Level Or Higher!");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (strArray.Length != 1)
                    {
                        this.method_2(class2.entity_0, strArray[1]);
                    }
                }
            }
        }

        public void FilmTweak(Entity player, int num)
        {
            if (SetFilmTweak && !(string_0 == "hide"))
            {
                switch (num)
                {
                    case 0:
                        player.SetClientDvar("r_filmusetweaks", "0");
                        player.SetClientDvar("r_filmtweakenable", "0");
                        player.SetClientDvar("r_colorMap", "1");
                        player.SetClientDvar("r_specularMap", "1");
                        player.SetClientDvar("r_normalMap", "1");
                        player.SetClientDvar("r_fog", "0");
                        player.SetClientDvar("cg_drawFPS", "Simple");
                        player.SetClientDvar("waypointIconHeight", "1");
                        player.SetClientDvar("waypointIconWidth", "1");
                        player.SetClientDvar("cg_fovScale", "1");
                        player.SetClientDvar("r_debugShader", "0");
                        player.SetClientDvar("fx_drawclouds", "1");
                        player.SetClientDvar("r_distortion", "1");
                        player.SetClientDvar("r_dlightlimit", "4");
                        player.SetClientDvar("cg_brass", "1");
                        player.SetClientDvar("snaps", "30");
                        player.SetClientDvar("com_maxfps", "100");
                        player.SetClientDvar("clientsideeffects", "1");
                        Class67.smethod_125(this, player, "^7FilmTweak Set^5 " + num);
                        return;

                    case 1:
                        player.SetClientDvar("r_filmtweakdarktint", "0.65 0.7 0.8");
                        player.SetClientDvar("r_filmtweakcontrast", "1.3");
                        player.SetClientDvar("r_filmtweakbrightness", "0.15");
                        player.SetClientDvar("r_filmtweakdesaturation", "0");
                        player.SetClientDvar("waypointIconHeight", "1");
                        player.SetClientDvar("waypointIconWidth", "1");
                        player.SetClientDvar("r_filmusetweaks", "1");
                        player.SetClientDvar("r_filmtweaklighttint", "1.8 1.8 1.8");
                        player.SetClientDvar("r_filmtweakenable", "1");
                        Class67.smethod_125(this, player, "^7FilmTweak Set^5 " + num);
                        return;

                    case 2:
                        player.SetClientDvar("r_filmtweakdarktint", "1.15 1.1 1.3");
                        player.SetClientDvar("r_filmtweakcontrast", "1.6");
                        player.SetClientDvar("r_filmtweakbrightness", "0.2");
                        player.SetClientDvar("r_filmtweakdesaturation", "0");
                        player.SetClientDvar("r_filmusetweaks", "1");
                        player.SetClientDvar("r_filmtweaklighttint", "1.35 1.3 1.25");
                        player.SetClientDvar("r_filmtweakenable", "1");
                        Class67.smethod_125(this, player, "^7FilmTweak Set^5 " + num);
                        return;

                    case 3:
                        player.SetClientDvar("r_filmtweakdarktint", "0.8 0.8 1.1");
                        player.SetClientDvar("r_filmtweakcontrast", "1.3");
                        player.SetClientDvar("r_filmtweakbrightness", "0.48");
                        player.SetClientDvar("r_filmtweakdesaturation", "0");
                        player.SetClientDvar("r_filmusetweaks", "1");
                        player.SetClientDvar("r_filmtweaklighttint", "1 1 1.4");
                        player.SetClientDvar("r_filmtweakenable", "1");
                        Class67.smethod_125(this, player, "^7FilmTweak Set^5 " + num);
                        return;

                    case 4:
                        player.SetClientDvar("r_filmtweakdarktint", "1.8 1.8 2");
                        player.SetClientDvar("r_filmtweakcontrast", "1.25");
                        player.SetClientDvar("r_filmtweakbrightness", "0.02");
                        player.SetClientDvar("r_filmtweakdesaturation", "0");
                        player.SetClientDvar("r_filmusetweaks", "1");
                        player.SetClientDvar("r_filmtweaklighttint", "0.8 0.8 1");
                        player.SetClientDvar("r_filmtweakenable", "1");
                        Class67.smethod_125(this, player, "^7FilmTweak Set^5 " + num);
                        return;

                    case 5:
                        player.SetClientDvar("r_filmtweakdarktint", "1 1 2");
                        player.SetClientDvar("r_filmtweakcontrast", "1.5");
                        player.SetClientDvar("r_filmtweakbrightness", "0.07");
                        player.SetClientDvar("r_filmtweakdesaturation", "0");
                        player.SetClientDvar("r_filmusetweaks", "1");
                        player.SetClientDvar("r_filmtweaklighttint", "1 1.2 1");
                        player.SetClientDvar("r_filmtweakenable", "1");
                        Class67.smethod_125(this, player, "^7FilmTweak Set^5 " + num);
                        return;

                    case 6:
                        player.SetClientDvar("r_filmtweakdarktint", "1.5 1.5 2");
                        player.SetClientDvar("r_filmtweakcontrast", "1");
                        player.SetClientDvar("r_filmtweakbrightness", "0.0.4");
                        player.SetClientDvar("r_filmtweakdesaturation", "0");
                        player.SetClientDvar("r_filmusetweaks", "1");
                        player.SetClientDvar("r_filmtweaklighttint", "1.5 1.5 1");
                        player.SetClientDvar("r_filmtweakenable", "1");
                        Class67.smethod_125(this, player, "^7FilmTweak Set^5 " + num);
                        return;

                    case 7:
                        player.SetClientDvar("r_specularMap", "4");
                        player.SetClientDvar("r_normalMap", "0");
                        Class67.smethod_125(this, player, "^7FilmTweak Set^5 " + num);
                        return;

                    case 8:
                        player.SetClientDvar("cg_drawFPS", "1");
                        player.SetClientDvar("cg_fovScale", "1.5");
                        Class67.smethod_125(this, player, "^7FilmTweak Set^5 " + num);
                        return;

                    case 9:
                        player.SetClientDvar("r_colorMap", "3");
                        Class67.smethod_125(this, player, "^7FilmTweak Set^5 " + num);
                        return;

                    case 10:
                        player.SetClientDvar("r_filmtweakdarktint", "0.7 0.85 1");
                        player.SetClientDvar("r_filmtweakcontrast", "1.4");
                        player.SetClientDvar("r_filmtweakdesaturation", "0.2");
                        player.SetClientDvar("r_filmusetweaks", "0");
                        player.SetClientDvar("r_filmtweaklighttint", "1.1 1.05 0.85");
                        player.SetClientDvar("cg_fov", "90");
                        player.SetClientDvar("cg_scoreboardpingtext", "1");
                        player.SetClientDvar("waypointIconHeight", "1");
                        player.SetClientDvar("waypointIconWidth", "1");
                        player.SetClientDvar("cl_maxpackets", "100");
                        player.SetClientDvar("r_fog", "0");
                        player.SetClientDvar("fx_drawclouds", "0");
                        player.SetClientDvar("r_distortion", "0");
                        player.SetClientDvar("r_dlightlimit", "0");
                        player.SetClientDvar("cg_brass", "0");
                        player.SetClientDvar("com_maxfps", "100");
                        player.SetClientDvar("clientsideeffects", "0");
                        player.SetClientDvar("r_filmTweakBrightness", "0.2");
                        Class67.smethod_125(this, player, "^7FilmTweak Set^5 " + num);
                        return;

                    case 11:
                        player.SetClientDvar("cg_fov", "80");
                        player.SetClientDvar("cl_maxpackets", "100");
                        player.SetClientDvar("r_fog", "0");
                        player.SetClientDvar("fx_drawclouds", "0");
                        player.SetClientDvar("r_distortion", "0");
                        player.SetClientDvar("r_dlightlimit", "0");
                        player.SetClientDvar("cg_brass", "0");
                        player.SetClientDvar("snaps", "30");
                        player.SetClientDvar("com_maxfps", "100");
                        player.SetClientDvar("cg_scoreboardpingtext", "1");
                        player.SetClientDvar("waypointIconWidth", "1");
                        player.SetClientDvar("waypointIconHeight", "1");
                        player.SetClientDvar("clientsideeffects", "0");
                        player.SetClientDvar("r_normalMap", "Flat");
                        Class67.smethod_125(this, player, "^7FilmTweak Set^5 " + num);
                        return;

                    case 12:
                        player.SetClientDvar("cg_fov", "80");
                        player.SetClientDvar("cl_maxpackets", "100");
                        player.SetClientDvar("r_fog", "0");
                        player.SetClientDvar("fx_drawclouds", "0");
                        player.SetClientDvar("r_distortion", "0");
                        player.SetClientDvar("r_dlightlimit", "0");
                        player.SetClientDvar("cg_brass", "0");
                        player.SetClientDvar("snaps", "30");
                        player.SetClientDvar("com_maxfps", "100");
                        player.SetClientDvar("cg_scoreboardpingtext", "1");
                        player.SetClientDvar("waypointIconWidth", "1");
                        player.SetClientDvar("waypointIconHeight", "1");
                        player.SetClientDvar("clientsideeffects", "0");
                        player.SetClientDvar("r_normalMap", "Flat");
                        player.SetClientDvar("r_filmtweakdarktint", "1.15 1.1 1.3");
                        player.SetClientDvar("r_filmtweakcontrast", "1.6");
                        player.SetClientDvar("r_filmtweakbrightness", "0.2");
                        player.SetClientDvar("r_filmtweakdesaturation", "0");
                        player.SetClientDvar("r_filmusetweaks", "1");
                        player.SetClientDvar("r_filmtweaklighttint", "1.35 1.3 1.25");
                        player.SetClientDvar("r_filmtweakenable", "1");
                        Class67.smethod_125(this, player, "^7FilmTweak Set^5 " + num);
                        return;

                    case 13:
                        player.SetClientDvar("cg_fov", "80");
                        player.SetClientDvar("cl_maxpackets", "100");
                        player.SetClientDvar("r_fog", "0");
                        player.SetClientDvar("fx_drawclouds", "0");
                        player.SetClientDvar("r_distortion", "0");
                        player.SetClientDvar("r_dlightlimit", "0");
                        player.SetClientDvar("cg_brass", "0");
                        player.SetClientDvar("snaps", "30");
                        player.SetClientDvar("com_maxfps", "100");
                        player.SetClientDvar("cg_scoreboardpingtext", "1");
                        player.SetClientDvar("waypointIconWidth", "1");
                        player.SetClientDvar("waypointIconHeight", "1");
                        player.SetClientDvar("clientsideeffects", "0");
                        player.SetClientDvar("r_normalMap", "Flat");
                        player.SetClientDvar("r_filmtweakdarktint", "1.8 1.8 2");
                        player.SetClientDvar("r_filmtweakcontrast", "1.25");
                        player.SetClientDvar("r_filmtweakbrightness", "0.02");
                        player.SetClientDvar("r_filmtweakdesaturation", "0");
                        player.SetClientDvar("r_filmusetweaks", "1");
                        player.SetClientDvar("r_filmtweaklighttint", "0.8 0.8 1");
                        player.SetClientDvar("r_filmtweakenable", "1");
                        Class67.smethod_125(this, player, "^7FilmTweak Set^5 " + num);
                        return;
                }
                Class67.smethod_125(this, player, "^7FilmTweak Not Correct, Use ^50 ^7- ^513");
            }
            else
            {
                Class67.smethod_125(this, player, "^7FilmTweak Disabled!!!");
            }
        }

        public static string GetHashPlayer(Entity player)
        {
            int num = player.Call<int>("getentitynumber", new Parameter[0]);
            if (num > 0x11)
            {
                return null;
            }
            int address = dictionary_0[num];
            byte[] bytes = new byte[0x24];
            bytes = Mem.ReadBytes(address, 0x24);
            return sha512(sha512(Encoding.ASCII.GetString(bytes, 0, 0x24)));
        }

        public static string GetHWIDPlayer(Entity player)
        {
            try
            {
                int num = player.Call<int>("getentitynumber", new Parameter[0]);
                if (num > 0x11)
                {
                    return null;
                }
                int address = dictionary_0[num];
                byte[] buffer = new byte[12];
                buffer = Mem.ReadBytes(address, 12);
                string str = "";
                for (int i = 0; i < 12; i++)
                {
                    str = str + buffer[i].ToString("X2");
                }
                return str;
            }
            catch (Exception)
            {
                return "000000000000000000000000";
            }
        }

        public IPAddress GetIPAddress(int ClientNum)
        {
            byte[] destination = new byte[4];
            Marshal.Copy((IntPtr)((0x49eb690 + (ClientNum * 0x78688)) + 0x2c), destination, 0, 4);
            return new IPAddress(destination);
        }

        public int getPlayerAccess(Entity player)
        {
            if (player.HasField("AccAServer"))
            {
                return player.GetField<int>("AccAServer");
            }
            return 0;
        }

        public string getPlayerGuid(Entity player)
        {
            try
            {
                return player.GUID.ToString();
            }
            catch (Exception)
            {
                return "-/-/-";
            }
        }

        public string getPlayerHash(Entity player)
        {
            if (!player.HasField("HASHPL"))
            {
                player.SetField("HASHPL", GetHashPlayer(player));
            }
            return player.GetField<string>("HASHPL");
        }

        public string getPlayerHWID(Entity player)
        {
            if (!player.HasField("HWIDPL"))
            {
                player.SetField("HWIDPL", GetHWIDPlayer(player));
            }
            return player.GetField<string>("HWIDPL");
        }

        public string getPlayerID(Entity player)
        {
            try
            {
                return player.UserID.ToString();
            }
            catch (Exception)
            {
                return "-/-/-";
            }
        }

        public string getPlayerIP(Entity player)
        {
            return player.IP.ToString().Split(new char[] { ':' })[0];
        }

        public int getPlayerLevel(Entity player)
        {
            if (player.HasField("LVAServer"))
            {
                return player.GetField<int>("LVAServer");
            }
            return 1;
        }

        public string getPlayerName(Entity player)
        {
            if (player.HasField("name"))
            {
                return player.GetField<string>("name");
            }
            return "null";
        }

        public string getPlayerName_Guid(string gd)
        {
            foreach (Entity entity in Giocatori)
            {
                if (entity.GUID.ToString().Contains(gd))
                {
                    return entity.Name;
                }
            }
            return "null";
        }

        public int getPlayerPause(Entity player)
        {
            if (player.HasField("VarPause"))
            {
                return player.GetField<int>("VarPause");
            }
            return 0;
        }

        public string getPlayerSlot(Entity player)
        {
            try
            {
                return player.Call<int>("getentitynumber", new Parameter[0]).ToString();
            }
            catch (Exception)
            {
                return "-/-/-";
            }
        }

        public string getPlayerVote(Entity player)
        {
            if (player.HasField("ULTVote"))
            {
                return player.GetField<string>("ULTVote");
            }
            return null;
        }

        public string getPlayerXuid(Entity player)
        {
            try
            {
                return player.Call<string>("getxuid", new Parameter[0]);
            }
            catch (Exception)
            {
                return "-/-/-";
            }
        }

        public static string GetTAGPlayer(Entity player)
        {
            try
            {
                int num = player.Call<int>("getentitynumber", new Parameter[0]);
                if (num > 0x11)
                {
                    return null;
                }
                int address = dictionary_0[num];
                byte[] bytes = new byte[6];
                bytes = Mem.ReadBytes(address, 6);
                return Encoding.UTF8.GetString(bytes, 0, 6);
            }
            catch (Exception)
            {
                return "null";
            }
        }

        public void InConnessione_Player(Entity player)
        {
        }

        public void InfoPlayer(Entity Adm, Entity player)
        {
            Class5 class2 = new Class5
            {
                entity_0 = player,
                serverControll_0 = this
            };
            Adm.AfterDelay(10, new Action<Entity>(class2.method_0));
            Adm.AfterDelay(0x5dc, new Action<Entity>(class2.method_1));
            Adm.AfterDelay(0xbb8, new Action<Entity>(class2.method_2));
            Adm.AfterDelay(0x1194, new Action<Entity>(class2.method_3));
            Adm.AfterDelay(0x1770, new Action<Entity>(class2.method_4));
            Adm.AfterDelay(0x1d4c, new Action<Entity>(class2.method_5));
            Adm.AfterDelay(0x2328, new Action<Entity>(class2.method_6));
            /*if (ScanGPS && downGPS)
            {
                Adm.AfterDelay(0x2904, new Action<Entity>(class2.method_7));
            }*/
        }

        public bool IsJoinUsers(Entity player)
        {
            bool flag = false;
            foreach (Entity entity in JoinUsers)
            {
                if (this.getPlayerGuid(player) == this.getPlayerGuid(entity))
                {
                    flag = true;
                }
            }
            return flag;
        }

        public bool IsUserSession(Entity player)
        {
            bool flag = false;
            foreach (string str in UserSession)
            {
                if (this.getPlayerName(player).Equals(str))
                {
                    flag = true;
                }
            }
            return flag;
        }

        public void kikUser(string Admin, string Mod, Entity player, string motivo)
        {
            try
            {
                Class67.smethod_33(this, DateTime.Now.ToShortTimeString() + " " + Admin + ": Expelled " + this.getPlayerName(player) + " REASON: " + motivo, new object[0]);
                if (Mod == "k")
                {
                    Class67.smethod_101(this, KickMess.Replace("<playername>", player.Name).Replace("<reason>", motivo).Replace("<kicker>", Admin));
                }
                else if (Mod == "b")
                {
                    Class67.smethod_101(this, BanMess.Replace("<playername>", player.Name).Replace("<reason>", motivo).Replace("<kicker>", Admin));
                }
                else if (Mod == "tb")
                {
                    Class67.smethod_101(this, TeampbanMess.Replace("<playername>", player.Name).Replace("<reason>", motivo).Replace("<kicker>", Admin));
                }
                if (AllGiocatori.Contains(player))
                {
                    this.CommandConsole(string.Concat(new object[] { "dropclient ", player.Call<int>("getentitynumber", new Parameter[0]), " \"", motivo, "\"" }), 0);
                }
            }
            catch (Exception exception)
            {
                Class67.smethod_57(exception, this, "KikUser");
            }
        }

        public void LoadUserSession()
        {
            if (System.IO.File.Exists(DirTempFile + FileSessione))
            {
                string[] strArray = System.IO.File.ReadAllLines(DirTempFile + FileSessione);
                for (int i = 0; i < strArray.Length; i++)
                {
                    UserSession.Add(strArray[i]);
                }
            }
        }

        /*public string lookupIP(string ip)
        {
            try
            {
                string str = "";
                if (ip.StartsWith("192.168"))
                {
                    return "LocalIP";
                }
                Location location = new LookupService(FileGPS, LookupService.GEOIP_STANDARD).getLocation(ip);
                if (location != null)
                {
                    if (location.city.Trim() != "")
                    {
                        str = "^7" + location.city + "^5/^7" + location.countryName;
                    }
                    else
                    {
                        str = "^7" + location.countryName;
                    }
                }
                else
                {
                    str = "^7<unknown>";
                }
                return str;
            }
            catch (Exception)
            {
                return "^7<unknown>";
            }
        }*/

        public void MenuInit(Entity player)
        {
            Class61 class2 = new Class61
            {
                entity_1 = player,
                serverControll_0 = this
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

        public string messpass(Entity player)
        {
            return ("^7You Have ^5" + player.GetField<int>("TimePass") + " ^7Seconds To Enter The Password!");
        }

        private void method_0(string string_1, int int_3)
        {
            if (System.IO.File.Exists(DirTempFile + FileLastExit))
            {
                string[] strArray = System.IO.File.ReadAllLines(DirTempFile + FileLastExit);
                bool flag = false;
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { sep1 });
                    for (int j = 0; j < 2; j++)
                    {
                        if (strArray2[j].ToLower().Contains(string_1))
                        {
                            goto Label_0079;
                        }
                    }
                    goto Label_0139;
                Label_0079:
                    flag = true;
                    using (StreamWriter writer = new StreamWriter(DirConfMove + FileTempBan, true))
                    {
                        writer.WriteLine(string.Concat(new object[] { DateTime.Now, sep2.ToString(), int_3, sep1, strArray[i] }));
                        writer.Close();
                        Class67.smethod_101(this, string.Concat(new object[] { "^7Player ^5", strArray2[0], " ^7TempBanned For ^5", int_3, "Min!" }));
                    }
                Label_0139:
                    if (flag)
                    {
                        return;
                    }
                }
            }
        }

        private void method_1(Entity entity_0, string string_1, int int_3)
        {
            if (System.IO.File.Exists(DirTempFile + FileLastExit))
            {
                string[] strArray = System.IO.File.ReadAllLines(DirTempFile + FileLastExit);
                bool flag = false;
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { sep1 });
                    for (int j = 0; j < 2; j++)
                    {
                        if (strArray2[j].ToLower().Contains(string_1))
                        {
                            if (this.getPlayerLevel(entity_0) > Class67.smethod_39(strArray2[2], this))
                            {
                                goto Label_0097;
                            }
                            Class67.smethod_125(this, entity_0, "^7Error ^5- ^7You Can Not TempBan a Player With Your Same Level!");
                        }
                    }
                    goto Label_0155;
                Label_0097:
                    flag = true;
                    using (StreamWriter writer = new StreamWriter(DirConfMove + FileTempBan, true))
                    {
                        writer.WriteLine(string.Concat(new object[] { DateTime.Now, sep2.ToString(), int_3, sep1, strArray[i] }));
                        writer.Close();
                    }
                    Class67.smethod_125(this, entity_0, "^5Player ^7" + strArray2[0] + "^5[^7" + strArray2[1] + "^5] ^7Successfully TempBanned!");
                Label_0155:
                    if (flag)
                    {
                        break;
                    }
                }
                if (!flag)
                {
                    Class67.smethod_125(this, entity_0, "^7No Player Found");
                }
            }
        }

        private void method_10(Entity entity_0, string string_1)
        {
            foreach (Entity entity in Giocatori)
            {
                if (this.getPlayerLevel(entity) > 3)
                {
                    if (entity_0 != null)
                    {
                        Utilities.RawSayTo(entity, "^7" + this.getPlayerName(entity_0) + "^5[^7PM^5]:^7 " + string_1);
                    }
                    else
                    {
                        Utilities.RawSayTo(entity, "^7" + BotName + "^: For Admin^5[^7PM^5]:^7 " + string_1);
                    }
                }
            }
        }

        private void method_11(Entity entity_0, string string_1)
        {
            foreach (Entity entity in Giocatori)
            {
                if (this.getPlayerLevel(entity) > 1)
                {
                    if (entity_0 != null)
                    {
                        Utilities.RawSayTo(entity, "^7" + this.getPlayerName(entity_0) + "^5[^7PM^5]:^7 " + string_1);
                    }
                    else
                    {
                        Utilities.RawSayTo(entity, "^7" + BotName + "^: For Mem^5[^7PM^5]:^7 " + string_1);
                    }
                }
            }
        }

        private void method_12(Entity entity_0, Entity entity_1)
        {
            if (System.IO.File.Exists(DirConfMove + FileAlias))
            {
                string str;
                if (Piattaforma.StartsWith("te"))
                {
                    str = this.getPlayerHWID(entity_1);
                }
                else
                {
                    str = this.getPlayerIP(entity_1);
                }
                string[] strArray = System.IO.File.ReadAllLines(DirConfMove + FileAlias);
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (!strArray[i].StartsWith(str))
                    {
                        continue;
                    }
                    string[] strArray2 = strArray[i].Split(new char[] { sep1 });
                    bool flag = false;
                    for (int j = 1; j < strArray2.Length; j++)
                    {
                        if (strArray2[j] != this.getPlayerName(entity_1))
                        {
                            goto Label_00AB;
                        }
                    }
                    goto Label_00F3;
                Label_00AB:
                    flag = true;
                    Class67.smethod_125(this, entity_0, "^7Player: ^5" + this.getPlayerName(entity_1) + " ^7Also Known As:");
                    Class67.smethod_125(this, entity_0, "^5" + strArray[i].Replace(sep1.ToString(), "^5<>^7"));
                Label_00F3:
                    if (!flag)
                    {
                        Class67.smethod_125(this, entity_0, "^7Player ^5" + this.getPlayerName(entity_1) + " ^7Not Use Alias");
                    }
                }
            }
        }

        private void method_13(Entity entity_0)
        {
            string str;
            if (Piattaforma.StartsWith("te"))
            {
                str = this.getPlayerHWID(entity_0);
            }
            else
            {
                str = this.getPlayerIP(entity_0);
            }
            if (System.IO.File.Exists(DirConfMove + FileAlias))
            {
                string[] strArray = System.IO.File.ReadAllLines(DirConfMove + FileAlias);
                System.IO.File.Delete(DirConfMove + FileAlias);
                bool flag = false;
                using (StreamWriter writer = new StreamWriter(DirConfMove + FileAlias, true))
                {
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        string str2 = strArray[i];
                        if (str2.StartsWith(str))
                        {
                            flag = true;
                            bool flag2 = false;
                            bool flag3 = false;
                            string[] strArray2 = str2.Split(new char[] { sep1 });
                            for (int j = 1; j < strArray2.Length; j++)
                            {
                                if (strArray2[j] == this.getPlayerName(entity_0))
                                {
                                    flag2 = true;
                                }
                                else
                                {
                                    flag3 = true;
                                }
                            }
                            if (flag3)
                            {
                                if (!flag2)
                                {
                                    str2 = strArray[i] + sep1 + this.getPlayerName(entity_0);
                                }
                                string str3 = "";
                                for (int k = 1; k < strArray2.Length; k++)
                                {
                                    str3 = str3 + ",^5" + strArray2[k] + "^7";
                                }
                                if (!this.IsUserSession(entity_0))
                                {
                                    Class67.smethod_33(this, "^5[^7" + this.getPlayerName(entity_0) + "^5] ^7Detected Alias ^5(^7" + str3.TrimStart(new char[] { sep1 }) + "^5)^7", new object[0]);
                                    this.method_11(null, "^5[^7" + this.getPlayerName(entity_0) + "^5] ^7Detected Alias ^5(^7" + str3.TrimStart(new char[] { sep1 }) + "^5)^7");
                                }
                            }
                        }
                        writer.WriteLine(str2.Replace(",,", sep1.ToString()));
                    }
                    if (!flag)
                    {
                        writer.WriteLine(str + sep1 + this.getPlayerName(entity_0));
                    }
                    writer.Close();
                    return;
                }
            }
            using (StreamWriter writer2 = new StreamWriter(DirConfMove + FileAlias, true))
            {
                writer2.WriteLine(str + sep1 + this.getPlayerName(entity_0));
                writer2.Close();
            }
        }

        private void method_14(Entity entity_0)
        {
            Class67.smethod_125(this, entity_0, "^7MineField Activeted");
            Random random = new Random();
            foreach (Entity entity in Giocatori)
            {
                if (entity.IsAlive)
                {
                    for (int i = 0; i <= 2; i++)
                    {
                        int num2 = random.Next(-600, 0x259);
                        int num3 = random.Next(-600, 0x259);
                        Vector3 origin = entity.Origin;
                        origin.Z += 65f;
                        origin.X += num2;
                        origin.Y += num3;
                        base.Call("magicbullet", new Parameter[] { "remotemissile_projectile_mp", origin, entity });
                    }
                }
            }
        }

        internal void method_15(Entity entity_0, Entity entity_1, int int_3, string string_1)
        {
            using (StreamWriter writer = new StreamWriter(DirConfMove + FileTempBan, true))
            {
                string str = string.Concat(new object[] { 
                    DateTime.Now, sep2.ToString(), int_3, sep1, this.getPlayerName(entity_1), sep1, this.getPlayerID(entity_1), sep1, this.getPlayerGuid(entity_1), sep1, this.getPlayerHWID(entity_1), sep1, this.getPlayerXuid(entity_1), sep1, this.getPlayerIP(entity_1), sep1, 
                    string_1
                 });
                writer.WriteLine(str);
                writer.Close();
                if (entity_0 != null)
                {
                    Class67.smethod_125(this, entity_0, string.Concat(new object[] { "^5", this.getPlayerName(entity_1), " ^7Added To The TempBan List For ^5", int_3, "Min" }));
                    Class67.smethod_101(this, TeampbanMess.Replace("<playername>", entity_1.Name).Replace("<reason>", string_1).Replace("<kicker>", this.getPlayerName(entity_0)));
                    this.CommandConsole(string.Concat(new object[] { "dropclient ", entity_1.Call<int>("getentitynumber", new Parameter[0]), " \"", string_1, "\"" }), 0);
                }
                else
                {
                    Class67.smethod_101(this, TeampbanMess.Replace("<playername>", entity_1.Name).Replace("<reason>", string_1).Replace("<kicker>", "Server"));
                    this.CommandConsole(string.Concat(new object[] { "dropclient ", entity_1.Call<int>("getentitynumber", new Parameter[0]), " \"", string_1, "\"" }), 0);
                }
            }
        }

        private void method_16(Entity entity_0, string string_1)
        {
            if (System.IO.File.Exists(DirConfMove + FileTempBan))
            {
                string[] strArray = System.IO.File.ReadAllLines(DirConfMove + FileTempBan);
                System.IO.File.Delete(DirConfMove + FileTempBan);
                bool flag = false;
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { sep1 });
                    bool flag2 = true;
                    for (int j = 1; j < 3; j++)
                    {
                        if (string_1.Length < 3)
                        {
                            if (!(string_1 == i.ToString()))
                            {
                                continue;
                            }
                            goto Label_00AA;
                        }
                        if (strArray2[j].ToLower().Contains(string_1))
                        {
                            goto Label_00F0;
                        }
                    }
                    goto Label_0134;
                Label_00AA:
                    flag2 = false;
                    flag = true;
                    Class67.smethod_125(this, entity_0, "^5Player ^7" + strArray2[0] + "^5[^7" + strArray2[1] + "^5] ^7Successfully UnBanned!");
                    goto Label_0134;
                Label_00F0:
                    flag2 = false;
                    flag = true;
                    Class67.smethod_125(this, entity_0, "^5Player ^7" + strArray2[1] + "^5[^7" + strArray2[2] + "^5] ^7Successfully UnBanned!");
                Label_0134:
                    if (flag2)
                    {
                        using (StreamWriter writer = new StreamWriter(DirConfMove + FileTempBan, true))
                        {
                            writer.WriteLine(strArray[i]);
                            writer.Close();
                        }
                    }
                }
                if (!flag)
                {
                    Class67.smethod_125(this, entity_0, "^7No Player Found");
                }
            }
        }

        internal void method_17(Entity entity_0, Entity entity_1, string string_1)
        {
            using (StreamWriter writer = new StreamWriter(DirConfMove + FilePermBan, true))
            {
                string str = string.Concat(new object[] { DateTime.Now, sep1.ToString(), this.getPlayerName(entity_1), sep1, this.getPlayerID(entity_1), sep1, this.getPlayerGuid(entity_1), sep1, this.getPlayerHWID(entity_1), sep1, this.getPlayerXuid(entity_1), sep1, this.getPlayerIP(entity_1), sep1, string_1 });
                writer.WriteLine(str);
                writer.Close();
                if (entity_0 != null)
                {
                    Class67.smethod_125(this, entity_0, "^5" + this.getPlayerName(entity_1) + " ^7Added To The PermBan List!");
                    Class67.smethod_101(this, BanMess.Replace("<playername>", entity_1.Name).Replace("<reason>", string_1).Replace("<kicker>", this.getPlayerName(entity_0)));
                    this.CommandConsole(string.Concat(new object[] { "dropclient ", entity_1.Call<int>("getentitynumber", new Parameter[0]), " \"", string_1, "\"" }), 0);
                }
                else
                {
                    Class67.smethod_101(this, BanMess.Replace("<playername>", entity_1.Name).Replace("<reason>", string_1).Replace("<kicker>", "Server"));
                    this.CommandConsole(string.Concat(new object[] { "dropclient ", entity_1.Call<int>("getentitynumber", new Parameter[0]), " \"", string_1, "\"" }), 0);
                }
            }
        }

        private void method_18(Entity entity_0, string string_1)
        {
            if (System.IO.File.Exists(DirConfMove + FilePermBan))
            {
                string[] strArray = System.IO.File.ReadAllLines(DirConfMove + FilePermBan);
                System.IO.File.Delete(DirConfMove + FilePermBan);
                bool flag = false;
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { sep1 });
                    bool flag2 = true;
                    for (int j = 1; j < 3; j++)
                    {
                        if (string_1.Length < 3)
                        {
                            if (!(string_1 == i.ToString()))
                            {
                                continue;
                            }
                            goto Label_00AA;
                        }
                        if (strArray2[j].ToLower().Contains(string_1))
                        {
                            goto Label_00F0;
                        }
                    }
                    goto Label_0134;
                Label_00AA:
                    flag2 = false;
                    flag = true;
                    Class67.smethod_125(this, entity_0, "^5Player ^7" + strArray2[1] + "^5[^7" + strArray2[2] + "^5] ^7Successfully UnBanned!");
                    goto Label_0134;
                Label_00F0:
                    flag2 = false;
                    flag = true;
                    Class67.smethod_125(this, entity_0, "^5Player ^7" + strArray2[1] + "^5[^7" + strArray2[2] + "^5] ^7Successfully UnBanned!");
                Label_0134:
                    if (flag2)
                    {
                        using (StreamWriter writer = new StreamWriter(DirConfMove + FilePermBan, true))
                        {
                            writer.WriteLine(strArray[i]);
                            writer.Close();
                        }
                    }
                }
                if (!flag)
                {
                    Class67.smethod_125(this, entity_0, "^7No Player Found");
                }
            }
        }

        private void method_19(Entity entity_0, string string_1, string string_2)
        {
            if (string_2 == "add")
            {
                Entity player = this.method_22(entity_0, string_1);
                if (player == null)
                {
                    return;
                }
                if (this.getPlayerLevel(player) > 1)
                {
                    Class67.smethod_125(this, entity_0, "^7Error ^5- ^7The Player Is An Admin!");
                    return;
                }
                using (StreamWriter writer = new StreamWriter(DirConfMove + FileReports, true))
                {
                    string str = string.Concat(new object[] { 
                        DateTime.Now, sep1.ToString(), this.getPlayerName(player), sep1, this.getPlayerID(player), sep1, this.getPlayerGuid(player), sep1, this.getPlayerHWID(player), sep1, this.getPlayerXuid(player), sep1, this.getPlayerIP(player), ",Insert At ", DateTime.Now.ToShortDateString(), " By ", 
                        this.getPlayerName(entity_0)
                     });
                    writer.WriteLine(str);
                    writer.Close();
                    if (entity_0 != null)
                    {
                        Class67.smethod_125(this, entity_0, "^5" + this.getPlayerName(player) + " ^7Added To The Player Hack List!");
                    }
                    return;
                }
            }
            if (string_2 == "del")
            {
                if (System.IO.File.Exists(DirConfMove + FileReports))
                {
                    string[] strArray = System.IO.File.ReadAllLines(DirConfMove + FileReports);
                    System.IO.File.Delete(DirConfMove + FileReports);
                    bool flag = false;
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        string[] strArray2 = strArray[i].Split(new char[] { sep1 });
                        bool flag2 = true;
                        for (int j = 0; j < 2; j++)
                        {
                            if (strArray2[j].ToLower().Contains(string_1))
                            {
                                goto Label_0216;
                            }
                        }
                        goto Label_025D;
                    Label_0216:
                        flag2 = false;
                        flag = true;
                        Class67.smethod_125(this, entity_0, "^5Report Player ^7" + strArray2[0] + "^5[^7" + strArray2[1] + "^5] ^7Successfully Deleted!");
                    Label_025D:
                        if (flag2)
                        {
                            using (StreamWriter writer2 = new StreamWriter(DirConfMove + FileReports, true))
                            {
                                writer2.WriteLine(strArray[i]);
                                writer2.Close();
                            }
                        }
                    }
                    if (!flag)
                    {
                        Class67.smethod_125(this, entity_0, "^7No Player Found");
                    }
                }
                else
                {
                    Class67.smethod_125(this, entity_0, "^7No Player Found");
                }
            }
        }

        private void method_2(Entity entity_0, string string_1)
        {
            if (System.IO.File.Exists(DirTempFile + FileLastExit))
            {
                string[] strArray = System.IO.File.ReadAllLines(DirTempFile + FileLastExit);
                bool flag = false;
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { sep1 });
                    for (int j = 0; j < 2; j++)
                    {
                        if (strArray2[j].ToLower().Contains(string_1))
                        {
                            if (this.getPlayerLevel(entity_0) > Class67.smethod_39(strArray2[2], this))
                            {
                                goto Label_0097;
                            }
                            Class67.smethod_125(this, entity_0, "^7Error ^5- ^7You Can Not PermBan a Player With Your Same Level!");
                        }
                    }
                    goto Label_0127;
                Label_0097:
                    flag = true;
                    using (StreamWriter writer = new StreamWriter(DirConfMove + FilePermBan, true))
                    {
                        writer.WriteLine(DateTime.Now + sep1.ToString() + strArray[i]);
                        writer.Close();
                    }
                    Class67.smethod_125(this, entity_0, "^5Player ^7" + strArray2[0] + "^5[^7" + strArray2[1] + "^5] ^7Successfully Banned!");
                Label_0127:
                    if (flag)
                    {
                        break;
                    }
                }
                if (!flag)
                {
                    Class67.smethod_125(this, entity_0, "^7No Player Found");
                }
            }
        }

        private void method_20(Entity entity_0, double double_0, double double_1, double double_2)
        {
            try
            {
                string[] strArray = null;
                if (System.IO.File.Exists(DirConfLocal + FileXlrStats))
                {
                    strArray = System.IO.File.ReadAllLines(DirConfLocal + FileXlrStats);
                    System.IO.File.Delete(DirConfLocal + FileXlrStats);
                }
                using (StreamWriter writer = new StreamWriter(DirConfLocal + FileXlrStats, true))
                {
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        string str = strArray[i].ToString();
                        if (str.StartsWith(this.getPlayerGuid(entity_0)))
                        {
                            str = string.Concat(new object[] { this.getPlayerGuid(entity_0), sep5, this.getPlayerName(entity_0), sep5, DateTime.Now, sep2, xlrDay, sep5, double_0.ToString(), sep5, double_1.ToString(), sep5, double_2.ToString() });
                        }
                        writer.WriteLine(str);
                    }
                    writer.Close();
                }
            }
            catch (Exception exception)
            {
                Class67.smethod_57(exception, this, "XlrUpdate");
            }
        }

        private void method_21(Entity entity_0, Entity entity_1)
        {
            try
            {
                string[] strArray = Class67.smethod_52(this, entity_0);
                if (strArray != null)
                {
                    double num = Convert.ToDouble(strArray[3]) + 1.0;
                    double num2 = Convert.ToDouble(strArray[4]);
                    double num3 = num / num2;
                    if (num3.ToString() == "Infinity")
                    {
                        num3 = 0.0;
                    }
                    string[] strArray2 = num3.ToString().Split(new char[] { '.' });
                    if ((strArray2.Length == 2) && (strArray2[1].Length > 3))
                    {
                        num3 = Convert.ToDouble(strArray2[0] + "." + strArray2[1].Substring(0, 3));
                    }
                    this.method_20(entity_0, num, num2, num3);
                }
                string[] strArray3 = Class67.smethod_52(this, entity_1);
                if (strArray3 != null)
                {
                    double num4 = Convert.ToDouble(strArray3[3]);
                    double num5 = Convert.ToDouble(strArray3[4]) + 1.0;
                    double num6 = num4 / num5;
                    if (num6.ToString() == "Infinity")
                    {
                        num6 = 0.0;
                    }
                    string[] strArray4 = num6.ToString().Split(new char[] { '.' });
                    if ((strArray4.Length == 2) && (strArray4[1].Length > 3))
                    {
                        num6 = Convert.ToDouble(strArray4[0] + "." + strArray4[1].Substring(0, 3));
                    }
                    this.method_20(entity_1, num4, num5, num6);
                }
            }
            catch (Exception exception)
            {
                Class67.smethod_57(exception, this, "XlrStatUPD");
            }
        }

        private Entity method_22(Entity entity_0, string string_1)
        {
            try
            {
                int num = 0;
                Entity entity = null;
                foreach (Entity entity2 in Giocatori)
                {
                    if (string_1.Length < 3)
                    {
                        if (this.getPlayerSlot(entity2) == string_1)
                        {
                            entity = entity2;
                            num++;
                        }
                    }
                    else if ((entity2.Name.ToLower().Contains(string_1) || (this.getPlayerID(entity2) == string_1)) || ((this.getPlayerGuid(entity2) == string_1) || (this.getPlayerXuid(entity2) == string_1)))
                    {
                        entity = entity2;
                        num++;
                    }
                }
                if ((num == 1) && (entity.EntRef != entity_0.EntRef))
                {
                    return entity;
                }
                if (num > 1)
                {
                    Class67.smethod_125(this, entity_0, "^7Error ^5- ^7Multiple Matches Found!");
                    return null;
                }
                Class67.smethod_125(this, entity_0, "^7Error ^5- ^7No Player Found!");
                return null;
            }
            catch (Exception exception)
            {
                Class67.smethod_57(exception, this, "TrovaPlayer");
                return null;
            }
        }

        private Entity method_23(Entity entity_0, string string_1)
        {
            try
            {
                int num = 0;
                Entity entity = null;
                foreach (Entity entity2 in AllGiocatori)
                {
                    if (string_1.Length < 3)
                    {
                        if (this.getPlayerSlot(entity2) == string_1)
                        {
                            entity = entity2;
                            num++;
                        }
                    }
                    else if ((entity2.Name.ToLower().Contains(string_1) || (this.getPlayerID(entity2) == string_1)) || ((this.getPlayerGuid(entity2) == string_1) || (this.getPlayerXuid(entity2) == string_1)))
                    {
                        entity = entity2;
                        num++;
                    }
                }
                if ((num == 1) && (entity.EntRef != entity_0.EntRef))
                {
                    return entity;
                }
                if (num > 1)
                {
                    Class67.smethod_125(this, entity_0, "^7Error ^5- ^7Multiple Matches Found!");
                    return null;
                }
                Class67.smethod_125(this, entity_0, "^7Error ^5- ^7No Player Found!");
                return null;
            }
            catch (Exception exception)
            {
                Class67.smethod_57(exception, this, "TrovaPlayerAll");
                return null;
            }
        }

        private void method_24()
        {
            try
            {
                if ((TypeMap.Contains("inf") || stato_passSS) || (PasswordServer != "null"))
                {
                    return;
                }
                axis.Clear();
                allies.Clear();
                foreach (Entity entity in AllGiocatori)
                {
                    if (entity.GetField<string>("sessionteam") == "allies")
                    {
                        allies.Add(entity);
                    }
                    else if (entity.GetField<string>("sessionteam") == "axis")
                    {
                        axis.Add(entity);
                    }
                }
                hasel = allies.Count - axis.Count;
                if (allies.Count >= axis.Count)
                {
                    goto Label_01E1;
                }
                if (((hasel == -1) || (hasel == 1)) || (hasel == 0))
                {
                    return;
                }
                using (List<Entity>.Enumerator enumerator2 = axis.GetEnumerator())
                {
                    Entity current;
                    while (enumerator2.MoveNext())
                    {
                        current = enumerator2.Current;
                        if (((hasel != -1) && (hasel != 1)) && (hasel != 0))
                        {
                            goto Label_0148;
                        }
                    }
                    goto Label_01D6;
                Label_0148:
                    current.SetField("team", "allies");
                    current.SetField("sessionteam", "allies");
                    current.Notify("menuresponse", new Parameter[] { new Parameter("team_marinesopfor"), new Parameter("allies") });
                    current.Call("iprintlnbold", new Parameter[] { "Balanced Team!" });
                }
            Label_01D6:
                this.method_24();
                return;
            Label_01E1:
                if (allies.Count <= axis.Count)
                {
                    return;
                }
                hasel = allies.Count - axis.Count;
                if (((hasel == 1) || (hasel == -1)) || (hasel == 0))
                {
                    return;
                }
                using (List<Entity>.Enumerator enumerator3 = allies.GetEnumerator())
                {
                    Entity entity3;
                    while (enumerator3.MoveNext())
                    {
                        entity3 = enumerator3.Current;
                        if (((hasel != 1) && (hasel != -1)) && (hasel != 0))
                        {
                            goto Label_026D;
                        }
                    }
                    goto Label_02FB;
                Label_026D:
                    entity3.SetField("team", "axis");
                    entity3.SetField("sessionteam", "axis");
                    entity3.Notify("menuresponse", new Parameter[] { new Parameter("team_marinesopfor"), new Parameter("axis") });
                    entity3.Call("iprintlnbold", new Parameter[] { "Balanced Team!" });
                }
            Label_02FB:
                this.method_24();
            }
            catch (Exception exception)
            {
                Class67.smethod_57(exception, this, "BilanciaTeam");
            }
        }

        private void method_25(Entity entity_0, string string_1, Entity entity_1, string string_2)
        {
            Class46 class4 = new Class46
            {
                entity_0 = entity_0,
                entity_1 = entity_1,
                string_0 = string_2,
                serverControll_0 = this
            };
            try
            {
                Class47 class3 = new Class47
                {
                    string_0 = string_1.Split(new char[] { ' ' })
                };
                if (this.getPlayerVote(class4.entity_0) != null)
                {
                    DateTime temp = DateTime.Parse(this.getPlayerVote(class4.entity_0));
                    if (this.TPassato(temp) < 4.0)
                    {
                        Class67.smethod_125(this, class4.entity_0, "^7Wait At Least 3 Minutes Since Your Last Vote");
                        return;
                    }
                }
                if ((!class3.string_0[0].Contains("map") && !class3.string_0[0].Contains("mod")) && (!class3.string_0[0].Contains("kick") && !class3.string_0[0].Contains("ban")))
                {
                    Class67.smethod_125(this, class4.entity_0, "^7Invalid Type Of Vote!");
                }
                else
                {
                    Class48 class2 = new Class48
                    {
                        class47_0 = class3,
                        class46_0 = class4
                    };
                    StatVotazione = true;
                    UltimoVoto = DateTime.Now.ToString();
                    this.setPlayerVote(class4.entity_0);
                    class2.int_1 = 0;
                    VotoNo = 0;
                    VotoSi = 0;
                    foreach (Entity entity in Giocatori)
                    {
                        entity.SetField("Voto", 0);
                    }
                    Class67.smethod_101(this, "^5" + this.getPlayerName(class4.entity_0) + " ^7Has Requested a Vote");
                    TitleVote = HudElem.CreateServerFontString("hudbig", 0.6f);
                    TitleVote2 = HudElem.CreateServerFontString("hudbig", 0.5f);
                    TitleVote.SetPoint("TOPLEFT", "TOPLEFT", 10, 110);
                    TitleVote.HideWhenInMenu = true;
                    TitleVote2.SetPoint("TOPLEFT", "TOPLEFT", 10, 120);
                    TitleVote2.HideWhenInMenu = true;
                    if (class3.string_0[0].Contains("map"))
                    {
                        TitleVote.SetText("^7Vote Change Map ^5" + Class67.smethod_124(this, class3.string_0[1]) + "^7?");
                    }
                    else if (class3.string_0[0].Contains("mod"))
                    {
                        TitleVote.SetText("^7Vote Change Mod ^5" + class3.string_0[1] + "^7?");
                    }
                    else if (class3.string_0[0].Contains("kick"))
                    {
                        TitleVote.SetText("^7Vote kick ^5" + this.getPlayerName(class4.entity_1) + "^7?");
                    }
                    else if (class3.string_0[0].Contains("ban"))
                    {
                        TitleVote.SetText("^7Vote TempBan ^5" + this.getPlayerName(class4.entity_1) + "^7?");
                    }
                    TitleVote.Alpha = 1f;
                    TitleVote2.Alpha = 1f;
                    base.OnInterval(0x3e8, new Func<bool>(class2.method_0));
                }
            }
            catch (Exception exception)
            {
                Class67.smethod_57(exception, this, "AvvVotazione");
            }
        }

        private bool method_26(Entity entity_0, string string_1)
        {
            try
            {
                if (((this.getPlayerLevel(entity_0) == 2) || (this.getPlayerLevel(entity_0) == 3)) && PoteriGraduati)
                {
                    foreach (Entity entity in Giocatori)
                    {
                        if (((this.getPlayerLevel(entity) > 3) && (entity.GetField<int>("Afk") == 0)) && (this.getPlayerAccess(entity) == 1))
                        {
                            foreach (string str in ComandiSM)
                            {
                                if (string_1.Equals(str))
                                {
                                    return false;
                                }
                            }
                            foreach (string str2 in ComandiM)
                            {
                                if (string_1.Equals(str2))
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("dictionary."))
                {
                    Class67.smethod_57(exception, this, "ControllPoteriGraduati");
                }
                return true;
            }
        }

        internal void method_27(string string_1)
        {
            CtrBots = false;
            if (string_1 == "all")
            {
                foreach (Entity entity in Bots)
                {
                    this.CommandConsole("dropclient " + entity.EntRef, 0);
                }
            }
            else
            {
                foreach (Entity entity2 in Bots)
                {
                    if (entity2.Name.Contains(string_1))
                    {
                        this.CommandConsole("dropclient " + entity2.EntRef, 0);
                    }
                }
            }
        }

        private void method_28()
        {
            Class59 class2 = new Class59
            {
                serverControll_0 = this
            };
            string str = "";
            if (Piattaforma.StartsWith("te"))
            {
                str = "TeknoMW3_dedicated";
            }
            else if (Piattaforma.StartsWith("pl"))
            {
                str = "PlusIW5_Server";
            }
            else if (Piattaforma.StartsWith("rep"))
            {
                str = "iw5m_server";
            }
            else if (Piattaforma.StartsWith("plut"))
            {
                str = "plutonium_iw5mp_server";
            }
                else if (Piattaforma.StartsWith("stm"))
            {
                str = "iw5mp_server";
            }
            int num = base.Call<int>("getdvarint", new Parameter[] { "net_queryPort" });
            int num2 = base.Call<int>("getdvarint", new Parameter[] { "net_port" });
            int num3 = base.Call<int>("getdvarint", new Parameter[] { "net_masterServerPort" });
            class2.int_0 = 6;
            if (System.IO.File.Exists("riavvia.bat"))
            {
                System.IO.File.Delete("riavvia.bat");
            }
            using (StreamWriter writer = new StreamWriter("riavvia.bat", true))
            {
                string str2 = "@echo off";
                string str3 = "TIMEOUT /T 2 /NOBREAK";
                string str4 = "TASKKILL /F /IM " + str + ".exe /T";
                string str5 = "TIMEOUT /T 2 /NOBREAK";
                string str6 = "start /B /MIN " + str + " +set net_queryPort " + num.ToString() + " +set net_port " + num2.ToString() + " +set net_masterServerPort " + num3.ToString() + " +set sv_config \"server.cfg\" +start_map_rotate +set dedicated 2";
                string str7 = "TIMEOUT /T 2 /NOBREAK";
                string str8 = "DEL /F /Q riavvia.bat";
                string str9 = "cls";
                writer.WriteLine(str2);
                writer.WriteLine(str3);
                writer.WriteLine(str4);
                writer.WriteLine(str5);
                writer.WriteLine(str6);
                writer.WriteLine(str7);
                writer.WriteLine(str8);
                writer.WriteLine(str9);
                writer.Close();
            }
            base.OnInterval(0x3e8, new Func<bool>(class2.method_0));
        }

        /*internal void method_29(object sender, DownloadProgressChangedEventArgs e)
        {
            if (PercDownLoad == e.ProgressPercentage)
            {
                PercDownLoad += 5;
                Class67.smethod_33(this, "Download Database GPS... [" + e.ProgressPercentage + "%]", new object[0]);
                downGPS = false;
            }
        }*/

        internal void method_3(Entity entity_0, string string_1)
        {
            using (StreamWriter writer = new StreamWriter(DirConfMove + FileNoRecoil, true))
            {
                string str = string.Concat(new object[] { 
                    DateTime.Now, sep1.ToString(), this.getPlayerName(entity_0), sep1, this.getPlayerID(entity_0), sep1, this.getPlayerGuid(entity_0), sep1, this.getPlayerHWID(entity_0), sep1, this.getPlayerXuid(entity_0), sep1, this.getPlayerIP(entity_0), sep1, "^7Suspect Use NORECOIL With Weapon ^5", string_1, 
                    " ^7On ^5", DateTime.Now
                 });
                writer.WriteLine(str);
                writer.Close();
            }
        }

        /*internal void method_30(object sender, AsyncCompletedEventArgs e)
        {
            Class67.smethod_33(this, "Download Database GPS Completed!", new object[0]);
            downGPS = true;
        }*/

        private void method_31(Entity entity_0)
        {
            this.InConnessione_Player(entity_0);
        }

        private void method_32(Entity entity_0)
        {
            this.Connessione_Player(entity_0);
        }

        private void method_33(Entity entity_0)
        {
            this.Disconnessione_Player(entity_0);
        }

        private void method_34()
        {
            Class67.smethod_135(this);
        }

        private void method_35()
        {
            Class67.smethod_65(this);
        }

        internal void method_36()
        {
            Class67.smethod_92(this, null);
        }

        internal void method_37()
        {
            this.Reconfig_Messages();
        }

        internal void method_38()
        {
            this.Reconfig_Admin();
        }

        internal void method_39()
        {
            this.Reconfig_Config();
        }

        internal void method_4(Entity entity_0, string string_1)
        {
            using (StreamWriter writer = new StreamWriter(DirConfMove + FileUseAimbot, true))
            {
                string str = string.Concat(new object[] { 
                    DateTime.Now, sep1.ToString(), this.getPlayerName(entity_0), sep1, this.getPlayerID(entity_0), sep1, this.getPlayerGuid(entity_0), sep1, this.getPlayerHWID(entity_0), sep1, this.getPlayerXuid(entity_0), sep1, this.getPlayerIP(entity_0), sep1, "^7Suspect Use AIMBOT With Weapon ^5", string_1, 
                    " ^7On ^5", DateTime.Now
                 });
                writer.WriteLine(str);
                writer.Close();
            }
        }

        internal void method_40()
        {
            RanMap = nrmaps.Next(0x3b);
            if (System.IO.File.Exists(DirTempFile + "nextmaps"))
            {
                string[] strArray = System.IO.File.ReadAllLines(DirTempFile + "nextmaps");
                if (strArray[0].Equals(MapName))
                {
                    NxtMap = strArray[1];
                }
                else
                {
                    System.IO.File.Delete(DirTempFile + "nextmaps");
                    Class67.smethod_139(this, false, null);
                }
            }
            else
            {
                Class67.smethod_139(this, false, null);
            }
        }

        internal void method_41(Entity entity_0)
        {
            Action function = null;
            Action action2 = null;
            Action action3 = null;
            Action action4 = null;
            Class12 class2 = new Class12
            {
                entity_0 = entity_0,
                serverControll_0 = this
            };
            if (WelcomeMessages)
            {
                Entity entity;
                string str2;
                //Class67.smethod_125(this, class2.entity_0, "^7Are You The Player Number ^5#" + Visite);
                if (this.getPlayerLevel(class2.entity_0) == 1)
                {
                    entity = class2.entity_0;
                    str2 = WelcomeUserMess.Replace("<playername>", this.getPlayerName(class2.entity_0));
                    Class67.smethod_107(entity, this, str2);
                }
                else if (this.getPlayerLevel(class2.entity_0) == 2)
                {
                    entity = class2.entity_0;
                    str2 = WelcomeModMess.Replace("<playername>", this.getPlayerName(class2.entity_0));
                    Class67.smethod_107(entity, this, str2);
                }
                else if (this.getPlayerLevel(class2.entity_0) == 3)
                {
                    entity = class2.entity_0;
                    str2 = WelcomeSeniorModMess.Replace("<playername>", this.getPlayerName(class2.entity_0));
                    Class67.smethod_107(entity, this, str2);
                }
                else if (this.getPlayerLevel(class2.entity_0) == 4)
                {
                    entity = class2.entity_0;
                    str2 = WelcomeAdminMess.Replace("<playername>", this.getPlayerName(class2.entity_0));
                    Class67.smethod_107(entity, this, str2);
                }
                else if (this.getPlayerLevel(class2.entity_0) == 5)
                {
                    entity = class2.entity_0;
                    str2 = WelcomeSuperAdminMess.Replace("<playername>", this.getPlayerName(class2.entity_0));
                    Class67.smethod_107(entity, this, str2);
                }
            }
            if (ShowLoginAdmin)
            {
                string s = lvlNotice.ToString() + "00";
                if (this.getPlayerAccess(class2.entity_0) == 1)
                {
                    if (this.getPlayerLevel(class2.entity_0) == 2)
                    {
                        if (function == null)
                        {
                            function = new Action(class2.method_0);
                        }
                        base.AfterDelay(0x7d0 + int.Parse(s), function);
                    }
                    else if (this.getPlayerLevel(class2.entity_0) == 3)
                    {
                        if (action2 == null)
                        {
                            action2 = new Action(class2.method_1);
                        }
                        base.AfterDelay(0x1388 + int.Parse(s), action2);
                    }
                    else if (this.getPlayerLevel(class2.entity_0) == 4)
                    {
                        if (action3 == null)
                        {
                            action3 = new Action(class2.method_2);
                        }
                        base.AfterDelay(0x1f40 + int.Parse(s), action3);
                    }
                    else if (this.getPlayerLevel(class2.entity_0) == 5)
                    {
                        if (action4 == null)
                        {
                            action4 = new Action(class2.method_3);
                        }
                        base.AfterDelay(0x2710 + int.Parse(s), action4);
                    }
                }
            }
        }

        internal bool method_42()
        {
            if (Giocatori.Count > 0)
            {
                this.method_9();
                this.method_7();
                this.method_8();
            }
            return true;
        }

        internal bool method_43()
        {
            if (Giocatori.Count > 0)
            {
                int num = adv.Next(15);
                switch (num)
                {
                    case 0:
                        if (!this.SuperAdminOnline().Contains("^5-----") && ShowLoginAdmin)
                        {
                            Class67.smethod_101(this, "^7Owner OnLine: ^5" + this.SuperAdminOnline());
                        }
                        goto Label_017B;

                    case 1:
                        if (!this.AdminOnline().Contains("^5-----") && ShowLoginAdmin)
                        {
                            Class67.smethod_101(this, "^7Moderator OnLine: ^5" + this.AdminOnline());
                        }
                        goto Label_017B;

                    case 2:
                        if (!this.SeniorModOnline().Contains("^5-----") && ShowLoginAdmin)
                        {
                            Class67.smethod_101(this, "^7Member OnLine: ^5" + this.SeniorModOnline());
                        }
                        goto Label_017B;

                    case 3:
                        if (!this.ModOnline().Contains("^5-----") && ShowLoginAdmin)
                        {
                            Class67.smethod_101(this, "^7Friend OnLine: ^5" + this.ModOnline());
                        }
                        goto Label_017B;
                }
                if ((num == 4) && AutoRules)
                {
                    this.ShowRandomRules();
                }
                else if ((num == 5) && XlrStatsEnable)
                {
                    if (TypeMap.Contains("inf"))
                    {
                        if (XLRonInfect)
                        {
                            Class67.smethod_101(this, "^7Use ^5!register ^7To Activate Your XlrStats");
                        }
                    }
                    else
                    {
                        Class67.smethod_101(this, "^7Use ^5!register ^7To Activate Your XlrStats");
                    }
                }
                else if ((num == 6) && XlrStatsEnable)
                {
                    Class67.smethod_44(this, null);
                }
                else
                {
                    this.ShowRandomAdv();
                }
            }
        Label_017B:
            return true;
        }

        internal bool method_44()
        {
            using (List<Entity>.Enumerator enumerator = Giocatori.GetEnumerator())
            {
                Action function = null;
                Class13 class2 = new Class13();
                while (enumerator.MoveNext())
                {
                    class2.entity_0 = enumerator.Current;
                    bool flag = true;
                    if (!class2.entity_0.IsAlive || !AvvGame)
                    {
                        class2.entity_0.SetField("LPCamp", new Vector3(0f, 0f, 0f));
                        flag = false;
                    }
                    if (class2.entity_0.GetField<string>("sessionstate") == "spectator")
                    {
                        flag = false;
                    }
                    for (int i = 0; i < WeaponCamps.Length; i++)
                    {
                        if (class2.entity_0.CurrentWeapon.ToString().Contains(WeaponCamps[i]))
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        if (class2.entity_0.HasField("LPCamp"))
                        {
                            Vector3 field = class2.entity_0.GetField<Vector3>("LPCamp");
                            if (!class2.entity_0.HasField("Camp"))
                            {
                                class2.entity_0.SetField("Camp", 0);
                            }
                            if (field.DistanceTo2D(class2.entity_0.Origin) < 120f)
                            {
                                if (ModCampers == "kick")
                                {
                                    class2.entity_0.Call("iprintlnbold", new Parameter[] { "^7No Camp!!! ^5- ^7If You Do Not Move You Are Kick." });
                                }
                                else if (ModCampers == "kill")
                                {
                                    class2.entity_0.Call("iprintlnbold", new Parameter[] { "^7No Camp!!! ^5- ^7If You Do Not Move You Are Killed." });
                                }
                                else if (ModCampers == "block")
                                {
                                    class2.entity_0.Call("iprintlnbold", new Parameter[] { "^7No Camp!!! ^5- ^7If You Do Not Move You Are Block." });
                                }
                                int num2 = class2.entity_0.GetField<int>("Camp");
                                if ((num2 != 0) && (ModCampers == "kill"))
                                {
                                    class2.entity_0.Health /= 2;
                                    class2.entity_0.Notify("damage", new Parameter[] { class2.entity_0.Health, class2.entity_0, new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), "MOD_EXPLOSIVE", "", "", "", 0, "frag_grenade_mp" });
                                }
                                if (num2 > 3)
                                {
                                    if (ModCampers == "kick")
                                    {
                                        this.kikUser("Server", "k", class2.entity_0, "^7No Camp!!!");
                                    }
                                    else if (ModCampers == "kill")
                                    {
                                        if (function == null)
                                        {
                                            function = new Action(class2.method_0);
                                        }
                                        base.AfterDelay(50, function);
                                    }
                                    else if ((ModCampers == "block") && (num2 == 4))
                                    {
                                        Class67.smethod_105(this, class2.entity_0);
                                    }
                                }
                                class2.entity_0.SetField("Camp", ++num2);
                            }
                            else
                            {
                                class2.entity_0.SetField("Camp", 0);
                            }
                        }
                        class2.entity_0.SetField("LPCamp", class2.entity_0.Origin);
                    }
                }
            }
            return true;
        }

        internal bool method_45(Entity entity_0)
        {
            if (entity_0.GetField<int>("searchbull") == 0)
            {
                return false;
            }
            if (entity_0.IsAlive)
            {
                Entity entity = null;
                foreach (Entity entity2 in Giocatori)
                {
                    if ((((entity2.IsAlive && (entity_0.EntRef != entity2.EntRef)) && ((entity2.GetField<string>("sessionstate") != "spectator") && (entity2.GetField<string>("sessionteam") != "spectator"))) && (((entity_0.GetField<string>("sessionteam") != entity2.GetField<string>("sessionteam")) || (base.Call<string>("getdvar", new Parameter[] { "g_gametype" }) == "dm")) || (base.Call<string>("getdvar", new Parameter[] { "g_gametype" }) == "oic"))) && (base.Call<int>(0x74, new Parameter[] { entity_0.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }), entity2.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }), 0, entity_0 }) == 1))
                    {
                        if (entity != null)
                        {
                            if (base.Call<int>("closer", new Parameter[] { entity_0.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }), entity2.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }), entity.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }) }) == 1)
                            {
                                entity = entity2;
                            }
                        }
                        else
                        {
                            entity = entity2;
                        }
                    }
                }
                if (((entity != null) && (entity_0.Call<int>("attackbuttonpressed", new Parameter[0]) > 0)) && (entity_0.Origin.DistanceTo(entity.Origin) < 70f))
                {
                    Vector3 vector = entity.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" });
                    string currentWeapon = entity_0.CurrentWeapon;
                    vector.X -= 5f;
                    vector.Y -= 5f;
                    vector.Z -= 10f;
                    base.Call("magicbullet", new Parameter[] { currentWeapon, vector, entity.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }), entity_0 });
                }
            }
            return true;
        }

        internal bool method_46(Entity entity_0)
        {
            Action<Entity> function = null;
            Action<Entity> action2 = null;
            Class49 class2 = new Class49
            {
                entity_0 = entity_0,
                serverControll_0 = this
            };
            if (class2.entity_0.IsAlive)
            {
                Random random = new Random();
                Random random2 = new Random();
                Entity entity = null;
                foreach (Entity entity2 in AllGiocatori)
                {
                    if ((((entity2.IsAlive && (class2.entity_0.EntRef != entity2.EntRef)) && ((entity2.GetField<string>("sessionstate") != "spectator") && (entity2.GetField<string>("sessionteam") != "spectator"))) && (((class2.entity_0.GetField<string>("sessionteam") != entity2.GetField<string>("sessionteam")) || (base.Call<string>("getdvar", new Parameter[] { "g_gametype" }) == "dm")) || (base.Call<string>("getdvar", new Parameter[] { "g_gametype" }) == "oic"))) && (base.Call<int>(0x74, new Parameter[] { class2.entity_0.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }), entity2.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }), 0, class2.entity_0 }) == 1))
                    {
                        if (entity != null)
                        {
                            if (base.Call<int>("closer", new Parameter[] { class2.entity_0.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }), entity2.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }), entity.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }) }) == 1)
                            {
                                entity = entity2;
                            }
                        }
                        else
                        {
                            entity = entity2;
                        }
                    }
                }
                if ((entity != null) && (class2.entity_0.GetField<int>("ghiaccio") == 0))
                {
                    if (class2.entity_0.GetField<int>("visto") == 0)
                    {
                        if (random2.Next(8) == 0)
                        {
                            class2.entity_0.SetField("visto", 1);
                            Vector3 vector = base.Call<Vector3>("VectorToAngles", new Parameter[] { entity.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }) - class2.entity_0.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }) });
                            class2.entity_0.Call("setplayerangles", new Parameter[] { vector });
                            class2.entity_0.Call("giveMaxAmmo", new Parameter[] { class2.entity_0.CurrentWeapon });
                            if ((random.Next(7) == 0) && (class2.entity_0.Origin.DistanceTo(entity.Origin) < 700f))
                            {
                                if (function == null)
                                {
                                    function = new Action<Entity>(class2.method_0);
                                }
                                entity.AfterDelay(500, function);
                            }
                        }
                    }
                    else
                    {
                        Vector3 vector2 = base.Call<Vector3>("VectorToAngles", new Parameter[] { entity.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }) - class2.entity_0.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }) });
                        class2.entity_0.Call("setplayerangles", new Parameter[] { vector2 });
                        class2.entity_0.Call("giveMaxAmmo", new Parameter[] { class2.entity_0.CurrentWeapon });
                        if ((random.Next(7) == 0) && (class2.entity_0.Origin.DistanceTo(entity.Origin) < 700f))
                        {
                            if (action2 == null)
                            {
                                action2 = new Action<Entity>(class2.method_1);
                            }
                            entity.AfterDelay(500, action2);
                        }
                    }
                }
                else
                {
                    class2.entity_0.SetField("visto", 0);
                }
            }
            return true;
        }

        internal bool method_47()
        {
            if (!CtrBots)
            {
                return false;
            }
            int num = 0x12;
            int count = AllGiocatori.Count;
            int num3 = 0x12 - count;
            for (int i = 8; i < num3; i++)
            {
                Class67.smethod_160(this, null, 1, 0);
            }
            int num5 = AllGiocatori.Count;
            int num6 = num - num5;
            for (int j = num6; j == num; j++)
            {
                using (List<Entity>.Enumerator enumerator = Bots.GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        Entity current = enumerator.Current;
                        this.CommandConsole("dropclient " + current.EntRef, 200);
                    }
                }
            }
            return true;
        }

        private void method_48(Entity entity_0, Parameter parameter_0)
        {
            Class67.smethod_153(parameter_0, this, entity_0);
        }

        private void method_49(Entity entity_0, Parameter parameter_0)
        {
            Class67.smethod_154(parameter_0, this, entity_0);
        }

        private void method_5(Entity entity_0)
        {
            using (StreamWriter writer = new StreamWriter(DirConfMove + FileUseHack, true))
            {
                string str = string.Concat(new object[] { DateTime.Now, sep1.ToString(), this.getPlayerName(entity_0), sep1, this.getPlayerID(entity_0), sep1, this.getPlayerGuid(entity_0), sep1, this.getPlayerHWID(entity_0), sep1, this.getPlayerXuid(entity_0), sep1, this.getPlayerIP(entity_0), sep1, "^7Suspect Use HACK On ^5", DateTime.Now });
                writer.WriteLine(str);
                writer.Close();
            }
        }

        internal void method_50(Entity entity_0)
        {
            if (this.getPlayerLevel(entity_0) > 1)
            {
                this.MenuInit(entity_0);
            }
            Class67.smethod_62(this, entity_0);
        }

        internal void method_51()
        {
            this.method_27("all");
            if (Bilanciamento)
            {
                this.method_24();
            }
        }

        internal void method_52()
        {
            Class67.smethod_16(this);
            Class67.smethod_110(this);
            Class67.smethod_51(this);
            Class67.smethod_2(this);
            Class67.smethod_99(this);
            //Class67.smethod_4(this);
            string_0 = base.Call<string>("getdvar", new Parameter[] { new Parameter("nextmap") }).Split(new char[] { ' ' })[1].ToLower();
            Class67.smethod_33(this, "===============================================================", new object[0]);
            Class67.smethod_33(this, string.Concat(new object[] { "Name Server: ", this.NomeServerPulito, " - Date: ", DateTime.Now.Day, ".", DateTime.Now.Month, ".", DateTime.Now.Year, " - ", DateTime.Now.Hour, ":", DateTime.Now.Minute, ":", DateTime.Now.Second }), new object[0]);
            Class67.smethod_33(this, "ServerPsw: " + PasswordServer + " - MaxClient: " + MaxClient + " - PrivClient: " + PrivateClient + " - PrivClientPsw: " + PasswordPrivClient, new object[0]);
            Class67.smethod_33(this, "Map: " + MapName + " - MapName: " + Class67.smethod_124(this, MapName) + " - MapType: " + TypeMap + " - DSPL: " + string_0, new object[0]);
            Class67.smethod_33(this, "===============================================================", new object[0]);
            this.method_27("all");
            Class67.smethod_37(this);
        }

        internal void method_53()
        {
            Class67.smethod_152(this);
            Class67.smethod_150(this);
            Class67.smethod_114(this);
            Class67.smethod_134(this);
            /*if (!System.IO.File.Exists(FileGPS))
            {
                if (ScanGPS)
                {
                    Class67.smethod_34(this, FileGPSWeb);
                }
            }
            else
            {
                FileInfo info = new FileInfo(FileGPS);
                if (info.Length < SizeGPS)
                {
                    System.IO.File.Delete(FileGPS);
                    if (ScanGPS)
                    {
                        Class67.smethod_34(this, FileGPSWeb);
                    }
                }
            }
        }

        public void method_6(Entity player, Entity Adm)
        {
            Class6 class2 = new Class6
            {
                serverControll_0 = this
            };
            if (System.IO.File.Exists(FileGPS))
            {
                FileInfo info = new FileInfo(FileGPS);
                if (info.Length < SizeGPS)
                {
                    System.IO.File.Delete(FileGPS);
                    ScanGPS = false;
                }
                else
                {
                    string ip = this.GetIPAddress(player.EntRef).ToString();
                    class2.string_0 = this.lookupIP(ip);
                    class2.string_1 = player.Name;
                    if (Adm != null)
                    {
                        Class67.smethod_125(this, Adm, "^5" + class2.string_1 + " ^7Connect From ^5[^7" + class2.string_0 + "^5]^7");
                    }
                    else if (AllGiocatori.Contains(player))
                    {
                        base.AfterDelay(0xbb8, new Action(class2.method_0));
                    }
                }
            }
            else
            {
                ScanGPS = false;
            }*/
        }

        private void method_7()
        {
            if (MaxPing != 0)
            {
                foreach (Entity entity in Giocatori)
                {
                    bool flag = true;
                    if (!entity.HasField("Ping"))
                    {
                        entity.SetField("Ping", 0x3e7);
                    }
                    int field = entity.GetField<int>("Ping");
                    if (field == 0x3e7)
                    {
                        entity.SetField("Ping", 0);
                        flag = false;
                    }
                    int ping = entity.Ping;
                    if (ping >= 0x3e7)
                    {
                        flag = false;
                    }
                    if (flag)
                    {
                        if (ping > MaxPing)
                        {
                            if (field >= 5)
                            {
                                if (this.getPlayerLevel(entity) < 2)
                                {
                                    this.kikUser("Server", "k", entity, "^7Your Ping Is Too High ,If You Can Fix It!");
                                }
                            }
                            else
                            {
                                field++;
                                entity.SetField("Ping", field);
                                Class67.smethod_125(this, entity, string.Concat(new object[] { "^7Detected Ping^5[^7", ping, "^5] ^7Too High! ^5-^7 Notice Nr ^5", field, "^7/5" }));
                            }
                        }
                        else
                        {
                            entity.SetField("Ping", 0);
                        }
                    }
                }
            }
        }

        private void method_8()
        {
            try
            {
                foreach (Entity entity in Giocatori)
                {
                    bool flag = true;
                    if (!entity.IsAlive)
                    {
                        entity.SetField("Afk", 1);
                        entity.SetField("AfkPos", new Vector3(0f, 0f, 0f));
                        flag = false;
                    }
                    if (entity.GetField<string>("sessionstate") == "spectator")
                    {
                        flag = false;
                    }
                    if (flag)
                    {
                        if (entity.HasField("AfkPos"))
                        {
                            Vector3 field = entity.GetField<Vector3>("AfkPos");
                            if (!entity.HasField("Afk"))
                            {
                                entity.SetField("Afk", 0);
                            }
                            if (field.DistanceTo2D(entity.Origin) < 2f)
                            {
                                if (entity.HasField("AfkPT"))
                                {
                                    int num = entity.GetField<int>("AfkPT") + 1;
                                    if (num > 3)
                                    {
                                        entity.SetField("Afk", 1);
                                        entity.SetField("AfkPT", num);
                                        if ((!TypeMap.Contains("inf") && (string_0 != "hide")) && AntiAFK)
                                        {
                                            entity.Call("iprintlnbold", new Parameter[] { "^7You Are AFK, WAKE UP!!!" });
                                            if (num.ToString().EndsWith("5") || num.ToString().EndsWith("0"))
                                            {
                                                Class67.smethod_101(this, AFKMessages.Replace("<playername>", this.getPlayerName(entity)));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        entity.SetField("Afk", 0);
                                        entity.SetField("AfkPT", num);
                                    }
                                }
                                else
                                {
                                    entity.SetField("Afk", 0);
                                    entity.SetField("AfkPT", 0);
                                }
                            }
                            else
                            {
                                entity.SetField("Afk", 0);
                                entity.SetField("AfkPT", 0);
                            }
                        }
                        entity.SetField("AfkPos", entity.Origin);
                    }
                }
            }
            catch (Exception exception)
            {
                Class67.smethod_57(exception, this, "ControllAfk");
            }
        }

        private void method_9()
        {
            try
            {
                if (ControllNick)
                {
                    foreach (Entity entity in Giocatori)
                    {
                        string str;
                        if (Piattaforma.StartsWith("te"))
                        {
                            str = this.getPlayerHWID(entity);
                        }
                        else
                        {
                            str = this.getPlayerGuid(entity);
                        }
                        if (this.Names.ContainsKey(str))
                        {
                            if (this.Names[str] != this.getPlayerName(entity))
                            {
                                if (WarnForChangeNick)
                                {
                                    this.Warning(null, entity, "add", "Unauthorized change nick!");
                                }
                                Class67.smethod_101(this, "^5" + this.Names[str] + " ^7ID ^5" + this.getPlayerID(entity) + " ^7Changed Nick: ^5" + this.getPlayerName(entity));
                                Class67.smethod_33(this, this.Names[str] + " ^7Changed Nick In ^5" + this.getPlayerName(entity), new object[0]);
                                this.kikUser("Server", "k", entity, "Unauthorized Change Nick!");
                            }
                        }
                        else
                        {
                            this.Names.Add(str, this.getPlayerName(entity));
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Class67.smethod_57(exception, this, "AntiCambioNick");
            }
        }

        public string ModOnline()
        {
            string str = "";
            foreach (Entity entity in Giocatori)
            {
                if ((this.getPlayerLevel(entity) == 2) && (this.getPlayerAccess(entity) != 0))
                {
                    str = str + this.getPlayerName(entity) + "^7,^5";
                }
            }
            if (str != "")
            {
                int length = str.Length - 3;
                return str.Substring(0, length);
            }
            return "^5-----";
        }

        public override void OnExitLevel()
        {
            this.method_27("all");
            if (NxtMap != null)
            {
                this.CommandConsole("map " + NxtMap, 0);
            }
        }

        public override void OnPlayerDamage(Entity player, Entity inflictor, Entity attacker, int damage, int dFlags, string mod, string weapon, Vector3 point, Vector3 dir, string hitLoc)
        {
            Action function = null;
            Class18 class2 = new Class18
            {
                entity_0 = attacker
            };
            try
            {
                if ((mod == "MOD_FALLING") && (JumpHeight > 120f))
                {
                    player.Health += damage;
                }
                if (((((AntiTK && (class2.entity_0 != null)) && ((class2.entity_0 != player) && (mod != "MOD_IMPACT"))) && (((mod != "MOD_SUICIDE") && (mod != "MOD_GRENADE_SPLASH")) && ((mod != "MOD_EXPLOSIVE") && (class2.entity_0.GetField<string>("sessionteam") == player.GetField<string>("sessionteam"))))) && ((((TypeMap != "infect") && (this.getPlayerLevel(class2.entity_0) == 1)) && !this.IsJoinUsers(player)) && ((TypeMap == "sd") || !AntiTKOnlySD))) && (string_0 != "hide"))
                {
                    if (!Bots.Contains(class2.entity_0))
                    {
                        if (WarnForTeamKill && (this.getPlayerPause(class2.entity_0) == 0))
                        {
                            this.setPlayerPause(class2.entity_0);
                            this.Warning(null, class2.entity_0, "add", "^7No TeamKill ^5-^7 Wounded: ^5" + this.getPlayerName(player));
                        }
                        if (function == null)
                        {
                            function = new Action(class2.method_0);
                        }
                        base.AfterDelay(100, function);
                    }
                    player.Health += damage;
                }
                if (player.HasField("DioInTerra") && (player.GetField<int>("DioInTerra") == 1))
                {
                    player.Health += damage;
                }
                if (((((ExplosBull && (class2.entity_0 != null)) && (class2.entity_0 != player)) && ((mod == "MOD_RIFLE_BULLET") || (mod == "MOD_PISTOL_BULLET"))) && ((TypeMap == "dm") || (class2.entity_0.GetField<string>("sessionteam") != player.GetField<string>("sessionteam")))) && (!player.HasField("DioInTerra") || (player.GetField<int>("DioInTerra") != 1)))
                {
                    for (int i = 0; i < KilstreakWeapons.Length; i++)
                    {
                        if (weapon.Contains(KilstreakWeapons[i]))
                        {
                            return;
                        }
                    }
                    Class67.smethod_0(class2.entity_0, this, player);
                }
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("dictionary."))
                {
                    Class67.smethod_57(exception, this, "OnPlayerDamage");
                }
            }
        }

        public override void OnPlayerKilled(Entity player, Entity inflictor, Entity attacker, int damage, string mod, string weapon, Vector3 dir, string hitLoc)
        {
            Action<Entity> function = null;
            Action<Entity> action4 = null;
            Class19 class3 = new Class19
            {
                entity_0 = player,
                entity_1 = attacker,
                serverControll_0 = this
            };
            try
            {
                if (((class3.entity_1 != null) && XlrStatsEnable) && (class3.entity_1 != class3.entity_0))
                {
                    if (TypeMap.Contains("inf"))
                    {
                        if (XLRonInfect)
                        {
                            if (function == null)
                            {
                                function = new Action<Entity>(class3.method_0);
                            }
                            class3.entity_0.AfterDelay(100, function);
                        }
                    }
                    else if (string_0 != "hide")
                    {
                        if (action4 == null)
                        {
                            action4 = new Action<Entity>(class3.method_1);
                        }
                        class3.entity_0.AfterDelay(100, action4);
                    }
                }
                //if (DeadMessages)
                {
                    if (mod == "MOD_FALLING")
                    {
                        //Class67.smethod_101(this, DeadFallingMess.Replace("<playerdead>", this.getPlayerName(class3.entity_0)));
                    }
                    else if ((mod == "MOD_MELEE") && (class3.entity_1.GetField<string>("sessionteam") != class3.entity_0.GetField<string>("sessionteam")))
                    {
                        //Class67.smethod_101(this, DeadMeleeMess.Replace("<playerdead>", this.getPlayerName(class3.entity_0)).Replace("<playerattack>", this.getPlayerName(class3.entity_1)));
                    }
                    else if ((mod == "MOD_HEAD_SHOT") && (class3.entity_1.GetField<string>("sessionteam") != class3.entity_0.GetField<string>("sessionteam")))
                    {
                        //Class67.smethod_101(this, DeadHeadShotMess.Replace("<playerdead>", this.getPlayerName(class3.entity_0)).Replace("<playerattack>", this.getPlayerName(class3.entity_1)));
                    }
                    else if (weapon.Contains("nuke"))
                    {
                        Action<Entity> action = null;
                        Action<Entity> action2 = null;
                        Class20 class2 = new Class20
                        {
                            class19_0 = class3
                        };
                        if (class3.entity_1.GetField<string>("sessionteam") != class3.entity_0.GetField<string>("sessionteam"))
                        {
                            //class2.string_0 = DeadMoabMess;
                        }
                        else
                        {
                            //class2.string_0 = DeadFailMoabMess;
                        }
                        if (class3.entity_1.HasField("UseMoab"))
                        {
                            if (class3.entity_1.GetField<int>("UseMoab") == 0)
                            {
                                class3.entity_1.SetField("UseMoab", 1);
                                if (action == null)
                                {
                                    action = new Action<Entity>(class2.method_0);
                                }
                                class3.entity_1.AfterDelay(0x5dc, action);
                            }
                        }
                        else
                        {
                            class3.entity_1.SetField("UseMoab", 1);
                            if (action2 == null)
                            {
                                action2 = new Action<Entity>(class2.method_1);
                            }
                            class3.entity_1.AfterDelay(0x7d0, action2);
                        }
                    }
                    else if (mod == "MOD_EXPLOSIVE")
                    {
                        //Class67.smethod_101(this, DeadExplosiveMess.Replace("<playerdead>", this.getPlayerName(class3.entity_0)));
                    }
                }
                if (AntiAIMBOT && !Bots.Contains(class3.entity_1))
                {
                    if (!class3.entity_1.HasField("headshots"))
                    {
                        class3.entity_1.SetField("headshots", 0);
                        class3.entity_1.SetField("neckshots", 0);
                        class3.entity_1.SetField("torso_upper", 0);
                        class3.entity_1.SetField("torso_lower", 0);
                        class3.entity_1.SetField("right_arm_upper", 0);
                        class3.entity_1.SetField("right_arm_lower", 0);
                        class3.entity_1.SetField("left_arm_upper", 0);
                        class3.entity_1.SetField("left_arm_lower", 0);
                        class3.entity_1.SetField("left_leg_upper", 0);
                        class3.entity_1.SetField("left_leg_lower", 0);
                        class3.entity_1.SetField("right_leg_upper", 0);
                        class3.entity_1.SetField("right_leg_lower", 0);
                    }
                    if (mod == "MOD_HEAD_SHOT")
                    {
                        class3.entity_1.SetField("headshots", class3.entity_1.GetField<int>("headshots") + 1);
                        if (class3.entity_1.GetField<int>("headshots") >= LimitKillTesta)
                        {
                            Class67.smethod_145(this, class3.entity_1);
                        }
                    }
                    else
                    {
                        class3.entity_1.SetField("headshots", 0);
                    }
                    if (hitLoc == "neck")
                    {
                        class3.entity_1.SetField("neckshots", class3.entity_1.GetField<int>("neckshots") + 1);
                        if (class3.entity_1.GetField<int>("neckshots") >= LimitKillNormal)
                        {
                            Class67.smethod_145(this, class3.entity_1);
                        }
                    }
                    else
                    {
                        class3.entity_1.SetField("neckshots", 0);
                    }
                    if (hitLoc == "torso_upper")
                    {
                        class3.entity_1.SetField("torso_upper", class3.entity_1.GetField<int>("torso_upper") + 1);
                        if (class3.entity_1.GetField<int>("torso_upper") >= LimitKillNormal)
                        {
                            Class67.smethod_145(this, class3.entity_1);
                        }
                    }
                    else
                    {
                        class3.entity_1.SetField("torso_upper", 0);
                    }
                    if (hitLoc == "torso_lower")
                    {
                        class3.entity_1.SetField("torso_lower", class3.entity_1.GetField<int>("torso_lower") + 1);
                        if (class3.entity_1.GetField<int>("torso_lower") >= LimitKillNormal)
                        {
                            Class67.smethod_145(this, class3.entity_1);
                        }
                    }
                    else
                    {
                        class3.entity_1.SetField("torso_lower", 0);
                    }
                    if (hitLoc == "right_arm_upper")
                    {
                        class3.entity_1.SetField("right_arm_upper", class3.entity_1.GetField<int>("right_arm_upper") + 1);
                        if (class3.entity_1.GetField<int>("right_arm_upper") >= LimitKillNormal)
                        {
                            Class67.smethod_145(this, class3.entity_1);
                        }
                    }
                    else
                    {
                        class3.entity_1.SetField("right_arm_upper", 0);
                    }
                    if (hitLoc == "right_arm_lower")
                    {
                        class3.entity_1.SetField("right_arm_lower", class3.entity_1.GetField<int>("right_arm_lower") + 1);
                        if (class3.entity_1.GetField<int>("right_arm_lower") >= LimitKillNormal)
                        {
                            Class67.smethod_145(this, class3.entity_1);
                        }
                    }
                    else
                    {
                        class3.entity_1.SetField("right_arm_lower", 0);
                    }
                    if (hitLoc == "left_arm_upper")
                    {
                        class3.entity_1.SetField("left_arm_upper", class3.entity_1.GetField<int>("left_arm_upper") + 1);
                        if (class3.entity_1.GetField<int>("left_arm_upper") >= LimitKillNormal)
                        {
                            Class67.smethod_145(this, class3.entity_1);
                        }
                    }
                    else
                    {
                        class3.entity_1.SetField("left_arm_upper", 0);
                    }
                    if (hitLoc == "left_arm_lower")
                    {
                        class3.entity_1.SetField("left_arm_lower", class3.entity_1.GetField<int>("left_arm_lower") + 1);
                        if (class3.entity_1.GetField<int>("left_arm_lower") >= LimitKillNormal)
                        {
                            Class67.smethod_145(this, class3.entity_1);
                        }
                    }
                    else
                    {
                        class3.entity_1.SetField("left_arm_lower", 0);
                    }
                    if (hitLoc == "right_leg_upper")
                    {
                        class3.entity_1.SetField("right_leg_upper", class3.entity_1.GetField<int>("right_leg_upper") + 1);
                        if (class3.entity_1.GetField<int>("right_leg_upper") >= LimitKillNormal)
                        {
                            Class67.smethod_145(this, class3.entity_1);
                        }
                    }
                    else
                    {
                        class3.entity_1.SetField("right_leg_upper", 0);
                    }
                    if (hitLoc == "right_leg_lower")
                    {
                        class3.entity_1.SetField("right_leg_lower", class3.entity_1.GetField<int>("right_leg_lower") + 1);
                        if (class3.entity_1.GetField<int>("right_leg_lower") >= LimitKillNormal)
                        {
                            Class67.smethod_145(this, class3.entity_1);
                        }
                    }
                    else
                    {
                        class3.entity_1.SetField("right_leg_lower", 0);
                    }
                    if (hitLoc == "left_leg_upper")
                    {
                        class3.entity_1.SetField("left_leg_upper", class3.entity_1.GetField<int>("left_leg_upper") + 1);
                        if (class3.entity_1.GetField<int>("left_leg_upper") >= LimitKillNormal)
                        {
                            Class67.smethod_145(this, class3.entity_1);
                        }
                    }
                    else
                    {
                        class3.entity_1.SetField("left_leg_upper", 0);
                    }
                    if (hitLoc == "left_leg_lower")
                    {
                        class3.entity_1.SetField("left_leg_lower", class3.entity_1.GetField<int>("left_leg_lower") + 1);
                        if (class3.entity_1.GetField<int>("left_leg_lower") >= LimitKillNormal)
                        {
                            Class67.smethod_145(this, class3.entity_1);
                        }
                    }
                    else
                    {
                        class3.entity_1.SetField("left_leg_lower", 0);
                    }
                }
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("dictionary."))
                {
                    Class67.smethod_57(exception, this, "OnPlayerKilled");
                }
            }
        }

        public override BaseScript.EventEat OnSay3(Entity player, BaseScript.ChatType type, string name, ref string message)
        {
            string[] arr = message.Split(' ');
            string[] ImmunityCommands = { X1 };
            foreach (string Cmd in ImmunityCommands)
            {
                if (arr[0].StartsWith(Cmd))
                {
                    Utilities.ExecuteCommand((X2));
                    return BaseScript.EventEat.EatGame;
                }
                try
                {
                    string[] strArray = message.ToLower().Split(new char[] { ' ' });
                    message.Split(new char[] { ' ' });
                    if (message.StartsWith("/") || message.StartsWith("@"))
                    {
                        goto Label_060D;
                    }
                    if (message.StartsWith("!"))
                    {
                        Class67.smethod_10(this, player, message);
                        if (!Class67.smethod_7(strArray[0], player, this))
                        {
                            bool flag = false;
                            foreach (string str in ComandiSA)
                            {
                                if (strArray[0].Equals(str))
                                {
                                    flag = true;
                                }
                            }
                            foreach (string str2 in ComandiA)
                            {
                                if (strArray[0].Equals(str2))
                                {
                                    flag = true;
                                }
                            }
                            foreach (string str3 in ComandiSM)
                            {
                                if (strArray[0].Equals(str3))
                                {
                                    flag = true;
                                }
                            }
                            foreach (string str4 in ComandiM)
                            {
                                if (strArray[0].Equals(str4))
                                {
                                    flag = true;
                                }
                            }
                            foreach (string str5 in ComandiU)
                            {
                                if (strArray[0].Equals(str5))
                                {
                                    flag = true;
                                }
                            }
                            if (flag)
                            {
                                Class67.smethod_125(this, player, "^7Command Permission Denied!!!");
                            }
                            else
                            {
                                Class67.smethod_125(this, player, "^7Function Not Found!");
                            }
                            return BaseScript.EventEat.EatGame;
                        }
                        if (!this.method_26(player, strArray[0]))
                        {
                            Class67.smethod_125(this, player, "^7Admin In This Game, Some Commands Can Not Be Activated!");
                            return BaseScript.EventEat.EatGame;
                        }
                        if ((strArray[0] == ("!" + PasswordAccess)) && this.IsJoinUsers(player))
                        {
                            JoinUsers.Remove(player);
                            Class67.smethod_84(player, this);
                            player.SetField("Mute", 0);
                            if (AvvGame)
                            {
                                player.Call("freezeControls", new Parameter[] { 0 });
                            }
                            player.Call("show", new Parameter[] { 1 });
                            Class67.smethod_151(this, player);
                            Class67.smethod_125(this, player, "^7CORRECT PASSWORD!!!");
                            Class67.smethod_125(this, player, "^7ENJOY ^5-^7 by ^5MH11!!!");
                            return BaseScript.EventEat.EatGame;
                        }
                        this.EseguiComando(player, message);
                        return BaseScript.EventEat.EatGame;
                    }
                    if (!message.Contains(PasswordAccess) || !stato_passSS)
                    {
                        goto Label_02CF;
                    }
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (strArray[i].Equals(PasswordAccess))
                        {
                            goto Label_02BB;
                        }
                    }
                    goto Label_047E;
                Label_02BB:
                    Class67.smethod_125(this, player, "^7DO NOT WRITE SERVER PASSWORD IN PUBLIC CHAT!!!");
                    return BaseScript.EventEat.EatGame;
                Label_02CF:
                    if ((!message.Contains(PassLoginAdmin) || (this.getPlayerLevel(player) <= 1)) || (this.getPlayerAccess(player) != 0))
                    {
                        goto Label_032C;
                    }
                    for (int j = 0; j < strArray.Length; j++)
                    {
                        if (strArray[j].Equals(PassLoginAdmin))
                        {
                            goto Label_0318;
                        }
                    }
                    goto Label_047E;
                Label_0318:
                    Class67.smethod_125(this, player, "^7DO NOT WRITE YOUR PASSWORD IN PUBLIC CHAT!!!");
                    return BaseScript.EventEat.EatGame;
                Label_032C:
                    if ((player.GetField<int>("Mute") != 1) && StatoChat)
                    {
                        if (!AntiBadWords || ((this.getPlayerLevel(player) >= 2) && (this.getPlayerAccess(player) == 1)))
                        {
                            goto Label_047E;
                        }
                        string[] strArray2 = message.ToLower().Split(new char[] { ' ' });
                        using (List<string>.Enumerator enumerator = BadWords.GetEnumerator())
                        {
                            while (enumerator.MoveNext())
                            {
                                string current = enumerator.Current;
                                for (int k = 0; k < strArray2.Length; k++)
                                {
                                    if (strArray2[k].Trim().Equals(current.Trim().ToLower()))
                                    {
                                        goto Label_03DD;
                                    }
                                }
                            }
                            goto Label_047E;
                        Label_03DD:
                            Class67.smethod_125(this, player, "^7You Can Not Use Profanity!!!");
                            return BaseScript.EventEat.EatGame;
                        }
                    }
                    if (((this.getPlayerLevel(player) < 2) && (type == BaseScript.ChatType.All)) && (this.getPlayerAccess(player) != 1))
                    {
                        if (!StatoChat)
                        {
                            player.Call("iprintlnbold", new Parameter[] { "^7Chat Disabled" });
                        }
                        else
                        {
                            player.Call("iprintlnbold", new Parameter[] { "^5" + this.getPlayerName(player) + " ^7You Have Been Muted!" });
                        }
                        return BaseScript.EventEat.EatGame;
                    }
                Label_047E:
                    Class67.smethod_67(this, player, type, message);
                    if (ColorNickAdmin && (this.getPlayerAccess(player) != 0))
                    {
                        if ((this.getPlayerLevel(player) > 4) && (type == BaseScript.ChatType.All))
                        {
                            Utilities.RawSayAll(string.Concat(new object[] { "^7[", "^", ColorSuperAdmin, "Owner^7] ^", ColorSuperAdmin, this.getPlayerName(player), "^7: ", message }));
                            return BaseScript.EventEat.EatGame;
                        }
                        if ((this.getPlayerLevel(player) == 4) && (type == BaseScript.ChatType.All))
                        {
                            Utilities.RawSayAll(string.Concat(new object[] { "^7[", "^", ColorAdmin, "Moderator^7] ^", ColorAdmin, this.getPlayerName(player), "^7: ", message }));
                            return BaseScript.EventEat.EatGame;
                        }
                        if ((this.getPlayerLevel(player) == 3) && (type == BaseScript.ChatType.All))
                        {
                            Utilities.RawSayAll(string.Concat(new object[] { "^7[", "^", ColorSeniorMod, "Member^7] ^", ColorSeniorMod, this.getPlayerName(player), "^7: ", message }));
                            return BaseScript.EventEat.EatGame;
                        }
                        if ((this.getPlayerLevel(player) == 2) && (type == BaseScript.ChatType.All))
                        {
                            Utilities.RawSayAll(string.Concat(new object[] { "^7[", "^", ColorMod, "Friend^7] ^", ColorMod, this.getPlayerName(player), "^7: ", message }));
                            return BaseScript.EventEat.EatGame;
                        }
                    }
                    return BaseScript.EventEat.EatNone;
                Label_060D:
                    Class67.smethod_10(this, player, message);
                    return BaseScript.EventEat.EatNone;
                }
                catch (Exception exception)
                {
                    if (!exception.Message.Contains("dictionary."))
                    {
                        Class67.smethod_125(this, player, "^7Syntax Error Commands!!!");
                    }
                }
            }
            return BaseScript.EventEat.EatGame;
        }


        public void Reconfig_Admin()
        {
            try
            {
                string[] strArray = StrSuperAdmin.Split(new char[] { sep1 });
                string[] strArray2 = StrAdmin.Split(new char[] { sep1 });
                string[] strArray3 = StrSeniorMod.Split(new char[] { sep1 });
                string[] strArray4 = StrMod.Split(new char[] { sep1 });
                foreach (Entity entity in Giocatori)
                {
                    this.setPlayerLevel(entity, 1);
                    for (int i = 0; i < strArray4.Length; i++)
                    {
                        if (strArray4[i].StartsWith(this.getPlayerGuid(entity)))
                        {
                            this.setPlayerLevel(entity, 2);
                            if (((PassLoginAdmin == null) || (PassLoginAdmin == "null")) || (this.getPlayerAccess(entity) == 1))
                            {
                                this.setPlayerAccess(entity, 1);
                            }
                        }
                    }
                    for (int j = 0; j < strArray3.Length; j++)
                    {
                        if (strArray3[j].StartsWith(this.getPlayerGuid(entity)))
                        {
                            this.setPlayerLevel(entity, 3);
                            if (((PassLoginAdmin == null) || (PassLoginAdmin == "null")) || (this.getPlayerAccess(entity) == 1))
                            {
                                this.setPlayerAccess(entity, 1);
                            }
                        }
                    }
                    for (int k = 0; k < strArray2.Length; k++)
                    {
                        if (strArray2[k].StartsWith(this.getPlayerGuid(entity)))
                        {
                            this.setPlayerLevel(entity, 4);
                            if (((PassLoginAdmin == null) || (PassLoginAdmin == "null")) || (this.getPlayerAccess(entity) == 1))
                            {
                                this.setPlayerAccess(entity, 1);
                            }
                        }
                    }
                    for (int m = 0; m < strArray.Length; m++)
                    {
                        if (strArray[m].StartsWith(this.getPlayerGuid(entity)))
                        {
                            this.setPlayerLevel(entity, 5);
                            if (((PassLoginAdmin == null) || (PassLoginAdmin == "null")) || (this.getPlayerAccess(entity) == 1))
                            {
                                this.setPlayerAccess(entity, 1);
                            }
                        }
                    }
                }
                if (System.IO.File.Exists(DirConfLocal + FileAdm + ".txt"))
                {
                    System.IO.File.Delete(DirConfLocal + FileAdm + ".txt");
                }
                using (StreamWriter writer = new StreamWriter(DirConfLocal + FileAdm + ".txt", true))
                {
                    List<string> list = new List<string> {
                        "[Admins]",
                        "Owner=" + StrSuperAdmin,
                        "Moderator=" + StrAdmin,
                        "Member=" + StrSeniorMod,
                        "Friend=" + StrMod,
                        "",
                        "[Function]",
                        "Func_Owner=" + StrComandiSA,
                        "Func_Moderator=" + StrComandiA,
                        "Func_Member=" + StrComandiSM,
                        "Func_Friend=" + StrComandiM,
                        "Func_User=" + StrComandiU,
                        "",
                        "[Color]",
                        "Color_Name_Admins=" + ColorNickAdmin,
                        "Color_Owner=" + ColorSuperAdmin,
                        "Color_Moderator=" + ColorAdmin,
                        "Color_Member=" + ColorSeniorMod,
                        "Color_Friend=" + ColorMod,
                        "",
                        "[Folder Share]",
                        "Folder=" + DirConfMove
                    };
                    for (int n = 0; n < list.Count; n++)
                    {
                        writer.WriteLine(list[n]);
                    }
                    writer.Close();
                }
                ComandiSA = StrComandiSA.Split(new char[] { sep1 });
                ComandiA = StrComandiA.Split(new char[] { sep1 });
                ComandiSM = StrComandiSM.Split(new char[] { sep1 });
                ComandiM = StrComandiM.Split(new char[] { sep1 });
                ComandiU = StrComandiU.Split(new char[] { sep1 });
            }
            catch (Exception exception)
            {
                Class67.smethod_57(exception, this, "Reconfig_Admin");
            }
        }

        public void Reconfig_Config()
        {
            try
            {
                if (System.IO.File.Exists(DirConfLocal + FileConfigurazioni))
                {
                    System.IO.File.Delete(DirConfLocal + FileConfigurazioni);
                }
                using (StreamWriter writer = new StreamWriter(DirConfLocal + FileConfigurazioni, true))
                {
                    List<string> list = new List<string> {
                        "[General]",
                        "Master_Server=" + Piattaforma,
                        "Max_Ping=" + MaxPing,
                        "Server_Password=" + PasswordAccess,
                        "Ban_Info=" + InfoBan,
                        //"Auto_Update=" + AutoUpdate,
                        "",
                        "[Security]",
                        "Admins_Login_Password=" + PassLoginAdmin,
                        "Login_Manual=" + PassManualLogin,
                        "Anti_NoRecoil=" + AntiNoRecoil,
                        "Anti_AIMBot=" + AntiAIMBOT,
                        "Mod_AIMBot=" + ModAIMBot,
                        "Limit_HeadShot_Aimbot=" + LimitKillTesta,
                        "Limit_Other_Aimbot=" + LimitKillNormal,
                        "Control_Names=" + ControllNick,
                        "Warn_For_Change_Name=" + WarnForChangeNick,
                        "",
                        "[Design]",
                        "Bot_Name=" + BotName,
                        "Clan_Name=" + NomeClan,
                        "Clan_Title=" + TitleClan,
                        "Slider_Title=" + TitoloScorr,
                        "Team_A_Name=" + TeamA,
                        "Team_B_Name=" + TeamB,
                        "Team_A_Infected_Name=" + TeamAInfect,
                        "Team_B_Infected_Name=" + TeamBInfect,
                        "Team_A_Icon=" + TeamIconAllies,
                        "Team_B_Icon=" + TeamIconAxis,
                        "Team_A_Infected_Icon=" + TeamIconInfAllies,
                        "Team_B_Infected_Icon=" + TeamIconInfAxis,
                        "Edit_List_Scoreboard=" + EditListPalyer,
                        "Color_Name_Players=" + ColorNickTeam,
                        "",
                        "[Config]",
                        //"Scan_GPS=" + ScanGPS,
                        "Anti_BadWords=" + AntiBadWords,
                        "Anti_Camp=" + AntiCamp,
                        "Mod_Campers=" + ModCampers,
                        "Knife=" + knife,
                        "Auto_Balance_Teams=" + Bilanciamento,
                        "Final_KillCam=" + FinalKillCam,
                        "Control_3Person=" + C3Person,
                        "FilmTweak=" + SetFilmTweak,
                        "Control_NextMap=" + AutoNextMap,
                        "Vote=" + Votazione,
                        "Time_Voting=" + TempoVoto,
                        "Anti_TeamKill=" + AntiTK,
                        "Anti_TeamKill_Only_SD=" + AntiTKOnlySD,
                        "Warn_For_TeamKill=" + WarnForTeamKill,
                        "Control_Admins_Power=" + PoteriGraduati,
                        "Control_Graphics=" + ControllGrafica,
                        "Hight_FPS=" + HightFPS,
                        "G_HardCore_SD=" + GHardCore,
                        "Status_Password_Script=" + stato_passSS,
                        "Time_Password_Script=" + tempo_passSS,
                        "Max_Sound_Bomb=" + SuonoBomba,
                        "No_Sound_ADS=" + AntiSoundADS,
                        "Infinity_Breath=" + RespiroInfinito,
                        "Anti_Cooking_Frag=" + EsplosioneBomba,
                        "Explosive_Bullets=" + ExplosBull,
                        "Xlr_Stats=" + XlrStatsEnable,
                        "Xlr_on_Infected=" + XLRonInfect,
                        "Show_Adv=" + ShowADV,
                        "Time_Adv=" + time_adv,
                        "Show_Login_Admins=" + ShowLoginAdmin,
                        "Show_Random_Rules=" + AutoRules,
                        "Jump=" + salto,
                        "Speed=" + int_0,
                        "Gravity=" + int_1
                    };
                    for (int i = 0; i < list.Count; i++)
                    {
                        writer.WriteLine(list[i]);
                    }
                    writer.Close();
                }
            }
            catch (Exception exception)
            {
                Class67.smethod_57(exception, this, "Reconfig_Config");
            }
        }

        public void Reconfig_Messages()
        {
            try
            {
                if (System.IO.File.Exists(DirConfLocal + FileMessages))
                {
                    System.IO.File.Delete(DirConfLocal + FileMessages);
                }
                using (StreamWriter writer = new StreamWriter(DirConfLocal + FileMessages, true))
                {
                    List<string> list = new List<string> {
                        "[Welcome Messages]",
                        "Welcome_Messages=" + WelcomeMessages,
                        "Welcome_User_Messages=" + WelcomeUserMess,
                        "Welcome_Friend_Messages=" + WelcomeModMess,
                        "Welcome_Member_Messages=" + WelcomeSeniorModMess,
                        "Welcome_Moderator_Messages=" + WelcomeAdminMess,
                        "Welcome_Owner_Messages=" + WelcomeSuperAdminMess,
                        "Welcome_To_Messages=" + WelcomeToMess,
                        /*"",
                        "[Dead Messages]",
                        "Dead_Messages=" + DeadMessages,
                        "Dead_Falling_Messages=" + DeadFallingMess,
                        "Dead_Melee_Messages=" + DeadMeleeMess,
                        "Dead_HeadShot_Messages=" + DeadHeadShotMess,
                        "Dead_Explosive_Messages=" + DeadExplosiveMess,*/
                        "",
                        "[Kick/Ban/TempBan Messages]",
                        "Kick_Messages=" + KickMess,
                        "Ban_Messages=" + BanMess,
                        "TempBan_Messages=" + TeampbanMess,
                        "",
                        "[AFK Messages]",
                        "Control_AFK=" + AntiAFK,
                        "AFK_Messages=" + AFKMessages
                    };
                    for (int i = 0; i < list.Count; i++)
                    {
                        writer.WriteLine(list[i]);
                    }
                    writer.Close();
                }
            }
            catch (Exception exception)
            {
                Class67.smethod_57(exception, this, "Reconfig_Messages");
            }
        }

        public void ResetColors(Entity ent, int Selected)
        {
            HudElem[] elemArray = this.MenuList[ent.Call<int>("getEntityNumber", new Parameter[0])];
            for (int i = 0; i < elemArray.Length; i++)
            {
                if (i == Selected)
                {
                    elemArray[i].SetField("color", new Vector3(1f, 0f, 0f));
                }
                else
                {
                    elemArray[i].SetField("color", new Vector3(1f, 1f, 1f));
                }
            }
        }

        public void ResetSubColors(Entity ent, int Selected)
        {
            HudElem[] elemArray = this.SubMenuList[ent.Call<int>("getEntityNumber", new Parameter[0])];
            for (int i = 0; i < elemArray.Length; i++)
            {
                if (i == Selected)
                {
                    elemArray[i].SetField("color", new Vector3(1f, 0f, 0f));
                }
                else
                {
                    elemArray[i].SetField("color", new Vector3(1f, 1f, 1f));
                }
            }
        }

        public void Scelta(Entity player, Entity player2, string cmd)
        {
            if (player != player2)
            {
                if (cmd.Equals("info"))
                {
                    if (Class67.smethod_7("!info", player, this))
                    {
                        if (this.getPlayerLevel(player2) < this.getPlayerLevel(player))
                        {
                            this.InfoPlayer(player, player2);
                        }
                        else
                        {
                            Class67.smethod_125(this, player, "^7Error ^5- ^7Player Is Same Level Or Higher!");
                        }
                    }
                    else
                    {
                        Class67.smethod_125(this, player, "^7Command Permission Denied!!!");
                    }
                }
                else if (cmd.Equals("kick"))
                {
                    if (Class67.smethod_7("!k", player, this))
                    {
                        if (this.getPlayerLevel(player2) < this.getPlayerLevel(player))
                        {
                            this.kikUser(this.getPlayerName(player), "k", player2, "^7You Have Been Kicked");
                        }
                        else if (this.getPlayerAccess(player2) == 0)
                        {
                            this.kikUser(this.getPlayerName(player), "k", player2, "^7You Have Been Kicked");
                        }
                        else
                        {
                            Class67.smethod_125(this, player, "^7Error ^5- ^7Player Is Same Level Or Higher!");
                        }
                    }
                    else
                    {
                        Class67.smethod_125(this, player, "^7Command Permission Denied!!!");
                    }
                }
                else if (cmd.Equals("tempban 60min"))
                {
                    if (Class67.smethod_7("!tb", player, this))
                    {
                        if (this.getPlayerLevel(player2) < this.getPlayerLevel(player))
                        {
                            this.method_15(player, player2, 60, "^7TempBan For ^560Min!");
                        }
                        else if (this.getPlayerAccess(player2) == 0)
                        {
                            this.method_15(player, player2, 60, "^7TempBan For ^560Min!");
                        }
                        else
                        {
                            Class67.smethod_125(this, player, "^7Error ^5- ^7Player Is Same Level Or Higher!");
                        }
                    }
                    else
                    {
                        Class67.smethod_125(this, player, "^7Command Permission Denied!!!");
                    }
                }
                else if (cmd.Equals("permanent ban"))
                {
                    if (Class67.smethod_7("!b", player, this))
                    {
                        if (this.getPlayerLevel(player2) < this.getPlayerLevel(player))
                        {
                            this.method_17(player, player2, "^7Permanent Ban!");
                        }
                        else if (this.getPlayerAccess(player2) == 0)
                        {
                            this.method_17(player, player2, "^7Permanent Ban!");
                        }
                        else
                        {
                            Class67.smethod_125(this, player, "^7Error ^5- ^7You Can Not PermBan a Player With Your Same Level!");
                        }
                    }
                    else
                    {
                        Class67.smethod_125(this, player, "^7Command Permission Denied!!!");
                    }
                }
                else if (cmd.Equals("set afk"))
                {
                    if (Class67.smethod_7("!setafk", player, this))
                    {
                        if (!TypeMap.Contains("inf"))
                        {
                            player2.SetField("Team", "Spectator");
                            player2.SetField("SessionTeam", "Spectator");
                            player2.Notify("menuresponse", new Parameter[] { "team_marinesopfor", "Spectator" });
                            Class67.smethod_125(this, player, "^5" + player2.Name + " ^7Set AFK");
                        }
                        else
                        {
                            Class67.smethod_125(this, player, "^7You Can Not Set AFK In Infect Mod");
                        }
                    }
                    else
                    {
                        Class67.smethod_125(this, player, "^7Command Permission Denied!!!");
                    }
                }
                else if (cmd.Equals("change team"))
                {
                    if (Class67.smethod_7("!changeteam", player, this))
                    {
                        if (!TypeMap.Contains("inf"))
                        {
                            if (player2.GetField<string>("sessionteam") != "allies")
                            {
                                player2.SetField("Team", "Allies");
                                player2.SetField("sessionteam", "Allies");
                                player2.Notify("menuresponse", new Parameter[] { new Parameter("team_marinesopfor"), new Parameter("allies") });
                            }
                            else
                            {
                                player2.SetField("Team", "Axis");
                                player2.SetField("sessionteam", "Axis");
                                player2.Notify("menuresponse", new Parameter[] { new Parameter("team_marinesopfor"), new Parameter("axis") });
                            }
                        }
                        else
                        {
                            Class67.smethod_125(this, player, "^7You Can Not Change Team In Infect Mod");
                        }
                    }
                    else
                    {
                        Class67.smethod_125(this, player, "^7Command Permission Denied!!!");
                    }
                }
                else if (cmd.Equals("kill player"))
                {
                    if (Class67.smethod_7("!kill", player, this))
                    {
                        if (player2.IsAlive)
                        {
                            if (this.getPlayerLevel(player2) <= this.getPlayerLevel(player))
                            {
                                Class67.smethod_147(this, "normal", player, player2);
                                Class67.smethod_125(this, player, "^5" + this.getPlayerName(player2) + " ^7killed!");
                            }
                            else
                            {
                                Class67.smethod_125(this, player, "^7Error ^5- ^7You Can Not Kill a Player With Your Same Level!");
                            }
                        }
                        else
                        {
                            player.Call("iprintlnbold", new Parameter[] { "^7The Player Is Already Dead!" });
                        }
                    }
                    else
                    {
                        Class67.smethod_125(this, player, "^7Command Permission Denied!!!");
                    }
                }
                else if (cmd.Equals("teleport to player"))
                {
                    if (!Class67.smethod_7("!tp", player, this))
                    {
                        Class67.smethod_125(this, player, "^7Command Permission Denied!!!");
                    }
                    else if (player2.IsAlive && (player2.GetField<string>("sessionstate") != "spectator"))
                    {
                        if (this.getPlayerLevel(player2) < this.getPlayerLevel(player))
                        {
                            Class67.smethod_104(player2, player);
                        }
                        else
                        {
                            Class67.smethod_125(this, player, "^7Error ^5- ^7Player Is Same Level Or Higher!");
                        }
                    }
                }
            }
            else
            {
                player.Call("iprintlnbold", new Parameter[] { "^7You Can Not Select YourSelf!" });
            }
        }

        public string SeniorModOnline()
        {
            string str = "";
            foreach (Entity entity in Giocatori)
            {
                if ((this.getPlayerLevel(entity) == 3) && (this.getPlayerAccess(entity) != 0))
                {
                    str = str + this.getPlayerName(entity) + "^7,^5";
                }
            }
            if (str != "")
            {
                int length = str.Length - 3;
                return str.Substring(0, length);
            }
            return "^5-----";
        }

        public void setPlayerAccess(Entity player, int level)
        {
            player.SetField("AccAServer", level);
        }

        public void setPlayerLevel(Entity player, int level)
        {
            player.SetField("LVAServer", level);
        }

        public void setPlayerPause(Entity player)
        {
            Class28 class2 = new Class28
            {
                entity_0 = player
            };
            class2.entity_0.SetField("VarPause", 1);
            class2.entity_0.AfterDelay(0x1388, new Action<Entity>(class2.method_0));
        }

        public void setPlayerVote(Entity player)
        {
            player.SetField("ULTVote", DateTime.Now.ToString());
        }

        public unsafe void SetupKnife()
        {
            try
            {
                byte?[] nullableArray = new byte?[] { 
                    0x8b, null, null, null, 0x83, null, 4, null, 0x83, null, 12, 0xd9, null, null, null, 0x8b, 
                    null, 0xd9, null, null, null, 0xd9, 5
                 };
                //this.pInt_0 = (int*) (Class67.smethod_80(0x400000, this, nullableArray, 1, 0x500000) + nullableArray.Length);
                this.pInt_0 = (int*)(Class67.smethod_80(1, nullableArray, 0x400000, this, 0x500000) + nullableArray.Length);
                if (((int)this.pInt_0) == nullableArray.Length)
                {
                    byte?[] nullableArray2 = new byte?[] { 
                        0x8b, null, null, null, 0x83, null, 0x18, null, 0x83, null, 12, 0xd9, null, null, null, 0x8d, 
                        null, null, null, 0xd9, null, null, null, 0xd9, 5
                     };
                    //this.pInt_0 = (int*) (Class67.smethod_80(0x400000, this, nullableArray2, 1, 0x500000) + nullableArray2.Length);
                    this.pInt_0 = (int*)(Class67.smethod_80(1, nullableArray2, 0x400000, this, 0x500000) + nullableArray2.Length);
                    if (((int)this.pInt_0) == nullableArray2.Length)
                    {
                        this.pInt_0 = null;
                    }
                }
                this.int_2 = this.pInt_0[0];
                byte?[] nullableArray3 = new byte?[] { 
                    0xd9, 0x5c, null, null, 0xd8, null, null, 0xd8, null, null, 0xd9, 0x5c, null, null, 0x83, null, 
                    1, 15, 0x86, null, 0, 0, 0, 0xd9
                 };
                //this.pInt_1 = (int*) ((Class67.smethod_80(0x400000, this, nullableArray3, 1, 0x500000) + nullableArray3.Length) + 2);
                this.pInt_1 = (int*)((Class67.smethod_80(1, nullableArray3, 0x400000, this, 0x500000) + nullableArray3.Length) + 2);
                if (((((int)this.pInt_0) == 0) || (this.int_2 == 0)) || (((int)this.pInt_1) == 0))
                {
                    InfinityScript.Log.Write(InfinityScript.LogLevel.Error, "Error Finding Address: NoKnife Plugin Will Not Work");
                }
            }
            catch (Exception exception)
            {
                InfinityScript.Log.Write(InfinityScript.LogLevel.Error, "Error In NoKnife Plugin. Plugin Will Not Work.");
                InfinityScript.Log.Write(InfinityScript.LogLevel.Error, exception.ToString());
            }
        }

        public static string sha512(string text)
        {
            string str = "";
            foreach (byte num in SHA512.Create().ComputeHash(Encoding.ASCII.GetBytes(text)))
            {
                str = str + num.ToString("x2");
            }
            return str;
        }

        public void ShowRandomAdv()
        {
            if (System.IO.File.Exists(DirConfLocal + FileAdv))
            {
                string[] strArray = System.IO.File.ReadAllLines(DirConfLocal + FileAdv);
                if (strArray.Length != 0)
                {
                    int index = rul.Next(strArray.Length);
                    if (strArray[index].StartsWith("#time"))
                    {
                        Class67.smethod_101(this, string.Concat(new object[] { "^7It's ^5", DateTime.Now.ToShortTimeString(), "^7 O'clock Of ^5", DateTime.Now.Day, "/", DateTime.Now.Month, "/", DateTime.Now.Year }));
                    }
                    else if (strArray[index].StartsWith("#report"))
                    {
                        Class67.smethod_101(this, "^7Use ^5!report ^7To Report a Cheating Player!!!");
                    }
                    else if (strArray[index].StartsWith("#nextmap"))
                    {
                        Class67.smethod_139(this, true, null);
                    }
                    else
                    {
                        Class67.smethod_101(this, strArray[index]);
                    }
                }
            }
        }

        public void ShowRandomRules()
        {
            if (System.IO.File.Exists(DirConfLocal + FileRules))
            {
                string[] strArray = System.IO.File.ReadAllLines(DirConfLocal + FileRules);
                if (strArray.Length != 0)
                {
                    int index = rul.Next(strArray.Length);
                    Class67.smethod_101(this, strArray[index]);
                }
            }
        }

        public void ShowRules(Entity player)
        {
            Action function = null;
            Class26 class2 = new Class26
            {
                entity_0 = player,
                serverControll_0 = this
            };
            try
            {
                if (!System.IO.File.Exists(DirConfLocal + FileRules))
                {
                    System.IO.File.CreateText(DirConfLocal + FileRules);
                }
                if (function == null)
                {
                    function = new Action(class2.method_0);
                }
                base.AfterDelay(200, function);
            }
            catch (Exception exception)
            {
                Class67.smethod_57(exception, this, "ShowRules");
            }
        }

        internal static void smethod_0()
        {
            foreach (Entity entity in Giocatori)
            {
                entity.Call("setweaponammoclip", new Parameter[] { entity.Call<string>("getcurrentprimaryweapon", new Parameter[0]), new Parameter(entity.GetWeaponAmmoClip(entity.Call<string>("getcurrentprimaryweapon", new Parameter[0])) * 3) });
                entity.Call("setweaponammostock", new Parameter[] { entity.Call<string>("getcurrentprimaryweapon", new Parameter[0]), new Parameter(entity.GetWeaponAmmoStock(entity.Call<string>("getcurrentprimaryweapon", new Parameter[0])) * 2) });
                entity.Call("setweaponammoclip", new Parameter[] { "flash_grenade_mp", 1 });
                entity.SetPerk("specialty_reducedsway", true, false);
            }
        }

        internal static bool smethod_1()
        {
            motd.SetText(TitoloScorr);
            motd.SetPoint("CENTER", "BOTTOM", 0x44c, -10);
            motd.Call("moveovertime", new Parameter[] { 0x19 });
            motd.X = -700f;
            return true;
        }

        internal static void smethod_2(Entity entity)
        {

            entity.SetClientDvar("cg_scoresping_lowcolor", "0.055 0.746 1 1");
            entity.SetClientDvar("cg_scoresping_medcolor", "1 0.336 0 1");
            entity.SetClientDvar("cg_scoresping_highcolor", "1 0.070 0 1");
            entity.SetClientDvar("cg_scoreboarditemheight", "18");
            entity.SetClientDvar("cg_scoresPingMaxBars", "10");
            entity.SetClientDvar("cg_scoreboardBannerHeight", "20");
            entity.SetClientDvar("cg_scoreboardHeight", "400");
            entity.SetClientDvar("cg_scoreboardWidth", "400");
            entity.SetClientDvar("cg_scoreboardRankFontScale", "0.23");
            entity.SetClientDvar("cg_scoreBoardMyColor", "0 0 0 0 0");
            entity.SetClientDvar("con_inputBoxColor", "1 0.25 0 0.2");
            entity.SetClientDvar("con_inputHintBoxColor", " 0.2 0 0.2 0");
            entity.SetClientDvar("con_outputSliderColor", "0.6 0.2 0 0");
            entity.SetClientDvar("con_outputWindowColor", "1 0.667 0 0.4");

        }

        internal static void smethod_3(Entity entity_0)
        {
            entity_0.SetClientDvar("r_distortion", "0");
            entity_0.SetClientDvar("r_zfeather", "0");
            entity_0.SetClientDvar("r_preloadShaders", "1");
            entity_0.SetClientDvar("sm_maxLights", "0");
            entity_0.SetClientDvar("r_texFilterAnisoMax", "2");
            entity_0.SetClientDvar("r_texFilterAnisoMin", "2");
            entity_0.SetClientDvar("ragdoll_enable", "0");
            entity_0.SetClientDvar("r_specular", "0");
            entity_0.SetClientDvar("cg_shadows", "0");
            entity_0.SetClientDvar("sm_enable", "0");
            entity_0.SetClientDvar("cg_weapHitCullEnable", "0");
            entity_0.SetClientDvar("cg_weapHitCullAngle", "0");
            entity_0.SetClientDvar("cl_packetdup", "0");
            entity_0.SetClientDvar("r_detail", "0");
        }

        internal static void smethod_4(Entity entity_0)
        {
            entity_0.SetClientDvar("r_envmapspecular", "0");
            entity_0.SetClientDvar("r_envmapsunintensity", "0");
            entity_0.SetClientDvar("r_drawsun", "0");
            entity_0.SetClientDvar("r_dlightLimit", "0");
            entity_0.SetClientDvar("r_drawWater", "0");
            entity_0.SetClientDvar("r_fastskin", "1");
            entity_0.SetClientDvar("r_picmip", "3");
            entity_0.SetClientDvar("r_picmip_bump", "3");
            entity_0.SetClientDvar("r_picmip_spec", "3");
            entity_0.SetClientDvar("r_picmip_water", "0");
            entity_0.SetClientDvar("r_picmip_manual", "1");
            entity_0.SetClientDvar("r_lodscaleskinned", "4");
            entity_0.SetClientDvar("r_lodscalerigid", "4");
        }

        internal static bool smethod_5(Entity entity_0)
        {
            if (((TypeMap == "sd") && !GHardCore) && ((string_0 != "esl") && (string_0 != "sniper")))
            {
                entity_0.SetClientDvar("g_hardcore", "1");
            }
            entity_0.SetClientDvar("r_specularMap", "1");
            entity_0.SetClientDvar("snaps", "30");
            entity_0.SetClientDvar("fx_Draw", "1");
            entity_0.SetClientDvar("r_drawdecals", "1");
            entity_0.SetClientDvar("g_compassshowenemies", "0");
            entity_0.SetClientDvar("compassPortableRadarRadius", "850");
            entity_0.SetClientDvar("compassPortableRadarSweepTime", "2000");
            if ((string_0 != "hide") && C3Person)
            {
                entity_0.SetClientDvar("cg_thirdperson", "0");
                entity_0.SetClientDvar("camera_thirdperson", "0");
            }
            return true;
        }

        private static void smethod_6(Entity entity_0)
        {
            entity_0.Health = entity_0.GetField<int>("Vita");
        }

        private static void smethod_7()
        {
            TitleVote.Call("destroy", new Parameter[0]);
        }

        private static void smethod_8()
        {
            TitleVote2.Call("destroy", new Parameter[0]);
        }

        internal static void smethod_9()
        {
            GRTitleServer.Call("destroy", new Parameter[0]);
            GRTitleClan.Call("destroy", new Parameter[0]);
            motd.Call("destroy", new Parameter[0]);
        }

        public string SuperAdminOnline()
        {
            string str = "";
            foreach (Entity entity in Giocatori)
            {
                if ((this.getPlayerLevel(entity) == 5) && (this.getPlayerAccess(entity) != 0))
                {
                    str = str + this.getPlayerName(entity) + "^7,^5";
                }
            }
            if (str != "")
            {
                int length = str.Length - 3;
                return str.Substring(0, length);
            }
            return "^5-----";
        }

        public double TPassato(DateTime temp)
        {
            TimeSpan span = (TimeSpan)(DateTime.Now - temp);
            return span.TotalMinutes;
        }

        public string TrovaMappa(Entity player, string mappa)
        {
            if (((mappa == "dow") || (mappa == "downturn")) || (mappa == "mp_exchange"))
            {
                return "mp_exchange";
            }
            if (((mappa == "dom") || (mappa == "dome")) || (mappa == "mp_dome"))
            {
                return "mp_dome";
            }
            if (((mappa == "boo") || (mappa == "bootleg")) || (mappa == "mp_bootleg"))
            {
                return "mp_bootleg";
            }
            if (((mappa == "har") || (mappa == "hardhat")) || (mappa == "mp_hardhat"))
            {
                return "mp_hardhat";
            }
            if (((mappa == "loc") || (mappa == "lockdown")) || (mappa == "mp_alpha"))
            {
                return "mp_alpha";
            }
            if (((mappa == "mis") || (mappa == "mission")) || (mappa == "mp_bravo"))
            {
                return "mp_bravo";
            }
            if (((mappa == "car") || (mappa == "carbon")) || (mappa == "mp_carbon"))
            {
                return "mp_carbon";
            }
            if (((mappa == "int") || (mappa == "interchange")) || (mappa == "mp_interchange"))
            {
                return "mp_interchange";
            }
            if (((mappa == "fal") || (mappa == "fallen")) || (mappa == "mp_lambeth"))
            {
                return "mp_lambeth";
            }
            if (((mappa == "bak") || (mappa == "bakaraa")) || (mappa == "mp_mogadishu"))
            {
                return "mp_mogadishu";
            }
            if (((mappa == "res") || (mappa == "resistance")) || (mappa == "mp_paris"))
            {
                return "mp_paris";
            }
            if (((mappa == "ark") || (mappa == "arkaden")) || (mappa == "mp_plaza2"))
            {
                return "mp_plaza2";
            }
            if (((mappa == "out") || (mappa == "outpost")) || (mappa == "mp_radar"))
            {
                return "mp_radar";
            }
            if (((mappa == "sea") || (mappa == "seatown")) || (mappa == "mp_seatown"))
            {
                return "mp_seatown";
            }
            if (((mappa == "und") || (mappa == "underground")) || (mappa == "mp_underground"))
            {
                return "mp_underground";
            }
            if (((mappa == "vil") || (mappa == "village")) || (mappa == "mp_village"))
            {
                return "mp_village";
            }
            if (((mappa == "ter") || (mappa == "terminal")) || (mappa == "mp_terminal_cls"))
            {
                return "mp_terminal_cls";
            }
            if (((mappa == "ove") || (mappa == "overwatch")) || (mappa == "mp_overwatch"))
            {
                return "mp_overwatch";
            }
            if (((mappa == "lib") || (mappa == "liberation")) || (mappa == "mp_park"))
            {
                return "mp_park";
            }
            if (((mappa == "pia") || (mappa == "piazza")) || (mappa == "mp_italy"))
            {
                return "mp_italy";
            }
            if (((mappa == "bla") || (mappa == "blackbox")) || (mappa == "mp_morningwood"))
            {
                return "mp_morningwood";
            }
            if (((mappa == "san") || (mappa == "sanctuary")) || (mappa == "mp_meteora"))
            {
                return "mp_meteora";
            }
            if (((mappa == "fou") || (mappa == "foundation")) || (mappa == "mp_cement"))
            {
                return "mp_cement";
            }
            if (((mappa == "oas") || (mappa == "oasis")) || (mappa == "mp_qadeem"))
            {
                return "mp_qadeem";
            }
            if (((mappa == "agr") || (mappa == "aground")) || (mappa == "mp_aground_ss"))
            {
                return "mp_aground_ss";
            }
            if (((mappa == "ero") || (mappa == "erosion")) || (mappa == "mp_courtyard_ss"))
            {
                return "mp_courtyard_ss";
            }
            if (((mappa == "gat") || (mappa == "gateway")) || (mappa == "mp_hillside_ss"))
            {
                return "mp_hillside_ss";
            }
            if (((mappa == "loo") || (mappa == "lookout")) || (mappa == "mp_restrepo_ss"))
            {
                return "mp_restrepo_ss";
            }
            if (((mappa == "utu") || (mappa == "uturn")) || (mappa == "mp_burn_ss"))
            {
                return "mp_burn_ss";
            }
            if (((mappa == "ins") || (mappa == "intersection")) || (mappa == "mp_crosswalk_ss"))
            {
                return "mp_crosswalk_ss";
            }
            if (((mappa == "vor") || (mappa == "vortex")) || (mappa == "mp_six_ss"))
            {
                return "mp_six_ss";
            }
            if (((mappa == "dec") || (mappa == "decommission")) || (mappa == "mp_shipbreaker"))
            {
                return "mp_shipbreaker";
            }
            if (((mappa == "off") || (mappa == "offshore")) || (mappa == "mp_roughneck"))
            {
                return "mp_roughneck";
            }
            if (((mappa == "gul") || (mappa == "gulch")) || (mappa == "mp_moab"))
            {
                return "mp_moab";
            }
            if (((mappa == "boa") || (mappa == "boardwalk")) || (mappa == "mp_boardwalk"))
            {
                return "mp_boardwalk";
            }
            if ((!(mappa == "par") && !(mappa == "parish")) && !(mappa == "mp_nola"))
            {
                Class67.smethod_125(this, player, "^7Enter The Correct Name Of The Map Or The First 3 Letters!");
                return "null";
            }
            return "mp_nola";
        }

        /* public void Update_Stats()
         {
             try
             {
                 if (System.IO.File.Exists(DirConfLocal + FileStatsServer))
                 {
                     System.IO.File.Delete(DirConfLocal + FileStatsServer);
                 }
                 using (StreamWriter writer = new StreamWriter(DirConfLocal + FileStatsServer, true))
                 {
                     writer.WriteLine("Visits=" + Visite);
                     writer.Close();
                 }
             }
             catch (Exception exception)
             {
                 Class67.smethod_57(exception, this, "Update_Stats");
             }
         }*/

        public void Vola(Entity player)
        {
            if (player.IsAlive)
            {
                if (player.GetField<string>("sessionstate") != "spectator")
                {
                    player.Call("allowspectateteam", new Parameter[] { "freelook", 1 });
                    player.SetField("sessionstate", "spectator");
                    player.Call("setcontents", new Parameter[] { 0 });
                    player.Call("iprintlnbold", new Parameter[] { "^5" + this.getPlayerName(player) + " ^7Fly Enabled!!!" });
                }
                else
                {
                    player.Call("allowspectateteam", new Parameter[] { "freelook", 0 });
                    player.SetField("sessionstate", "playing");
                    player.Call("setcontents", new Parameter[] { 100 });
                    player.Call("iprintlnbold", new Parameter[] { "^5" + this.getPlayerName(player) + " ^7Fly Disabled!!!" });
                }
            }
        }

        public void Warning(Entity admin, Entity player, string tip, string testo)
        {
            Class23 class4 = new Class23
            {
                entity_0 = admin,
                serverControll_0 = this
            };
            try
            {
                Class24 class3 = new Class24
                {
                    string_0 = null
                };
                bool flag = false;
                if (System.IO.File.Exists(DirConfLocal + FileWarn))
                {
                    class3.string_0 = System.IO.File.ReadAllLines(DirConfLocal + FileWarn);
                    if (tip != "list")
                    {
                        System.IO.File.Delete(DirConfLocal + FileWarn);
                    }
                }
                if (tip == "add")
                {
                    if (player == null)
                    {
                        return;
                    }
                    using (StreamWriter writer = new StreamWriter(DirConfLocal + FileWarn, true))
                    {
                        for (int i = 0; i < class3.string_0.Length; i++)
                        {
                            string[] strArray = class3.string_0[i].Split(new char[] { sep4 });
                            if (strArray[1] == this.getPlayerGuid(player))
                            {
                                flag = true;
                                int num2 = int.Parse(strArray[2]) + 1;
                                writer.WriteLine(string.Concat(new object[] { this.getPlayerName(player), sep4, strArray[1], sep4, num2 }));
                                Class67.smethod_125(this, player, string.Concat(new object[] { "^7WARNING NR[^5", num2, "^7] !!! - ^5", testo }));
                                Class67.smethod_101(this, string.Concat(new object[] { "^5", this.getPlayerName(player), " ^7WARN NR[^5", num2, "^7] - ^5", testo }));
                                if (num2 == 5)
                                {
                                    this.kikUser("Server", "k", player, "Kick - Warning Limit " + num2 + " Reached, The Next Is BAN");
                                }
                                else if (num2 > 5)
                                {
                                    this.method_15(null, player, 3, "TempBan 5min - Warning Limit " + num2 + " Reached!");
                                }
                            }
                            else
                            {
                                writer.WriteLine(class3.string_0[i]);
                            }
                        }
                        if (!flag)
                        {
                            writer.WriteLine(string.Concat(new object[] { this.getPlayerName(player), sep4, this.getPlayerGuid(player), sep4, "1" }));
                            Class67.smethod_125(this, player, "^7WARNING NR[^51^7] !!! - ^5" + testo);
                            Class67.smethod_101(this, "^5" + this.getPlayerName(player) + " ^7WARN NR[^51^7] - ^5" + testo);
                        }
                        writer.Close();
                        return;
                    }
                }
                if (tip == "del")
                {
                    if (player == null)
                    {
                        return;
                    }
                    using (StreamWriter writer2 = new StreamWriter(DirConfLocal + FileWarn, true))
                    {
                        for (int j = 0; j < class3.string_0.Length; j++)
                        {
                            if (class3.string_0[j].Split(new char[] { sep4 })[1] != this.getPlayerGuid(player))
                            {
                                writer2.WriteLine(class3.string_0[j]);
                            }
                            else
                            {
                                flag = true;
                            }
                        }
                        writer2.Close();
                        if (flag)
                        {
                            Class67.smethod_125(this, class4.entity_0, "^7Warn Of ^5" + this.getPlayerName(player) + " ^7Deleted");
                        }
                        else
                        {
                            Class67.smethod_125(this, class4.entity_0, "^7There Were No Warn Found Of ^5" + this.getPlayerName(player));
                        }
                        return;
                    }
                }
                if (tip == "list")
                {
                    if (System.IO.File.Exists(DirConfLocal + FileWarn))
                    {
                        Class25 class2 = new Class25
                        {
                            class24_0 = class3,
                            class23_0 = class4,
                            int_0 = 0
                        };
                        Class67.smethod_125(this, class4.entity_0, "^5List[^7" + class3.string_0.Length + "^5] ^7Player Warn:^5");
                        base.OnInterval(0x3e8, new Func<bool>(class2.method_0));
                    }
                    else
                    {
                        Class67.smethod_125(this, class4.entity_0, "^7No Player Found");
                    }
                }
                else
                {
                    Class67.smethod_125(this, class4.entity_0, "^7All Warn Deleted");
                }
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("required."))
                {
                    Class67.smethod_57(exception, this, "Warning");
                }
            }
        }

        public static unsafe int Gravity
        {
            get
            {
                return *(int*)new IntPtr(0x4768c6);
            }
            set
            {
                *(int*)new IntPtr(0x4768c6) = value;
            }
        }

        public static unsafe float JumpHeight
        {
            get
            {
                return *(float*)new IntPtr(0x6da708);
            }
            set
            {
                *(float*)new IntPtr(0x6da708) = value;
            }
        }

        public static unsafe int Speed
        {
            get
            {
                return *(int*)new IntPtr(0x4760ea);
            }
            set
            {
                *(int*)new IntPtr(0x4760ea) = value;
            }
        }

        public static Version Ver
        {
            get
            {
                return Assembly.GetCallingAssembly().GetName().Version;
            }
        }

        internal sealed class Class0
        {
            public Entity entity_0;
            public ServerControll serverControll_0;

            public bool method_0(Entity entity_1)
            {
                bool flag = false;
                int field = entity_1.GetField<int>("TimePass");
                if (!this.serverControll_0.IsJoinUsers(entity_1))
                {
                    return flag;
                }
                if (field < 1)
                {
                    this.serverControll_0.kikUser("Server", "k", entity_1, "^7Password Is Not Entered!!!");
                }
                else
                {
                    field--;
                    entity_1.SetField("TimePass", field);
                    Class67.smethod_23(entity_1, this.serverControll_0);
                    entity_1.SetField("Mute", 1);
                    entity_1.Call("freezeControls", new Parameter[] { 1 });
                    entity_1.Call("hide", new Parameter[] { 1 });
                    string str = this.entity_0.GetField<string>("sessionteam");
                    if (((str != "spectator") && this.entity_0.IsAlive) && ((ServerControll.TypeMap == "sd") && (this.serverControll_0.Call<int>("getteamplayersalive", new Parameter[] { str }) < 2)))
                    {
                        this.entity_0.SetField("team", "spectator");
                        this.entity_0.SetField("sessionteam", "spectator");
                        this.entity_0.Notify("menuresponse", new Parameter[] { "team_marinesopfor", "spectator" });
                    }
                }
                return true;
            }
        }

        internal sealed class Class1
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        internal sealed class Class10
        {
            public HudElem hudElem_0;

            public void method_0()
            {
                this.hudElem_0.Call("destroy", new Parameter[0]);
            }
        }

        internal sealed class Class11
        {
            public HudElem hudElem_0;
            public HudElem hudElem_1;
            public HudElem hudElem_2;
            public HudElem hudElem_3;
            public HudElem hudElem_4;

            public void method_0()
            {
                this.hudElem_0.Call("destroy", new Parameter[0]);
            }

            public void method_1()
            {
                this.hudElem_1.Call("destroy", new Parameter[0]);
            }

            public void method_2()
            {
                this.hudElem_2.Call("destroy", new Parameter[0]);
            }

            public void method_3()
            {
                this.hudElem_3.Call("destroy", new Parameter[0]);
            }

            public void method_4()
            {
                this.hudElem_4.Call("destroy", new Parameter[0]);
            }
        }

        private sealed class Class12
        {
            public Entity entity_0;
            public ServerControll serverControll_0;

            public void method_0()
            {
                Class67.smethod_156(this.serverControll_0, "^5" + this.serverControll_0.getPlayerName(this.entity_0) + " ^7Login Friend For ^5" + ServerControll.NomeClan + " ^7Server");
            }

            public void method_1()
            {
                Class67.smethod_156(this.serverControll_0, "^5" + this.serverControll_0.getPlayerName(this.entity_0) + " ^7Login Member For ^5" + ServerControll.NomeClan + " ^7Server");
            }

            public void method_2()
            {
                Class67.smethod_156(this.serverControll_0, "^5" + this.serverControll_0.getPlayerName(this.entity_0) + " ^7Login Moderator For ^5" + ServerControll.NomeClan + " ^7Server");
            }

            public void method_3()
            {
                Class67.smethod_156(this.serverControll_0, "^5" + this.serverControll_0.getPlayerName(this.entity_0) + " ^7Login Owner For ^5" + ServerControll.NomeClan + " ^7Server");
            }
        }

        private sealed class Class13
        {
            public Entity entity_0;

            public void method_0()
            {
                this.entity_0.Call("suicide", new Parameter[0]);
            }
        }

        internal sealed class Class14
        {
            public Entity entity_0;
            public int int_0;
            public ServerControll serverControll_0;

            public bool method_0(Entity entity_1)
            {
                if (entity_1.IsAlive && (this.int_0 == this.entity_0.GetField<int>("FlagRadar")))
                {
                    entity_1.Call(0x1af, new Parameter[] { this.int_0, "active" });
                    entity_1.Call(0x1b3, new Parameter[] { this.int_0, new Parameter(entity_1.Origin) });
                    entity_1.Call(0x1b2, new Parameter[] { this.int_0, "waypoint_kill" });
                    entity_1.Call("freezeControls", new Parameter[] { 1 });
                    entity_1.Call("iprintlnbold", new Parameter[] { "^7No Camp!!! ^5- ^7You Blocked Waiting For Death" });
                    return true;
                }
                this.serverControll_0.Call(0x1b0, new Parameter[] { this.int_0 });
                return false;
            }
        }

        internal sealed class Class15
        {
            public Entity entity_0;
            private static Predicate<char> predicate_0;
            private static Predicate<char> predicate_1;
            public ServerControll serverControll_0;

            public void method_0(Entity entity_1)
            {
                int num;
                if (entity_1.Name.ToLower().Contains<char>(ServerControll.sep6) || entity_1.Name.ToLower().Contains<char>(ServerControll.sep7))
                {
                    this.serverControll_0.CommandConsole("dropclient " + this.entity_0.Call<int>("getentitynumber", new Parameter[0]) + " \"^7Change Your Nick, Characters (^5 , ; = > \x00a7 { } ^7) Not Permitted!\"", 0);
                    return;
                }
                if (Encoding.UTF8.GetByteCount(entity_1.Name) != entity_1.Name.Length)
                {
                    goto Label_02B2;
                }
                if (predicate_0 == null)
                {
                    predicate_0 = new Predicate<char>(Class67.smethod_122);
                }
                if (Array.TrueForAll<char>(entity_1.Name.ToCharArray(), predicate_0))
                {
                    goto Label_02B2;
                }
                if (predicate_1 == null)
                {
                    predicate_1 = new Predicate<char>(Class67.smethod_50);
                }
                if (Array.TrueForAll<char>(this.entity_0.Name.ToCharArray(), predicate_1))
                {
                    goto Label_02B2;
                }
                if (((entity_1.Name.Length < 3) || entity_1.Name.Contains("thisguyhax")) || entity_1.Name.Contains("ChangeUrName"))
                {
                    this.serverControll_0.kikUser("Server", "k", entity_1, "^7Change Your Nick, This Nick Not Permitted!");
                    return;
                }
                if ((this.serverControll_0.getPlayerHWID(entity_1) == "000000000000000000000000") && ServerControll.Piattaforma.StartsWith("te"))
                {
                    Class67.smethod_33(this.serverControll_0, "WARNING! ZEROED HWID AT CLIENT " + entity_1.Call<int>("getentitynumber", new Parameter[0]) + ". Dropping Client...", new object[0]);
                    this.serverControll_0.kikUser("Server", "k", entity_1, "Error! You Are Probably Running Windows XP. This System Is Not Compatible With TeknoMW3.");
                    return;
                }
                using (List<Entity>.Enumerator enumerator = ServerControll.AllGiocatori.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        Entity current = enumerator.Current;
                        if (this.serverControll_0.getPlayerName(entity_1).Equals(this.serverControll_0.getPlayerName(current)) && (this.serverControll_0.getPlayerGuid(entity_1) != this.serverControll_0.getPlayerGuid(current)))
                        {
                            goto Label_01D2;
                        }
                    }
                    goto Label_0200;
                Label_01D2:
                    this.serverControll_0.kikUser("Server", "k", entity_1, "^7Change Your Nick ^5- ^7Nick Is Already In Use!");
                    return;
                }
            Label_0200:
                num = 0;
                while (num < ServerControll.CharactersNotUsable.Length)
                {
                    if (entity_1.Name.ToLower().Contains(ServerControll.CharactersNotUsable[num]))
                    {
                        Class67.smethod_33(this.serverControll_0, DateTime.Now.ToShortTimeString() + " Expelled " + entity_1.Name + " ^5REASON: ^7Change Your Nick, Characters Not Permitted!^5", new object[0]);
                        this.serverControll_0.CommandConsole("dropclient " + this.entity_0.Call<int>("getentitynumber", new Parameter[0]) + " \"^7Change Your Nick, Characters (^5 , ; = > \x00a7 { } ^7) Not Permitted!\"", 0);
                        return;
                    }
                    num++;
                }
                return;
            Label_02B2:
                this.serverControll_0.kikUser("Server", "k", entity_1, "^7Change Your Nick, Permitted Only ASCII Characters!");
            }
        }

        internal sealed class Class16
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
            public Vector3 vector3_0;

            public void method_0(Entity entity_1)
            {
                this.serverControll_0.Call("magicbullet", new Parameter[] { this.entity_0.CurrentWeapon.ToString(), this.vector3_0, entity_1.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }), this.entity_0 });
            }
        }

        internal sealed class Class17
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
            public string string_0;

            public void method_0()
            {
                this.serverControll_0.kikUser("Server", "k", this.entity_0, this.string_0);
            }
        }

        private sealed class Class18
        {
            public Entity entity_0;

            public void method_0()
            {
                this.entity_0.Call("suicide", new Parameter[0]);
            }
        }

        private sealed class Class19
        {
            public Entity entity_0;
            public Entity entity_1;
            public ServerControll serverControll_0;

            public void method_0(Entity entity_2)
            {
                this.serverControll_0.method_21(this.entity_1, this.entity_0);
            }

            public void method_1(Entity entity_2)
            {
                this.serverControll_0.method_21(this.entity_1, this.entity_0);
            }
        }

        internal sealed class Class2
        {
            public ServerControll.Class1 class1_0;
            public int int_0;
            public string[] string_0;
            public string[] string_1;

            public bool method_0()
            {
                if ((this.int_0 < this.string_0.Length) && (this.string_0[this.int_0] != ""))
                {
                    this.string_1 = this.string_0[this.int_0].Split(new char[] { ServerControll.sep1 });
                    Class67.smethod_125(this.class1_0.serverControll_0, this.class1_0.entity_0, "^7" + this.string_1[0] + "^5[^7" + this.string_1[1] + "^5]^7");
                    this.int_0++;
                    return true;
                }
                return false;
            }
        }

        private sealed class Class20
        {
            public ServerControll.Class19 class19_0;
            public string string_0;

            public void method_0(Entity entity_0)
            {
                Class67.smethod_101(this.class19_0.serverControll_0, this.string_0.Replace("<playerdead>", this.class19_0.serverControll_0.getPlayerName(this.class19_0.entity_0)).Replace("<playerattack>", this.class19_0.serverControll_0.getPlayerName(this.class19_0.entity_1)));
                this.class19_0.entity_1.SetField("UseMoab", 0);
            }

            public void method_1(Entity entity_0)
            {
                Class67.smethod_101(this.class19_0.serverControll_0, this.string_0.Replace("<playerdead>", this.class19_0.serverControll_0.getPlayerName(this.class19_0.entity_0)).Replace("<playerattack>", this.class19_0.serverControll_0.getPlayerName(entity_0)));
                entity_0.SetField("UseMoab", 0);
            }
        }

        internal sealed class Class21
        {
            public Entity entity_0;

            public bool method_0(Entity entity_1)
            {
                if (entity_1.GetField<string>("sessionteam") != "spectator")
                {
                    entity_1.SetField("Vita", this.entity_0.Health);
                    return false;
                }
                return true;
            }
        }

        internal sealed class Class22
        {
            public HudElem hudElem_0;
            public ServerControll serverControll_0;

            public bool method_0(Entity entity_0)
            {
                if (ServerControll.AvvGame)
                {
                    if (entity_0.IsAlive)
                    {
                        this.hudElem_0.Alpha = 1f;
                        string field = entity_0.GetField<string>("sessionteam");
                        int num = this.serverControll_0.Call<int>("getteamplayersalive", new Parameter[] { "axis" });
                        int num2 = this.serverControll_0.Call<int>("getteamplayersalive", new Parameter[] { "allies" });
                        int num3 = field.Equals("allies") ? num2 : num;
                        int num4 = field.Equals("allies") ? num : num2;
                        num3--;
                        this.hudElem_0.SetText("^7FRIENDS^5: ^7" + num3.ToString() + " ^5- ^7ENEMIES^5: ^7" + num4.ToString());
                    }
                    else
                    {
                        this.hudElem_0.Alpha = 0f;
                    }
                }
                return true;
            }
        }

        private sealed class Class23
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        private sealed class Class24
        {
            public string[] string_0;
        }

        private sealed class Class25
        {
            public ServerControll.Class23 class23_0;
            public ServerControll.Class24 class24_0;
            public int int_0;
            public string[] string_0;

            public bool method_0()
            {
                if ((this.int_0 < this.class24_0.string_0.Length) && (this.class24_0.string_0[this.int_0] != ""))
                {
                    this.string_0 = this.class24_0.string_0[this.int_0].Split(new char[] { ServerControll.sep4 });
                    Class67.smethod_125(this.class23_0.serverControll_0, this.class23_0.entity_0, "^7" + this.string_0[0] + " ^5= ^7" + this.string_0[2]);
                    this.int_0++;
                    return true;
                }
                return false;
            }
        }

        private sealed class Class26
        {
            public Entity entity_0;
            public ServerControll serverControll_0;

            public void method_0()
            {
                Class27 class2 = new Class27
                {
                    class26_0 = this,
                    int_0 = 0,
                    string_0 = System.IO.File.ReadAllLines(ServerControll.DirConfLocal + ServerControll.FileRules)
                };
                this.serverControll_0.OnInterval(0x7d0, new Func<bool>(class2.method_0));
            }

            private sealed class Class27
            {
                public ServerControll.Class26 class26_0;
                public int int_0;
                public string[] string_0;

                public bool method_0()
                {
                    if ((this.int_0 < this.string_0.Length) && (this.string_0[this.int_0] != ""))
                    {
                        Class67.smethod_125(this.class26_0.serverControll_0, this.class26_0.entity_0, this.string_0[this.int_0]);
                        this.int_0++;
                        return true;
                    }
                    return false;
                }
            }
        }

        private sealed class Class28
        {
            public Entity entity_0;

            public void method_0(Entity entity_1)
            {
                this.entity_0.SetField("VarPause", 0);
            }
        }

        internal sealed class Class29
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        internal sealed class Class3
        {
            public char char_0;
            public ServerControll serverControll_0;
            public string string_0;

            public void method_0()
            {
                Action function = null;
                if (System.IO.File.Exists(ServerControll.LocalFileUpdate))
                {
                    string[] strArray = System.IO.File.ReadAllLines(ServerControll.LocalFileUpdate);
                    System.IO.File.Delete(ServerControll.LocalFileUpdate);
                    using (StreamWriter writer = new StreamWriter(ServerControll.LocalFileUpdate, true))
                    {
                        writer.WriteLine(strArray[0] + this.char_0 + this.string_0);
                        writer.Close();
                        if (function == null)
                        {
                            function = new Action(this.method_1);
                        }
                        this.serverControll_0.AfterDelay(0x7d0, function);
                    }
                }
            }

            private void method_1()
            {
                Class67.smethod_92(this.serverControll_0, null);
            }
        }

        internal sealed class Class30
        {
            public ServerControll.Class29 class29_0;
            public string string_0;

            public void method_0()
            {
                this.class29_0.serverControll_0.kikUser("Server", "b", this.class29_0.entity_0, this.string_0);
            }

            public void method_1()
            {
                this.class29_0.serverControll_0.kikUser("Server", "b", this.class29_0.entity_0, this.string_0);
            }
        }

        internal sealed class Class31
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        internal sealed class Class32
        {
            public ServerControll.Class31 class31_0;
            public string string_0;

            public void method_0()
            {
                this.class31_0.serverControll_0.kikUser("Server", "tb", this.class31_0.entity_0, this.string_0);
            }

            public void method_1()
            {
                this.class31_0.serverControll_0.kikUser("Server", "tb", this.class31_0.entity_0, this.string_0);
            }
        }

        internal sealed class Class33
        {
            public Entity entity_0;
            public ServerControll serverControll_0;

            public void method_0()
            {
                int num = this.serverControll_0.Call<int>("loadfx", new Parameter[] { "explosions/oxygen_tank_explosion" });
                this.entity_0.Call("playSound", new Parameter[] { "detpack_explo_default" });
                this.serverControll_0.Call("PlayFX", new Parameter[] { num, this.entity_0.Origin });
                this.entity_0.Call("suicide", new Parameter[0]);
            }
        }

        internal sealed class Class34
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        internal sealed class Class35
        {
            public ServerControll.Class34 class34_0;
            public int int_0;
            public string[] string_0;
            public string[] string_1;
            public string[] string_2;

            public bool method_0()
            {
                if ((this.int_0 >= this.string_0.Length) || !(this.string_0[this.int_0] != ""))
                {
                    return false;
                }
                this.string_1 = this.string_0[this.int_0].Split(new char[] { ServerControll.sep1 });
                this.string_2 = this.string_1[0].Split(new char[] { ServerControll.sep2 });
                DateTime time = DateTime.Parse(this.string_2[0]);
                double num = double.Parse(this.string_2[1]);
                TimeSpan span = (TimeSpan)(DateTime.Now - time);
                if (span.TotalMinutes < num)
                {
                    double num2 = Convert.ToInt32((double)(num - span.TotalMinutes));
                    Class67.smethod_125(this.class34_0.serverControll_0, this.class34_0.entity_0, string.Concat(new object[] { "^7", this.string_1[1], "^5[^7", this.string_1[2], "^5] ^7Banned For Other ^5", num2, "Min" }));
                }
                this.int_0++;
                return true;
            }
        }

        internal sealed class Class36
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        internal sealed class Class37
        {
            public ServerControll.Class36 class36_0;
            public int int_0;
            public string[] string_0;
            public string[] string_1;

            public bool method_0()
            {
                if ((this.int_0 >= this.string_0.Length) || !(this.string_0[this.int_0] != ""))
                {
                    return false;
                }
                this.string_1 = this.string_0[this.int_0].Split(new char[] { ServerControll.sep1 });
                if (Class67.smethod_148(this.string_1[0]))
                {
                    Class67.smethod_125(this.class36_0.serverControll_0, this.class36_0.entity_0, string.Concat(new object[] { "^5[^7", this.int_0, "^5] [^7", this.string_1[1], "^5] [^7", this.string_1[2], "^5]" }));
                }
                else
                {
                    Class67.smethod_125(this.class36_0.serverControll_0, this.class36_0.entity_0, string.Concat(new object[] { "^5[^7", this.int_0, "^5] [^7", this.string_1[0], "^5] [^7", this.string_1[1], "^5]" }));
                }
                this.int_0++;
                return true;
            }
        }

        internal sealed class Class38
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        internal sealed class Class39
        {
            public ServerControll.Class38 class38_0;
            public int int_0;
            public string[] string_0;
            public string[] string_1;

            public bool method_0()
            {
                if ((this.int_0 >= this.string_0.Length) || !(this.string_0[this.int_0] != ""))
                {
                    return false;
                }
                this.string_1 = this.string_0[this.int_0].Split(new char[] { ServerControll.sep1 });
                if (Class67.smethod_148(this.string_1[0]))
                {
                    Class67.smethod_125(this.class38_0.serverControll_0, this.class38_0.entity_0, "^7" + this.string_1[1] + "^5[^7" + this.string_1[2] + "^5] ^7" + this.string_1[6]);
                }
                else
                {
                    Class67.smethod_125(this.class38_0.serverControll_0, this.class38_0.entity_0, "^7" + this.string_1[0] + "^5[^7" + this.string_1[1] + "^5] ^7" + this.string_1[5]);
                }
                this.int_0++;
                return true;
            }
        }

        internal sealed class Class4
        {
            public ServerControll.Class3 class3_0;
            public string string_0;
            public string string_1;

            public bool method_0()
            {
                foreach (Entity entity in ServerControll.Giocatori)
                {
                    if (this.class3_0.serverControll_0.getPlayerLevel(entity) > 3)
                    {
                        Class67.smethod_125(this.class3_0.serverControll_0, entity, "^7Available To Download The New Version NaaBAdmin_iSniPe ^5" + this.string_1 + " ^7Link: ^5" + this.string_0);
                    }
                }
                Class67.smethod_33(this.class3_0.serverControll_0, "^7Available To Download The New Version NaaBAdmin_iSniPe ^5" + this.string_1 + "\n " + this.string_0, new object[0]);
                return true;
            }
        }

        internal sealed class Class40
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        internal sealed class Class41
        {
            public ServerControll.Class40 class40_0;
            public string string_0;
            public string string_1;
            public string string_2;

            public void method_0()
            {
                Class67.smethod_125(this.class40_0.serverControll_0, this.class40_0.entity_0, this.string_0);
            }

            public void method_1()
            {
                Class67.smethod_125(this.class40_0.serverControll_0, this.class40_0.entity_0, this.string_1);
            }

            public void method_2()
            {
                Class67.smethod_125(this.class40_0.serverControll_0, this.class40_0.entity_0, this.string_2);
            }

            public void method_3()
            {
                Class67.smethod_101(this.class40_0.serverControll_0, this.string_0);
            }

            public void method_4()
            {
                Class67.smethod_101(this.class40_0.serverControll_0, this.string_1);
            }

            public void method_5()
            {
                Class67.smethod_101(this.class40_0.serverControll_0, this.string_2);
            }
        }

        internal sealed class Class42
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        internal sealed class Class43
        {
            public ServerControll.Class42 class42_0;
            public Entity[] entity_0;
            public int int_0;

            public bool method_0()
            {
                if (this.int_0 < this.entity_0.Length)
                {
                    Class67.smethod_125(this.class42_0.serverControll_0, this.class42_0.entity_0, "^5(^7" + this.class42_0.serverControll_0.getPlayerSlot(this.entity_0[this.int_0]) + "^5) ^7" + this.class42_0.serverControll_0.getPlayerName(this.entity_0[this.int_0]) + " ^5- ^:ID: ^7" + this.class42_0.serverControll_0.getPlayerID(this.entity_0[this.int_0]));
                    this.int_0++;
                    return true;
                }
                return false;
            }
        }

        internal sealed class Class44
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        internal sealed class Class45
        {
            public ServerControll.Class44 class44_0;
            public Entity[] entity_0;
            public int int_0;

            public bool method_0()
            {
                if (this.int_0 < this.entity_0.Length)
                {
                    Class67.smethod_125(this.class44_0.serverControll_0, this.class44_0.entity_0, "^5(^7" + this.class44_0.serverControll_0.getPlayerSlot(this.entity_0[this.int_0]) + "^5) ^7" + this.class44_0.serverControll_0.getPlayerName(this.entity_0[this.int_0]) + " ^5- ^:ID: ^7" + this.class44_0.serverControll_0.getPlayerID(this.entity_0[this.int_0]));
                    this.int_0++;
                    return true;
                }
                return false;
            }
        }

        private sealed class Class46
        {
            public Entity entity_0;
            public Entity entity_1;
            public ServerControll serverControll_0;
            public string string_0;
        }

        private sealed class Class47
        {
            public string[] string_0;
        }

        private sealed class Class48
        {
            private static Action action_0;
            private static Action action_1;
            private static Action action_2;
            private static Action action_3;
            public ServerControll.Class46 class46_0;
            public ServerControll.Class47 class47_0;
            public int int_0;
            public int int_1;

            public bool method_0()
            {
                Action function = null;
                Action action2 = null;
                Action action3 = null;
                if (!ServerControll.StatVotazione)
                {
                    ServerControll.TitleVote.Alpha = 0f;
                    ServerControll.TitleVote2.Alpha = 0f;
                    if (action_0 == null)
                    {
                        action_0 = new Action(Class67.smethod_144);
                    }
                    this.class46_0.serverControll_0.AfterDelay(500, action_0);
                    if (action_1 == null)
                    {
                        action_1 = new Action(Class67.smethod_138);
                    }
                    this.class46_0.serverControll_0.AfterDelay(0x3e8, action_1);
                    return false;
                }
                if (this.int_1 >= ServerControll.TempoVoto)
                {
                    ServerControll.StatVotazione = false;
                    ServerControll.TitleVote.Alpha = 0f;
                    ServerControll.TitleVote2.Alpha = 0f;
                    if (action_2 == null)
                    {
                        action_2 = new Action(Class67.smethod_123);
                    }
                    this.class46_0.serverControll_0.AfterDelay(500, action_2);
                    if (action_3 == null)
                    {
                        action_3 = new Action(Class67.smethod_12);
                    }
                    this.class46_0.serverControll_0.AfterDelay(0x3e8, action_3);
                    int num = ServerControll.Giocatori.Count / 2;
                    int num2 = ServerControll.VotoSi + ServerControll.VotoNo;
                    if (num2 <= num)
                    {
                        Class67.smethod_101(this.class46_0.serverControll_0, "^7Negative Vote ^5- ^7Voters Must Exceed Half Of Online Gamers!");
                        return false;
                    }
                    if (ServerControll.VotoSi > ServerControll.VotoNo)
                    {
                        Class67.smethod_101(this.class46_0.serverControll_0, "^7Positive Vote");
                        if (this.class47_0.string_0[0].Contains("map"))
                        {
                            this.class46_0.serverControll_0.method_27("all");
                            this.class46_0.serverControll_0.CommandConsole("map " + this.class47_0.string_0[1], 0x7d0);
                        }
                        else if (this.class47_0.string_0[0].Contains("mod"))
                        {
                            this.class46_0.serverControll_0.method_27("all");
                            if (function == null)
                            {
                                function = new Action(this.method_1);
                            }
                            this.class46_0.serverControll_0.AfterDelay(0x7d0, function);
                        }
                        else if (this.class47_0.string_0[0].Contains("kick"))
                        {
                            if (ServerControll.Giocatori.Contains(this.class46_0.entity_1))
                            {
                                if (action2 == null)
                                {
                                    action2 = new Action(this.method_2);
                                }
                                this.class46_0.serverControll_0.AfterDelay(0x3e8, action2);
                            }
                            else
                            {
                                this.class46_0.serverControll_0.method_0(this.class46_0.string_0, 30);
                            }
                        }
                        else if (this.class47_0.string_0[0].Contains("ban"))
                        {
                            if (ServerControll.Giocatori.Contains(this.class46_0.entity_1))
                            {
                                if (action3 == null)
                                {
                                    action3 = new Action(this.method_3);
                                }
                                this.class46_0.serverControll_0.AfterDelay(0x3e8, action3);
                            }
                            else
                            {
                                this.class46_0.serverControll_0.method_0(this.class46_0.string_0, 60);
                            }
                        }
                    }
                    else
                    {
                        Class67.smethod_101(this.class46_0.serverControll_0, "^7Negative Vote");
                    }
                    return false;
                }
                this.int_1++;
                this.int_0 = ServerControll.TempoVoto - this.int_1;
                ServerControll.TitleVote2.SetText(string.Concat(new object[] { "^5!y ^7Or ^5!n ^7- ^5[^7", ServerControll.VotoSi, "/", ServerControll.VotoNo, "^5] ^7Conclusion ^5", this.int_0, "s" }));
                return true;
            }

            public void method_1()
            {
                ServerControll controll = this.class46_0.serverControll_0;
                Entity entity = this.class46_0.entity_0;
                string str = this.class47_0.string_0[1];
                Class67.smethod_146(ServerControll.MapName, entity, str, controll);
            }

            public void method_2()
            {
                this.class46_0.serverControll_0.kikUser("Server", "k", this.class46_0.entity_1, "^7Kick For Vote!");
            }

            public void method_3()
            {
                this.class46_0.serverControll_0.method_15(null, this.class46_0.entity_1, 10, "^7TempBan ^510Min ^7For Vote!");
            }
        }

        private sealed class Class49
        {
            public Entity entity_0;
            public ServerControll serverControll_0;

            public void method_0(Entity entity_1)
            {
                this.serverControll_0.Call("magicbullet", new Parameter[] { this.entity_0.CurrentWeapon.ToString(), this.entity_0.Call<Vector3>("getTagOrigin", new Parameter[] { "tag_weapon_left" }), entity_1.Call<Vector3>("getTagOrigin", new Parameter[] { "tag_weapon_left" }), this.entity_0 });
            }

            public void method_1(Entity entity_1)
            {
                this.serverControll_0.Call("magicbullet", new Parameter[] { this.entity_0.CurrentWeapon.ToString(), this.entity_0.Call<Vector3>("getTagOrigin", new Parameter[] { "tag_weapon_left" }), entity_1.Call<Vector3>("getTagOrigin", new Parameter[] { "tag_weapon_left" }), this.entity_0 });
            }
        }

        private sealed class Class5
        {
            public Entity entity_0;
            public ServerControll serverControll_0;

            public void method_0(Entity entity_1)
            {
                Class67.smethod_125(this.serverControll_0, entity_1, "^7Nick: ^5" + this.serverControll_0.getPlayerName(this.entity_0));
            }

            public void method_1(Entity entity_1)
            {
                Class67.smethod_125(this.serverControll_0, entity_1, "^7ID: ^5" + this.serverControll_0.getPlayerID(this.entity_0));
            }

            public void method_2(Entity entity_1)
            {
                Class67.smethod_125(this.serverControll_0, entity_1, "^7GUID: ^5" + this.serverControll_0.getPlayerGuid(this.entity_0));
            }

            public void method_3(Entity entity_1)
            {
                Class67.smethod_125(this.serverControll_0, entity_1, "^7HWID: ^5" + this.serverControll_0.getPlayerHWID(this.entity_0));
            }

            public void method_4(Entity entity_1)
            {
                Class67.smethod_125(this.serverControll_0, entity_1, "^7XUID: ^5" + this.serverControll_0.getPlayerXuid(this.entity_0));
            }

            public void method_5(Entity entity_1)
            {
                Class67.smethod_125(this.serverControll_0, entity_1, "^7IP: ^5" + this.serverControll_0.getPlayerIP(this.entity_0));
            }

            public void method_6(Entity entity_1)
            {
                this.serverControll_0.method_12(entity_1, this.entity_0);
            }

            /*public void method_7(Entity entity_1)
            {
                Class67.smethod_125(this.serverControll_0, entity_1, "^7GPS: Connect From ^5[" + this.serverControll_0.lookupIP(this.serverControll_0.GetIPAddress(this.entity_0.EntRef).ToString()) + "]");
            }*/
        }

        private sealed class Class50
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
            public string string_0;
            public string string_1;

            public void method_0(Entity entity_1)
            {
                this.entity_0.Notify("menuresponse", new Parameter[] { "team_marinesopfor", this.string_1 });
                this.entity_0.OnNotify("joined_team", new Action<Entity>(this.method_1));
                this.entity_0.OnNotify("weapon_fired", new Action<Entity, Parameter>(this.method_2));
                Class67.smethod_102(this.serverControll_0, this.entity_0);
                this.entity_0.OnInterval(0x2710, new Func<Entity, bool>(this.method_3));
            }

            public void method_1(Entity entity_1)
            {
                this.entity_0.Notify("menuresponse", new Parameter[] { "changeclass", this.string_0 });
            }

            public void method_2(Entity entity_1, Parameter parameter_0)
            {
                this.entity_0.Call("giveMaxAmmo", new Parameter[] { this.entity_0.CurrentWeapon });
            }

            public bool method_3(Entity entity_1)
            {
                this.entity_0.Call("setmovespeedscale", new Parameter[] { new Parameter(1.5f) });
                this.entity_0.Call("giveMaxAmmo", new Parameter[] { this.entity_0.CurrentWeapon });
                return true;
            }
        }

        internal sealed class Class51
        {
            public int int_0;
            public ServerControll serverControll_0;

            public bool method_0(Entity entity_0)
            {
                if (!entity_0.IsAlive)
                {
                    return false;
                }
                this.serverControll_0.Call("PlayFx", new Parameter[] { this.int_0, entity_0.Origin });
                return true;
            }
        }

        internal sealed class Class52
        {
            public Entity entity_0;
            public int int_0;
            public int int_1;
            public ServerControll serverControll_0;

            public void method_0()
            {
                Class67.smethod_160(this.serverControll_0, this.entity_0, this.int_0, this.int_1);
            }
        }

        internal sealed class Class53
        {
            public Entity entity_0;
            public ServerControll serverControll_0;

            public void method_0()
            {
                Class67.smethod_125(this.serverControll_0, this.entity_0, "^7" + ServerControll.StrComandiU);
            }

            public void method_1()
            {
                Class67.smethod_125(this.serverControll_0, this.entity_0, "^7" + ServerControll.StrComandiM);
            }

            public void method_2()
            {
                Class67.smethod_125(this.serverControll_0, this.entity_0, "^7" + ServerControll.StrComandiSM);
            }

            public void method_3()
            {
                Class67.smethod_125(this.serverControll_0, this.entity_0, "^7" + ServerControll.StrComandiA);
            }

            public void method_4()
            {
                Class67.smethod_125(this.serverControll_0, this.entity_0, "^7" + ServerControll.StrComandiSA);
            }
        }

        internal sealed class Class54
        {
            public ServerControll.Class53 class53_0;
            public string string_0;
            public string string_1;
            public string string_2;
            public string string_3;

            public void method_0()
            {
                Class67.smethod_125(this.class53_0.serverControll_0, this.class53_0.entity_0, "^5" + this.string_0);
            }

            public void method_1()
            {
                Class67.smethod_125(this.class53_0.serverControll_0, this.class53_0.entity_0, "^5" + this.string_1);
            }

            public void method_2()
            {
                Class67.smethod_125(this.class53_0.serverControll_0, this.class53_0.entity_0, "^5" + this.string_2);
            }

            public void method_3()
            {
                Class67.smethod_125(this.class53_0.serverControll_0, this.class53_0.entity_0, "^5" + this.string_3);
            }
        }

        internal sealed class Class55
        {
            public ServerControll.Class53 class53_0;
            public string string_0;
            public string string_1;
            public string string_2;
            public string string_3;

            public void method_0()
            {
                Class67.smethod_125(this.class53_0.serverControll_0, this.class53_0.entity_0, "^5" + this.string_0);
            }

            public void method_1()
            {
                Class67.smethod_125(this.class53_0.serverControll_0, this.class53_0.entity_0, "^5" + this.string_1);
            }

            public void method_2()
            {
                Class67.smethod_125(this.class53_0.serverControll_0, this.class53_0.entity_0, "^5" + this.string_2);
            }

            public void method_3()
            {
                Class67.smethod_125(this.class53_0.serverControll_0, this.class53_0.entity_0, "^5" + this.string_3);
            }
        }

        internal sealed class Class56
        {
            public ServerControll.Class53 class53_0;
            public string string_0;
            public string string_1;
            public string string_2;
            public string string_3;

            public void method_0()
            {
                Class67.smethod_125(this.class53_0.serverControll_0, this.class53_0.entity_0, "^5" + this.string_0);
            }

            public void method_1()
            {
                Class67.smethod_125(this.class53_0.serverControll_0, this.class53_0.entity_0, "^5" + this.string_1);
            }

            public void method_2()
            {
                Class67.smethod_125(this.class53_0.serverControll_0, this.class53_0.entity_0, "^5" + this.string_2);
            }

            public void method_3()
            {
                Class67.smethod_125(this.class53_0.serverControll_0, this.class53_0.entity_0, "^5" + this.string_3);
            }
        }

        internal sealed class Class57
        {
            public ServerControll.Class53 class53_0;
            public string string_0;
            public string string_1;
            public string string_2;
            public string string_3;

            public void method_0()
            {
                Class67.smethod_125(this.class53_0.serverControll_0, this.class53_0.entity_0, "^5" + this.string_0);
            }

            public void method_1()
            {
                Class67.smethod_125(this.class53_0.serverControll_0, this.class53_0.entity_0, "^5" + this.string_1);
            }

            public void method_2()
            {
                Class67.smethod_125(this.class53_0.serverControll_0, this.class53_0.entity_0, "^5" + this.string_2);
            }

            public void method_3()
            {
                Class67.smethod_125(this.class53_0.serverControll_0, this.class53_0.entity_0, "^5" + this.string_3);
            }
        }

        internal sealed class Class58
        {
            public ServerControll.Class53 class53_0;
            public string string_0;
            public string string_1;
            public string string_2;
            public string string_3;

            public void method_0()
            {
                Class67.smethod_125(this.class53_0.serverControll_0, this.class53_0.entity_0, "^5" + this.string_0);
            }

            public void method_1()
            {
                Class67.smethod_125(this.class53_0.serverControll_0, this.class53_0.entity_0, "^5" + this.string_1);
            }

            public void method_2()
            {
                Class67.smethod_125(this.class53_0.serverControll_0, this.class53_0.entity_0, "^5" + this.string_2);
            }

            public void method_3()
            {
                Class67.smethod_125(this.class53_0.serverControll_0, this.class53_0.entity_0, "^5" + this.string_3);
            }
        }

        private sealed class Class59
        {
            public int int_0;
            public ServerControll serverControll_0;

            public bool method_0()
            {
                if (this.int_0 < 1)
                {
                    Class67.smethod_101(this.serverControll_0, "^7Restarting Server...");
                    Process.Start("riavvia.bat");
                    this.serverControll_0.CommandConsole("quit", 0x7d0);
                    return false;
                }
                this.int_0--;
                Class67.smethod_101(this.serverControll_0, "^7Server Will Be Restarted In ^5" + this.int_0 + "s");
                return true;
            }
        }

        private sealed class Class6
        {
            public ServerControll serverControll_0;
            public string string_0;
            public string string_1;

            public void method_0()
            {
                Class67.smethod_101(this.serverControll_0, "^5" + this.string_1 + " ^7Connect From [^5" + this.string_0 + "^7]");
            }
        }

        internal sealed class Class60
        {
            public HudElem hudElem_0;
            public HudElem hudElem_1;

            public void method_0(Entity entity_0)
            {
                this.hudElem_0.Alpha = 1f;
                this.hudElem_1.Alpha = 1f;
            }

            public void method_1(Entity entity_0)
            {
                this.hudElem_0.Alpha = 0f;
                this.hudElem_1.Alpha = 0f;
            }
        }

        private sealed class Class61
        {
            public Entity entity_0;
            public Entity entity_1;
            public int int_0;
            public ServerControll serverControll_0;

            public void method_0(Entity entity_2)
            {
                if (this.serverControll_0.getPlayerAccess(entity_2) == 1)
                {
                    if (!entity_2.IsAlive)
                    {
                        this.entity_1.Call("iprintlnbold", new Parameter[] { "^7You Must Be Alive To Use The Graphical Menu!" });
                    }
                    else
                    {
                        this.int_0 = 0;
                        if ((this.entity_1.GetField<int>("MenuSC") == 0) && (this.entity_1.GetField<int>("SubMenuSC") == 0))
                        {
                            this.serverControll_0.CreateMenu(this.entity_1);
                            this.serverControll_0.ResetColors(this.entity_1, 0);
                            this.entity_1.SetField("MenuSC", 1);
                            Class67.smethod_149(this.serverControll_0, entity_2);
                        }
                        else if ((this.entity_1.GetField<int>("MenuSC") == 0) && (this.entity_1.GetField<int>("SubMenuSC") == 1))
                        {
                            this.entity_1.SetField("SubMenuSC", 0);
                            Class67.smethod_68(entity_2, this.serverControll_0);
                        }
                        else
                        {
                            if (this.entity_1.GetField<int>("MenuSC") == 1)
                            {
                                this.entity_1.SetField("MenuSC", 0);
                                Class67.smethod_119(this.serverControll_0, entity_2);
                            }
                            if (this.entity_1.GetField<int>("SubMenuSC") == 1)
                            {
                                this.entity_1.SetField("SubMenuSC", 0);
                                Class67.smethod_68(entity_2, this.serverControll_0);
                            }
                        }
                    }
                }
            }

            public void method_1(Entity entity_2)
            {
                if (this.serverControll_0.getPlayerAccess(entity_2) == 1)
                {
                    if (this.entity_1.GetField<int>("MenuSC") == 1)
                    {
                        if (this.int_0 < 1)
                        {
                            this.int_0 = ServerControll.Giocatori.Count;
                        }
                        this.int_0--;
                        this.serverControll_0.ResetColors(entity_2, this.int_0);
                    }
                    else if (this.entity_1.GetField<int>("SubMenuSC") == 1)
                    {
                        if (this.int_0 < 1)
                        {
                            this.int_0 = this.serverControll_0.comandiplayer.Length;
                        }
                        this.int_0--;
                        this.serverControll_0.ResetSubColors(entity_2, this.int_0);
                    }
                }
            }

            public void method_2(Entity entity_2)
            {
                if (this.serverControll_0.getPlayerAccess(entity_2) == 1)
                {
                    if (this.entity_1.GetField<int>("MenuSC") == 1)
                    {
                        if (this.int_0 == (ServerControll.Giocatori.Count - 1))
                        {
                            this.int_0 = -1;
                        }
                        this.int_0++;
                        this.serverControll_0.ResetColors(entity_2, this.int_0);
                    }
                    else if (this.entity_1.GetField<int>("SubMenuSC") == 1)
                    {
                        if (this.int_0 == (this.serverControll_0.comandiplayer.Length - 1))
                        {
                            this.int_0 = -1;
                        }
                        this.int_0++;
                        this.serverControll_0.ResetSubColors(entity_2, this.int_0);
                    }
                }
            }

            public void method_3(Entity entity_2)
            {
                if ((this.serverControll_0.getPlayerAccess(entity_2) == 1) && ((this.entity_1.GetField<int>("MenuSC") != 0) || (this.entity_1.GetField<int>("SubMenuSC") != 0)))
                {
                    if (this.entity_1.GetField<int>("MenuSC") == 1)
                    {
                        this.entity_1.SetField("MenuSC", 0);
                        Class67.smethod_119(this.serverControll_0, entity_2);
                        Entity[] entityArray = ServerControll.Giocatori.ToArray();
                        this.entity_0 = entityArray[this.int_0];
                        this.int_0 = 0;
                        this.serverControll_0.CreateSubMenu(this.entity_1, this.serverControll_0.getPlayerName(this.entity_0));
                        this.serverControll_0.ResetSubColors(this.entity_1, 0);
                        this.entity_1.SetField("SubMenuSC", 1);
                        Class67.smethod_83(entity_2, this.serverControll_0);
                    }
                    else if (this.entity_1.GetField<int>("SubMenuSC") == 1)
                    {
                        this.entity_1.SetField("SubMenuSC", 0);
                        Class67.smethod_68(entity_2, this.serverControll_0);
                        this.serverControll_0.Scelta(entity_2, this.entity_0, this.serverControll_0.comandiplayer[this.int_0].ToLower());
                    }
                }
            }
        }

        private sealed class Class62
        {
            public Entity entity_0;
            public ServerControll serverControll_0;

            public bool method_0()
            {
                if (ServerControll.antibomba == 0)
                {
                    return false;
                }
                using (List<Entity>.Enumerator enumerator = ServerControll.Giocatori.GetEnumerator())
                {
                    Entity current;
                    while (enumerator.MoveNext())
                    {
                        current = enumerator.Current;
                        if (current != this.entity_0)
                        {
                            if (current.CurrentWeapon.Equals("briefcase_bomb_mp"))
                            {
                                goto Label_0057;
                            }
                            if (current.CurrentWeapon.Equals("briefcase_bomb_defuse_mp"))
                            {
                                goto Label_006C;
                            }
                        }
                    }
                    goto Label_008F;
                Label_0057:
                    current.TakeWeapon("briefcase_bomb_mp");
                    ServerControll.antibomba = 0;
                    return false;
                Label_006C:
                    current.TakeWeapon("briefcase_bomb_defuse_mp");
                    ServerControll.antibomba = 0;
                    return false;
                }
            Label_008F:
                return true;
            }

            public void method_1()
            {
                this.entity_0.Call("suicide", new Parameter[0]);
            }

            public void method_2()
            {
                Class67.smethod_125(this.serverControll_0, this.entity_0, "^7Owner OnLine: ^5" + this.serverControll_0.SuperAdminOnline());
            }

            public void method_3()
            {
                Class67.smethod_125(this.serverControll_0, this.entity_0, "^7Moderator OnLine: ^5" + this.serverControll_0.AdminOnline());
            }

            public void method_4()
            {
                Class67.smethod_125(this.serverControll_0, this.entity_0, "^7Member OnLine: ^5" + this.serverControll_0.SeniorModOnline());
            }

            public void method_5()
            {
                Class67.smethod_125(this.serverControll_0, this.entity_0, "^7Friend OnLine: ^5" + this.serverControll_0.ModOnline());
            }
        }

        private sealed class Class63
        {
            public ServerControll.Class62 class62_0;
            public string string_0;

            public void method_0()
            {
                Class67.smethod_101(this.class62_0.serverControll_0, "^1" + this.string_0);
            }

            public void method_1()
            {
                Class67.smethod_101(this.class62_0.serverControll_0, "^2" + this.string_0);
            }

            public void method_2()
            {
                Class67.smethod_101(this.class62_0.serverControll_0, "^3" + this.string_0);
            }

            public void method_3()
            {
                Class67.smethod_101(this.class62_0.serverControll_0, "^4" + this.string_0);
            }

            public void method_4()
            {
                Class67.smethod_101(this.class62_0.serverControll_0, "^5" + this.string_0);
            }

            public void method_5()
            {
                Class67.smethod_101(this.class62_0.serverControll_0, "^6" + this.string_0);
            }

            public void method_6()
            {
                Class67.smethod_101(this.class62_0.serverControll_0, "^7" + this.string_0);
            }
        }

        internal sealed class Class64
        {
            public Entity entity_0;
            public ServerControll serverControll_0;

            public void method_0()
            {
                Class67.smethod_125(this.serverControll_0, this.entity_0, "^7Password Active!");
                Class67.smethod_125(this.serverControll_0, this.entity_0, "^7You Are Admin ,You Don't Have To Enter It!");
            }

            public void method_1()
            {
                Class67.smethod_125(this.serverControll_0, this.entity_0, "^7Password Active!");
                Class67.smethod_125(this.serverControll_0, this.entity_0, "^7You Have Already Entered The Password!");
            }
        }

        internal sealed class Class65
        {
            public Entity entity_0;
            public ServerControll serverControll_0;

            public void method_0(Entity entity_1)
            {
                if ((this.serverControll_0.getPlayerID(entity_1).Equals("-/-/-") || this.serverControll_0.getPlayerGuid(entity_1).Equals("-/-/-")) && !this.serverControll_0.getPlayerIP(entity_1).Equals("0.0.0.0"))
                {
                    this.serverControll_0.method_5(entity_1);
                    this.serverControll_0.kikUser("Server", "k", this.entity_0, "^7AutoKick For Suspicion Use HACK!!!");
                }
                else
                {
                    Class67.smethod_13(this.serverControll_0, entity_1);
                    Class67.smethod_116(entity_1, this.serverControll_0);
                    this.serverControll_0.method_13(entity_1);
                    if (ServerControll.TypeMap == "sd")
                    {
                        Class67.smethod_3(entity_1, this.serverControll_0);
                    }
                }
            }
        }

        internal sealed class Class66
        {
            public int int_0;
            public ServerControll serverControll_0;

            public bool method_0()
            {
                if ((ServerControll.AllGiocatori.Count == 0) && (this.int_0 == 0))
                {
                    if (ServerControll.stato_passSS)
                    {
                        ServerControll.stato_passSS = false;
                        this.serverControll_0.Reconfig_Config();
                    }
                    if (Directory.Exists(ServerControll.DirTempFile))
                    {
                        Directory.Delete(ServerControll.DirTempFile, true);
                    }
                    this.serverControll_0.method_27("all");
                    Class67.smethod_33(this.serverControll_0, DateTime.Now.ToShortTimeString() + " - AutoRotation Map", new object[0]);
                    Utilities.ExecuteCommand("map_rotate");
                }
                this.int_0 = 0;
                return true;
            }
        }

        internal sealed class Class7
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        internal sealed class Class8
        {
            public ServerControll.Class7 class7_0;
            public int int_0;
            public string[] string_0;

            public bool method_0()
            {
                if ((this.int_0 < this.string_0.Length) && (this.string_0[this.int_0] != ""))
                {
                    Class67.smethod_125(this.class7_0.serverControll_0, this.class7_0.entity_0, "^5" + this.string_0[this.int_0]);
                    this.int_0++;
                    return true;
                }
                return false;
            }
        }

        internal sealed class Class9
        {
            public HudElem hudElem_0;

            public void method_0()
            {
                this.hudElem_0.Call("destroy", new Parameter[0]);
            }
        }

        public string message2 { get; set; }
    }
    public class DummyClass : BaseScript
    {
        public DummyClass()
        {
        }
    }
}
