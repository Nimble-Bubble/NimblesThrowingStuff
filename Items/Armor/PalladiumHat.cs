using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class PalladiumHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            // DisplayName.SetDefault("Palladium Hat");
                // Tooltip.SetDefault("Increases thrown critical strike chance by 7% and thrown damage by 13%");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 14;
            Item.value = 75000;
            Item.rare = ItemRarityID.LightRed;
            Item.defense = 7; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.PalladiumBreastplate && legs.type == ItemID.PalladiumLeggings;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increased life regeneration";
            player.onHitRegen = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Throwing) += 0.13f;
            player.GetCritChance(DamageClass.Throwing) += 6;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(1184, 12);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}