  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Accessories
{
    [AutoloadEquip(EquipType.Shoes)]
    public class ChlorophyteTreaders : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Allows super fast running and extra mobility on ice"
            + "\n20% increased movement speed"
            + "\nProvides the ability to walk on water, honey & lava"
            + "\nGrants immunity to fire blocks and 7 seconds of immunity to lava"
            + "\nImproved, environment-friendly soles allow for mid-air hops and softer landings");
        }
        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 22;
            item.height = 22;
            item.value = item.value = Item.buyPrice(0, 50, 0, 0);
            item.rare = ItemRarityID.Yellow;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += 0.2f;
            player.accRunSpeed = 9f;
            player.rocketBoots = 3;
            player.lavaMax += 420;
            player.fireWalk = true;
            player.waterWalk = true;
            player.iceSkate = true;
            player.doubleJumpSandstorm = true;
            player.doubleJumpBlizzard = true;
            player.doubleJumpCloud = true;
            player.jumpBoost = true;
            player.noFallDmg = true;
        }
        public override void AddRecipes() 
        {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrostsparkBoots);
            recipe.AddIngredient(ItemID.LavaWaders);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
            recipe.AddIngredient(ItemID.BundleofBalloons);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}