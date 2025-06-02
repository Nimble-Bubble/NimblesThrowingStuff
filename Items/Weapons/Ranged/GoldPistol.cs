using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class GoldPistol : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.damage = 12;
			Item.width = 34;
			Item.height = 24;
			Item.useTime = 26;
			Item.useAnimation = 26;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(0, 2, 40, 0);
			Item.rare = ItemRarityID.Blue;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item11;
			Item.shoot = ProjectileID.Bullet;
            Item.knockBack = 4f;
			Item.shootSpeed = 8f;
			Item.DamageType = DamageClass.Ranged;
		}
		/* public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.GoldBar, 10);
			recipe.AddIngredient(ItemID.Ruby, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		} */
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 4);
		}
	}
}