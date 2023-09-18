using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Dusts
{
    public class ProcellariteBrightWaterDust : ModDust
    {
        public override bool Update(Dust dust)
        {
            dust.velocity.X *= 0.8f;
            dust.velocity.Y *= 0.8f;
            dust.scale *= 0.95f;
            Lighting.AddLight(dust.position, 0.6f, 1.2f, 1.5f);
            return true;
        }
    }
}