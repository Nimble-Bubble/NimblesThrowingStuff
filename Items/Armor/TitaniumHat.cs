using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class TitaniumHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Titanium Hat");
                Tooltip.SetDefault("Increases thrown damage by 21% and thrown critical strike chance by 8%");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = 150000;
            item.rare = 4;
            item.defense = 11; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.TitaniumBreastplate && legs.type == ItemID.TitaniumLeggings;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Some attacks give you a free shadow dodge";
            player.onHitDodge = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.21f;
            player.thrownCrit += 8;
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.thrownSpeed += 0.1f;
        }


        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(1198, 13);
            r.AddTile(134);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}