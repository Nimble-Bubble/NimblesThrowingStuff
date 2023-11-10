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

namespace NimblesThrowingStuff.Items.Accessories.Shields
{
    [AutoloadEquip(EquipType.Shield)]
    public class GateguardShield : ModItem
    {
        
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            // Based on the Shield for the Paladin Lance, but the Paladin Shield is already a thing
            // "Gateguard" taken from the meaning of the name Babel/Babylon: "Gate of God"
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 28;
            Item.height = 28;
            Item.value = Item.value = Item.buyPrice(0, 2, 70, 0);
            Item.rare = ItemRarityID.Blue;
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
            modPlayer.whichShield = 15;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MeteoriteBar, 10);
            recipe.AddIngredient(ModContent.ItemType<IronShield>());
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
