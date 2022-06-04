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
			Item.damage = 13;
			Item.DamageType = DamageClass.Melee;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3.5f;
			Item.value = Item.buyPrice(0, 1, 50, 0);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.channel = true;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;
            Item.pick = 64;
			Item.shoot = ModContent.ProjectileType<MeteoriteDrillProj>();
			Item.shootSpeed = 30;
		}
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MeteoriteBar, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.Register();
		}
	}
}