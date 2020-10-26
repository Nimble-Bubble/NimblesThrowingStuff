using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class MartianMiracle : ModItem
	{

		public override void SetDefaults() 
		{
			item.damage = 72;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 8f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 75, 0, 0);
			item.rare = 9;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("MartianMiracleProj");
			item.shootSpeed = 25f;
            item.mana = 60;
            item.channel = true;
		}
	}
}