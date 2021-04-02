using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Melee;

namespace NimblesThrowingStuff.Items.Tools
{
	public class MeteoriteDrill : ModItem
	{
		public override void SetDefaults() 
		{
			item.damage = 13;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 3.5f;
			item.value = Item.buyPrice(0, 1, 50, 0);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.channel = true;
			item.autoReuse = true;
			item.noMelee = true;
			item.noUseGraphic = true;
            item.pick = 65;
			item.shoot = ModContent.ProjectileType<MeteoriteDrillProj>();
			item.shootSpeed = 30;
		}
        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}