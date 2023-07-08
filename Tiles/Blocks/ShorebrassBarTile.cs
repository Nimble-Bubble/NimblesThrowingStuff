using NimblesThrowingStuff.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
namespace NimblesThrowingStuff.Tiles.Blocks
{
    public class ShorebrassBarTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = false;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = false;
            Main.tileMergeDirt[Type] = false;
            ItemDrop/* tModPorter Note: Removed. Tiles and walls will drop the item which places them automatically. Use RegisterItemDrop to alter the automatic drop if necessary. */ = ModContent.ItemType<ShorebrassBar>();
            TileObjectData.newTile.StyleWrapLimit = 18;
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Procellarite Bar");
            AddMapEntry(new Color(0, 200, 185), name);
            MineResist = 1.5f;
            MinPick = 65;
            HitSound = SoundID.Dig;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}
