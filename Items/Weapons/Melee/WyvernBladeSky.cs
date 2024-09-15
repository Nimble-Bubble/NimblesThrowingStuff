using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using System;
using NimblesThrowingStuff.Projectiles.Melee;
using Terraria.GameContent.Creative;
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class WyvernBladeSky : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults() {
			Item.damage = 40;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 10;
			Item.useTime = 10;
			Item.knockBack = 5f;
			Item.width = 64;
			Item.height = 64;
			Item.scale = 1f;
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.buyPrice(0, 16, 0, 0);
            Item.DamageType = DamageClass.Melee;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileID.Muramasa;
			Item.shootSpeed = 16f;
			Item.autoReuse = true;
		}
        public override void MeleeEffects(Player player, Rectangle hitbox) 
        {
			if (Main.rand.NextBool(5)) 
            {
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 116);
			}
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<WyvernBladeFall>());
            recipe.AddIngredient(ItemID.SoulofFlight, 12);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
            recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<WyvernBladeLeaf>());
            recipe.AddIngredient(ItemID.SoulofFlight, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
	}
}