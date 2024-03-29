﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class TungstenKnife : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
		}
		public override void SetDefaults()
		{
			Item.damage = 13;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 26;
			Item.height = 26;
			Item.useTime = 21;
			Item.useAnimation = 21;
			Item.useStyle = 1;
			Item.knockBack = 4f;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 0, 4, 0);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("TungstenKnifeProj").Type;
			Item.shootSpeed = 8f;
			Item.consumable = true;
			Item.maxStack = 9999;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(ItemID.TungstenBar, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}