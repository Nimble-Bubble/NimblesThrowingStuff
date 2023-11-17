using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class StingerSpear : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			// Tooltip.SetDefault("Has a chance to poison enemies");
        }
        public override void SetDefaults() {
			Item.damage = 24;
			Item.useStyle = 5;
			Item.useAnimation = 38;
			Item.useTime = 38;
			Item.knockBack = 5.5f;
			Item.width = 64;
			Item.height = 64;
			Item.shoot = ModContent.ProjectileType<StingerSpearProj>();
            Item.shootSpeed = 3.25f;
			Item.rare = ItemRarityID.Green;
            Item.noUseGraphic = true;
            Item.noMelee = true;
			Item.value = Item.sellPrice(silver: 54);
            Item.DamageType = DamageClass.Melee;
			Item.UseSound = SoundID.Item1;
		}
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.JungleSpores, 12);
            recipe.AddIngredient(ItemID.Stinger, 4);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}