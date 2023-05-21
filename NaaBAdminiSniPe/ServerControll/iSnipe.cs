using InfinityScript;
using System;
using System.Collections.Generic;
using System.IO;
namespace iSnipe
{
    public class iSnipe : BaseScript
    {
        public List<Entity> PlayersIn = new List<Entity>();
        public string version = "v1.0";
        public string map;
        public bool _prematch = true;
        public bool antiTKnife;
        public bool antiPBomb;
        public bool antiKnife;
        public bool antihs;
        public bool antins;
        public bool anticamp;
        public bool antifalldamage;
        public int anticamptime = 2500;
        public int anticampchat = 2500;
        public string antihsmes = "^5No Hardscoping^7!";
        public string antinsmes = "^5No-Scoping is not allowed^7!";
        public string anticampmes = "^5Don't Camp^7! ";
        public string antiTKmes = "^5No Throwing Knife^7!";
        public string antiPBmes = "^5You are not allowed to plant the bomb^7!";
        public string antiKmes = "^5Don't knife^7!";
        public iSnipe()
        {
            string gtype = Call<string>("GetDvar", "g_gametype");
            if (gtype != "sd")
            {
                return;
            }
            this.Write2Console(string.Format("iSnipe - {0}", this.version));
            this.Config();
            this.NotifyHandle();
            base.PlayerConnected += new Action<Entity>(this.pCon);
            base.PlayerDisconnected += new Action<Entity>(this.pDis);

            this.map = base.Call<string>("getdvar", new Parameter[]
         {
            "mapname"
         });
        }
        public void Config()
        {
            if (!File.Exists("scripts\\NaaBiSniPe\\iSnipe.cfg"))
            {
                string[] contents = new string[]
            {
               "NOTICE: 0 = Disabled / 1 = Enabled",
               "AntiNoScope->1",
               "AntiHardScope->1",
               "AntiFallDamage->1",
               "AntiCamp->0",
               "AntiCampTime->2500",
               "AntiCampChatTime->2500",
               "AntiKnife->1",
               "AntiThrowingKnife->1",
               "AntiPlantBomb->1",
               "AntiNoScopeMessage->^5No-Scoping is not allowed^7!",
               "AntiHardScopeMessage->^5No Hardscoping^7!",
               "AntiCampMessage->^5Don't Camp^7! ",
               "AntiThrowingKnifeMessage->^5No Throwing Knife^7!",
               "AntiKnifeMessage->^5Don't Knife^7!",
               "AntiPlantBombMessage->^5You are not allowed to plant the bomb^7!",
            };
                File.WriteAllLines("scripts\\NaaBAdmin_iSniPe\\iSnipe.cfg", contents);
                return;
            }
            string[] array = File.ReadAllLines("scripts\\NaaBAdmin_iSniPe\\iSnipe.cfg");
            string[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                string text = array2[i];
                if (text.Contains("->"))
                {
                    string[] array3 = text.Split(new string[]
               {
                  "->"
               }, StringSplitOptions.None);
                    string key;
                    switch (key = array3[0].ToLower())
                    {
                        case "antinoscope":
                            if (array3[1] == "1")
                            {
                                this.antins = true;
                            }
                            break;
                        case "antihardscope":
                            if (array3[1] == "1")
                            {
                                this.antihs = true;
                            }
                            break;
                        case "antithrowingknife":
                            if (array3[1] == "1")
                            {
                                this.antiTKnife = true;
                            }
                            break;
                        case "antiknife":
                            if (array3[1] == "1")
                            {
                                this.antiKnife = true;
                            }
                            break;
                        case "antiplantbomb":
                            if (array3[1] == "1")
                            {
                                this.antiPBomb = true;
                            }
                            break;
                        case "anticamp":
                            if (array3[1] == "1")
                            {
                                this.anticamp = true;
                            }
                            break;
                        case "antifalldamage":
                            if (array3[1] == "1")
                            {
                                this.antifalldamage = true;
                            }
                            break;
                        case "anticamptime":
                            this.anticamptime = Convert.ToInt32(array3[1]);
                            break;
                        case "anticampchattime":
                            this.anticampchat = Convert.ToInt32(array3[1]);
                            break;
                        case "antinoscopemessage":
                            this.antinsmes = array3[1];
                            break;
                        case "antihardscopemessage":
                            this.antihsmes = array3[1];
                            break;
                        case "antithrowingknifemessage":
                            this.antiTKmes = array3[1];
                            break;
                        case "antiknifemessage":
                            this.antiKmes = array3[1];
                            break;
                        case "antiplantbombmessage":
                            this.antiPBmes = array3[1];
                            break;
                        case "anticampmessage":
                            this.anticampmes = array3[1];
                            break;
                    }
                }
            }

            PlayerConnected += new Action<Entity>(entity =>
            {
                entity.SetField("plantedbomb", 0);
                entity.OnNotify("weapon_change", (player, weap) =>
                {
                    if (antiPBomb)
                        if ((string)weap == "briefcase_bomb_mp")
                        {
                            if (entity.GetField<int>("plantedbomb") == 1)
                            {
                                player.TakeWeapon("briefcase_bomb_mp");
                                entity.Call("iprintlnbold", antiPBmes);
                                return;
                            }
                            else
                                entity.TakeWeapon("briefcase_bomb_mp");

                            entity.SetField("plantedbomb", 1);
                            entity.Call("iprintlnbold", antiPBmes);
                        }
                });
            });
        }
        public void pCon(Entity player)
        {
            this.PlayersIn.Add(player);
            this.PlayerInit(player);
        }
        public void pDis(Entity player)
        {
            this.PlayersIn.Remove(player);
        }

        public void AntiHS(Entity player)
        {
            player.SetField("adscycles", 0);
            player.SetField("letmehardscope", 0);
            player.OnInterval(50, ent =>
            {
                if (!ent.IsAlive)
                    return false;
                if (ent.GetField<int>("letmehardscope") == 1)
                    return true;
                if (Call<string>("getdvar", "g_gametype") == "infect" && ent.GetField<string>("sessionteam") != "allies")
                    return true;
                float ads = ent.Call<float>("playerads");
                int adscycles = player.GetField<int>("adscycles");
                if (ads == 1f)
                    adscycles++;
                else
                    adscycles = 0;

                if (adscycles > 5)
                {
                    ent.Call("allowads", false);
                    ent.Call("iprintlnbold", antihsmes);
                }

                if (ent.Call<int>("adsbuttonpressed") == 0 && ads == 0)
                {
                    ent.Call("allowads", true);
                }

                player.SetField("adscycles", adscycles);
                return true;
            });
        }

        private static bool isKillstreak(string wep)
        {
            return wep.Contains("ac130") || wep.Contains("remote") || wep.Contains("minigun") || wep.Contains("predator") || wep.Contains("missile");
        }
        public void AntiCamp(Entity e)
        {
            Vector3 curPos = e.Origin;
            Vector3 spawnPos = e.Origin;
            e.SetField("camping", 0);
            e.OnInterval(this.anticamptime, delegate (Entity ent)
            {
                int field = ent.GetField<int>("camping");
                if (this._prematch)
                {
                    return true;
                }
                if (ent.GetField<string>("sessionteam") == "spectator")
                {
                    return true;
                }
                if (ent.GetField<int>("isTalkingP") != 0 || ent.GetField<int>("isTalkingT") != 0 || ent.GetField<int>("isUsing") != 0)
                {
                    return true;
                }
                if (ent.IsAlive && !iSnipe.isKillstreak(ent.CurrentWeapon) && ent.Call<int>("isusingturret", new Parameter[0]) != 1 && ent.Call<int>("istalking", new Parameter[0]) != 1)
                {
                    if (curPos.DistanceTo(e.Origin) < 50f && curPos.DistanceTo(spawnPos) > 100f)
                    {
                        int num = field;
                        if (num == 0)
                        {
                            ent.Call("visionsetnakedforplayer", new Parameter[]
                  {
                     "blacktest"
                  });
                            ent.SetField("isBlack", true);
                            ent.Call("iprintlnbold", new Parameter[]
                  {
                     this.anticampmes
                  });
                            ent.SetField("camping", field + 1);
                        }
                        else
                        {
                            ent.Call("iprintlnbold", new Parameter[]
                  {
                     this.anticampmes
                  });
                        }
                        return true;
                    }
                }
                ent.SetField("isBlack", false);
                curPos = e.Origin;
                ent.Call("visionsetnakedforplayer", new Parameter[]
    {
               this.map
    });
                ent.SetField("camping", 0);
                return this.PlayersIn.Contains(ent);
            });
        }
        public override void OnPlayerDamage(Entity e, Entity inflictor, Entity attacker, int damage, int dFlags, string mod, string weapon, Vector3 point, Vector3 dir, string hitLoc)
        {
            if (mod == "MOD_FALLING" && this.antifalldamage)
            {
                e.Health += damage;
            }
            if (antiTKnife && (weapon == "throwingknife_mp"))
            {
                attacker.Call("iprintlnbold", antiTKmes);
                e.Health += damage;
            }
            if (mod == "MOD_MELEE" && this.antiKnife)
            {
                attacker.Call("iprintlnbold", antiKmes);
                e.Health += damage;
            }
            if (!antins)
                return;

            if (attacker.Origin.DistanceTo2D(e.Origin) < 250f)

                if (weapon.Contains("scope"))
                {
                    if (attacker.Call<float>("playerads") == 0)
                    {
                        e.Health += damage;
                        attacker.Call("iprintlnbold", antinsmes);
                    }
                }
            base.OnPlayerDamage(e, inflictor, attacker, damage, dFlags, mod, weapon, point, dir, hitLoc);
        }
        public void NotifyHandle()
        {
            OnNotify("prematch_done", () =>
            {
                this._prematch = false;
            });
            base.OnNotify("player_spawned", delegate (Parameter param)
            {
                Entity player = (Entity)param;
                if (this.anticamp)
                {
                    this.AntiCamp(player);
                }
                if (this.antihs)
                {
                    this.AntiHS(player);
                }
                if (this.antins)
                {
                    this.AntiNoScope(player);
                }
            });
        }

        private void AntiNoScope(Entity player)
        {
            bool aimed = false;
            player.OnInterval(100, delegate (Entity ent)
            {
                if (this._prematch)
                {
                    return true;
                }
                if (ent.Call<int>("adsbuttonpressed", new Parameter[0]) > 0)
                {
                    aimed = true;
                }
                else
                {
                    aimed = false;
                }
                return this.PlayersIn.Contains(ent);
            });
            player.OnNotify("weapon_fired", delegate (Entity ent, Parameter wep)
            {
                if (ent.Call<int>("adsbuttonpressed", new Parameter[0]) == 0 && !aimed)
                {
                    int oldHealth = player.Health;
                    player.Health += 1000;
                    base.AfterDelay(50, delegate
                    {
                        player.Health = oldHealth;
                    });
                    ent.Call("iprintlnbold", antinsmes);
                }
            });
        }

        public void PlayerInit(Entity e)
        {
            e.SetField("isBlack", false);
            if (this.anticamp)
            {
                e.SetField("isUsing", false);
                e.OnNotify("use_hold", delegate (Entity ent)
                {
                    ent.SetField("isUsing", true);
                });
                e.OnNotify("done_using", delegate (Entity ent)
                {
                    ent.SetField("isUsing", false);
                });
                e.Call("notifyOnPlayerCommand", new Parameter[]
            {
               "chatP",
               "chatmodepublic"
            });
                e.Call("notifyOnPlayerCommand", new Parameter[]
            {
               "chatT",
               "chatmodeteam"
            });
                e.SetField("isTalkingT", false);
                e.SetField("isTalkingP", false);
                e.OnNotify("chatP", delegate (Entity entt)
                {
                    if (entt.GetField<int>("isTalkingP") == 0)
                    {
                        entt.SetField("isTalkingP", true);
                    }
                    base.AfterDelay(this.anticampchat, delegate
                    {
                        entt.SetField("isTalkingP", false);
                    });
                });
                e.OnNotify("chatT", delegate (Entity entt)
                {
                    if (entt.GetField<int>("isTalkingT") == 0)
                    {
                        entt.SetField("isTalkingT", true);
                    }
                    base.AfterDelay(this.anticampchat, delegate
                    {
                        entt.SetField("isTalkingT", false);
                    });
                });
            }
        }

        public void Write2Console(string message)
        {
            Log.Write(LogLevel.All, message);
        }
    }
}
