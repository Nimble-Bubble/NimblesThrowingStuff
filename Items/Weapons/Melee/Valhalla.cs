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
	public class Valhalla : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("Its point is still rather small, but can you really say it's weak anymore? \nCauses enemies to bleed upon impact.");
		}
		public override void SetDefaults()
		{
			Item.damage = 41;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 19;
			Item.useTime = 19;
			Item.knockBack = 9f;
			Item.width = 20;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.buyPrice(0, 18, 75, 0);
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
			Item.shoot = ModContent.ProjectileType<ValhallaProj>();
			Item.shootSpeed = 15f;
			Item.UseSound = SoundID.Item1;
			Item.crit = 20;
			Item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Estoc>(), 1);
			recipe.AddRecipeGroup(nameof(ItemID.AdamantiteBar), 12);
			recipe.AddIngredient(ItemID.UnicornHorn, 3);
			recipe.AddIngredient(ItemID.CrystalShard, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}