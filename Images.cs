using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProbaNumer2
{
    public static class Images
    {

        public readonly static ImageSource Food = LoadImage("Food.png");
        public readonly static ImageSource BBishop = LoadImage("BBishop.png");
        public readonly static ImageSource WBishop = LoadImage("WBishop.png");
        public readonly static ImageSource WKnight = LoadImage("WKnight.png");
        public readonly static ImageSource BKnight = LoadImage("BKnight.png");
        public readonly static ImageSource WKing = LoadImage("WKing.png");
        public readonly static ImageSource BKing = LoadImage("BKing.png");
        public readonly static ImageSource WPawn = LoadImage("WPawn.png");
        public readonly static ImageSource BPawn = LoadImage("BPawn.png");
        public readonly static ImageSource WRook = LoadImage("WRook.png");
        public readonly static ImageSource BRook = LoadImage("BRook.png");
        public readonly static ImageSource WQueen = LoadImage("WQueen.png");
        public readonly static ImageSource BQueen = LoadImage("BQueen.png");




        private static ImageSource LoadImage(string fileName)
        {

            return new BitmapImage(new Uri($"Assets/{fileName}", UriKind.Relative));

        }

    }



}
