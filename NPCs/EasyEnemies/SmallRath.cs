using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
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
        private int bararata;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Small Rathwyvern");
            Main.npcFrameCount[NPC.type] = 10;
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 120;
            NPC.damage = 30;
            NPC.defense = 7;
            NPC.knockBackResist = 0.7f;
            NPC.width = 40;
            NPC.height = 40;
            NPC.value = 1200f;
            NPC.lavaImmune = true;
            NPC.onFire = false;
            NPC.noGravity = true;
            NPC.aiStyle = -1;
            NPC.HitSound = SoundEngine.PlaySound(new SoundStyle("Sounds/NPCHit/SmallRathHurt"));
            NPC.DeathSound = SoundEngine.PlaySound(new SoundStyle("Sounds/NPCKilled/SmallRathKill"));
            NPC.buffImmune[31] = true;
            NPC.scale = 1.1f;
            Banner = NPC.type;
            BannerItem = Mod.Find<ModItem>("SmallRathBannerItem").Type;
        }
        
        public override void AI()
        {
        
            Target();

            DespawnHandler();
            Move(new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101)));
            
            Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width / 2), NPC.position.Y + (NPC.height / 2));
        
            NPC.ai[1]++;  
            if (NPC.ai[1] % 40 == 0 && NPC.ai[1] >= 180 && NPC.ai[1] <= 230)
                {
                float Speed = 8f;
                int damage = 25;
                int type = ModContent.ProjectileType<RathFireball>();
                SoundEngine.PlaySound(new SoundStyle("Sounds/Item/SmallRathFire"));    
                float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));

                if (NPC.velocity.X > 0)
                {
                    bararata = 18;
                    int num54 = Projectile.NewProjectile(vector8.X + bararata, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                }
                else
                {
                    bararata = -18;
                    int num54 = Projectile.NewProjectile(vector8.X + bararata, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                }
                }
            if (NPC.ai[1] >= 240)
            {
                NPC.ai[1] = 0;
            }
            NPC.rotation = NPC.velocity.X * 0.05f;
            
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            //SpriteEffects effects = npc.spriteDirection > 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            return true;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.Underworld.Chance * 0.375f;
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
            speed = 5f;
            Vector2 moveTo = player.Center;
            Vector2 move = moveTo - NPC.Center;
            float magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            float turnResistance = 1f;
            move = (NPC.velocity * turnResistance + move) / (turnResistance + 1f);
            magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            NPC.velocity = move;
            if (NPC.velocity.X > 0)
            {
                NPC.direction = 1;
            }
            else
            {
                NPC.direction = -1;
            }
            
        }
        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }
        public override bool CheckDead()
        {
            Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Gores/SmallRathHead").Type, 1f);
            for (int f = 0; f < 30; f++)
            {
                int rathDust = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width * 2, NPC.height * 2, 6, 0f, 0f, 100, default(Color), 3f);
                Main.dust[rathDust].velocity *= 2f;
            }
            return true;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = 200;
            NPC.damage = 50;
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.spriteDirection = NPC.direction;
            NPC.frameCounter++;
            if (NPC.ai[1] >= 180)
            {
            if (NPC.frameCounter < 15) {
					NPC.frame.Y = 4 * frameHeight;
				}
				else if (NPC.frameCounter < 30) {
					NPC.frame.Y = 5 * frameHeight;
				}
				else if (NPC.frameCounter < 45) {
					NPC.frame.Y = 6 * frameHeight;
				}
                else if (NPC.frameCounter < 60) {
					NPC.frame.Y = 7 * frameHeight;
				}
				else {
					NPC.frameCounter = 0;
				}            
            }
            else
            {
                if (NPC.frameCounter < 15)
                {
                    NPC.frame.Y = 0 * frameHeight;
                }
                else if (NPC.frameCounter < 30)
                {
                    NPC.frame.Y = 1 * frameHeight;
                }
                else if (NPC.frameCounter < 45)
                {
                    NPC.frame.Y = 2 * frameHeight;
                }
                else if (NPC.frameCounter < 60)
                {
                    NPC.frame.Y = 3 * frameHeight;
                }
                else
                {
                    NPC.frameCounter = 0;
                }
            }
        }
        public override void OnKill()
        {
            
            Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, Mod.Find<ModItem>("RedRathScale").Type, Main.rand.Next(1, 3));
        }
    }
}
