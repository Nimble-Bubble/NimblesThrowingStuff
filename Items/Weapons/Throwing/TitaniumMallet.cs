using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class TitaniumMallet : ModItem
	{

		public override void SetDefaults() 
		{
			item.damage = 46;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.knockBack = 6f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 0, 17, 0);
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("TitaniumMalletProj");
			item.shootSpeed = 12f;
            item.consumable = true;
            item.maxStack = 999;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(1198, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}