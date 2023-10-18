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
using Terraria.ModLoader.Utilities;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NimblesThrowingStuff.NPCs.Morilus;
using NimblesThrowingStuff.Projectiles.Enemy;
using NimblesThrowingStuff.Items.Consumables;
using NimblesThrowingStuff.Items.Vanity;
using NimblesThrowingStuff.Tiles.Blocks;
using NimblesThrowingStuff.Items.Weapons.Melee;
using NimblesThrowingStuff.Items.Weapons.Ranged;
using NimblesThrowingStuff.Items.Weapons.Magic;
using NimblesThrowingStuff.Items.Weapons.Summoning;
using NimblesThrowingStuff.Items.Weapons.Throwing;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using NimblesThrowingStuff.Dusts;

namespace NimblesThrowingStuff.NPCs.Morilus
{
    [AutoloadBossHead]
    public class MorilusMain : ModNPC
    {
        private Player player;
        private float speed;
        private int boost;
        private int bigStarHealth;
        private Vector2 whereToOrbit;
        private bool sleepy;
        private bool doFunkyAnimationThing;
        private bool moveNormally;
        private bool hasDropped;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Morilus, the Great Guardian of the Sky's Sea");
            Main.npcFrameCount[NPC.type] = 5;
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 250000;
            NPC.damage = 150;
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
            Music = MusicID.Boss4;
            NPC.buffImmune[31] = true;
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
                if (moveNormally)
                {
                    Move(new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101)));
                }
            
            Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width / 2), NPC.position.Y + (NPC.height / 2));
        
            NPC.ai[1]++;
            NPC.ai[2]++;
            NPC.ai[3]++;
                if (NPC.life <= NPC.lifeMax / 20)
                {
                    if (NPC.ai[1] % 5 == 0)
                    {
                        int starRain = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X + Main.rand.Next(-750, 751), NPC.position.Y - 750, Main.rand.Next(-10, 11), Main.rand.Next(5, 11), ProjectileID.FallingStar, 70, 1);
                        Main.projectile[starRain].friendly = false;
                        Main.projectile[starRain].hostile = true;
                        Main.projectile[starRain].timeLeft = 600;
                        Main.projectile[starRain].tileCollide = false;
                    }
                    if (NPC.ai[1] % 20 == 0 && Main.expertMode)
                    {
                        int bigStar2 = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X, NPC.position.Y, Main.rand.Next(-5, 6), Main.rand.Next(-5, 6), ModContent.ProjectileType<MorilusBigStar>(), 100, 1);
                    }
                }
                if (Main.rand.NextBool(1000) && Main.expertMode)
                {
                    int zapOrb = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X, NPC.position.Y, Main.rand.Next(-5, 6), Main.rand.Next(-5, 6), ProjectileID.CultistBossLightningOrb, 90, 1);
                }    
            if (NPC.ai[1] % 60 == 0 && NPC.ai[1] <= 120)
                {
                float Speed = 8f;
                int damage = 80;
                if (!Main.expertMode)
                {
                damage = 120;
                }
                int type = ModContent.ProjectileType<MorilusBolt>();
                SoundEngine.PlaySound(SoundID.Item11, NPC.position);
                float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num54 = Projectile.NewProjectile(NPC.GetSource_FromThis(), vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                if (Main.rand.NextBool(4) && NPC.life >= NPC.lifeMax / 2 || NPC.life <= NPC.lifeMax / 2)
                    {
                        int num54b = Projectile.NewProjectile(NPC.GetSource_FromThis(), vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                        Main.projectile[num54b].velocity.RotatedBy(MathHelper.ToDegrees(20));
                        int num54c = Projectile.NewProjectile(NPC.GetSource_FromThis(), vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                        Main.projectile[num54c].velocity.RotatedBy(MathHelper.ToDegrees(-20));
                    }
                }
             if (NPC.ai[1] >= 120 && NPC.ai[1] <= 130)
             {
                    if (Main.rand.NextBool(6) && NPC.ai[2] < 1200)
                        {
                        NPC.ai[2] = 1350;
                    }
                    hasDropped = false;
            if (NPC.life >= NPC.lifeMax / 2)
            {
                        if (Main.rand.NextBool(4) && NPC.ai[3] <= 4950)
                        {
                            NPC.ai[3] = Main.rand.Next(4950, 5250);
                        }
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
                if (NPC.ai[1] % 30 == 0 && !hasDropped || NPC.ai[1] % 30 == 0 && NPC.life <= NPC.lifeMax / 2)
                {
                NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X + 20, (int)NPC.Center.Y, ModContent.NPCType<SkySeaSoldier>());
                        hasDropped = true;
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
                float Speed1 = 8.5f;
                int damage1 = 70;
                if (!Main.expertMode)
                {
                damage1 = 100;
                }
                int type1 = ModContent.ProjectileType<MorilusBolt>();
                SoundEngine.PlaySound(SoundID.Item11, NPC.position);
                float rotation1 = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                        if (!Main.expertMode)
                        {
                            for (int spaldaedal = 0 + Main.rand.Next(6); spaldaedal < 10; spaldaedal++)
                            {
                                int num54 = Projectile.NewProjectile(NPC.GetSource_FromThis(), vector8.X, vector8.Y, (float)((Math.Cos(rotation1) * Speed1) * -1) + Main.rand.Next(-3, 4), (float)((Math.Sin(rotation1) * Speed1) * -1) + Main.rand.Next(-3, 4), type1, damage1, 0f, 0);
                            }
                        }
                        else
                        {
                            for (int spaldaedal = 0; spaldaedal < 15; spaldaedal++)
                            {
                                int num54 = Projectile.NewProjectile(NPC.GetSource_FromThis(), vector8.X, vector8.Y, (float)((Math.Cos(rotation1) * Speed1) * -1) + Main.rand.Next(-3, 4), (float)((Math.Sin(rotation1) * Speed1) * -1) + Main.rand.Next(-3, 4), type1, damage1, 0f, 0);
                            }
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
                float Speed2 = 12f;
                int Damage2 = 80;
                if (!Main.expertMode)
                {
                Damage2 = 120;
                }
                int Type2 = ModContent.ProjectileType<MorilusBolt>();
                SoundEngine.PlaySound(SoundID.Item11, NPC.position);
                float rotation2 = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num55 = Projectile.NewProjectile(NPC.GetSource_FromThis(), vector8.X, vector8.Y, (float)((Math.Cos(rotation2) * Speed2) * -1), (float)((Math.Sin(rotation2) * Speed2) * -1), Type2, Damage2, 0f, 0);
                }
                if (NPC.life <= NPC.lifeMax - bigStarHealth)
                    {
                        int bigStar = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X, NPC.position.Y, Main.rand.Next(-5, 6), Main.rand.Next(-5, 6), ModContent.ProjectileType<MorilusBigStar>(), 100, 1);
                        NPC.ai[1] = 0;
                    }
                if (NPC.ai[1] >= 380)
                {    
                NPC.ai[1] = 0;
                }
            }
            if (NPC.ai[1] >= 450 && NPC.ai[1] <= 800)
            {
            if (NPC.ai[1] % 3 == 0)
            {
            float Speed3 = 4f;
                int Damage3 = 70;
                if (!Main.expertMode)
                {
                Damage3 = 110;
                }
                int Type3 = ModContent.ProjectileType<MorilusRain>();
                int num55 = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X + Main.rand.Next(-1000, 1001), NPC.position.Y - 750, Main.rand.NextFloat(-2.5f, 2.5f), 1f, Type3, Damage3, 0f, 0);
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
                            Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X, NPC.Center.Y, 1, 0, Mod.Find<ModProjectile>("MorilusHorizontalWall").Type, 125, 10f);
                            Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X, NPC.Center.Y, -1, 0, Mod.Find<ModProjectile>("MorilusHorizontalWall").Type, 125, 10f);
                        }
                        else
                        {
                            Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X, NPC.Center.Y, 0, 1, Mod.Find<ModProjectile>("MorilusVerticalWall").Type, 125, 10f);
                            Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X, NPC.Center.Y, 0, -1, Mod.Find<ModProjectile>("MorilusVerticalWall").Type, 125, 10f);
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
                if (NPC.ai[2] >= 610 && NPC.ai[2] < 1200)
                {
                    NPC.ai[2] = 0;
                }
                if (NPC.ai[2] >= 1200 && NPC.ai[2] <= 1500)
                {
                    NPC.velocity *= new Vector2(0.5f, 0.5f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<ProcellariteStarDust>(), Main.rand.Next(-2, 1), Main.rand.Next(-2, 1), 0, default, Main.rand.NextFloat(0.5f, 1.5f));
                }
                if (NPC.ai[2] >= 1500 && NPC.ai[2] <= 2400)
                {
                    if (NPC.ai[2] % 60 == 0 && Main.rand.NextBool(10) && NPC.ai[3] < 5400)
                    {
                        if (Main.rand.NextBool(2))
                        {
                            NPC.ai[3] = 7200;
                        }
                        else
                        {
                            NPC.ai[3] = 5400;
                        }
                    }
                    NPC.knockBackResist = 0.2f;
                    boost = 4;
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<ProcellariteStarDust>(), Main.rand.Next(-2, 1), Main.rand.Next(-2, 1), 0, default, Main.rand.NextFloat(0.5f, 1.5f));
                }
                if (NPC.ai[2] < 1500)
                {
                    NPC.knockBackResist = 0f;
                    boost = 0;
                }
                if (NPC.ai[2] > 2400)
                {
                    NPC.knockBackResist = 0f;
                    boost = 0;
                    for (int s = 0; s < 20; s++)
                    {
                        int smokeIndex = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, DustID.Cloud, 0f, 0f, 100, default(Color), 2f);
                        Main.dust[smokeIndex].velocity *= 1.4f;
                    }
                    NPC.ai[2] = 0;
                }

                    if (NPC.ai[3] >= 4950 && NPC.ai[3] <= 9000)
                    {
                        moveNormally = false;
                        if (NPC.ai[3] >= 4950 && NPC.ai[3] <= 5400)
                        {
                            whereToOrbit = new Vector2(0, -400);
                            Move(whereToOrbit);
                        }
                        if (NPC.ai[3] >= 5400 && NPC.ai[3] <= 7200)
                        {
                            Move(whereToOrbit);
                            if (Main.expertMode)
                            {
                            whereToOrbit.RotatedBy(MathHelper.ToRadians(0.75f));
                            }
                            else
                            {
                                whereToOrbit.RotatedBy(MathHelper.ToRadians(0.5f));
                            }
                            if (NPC.ai[3] >= 6000 && Main.rand.NextBool(2))
                            {
                                NPC.ai[3] += Main.rand.Next(1200, 4200);
                            }
                        }
                        if (NPC.ai[3] >= 7200 && NPC.ai[3] <= 9000)
                        {
                            Move(whereToOrbit);
                            if (Main.expertMode)
                            {
                                whereToOrbit.RotatedBy(MathHelper.ToRadians(-0.75f));
                            }
                            else
                            {
                                whereToOrbit.RotatedBy(MathHelper.ToRadians(-0.5f));
                            }
                            if (NPC.ai[3] >= 6000 && Main.rand.NextBool(2))
                            {
                                NPC.ai[3] += Main.rand.Next(1200, 4200);
                            }
                        }
                    }
                    if (NPC.ai[3] <= 4949 || NPC.ai[3] >= 9000)
                    {
                        moveNormally = true;
                        if (NPC.ai[3] >= 9000)
                        {
                            NPC.ai[3] = Main.rand.Next(0, 4800);
                        }
                    }
                NPC.dontTakeDamage = false;
            }
            else
            {
            NPC.dontTakeDamage = true;
            NPC.damage = 0;
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
            float addspeedwhenlow = NPC.position.Y / 25000;
            float enoughinposition = addspeedwhenlow - 1;
            if (enoughinposition < 0)
            {
                enoughinposition = 0;
            }
            float bwingawee = NPC.lifeMax / 4;
            if (!NPC.AnyNPCs(ModContent.NPCType<SkySeaGuardian>()))
            {
                speed = 8f + boost + enoughinposition - (NPC.life / bwingawee);
                NPC.defense = 80;
            }
            else
            {
                speed = 1f;
                NPC.defense = 1000;
            }
            Vector2 moveTo = player.Center + offset;
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

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.75f * balance);
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
            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity.RotatedByRandom(MathHelper.ToRadians(360)), Mod.Find<ModGore>("MorilusGore1").Type, 1f);
            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity.RotatedByRandom(MathHelper.ToRadians(360)), Mod.Find<ModGore>("MorilusGore2").Type, 1f);
            if (!NimblesWorld.downedMorilus)
            {
                NPC.SetEventFlagCleared(ref NimblesWorld.downedMorilus, -1);
                Utilities.SpawnOre(ModContent.TileType<ProcellariteOreTile>(), 15E-05, .8f, .999f);
                Utilities.SpawnOre(ModContent.TileType<ProcellariteOreTile>(), 15E-04, 0f, .1f);
                if (Main.netMode == NetmodeID.SinglePlayer)
                    Main.NewText("The clouds glow with the energy of a hellish storm...", new Color(0, 171, 171));
                else if (Main.netMode == NetmodeID.Server)
                    ChatHelper.BroadcastChatMessage(NetworkText.FromKey("The clouds glow with the energy of a hellish storm..."), new Color(0, 171, 171));
            }
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky,
                new FlavorTextBestiaryInfoElement("This strange ocular automaton serves as the protector of a place called the Sky-Sea.")
            });
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<MorilusTreasureBag>()));
            LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<MorilusMask>(), 7));
            notExpertRule.OnSuccess(ItemDropRule.Common(Mod.Find<ModItem>("MorilusTrophy").Type, 5));
            notExpertRule.OnSuccess(ItemDropRule.Common(Mod.Find<ModItem>("CarpatusDefender").Type, 4));
            notExpertRule.OnSuccess(ItemDropRule.OneFromOptions(1, Mod.Find<ModItem>("SkyseaSpinner").Type, Mod.Find<ModItem>("ProcellariteLongbow").Type, Mod.Find<ModItem>("GuardianStaff").Type, Mod.Find<ModItem>("StormShot").Type, Mod.Find<ModItem>("LacusDecapitator").Type));
            //notExpertRule.OnSuccess(ItemDropRule.OneFromOptions(2, ModContent.ItemType<SkyseaSpinner>(), ModContent.ItemType<ProcellariteLongbow>(), ModContent.ItemType<StormShot>(), ModContent.ItemType<GuardianStaff>(), ModContent.ItemType<LacusDecapitator>()));
            notExpertRule.OnSuccess(ItemDropRule.Common(Mod.Find<ModItem>("SoulOfTrite").Type, 1, 12, 20));
            npcLoot.Add(notExpertRule);
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 3544;
        }
    }
}
