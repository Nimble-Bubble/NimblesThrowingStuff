using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class SpikeKnife : ModItem
	{

		public override void SetDefaults() 
		{
			item.damage = 24;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 4.5f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 0, 1, 0);
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SpikeKnifeProj");
			item.shootSpeed = 9f;
            item.consumable = true;
            item.maxStack = 999;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(147, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 10);
			recipe.AddRecipe();
		}
	}
}