using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Items.Accessories;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Accessories
{
    public class AvengerWristband : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            /* Tooltip.SetDefault("Thrown critical strikes cause holy stars to fall down"
                              +"\n25% increased throwing velocity and 12% increased thrown damage"); */
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 28;
            Item.height = 20;
            Item.value = Item.buyPrice(0, 25, 0, 0);
            Item.rare = ItemRarityID.LightPurple;
            Item.expert = false;
        }
        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            if (modPlayer.sacredWrist)
            {
                return false;
            }
            else
            {
                return true;
            }
        } 
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<NimblesPlayer>().sacredWrist = true;
            player.ThrownVelocity += 0.25f;
            player.GetDamage(DamageClass.Throwing) += 0.12f;
        }
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SacredWristband>()); 
            recipe.AddIngredient(ItemID.AvengerEmblem, 1);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
            recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SacredWristband>());
            recipe.AddIngredient(ItemID.AvengerEmblem, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
