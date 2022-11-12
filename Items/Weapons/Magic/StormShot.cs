using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Magic;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Magic
{
	public class StormShot : ModItem
	{
        public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("Fires a ball of acid rain");
            Item.staff[Item.type] = false;
		}
		public override void SetDefaults() 
		{
			Item.damage = 170;
			Item.DamageType = DamageClass.Magic;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 11;
			Item.useAnimation = 11;
			Item.useStyle = 5;
			Item.knockBack = 4f;
            Item.noMelee = true;
			Item.value = Item.buyPrice(1, 0, 0, 0);
			Item.rare = ItemRarityID.Purple;
			Item.UseSound = SoundID.Item61;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<StormShotBall>();
			Item.shootSpeed = 13f;
            Item.mana = 12;
		}
	}
}