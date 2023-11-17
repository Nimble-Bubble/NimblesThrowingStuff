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
	public class FrostIcicle : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			/* Tooltip.SetDefault("A metallic lance with an icy edge."
				+"\nIts frostburn-inducing edge ensures the most bang for your buck."); */
		}
		public override void SetDefaults()
		{
			Item.damage = 56;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.knockBack = 5.5f;
			Item.width = 72;
			Item.height = 72;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.buyPrice(0, 17, 50, 0);
			Item.DamageType = DamageClass.Melee;
			// Item.channel = true;
			Item.shoot = ModContent.ProjectileType<FrostIcicleProj>();
			Item.shootSpeed = 13.5f;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
		}
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<KnightLance>(), 1);
			recipe.AddRecipeGroup(nameof(ItemID.AdamantiteBar), 15);
			recipe.AddIngredient(ItemID.FrostCore);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}