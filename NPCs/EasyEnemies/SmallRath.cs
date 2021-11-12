using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NimblesThrowingStuff.Projectiles.Enemy;
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.NPCs.EasyEnemies
{
    public class SmallRath : ModNPC
    {
        private Player player;
        private float speed;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Small Rathwyvern");
            Main.npcFrameCount[npc.type] = 10;
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 120;
            npc.damage = 30;
            npc.defense = 7;
            npc.knockBackResist = 0.7f;
            npc.width = 40;
            npc.height = 40;
            npc.value = 1200f;
            npc.lavaImmune = true;
            npc.onFire = false;
            npc.noGravity = true;
            npc.aiStyle = -1;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[31] = true;
            npc.scale = 1.1f;
            banner = npc.type;
            bannerItem = mod.ItemType("SmallRathBannerItem");
        }
        
        public override void AI()
        {
        
            Target();

            DespawnHandler();
            Move(new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101)));
            
            Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
        
            npc.ai[1]++;  
            if (npc.ai[1] % 40 == 0 && npc.ai[1] >= 180 && npc.ai[1] <= 230)
                {
                float Speed = 8f;
                int damage = 25;
                int type = ModContent.ProjectileType<RathFireball>();
                Main.PlaySound(mod.GetSoundSlot(SoundType.Custom, "Sounds/Custom/SmallRathFire"), (int)npc.position.X, (int)npc.position.Y);
                float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                }
            if (npc.ai[1] >= 240)
            {
                npc.ai[1] = 0;
            }
            npc.rotation = npc.velocity.X * 0.05f;
            
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.Underworld.Chance * 0.5f;
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
            speed = 5f;
            Vector2 moveTo = player.Center;
            Vector2 move = moveTo - npc.Center;
            float magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            float turnResistance = 1f;
            move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
            magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            npc.velocity = move;
            
        }
        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }
        public override bool CheckDead()
        {
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SmallRathHead"), 1f);
            for (int f = 0; f < 30; f++)
            {
                int rathDust = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width * 2, npc.height * 2, 6, 0f, 0f, 100, default(Color), 3f);
                Main.dust[rathDust].velocity *= 2f;
            }
            return true;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 200;
            npc.damage = 50;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            npc.frameCounter++;
            if (npc.ai[1] >= 180)
            {
            if (npc.frameCounter < 15) {
					npc.frame.Y = 4 * frameHeight;
				}
				else if (npc.frameCounter < 30) {
					npc.frame.Y = 5 * frameHeight;
				}
				else if (npc.frameCounter < 45) {
					npc.frame.Y = 6 * frameHeight;
				}
                else if (npc.frameCounter < 60) {
					npc.frame.Y = 7 * frameHeight;
				}
				else {
					npc.frameCounter = 0;
				}            
            }
            else
            {
                if (npc.frameCounter < 15)
                {
                    npc.frame.Y = 0 * frameHeight;
                }
                else if (npc.frameCounter < 30)
                {
                    npc.frame.Y = 1 * frameHeight;
                }
                else if (npc.frameCounter < 45)
                {
                    npc.frame.Y = 2 * frameHeight;
                }
                else if (npc.frameCounter < 60)
                {
                    npc.frame.Y = 3 * frameHeight;
                }
                else
                {
                    npc.frameCounter = 0;
                }
            }
        }
        public override void NPCLoot()
        {
            
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RedRathScale"), Main.rand.Next(1, 3));
        }
    }
}
