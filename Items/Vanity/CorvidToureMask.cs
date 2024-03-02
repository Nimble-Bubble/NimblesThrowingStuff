using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class CorvidToureMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 26;
            Item.value = 4065;
            Item.rare = ItemRarityID.Blue;
            Item.vanity = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BlackThread, 3);
            recipe.AddIngredient(ItemID.Feather, 10);
            recipe.AddIngredient(ItemID.Bone, 5);
            recipe.AddIngredient(ItemID.FossilOre, 8);
            recipe.AddIngredient(ItemID.Lens, 2);
            recipe.AddTile(TileID.Loom);
            recipe.Register();
        }
    }
}