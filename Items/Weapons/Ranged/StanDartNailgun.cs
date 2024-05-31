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
	public class StanDartNailgun : ModItem
	{
		SoundStyle UKNailgunFire = new SoundStyle("NimblesThrowingStuff/Sounds/Item/UKNailgunFire");
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.width = 102;
			Item.height = 36;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(0, 2, 50, 0);
			Item.rare = ItemRarityID.Green;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Dart;
			Item.UseSound = UKNailgunFire;
			Item.shoot = ProjectileID.NailFriendly;
            Item.knockBack = 3f;
			Item.shootSpeed = 11f;
			Item.DamageType = DamageClass.Ranged;
			Item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AshBlock, 100);
			recipe.AddIngredient(ItemID.AshBlock, 100);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-12, 0);
		}
	}
}