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
    public class AdamantiteHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            // DisplayName.SetDefault("Adamantite Hat");
                // Tooltip.SetDefault("Increases thrown damage by 24% and thrown critical strike chance by 8%");
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 14;
            Item.value = 150000;
            Item.rare = ItemRarityID.LightRed;
            Item.defense = 10; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.AdamantiteBreastplate && legs.type == ItemID.AdamantiteLeggings;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "33% chance to not consume weapons";
            player.ThrownCost33 = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Throwing) += 0.24f;
            player.GetCritChance(DamageClass.Throwing) += 8;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(391, 12);
            recipe.AddTile(134);
            recipe.Register();
        }
    }
}