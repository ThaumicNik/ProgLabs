namespace Laba_3._3
{

    public class Program
    {
        static void Main()
        {
            GameManager.ClassSetup();
            while (GameManager.Active.State != "Quit")
            {
                GameManager.MainMenu();
            }
        }
    }
}
