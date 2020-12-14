using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class PlatinumKnife : ModItem
	{

		public override void SetDefaults() 
		{
			item.damage = 15;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = 1;
			item.knockBack = 4.5f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 0, 5, 0);
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("PlatinumKnifeProj");
			item.shootSpeed = 9f;
            item.consumable = true;
            item.maxStack = 999;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlatinumBar, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}