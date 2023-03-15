using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using NimblesThrowingStuff.Projectiles.Melee;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;
using Terraria.Audio;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class LagiacrusBlade : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("A greatsword made using Lagiacrus materials."
				+"\nDanger: High voltage! Electricity still flows through Lagiacrus shell when separated from its source.");
        }
        public override void SetDefaults() {
			Item.damage = 28;
			Item.useStyle = 1;
			Item.useAnimation = 23;
			Item.useTime = 23;
			Item.knockBack = 5f;
			Item.width = 72;
			Item.height = 72;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.buyPrice(0, 15, 75, 0);
            Item.DamageType = DamageClass.Melee;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			for (int f = 0; f < 3; f++)
			{
				int zapIndex = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 226, 0f, 0f, 100, default(Color), 1f);
				Main.dust[zapIndex].velocity *= 6f;
			}
			if (Main.rand.NextBool(10) && !target.buffImmune[BuffID.Electrified])
			{
				for (int f = 0; f < 12; f++)
				{
					int zapIndex2 = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 226, 0f, 0f, 100, default(Color), 1.25f);
					Main.dust[zapIndex2].velocity *= 8f;
				}
				SoundEngine.PlaySound(SoundID.Item94);
				target.AddBuff(BuffID.Electrified, 450);
			}
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<LagiacrusShell>(), 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}