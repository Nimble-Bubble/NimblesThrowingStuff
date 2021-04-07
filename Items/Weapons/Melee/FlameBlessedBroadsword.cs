using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class FlameBlessedBroadsword : ModItem
	{
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Flame-Blessed Broadsword");
        }
        public override void SetDefaults() {
			item.damage = 32;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 20;
			item.useTime = 20;
			item.knockBack = 5f;
			item.width = 66;
			item.height = 66;
			item.scale = 1.3f;
			item.rare = ItemRarityID.Orange;
			item.value = Item.buyPrice(0, 25, 0, 0);
            item.melee = true;
            item.shoot = ModContent.ProjectileType<FlameBlessedBeamProj>();
            item.shootSpeed = 12f;
			item.UseSound = SoundID.Item1;
		}
        public override void MeleeEffects(Player player, Rectangle hitbox) 
        {
			if (Main.rand.NextBool(3)) 
            {
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 6);
			}
		}
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.EnchantedSword);
			recipe.AddIngredient(ItemID.HellstoneBar, 15);
			recipe.AddIngredient(ItemID.Bone, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}