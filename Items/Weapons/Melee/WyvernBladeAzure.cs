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
	public class WyvernBladeAzure : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults() {
			Item.damage = 104;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 18;
			Item.useTime = 18;
			Item.knockBack = 4.5f;
			Item.width = 120;
			Item.height = 120;
			Item.scale = 1.25f;
			Item.rare = ItemRarityID.Yellow;
			Item.value = Item.buyPrice(0, 50, 0, 0);
            Item.DamageType = DamageClass.Melee;
			Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
			Item.crit = 24;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox) 
        {
			if (Main.rand.NextBool(5)) 
            {
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 59);
			}
		}
		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (!target.buffImmune[BuffID.OnFire])
			{
				for (int f = 0; f < 9; f++)
				{
					int fireIndex2 = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 59, 0f, 0f, 100, default(Color), 3f);
					Main.dust[fireIndex2].velocity *= 6f;
				}
				SoundEngine.PlaySound(SoundID.Item88);
				target.AddBuff(BuffID.Frostburn2, 400);
			}
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SpectreBar, 15);
			recipe.AddIngredient(ModContent.ItemType<WyvernBladeFall>());
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}