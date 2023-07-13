using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.NPCs.Morilus
{
    [AutoloadBossHead]
    public class SkySeaGuardian : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 6;
        }
        public override void SetDefaults()
        {
            NPC.width = 52;
            NPC.height = 52;
            NPC.damage = 150;
            NPC.defense = 50;
            NPC.lifeMax = 25000;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath14;
            NPC.value = 25000f;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = 23;
            AIType = 84;
            //AnimationType = 84;
            NPC.boss = true;
            Music = MusicID.Boss4;
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */
        {
            //NPC.lifeMax = (int)(NPC.lifeMax * 0.75f * bossLifeScale);
            NPC.damage = 225;
        }
    }
}
