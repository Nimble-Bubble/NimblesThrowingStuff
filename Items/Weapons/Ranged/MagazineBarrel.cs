using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using NimblesThrowingStuff.Items.Materials;
using Terraria.DataStructures;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class MagazineBarrel : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.damage = 8;
			Item.width = 64;
			Item.height = 32;
			Item.useTime = 1;
			Item.useAnimation = 7;
			Item.reuseDelay = 28;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.Green;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item36;
			Item.shoot = ProjectileID.Bullet;
            Item.knockBack = 5f;
			Item.shootSpeed = 4f;
			Item.DamageType = DamageClass.Ranged;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IllegalGunParts, 2);
			recipe.AddRecipeGroup(nameof(ItemID.GoldBar), 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}