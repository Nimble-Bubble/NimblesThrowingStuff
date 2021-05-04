using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Magic;

namespace NimblesThrowingStuff.Items.Weapons.Magic
{
	public class RazorBolt : ModItem
	{
        public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Fires a wheel of rainwater");
            Item.staff[item.type] = true;
		}
		public override void SetDefaults() 
		{
			item.damage = 100;
			item.magic = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.knockBack = 8f;
            item.noMelee = true;
			item.value = Item.buyPrice(1, 0, 0, 0);
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item84;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<RazorboltProj>();
			item.shootSpeed = 7f;
            item.mana = 15;
		}
	}
}