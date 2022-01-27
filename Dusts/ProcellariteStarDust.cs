using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Dusts
{
    public class ProcellariteStarDust : ModDust
    {
        public override bool Update(Dust dust)
        {
            Lighting.AddLight(dust.position, 1, 0.75f, 0.25f);
            return true;
        }
    }
}