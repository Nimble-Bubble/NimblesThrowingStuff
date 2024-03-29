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
    [AutoloadEquip(EquipType.Body)]
    public class RathalosMail : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            /* Tooltip.SetDefault("Increases damage by 5%"
                +"\nGrants 3 seconds of lava immunity"); */
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 26;
            Item.value = 36000;
            Item.rare = ItemRarityID.Orange;
            Item.defense = 8; 
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.05f;
            player.lavaMax += 180;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HellstoneBar, 12);
            recipe.AddIngredient(ModContent.ItemType<RedRathScale>(), 12);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}