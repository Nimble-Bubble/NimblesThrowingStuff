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
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;

namespace NimblesThrowingStuff.NPCs.EasyEnemies
{
    public class SmallRathwyvern : ModNPC
    {
        private Player player;
        private float speed;
        SoundStyle SmallRathHurtNoise = new SoundStyle("NimblesThrowingStuff/Sounds/NPCHit/SmallRathHurt");
        SoundStyle SmallRathKillNoise = new SoundStyle("NimblesThrowingStuff/Sounds/NPCKilled/SmallRathKill");
        SoundStyle SmallRathFireNoise = new SoundStyle("NimblesThrowingStuff/Sounds/Item/SmallRathFire");
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 10;
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 80;
            NPC.damage = 30;
            NPC.defense = 7;
            NPC.knockBackResist = 0.5f;
            NPC.width = 40;
            NPC.height = 40;
            NPC.value = 800f;
            NPC.lavaImmune = true;
            NPC.onFire = false;
            NPC.noGravity = true;
            NPC.aiStyle = -1;
            NPC.HitSound = SmallRathHurtNoise;
            NPC.DeathSound = SmallRathKillNoise;
            NPC.buffImmune[31] = true;
            NPC.scale = 1f;
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
                SoundEngine.PlaySound(SmallRathFireNoise);    
                float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));

                if (NPC.velocity.X > 0)
                {
                    int num54 = Projectile.NewProjectile(NPC.GetSource_FromThis(), vector8.X + 18, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                }
                else
                {
                    int num54 = Projectile.NewProjectile(NPC.GetSource_FromThis(), vector8.X - 18, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
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
            return true;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.Underworld.Chance * 0.5f;
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
            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SmallRathHead").Type, 1f);
            for (int f = 0; f < 30; f++)
            {
                int rathDust = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width * 2, NPC.height * 2, 6, 0f, 0f, 100, default(Color), 3f);
                Main.dust[rathDust].velocity *= 2f;
            }
            return true;
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */
        {
            NPC.lifeMax = 120;
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
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("RedRathScale").Type, 1, 1, 2));
            npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("BeastBone").Type, 2));
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld,
                new FlavorTextBestiaryInfoElement("These small flying wyverns will one day grow up to be fierce apex predators, but they are minor threats in this stage of life.")
            });
        }
    }
}
