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
	public class TheFame : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.damage = 22;
			Item.width = 48;
			Item.height = 32;
			//Three round burst with no reuse delay, but "manual" operation
			Item.useTime = 4;
			Item.useAnimation = 12;
			//Item.reuseDelay = 0;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(0, 22, 50, 0);
			Item.rare = ItemRarityID.Pink;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item41;
			Item.shoot = ProjectileID.Bullet;
            Item.knockBack = 4.5f;
			Item.shootSpeed = 5.56f;
			Item.DamageType = DamageClass.Ranged;
			Item.autoReuse = false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FiberglassFishingPole);
			recipe.AddRecipeGroup(nameof(ItemID.MythrilBar), 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}