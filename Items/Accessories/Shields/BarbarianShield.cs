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
    //[AutoloadEquip(EquipType.Shield)]
    public class BarbarianShield : ModItem
    {
        
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 48;
            Item.height = 48;
            Item.value = Item.value = Item.buyPrice(0, 6, 25, 0);
            Item.rare = ItemRarityID.Orange;
            Item.defense = 3;
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
            modPlayer.whichShield = 1;
            player.GetDamage(DamageClass.Generic) += 0.1f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
