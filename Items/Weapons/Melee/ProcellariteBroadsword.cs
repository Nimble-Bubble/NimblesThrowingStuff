using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class ProcellariteBroadsword : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.damage = 240;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 21;
			Item.useTime = 21;
			Item.knockBack = 8f;
			Item.width = 90;
			Item.height = 90;
			Item.scale = 1.5f;
			Item.rare = ItemRarityID.Purple;
			Item.value = Item.buyPrice(1, 0, 0, 0);
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<ProcellariteBroadswordProj>();
            Item.shootSpeed = 11f;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
		}
        public override void MeleeEffects(Player player, Rectangle hitbox) 
        {
			if (Main.rand.NextBool(3)) 
            {
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 174);
			}
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ProcellariteBar>(), 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}