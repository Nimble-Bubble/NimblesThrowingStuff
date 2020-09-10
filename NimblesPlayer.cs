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
using Terraria.Utilities;

namespace NimblesThrowingStuff
{
    public class NimblesPlayer : ModPlayer
    {
        public float thrownSpeed = 1f;
        
        public override void ResetEffects()
        {
         thrownSpeed = 1f;
        }
        
        public override float UseTimeMultiplier(Item item)
        {
            float speed = base.UseTimeMultiplier(item);

            if (item.thrown)
            {
                speed *= thrownSpeed;
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

            return speed;
        }
    }
}