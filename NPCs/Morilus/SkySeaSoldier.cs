using Microsoft.Xna.Framework;
using NimblesThrowingStuff.Dusts;
using NimblesThrowingStuff.Projectiles.Enemy;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.NPCs.Morilus
{
    public class SkySeaSoldier : ModNPC
    {
        private Player player;
        private float speed;
        private Vector2 whereToOrbit;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Prankster of the Sky Sea");
            Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.width = 38;
			NPC.height = 38;
			NPC.aiStyle = -1;
			NPC.damage = 120;
			NPC.defense = 40;
			NPC.lifeMax = 750;
			NPC.HitSound = SoundID.NPCHit3;
			NPC.DeathSound = SoundID.NPCDeath3;
			NPC.knockBackResist = 0.5f;
        }
        public override void AI()
        {
            Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<ProcellariteStarDust>(), Main.rand.Next(-1, 2), Main.rand.Next(-1, 2), 0, default, Main.rand.NextFloat(0.5f, 1.5f));

            Target();

            DespawnHandler();
            Move(new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101)));

            Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width / 2), NPC.position.Y + (NPC.height / 2));

            NPC.ai[1]++;
            NPC.ai[2]++;
            if (NPC.ai[1] >= 120 && NPC.ai[1] <= 130)
            {
                int MoriAttack1 = Main.rand.Next(2);
                switch (MoriAttack1)
                {
                    case 0:
                        NPC.ai[1] = 140;
                        break;
                    case 1:
                        NPC.ai[1] = 230;
                        break;
                }
            }
            if (NPC.ai[1] >= 140 && NPC.ai[1] <= 220)
            {
                if (NPC.ai[1] % 20 == 0)
                {
                    float Speed1 = 11f;
                    int damage1 = 90;
                    int type1 = ModContent.ProjectileType<MorileShot>();
                    SoundEngine.PlaySound(SoundID.Item11, NPC.position);
                    float rotation1 = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(NPC.GetSource_FromThis(), vector8.X, vector8.Y, (float)((Math.Cos(rotation1) * Speed1) * -1) + Main.rand.Next(-3, 4), (float)((Math.Sin(rotation1) * Speed1) * -1) + Main.rand.Next(-3, 4), type1, damage1, 0f, 0);
                    if (NPC.ai[1] >= 200)
                    {
                        NPC.ai[1] = 0;
                    }
                }
                if (NPC.ai[1] >= 230 && NPC.ai[1] <= 310)
                {
                    if (NPC.ai[1] % 30 == 0)
                    {
                        float Speed1 = 10f;
                        int damage1 = 90;
                        int type1 = ModContent.ProjectileType<MorilusBolt>();
                        SoundEngine.PlaySound(SoundID.Item11, NPC.position);
                        float rotation1 = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(NPC.GetSource_FromThis(), vector8.X, vector8.Y, (float)((Math.Cos(rotation1) * Speed1) * -1) + Main.rand.Next(-3, 4), (float)((Math.Sin(rotation1) * Speed1) * -1) + Main.rand.Next(-3, 4), type1, damage1, 0f, 0);
                    }
                    if (NPC.ai[1] >= 290)
                    {
                        NPC.ai[1] = 0;
                    }
                }
            }
            if (NPC.ai[1] >= 330 || NPC.ai[1] <= -1)
            {
                NPC.ai[1] = 0;
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
            float bwingawee = NPC.lifeMax / 6;
            speed = 10f - (NPC.life / bwingawee);
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
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (NPC.downedMoonlord && spawnInfo.Player.ZoneSkyHeight)
			{
				return 0.35f;
			}
			return 0f;
		}
		public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;

                if (NPC.frameCounter < 20) {
					NPC.frame.Y = 0 * frameHeight;
				}
				else if (NPC.frameCounter < 30) {
					NPC.frame.Y = 1 * frameHeight;
				}
				else if (NPC.frameCounter < 50) {
					NPC.frame.Y = 2 * frameHeight;
				}
                else if (NPC.frameCounter < 60) {
					NPC.frame.Y = 3 * frameHeight;
				}
				else {
					NPC.frameCounter = 0;
				} 
        }
		public override void OnKill()
		{
            for (int io = 0; io < 25; io++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<ProcellariteStarDust>(), Main.rand.Next(-5, 6), Main.rand.Next(-5, 6), 0, default, Main.rand.NextFloat(0.5f, 1.5f));
            }
            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity.RotatedBy(MathHelper.ToRadians(90f)), Mod.Find<ModGore>("SkySeaPranksterGore2").Type, 1f);
			Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SkySeaPranksterGore1").Type, 1f);
			Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity * new Vector2(-1, -1), Mod.Find<ModGore>("SkySeaPranksterGore1").Type, 1f);
		}
	}
}