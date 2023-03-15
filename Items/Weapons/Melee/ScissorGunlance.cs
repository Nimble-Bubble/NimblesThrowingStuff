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
	public class ScissorGunlance : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("Made from improved Hermitaur parts, this gunlance is admirable for its versatility."
				+"\nCritical strikes give you increased endurance for a short period of time.");
        }
        public override void SetDefaults() {
			Item.damage = 46;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.knockBack = 7f;
			Item.width = 20;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.buyPrice(0, 20, 0, 0);
            Item.DamageType = DamageClass.Melee;
			Item.channel = true;
            Item.shoot = ModContent.ProjectileType<ScissorGunlanceProj>();
            Item.shootSpeed = 12f;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup(nameof(ItemID.MythrilBar), 12);
			recipe.AddIngredient(ItemID.Bone, 10);
			recipe.AddIngredient(ModContent.ItemType<BoneClawLance>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		} //Recipe to be changed
	}
}