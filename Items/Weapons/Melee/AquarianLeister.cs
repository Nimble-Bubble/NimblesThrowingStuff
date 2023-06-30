using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class AquarianLeister : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("Fires three bubbles in a spread");
        }
        public override void SetDefaults() {
			Item.damage = 75;
			Item.useStyle = 5;
			Item.useAnimation = 22;
			Item.useTime = 22;
			Item.knockBack = 5f;
			Item.width = 50;
			Item.height = 50;
			Item.shoot = ModContent.ProjectileType<AquarianLeisterProj>();
            Item.shootSpeed = 7.25f;
			Item.rare = ItemRarityID.Yellow;
            Item.noUseGraphic = true;
            Item.noMelee = true;
			Item.value = Item.buyPrice(0, 27, 50, 0);
            Item.DamageType = DamageClass.Melee;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<RoyalFin>(), 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}