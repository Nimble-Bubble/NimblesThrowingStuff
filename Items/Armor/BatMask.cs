using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class BatMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Tooltip.SetDefault("Increases throwing damage by 10%");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 15000;
            Item.rare = 1;
            Item.defense = 3; // The Defence value for this piece of armour.
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Throwing) += 0.1f;
        }
        public override void AddRecipes()
        {
            Recipe r = CreateRecipe();
            r.AddRecipeGroup(nameof(ItemID.GoldBar), 8);
            r.AddIngredient(ModContent.ItemType<BatFlesh>(), 6);
            r.AddTile(16);
            r.Register();
        }
    }
}