using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
 
namespace NimblesThrowingStuff.Tiles.Banners
{
    public class MimiclamBanner : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            disableSmartCursor = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Clam Banner");
            AddMapEntry(new Color(132, 132, 88), name); 
        }
 
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("MimiclamBannerItem"));
        }
 
        public override void NearbyEffects(int i, int j, bool closer)   
        {
            if (closer)          
            {
                Player player = Main.LocalPlayer;
                player.NPCBannerBuff[mod.NPCType("Mimiclam")] = true;	
                player.hasBanner = true;
            }
        }
    }
}
