using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using NimblesThrowingStuff.Items.Materials;
using NimblesThrowingStuff.Tiles.Furniture;
using Terraria.DataStructures;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class MeteorCannon : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.damage = 55;
			Item.width = 70;
			Item.height = 20;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(0, 2, 25, 0);
			Item.rare = ItemRarityID.Orange;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Dart;
			Item.UseSound = SoundID.Item89;
			Item.shoot = ProjectileID.PoisonDartBlowgun;
            Item.knockBack = 5f;
			Item.shootSpeed = 16f;
			Item.DamageType = DamageClass.Ranged;
			Item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MeteoriteBar, 20);
			recipe.AddIngredient(ItemID.HellstoneBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-16, -4);
		}
	}
}