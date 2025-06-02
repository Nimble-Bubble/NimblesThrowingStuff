using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class PlatinumPistol : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.damage = 13;
			Item.width = 34;
			Item.height = 24;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(0, 3, 0, 0);
			Item.rare = ItemRarityID.Blue;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item11;
			Item.shoot = ProjectileID.Bullet;
            Item.knockBack = 4f;
			Item.shootSpeed = 8.5f;
			Item.DamageType = DamageClass.Ranged;
		}
		/* public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PlatinumBar, 10);
			recipe.AddIngredient(ItemID.Diamond, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		} */
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 4);
		}
	}
}