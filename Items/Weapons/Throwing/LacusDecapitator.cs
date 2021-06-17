using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Throwing;
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class LacusDecapitator : ModItem
	{

		public override void SetDefaults() 
		{
			item.damage = 280;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(1, 0, 0, 0);
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<LacusDecapitatorProj>();
			item.shootSpeed = 20f;
            item.mana = 21;
		}
	}
}