using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Magic;

namespace NimblesThrowingStuff.Items.Weapons.Magic
{
	public class StormShot : ModItem
	{
        public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Fires a ball of acid rain");
            Item.staff[item.type] = false;
		}
		public override void SetDefaults() 
		{
			item.damage = 170;
			item.magic = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 11;
			item.useAnimation = 11;
			item.useStyle = 5;
			item.knockBack = 4f;
            item.noMelee = true;
			item.value = Item.buyPrice(1, 0, 0, 0);
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item61;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<StormShotBall>();
			item.shootSpeed = 13f;
            item.mana = 12;
		}
	}
}