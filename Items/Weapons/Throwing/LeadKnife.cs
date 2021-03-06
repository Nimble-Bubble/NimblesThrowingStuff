using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class LeadKnife : ModItem
	{

		public override void SetDefaults() 
		{
			item.damage = 11;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 3.5f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 0, 3, 0);
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("LeadKnifeProj");
			item.shootSpeed = 7f;
            item.consumable = true;
            item.maxStack = 999;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LeadBar, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}