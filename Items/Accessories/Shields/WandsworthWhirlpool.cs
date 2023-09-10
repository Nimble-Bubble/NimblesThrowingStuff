using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.Items.Accessories.Shields
{
    public class WandsworthWhirlpool : ModItem
    {
        
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            /* Tooltip.SetDefault("The stinger stabs enemies on contact when guarding"
                +"\nSting damage is equal to damage taken by the user"); */
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 40;
            Item.height = 56;
            Item.value = Item.value = Item.buyPrice(0, 5, 40, 0);
            Item.rare = ItemRarityID.Orange;
            Item.defense = 4;
        }
        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            if (modPlayer.whichShield >= 1)
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
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.whichShield = 7;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<LagiacrusShell>(), 12);
            recipe.AddIngredient(ModContent.ItemType<BeastBone>(), 8);
            recipe.AddIngredient(ItemID.BeeWax, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
