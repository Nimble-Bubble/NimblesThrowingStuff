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
	public class BoneClawLance : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("Made from Hermitaur parts, this weapon is more than adequate as a beginner's lance."
				+"\nCritical strikes give you increased endurance for a short period of time.");
        }
        public override void SetDefaults() {
			Item.damage = 26;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.knockBack = 7f;
			Item.width = 20;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.buyPrice(0, 1, 55, 0);
            Item.DamageType = DamageClass.Melee;
			Item.channel = true;
            Item.shoot = ModContent.ProjectileType<BoneClawLanceProj>();
            Item.shootSpeed = 11f;
			Item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Longhorn>());
			recipe.AddIngredient(ItemID.AntlionMandible, 6);
			recipe.AddIngredient(ModContent.ItemType<HermitaurShell>(), 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}