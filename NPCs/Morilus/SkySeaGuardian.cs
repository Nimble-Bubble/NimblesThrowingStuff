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
            Main.npcFrameCount[npc.type] = 6;
        }
        public override void SetDefaults()
        {
            npc.width = 52;
            npc.height = 52;
            npc.damage = 150;
            npc.defense = 50;
            npc.lifeMax = 25000;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.value = 25000f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 23;
            aiType = 84;
            animationType = 84;
            npc.boss = true;
            music = MusicID.Boss4;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.75f * bossLifeScale);
            npc.damage = 225;
        }
    }
}
