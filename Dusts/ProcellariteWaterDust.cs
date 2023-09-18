using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Dusts
{
    public class ProcellariteWaterDust : ModDust
    {
        public override bool Update(Dust dust)
        {
            dust.velocity.X *= 0.9f;
            dust.velocity.Y *= 0.9f;
            dust.scale *= 0.95f;
            Lighting.AddLight(dust.position, 0, 0.5f, 1);
            return true;
        }
    }
}