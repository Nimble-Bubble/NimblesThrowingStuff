using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class VenomousArachknife : ModItem
	{
        public override void SetStaticDefaults()
        {
         Tooltip.SetDefault("This knife sticks to enemies");   
        }

		public override void SetDefaults() 
		{
			item.damage = 48;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = 1;
			item.knockBack = 8f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 16, 0, 0);
			item.rare = 6;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("VenomousArachknifeProj");
			item.shootSpeed = 12f;
            item.mana = 12;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Arachknife"));
            recipe.AddIngredient(1006, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}