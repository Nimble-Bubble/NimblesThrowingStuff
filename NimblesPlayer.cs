using System.Linq;  
using System;
using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using NimblesThrowingStuff.Buffs;
using Terraria.Utilities;

namespace NimblesThrowingStuff
{
    public class NimblesPlayer : ModPlayer
    {
        public float rangedSpeed = 1f;
        public float magicSpeed = 1f;
        public float thrownSpeed = 1f;
        public bool sacredWrist;
        public bool greek;
        public bool chloroThrow;
        
        public override void ResetEffects()
        {
         rangedSpeed = 1f;
         magicSpeed = 1f;
         thrownSpeed = 1f;
         sacredWrist = false;
        chloroThrow = false;
            greek = false;
        }
        public override void UpdateDead()
        {
            greek = false;
    }
        
        public override float UseTimeMultiplier(Item item)
        {
            float speed = base.UseTimeMultiplier(item);

            if (item.thrown)
            {
                speed *= thrownSpeed;
            }
            if (item.ranged)
            {
                speed *= rangedSpeed;
            }
            if (item.magic || item.summon)
            {
                speed *= magicSpeed;
            }

            return speed;
        }
        public override float MeleeSpeedMultiplier(Item item)
        {
            float speed = base.MeleeSpeedMultiplier(item);

            if (item.thrown)
            {
                speed *= thrownSpeed;
            }
            if (item.ranged)
            {
                speed *= rangedSpeed;
            }
            if (item.magic || item.summon)
            {
                speed *= magicSpeed;
            }

            return speed;
        }
        public override void UpdateBadLifeRegen()
		{
			if (greek)
			{
				// These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects.
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				// lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 25 life lost per second. Ouch.
				player.lifeRegen -= 50;
			}
        }
    }
}