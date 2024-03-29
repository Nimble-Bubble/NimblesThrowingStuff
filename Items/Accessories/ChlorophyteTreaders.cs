  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Accessories
{
    [AutoloadEquip(EquipType.Shoes)]
    public class ChlorophyteTreaders : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            /* Tooltip.SetDefault("Allows super fast running and extra mobility on ice"
            + "\n20% increased movement speed"
            + "\nProvides the ability to walk on water, honey & lava"
            + "\nGrants immunity to fire blocks and lava damage"
            + "\nImproved, environment-friendly soles allow for mid-air hops and softer landings"); */
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 32;
            Item.height = 32;
            Item.value = Item.value = Item.buyPrice(0, 50, 0, 0);
            Item.rare = ItemRarityID.Yellow;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += 0.2f;
            player.accRunSpeed = 9f;
            player.rocketBoots = 3;
            player.lavaImmune = true;
            player.buffImmune[BuffID.OnFire] = true;
            player.fireWalk = true;
            player.waterWalk = true;
            player.iceSkate = true;
            player.GetJumpState(ExtraJump.SandstormInABottle).Enable();
            player.GetJumpState(ExtraJump.BlizzardInABottle).Enable();
            player.GetJumpState(ExtraJump.CloudInABottle).Enable();
            player.jumpBoost = true;
            player.noFallDmg = true;
        }
        public override void AddRecipes() 
        {
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TerrasparkBoots);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
            recipe.AddIngredient(ItemID.BundleofBalloons);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TerrasparkBoots);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
            recipe.AddIngredient(ItemID.BundleofBalloons);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}