using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Dusts
{
    public class ProcellariteStarDust : ModDust
    {
        public override bool Update(Dust dust)
        {
            dust.velocity.X *= 0.9f;
            dust.velocity.Y *= 0.9f;
            dust.scale *= 0.975f;
            Lighting.AddLight(dust.position, 1, 0.9f, 0.45f);
            return true;
        }
    }
}