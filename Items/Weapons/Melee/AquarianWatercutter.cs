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
	public class AquarianWatercutter : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("Fires a jet of water upon hitting a target");
        }
        public override void SetDefaults() {
			Item.damage = 90;
			Item.useStyle = 1;
			Item.useAnimation = 32;
			Item.useTime = 32;
			Item.knockBack = 6.5f;
			Item.width = 80;
			Item.height = 80;
			Item.rare = ItemRarityID.Yellow;
            Item.noUseGraphic = false;
            Item.noMelee = false;
			Item.value = Item.buyPrice(0, 27, 50, 0);
            Item.DamageType = DamageClass.Melee;
			Item.UseSound = SoundID.Item81;
			Item.autoReuse = true;
			Item.scale = 1.2f;
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