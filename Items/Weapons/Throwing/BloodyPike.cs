using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Throwing;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class BloodyPike : ModItem
	{
        public override void SetStaticDefaults()
        {
         Tooltip.SetDefault("Turns into a stream of ichor");   
        }

		public override void SetDefaults() 
		{
			item.damage = 42;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 5f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 18, 75, 0);
			item.rare = 6;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<BloodyPikeProj>();
			item.shootSpeed = 9f;
            item.mana = 12;
		}
	}
}