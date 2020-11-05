using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class ShadowflameSpikeBall : ModItem
	{
		public override void SetDefaults() 
		{
			item.damage = 38;
			item.thrown = true;
			item.width = 34;
			item.height = 34;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 1f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 0, 12, 50);
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ShadowflameSpikeBallProj");
			item.shootSpeed = 6f;
            item.consumable = true;
            item.maxStack = 999;
		}
	}
}