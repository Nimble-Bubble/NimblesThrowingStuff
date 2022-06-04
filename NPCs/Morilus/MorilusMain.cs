using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NimblesThrowingStuff.NPCs.Morilus;
using NimblesThrowingStuff.Projectiles.Enemy;
using NimblesThrowingStuff.Items.Consumables;
using NimblesThrowingStuff.Items.Vanity;
using NimblesThrowingStuff.Tiles.Blocks;

namespace NimblesThrowingStuff.NPCs.Morilus
{
    [AutoloadBossHead]
    public class MorilusMain : ModNPC
    {
        private Player player;
        private float speed;
        private int bigStarHealth;
        private bool sleepy;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Morilus, the Great Guardian of the Sky's Sea");
            //it's a pretty long name, but there's much more to this weird thing than that, believe me
            Main.npcFrameCount[NPC.type] = 5;
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 250000;
            NPC.damage = 140;
            NPC.defense = 80;
            NPC.knockBackResist = 0f;
            NPC.width = 100;
            NPC.height = 100;
            NPC.value = 1000000f;
            NPC.npcSlots = 5f;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.onFire = false;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.aiStyle = -1;
            NPC.HitSound = SoundID.NPCHit3;
            NPC.DeathSound = SoundID.NPCDeath3;
            music = MusicID.Boss4;
            NPC.buffImmune[31] = true;
            bossBag = ModContent.ItemType<MorilusTreasureBag>();
            NPC.scale = 1.3f;
        }
        
        public override void AI()
        {
        
            Target();

            DespawnHandler();
            if (!NPC.AnyNPCs(ModContent.NPCType<SkySeaGuardian>()))
        {
        sleepy = false;
                bigStarHealth = NPC.lifeMax / 4;
            Move(new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101)));
            
            Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width / 2), NPC.position.Y + (NPC.height / 2));
        
            NPC.ai[1]++;
            NPC.ai[2]++;
                if (NPC.life <= NPC.lifeMax / 20)
                {
                    if (NPC.ai[1] % 5 == 0)
                    {
                        int starRain = Projectile.NewProjectile(NPC.position.X + Main.rand.Next(-750, 751), NPC.position.Y - 750, Main.rand.Next(-10, 11), Main.rand.Next(5, 11), ProjectileID.FallingStar, 70, 1);
                        Main.projectile[starRain].friendly = false;
                        Main.projectile[starRain].hostile = true;
                        Main.projectile[starRain].timeLeft = 600;
                        Main.projectile[starRain].tileCollide = false;
                    }
                    if (NPC.ai[1] % 20 == 0 && Main.expertMode)
                    {
                        int bigStar2 = Projectile.NewProjectile(NPC.position.X, NPC.position.Y, Main.rand.Next(-5, 6), Main.rand.Next(-5, 6), ModContent.ProjectileType<MorilusBigStar>(), 100, 1);
                    }
                }
                if (Main.rand.NextBool(1000) && Main.expertMode)
                {
                    int zapOrb = Projectile.NewProjectile(NPC.position.X, NPC.position.Y, Main.rand.Next(-5, 6), Main.rand.Next(-5, 6), ProjectileID.CultistBossLightningOrb, 90, 1);
                }    
            if (NPC.ai[1] % 60 == 0 && NPC.ai[1] <= 120)
                {
                float Speed = 8f;
                int damage = 80;
                if (!Main.expertMode)
                {
                damage = 120;
                }
                int type = ModContent.ProjectileType<MorilusStream>();
                SoundEngine.PlaySound(2, (int)NPC.position.X, (int)NPC.position.Y, 11);
                float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                }
             if (NPC.ai[1] >= 120 && NPC.ai[1] <= 130)
             {
            if (NPC.life >= NPC.lifeMax / 2)
            {
                int MoriAttack1 = Main.rand.Next(3);
            switch(MoriAttack1)
            {
                case 0:
                NPC.ai[1] = 140;
                break;
                case 1:
                NPC.ai[1] = 230;
                break;
                case 2:
                NPC.ai[1] = 320;
                break;
            }
            }
            else
            {
            int MoriAttack2 = Main.rand.Next(4);
            switch(MoriAttack2)
            {
                case 0:
                NPC.ai[1] = 140;
                break;
                case 1:
                NPC.ai[1] = 230;
                break;
                case 2:
                NPC.ai[1] = 320;
                break;
                case 3:
                NPC.ai[1] = 450;
                break;
            }
            }
            }
            if (NPC.ai[1] >= 140 && NPC.ai[1] <= 220)
            {
                if (NPC.ai[1] % 30 == 0 && NPC.life >= NPC.lifeMax / 2 || NPC.ai[1] % 20 == 0 && NPC.life <= NPC.lifeMax / 2)
                {
                NPC.NewNPC((int)NPC.Center.X + 20, (int)NPC.Center.Y, ModContent.NPCType<SkySeaPrankster>());
                }
                if (NPC.ai[1] >= 200)
                {    
                NPC.ai[1] = 0;
                }
            }
            if (NPC.ai[1] >= 230 && NPC.ai[1] <= 310)
            {
                if (NPC.ai[1] % 30 == 0 && NPC.life >= NPC.lifeMax / 2 || NPC.ai[1] % 20 == 0)
                {
                float Speed1 = 10f;
                int damage1 = 70;
                if (!Main.expertMode)
                {
                damage1 = 100;
                }
                int type1 = ModContent.ProjectileType<MorilusBolt>();
                SoundEngine.PlaySound(2, (int)NPC.position.X, (int)NPC.position.Y, 11);
                float rotation1 = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                for (int spaldaedal = 0; spaldaedal < 15; spaldaedal++)
                {
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation1) * Speed1) * -1) + Main.rand.Next(-3, 4), (float)((Math.Sin(rotation1) * Speed1) * -1) + Main.rand.Next(-3, 4), type1, damage1, 0f, 0);
                }
                }
                if (NPC.ai[1] >= 290)
                {    
                NPC.ai[1] = 0;
                }
            }
            if (NPC.ai[1] >= 320 && NPC.ai[1] <= 400)
            {
                if (NPC.ai[1] % 6 == 0 && NPC.life >= NPC.lifeMax - bigStarHealth)
                {
                float Speed2 = 15f;
                int Damage2 = 80;
                if (!Main.expertMode)
                {
                Damage2 = 120;
                }
                int Type2 = ModContent.ProjectileType<MorilusBolt>();
                SoundEngine.PlaySound(2, (int)NPC.position.X, (int)NPC.position.Y, 11);
                float rotation2 = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num55 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation2) * Speed2) * -1), (float)((Math.Sin(rotation2) * Speed2) * -1), Type2, Damage2, 0f, 0);
                }
                if (NPC.life <= NPC.lifeMax - bigStarHealth)
                    {
                        int bigStar = Projectile.NewProjectile(NPC.position.X, NPC.position.Y, Main.rand.Next(-5, 6), Main.rand.Next(-5, 6), ModContent.ProjectileType<MorilusBigStar>(), 100, 1);
                        NPC.ai[1] = 0;
                    }
                if (NPC.ai[1] >= 380)
                {    
                NPC.ai[1] = 0;
                }
            }
            if (NPC.ai[1] >= 450 && NPC.ai[1] <= 800)
            {
            if (NPC.ai[1] % 2 == 0)
            {
            float Speed3 = 4f;
                int Damage3 = 70;
                if (!Main.expertMode)
                {
                Damage3 = 110;
                }
                int Type3 = ModContent.ProjectileType<MorilusRain>();
                int num55 = Projectile.NewProjectile(NPC.position.X + Main.rand.Next(-750, 751), NPC.position.Y - 750, 0, Speed3, Type3, Damage3, 0f, 0);
            }
            if (NPC.ai[1] >= 650 && NPC.life >= NPC.lifeMax / 4 || NPC.ai[1] >= 750)
            {
            NPC.ai[1] = 20;
            }

            }
            if (NPC.ai[2] == 300 && Main.rand.NextBool(2))
                {
                    NPC.ai[2] = 600;
                }
                if (NPC.ai[2] >= 300 && NPC.ai[2] <= 500)
                {
                    if (NPC.ai[2] % 120 == 0)
                    {
                        if (Main.rand.NextBool(2))
                        {
                            Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, 1, 0, Mod.Find<ModProjectile>("MorilusHorizontalWall").Type, 125, 10f);
                            Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, -1, 0, Mod.Find<ModProjectile>("MorilusHorizontalWall").Type, 125, 10f);
                        }
                        else
                        {
                            Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, 0, 1, Mod.Find<ModProjectile>("MorilusVerticalWall").Type, 125, 10f);
                            Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, 0, -1, Mod.Find<ModProjectile>("MorilusVerticalWall").Type, 125, 10f);
                        }
                    }
                    if (NPC.ai[2] == 400 && Main.rand.NextBool(3))
                    {
                        if (Main.expertMode)
                        {
                            NPC.ai[2] = Main.rand.Next(300, 360);
                        }
                        else
                        {
                            NPC.ai[2] = Main.rand.Next(90, 150);
                        }
                    }
                }
                if (NPC.ai[2] >= 500 && NPC.ai[2] <= 510)
                {
                    NPC.ai[2] = Main.rand.Next(0, 30);
                }
                if (NPC.ai[2] >= 610)
                {
                    NPC.ai[2] = 0;
                }
                NPC.dontTakeDamage = false;
            }
            else
            {
            NPC.dontTakeDamage = true;
            sleepy = true;
            }

        }

        private void Target()
        {
            player = Main.player[NPC.target];
        }
        private void DespawnHandler()
        {
            if (!player.active || player.dead)
            {
                NPC.TargetClosest(false);
                player = Main.player[NPC.target];
                if (!player.active || player.dead)
                {
                    NPC.velocity = new Vector2(0f, -10f);
                    if (NPC.timeLeft > 10)
                    {
                        NPC.timeLeft = 10;
                    }
                }
                return;
            }
        }
        private void Move(Vector2 offset)
        {
            float bwingawee = NPC.lifeMax / 4;
            if (!NPC.AnyNPCs(ModContent.NPCType<SkySeaGuardian>()))
            {
                speed = 8f - (NPC.life / bwingawee);
                NPC.defense = 80;
            }
            else
            {
                speed = 1f;
                NPC.defense = 1000;
            }
            Vector2 moveTo = player.Center;
            Vector2 move = moveTo - NPC.Center;
            float magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            float turnResistance = 10f;
            move = (NPC.velocity * turnResistance + move) / (turnResistance + 1f);
            magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            NPC.velocity = move;
            NPC.rotation = NPC.velocity.X * 0.05f;
        }
        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.75f * bossLifeScale);
            NPC.damage = 220;
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;
            if (!NPC.AnyNPCs(ModContent.NPCType<SkySeaGuardian>()))
            {
            if (NPC.frameCounter < 15) {
					NPC.frame.Y = 1 * frameHeight;
				}
				else if (NPC.frameCounter < 30) {
					NPC.frame.Y = 2 * frameHeight;
				}
				else if (NPC.frameCounter < 45) {
					NPC.frame.Y = 3 * frameHeight;
				}
                else if (NPC.frameCounter < 60) {
					NPC.frame.Y = 4 * frameHeight;
				}
				else {
					NPC.frameCounter = 0;
				}            
            }
            else
            {
                NPC.frame.Y = 0 * frameHeight;
            }
        }
        public override void OnKill()
        {
            Gore.NewGore(NPC.position, NPC.velocity, Mod.GetGoreSlot("Gores/MorilusGore1"), 1f);
            if (!NimblesWorld.downedMorilus)
            {
                Utilities.SpawnOre(ModContent.TileType<ProcellariteOreTile>(), 15E-05, .8f, .999f);
                NimblesWorld.downedMorilus = true;
                if (Main.netMode == NetmodeID.SinglePlayer)
                    Main.NewText("The underworld glows with the energy of a storm...", new Color(0, 171, 171));
                else if (Main.netMode == NetmodeID.Server)
                    ChatHelper.BroadcastChatMessage(NetworkText.FromKey("The underworld glows with the energy of a storm..."), new Color(0, 171, 171));
            }
            if(Main.expertMode)
            {
                NPC.DropBossBags();
            }
            else
            {
            if (Main.rand.NextBool(7))
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, Mod.Find<ModItem>("MorilusMask").Type);
                }
            if (Main.rand.NextBool(5))
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, Mod.Find<ModItem>("MorilusTrophy").Type);
                }
                int MorileLoot = Main.rand.Next(5);
            switch (MorileLoot)
            {
                case 0:
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, Mod.Find<ModItem>("SkyseaSpinner").Type);
                break;
                case 1:
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, Mod.Find<ModItem>("ProcellariteLongbow").Type);
                break;
                case 2:
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, Mod.Find<ModItem>("GuardianStaff").Type);
                break;
                case 3:
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, Mod.Find<ModItem>("StormShot").Type);
                break;
                case 4:
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, Mod.Find<ModItem>("LacusDecapitator").Type);
                break;
            }
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, Mod.Find<ModItem>("SoulOfTrite").Type, Main.rand.Next(15, 24));
            }
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 3544;
        }
    }
}
