namespace ServerControll
{
    using InfinityScript;
    using ns0;
    using ns1;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading;
    using System.Reflection;

    public class ServerControll : BaseScript
    {
        string CurrentGametype;
        string CurrentMap;
        string PreviousMap;
        private static Action<Entity, Parameter> action_0;
        internal static Action action_1;
        internal static Action action_2;
        private static Action<Entity> action_3;
        private static Action<Entity> action_4;
        private static Action<Entity> action_5;
        internal static bool bool_0 = false;
        internal static bool bool_1 = true;
        internal static bool bool_10 = false;
        internal static bool bool_11 = true;
        internal static bool bool_12 = true;
        internal static bool bool_13 = true;
        internal static bool bool_14 = true;
        internal static bool bool_15 = true;
        internal static bool bool_16 = true;
        internal static bool bool_17 = true;
        internal static bool bool_18 = false;
        internal static bool bool_19 = true;
        internal static bool bool_2 = false;
        internal static bool bool_20 = true;
        internal static bool bool_21 = true;
        internal static bool bool_22 = true;
        internal static bool bool_23 = false;
        internal static bool bool_24 = true;
        internal static bool bool_25 = true;
        internal static bool bool_26 = false;
        internal static bool bool_27 = false;
        internal static bool bool_28 = false;
        internal static bool bool_29 = false;
        internal static bool bool_3 = true;
        internal static bool bool_30 = false;
        internal static bool bool_31 = true;
        internal static bool bool_32 = false;
        internal static bool bool_33 = false;
        internal static bool bool_34 = true;
        internal static bool bool_35 = true;
        internal static bool bool_36 = false;
        internal static bool bool_37 = true;
        internal static bool bool_38 = false;
        internal static bool bool_39 = false;
        internal static bool bool_4 = false;
        internal static bool bool_40 = false;
        internal static bool bool_41 = true;
        internal static bool bool_42 = true;
        internal static bool bool_43 = true;
        internal static bool bool_44 = true;
        internal static bool bool_45 = false;
        internal static bool bool_46 = true;
        internal static bool bool_47 = true;
        internal static bool bool_48 = false;
        private static bool bool_49 = false;
        internal static bool bool_5 = true;
        private static bool bool_50 = true;
        internal static bool bool_51 = false;
        internal static bool bool_52 = true;
        internal static bool bool_53 = false;
        internal static bool bool_54 = false;
        internal static bool bool_6 = true;
        internal static bool bool_7 = true;
        internal static bool bool_8 = false;
        internal static bool bool_9 = false;
        internal static char char_0 = ' ';
        internal static char char_1 = ',';
        internal static char char_2 = ';';
        internal static char char_3 = '=';
        internal static char char_4 = '>';
        internal static char char_5 = '\x00a7';
        public static int Colorlvl01 = 5;
        public static int Colorlvl02 = 5;
        public static int Colorlvl03 = 5;
        public static int Colorlvl04 = 5;
        public static int Colorlvl05 = 5;
        public static int Colorlvl06 = 5;
        public static int Colorlvl07 = 5;
        public static int Colorlvl08 = 5;
        public static int Colorlvl09 = 5;
        public string[] comandiplayer;
        public static List<string> DBColorlvl = new List<string>();
        public static List<string> DBComandilvl = new List<string>();
        public static List<string> DBHelplvl = new List<string>();
        public static List<string> DBNomeGruppi = new List<string>();
        public static List<string> DBPlayerlvl = new List<string>();
        public static List<string> DBTaglvl = new List<string>();
        internal static Dictionary<int, int> dictionary_0 = new Dictionary<int, int>();
        internal static Dictionary<string, string> dictionary_1 = new Dictionary<string, string>();
        public string FileSession;
        public string FileUser;
        private static Func<Entity, bool> func_0;
        internal static Func<bool> func_1;
        internal static Func<Entity, bool> func_2;
        internal static HudElem hudElem_0 = HudElem.NewHudElem();
        internal static HudElem hudElem_1 = HudElem.NewHudElem();
        internal static HudElem hudElem_2 = HudElem.NewHudElem();
        internal static HudElem hudElem_3 = HudElem.NewHudElem();
        internal static HudElem hudElem_4 = HudElem.NewHudElem();
        internal static HudElem hudElem_5 = HudElem.NewHudElem();
        internal int int_0;
        internal int int_1;
        internal static int int_10 = 10;
        internal static int int_11 = 0xa8c0;
        internal static int int_12 = 0;
        internal static int int_13 = 12;
        internal static int int_14 = 0;
        private static int int_15 = 0;
        internal static int int_16 = 30;
        private static int int_17;
        private static int int_18;
        private static int int_19 = 0;
        internal int int_2;
        internal static int int_20 = 0;
        internal static int int_21 = 0;
        private static int int_22 = 0x7d0;
        internal static int int_23;
        private static int int_24 = 0;
        private static int int_25 = 0;
        internal static int int_26 = 1;
        internal static int int_27 = 0x1a00000;
        internal static int int_28 = 0;
        internal static int int_29 = 0;
        internal static int int_3 = 450;
        internal static int int_30 = 30;
        internal static int int_4 = 50;
        internal static int int_5 = 0x27;
        internal static int int_6 = 190;
        internal static int int_7 = 800;
        internal static int int_8 = 40;
        internal static int int_9 = 6;
        internal static List<int> list_0 = new List<int>();
        internal static List<string> list_1 = new List<string>();
        internal static List<Entity> list_10 = new List<Entity>();
        internal static List<string> list_11 = new List<string>();
        internal static List<string> list_12 = new List<string>();
        internal static List<Entity> list_2 = new List<Entity>();
        internal static List<Entity> list_3 = new List<Entity>();
        internal static List<Entity> list_4 = new List<Entity>();
        internal static List<Entity> list_5 = new List<Entity>();
        private static List<Entity> list_6 = new List<Entity>();
        private static List<Entity> list_7 = new List<Entity>();
        private static List<Entity> list_8 = new List<Entity>();
        private static List<Entity> list_9 = new List<Entity>();
        public MD5 md5Hash;
        public static MemClass Mem = new MemClass();
        public Dictionary<int, HudElem[]> MenuList;
        public static string NomeGruppo01 = "Friend";
        public static string NomeGruppo02 = "Vip";
        public static string NomeGruppo03 = "Member";
        public static string NomeGruppo04 = "ProMember";
        public static string NomeGruppo05 = "Captain";
        public static string NomeGruppo06 = "ModeratorAssistant";
        public static string NomeGruppo07 = "Moderator";
        public static string NomeGruppo08 = "Leader";
        public static string NomeGruppo09 = "Owner";
        private static Process process_0 = Process.GetCurrentProcess();
        private static Random random_0 = new Random();
        internal static Random random_1 = new Random();
        private static Random random_2 = new Random();
        public static string StrComandilvl00 = string.Empty;
        public static string StrComandilvl01 = string.Empty;
        public static string StrComandilvl02 = string.Empty;
        public static string StrComandilvl03 = string.Empty;
        public static string StrComandilvl04 = string.Empty;
        public static string StrComandilvl05 = string.Empty;
        public static string StrComandilvl06 = string.Empty;
        public static string StrComandilvl07 = string.Empty;
        public static string StrComandilvl08 = string.Empty;
        public static string StrComandilvl09 = string.Empty;
        internal static string string_0 = process_0.ProcessName;
        internal static string string_1 = Class75.smethod_65().ToString();
        internal static string string_10 = "^5IN^7FEC^1TED";
        internal static string string_100;
        internal static string string_101;
        internal static string string_102;
        internal static string string_103;
        internal static string string_104 = "-/--/-";
        internal static string string_105 = "normal";
        internal static string string_11 = "null";
        internal static string string_12 = "null";
        internal static string string_13 = "null";
        internal static string string_14 = "null";
        internal static string string_15 = "null";
        internal static string string_16 = "null";
        internal static string string_17 = "^7NaaBAdmin v4.0 by ^5MH11^7 - Info: ^1www.naabbax.ir";
        internal static string string_18 = "kill";
        internal static string string_19 = "tempban";
        internal static string string_2 = "teknomw3";
        internal static string string_20 = "https://naabbax.ir/";
        internal static string string_21 = "^1<playername> ^7has been ^1kicked ^7for ^5<reason> ^7by ^5<kicker>";
        internal static string string_22 = "^1<playername> ^7has been ^1banned ^7for ^5<reason> ^7by ^5<kicker>";
        internal static string string_23 = "^1<playername> ^7has been ^1TempBanned ^7for ^5<reason> ^7by ^5<kicker>";
        internal static string string_24 = "^5<playername> ^7welcome to the ^5<nameclan> ^7Server!";
        internal static string string_25 = "^5<playername> ^7welcome to the ^5<nameclan> ^7Server!";
        internal static string string_26 = "^5<playername> ^7welcome to the ^5<nameclan> ^7Server!";
        internal static string string_27 = "^5<playername> ^7welcome to the ^5<nameclan> ^7Server!";
        internal static string string_28 = "^5<playername> ^7welcome to the ^5<nameclan> ^7Server!";
        internal static string string_29 = "^5<playername> ^7welcome to the ^5<nameclan> ^7Server!";
        internal static string string_3 = "null";
        internal static string string_30 = "^5<playername> ^7welcome to the ^5<nameclan> ^7Server!";
        internal static string string_31 = "^5<playername> ^7welcome to the ^5<nameclan> ^7Server!";
        internal static string string_32 = "^5<playername> ^7welcome to the ^5<nameclan> ^7Server!";
        internal static string string_33 = "^5<playername> ^7welcome to the ^5<nameclan> ^7Server!";
        internal static string string_34 = "^1<playerdead> ^7is Spider Man :)";
        internal static string string_35 = "^1<playerdead> ^7troll by^5 <playerattack>";
        internal static string string_36 = "^1<playerdead> ^7HEAD-SHOT by^5 <playerattack>";
        internal static string string_37 = "^1<playerdead> ^7blown up :)";
        internal static string string_38 = "^5<playername> ^7is^1 AFK^7 or is a Camper!";
        internal static string string_39 = "^5<playerattack> ^7MultiKill with ^1Moab!";
        internal static string string_4 = "^7[^5NaaB^7]";
        internal static string string_40 = "^5<playerattack> ^7MOAB-FAIL ^1Hahaha!";
        internal static string string_41 = "^1Change your Nick, this nick not permitted!";
        internal static string string_42 = "^5Your account in BlackList... ^1You Ban!";
        internal static string string_43 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        internal static string string_44;
        internal static string string_45 = "NaaBAdmin";
        internal static string string_46 = "Admins.txt";
        internal static string string_47 = "Config.txt";
        internal static string string_48 = "Rules.txt";
        internal static string string_49 = "Adv.txt";
        internal static string string_5 = "NaaB";
        internal static string string_50 = "Messages.txt";
        internal static string string_51 = "BadWords.txt";
        internal static string string_52 = "Warn.txt";
        internal static string string_53 = "XlrStats.txt";
        internal static string string_54 = "TempBanList.txt";
        internal static string string_55 = "PermBanList.txt";
        internal static string string_56 = "Alias.txt";
        internal static string string_57 = "lastexit";
        internal static string string_58 = "StatsServer.txt";
        internal static string string_59 = "AdminLogin";
        internal static string string_6 = "www.naabbax.ir";
        internal static string string_60 = "SessionServer";
        private static string string_61 = "LogKickAimBot.txt";
        private static string string_62 = "LogKickNoRecoil.txt";
        private static string string_63 = "LogKickHack.txt";
        internal static string string_64 = "PlayerHackList.txt";
        private static string string_65 = "BlackListNickName.txt";
        private static string string_66 = "BlackListTagClan.txt";
        internal static string string_67 = "Voting";
        internal static string string_68 = "Ver";
        private static string string_69 = "http://www.btfitalianclan.com/script/servercontroll/gps/gps_controll.dat";
        internal static string string_7 = "^1TEAM B";
        internal static string string_70 = "http://www.btfitalianclan.com/script/servercontroll/update";
        internal static string string_71;
        private static string[] string_72 = new string[] { char_1.ToString(), char_2.ToString(), char_3.ToString(), char_4.ToString(), char_5.ToString() };
        internal static string[] string_73 = new string[] { "mp7", "akimbo", "skorpion", "ac130", "silencer", "killstreak", "remote", "helicopter", "airdrop", "osprey", "turret", "akimbo" };
        private static string[] string_74 = new string[] { "ac130", "killstreak", "remote", "helicopter", "osprey", "airdrop", "turret" };
        private static string[] string_75 = new string[] { 
            "ac130", "killstreak", "remote", "helicopter", "osprey", "airdrop", "turret", "a10_30mm_mp", "abrams_minigun_mp", "ac130_105mm_mp", "ac130_25mm_mp", "ac130_40mm_mp", "ac130_m​p", "airdrop_escort_marker", "airdrop_juggernaut_gl", "airdrop_mega_marker",
            "airdrop_sentry​_marker", "airdrop_tank_marker", "airdrop_trap_explosive_mp", "airdrop_trap_marker", "apache​_minigun_mp", "artillery_mp", "barrel_mp", "bmp_turret_mp", "bomb_site_mp", "bradley_turret_mp", "​bullet_ricochet_mp", "cobra_20mm_mp", "cobra_ffar_mp", "cobra_player_minigun_mp", "defaultwe​apon_mp", "deployable_vest_marker",
            "destructible", "destructible_car", "frag_grenade_short", "​harrier_20mm_mp", "harrier_ffar_mp", "helicopter_mp", "hind_ffar_mp", "humvee_50cal_mp", "ims_g​renade_mp", "ims_projectile_mp", "littlebird_guard_minigun_mp", "m1a1_turret_mp", "manned_gl​_turret_mp", "manned_littlebird_minigun_mp", "manned_littlebird_sniper_mp", "manned_minig​un_turret_mp",
            "minigun_littlebird_mp", "nuke_mp", "osprey_minigun_mp", "osprey_player_minig​un_mp", "pavelow_minigun_mp", "remote_mortar_missile_mp", "remote_tank_projectile_mp", "remo​temissile_mp", "remotemissile_projectile_mp", "ricochet_mp", "sam_projectile_mp", "saw_bipod​_stand_mp", "sentry_gun_mp", "sentry_minigun_mp", "smartarrow", "stealth_bomb_mp",
            "train_mp", "tu​rret_minigun_mp", "uav_strike_projectile_mp", "ugv_gl_turret_mp", "ugv_turret_mp", "weapon_c​obra_mk19_mp"
        };
        private static string[] string_76 = new string[] { 
            "iw5_l96a1_mp", "iw5_44magnum_mp", "iw5_usp45_mp", "iw5_deserteagle_mp", "iw5_mp412_mp", "iw5_g18_mp", "iw5_fmg9_mp", "iw5_mp9_mp", "iw5_skorpion_mp", "iw5_p99_mp", "iw5_fnfiveseven_mp", "rpg_mp", "iw5_smaw_mp", "stinger_mp", "javelin_mp", "xm25_mp",
            "iw5_usp45jugg_mp", "iw5_mp412jugg_mp", "iw5_m60jugg_mp", "iw5_riotshieldjugg_mp", "iw5_m4_mp", "riotshield_mp", "iw5_ak47_mp", "iw5_m16_mp", "iw5_fad_mp", "iw5_acr_mp", "iw5_type95_mp", "iw5_mk14_mp", "iw5_scar_mp", "iw5_g36c_mp", "iw5_cm901_mp", "iw5_mp5_mp",
            "iw5_mp7_mp", "iw5_m9_mp", "iw5_p90_mp", "iw5_pp90m1_mp", "iw5_ump45_mp", "iw5_barrett_mp", "iw5_rsass_mp", "iw5_dragunov_mp", "iw5_msr_mp", "iw5_as50_mp", "iw5_ksg_mp", "iw5_1887_mp", "iw5_striker_mp", "iw5_aa12_mp", "iw5_usas12_mp", "iw5_spas12_mp",
            "iw5_m60_mp", "iw5_mk46_mp", "iw5_pecheneg_mp", "iw5_sa80_mp", "emp_grenade_mp", "iw5_mg36_mp"
        };
        private static string[] string_77 = new string[] { "specialty_longersprint", "specialty_fastreload", "specialty_scavenger", "specialty_blindeye", "specialty_paint", "specialty_hardline", "specialty_coldblooded", "specialty_quickdraw", "specialty_twoprimaries", "specialty_assists", "specialty_blastshield", "specialty_detectexplosive", "specialty_autospot", "specialty_bulletaccuracy", "specialty_quieter", "specialty_stalker" };
        private static string[] string_78 = new string[] { "flash_grenade_mp", "concussion_grenade_mp", "smoke_grenade_mp", "emp_grenade_mp", "trophy_mp", "specialty_tacticalinsertion", "specialty_scrambler", "specialty_portable_radar" };
        private static string[] string_79 = new string[] { "frag_grenade_mp", "semtex_mp", "throwingknife_mp", "claymore_mp", "c4_mp", "bouncingbetty_mp", "specialty_portable_radar" };
        internal static string string_8 = "^5TEAM A";
        internal static string[] string_80 = new string[] { "iw5_barrett", "iw5_rsass", "iw5_dragunov", "iw5_msr", "iw5_l96a1", "iw5_as50" };
        private static string[] string_81 = new string[] { "war", "dm", "sd", "sab", "dom", "koth", "ctf", "dd", "tdef", "conf", "grnd", "tjugg", "jugg", "gun", "infect", "oic" };
        private static string[] string_82 = new string[] { "\x007f", "thisguyhax", "ChangeUrName", ".gseclan.", "Prodigi", "Splash", "NR||", "hkclan", "hkcl" };
        internal static string[] string_83 = new string[] { "hkclan", "hkcl" };
        internal static string string_84;
        internal static string string_85;
        internal static string string_86;
        internal static string string_87;
        internal static string string_88;
        private static string string_89;
        internal static string string_9 = "^1SUR^7VIV^5ORS";
        internal static string string_90;
        internal static string string_91 = null;
        internal static string string_92;
        internal static string string_93;
        internal static string string_94;
        internal static string string_95;
        internal static string string_96;
        internal static string string_97;
        private static string string_98 = null;
        internal static string string_99;
        public static string StrPlayerlvl01 = string.Empty;
        public static string StrPlayerlvl02 = string.Empty;
        public static string StrPlayerlvl03 = string.Empty;
        public static string StrPlayerlvl04 = string.Empty;
        public static string StrPlayerlvl05 = string.Empty;
        public static string StrPlayerlvl06 = string.Empty;
        public static string StrPlayerlvl07 = string.Empty;
        public static string StrPlayerlvl08 = string.Empty;
        public static string StrPlayerlvl09 = string.Empty;
        public Dictionary<int, HudElem[]> SubMenuList;
        public static string Taglvl01 = "^7[^5LvL^101^7]";
        public static string Taglvl02 = "^7[^5LvL^102^7]";
        public static string Taglvl03 = "^7[^5LvL^103^7]";
        public static string Taglvl04 = "^7[^5LvL^104^7]";
        public static string Taglvl05 = "^7[^5LvL^105^7]";
        public static string Taglvl06 = "^7[^5LvL^106^7]";
        public static string Taglvl07 = "^7[^5LvL^107^7]";
        public static string Taglvl08 = "^7[^5LvL^108^7]";
        public static string Taglvl09 = "^7[^5LvL^109^7]";
        public static string[] xStrComandiControlloPG = new string[] { "!fast", "!map", "!maprotate", "!restart", "!mod", "!k", "!kick", "!votecancel", "!password", "!tempban", "!tb", "!untempban", "!utb", "!tempbanexit", "!tbe", "!warnclear" };
        public static string xStrComandilvl00 = "!info,!list,!pm,!login,!access,!afk,!suicide,!admins,!time,!rules,!ver,!votemap,!votemod,!votekick,!voteban,!y,!n,!fov,!iamgod,!report,!nextmap,!register,!xlrstats,!xlrtopstats,!help,!ft,!fps";
        public static string xStrComandilvl01 = "!banlist,!team,!fast,!map,!balance,!mteam,!ateam";
        public static string xStrComandilvl02 = "!maprotate,!restart,!alias,!mod";
        public static string xStrComandilvl03 = "!k,!kick,!listall,!listbadwords,!w,!warn,!uw,!unwarn,!warnlist,!setafk";
        public static string xStrComandilvl04 = "!votecancel,!reportlist,!setnextmap!tempban,!tb,!untempban,!utb,!tempbanlist,!exitlist,!tempbanexit,!tbe,!listgroup";
        public static string xStrComandilvl05 = "!password,!showpass,!statuspass,!spam,!scream,!mute,!unmute,!spect";
        public static string xStrComandilvl06 = "!warnclear,!resetfog,!bot,!kb,!loadbots,!ban,!b,!unban,!ub,!ban2,!b2,!kill,!voting,!eb,!banexit,!be,!changeteam";
        public static string xStrComandilvl07 = "!chat,!night,!status,!kickall,!ka";
        public static string xStrComandilvl08 = "!listgroup,!setpw,!editpass,!add,!del,!minefield,!endround,!fire,!knife,!1shot,!addbadwords,!delbadwords,!addadv,!addrules,!j,!s,!g";
        public static string xStrComandilvl09 = "!delalias,!resetadmin,!downgrade,!setclient,!load,!unload,!reboot,!svname,!invisiblegod,!ac130,!sb,!ammo,!god,!unfreez,!freez,!fly,!bomb,!uav,!tp,!cw";

        public ServerControll()
        {
            Action<Entity> action = null;
            Action<Entity> action2 = null;
            Action<Entity> action3 = null;
            Action handler = null;
            Action action5 = null;
            this.int_0 = 10;
            this.int_1 = 8;
            this.int_2 = 600;
            this.FileUser = "UserLogin.dat";
            this.FileSession = "UserLoginSession";
            this.md5Hash = MD5.Create();
            this.MenuList = new Dictionary<int, HudElem[]>();
            this.SubMenuList = new Dictionary<int, HudElem[]>();
            this.comandiplayer = new string[] { "Info", "Kick", "TempBan 60min", "Permanent Ban", "Set AFK", "Change Team", "Kill Player", "Teleport to Player" };
            Mem.MyProcess_Handle();
            Class75.smethod_117(this);
            Class75.smethod_29(this);
            DateTimeFormatInfo info = new DateTimeFormatInfo();
            string str = info.GetMonthName(DateTime.Now.Month) + "_" + DateTime.Now.Year;
            string_84 = string_43 + @"\" + string_45 + @"\";
            string_86 = string_43 + @"\" + string_45 + @"\LogConnect\" + str + @"\";
            string_87 = string_43 + @"\" + string_45 + @"\LogChat\" + str + @"\";
            string_88 = string_43 + @"\" + string_45 + @"\TempFile\";
            string_89 = string_43 + @"\" + string_45 + @"\LogError\";
            string_90 = string_43 + @"\" + string_45 + @"\LogConsole\" + str + @"\";
            string_99 = string_43 + @"\" + string_45 + @"\gps_controll.dat";
            string_71 = string_88 + "update";
            string_85 = string_84;
            if (!Directory.Exists(string_84))
            {
                Directory.CreateDirectory(string_84);
            }
            if (!Directory.Exists(string_86))
            {
                Directory.CreateDirectory(string_86);
            }
            if (!Directory.Exists(string_87))
            {
                Directory.CreateDirectory(string_87);
            }
            if (!Directory.Exists(string_88))
            {
                Directory.CreateDirectory(string_88);
            }
            if (!Directory.Exists(string_90))
            {
                Directory.CreateDirectory(string_90);
            }
            Class75.smethod_70(this);
            Class75.smethod_159(this);
            if (System.IO.File.Exists(string_88 + "nextmodmap"))
            {
                string[] strArray2 = System.IO.File.ReadAllLines(string_88 + "nextmodmap");
                System.IO.File.Delete(string_88 + "nextmodmap");
                Class75.smethod_6(this, "map " + strArray2[0], 500);
            }
            if (System.IO.File.Exists(string_88 + string_67))
            {
                bool_48 = true;
            }
            Class75.smethod_123(this);
            Class75.smethod_67(this);
            Class75.smethod_109(this);
            Class75.smethod_51(this);
            Class75.smethod_215(this);
            Class75.smethod_5(this);
            Class75.smethod_0(this);
            Class75.smethod_116(this);
            Class75.smethod_126(this);
            Class75.smethod_114(this);
            Class75.smethod_124(this);
            if (action == null)
            {
                action = new Action<Entity>(this.method_46);
            }
            base.PlayerConnecting += action;
            if (action2 == null)
            {
                action2 = new Action<Entity>(this.method_47);
            }
            CurrentGametype = Call<string>("getdvar", "ui_gametype");
            CurrentMap = Call<string>("getdvar", "mapname");
            PreviousMap = Call<string>("getdvar", "previousmap");
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
            base.PlayerConnected += action2;
            if (action3 == null)
            {
                action3 = new Action<Entity>(this.method_48);
            }
            base.PlayerDisconnected += action3;
            if (handler == null)
            {
                handler = new Action(this.method_49);
            }
            base.OnNotify("game_over", handler);
            if (action5 == null)
            {
                action5 = new Action(this.method_50);
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

        public int getBotLook(Entity player)
        {
            if (player.HasField("visto"))
            {
                return player.GetField<int>("visto");
            }
            return 0;
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
                string str2 = "";
                for (int i = 0; i < 12; i++)
                {
                    str2 = str2 + buffer[i].ToString("X2");
                }
                return str2;
            }
            catch
            {
                return "000000000000000000000000";
            }
        }

        public IPAddress GetIPAddress(int ClientNum)
        {
            byte[] destination = new byte[4];
            Marshal.Copy((IntPtr) ((0x49eb690 + (ClientNum * 0x78688)) + 0x2c), destination, 0, 4);
            return new IPAddress(destination);
        }

        public static string GetLastString(string source, int tail_length, int fine = 0)
        {
            if (tail_length >= source.Length)
            {
                return source;
            }
            if (fine > 0)
            {
                return source.Substring(source.Length - tail_length, fine);
            }
            return source.Substring(source.Length - tail_length);
        }

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] buffer = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < buffer.Length; i++)
            {
                builder.Append(buffer[i].ToString("x2"));
            }
            return builder.ToString();
        }

        public int getPlayerAccess(Entity player)
        {
            if (player.HasField("AccAServer"))
            {
                return player.GetField<int>("AccAServer");
            }
            return 0;
        }

        public int getPlayerAFK(Entity player)
        {
            if (player.HasField("Afk"))
            {
                return player.GetField<int>("Afk");
            }
            return 0;
        }

        public string getPlayerCODE(Entity player)
        {
            string str = this.getPlayerID(player);
            string source = this.getPlayerGuid(player);
            string str3 = this.getPlayerXuid(player);
            string str4 = this.getPlayerHWID(player);
            string input = string.Empty;
            if (((source.Contains(string_104) || str3.Contains(string_104)) || str4.Contains(string_104)) || str.Contains(string_104))
            {
                input = string_104;
            }
            else
            {
                input = (GetLastString(source, 10, 0) + str + GetLastString(str3, 10, 0)).ToLower();
            }
            return GetMd5Hash(this.md5Hash, input);
        }

        public string getPlayerGuid(Entity player)
        {
            try
            {
                return player.GUID.ToString().ToLower();
            }
            catch
            {
                return string_104;
            }
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
            catch
            {
                return string_104;
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

        public int getPlayerMoab(Entity player)
        {
            if (player.HasField("UsrMoab"))
            {
                return player.GetField<int>("UsrMoab");
            }
            return 0;
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
            foreach (Entity entity in list_3)
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

        public int getPlayerPsw(Entity player)
        {
            if (player.HasField("userorigin"))
            {
                return player.GetField<int>("userorigin");
            }
            return 0;
        }

        public int getPlayerPswOk(Entity player)
        {
            if (player.HasField("useroriginok"))
            {
                return player.GetField<int>("useroriginok");
            }
            return 0;
        }

        public string getPlayerSlot(Entity player)
        {
            try
            {
                return player.Call<int>("getentitynumber", new Parameter[0]).ToString();
            }
            catch
            {
                return string_104;
            }
        }

        public int getPlayerSpect(Entity player)
        {
            if (player.HasField("UsrSpect"))
            {
                return player.GetField<int>("UsrSpect");
            }
            return 0;
        }

        public string getPlayerTag(Entity player)
        {
            if (player.HasField("TagPlayer"))
            {
                return player.GetField<string>("TagPlayer");
            }
            return string_104;
        }

        public int getPlayerTentavivi(Entity player)
        {
            if (player.HasField("PSWTent"))
            {
                return player.GetField<int>("PSWTent");
            }
            return 0;
        }

        public string getPlayerTmpINF(Entity player)
        {
            if (player.HasField("tmpinfect"))
            {
                return player.GetField<string>("tmpinfect");
            }
            return "null";
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
                return player.Call<string>("getxuid", new Parameter[0]).ToLower();
            }
            catch
            {
                return string_104;
            }
        }

        public static string GetServerIP()
        {
            string str;
            try
            {
                str = Class75.smethod_134("http://bot.whatismyipaddress.com");
            }
            catch (Exception)
            {
                return "";
            }
            return str;
        }

        public string GruppiOnline(int num)
        {
            string str = "";
            foreach (Entity entity in list_3)
            {
                if ((this.getPlayerLevel(entity) == num) && (this.getPlayerAccess(entity) != 0))
                {
                    str = str + this.getPlayerName(entity) + "^1,^5";
                }
            }
            if (str != "")
            {
                int length = str.Length - 3;
                return str.Substring(0, length);
            }
            return ("^5" + string_104);
        }

        public static bool isBool(string value)
        {
            bool flag;
            return bool.TryParse(value, out flag);
        }

        public static bool isDate(string value)
        {
            DateTime time;
            return DateTime.TryParse(value, out time);
        }

        public static bool isFloatNum(string value)
        {
            float num;
            return float.TryParse(value, out num);
        }

        public bool IsJoinUsers(Entity player)
        {
            bool flag = false;
            foreach (Entity entity in list_10)
            {
                if (this.getPlayerGuid(player) == this.getPlayerGuid(entity))
                {
                    flag = true;
                }
            }
            return flag;
        }

        public static bool isNum(string value)
        {
            int num;
            return int.TryParse(value, out num);
        }

        public bool IsUserSession(Entity player)
        {
            bool flag = false;
            foreach (string str in list_11)
            {
                if (this.getPlayerName(player).Equals(str))
                {
                    flag = true;
                }
            }
            return flag;
        }

        public static void LogErrori(string funzione, Exception error, string note = "---")
        {
            try
            {
                string str = string.Concat(new object[] { "LogError_", DateTime.Now.Day, ".", DateTime.Now.Month, ".", DateTime.Now.Year, ".txt" });
                string str2 = "";
                if (!Directory.Exists(string_89))
                {
                    Directory.CreateDirectory(string_89);
                }
                using (StreamWriter writer = new StreamWriter(string_89 + str, true))
                {
                    writer.WriteLine(string.Concat(new object[] { "Date: ", DateTime.Now.Day, ".", DateTime.Now.Month, ".", DateTime.Now.Year }));
                    writer.WriteLine(string.Concat(new object[] { "Time: ", DateTime.Now.Hour, ":", DateTime.Now.Minute, ":", DateTime.Now.Second }));
                    writer.WriteLine("Map: " + string_92);
                    writer.WriteLine("MapType: " + string_93);
                    writer.WriteLine("Mod: " + string_100);
                    writer.WriteLine("Nr. Player: " + list_3.Count);
                    for (int i = 0; i < list_3.Count; i++)
                    {
                        str2 = str2 + char_1 + list_3[i].Name;
                    }
                    writer.WriteLine("Player: " + str2.TrimStart(new char[] { char_1 }));
                    writer.WriteLine("Version: " + string_1);
                    writer.WriteLine("Function: " + funzione);
                    writer.WriteLine("Target: " + error.TargetSite);
                    writer.WriteLine("Notes: " + note);
                    writer.WriteLine("Message: " + error.Message);
                    writer.WriteLine("==================================================================================================================");
                    writer.Close();
                }
            }
            catch (Exception exception)
            {
                InfinityScript.Log.Write(InfinityScript.LogLevel.All, "Error LogErrori => " + exception.Message);
            }
        }

        public string lookupIP(string ip)
        {
            try
            {
                string str = "";
                if (ip.StartsWith("192.168"))
                {
                    return "^5LocalIP";
                }
                Location location = new LookupService(string_99, LookupService.GEOIP_STANDARD).getLocation(ip);
                if (location != null)
                {
                    if (location.city.Trim() != "")
                    {
                        str = "^5" + location.city + "^1/^5" + location.countryName;
                    }
                    else
                    {
                        str = "^5" + location.countryName;
                    }
                }
                else
                {
                    str = "^5<unknown>";
                }
                return str;
            }
            catch
            {
                return "^5<unknown>";
            }
        }

        public string messpass(Entity player)
        {
           return ("^5You have ^1" + player.GetField<int>("TimePass") + " ^5seconds to enter the password!");
        }

        internal void method_0(string string_106)
        {
            bool_53 = false;
            if (string_106 == "all")
            {
                foreach (Entity entity in list_5)
                {
                    Class75.smethod_6(this, "dropclient " + entity.EntRef, 0);
                }
            }
            else
            {
                foreach (Entity entity in list_5)
                {
                    if (entity.Name.Contains(string_106))
                    {
                        Class75.smethod_6(this, "dropclient " + entity.EntRef, 0);
                    }
                }
            }
        }

        private void method_1(Entity entity_0, string string_106)
        {
            Class1 class2 = new Class1();
            Random random = new Random();
            class2.string_0 = "class" + random.Next(1, 4).ToString();
            entity_0.Notify("menuresponse", new Parameter[] { "team_marinesopfor", string_106 });
            entity_0.OnNotify("joined_team", new Action<Entity>(class2.method_0));
            if (action_0 == null)
            {
                action_0 = new Action<Entity, Parameter>(ServerControll.smethod_0);
            }
            entity_0.OnNotify("weapon_fired", action_0);
            Class75.smethod_143(entity_0, this);
            if (func_0 == null)
            {
                func_0 = new Func<Entity, bool>(ServerControll.smethod_1);
            }
            entity_0.OnInterval(0x2710, func_0);
        }

        private void method_10(Entity entity_0, string string_106, int int_31)
        {
            if (System.IO.File.Exists(string_88 + string_57))
            {
                string[] strArray = System.IO.File.ReadAllLines(string_88 + string_57);
                bool flag = false;
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { char_1 });
                    for (int j = 0; j < 2; j++)
                    {
                        if (strArray2[j].ToLower().Contains(string_106))
                        {
                            if (this.getPlayerLevel(entity_0) > Class75.smethod_145(this, strArray2[2]))
                            {
                                goto Label_00A4;
                            }
                            Class75.smethod_73(this, entity_0, "^1Error - You can not TempBan a player with your same level!");
                        }
                    }
                    goto Label_0167;
                Label_00A4:
                    flag = true;
                    using (StreamWriter writer = new StreamWriter(string_85 + string_54, true))
                    {
                        writer.WriteLine(string.Concat(new object[] { DateTime.Now, char_2.ToString(), int_31, char_1, strArray[i] }));
                        writer.Close();
                    }
                    Class75.smethod_73(this, entity_0, "^5Player ^1" + strArray2[0] + "^7[^1" + strArray2[1] + "^7] ^5successfully TempBanned!");
                Label_0167:
                    if (flag)
                    {
                        break;
                    }
                }
                if (!flag)
                {
                    Class75.smethod_73(this, entity_0, "^1No Player Found");
                }
            }
        }

        private void method_11(Entity entity_0, string string_106)
        {
            if (System.IO.File.Exists(string_88 + string_57))
            {
                string[] strArray = System.IO.File.ReadAllLines(string_88 + string_57);
                bool flag = false;
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { char_1 });
                    for (int j = 0; j < 2; j++)
                    {
                        if (strArray2[j].ToLower().Contains(string_106))
                        {
                            if (this.getPlayerLevel(entity_0) > Class75.smethod_145(this, strArray2[2]))
                            {
                                goto Label_00A4;
                            }
                            Class75.smethod_73(this, entity_0, "^1Error - You can not PermBan a player with your same level!");
                        }
                    }
                    goto Label_0139;
                Label_00A4:
                    flag = true;
                    using (StreamWriter writer = new StreamWriter(string_85 + string_55, true))
                    {
                        writer.WriteLine(DateTime.Now + char_1.ToString() + strArray[i]);
                        writer.Close();
                    }
                    Class75.smethod_73(this, entity_0, "^5Player ^1" + strArray2[0] + "^7[^1" + strArray2[1] + "^7] ^5successfully Banned!");
                Label_0139:
                    if (flag)
                    {
                        break;
                    }
                }
                if (!flag)
                {
                    Class75.smethod_73(this, entity_0, "^1No Player Found");
                }
            }
        }

        internal void method_12(Entity entity_0, string string_106)
        {
            using (StreamWriter writer = new StreamWriter(string_85 + string_62, true))
            {
                string str = string.Concat(new object[] { 
                    DateTime.Now, char_1.ToString(), this.getPlayerName(entity_0), char_1, this.getPlayerID(entity_0), char_1, this.getPlayerGuid(entity_0), char_1, this.getPlayerHWID(entity_0), char_1, this.getPlayerXuid(entity_0), char_1, this.getPlayerIP(entity_0), char_1, "^5Suspect use ^1NORECOIL^5 with weapon ^1", string_106,
                    " ^7on ^5", DateTime.Now
                });
                writer.WriteLine(str);
                writer.Close();
            }
        }

        internal void method_13(Entity entity_0, string string_106)
        {
            using (StreamWriter writer = new StreamWriter(string_85 + string_61, true))
            {
                string str = string.Concat(new object[] { 
                    DateTime.Now, char_1.ToString(), this.getPlayerName(entity_0), char_1, this.getPlayerID(entity_0), char_1, this.getPlayerGuid(entity_0), char_1, this.getPlayerHWID(entity_0), char_1, this.getPlayerXuid(entity_0), char_1, this.getPlayerIP(entity_0), char_1, "^5Suspect use ^1AIMBOT^5 with weapon ^1", string_106,
                    " ^7on ^5", DateTime.Now
                });
                writer.WriteLine(str);
                writer.Close();
            }
        }

        internal void method_14(Entity entity_0)
        {
            using (StreamWriter writer = new StreamWriter(string_85 + string_63, true))
            {
                string str = string.Concat(new object[] { DateTime.Now, char_1.ToString(), this.getPlayerName(entity_0), char_1, this.getPlayerID(entity_0), char_1, this.getPlayerGuid(entity_0), char_1, this.getPlayerHWID(entity_0), char_1, this.getPlayerXuid(entity_0), char_1, this.getPlayerIP(entity_0), char_1, "^5Suspect use ^1HACK^5 on ^1", DateTime.Now });
                writer.WriteLine(str);
                writer.Close();
            }
        }

        private void method_15()
        {
            if (int_3 != 0)
            {
                foreach (Entity entity in list_3)
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
                        if (ping > int_3)
                        {
                            if (field >= 5)
                            {
                                if (this.getPlayerLevel(entity) < 2)
                                {
                                    Class75.smethod_20(this, "Server", "k", entity, "^1Your Ping is too high if you can fix it!");
                                }
                            }
                            else
                            {
                                field++;
                                entity.SetField("Ping", field);
                                Class75.smethod_73(this, entity, string.Concat(new object[] { "^5Detected Ping^7[^1", ping, "^7] ^5Too High! ^7- ^5Notice Nr ^1", field, "^7/^15" }));
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

        private void method_16()
        {
            try
            {
                foreach (Entity entity in list_3)
                {
                    bool flag = true;
                    if (!(entity.IsAlive && (entity.GetField<string>("sessionstate") != "spectator")))
                    {
                        Class75.smethod_218(1, this, entity);
                        entity.SetField("AfkPos", new Vector3(0f, 0f, 0f));
                        flag = false;
                    }
                    if (flag)
                    {
                        if (entity.HasField("AfkPos"))
                        {
                            if (entity.GetField<Vector3>("AfkPos").DistanceTo2D(entity.Origin) < 2f)
                            {
                                if (entity.HasField("AfkPT"))
                                {
                                    int num = entity.GetField<int>("AfkPT") + 1;
                                    if (num > 2)
                                    {
                                        Class75.smethod_218(1, this, entity);
                                        entity.SetField("AfkPT", num);
                                        if ((!string_93.Contains("inf") && (string_100 != "hide")) && bool_37)
                                        {
                                            Class75.smethod_158(this, entity, "^1You are AFK, wake up!!!");
                                            if (num.ToString().EndsWith("5") || num.ToString().EndsWith("0"))
                                            {
                                                Class75.smethod_64(this, string_38.Replace("<playername>", this.getPlayerName(entity)));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Class75.smethod_218(0, this, entity);
                                        entity.SetField("AfkPT", num);
                                    }
                                }
                                else
                                {
                                    Class75.smethod_218(0, this, entity);
                                    entity.SetField("AfkPT", 0);
                                }
                            }
                            else
                            {
                                Class75.smethod_218(0, this, entity);
                                entity.SetField("AfkPT", 0);
                            }
                        }
                        entity.SetField("AfkPos", entity.Origin);
                    }
                }
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("array"))
                {
                    LogErrori("ControllAfk", exception, "---");
                }
            }
        }

        private void method_17()
        {
            try
            {
                if (bool_12)
                {
                    foreach (Entity entity in list_3)
                    {
                        string str;
                        if (string_2.StartsWith("te"))
                        {
                            str = this.getPlayerHWID(entity);
                        }
                        else
                        {
                            str = this.getPlayerGuid(entity);
                        }
                        if (dictionary_1.ContainsKey(str))
                        {
                            if (dictionary_1[str] != this.getPlayerName(entity))
                            {
                                if (bool_20)
                                {
                                    string str2 = "add";
                                    string str3 = "Unauthorized change nick!";
                                    Class75.smethod_24(str2, this, entity, null, str3);
                                }
                                Class75.smethod_64(this, "^5" + dictionary_1[str] + " ^7ID^1 " + this.getPlayerID(entity) + " ^5changed nick:^1 " + this.getPlayerName(entity));
                                Class75.smethod_84(dictionary_1[str] + " changed nick in " + this.getPlayerName(entity), this);
                                Class75.smethod_20(this, "Server", "k", entity, "Unauthorized change nick!");
                            }
                        }
                        else
                        {
                            dictionary_1.Add(str, this.getPlayerName(entity));
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                LogErrori("AntiCambioNick", exception, "---");
            }
        }

        private void method_18(Entity entity_0)
        {
            Class42 class2 = new Class42 {
                entity_0 = entity_0
            };
            class2.entity_0.SetField("Voto", 0);
            class2.entity_0.SetField("AntiAIM", 0);
            class2.entity_0.SetField("Mute", 0);
            class2.entity_0.SetClientDvar("cg_drawFPS", "Simple");
            class2.entity_0.SetClientDvar("cl_demo_enabled", "1");
            class2.entity_0.SetClientDvar("theater_active", "1");
            class2.entity_0.SetClientDvar("waypointiconheight", int_13.ToString());
            class2.entity_0.SetClientDvar("waypointiconwidth", int_13.ToString());
            class2.entity_0.SetClientDvar("waypointOffscreenPointerHeight", (int_13 - 4).ToString());
            class2.entity_0.SetClientDvar("waypointOffscreenPointerWidth", (int_13 - 4).ToString());
            class2.entity_0.OnInterval(0x1388, new Func<Entity, bool>(class2.method_0));
            if (string_93.Contains("inf"))
            {
                if ((string_13 != null) && (string_13 != "null"))
                {
                    base.Call("setdvar", new Parameter[] { "g_teamicon_allies", string_13 });
                    base.Call("setdvar", new Parameter[] { "g_TeamIcon_EnemyAllies", string_13 });
                    base.Call("setdvar", new Parameter[] { "g_TeamIcon_MyAllies", string_13 });
                }
                if ((string_14 != null) && (string_14 != "null"))
                {
                    base.Call("setdvar", new Parameter[] { "g_teamicon_axis", string_14 });
                    base.Call("setdvar", new Parameter[] { "g_TeamIcon_EnemyAxis", string_14 });
                    base.Call("setdvar", new Parameter[] { "g_TeamIcon_MyAxis", string_14 });
                }
                if ((string_9 != null) && (string_9 != "null"))
                {
                    class2.entity_0.SetClientDvar("g_teamname_allies", string_9);
                }
                if ((string_10 != null) && (string_10 != "null"))
                {
                    class2.entity_0.SetClientDvar("g_teamname_axis", string_10);
                }
            }
            else
            {
                if ((string_11 != null) && (string_11 != "null"))
                {
                    base.Call("setdvar", new Parameter[] { "g_teamicon_allies", string_11 });
                    base.Call("setdvar", new Parameter[] { "g_TeamIcon_EnemyAllies", string_11 });
                    base.Call("setdvar", new Parameter[] { "g_TeamIcon_MyAllies", string_11 });
                }
                if ((string_12 != null) && (string_12 != "null"))
                {
                    base.Call("setdvar", new Parameter[] { "g_teamicon_axis", string_12 });
                    base.Call("setdvar", new Parameter[] { "g_TeamIcon_EnemyAxis", string_12 });
                    base.Call("setdvar", new Parameter[] { "g_TeamIcon_MyAxis", string_12 });
                }
                if (((string_7 != null) && (string_7 != "null")) && (string_100 != "hide"))
                {
                    class2.entity_0.SetClientDvar("g_teamname_allies", string_7);
                }
                if (((string_8 != null) && (string_8 != "null")) && (string_100 != "hide"))
                {
                    class2.entity_0.SetClientDvar("g_teamname_axis", string_8);
                }
            }
            if (bool_7)
            {
                class2.entity_0.SetClientDvar("useRelativeTeamColors", "1");
            }
            else
            {
                class2.entity_0.SetClientDvar("useRelativeTeamColors", "0");
            }
            if (bool_49)
            {
                class2.entity_0.SetClientDvar("r_lightmap", "0");
            }
            else
            {
                class2.entity_0.SetClientDvar("r_lightmap", "1");
            }
            if (bool_13)
            {
                if (action_3 == null)
                {
                    action_3 = new Action<Entity>(ServerControll.smethod_5);
                }
                class2.entity_0.AfterDelay(0x3e8, action_3);
            }
            if (bool_18)
            {
                if (action_4 == null)
                {
                    action_4 = new Action<Entity>(ServerControll.smethod_6);
                }
                class2.entity_0.AfterDelay(0x7d0, action_4);
                if (action_5 == null)
                {
                    action_5 = new Action<Entity>(ServerControll.smethod_7);
                }
                class2.entity_0.AfterDelay(0xbb8, action_5);
            }
            else
            {
                class2.entity_0.SetClientDvar("r_detail", "1");
            }
        }

        private void method_19(Entity entity_0, string string_106)
        {
            foreach (Entity entity in list_3)
            {
                if (this.getPlayerLevel(entity) > 5)
                {
                    if (entity_0 != null)
                    {
                        Utilities.RawSayTo(entity, "^7[^5" + this.getPlayerName(entity_0) + "^7][PM]: " + string_106);
                    }
                    else
                    {
                        Utilities.RawSayTo(entity, "^7[" + string_4 + "^5 for Admin^7][PM]: " + string_106);
                    }
                }
            }
        }

        private void method_2(Entity entity_0, string string_106)
        {
            Func<bool> function = null;
            Action action = null;
            Class3 class2 = new Class3 {
                entity_0 = entity_0,
                serverControll_0 = this
            };
            string[] strArray = string_106.ToLower().Trim().Split(new char[] { char_0 });
            string[] strArray2 = string_106.Trim().Split(new char[] { char_0 });
            string_106.ToLower().Trim();
            string str = strArray[0];
            try
            {
                Entity current;
                string str3;
                string str4;
                int num3;
                int num4;
                Entity entity3;
                string str5;
                List<Entity>.Enumerator enumerator;
                int num5;
                IniParser parser;
                int num7;
                Entity entity10;
                string str12;
                Entity entity11;
                string str14;
                string str15;
                Class4 class3;
                int num12;
                bool flag;
                string[] strArray3;
                string key = str;
                if (key != null)
                {
                    int num;
                    if (Class74.dictionary_0 == null)
                    {
                        Dictionary<string, int> dictionary1 = new Dictionary<string, int>(0x81) {
                            { 
                                "!listgroup",
                                0
                            },
                            { 
                                "!delpsw",
                                1
                            },
                            { 
                                "!add",
                                2
                            },
                            { 
                                "!del",
                                3
                            },
                            { 
                                "!ateam",
                                4
                            },
                            { 
                                "!mteam",
                                5
                            },
                            { 
                                "!cw",
                                6
                            },
                            { 
                                "!ammo",
                                7
                            },
                            { 
                                "!alias",
                                8
                            },
                            { 
                                "!exitlist",
                                9
                            },
                            { 
                                "!banexit",
                                10
                            },
                            { 
                                "!be",
                                11
                            },
                            { 
                                "!tempbanexit",
                                12
                            },
                            { 
                                "!tbe",
                                13
                            },
                            { 
                                "!god",
                                14
                            },
                            { 
                                "!unfreez",
                                15
                            },
                            { 
                                "!freez",
                                0x10
                            },
                            { 
                                "!fly",
                                0x11
                            },
                            { 
                                "!bomb",
                                0x12
                            },
                            { 
                                "!uav",
                                0x13
                            },
                            { 
                                "!tp",
                                20
                            },
                            { 
                                "!sb",
                                0x15
                            },
                            { 
                                "!eb",
                                0x16
                            },
                            { 
                                "!1shot",
                                0x17
                            },
                            { 
                                "!knife",
                                0x18
                            },
                            { 
                                "!ac130",
                                0x19
                            },
                            { 
                                "!fps",
                                0x1a
                            },
                            { 
                                "!invisiblegod",
                                0x1b
                            },
                            { 
                                "!fire",
                                0x1c
                            },
                            { 
                                "!svname",
                                0x1d
                            },
                            { 
                                "!spect",
                                30
                            },
                            { 
                                "!setafk",
                                0x1f
                            },
                            { 
                                "!afk",
                                0x20
                            },
                            { 
                                "!endround",
                                0x21
                            },
                            { 
                                "!minefield",
                                0x22
                            },
                            { 
                                "!ft",
                                0x23
                            },
                            { 
                                "!loadbots",
                                0x24
                            },
                            { 
                                "!update",
                                0x25
                            },
                            { 
                                "!info",
                                0x26
                            },
                            { 
                                "!kb",
                                0x27
                            },
                            { 
                                "!bot",
                                40
                            },
                            { 
                                "!setclient",
                                0x29
                            },
                            { 
                                "!downgrade",
                                0x2a
                            },
                            { 
                                "!reboot",
                                0x2b
                            },
                            { 
                                "!load",
                                0x2c
                            },
                            { 
                                "!unload",
                                0x2d
                            },
                            { 
                                "!j",
                                0x2e
                            },
                            { 
                                "!s",
                                0x2f
                            },
                            { 
                                "!g",
                                0x30
                            },
                            { 
                                "!addbadwords",
                                0x31
                            },
                            { 
                                "!delbadwords",
                                50
                            },
                            { 
                                "!addadv",
                                0x33
                            },
                            { 
                                "!addrules",
                                0x34
                            },
                            { 
                                "!ban",
                                0x35
                            },
                            { 
                                "!b",
                                0x36
                            },
                            { 
                                "!ban2",
                                0x37
                            },
                            { 
                                "!b2",
                                0x38
                            },
                            { 
                                "!unban",
                                0x39
                            },
                            { 
                                "!ub",
                                0x3a
                            },
                            { 
                                "!setpw",
                                0x3b
                            },
                            { 
                                "!night",
                                60
                            },
                            { 
                                "!kill",
                                0x3d
                            },
                            { 
                                "!voting",
                                0x3e
                            },
                            { 
                                "!chat",
                                0x3f
                            },
                            { 
                                "!status",
                                0x40
                            },
                            { 
                                "!changeteam",
                                0x41
                            },
                            { 
                                "!tb",
                                0x42
                            },
                            { 
                                "!tempban",
                                0x43
                            },
                            { 
                                "!untempban",
                                0x44
                            },
                            { 
                                "!utb",
                                0x45
                            },
                            { 
                                "!delalias",
                                70
                            },
                            { 
                                "!warnclear",
                                0x47
                            },
                            { 
                                "!banlist",
                                0x48
                            },
                            { 
                                "!tempbanlist",
                                0x49
                            },
                            { 
                                "!mute",
                                0x4a
                            },
                            { 
                                "!unmute",
                                0x4b
                            },
                            { 
                                "!editpass",
                                0x4c
                            },
                            { 
                                "!map",
                                0x4d
                            },
                            { 
                                "!fast",
                                0x4e
                            },
                            { 
                                "!restart",
                                0x4f
                            },
                            { 
                                "!maprotate",
                                80
                            },
                            { 
                                "!kick",
                                0x51
                            },
                            { 
                                "!k",
                                0x52
                            },
                            { 
                                "!kickall",
                                0x53
                            },
                            { 
                                "!ka",
                                0x54
                            },
                            { 
                                "!mod",
                                0x55
                            },
                            { 
                                "!warn",
                                0x56
                            },
                            { 
                                "!w",
                                0x57
                            },
                            { 
                                "!warnlist",
                                0x58
                            },
                            { 
                                "!unwarn",
                                0x59
                            },
                            { 
                                "!uw",
                                90
                            },
                            { 
                                "!password",
                                0x5b
                            },
                            { 
                                "!setnextmap",
                                0x5c
                            },
                            { 
                                "!showpass",
                                0x5d
                            },
                            { 
                                "!statuspass",
                                0x5e
                            },
                            { 
                                "!list",
                                0x5f
                            },
                            { 
                                "!listall",
                                0x60
                            },
                            { 
                                "!reportlist",
                                0x61
                            },
                            { 
                                "!listbadwords",
                                0x62
                            },
                            { 
                                "!resetfog",
                                0x63
                            },
                            { 
                                "!scream",
                                100
                            },
                            { 
                                "!spam",
                                0x65
                            },
                            { 
                                "!pm",
                                0x66
                            },
                            { 
                                "!votecancel",
                                0x67
                            },
                            { 
                                "!balance",
                                0x68
                            },
                            { 
                                "!suicide",
                                0x69
                            },
                            { 
                                "!admins",
                                0x6a
                            },
                            { 
                                "!time",
                                0x6b
                            },
                            { 
                                "!rules",
                                0x6c
                            },
                            { 
                                "!help",
                                0x6d
                            },
                            { 
                                "!nextmap",
                                110
                            },
                            { 
                                "!team",
                                0x6f
                            },
                            { 
                                "!ver",
                                0x70
                            },
                            { 
                                "!v",
                                0x71
                            },
                            { 
                                "!y",
                                0x72
                            },
                            { 
                                "!n",
                                0x73
                            },
                            { 
                                "!votemap",
                                0x74
                            },
                            { 
                                "!votemod",
                                0x75
                            },
                            { 
                                "!votekick",
                                0x76
                            },
                            { 
                                "!voteban",
                                0x77
                            },
                            { 
                                "!access",
                                120
                            },
                            { 
                                "!login",
                                0x79
                            },
                            { 
                                "!fov",
                                0x7a
                            },
                            { 
                                "!iamgod",
                                0x7b
                            },
                            { 
                                "!xlrstats",
                                0x7c
                            },
                            { 
                                "!xlrtopstats",
                                0x7d
                            },
                            { 
                                "!register",
                                0x7e
                            },
                            { 
                                "!report",
                                0x7f
                            },
                            { 
                                "!resetadmin",
                                0x80
                            }
                        };
                        Class74.dictionary_0 = dictionary1;
                    }
                    if (Class74.dictionary_0.TryGetValue(key, out num))
                    {
                        Entity entity2;
                        Entity entity7;
                        string str8;
                        string str9;
                        string str13;
                        switch (num)
                        {
                            case 0:
                                Class75.smethod_53(this, class2.entity_0);
                                return;

                            case 1:
                                if (bool_41)
                                {
                                    goto Label_096B;
                                }
                                Class75.smethod_73(this, class2.entity_0, "^1User password function disabled!");
                                return;

                            case 2:
                                if ((strArray.Length == 3) && isNum(strArray[2]))
                                {
                                    int num2 = int.Parse(strArray[2]);
                                    if ((num2 < 1) || (num2 > DBNomeGruppi.Count))
                                    {
                                        goto Label_0A80;
                                    }
                                    if ((DBNomeGruppi[num2] == "null") || (DBNomeGruppi[num2] == ""))
                                    {
                                        goto Label_0A6A;
                                    }
                                    current = this.method_4(class2.entity_0, strArray[1]);
                                    if (current != null)
                                    {
                                        str3 = "add";
                                        entity2 = class2.entity_0;
                                        Class75.smethod_61(num2, current, entity2, str3, this);
                                    }
                                }
                                return;

                            case 3:
                                if (strArray.Length == 2)
                                {
                                    current = this.method_4(class2.entity_0, strArray[1]);
                                    if (current != null)
                                    {
                                        str3 = "del";
                                        entity2 = class2.entity_0;
                                        Class75.smethod_61(0, current, entity2, str3, this);
                                    }
                                }
                                return;

                            case 4:
                                if (strArray.Length == 1)
                                {
                                    return;
                                }
                                str4 = "";
                                num3 = 1;
                                goto Label_0B2C;

                            case 5:
                                if (strArray.Length == 1)
                                {
                                    return;
                                }
                                str4 = "";
                                num3 = 1;
                                goto Label_0B90;

                            case 6:
                                if (strArray.Length == 1)
                                {
                                    goto Label_0CBF;
                                }
                                if (strArray.Length != 2)
                                {
                                    goto Label_0C30;
                                }
                                num4 = 0;
                                goto Label_0BFC;

                            case 7:
                                goto Label_0CD5;

                            case 8:
                                if (strArray.Length != 1)
                                {
                                    current = this.method_4(class2.entity_0, strArray[1]);
                                    if (current != null)
                                    {
                                        Class75.smethod_77(current, this, class2.entity_0);
                                    }
                                }
                                return;

                            case 9:
                                if (strArray.Length == 1)
                                {
                                    Class75.smethod_45(class2.entity_0, this);
                                }
                                return;

                            case 10:
                            case 11:
                                if (strArray.Length != 1)
                                {
                                    this.method_11(class2.entity_0, strArray[1]);
                                }
                                return;

                            case 12:
                            case 13:
                                if ((strArray.Length == 3) && isNum(strArray[2]))
                                {
                                    num5 = int.Parse(strArray[2]);
                                    if (num5 > int_11)
                                    {
                                        goto Label_0F56;
                                    }
                                    this.method_10(class2.entity_0, strArray[1], num5);
                                }
                                return;

                            case 14:
                                if (strArray.Length == 1)
                                {
                                    goto Label_0FE7;
                                }
                                current = this.method_4(class2.entity_0, strArray[1]);
                                if ((current != null) && current.IsAlive)
                                {
                                    Class75.smethod_87(this, current);
                                    Class75.smethod_158(this, class2.entity_0, "^5" + this.getPlayerName(class2.entity_0) + " ^1GodMode given to " + current.Name);
                                }
                                return;

                            case 15:
                                if (strArray.Length == 1)
                                {
                                    goto Label_106B;
                                }
                                current = this.method_4(class2.entity_0, strArray[1]);
                                if ((current != null) && current.IsAlive)
                                {
                                    current.Call("freezeControls", new Parameter[] { 0 });
                                    Class75.smethod_158(this, class2.entity_0, "^1Unfreeze ^5" + current.Name);
                                }
                                return;

                            case 0x10:
                                if (strArray.Length == 1)
                                {
                                    goto Label_1107;
                                }
                                current = this.method_4(class2.entity_0, strArray[1]);
                                if ((current != null) && current.IsAlive)
                                {
                                    current.Call("freezeControls", new Parameter[] { 1 });
                                    Class75.smethod_158(this, class2.entity_0, "Freeze ^5" + current.Name);
                                }
                                return;

                            case 0x11:
                                if (strArray.Length == 1)
                                {
                                    goto Label_11A1;
                                }
                                current = this.method_4(class2.entity_0, strArray[1]);
                                if (current != null)
                                {
                                    if (!current.IsAlive)
                                    {
                                        goto Label_118B;
                                    }
                                    Class75.smethod_217(current, this);
                                    Class75.smethod_158(this, class2.entity_0, "^1Fly mode enabled to ^5" + current.Name);
                                }
                                return;

                            case 0x12:
                                if (int_24 != 0)
                                {
                                    goto Label_11ED;
                                }
                                int_24 = 1;
                                goto Label_11F3;

                            case 0x13:
                                if (int_25 != 0)
                                {
                                    goto Label_1229;
                                }
                                int_25 = 1;
                                goto Label_122F;

                            case 20:
                                if (strArray.Length != 2)
                                {
                                    goto Label_1307;
                                }
                                current = this.method_4(class2.entity_0, strArray[1]);
                                if (((current != null) && current.IsAlive) && (current.GetField<string>("sessionstate") != "spectator"))
                                {
                                    if (this.getPlayerLevel(current) >= this.getPlayerLevel(class2.entity_0))
                                    {
                                        goto Label_12F1;
                                    }
                                    Class75.smethod_149(class2.entity_0, current);
                                }
                                return;

                            case 0x15:
                                Class75.smethod_130(class2.entity_0, this);
                                return;

                            case 0x16:
                                goto Label_13B8;

                            case 0x17:
                                goto Label_13D3;

                            case 0x18:
                                if (!bool_35)
                                {
                                    goto Label_1441;
                                }
                                bool_35 = false;
                                parser = new IniParser(string_84 + string_47);
                                parser.AddSetting("GENERAL_SETTING", "Knife", "false");
                                parser.SaveSettings();
                                Class75.smethod_64(this, "^1knife Disabled!");
                                return;

                            case 0x19:
                                if (strArray.Length == 1)
                                {
                                    goto Label_15F0;
                                }
                                if (strArray.Length != 2)
                                {
                                    goto Label_153E;
                                }
                                if (strArray[1] != "25")
                                {
                                    goto Label_14D7;
                                }
                                entity3 = class2.entity_0;
                                str5 = "ac130_25mm_mp";
                                Class75.smethod_112(entity3, str5, this, false);
                                return;

                            case 0x1a:
                                if ((strArray.Length == 2) && isNum(strArray[1]))
                                {
                                    int num6 = int.Parse(strArray[1]);
                                    if ((num6 < 0) || (num6 > 100))
                                    {
                                        goto Label_1683;
                                    }
                                    class2.entity_0.SetClientDvar("com_maxfps", strArray[1]);
                                    class2.entity_0.SetClientDvar("con_maxfps", strArray[1]);
                                    Class75.smethod_73(this, class2.entity_0, "^5FPS set on:^1 " + strArray[1]);
                                }
                                return;

                            case 0x1b:
                                if (strArray.Length == 1)
                                {
                                    goto Label_16DD;
                                }
                                current = this.method_4(class2.entity_0, strArray[1]);
                                if ((current != null) && current.IsAlive)
                                {
                                    Class75.smethod_17(this, class2.entity_0, current);
                                }
                                return;

                            case 0x1c:
                                if (strArray.Length != 1)
                                {
                                    current = this.method_4(class2.entity_0, strArray[1]);
                                    if ((current != null) && current.IsAlive)
                                    {
                                        Class75.smethod_190(current, class2.entity_0, this);
                                    }
                                }
                                return;

                            case 0x1d:
                                if (strArray.Length == 1)
                                {
                                    return;
                                }
                                str4 = "";
                                num3 = 1;
                                goto Label_176C;

                            case 30:
                                if (!class2.entity_0.IsAlive)
                                {
                                    goto Label_1873;
                                }
                                num7 = base.Call<int>("getteamplayersalive", new Parameter[] { class2.entity_0.GetField<string>("sessionteam") });
                                if (class2.entity_0.GetField<string>("sessionteam") != "none")
                                {
                                    goto Label_1842;
                                }
                                Class75.smethod_156(class2.entity_0, this);
                                return;

                            case 0x1f:
                                if (string_93.Contains("inf"))
                                {
                                    goto Label_194A;
                                }
                                if (strArray.Length != 1)
                                {
                                    current = this.method_4(class2.entity_0, strArray[1]);
                                    if (current != null)
                                    {
                                        current.SetField("team", "spectator");
                                        current.SetField("sessionteam", "spectator");
                                        current.Notify("menuresponse", new Parameter[] { "team_marinesopfor", "spectator" });
                                        Class75.smethod_73(this, class2.entity_0, "^1" + current.Name + " ^5set AFK");
                                    }
                                }
                                return;

                            case 0x20:
                                if (string_93.Contains("inf"))
                                {
                                    goto Label_1A09;
                                }
                                class2.entity_0.SetField("team", "spectator");
                                class2.entity_0.SetField("sessionteam", "spectator");
                                class2.entity_0.Notify("menuresponse", new Parameter[] { "team_marinesopfor", "spectator" });
                                Class75.smethod_73(this, class2.entity_0, "^1" + class2.entity_0.Name + " ^5set AFK");
                                return;

                            case 0x21:
                                class2.entity_0.Notify("menuresponse", new Parameter[] { "menu", "endround" });
                                Class75.smethod_64(this, "^5Round Ended by ^1" + class2.entity_0.Name);
                                return;

                            case 0x22:
                                this.method_22(class2.entity_0);
                                return;

                            case 0x23:
                                if (((strArray.Length != 3) || !isNum(strArray[2])) || (this.getPlayerLevel(class2.entity_0) <= 3))
                                {
                                    goto Label_1AFF;
                                }
                                current = this.method_4(class2.entity_0, strArray[1]);
                                if (current != null)
                                {
                                    Class75.smethod_185(false, this, int.Parse(strArray[2]), current);
                                    Class75.smethod_158(this, class2.entity_0, "^1FilmTweak set on ^5" + current.Name);
                                }
                                return;

                            case 0x24:
                                if (string_2.StartsWith("te"))
                                {
                                    goto Label_1B59;
                                }
                                Class75.smethod_15(this);
                                return;

                            case 0x25:
                                Class75.smethod_153(class2.entity_0, this);
                                return;

                            case 0x26:
                                if (strArray.Length != 1)
                                {
                                    current = this.method_4(class2.entity_0, strArray[1]);
                                    if (current != null)
                                    {
                                        if (this.getPlayerLevel(current) >= this.getPlayerLevel(class2.entity_0))
                                        {
                                            goto Label_1BD6;
                                        }
                                        Class75.smethod_22(current, class2.entity_0, this);
                                    }
                                }
                                return;

                            case 0x27:
                                if (strArray.Length == 1)
                                {
                                    goto Label_1C04;
                                }
                                this.method_0(strArray[1]);
                                return;

                            case 40:
                            {
                                if (string_2.StartsWith("te"))
                                {
                                    goto Label_1C83;
                                }
                                if ((strArray.Length != 2) || !isNum(strArray[1]))
                                {
                                    goto Label_1C77;
                                }
                                int num9 = int.Parse(strArray[1]);
                                int num10 = int.Parse(string_95) - list_2.Count;
                                if (num9 <= num10)
                                {
                                    Class75.smethod_176(this, num9);
                                }
                                return;
                            }
                            case 0x29:
                                goto Label_1C99;

                            case 0x2a:
                                if (strArray.Length != 1)
                                {
                                    current = this.method_4(class2.entity_0, strArray[1]);
                                    if (current != null)
                                    {
                                        Class75.smethod_203(1, this, current);
                                        Class75.smethod_158(this, class2.entity_0, "^1Degraded ^5" + this.getPlayerName(current));
                                    }
                                }
                                return;

                            case 0x2b:
                                this.method_30();
                                return;

                            case 0x2c:
                                if (strArray.Length >= 2)
                                {
                                    goto Label_1DB6;
                                }
                                Class75.smethod_73(this, class2.entity_0, "^1Enter the name of the script. example: ^7!load NaaBAdmin.dll");
                                return;

                            case 0x2d:
                                if (strArray.Length >= 2)
                                {
                                    goto Label_1E2D;
                                }
                                Class75.smethod_73(this, class2.entity_0, "^1Enter the name of the script. example: ^7!unload NaaBAdmin.dll");
                                return;

                            case 0x2e:
                                if ((strArray.Length != 1) && isNum(strArray[1]))
                                {
                                    Class75.smethod_10(this, string.Concat(new object[] { "^5", this.getPlayerName(class2.entity_0), " ^7Jump: ^1", int_5, " ^7------->^1 ", strArray[1] }));
                                    int_5 = int.Parse(strArray[1]);
                                    JumpHeight = int_5;
                                }
                                return;

                            case 0x2f:
                                if ((strArray.Length != 1) && isNum(strArray[1]))
                                {
                                    Class75.smethod_10(this, string.Concat(new object[] { "^5", this.getPlayerName(class2.entity_0), " ^7Speed: ^1", int_6, " ^7------->^1 ", strArray[1] }));
                                    int_6 = int.Parse(strArray[1]);
                                    Speed = int_6;
                                }
                                return;

                            case 0x30:
                                if ((strArray.Length != 1) && isNum(strArray[1]))
                                {
                                    Class75.smethod_10(this, string.Concat(new object[] { "^5", this.getPlayerName(class2.entity_0), " ^7Gravity: ^1", int_7, " ^7------->^1 ", strArray[1] }));
                                    int_7 = int.Parse(strArray[1]);
                                    Gravity = int_7;
                                }
                                return;

                            case 0x31:
                                if (strArray.Length == 2)
                                {
                                    entity7 = class2.entity_0;
                                    str8 = strArray[1];
                                    str9 = "add";
                                    Class75.smethod_96(str9, this, str8, entity7);
                                }
                                return;

                            case 50:
                                if (strArray.Length == 2)
                                {
                                    entity7 = class2.entity_0;
                                    str8 = strArray[1];
                                    str9 = "del";
                                    Class75.smethod_96(str9, this, str8, entity7);
                                }
                                return;

                            case 0x33:
                                if (strArray.Length == 1)
                                {
                                    return;
                                }
                                str4 = "";
                                num3 = 1;
                                goto Label_20C8;

                            case 0x34:
                                if (strArray.Length == 1)
                                {
                                    return;
                                }
                                str4 = "";
                                num3 = 1;
                                goto Label_2123;

                            case 0x35:
                            case 0x36:
                                if (strArray.Length == 1)
                                {
                                    return;
                                }
                                current = this.method_4(class2.entity_0, strArray[1]);
                                if (current == null)
                                {
                                    return;
                                }
                                if (this.getPlayerLevel(current) >= this.getPlayerLevel(class2.entity_0))
                                {
                                    goto Label_220E;
                                }
                                if (strArray.Length <= 2)
                                {
                                    goto Label_21F6;
                                }
                                str4 = "";
                                num3 = 2;
                                goto Label_21C1;

                            case 0x37:
                            case 0x38:
                                if (strArray.Length == 1)
                                {
                                    return;
                                }
                                current = this.method_5(class2.entity_0, strArray[1]);
                                if (current == null)
                                {
                                    return;
                                }
                                if (this.getPlayerLevel(current) >= this.getPlayerLevel(class2.entity_0))
                                {
                                    goto Label_2373;
                                }
                                if (strArray.Length <= 2)
                                {
                                    goto Label_235B;
                                }
                                str4 = "";
                                num3 = 2;
                                goto Label_2326;

                            case 0x39:
                            case 0x3a:
                                if (strArray.Length <= 1)
                                {
                                    return;
                                }
                                str4 = "";
                                num3 = 1;
                                goto Label_244B;

                            case 0x3b:
                                if (strArray.Length == 1)
                                {
                                    goto Label_24FF;
                                }
                                if (strArray[1] != "null")
                                {
                                    goto Label_24C1;
                                }
                                Class75.smethod_6(this, "g_password \"\"", 0);
                                Class75.smethod_158(this, class2.entity_0, "^5" + this.getPlayerName(class2.entity_0) + " ^1Password Disabled!");
                                goto Label_2532;

                            case 60:
                                if (bool_49)
                                {
                                    goto Label_2556;
                                }
                                bool_49 = true;
                                goto Label_255C;

                            case 0x3d:
                                if (strArray.Length == 1)
                                {
                                    return;
                                }
                                current = this.method_4(class2.entity_0, strArray[1]);
                                if ((current == null) || !current.IsAlive)
                                {
                                    return;
                                }
                                if (this.getPlayerLevel(current) > this.getPlayerLevel(class2.entity_0))
                                {
                                    goto Label_26B2;
                                }
                                if (strArray.Length != 2)
                                {
                                    goto Label_2678;
                                }
                                Class75.smethod_34(this, "normal", class2.entity_0, current);
                                goto Label_268A;

                            case 0x3e:
                                if (!bool_1)
                                {
                                    goto Label_26DA;
                                }
                                bool_1 = false;
                                goto Label_26E0;

                            case 0x3f:
                                if (!bool_50)
                                {
                                    goto Label_2717;
                                }
                                bool_50 = false;
                                goto Label_271D;

                            case 0x40:
                                Class75.smethod_10(this, "^5Current Atmosphere Parameters:");
                                Class75.smethod_10(this, string.Concat(new object[] { "^5Jump = ^1", int_5, "^5 - Speed = ^1", int_6, "^5 - Gravity = ^1", int_7 }));
                                Class75.smethod_10(this, "^7Script Made by ^5MH11");
                                return;

                            case 0x41:
                                if (strArray.Length != 1)
                                {
                                    if (string_93.Contains("inf"))
                                    {
                                        goto Label_28D4;
                                    }
                                    current = this.method_4(class2.entity_0, strArray[1]);
                                    if (current != null)
                                    {
                                        if (current.GetField<string>("sessionteam") == "allies")
                                        {
                                            goto Label_2871;
                                        }
                                        current.SetField("team", "allies");
                                        current.SetField("sessionteam", "allies");
                                        current.Notify("menuresponse", new Parameter[] { new Parameter("team_marinesopfor"), new Parameter("allies") });
                                    }
                                }
                                return;

                            case 0x42:
                            case 0x43:
                                if ((strArray.Length <= 2) || !isNum(strArray[2]))
                                {
                                    return;
                                }
                                num5 = int.Parse(strArray[2]);
                                if (num5 > int_11)
                                {
                                    goto Label_2AA7;
                                }
                                current = this.method_4(class2.entity_0, strArray[1]);
                                if (current == null)
                                {
                                    return;
                                }
                                if (this.getPlayerLevel(current) >= this.getPlayerLevel(class2.entity_0))
                                {
                                    goto Label_29EB;
                                }
                                if (strArray.Length <= 3)
                                {
                                    goto Label_29C0;
                                }
                                str4 = "";
                                num3 = 3;
                                goto Label_2989;

                            case 0x44:
                            case 0x45:
                                if (strArray.Length <= 1)
                                {
                                    return;
                                }
                                str4 = "";
                                num3 = 1;
                                goto Label_2B00;

                            case 70:
                                if (strArray.Length == 2)
                                {
                                    current = this.method_4(class2.entity_0, strArray[1]);
                                    if (current != null)
                                    {
                                        Class75.smethod_121(class2.entity_0, current, this);
                                    }
                                }
                                return;

                            case 0x47:
                                if (strArray.Length == 1)
                                {
                                    entity10 = class2.entity_0;
                                    str12 = "all";
                                    Class75.smethod_24(str12, this, null, entity10, null);
                                }
                                return;

                            case 0x48:
                                if (strArray.Length == 1)
                                {
                                    Class75.smethod_86(class2.entity_0, this);
                                }
                                return;

                            case 0x49:
                                if (strArray.Length == 1)
                                {
                                    Class75.smethod_201(class2.entity_0, this);
                                }
                                return;

                            case 0x4a:
                                if (strArray.Length == 2)
                                {
                                    current = this.method_4(class2.entity_0, strArray[1]);
                                    if (current != null)
                                    {
                                        current.SetField("Mute", 1);
                                        Class75.smethod_73(this, class2.entity_0, "^5" + this.getPlayerName(current) + " ^1Muted!");
                                    }
                                }
                                return;

                            case 0x4b:
                                if (strArray.Length == 2)
                                {
                                    current = this.method_4(class2.entity_0, strArray[1]);
                                    if (current != null)
                                    {
                                        current.SetField("Mute", 0);
                                        Class75.smethod_73(this, class2.entity_0, "^5" + this.getPlayerName(current) + " ^1UnMuted!");
                                    }
                                }
                                return;

                            case 0x4c:
                                if (strArray.Length != 1)
                                {
                                    Class75.smethod_64(this, "^5Server password successfully changed!");
                                    string_16 = strArray[1];
                                    parser = new IniParser(string_84 + string_47);
                                    parser.AddSetting("PASSWORD_ACCESS_SERVER", "Server_Password", string_16);
                                    parser.SaveSettings();
                                    Class75.smethod_64(this, "^5Restart Map in 2 second...");
                                    Class75.smethod_6(this, "map_restart", 0x7d0);
                                }
                                return;

                            case 0x4d:
                                if (strArray.Length == 1)
                                {
                                    goto Label_2D62;
                                }
                                str13 = this.TrovaMappa(class2.entity_0, strArray[1]);
                                if (str13 != "null")
                                {
                                    this.method_0("all");
                                    Class75.smethod_6(this, "map " + str13, 500);
                                }
                                return;

                            case 0x4e:
                                this.method_0("all");
                                Class75.smethod_6(this, "fast_restart", 500);
                                return;

                            case 0x4f:
                                this.method_0("all");
                                Class75.smethod_6(this, "map_restart", 500);
                                return;

                            case 80:
                                this.method_0("all");
                                Class75.smethod_6(this, "map_rotate", 500);
                                return;

                            case 0x51:
                            case 0x52:
                                if (strArray.Length == 1)
                                {
                                    return;
                                }
                                current = this.method_4(class2.entity_0, strArray[1]);
                                if (current == null)
                                {
                                    return;
                                }
                                if (this.getPlayerLevel(current) >= this.getPlayerLevel(class2.entity_0))
                                {
                                    goto Label_2EB2;
                                }
                                if (strArray.Length <= 2)
                                {
                                    goto Label_2E8F;
                                }
                                str4 = "";
                                num3 = 2;
                                goto Label_2E4F;

                            case 0x53:
                            case 0x54:
                                goto Label_2F6F;

                            case 0x55:
                                goto Label_3019;

                            case 0x56:
                            case 0x57:
                                if (strArray.Length <= 2)
                                {
                                    return;
                                }
                                current = this.method_4(class2.entity_0, strArray[1]);
                                if (current == null)
                                {
                                    return;
                                }
                                if (this.getPlayerLevel(current) >= this.getPlayerLevel(class2.entity_0))
                                {
                                    goto Label_316A;
                                }
                                str4 = "";
                                num3 = 2;
                                goto Label_3130;

                            case 0x58:
                                if (strArray.Length == 1)
                                {
                                    entity10 = class2.entity_0;
                                    str12 = "list";
                                    Class75.smethod_24(str12, this, null, entity10, null);
                                }
                                return;

                            case 0x59:
                            case 90:
                                if (strArray.Length == 2)
                                {
                                    current = this.method_4(class2.entity_0, strArray[1]);
                                    if (current != null)
                                    {
                                        entity10 = class2.entity_0;
                                        str12 = "del";
                                        Class75.smethod_24(str12, this, current, entity10, null);
                                    }
                                }
                                return;

                            case 0x5b:
                                if (!bool_8)
                                {
                                    goto Label_3269;
                                }
                                Class75.smethod_64(this, "^5Server Password Disabled!");
                                bool_8 = false;
                                parser = new IniParser(string_84 + string_47);
                                parser.AddSetting("PASSWORD_ACCESS_SERVER", "Status_Password_Script", "false");
                                parser.SaveSettings();
                                Class75.smethod_64(this, "^5Restart Map in 2 second...");
                                Class75.smethod_6(this, "map_restart", 0x7d0);
                                return;

                            case 0x5c:
                                if (strArray.Length == 1)
                                {
                                    goto Label_333C;
                                }
                                str13 = this.TrovaMappa(class2.entity_0, strArray[1]);
                                if (str13 != "null")
                                {
                                    Class75.smethod_170(class2.entity_0, str13, this);
                                }
                                return;

                            case 0x5d:
                                Class75.smethod_73(this, class2.entity_0, "^5Current Password is: ^1" + string_16);
                                return;

                            case 0x5e:
                                Class75.smethod_73(this, class2.entity_0, "^5Password Status: ^1" + bool_8);
                                return;

                            case 0x5f:
                                Class75.smethod_180(this, class2.entity_0);
                                return;

                            case 0x60:
                                Class75.smethod_63(class2.entity_0, this);
                                return;

                            case 0x61:
                                Class75.smethod_46(class2.entity_0, this);
                                return;

                            case 0x62:
                                Class75.smethod_167(class2.entity_0, this);
                                return;

                            case 0x63:
                                goto Label_33DB;

                            case 100:
                                if (strArray.Length == 1)
                                {
                                    return;
                                }
                                class3 = new Class4 {
                                    class3_0 = class2,
                                    string_0 = ""
                                };
                                num3 = 1;
                                goto Label_35F7;

                            case 0x65:
                                if (strArray.Length == 1)
                                {
                                    return;
                                }
                                str4 = "";
                                num3 = 1;
                                goto Label_36DC;

                            case 0x66:
                                if (strArray.Length <= 2)
                                {
                                    return;
                                }
                                current = this.method_4(class2.entity_0, strArray[1]);
                                if (current == null)
                                {
                                    return;
                                }
                                str4 = "";
                                num3 = 2;
                                goto Label_3748;

                            case 0x67:
                                if (!bool_48)
                                {
                                    goto Label_37B2;
                                }
                                bool_48 = false;
                                Class75.smethod_64(this, "^5Votation canceled!");
                                return;

                            case 0x68:
                                this.method_28();
                                return;

                            case 0x69:
                                goto Label_37D3;

                            case 0x6a:
                                Class75.smethod_119(this, class2.entity_0);
                                return;

                            case 0x6b:
                                Class75.smethod_73(this, class2.entity_0, string.Concat(new object[] { "^7It's ^5", DateTime.Now.ToShortTimeString(), "^7 o'clock of ^1", DateTime.Now.Day, "^7/^1", DateTime.Now.Month, "^7/^1", DateTime.Now.Year }));
                                return;

                            case 0x6c:
                                Class75.smethod_44(class2.entity_0, this);
                                return;

                            case 0x6d:
                                Class75.smethod_165(this, class2.entity_0);
                                return;

                            case 110:
                                Class75.smethod_228(this, true, class2.entity_0);
                                return;

                            case 0x6f:
                                if (strArray.Length == 1)
                                {
                                    Class75.smethod_26(this, class2.entity_0);
                                }
                                return;

                            case 0x70:
                            case 0x71:
                                Class75.smethod_73(this, class2.entity_0, "^7NaaBAdmin v4.0 by ^5Dargula^7 - Info: ^1www.naabbax.ir");
                                return;

                            case 0x72:
                                if (strArray.Length == 1)
                                {
                                    if (!bool_48)
                                    {
                                        goto Label_3A45;
                                    }
                                    if (class2.entity_0.GetField<int>("Voto") != 0)
                                    {
                                        goto Label_3A2F;
                                    }
                                    class2.entity_0.SetField("Voto", 2);
                                    int_17++;
                                    Class75.smethod_73(this, class2.entity_0, "^5Vote accepted!");
                                    Class75.smethod_84(this.getPlayerName(class2.entity_0) + " vote Yes", this);
                                    parser = new IniParser(string_88 + string_67);
                                    parser.AddSetting("User", this.getPlayerGuid(class2.entity_0) + char_1 + "y");
                                    parser.SaveSettings();
                                }
                                return;

                            case 0x73:
                                if (strArray.Length == 1)
                                {
                                    if (!bool_48)
                                    {
                                        goto Label_3B45;
                                    }
                                    if (class2.entity_0.GetField<int>("Voto") != 0)
                                    {
                                        goto Label_3B2F;
                                    }
                                    class2.entity_0.SetField("Voto", 1);
                                    int_18++;
                                    Class75.smethod_73(this, class2.entity_0, "^5Vote accepted!");
                                    Class75.smethod_84(this.getPlayerName(class2.entity_0) + " vote No", this);
                                    parser = new IniParser(string_88 + string_67);
                                    parser.AddSetting("User", this.getPlayerGuid(class2.entity_0) + char_1 + "n");
                                    parser.SaveSettings();
                                }
                                return;

                            case 0x74:
                            case 0x75:
                            case 0x76:
                            case 0x77:
                                if (strArray.Length != 1)
                                {
                                    if (!bool_1)
                                    {
                                        goto Label_3C0E;
                                    }
                                    if (list_3.Count <= 2)
                                    {
                                        goto Label_3BF8;
                                    }
                                    if (!bool_48)
                                    {
                                        goto Label_3BA6;
                                    }
                                    Class75.smethod_73(this, class2.entity_0, "^7Vote active ... ^5Wait till the end!");
                                }
                                return;

                            case 120:
                                if (strArray.Length != 1)
                                {
                                    if (((string_15 == "null") || (string_15 == null)) || (string_15 == ""))
                                    {
                                        goto Label_3CF2;
                                    }
                                    if ((strArray[1] != string_15) || (this.getPlayerLevel(class2.entity_0) >= 1))
                                    {
                                        goto Label_3CDC;
                                    }
                                    Entity entity13 = class2.entity_0;
                                    int num11 = DBPlayerlvl.Count - 1;
                                    Class75.smethod_203(num11, this, entity13);
                                    Class75.smethod_182(1, class2.entity_0, this);
                                    Class75.smethod_64(this, "^1" + this.getPlayerName(class2.entity_0) + " ^5manual login as Owner");
                                }
                                return;

                            case 0x79:
                                if (((strArray.Length != 1) && (string_3 != null)) && (string_3 != "null"))
                                {
                                    if (((strArray[1] != string_3) || (this.getPlayerLevel(class2.entity_0) <= 1)) || (this.getPlayerAccess(class2.entity_0) != 0))
                                    {
                                        goto Label_3DAB;
                                    }
                                    Class75.smethod_182(1, class2.entity_0, this);
                                    Class75.smethod_137(class2.entity_0, this);
                                    Class75.smethod_73(this, class2.entity_0, "^1" + this.getPlayerName(class2.entity_0) + " ^5control enabled!");
                                }
                                return;

                            case 0x7a:
                                if ((strArray.Length == 2) && isNum(strArray[1]))
                                {
                                    num12 = int.Parse(strArray[1]);
                                    if (num12 != 0x41)
                                    {
                                        goto Label_3E1D;
                                    }
                                    class2.entity_0.SetClientDvar("cg_fov", "65");
                                    Class75.smethod_158(this, class2.entity_0, "^5 Fov Set on ^165");
                                }
                                return;

                            case 0x7b:
                                flag = true;
                                num4 = 1;
                                goto Label_3F7B;

                            case 0x7c:
                                if (!bool_16)
                                {
                                    goto Label_4296;
                                }
                                strArray3 = null;
                                if (strArray.Length != 1)
                                {
                                    goto Label_41A9;
                                }
                                strArray3 = Class75.smethod_38(this, class2.entity_0);
                                if (strArray3 == null)
                                {
                                    goto Label_4193;
                                }
                                Class75.smethod_73(this, class2.entity_0, "^5Your stats: ^7Kill ^1" + strArray3[3].ToString() + "^7, Dead ^1" + strArray3[4].ToString() + "^7, Skill ^1" + strArray3[5].ToString() + "^7, HeadShot ^1" + strArray3[6].ToString() + "^7, Moab ^1" + strArray3[7].ToString());
                                return;

                            case 0x7d:
                                this.method_34(class2.entity_0);
                                return;

                            case 0x7e:
                                if (!bool_16)
                                {
                                    goto Label_431D;
                                }
                                if (!string_93.Contains("inf"))
                                {
                                    goto Label_430C;
                                }
                                if (!bool_33)
                                {
                                    goto Label_42F6;
                                }
                                Class75.smethod_189(this, class2.entity_0);
                                return;

                            case 0x7f:
                                if (strArray.Length != 1)
                                {
                                    this.method_27(class2.entity_0, strArray[1], "add");
                                }
                                return;

                            case 0x80:
                                DBComandilvl.Add(xStrComandilvl00);
                                DBComandilvl.Add(xStrComandilvl01);
                                DBComandilvl.Add(xStrComandilvl02);
                                DBComandilvl.Add(xStrComandilvl03);
                                DBComandilvl.Add(xStrComandilvl04);
                                DBComandilvl.Add(xStrComandilvl05);
                                DBComandilvl.Add(xStrComandilvl06);
                                DBComandilvl.Add(xStrComandilvl07);
                                DBComandilvl.Add(xStrComandilvl08);
                                DBComandilvl.Add(xStrComandilvl09);
                                parser = new IniParser(string_84 + string_46);
                                parser.AddSetting("Function", "Commandlvl10", xStrComandilvl09);
                                parser.AddSetting("Function", "Commandlvl09", xStrComandilvl08);
                                parser.AddSetting("Function", "Commandlvl08", xStrComandilvl07);
                                parser.AddSetting("Function", "Commandlvl07", xStrComandilvl06);
                                parser.AddSetting("Function", "Commandlvl06", xStrComandilvl05);
                                parser.AddSetting("Function", "Commandlvl05", xStrComandilvl04);
                                parser.AddSetting("Function", "Commandlvl04", xStrComandilvl03);
                                parser.AddSetting("Function", "Commandlvl03", xStrComandilvl02);
                                parser.AddSetting("Function", "Commandlvl02", xStrComandilvl01);
                                parser.AddSetting("Function", "Commandlvl01", xStrComandilvl00);
                                parser.SaveSettings();
                                Class75.smethod_73(this, class2.entity_0, "^5Reset Commands OK");
                                return;
                        }
                    }
                }
                goto Label_44FB;
            Label_096B:
                if (strArray.Length == 1)
                {
                    if (this.getPlayerPswOk(class2.entity_0) == 1)
                    {
                        Class75.smethod_202(this, class2.entity_0);
                    }
                    else
                    {
                        Class75.smethod_73(this, class2.entity_0, "^5Login required before deleting the registration!");
                    }
                }
                return;
            Label_0A6A:
                Class75.smethod_73(this, class2.entity_0, "^1Admin Group is not actived!");
                return;
            Label_0A80:
                Class75.smethod_73(this, class2.entity_0, "^1Insert number Group min 1 max " + DBNomeGruppi.Count + "!");
                return;
            Label_0B13:
                str4 = str4 + " " + strArray2[num3];
                num3++;
            Label_0B2C:
                if (num3 < strArray2.Length)
                {
                    goto Label_0B13;
                }
                this.method_19(class2.entity_0, str4.Trim());
                Class75.smethod_158(this, class2.entity_0, "^5Message sent to connected Admins!");
                return;
            Label_0B77:
                str4 = str4 + " " + strArray2[num3];
                num3++;
            Label_0B90:
                if (num3 < strArray2.Length)
                {
                    goto Label_0B77;
                }
                this.method_20(class2.entity_0, str4.Trim());
                Class75.smethod_158(this, class2.entity_0, "^5Message sent to connected Admins!");
                return;
            Label_0BE0:
                if (string_76[num4].Contains(strArray[1]))
                {
                    goto Label_0C0E;
                }
                num4++;
            Label_0BFC:
                if (num4 < string_76.Length)
                {
                    goto Label_0BE0;
                }
                return;
            Label_0C0E:
                entity3 = class2.entity_0;
                str5 = string_76[num4];
                Class75.smethod_112(entity3, str5, this, true);
                return;
            Label_0C30:
                current = this.method_4(class2.entity_0, strArray[2]);
                if ((current != null) && current.IsAlive)
                {
                    num4 = 0;
                    while (num4 < string_76.Length)
                    {
                        if (string_76[num4].Contains(strArray[1]))
                        {
                            goto Label_0C8B;
                        }
                        num4++;
                    }
                }
                return;
            Label_0C8B:
                Class75.smethod_112(current, string_76[num4], this, true);
                Class75.smethod_73(this, class2.entity_0, "^5Weapon  given to^1 " + this.getPlayerName(current));
                return;
            Label_0CBF:
                Class75.smethod_73(this, class2.entity_0, "^1Select Weapon");
                return;
            Label_0CD5:
                if (strArray.Length != 1)
                {
                    if (strArray[1] == "all")
                    {
                        foreach (Entity entity in list_3)
                        {
                            if (entity.IsAlive)
                            {
                                entity.Call("giveMaxAmmo", new Parameter[] { entity.CurrentWeapon });
                                entity.Call("iprintlnbold", new Parameter[] { "^5" + this.getPlayerName(entity) + " ^1Ammo received!!!" });
                            }
                        }
                    }
                    else
                    {
                        current = this.method_4(class2.entity_0, strArray[1]);
                        if ((current != null) && current.IsAlive)
                        {
                            current.Call("giveMaxAmmo", new Parameter[] { current.CurrentWeapon });
                            current.Call("iprintlnbold", new Parameter[] { "^5" + current.Name + " ^1Ammo received!!!" });
                            Class75.smethod_158(this, class2.entity_0, "^1Ammo given to ^5" + current.Name);
                        }
                    }
                }
                else
                {
                    class2.entity_0.Call("giveMaxAmmo", new Parameter[] { class2.entity_0.CurrentWeapon });
                    Class75.smethod_158(this, class2.entity_0, "^5" + this.getPlayerName(class2.entity_0) + " ^1Ammo received!!!");
                }
                return;
            Label_0F56:
                Class75.smethod_73(this, class2.entity_0, "^1Error - The TempBan minutes limit for your group is ^5" + int_11);
                return;
            Label_0FE7:
                Class75.smethod_87(this, class2.entity_0);
                return;
            Label_106B:;
                class2.entity_0.Call("freezeControls", new Parameter[] { 0 });
                return;
            Label_1107:;
                class2.entity_0.Call("freezeControls", new Parameter[] { 1 });
                return;
            Label_118B:
                Class75.smethod_73(this, class2.entity_0, "^1You can not use this command on a dead player");
                return;
            Label_11A1:
                if (class2.entity_0.IsAlive)
                {
                    Class75.smethod_217(class2.entity_0, this);
                }
                else
                {
                    Class75.smethod_73(this, class2.entity_0, "^1You can not use this command if you're dead");
                }
                return;
            Label_11ED:
                int_24 = 0;
            Label_11F3:
                if (function == null)
                {
                    function = new Func<bool>(class2.method_0);
                }
                base.OnInterval(0x3e8, function);
                return;
            Label_1229:
                int_25 = 0;
            Label_122F:;
                class2.entity_0.Call(0x155, new Parameter[] { class2.entity_0.GetField<string>("sessionteam"), int_25 });
                return;
            Label_12F1:
                Class75.smethod_73(this, class2.entity_0, "^1Error - Player is same level or higher!");
                return;
            Label_1307:
                if (strArray.Length == 3)
                {
                    current = this.method_4(class2.entity_0, strArray[1]);
                    if ((current != null) && current.IsAlive)
                    {
                        Entity entity4 = class2.entity_0;
                        string str6 = strArray[2];
                        Entity entity5 = Class75.smethod_107(str6, this, entity4);
                        if ((entity5 != null) && current.IsAlive)
                        {
                            Class75.smethod_149(current, entity5);
                            Class75.smethod_158(this, class2.entity_0, "^5" + this.getPlayerName(current) + " ^1teleported to^5 " + this.getPlayerName(entity5));
                        }
                    }
                }
                return;
            Label_13B8:
                if (bool_30)
                {
                    Class75.smethod_54(this);
                }
                Class75.smethod_227(this);
                return;
            Label_13D3:
                if (bool_29)
                {
                    Class75.smethod_227(this);
                }
                Class75.smethod_54(this);
                return;
            Label_1441:
                bool_35 = true;
                parser = new IniParser(string_84 + string_47);
                parser.AddSetting("GENERAL_SETTING", "Knife", "true");
                parser.SaveSettings();
                Class75.smethod_64(this, "^1knife Enabled!");
                return;
            Label_14D7:
                if (strArray[1] == "40")
                {
                    entity3 = class2.entity_0;
                    str5 = "ac130_40mm_mp";
                    Class75.smethod_112(entity3, str5, this, false);
                }
                else if (strArray[1] == "105")
                {
                    entity3 = class2.entity_0;
                    str5 = "ac130_105mm_mp";
                    Class75.smethod_112(entity3, str5, this, false);
                }
                return;
            Label_153E:
                current = this.method_4(class2.entity_0, strArray[2]);
                if ((current != null) && current.IsAlive)
                {
                    if (strArray[1] == "25")
                    {
                        Class75.smethod_112(current, "ac130_25mm_mp", this, false);
                    }
                    else if (strArray[1] == "40")
                    {
                        Class75.smethod_112(current, "ac130_40mm_mp", this, false);
                    }
                    else if (strArray[1] == "105")
                    {
                        Class75.smethod_112(current, "ac130_105mm_mp", this, false);
                    }
                    Class75.smethod_73(this, class2.entity_0, "^5Weapon given to^1 " + this.getPlayerName(current));
                }
                return;
            Label_15F0:
                Class75.smethod_73(this, class2.entity_0, "^1Select the Caliber");
                return;
            Label_1683:
                Class75.smethod_73(this, class2.entity_0, "^1FPS set on number min 0 max 100");
                return;
            Label_16DD:
                Class75.smethod_17(this, class2.entity_0, class2.entity_0);
                return;
            Label_1753:
                str4 = str4 + " " + strArray2[num3];
                num3++;
            Label_176C:
                if (num3 < strArray2.Length)
                {
                    goto Label_1753;
                }
                base.Call("setdvar", new Parameter[] { "sv_hostname", str4.Trim() });
                Class75.smethod_73(this, class2.entity_0, "^5Server name set to:^1 " + str4.Trim());
                return;
            Label_1842:
                if (num7 > 1)
                {
                    Class75.smethod_156(class2.entity_0, this);
                }
                else
                {
                    Class75.smethod_73(this, class2.entity_0, "^1You can not use this command if only you on team");
                }
                return;
            Label_1873:
                Class75.smethod_73(this, class2.entity_0, "^1You can not use this command if you're dead");
                return;
            Label_194A:
                Class75.smethod_73(this, class2.entity_0, "You can not set Afk in infect mode");
                return;
            Label_1A09:
                Class75.smethod_73(this, class2.entity_0, "You can not set Afk in infect mode");
                return;
            Label_1AFF:
                if ((strArray.Length == 2) && isNum(strArray[1]))
                {
                    Entity entity6 = class2.entity_0;
                    int num8 = int.Parse(strArray[1]);
                    Class75.smethod_185(false, this, num8, entity6);
                }
                return;
            Label_1B59:
                Class75.smethod_73(this, class2.entity_0, "Bots are not compatible with TeknoMW3");
                return;
            Label_1BD6:
                Class75.smethod_73(this, class2.entity_0, "^1Error - Player is same level or higher!");
                return;
            Label_1C04:
                this.method_0("all");
                return;
            Label_1C77:
                Class75.smethod_176(this, 1);
                return;
            Label_1C83:
                Class75.smethod_73(this, class2.entity_0, "Bots are not compatible with TeknoMW3");
                return;
            Label_1C99:
                if (strArray.Length > 2)
                {
                    using (enumerator = list_3.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            current = enumerator.Current;
                            current.Call("setclientdvar", new Parameter[] { new Parameter(strArray[1]), new Parameter(strArray[2]) });
                        }
                    }
                    Class75.smethod_158(this, class2.entity_0, "^5" + this.getPlayerName(class2.entity_0) + " ^1Parameters are Set!");
                }
                return;
            Label_1DB6:
                if (!System.IO.File.Exists(@"scripts\" + strArray[1]))
                {
                    Class75.smethod_73(this, class2.entity_0, "^1Script file not found!");
                }
                else
                {
                    Class75.smethod_6(this, "loadscript " + strArray[1], 0);
                    Class75.smethod_6(this, "fast_restart", 500);
                }
                return;
            Label_1E2D:
                if (!System.IO.File.Exists(@"scripts\" + strArray[1]))
                {
                    Class75.smethod_73(this, class2.entity_0, "^1Script file not found!");
                }
                else
                {
                    Class75.smethod_6(this, "unloadscript " + strArray[1], 0);
                    Class75.smethod_6(this, "fast_restart", 500);
                }
                return;
            Label_20AF:
                str4 = str4 + " " + strArray2[num3];
                num3++;
            Label_20C8:
                if (num3 < strArray2.Length)
                {
                    goto Label_20AF;
                }
                Entity entity8 = class2.entity_0;
                Class75.smethod_91(str4.Trim(), this, entity8);
                return;
            Label_210A:
                str4 = str4 + " " + strArray2[num3];
                num3++;
            Label_2123:
                if (num3 < strArray2.Length)
                {
                    goto Label_210A;
                }
                Entity entity9 = class2.entity_0;
                string str11 = str4.Trim();
                Class75.smethod_183(entity9, str11, this);
                return;
            Label_21A8:
                str4 = str4 + " " + strArray2[num3];
                num3++;
            Label_21C1:
                if (num3 < strArray2.Length)
                {
                    goto Label_21A8;
                }
                this.method_25(class2.entity_0, current, str4.Replace(char_1, '.').Trim().ToLower());
                return;
            Label_21F6:
                this.method_25(class2.entity_0, current, "Permanent Ban!");
                return;
            Label_220E:
                if (this.getPlayerAccess(current) == 0)
                {
                    if (strArray.Length > 2)
                    {
                        str4 = "";
                        num3 = 2;
                        while (num3 < strArray2.Length)
                        {
                            str4 = str4 + " " + strArray2[num3];
                            num3++;
                        }
                        this.method_25(class2.entity_0, current, str4.Replace(char_1, '.').Trim().ToLower());
                    }
                    else
                    {
                        this.method_25(class2.entity_0, current, "Permanent Ban!");
                    }
                }
                else
                {
                    Class75.smethod_73(this, class2.entity_0, "^1Error - You can not PermBan a player with your same level!");
                }
                return;
            Label_230D:
                str4 = str4 + " " + strArray2[num3];
                num3++;
            Label_2326:
                if (num3 < strArray2.Length)
                {
                    goto Label_230D;
                }
                this.method_25(class2.entity_0, current, str4.Replace(char_1, '.').Trim().ToLower());
                return;
            Label_235B:
                this.method_25(class2.entity_0, current, "Permanent Ban!");
                return;
            Label_2373:
                if (this.getPlayerAccess(current) == 0)
                {
                    if (strArray.Length > 2)
                    {
                        str4 = "";
                        num3 = 2;
                        while (num3 < strArray2.Length)
                        {
                            str4 = str4 + " " + strArray2[num3];
                            num3++;
                        }
                        this.method_25(class2.entity_0, current, str4.Replace(char_1, '.').Trim().ToLower());
                    }
                    else
                    {
                        this.method_25(class2.entity_0, current, "Permanent Ban!");
                    }
                }
                else
                {
                    Class75.smethod_73(this, class2.entity_0, "^1Error - You can not PermBan a player with your same level!");
                }
                return;
            Label_2432:
                str4 = str4 + " " + strArray2[num3];
                num3++;
            Label_244B:
                if (num3 < strArray2.Length)
                {
                    goto Label_2432;
                }
                this.method_26(class2.entity_0, str4.Trim());
                return;
            Label_24C1:
                Class75.smethod_6(this, "g_password " + strArray[1], 0);
                Class75.smethod_158(this, class2.entity_0, "^5" + this.getPlayerName(class2.entity_0) + " ^1Password Enabled!");
                goto Label_2532;
            Label_24FF:
                Class75.smethod_6(this, "g_password \"\"", 0);
                Class75.smethod_158(this, class2.entity_0, "^5" + this.getPlayerName(class2.entity_0) + " ^1Password Disabled!");
            Label_2532:
                Class75.smethod_6(this, "map_rotate", 0x7d0);
                return;
            Label_2556:
                bool_49 = false;
            Label_255C:
                using (enumerator = list_3.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        current = enumerator.Current;
                        if (bool_49)
                        {
                            current.SetClientDvar("r_lightmap", "0");
                        }
                        else
                        {
                            current.SetClientDvar("r_lightmap", "1");
                        }
                    }
                }
                Class75.smethod_158(this, class2.entity_0, string.Concat(new object[] { "^5", this.getPlayerName(class2.entity_0), " night set ^1", bool_49 }));
                return;
            Label_2678:
                Class75.smethod_34(this, strArray[2], class2.entity_0, current);
            Label_268A:
                Class75.smethod_73(this, class2.entity_0, "^1" + this.getPlayerName(current) + " ^5killed!");
                return;
            Label_26B2:
                Class75.smethod_73(this, class2.entity_0, "^1Error - You can not Kill a player with your same level!");
                return;
            Label_26DA:
                bool_1 = true;
            Label_26E0:
                Class75.smethod_73(this, class2.entity_0, "Vote status changed in: ^5" + bool_1);
                return;
            Label_2717:
                bool_50 = true;
            Label_271D:
                Class75.smethod_73(this, class2.entity_0, "Chat status changed in: ^5" + bool_50);
                return;
            Label_2871:
                current.SetField("team", "axis");
                current.SetField("sessionteam", "axis");
                current.Notify("menuresponse", new Parameter[] { new Parameter("team_marinesopfor"), new Parameter("axis") });
                return;
            Label_28D4:
                Class75.smethod_73(this, class2.entity_0, "^1You can not change team in infect mode");
                return;
            Label_2970:
                str4 = str4 + " " + strArray2[num3];
                num3++;
            Label_2989:
                if (num3 < strArray2.Length)
                {
                    goto Label_2970;
                }
                this.method_23(class2.entity_0, current, num5, str4.Replace(char_1, '.').Trim().ToLower());
                return;
            Label_29C0:
                this.method_23(class2.entity_0, current, num5, "^1TempBan for " + num5 + "min!");
                return;
            Label_29EB:
                if (this.getPlayerAccess(current) == 0)
                {
                    if (strArray.Length > 3)
                    {
                        str4 = "";
                        num3 = 3;
                        while (num3 < strArray2.Length)
                        {
                            str4 = str4 + " " + strArray2[num3];
                            num3++;
                        }
                        this.method_23(class2.entity_0, current, num5, str4.Replace(char_1, '.').Trim().ToLower());
                    }
                    else
                    {
                        this.method_23(class2.entity_0, current, num5, "^1TempBan for " + num5 + "min!");
                    }
                }
                else
                {
                    Class75.smethod_73(this, class2.entity_0, "^1Error - Player is same level or higher!");
                }
                return;
            Label_2AA7:
                Class75.smethod_73(this, class2.entity_0, "^1Error - TempBan minutes limit for your group is ^5" + int_11);
                return;
            Label_2AE7:
                str4 = str4 + " " + strArray2[num3];
                num3++;
            Label_2B00:
                if (num3 < strArray2.Length)
                {
                    goto Label_2AE7;
                }
                this.method_24(class2.entity_0, str4.Trim());
                return;
            Label_2D62:
                Class75.smethod_73(this, class2.entity_0, "^1Map Name not entered!");
                return;
            Label_2E36:
                str4 = str4 + " " + strArray2[num3];
                num3++;
            Label_2E4F:
                if (num3 < strArray2.Length)
                {
                    goto Label_2E36;
                }
                Class75.smethod_20(this, this.getPlayerName(class2.entity_0), "k", current, str4.Replace(char_1, '.').Trim().ToLower());
                return;
            Label_2E8F:
                Class75.smethod_20(this, this.getPlayerName(class2.entity_0), "k", current, "You have been kick");
                return;
            Label_2EB2:
                if (this.getPlayerAccess(current) == 0)
                {
                    if (strArray.Length > 2)
                    {
                        str4 = "";
                        num3 = 2;
                        while (num3 < strArray2.Length)
                        {
                            str4 = str4 + " " + strArray2[num3];
                            num3++;
                        }
                        Class75.smethod_20(this, this.getPlayerName(class2.entity_0), "k", current, str4.Replace(char_1, '.').Trim().ToLower());
                    }
                    else
                    {
                        Class75.smethod_20(this, this.getPlayerName(class2.entity_0), "k", current, "You have been kick");
                    }
                }
                else
                {
                    Class75.smethod_73(this, class2.entity_0, "^1Error - Player is same level or higher!");
                }
                return;
            Label_2F6F:
                using (enumerator = list_2.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        current = enumerator.Current;
                        if (this.getPlayerLevel(current) < this.getPlayerLevel(class2.entity_0))
                        {
                            Class75.smethod_20(this, this.getPlayerName(class2.entity_0), "k", current, "All players were kicked");
                        }
                        else if (this.getPlayerAccess(current) == 0)
                        {
                            Class75.smethod_20(this, this.getPlayerName(class2.entity_0), "k", current, "All players were kicked");
                        }
                        Thread.Sleep(200);
                    }
                    return;
                }
            Label_3019:
                if (strArray.Length == 1)
                {
                    entity11 = class2.entity_0;
                    str14 = string_92;
                    Class75.smethod_39(null, str14, this, entity11);
                }
                if (strArray.Length == 2)
                {
                    entity11 = class2.entity_0;
                    str15 = strArray[1];
                    str14 = string_92;
                    Class75.smethod_39(str15, str14, this, entity11);
                }
                else if (strArray.Length == 3)
                {
                    string str16 = this.TrovaMappa(class2.entity_0, strArray[2]);
                    if (str16 != "null")
                    {
                        entity11 = class2.entity_0;
                        str15 = strArray[1];
                        Class75.smethod_39(str15, str16, this, entity11);
                    }
                }
                return;
            Label_3117:
                str4 = str4 + " " + strArray2[num3];
                num3++;
            Label_3130:
                if (num3 < strArray2.Length)
                {
                    goto Label_3117;
                }
                entity10 = class2.entity_0;
                str12 = "add";
                string str17 = str4.Trim().ToLower();
                Class75.smethod_24(str12, this, current, entity10, str17);
                return;
            Label_316A:
                Class75.smethod_73(this, class2.entity_0, "^1Error - Player is same level or higher!");
                return;
            Label_3269:
                Class75.smethod_64(this, "^5Server Password Enabled!");
                bool_8 = true;
                parser = new IniParser(string_84 + string_47);
                parser.AddSetting("PASSWORD_ACCESS_SERVER", "Status_Password_Script", "true");
                parser.SaveSettings();
                if (System.IO.File.Exists(string_88 + string_60))
                {
                    System.IO.File.Delete(string_88 + string_60);
                }
                Class75.smethod_64(this, "^5Restart Map in 2 second...");
                Class75.smethod_6(this, "map_restart", 0x7d0);
                return;
            Label_333C:
                Class75.smethod_73(this, class2.entity_0, "^1Map Name not entered!");
                return;
            Label_33DB:
                using (enumerator = list_3.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        current = enumerator.Current;
                        current.SetClientDvar("r_FilmTweakEnable", "0");
                        current.SetClientDvar("r_filmUseTweaks", "0");
                        current.SetClientDvar("r_filmAltShader", "0");
                        current.SetClientDvar("r_fog", "1");
                        current.SetClientDvar("fx_drawclouds", "1");
                        current.SetClientDvar("r_specularMap", "1");
                        current.SetClientDvar("r_lightmap", "1");
                        current.SetClientDvar("r_filmTweakBrightness", "0");
                        current.SetClientDvar("r_filmTweakContrast", "0");
                        current.SetClientDvar("cl_maxpackets", "100");
                        current.SetClientDvar("cg_brass", "1");
                        current.SetClientDvar("snaps", "30");
                        current.SetClientDvar("con_maxfps", int_12.ToString());
                        current.SetClientDvar("com_maxfps", int_12.ToString());
                        current.SetClientDvar("r_colorMap", "1");
                        current.SetClientDvar("r_normalMap", "1");
                        current.SetClientDvar("cg_drawFPS", "Simple");
                        current.SetClientDvar("cg_fovScale", "1");
                        current.SetClientDvar("r_debugShader", "0");
                        current.SetClientDvar("r_distortion", "1");
                        current.SetClientDvar("r_dlightlimit", "4");
                        current.SetClientDvar("clientsideeffects", "1");
                    }
                }
                Class75.smethod_73(this, class2.entity_0, "^5Fog Reset");
                return;
            Label_35D4:
                class3.string_0 = class3.string_0 + " " + strArray2[num3];
                num3++;
            Label_35F7:
                if (num3 < strArray2.Length)
                {
                    goto Label_35D4;
                }
                base.AfterDelay(10, new Action(class3.method_0));
                base.AfterDelay(0x5dc, new Action(class3.method_1));
                base.AfterDelay(0xbb8, new Action(class3.method_2));
                base.AfterDelay(0x1194, new Action(class3.method_3));
                base.AfterDelay(0x1770, new Action(class3.method_4));
                base.AfterDelay(0x1d4c, new Action(class3.method_5));
                base.AfterDelay(0x2328, new Action(class3.method_6));
                return;
            Label_36C3:
                str4 = str4 + " " + strArray2[num3];
                num3++;
            Label_36DC:
                if (num3 < strArray2.Length)
                {
                    goto Label_36C3;
                }
                Class75.smethod_64(this, str4.Trim());
                return;
            Label_372F:
                str4 = str4 + " " + strArray2[num3];
                num3++;
            Label_3748:
                if (num3 < strArray2.Length)
                {
                    goto Label_372F;
                }
                Entity entity12 = class2.entity_0;
                Class75.smethod_50(str4.Trim(), entity12, current, this);
                Class75.smethod_73(this, class2.entity_0, "^5Mess sent to ^1" + this.getPlayerName(current));
                return;
            Label_37B2:
                Class75.smethod_73(this, class2.entity_0, "^5There are no active votings");
                return;
            Label_37D3:
                if (strArray.Length == 1)
                {
                    if (bool_51)
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
                        Class75.smethod_73(this, class2.entity_0, "^5The command will be active as soon as you start the match");
                    }
                }
                return;
            Label_3A2F:
                Class75.smethod_73(this, class2.entity_0, "^1Vote already expressed!");
                return;
            Label_3A45:
                Class75.smethod_73(this, class2.entity_0, "^1No active votings!");
                return;
            Label_3B2F:
                Class75.smethod_73(this, class2.entity_0, "^1Vote already expressed!");
                return;
            Label_3B45:
                Class75.smethod_73(this, class2.entity_0, "^1No active votings!");
                return;
            Label_3BA6:
                if ((string_98 != null) && (this.TPassato(DateTime.Parse(string_98)) < 2.0))
                {
                    Class75.smethod_73(this, class2.entity_0, "^5There Must pass at least 1 minutes after the last votation or the begin of the match");
                }
                else
                {
                    Class75.smethod_75(this, class2.entity_0, string_106);
                }
                return;
            Label_3BF8:
                Class75.smethod_73(this, class2.entity_0, "^1The number of the players is less than 3!!!");
                return;
            Label_3C0E:
                Class75.smethod_73(this, class2.entity_0, "^1Votation is not enabled!!!");
                return;
            Label_3CDC:
                Class75.smethod_73(this, class2.entity_0, "^1Wrong password or you're graduated!");
                return;
            Label_3CF2:
                Class75.smethod_73(this, class2.entity_0, "^1Command is not enabled!!!");
                return;
            Label_3DAB:
                Class75.smethod_73(this, class2.entity_0, "^1Wrong password or you're graduated!");
                return;
            Label_3E1D:
                if (num12 == 70)
                {
                    class2.entity_0.SetClientDvar("cg_fov", "70");
                    Class75.smethod_158(this, class2.entity_0, "^5 Fov Set on ^170");
                }
                else if (num12 == 0x4b)
                {
                    class2.entity_0.SetClientDvar("cg_fov", "75");
                    Class75.smethod_158(this, class2.entity_0, "^5 Fov Set to ^175");
                }
                else if (num12 == 80)
                {
                    class2.entity_0.SetClientDvar("cg_fov", "80");
                    Class75.smethod_158(this, class2.entity_0, "^5 Fov Set on ^180");
                }
                else if (num12 == 0x55)
                {
                    class2.entity_0.SetClientDvar("cg_fov", "85");
                    Class75.smethod_158(this, class2.entity_0, "^5 Fov Set on ^185");
                }
                else if (num12 == 90)
                {
                    class2.entity_0.SetClientDvar("cg_fov", "90");
                    Class75.smethod_158(this, class2.entity_0, "^5 Fov Set on ^190");
                }
                else
                {
                    Class75.smethod_158(this, class2.entity_0, "^5 Value ^1" + num12 + "^5 is not valid. Choose from 65-70-75-80-85-90!");
                }
                return;
            Label_3F5A:
                if (DBPlayerlvl[num4] != "")
                {
                    goto Label_3F8D;
                }
                num4++;
            Label_3F7B:
                if (num4 < DBPlayerlvl.Count)
                {
                    goto Label_3F5A;
                }
                goto Label_3FA1;
            Label_3F8D:
                Class75.smethod_73(this, class2.entity_0, "^5Command already in use!");
                flag = false;
            Label_3FA1:
                if (flag)
                {
                    int num13;
                    Entity entity14;
                    if (bool_41)
                    {
                        if ((this.getPlayerPsw(class2.entity_0) == 1) && (this.getPlayerPswOk(class2.entity_0) == 1))
                        {
                            str3 = "add";
                            num13 = DBPlayerlvl.Count - 1;
                            entity14 = class2.entity_0;
                            Class75.smethod_61(num13, entity14, null, str3, this);
                            Class75.smethod_73(this, class2.entity_0, "^5" + this.getPlayerName(class2.entity_0) + " ^7registered as ^1" + DBNomeGruppi[DBNomeGruppi.Count - 1]);
                        }
                        else
                        {
                            Class75.smethod_73(this, class2.entity_0, "^5You must first register your account... use function ^1!psw");
                        }
                    }
                    else
                    {
                        str3 = "add";
                        num13 = DBPlayerlvl.Count - 1;
                        entity14 = class2.entity_0;
                        Class75.smethod_61(num13, entity14, null, str3, this);
                        Class75.smethod_73(this, class2.entity_0, "^5" + this.getPlayerName(class2.entity_0) + " ^7registered as ^1" + DBNomeGruppi[DBNomeGruppi.Count - 1]);
                    }
                }
                return;
            Label_4193:
                Class75.smethod_73(this, class2.entity_0, "^1Could not find you in the stats database, type !register to save your stats");
                return;
            Label_41A9:
                current = this.method_4(class2.entity_0, strArray[1]);
                if (current != null)
                {
                    strArray3 = Class75.smethod_38(this, current);
                    if (strArray3 != null)
                    {
                        Class75.smethod_73(this, class2.entity_0, "^5Player^1 " + this.getPlayerName(current) + " ^5stats: ^7Kill ^1" + strArray3[3].ToString() + "^7, Dead ^1" + strArray3[4].ToString() + "^7, Skill ^1" + strArray3[5].ToString() + "^7, HeadShot ^1" + strArray3[6].ToString() + "^7, Moab ^1" + strArray3[7].ToString());
                    }
                    else
                    {
                        Class75.smethod_73(this, class2.entity_0, "^1There were no XlrStats found for this player");
                    }
                }
                return;
            Label_4296:
                Class75.smethod_73(this, class2.entity_0, "^1XlrStats not Active");
                return;
            Label_42F6:
                Class75.smethod_73(this, class2.entity_0, "^1XlrStats not Active in Infect Mode");
                return;
            Label_430C:
                Class75.smethod_189(this, class2.entity_0);
                return;
            Label_431D:
                Class75.smethod_73(this, class2.entity_0, "^1XlrStats not Active");
                return;
            Label_44FB:
                Class75.smethod_73(this, class2.entity_0, "^1Function not found");
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("dictionary"))
                {
                    LogErrori("EseguiComando", exception, "---");
                }
            }
        }

        private void method_20(Entity entity_0, string string_106)
        {
            foreach (Entity entity in list_3)
            {
                if (this.getPlayerLevel(entity) > 2)
                {
                    if (entity_0 != null)
                    {
                        Utilities.RawSayTo(entity, "^7[^5" + this.getPlayerName(entity_0) + "^7][PM]: " + string_106);
                    }
                    else
                    {
                        Utilities.RawSayTo(entity, "^7[" + string_4 + "^5 for Mod^7][PM]: " + string_106);
                    }
                }
            }
        }

        private void method_21(Entity entity_0)
        {
            string str;
            StreamWriter writer;
            if (string_2.StartsWith("te"))
            {
                str = this.getPlayerHWID(entity_0);
            }
            else
            {
                str = this.getPlayerIP(entity_0);
            }
            if (System.IO.File.Exists(string_85 + string_56))
            {
                string[] strArray = System.IO.File.ReadAllLines(string_85 + string_56);
                System.IO.File.Delete(string_85 + string_56);
                bool flag = false;
                using (writer = new StreamWriter(string_85 + string_56, true))
                {
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        string str2 = strArray[i];
                        if (str2.StartsWith(str))
                        {
                            flag = true;
                            bool flag2 = false;
                            bool flag3 = false;
                            string[] strArray2 = str2.Split(new char[] { char_1 });
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
                                    str2 = strArray[i] + char_1 + this.getPlayerName(entity_0);
                                }
                                string str3 = "";
                                for (int k = 1; k < strArray2.Length; k++)
                                {
                                    str3 = str3 + ",^5" + strArray2[k] + "^1";
                                }
                                if (!this.IsUserSession(entity_0))
                                {
                                    string[] strArray3 = new string[] { "[", this.getPlayerName(entity_0), "] Detected Alias (", str3.TrimStart(new char[] { char_1 }), ")" };
                                    ServerControll controll = this;
                                    Class75.smethod_84(string.Concat(strArray3), controll);
                                    this.method_20(null, "^7[^1" + this.getPlayerName(entity_0) + "^7] Detected Alias (^5" + str3.TrimStart(new char[] { char_1 }) + "^7)");
                                }
                            }
                        }
                        writer.WriteLine(str2.Replace(",,", char_1.ToString()));
                    }
                    if (!flag)
                    {
                        writer.WriteLine(str + char_1 + this.getPlayerName(entity_0));
                    }
                    writer.Close();
                    return;
                }
            }
            using (writer = new StreamWriter(string_85 + string_56, true))
            {
                writer.WriteLine(str + char_1 + this.getPlayerName(entity_0));
                writer.Close();
            }
        }

        private void method_22(Entity entity_0)
        {
            Class75.smethod_73(this, entity_0, "^5MineField Activeted");
            Random random = new Random();
            foreach (Entity entity in list_3)
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

        internal void method_23(Entity entity_0, Entity entity_1, int int_31, string string_106)
        {
            using (StreamWriter writer = new StreamWriter(string_85 + string_54, true))
            {
                string str = string.Concat(new object[] { 
                    DateTime.Now, char_2.ToString(), int_31, char_1, this.getPlayerName(entity_1), char_1, this.getPlayerID(entity_1), char_1, this.getPlayerGuid(entity_1), char_1, this.getPlayerHWID(entity_1), char_1, this.getPlayerXuid(entity_1), char_1, this.getPlayerIP(entity_1), char_1,
                    string_106
                });
                writer.WriteLine(str);
                writer.Close();
                if (entity_0 != null)
                {
                    Class75.smethod_73(this, entity_0, string.Concat(new object[] { "^1", this.getPlayerName(entity_1), " ^5added to the TempBan list for^7 ", int_31, "min" }));
                    Class75.smethod_64(this, string_23.Replace("<playername>", entity_1.Name).Replace("<reason>", string_106).Replace("<kicker>", this.getPlayerName(entity_0)));
                    Class75.smethod_6(this, string.Concat(new object[] { "dropclient ", entity_1.Call<int>("getentitynumber", new Parameter[0]), " \"", string_106, "\"" }), 0);
                }
                else
                {
                    Class75.smethod_64(this, string_23.Replace("<playername>", entity_1.Name).Replace("<reason>", string_106).Replace("<kicker>", "Server"));
                    Class75.smethod_6(this, string.Concat(new object[] { "dropclient ", entity_1.Call<int>("getentitynumber", new Parameter[0]), " \"", string_106, "\"" }), 0);
                }
            }
        }

        private void method_24(Entity entity_0, string string_106)
        {
            if (System.IO.File.Exists(string_85 + string_54))
            {
                string[] strArray = System.IO.File.ReadAllLines(string_85 + string_54);
                System.IO.File.Delete(string_85 + string_54);
                bool flag = false;
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { char_1 });
                    bool flag2 = true;
                    for (int j = 1; j < 3; j++)
                    {
                        if ((string_106.Length < 4) && isNum(string_106))
                        {
                            if (string_106 != i.ToString())
                            {
                                continue;
                            }
                            goto Label_00C2;
                        }
                        if (strArray2[j].ToLower().Contains(string_106))
                        {
                            goto Label_010A;
                        }
                    }
                    goto Label_0150;
                Label_00C2:
                    flag2 = false;
                    flag = true;
                    Class75.smethod_73(this, entity_0, "^5Player ^1" + strArray2[1] + "^7[^1" + strArray2[2] + "^7] ^5successfully UnBanned!");
                    goto Label_0150;
                Label_010A:
                    flag2 = false;
                    flag = true;
                    Class75.smethod_73(this, entity_0, "^5Player ^1" + strArray2[1] + "^7[^1" + strArray2[2] + "^7] ^5successfully UnBanned!");
                Label_0150:
                    if (flag2)
                    {
                        using (StreamWriter writer = new StreamWriter(string_85 + string_54, true))
                        {
                            writer.WriteLine(strArray[i]);
                            writer.Close();
                        }
                    }
                }
                if (!flag)
                {
                    Class75.smethod_73(this, entity_0, "^1No Player Found");
                }
            }
        }

        internal void method_25(Entity entity_0, Entity entity_1, string string_106)
        {
            using (StreamWriter writer = new StreamWriter(string_85 + string_55, true))
            {
                string str = string.Concat(new object[] { DateTime.Now, char_1.ToString(), this.getPlayerName(entity_1), char_1, this.getPlayerID(entity_1), char_1, this.getPlayerGuid(entity_1), char_1, this.getPlayerHWID(entity_1), char_1, this.getPlayerXuid(entity_1), char_1, this.getPlayerIP(entity_1), char_1, string_106 });
                writer.WriteLine(str);
                writer.Close();
                if (entity_0 != null)
                {
                    Class75.smethod_73(this, entity_0, "^5" + this.getPlayerName(entity_1) + "^1 added to the PermBan list!");
                    Class75.smethod_64(this, string_22.Replace("<playername>", entity_1.Name).Replace("<reason>", string_106).Replace("<kicker>", this.getPlayerName(entity_0)));
                    Class75.smethod_6(this, string.Concat(new object[] { "dropclient ", entity_1.Call<int>("getentitynumber", new Parameter[0]), " \"", string_106, "\"" }), 0);
                }
                else
                {
                    Class75.smethod_64(this, string_22.Replace("<playername>", entity_1.Name).Replace("<reason>", string_106).Replace("<kicker>", "Server"));
                    Class75.smethod_6(this, string.Concat(new object[] { "dropclient ", entity_1.Call<int>("getentitynumber", new Parameter[0]), " \"", string_106, "\"" }), 0);
                }
            }
        }

        private void method_26(Entity entity_0, string string_106)
        {
            if (System.IO.File.Exists(string_85 + string_55))
            {
                string[] strArray = System.IO.File.ReadAllLines(string_85 + string_55);
                System.IO.File.Delete(string_85 + string_55);
                bool flag = false;
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { char_1 });
                    bool flag2 = true;
                    for (int j = 1; j < 3; j++)
                    {
                        if ((string_106.Length < 4) && isNum(string_106))
                        {
                            if (string_106 != i.ToString())
                            {
                                continue;
                            }
                            goto Label_00C2;
                        }
                        if (strArray2[j].ToLower().Contains(string_106))
                        {
                            goto Label_010A;
                        }
                    }
                    goto Label_0150;
                Label_00C2:
                    flag2 = false;
                    flag = true;
                    Class75.smethod_73(this, entity_0, "^5Player ^1" + strArray2[1] + "^7[^1" + strArray2[2] + "^7] ^5successfully UnBanned!");
                    goto Label_0150;
                Label_010A:
                    flag2 = false;
                    flag = true;
                    Class75.smethod_73(this, entity_0, "^5Player ^1" + strArray2[1] + "^7[^1" + strArray2[2] + "^7] ^5successfully UnBanned!");
                Label_0150:
                    if (flag2)
                    {
                        using (StreamWriter writer = new StreamWriter(string_85 + string_55, true))
                        {
                            writer.WriteLine(strArray[i]);
                            writer.Close();
                        }
                    }
                }
                if (!flag)
                {
                    Class75.smethod_73(this, entity_0, "^1No Player Found");
                }
            }
        }

        private void method_27(Entity entity_0, string string_106, string string_107)
        {
            StreamWriter writer;
            if (string_107 == "add")
            {
                Entity player = this.method_4(entity_0, string_106);
                if (player != null)
                {
                    if (this.getPlayerLevel(player) > 1)
                    {
                        Class75.smethod_73(this, entity_0, "^1Error - The Player is an Admin!");
                        return;
                    }
                    using (writer = new StreamWriter(string_85 + string_64, true))
                    {
                        string str = string.Concat(new object[] { 
                            DateTime.Now, char_1.ToString(), this.getPlayerName(player), char_1, this.getPlayerID(player), char_1, this.getPlayerGuid(player), char_1, this.getPlayerHWID(player), char_1, this.getPlayerXuid(player), char_1, this.getPlayerIP(player), ",insert at ", DateTime.Now.ToShortDateString(), " by ",
                            this.getPlayerName(entity_0)
                        });
                        writer.WriteLine(str);
                        writer.Close();
                        if (entity_0 != null)
                        {
                            Class75.smethod_73(this, entity_0, "^1" + this.getPlayerName(player) + " added to the Player Hack list!");
                        }
                        return;
                    }
                }
                Class75.smethod_73(this, entity_0, "^5Player not found? Use^1 ID");
                Class75.smethod_180(this, entity_0);
            }
            else if (string_107 == "del")
            {
                if (System.IO.File.Exists(string_85 + string_64))
                {
                    string[] strArray = System.IO.File.ReadAllLines(string_85 + string_64);
                    System.IO.File.Delete(string_85 + string_64);
                    bool flag = false;
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        string[] strArray2 = strArray[i].Split(new char[] { char_1 });
                        bool flag2 = true;
                        for (int j = 0; j < 2; j++)
                        {
                            if (strArray2[j].ToLower().Contains(string_106))
                            {
                                goto Label_023E;
                            }
                        }
                        goto Label_0285;
                    Label_023E:
                        flag2 = false;
                        flag = true;
                        Class75.smethod_73(this, entity_0, "^5Report Player ^1" + strArray2[0] + "^7[^1" + strArray2[1] + "^7] ^5successfully deleted!");
                    Label_0285:
                        if (flag2)
                        {
                            using (writer = new StreamWriter(string_85 + string_64, true))
                            {
                                writer.WriteLine(strArray[i]);
                                writer.Close();
                            }
                        }
                    }
                    if (!flag)
                    {
                        Class75.smethod_73(this, entity_0, "^1No Player Found");
                    }
                }
                else
                {
                    Class75.smethod_73(this, entity_0, "^1No Player Found");
                }
            }
        }

        internal void method_28()
        {
            try
            {
                List<Entity>.Enumerator enumerator;
                Entity current;
                if ((string_93.Contains("inf") || bool_8) || (string_94 != "null"))
                {
                    return;
                }
                list_7.Clear();
                list_9.Clear();
                list_6.Clear();
                list_8.Clear();
                using (enumerator = list_2.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        current = enumerator.Current;
                        if (current.GetField<string>("sessionteam") == "allies")
                        {
                            list_6.Add(current);
                            if (!current.IsAlive)
                            {
                                list_8.Add(current);
                            }
                        }
                        else if (current.GetField<string>("sessionteam") == "axis")
                        {
                            list_7.Add(current);
                            if (!current.IsAlive)
                            {
                                list_9.Add(current);
                            }
                        }
                    }
                }
                int_15 = list_6.Count - list_7.Count;
                List<Entity> list = new List<Entity>();
                if (list_6.Count >= list_7.Count)
                {
                    goto Label_0237;
                }
                if (((int_15 == -1) || (int_15 == 1)) || (int_15 == 0))
                {
                    return;
                }
                if (list_9.Count > 0)
                {
                    list = list_9;
                }
                else
                {
                    list = list_7;
                }
                using (enumerator = list.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        current = enumerator.Current;
                        if (((int_15 != -1) && (int_15 != 1)) && (int_15 != 0))
                        {
                            goto Label_01B9;
                        }
                    }
                    goto Label_022C;
                Label_01B9:
                    current.SetField("team", "allies");
                    current.SetField("sessionteam", "allies");
                    current.Notify("menuresponse", new Parameter[] { new Parameter("team_marinesopfor"), new Parameter("allies") });
                    Class75.smethod_158(this, current, "Balanced Team!");
                }
            Label_022C:
                this.method_28();
                return;
            Label_0237:
                if ((list_6.Count <= list_7.Count) || (((int_15 == 1) || (int_15 == -1)) || (int_15 == 0)))
                {
                    return;
                }
                if (list_8.Count > 0)
                {
                    list = list_8;
                }
                else
                {
                    list = list_6;
                }
                using (enumerator = list.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        current = enumerator.Current;
                        if (((int_15 != 1) && (int_15 != -1)) && (int_15 != 0))
                        {
                            goto Label_02CF;
                        }
                    }
                    goto Label_0342;
                Label_02CF:
                    current.SetField("team", "axis");
                    current.SetField("sessionteam", "axis");
                    current.Notify("menuresponse", new Parameter[] { new Parameter("team_marinesopfor"), new Parameter("axis") });
                    Class75.smethod_158(this, current, "Balanced Team!");
                }
            Label_0342:
                this.method_28();
            }
            catch (Exception exception)
            {
                LogErrori("BilanciaTeam", exception, "---");
            }
        }

        private bool method_29(Entity entity_0, string string_106)
        {
            try
            {
                if (((this.getPlayerLevel(entity_0) > 0) && (this.getPlayerLevel(entity_0) < 6)) && bool_5)
                {
                    bool flag = false;
                    for (int i = 0; i < xStrComandiControlloPG.Length; i++)
                    {
                        if (string_106.Equals(xStrComandiControlloPG[i]))
                        {
                            flag = true;
                        }
                    }
                    if (flag)
                    {
                        foreach (Entity entity in list_3)
                        {
                            if ((entity.EntRef != entity_0.EntRef) && (((this.getPlayerLevel(entity) > this.getPlayerLevel(entity_0)) && (this.getPlayerAFK(entity) == 0)) && (this.getPlayerAccess(entity) == 1)))
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("dictionary."))
                {
                    LogErrori("ControllPoteriGraduati", exception, "---");
                }
                return true;
            }
        }

        internal void method_3(Entity entity_0)
        {
            Action<Entity, Parameter> handler = null;
            Action<Entity, Parameter> action2 = null;
            Action<Entity> action3 = null;
            Action action4 = null;
            Class12 class2 = new Class12 {
                entity_0 = entity_0,
                serverControll_0 = this
            };
            try
            {
                string[] strArray = new string[] { DateTime.Now.ToShortTimeString(), " [Player]Connect... [", this.getPlayerSlot(class2.entity_0), "]", this.getPlayerName(class2.entity_0) };
                ServerControll controll = this;
                Class75.smethod_84(string.Concat(strArray), controll);
                list_3.Add(class2.entity_0);
                Class75.smethod_12(this, class2.entity_0);
                Class75.smethod_162(class2.entity_0, this);
                Class75.smethod_33(this, class2.entity_0);
                Class75.smethod_152(this, class2.entity_0);
                Class75.smethod_127(class2.entity_0, this);
                Class75.smethod_13(this, class2.entity_0);
                class2.entity_0.Call("notifyonplayercommand", new Parameter[] { "CRD", "+scores" });
                class2.entity_0.Call("notifyonplayercommand", new Parameter[] { "-CRD", "-scores" });
                Class75.smethod_205(class2.entity_0, this);
                if (handler == null)
                {
                    handler = new Action<Entity, Parameter>(this.method_42);
                }
                class2.entity_0.OnNotify("weapon_change", handler);
                if (bool_24 && !list_5.Contains(class2.entity_0))
                {
                    if (action2 == null)
                    {
                        action2 = new Action<Entity, Parameter>(this.method_43);
                    }
                    class2.entity_0.OnNotify("weapon_fired", action2);
                }
                if (action3 == null)
                {
                    action3 = new Action<Entity>(this.method_44);
                }
                class2.entity_0.OnNotify("joined_team", action3);
                if ((!this.IsUserSession(class2.entity_0) && bool_26) && bool_52)
                {
                    Class75.smethod_144(class2.entity_0, this, null);
                }
                if (action4 == null)
                {
                    action4 = new Action(class2.method_0);
                }
                class2.entity_0.SpawnedPlayer += action4;
                if (!this.IsUserSession(class2.entity_0))
                {
                    if (int_12 != 0)
                    {
                        class2.entity_0.SetClientDvar("com_maxfps", int_12.ToString());
                        class2.entity_0.SetClientDvar("con_maxfps", int_12.ToString());
                    }
                    int_29++;
                    if (bool_51)
                    {
                        Class75.smethod_174(this);
                    }
                }
                Class75.smethod_93(this, class2.entity_0);
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("range."))
                {
                    LogErrori("IsAPlayer", exception, "---");
                }
            }
        }

        private void method_30()
        {
            Class61 class2 = new Class61 {
                serverControll_0 = this
            };
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
                string str = "@echo off";
                string str2 = "TIMEOUT /T 2 /NOBREAK";
                string str3 = "TASKKILL /F /IM " + string_0 + ".exe /T";
                string str4 = "TIMEOUT /T 2 /NOBREAK";
                string str5 = "start /B /MIN " + string_0 + ".exe +set net_queryPort " + num.ToString() + " +set net_port " + num2.ToString() + " +set net_masterServerPort " + num3.ToString() + " +set sv_config \"server.cfg\" +start_map_rotate +set dedicated 2";
                string str6 = "TIMEOUT /T 2 /NOBREAK";
                string str7 = "DEL /F /Q riavvia.bat";
                string str8 = "cls";
                writer.WriteLine(str);
                writer.WriteLine(str2);
                writer.WriteLine(str3);
                writer.WriteLine(str4);
                writer.WriteLine(str5);
                writer.WriteLine(str6);
                writer.WriteLine(str7);
                writer.WriteLine(str8);
                writer.Close();
            }
            base.OnInterval(0x3e8, new Func<bool>(class2.method_0));
        }

        internal void method_31()
        {
            try
            {
                DBPlayerlvl.Add("NormalUsersEmpty");
                DBPlayerlvl.Add(StrPlayerlvl01);
                DBPlayerlvl.Add(StrPlayerlvl02);
                DBPlayerlvl.Add(StrPlayerlvl03);
                DBPlayerlvl.Add(StrPlayerlvl04);
                DBPlayerlvl.Add(StrPlayerlvl05);
                DBPlayerlvl.Add(StrPlayerlvl06);
                DBPlayerlvl.Add(StrPlayerlvl07);
                DBPlayerlvl.Add(StrPlayerlvl08);
                DBPlayerlvl.Add(StrPlayerlvl09);
                DBComandilvl.Add(StrComandilvl00);
                DBComandilvl.Add(StrComandilvl01);
                DBComandilvl.Add(StrComandilvl02);
                DBComandilvl.Add(StrComandilvl03);
                DBComandilvl.Add(StrComandilvl04);
                DBComandilvl.Add(StrComandilvl05);
                DBComandilvl.Add(StrComandilvl06);
                DBComandilvl.Add(StrComandilvl07);
                DBComandilvl.Add(StrComandilvl08);
                DBComandilvl.Add(StrComandilvl09);
                for (int i = 0; i < DBComandilvl.Count; i++)
                {
                    DBHelplvl.Add(DBComandilvl[i]);
                }
                DBNomeGruppi.Add("NormalUsers");
                DBNomeGruppi.Add(NomeGruppo01);
                DBNomeGruppi.Add(NomeGruppo02);
                DBNomeGruppi.Add(NomeGruppo03);
                DBNomeGruppi.Add(NomeGruppo04);
                DBNomeGruppi.Add(NomeGruppo05);
                DBNomeGruppi.Add(NomeGruppo06);
                DBNomeGruppi.Add(NomeGruppo07);
                DBNomeGruppi.Add(NomeGruppo08);
                DBNomeGruppi.Add(NomeGruppo09);
                DBColorlvl.Add("^7");
                DBColorlvl.Add("^" + Colorlvl01.ToString());
                DBColorlvl.Add("^" + Colorlvl02.ToString());
                DBColorlvl.Add("^" + Colorlvl03.ToString());
                DBColorlvl.Add("^" + Colorlvl04.ToString());
                DBColorlvl.Add("^" + Colorlvl05.ToString());
                DBColorlvl.Add("^" + Colorlvl06.ToString());
                DBColorlvl.Add("^" + Colorlvl07.ToString());
                DBColorlvl.Add("^" + Colorlvl08.ToString());
                DBColorlvl.Add("^" + Colorlvl09.ToString());
                DBTaglvl.Add("[]");
                DBTaglvl.Add(Taglvl01);
                DBTaglvl.Add(Taglvl02);
                DBTaglvl.Add(Taglvl03);
                DBTaglvl.Add(Taglvl04);
                DBTaglvl.Add(Taglvl05);
                DBTaglvl.Add(Taglvl06);
                DBTaglvl.Add(Taglvl07);
                DBTaglvl.Add(Taglvl08);
                DBTaglvl.Add(Taglvl09);
            }
            catch (Exception exception)
            {
                LogErrori("LoadDatabase", exception, "---");
            }
        }

        internal void method_32(Entity entity_0, string string_106, Entity entity_1, string string_107)
        {
            Class69 class2 = new Class69 {
                entity_0 = entity_0,
                entity_1 = entity_1,
                string_0 = string_107,
                serverControll_0 = this
            };
            try
            {
                Func<bool> function = null;
                Class70 class3 = new Class70 {
                    class69_0 = class2,
                    string_0 = string_106.Split(new char[] { char_0 })
                };
                if ((class2.entity_0 != null) && (this.getPlayerVote(class2.entity_0) != null))
                {
                    DateTime temp = DateTime.Parse(this.getPlayerVote(class2.entity_0));
                    if (this.TPassato(temp) < 3.0)
                    {
                        Class75.smethod_73(this, class2.entity_0, "^1Wait at least 2 minutes since your last vote");
                        return;
                    }
                }
                if (((class3.string_0[0].Contains("map") || class3.string_0[0].Contains("mod")) || class3.string_0[0].Contains("kick")) || class3.string_0[0].Contains("ban"))
                {
                    bool_48 = true;
                    string_98 = DateTime.Now.ToString();
                    int_18 = 0;
                    int_17 = 0;
                    if (class2.entity_0 != null)
                    {
                        Class75.smethod_105(class2.entity_0, this);
                        Class75.smethod_64(this, "^1" + this.getPlayerName(class2.entity_0) + " ^5has requested a vote");
                        this.method_33(true, class2.entity_0, string_106, int_20, null, false);
                    }
                    foreach (Entity entity in list_3)
                    {
                        entity.SetField("Voto", 0);
                        entity.Call("playlocalsound", new Parameter[] { "mp_suitcase_pickup" });
                    }
                    hudElem_0 = HudElem.CreateServerFontString("hudbig", 0.9f);
                    hudElem_1 = HudElem.CreateServerFontString("hudbig", 0.8f);
                    hudElem_0.SetPoint("TOPLEFT", "TOPLEFT", 12, 0x69);
                    hudElem_0.HideWhenInMenu = true;
                    hudElem_1.SetPoint("TOPLEFT", "TOPLEFT", 12, 0x7a);
                    hudElem_1.HideWhenInMenu = true;
                    if (class3.string_0[0].Contains("map"))
                    {
                        hudElem_0.SetText("^7Vote Change ^5Map ^1" + Class75.smethod_88(this, class3.string_0[1]) + "?");
                    }
                    else if (class3.string_0[0].Contains("mod"))
                    {
                        hudElem_0.SetText("^7Vote Change ^5Mode ^1" + class3.string_0[1] + "?");
                    }
                    else if (class3.string_0[0].Contains("kick"))
                    {
                        hudElem_0.SetText("^7Vote ^5kick^1" + class2.string_0 + "?");
                    }
                    else if (class3.string_0[0].Contains("ban"))
                    {
                        hudElem_0.SetText("^7Vote ^5TempBan ^1" + class2.string_0 + "?");
                    }
                    hudElem_0.Alpha = 1f;
                    hudElem_1.Alpha = 1f;
                    if (function == null)
                    {
                        function = new Func<bool>(class3.method_0);
                    }
                    base.OnInterval(0x3e8, function);
                }
                else
                {
                    Class75.smethod_73(this, class2.entity_0, "^1Invalid type of vote!");
                }
            }
            catch (Exception exception)
            {
                LogErrori("AvvVotazione", exception, "---");
            }
        }

        private void method_33(bool bool_55, Entity entity_0, string string_106, int int_31, Entity entity_1 = null, bool bool_56 = false)
        {
            try
            {
                if (!System.IO.File.Exists(string_88 + string_67))
                {
                    using (StreamWriter writer = new StreamWriter(string_88 + string_67, true))
                    {
                        writer.WriteLine("[Voting]");
                        writer.WriteLine("[User]");
                        writer.Close();
                    }
                }
                IniParser parser = new IniParser(string_88 + string_67);
                if (bool_55)
                {
                    parser.AddSetting("Voting", "Player", this.getPlayerName(entity_0));
                    parser.AddSetting("Voting", "Vote", string_106);
                    parser.AddSetting("Voting", "tmp", int_31.ToString());
                }
                else
                {
                    parser.AddSetting("User", this.getPlayerGuid(entity_1) + char_1 + bool_56.ToString());
                }
                parser.SaveSettings();
            }
            catch (Exception exception)
            {
                LogErrori("RecordVoting", exception, "---");
            }
        }

        private void method_34(Entity entity_0)
        {
            ServerControll.Class72 @class = new ServerControll.Class72();
            @class.entity_0 = entity_0;
            @class.serverControll_0 = this;
            try
            {
                if (File.Exists(ServerControll.string_84 + ServerControll.string_53))
                {
                    ServerControll.Class73 class2 = new ServerControll.Class73();
                    class2.class72_0 = @class;
                    int num = 5;
                    int num2 = 500;
                    class2.list_0 = new List<string>();
                    List<string> list = new List<string>();
                    list.AddRange(File.ReadAllLines(ServerControll.string_84 + ServerControll.string_53));
                    int num3 = 1;
                    while (true)
                    {
                        double num4 = 0.0;
                        string text = string.Empty;
                        string text2 = string.Empty;
                        if (num3 > num || list.Count <= 0)
                        {
                            break;
                        }
                        foreach (string current in list)
                        {
                            string[] array = current.Split(new char[]
							{
								ServerControll.char_5
							});
                            string text3 = array[1];
                            double num5 = Convert.ToDouble(array[5]);
                            double num6 = Convert.ToDouble(array[3]);
                            if (num5 > num4 && num6 >= (double)num2)
                            {
                                num4 = num5;
                                text = text3;
                                text2 = current;
                            }
                        }
                        if (text2 != string.Empty)
                        {
                            list.Remove(text2);
                            class2.list_0.Add(string.Concat(new object[]
							{
								"^1",
								num3,
								"° ^5",
								text,
								" ^7Skill: ^1",
								num4
							}));
                        }
                        num3++;
                    }
                    class2.int_0 = 0;
                    base.OnInterval(1000, new Func<bool>(class2.method_0));
                }
                else
                {
                    if (@class.entity_0 != null)
                    {
                        Class75.smethod_73(this, @class.entity_0, "^1Could not find you in the stats database, type !register to save your stats");
                    }
                }
            }
            catch (Exception error)
            {
                ServerControll.LogErrori("XlrTopStats", error, "---");
            }
        }

        private void method_35(Entity entity_0, double double_0, double double_1, double double_2, double double_3, double double_4)
        {
            try
            {
                string[] strArray = null;
                if (System.IO.File.Exists(string_84 + string_53))
                {
                    strArray = System.IO.File.ReadAllLines(string_84 + string_53);
                    System.IO.File.Delete(string_84 + string_53);
                }
                using (StreamWriter writer = new StreamWriter(string_84 + string_53, true))
                {
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        string str = strArray[i].ToString();
                        if (str.StartsWith(this.getPlayerGuid(entity_0)))
                        {
                            str = string.Concat(new object[] { this.getPlayerGuid(entity_0), char_5, this.getPlayerName(entity_0), char_5, DateTime.Now, char_5, double_0.ToString(), char_5, double_1.ToString(), char_5, double_2.ToString(), char_5, double_3.ToString(), char_5, double_4.ToString() });
                        }
                        writer.WriteLine(str);
                    }
                    writer.Close();
                }
            }
            catch (Exception exception)
            {
                LogErrori("XlrUpdate", exception, "---");
            }
        }

        private void method_36(Entity entity_0, Entity entity_1, bool bool_55, bool bool_56)
        {
            try
            {
                double num;
                double num2;
                double num3;
                double num4;
                double num5;
                string[] strArray2;
                string[] strArray = Class75.smethod_38(this, entity_0);
                if (strArray != null)
                {
                    num = Convert.ToDouble(strArray[3]) + 1.0;
                    num2 = Convert.ToDouble(strArray[4]);
                    num3 = num / num2;
                    num4 = (strArray.Length > 6) ? Convert.ToDouble(strArray[6]) : 0.0;
                    num5 = (strArray.Length > 6) ? Convert.ToDouble(strArray[7]) : 0.0;
                    if (bool_55)
                    {
                        num4++;
                    }
                    if (bool_56)
                    {
                        num5++;
                    }
                    if (num3.ToString() == "Infinity")
                    {
                        num3 = 0.0;
                    }
                    strArray2 = num3.ToString().Split(new char[] { '.' });
                    if ((strArray2.Length == 2) && (strArray2[1].Length > 3))
                    {
                        num3 = Convert.ToDouble(strArray2[0] + "." + strArray2[1].Substring(0, 3));
                    }
                    this.method_35(entity_0, num, num2, num3, num4, num5);
                }
                string[] strArray3 = Class75.smethod_38(this, entity_1);
                if (strArray3 != null)
                {
                    num = Convert.ToDouble(strArray3[3]);
                    num2 = Convert.ToDouble(strArray3[4]) + 1.0;
                    num3 = num / num2;
                    num4 = (strArray3.Length > 6) ? Convert.ToDouble(strArray3[6]) : 0.0;
                    num5 = (strArray3.Length > 6) ? Convert.ToDouble(strArray3[7]) : 0.0;
                    if (num3.ToString() == "Infinity")
                    {
                        num3 = 0.0;
                    }
                    strArray2 = num3.ToString().Split(new char[] { '.' });
                    if ((strArray2.Length == 2) && (strArray2[1].Length > 3))
                    {
                        num3 = Convert.ToDouble(strArray2[0] + "." + strArray2[1].Substring(0, 3));
                    }
                    this.method_35(entity_1, num, num2, num3, num4, num5);
                }
            }
            catch (Exception exception)
            {
                LogErrori("XlrStatUPD", exception, "---");
            }
        }

        internal bool method_37(Entity entity_0)
        {
            Action<Entity> function = null;
            Action<Entity> action2 = null;
            Class0 class2 = new Class0 {
                entity_0 = entity_0,
                serverControll_0 = this
            };
            if (class2.entity_0.IsAlive)
            {
                Random random = new Random();
                Random random2 = new Random();
                Entity entity = null;
                foreach (Entity entity2 in list_2)
                {
                    if ((((entity2.IsAlive && (class2.entity_0.EntRef != entity2.EntRef)) && ((entity2.GetField<string>("sessionstate") != "spectator") && (entity2.GetField<string>("sessionteam") != "spectator"))) && ((class2.entity_0.GetField<string>("sessionteam") != entity2.GetField<string>("sessionteam")) || ((base.Call<string>("getdvar", new Parameter[] { "g_gametype" }) == "dm") || (base.Call<string>("getdvar", new Parameter[] { "g_gametype" }) == "oic")))) && (base.Call<int>(0x74, new Parameter[] { class2.entity_0.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }), entity2.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }), 0, class2.entity_0 }) == 1))
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
                    Vector3 vector;
                    if (this.getBotLook(class2.entity_0) == 0)
                    {
                        if (random2.Next(this.int_0) == 0)
                        {
                            Class75.smethod_118(this, class2.entity_0, 1);
                            vector = base.Call<Vector3>("VectorToAngles", new Parameter[] { entity.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }) - class2.entity_0.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }) });
                            class2.entity_0.Call("setplayerangles", new Parameter[] { vector });
                            class2.entity_0.Call("giveMaxAmmo", new Parameter[] { class2.entity_0.CurrentWeapon });
                            if ((random.Next(this.int_1) == 0) && (class2.entity_0.Origin.DistanceTo(entity.Origin) <= this.int_2))
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
                        vector = base.Call<Vector3>("VectorToAngles", new Parameter[] { entity.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }) - class2.entity_0.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }) });
                        class2.entity_0.Call("setplayerangles", new Parameter[] { vector });
                        class2.entity_0.Call("giveMaxAmmo", new Parameter[] { class2.entity_0.CurrentWeapon });
                        if ((random.Next(this.int_1) == 0) && (class2.entity_0.Origin.DistanceTo(entity.Origin) <= this.int_2))
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
                    Class75.smethod_118(this, class2.entity_0, 0);
                }
            }
            return true;
        }

        internal bool method_38()
        {
            int num4;
            if (!bool_53)
            {
                return false;
            }
            int num = int.Parse(string_95);
            int count = list_2.Count;
            int num3 = num - count;
            for (num4 = 6; num4 < num3; num4++)
            {
                Class75.smethod_176(this, 1);
            }
            int num5 = list_2.Count;
            int num6 = num - num5;
            for (num4 = num6; num4 == num; num4++)
            {
                using (List<Entity>.Enumerator enumerator = list_5.GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        Entity current = enumerator.Current;
                        Class75.smethod_6(this, "dropclient " + current.EntRef, 200);
                    }
                }
            }
            return true;
        }

        internal void method_39()
        {
            this.method_0("all");
            if (bool_22)
            {
                this.method_28();
            }
        }

        internal Entity method_4(Entity entity_0, string string_106)
        {
            try
            {
                if (list_2.Count != 0)
                {
                    int num = 0;
                    Entity entity2 = null;
                    foreach (Entity entity3 in list_3)
                    {
                        if (string_106.Length < 3)
                        {
                            if (this.getPlayerSlot(entity3) == string_106)
                            {
                                entity2 = entity3;
                                num++;
                            }
                        }
                        else if (((entity3.Name.ToLower().Contains(string_106) || (this.getPlayerID(entity3) == string_106)) || (this.getPlayerGuid(entity3) == string_106)) || (this.getPlayerXuid(entity3) == string_106))
                        {
                            entity2 = entity3;
                            num++;
                        }
                    }
                    if ((num == 1) && (entity2.EntRef != entity_0.EntRef))
                    {
                        return entity2;
                    }
                    if (num > 1)
                    {
                        Class75.smethod_73(this, entity_0, "^1Error - Multiple matches found!");
                        return null;
                    }
                    Class75.smethod_73(this, entity_0, "^1Error - No Player Found!");
                }
                return null;
            }
            catch (Exception exception)
            {
                LogErrori("TrovaPlayer", exception, "---");
                return null;
            }
        }

        internal void method_40()
        {
            Class75.smethod_66(this);
            //Class75.smethod_23(this);
            NoKnife nk = new NoKnife();//Class75.smethod_23(this);
            Class75.smethod_32(this);
            Class75.smethod_188(this);
            Class75.smethod_155(this);
            string_100 = base.Call<string>("getdvar", new Parameter[] { new Parameter("nextmap") }).Split(new char[] { char_0 })[1].ToLower();
            Class75.smethod_84("===============================================================", this);
            object[] objArray = new object[] { "Name Server: ", string_101, " - Date: ", DateTime.Now.Day, ".", DateTime.Now.Month, ".", DateTime.Now.Year, " - ", DateTime.Now.Hour, ":", DateTime.Now.Minute, ":", DateTime.Now.Second };
            ServerControll controll = this;
            Class75.smethod_84(string.Concat(objArray), controll);
            string[] strArray2 = new string[] { "ServerPsw: ", string_94, " - MaxClient: ", string_95, " - PrivClient: ", string_96, " - PrivClientPsw: ", string_97 };
            controll = this;
            Class75.smethod_84(string.Concat(strArray2), controll);
            strArray2 = new string[] { "Map: ", string_92, " - MapName: ", Class75.smethod_88(this, string_92), " - MapType: ", string_93, " - DSPL: ", string_100 };
            controll = this;
            Class75.smethod_84(string.Concat(strArray2), controll);
            Class75.smethod_84("===============================================================", this);
            this.method_0("all");
            Class75.smethod_140(this);
        }

        internal void method_41()
        {
            Class75.smethod_177(this);
            Class75.smethod_113(this);
            Class75.smethod_80(this);
            Class75.smethod_187(this);
            if (!System.IO.File.Exists(string_99))
            {
                if (bool_26)
                {
                    Class75.smethod_97(string_69, this);
                }
            }
            else
            {
                FileInfo info = new FileInfo(string_99);
                if (info.Length < int_27)
                {
                    System.IO.File.Delete(string_99);
                    if (bool_26)
                    {
                        Class75.smethod_97(string_69, this);
                    }
                }
            }
        }

        private void method_42(Entity entity_0, Parameter parameter_0)
        {
            Class75.smethod_207(parameter_0, entity_0, this);
        }

        private void method_43(Entity entity_0, Parameter parameter_0)
        {
            Class75.smethod_142(parameter_0, entity_0, this);
        }

        private void method_44(Entity entity_0)
        {
            Class75.smethod_160(entity_0, this);
        }

        internal void method_45(Entity entity_0)
        {
            this.method_18(entity_0);
            Class75.smethod_141(entity_0, this);
            this.method_21(entity_0);
            if ((string_93 == "sd") && (string_100 != "hide"))
            {
                Class75.smethod_59(this, entity_0);
            }
        }

        private void method_46(Entity entity_0)
        {
            Class75.smethod_69(entity_0, this);
        }

        private void method_47(Entity entity_0)
        {
            Class75.smethod_74(entity_0, this);
        }

        private void method_48(Entity entity_0)
        {
            Class75.smethod_100(entity_0, this);
        }

        private void method_49()
        {
            Class75.smethod_222(this);
        }

        private Entity method_5(Entity entity_0, string string_106)
        {
            try
            {
                if (list_2.Count != 0)
                {
                    int num = 0;
                    Entity entity2 = null;
                    foreach (Entity entity3 in list_2)
                    {
                        if (string_106.Length < 3)
                        {
                            if (this.getPlayerSlot(entity3) == string_106)
                            {
                                entity2 = entity3;
                                num++;
                            }
                        }
                        else if (((entity3.Name.ToLower().Contains(string_106) || (this.getPlayerID(entity3) == string_106)) || (this.getPlayerGuid(entity3) == string_106)) || (this.getPlayerXuid(entity3) == string_106))
                        {
                            entity2 = entity3;
                            num++;
                        }
                    }
                    if ((num == 1) && (entity2.EntRef != entity_0.EntRef))
                    {
                        return entity2;
                    }
                    if (num > 1)
                    {
                        Class75.smethod_73(this, entity_0, "^1Error - Multiple matches found!");
                        return null;
                    }
                    Class75.smethod_73(this, entity_0, "^1Error - No Player Found!");
                }
                return null;
            }
            catch (Exception exception)
            {
                LogErrori("TrovaPlayerAll", exception, "---");
                return null;
            }
        }

        private void method_50()
        {
            Class75.smethod_221(this);
        }

        internal void method_51()
        {
            int_14 = random_2.Next(0x3b);
            if (System.IO.File.Exists(string_88 + "nextmaps"))
            {
                string[] strArray = System.IO.File.ReadAllLines(string_88 + "nextmaps");
                if (strArray[0].Equals(string_92))
                {
                    string_91 = strArray[1];
                }
                else
                {
                    System.IO.File.Delete(string_88 + "nextmaps");
                    Class75.smethod_228(this, false, null);
                }
            }
            else
            {
                Class75.smethod_228(this, false, null);
            }
        }

        internal void method_52(Entity entity_0)
        {
            Action function = null;
            Class35 class2 = new Class35 {
                entity_0 = entity_0,
                serverControll_0 = this
            };
            if (bool_15)
            {
                //Class75.smethod_73(this, class2.entity_0, "^5Are you the player number ^1#" + int_29);
                Entity entity = class2.entity_0;
                string str = list_12[this.getPlayerLevel(class2.entity_0)].Replace("<playername>", this.getPlayerName(class2.entity_0)).Replace("<nameclan>", string_5);
                Class75.smethod_209(entity, this, str);
            }
            if (bool_34 && (this.getPlayerAccess(class2.entity_0) == 1))
            {
                if (function == null)
                {
                    function = new Action(class2.method_0);
                }
                base.AfterDelay(int_22, function);
                int_22 += 0xbb8;
            }
        }

        internal bool method_53()
        {
            if (list_3.Count > 0)
            {
                this.method_17();
                this.method_15();
                this.method_16();
            }
            return true;
        }

        internal bool method_54()
        {
            if (list_3.Count > 0)
            {
                int num = random_0.Next(15);
                int num2 = random_0.Next(1, 10);
                switch (num)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        if (!(this.GruppiOnline(num2).Contains(string_104) || !bool_34))
                        {
                            Class75.smethod_64(this, "^1" + DBNomeGruppi[num2] + " ^7OnLine: ^5" + this.GruppiOnline(num2));
                        }
                        goto Label_0142;
                }
                if ((num == 6) && bool_32)
                {
                    Class75.smethod_198(this);
                }
                else if ((num == 7) && bool_16)
                {
                    if (string_93.Contains("inf"))
                    {
                        if (bool_33)
                        {
                            Class75.smethod_64(this, "^5Use ^1!register ^5to activate your XlrStats");
                        }
                    }
                    else
                    {
                        Class75.smethod_64(this, "^5Use ^1!register ^5to activate your XlrStats");
                    }
                }
                else if ((num == 8) && bool_41)
                {
                    Class75.smethod_64(this, "^5Protect your account, use ^1!psw <password> <repeatpassword> ^5to register it");
                }
                else if ((num == 9) && bool_16)
                {
                    this.method_34(null);
                }
                else
                {
                    Class75.smethod_148(this);
                }
            }
        Label_0142:
            return true;
        }

        internal bool method_55(Entity entity_0)
        {
            if (entity_0.GetField<int>("searchbull") == 0)
            {
                return false;
            }
            if (entity_0.IsAlive)
            {
                Entity entity = null;
                foreach (Entity entity2 in list_3)
                {
                    if ((((entity2.IsAlive && (entity_0.EntRef != entity2.EntRef)) && ((entity2.GetField<string>("sessionstate") != "spectator") && (entity2.GetField<string>("sessionteam") != "spectator"))) && ((entity_0.GetField<string>("sessionteam") != entity2.GetField<string>("sessionteam")) || ((base.Call<string>("getdvar", new Parameter[] { "g_gametype" }) == "dm") || (base.Call<string>("getdvar", new Parameter[] { "g_gametype" }) == "oic")))) && (base.Call<int>(0x74, new Parameter[] { entity_0.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }), entity2.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }), 0, entity_0 }) == 1))
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
                if ((entity != null) && ((entity_0.Call<int>("attackbuttonpressed", new Parameter[0]) > 0) && (entity_0.Origin.DistanceTo(entity.Origin) < 70f)))
                {
                    Vector3 vector2 = entity.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" });
                    string currentWeapon = entity_0.CurrentWeapon;
                    vector2.X -= 5f;
                    vector2.Y -= 5f;
                    vector2.Z -= 10f;
                    base.Call("magicbullet", new Parameter[] { currentWeapon, vector2, entity.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }), entity_0 });
                }
            }
            return true;
        }

        internal void method_56()
        {
            Class75.smethod_153(null, this);
        }

        internal Entity method_6(string string_106)
        {
            try
            {
                if (list_2.Count != 0)
                {
                    int num = 0;
                    Entity entity2 = null;
                    foreach (Entity entity3 in list_2)
                    {
                        if (string_106.Length < 3)
                        {
                            if (this.getPlayerSlot(entity3) == string_106)
                            {
                                entity2 = entity3;
                                num++;
                            }
                        }
                        else if (((entity3.Name.ToLower().Contains(string_106) || (this.getPlayerID(entity3) == string_106)) || (this.getPlayerGuid(entity3) == string_106)) || (this.getPlayerXuid(entity3) == string_106))
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
                        return null;
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                LogErrori("TrovaPlayer", exception, "---");
                return null;
            }
        }

        internal void method_7(object sender, DownloadProgressChangedEventArgs e)
        {
            if (int_23 == e.ProgressPercentage)
            {
                int_23 += 5;
                Class75.smethod_84("Download database GPS... [" + e.ProgressPercentage + "%]", this);
                bool_52 = false;
            }
        }

        internal void method_8(object sender, AsyncCompletedEventArgs e)
        {
            Class75.smethod_84("Download database GPS completed!", this);
            bool_52 = true;
        }

        private void method_9(string string_106, int int_31)
        {
            if (System.IO.File.Exists(string_88 + string_57))
            {
                string[] strArray = System.IO.File.ReadAllLines(string_88 + string_57);
                bool flag = false;
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { char_1 });
                    for (int j = 0; j < 2; j++)
                    {
                        if (strArray2[j].ToLower().Contains(string_106.ToLower()))
                        {
                            goto Label_0085;
                        }
                    }
                    goto Label_0149;
                Label_0085:
                    flag = true;
                    using (StreamWriter writer = new StreamWriter(string_85 + string_54, true))
                    {
                        writer.WriteLine(string.Concat(new object[] { DateTime.Now, char_2.ToString(), int_31, char_1, strArray[i] }));
                        writer.Close();
                        Class75.smethod_64(this, string.Concat(new object[] { "^5Player ^1", strArray2[0], " ^5TempBanned for ^1", int_31, "min!" }));
                    }
                Label_0149:
                    if (flag)
                    {
                        break;
                    }
                }
            }
        }

        public override void OnExitLevel()
        {
            this.method_0("all");
            if (string_91 != null)
            {
                Class75.smethod_6(this, "map " + string_91, 0);
            }
        }

        public override void OnPlayerDamage(Entity player, Entity inflictor, Entity attacker, int damage, int dFlags, string mod, string weapon, Vector3 point, Vector3 dir, string hitLoc)
        {
            Action function = null;
            Class5 class2 = new Class5 {
                entity_0 = attacker
            };
            try
            {
                int num;
                if (!(bool_35 || (mod != "MOD_MELEE")))
                {
                    player.Health += damage;
                }
                if ((mod == "MOD_FALLING") && (int_5 > 120))
                {
                    player.Health += damage;
                }
                if (((((((bool_2 && (class2.entity_0 != null)) && ((class2.entity_0 != player) && (mod != "MOD_IMPACT"))) && (((mod != "MOD_SUICIDE") && (mod != "MOD_GRENADE_SPLASH")) && ((mod != "MOD_EXPLOSIVE") && (class2.entity_0.GetField<string>("sessionteam") == player.GetField<string>("sessionteam"))))) && ((string_93 != "infect") && (this.getPlayerLevel(class2.entity_0) < 3))) && !this.IsJoinUsers(player)) && ((string_93 == "sd") || !bool_38)) && (string_100 != "hide"))
                {
                    if (!list_5.Contains(class2.entity_0))
                    {
                        if (bool_19 && (this.getPlayerPause(class2.entity_0) == 0))
                        {
                            Class75.smethod_4(this, class2.entity_0);
                            Entity entity = class2.entity_0;
                            string str = "add";
                            string str2 = "No TeamKill - Wounded: ^1" + this.getPlayerName(player);
                            Class75.smethod_24(str, this, entity, null, str2);
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
                if ((((bool_29 && (class2.entity_0 != null)) && (class2.entity_0 != player)) && ((mod == "MOD_RIFLE_BULLET") || (mod == "MOD_PISTOL_BULLET"))) && (string_93 != "infect"))
                {
                    if (((string_93 != "dm") && (class2.entity_0.GetField<string>("sessionteam") == player.GetField<string>("sessionteam"))) || (player.HasField("DioInTerra") && (player.GetField<int>("DioInTerra") == 1)))
                    {
                        return;
                    }
                    for (num = 0; num < string_75.Length; num++)
                    {
                        if (weapon.Contains(string_75[num]))
                        {
                            return;
                        }
                    }
                    Class75.smethod_131(player, class2.entity_0, true, this);
                }
                if ((((((bool_30 && (class2.entity_0 != null)) && (class2.entity_0 != player)) && ((mod == "MOD_RIFLE_BULLET") || (mod == "MOD_PISTOL_BULLET"))) && (string_93 != "infect")) && ((string_93 == "dm") || (class2.entity_0.GetField<string>("sessionteam") != player.GetField<string>("sessionteam")))) && (!player.HasField("DioInTerra") || (player.GetField<int>("DioInTerra") != 1)))
                {
                    for (num = 0; num < string_75.Length; num++)
                    {
                        if (weapon.Contains(string_75[num]))
                        {
                            return;
                        }
                    }
                    Class75.smethod_131(player, class2.entity_0, false, this);
                }
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("dictionary."))
                {
                    LogErrori("OnPlayerDamage", exception, "---");
                }
            }
        }

        public override void OnPlayerKilled(Entity player, Entity inflictor, Entity attacker, int damage, string mod, string weapon, Vector3 dir, string hitLoc)
        {
            Action<Entity> function = null;
            Action<Entity> action2 = null;
            Action<Entity> action3 = null;
            Class6 class2 = new Class6 {
                entity_0 = player,
                entity_1 = attacker,
                serverControll_0 = this
            };
            try
            {
                if (((class2.entity_1 != null) && bool_16) && (class2.entity_1 != class2.entity_0))
                {
                    bool flag = true;
                    if (!((!string_93.Contains("inf") || bool_33) ? (string_100 != "hide") : false))
                    {
                        flag = false;
                    }
                    if (flag)
                    {
                        if (mod == "MOD_HEAD_SHOT")
                        {
                            if (function == null)
                            {
                                function = new Action<Entity>(class2.method_0);
                            }
                            class2.entity_0.AfterDelay(100, function);
                        }
                        else if (weapon.Contains("nuke") && (this.getPlayerMoab(class2.entity_1) == 0))
                        {
                            if (action2 == null)
                            {
                                action2 = new Action<Entity>(class2.method_1);
                            }
                            class2.entity_0.AfterDelay(100, action2);
                        }
                        else
                        {
                            if (action3 == null)
                            {
                                action3 = new Action<Entity>(class2.method_2);
                            }
                            class2.entity_0.AfterDelay(100, action3);
                        }
                    }
                }
                if (bool_14)
                {
                    if (mod == "MOD_FALLING")
                    {
                        Class75.smethod_64(this, string_34.Replace("<playerdead>", this.getPlayerName(class2.entity_0)));
                    }
                    else if ((mod == "MOD_MELEE") && (class2.entity_1.GetField<string>("sessionteam") != class2.entity_0.GetField<string>("sessionteam")))
                    {
                        Class75.smethod_64(this, string_35.Replace("<playerdead>", this.getPlayerName(class2.entity_0)).Replace("<playerattack>", this.getPlayerName(class2.entity_1)));
                    }
                    else if ((mod == "MOD_HEAD_SHOT") && (class2.entity_1.GetField<string>("sessionteam") != class2.entity_0.GetField<string>("sessionteam")))
                    {
                        Class75.smethod_64(this, string_36.Replace("<playerdead>", this.getPlayerName(class2.entity_0)).Replace("<playerattack>", this.getPlayerName(class2.entity_1)));
                    }
                    else if (weapon.Contains("nuke"))
                    {
                        Action<Entity> action4 = null;
                        Class7 class3 = new Class7 {
                            class6_0 = class2
                        };
                        if ((class2.entity_1.GetField<string>("sessionteam") != class2.entity_0.GetField<string>("sessionteam")) || (string_93 == "dm"))
                        {
                            class3.string_0 = string_39;
                        }
                        else
                        {
                            class3.string_0 = string_40;
                        }
                        if (this.getPlayerMoab(class2.entity_1) == 0)
                        {
                            Class75.smethod_146(class2.entity_1, 1, this);
                            if (action4 == null)
                            {
                                action4 = new Action<Entity>(class3.method_0);
                            }
                            class2.entity_1.AfterDelay(0xbb8, action4);
                        }
                    }
                    else if (mod == "MOD_EXPLOSIVE")
                    {
                        Class75.smethod_64(this, string_37.Replace("<playerdead>", this.getPlayerName(class2.entity_0)));
                    }
                }
                if (bool_3 && !list_5.Contains(class2.entity_1))
                {
                    if (!class2.entity_1.HasField("headshots"))
                    {
                        class2.entity_1.SetField("headshots", 0);
                        class2.entity_1.SetField("neckshots", 0);
                        class2.entity_1.SetField("torso_upper", 0);
                        class2.entity_1.SetField("torso_lower", 0);
                        class2.entity_1.SetField("right_arm_upper", 0);
                        class2.entity_1.SetField("right_arm_lower", 0);
                        class2.entity_1.SetField("left_arm_upper", 0);
                        class2.entity_1.SetField("left_arm_lower", 0);
                        class2.entity_1.SetField("left_leg_upper", 0);
                        class2.entity_1.SetField("left_leg_lower", 0);
                        class2.entity_1.SetField("right_leg_upper", 0);
                        class2.entity_1.SetField("right_leg_lower", 0);
                    }
                    if (mod == "MOD_HEAD_SHOT")
                    {
                        class2.entity_1.SetField("headshots", class2.entity_1.GetField<int>("headshots") + 1);
                        if (class2.entity_1.GetField<int>("headshots") >= int_9)
                        {
                            Class75.smethod_150(class2.entity_1, this);
                        }
                    }
                    else
                    {
                        class2.entity_1.SetField("headshots", 0);
                    }
                    if (hitLoc == "neck")
                    {
                        class2.entity_1.SetField("neckshots", class2.entity_1.GetField<int>("neckshots") + 1);
                        if (class2.entity_1.GetField<int>("neckshots") >= int_10)
                        {
                            Class75.smethod_150(class2.entity_1, this);
                        }
                    }
                    else
                    {
                        class2.entity_1.SetField("neckshots", 0);
                    }
                    if (hitLoc == "torso_upper")
                    {
                        class2.entity_1.SetField("torso_upper", class2.entity_1.GetField<int>("torso_upper") + 1);
                        if (class2.entity_1.GetField<int>("torso_upper") >= int_10)
                        {
                            Class75.smethod_150(class2.entity_1, this);
                        }
                    }
                    else
                    {
                        class2.entity_1.SetField("torso_upper", 0);
                    }
                    if (hitLoc == "torso_lower")
                    {
                        class2.entity_1.SetField("torso_lower", class2.entity_1.GetField<int>("torso_lower") + 1);
                        if (class2.entity_1.GetField<int>("torso_lower") >= int_10)
                        {
                            Class75.smethod_150(class2.entity_1, this);
                        }
                    }
                    else
                    {
                        class2.entity_1.SetField("torso_lower", 0);
                    }
                    if (hitLoc == "right_arm_upper")
                    {
                        class2.entity_1.SetField("right_arm_upper", class2.entity_1.GetField<int>("right_arm_upper") + 1);
                        if (class2.entity_1.GetField<int>("right_arm_upper") >= int_10)
                        {
                            Class75.smethod_150(class2.entity_1, this);
                        }
                    }
                    else
                    {
                        class2.entity_1.SetField("right_arm_upper", 0);
                    }
                    if (hitLoc == "right_arm_lower")
                    {
                        class2.entity_1.SetField("right_arm_lower", class2.entity_1.GetField<int>("right_arm_lower") + 1);
                        if (class2.entity_1.GetField<int>("right_arm_lower") >= int_10)
                        {
                            Class75.smethod_150(class2.entity_1, this);
                        }
                    }
                    else
                    {
                        class2.entity_1.SetField("right_arm_lower", 0);
                    }
                    if (hitLoc == "left_arm_upper")
                    {
                        class2.entity_1.SetField("left_arm_upper", class2.entity_1.GetField<int>("left_arm_upper") + 1);
                        if (class2.entity_1.GetField<int>("left_arm_upper") >= int_10)
                        {
                            Class75.smethod_150(class2.entity_1, this);
                        }
                    }
                    else
                    {
                        class2.entity_1.SetField("left_arm_upper", 0);
                    }
                    if (hitLoc == "left_arm_lower")
                    {
                        class2.entity_1.SetField("left_arm_lower", class2.entity_1.GetField<int>("left_arm_lower") + 1);
                        if (class2.entity_1.GetField<int>("left_arm_lower") >= int_10)
                        {
                            Class75.smethod_150(class2.entity_1, this);
                        }
                    }
                    else
                    {
                        class2.entity_1.SetField("left_arm_lower", 0);
                    }
                    if (hitLoc == "right_leg_upper")
                    {
                        class2.entity_1.SetField("right_leg_upper", class2.entity_1.GetField<int>("right_leg_upper") + 1);
                        if (class2.entity_1.GetField<int>("right_leg_upper") >= int_10)
                        {
                            Class75.smethod_150(class2.entity_1, this);
                        }
                    }
                    else
                    {
                        class2.entity_1.SetField("right_leg_upper", 0);
                    }
                    if (hitLoc == "right_leg_lower")
                    {
                        class2.entity_1.SetField("right_leg_lower", class2.entity_1.GetField<int>("right_leg_lower") + 1);
                        if (class2.entity_1.GetField<int>("right_leg_lower") >= int_10)
                        {
                            Class75.smethod_150(class2.entity_1, this);
                        }
                    }
                    else
                    {
                        class2.entity_1.SetField("right_leg_lower", 0);
                    }
                    if (hitLoc == "left_leg_upper")
                    {
                        class2.entity_1.SetField("left_leg_upper", class2.entity_1.GetField<int>("left_leg_upper") + 1);
                        if (class2.entity_1.GetField<int>("left_leg_upper") >= int_10)
                        {
                            Class75.smethod_150(class2.entity_1, this);
                        }
                    }
                    else
                    {
                        class2.entity_1.SetField("left_leg_upper", 0);
                    }
                    if (hitLoc == "left_leg_lower")
                    {
                        class2.entity_1.SetField("left_leg_lower", class2.entity_1.GetField<int>("left_leg_lower") + 1);
                        if (class2.entity_1.GetField<int>("left_leg_lower") >= int_10)
                        {
                            Class75.smethod_150(class2.entity_1, this);
                        }
                    }
                    else
                    {
                        class2.entity_1.SetField("left_leg_lower", 0);
                    }
                }
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("dictionary."))
                {
                    LogErrori("OnPlayerKilled", exception, "---");
                }
            }
        }

        public override BaseScript.EventEat OnSay3(Entity player, BaseScript.ChatType type, string name, ref string message)
        {
            try
            {
                int num;
                string[] strArray = message.ToLower().Trim().Split(new char[] { char_0 });
                message.Trim().Split(new char[] { char_0 });
                if (message.StartsWith("/") || message.StartsWith("@"))
                {
                    Class75.smethod_49(message, this, player);
                    return BaseScript.EventEat.EatNone;
                }
                if (message.StartsWith("!"))
                {
                    Class75.smethod_49(message, this, player);
                    if (!Class75.smethod_161(strArray[0], this, player))
                    {
                        bool flag = false;
                        for (num = 0; num < DBComandilvl.Count; num++)
                        {
                            string[] strArray2 = DBComandilvl[num].Split(new char[] { char_1 });
                            for (int i = 0; i < strArray2.Length; i++)
                            {
                                if (strArray[0].Equals(strArray2[i]))
                                {
                                    goto Label_00F8;
                                }
                            }
                            continue;
                        Label_00F8:
                            flag = true;
                        }
                        if (flag)
                        {
                            Class75.smethod_73(this, player, "^1Command Permission Denied!!!");
                        }
                        else
                        {
                            Class75.smethod_73(this, player, "^1Function not found");
                        }
                        return BaseScript.EventEat.EatGame;
                    }
                    if (this.method_29(player, strArray[0]))
                    {
                        Class75.smethod_73(this, player, "^5Higher player in this game, some commands can not be activated!");
                        return BaseScript.EventEat.EatGame;
                    }
                    if ((strArray[0] == ("!" + string_16)) && this.IsJoinUsers(player))
                    {
                        list_10.Remove(player);
                        Class75.smethod_132(player, this);
                        player.SetField("Mute", 0);
                        if (bool_51)
                        {
                            player.Call("freezeControls", new Parameter[] { 0 });
                        }
                        player.Call("show", new Parameter[] { 1 });
                        Class75.smethod_98(this, player);
                        Class75.smethod_73(this, player, "^5CORRECT PASSWORD!!!");
                        Class75.smethod_73(this, player, "^5ENJOY ^7- ^1By MH11!!!");
                        return BaseScript.EventEat.EatGame;
                    }
                    if (strArray[0] == "!psw")
                    {
                        if (!bool_41)
                        {
                            Class75.smethod_73(this, player, "^1User password function disabled!");
                            return BaseScript.EventEat.EatGame;
                        }
                        if (strArray.Length == 2)
                        {
                            if (this.getPlayerPswOk(player) == 0)
                            {
                                if (this.getPlayerPsw(player) == 1)
                                {
                                    Class75.smethod_224(player, this, strArray[1]);
                                }
                                else
                                {
                                    Class75.smethod_73(this, player, "^5Username not registered!");
                                    Class75.smethod_73(this, player, "^5Use ^1!psw password repeatpassword ^5to register username.");
                                }
                            }
                            else
                            {
                                Class75.smethod_73(this, player, "^5User is already authenticated!");
                            }
                        }
                        else if (strArray.Length == 3)
                        {
                            if (this.getPlayerPsw(player) == 0)
                            {
                                if (strArray[1].Equals(strArray[2]))
                                {
                                    Class75.smethod_36(player, this, strArray[1]);
                                }
                                else
                                {
                                    Class75.smethod_73(this, player, "^1Passwords do not match!");
                                }
                            }
                            else
                            {
                                Class75.smethod_73(this, player, "^5Username already registered!");
                            }
                        }
                        return BaseScript.EventEat.EatGame;
                    }
                    if (((this.getPlayerPsw(player) == 1) && (this.getPlayerPswOk(player) == 0)) && bool_41)
                    {
                        Class75.smethod_73(this, player, "^1You can not give any commands without authentication!");
                    }
                    else
                    {
                        this.method_2(player, message);
                    }
                    return BaseScript.EventEat.EatGame;
                }
                if (message.Contains("!psw") && (this.getPlayerPsw(player) == 1))
                {
                    Class75.smethod_73(this, player, "^1DO NOT WRITE YOUR PASSWORD IN PUBLIC CHAT!!!");
                    return BaseScript.EventEat.EatGame;
                }
                if (!message.Contains(string_16) || !bool_8)
                {
                    goto Label_03C7;
                }
                for (num = 0; num < strArray.Length; num++)
                {
                    if (strArray[num].Equals(string_16))
                    {
                        goto Label_03B4;
                    }
                }
                goto Label_049E;
            Label_03B4:
                Class75.smethod_73(this, player, "^1DO NOT WRITE SERVER PASSWORD IN PUBLIC CHAT!!!");
                return BaseScript.EventEat.EatGame;
            Label_03C7:
                if ((!message.Contains(string_3) || (this.getPlayerLevel(player) <= 0)) || (this.getPlayerAccess(player) != 0))
                {
                    goto Label_0431;
                }
                for (num = 0; num < strArray.Length; num++)
                {
                    if (strArray[num].Equals(string_3))
                    {
                        goto Label_041E;
                    }
                }
                goto Label_049E;
            Label_041E:
                Class75.smethod_73(this, player, "^1DO NOT WRITE YOUR PASSWORD IN PUBLIC CHAT!!!");
                return BaseScript.EventEat.EatGame;
            Label_0431:
                if (((player.GetField<int>("Mute") == 1) || !bool_50) && (((this.getPlayerLevel(player) < 2) && (type == BaseScript.ChatType.All)) && (this.getPlayerAccess(player) != 1)))
                {
                    if (!bool_50)
                    {
                        Class75.smethod_158(this, player, "^1Chat Disabled");
                    }
                    else
                    {
                        Class75.smethod_158(this, player, "^1" + this.getPlayerName(player) + " ^5you have been mutated!");
                    }
                    return BaseScript.EventEat.EatGame;
                }
            Label_049E:
                if (bool_21 && ((this.getPlayerLevel(player) < 2) || (this.getPlayerAccess(player) != 1)))
                {
                    using (List<string>.Enumerator enumerator = list_1.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            string current = enumerator.Current;
                            for (int j = 0; j < strArray.Length; j++)
                            {
                                if (strArray[j].Equals(current.ToLower()))
                                {
                                    goto Label_050D;
                                }
                            }
                        }
                        goto Label_052E;
                    Label_050D:
                        Class75.smethod_73(this, player, "^1You can not use profanity!!!");
                        return BaseScript.EventEat.EatGame;
                    }
                }
            Label_052E:
                if ((this.getPlayerPsw(player) == 1) && (this.getPlayerPswOk(player) == 0))
                {
                    Class75.smethod_73(this, player, "^1You can not write anything before authentication!");
                    return BaseScript.EventEat.EatGame;
                }
                Class75.smethod_172(this, player, type, message);
                if ((bool_6 && (this.getPlayerAccess(player) != 0)) && (type == BaseScript.ChatType.All))
                {
                    Utilities.RawSayAll(DBTaglvl[this.getPlayerLevel(player)] + DBColorlvl[this.getPlayerLevel(player)] + this.getPlayerName(player) + "^7: " + message);
                    return BaseScript.EventEat.EatGame;
                }
                return BaseScript.EventEat.EatNone;
            }
            catch (Exception exception)
            {
                if (!exception.Message.Contains("dictionary."))
                {
                    Class75.smethod_73(this, player, "^1Syntax Error Commands!!!");
                }
                if ((message.StartsWith("!") || message.StartsWith("/")) || message.StartsWith("@"))
                {
                    return BaseScript.EventEat.EatGame;
                }
                return BaseScript.EventEat.EatNone;
            }
        }

        public static string sha512(string text)
        {
            string str = "";
            foreach (byte num2 in SHA512.Create().ComputeHash(Encoding.ASCII.GetBytes(text)))
            {
                str = str + num2.ToString("x2");
            }
            return str;
        }

        private static void smethod_0(Entity entity_0, Parameter parameter_0)
        {
            entity_0.Call("giveMaxAmmo", new Parameter[] { entity_0.CurrentWeapon });
        }

        private static bool smethod_1(Entity entity_0)
        {
            entity_0.Call("setmovespeedscale", new Parameter[] { new Parameter(1.3f) });
            entity_0.Call("giveMaxAmmo", new Parameter[] { entity_0.CurrentWeapon });
            return true;
        }

        internal static void smethod_2()
        {
            StreamWriter writer;
            int num;
            if (System.IO.File.Exists(string_85 + string_65))
            {
                string_82 = System.IO.File.ReadAllLines(string_85 + string_65);
            }
            else
            {
                using (writer = new StreamWriter(string_85 + string_65, true))
                {
                    for (num = 0; num < string_82.Length; num++)
                    {
                        writer.WriteLine(string_82[num].ToLower());
                    }
                    writer.Close();
                }
            }
            if (System.IO.File.Exists(string_85 + string_66))
            {
                string_83 = System.IO.File.ReadAllLines(string_85 + string_66);
            }
            else
            {
                using (writer = new StreamWriter(string_85 + string_66, true))
                {
                    for (num = 0; num < string_83.Length; num++)
                    {
                        writer.WriteLine(string_83[num].ToLower());
                    }
                    writer.Close();
                }
            }
        }

        internal static void smethod_3()
        {
            foreach (Entity entity in list_3)
            {
                entity.Call("setweaponammoclip", new Parameter[] { entity.Call<string>("getcurrentprimaryweapon", new Parameter[0]), new Parameter(entity.GetWeaponAmmoClip(entity.Call<string>("getcurrentprimaryweapon", new Parameter[0])) * 3) });
                entity.Call("setweaponammostock", new Parameter[] { entity.Call<string>("getcurrentprimaryweapon", new Parameter[0]), new Parameter(entity.GetWeaponAmmoStock(entity.Call<string>("getcurrentprimaryweapon", new Parameter[0])) * 2) });
                entity.Call("setweaponammoclip", new Parameter[] { "flash_grenade_mp", 1 });
                entity.SetPerk("specialty_reducedsway", true, false);
            }
        }

        internal static bool smethod_4()
        {
            hudElem_5.SetText(string_17);
            hudElem_5.SetPoint("CENTER", "BOTTOM", 0x44c, -10);
            hudElem_5.Call("moveovertime", new Parameter[] { 0x19 });
            hudElem_5.X = -700f;
            return true;
        }

        private static void smethod_5(Entity entity_0)
        {
            entity_0.SetClientDvar("compassobjectivewidth", "14");
            entity_0.SetClientDvar("compassobjectiveheight", "14");
            entity_0.SetClientDvar("cg_scoreboardPingText", "1");
            entity_0.SetClientDvar("cg_scoreboarditemheight", "14");
            entity_0.SetClientDvar("cg_scoreboardBannerHeight", "20");
            entity_0.SetClientDvar("cg_scoreboardHeight", "400");
            entity_0.SetClientDvar("cg_scoreboardWidth", "400");
            entity_0.SetClientDvar("cg_scoreboardRankFontScale", "0.23");
            entity_0.SetClientDvar("g_ScoresColor_Axis", "2 0 0");
            entity_0.SetClientDvar("g_ScoresColor_Allies", "0.498 2 0");
            entity_0.SetClientDvar("g_ScoresColor_Spectator", "2 0.498 0");
            entity_0.SetClientDvar("g_ScoresColor_Free", "0.66666 0.2028 1.09018");
            entity_0.SetClientDvar("cg_scoreBoardMyColor", "0 0 0 1");
        }

        private static void smethod_6(Entity entity_0)
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

        private static void smethod_7(Entity entity_0)
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

        internal static bool smethod_8(Entity entity_0)
        {
            if ((string_93 == "sd") && bool_45)
            {
                if ((!bool_23 && (string_100 != "esl")) && (string_100 != "sniper"))
                {
                    entity_0.SetClientDvar("g_hardcore", "1");
                }
                entity_0.Call("clearperks", new Parameter[0]);
            }
            entity_0.SetClientDvar("r_specularMap", "1");
            entity_0.SetClientDvar("snaps", "30");
            entity_0.SetClientDvar("fx_Draw", "1");
            entity_0.SetClientDvar("r_drawdecals", "1");
            entity_0.SetClientDvar("g_compassshowenemies", "0");
            entity_0.SetClientDvar("compassPortableRadarRadius", "850");
            entity_0.SetClientDvar("compassPortableRadarSweepTime", "2000");
            if ((string_100 != "hide") && bool_40)
            {
                entity_0.SetClientDvar("cg_thirdperson", "0");
                entity_0.SetClientDvar("camera_thirdperson", "0");
            }
            return true;
        }

        public double TPassato(DateTime temp)
        {
            TimeSpan span = (TimeSpan) (DateTime.Now - temp);
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
            if (((mappa == "par") || (mappa == "parish")) || (mappa == "mp_nola"))
            {
                return "mp_nola";
            }
            Class75.smethod_73(this, player, "^1Enter the correct name of the map or the first 3 letters!");
            return "null";
        }

        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            string x = GetMd5Hash(md5Hash, input);
            StringComparer ordinalIgnoreCase = StringComparer.OrdinalIgnoreCase;
            return (0 == ordinalIgnoreCase.Compare(x, hash));
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

        private sealed class Class0
        {
            public Entity entity_0;
            public ServerControll serverControll_0;

            public void method_0(Entity entity_1)
            {
                this.serverControll_0.Call("magicbullet", new Parameter[] { this.entity_0.CurrentWeapon, this.entity_0.Call<Vector3>("getTagOrigin", new Parameter[] { "tag_weapon_left" }), entity_1.Call<Vector3>("getTagOrigin", new Parameter[] { "tag_weapon_left" }), this.entity_0 });
            }

            public void method_1(Entity entity_1)
            {
                this.serverControll_0.Call("magicbullet", new Parameter[] { this.entity_0.CurrentWeapon, this.entity_0.Call<Vector3>("getTagOrigin", new Parameter[] { "tag_weapon_left" }), entity_1.Call<Vector3>("getTagOrigin", new Parameter[] { "tag_weapon_left" }), this.entity_0 });
            }
        }

        private sealed class Class1
        {
            public string string_0;

            public void method_0(Entity entity_0)
            {
                entity_0.Notify("menuresponse", new Parameter[] { "changeclass", this.string_0 });
            }
        }

        internal sealed class Class11
        {
            public ServerControll.Class9 class9_0;
            public string string_0;

            public void method_0(Entity entity_0)
            {
                this.class9_0.serverControll_0.method_1(entity_0, this.string_0);
            }
        }

        private sealed class Class12
        {
            public Entity entity_0;
            public ServerControll serverControll_0;

            public void method_0()
            {
                ServerControll controll = this.serverControll_0;
                Class75.smethod_81(this.entity_0, controll);
            }
        }

        internal sealed class Class13
        {
            public Entity entity_0;
            public ServerControll serverControll_0;

            public void method_0()
            {
                Class75.smethod_73(this.serverControll_0, this.entity_0, "^5Password Active!");
                Class75.smethod_73(this.serverControll_0, this.entity_0, "^5You are ^1Staff^5 you don't have to enter it!");
            }

            public void method_1()
            {
                Class75.smethod_73(this.serverControll_0, this.entity_0, "^5Password Active!");
                Class75.smethod_73(this.serverControll_0, this.entity_0, "^5You have already entered the password!");
            }
        }

        internal sealed class Class14
        {
            public Entity entity_0;
            public ServerControll serverControll_0;

            public void method_0(Entity entity_1)
            {
                if ((this.serverControll_0.getPlayerLevel(entity_1) > 1) && ServerControll.bool_46)
                {
                    Class75.smethod_200(this.serverControll_0, entity_1);
                }
                Class75.smethod_40(this.serverControll_0, entity_1);
                Class75.smethod_71(entity_1, this.serverControll_0);
                if (!(ServerControll.bool_27 && (ServerControll.string_100 != "hide")))
                {
                    ServerControll controll = this.serverControll_0;
                    Entity entity = this.entity_0;
                    Class75.smethod_185(true, controll, 0, entity);
                }
            }
        }

        internal sealed class Class15
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        internal sealed class Class16
        {
            public ServerControll.Class15 class15_0;
            public int int_0;

            public void method_0()
            {
                Class75.smethod_73(this.class15_0.serverControll_0, this.class15_0.entity_0, "^5" + ServerControll.DBComandilvl[this.int_0]);
            }
        }

        internal sealed class Class17
        {
            public ServerControll.Class15 class15_0;
            public string string_0;

            public void method_0(Entity entity_0)
            {
                Class75.smethod_73(this.class15_0.serverControll_0, entity_0, "^5" + this.string_0);
            }
        }

        internal sealed class Class18
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        internal sealed class Class19
        {
            public ServerControll.Class18 class18_0;
            public int int_0;
            public int int_1;
            public int int_2;

            public bool method_0(Entity entity_0)
            {
                this.int_2 = this.int_0 - this.int_1;
                Class75.smethod_158(this.class18_0.serverControll_0, this.class18_0.entity_0, "^5Use ^1!psw password ^5to login, kick in ^1" + this.int_2 + " seconds");
                if (this.int_2.ToString().EndsWith("0"))
                {
                    Class75.smethod_64(this.class18_0.serverControll_0, "^5Player ^1" + this.class18_0.serverControll_0.getPlayerName(this.class18_0.entity_0) + " ^5awaiting authentication...");
                }
                if (this.int_2 < 1)
                {
                    if (this.class18_0.serverControll_0.getPlayerPswOk(this.class18_0.entity_0) == 1)
                    {
                        return false;
                    }
                    Class75.smethod_20(this.class18_0.serverControll_0, "Server", "k", this.class18_0.entity_0, "^1Password username not entered!");
                }
                else
                {
                    if (this.class18_0.serverControll_0.getPlayerPswOk(this.class18_0.entity_0) == 1)
                    {
                        return false;
                    }
                    if (this.int_2.ToString().EndsWith("0") || this.int_2.ToString().EndsWith("5"))
                    {
                        Class75.smethod_73(this.class18_0.serverControll_0, this.class18_0.entity_0, "^1" + this.class18_0.serverControll_0.getPlayerName(this.class18_0.entity_0) + " ^5- The user name is protected, enter the password!");
                    }
                    this.class18_0.entity_0.Call("freezeControls", new Parameter[] { 1 });
                    this.class18_0.entity_0.Call("hide", new Parameter[] { 1 });
                    this.int_1++;
                }
                return true;
            }
        }

        internal sealed class Class2
        {
            public int int_0;
            public ServerControll serverControll_0;

            public void method_0()
            {
                Class75.smethod_176(this.serverControll_0, this.int_0);
            }
        }

        internal sealed class Class20
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
                        Class75.smethod_158(this.serverControll_0, this.entity_1, "^5You must be alive to use the graphical menu!");
                    }
                    else
                    {
                        this.int_0 = 0;
                        if ((this.entity_1.GetField<int>("MenuSC") == 0) && (this.entity_1.GetField<int>("SubMenuSC") == 0))
                        {
                            Class75.smethod_90(this.serverControll_0, this.entity_1);
                            ServerControll controll = this.serverControll_0;
                            Class75.smethod_31(this.entity_1, controll, 0);
                            this.entity_1.SetField("MenuSC", 1);
                            Class75.smethod_220(entity_2, this.serverControll_0);
                        }
                        else if ((this.entity_1.GetField<int>("MenuSC") == 0) && (this.entity_1.GetField<int>("SubMenuSC") == 1))
                        {
                            this.entity_1.SetField("SubMenuSC", 0);
                            Class75.smethod_120(entity_2, this.serverControll_0);
                        }
                        else
                        {
                            if (this.entity_1.GetField<int>("MenuSC") == 1)
                            {
                                this.entity_1.SetField("MenuSC", 0);
                                Class75.smethod_60(this.serverControll_0, entity_2);
                            }
                            if (this.entity_1.GetField<int>("SubMenuSC") == 1)
                            {
                                this.entity_1.SetField("SubMenuSC", 0);
                                Class75.smethod_120(entity_2, this.serverControll_0);
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
                            this.int_0 = ServerControll.list_3.Count;
                        }
                        this.int_0--;
                        ServerControll controll = this.serverControll_0;
                        int num = this.int_0;
                        Class75.smethod_31(entity_2, controll, num);
                    }
                    else if (this.entity_1.GetField<int>("SubMenuSC") == 1)
                    {
                        if (this.int_0 < 1)
                        {
                            this.int_0 = this.serverControll_0.comandiplayer.Length;
                        }
                        this.int_0--;
                        ServerControll controll2 = this.serverControll_0;
                        int num2 = this.int_0;
                        Class75.smethod_41(entity_2, controll2, num2);
                    }
                }
            }

            public void method_2(Entity entity_2)
            {
                if (this.serverControll_0.getPlayerAccess(entity_2) == 1)
                {
                    if (this.entity_1.GetField<int>("MenuSC") == 1)
                    {
                        if (this.int_0 == (ServerControll.list_3.Count - 1))
                        {
                            this.int_0 = -1;
                        }
                        this.int_0++;
                        ServerControll controll = this.serverControll_0;
                        int num = this.int_0;
                        Class75.smethod_31(entity_2, controll, num);
                    }
                    else if (this.entity_1.GetField<int>("SubMenuSC") == 1)
                    {
                        if (this.int_0 == (this.serverControll_0.comandiplayer.Length - 1))
                        {
                            this.int_0 = -1;
                        }
                        this.int_0++;
                        ServerControll controll2 = this.serverControll_0;
                        int num2 = this.int_0;
                        Class75.smethod_41(entity_2, controll2, num2);
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
                        Class75.smethod_60(this.serverControll_0, entity_2);
                        Entity[] entityArray = ServerControll.list_3.ToArray();
                        this.entity_0 = entityArray[this.int_0];
                        this.int_0 = 0;
                        ServerControll controll = this.serverControll_0;
                        Entity entity = this.entity_1;
                        string str = this.serverControll_0.getPlayerName(this.entity_0);
                        Class75.smethod_9(entity, str, controll);
                        ServerControll controll2 = this.serverControll_0;
                        Class75.smethod_41(this.entity_1, controll2, 0);
                        this.entity_1.SetField("SubMenuSC", 1);
                        Class75.smethod_204(entity_2, this.serverControll_0);
                    }
                    else if (this.entity_1.GetField<int>("SubMenuSC") == 1)
                    {
                        this.entity_1.SetField("SubMenuSC", 0);
                        Class75.smethod_120(entity_2, this.serverControll_0);
                        ServerControll controll3 = this.serverControll_0;
                        Entity entity3 = this.entity_0;
                        string str2 = this.serverControll_0.comandiplayer[this.int_0].ToLower();
                        Class75.smethod_18(entity_2, entity3, str2, controll3);
                    }
                }
            }
        }

        internal sealed class Class21
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        internal sealed class Class22
        {
            public ServerControll.Class21 class21_0;
            public Entity[] entity_0;
            public int int_0;

            public bool method_0()
            {
                if (this.int_0 < this.entity_0.Length)
                {
                    Class75.smethod_73(this.class21_0.serverControll_0, this.class21_0.entity_0, "^7(^5" + this.class21_0.serverControll_0.getPlayerSlot(this.entity_0[this.int_0]) + "^7)^5 " + this.class21_0.serverControll_0.getPlayerName(this.entity_0[this.int_0]));
                    this.int_0++;
                    return true;
                }
                return false;
            }
        }

        internal sealed class Class23
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        internal sealed class Class24
        {
            public ServerControll.Class23 class23_0;
            public Entity[] entity_0;
            public int int_0;

            public bool method_0()
            {
                if (this.int_0 < this.entity_0.Length)
                {
                    Class75.smethod_73(this.class23_0.serverControll_0, this.class23_0.entity_0, "^7(^5" + this.class23_0.serverControll_0.getPlayerSlot(this.entity_0[this.int_0]) + "^7)^5 " + this.class23_0.serverControll_0.getPlayerName(this.entity_0[this.int_0]) + " ^7- ID:^5 " + this.class23_0.serverControll_0.getPlayerID(this.entity_0[this.int_0]));
                    this.int_0++;
                    return true;
                }
                return false;
            }
        }

        internal sealed class Class25
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
                    Class75.smethod_20(this.serverControll_0, "Server", "k", entity_1, "Password is not entered!!!");
                }
                else
                {
                    field--;
                    entity_1.SetField("TimePass", field);
                    Class75.smethod_85(entity_1, this.serverControll_0);
                    entity_1.SetField("Mute", 1);
                    entity_1.Call("freezeControls", new Parameter[] { 1 });
                    entity_1.Call("hide", new Parameter[] { 1 });
                    string str = this.entity_0.GetField<string>("sessionteam");
                    if ((((str != "spectator") && this.entity_0.IsAlive) && (ServerControll.string_93 == "sd")) && (this.serverControll_0.Call<int>("getteamplayersalive", new Parameter[] { str }) < 2))
                    {
                        this.entity_0.SetField("team", "spectator");
                        this.entity_0.SetField("sessionteam", "spectator");
                        this.entity_0.Notify("menuresponse", new Parameter[] { "team_marinesopfor", "spectator" });
                    }
                }
                return true;
            }
        }

        internal sealed class Class26
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        internal sealed class Class27
        {
            public ServerControll.Class26 class26_0;
            public int int_0;
            public string[] string_0;
            public string[] string_1;

            public bool method_0()
            {
                if ((this.int_0 < this.string_0.Length) && (this.string_0[this.int_0] != ""))
                {
                    this.string_1 = this.string_0[this.int_0].Split(new char[] { ServerControll.char_1 });
                    Class75.smethod_73(this.class26_0.serverControll_0, this.class26_0.entity_0, "^5" + this.string_1[0] + "^7[^1" + this.string_1[1] + "^7]");
                    this.int_0++;
                    return true;
                }
                return false;
            }
        }

        internal sealed class Class28
        {
            public Entity entity_0;
            public ServerControll serverControll_0;

            public void method_0(Entity entity_1)
            {
                Class75.smethod_73(this.serverControll_0, entity_1, "^5Nick: ^1" + this.serverControll_0.getPlayerName(this.entity_0));
            }

            public void method_1(Entity entity_1)
            {
                Class75.smethod_73(this.serverControll_0, entity_1, "^5Group Level: ^1" + ServerControll.DBNomeGruppi[this.serverControll_0.getPlayerLevel(this.entity_0)]);
            }

            public void method_10(Entity entity_1)
            {
                Class75.smethod_73(this.serverControll_0, entity_1, "^5GPS: ^7Connect from [^1" + this.serverControll_0.lookupIP(this.serverControll_0.GetIPAddress(this.entity_0.EntRef).ToString()) + "^7]");
            }

            public void method_2(Entity entity_1)
            {
                Class75.smethod_73(this.serverControll_0, entity_1, "^5ClanTag: ^1" + this.serverControll_0.getPlayerTag(this.entity_0));
            }

            public void method_3(Entity entity_1)
            {
                Class75.smethod_73(this.serverControll_0, entity_1, "^5ID: ^1" + this.serverControll_0.getPlayerID(this.entity_0));
            }

            public void method_4(Entity entity_1)
            {
                Class75.smethod_73(this.serverControll_0, entity_1, "^5GUID: ^1" + this.serverControll_0.getPlayerGuid(this.entity_0));
            }

            public void method_5(Entity entity_1)
            {
                Class75.smethod_73(this.serverControll_0, entity_1, "^5HWID: ^1" + this.serverControll_0.getPlayerHWID(this.entity_0));
            }

            public void method_6(Entity entity_1)
            {
                Class75.smethod_73(this.serverControll_0, entity_1, "^5XUID: ^1" + this.serverControll_0.getPlayerXuid(this.entity_0));
            }

            public void method_7(Entity entity_1)
            {
                Class75.smethod_73(this.serverControll_0, entity_1, "^5IP: ^1" + this.serverControll_0.getPlayerIP(this.entity_0));
            }

            public void method_8(Entity entity_1)
            {
                if (this.serverControll_0.getPlayerPsw(this.entity_0) == 1)
                {
                    Class75.smethod_73(this.serverControll_0, entity_1, "^5PSW: ^1Player Registered");
                }
                else
                {
                    Class75.smethod_73(this.serverControll_0, entity_1, "^5PSW: ^1Player Not Registered");
                }
            }

            public void method_9(Entity entity_1)
            {
                ServerControll controll = this.serverControll_0;
                Class75.smethod_77(this.entity_0, controll, entity_1);
            }
        }

        internal sealed class Class29
        {
            public ServerControll serverControll_0;
            public string string_0;
            public string string_1;

            public void method_0()
            {
                Class75.smethod_64(this.serverControll_0, "^1" + this.string_1 + " ^7connect from [^5" + this.string_0 + "^7]");
            }
        }

        private sealed class Class3
        {
            public Entity entity_0;
            public ServerControll serverControll_0;

            public bool method_0()
            {
                if (ServerControll.int_24 == 0)
                {
                    return false;
                }
                using (List<Entity>.Enumerator enumerator = ServerControll.list_3.GetEnumerator())
                {
                    Entity current;
                    while (enumerator.MoveNext())
                    {
                        current = enumerator.Current;
                        if (current != this.entity_0)
                        {
                            if (current.CurrentWeapon.Equals("briefcase_bomb_mp"))
                            {
                                goto Label_006A;
                            }
                            if (current.CurrentWeapon.Equals("briefcase_bomb_defuse_mp"))
                            {
                                goto Label_007F;
                            }
                        }
                    }
                    goto Label_00A2;
                Label_006A:
                    current.TakeWeapon("briefcase_bomb_mp");
                    ServerControll.int_24 = 0;
                    return false;
                Label_007F:
                    current.TakeWeapon("briefcase_bomb_defuse_mp");
                    ServerControll.int_24 = 0;
                    return false;
                }
            Label_00A2:
                return true;
            }

            public void method_1()
            {
                this.entity_0.Call("suicide", new Parameter[0]);
            }
        }

        internal sealed class Class30
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        internal sealed class Class31
        {
            public ServerControll.Class30 class30_0;
            public int int_0;
            public string[] string_0;

            public bool method_0()
            {
                if ((this.int_0 < this.string_0.Length) && (this.string_0[this.int_0] != ""))
                {
                    Class75.smethod_73(this.class30_0.serverControll_0, this.class30_0.entity_0, "^1" + this.string_0[this.int_0]);
                    this.int_0++;
                    return true;
                }
                return false;
            }
        }

        internal sealed class Class32
        {
            public HudElem hudElem_0;

            public void method_0()
            {
                this.hudElem_0.Call("destroy", new Parameter[0]);
            }
        }

        internal sealed class Class33
        {
            public HudElem hudElem_0;

            public void method_0()
            {
                this.hudElem_0.Call("destroy", new Parameter[0]);
            }
        }

        internal sealed class Class34
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

        private sealed class Class35
        {
            public Entity entity_0;
            public ServerControll serverControll_0;

            public void method_0()
            {
                Class75.smethod_55(this.serverControll_0, "^1" + this.serverControll_0.getPlayerName(this.entity_0) + "^7 login ^5" + ServerControll.DBNomeGruppi[this.serverControll_0.getPlayerLevel(this.entity_0)] + "^7 for ^5" + ServerControll.string_5 + " ^7Server");
            }
        }

        internal sealed class Class36
        {
            public int int_0;
            public ServerControll serverControll_0;

            public bool method_0(Entity entity_0)
            {
                Action function = null;
                Class37 class2 = new Class37 {
                    class36_0 = this,
                    entity_0 = entity_0
                };
                bool flag = true;
                if (!(class2.entity_0.IsAlive && ServerControll.bool_51))
                {
                    class2.entity_0.SetField("LPCamp", new Vector3(0f, 0f, 0f));
                    class2.entity_0.SetField("Camp", 0);
                    flag = false;
                }
                if (class2.entity_0.GetField<string>("sessionstate") == "spectator")
                {
                    flag = false;
                }
                for (int i = 0; i < ServerControll.string_74.Length; i++)
                {
                    if (class2.entity_0.CurrentWeapon.ToString().Contains(ServerControll.string_74[i]))
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
                        if (field.DistanceTo2D(class2.entity_0.Origin) < 100f)
                        {
                            int num2 = class2.entity_0.GetField<int>("Camp");
                            class2.entity_0.SetField("Camp", ++num2);
                            if (num2 <= this.int_0)
                            {
                                string str = string.Empty;
                                if (ServerControll.string_18 == "kick")
                                {
                                    str = "kick";
                                }
                                else if (ServerControll.string_18 == "kill")
                                {
                                    str = "killed";
                                }
                                else if (ServerControll.string_18 == "block")
                                {
                                    str = "block";
                                }
                                Class75.smethod_158(this.serverControll_0, class2.entity_0, string.Concat(new object[] { "^7[^5", num2, "^1/^5", this.int_0, "^7]^1No Camp!!! - If you do not move you are ", str }));
                            }
                            if ((num2 == this.int_0) && (ServerControll.string_18 == "kill"))
                            {
                                class2.entity_0.Health /= 2;
                                class2.entity_0.Notify("damage", new Parameter[] { class2.entity_0.Health, class2.entity_0, new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), "MOD_EXPLOSIVE", "", "", "", 0, "frag_grenade_mp" });
                            }
                            if (num2 > this.int_0)
                            {
                                if (ServerControll.string_18 == "kick")
                                {
                                    Class75.smethod_20(this.serverControll_0, "Server", "k", class2.entity_0, "No Camp!!!");
                                }
                                else if (ServerControll.string_18 == "kill")
                                {
                                    if (function == null)
                                    {
                                        function = new Action(class2.method_0);
                                    }
                                    this.serverControll_0.AfterDelay(50, function);
                                }
                                else if ((ServerControll.string_18 == "block") && (num2 == 4))
                                {
                                    Class75.smethod_11(this.serverControll_0, class2.entity_0);
                                }
                            }
                        }
                        else
                        {
                            class2.entity_0.SetField("Camp", 0);
                        }
                    }
                    class2.entity_0.SetField("LPCamp", class2.entity_0.Origin);
                }
                return true;
            }

            private sealed class Class37
            {
                public ServerControll.Class36 class36_0;
                public Entity entity_0;

                public void method_0()
                {
                    this.entity_0.Call("suicide", new Parameter[0]);
                }
            }
        }

        internal sealed class Class38
        {
            public Entity entity_0;
            public int int_0;
            public ServerControll serverControll_0;

            public bool method_0(Entity entity_1)
            {
                if (!(entity_1.IsAlive && (this.int_0 == this.entity_0.GetField<int>("FlagRadar"))))
                {
                    this.serverControll_0.Call(0x1b0, new Parameter[] { this.int_0 });
                    return false;
                }
                entity_1.Call(0x1af, new Parameter[] { this.int_0, "active" });
                entity_1.Call(0x1b3, new Parameter[] { this.int_0, new Parameter(entity_1.Origin) });
                entity_1.Call(0x1b2, new Parameter[] { this.int_0, "waypoint_kill" });
                entity_1.Call("freezeControls", new Parameter[] { 1 });
                entity_1.Call("iprintlnbold", new Parameter[] { "^1No Camp!!! - You Blocked Waiting for Death" });
                return true;
            }
        }

        internal sealed class Class39
        {
            public ServerControll serverControll_0;
            public Entity entity_0;
            private static Predicate<char> predicate_0;
            private static Predicate<char> predicate_1;

            public void method_0(Entity entity_1)
            {
                int num;
                if (Encoding.UTF8.GetByteCount(entity_1.Name) == entity_1.Name.Length)
                {
                    char[] array1 = entity_1.Name.ToCharArray();
                    if (ServerControll.Class39.predicate_0 == null)
                        ServerControll.Class39.predicate_0 = new Predicate<char>(Class75.smethod_206);
                    Predicate<char> match1 = ServerControll.Class39.predicate_0;
                    if (!Array.TrueForAll<char>(array1, match1))
                    {
                        char[] array2 = this.entity_0.Name.ToCharArray();
                        if (ServerControll.Class39.predicate_1 == null)
                            ServerControll.Class39.predicate_1 = new Predicate<char>(Class75.smethod_35);
                        Predicate<char> match2 = ServerControll.Class39.predicate_1;
                        num = !Array.TrueForAll<char>(array2, match2) ? 1 : 0;
                        goto label_8;
                    }
                }
                num = 0;
            label_8:
                if (num == 0)
                    Class75.smethod_20(this.serverControll_0, "Server", "k", entity_1, "^1Change your Nick, permitted only ASCII characters!");
                else if (entity_1.Name.Length < 3)
                {
                    Class75.smethod_20(this.serverControll_0, "Server", "k", entity_1, "^1Change your Nick, this nickname is too short!");
                }
                else
                {
                    for (int index = 0; index < ServerControll.string_82.Length; ++index)
                    {
                        if (entity_1.Name.ToLower().Contains(ServerControll.string_82[index]))
                        {
                            Class75.smethod_20(this.serverControll_0, "Server", "k", entity_1, ServerControll.string_41);
                            break;
                        }
                    }
                    if ((!this.serverControll_0.getPlayerHWID(entity_1).Contains("0000000000") ? 1 : (!ServerControll.string_2.StartsWith("te") ? 1 : 0)) == 0)
                    {
                        ServerControll serverControll_0 = this.serverControll_0;
                        Class75.smethod_84("WARNING! ZEROED HWID AT CLIENT " + (object)entity_1.Call<int>("getentitynumber", new Parameter[0]) + ". Dropping client...", serverControll_0);
                        Class75.smethod_20(this.serverControll_0, "Server", "k", entity_1, "Error! You are probably running Windows XP. This system is not compatible with TeknoMW3.");
                    }
                    else
                    {
                        foreach (Entity player in ServerControll.list_2)
                        {
                            if ((!this.serverControll_0.getPlayerName(entity_1).Equals(this.serverControll_0.getPlayerName(player)) ? 1 : (!(this.serverControll_0.getPlayerGuid(entity_1) != this.serverControll_0.getPlayerGuid(player)) ? 1 : 0)) == 0)
                            {
                                Class75.smethod_20(this.serverControll_0, "Server", "k", entity_1, "^1Change your Nick - Nick is already in use!");
                                return;
                            }
                        }
                        for (int index = 0; index < ServerControll.string_72.Length; ++index)
                        {
                            if (entity_1.Name.ToLower().Contains(ServerControll.string_72[index]))
                            {
                                ServerControll serverControll = this.serverControll_0;
                                DateTime now = DateTime.Now;
                                ServerControll serverControll_0 = serverControll;
                                Class75.smethod_84(now.ToShortTimeString() + " Expelled " + entity_1.Name + " REASON: Change your Nick, characters not permitted!", serverControll_0);
                                Class75.smethod_6(this.serverControll_0, "dropclient " + (object)this.entity_0.Call<int>("getentitynumber", new Parameter[0]) + " \"^1Change your Nick, characters (^5 , ; = > § ^1) not permitted!\"", 0);
                                return;
                            }
                        }
                        Class75.smethod_79(this.entity_0, this.serverControll_0);
                    }
                }
            }
        }

        private sealed class Class4
        {
            public ServerControll.Class3 class3_0;
            public string string_0;

            public void method_0()
            {
                Class75.smethod_64(this.class3_0.serverControll_0, "^1" + this.string_0);
            }

            public void method_1()
            {
                Class75.smethod_64(this.class3_0.serverControll_0, "^2" + this.string_0);
            }

            public void method_2()
            {
                Class75.smethod_64(this.class3_0.serverControll_0, "^3" + this.string_0);
            }

            public void method_3()
            {
                Class75.smethod_64(this.class3_0.serverControll_0, "^4" + this.string_0);
            }

            public void method_4()
            {
                Class75.smethod_64(this.class3_0.serverControll_0, "^5" + this.string_0);
            }

            public void method_5()
            {
                Class75.smethod_64(this.class3_0.serverControll_0, "^6" + this.string_0);
            }

            public void method_6()
            {
                Class75.smethod_64(this.class3_0.serverControll_0, "^7" + this.string_0);
            }
        }

        internal sealed class Class40
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
            public Vector3 vector3_0;

            public void method_0(Entity entity_1)
            {
                this.serverControll_0.Call("magicbullet", new Parameter[] { this.entity_0.CurrentWeapon.ToString(), this.vector3_0, entity_1.Call<Vector3>("getTagOrigin", new Parameter[] { "j_head" }), this.entity_0 });
            }
        }

        internal sealed class Class41
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
            public string string_0;

            public void method_0()
            {
                Class75.smethod_20(this.serverControll_0, "Server", "k", this.entity_0, this.string_0);
            }
        }

        private sealed class Class42
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

        internal sealed class Class43
        {
            public HudElem hudElem_0;
            public ServerControll serverControll_0;

            public bool method_0(Entity entity_0)
            {
                if (ServerControll.bool_51)
                {
                    if (entity_0.IsAlive)
                    {
                        this.hudElem_0.Alpha = 1f;
                        string str = string.Empty;
                        string str2 = string.Empty;
                        string field = entity_0.GetField<string>("sessionteam");
                        int num = this.serverControll_0.Call<int>("getteamplayersalive", new Parameter[] { "axis" });
                        int num2 = this.serverControll_0.Call<int>("getteamplayersalive", new Parameter[] { "allies" });
                        int num3 = field.Equals("allies") ? num2 : num;
                        int num4 = field.Equals("allies") ? num : num2;
                        num3--;
                        if ((num3 == 0) && (num4 == 1))
                        {
                            Entity player = null;
                            foreach (Entity entity2 in ServerControll.list_2)
                            {
                                if ((entity2.EntRef != entity_0.EntRef) && entity2.IsAlive)
                                {
                                    player = entity2;
                                }
                            }
                            str = "^7(^5" + this.serverControll_0.getPlayerName(entity_0) + "^7) ";
                            str2 = " ^7(^5" + this.serverControll_0.getPlayerName(player) + "^7)";
                        }
                        this.hudElem_0.SetText(str + "^5FRIENDS:^7 " + num3.ToString() + " ^7- ^1ENEMIES:^7 " + num4.ToString() + str2);
                    }
                    else
                    {
                        this.hudElem_0.Alpha = 0f;
                    }
                }
                return true;
            }
        }

        internal sealed class Class44
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        internal sealed class Class45
        {
            public string[] string_0;
        }

        internal sealed class Class46
        {
            public ServerControll.Class44 class44_0;
            public ServerControll.Class45 class45_0;
            public int int_0;
            public string[] string_0;

            public bool method_0()
            {
                if ((this.int_0 < this.class45_0.string_0.Length) && (this.class45_0.string_0[this.int_0] != ""))
                {
                    this.string_0 = this.class45_0.string_0[this.int_0].Split(new char[] { ServerControll.char_4 });
                    Class75.smethod_73(this.class44_0.serverControll_0, this.class44_0.entity_0, "^5" + this.string_0[0] + " = ^1" + this.string_0[2]);
                    this.int_0++;
                    return true;
                }
                return false;
            }
        }

        internal sealed class Class47
        {
            public Entity entity_0;
            public ServerControll serverControll_0;

            public void method_0()
            {
                Class48 class2 = new Class48 {
                    class47_0 = this,
                    int_0 = 0,
                    string_0 = System.IO.File.ReadAllLines(ServerControll.string_84 + ServerControll.string_48)
                };
                this.serverControll_0.OnInterval(0x7d0, new Func<bool>(class2.method_0));
            }

            private sealed class Class48
            {
                public ServerControll.Class47 class47_0;
                public int int_0;
                public string[] string_0;

                public bool method_0()
                {
                    if ((this.int_0 < this.string_0.Length) && (this.string_0[this.int_0] != ""))
                    {
                        Class75.smethod_73(this.class47_0.serverControll_0, this.class47_0.entity_0, this.string_0[this.int_0]);
                        this.int_0++;
                        return true;
                    }
                    return false;
                }
            }
        }

        internal sealed class Class49
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        private sealed class Class5
        {
            public Entity entity_0;

            public void method_0()
            {
                this.entity_0.Call("suicide", new Parameter[0]);
            }
        }

        internal sealed class Class50
        {
            public ServerControll.Class49 class49_0;
            public string string_0;

            public void method_0()
            {
                Class75.smethod_20(this.class49_0.serverControll_0, "Server", "b", this.class49_0.entity_0, this.string_0);
            }

            public void method_1()
            {
                Class75.smethod_20(this.class49_0.serverControll_0, "Server", "b", this.class49_0.entity_0, this.string_0);
            }
        }

        internal sealed class Class51
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        internal sealed class Class52
        {
            public ServerControll.Class51 class51_0;
            public string string_0;

            public void method_0()
            {
                Class75.smethod_20(this.class51_0.serverControll_0, "Server", "tb", this.class51_0.entity_0, this.string_0);
            }

            public void method_1()
            {
                Class75.smethod_20(this.class51_0.serverControll_0, "Server", "tb", this.class51_0.entity_0, this.string_0);
            }
        }

        internal sealed class Class53
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

        internal sealed class Class54
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        internal sealed class Class55
        {
            public ServerControll.Class54 class54_0;
            public int int_0;
            public string[] string_0;
            public string[] string_1;
            public string[] string_2;

            public bool method_0()
            {
                if ((this.int_0 < this.string_0.Length) && (this.string_0[this.int_0] != ""))
                {
                    this.string_1 = this.string_0[this.int_0].Split(new char[] { ServerControll.char_1 });
                    this.string_2 = this.string_1[0].Split(new char[] { ServerControll.char_2 });
                    DateTime time = DateTime.Parse(this.string_2[0]);
                    double num = double.Parse(this.string_2[1]);
                    TimeSpan span = (TimeSpan) (DateTime.Now - time);
                    if (span.TotalMinutes < num)
                    {
                        double num2 = Convert.ToInt32((double) (num - span.TotalMinutes));
                        Class75.smethod_73(this.class54_0.serverControll_0, this.class54_0.entity_0, string.Concat(new object[] { "^7[^1", this.int_0, "^7] ^5", this.string_1[1], "^7[^1", this.string_1[2], "^7]^5 banned for other ", num2, "min" }));
                    }
                    this.int_0++;
                    return true;
                }
                return false;
            }
        }

        internal sealed class Class56
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        internal sealed class Class57
        {
            public ServerControll.Class56 class56_0;
            public int int_0;
            public string[] string_0;
            public string[] string_1;

            public bool method_0()
            {
                if ((this.int_0 < this.string_0.Length) && (this.string_0[this.int_0] != ""))
                {
                    this.string_1 = this.string_0[this.int_0].Split(new char[] { ServerControll.char_1 });
                    if (ServerControll.isDate(this.string_1[0]))
                    {
                        Class75.smethod_73(this.class56_0.serverControll_0, this.class56_0.entity_0, string.Concat(new object[] { "^7[^1", this.int_0, "^7] ^5", this.string_1[1], "^7[^1", this.string_1[2], "^7]" }));
                    }
                    else
                    {
                        Class75.smethod_73(this.class56_0.serverControll_0, this.class56_0.entity_0, string.Concat(new object[] { "^7[^1", this.int_0, "^7] ^5", this.string_1[0], "^7[^1", this.string_1[1], "^7]" }));
                    }
                    this.int_0++;
                    return true;
                }
                return false;
            }
        }

        internal sealed class Class58
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        internal sealed class Class59
        {
            public ServerControll.Class58 class58_0;
            public int int_0;
            public string[] string_0;
            public string[] string_1;

            public bool method_0()
            {
                if ((this.int_0 < this.string_0.Length) && (this.string_0[this.int_0] != ""))
                {
                    this.string_1 = this.string_0[this.int_0].Split(new char[] { ServerControll.char_1 });
                    if (ServerControll.isDate(this.string_1[0]))
                    {
                        Class75.smethod_73(this.class58_0.serverControll_0, this.class58_0.entity_0, "^5" + this.string_1[1] + "^7[^1" + this.string_1[2] + "^7] ^5" + this.string_1[6]);
                    }
                    else
                    {
                        Class75.smethod_73(this.class58_0.serverControll_0, this.class58_0.entity_0, "^5" + this.string_1[0] + "^7[^1" + this.string_1[1] + "^7] ^5" + this.string_1[5]);
                    }
                    this.int_0++;
                    return true;
                }
                return false;
            }
        }

        private sealed class Class6
        {
            public Entity entity_0;
            public Entity entity_1;
            public ServerControll serverControll_0;

            public void method_0(Entity entity_2)
            {
                this.serverControll_0.method_36(this.entity_1, this.entity_0, true, false);
            }

            public void method_1(Entity entity_2)
            {
                this.serverControll_0.method_36(this.entity_1, this.entity_0, false, true);
            }

            public void method_2(Entity entity_2)
            {
                this.serverControll_0.method_36(this.entity_1, this.entity_0, false, false);
            }
        }

        internal sealed class Class60
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

        private sealed class Class61
        {
            public int int_0;
            public ServerControll serverControll_0;

            public bool method_0()
            {
                if (this.int_0 < 1)
                {
                    Class75.smethod_64(this.serverControll_0, "^5Restarting server...");
                    Process.Start("riavvia.bat");
                    Class75.smethod_6(this.serverControll_0, "quit", 0x7d0);
                    return false;
                }
                this.int_0--;
                Class75.smethod_64(this.serverControll_0, "^5Server will be restarted in^1 " + this.int_0 + "s");
                return true;
            }
        }

        internal sealed class Class62
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

        internal sealed class Class63
        {
            public Entity entity_0;
            public ServerControll serverControll_0;

            public bool method_0(Entity entity_1)
            {
                Action function = null;
                if (entity_1.GetField<string>("sessionteam") == "none")
                {
                    return false;
                }
                if (this.serverControll_0.getPlayerSpect(entity_1) == 0)
                {
                    return false;
                }
                if (this.serverControll_0.Call<int>("getteamplayersalive", new Parameter[] { entity_1.GetField<string>("sessionteam") }) <= 1)
                {
                    this.entity_0.SetField("sessionstate", "playing");
                    this.entity_0.Call("setcontents", new Parameter[] { 100 });
                    ServerControll controll = this.serverControll_0;
                    Class75.smethod_58(this.entity_0, 0, controll);
                    this.entity_0.SetField("FlagRadar", 0);
                    if (function == null)
                    {
                        function = new Action(this.method_2);
                    }
                    this.serverControll_0.AfterDelay(300, function);
                    return false;
                }
                return true;
            }

            public void method_1()
            {
                this.entity_0.Call("suicide", new Parameter[0]);
            }

            public void method_2()
            {
                this.entity_0.Call("suicide", new Parameter[0]);
            }
        }

        internal sealed class Class64
        {
            public Entity entity_0;

            public void method_0(Entity entity_1)
            {
                this.entity_0.SetField("VarPause", 0);
            }
        }

        internal sealed class Class65
        {
            public Entity entity_0;
            public int int_0;
            public ServerControll serverControll_0;

            public bool method_0(Entity entity_1)
            {
                if ((ServerControll.DBNomeGruppi[this.int_0] != "null") && (ServerControll.DBNomeGruppi[this.int_0] != ""))
                {
                    Class75.smethod_73(this.serverControll_0, this.entity_0, "^1" + ServerControll.DBNomeGruppi[this.int_0] + " ^7OnLine: ^5" + this.serverControll_0.GruppiOnline(this.int_0));
                    this.int_0--;
                }
                else
                {
                    this.int_0--;
                }
                if (this.int_0 < 1)
                {
                    return false;
                }
                return true;
            }
        }

        internal sealed class Class66
        {
            public Entity entity_0;
            public int int_0;
            public ServerControll serverControll_0;

            public bool method_0(Entity entity_1)
            {
                if ((ServerControll.DBNomeGruppi[this.int_0] != "null") && (ServerControll.DBNomeGruppi[this.int_0] != ""))
                {
                    Class75.smethod_73(this.serverControll_0, this.entity_0, string.Concat(new object[] { "^5Level Group ^1", this.int_0, "^5 = ^1", ServerControll.DBNomeGruppi[this.int_0] }));
                    this.int_0--;
                }
                else
                {
                    this.int_0--;
                }
                if (this.int_0 < 1)
                {
                    return false;
                }
                return true;
            }
        }

        internal sealed class Class67
        {
            public char char_0;
            public ServerControll serverControll_0;
            public string string_0;

            public void method_0()
            {
                Action function = null;
                if (System.IO.File.Exists(ServerControll.string_71))
                {
                    string[] strArray = System.IO.File.ReadAllLines(ServerControll.string_71);
                    System.IO.File.Delete(ServerControll.string_71);
                    using (StreamWriter writer = new StreamWriter(ServerControll.string_71, true))
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
                Class75.smethod_153(null, this.serverControll_0);
            }
        }

        internal sealed class Class68
        {
            public ServerControll.Class67 class67_0;
            public string string_0;
            public string string_1;

            public bool method_0()
            {
                foreach (Entity entity in ServerControll.list_3)
                {
                    if (this.class67_0.serverControll_0.getPlayerLevel(entity) > 6)
                    {
                        Class75.smethod_73(this.class67_0.serverControll_0, entity, "^5Available to download the new version ^1NaaBAdmin " + this.string_1 + " ^5Link:^1 " + this.string_0);
                    }
                }
                ServerControll controll = this.class67_0.serverControll_0;
                Class75.smethod_84("Available to download the new version ^1NaaBAdmin " + this.string_1 + "\n " + this.string_0, controll);
                return true;
            }
        }

        private sealed class Class69
        {
            public Entity entity_0;
            public Entity entity_1;
            public ServerControll serverControll_0;
            public string string_0;
        }

        private sealed class Class7
        {
            public ServerControll.Class6 class6_0;
            public string string_0;

            public void method_0(Entity entity_0)
            {
                Class75.smethod_64(this.class6_0.serverControll_0, this.string_0.Replace("<playerdead>", this.class6_0.serverControll_0.getPlayerName(this.class6_0.entity_0)).Replace("<playerattack>", this.class6_0.serverControll_0.getPlayerName(this.class6_0.entity_1)));
                ServerControll controll = this.class6_0.serverControll_0;
                Class75.smethod_146(this.class6_0.entity_1, 0, controll);
            }
        }

        private sealed class Class70
        {
            private static Action action_0;
            private static Action action_1;
            private static Action action_2;
            private static Action action_3;
            private static Action action_4;
            private static Action action_5;
            public ServerControll.Class69 class69_0;
            public string[] string_0;

            public bool method_0()
            {
                Action function = null;
                Action action2 = null;
                Action action3 = null;
                if (!ServerControll.bool_48)
                {
                    ServerControll.hudElem_0.Alpha = 0f;
                    ServerControll.hudElem_1.Alpha = 0f;
                    if (action_0 == null)
                    {
                        action_0 = new Action(Class75.smethod_135);
                    }
                    this.class69_0.serverControll_0.AfterDelay(500, action_0);
                    if (action_1 == null)
                    {
                        action_1 = new Action(Class75.smethod_78);
                    }
                    this.class69_0.serverControll_0.AfterDelay(0x3e8, action_1);
                    ServerControll.int_18 = 0;
                    ServerControll.int_17 = 0;
                    ServerControll.int_19 = 0;
                    ServerControll.int_20 = 0;
                    if (System.IO.File.Exists(ServerControll.string_88 + ServerControll.string_67))
                    {
                        System.IO.File.Delete(ServerControll.string_88 + ServerControll.string_67);
                    }
                    if (action_2 == null)
                    {
                        action_2 = new Action(Class75.smethod_210);
                    }
                    this.class69_0.serverControll_0.AfterDelay(10, action_2);
                    if (action_3 == null)
                    {
                        action_3 = new Action(Class75.smethod_82);
                    }
                    this.class69_0.serverControll_0.AfterDelay(50, action_3);
                    foreach (Entity entity in ServerControll.list_3)
                    {
                        entity.SetField("Voto", 0);
                    }
                    return false;
                }
                if (ServerControll.int_20 >= ServerControll.int_16)
                {
                    ServerControll.bool_48 = false;
                    ServerControll.hudElem_0.Alpha = 0f;
                    ServerControll.hudElem_1.Alpha = 0f;
                    if (action_4 == null)
                    {
                        action_4 = new Action(Class75.smethod_147);
                    }
                    this.class69_0.serverControll_0.AfterDelay(500, action_4);
                    if (action_5 == null)
                    {
                        action_5 = new Action(Class75.smethod_169);
                    }
                    this.class69_0.serverControll_0.AfterDelay(0x3e8, action_5);
                    ServerControll.int_19 = 0;
                    ServerControll.int_20 = 0;
                    if (System.IO.File.Exists(ServerControll.string_88 + ServerControll.string_67))
                    {
                        System.IO.File.Delete(ServerControll.string_88 + ServerControll.string_67);
                    }
                    int num = ServerControll.list_3.Count / 2;
                    int num2 = ServerControll.int_17 + ServerControll.int_18;
                    if (num2 <= num)
                    {
                        foreach (Entity entity in ServerControll.list_3)
                        {
                            entity.Call("playlocalsound", new Parameter[] { "mp_killconfirm_tags_deny" });
                        }
                        Class75.smethod_64(this.class69_0.serverControll_0, "^1Negative vote ^5- Voters must exceed half of online gamers!");
                        return false;
                    }
                    if (ServerControll.int_17 > ServerControll.int_18)
                    {
                        foreach (Entity entity in ServerControll.list_3)
                        {
                            entity.Call("playlocalsound", new Parameter[] { "mp_killconfirm_tags_pickup" });
                        }
                        Class75.smethod_64(this.class69_0.serverControll_0, "^5Positive vote");
                        if (this.string_0[0].Contains("map"))
                        {
                            this.class69_0.serverControll_0.method_0("all");
                            Class75.smethod_6(this.class69_0.serverControll_0, "map " + this.string_0[1], 0x7d0);
                        }
                        else if (this.string_0[0].Contains("mod"))
                        {
                            this.class69_0.serverControll_0.method_0("all");
                            if (function == null)
                            {
                                function = new Action(this.method_1);
                            }
                            this.class69_0.serverControll_0.AfterDelay(0x7d0, function);
                        }
                        else if (this.string_0[0].Contains("kick"))
                        {
                            if (ServerControll.list_3.Contains(this.class69_0.entity_1) && (this.class69_0.entity_1 != null))
                            {
                                if (action2 == null)
                                {
                                    action2 = new Action(this.method_2);
                                }
                                this.class69_0.serverControll_0.AfterDelay(100, action2);
                            }
                            else
                            {
                                this.class69_0.serverControll_0.method_9(this.class69_0.string_0, 30);
                            }
                        }
                        else if (this.string_0[0].Contains("ban"))
                        {
                            if (ServerControll.list_3.Contains(this.class69_0.entity_1) && (this.class69_0.entity_1 != null))
                            {
                                if (action3 == null)
                                {
                                    action3 = new Action(this.method_3);
                                }
                                this.class69_0.serverControll_0.AfterDelay(100, action3);
                            }
                            else
                            {
                                this.class69_0.serverControll_0.method_9(this.class69_0.string_0, 60);
                            }
                        }
                    }
                    else
                    {
                        Class75.smethod_64(this.class69_0.serverControll_0, "^1Negative vote");
                    }
                    return false;
                }
                ServerControll.int_20++;
                IniParser parser = new IniParser(ServerControll.string_88 + ServerControll.string_67);
                parser.AddSetting("Voting", "tmp", ServerControll.int_20.ToString());
                parser.SaveSettings();
                foreach (Entity entity in ServerControll.list_3)
                {
                    entity.Call("playlocalsound", new Parameter[] { "missile_locking" });
                }
                ServerControll.int_19 = ServerControll.int_16 - ServerControll.int_20;
                ServerControll.hudElem_1.SetText(string.Concat(new object[] { "^1!y ^7or^1 !n ^7- [^5", ServerControll.int_17, "^1/^5", ServerControll.int_18, "^7] Conclusion^5 ", ServerControll.int_19, "s" }));
                return true;
            }

            public void method_1()
            {
                ServerControll controll = this.class69_0.serverControll_0;
                Entity entity = this.class69_0.entity_0;
                string str = this.string_0[1];
                string str2 = ServerControll.string_92;
                Class75.smethod_39(str, str2, controll, entity);
            }

            public void method_2()
            {
                Class75.smethod_20(this.class69_0.serverControll_0, "Server", "k", this.class69_0.entity_1, "Kick for Vote");
            }

            public void method_3()
            {
                this.class69_0.serverControll_0.method_23(null, this.class69_0.entity_1, 10, "TempBan 10min for vote");
            }
        }

        internal sealed class Class71
        {
            public IniParser iniParser_0;
            public ServerControll serverControll_0;

            public void method_0()
            {
                string[] strArray = this.iniParser_0.EnumSection("User");
                foreach (Entity entity in ServerControll.list_3)
                {
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        string[] strArray2 = strArray[i].Split(new char[] { ServerControll.char_1 });
                        if (this.serverControll_0.getPlayerGuid(entity).Equals(strArray2[0]))
                        {
                            if (strArray2[1].Equals("Y"))
                            {
                                entity.SetField("Voto", 2);
                                ServerControll.int_17++;
                            }
                            else
                            {
                                entity.SetField("Voto", 1);
                                ServerControll.int_18++;
                            }
                        }
                    }
                }
            }
        }

        private sealed class Class72
        {
            public Entity entity_0;
            public ServerControll serverControll_0;
        }

        private sealed class Class73
        {
            public ServerControll.Class72 class72_0;
            public int int_0;
            public List<string> list_0;

            public bool method_0()
            {
                if (this.int_0 < this.list_0.Count)
                {
                    if (this.class72_0.entity_0 != null)
                    {
                        Class75.smethod_73(this.class72_0.serverControll_0, this.class72_0.entity_0, this.list_0[this.int_0]);
                    }
                    else
                    {
                        Class75.smethod_64(this.class72_0.serverControll_0, this.list_0[this.int_0]);
                    }
                    this.int_0++;
                    return true;
                }
                return false;
            }
        }

        internal sealed class Class8
        {
            public int int_0;
            public ServerControll serverControll_0;

            public bool method_0()
            {
                if (this.int_0 == 0)
                {
                    if (ServerControll.list_2.Count == 0)
                    {
                        if (ServerControll.bool_8)
                        {
                            IniParser parser = new IniParser(ServerControll.string_84 + ServerControll.string_47);
                            parser.AddSetting("PASSWORD_ACCESS_SERVER", "Status_Password_Script", "false");
                            parser.SaveSettings();
                        }
                        if (Directory.Exists(ServerControll.string_88))
                        {
                            Directory.Delete(ServerControll.string_88, true);
                        }
                        if (ServerControll.bool_44)
                        {
                            this.serverControll_0.method_0("all");
                            DateTime now = DateTime.Now;
                            ServerControll controll = this.serverControll_0;
                            Class75.smethod_84(now.ToShortTimeString() + " - AutoRotation Map", controll);
                            Utilities.ExecuteCommand("map_rotate");
                        }
                    }
                    foreach (Entity entity in ServerControll.list_2)
                    {
                        Class75.smethod_214(entity, this.serverControll_0);
                    }
                }
                this.int_0 = 0;
                return true;
            }
        }

        internal sealed class Class9
        {
            public Entity entity_0;
            public ServerControll serverControll_0;

            public void method_0()
            {
                if (ServerControll.list_5.Contains(this.entity_0))
                {
                    Class10 class2 = new Class10 {
                        class9_0 = this
                    };
                    Random random = new Random();
                    class2.string_0 = "class" + random.Next(1, 4).ToString();
                    this.entity_0.OnNotify("joined_team", new Action<Entity>(class2.method_0));
                }
            }

            private sealed class Class10
            {
                public ServerControll.Class9 class9_0;
                public string string_0;

                public void method_0(Entity entity_0)
                {
                    entity_0.Notify("menuresponse", new Parameter[] { "changeclass", this.string_0 });
                }
            }
        }
    }
}

