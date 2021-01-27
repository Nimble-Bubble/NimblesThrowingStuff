using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NimblesThrowingStuff.NPCs.Morilus
{
    [AutoloadBossHead]
    public class MorilusMain : ModNPC
    {
        private Player player;
        private float speed;
        private bool sleepy;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Morilus, the Great Guardian of the Sky's Sea");
            //it's a pretty long name, but there's much more to this weird thing than that, believe me
            Main.npcFrameCount[npc.type] = 5;
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 300000;
            npc.damage = 160;
            npc.defense = 80;
            npc.knockBackResist = 0f;
            npc.width = 100;
            npc.height = 100;
            npc.value = 1000000f;
            npc.npcSlots = 5f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.onFire = false;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.aiStyle = -1;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath3;
            music = MusicID.Boss4;
            npc.buffImmune[31] = true;
            bossBag = mod.ItemType("MorilusTreasureBag");
            npc.scale = 1.3f;
        }
        
        public override void AI()
        {
        
            Target();

            DespawnHandler();
            if (!NPC.AnyNPCs(mod.NPCType("SkySeaGuardian")))
        {
        sleepy = false;
            Move(new Vector2(0, 0f));
            
            Vector2 vector8 = new Vector2(npc.position.X + (npc.width), npc.position.Y + (npc.height / 2));
        
            npc.ai[1]++;
            if (npc.ai[1] % 60 == 0 && npc.ai[1] <= 120)
                {
                float Speed = 8f;
                int damage = 120;
                if (Main.expertMode)
                {
                damage = 100;
                }
                int type = mod.ProjectileType("MorilusStream");
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 11);
                float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                }
             if (npc.ai[1] >= 120 && npc.ai[1] <= 130)
             {
            if (npc.life >= npc.lifeMax / 2)
            {
                int MoriAttack1 = Main.rand.Next(3);
            switch(MoriAttack1)
            {
                case 0:
                npc.ai[1] = 140;
                break;
                case 1:
                npc.ai[1] = 230;
                break;
                case 2:
                npc.ai[1] = 320;
                break;
            }
            }
            else
            {
            int MoriAttack2 = Main.rand.Next(4);
            switch(MoriAttack2)
            {
                case 0:
                npc.ai[1] = 140;
                break;
                case 1:
                npc.ai[1] = 230;
                break;
                case 2:
                npc.ai[1] = 320;
                break;
                case 3:
                npc.ai[1] = 450;
                break;
            }
            }
            }
            if (npc.ai[1] >= 140 && npc.ai[1] <= 220)
            {
                if (npc.ai[1] % 30 == 0 && npc.life >= npc.lifeMax / 2 || npc.ai[1] % 20 == 0 && npc.life <= npc.lifeMax / 2)
                {
                NPC.NewNPC((int)npc.Center.X + 20, (int)npc.Center.Y, mod.NPCType("SkySeaPrankster"));
                }
                if (npc.ai[1] >= 200)
                {    
                npc.ai[1] = 0;
                }
            }
            if (npc.ai[1] >= 230 && npc.ai[1] <= 310)
            {
                if (npc.ai[1] % 40 == 0 && npc.life >= npc.lifeMax / 2 || npc.ai[1] % 20 == 0)
                {
                float Speed1 = 12f;
                
                int damage1 = 135;
                if (Main.expertMode)
                {
                damage1 = 95;
                }
                int type1 = mod.ProjectileType("MorilusBolt");
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 11);
                float rotation1 = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation1) * Speed1) * -1), (float)((Math.Sin(rotation1) * Speed1) * -1), type1, damage1, 0f, 0);
                }
                if (npc.ai[1] >= 290)
                {    
                npc.ai[1] = 0;
                }
            }
            if (npc.ai[1] >= 320 && npc.ai[1] <= 400)
            {
                if (npc.ai[1] % 84 == 0)
                {
                float Speed2 = 12f;
                int Damage2 = 130;
                if (Main.expertMode)
                {
                Damage2 = 90;
                }
                int Type2 = mod.ProjectileType("MorilusBolt");
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 11);
                float rotation2 = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num55 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation2) * Speed2) * -1), (float)((Math.Sin(rotation2) * Speed2) * -1), Type2, Damage2, 0f, 0);
                }
                if (npc.ai[1] >= 380)
                {    
                npc.ai[1] = 0;
                }
            }
            if (npc.ai[1] >= 450 && npc.ai[1] <= 800)
            {
            if (npc.ai[1] % 3 == 0)
            {
            float Speed3 = 1f;
                int Damage3 = 130;
                if (Main.expertMode)
                {
                Damage3 = 90;
                }
                int Type3 = mod.ProjectileType("MorilusRain");
                int num55 = Projectile.NewProjectile(npc.position.X + Main.rand.Next(-750, 751), npc.position.Y - 500, 0, Speed3, Type3, Damage3, 0f, 0);
            }
            if (npc.ai[1] >= 650 && npc.life >= npc.lifeMax / 4 || npc.ai[1] >= 750)
            {
            npc.ai[1] = 20;
            }
            }
            npc.takenDamageMultiplier = 1f;
            }
            else
            {
            npc.takenDamageMultiplier = 0.01f;
            sleepy = true;
            }
        }

        private void Target()
        {
            player = Main.player[npc.target];
        }
        private void DespawnHandler()
        {
            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                if (!player.active || player.dead)
                {
                    npc.velocity = new Vector2(0f, -10f);
                    if (npc.timeLeft > 10)
                    {
                        npc.timeLeft = 10;
                    }
                }
                return;
            }
        }
        private void Move(Vector2 offset)
        {
            float bwingawee = npc.lifeMax / 4;
            speed = 8f - (npc.life / bwingawee);
            Vector2 moveTo = player.Center;
            Vector2 move = moveTo - npc.Center;
            float magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            float turnResistance = 10f;
            move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
            magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            npc.velocity = move;
            npc.rotation = npc.velocity.X * 0.05f;
        }
        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.75f * bossLifeScale);
            npc.damage = 240;
            npc.defense = (int)(npc.defense);
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
            if (!NPC.AnyNPCs(mod.NPCType("SkySeaGuardian")))
            {
            if (npc.frameCounter < 15) {
					npc.frame.Y = 1 * frameHeight;
				}
				else if (npc.frameCounter < 30) {
					npc.frame.Y = 2 * frameHeight;
				}
				else if (npc.frameCounter < 45) {
					npc.frame.Y = 3 * frameHeight;
				}
                else if (npc.frameCounter < 60) {
					npc.frame.Y = 4 * frameHeight;
				}
				else {
					npc.frameCounter = 0;
				}            
            }
            else
            {
                npc.frame.Y = 0 * frameHeight;
            }
        }
        public override void NPCLoot()
        {
            if(Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                int MorileLoot = Main.rand.Next(5);
            switch (MorileLoot)
            {
                case 0:
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ProcellariteOre"));
                break;
                case 1:
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ProcellariteOre"));
                break;
                case 2:
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ProcellariteOre"));
                break;
                case 3:
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ProcellariteOre"));
                break;
                case 4:
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ProcellariteOre"));
                break;
            }
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ChlorophyteBar, Main.rand.Next(15, 24));
            }
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 3544;
        }
    }
}
