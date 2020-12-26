using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class MoltenKnife : ModItem
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
			item.knockBack = 6f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 0, 8, 0);
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("MoltenKnifeProj");
			item.shootSpeed = 11f;
            item.consumable = true;
            item.maxStack = 999;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}