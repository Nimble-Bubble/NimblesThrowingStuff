using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class TrueNightPiercer : ModItem
	{
        public override void SetStaticDefaults()
        {
        DisplayName.SetDefault("True Night's Piercer")
         Tooltip.SetDefault("'Find your own way to the Knife'");   
        }

		public override void SetDefaults() 
		{
			item.damage = 64;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 27;
			item.useAnimation = 27;
			item.useStyle = 1;
			item.knockBack = 7f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 50, 0, 0);
			item.rare = 7;
			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("TrueNightPiercerProj");
			item.shootSpeed = 20f;
            item.mana = 50;
            item.channel = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("NightPiercer"));
            recipe.AddIngredient(1570);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}