using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class CrimtaneKnife : ModItem
	{

		public override void SetDefaults() 
		{
			item.damage = 22;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 1;
			item.knockBack = 6f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 0, 7, 50);
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("CrimtaneKnifeProj");
			item.shootSpeed = 10f;
            item.consumable = true;
            item.maxStack = 999;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneBar, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}