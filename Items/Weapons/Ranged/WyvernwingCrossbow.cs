using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class WyvernwingCrossbow : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 40;
			Item.width = 56;
			Item.height = 20;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.LightRed;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
			Item.shoot = 5;
            Item.knockBack = 5f;
			Item.shootSpeed = 15f;
			Item.DamageType = DamageClass.Ranged;
			Item.autoReuse = true;
			Item.crit = 15;
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.WoodenArrowFriendly)
			{
				type = ProjectileID.JestersArrow;
			}
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SoulofFlight, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}