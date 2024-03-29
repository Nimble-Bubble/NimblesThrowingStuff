using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Magic;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Magic
{
	public class RazorBolt : ModItem
	{
        public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			// Tooltip.SetDefault("Fires a wheel of rainwater");
            Item.staff[Item.type] = true;
		}
		public override void SetDefaults() 
		{
			Item.damage = 100;
			Item.DamageType = DamageClass.Magic;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 5;
			Item.knockBack = 8f;
            Item.noMelee = true;
			Item.value = Item.buyPrice(1, 0, 0, 0);
			Item.rare = ItemRarityID.Red;
			Item.UseSound = SoundID.Item84;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<RazorboltProj>();
			Item.shootSpeed = 7f;
            Item.mana = 15;
		}
	}
}