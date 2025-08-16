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
	public class SacredGlider : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			//This is how much damage the Revolver does in Half-Life
			Item.damage = 40;
			Item.width = 58;
			Item.height = 26;
			//This gun is meant to resemble a Colt revolver, but I've decided to give it six-round autofire
			Item.useTime = 5;
			Item.useAnimation = 30;
			Item.reuseDelay = 15;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(0, 30, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item41;
			Item.shoot = ProjectileID.Bullet;
            Item.knockBack = 6f;
			Item.shootSpeed = 36f;
			Item.DamageType = DamageClass.Ranged;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Revolver);
			recipe.AddIngredient(ItemID.LihzahrdBrick, 100);
			recipe.AddIngredient(ItemID.BeetleHusk, 4);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}