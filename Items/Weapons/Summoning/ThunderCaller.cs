using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using NimblesThrowingStuff.Projectiles.Summoning;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;
using Terraria.Audio;

namespace NimblesThrowingStuff.Items.Weapons.Summoning
{
	public class ThunderCaller : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("Made from Lagiacrus parts, this glaive brings an electrifying kick to one's moves."
				+"\nLeft click to swing the glaive in a circle"
				+"\nRight click to thrust the glaive out"
				+"\nGuard and left click to use the full glaive as a broadsword?"
				+"\nGuard and right click to fire a thunderbug that chases enemies");
        }
        public override void SetDefaults() {
			Item.damage = 32;
			Item.useStyle = 1;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.knockBack = 6f;
			Item.width = 72;
			Item.height = 72;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.buyPrice(0, 15, 75, 0);
            Item.DamageType = DamageClass.Summon;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.noUseGraphic = true;
			Item.shoot = ModContent.ProjectileType<ThunderCallerProj>();
			Item.shootSpeed = 8f;
			Item.channel = true;
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