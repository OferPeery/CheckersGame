using System;
using System.Windows.Forms;

namespace CheckersGame.UI
{
    // $G$ SFN-012 (+5) Bonus: Events in the Logic layer are handled by the UI.
    // $G$ SFN-013 (+5) Bonus: Richer graphic for the game (photos for the 'X' and 'O').
    public class Program
    {
        public static void Main()
        {
            Application.EnableVisualStyles();
            UIFlow.Run();
        }
    }
}