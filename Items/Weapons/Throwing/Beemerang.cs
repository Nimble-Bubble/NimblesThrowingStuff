using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class Beemerang : ModItem
	{

		public override void SetDefaults() 
		{
			item.damage = 26;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 6.5f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("BeemerangProj");
			item.shootSpeed = 13.5f;
            item.mana = 12;
		}
	}
}